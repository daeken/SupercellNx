using System;

namespace Supercell.IpcServices.nn.am.Service {
	[IpcService("appletOE")]
	public class IApplicationProxyService : IpcInterface {
		[IpcCommand(0)]
		void OpenApplicationProxy(ulong unknown0, [Pid] ulong pid, [Move] out IApplicationProxy proxy) =>
			proxy = new IApplicationProxy();
	}
	
	public class IApplicationProxy : IpcInterface {
		[IpcCommand(0)]
		void GetCommonStateGetter([Move] out ICommonStateGetter obj) => obj = new ICommonStateGetter();
		[IpcCommand(1)]
		void GetSelfController([Move] out ISelfController obj) => obj = new ISelfController();
		[IpcCommand(2)]
		void GetWindowController([Move] out IWindowController obj) => obj = new IWindowController();
		[IpcCommand(3)]
		void GetAudioController([Move] out IAudioController obj) => obj = new IAudioController();
		[IpcCommand(4)]
		void GetDisplayController([Move] out IDisplayController obj) => obj = new IDisplayController();
		[IpcCommand(10)]
		void GetProcessWindingController([Move] out IProcessWindingController obj) => obj = new IProcessWindingController();
		[IpcCommand(11)]
		void GetLibraryAppletCreator([Move] out ILibraryAppletCreator obj) => obj = new ILibraryAppletCreator();
		[IpcCommand(20)]
		void GetApplicationFunctions([Move] out IApplicationFunctions obj) => obj = new IApplicationFunctions();
		[IpcCommand(1000)]
		void GetDebugFunctions([Move] out IDebugFunctions obj) => obj = new IDebugFunctions();
	}

	public class ICommonStateGetter : IpcInterface {
		[IpcCommand(0)]
		void GetEventHandle([Move] out KObject unknown0) => unknown0 = null;

		[IpcCommand(1)]
		void ReceiveMessage(out uint /* nn::am::AppletMessage */ msg) => msg = 0xF; // Focus

		[IpcCommand(2)]
		void GetThisAppletKind([Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::am::service::AppletKind */ unknown0) =>
			throw new NotImplementedException();

		[IpcCommand(3)]
		void AllowToEnterSleep() => throw new NotImplementedException();

		[IpcCommand(4)]
		void DisallowToEnterSleep() => throw new NotImplementedException();

		[IpcCommand(5)]
		void GetOperationMode(out byte unknown0) => throw new NotImplementedException();

		[IpcCommand(6)]
		void GetPerformanceMode(out uint unknown0) => throw new NotImplementedException();

		[IpcCommand(7)]
		void GetCradleStatus(out byte unknown0) => throw new NotImplementedException();

		[IpcCommand(8)]
		void GetBootMode(out byte unknown0) => throw new NotImplementedException();

		[IpcCommand(9)]
		void GetCurrentFocusState(out byte state) => state = 1; // In focus

		[IpcCommand(10)]
		void RequestToAcquireSleepLock() => throw new NotImplementedException();

		[IpcCommand(11)]
		void ReleaseSleepLock() => throw new NotImplementedException();

		[IpcCommand(12)]
		void ReleaseSleepLockTransiently() => throw new NotImplementedException();

		[IpcCommand(13)]
		void GetAcquiredSleepLockEvent([Move] out KObject unknown0) => throw new NotImplementedException();

		[IpcCommand(20)]
		void PushToGeneralChannel(object unknown0) => throw new NotImplementedException();

		[IpcCommand(30)]
		void GetHomeButtonReaderLockAccessor(out object unknown0) => throw new NotImplementedException();

		[IpcCommand(31)]
		void GetReaderLockAccessorEx(uint unknown0, out object unknown1) => throw new NotImplementedException();

		[IpcCommand(40)]
		void GetCradleFwVersion(out uint unknown0, out uint unknown1, out uint unknown2, out uint unknown3) =>
			throw new NotImplementedException();

		[IpcCommand(50)]
		void IsVrModeEnabled(out bool unknown0) => throw new NotImplementedException();

		[IpcCommand(51)]
		void SetVrModeEnabled(bool unknown0) => throw new NotImplementedException();

		[IpcCommand(52)]
		void SetLcdBacklighOffEnabled(bool unknown0) => throw new NotImplementedException();

		[IpcCommand(55)]
		void IsInControllerFirmwareUpdateSection(out bool unknown0) => throw new NotImplementedException();

		[IpcCommand(60)]
		void GetDefaultDisplayResolution(out uint unknown0, out uint unknown1) => throw new NotImplementedException();

		[IpcCommand(61)]
		void GetDefaultDisplayResolutionChangeEvent([Move] out KObject unknown0) => throw new NotImplementedException();

		[IpcCommand(62)]
		void GetHdcpAuthenticationState(out uint unknown0) => throw new NotImplementedException();

		[IpcCommand(63)]
		void GetHdcpAuthenticationStateChangeEvent([Move] out KObject unknown0) => throw new NotImplementedException();
	}

