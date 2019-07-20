#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfc.Mifare.Detail {
	[IpcService("nfc:mf:u")]
	public unsafe partial class IUserManager : _Base_IUserManager {}
	public unsafe class _Base_IUserManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateUserInterface
					var ret = CreateUserInterface();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUserManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Nfc.Detail.IUser CreateUserInterface() => throw new NotImplementedException();
	}
	
	public unsafe partial class IUser : _Base_IUser {}
	public unsafe class _Base_IUser : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // Finalize
					Finalize();
					break;
				}
				case 2: { // ListDevices
					ListDevices(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 3: { // StartDetection
					StartDetection(im.GetBytes(0, 0x8));
					break;
				}
				case 4: { // StopDetection
					StopDetection(im.GetBytes(0, 0x8));
					break;
				}
				case 5: { // Read
					Read(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 6: { // Write
					Write(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 7: { // GetTagInfo
					GetTagInfo(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 8: { // GetActivateEventHandle
					var ret = GetActivateEventHandle(im.GetBytes(0, 0x8));
					om.Copy(0, ret.Handle);
					break;
				}
				case 9: { // GetDeactivateEventHandle
					var ret = GetDeactivateEventHandle(im.GetBytes(0, 0x8));
					om.Copy(0, ret.Handle);
					break;
				}
				case 10: { // GetState
					var ret = GetState();
					om.SetData(0, ret);
					break;
				}
				case 11: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 12: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 13: { // GetAvailabilityChangeEventHandle
					var ret = GetAvailabilityChangeEventHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUser: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Finalize() => throw new NotImplementedException();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0) => throw new NotImplementedException();
		public virtual void StopDetection(byte[] _0) => throw new NotImplementedException();
		public virtual void Read(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Write(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject GetActivateEventHandle(byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetDeactivateEventHandle(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetAvailabilityChangeEventHandle() => throw new NotImplementedException();
	}
}
