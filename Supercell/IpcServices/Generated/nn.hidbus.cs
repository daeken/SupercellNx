#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Hidbus {
	[IpcService("hidbus")]
	public unsafe partial class IHidbusServer : _Base_IHidbusServer {}
	public unsafe class _Base_IHidbusServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // GetBusHandle
					var ret = GetBusHandle(null);
					break;
				}
				case 2: { // IsExternalDeviceConnected
					var ret = IsExternalDeviceConnected(null);
					break;
				}
				case 3: { // Initialize
					var ret = Initialize(null);
					break;
				}
				case 4: { // Finalize
					var ret = Finalize(null);
					break;
				}
				case 5: { // EnableExternalDevice
					var ret = EnableExternalDevice(null);
					break;
				}
				case 6: { // GetExternalDeviceId
					var ret = GetExternalDeviceId(null);
					break;
				}
				case 7: { // SendCommandAsync
					var ret = SendCommandAsync(null);
					break;
				}
				case 8: { // GetSendCommandAsynceResult
					var ret = GetSendCommandAsynceResult(null);
					break;
				}
				case 9: { // SetEventForSendCommandAsycResult
					var ret = SetEventForSendCommandAsycResult(null);
					break;
				}
				case 10: { // GetSharedMemoryHandle
					var ret = GetSharedMemoryHandle(null);
					break;
				}
				case 11: { // EnableJoyPollingReceiveMode
					var ret = EnableJoyPollingReceiveMode(null);
					break;
				}
				case 12: { // DisableJoyPollingReceiveMode
					var ret = DisableJoyPollingReceiveMode(null);
					break;
				}
				case 13: { // GetPollingData
					var ret = GetPollingData(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidbusServer: {im.CommandId}");
			}
		}
		
		public virtual object GetBusHandle(object _0) => throw new NotImplementedException();
		public virtual object IsExternalDeviceConnected(object _0) => throw new NotImplementedException();
		public virtual object Initialize(object _0) => throw new NotImplementedException();
		public virtual object Finalize(object _0) => throw new NotImplementedException();
		public virtual object EnableExternalDevice(object _0) => throw new NotImplementedException();
		public virtual object GetExternalDeviceId(object _0) => throw new NotImplementedException();
		public virtual object SendCommandAsync(object _0) => throw new NotImplementedException();
		public virtual object GetSendCommandAsynceResult(object _0) => throw new NotImplementedException();
		public virtual object SetEventForSendCommandAsycResult(object _0) => throw new NotImplementedException();
		public virtual object GetSharedMemoryHandle(object _0) => throw new NotImplementedException();
		public virtual object EnableJoyPollingReceiveMode(object _0) => throw new NotImplementedException();
		public virtual object DisableJoyPollingReceiveMode(object _0) => throw new NotImplementedException();
		public virtual object GetPollingData(object _0) => throw new NotImplementedException();
	}
}
