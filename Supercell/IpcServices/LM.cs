using System;

namespace Supercell.IpcServices.nn.lm {
	[IpcService("lm")]
	public class ILogService : IpcInterface {
		[IpcCommand(0)]
		public void Initialize(ulong unknown, [Pid] ulong pid, [Move] out ILogger logger) =>
			logger = new ILogger();
	}

	public class ILogger : IpcInterface {
		[IpcCommand(0)]
		public void Initialize() {}
		
		[IpcCommand(1)]
		public void SetDestination(uint destination) {}
	}
}