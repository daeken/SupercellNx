using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Common;
using Cpu64;
using static Supercell.Globals;

namespace Supercell {
	public unsafe class Thread : KObject {
		static readonly ThreadLocal<Thread> _CurrentThread = new ThreadLocal<Thread>();
		public static readonly List<Thread> Threads = new List<Thread>();
		public static Thread CurrentThread => _CurrentThread.Value;
		static ulong ThreadIdIter;
		
		//public readonly BaseCpu Cpu = new Interpreter(Kernel);
		public readonly BaseCpu Cpu = new Dynarec(Kernel);
		//public readonly BaseCpu Cpu = new LlvmRecompiler(Kernel);
		//public readonly BaseCpu Cpu = new Unicore(Kernel);

		public System.Threading.Thread SystemThread;
		public readonly ulong Id;

		public readonly ulong Stack, TlsBase;

		public string Name =>
			(Memory.IsGoodPointer(*(ulong*) (Cpu.State->TlsBase + 0x1F8))
				? Marshal.PtrToStringUTF8((IntPtr) (*(ulong*) (Cpu.State->TlsBase + 0x1F8) + 0x188))
				: "") switch { "" => "<unknown thread name>", var x => x };

		public Thread(ulong isp = 0) {
			SystemThread = System.Threading.Thread.CurrentThread;
			Threads.Add(this);
			if(isp == 0)
				_CurrentThread.Value = this;
			lock(Threading)
				Id = ThreadIdIter++;
			
			if(isp == 0) {
				var (stack, stackSize) = Memory.AllocateStack();
				Stack = stack + stackSize;
				$"Stack Base: {Stack - stackSize:X}".Debug();
			} else {
				Stack = isp;
				$"Stack Top: {Stack:X}".Debug();
			}
			TlsBase = Cpu.State->TlsBase = Memory.AllocateAligned(0x10000, (0x11UL << 32) + 0x10000UL * Id);
			$"TLS Base: {TlsBase:X}".Debug();
		}

		public void Run(ulong ep) {
			_CurrentThread.Value = this;
			try {
				Cpu.Run(ep, Stack);
			} catch(TargetInvocationException e) {
				Logger.Exclusive(() => {
					Backtrace.Print();
					Console.WriteLine($"Unhandled exception on thread {CurrentThread.Id}");
					Console.WriteLine(e.InnerException);
					Environment.Exit(1);
				});
			}
		}
	}

	public class SpawnedThread : Thread {
		public readonly ulong EntryPoint;
		public unsafe SpawnedThread(ulong ep, ulong context, ulong stack) : base(stack) {
			EntryPoint = ep;
			Cpu.State->X0 = context;
		}
	}
	
	public class ThreadManager {
		[Svc(0x8)]
		public static (uint, uint) CreateThread(ulong _, ulong entry, ulong threadContext, ulong stackTop, uint priority, uint processorId) {
			var nthread = new SpawnedThread(entry, threadContext, stackTop);
			return (0, nthread.Handle);
		}

		[Svc(0x9)]
		public static uint StartThread(uint handle) {
			var thread = Kernel.Get<SpawnedThread>(handle);
			new System.Threading.Thread(() => thread.Run(thread.EntryPoint)).Start();
			return 0;
		}
		
		[Svc(0xB)]
		public void SleepThread(long nanoseconds) {
			if(nanoseconds > 0)
				System.Threading.Thread.Sleep(new TimeSpan(nanoseconds / 100));
		}

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
			return (0, Thread.CurrentThread.Id);
		}
	}
}