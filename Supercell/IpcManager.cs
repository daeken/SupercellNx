using System;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using PrettyPrinter;

namespace Supercell {
	public class IpcManager {
		[Svc(0x1F)]
		public (uint, uint) ConnectToNamedPort(uint _, ulong _name) {
			var name = Marshal.PtrToStringAnsi((IntPtr) _name);
			$"ConnectToNamedPort({name.ToPrettyString()})".Debug();
			return (0, 0);
		}
	}
}