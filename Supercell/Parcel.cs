using System;
using System.IO;
using Common;

namespace Supercell {
	public class Parcel {
		public static Span<byte> GetParcelData(Buffer<byte> parcelBuffer) {
			var bi = parcelBuffer.As<int>().GetSpan();
			return parcelBuffer.GetSpan().Slice(bi[1], bi[0]);
		}
		
		public static ulong MakeParcel(Buffer<byte> parcelBuffer, byte[] data, byte[] objs) {
			var parcel = parcelBuffer.As<int>().GetSpan();
			parcel[0] = data.Length;
			parcel[1] = 0x10;
			parcel[2] = objs.Length;
			parcel[3] = data.Length + 0x10;
			data.CopyTo(parcelBuffer.GetSpan().Slice(4 * 4));
			objs.CopyTo(parcelBuffer.GetSpan().Slice(4 * 4 + data.Length));
			return (ulong) (4 * 4 + data.Length + objs.Length);
		}

		public static ulong MakeParcel(Buffer<byte> parcelBuffer, Action<BinaryWriter> data, Action<BinaryWriter> objs)
			=> MakeParcel(parcelBuffer, data.ToArray(), objs.ToArray());

		public static ulong MakeParcel(Buffer<byte> parcelBuffer, byte[] data, Action<BinaryWriter> objs)
			=> MakeParcel(parcelBuffer, data, objs.ToArray());

		public static ulong MakeParcel(Buffer<byte> parcelBuffer, Action<BinaryWriter> data, byte[] objs)
			=> MakeParcel(parcelBuffer, data.ToArray(), objs);
	}
}