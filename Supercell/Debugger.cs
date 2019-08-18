using System;
using System.Collections.Generic;
using System.Net;
using GdbStub;

namespace Supercell {
	public class DebugTarget : IDebugTarget {
		public event Action<TrapType> Trapped;
		public int RegisterSize { get; } = 64;
		public RegisterSet Registers { get; } = new Arm64RegisterSet();

		public ulong this[string reg] {
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public uint ThreadId { get; set; }
		public Dictionary<uint, string> Threads { get; }
		public byte[] ReadMemory(ulong addr, uint size) => throw new NotImplementedException();

		public void WriteMemory(ulong addr, byte[] data) {
			throw new NotImplementedException();
		}

		public void AddBreakpoint(BreakpointType type, ulong addr) {
			throw new NotImplementedException();
		}

		public void RemoveBreakpoint(BreakpointType type, ulong addr) {
			throw new NotImplementedException();
		}

		public void SingleStep(uint? threadId = null) {
			throw new NotImplementedException();
		}

		public void Continue(uint? threadId = null) {
			throw new NotImplementedException();
		}

		public void BreakIn() {
			throw new NotImplementedException();
		}
	}

	public class Debugger {
		public static void Start() =>
			new System.Threading.Thread(() =>
				new Gdb<DebugTarget>(new DebugTarget(), IPEndPoint.Parse("127.0.0.1:12345")).Run()).Start();
	}
}