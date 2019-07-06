using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using MoreLinq;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nns.nvdrv {
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
					var cmd = x.GetCustomAttribute<IoctlAttribute>().Cmd;
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
			return !Ioctls.TryGetValue(cmd, out var func)
				? throw new NotSupportedException($"Unknown IOCTL for {GetType().Name}: 0x{cmd:X}")
				: func(this, input, output);
		}

		public virtual KEvent GetEvent(uint eventId) => throw new NotSupportedException($"GetEvent on {GetType().Name}");
	}

	class NvhostAsGpu : NvDevice {
		[Ioctl(0x40284109)]
		void InitializeEx(Buffer<byte> input) {}

		[Ioctl(0xC0404108)]
		void GetVaRegions(Buffer<byte> input, Buffer<byte> output) {}
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

		public override KEvent GetEvent(uint eventId) => new KEvent();
	}
	
	[IpcService("nvdrv")]
	[IpcService("nvdrv:a")]
	[IpcService("nvdrv:s")]
	[IpcService("nvdrv:t")]
	public class INvDrvServices : IpcInterface {
		uint CurFd;
		readonly Dictionary<uint, NvDevice> Fds = new Dictionary<uint, NvDevice>();

		[IpcCommand(0)]
		void Open([Buffer(0x5)] Buffer<byte> pathBuffer, out uint fd, out uint error_code) {
			var cfd = fd = CurFd++;
			void Add(NvDevice device) => Fds[cfd] = device;
			var path = Encoding.ASCII.GetString(pathBuffer.GetSpan());
			switch(path) {
				case "/dev/nvhost-as-gpu":
					Add(new NvhostAsGpu());
					break;
				case "/dev/nvhost-ctrl-gpu":
					Add(new NvhostCtrlGpu());
					break;
				default:
					throw new NotSupportedException($"Unknown NV device: {path}");
			}
			error_code = 0;
		}

		[IpcCommand(1)]
		void Ioctl(uint fd, uint cmd, [Buffer(0x21)] Buffer<byte> input, out uint error_code,
			[Buffer(0x22)] Buffer<byte> output) {
			error_code = Fds[fd].Ioctl(cmd, input, output);
		}

		[IpcCommand(2)]
		void Close(uint fd, out uint error_code) {
			Fds.Remove(fd);
			error_code = 0;
		}

		[IpcCommand(3)]
		void Initialize(uint transfer_memory_size, [Move] KObject current_process, [Move] KObject transfer_memory,
			out uint error_code) => error_code = 0;

		[IpcCommand(4)]
		void QueryEvent(uint fd, uint event_id, out uint error_code, [Move] out KObject evt) {
			error_code = 0;
			evt = Fds[fd].GetEvent(event_id);
		}
		
		[IpcCommand(5)]
		void MapSharedMem(uint fd, uint nvmap_handle, [Move] KObject unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(6)]
		void GetStatus([Bytes(0x24)] out byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(7)]
		void ForceSetClientPID(ulong pid, out uint error_code) => throw new NotImplementedException();

		[IpcCommand(8)]
		void SetClientPID(ulong unknown0, [Pid] ulong pid, out uint error_code) {
			error_code = 0;
		}
		
		[IpcCommand(9)]
		void DumpGraphicsMemoryInfo() => throw new NotImplementedException();
		[IpcCommand(10)]
		void Unknown10(uint unknown0, [Move] KObject unknown1, out uint unknown2) => throw new NotImplementedException();
		[IpcCommand(11)]
		void Ioctl2(uint unknown0, uint unknown1, [Buffer(0x21)] Buffer<byte> unknown2, [Buffer(0x21)] Buffer<byte> unknown3, out uint unknown4, [Buffer(0x22)] Buffer<byte> unknown5) => throw new NotImplementedException();
		[IpcCommand(12)]
		void Ioctl3(uint unknown0, uint unknown1, [Buffer(0x21)] Buffer<byte> unknown2, out uint unknown3, [Buffer(0x22)] Buffer<byte> unknown4, [Buffer(0x22)] Buffer<byte> unknown5) => throw new NotImplementedException();

		[IpcCommand(13)]
		void Unknown13(ulong unknown0) {
		}
	}
}