	public class ISelfController : IpcInterface {
		[IpcCommand(0)]
		void Exit() => throw new NotImplementedException();
		[IpcCommand(1)]
		void LockExit() {}
		[IpcCommand(2)]
		void UnlockExit() {}
		[IpcCommand(3)]
		void EnterFatalSection() => throw new NotImplementedException();
		[IpcCommand(4)]
		void LeaveFatalSection() => throw new NotImplementedException();
		[IpcCommand(9)]
		void GetLibraryAppletLaunchableEvent([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(10)]
		void SetScreenShotPermission(uint unknown0) {}
		[IpcCommand(11)]
		void SetOperationModeChangedNotification(bool unknown0) {}
		[IpcCommand(12)]
		void SetPerformanceModeChangedNotification(bool unknown0) {}
		[IpcCommand(13)]
		void SetFocusHandlingMode(bool unknown0, bool unknown1, bool unknown2) {}
		[IpcCommand(14)]
		void SetRestartMessageEnabled(bool unknown0) {}
		[IpcCommand(15)]
		void SetScreenShotAppletIdentityInfo(object /* nn::am::service::AppletIdentityInfo */ unknown0) {}
		[IpcCommand(16)]
		void SetOutOfFocusSuspendingEnabled(bool unknown0) {}
		[IpcCommand(17)]
		void SetControllerFirmwareUpdateSection(bool unknown0) {}
		[IpcCommand(18)]
		void SetRequiresCaptureButtonShortPressedMessage(bool unknown0) {}
		[IpcCommand(19)]
		void SetScreenShotImageOrientation(uint unknown0) {}
		[IpcCommand(20)]
		void SetDesirableKeyboardLayout(uint unknown0) {}
		
		[IpcCommand(40)]
		void CreateManagedDisplayLayer(out ulong layerId) => layerId = 1;
		
		[IpcCommand(41)]
		void IsSystemBufferSharingEnabled() {}
		[IpcCommand(42)]
		void GetSystemSharedLayerHandle(out ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, out ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown1) => throw new NotImplementedException();
		[IpcCommand(50)]
		void SetHandlesRequestToDisplay(bool unknown0) {}
		[IpcCommand(51)]
		void ApproveToDisplay() {}
		[IpcCommand(60)]
		void OverrideAutoSleepTimeAndDimmingTime(uint unknown0, uint unknown1, uint unknown2, uint unknown3) {}
		[IpcCommand(61)]
		void SetMediaPlaybackState(bool unknown0) {}
		[IpcCommand(62)]
		void SetIdleTimeDetectionExtension(uint unknown0) {}
		[IpcCommand(63)]
		void GetIdleTimeDetectionExtension(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(64)]
		void SetInputDetectionSourceSet(uint unknown0) {}
		[IpcCommand(65)]
		void ReportUserIsActive() {}
		[IpcCommand(66)]
		void GetCurrentIlluminance(out float unknown0) => throw new NotImplementedException();
		[IpcCommand(67)]
		void IsIlluminanceAvailable(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(70)]
		void ReportMultimediaError(uint unknown0, [Buffer(0x5)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(80)]
		void SetWirelessPriorityMode(uint unknown0) {}
	}

	public class IWindowController : IpcInterface {
		[IpcCommand(0)]
		void CreateWindow(uint /* nn::am::service::WindowCreationOption */ unknown0, [Move] out KObject unknown1) =>
			throw new NotImplementedException();

		[IpcCommand(1)]
		void GetAppletResourceUserId(out ulong /* nn::applet::AppletResourceUserId */ unknown0) =>
			unknown0 = 0xCAFEBABE;

		[IpcCommand(10)]
		void AcquireForegroundRights() {}

		[IpcCommand(11)]
		void ReleaseForegroundRights() {}

		[IpcCommand(12)]
		void RejectToChangeIntoBackground() {}
	}

	public class IAudioController : IpcInterface {
	}

	public class IDisplayController : IpcInterface {
	}

	public class IProcessWindingController : IpcInterface {
	}

	public class ILibraryAppletCreator : IpcInterface {
		[IpcCommand(0)]
		void CreateLibraryApplet(uint unknown0, uint unknown1, out object unknown2) =>
			throw new NotImplementedException();

		[IpcCommand(1)]
		void TerminateAllLibraryApplets() => throw new NotImplementedException();

		[IpcCommand(2)]
		void AreAnyLibraryAppletsLeft(out bool unknown0) => throw new NotImplementedException();

		[IpcCommand(10)]
		void CreateStorage(ulong unknown0, out object unknown1) => throw new NotImplementedException();

		[IpcCommand(11)]
		void CreateTransferMemoryStorage(bool unknown0, ulong unknown1, out object unknown3) =>
			throw new NotImplementedException();

		[IpcCommand(12)]
		void CreateHandleStorage(ulong unknown0, out object unknown2) =>
			throw new NotImplementedException();
	}

	public class IApplicationFunctions : IpcInterface {
		[IpcCommand(1)]
		void PopLaunchParameter(uint unknown0, out object unknown1) => throw new NotImplementedException();

		[IpcCommand(10)]
		void CreateApplicationAndPushAndRequestToStart(ulong /* nn::ncm::ApplicationId */ unknown0, object unknown1) {}

		[IpcCommand(11)]
		void CreateApplicationAndPushAndRequestToStartForQuest(uint unknown0, uint unknown1,
			ulong /* nn::ncm::ApplicationId */ unknown2, object unknown3) {}

		[IpcCommand(12)]
		void CreateApplicationAndRequestToStart(ulong /* nn::ncm::ApplicationId */ unknown0) {}

		[IpcCommand(13)]
		void CreateApplicationAndRequestToStartForQuest(uint unknown0, uint unknown1,
			ulong /* nn::ncm::ApplicationId */ unknown2) {}

		[IpcCommand(20)]
		void EnsureSaveData([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, out ulong unknown1) =>
			throw new NotImplementedException();

		[IpcCommand(21)]
		void GetDesiredLanguage([Bytes(0x8 /* 8 x 1 */)] out byte[] /* nn::settings::LanguageCode */ unknown0) => 
			throw new NotImplementedException();

		[IpcCommand(22)]
		void SetTerminateResult(uint unknown0) {}

		[IpcCommand(23)]
		void GetDisplayVersion([Bytes(0x10 /* 16 x 1 */)] out byte[] /* nn::oe::DisplayVersion */ unknown0) => 
		throw new NotImplementedException();

		[IpcCommand(24)]
		void GetLaunchStorageInfoForDebug(out byte /* nn::ncm::StorageId */ unknown0,
			out byte /* nn::ncm::StorageId */ unknown1) => throw new NotImplementedException();

		[IpcCommand(25)]
		void ExtendSaveData(byte unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1,
			ulong unknown2, ulong unknown3, out ulong unknown4) => throw new NotImplementedException();

		[IpcCommand(26)]
		void GetSaveDataSize(byte unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1,
			out ulong unknown2, out ulong unknown3) => throw new NotImplementedException();

		[IpcCommand(30)]
		void BeginBlockingHomeButtonShortAndLongPressed(ulong unknown0) {}

		[IpcCommand(31)]
		void EndBlockingHomeButtonShortAndLongPressed() {}

		[IpcCommand(32)]
		void BeginBlockingHomeButton(ulong unknown0) {}

		[IpcCommand(33)]
		void EndBlockingHomeButton1() {}

		[IpcCommand(40)]
		void NotifyRunning(out bool unknown0) => throw new NotImplementedException();

		[IpcCommand(50)]
		void GetPseudoDeviceId([Bytes(0x10 /* 16 x 1 */)] out byte[] /* nn::util::Uuid */ unknown0) => 
			throw new NotImplementedException();

		[IpcCommand(60)]
		void SetMediaPlaybackStateForApplication(bool unknown0) {}

		[IpcCommand(65)]
		void IsGamePlayRecordingSupported(out bool unknown0) => throw new NotImplementedException();

		[IpcCommand(66)]
		void InitializeGamePlayRecording(ulong unknown0) {}

		[IpcCommand(67)]
		void SetGamePlayRecordingState(uint unknown0) {}

		[IpcCommand(68)]
		void RequestFlushGamePlayingMovieForDebug() {}

		[IpcCommand(70)]
		void RequestToShutdown() {}

		[IpcCommand(71)]
		void RequestToReboot() {}

		[IpcCommand(80)]
		void ExitAndRequestToShowThanksMessage() {}

		[IpcCommand(90)]
		void EnableApplicationCrashReport(bool unknown0) => throw new NotImplementedException();
	}

	public class IDebugFunctions : IpcInterface {
	}
}