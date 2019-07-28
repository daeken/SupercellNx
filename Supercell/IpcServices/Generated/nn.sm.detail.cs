#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Sm.Detail {
	[IpcService("sm:m")]
	public unsafe partial class IManagerInterface : _Base_IManagerInterface {}
	public unsafe class _Base_IManagerInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RegisterProcess
					RegisterProcess(im.GetData<ulong>(8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // UnregisterProcess
					UnregisterProcess(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerInterface: {im.CommandId}");
			}
		}
		
		public virtual void RegisterProcess(ulong _0, Buffer<byte> _1, Buffer<byte> _2) => "Stub hit for Nn.Sm.Detail.IManagerInterface.RegisterProcess [0]".Debug();
		public virtual void UnregisterProcess(ulong _0) => "Stub hit for Nn.Sm.Detail.IManagerInterface.UnregisterProcess [1]".Debug();
	}
	
	[IpcService("sm:")]
	public unsafe partial class IUserInterface : _Base_IUserInterface {}
	public unsafe class _Base_IUserInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize(im.Pid, im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetService
					var ret = GetService(im.GetBytes(8, 0x8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // RegisterService
					var ret = RegisterService(im.GetBytes(8, 0x8), im.GetData<byte>(16), im.GetData<uint>(20));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // UnregisterService
					UnregisterService(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUserInterface: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong reserved) => "Stub hit for Nn.Sm.Detail.IUserInterface.Initialize [0]".Debug();
		public virtual IpcInterface GetService(byte[] name) => throw new NotImplementedException();
		public virtual IpcInterface RegisterService(byte[] name, byte _1, uint maxHandles) => throw new NotImplementedException();
		public virtual void UnregisterService(byte[] name) => "Stub hit for Nn.Sm.Detail.IUserInterface.UnregisterService [3]".Debug();
	}
}
