using System;
using System.Collections.Generic;

namespace GdbStub {
	public enum BreakpointType {
		Execute, 
		Read, 
		Write, 
		Access
	}

	public enum TrapType {
		None = 0, 
		Segfault = 14, 
		Breakpoint = 5, 
		SingleStep = 0
	}

	public interface IDebugTarget {
		event Action<TrapType> Trapped;
		
		int RegisterSize { get; } // Bits
		RegisterSet Registers { get; }
		ulong this[string reg] { get; set; }
		uint ThreadId { get; set; }
		Dictionary<uint, string> Threads { get; } // ID -> status/extra info (null if just running)
		byte[] ReadMemory(ulong addr, uint size);
		void WriteMemory(ulong addr, byte[] data);
		void AddBreakpoint(BreakpointType type, ulong addr);
		void RemoveBreakpoint(BreakpointType type, ulong addr);
		void SingleStep(uint? threadId = null);
		void Continue(uint? threadId = null);
		void BreakIn();
	}
}