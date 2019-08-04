using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Common;
using static Supercell.Globals;

namespace Supercell {
	public class KSharedMemory : KObject {
		readonly int Size;
		byte[] InitialBackingMemory;
		ulong _Address;
		public ulong Address {
			set => SetAddress(value);
		}

		unsafe void SetAddress(ulong value) {
			var data = _Address != 0 ? new Span<byte>((byte*) _Address, Size).ToArray() : InitialBackingMemory;
			_Address = value;
			if(_Address == 0) {
				InitialBackingMemory = new byte[Size];
				return;
			}
			if(data != null) {
				var span = new Span<byte>((byte*) _Address, Size);
				for(var i = 0; i < Size; ++i)
					span[i] = data[i];
			}
		}

		public KSharedMemory(int size) {
			Size = size;
			InitialBackingMemory = new byte[size];
		}

		public KSharedMemory(byte[] data) {
			Size = data.Length;
			InitialBackingMemory = data;
		}
	}
	
	public unsafe class MemoryManager {
		[DllImport("libc")]
		static extern ulong mmap(ulong addr, ulong len, int prot, int flags, int fd, ulong offset);
		[DllImport("libc")]
		static extern void munmap(ulong addr, ulong len);
		[DllImport("libc")]
		static extern void mprotect(ulong addr, ulong len, int prot);

		[DllImport("kernel32")]
		static extern ulong VirtualAlloc(ulong addr, ulong len, uint allocationType, uint protect);
		[DllImport("kernel32")]
		static extern void VirtualFree(ulong addr, ulong len, uint freeType);

		[StructLayout(LayoutKind.Explicit)]
		public struct SYSTEM_INFO_UNION {
			[FieldOffset(0)] public uint OemId;
			[FieldOffset(0)] public ushort ProcessorArchitecture;
			[FieldOffset(2)] public ushort Reserved;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct SYSTEM_INFO {
			public SYSTEM_INFO_UNION CpuInfo;
			public uint PageSize;
			public uint MinimumApplicationAddress;
			public uint MaximumApplicationAddress;
			public uint ActiveProcessorMask;
			public uint NumberOfProcessors;
			public uint ProcessorType;
			public uint AllocationGranularity;
			public ushort ProcessorLevel;
			public ushort ProcessorRevision;
		}
		
		[StructLayout(LayoutKind.Sequential)]
		public struct MEMORY_BASIC_INFORMATION {
			public ulong BaseAddress;
			public ulong AllocationBase;
			public uint AllocationProtect;
			public ulong RegionSize;
			public uint State;
			public uint Protect;
			public uint Type;
		}

		[DllImport("kernel32.dll", SetLastError=false)]
		static extern void GetSystemInfo(out SYSTEM_INFO Info);
		[DllImport("kernel32.dll")]
		static extern int VirtualQueryEx(IntPtr hProcess, ulong lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
		
		public readonly SortedList<ulong, (ulong Addr, ulong Size)> Regions = new SortedList<ulong, (ulong Addr, ulong Size)>();
		public readonly SortedList<ulong, ulong> Reserved = new SortedList<ulong, ulong>();

		public ulong HeapAddress;
		public uint HeapSize;

		public ulong PageSize, PageMask;
		public ulong StackBase;
		public ulong StackSize;
		public const ulong EachStackSize = 8UL * 1024 * 1024;
		
		readonly Queue<ulong> AvailableStacks = new Queue<ulong>();

		public MemoryManager() {
			if(IsWindows) {
				GetSystemInfo(out var info);
				PageSize = info.PageSize;
			} else
				PageSize = 0x1000;
			PageMask = PageSize - 1;
			
			// 1GB of stack space total should be enough, right?
			// This certainly won't bite us in the ass later
			StackSize = 1UL * 1024 * 1024 * 1024;
			StackBase = AllocateAligned(StackSize, 0x10UL << 32, reserve: true);

			var top = StackBase + StackSize;
			for(var addr = StackBase; addr < top; addr += EachStackSize) {
				Debug.Assert(addr + EachStackSize <= top);
				AvailableStacks.Enqueue(addr);
			}
		}

		public (ulong Addr, ulong Size) AllocateStack() {
			var addr = AvailableStacks.Dequeue();
			Regions.Add(addr, (addr, EachStackSize));
			return (addr, EachStackSize);
		}

		public ulong AllocateAligned(ulong size, ulong preferred = 0UL, bool reserve = false) {
			if(IsWindows && (preferred & 0xFFFF) != 0) {
				var ret = VirtualQueryEx(Process.GetCurrentProcess().Handle, preferred, out var info,
					(uint) Marshal.SizeOf<MEMORY_BASIC_INFORMATION>());
				Debug.Assert(ret != 0);
				if(info.State == 0x10000) // MEM_FREE
					AllocateAligned((size & ~0xFFFFUL) + 0x10000, preferred & ~0xFFFFUL, reserve: true);
			}
			
			if((size & PageMask) != 0)
				size = (size & ~PageMask) + PageSize;

			const bool required = true;
			var addr = IsWindows
				? VirtualAlloc(preferred, size, 0x1000 | 0x2000, 0x04) // MEM_COMMIT | MEM_RESERVE
				: mmap(preferred, size, 1 | 2, (IsLinux ? 0x20 : 0x1000) | 0x0001 | (required ? 0x0010 : 0), 0, 0);
			if(addr == 0 && Reserved.Any(x => x.Key <= preferred && x.Value >= preferred + size))
				addr = preferred;
			else
				Debug.Assert(!required || addr == preferred || (addr != 0 && addr != unchecked((ulong) -1L)));

			if(reserve)
				Reserved.Add(addr, addr + size);
			else
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

		[Svc(0x3)]
		public uint SetMemoryAttribute(ulong addr, ulong size, uint state0, uint state1) {
			return 0;
		}

		[Svc(0x4)]
		public unsafe uint MapMemory(ulong dst, ulong src, ulong size) {
			$"Mapping memory region 0x{src:X} -> 0x{dst:X} of size 0x{size:X}".Debug();
			AllocateAligned(size, dst);
			var srcptr = (byte*) src;
			var dstptr = (byte*) dst;
			for(var i = 0UL; i < size; i++)
				*dstptr++ = *srcptr++;
			//mprotect(src, size, 0);
			return 0;
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

				if(addr >= HeapAddress && addr < HeapAddress + HeapSize)
					memoryInfo->MemoryType = 5;

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

		[Svc(0x13)]
		public uint MapSharedMemory(uint handle, ulong addr, ulong size, uint perm) {
			$"MapSharedMemory(0x{handle:X}, 0x{addr:X}, 0x{size:X}, 0x{perm:X})".Debug();
			var shmem = Kernel.Get<KSharedMemory>(handle);
			AllocateAligned(size, addr);
			shmem.Address = addr;
			return 0;
		}

		[Svc(0x15)]
		public (uint, uint) CreateTransferMemory(uint _, ulong addr, ulong size, uint perm) {
			$"CreateTransferMemory(0x{addr:X}, 0x{size:X}, 0x{perm:X})".Debug();
			return (0, 0);
		}
	}
}