#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Fatalsrv {
	[IpcService("fatal:p")]
	public unsafe partial class IPrivateService : _Base_IPrivateService {}
	public unsafe class _Base_IPrivateService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetFatalEvent
					var ret = GetFatalEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPrivateService: {im.CommandId}");
			}
		}
		
		public virtual KObject GetFatalEvent() => throw new NotImplementedException();
	}
	
	[IpcService("fatal:u")]
	public unsafe partial class IService : _Base_IService {}
	public unsafe class _Base_IService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ThrowFatal
					ThrowFatal(null, im.Pid);
					break;
				}
				case 1: { // ThrowFatalWithPolicy
					ThrowFatalWithPolicy(null, im.Pid);
					break;
				}
				case 2: { // ThrowFatalWithCpuContext
					ThrowFatalWithCpuContext(null, im.Pid, im.GetBuffer<byte>(0x15, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IService: {im.CommandId}");
			}
		}
		
		public virtual void ThrowFatal(object _0, ulong _1) => throw new NotImplementedException();
		public virtual void ThrowFatalWithPolicy(object _0, ulong _1) => throw new NotImplementedException();
		public virtual void ThrowFatalWithCpuContext(object _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
}
