using System;
using System.Threading;
using PrettyPrinter;
using static Supercell.Globals;

namespace Supercell {
	public static class Extensions {
		[System.Diagnostics.Conditional("DEBUG")]
		public static void Debug(this string message) => Logger.Log(message);
		[System.Diagnostics.Conditional("DEBUG")]
		public static void Debug<T>(this T obj) => Logger.Log(obj.ToPrettyString());
		
		const string Printable = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-[]{}`~!@#$%^&*()-=\\|;:'\",./<>?";
		public static void Hexdump(this Span<byte> _buffer) {
			var buffer = _buffer.ToArray();
			Logger.Exclusive(() => {
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
			});
		}

		public static unsafe void DebugWaitOne(this AutoResetEvent are) {
			while(true) {
				if(are.WaitOne(100)) return;
				if(Thread.CurrentThread.Cpu.State->Debugging != 0)
					Kernel.DebugWait(real: false);
			}
		}
	}
}