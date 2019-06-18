using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common {
	public static class Extensions {
		public static void Debug<T>(this T obj) => Console.WriteLine(obj);

		/*public static Dictionary<TKey, TValue>
			ToDictionary<TKey, TValue>(this IEnumerable<(TKey, TValue)> enumerable) =>
			enumerable.ToDictionary(x => x.Item1, x => x.Item2);*/

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
	}
}