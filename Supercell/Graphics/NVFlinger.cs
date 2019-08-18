using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Common;
using MoreLinq;
using PrettyPrinter;

namespace Supercell.Graphics {
	[StructLayout(LayoutKind.Sequential, Size = 0x28)]
    struct GraphicBufferHeader {
        public uint Magic;
        public uint Width;
        public uint Height;
        public uint Stride;
        public uint Format;
        public uint Usage;

        public uint Pid;
        public uint RefCount;

        public uint FdsCount;
        public uint IntsCount;
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x58)]
    struct NvGraphicBufferSurface {
        public uint Width;
        public uint Height;
        public ColorFormat ColorFormat;
        public uint Layout;
        public uint Pitch;
        public uint NvMapHandle;
        public uint Offset;
        public uint Kind;
        public uint BlockHeightLog2;
        public uint ScanFormat, _unknown;
        public ulong Flags;
        public ulong Size;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct NvGraphicBufferSurfaceArray {
        NvGraphicBufferSurface Surface0, Surface1, Surface2;
        public NvGraphicBufferSurface this[int index] =>
	        index switch { 0 => Surface0, 1 => Surface1, 2 => Surface2, _ => throw new NotSupportedException() };
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x144)]
    struct NvGraphicBuffer {
        [FieldOffset(0x4)]
        public uint NvMapId;
        [FieldOffset(0xC)]
        public uint Magic;
        [FieldOffset(0x10)]
        public uint Pid;
        [FieldOffset(0x14)]
        public uint Type;
        [FieldOffset(0x18)]
        public uint Usage;
        [FieldOffset(0x1C)]
        public uint PixelFormat;
        [FieldOffset(0x20)]
        public uint ExternalPixelFormat;
        [FieldOffset(0x24)]
        public uint Stride;
        [FieldOffset(0x28)]
        public uint FrameBufferSize;
        [FieldOffset(0x2C)]
        public uint PlanesCount;
        [FieldOffset(0x34)]
        public NvGraphicBufferSurfaceArray Surfaces;
    }

    struct GbpBuffer {
	    public readonly GraphicBufferHeader Header;
	    public readonly NvGraphicBuffer Buffer;

	    public GbpBuffer(Buffer<byte> buffer) {
		    Header = buffer.As<GraphicBufferHeader>();
		    Buffer = (buffer + Marshal.SizeOf<GraphicBufferHeader>() + Header.FdsCount * 4).As<NvGraphicBuffer>();
	    }
    }
    
	public class NVFlinger {
		[Flags]
		enum HalTransform {
			FlipX     = 1,
			FlipY     = 2,
			Rotate90  = 4,
			Rotate180 = FlipX | FlipY,
			Rotate270 = Rotate90 | Rotate180,
		}
		
		enum BufferState {
			Free,
			Dequeued,
			Queued,
			Acquired
		}
		
		[StructLayout(LayoutKind.Sequential, Size = 0x8)]
		struct Fence {
			public uint Id, Value;
		}

		[StructLayout(LayoutKind.Sequential, Size = 0x24)]
		struct MultiFence {
			public uint FenceCount;
			public Fence Fence0, Fence1, Fence2, Fence3;
		}
		
		[StructLayout(LayoutKind.Sequential, Size = 0x10)]
		struct Rect {
			public uint Top, Left, Right, Bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct QueueBufferObject {
			public ulong Timestamp;
			public uint IsAutoTimestamp;
			public Rect Crop;
			public uint ScalingMode;
			public HalTransform Transform;
			public uint StickyTransform;
			public uint Unknown;
			public uint SwapInterval;
			public MultiFence Fence;
		}
		
		struct BufferEntry {
			public BufferState State;
			public HalTransform Transform;
			public Rect Crop;
			public GbpBuffer Data;
		}
		
		class CommandAttribute : Attribute {
			public readonly string Iface;
			public readonly uint Id;
			public CommandAttribute(string iface, uint id) {
				Iface = iface;
				Id = id;
			}
		}
		
		static readonly Dictionary<(string Interface, uint Id), Action<NVFlinger, Buffer<byte>, BinaryWriter>> Commands;
		
		readonly BufferEntry[] BufferQueue = new BufferEntry[0x40];
		readonly AutoResetEvent WaitBufferFree = new AutoResetEvent(false);

		static NVFlinger() =>
			Commands = typeof(NVFlinger).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
				.Where(x => x.HasAttribute<CommandAttribute>())
				.Select(x => (x, x.GetCustomAttribute<CommandAttribute>()))
				.Select(x => ((x.Item2.Iface, x.Item2.Id),
					(Action<NVFlinger, Buffer<byte>, BinaryWriter>) ((self, buf, bw) =>
						x.Item1.Invoke(self, new object[] { buf, bw }))))
				.ToDictionary();

		public uint ProcessParcel(Buffer<byte> replyBuffer, Span<byte> parcel, uint code) {
			var name = Encoding.Unicode.GetString(parcel.Slice(8, parcel.Get<int>(1) * 2));
			if(!Commands.TryGetValue((name, code), out var cmd))
				throw new NotSupportedException($"Unknown command for parcel: {name.ToPrettyString()} 0x{code:X}");
			Buffer<byte>.ScopedSpan(parcel.Slice(0x50),
				buffer => Parcel.MakeParcel(replyBuffer, bw => cmd(this, buffer, bw), new byte[0]));
			return 0;
		}

		[Command("android.gui.IGraphicBufferProducer", 0x1)]
		void GbpRequestBuffer(Buffer<byte> parcelData, BinaryWriter bw) {
			var slot = parcelData.As<uint>().Value;
			
			bw.Write(1); // buffer count
			bw.Write((ulong) (Marshal.SizeOf<GraphicBufferHeader>() + Marshal.SizeOf<NvGraphicBuffer>()));

			lock(BufferQueue) {
				var data = BufferQueue[slot].Data;
				bw.WriteStruct(data.Header);
				bw.WriteStruct(data.Buffer);
			}
			
			bw.Write(0);
		}

		[StructLayout(LayoutKind.Sequential)]
		struct DequeueInfo {
			public uint Format, Width, Height, GetTimestamps, Usage;
		}
		
		[Command("android.gui.IGraphicBufferProducer", 0x3)]
		void GbpDequeueBuffer(Buffer<byte> parcelData, BinaryWriter bw) {
			var info = parcelData.As<DequeueInfo>().Value;
			var slot = GetFreeSlotBacking(info.Width, info.Height);
			Debug.Assert(slot != uint.MaxValue);
			bw.WriteAll((int) slot, 1, 0x24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}
		
		[Command("android.gui.IGraphicBufferProducer", 0x9)]
		void GbpQuery(Buffer<byte> parcelData, BinaryWriter bw) => bw.WriteAll(0, 0);
		
		[Command("android.gui.IGraphicBufferProducer", 0xA)]
		void GbpConnect(Buffer<byte> parcelData, BinaryWriter bw) => bw.WriteAll(1280, 720, 0, 0, 0);

		[Command("android.gui.IGraphicBufferProducer", 0xE)]
		void GbpPreallocBuffer(Buffer<byte> parcelData, BinaryWriter bw) {
			var ub = parcelData.As<uint>();
			var slot = ub[0];
			if(ub[1] == 1) {
				var size = parcelData.As<ulong>()[1];
				var data = parcelData.Span.Slice(16, (int) size);
				lock(BufferQueue)
					Buffer<byte>.ScopedSpan(data, cb => {
						BufferQueue[slot].State = BufferState.Free;
						BufferQueue[slot].Data = new GbpBuffer(cb);
					});
			}
			
			bw.Write(0);
		}

		void ReleaseBuffer(uint slot) {
			lock(BufferQueue)
				BufferQueue[slot].State = BufferState.Free;
			WaitBufferFree.Set();
		}

		uint GetFreeSlotBacking(uint width, uint height) {
			do {
				var slot = GetFreeSlot(width, height);
				if(slot != uint.MaxValue)
					return slot;
				WaitBufferFree.DebugWaitOne();
			} while(true);
		}

		uint GetFreeSlot(uint width, uint height) {
			lock(BufferQueue)
				for(var slot = 0U; slot < BufferQueue.Length; ++slot) {
					if(BufferQueue[slot].State != BufferState.Free)
						continue;
					var data = BufferQueue[slot].Data;
					if(data.Header.Width != width || data.Header.Height != height) continue;
					BufferQueue[slot].State = BufferState.Dequeued;
					return slot;
				}
			return uint.MaxValue;
		}
	}
}