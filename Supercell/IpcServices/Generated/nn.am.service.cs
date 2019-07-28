#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Am.Service {
	[IpcService("appletAE")]
	public unsafe partial class IAllSystemAppletProxiesService : _Base_IAllSystemAppletProxiesService {}
	public unsafe class _Base_IAllSystemAppletProxiesService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 100: { // OpenSystemAppletProxy
					var ret = OpenSystemAppletProxy(im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 200: { // OpenLibraryAppletProxyOld
					var ret = OpenLibraryAppletProxyOld(im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 201: { // OpenLibraryAppletProxy
					var ret = OpenLibraryAppletProxy(im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x15, 0));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 300: { // OpenOverlayAppletProxy
					var ret = OpenOverlayAppletProxy(im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 350: { // OpenSystemApplicationProxy
					var ret = OpenSystemApplicationProxy(im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 400: { // CreateSelfLibraryAppletCreatorForDevelop
					var ret = CreateSelfLibraryAppletCreatorForDevelop(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAllSystemAppletProxiesService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.ISystemAppletProxy OpenSystemAppletProxy(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletProxy OpenLibraryAppletProxyOld(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletProxy OpenLibraryAppletProxy(ulong _0, ulong _1, KObject _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual Nn.Am.Service.IOverlayAppletProxy OpenOverlayAppletProxy(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
		public virtual Nn.Am.Service.IApplicationProxy OpenSystemApplicationProxy(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletCreator CreateSelfLibraryAppletCreatorForDevelop(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	[IpcService("appletOE")]
	public unsafe partial class IApplicationProxyService : _Base_IApplicationProxyService {}
	public unsafe class _Base_IApplicationProxyService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenApplicationProxy
					var ret = OpenApplicationProxy(im.GetData<ulong>(8), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationProxyService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.IApplicationProxy OpenApplicationProxy(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAppletAccessor : _Base_IAppletAccessor {}
	public unsafe class _Base_IAppletAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAppletStateChangedEvent
					var ret = GetAppletStateChangedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // IsCompleted
					var ret = IsCompleted();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 10: { // Start
					Start();
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // RequestExit
					RequestExit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Terminate
					Terminate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAppletAccessor: {im.CommandId}");
			}
		}
		
		public virtual KObject GetAppletStateChangedEvent() => throw new NotImplementedException();
		public virtual byte IsCompleted() => throw new NotImplementedException();
		public virtual void Start() => "Stub hit for Nn.Am.Service.IAppletAccessor.Start [10]".Debug();
		public virtual void RequestExit() => "Stub hit for Nn.Am.Service.IAppletAccessor.RequestExit [20]".Debug();
		public virtual void Terminate() => "Stub hit for Nn.Am.Service.IAppletAccessor.Terminate [25]".Debug();
		public virtual void GetResult() => "Stub hit for Nn.Am.Service.IAppletAccessor.GetResult [30]".Debug();
	}
	
	public unsafe partial class IApplicationAccessor : _Base_IApplicationAccessor {}
	public unsafe class _Base_IApplicationAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAppletStateChangedEvent
					var ret = GetAppletStateChangedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // IsCompleted
					var ret = IsCompleted();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 10: { // Start
					Start();
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // RequestExit
					RequestExit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Terminate
					Terminate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // RequestForApplicationToGetForeground
					RequestForApplicationToGetForeground();
					om.Initialize(0, 0, 0);
					break;
				}
				case 110: { // TerminateAllLibraryApplets
					TerminateAllLibraryApplets();
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // AreAnyLibraryAppletsLeft
					var ret = AreAnyLibraryAppletsLeft();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 112: { // GetCurrentLibraryApplet
					var ret = GetCurrentLibraryApplet();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 120: { // GetApplicationId
					var ret = GetApplicationId();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 121: { // PushLaunchParameter
					PushLaunchParameter(im.GetData<uint>(8), Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 122: { // GetApplicationControlProperty
					GetApplicationControlProperty(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 123: { // GetApplicationLaunchProperty
					GetApplicationLaunchProperty(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationAccessor: {im.CommandId}");
			}
		}
		
		public virtual KObject GetAppletStateChangedEvent() => throw new NotImplementedException();
		public virtual byte IsCompleted() => throw new NotImplementedException();
		public virtual void Start() => "Stub hit for Nn.Am.Service.IApplicationAccessor.Start [10]".Debug();
		public virtual void RequestExit() => "Stub hit for Nn.Am.Service.IApplicationAccessor.RequestExit [20]".Debug();
		public virtual void Terminate() => "Stub hit for Nn.Am.Service.IApplicationAccessor.Terminate [25]".Debug();
		public virtual void GetResult() => "Stub hit for Nn.Am.Service.IApplicationAccessor.GetResult [30]".Debug();
		public virtual void RequestForApplicationToGetForeground() => "Stub hit for Nn.Am.Service.IApplicationAccessor.RequestForApplicationToGetForeground [101]".Debug();
		public virtual void TerminateAllLibraryApplets() => "Stub hit for Nn.Am.Service.IApplicationAccessor.TerminateAllLibraryApplets [110]".Debug();
		public virtual byte AreAnyLibraryAppletsLeft() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IAppletAccessor GetCurrentLibraryApplet() => throw new NotImplementedException();
		public virtual ulong GetApplicationId() => throw new NotImplementedException();
		public virtual void PushLaunchParameter(uint _0, Nn.Am.Service.IStorage _1) => "Stub hit for Nn.Am.Service.IApplicationAccessor.PushLaunchParameter [121]".Debug();
		public virtual void GetApplicationControlProperty(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetApplicationLaunchProperty(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IApplicationCreator : _Base_IApplicationCreator {}
	public unsafe class _Base_IApplicationCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateApplication
					var ret = CreateApplication(im.GetData<ulong>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // PopLaunchRequestedApplication
					var ret = PopLaunchRequestedApplication();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // CreateSystemApplication
					var ret = CreateSystemApplication(im.GetData<ulong>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 100: { // PopFloatingApplicationForDevelopment
					var ret = PopFloatingApplicationForDevelopment();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.IApplicationAccessor CreateApplication(ulong _0) => throw new NotImplementedException();
		public virtual Nn.Am.Service.IApplicationAccessor PopLaunchRequestedApplication() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IApplicationAccessor CreateSystemApplication(ulong _0) => throw new NotImplementedException();
		public virtual Nn.Am.Service.IApplicationAccessor PopFloatingApplicationForDevelopment() => throw new NotImplementedException();
	}
	
	public unsafe partial class IApplicationFunctions : _Base_IApplicationFunctions {}
	public unsafe class _Base_IApplicationFunctions : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // PopLaunchParameter
					var ret = PopLaunchParameter(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // CreateApplicationAndPushAndRequestToStart
					CreateApplicationAndPushAndRequestToStart(im.GetData<ulong>(8), Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // CreateApplicationAndPushAndRequestToStartForQuest
					CreateApplicationAndPushAndRequestToStartForQuest(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // CreateApplicationAndRequestToStart
					CreateApplicationAndRequestToStart(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // CreateApplicationAndRequestToStartForQuest
					CreateApplicationAndRequestToStartForQuest(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // EnsureSaveData
					var ret = EnsureSaveData(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 21: { // GetDesiredLanguage
					GetDesiredLanguage(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 22: { // SetTerminateResult
					SetTerminateResult(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // GetDisplayVersion
					GetDisplayVersion(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 24: { // GetLaunchStorageInfoForDebug
					GetLaunchStorageInfoForDebug(out var _0, out var _1);
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					om.SetData(9, _1);
					break;
				}
				case 25: { // ExtendSaveData
					var ret = ExtendSaveData(im.GetData<byte>(8), im.GetBytes(9, 0x10), im.GetData<ulong>(32), im.GetData<ulong>(40));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 26: { // GetSaveDataSize
					GetSaveDataSize(im.GetData<byte>(8), im.GetBytes(9, 0x10), out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 30: { // BeginBlockingHomeButtonShortAndLongPressed
					BeginBlockingHomeButtonShortAndLongPressed(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // EndBlockingHomeButtonShortAndLongPressed
					EndBlockingHomeButtonShortAndLongPressed();
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // BeginBlockingHomeButton
					BeginBlockingHomeButton(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 33: { // EndBlockingHomeButton
					EndBlockingHomeButton();
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // NotifyRunning
					var ret = NotifyRunning();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 50: { // GetPseudoDeviceId
					GetPseudoDeviceId(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 60: { // SetMediaPlaybackStateForApplication
					SetMediaPlaybackStateForApplication(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 65: { // IsGamePlayRecordingSupported
					var ret = IsGamePlayRecordingSupported();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 66: { // InitializeGamePlayRecording
					InitializeGamePlayRecording(im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 67: { // SetGamePlayRecordingState
					SetGamePlayRecordingState(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 68: { // RequestFlushGamePlayingMovieForDebug
					RequestFlushGamePlayingMovieForDebug();
					om.Initialize(0, 0, 0);
					break;
				}
				case 70: { // RequestToShutdown
					RequestToShutdown();
					om.Initialize(0, 0, 0);
					break;
				}
				case 71: { // RequestToReboot
					RequestToReboot();
					om.Initialize(0, 0, 0);
					break;
				}
				case 80: { // ExitAndRequestToShowThanksMessage
					ExitAndRequestToShowThanksMessage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 90: { // EnableApplicationCrashReport
					EnableApplicationCrashReport(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationFunctions: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.IStorage PopLaunchParameter(uint _0) => throw new NotImplementedException();
		public virtual void CreateApplicationAndPushAndRequestToStart(ulong _0, Nn.Am.Service.IStorage _1) => "Stub hit for Nn.Am.Service.IApplicationFunctions.CreateApplicationAndPushAndRequestToStart [10]".Debug();
		public virtual void CreateApplicationAndPushAndRequestToStartForQuest(uint _0, uint _1, ulong _2, Nn.Am.Service.IStorage _3) => "Stub hit for Nn.Am.Service.IApplicationFunctions.CreateApplicationAndPushAndRequestToStartForQuest [11]".Debug();
		public virtual void CreateApplicationAndRequestToStart(ulong _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.CreateApplicationAndRequestToStart [12]".Debug();
		public virtual void CreateApplicationAndRequestToStartForQuest(uint _0, uint _1, ulong _2) => "Stub hit for Nn.Am.Service.IApplicationFunctions.CreateApplicationAndRequestToStartForQuest [13]".Debug();
		public virtual ulong EnsureSaveData(byte[] _0) => throw new NotImplementedException();
		public virtual void GetDesiredLanguage(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetTerminateResult(uint _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.SetTerminateResult [22]".Debug();
		public virtual void GetDisplayVersion(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetLaunchStorageInfoForDebug(out byte _0, out byte _1) => throw new NotImplementedException();
		public virtual ulong ExtendSaveData(byte _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void GetSaveDataSize(byte _0, byte[] _1, out ulong _2, out ulong _3) => throw new NotImplementedException();
		public virtual void BeginBlockingHomeButtonShortAndLongPressed(ulong _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.BeginBlockingHomeButtonShortAndLongPressed [30]".Debug();
		public virtual void EndBlockingHomeButtonShortAndLongPressed() => "Stub hit for Nn.Am.Service.IApplicationFunctions.EndBlockingHomeButtonShortAndLongPressed [31]".Debug();
		public virtual void BeginBlockingHomeButton(ulong _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.BeginBlockingHomeButton [32]".Debug();
		public virtual void EndBlockingHomeButton() => "Stub hit for Nn.Am.Service.IApplicationFunctions.EndBlockingHomeButton [33]".Debug();
		public virtual byte NotifyRunning() => throw new NotImplementedException();
		public virtual void GetPseudoDeviceId(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetMediaPlaybackStateForApplication(byte _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.SetMediaPlaybackStateForApplication [60]".Debug();
		public virtual byte IsGamePlayRecordingSupported() => throw new NotImplementedException();
		public virtual void InitializeGamePlayRecording(ulong _0, KObject _1) => "Stub hit for Nn.Am.Service.IApplicationFunctions.InitializeGamePlayRecording [66]".Debug();
		public virtual void SetGamePlayRecordingState(uint _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.SetGamePlayRecordingState [67]".Debug();
		public virtual void RequestFlushGamePlayingMovieForDebug() => "Stub hit for Nn.Am.Service.IApplicationFunctions.RequestFlushGamePlayingMovieForDebug [68]".Debug();
		public virtual void RequestToShutdown() => "Stub hit for Nn.Am.Service.IApplicationFunctions.RequestToShutdown [70]".Debug();
		public virtual void RequestToReboot() => "Stub hit for Nn.Am.Service.IApplicationFunctions.RequestToReboot [71]".Debug();
		public virtual void ExitAndRequestToShowThanksMessage() => "Stub hit for Nn.Am.Service.IApplicationFunctions.ExitAndRequestToShowThanksMessage [80]".Debug();
		public virtual void EnableApplicationCrashReport(byte _0) => "Stub hit for Nn.Am.Service.IApplicationFunctions.EnableApplicationCrashReport [90]".Debug();
	}
	
	public unsafe partial class IApplicationProxy : _Base_IApplicationProxy {}
	public unsafe class _Base_IApplicationProxy : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCommonStateGetter
					var ret = GetCommonStateGetter();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetSelfController
					var ret = GetSelfController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // GetWindowController
					var ret = GetWindowController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // GetAudioController
					var ret = GetAudioController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 4: { // GetDisplayController
					var ret = GetDisplayController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // GetProcessWindingController
					var ret = GetProcessWindingController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 11: { // GetLibraryAppletCreator
					var ret = GetLibraryAppletCreator();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 20: { // GetApplicationFunctions
					var ret = GetApplicationFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1000: { // GetDebugFunctions
					var ret = GetDebugFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationProxy: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.ICommonStateGetter GetCommonStateGetter() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ISelfController GetSelfController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IWindowController GetWindowController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IAudioController GetAudioController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDisplayController GetDisplayController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IProcessWindingController GetProcessWindingController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletCreator GetLibraryAppletCreator() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IApplicationFunctions GetApplicationFunctions() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDebugFunctions GetDebugFunctions() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAudioController : _Base_IAudioController {}
	public unsafe class _Base_IAudioController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetExpectedMasterVolume
					SetExpectedMasterVolume(im.GetData<float>(8), im.GetData<float>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetMainAppletExpectedMasterVolume
					var ret = GetMainAppletExpectedMasterVolume();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 2: { // GetLibraryAppletExpectedMasterVolume
					var ret = GetLibraryAppletExpectedMasterVolume();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 3: { // ChangeMainAppletMasterVolume
					ChangeMainAppletMasterVolume(im.GetData<float>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // SetTransparentVolumeRate
					SetTransparentVolumeRate(im.GetData<float>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAudioController: {im.CommandId}");
			}
		}
		
		public virtual void SetExpectedMasterVolume(float _0, float _1) => "Stub hit for Nn.Am.Service.IAudioController.SetExpectedMasterVolume [0]".Debug();
		public virtual float GetMainAppletExpectedMasterVolume() => throw new NotImplementedException();
		public virtual float GetLibraryAppletExpectedMasterVolume() => throw new NotImplementedException();
		public virtual void ChangeMainAppletMasterVolume(float _0, ulong _1) => "Stub hit for Nn.Am.Service.IAudioController.ChangeMainAppletMasterVolume [3]".Debug();
		public virtual void SetTransparentVolumeRate(float _0) => "Stub hit for Nn.Am.Service.IAudioController.SetTransparentVolumeRate [4]".Debug();
	}
	
	public unsafe partial class ICommonStateGetter : _Base_ICommonStateGetter {}
	public unsafe class _Base_ICommonStateGetter : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetEventHandle
					var ret = GetEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // ReceiveMessage
					var ret = ReceiveMessage();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 2: { // GetThisAppletKind
					GetThisAppletKind(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 3: { // AllowToEnterSleep
					AllowToEnterSleep();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // DisallowToEnterSleep
					DisallowToEnterSleep();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetOperationMode
					var ret = GetOperationMode();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 6: { // GetPerformanceMode
					var ret = GetPerformanceMode();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 7: { // GetCradleStatus
					var ret = GetCradleStatus();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 8: { // GetBootMode
					var ret = GetBootMode();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 9: { // GetCurrentFocusState
					var ret = GetCurrentFocusState();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 10: { // RequestToAcquireSleepLock
					RequestToAcquireSleepLock();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // ReleaseSleepLock
					ReleaseSleepLock();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // ReleaseSleepLockTransiently
					ReleaseSleepLockTransiently();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetAcquiredSleepLockEvent
					var ret = GetAcquiredSleepLockEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 20: { // PushToGeneralChannel
					PushToGeneralChannel(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // GetHomeButtonReaderLockAccessor
					var ret = GetHomeButtonReaderLockAccessor();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 31: { // GetReaderLockAccessorEx
					var ret = GetReaderLockAccessorEx(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 40: { // GetCradleFwVersion
					GetCradleFwVersion(out var _0, out var _1, out var _2, out var _3);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					om.SetData(20, _3);
					break;
				}
				case 50: { // IsVrModeEnabled
					var ret = IsVrModeEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 51: { // SetVrModeEnabled
					SetVrModeEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 52: { // SetLcdBacklighOffEnabled
					SetLcdBacklighOffEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 55: { // IsInControllerFirmwareUpdateSection
					var ret = IsInControllerFirmwareUpdateSection();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 60: { // GetDefaultDisplayResolution
					GetDefaultDisplayResolution(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 61: { // GetDefaultDisplayResolutionChangeEvent
					var ret = GetDefaultDisplayResolutionChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 62: { // GetHdcpAuthenticationState
					var ret = GetHdcpAuthenticationState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 63: { // GetHdcpAuthenticationStateChangeEvent
					var ret = GetHdcpAuthenticationStateChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ICommonStateGetter: {im.CommandId}");
			}
		}
		
		public virtual KObject GetEventHandle() => throw new NotImplementedException();
		public virtual uint ReceiveMessage() => throw new NotImplementedException();
		public virtual void GetThisAppletKind(out byte[] _0) => throw new NotImplementedException();
		public virtual void AllowToEnterSleep() => "Stub hit for Nn.Am.Service.ICommonStateGetter.AllowToEnterSleep [3]".Debug();
		public virtual void DisallowToEnterSleep() => "Stub hit for Nn.Am.Service.ICommonStateGetter.DisallowToEnterSleep [4]".Debug();
		public virtual byte GetOperationMode() => throw new NotImplementedException();
		public virtual uint GetPerformanceMode() => throw new NotImplementedException();
		public virtual byte GetCradleStatus() => throw new NotImplementedException();
		public virtual byte GetBootMode() => throw new NotImplementedException();
		public virtual byte GetCurrentFocusState() => throw new NotImplementedException();
		public virtual void RequestToAcquireSleepLock() => "Stub hit for Nn.Am.Service.ICommonStateGetter.RequestToAcquireSleepLock [10]".Debug();
		public virtual void ReleaseSleepLock() => "Stub hit for Nn.Am.Service.ICommonStateGetter.ReleaseSleepLock [11]".Debug();
		public virtual void ReleaseSleepLockTransiently() => "Stub hit for Nn.Am.Service.ICommonStateGetter.ReleaseSleepLockTransiently [12]".Debug();
		public virtual KObject GetAcquiredSleepLockEvent() => throw new NotImplementedException();
		public virtual void PushToGeneralChannel(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ICommonStateGetter.PushToGeneralChannel [20]".Debug();
		public virtual Nn.Am.Service.ILockAccessor GetHomeButtonReaderLockAccessor() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILockAccessor GetReaderLockAccessorEx(uint _0) => throw new NotImplementedException();
		public virtual void GetCradleFwVersion(out uint _0, out uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual byte IsVrModeEnabled() => throw new NotImplementedException();
		public virtual void SetVrModeEnabled(byte _0) => "Stub hit for Nn.Am.Service.ICommonStateGetter.SetVrModeEnabled [51]".Debug();
		public virtual void SetLcdBacklighOffEnabled(byte _0) => "Stub hit for Nn.Am.Service.ICommonStateGetter.SetLcdBacklighOffEnabled [52]".Debug();
		public virtual byte IsInControllerFirmwareUpdateSection() => throw new NotImplementedException();
		public virtual void GetDefaultDisplayResolution(out uint _0, out uint _1) => throw new NotImplementedException();
		public virtual KObject GetDefaultDisplayResolutionChangeEvent() => throw new NotImplementedException();
		public virtual uint GetHdcpAuthenticationState() => throw new NotImplementedException();
		public virtual KObject GetHdcpAuthenticationStateChangeEvent() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDebugFunctions : _Base_IDebugFunctions {}
	public unsafe class _Base_IDebugFunctions : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // NotifyMessageToHomeMenuForDebug
					NotifyMessageToHomeMenuForDebug(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // OpenMainApplication
					var ret = OpenMainApplication();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // EmulateButtonEvent
					EmulateButtonEvent(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // InvalidateTransitionLayer
					InvalidateTransitionLayer();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugFunctions: {im.CommandId}");
			}
		}
		
		public virtual void NotifyMessageToHomeMenuForDebug(uint _0) => "Stub hit for Nn.Am.Service.IDebugFunctions.NotifyMessageToHomeMenuForDebug [0]".Debug();
		public virtual Nn.Am.Service.IApplicationAccessor OpenMainApplication() => throw new NotImplementedException();
		public virtual void EmulateButtonEvent(uint _0) => "Stub hit for Nn.Am.Service.IDebugFunctions.EmulateButtonEvent [10]".Debug();
		public virtual void InvalidateTransitionLayer() => "Stub hit for Nn.Am.Service.IDebugFunctions.InvalidateTransitionLayer [20]".Debug();
	}
	
	public unsafe partial class IDisplayController : _Base_IDisplayController {}
	public unsafe class _Base_IDisplayController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetLastForegroundCaptureImage
					GetLastForegroundCaptureImage(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // UpdateLastForegroundCaptureImage
					UpdateLastForegroundCaptureImage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetLastApplicationCaptureImage
					GetLastApplicationCaptureImage(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetCallerAppletCaptureImage
					GetCallerAppletCaptureImage(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // UpdateCallerAppletCaptureImage
					UpdateCallerAppletCaptureImage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetLastForegroundCaptureImageEx
					GetLastForegroundCaptureImageEx(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 1);
					om.SetData(8, _0);
					break;
				}
				case 6: { // GetLastApplicationCaptureImageEx
					GetLastApplicationCaptureImageEx(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 1);
					om.SetData(8, _0);
					break;
				}
				case 7: { // GetCallerAppletCaptureImageEx
					GetCallerAppletCaptureImageEx(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 1);
					om.SetData(8, _0);
					break;
				}
				case 8: { // TakeScreenShotOfOwnLayer
					TakeScreenShotOfOwnLayer(im.GetData<byte>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // AcquireLastApplicationCaptureBuffer
					var ret = AcquireLastApplicationCaptureBuffer();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 11: { // ReleaseLastApplicationCaptureBuffer
					ReleaseLastApplicationCaptureBuffer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // AcquireLastForegroundCaptureBuffer
					var ret = AcquireLastForegroundCaptureBuffer();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 13: { // ReleaseLastForegroundCaptureBuffer
					ReleaseLastForegroundCaptureBuffer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // AcquireCallerAppletCaptureBuffer
					var ret = AcquireCallerAppletCaptureBuffer();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 15: { // ReleaseCallerAppletCaptureBuffer
					ReleaseCallerAppletCaptureBuffer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // AcquireLastApplicationCaptureBufferEx
					AcquireLastApplicationCaptureBufferEx(out var _0, out var _1);
					om.Initialize(0, 1, 1);
					om.SetData(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 17: { // AcquireLastForegroundCaptureBufferEx
					AcquireLastForegroundCaptureBufferEx(out var _0, out var _1);
					om.Initialize(0, 1, 1);
					om.SetData(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 18: { // AcquireCallerAppletCaptureBufferEx
					AcquireCallerAppletCaptureBufferEx(out var _0, out var _1);
					om.Initialize(0, 1, 1);
					om.SetData(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 20: { // ClearCaptureBuffer
					ClearCaptureBuffer(im.GetData<byte>(8), im.GetData<uint>(12), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // ClearAppletTransitionBuffer
					ClearAppletTransitionBuffer(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // AcquireLastApplicationCaptureSharedBuffer
					AcquireLastApplicationCaptureSharedBuffer(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 23: { // ReleaseLastApplicationCaptureSharedBuffer
					ReleaseLastApplicationCaptureSharedBuffer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // AcquireLastForegroundCaptureSharedBuffer
					AcquireLastForegroundCaptureSharedBuffer(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 25: { // ReleaseLastForegroundCaptureSharedBuffer
					ReleaseLastForegroundCaptureSharedBuffer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // AcquireCallerAppletCaptureSharedBuffer
					AcquireCallerAppletCaptureSharedBuffer(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 27: { // ReleaseCallerAppletCaptureSharedBuffer
					ReleaseCallerAppletCaptureSharedBuffer();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDisplayController: {im.CommandId}");
			}
		}
		
		public virtual void GetLastForegroundCaptureImage(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void UpdateLastForegroundCaptureImage() => "Stub hit for Nn.Am.Service.IDisplayController.UpdateLastForegroundCaptureImage [1]".Debug();
		public virtual void GetLastApplicationCaptureImage(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetCallerAppletCaptureImage(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void UpdateCallerAppletCaptureImage() => "Stub hit for Nn.Am.Service.IDisplayController.UpdateCallerAppletCaptureImage [4]".Debug();
		public virtual void GetLastForegroundCaptureImageEx(out byte _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetLastApplicationCaptureImageEx(out byte _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetCallerAppletCaptureImageEx(out byte _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void TakeScreenShotOfOwnLayer(byte _0, uint _1) => "Stub hit for Nn.Am.Service.IDisplayController.TakeScreenShotOfOwnLayer [8]".Debug();
		public virtual KObject AcquireLastApplicationCaptureBuffer() => throw new NotImplementedException();
		public virtual void ReleaseLastApplicationCaptureBuffer() => "Stub hit for Nn.Am.Service.IDisplayController.ReleaseLastApplicationCaptureBuffer [11]".Debug();
		public virtual KObject AcquireLastForegroundCaptureBuffer() => throw new NotImplementedException();
		public virtual void ReleaseLastForegroundCaptureBuffer() => "Stub hit for Nn.Am.Service.IDisplayController.ReleaseLastForegroundCaptureBuffer [13]".Debug();
		public virtual KObject AcquireCallerAppletCaptureBuffer() => throw new NotImplementedException();
		public virtual void ReleaseCallerAppletCaptureBuffer() => "Stub hit for Nn.Am.Service.IDisplayController.ReleaseCallerAppletCaptureBuffer [15]".Debug();
		public virtual void AcquireLastApplicationCaptureBufferEx(out byte _0, out KObject _1) => throw new NotImplementedException();
		public virtual void AcquireLastForegroundCaptureBufferEx(out byte _0, out KObject _1) => throw new NotImplementedException();
		public virtual void AcquireCallerAppletCaptureBufferEx(out byte _0, out KObject _1) => throw new NotImplementedException();
		public virtual void ClearCaptureBuffer(byte _0, uint _1, uint _2) => "Stub hit for Nn.Am.Service.IDisplayController.ClearCaptureBuffer [20]".Debug();
		public virtual void ClearAppletTransitionBuffer(uint _0) => "Stub hit for Nn.Am.Service.IDisplayController.ClearAppletTransitionBuffer [21]".Debug();
		public virtual void AcquireLastApplicationCaptureSharedBuffer(out byte _0, out uint _1) => throw new NotImplementedException();
		public virtual void ReleaseLastApplicationCaptureSharedBuffer() => "Stub hit for Nn.Am.Service.IDisplayController.ReleaseLastApplicationCaptureSharedBuffer [23]".Debug();
		public virtual void AcquireLastForegroundCaptureSharedBuffer(out byte _0, out uint _1) => throw new NotImplementedException();
		public virtual void ReleaseLastForegroundCaptureSharedBuffer() => "Stub hit for Nn.Am.Service.IDisplayController.ReleaseLastForegroundCaptureSharedBuffer [25]".Debug();
		public virtual void AcquireCallerAppletCaptureSharedBuffer(out byte _0, out uint _1) => throw new NotImplementedException();
		public virtual void ReleaseCallerAppletCaptureSharedBuffer() => "Stub hit for Nn.Am.Service.IDisplayController.ReleaseCallerAppletCaptureSharedBuffer [27]".Debug();
	}
	
	public unsafe partial class IGlobalStateController : _Base_IGlobalStateController {}
	public unsafe class _Base_IGlobalStateController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestToEnterSleep
					RequestToEnterSleep();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // EnterSleep
					EnterSleep();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // StartSleepSequence
					StartSleepSequence(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // StartShutdownSequence
					StartShutdownSequence();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // StartRebootSequence
					StartRebootSequence();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // LoadAndApplyIdlePolicySettings
					LoadAndApplyIdlePolicySettings();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // NotifyCecSettingsChanged
					NotifyCecSettingsChanged();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // SetDefaultHomeButtonLongPressTime
					SetDefaultHomeButtonLongPressTime(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // UpdateDefaultDisplayResolution
					UpdateDefaultDisplayResolution();
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // ShouldSleepOnBoot
					var ret = ShouldSleepOnBoot();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 15: { // GetHdcpAuthenticationFailedEvent
					var ret = GetHdcpAuthenticationFailedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IGlobalStateController: {im.CommandId}");
			}
		}
		
		public virtual void RequestToEnterSleep() => "Stub hit for Nn.Am.Service.IGlobalStateController.RequestToEnterSleep [0]".Debug();
		public virtual void EnterSleep() => "Stub hit for Nn.Am.Service.IGlobalStateController.EnterSleep [1]".Debug();
		public virtual void StartSleepSequence(byte _0) => "Stub hit for Nn.Am.Service.IGlobalStateController.StartSleepSequence [2]".Debug();
		public virtual void StartShutdownSequence() => "Stub hit for Nn.Am.Service.IGlobalStateController.StartShutdownSequence [3]".Debug();
		public virtual void StartRebootSequence() => "Stub hit for Nn.Am.Service.IGlobalStateController.StartRebootSequence [4]".Debug();
		public virtual void LoadAndApplyIdlePolicySettings() => "Stub hit for Nn.Am.Service.IGlobalStateController.LoadAndApplyIdlePolicySettings [10]".Debug();
		public virtual void NotifyCecSettingsChanged() => "Stub hit for Nn.Am.Service.IGlobalStateController.NotifyCecSettingsChanged [11]".Debug();
		public virtual void SetDefaultHomeButtonLongPressTime(ulong _0) => "Stub hit for Nn.Am.Service.IGlobalStateController.SetDefaultHomeButtonLongPressTime [12]".Debug();
		public virtual void UpdateDefaultDisplayResolution() => "Stub hit for Nn.Am.Service.IGlobalStateController.UpdateDefaultDisplayResolution [13]".Debug();
		public virtual byte ShouldSleepOnBoot() => throw new NotImplementedException();
		public virtual KObject GetHdcpAuthenticationFailedEvent() => throw new NotImplementedException();
	}
	
	public unsafe partial class IHomeMenuFunctions : _Base_IHomeMenuFunctions {}
	public unsafe class _Base_IHomeMenuFunctions : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 10: { // RequestToGetForeground
					RequestToGetForeground();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // LockForeground
					LockForeground();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // UnlockForeground
					UnlockForeground();
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // PopFromGeneralChannel
					var ret = PopFromGeneralChannel();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 21: { // GetPopFromGeneralChannelEvent
					var ret = GetPopFromGeneralChannelEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 30: { // GetHomeButtonWriterLockAccessor
					var ret = GetHomeButtonWriterLockAccessor();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 31: { // GetWriterLockAccessorEx
					var ret = GetWriterLockAccessorEx(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHomeMenuFunctions: {im.CommandId}");
			}
		}
		
		public virtual void RequestToGetForeground() => "Stub hit for Nn.Am.Service.IHomeMenuFunctions.RequestToGetForeground [10]".Debug();
		public virtual void LockForeground() => "Stub hit for Nn.Am.Service.IHomeMenuFunctions.LockForeground [11]".Debug();
		public virtual void UnlockForeground() => "Stub hit for Nn.Am.Service.IHomeMenuFunctions.UnlockForeground [12]".Debug();
		public virtual Nn.Am.Service.IStorage PopFromGeneralChannel() => throw new NotImplementedException();
		public virtual KObject GetPopFromGeneralChannelEvent() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILockAccessor GetHomeButtonWriterLockAccessor() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILockAccessor GetWriterLockAccessorEx(uint _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ILibraryAppletAccessor : _Base_ILibraryAppletAccessor {}
	public unsafe class _Base_ILibraryAppletAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAppletStateChangedEvent
					var ret = GetAppletStateChangedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // IsCompleted
					var ret = IsCompleted();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 10: { // Start
					Start();
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // RequestExit
					RequestExit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Terminate
					Terminate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 50: { // SetOutOfFocusApplicationSuspendingEnabled
					SetOutOfFocusApplicationSuspendingEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // PushInData
					PushInData(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // PopOutData
					var ret = PopOutData();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 102: { // PushExtraStorage
					PushExtraStorage(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // PushInteractiveInData
					PushInteractiveInData(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 104: { // PopInteractiveOutData
					var ret = PopInteractiveOutData();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 105: { // GetPopOutDataEvent
					var ret = GetPopOutDataEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 106: { // GetPopInteractiveOutDataEvent
					var ret = GetPopInteractiveOutDataEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 110: { // NeedsToExitProcess
					var ret = NeedsToExitProcess();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 120: { // GetLibraryAppletInfo
					GetLibraryAppletInfo(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 150: { // RequestForAppletToGetForeground
					RequestForAppletToGetForeground();
					om.Initialize(0, 0, 0);
					break;
				}
				case 160: { // GetIndirectLayerConsumerHandle
					var ret = GetIndirectLayerConsumerHandle(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILibraryAppletAccessor: {im.CommandId}");
			}
		}
		
		public virtual KObject GetAppletStateChangedEvent() => throw new NotImplementedException();
		public virtual byte IsCompleted() => throw new NotImplementedException();
		public virtual void Start() => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.Start [10]".Debug();
		public virtual void RequestExit() => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.RequestExit [20]".Debug();
		public virtual void Terminate() => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.Terminate [25]".Debug();
		public virtual void GetResult() => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.GetResult [30]".Debug();
		public virtual void SetOutOfFocusApplicationSuspendingEnabled(byte _0) => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.SetOutOfFocusApplicationSuspendingEnabled [50]".Debug();
		public virtual void PushInData(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.PushInData [100]".Debug();
		public virtual Nn.Am.Service.IStorage PopOutData() => throw new NotImplementedException();
		public virtual void PushExtraStorage(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.PushExtraStorage [102]".Debug();
		public virtual void PushInteractiveInData(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.PushInteractiveInData [103]".Debug();
		public virtual Nn.Am.Service.IStorage PopInteractiveOutData() => throw new NotImplementedException();
		public virtual KObject GetPopOutDataEvent() => throw new NotImplementedException();
		public virtual KObject GetPopInteractiveOutDataEvent() => throw new NotImplementedException();
		public virtual byte NeedsToExitProcess() => throw new NotImplementedException();
		public virtual void GetLibraryAppletInfo(out byte[] _0) => throw new NotImplementedException();
		public virtual void RequestForAppletToGetForeground() => "Stub hit for Nn.Am.Service.ILibraryAppletAccessor.RequestForAppletToGetForeground [150]".Debug();
		public virtual ulong GetIndirectLayerConsumerHandle(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ILibraryAppletCreator : _Base_ILibraryAppletCreator {}
	public unsafe class _Base_ILibraryAppletCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateLibraryApplet
					var ret = CreateLibraryApplet(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // TerminateAllLibraryApplets
					TerminateAllLibraryApplets();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // AreAnyLibraryAppletsLeft
					var ret = AreAnyLibraryAppletsLeft();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 10: { // CreateStorage
					var ret = CreateStorage(im.GetData<ulong>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 11: { // CreateTransferMemoryStorage
					var ret = CreateTransferMemoryStorage(im.GetData<byte>(8), im.GetData<ulong>(16), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 12: { // CreateHandleStorage
					var ret = CreateHandleStorage(im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILibraryAppletCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.ILibraryAppletAccessor CreateLibraryApplet(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void TerminateAllLibraryApplets() => "Stub hit for Nn.Am.Service.ILibraryAppletCreator.TerminateAllLibraryApplets [1]".Debug();
		public virtual byte AreAnyLibraryAppletsLeft() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IStorage CreateStorage(ulong _0) => throw new NotImplementedException();
		public virtual Nn.Am.Service.IStorage CreateTransferMemoryStorage(byte _0, ulong _1, KObject _2) => throw new NotImplementedException();
		public virtual Nn.Am.Service.IStorage CreateHandleStorage(ulong _0, KObject _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ILibraryAppletProxy : _Base_ILibraryAppletProxy {}
	public unsafe class _Base_ILibraryAppletProxy : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCommonStateGetter
					var ret = GetCommonStateGetter();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetSelfController
					var ret = GetSelfController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // GetWindowController
					var ret = GetWindowController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // GetAudioController
					var ret = GetAudioController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 4: { // GetDisplayController
					var ret = GetDisplayController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // GetProcessWindingController
					var ret = GetProcessWindingController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 11: { // GetLibraryAppletCreator
					var ret = GetLibraryAppletCreator();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 20: { // OpenLibraryAppletSelfAccessor
					var ret = OpenLibraryAppletSelfAccessor();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1000: { // GetDebugFunctions
					var ret = GetDebugFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILibraryAppletProxy: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.ICommonStateGetter GetCommonStateGetter() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ISelfController GetSelfController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IWindowController GetWindowController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IAudioController GetAudioController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDisplayController GetDisplayController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IProcessWindingController GetProcessWindingController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletCreator GetLibraryAppletCreator() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletSelfAccessor OpenLibraryAppletSelfAccessor() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDebugFunctions GetDebugFunctions() => throw new NotImplementedException();
	}
	
	public unsafe partial class ILibraryAppletSelfAccessor : _Base_ILibraryAppletSelfAccessor {}
	public unsafe class _Base_ILibraryAppletSelfAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // PopInData
					var ret = PopInData();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // PushOutData
					PushOutData(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // PopInteractiveInData
					var ret = PopInteractiveInData();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // PushInteractiveOutData
					PushInteractiveOutData(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetPopInDataEvent
					var ret = GetPopInDataEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 6: { // GetPopInteractiveInDataEvent
					var ret = GetPopInteractiveInDataEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 10: { // ExitProcessAndReturn
					ExitProcessAndReturn();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // GetLibraryAppletInfo
					GetLibraryAppletInfo(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 12: { // GetMainAppletIdentityInfo
					var ret = GetMainAppletIdentityInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // CanUseApplicationCore
					var ret = CanUseApplicationCore();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 14: { // GetCallerAppletIdentityInfo
					var ret = GetCallerAppletIdentityInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetMainAppletApplicationControlProperty
					GetMainAppletApplicationControlProperty(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetMainAppletStorageId
					var ret = GetMainAppletStorageId();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 17: { // GetCallerAppletIdentityInfoStack
					GetCallerAppletIdentityInfoStack(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 18: { // GetNextReturnDestinationAppletIdentityInfo
					var ret = GetNextReturnDestinationAppletIdentityInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // GetDesirableKeyboardLayout
					var ret = GetDesirableKeyboardLayout();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20: { // PopExtraStorage
					var ret = PopExtraStorage();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 25: { // GetPopExtraStorageEvent
					var ret = GetPopExtraStorageEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 30: { // UnpopInData
					UnpopInData(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // UnpopExtraStorage
					UnpopExtraStorage(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // GetIndirectLayerProducerHandle
					var ret = GetIndirectLayerProducerHandle();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 50: { // ReportVisibleError
					ReportVisibleError(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 51: { // ReportVisibleErrorWithErrorContext
					ReportVisibleErrorWithErrorContext(im.GetBytes(8, 0x8), im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 60: { // GetMainAppletApplicationDesiredLanguage
					GetMainAppletApplicationDesiredLanguage(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 100: { // CreateGameMovieTrimmer
					var ret = CreateGameMovieTrimmer(im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILibraryAppletSelfAccessor: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.IStorage PopInData() => throw new NotImplementedException();
		public virtual void PushOutData(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.PushOutData [1]".Debug();
		public virtual Nn.Am.Service.IStorage PopInteractiveInData() => throw new NotImplementedException();
		public virtual void PushInteractiveOutData(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.PushInteractiveOutData [3]".Debug();
		public virtual KObject GetPopInDataEvent() => throw new NotImplementedException();
		public virtual KObject GetPopInteractiveInDataEvent() => throw new NotImplementedException();
		public virtual void ExitProcessAndReturn() => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.ExitProcessAndReturn [10]".Debug();
		public virtual void GetLibraryAppletInfo(out byte[] _0) => throw new NotImplementedException();
		public virtual object GetMainAppletIdentityInfo() => throw new NotImplementedException();
		public virtual byte CanUseApplicationCore() => throw new NotImplementedException();
		public virtual object GetCallerAppletIdentityInfo() => throw new NotImplementedException();
		public virtual void GetMainAppletApplicationControlProperty(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual byte GetMainAppletStorageId() => throw new NotImplementedException();
		public virtual void GetCallerAppletIdentityInfoStack(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object GetNextReturnDestinationAppletIdentityInfo() => throw new NotImplementedException();
		public virtual uint GetDesirableKeyboardLayout() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IStorage PopExtraStorage() => throw new NotImplementedException();
		public virtual KObject GetPopExtraStorageEvent() => throw new NotImplementedException();
		public virtual void UnpopInData(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.UnpopInData [30]".Debug();
		public virtual void UnpopExtraStorage(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.UnpopExtraStorage [31]".Debug();
		public virtual ulong GetIndirectLayerProducerHandle() => throw new NotImplementedException();
		public virtual void ReportVisibleError(byte[] _0) => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.ReportVisibleError [50]".Debug();
		public virtual void ReportVisibleErrorWithErrorContext(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Am.Service.ILibraryAppletSelfAccessor.ReportVisibleErrorWithErrorContext [51]".Debug();
		public virtual void GetMainAppletApplicationDesiredLanguage(out byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Grcsrv.IGameMovieTrimmer CreateGameMovieTrimmer(ulong _0, KObject _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ILockAccessor : _Base_ILockAccessor {}
	public unsafe class _Base_ILockAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // TryLock
					TryLock(im.GetData<byte>(8), out var _0, out var _1);
					om.Initialize(0, 1, 1);
					om.SetData(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 2: { // Unlock
					Unlock();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetEvent
					var ret = GetEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILockAccessor: {im.CommandId}");
			}
		}
		
		public virtual void TryLock(byte _0, out byte _1, out KObject _2) => throw new NotImplementedException();
		public virtual void Unlock() => "Stub hit for Nn.Am.Service.ILockAccessor.Unlock [2]".Debug();
		public virtual KObject GetEvent() => throw new NotImplementedException();
	}
	
	public unsafe partial class IOverlayAppletProxy : _Base_IOverlayAppletProxy {}
	public unsafe class _Base_IOverlayAppletProxy : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCommonStateGetter
					var ret = GetCommonStateGetter();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetSelfController
					var ret = GetSelfController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // GetWindowController
					var ret = GetWindowController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // GetAudioController
					var ret = GetAudioController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 4: { // GetDisplayController
					var ret = GetDisplayController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // GetProcessWindingController
					var ret = GetProcessWindingController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 11: { // GetLibraryAppletCreator
					var ret = GetLibraryAppletCreator();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 20: { // GetOverlayFunctions
					var ret = GetOverlayFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1000: { // GetDebugFunctions
					var ret = GetDebugFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOverlayAppletProxy: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.ICommonStateGetter GetCommonStateGetter() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ISelfController GetSelfController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IWindowController GetWindowController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IAudioController GetAudioController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDisplayController GetDisplayController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IProcessWindingController GetProcessWindingController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletCreator GetLibraryAppletCreator() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IOverlayFunctions GetOverlayFunctions() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDebugFunctions GetDebugFunctions() => throw new NotImplementedException();
	}
	
	public unsafe partial class IOverlayFunctions : _Base_IOverlayFunctions {}
	public unsafe class _Base_IOverlayFunctions : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BeginToWatchShortHomeButtonMessage
					BeginToWatchShortHomeButtonMessage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // EndToWatchShortHomeButtonMessage
					EndToWatchShortHomeButtonMessage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetApplicationIdForLogo
					var ret = GetApplicationIdForLogo();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 3: { // SetGpuTimeSliceBoost
					SetGpuTimeSliceBoost(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // SetAutoSleepTimeAndDimmingTimeEnabled
					SetAutoSleepTimeAndDimmingTimeEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // TerminateApplicationAndSetReason
					TerminateApplicationAndSetReason(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // SetScreenShotPermissionGlobally
					SetScreenShotPermissionGlobally(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOverlayFunctions: {im.CommandId}");
			}
		}
		
		public virtual void BeginToWatchShortHomeButtonMessage() => "Stub hit for Nn.Am.Service.IOverlayFunctions.BeginToWatchShortHomeButtonMessage [0]".Debug();
		public virtual void EndToWatchShortHomeButtonMessage() => "Stub hit for Nn.Am.Service.IOverlayFunctions.EndToWatchShortHomeButtonMessage [1]".Debug();
		public virtual ulong GetApplicationIdForLogo() => throw new NotImplementedException();
		public virtual void SetGpuTimeSliceBoost(ulong _0) => "Stub hit for Nn.Am.Service.IOverlayFunctions.SetGpuTimeSliceBoost [3]".Debug();
		public virtual void SetAutoSleepTimeAndDimmingTimeEnabled(byte _0) => "Stub hit for Nn.Am.Service.IOverlayFunctions.SetAutoSleepTimeAndDimmingTimeEnabled [4]".Debug();
		public virtual void TerminateApplicationAndSetReason(uint _0) => "Stub hit for Nn.Am.Service.IOverlayFunctions.TerminateApplicationAndSetReason [5]".Debug();
		public virtual void SetScreenShotPermissionGlobally(byte _0) => "Stub hit for Nn.Am.Service.IOverlayFunctions.SetScreenShotPermissionGlobally [6]".Debug();
	}
	
	public unsafe partial class IProcessWindingController : _Base_IProcessWindingController {}
	public unsafe class _Base_IProcessWindingController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetLaunchReason
					GetLaunchReason(out var _0);
					om.Initialize(0, 0, 4);
					om.SetBytes(8, _0);
					break;
				}
				case 11: { // OpenCallingLibraryApplet
					var ret = OpenCallingLibraryApplet();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 21: { // PushContext
					PushContext(Kernel.Get<Nn.Am.Service.IStorage>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // PopContext
					var ret = PopContext();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 23: { // CancelWindingReservation
					CancelWindingReservation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // WindAndDoReserved
					WindAndDoReserved();
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // ReserveToStartAndWaitAndUnwindThis
					ReserveToStartAndWaitAndUnwindThis(Kernel.Get<Nn.Am.Service.ILibraryAppletAccessor>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 41: { // ReserveToStartAndWait
					ReserveToStartAndWait(Kernel.Get<Nn.Am.Service.ILibraryAppletAccessor>(im.GetMove(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProcessWindingController: {im.CommandId}");
			}
		}
		
		public virtual void GetLaunchReason(out byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletAccessor OpenCallingLibraryApplet() => throw new NotImplementedException();
		public virtual void PushContext(Nn.Am.Service.IStorage _0) => "Stub hit for Nn.Am.Service.IProcessWindingController.PushContext [21]".Debug();
		public virtual Nn.Am.Service.IStorage PopContext() => throw new NotImplementedException();
		public virtual void CancelWindingReservation() => "Stub hit for Nn.Am.Service.IProcessWindingController.CancelWindingReservation [23]".Debug();
		public virtual void WindAndDoReserved() => "Stub hit for Nn.Am.Service.IProcessWindingController.WindAndDoReserved [30]".Debug();
		public virtual void ReserveToStartAndWaitAndUnwindThis(Nn.Am.Service.ILibraryAppletAccessor _0) => "Stub hit for Nn.Am.Service.IProcessWindingController.ReserveToStartAndWaitAndUnwindThis [40]".Debug();
		public virtual void ReserveToStartAndWait(Nn.Am.Service.ILibraryAppletAccessor _0) => "Stub hit for Nn.Am.Service.IProcessWindingController.ReserveToStartAndWait [41]".Debug();
	}
	
	public unsafe partial class ISelfController : _Base_ISelfController {}
	public unsafe class _Base_ISelfController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Exit
					Exit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // LockExit
					LockExit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // UnlockExit
					UnlockExit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // EnterFatalSection
					EnterFatalSection();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // LeaveFatalSection
					LeaveFatalSection();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // GetLibraryAppletLaunchableEvent
					var ret = GetLibraryAppletLaunchableEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 10: { // SetScreenShotPermission
					SetScreenShotPermission(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // SetOperationModeChangedNotification
					SetOperationModeChangedNotification(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // SetPerformanceModeChangedNotification
					SetPerformanceModeChangedNotification(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // SetFocusHandlingMode
					SetFocusHandlingMode(im.GetData<byte>(8), im.GetData<byte>(9), im.GetData<byte>(10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // SetRestartMessageEnabled
					SetRestartMessageEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // SetScreenShotAppletIdentityInfo
					SetScreenShotAppletIdentityInfo(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // SetOutOfFocusSuspendingEnabled
					SetOutOfFocusSuspendingEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // SetControllerFirmwareUpdateSection
					SetControllerFirmwareUpdateSection(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // SetRequiresCaptureButtonShortPressedMessage
					SetRequiresCaptureButtonShortPressedMessage(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // SetScreenShotImageOrientation
					SetScreenShotImageOrientation(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // SetDesirableKeyboardLayout
					SetDesirableKeyboardLayout(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // CreateManagedDisplayLayer
					var ret = CreateManagedDisplayLayer();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 41: { // IsSystemBufferSharingEnabled
					IsSystemBufferSharingEnabled();
					om.Initialize(0, 0, 0);
					break;
				}
				case 42: { // GetSystemSharedLayerHandle
					GetSystemSharedLayerHandle(out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 50: { // SetHandlesRequestToDisplay
					SetHandlesRequestToDisplay(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 51: { // ApproveToDisplay
					ApproveToDisplay();
					om.Initialize(0, 0, 0);
					break;
				}
				case 60: { // OverrideAutoSleepTimeAndDimmingTime
					OverrideAutoSleepTimeAndDimmingTime(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetData<uint>(20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 61: { // SetMediaPlaybackState
					SetMediaPlaybackState(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 62: { // SetIdleTimeDetectionExtension
					SetIdleTimeDetectionExtension(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 63: { // GetIdleTimeDetectionExtension
					var ret = GetIdleTimeDetectionExtension();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 64: { // SetInputDetectionSourceSet
					SetInputDetectionSourceSet(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 65: { // ReportUserIsActive
					ReportUserIsActive();
					om.Initialize(0, 0, 0);
					break;
				}
				case 66: { // GetCurrentIlluminance
					var ret = GetCurrentIlluminance();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 67: { // IsIlluminanceAvailable
					var ret = IsIlluminanceAvailable();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 70: { // ReportMultimediaError
					ReportMultimediaError(im.GetData<uint>(8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 80: { // SetWirelessPriorityMode
					SetWirelessPriorityMode(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISelfController: {im.CommandId}");
			}
		}
		
		public virtual void Exit() => "Stub hit for Nn.Am.Service.ISelfController.Exit [0]".Debug();
		public virtual void LockExit() => "Stub hit for Nn.Am.Service.ISelfController.LockExit [1]".Debug();
		public virtual void UnlockExit() => "Stub hit for Nn.Am.Service.ISelfController.UnlockExit [2]".Debug();
		public virtual void EnterFatalSection() => "Stub hit for Nn.Am.Service.ISelfController.EnterFatalSection [3]".Debug();
		public virtual void LeaveFatalSection() => "Stub hit for Nn.Am.Service.ISelfController.LeaveFatalSection [4]".Debug();
		public virtual KObject GetLibraryAppletLaunchableEvent() => throw new NotImplementedException();
		public virtual void SetScreenShotPermission(uint _0) => "Stub hit for Nn.Am.Service.ISelfController.SetScreenShotPermission [10]".Debug();
		public virtual void SetOperationModeChangedNotification(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetOperationModeChangedNotification [11]".Debug();
		public virtual void SetPerformanceModeChangedNotification(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetPerformanceModeChangedNotification [12]".Debug();
		public virtual void SetFocusHandlingMode(byte _0, byte _1, byte _2) => "Stub hit for Nn.Am.Service.ISelfController.SetFocusHandlingMode [13]".Debug();
		public virtual void SetRestartMessageEnabled(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetRestartMessageEnabled [14]".Debug();
		public virtual void SetScreenShotAppletIdentityInfo(object _0) => "Stub hit for Nn.Am.Service.ISelfController.SetScreenShotAppletIdentityInfo [15]".Debug();
		public virtual void SetOutOfFocusSuspendingEnabled(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetOutOfFocusSuspendingEnabled [16]".Debug();
		public virtual void SetControllerFirmwareUpdateSection(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetControllerFirmwareUpdateSection [17]".Debug();
		public virtual void SetRequiresCaptureButtonShortPressedMessage(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetRequiresCaptureButtonShortPressedMessage [18]".Debug();
		public virtual void SetScreenShotImageOrientation(uint _0) => "Stub hit for Nn.Am.Service.ISelfController.SetScreenShotImageOrientation [19]".Debug();
		public virtual void SetDesirableKeyboardLayout(uint _0) => "Stub hit for Nn.Am.Service.ISelfController.SetDesirableKeyboardLayout [20]".Debug();
		public virtual ulong CreateManagedDisplayLayer() => throw new NotImplementedException();
		public virtual void IsSystemBufferSharingEnabled() => "Stub hit for Nn.Am.Service.ISelfController.IsSystemBufferSharingEnabled [41]".Debug();
		public virtual void GetSystemSharedLayerHandle(out ulong _0, out ulong _1) => throw new NotImplementedException();
		public virtual void SetHandlesRequestToDisplay(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetHandlesRequestToDisplay [50]".Debug();
		public virtual void ApproveToDisplay() => "Stub hit for Nn.Am.Service.ISelfController.ApproveToDisplay [51]".Debug();
		public virtual void OverrideAutoSleepTimeAndDimmingTime(uint _0, uint _1, uint _2, uint _3) => "Stub hit for Nn.Am.Service.ISelfController.OverrideAutoSleepTimeAndDimmingTime [60]".Debug();
		public virtual void SetMediaPlaybackState(byte _0) => "Stub hit for Nn.Am.Service.ISelfController.SetMediaPlaybackState [61]".Debug();
		public virtual void SetIdleTimeDetectionExtension(uint _0) => "Stub hit for Nn.Am.Service.ISelfController.SetIdleTimeDetectionExtension [62]".Debug();
		public virtual uint GetIdleTimeDetectionExtension() => throw new NotImplementedException();
		public virtual void SetInputDetectionSourceSet(uint _0) => "Stub hit for Nn.Am.Service.ISelfController.SetInputDetectionSourceSet [64]".Debug();
		public virtual void ReportUserIsActive() => "Stub hit for Nn.Am.Service.ISelfController.ReportUserIsActive [65]".Debug();
		public virtual float GetCurrentIlluminance() => throw new NotImplementedException();
		public virtual byte IsIlluminanceAvailable() => throw new NotImplementedException();
		public virtual void ReportMultimediaError(uint _0, Buffer<byte> _1) => "Stub hit for Nn.Am.Service.ISelfController.ReportMultimediaError [70]".Debug();
		public virtual void SetWirelessPriorityMode(uint _0) => "Stub hit for Nn.Am.Service.ISelfController.SetWirelessPriorityMode [80]".Debug();
	}
	
	public unsafe partial class IStorage : _Base_IStorage {}
	public unsafe class _Base_IStorage : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStorage: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.IStorageAccessor Unknown0() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ITransferStorageAccessor Unknown1() => throw new NotImplementedException();
	}
	
	public unsafe partial class IStorageAccessor : _Base_IStorageAccessor {}
	public unsafe class _Base_IStorageAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSize
					var ret = GetSize();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 10: { // Write
					Write(im.GetData<ulong>(8), im.GetBuffer<byte>(0x21, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Read
					Read(im.GetData<ulong>(8), im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStorageAccessor: {im.CommandId}");
			}
		}
		
		public virtual ulong GetSize() => throw new NotImplementedException();
		public virtual void Write(ulong _0, Buffer<byte> _1) => "Stub hit for Nn.Am.Service.IStorageAccessor.Write [10]".Debug();
		public virtual void Read(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystemAppletProxy : _Base_ISystemAppletProxy {}
	public unsafe class _Base_ISystemAppletProxy : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCommonStateGetter
					var ret = GetCommonStateGetter();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetSelfController
					var ret = GetSelfController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // GetWindowController
					var ret = GetWindowController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // GetAudioController
					var ret = GetAudioController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 4: { // GetDisplayController
					var ret = GetDisplayController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // GetProcessWindingController
					var ret = GetProcessWindingController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 11: { // GetLibraryAppletCreator
					var ret = GetLibraryAppletCreator();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 20: { // GetHomeMenuFunctions
					var ret = GetHomeMenuFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 21: { // GetGlobalStateController
					var ret = GetGlobalStateController();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 22: { // GetApplicationCreator
					var ret = GetApplicationCreator();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1000: { // GetDebugFunctions
					var ret = GetDebugFunctions();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemAppletProxy: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.ICommonStateGetter GetCommonStateGetter() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ISelfController GetSelfController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IWindowController GetWindowController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IAudioController GetAudioController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDisplayController GetDisplayController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IProcessWindingController GetProcessWindingController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.ILibraryAppletCreator GetLibraryAppletCreator() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IHomeMenuFunctions GetHomeMenuFunctions() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IGlobalStateController GetGlobalStateController() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IApplicationCreator GetApplicationCreator() => throw new NotImplementedException();
		public virtual Nn.Am.Service.IDebugFunctions GetDebugFunctions() => throw new NotImplementedException();
	}
	
	public unsafe partial class ITransferStorageAccessor : _Base_ITransferStorageAccessor {}
	public unsafe class _Base_ITransferStorageAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSize
					var ret = GetSize();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetHandle
					GetHandle(out var _0, out var _1);
					om.Initialize(0, 1, 8);
					om.SetData(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ITransferStorageAccessor: {im.CommandId}");
			}
		}
		
		public virtual ulong GetSize() => throw new NotImplementedException();
		public virtual void GetHandle(out ulong _0, out KObject _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IWindow : _Base_IWindow {}
	public unsafe class _Base_IWindow : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				default:
					throw new NotImplementedException($"Unhandled command ID to IWindow: {im.CommandId}");
			}
		}
		
	}
	
	public unsafe partial class IWindowController : _Base_IWindowController {}
	public unsafe class _Base_IWindowController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateWindow
					var ret = CreateWindow(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetAppletResourceUserId
					var ret = GetAppletResourceUserId();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 10: { // AcquireForegroundRights
					AcquireForegroundRights();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // ReleaseForegroundRights
					ReleaseForegroundRights();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // RejectToChangeIntoBackground
					RejectToChangeIntoBackground();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IWindowController: {im.CommandId}");
			}
		}
		
		public virtual Nn.Am.Service.IWindow CreateWindow(uint _0) => throw new NotImplementedException();
		public virtual ulong GetAppletResourceUserId() => throw new NotImplementedException();
		public virtual void AcquireForegroundRights() => "Stub hit for Nn.Am.Service.IWindowController.AcquireForegroundRights [10]".Debug();
		public virtual void ReleaseForegroundRights() => "Stub hit for Nn.Am.Service.IWindowController.ReleaseForegroundRights [11]".Debug();
		public virtual void RejectToChangeIntoBackground() => "Stub hit for Nn.Am.Service.IWindowController.RejectToChangeIntoBackground [12]".Debug();
	}
}
