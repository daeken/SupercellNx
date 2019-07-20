#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Audioctrl.Detail {
	[IpcService("audctl")]
	public unsafe partial class IAudioController : _Base_IAudioController {}
	public unsafe class _Base_IAudioController : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetTargetVolume
					var ret = GetTargetVolume(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 1: { // SetTargetVolume
					SetTargetVolume(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 2: { // GetTargetVolumeMin
					var ret = GetTargetVolumeMin();
					om.SetData(0, ret);
					break;
				}
				case 3: { // GetTargetVolumeMax
					var ret = GetTargetVolumeMax();
					om.SetData(0, ret);
					break;
				}
				case 4: { // IsTargetMute
					var ret = IsTargetMute(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 5: { // SetTargetMute
					SetTargetMute(im.GetData<ulong>(0));
					break;
				}
				case 6: { // IsTargetConnected
					var ret = IsTargetConnected(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 7: { // SetDefaultTarget
					SetDefaultTarget(null);
					break;
				}
				case 8: { // GetDefaultTarget
					var ret = GetDefaultTarget();
					om.SetData(0, ret);
					break;
				}
				case 9: { // GetAudioOutputMode
					var ret = GetAudioOutputMode(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 10: { // SetAudioOutputMode
					SetAudioOutputMode(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 11: { // SetForceMutePolicy
					SetForceMutePolicy(im.GetData<uint>(0));
					break;
				}
				case 12: { // GetForceMutePolicy
					var ret = GetForceMutePolicy();
					om.SetData(0, ret);
					break;
				}
				case 13: { // GetOutputModeSetting
					var ret = GetOutputModeSetting(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 14: { // SetOutputModeSetting
					SetOutputModeSetting(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 15: { // SetOutputTarget
					SetOutputTarget(im.GetData<uint>(0));
					break;
				}
				case 16: { // SetInputTargetForceEnabled
					SetInputTargetForceEnabled(im.GetData<byte>(0));
					break;
				}
				case 17: { // SetHeadphoneOutputLevelMode
					SetHeadphoneOutputLevelMode(im.GetData<uint>(0));
					break;
				}
				case 18: { // GetHeadphoneOutputLevelMode
					var ret = GetHeadphoneOutputLevelMode();
					om.SetData(0, ret);
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
					om.SetData(0, ret);
					break;
				}
				case 22: { // NotifyHeadphoneVolumeWarningDisplayedEvent
					NotifyHeadphoneVolumeWarningDisplayedEvent();
					break;
				}
				case 23: { // SetSystemOutputMasterVolume
					SetSystemOutputMasterVolume(im.GetData<uint>(0));
					break;
				}
				case 24: { // GetSystemOutputMasterVolume
					var ret = GetSystemOutputMasterVolume();
					om.SetData(0, ret);
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
		
		public virtual uint GetTargetVolume(uint _0) => throw new NotImplementedException();
		public virtual void SetTargetVolume(uint _0, uint _1) => throw new NotImplementedException();
		public virtual uint GetTargetVolumeMin() => throw new NotImplementedException();
		public virtual uint GetTargetVolumeMax() => throw new NotImplementedException();
		public virtual byte IsTargetMute(uint _0) => throw new NotImplementedException();
		public virtual void SetTargetMute(ulong _0) => throw new NotImplementedException();
		public virtual byte IsTargetConnected(uint _0) => throw new NotImplementedException();
		public virtual void SetDefaultTarget(object _0) => throw new NotImplementedException();
		public virtual uint GetDefaultTarget() => throw new NotImplementedException();
		public virtual uint GetAudioOutputMode(uint _0) => throw new NotImplementedException();
		public virtual void SetAudioOutputMode(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void SetForceMutePolicy(uint _0) => throw new NotImplementedException();
		public virtual uint GetForceMutePolicy() => throw new NotImplementedException();
		public virtual uint GetOutputModeSetting(uint _0) => throw new NotImplementedException();
		public virtual void SetOutputModeSetting(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void SetOutputTarget(uint _0) => throw new NotImplementedException();
		public virtual void SetInputTargetForceEnabled(byte _0) => throw new NotImplementedException();
		public virtual void SetHeadphoneOutputLevelMode(uint _0) => throw new NotImplementedException();
		public virtual uint GetHeadphoneOutputLevelMode() => throw new NotImplementedException();
		public virtual KObject AcquireAudioVolumeUpdateEventForPlayReport() => throw new NotImplementedException();
		public virtual KObject AcquireAudioOutputDeviceUpdateEventForPlayReport() => throw new NotImplementedException();
		public virtual uint GetAudioOutputTargetForPlayReport() => throw new NotImplementedException();
		public virtual void NotifyHeadphoneVolumeWarningDisplayedEvent() => throw new NotImplementedException();
		public virtual void SetSystemOutputMasterVolume(uint _0) => throw new NotImplementedException();
		public virtual uint GetSystemOutputMasterVolume() => throw new NotImplementedException();
		public virtual object GetAudioVolumeDataForPlayReport() => throw new NotImplementedException();
		public virtual void UpdateHeadphoneSettings(object _0) => throw new NotImplementedException();
	}
}
