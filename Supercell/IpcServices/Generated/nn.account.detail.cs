#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Account.Detail {
	public unsafe partial class IAsyncContext : _Base_IAsyncContext {}
	public unsafe class _Base_IAsyncContext : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSystemEvent
					var ret = GetSystemEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Cancel
					Cancel();
					break;
				}
				case 2: { // HasDone
					var ret = HasDone();
					om.SetData(0, ret);
					break;
				}
				case 3: { // GetResult
					GetResult();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncContext: {im.CommandId}");
			}
		}
		
		public virtual KObject GetSystemEvent() => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
		public virtual byte HasDone() => throw new NotImplementedException();
		public virtual void GetResult() => throw new NotImplementedException();
	}
	
	public unsafe partial class INotifier : _Base_INotifier {}
	public unsafe class _Base_INotifier : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSystemEvent
					var ret = GetSystemEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INotifier: {im.CommandId}");
			}
		}
		
		public virtual KObject GetSystemEvent() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISessionObject : _Base_ISessionObject {}
	public unsafe class _Base_ISessionObject : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 999: { // Dummy
					Dummy();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISessionObject: {im.CommandId}");
			}
		}
		
		public virtual void Dummy() => throw new NotImplementedException();
	}
}
