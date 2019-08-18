using System;
using static Supercell.Globals;

namespace Supercell {
	public static class Backtrace {
		public static unsafe void Print(Thread thread = null) {
			thread ??= Thread.CurrentThread;
			var cpu = thread.Cpu;
			var isp = cpu.State->SP;
			var osp = cpu.State->X29;
			if(osp > isp && osp - isp <= 0x400)
				isp = osp;
			var pc = cpu.State->PC;
			var sp = isp;
			$"Stack Trace [{thread.Id}]".Debug();
			"===========".Debug();
			while(sp >= isp && sp - isp < 1024 * 1024) {
				Kernel.MapAddress(pc).Debug();
				pc = *(ulong*) (sp + 8);
				sp = *(ulong*) sp;
			}
		}
	}
}