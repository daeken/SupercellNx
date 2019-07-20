using System;

namespace Supercell.IpcServices.Nn.Apm {
	public partial class IManager {
		public override Nn.Apm.ISession OpenSession() => new ISession();
		public override uint GetPerformanceMode() => throw new NotImplementedException();
	}

	public partial class ISession {
		public override void SetPerformanceConfiguration(uint _0, uint _1) {}
		public override uint GetPerformanceConfiguration(uint _0) => 0;
	}
}