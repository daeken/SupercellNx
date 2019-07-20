#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Audio.Detail {
	public unsafe struct AudioRendererUpdateDataHeader {
		public int Revision;
		public int BehaviorSize;
		public int MemoryPoolSize;
		public int VoiceSize;
		public int VoiceResourceSize;
		public int EffectSize;
		public int MixSize;
		public int SinkSize;
		public int PerformanceManagerSize;
		public int Unknown24;
		public int Unknown28;
		public int Unknown2C;
		public int Unknown30;
		public int Unknown34;
		public int Unknown38;
		public int TotalSize;
	}
	
	public unsafe struct AudioRendererParameterInternal {
		public int SampleRate;
		public int SampleCount;
		public int Unknown8;
		public int MixCount;
		public int VoiceCount;
		public int SinkCount;
		public int EffectCount;
		public int PerformanceManagerCount;
		public int VoiceDropEnable;
		public int SplitterCount;
		public int SplitterDestinationDataCount;
		public int Unknown2C;
		public int Revision;
	}
	
	[IpcService("auddebug")]
	public unsafe partial class IAudioDebugManager : _Base_IAudioDebugManager {}
	public unsafe class _Base_IAudioDebugManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetData<uint>(0), im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioDebugManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(uint _0, ulong _1, KObject _2) => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
	}
	
	[IpcService("audin:u")]
	public unsafe partial class IAudioInManager : _Base_IAudioInManager {}
	public unsafe class _Base_IAudioInManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ListAudioIns
					ListAudioIns(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1: { // OpenAudioIn
					OpenAudioIn(im.GetBytes(0, 0x8), im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0), out var _2);
					om.SetBytes(0, _0);
					om.Move(0, _2.Handle);
					break;
				}
				case 2: { // Unknown2
					Unknown2(out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 3: { // OpenAudioInAuto
					OpenAudioInAuto(im.GetBytes(0, 0x8), im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x21, 0), out var _0, im.GetBuffer<byte>(0x22, 0), out var _2);
					om.SetBytes(0, _0);
					om.Move(0, _2.Handle);
					break;
				}
				case 4: { // ListAudioInsAuto
					ListAudioInsAuto(out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioInManager: {im.CommandId}");
			}
		}
		
		public virtual void ListAudioIns(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void OpenAudioIn(byte[] _0, ulong _1, ulong _2, KObject _3, Buffer<byte> _4, out byte[] _5, Buffer<byte> _6, out Nn.Audio.Detail.IAudioIn _7) => throw new NotImplementedException();
		public virtual void Unknown2(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void OpenAudioInAuto(byte[] _0, ulong _1, ulong _2, KObject _3, Buffer<byte> _4, out byte[] _5, Buffer<byte> _6, out Nn.Audio.Detail.IAudioIn _7) => throw new NotImplementedException();
		public virtual void ListAudioInsAuto(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	[IpcService("audin:a")]
	public unsafe partial class IAudioInManagerForApplet : _Base_IAudioInManagerForApplet {}
	public unsafe class _Base_IAudioInManagerForApplet : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestSuspendAudioIns
					RequestSuspendAudioIns(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 1: { // RequestResumeAudioIns
					RequestResumeAudioIns(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 2: { // GetAudioInsProcessMasterVolume
					var ret = GetAudioInsProcessMasterVolume(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // SetAudioInsProcessMasterVolume
					SetAudioInsProcessMasterVolume(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioInManagerForApplet: {im.CommandId}");
			}
		}
		
		public virtual void RequestSuspendAudioIns(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void RequestResumeAudioIns(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetAudioInsProcessMasterVolume(ulong _0) => throw new NotImplementedException();
		public virtual void SetAudioInsProcessMasterVolume(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
	}
	
	[IpcService("audin:u")]
	public unsafe partial class IAudioInManagerForDebugger : _Base_IAudioInManagerForDebugger {}
	public unsafe class _Base_IAudioInManagerForDebugger : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetData<ulong>(0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetData<ulong>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioInManagerForDebugger: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(ulong _0) => throw new NotImplementedException();
		public virtual void Unknown1(ulong _0) => throw new NotImplementedException();
	}
	
	[IpcService("audout:u")]
	public unsafe partial class IAudioOutManager : _Base_IAudioOutManager {}
	public unsafe class _Base_IAudioOutManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ListAudioOuts
					ListAudioOuts(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1: { // OpenAudioOut
					OpenAudioOut(im.GetBytes(0, 0x8), im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0), out var _2);
					om.SetBytes(0, _0);
					om.Move(0, _2.Handle);
					break;
				}
				case 2: { // ListAudioOutsAuto
					ListAudioOutsAuto(out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 3: { // OpenAudioOutAuto
					OpenAudioOutAuto(im.GetBytes(0, 0x8), im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x21, 0), out var _0, im.GetBuffer<byte>(0x22, 0), out var _2);
					om.SetBytes(0, _0);
					om.Move(0, _2.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioOutManager: {im.CommandId}");
			}
		}
		
		public virtual void ListAudioOuts(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void OpenAudioOut(byte[] _0, ulong _1, ulong _2, KObject _3, Buffer<byte> _4, out byte[] _5, Buffer<byte> _6, out Nn.Audio.Detail.IAudioOut _7) => throw new NotImplementedException();
		public virtual void ListAudioOutsAuto(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void OpenAudioOutAuto(byte[] _0, ulong _1, ulong _2, KObject _3, Buffer<byte> _4, out byte[] _5, Buffer<byte> _6, out Nn.Audio.Detail.IAudioOut _7) => throw new NotImplementedException();
	}
	
	[IpcService("audout:a")]
	public unsafe partial class IAudioOutManagerForApplet : _Base_IAudioOutManagerForApplet {}
	public unsafe class _Base_IAudioOutManagerForApplet : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestSuspendAudioOuts
					RequestSuspendAudioOuts(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 1: { // RequestResumeAudioOuts
					RequestResumeAudioOuts(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 2: { // GetAudioOutsProcessMasterVolume
					var ret = GetAudioOutsProcessMasterVolume(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // SetAudioOutsProcessMasterVolume
					SetAudioOutsProcessMasterVolume(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				case 4: { // GetAudioOutsProcessRecordVolume
					var ret = GetAudioOutsProcessRecordVolume(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 5: { // SetAudioOutsProcessRecordVolume
					SetAudioOutsProcessRecordVolume(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioOutManagerForApplet: {im.CommandId}");
			}
		}
		
		public virtual void RequestSuspendAudioOuts(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void RequestResumeAudioOuts(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetAudioOutsProcessMasterVolume(ulong _0) => throw new NotImplementedException();
		public virtual void SetAudioOutsProcessMasterVolume(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual uint GetAudioOutsProcessRecordVolume(ulong _0) => throw new NotImplementedException();
		public virtual void SetAudioOutsProcessRecordVolume(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
	}
	
	[IpcService("audin:d")]
	[IpcService("audout:d")]
	[IpcService("audren:d")]
	[IpcService("audrec:d")]
	public unsafe partial class IAudioOutManagerForDebugger : _Base_IAudioOutManagerForDebugger {}
	public unsafe class _Base_IAudioOutManagerForDebugger : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestSuspendForDebug
					RequestSuspendForDebug(im.GetData<ulong>(0));
					break;
				}
				case 1: { // RequestResumeForDebug
					RequestResumeForDebug(im.GetData<ulong>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioOutManagerForDebugger: {im.CommandId}");
			}
		}
		
		public virtual void RequestSuspendForDebug(ulong _0) => throw new NotImplementedException();
		public virtual void RequestResumeForDebug(ulong _0) => throw new NotImplementedException();
	}
	
	[IpcService("audren:u")]
	public unsafe partial class IAudioRendererManager : _Base_IAudioRendererManager {}
	public unsafe class _Base_IAudioRendererManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenAudioRenderer
					var ret = OpenAudioRenderer(im.GetBytes(0, 0x34), im.GetData<ulong>(56), im.GetData<ulong>(64), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)));
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetAudioRendererWorkBufferSize
					var ret = GetAudioRendererWorkBufferSize(im.GetBytes(0, 0x34));
					om.SetData(0, ret);
					break;
				}
				case 2: { // GetAudioDeviceService
					var ret = GetAudioDeviceService(im.GetData<ulong>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // OpenAudioRendererAuto
					var ret = OpenAudioRendererAuto(im.GetBytes(0, 0x34), im.GetData<ulong>(56), im.GetData<ulong>(64), im.GetData<ulong>(72), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Move(0, ret.Handle);
					break;
				}
				case 4: { // GetAudioDeviceServiceWithRevisionInfo
					var ret = GetAudioDeviceServiceWithRevisionInfo(im.GetData<uint>(0), im.GetData<ulong>(8));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioRendererManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Audio.Detail.IAudioRenderer OpenAudioRenderer(byte[] _0, ulong _1, ulong _2, ulong _3, KObject _4, KObject _5) => throw new NotImplementedException();
		public virtual ulong GetAudioRendererWorkBufferSize(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Audio.Detail.IAudioDevice GetAudioDeviceService(ulong _0) => throw new NotImplementedException();
		public virtual Nn.Audio.Detail.IAudioRenderer OpenAudioRendererAuto(byte[] _0, ulong _1, ulong _2, ulong _3, ulong _4, KObject _5) => throw new NotImplementedException();
		public virtual Nn.Audio.Detail.IAudioDevice GetAudioDeviceServiceWithRevisionInfo(uint _0, ulong _1) => throw new NotImplementedException();
	}
	
	[IpcService("audren:a")]
	public unsafe partial class IAudioRendererManagerForApplet : _Base_IAudioRendererManagerForApplet {}
	public unsafe class _Base_IAudioRendererManagerForApplet : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestSuspendAudioRenderers
					RequestSuspendAudioRenderers(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 1: { // RequestResumeAudioRenderers
					RequestResumeAudioRenderers(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 2: { // GetAudioRenderersProcessMasterVolume
					var ret = GetAudioRenderersProcessMasterVolume(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // SetAudioRenderersProcessMasterVolume
					SetAudioRenderersProcessMasterVolume(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				case 4: { // RegisterAppletResourceUserId
					RegisterAppletResourceUserId(im.GetData<ulong>(0));
					break;
				}
				case 5: { // UnregisterAppletResourceUserId
					UnregisterAppletResourceUserId(im.GetData<ulong>(0));
					break;
				}
				case 6: { // GetAudioRenderersProcessRecordVolume
					var ret = GetAudioRenderersProcessRecordVolume(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 7: { // SetAudioRenderersProcessRecordVolume
					SetAudioRenderersProcessRecordVolume(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioRendererManagerForApplet: {im.CommandId}");
			}
		}
		
		public virtual void RequestSuspendAudioRenderers(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void RequestResumeAudioRenderers(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetAudioRenderersProcessMasterVolume(ulong _0) => throw new NotImplementedException();
		public virtual void SetAudioRenderersProcessMasterVolume(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void RegisterAppletResourceUserId(ulong _0) => throw new NotImplementedException();
		public virtual void UnregisterAppletResourceUserId(ulong _0) => throw new NotImplementedException();
		public virtual uint GetAudioRenderersProcessRecordVolume(ulong _0) => throw new NotImplementedException();
		public virtual void SetAudioRenderersProcessRecordVolume(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
	}
	
	[IpcService("audren:d")]
	public unsafe partial class IAudioRendererManagerForDebugger : _Base_IAudioRendererManagerForDebugger {}
	public unsafe class _Base_IAudioRendererManagerForDebugger : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetData<ulong>(0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetData<ulong>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioRendererManagerForDebugger: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(ulong _0) => throw new NotImplementedException();
		public virtual void Unknown1(ulong _0) => throw new NotImplementedException();
	}
	
	[IpcService("codecctl")]
	public unsafe partial class ICodecController : _Base_ICodecController {}
	public unsafe class _Base_ICodecController : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // InitializeCodecController
					InitializeCodecController();
					break;
				}
				case 1: { // FinalizeCodecController
					FinalizeCodecController();
					break;
				}
				case 2: { // SleepCodecController
					SleepCodecController();
					break;
				}
				case 3: { // WakeCodecController
					WakeCodecController();
					break;
				}
				case 4: { // SetCodecVolume
					SetCodecVolume(im.GetData<uint>(0));
					break;
				}
				case 5: { // GetCodecVolumeMax
					var ret = GetCodecVolumeMax();
					om.SetData(0, ret);
					break;
				}
				case 6: { // GetCodecVolumeMin
					var ret = GetCodecVolumeMin();
					om.SetData(0, ret);
					break;
				}
				case 7: { // SetCodecActiveTarget
					SetCodecActiveTarget(im.GetData<uint>(0));
					break;
				}
				case 8: { // GetCodecActiveTarget
					var ret = GetCodecActiveTarget();
					om.SetData(0, ret);
					break;
				}
				case 9: { // BindCodecHeadphoneMicJackInterrupt
					var ret = BindCodecHeadphoneMicJackInterrupt();
					om.Copy(0, ret.Handle);
					break;
				}
				case 10: { // IsCodecHeadphoneMicJackInserted
					var ret = IsCodecHeadphoneMicJackInserted();
					om.SetData(0, ret);
					break;
				}
				case 11: { // ClearCodecHeadphoneMicJackInterrupt
					ClearCodecHeadphoneMicJackInterrupt();
					break;
				}
				case 12: { // IsCodecDeviceRequested
					var ret = IsCodecDeviceRequested();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ICodecController: {im.CommandId}");
			}
		}
		
		public virtual void InitializeCodecController() => throw new NotImplementedException();
		public virtual void FinalizeCodecController() => throw new NotImplementedException();
		public virtual void SleepCodecController() => throw new NotImplementedException();
		public virtual void WakeCodecController() => throw new NotImplementedException();
		public virtual void SetCodecVolume(uint _0) => throw new NotImplementedException();
		public virtual uint GetCodecVolumeMax() => throw new NotImplementedException();
		public virtual uint GetCodecVolumeMin() => throw new NotImplementedException();
		public virtual void SetCodecActiveTarget(uint _0) => throw new NotImplementedException();
		public virtual uint GetCodecActiveTarget() => throw new NotImplementedException();
		public virtual KObject BindCodecHeadphoneMicJackInterrupt() => throw new NotImplementedException();
		public virtual byte IsCodecHeadphoneMicJackInserted() => throw new NotImplementedException();
		public virtual void ClearCodecHeadphoneMicJackInterrupt() => throw new NotImplementedException();
		public virtual byte IsCodecDeviceRequested() => throw new NotImplementedException();
	}
	
	[IpcService("audrec:u")]
	public unsafe partial class IFinalOutputRecorderManager : _Base_IFinalOutputRecorderManager {}
	public unsafe class _Base_IFinalOutputRecorderManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenFinalOutputRecorder
					OpenFinalOutputRecorder(im.GetBytes(0, 0x8), im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)), out var _0, out var _1);
					om.SetBytes(0, _0);
					om.Move(0, _1.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFinalOutputRecorderManager: {im.CommandId}");
			}
		}
		
		public virtual void OpenFinalOutputRecorder(byte[] _0, ulong _1, KObject _2, out byte[] _3, out Nn.Audio.Detail.IFinalOutputRecorder _4) => throw new NotImplementedException();
	}
	
	[IpcService("audrec:a")]
	public unsafe partial class IFinalOutputRecorderManagerForApplet : _Base_IFinalOutputRecorderManagerForApplet {}
	public unsafe class _Base_IFinalOutputRecorderManagerForApplet : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestSuspendFinalOutputRecorders
					RequestSuspendFinalOutputRecorders(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 1: { // RequestResumeFinalOutputRecorders
					RequestResumeFinalOutputRecorders(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFinalOutputRecorderManagerForApplet: {im.CommandId}");
			}
		}
		
		public virtual void RequestSuspendFinalOutputRecorders(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void RequestResumeFinalOutputRecorders(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	[IpcService("audrec:d")]
	public unsafe partial class IFinalOutputRecorderManagerForDebugger : _Base_IFinalOutputRecorderManagerForDebugger {}
	public unsafe class _Base_IFinalOutputRecorderManagerForDebugger : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetData<ulong>(0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetData<ulong>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFinalOutputRecorderManagerForDebugger: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(ulong _0) => throw new NotImplementedException();
		public virtual void Unknown1(ulong _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAudioDevice : _Base_IAudioDevice {}
	public unsafe class _Base_IAudioDevice : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ListAudioDeviceName
					ListAudioDeviceName(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1: { // SetAudioDeviceOutputVolume
					SetAudioDeviceOutputVolume(im.GetData<uint>(0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2: { // GetAudioDeviceOutputVolume
					var ret = GetAudioDeviceOutputVolume(im.GetBuffer<byte>(0x5, 0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // GetActiveAudioDeviceName
					GetActiveAudioDeviceName(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // QueryAudioDeviceSystemEvent
					var ret = QueryAudioDeviceSystemEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // GetActiveChannelCount
					var ret = GetActiveChannelCount();
					om.SetData(0, ret);
					break;
				}
				case 6: { // ListAudioDeviceNameAuto
					ListAudioDeviceNameAuto(out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 7: { // SetAudioDeviceOutputVolumeAuto
					SetAudioDeviceOutputVolumeAuto(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 8: { // GetAudioDeviceOutputVolumeAuto
					var ret = GetAudioDeviceOutputVolumeAuto(im.GetBuffer<byte>(0x21, 0));
					om.SetData(0, ret);
					break;
				}
				case 10: { // GetActiveAudioDeviceNameAuto
					GetActiveAudioDeviceNameAuto(im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 11: { // QueryAudioDeviceInputEvent
					var ret = QueryAudioDeviceInputEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 12: { // QueryAudioDeviceOutputEvent
					var ret = QueryAudioDeviceOutputEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioDevice: {im.CommandId}");
			}
		}
		
		public virtual void ListAudioDeviceName(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAudioDeviceOutputVolume(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetAudioDeviceOutputVolume(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetActiveAudioDeviceName(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject QueryAudioDeviceSystemEvent() => throw new NotImplementedException();
		public virtual uint GetActiveChannelCount() => throw new NotImplementedException();
		public virtual void ListAudioDeviceNameAuto(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAudioDeviceOutputVolumeAuto(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetAudioDeviceOutputVolumeAuto(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetActiveAudioDeviceNameAuto(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject QueryAudioDeviceInputEvent() => throw new NotImplementedException();
		public virtual KObject QueryAudioDeviceOutputEvent() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAudioIn : _Base_IAudioIn {}
	public unsafe class _Base_IAudioIn : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAudioInState
					var ret = GetAudioInState();
					om.SetData(0, ret);
					break;
				}
				case 1: { // StartAudioIn
					StartAudioIn();
					break;
				}
				case 2: { // StopAudioIn
					StopAudioIn();
					break;
				}
				case 3: { // AppendAudioInBuffer
					AppendAudioInBuffer(im.GetData<ulong>(0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 4: { // RegisterBufferEvent
					var ret = RegisterBufferEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // GetReleasedAudioInBuffer
					GetReleasedAudioInBuffer(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 6: { // ContainsAudioInBuffer
					var ret = ContainsAudioInBuffer(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 7: { // AppendAudioInBufferWithUserEvent
					AppendAudioInBufferWithUserEvent(im.GetData<ulong>(0), Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 8: { // AppendAudioInBufferAuto
					AppendAudioInBufferAuto(im.GetData<ulong>(0), im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 9: { // GetReleasedAudioInBufferAuto
					GetReleasedAudioInBufferAuto(out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 10: { // AppendAudioInBufferWithUserEventAuto
					AppendAudioInBufferWithUserEventAuto(im.GetData<ulong>(0), Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 11: { // GetAudioInBufferCount
					var ret = GetAudioInBufferCount();
					om.SetData(0, ret);
					break;
				}
				case 12: { // SetAudioInDeviceGain
					SetAudioInDeviceGain(im.GetData<uint>(0));
					break;
				}
				case 13: { // GetAudioInDeviceGain
					var ret = GetAudioInDeviceGain();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioIn: {im.CommandId}");
			}
		}
		
		public virtual uint GetAudioInState() => throw new NotImplementedException();
		public virtual void StartAudioIn() => throw new NotImplementedException();
		public virtual void StopAudioIn() => throw new NotImplementedException();
		public virtual void AppendAudioInBuffer(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject RegisterBufferEvent() => throw new NotImplementedException();
		public virtual void GetReleasedAudioInBuffer(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual byte ContainsAudioInBuffer(ulong _0) => throw new NotImplementedException();
		public virtual void AppendAudioInBufferWithUserEvent(ulong _0, KObject _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void AppendAudioInBufferAuto(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetReleasedAudioInBufferAuto(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void AppendAudioInBufferWithUserEventAuto(ulong _0, KObject _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual uint GetAudioInBufferCount() => throw new NotImplementedException();
		public virtual void SetAudioInDeviceGain(uint _0) => throw new NotImplementedException();
		public virtual uint GetAudioInDeviceGain() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAudioOut : _Base_IAudioOut {}
	public unsafe class _Base_IAudioOut : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAudioOutState
					var ret = GetAudioOutState();
					om.SetData(0, ret);
					break;
				}
				case 1: { // StartAudioOut
					StartAudioOut();
					break;
				}
				case 2: { // StopAudioOut
					StopAudioOut();
					break;
				}
				case 3: { // AppendAudioOutBuffer
					AppendAudioOutBuffer(im.GetData<ulong>(0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 4: { // RegisterBufferEvent
					var ret = RegisterBufferEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // GetReleasedAudioOutBuffer
					GetReleasedAudioOutBuffer(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 6: { // ContainsAudioOutBuffer
					var ret = ContainsAudioOutBuffer(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 7: { // AppendAudioOutBufferAuto
					AppendAudioOutBufferAuto(im.GetData<ulong>(0), im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 8: { // GetReleasedAudioOutBufferAuto
					GetReleasedAudioOutBufferAuto(out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 9: { // GetAudioOutBufferCount
					var ret = GetAudioOutBufferCount();
					om.SetData(0, ret);
					break;
				}
				case 10: { // GetAudioOutPlayedSampleCount
					var ret = GetAudioOutPlayedSampleCount();
					om.SetData(0, ret);
					break;
				}
				case 11: { // FlushAudioOutBuffers
					var ret = FlushAudioOutBuffers();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioOut: {im.CommandId}");
			}
		}
		
		public virtual uint GetAudioOutState() => throw new NotImplementedException();
		public virtual void StartAudioOut() => throw new NotImplementedException();
		public virtual void StopAudioOut() => throw new NotImplementedException();
		public virtual void AppendAudioOutBuffer(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject RegisterBufferEvent() => throw new NotImplementedException();
		public virtual void GetReleasedAudioOutBuffer(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual byte ContainsAudioOutBuffer(ulong _0) => throw new NotImplementedException();
		public virtual void AppendAudioOutBufferAuto(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetReleasedAudioOutBufferAuto(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetAudioOutBufferCount() => throw new NotImplementedException();
		public virtual ulong GetAudioOutPlayedSampleCount() => throw new NotImplementedException();
		public virtual byte FlushAudioOutBuffers() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAudioRenderer : _Base_IAudioRenderer {}
	public unsafe class _Base_IAudioRenderer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAudioRendererSampleRate
					var ret = GetAudioRendererSampleRate();
					om.SetData(0, ret);
					break;
				}
				case 1: { // GetAudioRendererSampleCount
					var ret = GetAudioRendererSampleCount();
					om.SetData(0, ret);
					break;
				}
				case 2: { // GetAudioRendererMixBufferCount
					var ret = GetAudioRendererMixBufferCount();
					om.SetData(0, ret);
					break;
				}
				case 3: { // GetAudioRendererState
					var ret = GetAudioRendererState();
					om.SetData(0, ret);
					break;
				}
				case 4: { // RequestUpdateAudioRenderer
					RequestUpdateAudioRenderer(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0), im.GetBuffer<byte>(0x6, 1));
					break;
				}
				case 5: { // StartAudioRenderer
					StartAudioRenderer();
					break;
				}
				case 6: { // StopAudioRenderer
					StopAudioRenderer();
					break;
				}
				case 7: { // QuerySystemEvent
					var ret = QuerySystemEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 8: { // SetAudioRendererRenderingTimeLimit
					SetAudioRendererRenderingTimeLimit(im.GetData<uint>(0));
					break;
				}
				case 9: { // GetAudioRendererRenderingTimeLimit
					var ret = GetAudioRendererRenderingTimeLimit();
					om.SetData(0, ret);
					break;
				}
				case 10: { // RequestUpdateAudioRendererAuto
					RequestUpdateAudioRendererAuto(im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1));
					break;
				}
				case 11: { // ExecuteAudioRendererRendering
					ExecuteAudioRendererRendering();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioRenderer: {im.CommandId}");
			}
		}
		
		public virtual uint GetAudioRendererSampleRate() => throw new NotImplementedException();
		public virtual uint GetAudioRendererSampleCount() => throw new NotImplementedException();
		public virtual uint GetAudioRendererMixBufferCount() => throw new NotImplementedException();
		public virtual uint GetAudioRendererState() => throw new NotImplementedException();
		public virtual void RequestUpdateAudioRenderer(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void StartAudioRenderer() => throw new NotImplementedException();
		public virtual void StopAudioRenderer() => throw new NotImplementedException();
		public virtual KObject QuerySystemEvent() => throw new NotImplementedException();
		public virtual void SetAudioRendererRenderingTimeLimit(uint _0) => throw new NotImplementedException();
		public virtual uint GetAudioRendererRenderingTimeLimit() => throw new NotImplementedException();
		public virtual void RequestUpdateAudioRendererAuto(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ExecuteAudioRendererRendering() => throw new NotImplementedException();
	}
	
	public unsafe partial class IFinalOutputRecorder : _Base_IFinalOutputRecorder {}
	public unsafe class _Base_IFinalOutputRecorder : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetFinalOutputRecorderState
					var ret = GetFinalOutputRecorderState();
					om.SetData(0, ret);
					break;
				}
				case 1: { // StartFinalOutputRecorder
					StartFinalOutputRecorder();
					break;
				}
				case 2: { // StopFinalOutputRecorder
					StopFinalOutputRecorder();
					break;
				}
				case 3: { // AppendFinalOutputRecorderBuffer
					AppendFinalOutputRecorderBuffer(im.GetData<ulong>(0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 4: { // RegisterBufferEvent
					var ret = RegisterBufferEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // GetReleasedFinalOutputRecorderBuffer
					GetReleasedFinalOutputRecorderBuffer(out var _0, out var _1, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 6: { // ContainsFinalOutputRecorderBuffer
					var ret = ContainsFinalOutputRecorderBuffer(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 8: { // AppendFinalOutputRecorderBufferAuto
					AppendFinalOutputRecorderBufferAuto(im.GetData<ulong>(0), im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 9: { // GetReleasedFinalOutputRecorderBufferAuto
					GetReleasedFinalOutputRecorderBufferAuto(out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFinalOutputRecorder: {im.CommandId}");
			}
		}
		
		public virtual uint GetFinalOutputRecorderState() => throw new NotImplementedException();
		public virtual void StartFinalOutputRecorder() => throw new NotImplementedException();
		public virtual void StopFinalOutputRecorder() => throw new NotImplementedException();
		public virtual void AppendFinalOutputRecorderBuffer(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject RegisterBufferEvent() => throw new NotImplementedException();
		public virtual void GetReleasedFinalOutputRecorderBuffer(out uint _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual byte ContainsFinalOutputRecorderBuffer(ulong _0) => throw new NotImplementedException();
		public virtual ulong Unknown7(ulong _0) => throw new NotImplementedException();
		public virtual void AppendFinalOutputRecorderBufferAuto(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetReleasedFinalOutputRecorderBufferAuto(out uint _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
}
