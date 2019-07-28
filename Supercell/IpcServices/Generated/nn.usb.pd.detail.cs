#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Usb.Pd.Detail {
	[IpcService("usb:pd:c")]
	public unsafe partial class IPdCradleManager : _Base_IPdCradleManager {}
	public unsafe class _Base_IPdCradleManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetPdCradleSession
					var ret = GetPdCradleSession();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPdCradleManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Usb.Pd.Detail.IPdCradleSession GetPdCradleSession() => throw new NotImplementedException();
	}
	
	[IpcService("usb:pd")]
	public unsafe partial class IPdManager : _Base_IPdManager {}
	public unsafe class _Base_IPdManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetPdSession
					var ret = GetPdSession();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPdManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Usb.Pd.Detail.IPdSession GetPdSession() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPdCradleSession : _Base_IPdCradleSession {}
	public unsafe class _Base_IPdCradleSession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // VdmUserWrite
					VdmUserWrite(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // VdmUserRead
					var ret = VdmUserRead(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Vdm20Init
					Vdm20Init();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetFwType
					var ret = GetFwType();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetFwRevision
					var ret = GetFwRevision();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetManufacturerId
					var ret = GetManufacturerId();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // GetDeviceId
					var ret = GetDeviceId();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPdCradleSession: {im.CommandId}");
			}
		}
		
		public virtual void VdmUserWrite(object _0) => "Stub hit for Nn.Usb.Pd.Detail.IPdCradleSession.VdmUserWrite [0]".Debug();
		public virtual object VdmUserRead(object _0) => throw new NotImplementedException();
		public virtual void Vdm20Init() => "Stub hit for Nn.Usb.Pd.Detail.IPdCradleSession.Vdm20Init [2]".Debug();
		public virtual object GetFwType() => throw new NotImplementedException();
		public virtual object GetFwRevision() => throw new NotImplementedException();
		public virtual object GetManufacturerId() => throw new NotImplementedException();
		public virtual object GetDeviceId() => throw new NotImplementedException();
		public virtual object Unknown7() => throw new NotImplementedException();
		public virtual object Unknown8() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPdManufactureManager : _Base_IPdManufactureManager {}
	public unsafe class _Base_IPdManufactureManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPdManufactureManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Usb.Pd.Detail.IPdManufactureSession Unknown0() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPdManufactureSession : _Base_IPdManufactureSession {}
	public unsafe class _Base_IPdManufactureSession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPdManufactureSession: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPdSession : _Base_IPdSession {}
	public unsafe class _Base_IPdSession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BindNoticeEvent
					var ret = BindNoticeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetStatus
					var ret = GetStatus();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetNotice
					var ret = GetNotice();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // ReplyPowerRequest
					ReplyPowerRequest(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPdSession: {im.CommandId}");
			}
		}
		
		public virtual KObject BindNoticeEvent() => throw new NotImplementedException();
		public virtual void Unknown1() => "Stub hit for Nn.Usb.Pd.Detail.IPdSession.Unknown1 [1]".Debug();
		public virtual object GetStatus() => throw new NotImplementedException();
		public virtual object GetNotice() => throw new NotImplementedException();
		public virtual void Unknown4() => "Stub hit for Nn.Usb.Pd.Detail.IPdSession.Unknown4 [4]".Debug();
		public virtual void Unknown5() => "Stub hit for Nn.Usb.Pd.Detail.IPdSession.Unknown5 [5]".Debug();
		public virtual void ReplyPowerRequest(object _0) => "Stub hit for Nn.Usb.Pd.Detail.IPdSession.ReplyPowerRequest [6]".Debug();
	}
}
