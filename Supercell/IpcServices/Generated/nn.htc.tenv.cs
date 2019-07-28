#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Htc.Tenv {
	[IpcService("htc:tenv")]
	public unsafe partial class IServiceManager : _Base_IServiceManager {}
	public unsafe class _Base_IServiceManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetServiceInterface
					var ret = GetServiceInterface(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IServiceManager: {im.CommandId}");
			}
		}
		
		public virtual IpcInterface GetServiceInterface(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IService : _Base_IService {}
	public unsafe class _Base_IService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetVariable
					GetVariable(im.GetBytes(8, 0x40), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 1: { // GetVariableLength
					var ret = GetVariableLength(im.GetBytes(8, 0x40));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 2: { // WaitUntilVariableAvailable
					WaitUntilVariableAvailable(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IService: {im.CommandId}");
			}
		}
		
		public virtual void GetVariable(byte[] _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual ulong GetVariableLength(byte[] _0) => throw new NotImplementedException();
		public virtual void WaitUntilVariableAvailable(ulong _0) => "Stub hit for Nn.Htc.Tenv.IService.WaitUntilVariableAvailable [2]".Debug();
	}
}
