using System;

namespace Supercell.IpcServices.Nn.Pctl.Detail.Ipc {
	public partial class IParentalControlServiceFactory {
		public override Nn.Pctl.Detail.Ipc.IParentalControlService CreateService(ulong _0, ulong _1) =>
			new IParentalControlService();

		public override Nn.Pctl.Detail.Ipc.IParentalControlService CreateServiceWithoutInitialize(ulong _0, ulong _1) =>
			new IParentalControlService();
	}
}