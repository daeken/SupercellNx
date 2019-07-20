#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Sm.Detail {
	[IpcService("sm:m")]
	public unsafe partial class IManagerInterface : _Base_IManagerInterface {}
	public unsafe class _Base_IManagerInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RegisterProcess
					RegisterProcess(im.GetData<ulong>(0), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				case 1: { // UnregisterProcess
					UnregisterProcess(im.GetData<ulong>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerInterface: {im.CommandId}");
			}
		}
		
		public virtual void RegisterProcess(ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void UnregisterProcess(ulong _0) => throw new NotImplementedException();
	}
	
	[IpcService("sm:")]
	public unsafe partial class IUserInterface : _Base_IUserInterface {}
	public unsafe class _Base_IUserInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize(im.Pid, im.GetData<ulong>(0));
					break;
				}
				case 1: { // GetService
					var ret = GetService(im.GetBytes(0, 0x8));
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // RegisterService
					var ret = RegisterService(im.GetBytes(0, 0x8), im.GetData<byte>(8), im.GetData<uint>(12));
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // UnregisterService
					UnregisterService(im.GetBytes(0, 0x8));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUserInterface: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong reserved) => throw new NotImplementedException();
		public virtual IpcInterface GetService(byte[] name) => throw new NotImplementedException();
		public virtual IpcInterface RegisterService(byte[] name, byte _1, uint maxHandles) => throw new NotImplementedException();
		public virtual void UnregisterService(byte[] name) => throw new NotImplementedException();
	}
}
