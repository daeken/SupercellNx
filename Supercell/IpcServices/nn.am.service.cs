using System;

namespace Supercell.IpcServices.Nn.Am.Service {
	public partial class IApplicationProxyService {
		public override Nn.Am.Service.IApplicationProxy OpenApplicationProxy(ulong _0, ulong _1, KObject _2) =>
			new IApplicationProxy();
	}

	public partial class IApplicationProxy {
		public override Nn.Am.Service.ICommonStateGetter GetCommonStateGetter() => new ICommonStateGetter();
		public override Nn.Am.Service.ISelfController GetSelfController() => new ISelfController();
		public override Nn.Am.Service.IWindowController GetWindowController() => new IWindowController();
		public override Nn.Am.Service.IAudioController GetAudioController() => new IAudioController();
		public override Nn.Am.Service.IDisplayController GetDisplayController() => new IDisplayController();
		public override Nn.Am.Service.IProcessWindingController GetProcessWindingController() => new IProcessWindingController();
		public override Nn.Am.Service.ILibraryAppletCreator GetLibraryAppletCreator() => new ILibraryAppletCreator();
		public override Nn.Am.Service.IApplicationFunctions GetApplicationFunctions() => new IApplicationFunctions();
		public override Nn.Am.Service.IDebugFunctions GetDebugFunctions() => new IDebugFunctions();
	}

	public partial class ICommonStateGetter {
		public override KObject GetEventHandle() => null;
		public override uint ReceiveMessage() => 0xF; // Focus
		public override void GetThisAppletKind(out byte[] _0) => throw new NotImplementedException();
		public override void AllowToEnterSleep() => throw new NotImplementedException();
		public override void DisallowToEnterSleep() => throw new NotImplementedException();
		public override byte GetOperationMode() => throw new NotImplementedException();
		public override uint GetPerformanceMode() => throw new NotImplementedException();
		public override byte GetCradleStatus() => throw new NotImplementedException();
		public override byte GetBootMode() => throw new NotImplementedException();
		public override byte GetCurrentFocusState() => 1; // In focus
		public override void RequestToAcquireSleepLock() => throw new NotImplementedException();
		public override void ReleaseSleepLock() => throw new NotImplementedException();
		public override void ReleaseSleepLockTransiently() => throw new NotImplementedException();
		public override KObject GetAcquiredSleepLockEvent() => throw new NotImplementedException();
		public override void PushToGeneralChannel(Nn.Am.Service.IStorage _0) => throw new NotImplementedException();
		public override Nn.Am.Service.ILockAccessor GetHomeButtonReaderLockAccessor() => throw new NotImplementedException();
		public override Nn.Am.Service.ILockAccessor GetReaderLockAccessorEx(uint _0) => throw new NotImplementedException();
		public override void GetCradleFwVersion(out uint _0, out uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public override byte IsVrModeEnabled() => throw new NotImplementedException();
		public override void SetVrModeEnabled(byte _0) => throw new NotImplementedException();
		public override void SetLcdBacklighOffEnabled(byte _0) => throw new NotImplementedException();
		public override byte IsInControllerFirmwareUpdateSection() => throw new NotImplementedException();
		public override void GetDefaultDisplayResolution(out uint _0, out uint _1) => throw new NotImplementedException();
		public override KObject GetDefaultDisplayResolutionChangeEvent() => throw new NotImplementedException();
		public override uint GetHdcpAuthenticationState() => throw new NotImplementedException();
		public override KObject GetHdcpAuthenticationStateChangeEvent() => throw new NotImplementedException();
	}

	public partial class ISelfController {
		public override void Exit() => throw new NotImplementedException();
		public override void LockExit() {}
		public override void UnlockExit() {}
		public override void EnterFatalSection() => throw new NotImplementedException();
		public override void LeaveFatalSection() => throw new NotImplementedException();
		public override KObject GetLibraryAppletLaunchableEvent() => throw new NotImplementedException();
		public override void SetScreenShotPermission(uint _0) {}
		public override void SetOperationModeChangedNotification(byte _0) {}
		public override void SetPerformanceModeChangedNotification(byte _0) {}
		public override void SetFocusHandlingMode(byte _0, byte _1, byte _2) {}
		public override void SetRestartMessageEnabled(byte _0) {}
		public override void SetScreenShotAppletIdentityInfo(object _0) {}
		public override void SetOutOfFocusSuspendingEnabled(byte _0) {}
		public override void SetControllerFirmwareUpdateSection(byte _0) {}
		public override void SetRequiresCaptureButtonShortPressedMessage(byte _0) {}
		public override void SetScreenShotImageOrientation(uint _0) {}
		public override void SetDesirableKeyboardLayout(uint _0) {}
		public override ulong CreateManagedDisplayLayer() => 1;
		public override void IsSystemBufferSharingEnabled() {}
		public override void GetSystemSharedLayerHandle(out ulong _0, out ulong _1) => throw new NotImplementedException();
		public override void SetHandlesRequestToDisplay(byte _0) {}
		public override void ApproveToDisplay() {}
		public override void OverrideAutoSleepTimeAndDimmingTime(uint _0, uint _1, uint _2, uint _3) {}
		public override void SetMediaPlaybackState(byte _0) {}
		public override void SetIdleTimeDetectionExtension(uint _0) {}
		public override uint GetIdleTimeDetectionExtension() => throw new NotImplementedException();
		public override void SetInputDetectionSourceSet(uint _0) {}
		public override void ReportUserIsActive() {}
		public override float GetCurrentIlluminance() => throw new NotImplementedException();
		public override byte IsIlluminanceAvailable() => throw new NotImplementedException();
		public override void ReportMultimediaError(uint _0, Buffer<byte> _1) {}
		public override void SetWirelessPriorityMode(uint _0) {}
	}

