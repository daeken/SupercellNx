using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common;

namespace Cpu64 {
	public unsafe delegate void BlockFunc(CpuState* state, BaseCpu cpu);
	public unsafe delegate void LlvmBlockFunc(CpuState* state, LlvmCallbacks* callbacks);
	
	public class Block {
		public readonly ulong Addr;
		public BlockFunc Func;
		public ulong HitCount; // WARNING: There is no lock for this so cannot be 100% relied upon
		public bool Optimized;

		public Block(ulong addr) => Addr = addr;
	}
	
	public static class CacheManager {
		static readonly Dictionary<ulong, Block> Blocks = new Dictionary<ulong, Block>();
		
		public static void Clear() {
			lock(Blocks)
				Blocks.Clear();
		}

		public static void StartOptimizer(IKernel kernel) => new Thread(() => Optimizer(kernel)).Start();
		static void Optimizer(IKernel kernel) {
			var recompiler = new LlvmRecompiler(kernel);
			while(true) {
				Block candidate = null;
				lock(Blocks)
					foreach(var block in Blocks.Values)
						if(!block.Optimized && block.Addr != 0x740008FD7C && block.HitCount > 2000 && (candidate == null || block.HitCount > candidate.HitCount))
							candidate = block;
				if(candidate == null) {
					Thread.Sleep(100);
					continue;
				}

				candidate.Optimized = true;
				recompiler.RecompileMultiple(candidate);
				//Console.WriteLine($"Optimized 0x{candidate.Addr:X} with {candidate.HitCount} hits!");
			}
		}

		public static Block GetBlock(ulong addr) {
			lock(Blocks)
				return Blocks.TryGetValue(addr, out var block) ? block : Blocks[addr] = new Block(addr);
		}
	}
}