using System;

namespace Supercell.IpcServices.nn.apm {
	[IpcService("apm")]
	public class IManager : IpcInterface {
		[IpcCommand(0)]
		void OpenSession([Move] out ISession session) => session = new ISession();
		
		[IpcCommand(1)]
		void GetPerformanceMode(out uint /* nn::apm::PerformanceMode */ performanceMode) => throw new NotImplementedException();
	}

	public class ISession : IpcInterface {
		[IpcCommand(0)]
		void SetPerformanceConfiguration(uint /* nn::apm::PerformanceMode */ performanceMode,
			uint /* nn::apm::PerformanceConfiguration */ configuration) {}

		[IpcCommand(1)]
		void GetPerformanceConfiguration(uint /* nn::apm::PerformanceMode */ performanceMode,
			out uint /* nn::apm::PerformanceConfiguration */ configuration) => configuration = 0;
	}
}