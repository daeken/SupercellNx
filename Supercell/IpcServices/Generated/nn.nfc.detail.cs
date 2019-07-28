#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfc.Detail {
	[IpcService("nfc:sys")]
	public unsafe partial class ISystemManager : _Base_ISystemManager {}
	public unsafe class _Base_ISystemManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateSystemInterface
					var ret = CreateSystemInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
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
		
		public virtual Nn.Nfc.Mifare.Detail.IUser CreateUserInterface() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystem : _Base_ISystem {}
	public unsafe class _Base_ISystem : IpcInterface {
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
				case 2: { // GetStateOld
					var ret = GetStateOld();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 3: { // IsNfcEnabledOld
					var ret = IsNfcEnabledOld();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 100: { // SetNfcEnabledOld
					SetNfcEnabledOld(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 400: { // InitializeSystem
					InitializeSystem(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 401: { // FinalizeSystem
					FinalizeSystem();
					om.Initialize(0, 0, 0);
					break;
				}
				case 402: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 403: { // IsNfcEnabled
					var ret = IsNfcEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 404: { // ListDevices
					ListDevices(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 405: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 406: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 407: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 408: { // StartDetection
					StartDetection(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 409: { // StopDetection
					StopDetection(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 410: { // GetTagInfo
					GetTagInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 411: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 412: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 500: { // SetNfcEnabled
					SetNfcEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1000: { // ReadMifare
					ReadMifare(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1001: { // WriteMifare
					WriteMifare(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1300: { // SendCommandByPassThrough
					SendCommandByPassThrough(im.GetBytes(8, 0x8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 1301: { // KeepPassThroughSession
					KeepPassThroughSession(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1302: { // ReleasePassThroughSession
					ReleasePassThroughSession(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystem: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfc.Detail.ISystem.Initialize [0]".Debug();
		public virtual void Finalize() => "Stub hit for Nn.Nfc.Detail.ISystem.Finalize [1]".Debug();
		public virtual uint GetStateOld() => throw new NotImplementedException();
		public virtual byte IsNfcEnabledOld() => throw new NotImplementedException();
		public virtual void SetNfcEnabledOld(byte _0) => "Stub hit for Nn.Nfc.Detail.ISystem.SetNfcEnabledOld [100]".Debug();
		public virtual void InitializeSystem(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfc.Detail.ISystem.InitializeSystem [400]".Debug();
		public virtual void FinalizeSystem() => "Stub hit for Nn.Nfc.Detail.ISystem.FinalizeSystem [401]".Debug();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual byte IsNfcEnabled() => throw new NotImplementedException();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0, uint _1) => "Stub hit for Nn.Nfc.Detail.ISystem.StartDetection [408]".Debug();
		public virtual void StopDetection(byte[] _0) => "Stub hit for Nn.Nfc.Detail.ISystem.StopDetection [409]".Debug();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual void SetNfcEnabled(byte _0) => "Stub hit for Nn.Nfc.Detail.ISystem.SetNfcEnabled [500]".Debug();
		public virtual void ReadMifare(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void WriteMifare(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfc.Detail.ISystem.WriteMifare [1001]".Debug();
		public virtual void SendCommandByPassThrough(byte[] _0, ulong _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void KeepPassThroughSession(byte[] _0) => "Stub hit for Nn.Nfc.Detail.ISystem.KeepPassThroughSession [1301]".Debug();
		public virtual void ReleasePassThroughSession(byte[] _0) => "Stub hit for Nn.Nfc.Detail.ISystem.ReleasePassThroughSession [1302]".Debug();
	}
	
	public unsafe partial class IUser : _Base_IUser {}
	public unsafe class _Base_IUser : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // InitializeOld
					InitializeOld(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // FinalizeOld
					FinalizeOld();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetStateOld
					var ret = GetStateOld();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 3: { // IsNfcEnabledOld
					var ret = IsNfcEnabledOld();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 400: { // Initialize
					Initialize(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 401: { // Finalize
					Finalize();
					om.Initialize(0, 0, 0);
					break;
				}
				case 402: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 403: { // IsNfcEnabled
					var ret = IsNfcEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 404: { // ListDevices
					ListDevices(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 405: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 406: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 407: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 408: { // StartDetection
					StartDetection(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 409: { // StopDetection
					StopDetection(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 410: { // GetTagInfo
					GetTagInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 411: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 412: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1000: { // ReadMifare
					ReadMifare(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1001: { // WriteMifare
					WriteMifare(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1300: { // SendCommandByPassThrough
					SendCommandByPassThrough(im.GetBytes(8, 0x8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 1301: { // KeepPassThroughSession
					KeepPassThroughSession(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1302: { // ReleasePassThroughSession
					ReleasePassThroughSession(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUser: {im.CommandId}");
			}
		}
		
		public virtual void InitializeOld(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfc.Detail.IUser.InitializeOld [0]".Debug();
		public virtual void FinalizeOld() => "Stub hit for Nn.Nfc.Detail.IUser.FinalizeOld [1]".Debug();
		public virtual uint GetStateOld() => throw new NotImplementedException();
		public virtual byte IsNfcEnabledOld() => throw new NotImplementedException();
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfc.Detail.IUser.Initialize [400]".Debug();
		public virtual void Finalize() => "Stub hit for Nn.Nfc.Detail.IUser.Finalize [401]".Debug();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual byte IsNfcEnabled() => throw new NotImplementedException();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0, uint _1) => "Stub hit for Nn.Nfc.Detail.IUser.StartDetection [408]".Debug();
		public virtual void StopDetection(byte[] _0) => "Stub hit for Nn.Nfc.Detail.IUser.StopDetection [409]".Debug();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual void ReadMifare(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void WriteMifare(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfc.Detail.IUser.WriteMifare [1001]".Debug();
		public virtual void SendCommandByPassThrough(byte[] _0, ulong _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void KeepPassThroughSession(byte[] _0) => "Stub hit for Nn.Nfc.Detail.IUser.KeepPassThroughSession [1301]".Debug();
		public virtual void ReleasePassThroughSession(byte[] _0) => "Stub hit for Nn.Nfc.Detail.IUser.ReleasePassThroughSession [1302]".Debug();
	}
}
