using System.Linq;

namespace Supercell.Gpu {
	public class GpuVmm {
		public const long AddrSize = 1L << 40;

		const int PtLvl0Bits = 14;
		const int PtLvl1Bits = 14;
		const int PtPageBits = 12;

		const int PtLvl0Size = 1 << PtLvl0Bits;
		const int PtLvl1Size = 1 << PtLvl1Bits;
		public const ulong PageSize = 1UL << PtPageBits;

		const int PtLvl0Mask = PtLvl0Size - 1;
		const int PtLvl1Mask = PtLvl1Size - 1;
		public const ulong PageMask = PageSize - 1;

		const int PtLvl0Bit = PtPageBits + PtLvl1Bits;
		const int PtLvl1Bit = PtPageBits;
		
		public readonly ulong[][] Pagetable = new ulong[PtLvl0Size][];

		public const ulong PteUnmapped = ulong.MaxValue;
		public const ulong PteReserved = ulong.MaxValue - 1;

		bool PageInUse(ulong addr) {
			if(addr >> (PtLvl0Bits + PtLvl1Bits + PtPageBits) != 0)
				return false;
			var l0 = (addr >> PtLvl0Bit) & PtLvl0Mask;
			var l1 = (addr >> PtLvl1Bit) & PtLvl1Mask;
			if(Pagetable[l0] == null)
				return false;
			return Pagetable[l0][l1] != PteUnmapped;
		}

		public ulong Map(ulong physAddr, ulong virtAddr, ulong size) {
			lock(Pagetable)
				for(var offset = 0UL; offset < size; offset += PageSize)
					SetPte(virtAddr + offset, physAddr + offset);
			return virtAddr;
		}

		public ulong Map(ulong physAddr, ulong size) {
			lock(Pagetable) {
				var virtAddr = GetFreePosition(size);
				if(virtAddr == ulong.MaxValue) return ulong.MaxValue;
				for(var offset = 0UL; offset < size; offset += PageSize)
					SetPte(virtAddr + offset, physAddr + offset);
				return virtAddr;
			}
		}

		void SetPte(ulong position, ulong target) {
			var l0 = (position >> PtLvl0Bit) & PtLvl0Mask;
			var l1 = (position >> PtLvl1Bit) & PtLvl1Mask;
			if(Pagetable[l0] == null)
				Pagetable[l0] = Enumerable.Range(0, PtLvl1Size).Select(_ => PteUnmapped).ToArray();
			Pagetable[l0][l1] = target;
		}

		public ulong ReserveFixed(ulong addr, ulong size) {
			lock(Pagetable) {
				for(var offset = 0UL; offset < size; offset += PageSize)
					if(PageInUse(addr + offset))
						return ulong.MaxValue;
				for(var offset = 0UL; offset < size; offset += PageSize)
					SetPte(addr + offset, PteReserved);
			}
			return addr;
		}

		public ulong Reserve(ulong size, ulong align) {
			lock(Pagetable) {
				var position = GetFreePosition(size, align);
				if(position != ulong.MaxValue)
					for(var offset = 0UL; offset < size; offset += PageSize)
						SetPte(position + offset, PteReserved);
				return position;
			}
		}

		ulong GetFreePosition(ulong size, ulong align = 1, ulong start = 1UL << 32) {
			var position = start;
			var freeSize = 0UL;
			if(align < 1)
				align = 1;
			align = (align + PageSize) & ~PageMask;
			while(position + freeSize < AddrSize) {
				if(!PageInUse(position + freeSize)) {
					freeSize += PageSize;
					if(freeSize >= size)
						return position;
				} else {
					position += freeSize + PageSize;
					freeSize = 0;
					var remainder = position % align;
					if(remainder != 0)
						position = (position - remainder) + align;
				}
			}
			return ulong.MaxValue;
		}
	}
}