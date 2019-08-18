using System;
using static Supercell.Globals;

namespace Supercell {
	public static class Backtrace {
		public static unsafe void Print(Thread thread = null) {
			var cpu = (thread ?? Thread.CurrentThread).Cpu;
			var isp = cpu.State->SP;
			var pc = cpu.State->PC;
			var sp = isp;
			"Stack Trace".Debug();
			"===========".Debug();
			while(sp >= isp && sp - isp < 1024 * 1024) {
				Kernel.MapAddress(pc).Debug();
				pc = *(ulong*) (sp + 8);
				sp = *(ulong*) sp;
			}
			if(isp != cpu.State->SP)
				$"PDSOFJAPFDOJ".Debug();
			"End?".Debug();
		}
	}
}