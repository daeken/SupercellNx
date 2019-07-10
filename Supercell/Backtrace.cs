using System;
using static Supercell.Globals;

namespace Supercell {
	public static class Backtrace {
		public static unsafe void Print() {
			var cpu = Thread.CurrentThread.Cpu;
			var isp = cpu.SP;
			var sp = isp;
			var pc = cpu.PC;
			"Stack Trace".Debug();
			"===========".Debug();
			while(sp >= isp && sp - isp < 1024 * 1024) {
				Kernel.MapAddress(pc).Debug();
				pc = *(ulong*) (sp + 8);
				sp = *(ulong*) sp;
			}
		}
	}
}