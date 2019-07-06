using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using MoreLinq;
using PrettyPrinter;

namespace Supercell.Graphics {
	public class NVFlinger {
		class CommandAttribute : Attribute {
			public readonly string Iface;
			public readonly uint Id;
			public CommandAttribute(string iface, uint id) {
				Iface = iface;
				Id = id;
			}
		}

		static readonly Dictionary<(string Interface, uint Id), Action<NVFlinger, Buffer<byte>, BinaryWriter>> Commands;

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
		void GbpRequestBuffer(Buffer<byte> parcelData, BinaryWriter bw) => throw new NotSupportedException();
		
		[Command("android.gui.IGraphicBufferProducer", 0xA)]
		void GbpConnect(Buffer<byte> parcelData, BinaryWriter bw) => bw.WriteAll(1280, 720, 0, 0, 0);
	}
}