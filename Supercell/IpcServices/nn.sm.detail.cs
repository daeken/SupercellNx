using System;
using System.Text;
using static Supercell.Globals;

namespace Supercell.IpcServices.Nn.Sm.Detail {
	public partial class IUserInterface {
		public override void Initialize(ulong _0, ulong reserved) =>
			"Stub hit for Nn.Sm.Detail.IUserInterface.Initialize [0]".Debug();

		public override IpcInterface GetService(byte[] name) =>
			Ipc.CreateService(Encoding.ASCII.GetString(name).TrimEnd('\0'));

		public override IpcInterface RegisterService(byte[] name, byte _1, uint maxHandles) =>
			throw new NotImplementedException();
		public override void UnregisterService(byte[] name) =>
			"Stub hit for Nn.Sm.Detail.IUserInterface.UnregisterService [3]".Debug();
	}
}
