using System;
using System.Runtime.InteropServices;
using static Supercell.Globals;

namespace Supercell {
	public static class SignalHandler {
		[DllImport("libc")]
		static extern void signal(int sig, ulong func);
		delegate void SignalDelegate(int sig);
		
		public static void Setup() {
			if(IsWindows) return;
			
			void Set(int sig, SignalDelegate func) {
				GCHandle.Alloc(func);
				signal(sig, 0);
				signal(sig, (ulong) Marshal.GetFunctionPointerForDelegate(func));
			}
			
			Set(4, SigIll); // SIGILL
			Set(5, SigTrap); // SIGTRAP
			Set(6, SigAbort); // SIGABRT
			Set(8, SigFpe); // SIGFPE
			Set(11, SigSegv); // SIGSEGV
		}

		static void SigIll(int sig) {
			Console.WriteLine("Illegal instruction");
			Environment.Exit(1);
		}
		static void SigTrap(int sig) {
			Console.WriteLine("Trap");
			Environment.Exit(1);
		}
		static void SigAbort(int sig) {
			Console.WriteLine("Abort");
			Environment.Exit(1);
		}
		static void SigFpe(int sig) {
			Console.WriteLine("FPE");
			Environment.Exit(1);
		}
		static void SigSegv(int sig) {
			Logger.Exclusive(() => {
				Console.WriteLine("!!!!Segfault!!!!");
				Console.WriteLine();
				foreach(var thread in Thread.Threads) {
					Console.WriteLine($"Thread {thread.Id}");
					thread.Cpu.DebugRegs();
				}
				Environment.Exit(0);
			});
		}
	}
}