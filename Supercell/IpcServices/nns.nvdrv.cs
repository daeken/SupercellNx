using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using MoreLinq;
using Supercell.Gpu;
using static Supercell.Globals;
#pragma warning disable 649

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nns.Nvdrv {
	enum NvStatus {
		NotAvailableInProduction = 196614, 
		Success                  = 0, 
		TryAgain                 = -11, 
		OutOfMemory              = -12, 
		InvalidInput             = -22, 
		NotSupported             = -25, 
		Restart                  = -85, 
		TimedOut                 = -110
	}
	
	class IoctlAttribute : Attribute {
		public readonly uint Cmd;
		public IoctlAttribute(uint cmd) => Cmd = cmd;
	}
	
	abstract class NvDevice {
		public readonly Dictionary<uint, Func<object, Buffer<byte>, Buffer<byte>, uint>> Ioctls;

		protected NvDevice() =>
			Ioctls = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				.Where(x => x.HasAttribute<IoctlAttribute>())
				.Select(x => {
					var cmd = x.GetCustomAttribute<IoctlAttribute>().Cmd & 0xFF00FFFFU;
					switch(cmd >> 28) {
						case 0x4: {
							var p = x.GetParameters();
							var itype = p[0].ParameterType.GetGenericArguments()[0];
							var im = typeof(Buffer<byte>).GetMethod("As").MakeGenericMethod(itype);
							var icast = itype == typeof(byte)
								? (Func<Buffer<byte>, object>) (y => y)
								: y => im.Invoke(y, null);
							return (cmd, x.ReturnType == typeof(uint)
								? (Func<object, Buffer<byte>, Buffer<byte>, uint>) ((obj, input, output) =>
									(uint) x.Invoke(obj, new[] { icast(input) }))
								: (Func<object, Buffer<byte>, Buffer<byte>, uint>) ((obj, input, output) => {
									x.Invoke(obj, new[] { icast(input) });
									return 0;
								}));
						}
						case 0x8: {
							var p = x.GetParameters();
							var otype = p[0].ParameterType.GetGenericArguments()[0];
							var om = typeof(Buffer<byte>).GetMethod("As").MakeGenericMethod(otype);
							var ocast = otype == typeof(byte)
								? (Func<Buffer<byte>, object>) (y => y)
								: y => om.Invoke(y, null);
							return (cmd, x.ReturnType == typeof(uint)
								? (Func<object, Buffer<byte>, Buffer<byte>, uint>) ((obj, input, output) =>
									(uint) x.Invoke(obj, new[] { ocast(output) }))
								: (Func<object, Buffer<byte>, Buffer<byte>, uint>) ((obj, input, output) => {
									x.Invoke(obj, new[] { ocast(output) });
									return 0;
								}));
						}
						case 0xC: {
							var p = x.GetParameters();
							var itype = p[0].ParameterType.GetGenericArguments()[0];
							var im = typeof(Buffer<byte>).GetMethod("As").MakeGenericMethod(itype);
							var icast = itype == typeof(byte)
								? (Func<Buffer<byte>, object>) (y => y)
								: y => im.Invoke(y, null);
							var otype = p[1].ParameterType.GetGenericArguments()[0];
							var om = typeof(Buffer<byte>).GetMethod("As").MakeGenericMethod(otype);
							var ocast = otype == typeof(byte)
								? (Func<Buffer<byte>, object>) (y => y)
								: y => om.Invoke(y, null);
							return (cmd, x.ReturnType == typeof(uint)
								? (Func<object, Buffer<byte>, Buffer<byte>, uint>) ((obj, input, output) =>
									(uint) x.Invoke(obj, new[] { icast(input), ocast(output) }))
								: (Func<object, Buffer<byte>, Buffer<byte>, uint>) ((obj, input, output) => {
									x.Invoke(obj, new[] { icast(input), ocast(output) });
									return 0;
								}));
						}
						default: throw new NotImplementedException();
					}
				})
				.ToDictionary();
		
		public uint Ioctl(uint cmd, Buffer<byte> input, Buffer<byte> output) {
			if((cmd & 0x40000000) != 0 && input.Address == 0)
				return unchecked((uint) NvStatus.InvalidInput);
			if((cmd & 0x80000000) != 0 && output.Address == 0)
				return unchecked((uint) NvStatus.InvalidInput);
			return !Ioctls.TryGetValue(cmd & 0xFF00FFFFU, out var func)
				? throw new NotSupportedException($"Unknown IOCTL for {GetType().Name}: 0x{cmd:X}")
				: func(this, input, output);
		}

		public virtual Event GetEvent(uint eventId) => throw new NotSupportedException($"GetEvent on {GetType().Name}");
	}

	class NvhostAsGpu : NvDevice {
		class Range {
			public ulong Start, End;
			public Range(ulong start, ulong size) {
				Start = start;
				End = start + size;
			}
		}

		class MappedRange : Range {
			public ulong PhysAddr;
			public bool VaAllocated;
			public MappedRange(ulong start, ulong size, ulong physAddr, bool vaAllocated) : base(start, size) {
				PhysAddr = physAddr;
				VaAllocated = vaAllocated;
			}
		}

		static readonly SortedList<ulong, MappedRange> Maps = new SortedList<ulong, MappedRange>();
		static readonly SortedList<ulong, Range> Reservations = new SortedList<ulong, Range>();

		bool TryGetMapPhysicalAddress(ulong addr, out ulong physAddr) {
			var mapping = Maps.FirstOrDefault(x => x.Value.Start <= addr && x.Value.End > addr).Value;
			if(mapping != null) {
				physAddr = mapping.PhysAddr;
				return true;
			}
			physAddr = 0;
			return false;
		}
		
		[Ioctl(0x40284109)]
		void InitializeEx(Buffer<byte> input) {}

		[Ioctl(0xC0404108)]
		void GetVaRegions(Buffer<byte> input, Buffer<byte> output) {}

		struct AllocSpaceStruct {
			public int  Pages;
			public int  PageSize;
			public int  Flags;
			public int  Padding;
			public ulong Offset;
		}
		
		[Ioctl(0xC0184102)]
		void AllocSpace(Buffer<AllocSpaceStruct> input, Buffer<AllocSpaceStruct> output) {
			var args = input.Value;
			var size = (ulong) args.Pages * (ulong) args.PageSize;
			if((args.Flags & 1) != 0) // Fixed offset
				args.Offset = GpuInstance.Vmm.ReserveFixed(args.Offset, size);
			else
				args.Offset = GpuInstance.Vmm.Reserve(size, args.Offset);
			Debug.Assert(args.Offset != ulong.MaxValue);
			Reservations.Add(args.Offset, new Range(args.Offset, size));
			output.Value = args;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct MapBufferExStruct {
			public uint  Flags;
			public uint  Kind;
			public uint  NvMapHandle;
			public uint  PageSize;
			public ulong BufferOffset;
			public ulong MappingSize;
			public ulong Offset;
		}

		[Ioctl(0xC0284106)]
		void MapBufferEx(Buffer<MapBufferExStruct> input, Buffer<MapBufferExStruct> output) {
			var args = input.Value;
			var map = Nvmap.Maps[args.NvMapHandle];

			ulong physAddr;
			if((args.Flags & 0x100) != 0) // Remap sub range
				lock(Maps) {
					if(TryGetMapPhysicalAddress(args.Offset, out physAddr)) {
						var virtAddr = args.Offset + args.BufferOffset;
						physAddr += args.BufferOffset;
						GpuInstance.Vmm.Map(physAddr, virtAddr, args.MappingSize);
						return;
					} else
						throw new NotSupportedException();
				}

			physAddr = map.Address + args.BufferOffset;
			var size = args.MappingSize;
			$"Incoming size 0x{size:X} -- flags 0x{args.Flags}".Debug();
			if(size == 0)
				size = map.Size;

			lock(Maps) {
				var vaAllocated = (args.Flags & 1) == 0; // Fixed offset
				if(vaAllocated)
					args.Offset = GpuInstance.Vmm.Map(physAddr, size);
				else
					//Debug.Assert(ValidateFixedBuffer(args.Offset, size));
					args.Offset = GpuInstance.Vmm.Map(physAddr, args.Offset, size);
				
				Maps.Add(args.Offset, new MappedRange(args.Offset, size, physAddr, vaAllocated));
			}
			
			$"Allocated 0x{size:X} bytes at 0x{args.Offset:X}".Debug();
			
			output.Value = args;
		}

		[Ioctl(0x40044101)]
		void BindChannel(Buffer<uint> input) {
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x14)]
		struct RemapEntry {
			public ushort Flags, Kind;
			public uint NvMapHandle, _padding, Offset, Pages;
		}

		[Ioctl(0xC0144114)]
		void Remap(Buffer<RemapEntry> input, Buffer<RemapEntry> output) {
			foreach(var entry in input)
				GpuInstance.Vmm.Map(Nvmap.Maps[entry.NvMapHandle].Address, entry.Offset << 16, entry.Pages << 16);
		}
	}

	class NvhostCtrlGpu : NvDevice {
		[StructLayout(LayoutKind.Sequential)]
		struct Characteristics {
			public long BufferSize;
			public long BufferAddress;
			public int  Arch;
			public int  Impl;
			public int  Rev;
			public int  NumGpc;
			public long L2CacheSize;
			public long OnBoardVideoMemorySize;
			public int  NumTpcPerGpc;
			public int  BusType;
			public int  BigPageSize;
			public int  CompressionPageSize;
			public int  PdeCoverageBitCount;
			public int  AvailableBigPageSizes;
			public int  GpcMask;
			public int  SmArchSmVersion;
			public int  SmArchSpaVersion;
			public int  SmArchWarpCount;
			public int  GpuVaBitCount;
			public int  Reserved;
			public long Flags;
			public int  TwodClass;
			public int  ThreedClass;
			public int  ComputeClass;
			public int  GpfifoClass;
			public int  InlineToMemoryClass;
			public int  DmaCopyClass;
			public int  MaxFbpsCount;
			public int  FbpEnMask;
			public int  MaxLtcPerFbp;
			public int  MaxLtsPerLtc;
			public int  MaxTexPerTpc;
			public int  MaxGpcCount;
			public int  RopL2EnMask0;
			public int  RopL2EnMask1;
			public long ChipName;
			public long GrCompbitStoreBaseHw;
		}
		
		[Ioctl(0xC0B04705)]
		void GetCharacteristics(Buffer<Characteristics> input, Buffer<Characteristics> output) =>
			output.Value = new Characteristics {
				BufferSize = 0xa0,
				Arch = 0x120,
				Impl = 0xb,
				Rev = 0xa1,
				NumGpc = 0x1,
				L2CacheSize = 0x40000,
				OnBoardVideoMemorySize = 0x0,
				NumTpcPerGpc = 0x2,
				BusType = 0x20,
				BigPageSize = 0x20000,
				CompressionPageSize = 0x20000,
				PdeCoverageBitCount = 0x1b,
				AvailableBigPageSizes = 0x30000,
				GpcMask = 0x1,
				SmArchSmVersion = 0x503,
				SmArchSpaVersion = 0x503,
				SmArchWarpCount = 0x80,
				GpuVaBitCount = 0x28,
				Reserved = 0x0,
				Flags = 0x55,
				TwodClass = 0x902d,
				ThreedClass = 0xb197,
				ComputeClass = 0xb1c0,
				GpfifoClass = 0xb06f,
				InlineToMemoryClass = 0xa140,
				DmaCopyClass = 0xb0b5,
				MaxFbpsCount = 0x1,
				FbpEnMask = 0x0,
				MaxLtcPerFbp = 0x2,
				MaxLtsPerLtc = 0x1,
				MaxTexPerTpc = 0x0,
				MaxGpcCount = 0x1,
				RopL2EnMask0 = 0x21d70,
				RopL2EnMask1 = 0x0,
				ChipName = 0x6230326d67,
				GrCompbitStoreBaseHw = 0x0
			};

		[StructLayout(LayoutKind.Sequential)]
		struct TpcMasks {
			public int  MaskBufferSize;
			public int  Reserved;
			public long MaskBufferAddress;
			public int  TpcMask;
			public int  Padding;
		}

		[Ioctl(0xC0184706)]
		void GetTpcMasks(Buffer<TpcMasks> input, Buffer<TpcMasks> output) {
			var tpcMasks = input.Value;
			if(tpcMasks.MaskBufferSize != 0)
				tpcMasks.TpcMask = 3;
			output.Value = tpcMasks;
		}

		[Ioctl(0x80044701)]
		void ZCullGetCtxSize(Buffer<uint> output) => output.Value = 1;

		[StructLayout(LayoutKind.Sequential)]
		struct ZCullInfo {
			public int WidthAlignPixels;
			public int HeightAlignPixels;
			public int PixelSquaresByAliquots;
			public int AliquotTotal;
			public int RegionByteMultiplier;
			public int RegionHeaderSize;
			public int SubregionHeaderSize;
			public int SubregionWidthAlignPixels;
			public int SubregionHeightAlignPixels;
			public int SubregionCount;
		}
		
		[Ioctl(0x80284702)]
		void ZCullGetInfo(Buffer<ZCullInfo> output) =>
			output.Value = new ZCullInfo {
				WidthAlignPixels           = 0x20, 
				HeightAlignPixels          = 0x20, 
				PixelSquaresByAliquots     = 0x400, 
				AliquotTotal               = 0x800, 
				RegionByteMultiplier       = 0x20, 
				RegionHeaderSize           = 0x20, 
				SubregionHeaderSize        = 0xc0, 
				SubregionWidthAlignPixels  = 0x20, 
				SubregionHeightAlignPixels = 0x40, 
				SubregionCount             = 0x10
			};

		[StructLayout(LayoutKind.Sequential)]
		struct SlotMask {
			public uint Slot, Mask;
		}

		[Ioctl(0x80084714)]
		void ZbcGetActiveSlotMask(Buffer<SlotMask> output) => output.Value = new SlotMask { Slot = 7, Mask = 1 };

		public override Event GetEvent(uint eventId) => new Event();
	}

	abstract class NvChannel : NvDevice {
		ulong UserData;
		
		[Ioctl(0x40044801)]
		protected void SetNvmapFd(Buffer<uint> input) {
		}

		[Ioctl(0xC0004808)]
		protected void SubmitGpfifo(Buffer<byte> input, Buffer<byte> output) {
		}

		[Ioctl(0xC0104809)]
		protected void AllocObjCtx(Buffer<byte> input, Buffer<byte> output) {
		}

		[Ioctl(0xC020481A)]
		protected void AllocGpfifoEx32(Buffer<byte> input, Buffer<byte> output) {
		}

		[Ioctl(0xC010480B)]
		protected void ZCullBind(Buffer<byte> input, Buffer<byte> output) {
		}

		[Ioctl(0xC018480C)]
		protected void SetErrorNotifier(Buffer<byte> input, Buffer<byte> output) {
		}

		[Ioctl(0x4004480D)]
		protected void SetPriority(Buffer<uint> input) {
		}
		
		[Ioctl(0x40084714)]
		protected void SetUserData(Buffer<ulong> input) => UserData = input.Value;
		[Ioctl(0x80084715)]
		protected void GetUserData(Buffer<ulong> output) => output.Value = UserData;

		public override Event GetEvent(uint eventId) => new Event();
	}

	class NvhostGpu : NvChannel {
	}

	class Nvmap : NvDevice {
		public class NvmapHandle {
			public readonly uint Size;
			public bool Allocated;
			public uint Align;
			public byte Kind;
			public ulong Address;
			public NvmapHandle(uint size) => Size = size;
		}

		uint NvmapIter;
		public static readonly Dictionary<uint, NvmapHandle> Maps = new Dictionary<uint, NvmapHandle>();

		[StructLayout(LayoutKind.Sequential)]
		struct CreateInfo {
			public uint Size, Handle;
		}
		
		[Ioctl(0xC0080101)]
		void Create(Buffer<CreateInfo> input, Buffer<CreateInfo> output) {
			var args = input.Value;
			while(args.Size % GpuVmm.PageSize != 0)
				args.Size++;
			lock(Maps)
				Maps[args.Handle = ++NvmapIter] = new NvmapHandle(args.Size);
			output.Value = args;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct AllocInfo {
			public uint  Handle;
			public uint  HeapMask;
			public uint  Flags;
			public uint  Align;
			public ulong Kind;
			public ulong Address;
		}

		[Ioctl(0xC0200104)]
		void Alloc(Buffer<AllocInfo> input, Buffer<AllocInfo> output) {
			var args = input.Value;
			var map = Maps[args.Handle];
			if(args.Align < GpuVmm.PageSize)
				args.Align = (uint) GpuVmm.PageSize;
			if(!map.Allocated) {
				map.Allocated = true;
				map.Align = args.Align;
				map.Kind = (byte) args.Kind;
				
				Debug.Assert(args.Address != 0);
				map.Address = args.Address;
			}
			output.Value = args;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct IdInfo {
			public uint Id, Handle;
		}

		[Ioctl(0xC008010E)]
		void GetId(Buffer<IdInfo> input, Buffer<IdInfo> output) {
			var args = input.Value;
			args.Id = args.Handle;
			output.Value = args;
		}
	}

	public unsafe partial class INvDrvServices {
		static uint CurFd;
		static readonly Dictionary<uint, NvDevice> Fds = new Dictionary<uint, NvDevice>();

		public override void Open(Buffer<byte> pathBuffer, out uint fd, out uint error_code) {
			lock(Fds) {
				var cfd = fd = CurFd++;
				void Add(NvDevice device) => Fds[cfd] = device;
				var path = Encoding.ASCII.GetString(pathBuffer.Span);
				switch(path) {
					case "/dev/nvhost-as-gpu":
						Add(new NvhostAsGpu());
						break;
					case "/dev/nvhost-ctrl-gpu":
						Add(new NvhostCtrlGpu());
						break;
					case "/dev/nvhost-gpu":
						Add(new NvhostGpu());
						break;
					case "/dev/nvmap":
						Add(new Nvmap());
						break;
					default:
						throw new NotSupportedException($"Unknown NV device: {path}");
				}
				error_code = 0;
			}
		}

		public override void Ioctl(uint fd, uint cmd, Buffer<byte> input, out uint error_code, Buffer<byte> output) =>
			error_code = Fds[fd].Ioctl(cmd, input, output);
		
		public override uint _Close(uint fd) {
			Fds.Remove(fd);
			return 0;
		}

		public override uint Initialize(uint transfer_memory_size, KObject current_process, KObject transfer_memory) => 0;

		public override void QueryEvent(uint fd, uint event_id, out uint error_code, out KObject evt) {
			error_code = 0;
			evt = Fds[fd].GetEvent(event_id);
		}
		
		public override uint MapSharedMem(uint fd, uint nvmap_handle, KObject _2) => throw new NotImplementedException();
		public override object GetStatus() => throw new NotImplementedException();
		public override uint ForceSetClientPID(ulong pid) => throw new NotImplementedException();
		
		public override uint SetClientPID(ulong _0, ulong _1) => 0;
		
		public override void DumpGraphicsMemoryInfo() => throw new NotImplementedException();
		public override uint Unknown10(uint _0, KObject _1) => throw new NotImplementedException();
		public override void Ioctl2(uint _0, uint _1, Buffer<byte> _2, Buffer<byte> _3, out uint _4, Buffer<byte> _5) => throw new NotImplementedException();
		public override void Ioctl3(uint _0, uint _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4, Buffer<byte> _5) => throw new NotImplementedException();
		public override void Unknown13(object _0) {}
	}
}
