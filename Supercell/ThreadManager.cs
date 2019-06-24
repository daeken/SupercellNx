using System;
using System.Threading;
using Common;
using Cpu64;
using static Supercell.Globals;

namespace Supercell {
	public class Thread : KObject {
		static readonly ThreadLocal<Thread> _CurrentThread = new ThreadLocal<Thread>();
		public static Thread CurrentThread => _CurrentThread.Value;
		static ulong ThreadIdIter;
		//public readonly BaseCpu Cpu = new Interpreter(Kernel);
		public readonly BaseCpu Cpu = new Recompiler(Kernel);

		public readonly ulong Id;
		
		public readonly ulong StackSize = 32UL * 1024 * 1024;
		public readonly ulong StackBase, TlsBase;

		public unsafe Thread() {
			_CurrentThread.Value = this;
			lock(Threading)
				Id = ThreadIdIter++;
			
			StackBase = Memory.AllocateAligned(StackSize);
			TlsBase = Cpu.TlsBase = Memory.AllocateAligned(0x1000);
			*(ulong*) (Cpu.TlsBase + 0x1F8) = Cpu.TlsBase + 0x400;
		}

		public void Run(ulong ep) {
			Cpu.Run(ep, StackBase + StackSize);
		}
	}
	
	public class ThreadManager {
		[Svc(0xC)]
		public static (uint, uint) GetThreadPriority(ulong _, uint threadHandle) {
			$"GetThreadPriority({threadHandle})".Debug();
			return (0, 0);
		}
		
		[Svc(0x25)]
		public static (uint, ulong) GetThreadId(ulong _, uint threadHandle) {
			$"GetThreadId({threadHandle})".Debug();
			return (0, 0xf00);
		}
	}
}