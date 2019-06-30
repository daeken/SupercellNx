using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Common;

namespace Supercell {
	public unsafe class MemoryManager {
		[DllImport("libc")]
		static extern ulong mmap(ulong addr, ulong len, int prot, int flags, int fd, ulong offset);
		[DllImport("libc")]
		static extern void munmap(ulong addr, ulong len);
		
		public readonly SortedList<ulong, (ulong Addr, ulong Size)> Regions = new SortedList<ulong, (ulong Addr, ulong Size)>();

		public ulong HeapAddress;
		public uint HeapSize;
		
		public ulong AllocateAligned(ulong size, ulong preferred = 0UL) {
			if((size & 0xFFF) != 0)
				size = (size & ~0xFFFUL) + 0x1000UL;

			const bool required = true;
			var addr = mmap(preferred, size, 1 | 2, 0x1000 | 0x0001 | (required ? 0x0010 : 0), 0, 0);
			Debug.Assert(!required || addr != unchecked((ulong) -1L));
			Regions.Add(addr, (addr, size));
			return addr;
		}

		public void UnAllocate(ulong addr, ulong size) => munmap(addr, size);

		IEnumerable<(ulong Start, ulong End, bool Resident)> AllRegions() {
			var prevAddr = 0UL;
			foreach(var (addr, size) in Regions.Values) {
				if(prevAddr != addr)
					yield return (prevAddr, addr, false);
				prevAddr = addr + size;
				yield return (addr, prevAddr, true);
			}
			yield return (prevAddr, 0 - prevAddr, false);
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MemoryInfo {
			public ulong Begin, Size;
			public uint MemoryType, MemoryAttribute;
			public uint Permission, DeviceRefCount, IpcRefCount;
			public uint __padding;
		}

		[Svc(0x1)]
		public (uint, ulong) SetHeapSize(uint _, uint size) {
			$"SetHeapSize(0x{size:X})".Debug();
			if(HeapAddress != 0)
				UnAllocate(HeapAddress, HeapSize);
			HeapAddress = AllocateAligned(size, 0x76UL << 32);
			$"Heap at 0x{HeapAddress:X}".Debug();
			HeapSize = size;
			return (0, HeapAddress);
		}

		[Svc(0x6)]
		public uint QueryMemory(ulong _memoryInfo, ulong _pageInfo, ulong addr) {
			$"QueryMemory(0x{addr:X})".Debug();
			var memoryInfo = (MemoryInfo*) _memoryInfo;
			foreach(var (start, end, resident) in AllRegions()) {
				if(!(start <= addr && addr < end)) continue;
				memoryInfo->Begin = start;
				memoryInfo->Size = end - start;
				memoryInfo->MemoryType = resident ? 3U : 0;
				memoryInfo->MemoryAttribute = 0;
				memoryInfo->Permission = 0;
				memoryInfo->__padding = 0;

				if(resident) {
					var offset = (ulong) *(uint*) (start + 4);
					if(start + offset < end && *(uint*) (start + offset) == 0x30444f4d) // MOD0
						memoryInfo->Permission = 5;
					else
						memoryInfo->Permission = 3;
				}
				break;
			}
			*(uint*) _pageInfo = 0;
			return 0;
		}

		[Svc(0x15)]
		public (uint, uint) CreateTransferMemory(uint _, ulong addr, ulong size, uint perm) {
			$"CreateTransferMemory(0x{addr:X}, 0x{size:X}, 0x{perm:X})".Debug();
			return (0, 0);
		}
	}
}