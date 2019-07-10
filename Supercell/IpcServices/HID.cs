using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices {
	[IpcService("hid")]
	public class IHidServer : IpcInterface {
		public static readonly KSharedMemory Memory = new KSharedMemory(0x40000);
		
		[IpcCommand(0)]
		void CreateAppletResource(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid, [Move] out IAppletResource resource) => resource = new IAppletResource();
		[IpcCommand(1)]
		void ActivateDebugPad(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(11)]
		void ActivateTouchScreen(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(21)]
		void ActivateMouse(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(31)]
		void ActivateKeyboard(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(32)]
		void Unknown32(ulong unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(40)]
		void AcquireXpadIdEventHandle(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(41)]
		void ReleaseXpadIdEventHandle(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(51)]
		void ActivateXpad(uint /* nn::hid::BasicXpadId */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(55)]
		void GetXpadIds(out long unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(56)]
		void ActivateJoyXpad(uint /* nn::hid::JoyXpadId */ unknown0) {}
		[IpcCommand(58)]
		void GetJoyXpadLifoHandle(uint /* nn::hid::JoyXpadId */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(59)]
		void GetJoyXpadIds(out long unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(60)]
		void ActivateSixAxisSensor(uint /* nn::hid::BasicXpadId */ unknown0) {}
		[IpcCommand(61)]
		void DeactivateSixAxisSensor(uint /* nn::hid::BasicXpadId */ unknown0) {}
		[IpcCommand(62)]
		void GetSixAxisSensorLifoHandle(uint /* nn::hid::BasicXpadId */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(63)]
		void ActivateJoySixAxisSensor(uint /* nn::hid::JoyXpadId */ unknown0) {}
		[IpcCommand(64)]
		void DeactivateJoySixAxisSensor(uint /* nn::hid::JoyXpadId */ unknown0) {}
		[IpcCommand(65)]
		void GetJoySixAxisSensorLifoHandle(uint /* nn::hid::JoyXpadId */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(66)]
		void StartSixAxisSensor(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(67)]
		void StopSixAxisSensor(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(68)]
		void IsSixAxisSensorFusionEnabled(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out bool unknown2) => throw new NotImplementedException();
		[IpcCommand(69)]
		void EnableSixAxisSensorFusion(bool unknown0, uint /* nn::hid::SixAxisSensorHandle */ unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(70)]
		void SetSixAxisSensorFusionParameters(uint /* nn::hid::SixAxisSensorHandle */ unknown0, float unknown1, float unknown2, ulong /* nn::applet::AppletResourceUserId */ unknown3, [Pid] ulong pid) {}
		[IpcCommand(71)]
		void GetSixAxisSensorFusionParameters(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out float unknown2, out float unknown3) => throw new NotImplementedException();
		[IpcCommand(72)]
		void ResetSixAxisSensorFusionParameters(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(73)]
		void SetAccelerometerParameters(uint /* nn::hid::SixAxisSensorHandle */ unknown0, float unknown1, float unknown2, ulong /* nn::applet::AppletResourceUserId */ unknown3, [Pid] ulong pid) {}
		[IpcCommand(74)]
		void GetAccelerometerParameters(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out float unknown2, out float unknown3) => throw new NotImplementedException();
		[IpcCommand(75)]
		void ResetAccelerometerParameters(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(76)]
		void SetAccelerometerPlayMode(uint /* nn::hid::SixAxisSensorHandle */ unknown0, uint unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(77)]
		void GetAccelerometerPlayMode(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out uint unknown2) => throw new NotImplementedException();
		[IpcCommand(78)]
		void ResetAccelerometerPlayMode(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(79)]
		void SetGyroscopeZeroDriftMode(uint /* nn::hid::SixAxisSensorHandle */ unknown0, uint unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(80)]
		void GetGyroscopeZeroDriftMode(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out uint unknown2) => throw new NotImplementedException();
		[IpcCommand(81)]
		void ResetGyroscopeZeroDriftMode(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(82)]
		void IsSixAxisSensorAtRest(uint /* nn::hid::SixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out bool unknown2) => throw new NotImplementedException();
		[IpcCommand(83)]
		void Unknown83(ulong unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out bool unknown2) => throw new NotImplementedException();
		[IpcCommand(91)]
		void ActivateGesture(int unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(100)]
		void SetSupportedNpadStyleSet(object unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(101)]
		void GetSupportedNpadStyleSet(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(102)]
		void SetSupportedNpadIdType(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid, object unknown1) {}
		[IpcCommand(103)]
		void ActivateNpad(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(104)]
		void DeactivateNpad(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(106)]
		void AcquireNpadStyleSetUpdateEventHandle(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, ulong unknown2, [Pid] ulong pid, [Move] out KObject unknown3) => throw new NotImplementedException();
		[IpcCommand(107)]
		void DisconnectNpad(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(108)]
		void GetPlayerLedPattern(uint unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(120)]
		void SetNpadJoyHoldType(ulong /* nn::applet::AppletResourceUserId */ unknown0, long unknown1, [Pid] ulong pid) {}
		[IpcCommand(121)]
		void GetNpadJoyHoldType(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid, out long unknown1) => throw new NotImplementedException();
		[IpcCommand(122)]
		void SetNpadJoyAssignmentModeSingleByDefault(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(123)]
		void SetNpadJoyAssignmentModeSingle(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, long unknown2, [Pid] ulong pid) {}
		[IpcCommand(124)]
		void SetNpadJoyAssignmentModeDual(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(125)]
		void MergeSingleJoyAsDualJoy(uint unknown0, uint unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(126)]
		void StartLrAssignmentMode(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(127)]
		void StopLrAssignmentMode(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(128)]
		void SetNpadHandheldActivationMode(ulong /* nn::applet::AppletResourceUserId */ unknown0, long unknown1, [Pid] ulong pid) {}
		[IpcCommand(129)]
		void GetNpadHandheldActivationMode(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid, out long unknown1) => throw new NotImplementedException();
		[IpcCommand(130)]
		void SwapNpadAssignment(uint unknown0, uint unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(131)]
		void IsUnintendedHomeButtonInputProtectionEnabled(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out bool unknown2) => throw new NotImplementedException();
		[IpcCommand(132)]
		void EnableUnintendedHomeButtonInputProtection(bool unknown0, uint unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(133)]
		void SetNpadJoyAssignmentModeSingleWithDestination(uint unknown0, ulong unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid, out bool unknown3, out uint unknown4) => throw new NotImplementedException();
		[IpcCommand(200)]
		void GetVibrationDeviceInfo(uint deviceHandle, [Bytes(0x20 /* 8 x 4 */)] out byte[] deviceInfo) => throw new NotImplementedException();
		[IpcCommand(201)]
		void SendVibrationValue(uint deviceHandle, object unknown1, ulong userId, [Pid] ulong pid) {}
		[IpcCommand(202)]
		void GetActualVibrationValue(uint /* nn::hid::VibrationDeviceHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out object /* nn::hid::VibrationValue */ unknown2) => throw new NotImplementedException();
		[IpcCommand(203)]
		void CreateActiveVibrationDeviceList(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(204)]
		void PermitVibration(bool unknown0) {}
		[IpcCommand(205)]
		void IsVibrationPermitted(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(206)]
		void SendVibrationValues(ulong userId, object unknown1, object unknown2) {}
		[IpcCommand(207)]
		void SendVibrationGcErmCommand(uint /* nn::hid::VibrationDeviceHandle */ unknown0, ulong /* nn::hid::VibrationGcErmCommand */ unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) {}
		[IpcCommand(208)]
		void GetActualVibrationGcErmCommand(uint /* nn::hid::VibrationDeviceHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out ulong /* nn::hid::VibrationGcErmCommand */ unknown2) => throw new NotImplementedException();
		[IpcCommand(209)]
		void BeginPermitVibrationSession(ulong /* nn::applet::AppletResourceUserId */ unknown0) {}
		[IpcCommand(210)]
		void EndPermitVibrationSession() {}
		[IpcCommand(300)]
		void ActivateConsoleSixAxisSensor(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(301)]
		void StartConsoleSixAxisSensor(uint /* nn::hid::ConsoleSixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(302)]
		void StopConsoleSixAxisSensor(uint /* nn::hid::ConsoleSixAxisSensorHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(303)]
		void ActivateSevenSixAxisSensor(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(304)]
		void StartSevenSixAxisSensor(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(305)]
		void StopSevenSixAxisSensor(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(306)]
		void InitializeSevenSixAxisSensor(uint unknown0, ulong unknown1, uint unknown2, ulong unknown3, ulong /* nn::applet::AppletResourceUserId */ unknown4, [Pid] ulong pid) {}
		[IpcCommand(307)]
		void FinalizeSevenSixAxisSensor(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(308)]
		void SetSevenSixAxisSensorFusionStrength(float unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) {}
		[IpcCommand(309)]
		void GetSevenSixAxisSensorFusionStrength(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid, out float unknown1) => throw new NotImplementedException();
		[IpcCommand(310)]
		void Unknown310(ulong /* nn::applet::AppletResourceUserId */ unknown0, [Pid] ulong pid) {}
		[IpcCommand(400)]
		void IsUsbFullKeyControllerEnabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(401)]
		void EnableUsbFullKeyController(bool unknown0) {}
		[IpcCommand(402)]
		void IsUsbFullKeyControllerConnected(uint unknown0, out bool unknown1) => throw new NotImplementedException();
		[IpcCommand(403)]
		void HasBattery(uint unknown0, out bool battery) => battery = true;
		[IpcCommand(404)]
		void HasLeftRightBattery(uint unknown0, out bool unknown1, out bool unknown2) => throw new NotImplementedException();
		[IpcCommand(405)]
		void GetNpadInterfaceType(uint unknown0, out byte unknown1) => throw new NotImplementedException();
		[IpcCommand(406)]
		void GetNpadLeftRightInterfaceType(uint unknown0, out byte unknown1, out byte unknown2) => throw new NotImplementedException();
		[IpcCommand(500)]
		void GetPalmaConnectionHandle(uint unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out ulong /* nn::hid::PalmaConnectionHandle */ unknown2) => throw new NotImplementedException();
		[IpcCommand(501)]
		void InitializePalma(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) {}
		[IpcCommand(502)]
		void AcquirePalmaOperationCompleteEvent(ulong /* nn::hid::PalmaConnectionHandle */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(503)]
		void GetPalmaOperationInfo(ulong /* nn::hid::PalmaConnectionHandle */ unknown0, out ulong unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(504)]
		void PlayPalmaActivity(ulong unknown0, ulong /* nn::hid::PalmaConnectionHandle */ unknown1) {}
		[IpcCommand(505)]
		void SetPalmaFrModeType(ulong unknown0, ulong /* nn::hid::PalmaConnectionHandle */ unknown1) {}
		[IpcCommand(506)]
		void ReadPalmaStep(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) {}
		[IpcCommand(507)]
		void EnablePalmaStep(bool unknown0, ulong /* nn::hid::PalmaConnectionHandle */ unknown1) {}
		[IpcCommand(508)]
		void ResetPalmaStep(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) {}
		[IpcCommand(509)]
		void ReadPalmaApplicationSection(ulong unknown0, ulong unknown1, ulong /* nn::hid::PalmaConnectionHandle */ unknown2) => throw new NotImplementedException();
		[IpcCommand(510)]
		void WritePalmaApplicationSection(ulong unknown0, ulong unknown1, [Buffer(0x19)] Buffer<byte> unknown2, ulong /* nn::hid::PalmaConnectionHandle */ unknown3) {}
		[IpcCommand(511)]
		void ReadPalmaUniqueCode(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(512)]
		void SetPalmaUniqueCodeInvalid(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) {}
		[IpcCommand(513)]
		void WritePalmaActivityEntry(ulong unknown0, ulong unknown1, ulong unknown2, ulong unknown3, ulong /* nn::hid::PalmaConnectionHandle */ unknown4) {}
		[IpcCommand(514)]
		void WritePalmaRgbLedPatternEntry(ulong unknown0, [Buffer(0x5)] Buffer<byte> unknown1, ulong /* nn::hid::PalmaConnectionHandle */ unknown2) {}
		[IpcCommand(515)]
		void WritePalmaWaveEntry(ulong unknown0, ulong unknown1, KObject unknown2, ulong unknown3, ulong unknown4, ulong /* nn::hid::PalmaConnectionHandle */ unknown5) {}
		[IpcCommand(516)]
		void SetPalmaDataBaseIdentificationVersion(uint unknown0, ulong /* nn::hid::PalmaConnectionHandle */ unknown1, int unknown2) {}
		[IpcCommand(517)]
		void GetPalmaDataBaseIdentificationVersion(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(518)]
		void SuspendPalmaFeature(ulong /* nn::hid::PalmaConnectionHandle */ unknown0, ulong /* nn::hid::PalmaFeature */ unknown1) {}
		[IpcCommand(519)]
		void GetPalmaOperationResult(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(520)]
		void ReadPalmaPlayLog(ulong /* nn::hid::PalmaConnectionHandle */ unknown0, ushort unknown1) => throw new NotImplementedException();
		[IpcCommand(521)]
		void ResetPalmaPlayLog(ulong /* nn::hid::PalmaConnectionHandle */ unknown0, ushort unknown1) {}
		[IpcCommand(522)]
		void SetIsPalmaAllConnectable(ulong /* nn::applet::AppletResourceUserId */ unknown0, bool unknown1, [Pid] ulong pid) {}
		[IpcCommand(523)]
		void SetIsPalmaPairedConnectable(ulong /* nn::applet::AppletResourceUserId */ unknown0, bool unknown1, [Pid] ulong pid) {}
		[IpcCommand(524)]
		void PairPalma(ulong /* nn::hid::PalmaConnectionHandle */ unknown0) {}
		[IpcCommand(525)]
		void SetPalmaBoostMode(bool unknown0) {}
		[IpcCommand(1000)]
		void SetNpadCommunicationMode(ulong /* nn::applet::AppletResourceUserId */ unknown0, long unknown1, [Pid] ulong pid) {}
		[IpcCommand(1001)]
		void GetNpadCommunicationMode(out long unknown0) => throw new NotImplementedException();
	}
	
	public class IAppletResource : IpcInterface {
		[IpcCommand(0)]
		void GetSharedMemoryHandle([Copy] out KSharedMemory memory) => memory = IHidServer.Memory;
	}
}