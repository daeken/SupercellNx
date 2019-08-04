using System.Runtime.Intrinsics;

namespace Common {
	public static class VectorExtensions {
		public static T Element<T>(this Vector128<float> vec, uint index) where T : struct =>
			vec.As<float, T>().GetElement((int) index);
		
		public static T Element<T>(this Vector128<T> vec, uint index) where T : struct =>
			vec.GetElement((int) index);
		
		public static Vector128<byte> Add(this Vector128<byte> a, Vector128<byte> b) =>
			Vector128.Create(
				(byte) (a.Element( 0) + b.Element( 0)),
				(byte) (a.Element( 1) + b.Element( 1)), 
				(byte) (a.Element( 2) + b.Element( 2)), 
				(byte) (a.Element( 3) + b.Element( 3)), 
				(byte) (a.Element( 4) + b.Element( 4)), 
				(byte) (a.Element( 5) + b.Element( 5)), 
				(byte) (a.Element( 6) + b.Element( 6)), 
				(byte) (a.Element( 7) + b.Element( 7)), 
				(byte) (a.Element( 8) + b.Element( 8)), 
				(byte) (a.Element( 9) + b.Element( 9)), 
				(byte) (a.Element(10) + b.Element(10)), 
				(byte) (a.Element(11) + b.Element(11)), 
				(byte) (a.Element(12) + b.Element(12)), 
				(byte) (a.Element(13) + b.Element(13)), 
				(byte) (a.Element(14) + b.Element(14)), 
				(byte) (a.Element(15) + b.Element(15))
			);
		public static Vector128<byte> Add(this Vector128<byte> a, byte b) =>
			Vector128.Create(
				(byte) (a.Element( 0) + b),
				(byte) (a.Element( 1) + b), 
				(byte) (a.Element( 2) + b), 
				(byte) (a.Element( 3) + b), 
				(byte) (a.Element( 4) + b), 
				(byte) (a.Element( 5) + b), 
				(byte) (a.Element( 6) + b), 
				(byte) (a.Element( 7) + b), 
				(byte) (a.Element( 8) + b), 
				(byte) (a.Element( 9) + b), 
				(byte) (a.Element(10) + b), 
				(byte) (a.Element(11) + b), 
				(byte) (a.Element(12) + b), 
				(byte) (a.Element(13) + b), 
				(byte) (a.Element(14) + b), 
				(byte) (a.Element(15) + b)
			);

		public static Vector128<ushort> Add(this Vector128<ushort> a, Vector128<ushort> b) =>
			Vector128.Create(
				(ushort) (a.Element(0) + b.Element(0)),
				(ushort) (a.Element(1) + b.Element(1)), 
				(ushort) (a.Element(2) + b.Element(2)), 
				(ushort) (a.Element(3) + b.Element(3)), 
				(ushort) (a.Element(4) + b.Element(4)), 
				(ushort) (a.Element(5) + b.Element(5)), 
				(ushort) (a.Element(6) + b.Element(6)), 
				(ushort) (a.Element(7) + b.Element(7))
			);
		public static Vector128<ushort> Add(this Vector128<ushort> a, ushort b) =>
			Vector128.Create(
				(ushort) (a.Element(0) + b),
				(ushort) (a.Element(1) + b), 
				(ushort) (a.Element(2) + b), 
				(ushort) (a.Element(3) + b), 
				(ushort) (a.Element(4) + b), 
				(ushort) (a.Element(5) + b), 
				(ushort) (a.Element(6) + b), 
				(ushort) (a.Element(7) + b)
			);

		public static Vector128<uint> Add(this Vector128<uint> a, Vector128<uint> b) =>
			Vector128.Create(
				a.Element(0) + b.Element(0),
				a.Element(1) + b.Element(1), 
				a.Element(2) + b.Element(2), 
				a.Element(3) + b.Element(3)
			);
		public static Vector128<uint> Add(this Vector128<uint> a, uint b) =>
			Vector128.Create(
				a.Element(0) + b,
				a.Element(1) + b, 
				a.Element(2) + b, 
				a.Element(3) + b
			);
		
