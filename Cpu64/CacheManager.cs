using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Common;
using PrettyPrinter;

namespace Cpu64 {
	public unsafe delegate void BlockFunc(CpuState* state, BaseCpu cpu);
	public unsafe delegate void LlvmBlockFunc(CpuState* state, LlvmCallbacks* callbacks);
	
	public class Block {
		public readonly ulong Addr;
		public BlockFunc Func;

		byte[] _ObjectCode;
		public byte[] ObjectCode {
			get => _ObjectCode;
			set {
				_ObjectCode = value;
				CacheManager.NeedCacheToDisk.Enqueue(this);
			}
		}
		public ulong HitCount; // WARNING: There is no lock for this so cannot be 100% relied upon
		public bool Optimized;

		public Block(ulong addr) => Addr = addr;
	}
	
	public static class CacheManager {
		static readonly Dictionary<ulong, Block> Blocks = new Dictionary<ulong, Block>();
		internal static readonly Queue<Block> NeedCacheToDisk = new Queue<Block>();
		static FileStream CacheFile;
		static BinaryWriter CacheWriter;

		public static unsafe void LoadCache() {
			try {
				using var fp = File.OpenRead("cache.bin");
				var length = fp.Length;
				using var br = new BinaryReader(fp);
				var cr = new CoffReader();
				while(fp.Position < length) {
					var addr = br.ReadUInt64();
					//$"Loading block {addr:X}".Print();
					var size = (int) br.ReadUInt64();
					var code = br.ReadBytes(size);
					/*using var ofp = File.OpenWrite($"_{addr:X}.o");
					ofp.Write(code);*/
					var loadAddr = cr.Load(code, addr);
					if(loadAddr == null) continue;
					var block = GetBlock(addr);
					var tfunc = Marshal.GetDelegateForFunctionPointer<LlvmBlockFunc>((IntPtr) loadAddr);
					block.Func = (state, _) => {
						//Console.WriteLine($"Running block {addr:X}");
						tfunc(state, LlvmRecompiler.Callbacks);
					};
					block.Optimized = true;
				}
			} catch(FileNotFoundException) {}

			CacheFile = File.Open("cache.bin", FileMode.Append, FileAccess.Write);
			CacheWriter = new BinaryWriter(CacheFile);
		}
		
		public static void Clear() {
			lock(Blocks)
				Blocks.Clear();
		}

		public static void StartOptimizer(IKernel kernel) => new Thread(() => Optimizer(kernel)).Start();
		static void Optimizer(IKernel kernel) {
			if(CacheFile == null) throw new Exception();
			
			var recompiler = new LlvmRecompiler(kernel);
			while(true) {
				Block candidate = null;
				lock(Blocks)
					foreach(var block in Blocks.Values)
						if(!block.Optimized && block.Addr != 0x740008FD7C && block.HitCount > 5 && (candidate == null || block.HitCount > candidate.HitCount))
							candidate = block;
				if(candidate == null) {
					if(!TryCacheToDisk())
						Thread.Sleep(100);
					continue;
				}

				candidate.Optimized = true;
				recompiler.RecompileMultiple(candidate);
				//Console.WriteLine($"Optimized 0x{candidate.Addr:X} with {candidate.HitCount} hits!");
				TryCacheToDisk();
			}
		}

		static bool TryCacheToDisk() {
			if(NeedCacheToDisk.Count == 0) return false;

			while(NeedCacheToDisk.TryDequeue(out var block)) {
				CacheWriter.Write(block.Addr);
				CacheWriter.Write((ulong) block.ObjectCode.Length);
				CacheWriter.Write(block.ObjectCode);
			}
			CacheWriter.Flush();
			
			return true;
		}

		public static Block GetBlock(ulong addr) {
			lock(Blocks)
				return Blocks.TryGetValue(addr, out var block) ? block : Blocks[addr] = new Block(addr);
		}
	}
}