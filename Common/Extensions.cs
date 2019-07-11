using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using MoreLinq;

namespace Common {
	public static class Extensions {
		public static DelegateT CreateDelegate<DelegateT>(this MethodInfo mi) =>
			(DelegateT) (object) Delegate.CreateDelegate(typeof(DelegateT), mi);

		public static string ReadString(this BinaryReader br, int size) =>
			string.Join("", Enumerable.Range(0, size).Select(_ => (char) br.ReadByte()));

		public static BinaryReader At(this BinaryReader br, long offset) {
			br.BaseStream.Position = offset;
			return br;
		}
		
		public static bool HasBit(this byte v, int bit) => (v & (1U << bit)) != 0;
		public static bool HasBit(this ushort v, int bit) => (v & (1U << bit)) != 0;
		public static bool HasBit(this uint v, int bit) => (v & (1U << bit)) != 0;
		public static uint ToBit(this bool v, int bit) => v ? 1U << bit : 0;

		public static bool HasAttribute<T>(this ICustomAttributeProvider obj) =>
			obj.GetCustomAttributes(typeof(T), true).Length != 0;

		public static bool TryGetAttribute<T>(this ICustomAttributeProvider obj, out T attr) where T : Attribute {
			var attrs = obj.GetCustomAttributes(typeof(T), true);
			if(attrs.Length == 0) {
				attr = null;
				return false;
			}
			attr = (T) attrs[0];
			return true;
		}

		public static string Repeat(this string str, int count) => string.Concat(Enumerable.Repeat(str, count));

		public static byte[] ToArray(this Action<BinaryWriter> func) {
			using var ms = new MemoryStream();
			using var bw = new BinaryWriter(ms);
			func(bw);
			return ms.ToArray();
		}

		public static T Get<T>(this Span<byte> span, int index) where T : struct =>
			MemoryMarshal.Cast<byte, T>(span)[index];

		public static void WriteAll(this BinaryWriter bw, params int[] args) => args.ForEach(bw.Write);

		public static void WriteStruct<T>(this BinaryWriter bw, T obj) where T : struct =>
			bw.Write(MemoryMarshal.Cast<T, byte>(MemoryMarshal.CreateSpan(ref obj, 1)));

		public static T Element<T>(this Vector128<float> vec, uint index) where T : struct =>
			vec.As<float, T>().GetElement((int) index);
	}
}