	public partial class IWindowController {
		public override Nn.Am.Service.IWindow CreateWindow(uint _0) => throw new NotImplementedException();
		public override ulong GetAppletResourceUserId() => 0xCAFEBABE;
		public override void AcquireForegroundRights() {}
		public override void ReleaseForegroundRights() {}
		public override void RejectToChangeIntoBackground() {}
	}

	public partial class IStorage {
		readonly byte[] Data;
		public IStorage(byte[] data) => Data = data;
		
		public override Nn.Am.Service.IStorageAccessor Unknown0() => new IStorageAccessor(Data);
		public override Nn.Am.Service.ITransferStorageAccessor Unknown1() => throw new NotImplementedException();
	}

	public partial class IStorageAccessor {
		readonly byte[] Data;
		public IStorageAccessor(byte[] data) => Data = data;
		
		public override ulong GetSize() => (ulong) Data.Length;
		public override void Write(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void Read(ulong offset, Buffer<byte> buffer) {
			var span = buffer.Span;
			var len = Math.Min(span.Length, Data.Length);
			for(var i = 0; i < len; ++i)
				span[i] = Data[i];
		}
	}

	public partial class IApplicationFunctions {
		public override Nn.Am.Service.IStorage PopLaunchParameter(uint _0) {
			var data = new byte[0x88];
			data[0] = 0xCA;
			data[1] = 0x97;
			data[2] = 0x94;
			data[3] = 0xC7;
			data[4] = 1;
			data[8] = 1;
			return new IStorage(data);
		}

		public override void CreateApplicationAndPushAndRequestToStart(ulong _0, Nn.Am.Service.IStorage _1) {}
		public override void CreateApplicationAndPushAndRequestToStartForQuest(uint _0, uint _1, ulong _2, Nn.Am.Service.IStorage _3) {}
		public override void CreateApplicationAndRequestToStart(ulong _0) {}
		public override void CreateApplicationAndRequestToStartForQuest(uint _0, uint _1, ulong _2) {}
		public override ulong EnsureSaveData(byte[] _0) => 0;
		public override void GetDesiredLanguage(out byte[] _0) => _0 = BitConverter.GetBytes(LanguageCode.GetLanguageCode(1));
		public override void SetTerminateResult(uint _0) {}
		public override void GetDisplayVersion(out byte[] _0) => throw new NotImplementedException();
		public override void GetLaunchStorageInfoForDebug(out byte _0, out byte _1) => throw new NotImplementedException();
		public override ulong ExtendSaveData(byte _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public override void GetSaveDataSize(byte _0, byte[] _1, out ulong _2, out ulong _3) => throw new NotImplementedException();
		public override void BeginBlockingHomeButtonShortAndLongPressed(ulong _0) {}
		public override void EndBlockingHomeButtonShortAndLongPressed() {}
		public override void BeginBlockingHomeButton(ulong _0) {}
		public override void EndBlockingHomeButton() {}
		public override byte NotifyRunning() => throw new NotImplementedException();
		public override void GetPseudoDeviceId(out byte[] _0) => throw new NotImplementedException();
		public override void SetMediaPlaybackStateForApplication(byte _0) {}
		public override byte IsGamePlayRecordingSupported() => throw new NotImplementedException();
		public override void InitializeGamePlayRecording(ulong _0, KObject _1) {}
		public override void SetGamePlayRecordingState(uint _0) {}
		public override void RequestFlushGamePlayingMovieForDebug() {}
		public override void RequestToShutdown() {}
		public override void RequestToReboot() {}
		public override void ExitAndRequestToShowThanksMessage() {}
		public override void EnableApplicationCrashReport(byte _0) {}
	}
}