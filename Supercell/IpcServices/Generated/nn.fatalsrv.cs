#pragma warning disable 169, 465
using System;
using UltimateOrb;
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
					ThrowFatal(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 1: { // ThrowFatalWithPolicy
					ThrowFatalWithPolicy(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 2: { // ThrowFatalWithCpuContext
					ThrowFatalWithCpuContext(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetBuffer<byte>(0x15, 0), im.Pid);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IService: {im.CommandId}");
			}
		}
		
		public virtual void ThrowFatal(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ThrowFatalWithPolicy(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ThrowFatalWithCpuContext(ulong errorCode, ulong _1, Buffer<byte> errorBuf, ulong _3) => throw new NotImplementedException();
	}
}
