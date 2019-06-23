using System.Collections.Generic;

namespace Common {
	public interface IKernel {
		IEnumerable<(ulong Start, ulong Size)> MemoryRegions { get; }
		void Svc(int svc);
	}
}