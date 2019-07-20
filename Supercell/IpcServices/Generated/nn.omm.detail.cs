#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Omm.Detail {
	[IpcService("omm")]
	public unsafe partial class IOperationModeManager : _Base_IOperationModeManager {}
	public unsafe class _Base_IOperationModeManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetOperationMode
					var ret = GetOperationMode();
					break;
				}
				case 1: { // GetOperationModeChangeEvent
					var ret = GetOperationModeChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // EnableAudioVisual
					EnableAudioVisual();
					break;
				}
				case 3: { // DisableAudioVisual
					DisableAudioVisual();
					break;
				}
				case 4: { // EnterSleepAndWait
					EnterSleepAndWait(Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 5: { // GetCradleStatus
					var ret = GetCradleStatus();
					break;
				}
				case 6: { // FadeInDisplay
					FadeInDisplay();
					break;
				}
				case 7: { // FadeOutDisplay
					FadeOutDisplay();
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8();
					break;
				}
				case 9: { // Unknown9
					Unknown9();
					break;
				}
				case 10: { // Unknown10
					Unknown10(null);
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12();
					om.Copy(0, ret.Handle);
					break;
				}
				case 13: { // Unknown13
					Unknown13();
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14();
					break;
				}
				case 15: { // Unknown15
					Unknown15();
					break;
				}
				case 16: { // Unknown16
					Unknown16();
					break;
				}
				case 17: { // Unknown17
					Unknown17();
					break;
				}
				case 18: { // Unknown18
					Unknown18();
					break;
				}
				case 19: { // Unknown19
					var ret = Unknown19();
					om.Copy(0, ret.Handle);
					break;
				}
				case 20: { // Unknown20
					var ret = Unknown20();
					break;
				}
				case 21: { // Unknown21
					Unknown21(null);
					break;
				}
				case 22: { // Unknown22
					var ret = Unknown22();
					om.Copy(0, ret.Handle);
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOperationModeManager: {im.CommandId}");
			}
		}
		
		public virtual object GetOperationMode() => throw new NotImplementedException();
		public virtual KObject GetOperationModeChangeEvent() => throw new NotImplementedException();
		public virtual void EnableAudioVisual() => throw new NotImplementedException();
		public virtual void DisableAudioVisual() => throw new NotImplementedException();
		public virtual void EnterSleepAndWait(KObject _0) => throw new NotImplementedException();
		public virtual object GetCradleStatus() => throw new NotImplementedException();
		public virtual void FadeInDisplay() => throw new NotImplementedException();
		public virtual void FadeOutDisplay() => throw new NotImplementedException();
		public virtual object Unknown8() => throw new NotImplementedException();
		public virtual void Unknown9() => throw new NotImplementedException();
		public virtual void Unknown10(object _0) => throw new NotImplementedException();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual KObject Unknown12() => throw new NotImplementedException();
		public virtual void Unknown13() => throw new NotImplementedException();
		public virtual object Unknown14() => throw new NotImplementedException();
		public virtual void Unknown15() => throw new NotImplementedException();
		public virtual void Unknown16() => throw new NotImplementedException();
		public virtual void Unknown17() => throw new NotImplementedException();
		public virtual void Unknown18() => throw new NotImplementedException();
		public virtual KObject Unknown19() => throw new NotImplementedException();
		public virtual object Unknown20() => throw new NotImplementedException();
		public virtual void Unknown21(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown22() => throw new NotImplementedException();
		public virtual object Unknown23() => throw new NotImplementedException();
	}
}
