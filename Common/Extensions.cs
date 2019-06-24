using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Common {
	public static class Extensions {
		public static void Debug<T>(this T obj) => Console.WriteLine(obj);
		
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

		const string Printable = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-[]{}`~!@#$%^&*()-=\\|;:'\",./<>?";
		public static void Hexdump(this Span<byte> buffer) {
			for(var i = 0; i < buffer.Length; i += 16) {
				Console.Write($"{i:X4} | ");
				for(var j = 0; j < 16; ++j) {
					Console.Write(i + j >= buffer.Length ? $"   " : $"{buffer[i + j]:X2} ");
					if(j == 7) Console.Write(" ");
				}
				Console.Write("| ");
				for(var j = 0; j < 16; ++j) {
					if(i + j >= buffer.Length) break;
					Console.Write(Printable.Contains((char) buffer[i + j]) ? new string((char) buffer[i + j], 1) : ".");
					if(j == 7) Console.Write(" ");
				}
				Console.WriteLine();
			}
			Console.WriteLine($"{buffer.Length:X4}");
		}

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
	}
}