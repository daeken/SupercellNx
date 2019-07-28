#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfp.Detail {
	[IpcService("nfp:dbg")]
	public unsafe partial class IDebugManager : _Base_IDebugManager {}
	public unsafe class _Base_IDebugManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateDebugInterface
					var ret = CreateDebugInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Nfp.Detail.IDebug CreateDebugInterface() => throw new NotImplementedException();
	}
	
	[IpcService("nfp:sys")]
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
		
		public virtual Nn.Nfp.Detail.ISystem CreateSystemInterface() => throw new NotImplementedException();
	}
	
	[IpcService("nfp:user")]
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
		
		public virtual Nn.Nfp.Detail.IUser CreateUserInterface() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDebug : _Base_IDebug {}
	public unsafe class _Base_IDebug : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // InitializeDebug
					InitializeDebug(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // FinalizeDebug
					FinalizeDebug();
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
				case 5: { // Mount
					Mount(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetData<uint>(20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unmount
					Unmount(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // OpenApplicationArea
					OpenApplicationArea(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // GetApplicationArea
					GetApplicationArea(im.GetBytes(8, 0x8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 9: { // SetApplicationArea
					SetApplicationArea(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Flush
					Flush(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Restore
					Restore(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // CreateApplicationArea
					CreateApplicationArea(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetTagInfo
					GetTagInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // GetRegisterInfo
					GetRegisterInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetCommonInfo
					GetCommonInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetModelInfo
					GetModelInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 18: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 19: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 21: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 22: { // GetApplicationArea2
					var ret = GetApplicationArea2(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 23: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 24: { // RecreateApplicationArea
					RecreateApplicationArea(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // Format
					Format(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // GetAdminInfo
					GetAdminInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // GetRegisterInfo2
					GetRegisterInfo2(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // SetRegisterInfo
					SetRegisterInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 104: { // DeleteRegisterInfo
					DeleteRegisterInfo(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 105: { // DeleteApplicationArea
					DeleteApplicationArea(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 106: { // ExistsApplicationArea
					var ret = ExistsApplicationArea(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 200: { // GetAll
					GetAll(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 201: { // SetAll
					SetAll(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // FlushDebug
					FlushDebug(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 203: { // BreakTag
					BreakTag(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 204: { // ReadBackupData
					ReadBackupData(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 205: { // WriteBackupData
					WriteBackupData(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 206: { // WriteNtf
					WriteNtf(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 300: { // Unknown300
					Unknown300(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // Unknown301
					Unknown301();
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // Unknown302
					Unknown302(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 303: { // Unknown303
					Unknown303(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 304: { // Unknown304
					Unknown304(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 305: { // Unknown305
					Unknown305(im.GetBytes(8, 0x8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 306: { // Unknown306
					Unknown306(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 307: { // Unknown307
					var ret = Unknown307(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 308: { // Unknown308
					var ret = Unknown308(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 309: { // Unknown309
					var ret = Unknown309();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 310: { // Unknown310
					var ret = Unknown310(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 311: { // Unknown311
					var ret = Unknown311(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 312: { // Unknown312
					Unknown312(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 313: { // Unknown313
					Unknown313(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 314: { // Unknown314
					var ret = Unknown314();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebug: {im.CommandId}");
			}
		}
		
		public virtual void InitializeDebug(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfp.Detail.IDebug.InitializeDebug [0]".Debug();
		public virtual void FinalizeDebug() => "Stub hit for Nn.Nfp.Detail.IDebug.FinalizeDebug [1]".Debug();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.StartDetection [3]".Debug();
		public virtual void StopDetection(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.StopDetection [4]".Debug();
		public virtual void Mount(byte[] _0, uint _1, uint _2) => "Stub hit for Nn.Nfp.Detail.IDebug.Mount [5]".Debug();
		public virtual void Unmount(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Unmount [6]".Debug();
		public virtual void OpenApplicationArea(byte[] _0, uint _1) => "Stub hit for Nn.Nfp.Detail.IDebug.OpenApplicationArea [7]".Debug();
		public virtual void GetApplicationArea(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SetApplicationArea(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfp.Detail.IDebug.SetApplicationArea [9]".Debug();
		public virtual void Flush(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Flush [10]".Debug();
		public virtual void Restore(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Restore [11]".Debug();
		public virtual void CreateApplicationArea(byte[] _0, uint _1, Buffer<byte> _2) => "Stub hit for Nn.Nfp.Detail.IDebug.CreateApplicationArea [12]".Debug();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetRegisterInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetCommonInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetModelInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetApplicationArea2(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void RecreateApplicationArea(byte[] _0, uint _1, Buffer<byte> _2) => "Stub hit for Nn.Nfp.Detail.IDebug.RecreateApplicationArea [24]".Debug();
		public virtual void Format(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Format [100]".Debug();
		public virtual void GetAdminInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetRegisterInfo2(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetRegisterInfo(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfp.Detail.IDebug.SetRegisterInfo [103]".Debug();
		public virtual void DeleteRegisterInfo(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.DeleteRegisterInfo [104]".Debug();
		public virtual void DeleteApplicationArea(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.DeleteApplicationArea [105]".Debug();
		public virtual byte ExistsApplicationArea(byte[] _0) => throw new NotImplementedException();
		public virtual void GetAll(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAll(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfp.Detail.IDebug.SetAll [201]".Debug();
		public virtual void FlushDebug(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.FlushDebug [202]".Debug();
		public virtual void BreakTag(byte[] _0, uint _1) => "Stub hit for Nn.Nfp.Detail.IDebug.BreakTag [203]".Debug();
		public virtual void ReadBackupData(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void WriteBackupData(Buffer<byte> _0) => "Stub hit for Nn.Nfp.Detail.IDebug.WriteBackupData [205]".Debug();
		public virtual void WriteNtf(byte[] _0, uint _1, Buffer<byte> _2) => "Stub hit for Nn.Nfp.Detail.IDebug.WriteNtf [206]".Debug();
		public virtual void Unknown300(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfp.Detail.IDebug.Unknown300 [300]".Debug();
		public virtual void Unknown301() => "Stub hit for Nn.Nfp.Detail.IDebug.Unknown301 [301]".Debug();
		public virtual void Unknown302(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown303(byte[] _0, uint _1) => "Stub hit for Nn.Nfp.Detail.IDebug.Unknown303 [303]".Debug();
		public virtual void Unknown304(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Unknown304 [304]".Debug();
		public virtual void Unknown305(byte[] _0, ulong _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void Unknown306(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject Unknown307(byte[] _0) => throw new NotImplementedException();
		public virtual KObject Unknown308(byte[] _0) => throw new NotImplementedException();
		public virtual uint Unknown309() => throw new NotImplementedException();
		public virtual uint Unknown310(byte[] _0) => throw new NotImplementedException();
		public virtual uint Unknown311(byte[] _0) => throw new NotImplementedException();
		public virtual void Unknown312(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Unknown312 [312]".Debug();
		public virtual void Unknown313(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IDebug.Unknown313 [313]".Debug();
		public virtual KObject Unknown314() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystem : _Base_ISystem {}
	public unsafe class _Base_ISystem : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // InitializeSystem
					InitializeSystem(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // FinalizeSystem
					FinalizeSystem();
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
				case 5: { // Mount
					Mount(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetData<uint>(20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unmount
					Unmount(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Flush
					Flush(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Restore
					Restore(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetTagInfo
					GetTagInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // GetRegisterInfo
					GetRegisterInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetCommonInfo
					GetCommonInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetModelInfo
					GetModelInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 18: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 19: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 21: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 23: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 100: { // Format
					Format(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // GetAdminInfo
					GetAdminInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // GetRegisterInfo2
					GetRegisterInfo2(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // SetRegisterInfo
					SetRegisterInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 104: { // DeleteRegisterInfo
					DeleteRegisterInfo(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 105: { // DeleteApplicationArea
					DeleteApplicationArea(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 106: { // ExistsApplicationArea
					var ret = ExistsApplicationArea(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystem: {im.CommandId}");
			}
		}
		
		public virtual void InitializeSystem(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfp.Detail.ISystem.InitializeSystem [0]".Debug();
		public virtual void FinalizeSystem() => "Stub hit for Nn.Nfp.Detail.ISystem.FinalizeSystem [1]".Debug();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.StartDetection [3]".Debug();
		public virtual void StopDetection(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.StopDetection [4]".Debug();
		public virtual void Mount(byte[] _0, uint _1, uint _2) => "Stub hit for Nn.Nfp.Detail.ISystem.Mount [5]".Debug();
		public virtual void Unmount(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.Unmount [6]".Debug();
		public virtual void Flush(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.Flush [10]".Debug();
		public virtual void Restore(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.Restore [11]".Debug();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetRegisterInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetCommonInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetModelInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void Format(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.Format [100]".Debug();
		public virtual void GetAdminInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetRegisterInfo2(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetRegisterInfo(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfp.Detail.ISystem.SetRegisterInfo [103]".Debug();
		public virtual void DeleteRegisterInfo(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.DeleteRegisterInfo [104]".Debug();
		public virtual void DeleteApplicationArea(byte[] _0) => "Stub hit for Nn.Nfp.Detail.ISystem.DeleteApplicationArea [105]".Debug();
		public virtual byte ExistsApplicationArea(byte[] _0) => throw new NotImplementedException();
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
				case 5: { // Mount
					Mount(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetData<uint>(20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unmount
					Unmount(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // OpenApplicationArea
					OpenApplicationArea(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // GetApplicationArea
					GetApplicationArea(im.GetBytes(8, 0x8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 9: { // SetApplicationArea
					SetApplicationArea(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Flush
					Flush(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Restore
					Restore(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // CreateApplicationArea
					CreateApplicationArea(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetTagInfo
					GetTagInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // GetRegisterInfo
					GetRegisterInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetCommonInfo
					GetCommonInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetModelInfo
					GetModelInfo(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // AttachActivateEvent
					var ret = AttachActivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 18: { // AttachDeactivateEvent
					var ret = AttachDeactivateEvent(im.GetBytes(8, 0x8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 19: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20: { // GetDeviceState
					var ret = GetDeviceState(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 21: { // GetNpadId
					var ret = GetNpadId(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 22: { // GetApplicationArea2
					var ret = GetApplicationArea2(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 23: { // AttachAvailabilityChangeEvent
					var ret = AttachAvailabilityChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 24: { // RecreateApplicationArea
					RecreateApplicationArea(im.GetBytes(8, 0x8), im.GetData<uint>(16), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUser: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(ulong _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Nfp.Detail.IUser.Initialize [0]".Debug();
		public virtual void Finalize() => "Stub hit for Nn.Nfp.Detail.IUser.Finalize [1]".Debug();
		public virtual void ListDevices(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StartDetection(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IUser.StartDetection [3]".Debug();
		public virtual void StopDetection(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IUser.StopDetection [4]".Debug();
		public virtual void Mount(byte[] _0, uint _1, uint _2) => "Stub hit for Nn.Nfp.Detail.IUser.Mount [5]".Debug();
		public virtual void Unmount(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IUser.Unmount [6]".Debug();
		public virtual void OpenApplicationArea(byte[] _0, uint _1) => "Stub hit for Nn.Nfp.Detail.IUser.OpenApplicationArea [7]".Debug();
		public virtual void GetApplicationArea(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SetApplicationArea(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Nfp.Detail.IUser.SetApplicationArea [9]".Debug();
		public virtual void Flush(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IUser.Flush [10]".Debug();
		public virtual void Restore(byte[] _0) => "Stub hit for Nn.Nfp.Detail.IUser.Restore [11]".Debug();
		public virtual void CreateApplicationArea(byte[] _0, uint _1, Buffer<byte> _2) => "Stub hit for Nn.Nfp.Detail.IUser.CreateApplicationArea [12]".Debug();
		public virtual void GetTagInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetRegisterInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetCommonInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetModelInfo(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AttachActivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachDeactivateEvent(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual uint GetDeviceState(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetNpadId(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetApplicationArea2(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachAvailabilityChangeEvent() => throw new NotImplementedException();
		public virtual void RecreateApplicationArea(byte[] _0, uint _1, Buffer<byte> _2) => "Stub hit for Nn.Nfp.Detail.IUser.RecreateApplicationArea [24]".Debug();
	}
}
