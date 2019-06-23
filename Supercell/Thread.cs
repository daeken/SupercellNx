using Common;

namespace Supercell {
	public class Thread {
		[Svc(0xC)]
		public static (uint, uint) GetThreadPriority(ulong _, uint threadHandle) {
			$"GetThreadPriority({threadHandle})".Debug();
			return (0, 0);
		}
		
		[Svc(0x25)]
		public static (uint, ulong) GetThreadId(ulong _, uint threadHandle) {
			$"GetThreadId({threadHandle})".Debug();
			return (0, 0xf00);
		}
	}
}