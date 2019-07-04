using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using MoreLinq.Extensions;

namespace ExeDiff {
	struct Insn {
		public ulong PC;
		public byte NZCV;
		public ulong[] X;
		public ulong[] V;
		public ulong SP;

		public static Insn Read(BinaryReader br) =>
			new Insn {
				PC = br.ReadUInt64(), 
				NZCV = br.ReadByte(), 
				X = Enumerable.Range(0, 31).Select(_ => br.ReadUInt64()).ToArray(), 
				V = Enumerable.Range(0, 32).Select(_ => br.ReadUInt64()).ToArray(), 
				SP = br.ReadUInt64()
			};
	}
		
	class Program {
		static IEnumerable<Insn> Read(string fn, long skip) {
			using var fp = File.OpenRead(fn);
			using var br = new BinaryReader(fp);
			fp.Position = skip * (8 * 33 + 8 * 32 + 1);
			var len = fp.Length;
			while(fp.Position < len)
				yield return Insn.Read(br);
		}
		
		static void Main(string[] args) {
			var skip = 129000000L;
			var a = Read("../App/uniinsns.bin", skip);
			var b = Read("../App/recinsns.bin", skip);
			
			"Diffing".Debug();

			var count = skip;
			var last = new Insn();
			foreach(var (i, j) in a.Zip(b)) {
				count++;
				if(count % 100000 == 0)
					count.Debug();
				if(
					i.PC == j.PC &&
					(i.NZCV == j.NZCV || count < 1000) &&
					i.SP == j.SP &&
					i.X.SequenceEqual(j.X) && 
					i.V.SequenceEqual(j.V) || 
					last.X == null
				) {
					last = i;
					continue;
				}

				"DIVERGENCE".Debug();
				if(i.PC != j.PC)
					$"PC  {i.PC:X} vs {j.PC:X}".Debug();
				else
					$"PC  {i.PC:X}".Debug();
				if(i.NZCV != j.NZCV)
					$"NZCV  {i.NZCV:X} vs {j.NZCV:X}".Debug();
				if(i.SP != j.SP)
					$"SP  {i.SP:X} vs {j.SP:X}".Debug();
				i.X.Zip(j.X).ForEach((x, o) => {
					if(x.First != x.Second)
						$"X{o}  {x.First:X} vs {x.Second:X}".Debug();
				});
				i.V.Zip(j.V).ForEach((x, o) => {
					if(x.First != x.Second)
						$"V{o}  {x.First:X} vs {x.Second:X}".Debug();
				});
				"".Debug();
				"Previous instruction:".Debug();
				$"PC  {last.PC:X}".Debug();
				$"NZCV  {last.NZCV:X}".Debug();
				$"SP  {last.SP:X}".Debug();
				for(var x = 0; x < 31; ++x)
					$"X{x}  {last.X[x]:X}".Debug();
				break;
			}
		}
	}
}