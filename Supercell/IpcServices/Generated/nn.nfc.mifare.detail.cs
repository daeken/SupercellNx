#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfc.Mifare.Detail {
	[IpcService("nfc:mf:u")]
	public unsafe partial class IUserManager : _Base_IUserManager {}
	public unsafe class _Base_IUserManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateUserInterface
					var ret = CreateUserInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Finalize
					Finalize();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // ListDevices
					ListDevices(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 3: { // StartDetection
					StartDetection(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // StopDetection
					StopDetection(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Read
					Read(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Write
					Write(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // GetTagInfo
					GetTagInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // GetActivateEventHandle
					var ret = GetActivateEventHandle(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 9: { // GetDeactivateEventHandle
					var ret = GetDeactivateEventHandle(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 10: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 11: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 12: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 13: { // GetAvailabilityChangeEventHandle
					var ret = GetAvailabilityChangeEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUser: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfc.Mifare.Detail.IUser.Initialize [0]".Debug();
		public virtual void Finalize() => "Stub hit for Nn.Nfc.Mifare.Detail.IUser.Finalize [1]".Debug();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0) => "Stub hit for Nn.Nfc.Mifare.Detail.IUser.StartDetection [3]".Debug();
		public virtual void StopDetection(byte[] _0) => "Stub hit for Nn.Nfc.Mifare.Detail.IUser.StopDetection [4]".Debug();
		public virtual void Read(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Write(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfc.Mifare.Detail.IUser.Write [6]".Debug();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject GetActivateEventHandle(byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetDeactivateEventHandle(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetAvailabilityChangeEventHandle() => throw new NotImplementedException();
	}
}
