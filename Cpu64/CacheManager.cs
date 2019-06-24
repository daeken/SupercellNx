using System.Collections.Generic;

namespace Cpu64 {
	public static class CacheManager {
		static readonly Dictionary<ulong, Block> Blocks = new Dictionary<ulong, Block>();
		
		public static Block GetBlock(ulong addr) {
			lock(Blocks)
				return Blocks.TryGetValue(addr, out var block) ? block : Blocks[addr] = new Block(addr);
		}
	}
}