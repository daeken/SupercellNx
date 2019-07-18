using System;
using PrettyPrinter;

namespace IpcGenerator {
	public static class Extensions {
		public static void Debug(this string str) => Console.WriteLine(str);
		public static void Debug<T>(this T obj) => obj.Print();
	}
}