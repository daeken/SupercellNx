using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Cpu64 {
	public class Block {
		public readonly ulong Addr;
		public Action<Dynarec> Func;
		public ulong HitCount; // WARNING: There is no lock for this so cannot be 100% relied upon
		public bool Optimized;

		public Block(ulong addr) => Addr = addr;
	}
	
	public static class CacheManager {
		static readonly Dictionary<ulong, Block> Blocks = new Dictionary<ulong, Block>();
		static readonly Recompiler Recompiler = new Recompiler();
		
		//static CacheManager() => StartOptimizer();

		public static void StartOptimizer() => new Thread(Optimizer).Start();
		static void Optimizer() {
			while(true) {
				Block candidate = null;
				lock(Blocks)
					foreach(var block in Blocks.Values)
						if(!block.Optimized && block.HitCount > 1000 && (candidate == null || block.HitCount > candidate.HitCount))
							candidate = block;
				if(candidate == null) {
					Thread.Sleep(100);
					continue;
				}

				candidate.Optimized = true;
				Recompiler.RecompileMultiple(candidate);
			}
		}

		public static Block GetBlock(ulong addr) {
			lock(Blocks)
				return Blocks.TryGetValue(addr, out var block) ? block : Blocks[addr] = new Block(addr);
		}
	}
}