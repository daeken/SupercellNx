using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Nifm.Detail {
	public unsafe partial class IStaticService {
		public override Nn.Nifm.Detail.IGeneralService CreateGeneralServiceOld() => new IGeneralService();
		public override Nn.Nifm.Detail.IGeneralService CreateGeneralService(ulong _0, ulong _1) => new IGeneralService();
	}
}