#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfc.Detail {
	[IpcService("nfc:sys")]
	public unsafe partial class ISystemManager : _Base_ISystemManager {}
	public unsafe class _Base_ISystemManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateSystemInterface
					var ret = CreateSystemInterface();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Nfc.Detail.ISystem CreateSystemInterface() => throw new NotImplementedException();
	}
	
	[IpcService("nfc:user")]
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
		
		public virtual Nn.Nfc.Mifare.Detail.IUser CreateUserInterface() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystem : _Base_ISystem {}
	public unsafe class _Base_ISystem : IpcInterface {
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
				case 2: { // GetStateOld
					var ret = GetStateOld();
					om.SetData(0, ret);
					break;
				}
				case 3: { // IsNfcEnabledOld
					var ret = IsNfcEnabledOld();
					om.SetData(0, ret);
					break;
				}
				case 100: { // SetNfcEnabledOld
					SetNfcEnabledOld(im.GetData<byte>(0));
					break;
				}
				case 400: { // InitializeSystem
					InitializeSystem(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 401: { // FinalizeSystem
					FinalizeSystem();
					break;
				}
				case 402: { // GetState
					var ret = GetState();
					om.SetData(0, ret);
					break;
				}
				case 403: { // IsNfcEnabled
					var ret = IsNfcEnabled();
					om.SetData(0, ret);
					break;
				}
				case 404: { // ListDevices
					ListDevices(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 405: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 406: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 407: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 408: { // StartDetection
					StartDetection(im.GetBytes(0, 0x8), im.GetData<uint>(8));
					break;
				}
				case 409: { // StopDetection
					StopDetection(im.GetBytes(0, 0x8));
					break;
				}
				case 410: { // GetTagInfo
					GetTagInfo(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 411: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(0, 0x8));
					om.Copy(0, ret.Handle);
					break;
				}
				case 412: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(0, 0x8));
					om.Copy(0, ret.Handle);
					break;
				}
				case 500: { // SetNfcEnabled
					SetNfcEnabled(im.GetData<byte>(0));
					break;
				}
				case 1000: { // ReadMifare
					ReadMifare(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1001: { // WriteMifare
					WriteMifare(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1300: { // SendCommandByPassThrough
					SendCommandByPassThrough(im.GetBytes(0, 0x8), im.GetData<ulong>(8), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1301: { // KeepPassThroughSession
					KeepPassThroughSession(im.GetBytes(0, 0x8));
					break;
				}
				case 1302: { // ReleasePassThroughSession
					ReleasePassThroughSession(im.GetBytes(0, 0x8));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystem: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Finalize() => throw new NotImplementedException();
		public virtual uint GetStateOld() => throw new NotImplementedException();
		public virtual byte IsNfcEnabledOld() => throw new NotImplementedException();
		public virtual void SetNfcEnabledOld(byte _0) => throw new NotImplementedException();
		public virtual void InitializeSystem(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void FinalizeSystem() => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual byte IsNfcEnabled() => throw new NotImplementedException();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0, uint _1) => throw new NotImplementedException();
		public virtual void StopDetection(byte[] _0) => throw new NotImplementedException();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual void SetNfcEnabled(byte _0) => throw new NotImplementedException();
		public virtual void ReadMifare(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void WriteMifare(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SendCommandByPassThrough(byte[] _0, ulong _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void KeepPassThroughSession(byte[] _0) => throw new NotImplementedException();
		public virtual void ReleasePassThroughSession(byte[] _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IUser : _Base_IUser {}
	public unsafe class _Base_IUser : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // InitializeOld
					InitializeOld(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // FinalizeOld
					FinalizeOld();
					break;
				}
				case 2: { // GetStateOld
					var ret = GetStateOld();
					om.SetData(0, ret);
					break;
				}
				case 3: { // IsNfcEnabledOld
					var ret = IsNfcEnabledOld();
					om.SetData(0, ret);
					break;
				}
				case 400: { // Initialize
					Initialize(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 401: { // Finalize
					Finalize();
					break;
				}
				case 402: { // GetState
					var ret = GetState();
					om.SetData(0, ret);
					break;
				}
				case 403: { // IsNfcEnabled
					var ret = IsNfcEnabled();
					om.SetData(0, ret);
					break;
				}
				case 404: { // ListDevices
					ListDevices(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 405: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 406: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 407: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 408: { // StartDetection
					StartDetection(im.GetBytes(0, 0x8), im.GetData<uint>(8));
					break;
				}
				case 409: { // StopDetection
					StopDetection(im.GetBytes(0, 0x8));
					break;
				}
				case 410: { // GetTagInfo
					GetTagInfo(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 411: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(0, 0x8));
					om.Copy(0, ret.Handle);
					break;
				}
				case 412: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(0, 0x8));
					om.Copy(0, ret.Handle);
					break;
				}
				case 1000: { // ReadMifare
					ReadMifare(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1001: { // WriteMifare
					WriteMifare(im.GetBytes(0, 0x8), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1300: { // SendCommandByPassThrough
					SendCommandByPassThrough(im.GetBytes(0, 0x8), im.GetData<ulong>(8), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1301: { // KeepPassThroughSession
					KeepPassThroughSession(im.GetBytes(0, 0x8));
					break;
				}
				case 1302: { // ReleasePassThroughSession
					ReleasePassThroughSession(im.GetBytes(0, 0x8));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUser: {im.CommandId}");
			}
		}
		
		public virtual void InitializeOld(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void FinalizeOld() => throw new NotImplementedException();
		public virtual uint GetStateOld() => throw new NotImplementedException();
		public virtual byte IsNfcEnabledOld() => throw new NotImplementedException();
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Finalize() => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual byte IsNfcEnabled() => throw new NotImplementedException();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0, uint _1) => throw new NotImplementedException();
		public virtual void StopDetection(byte[] _0) => throw new NotImplementedException();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual void ReadMifare(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void WriteMifare(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SendCommandByPassThrough(byte[] _0, ulong _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void KeepPassThroughSession(byte[] _0) => throw new NotImplementedException();
		public virtual void ReleasePassThroughSession(byte[] _0) => throw new NotImplementedException();
	}
}
