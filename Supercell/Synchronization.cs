using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Common;
using MoreLinq;
using static Supercell.Globals;

namespace Supercell {
	public abstract class Waitable : KObject {
		public readonly Queue<Func<bool, int>> Waiters = new Queue<Func<bool, int>>();
		public bool Presignaled, Canceled;
		
		protected virtual bool Presignalable => true;

		public bool Wait() {
			var wait = new AutoResetEvent(false);
			var canceled = false;
			Wait(_canceled => {
				canceled = _canceled;
				wait.Set();
				return 1;
			});
			wait.DebugWaitOne();
			return canceled;
		}
		public void Wait(Func<int> cb) => Wait(_ => cb());
		public virtual void Wait(Func<bool, int> cb) {
			lock(this) {
				if(!Presignaled || (Presignaled && cb(Canceled) == 0))
					Waiters.Enqueue(cb);
				Presignaled = false;
				Canceled = false;
			}
		}

		public void Signal(bool one = false) {
			lock(this) {
				if(Waiters.Count == 0 && Presignalable)
					Presignaled = true;
				else {
					var realHit = false;
					while(Waiters.TryDequeue(out var waiter)) {
						var res = waiter(Canceled);
						if(res == 0)
							Waiters.Enqueue(waiter);
						if(res != -1) {
							realHit = true;
							if(one)
								break;
						}
					}
					if(!realHit && Presignalable)
						Presignaled = true;
				}
			}
		}

		public void Cancel() {
			lock(this) {
				Canceled = true;
				Signal();
			}
		}
	}
	
	public unsafe class Semaphore : Waitable {
		public readonly uint* Addr;
		public uint Value {
			get {
				lock(this)
					return *Addr;
			}
		}

		public Semaphore(ulong addr) => Addr = (uint*) addr;
		protected override bool Presignalable => false;

		public void Increment() {
			lock(this)
				(*Addr)++;
		}
		
		public void Decrement() {
			lock(this)
				(*Addr)--;
		}
	}

	public class Event : Waitable {
		bool _Triggered;
		public bool Triggered {
			get => _Triggered;
			set {
				var doSignal = !_Triggered && value; 
				_Triggered = value;
				if(doSignal) Signal();
			}
		}

		public Event(bool? triggered = null) {
			if(triggered != null)
				Triggered = triggered.Value;
		}
	}

	public class Synchronization {
		public static readonly Synchronization Instance = new Synchronization();

		readonly Dictionary<ulong, Semaphore> Semaphores = new Dictionary<ulong, Semaphore>();
		readonly Dictionary<ulong, Mutex> Mutexes = new Dictionary<ulong, Mutex>();

		Semaphore EnsureSemaphore(ulong addr) => Semaphores.TryGetValue(addr, out var sema)
			? sema
			: Semaphores[addr] = new Semaphore(addr);

		Mutex EnsureMutex(ulong addr) => Mutexes.TryGetValue(addr, out var mutex)
			? mutex
			: Mutexes[addr] = new Mutex();

		[Svc(0x12)]
		public uint ClearEvent(uint handle) {
			$"ClearEvent(0x{handle:X})".Debug();
			var evt = Kernel.Get<Event>(handle);
			evt.Triggered = false;
			return 0;
		}
		
		[Svc(0x17)]
		public uint ResetSignal(uint handle) {
			$"ResetSignal(0x{handle:X})".Debug();
			var evt = Kernel.Get<Event>(handle);
			evt.Triggered = false;
			return 0;
		}

		[Svc(0x18)]
		public (uint, uint) WaitSynchronization(ulong _, ulong handlesAddr, uint numHandles, ulong timeout) {
			$"WaitSynchronization(0x{handlesAddr:X}, {numHandles})".Debug();
			var handles = new Buffer<uint>(handlesAddr, numHandles * 4);
			var waitHandle = new AutoResetEvent(false);
			var activated = uint.MaxValue;
			handles.ForEach((handle, i) => Kernel.Get<Waitable>(handle).Wait(() => {
				lock(waitHandle) {
					activated = (uint) i;
					waitHandle.Set();
					return 1;
				}
			}));
			waitHandle.DebugWaitOne();
			return (0, activated);
		}

		[Svc(0x1A)]
		public unsafe uint LockMutex(uint curThreadHandle, ulong addr, uint reqThreadHandle) {
			$"LockMutex(0x{curThreadHandle:X}, 0x{addr:X}, 0x{reqThreadHandle:X})".Debug();
			EnsureMutex(addr).WaitOne();
			"Locked mutex".Debug();
			*(uint*) addr = (*(uint*) addr & 0x40000000) | reqThreadHandle;
			return 0;
		}

		[Svc(0x1B)]
		public unsafe uint UnlockMutex(ulong addr) {
			$"UnlockMutex(0x{addr:X})".Debug();
			*(uint*) addr = *(uint*) addr & 0x40000000;
			try {
				EnsureMutex(addr).ReleaseMutex();
			} catch(ApplicationException) {
			}
			return 0;
		}

		[Svc(0x1C)]
		public unsafe uint WaitProcessWideKeyAtomic(ulong mutexAddr, ulong semaAddr, uint threadHandle, uint timeout) {
			$"WaitProcessWideKeyAtomic(0x{mutexAddr:X}, 0x{semaAddr:X}, 0x{threadHandle:X})".Debug();
			var mutex = EnsureMutex(mutexAddr);
			var sema = EnsureSemaphore(semaAddr);
			//Debug.Assert((*(uint*) mutexAddr & ~0x40000000U) == threadHandle);
			if(sema.Value > 0) {
				$"Early bailout 0x{sema.Value:X}".Debug();
				sema.Decrement();
				return 0;
			}
			UnlockMutex(mutexAddr);
			sema.Wait();
			LockMutex(0, mutexAddr, threadHandle);
			"Waited".Debug();
			sema.Decrement();
			return 0;
		}

		[Svc(0x1D)]
		public uint SignalProcessWideKey(ulong semaAddr, uint target) {
			var semaphore = EnsureSemaphore(semaAddr);
			semaphore.Increment();
			if(target == 1)
				semaphore.Signal(true);
			else if(target == 0xFFFFFFFF)
				semaphore.Signal();
			return 0;
		}
	}
}