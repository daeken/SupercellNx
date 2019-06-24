using System.Text;
using static Supercell.Globals;

namespace Supercell.IpcServices.nn.sm.detail {
	[IpcService("sm:")]
	public class IUserInterface : IpcInterface {
		[IpcCommand(0)]
		public void Initialize([Pid] ulong _, ulong __) {}

		[IpcCommand(1)]
		public void GetService([Bytes(8)] byte[] name, [Move] out IpcInterface session) =>
			session = Ipc.CreateService(Encoding.ASCII.GetString(name).TrimEnd('\0'));
	}
}
