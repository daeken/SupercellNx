#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bpc {
	[IpcService("bpc")]
	public unsafe partial class IBoardPowerControlManager : _Base_IBoardPowerControlManager {}
	public unsafe class _Base_IBoardPowerControlManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ShutdownSystem
					ShutdownSystem();
					break;
				}
				case 1: { // RebootSystem
					RebootSystem();
					break;
				}
				case 2: { // GetWakeupReason
					var ret = GetWakeupReason();
					break;
				}
				case 3: { // GetShutdownReason
					var ret = GetShutdownReason();
					break;
				}
				case 4: { // GetAcOk
					var ret = GetAcOk();
					break;
				}
				case 5: { // GetBoardPowerControlEvent
					var ret = GetBoardPowerControlEvent(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 6: { // GetSleepButtonState
					var ret = GetSleepButtonState();
					break;
				}
				case 7: { // GetPowerEvent
					var ret = GetPowerEvent(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8(null);
					break;
				}
				case 9: { // Unknown9
					Unknown9(null);
					break;
				}
				case 10: { // Unknown10
					var ret = Unknown10();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBoardPowerControlManager: {im.CommandId}");
			}
		}
		
		public virtual void ShutdownSystem() => throw new NotImplementedException();
		public virtual void RebootSystem() => throw new NotImplementedException();
		public virtual object GetWakeupReason() => throw new NotImplementedException();
		public virtual object GetShutdownReason() => throw new NotImplementedException();
		public virtual object GetAcOk() => throw new NotImplementedException();
		public virtual KObject GetBoardPowerControlEvent(object _0) => throw new NotImplementedException();
		public virtual object GetSleepButtonState() => throw new NotImplementedException();
		public virtual KObject GetPowerEvent(object _0) => throw new NotImplementedException();
		public virtual object Unknown8(object _0) => throw new NotImplementedException();
		public virtual void Unknown9(object _0) => throw new NotImplementedException();
		public virtual object Unknown10() => throw new NotImplementedException();
	}
	
	[IpcService("bpc:r")]
	public unsafe partial class IRtcManager : _Base_IRtcManager {}
	public unsafe class _Base_IRtcManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetExternalRtcValue
					var ret = GetExternalRtcValue();
					break;
				}
				case 1: { // SetExternalRtcValue
					SetExternalRtcValue(null);
					break;
				}
				case 2: { // ReadExternalRtcResetFlag
					var ret = ReadExternalRtcResetFlag();
					break;
				}
				case 3: { // ClearExternalRtcResetFlag
					ClearExternalRtcResetFlag();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRtcManager: {im.CommandId}");
			}
		}
		
		public virtual object GetExternalRtcValue() => throw new NotImplementedException();
		public virtual void SetExternalRtcValue(object _0) => throw new NotImplementedException();
		public virtual object ReadExternalRtcResetFlag() => throw new NotImplementedException();
		public virtual void ClearExternalRtcResetFlag() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPowerButtonManager : _Base_IPowerButtonManager {}
	public unsafe class _Base_IPowerButtonManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPowerButtonManager: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual KObject Unknown1(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IWakeupConfigManager : _Base_IWakeupConfigManager {}
	public unsafe class _Base_IWakeupConfigManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IWakeupConfigManager: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0) => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
	}
}