		public static Vector128<ulong> Add(this Vector128<ulong> a, Vector128<ulong> b) =>
			Vector128.Create(
				a.Element(0) + b.Element(0),
				a.Element(1) + b.Element(1)
			);
		public static Vector128<ulong> Add(this Vector128<ulong> a, ulong b) =>
			Vector128.Create(
				a.Element(0) + b,
				a.Element(1) + b
			);
		
		public static Vector128<byte> Multiply(this Vector128<byte> a, Vector128<byte> b) =>
			Vector128.Create(
				(byte) (a.Element( 0) * b.Element( 0)),
				(byte) (a.Element( 1) * b.Element( 1)), 
				(byte) (a.Element( 2) * b.Element( 2)), 
				(byte) (a.Element( 3) * b.Element( 3)), 
				(byte) (a.Element( 4) * b.Element( 4)), 
				(byte) (a.Element( 5) * b.Element( 5)), 
				(byte) (a.Element( 6) * b.Element( 6)), 
				(byte) (a.Element( 7) * b.Element( 7)), 
				(byte) (a.Element( 8) * b.Element( 8)), 
				(byte) (a.Element( 9) * b.Element( 9)), 
				(byte) (a.Element(10) * b.Element(10)), 
				(byte) (a.Element(11) * b.Element(11)), 
				(byte) (a.Element(12) * b.Element(12)), 
				(byte) (a.Element(13) * b.Element(13)), 
				(byte) (a.Element(14) * b.Element(14)), 
				(byte) (a.Element(15) * b.Element(15))
			);
		public static Vector128<byte> Multiply(this Vector128<byte> a, byte b) =>
			Vector128.Create(
				(byte) (a.Element( 0) * b),
				(byte) (a.Element( 1) * b), 
				(byte) (a.Element( 2) * b), 
				(byte) (a.Element( 3) * b), 
				(byte) (a.Element( 4) * b), 
				(byte) (a.Element( 5) * b), 
				(byte) (a.Element( 6) * b), 
				(byte) (a.Element( 7) * b), 
				(byte) (a.Element( 8) * b), 
				(byte) (a.Element( 9) * b), 
				(byte) (a.Element(10) * b), 
				(byte) (a.Element(11) * b), 
				(byte) (a.Element(12) * b), 
				(byte) (a.Element(13) * b), 
				(byte) (a.Element(14) * b), 
				(byte) (a.Element(15) * b)
			);

		public static Vector128<ushort> Multiply(this Vector128<ushort> a, Vector128<ushort> b) =>
			Vector128.Create(
				(ushort) (a.Element(0) * b.Element(0)),
				(ushort) (a.Element(1) * b.Element(1)), 
				(ushort) (a.Element(2) * b.Element(2)), 
				(ushort) (a.Element(3) * b.Element(3)), 
				(ushort) (a.Element(4) * b.Element(4)), 
				(ushort) (a.Element(5) * b.Element(5)), 
				(ushort) (a.Element(6) * b.Element(6)), 
				(ushort) (a.Element(7) * b.Element(7))
			);
		public static Vector128<ushort> Multiply(this Vector128<ushort> a, ushort b) =>
			Vector128.Create(
				(ushort) (a.Element(0) * b),
				(ushort) (a.Element(1) * b), 
				(ushort) (a.Element(2) * b), 
				(ushort) (a.Element(3) * b), 
				(ushort) (a.Element(4) * b), 
				(ushort) (a.Element(5) * b), 
				(ushort) (a.Element(6) * b), 
				(ushort) (a.Element(7) * b)
			);

		public static Vector128<uint> Multiply(this Vector128<uint> a, Vector128<uint> b) =>
			Vector128.Create(
				a.Element(0) * b.Element(0),
				a.Element(1) * b.Element(1), 
				a.Element(2) * b.Element(2), 
				a.Element(3) * b.Element(3)
			);
		public static Vector128<uint> Multiply(this Vector128<uint> a, uint b) =>
			Vector128.Create(
				a.Element(0) * b,
				a.Element(1) * b, 
				a.Element(2) * b, 
				a.Element(3) * b
			);
	}
}