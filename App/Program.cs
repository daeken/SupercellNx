using System;
using System.IO;
using Common;
using Cpu64;

namespace App {
	class Program {
		static void Main(string[] args) {
			var main = Nxo.Load(File.OpenRead(args[0]));
			var data = main.Data;
			using var ms = new MemoryStream(data);
			using var br = new BinaryReader(ms);
			var cpu = new Interpreter();
			for(var i = 0; i < 32; ++i)
				cpu.X[i] = 0xDE000000 | (ulong) (i << 16);
			var addr = 0x7100000024UL;
			br.At(0x24);
			for(var i = 0; i < 8; ++i) {
				var inst = br.ReadUInt32();
				var asm = cpu.Disassemble(inst, addr);
				if(asm == null) {
					$"Disassembly failed at {addr:X} --- {inst:X8}".Debug();
					break;
				}
				asm.Debug();
				cpu.Interpret(inst, addr);
				addr += 4;
			}
		}
	}
}