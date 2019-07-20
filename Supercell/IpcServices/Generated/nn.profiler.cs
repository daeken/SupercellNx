#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Profiler {
	[IpcService("banana")]
	public unsafe partial class IProfiler : _Base_IProfiler {}
	public unsafe class _Base_IProfiler : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSystemEvent
					var ret = GetSystemEvent(null);
					break;
				}
				case 1: { // StartSignalingEvent
					var ret = StartSignalingEvent(null);
					break;
				}
				case 2: { // StopSignalingEvent
					var ret = StopSignalingEvent(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProfiler: {im.CommandId}");
			}
		}
		
		public virtual object GetSystemEvent(object _0) => throw new NotImplementedException();
		public virtual object StartSignalingEvent(object _0) => throw new NotImplementedException();
		public virtual object StopSignalingEvent(object _0) => throw new NotImplementedException();
	}
}
