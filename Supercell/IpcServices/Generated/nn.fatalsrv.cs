#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Fatalsrv {
	[IpcService("fatal:p")]
	public unsafe partial class IPrivateService : _Base_IPrivateService {}
	public unsafe class _Base_IPrivateService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetFatalEvent
					var ret = GetFatalEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ThrowFatal
					ThrowFatal(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // ThrowFatalWithPolicy
					ThrowFatalWithPolicy(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // ThrowFatalWithCpuContext
					ThrowFatalWithCpuContext(im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x15, 0), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IService: {im.CommandId}");
			}
		}
		
		public virtual void ThrowFatal(ulong _0, ulong _1, ulong _2) => "Stub hit for Nn.Fatalsrv.IService.ThrowFatal [0]".Debug();
		public virtual void ThrowFatalWithPolicy(ulong _0, ulong _1, ulong _2) => "Stub hit for Nn.Fatalsrv.IService.ThrowFatalWithPolicy [1]".Debug();
		public virtual void ThrowFatalWithCpuContext(ulong errorCode, ulong _1, Buffer<byte> errorBuf, ulong _3) => "Stub hit for Nn.Fatalsrv.IService.ThrowFatalWithCpuContext [2]".Debug();
	}
}
