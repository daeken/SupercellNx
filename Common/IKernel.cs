using System;
using System.Collections.Generic;

namespace Common {
	public interface IKernel {
		string MapAddress(ulong addr);
		IEnumerable<(ulong Start, ulong Size)> MemoryRegions { get; }
		void Svc(int svc);
		void Log(string message);
		void LogExclusive(Action cb);
	}
}