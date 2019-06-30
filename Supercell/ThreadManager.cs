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
		//public readonly BaseCpu Cpu = new Unicore(Kernel);

		public readonly ulong Id;
		
		public readonly ulong StackSize = 32UL * 1024 * 1024;
		public readonly ulong StackBase, TlsBase;

		public Thread() {
			_CurrentThread.Value = this;
			lock(Threading)
				Id = ThreadIdIter++;
			
			StackBase = Memory.AllocateAligned(StackSize, 0x10UL << 32);
			$"Stack Base: {StackBase:X}".Debug();
			TlsBase = Cpu.TlsBase = Memory.AllocateAligned(0x1000, 0x11UL << 32);
			$"TLS Base: {TlsBase:X}".Debug();
		}

		public void Run(ulong ep) {
			Cpu.Run(ep, StackBase + StackSize);
		}
	}
	
	public class ThreadManager {
		[Svc(0xC)]
		public static (uint, uint) GetThreadPriority(ulong _, uint threadHandle) {
			$"GetThreadPriority(0x{threadHandle:X})".Debug();
			return (0, 0);
		}

		[Svc(0xD)]
		public static uint SetThreadPriority(uint threadHandle, uint priority) {
			$"SetThreadPriority(0x{threadHandle:X}, 0x{priority:X})".Debug();
			return 0;
		}

		[Svc(0xF)]
		public static uint SetThreadCoreMask(uint threadHandle, uint in1, ulong in2) {
			$"SetThreadCoreMask(0x{threadHandle:X}, 0x{in1:X}, 0x{in2:X})".Debug();
			return 0;
		}

		[Svc(0x10)]
		public static uint GetCurrentProcessorNumber() {
			"GetCurrentProcessorNumber()".Debug();
			return 0;
		}
		
		[Svc(0x25)]
		public static (uint, ulong) GetThreadId(ulong _, uint threadHandle) {
			$"GetThreadId(0x{threadHandle:X})".Debug();
			return (0, 0xf00);
		}
	}
}