#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Audioctrl.Detail {
	[IpcService("audctl")]
	public unsafe partial class IAudioController : _Base_IAudioController {}
	public unsafe class _Base_IAudioController : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetTargetVolume
					var ret = GetTargetVolume(null);
					break;
				}
				case 1: { // SetTargetVolume
					SetTargetVolume(null);
					break;
				}
				case 2: { // GetTargetVolumeMin
					var ret = GetTargetVolumeMin();
					break;
				}
				case 3: { // GetTargetVolumeMax
					var ret = GetTargetVolumeMax();
					break;
				}
				case 4: { // IsTargetMute
					var ret = IsTargetMute(null);
					break;
				}
				case 5: { // SetTargetMute
					SetTargetMute(null);
					break;
				}
				case 6: { // IsTargetConnected
					var ret = IsTargetConnected(null);
					break;
				}
				case 7: { // SetDefaultTarget
					SetDefaultTarget(null);
					break;
				}
				case 8: { // GetDefaultTarget
					var ret = GetDefaultTarget();
					break;
				}
				case 9: { // GetAudioOutputMode
					var ret = GetAudioOutputMode(null);
					break;
				}
				case 10: { // SetAudioOutputMode
					SetAudioOutputMode(null);
					break;
				}
				case 11: { // SetForceMutePolicy
					SetForceMutePolicy(null);
					break;
				}
				case 12: { // GetForceMutePolicy
					var ret = GetForceMutePolicy();
					break;
				}
				case 13: { // GetOutputModeSetting
					var ret = GetOutputModeSetting(null);
					break;
				}
				case 14: { // SetOutputModeSetting
					SetOutputModeSetting(null);
					break;
				}
				case 15: { // SetOutputTarget
					SetOutputTarget(null);
					break;
				}
				case 16: { // SetInputTargetForceEnabled
					SetInputTargetForceEnabled(null);
					break;
				}
				case 17: { // SetHeadphoneOutputLevelMode
					SetHeadphoneOutputLevelMode(null);
					break;
				}
				case 18: { // GetHeadphoneOutputLevelMode
					var ret = GetHeadphoneOutputLevelMode();
					break;
				}
				case 19: { // AcquireAudioVolumeUpdateEventForPlayReport
					var ret = AcquireAudioVolumeUpdateEventForPlayReport();
					om.Copy(0, ret.Handle);
					break;
				}
				case 20: { // AcquireAudioOutputDeviceUpdateEventForPlayReport
					var ret = AcquireAudioOutputDeviceUpdateEventForPlayReport();
					om.Copy(0, ret.Handle);
					break;
				}
				case 21: { // GetAudioOutputTargetForPlayReport
					var ret = GetAudioOutputTargetForPlayReport();
					break;
				}
				case 22: { // NotifyHeadphoneVolumeWarningDisplayedEvent
					NotifyHeadphoneVolumeWarningDisplayedEvent();
					break;
				}
				case 23: { // SetSystemOutputMasterVolume
					SetSystemOutputMasterVolume(null);
					break;
				}
				case 24: { // GetSystemOutputMasterVolume
					var ret = GetSystemOutputMasterVolume();
					break;
				}
				case 25: { // GetAudioVolumeDataForPlayReport
					var ret = GetAudioVolumeDataForPlayReport();
					break;
				}
				case 26: { // UpdateHeadphoneSettings
					UpdateHeadphoneSettings(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioController: {im.CommandId}");
			}
		}
		
		public virtual object GetTargetVolume(object _0) => throw new NotImplementedException();
		public virtual void SetTargetVolume(object _0) => throw new NotImplementedException();
		public virtual object GetTargetVolumeMin() => throw new NotImplementedException();
		public virtual object GetTargetVolumeMax() => throw new NotImplementedException();
		public virtual object IsTargetMute(object _0) => throw new NotImplementedException();
		public virtual void SetTargetMute(object _0) => throw new NotImplementedException();
		public virtual object IsTargetConnected(object _0) => throw new NotImplementedException();
		public virtual void SetDefaultTarget(object _0) => throw new NotImplementedException();
		public virtual object GetDefaultTarget() => throw new NotImplementedException();
		public virtual object GetAudioOutputMode(object _0) => throw new NotImplementedException();
		public virtual void SetAudioOutputMode(object _0) => throw new NotImplementedException();
		public virtual void SetForceMutePolicy(object _0) => throw new NotImplementedException();
		public virtual object GetForceMutePolicy() => throw new NotImplementedException();
		public virtual object GetOutputModeSetting(object _0) => throw new NotImplementedException();
		public virtual void SetOutputModeSetting(object _0) => throw new NotImplementedException();
		public virtual void SetOutputTarget(object _0) => throw new NotImplementedException();
		public virtual void SetInputTargetForceEnabled(object _0) => throw new NotImplementedException();
		public virtual void SetHeadphoneOutputLevelMode(object _0) => throw new NotImplementedException();
		public virtual object GetHeadphoneOutputLevelMode() => throw new NotImplementedException();
		public virtual KObject AcquireAudioVolumeUpdateEventForPlayReport() => throw new NotImplementedException();
		public virtual KObject AcquireAudioOutputDeviceUpdateEventForPlayReport() => throw new NotImplementedException();
		public virtual object GetAudioOutputTargetForPlayReport() => throw new NotImplementedException();
		public virtual void NotifyHeadphoneVolumeWarningDisplayedEvent() => throw new NotImplementedException();
		public virtual void SetSystemOutputMasterVolume(object _0) => throw new NotImplementedException();
		public virtual object GetSystemOutputMasterVolume() => throw new NotImplementedException();
		public virtual object GetAudioVolumeDataForPlayReport() => throw new NotImplementedException();
		public virtual void UpdateHeadphoneSettings(object _0) => throw new NotImplementedException();
	}
}
