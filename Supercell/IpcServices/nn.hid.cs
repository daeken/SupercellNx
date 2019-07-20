using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Hid {
	public partial class IHidServer {
		public static readonly KSharedMemory Memory = new KSharedMemory(0x40000);
		
		public override Nn.Hid.IAppletResource CreateAppletResource(ulong _0, ulong _1) => new IAppletResource();
		
		public override void ActivateDebugPad(ulong _0, ulong _1) {}
		public override void ActivateTouchScreen(ulong _0, ulong _1) {}
		public override void ActivateMouse(ulong _0, ulong _1) {}
		public override void ActivateKeyboard(ulong _0, ulong _1) {}
		public override void Unknown32(ulong _0, ulong _1, ulong _2) {}
		public override KObject AcquireXpadIdEventHandle(ulong _0) => throw new NotImplementedException();
		public override void ReleaseXpadIdEventHandle(ulong _0) {}
		public override void ActivateXpad(uint _0, ulong _1, ulong _2) {}
		public override void GetXpadIds(out long _0, Buffer<uint> _1) => throw new NotImplementedException();
		public override void ActivateJoyXpad(uint _0) {}
		public override KObject GetJoyXpadLifoHandle(uint _0) => throw new NotImplementedException();
		public override void GetJoyXpadIds(out long _0, Buffer<uint> _1) => throw new NotImplementedException();
		public override void ActivateSixAxisSensor(uint _0) {}
		public override void DeactivateSixAxisSensor(uint _0) {}
		public override KObject GetSixAxisSensorLifoHandle(uint _0) => throw new NotImplementedException();
		public override void ActivateJoySixAxisSensor(uint _0) {}
		public override void DeactivateJoySixAxisSensor(uint _0) {}
		public override KObject GetJoySixAxisSensorLifoHandle(uint _0) => throw new NotImplementedException();
		public override void StartSixAxisSensor(uint _0, ulong _1, ulong _2) {}
		public override void StopSixAxisSensor(uint _0, ulong _1, ulong _2) {}
		public override bool IsSixAxisSensorFusionEnabled(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void EnableSixAxisSensorFusion(bool _0, uint _1, ulong _2, ulong _3) {}
		public override void SetSixAxisSensorFusionParameters(uint _0, float _1, float _2, ulong _3, ulong _4) {}
		public override void GetSixAxisSensorFusionParameters(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public override void ResetSixAxisSensorFusionParameters(uint _0, ulong _1, ulong _2) {}
		public override void SetAccelerometerParameters(uint _0, float _1, float _2, ulong _3, ulong _4) {}
		public override void GetAccelerometerParameters(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public override void ResetAccelerometerParameters(uint _0, ulong _1, ulong _2) {}
		public override void SetAccelerometerPlayMode(uint _0, uint _1, ulong _2, ulong _3) {}
		public override uint GetAccelerometerPlayMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void ResetAccelerometerPlayMode(uint _0, ulong _1, ulong _2) {}
		public override void SetGyroscopeZeroDriftMode(uint _0, uint _1, ulong _2, ulong _3) {}
		public override uint GetGyroscopeZeroDriftMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void ResetGyroscopeZeroDriftMode(uint _0, ulong _1, ulong _2) {}
		public override bool IsSixAxisSensorAtRest(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override bool Unknown83(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void ActivateGesture(int _0, ulong _1, ulong _2) {}
		public override void SetSupportedNpadStyleSet(uint _0, ulong _1, ulong _2) {}
		public override uint GetSupportedNpadStyleSet(ulong _0, ulong _1) => throw new NotImplementedException();
		public override void SetSupportedNpadIdType(ulong _0, ulong _1, Buffer<uint> _2) {}
		public override void ActivateNpad(ulong _0, ulong _1) {}
		public override void DeactivateNpad(ulong _0, ulong _1) {}
		public override KObject AcquireNpadStyleSetUpdateEventHandle(uint _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public override void DisconnectNpad(uint _0, ulong _1, ulong _2) {}
		public override void ActivateNpadWithRevision(uint _0, ulong _1, ulong _2) {}
		public override void SetNpadJoyHoldType(ulong _0, long _1, ulong _2) {}
		public override long GetNpadJoyHoldType(ulong _0, ulong _1) => throw new NotImplementedException();
		public override void SetNpadJoyAssignmentModeSingleByDefault(uint _0, ulong _1, ulong _2) {}
		public override void SetNpadJoyAssignmentModeSingle(uint _0, ulong _1, long _2, ulong _3) {}
		public override void SetNpadJoyAssignmentModeDual(uint _0, ulong _1, ulong _2) {}
		public override void MergeSingleJoyAsDualJoy(uint _0, uint _1, ulong _2, ulong _3) {}
		public override void StartLrAssignmentMode(ulong _0, ulong _1) {}
		public override void StopLrAssignmentMode(ulong _0, ulong _1) {}
		public override void SetNpadHandheldActivationMode(ulong _0, long _1, ulong _2) {}
		public override long GetNpadHandheldActivationMode(ulong _0, ulong _1) => throw new NotImplementedException();
		public override void SwapNpadAssignment(uint _0, uint _1, ulong _2, ulong _3) {}
		public override bool IsUnintendedHomeButtonInputProtectionEnabled(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void EnableUnintendedHomeButtonInputProtection(bool _0, uint _1, ulong _2, ulong _3) {}
		public override void SetNpadJoyAssignmentModeSingleWithDestination(uint _0, ulong _1, ulong _2, ulong _3, out bool _4, out uint _5) => throw new NotImplementedException();
		public override void GetVibrationDeviceInfo(uint _0, out byte[] _1) => throw new NotImplementedException();
		public override void SendVibrationValue(uint _0, object _1, ulong _2, ulong _3) {}
		public override object GetActualVibrationValue(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override Nn.Hid.IActiveVibrationDeviceList CreateActiveVibrationDeviceList() => throw new NotImplementedException();
		public override void PermitVibration(bool _0) {}
		public override bool IsVibrationPermitted() => throw new NotImplementedException();
		public override void SendVibrationValues(ulong _0, Buffer<uint> _1, Buffer<byte> _2) {}
		public override void SendVibrationGcErmCommand(uint _0, ulong _1, ulong _2, ulong _3) {}
		public override ulong GetActualVibrationGcErmCommand(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void BeginPermitVibrationSession(ulong _0) {}
		public override void EndPermitVibrationSession() {}
		public override void ActivateConsoleSixAxisSensor(ulong _0, ulong _1) {}
		public override void StartConsoleSixAxisSensor(uint _0, ulong _1, ulong _2) {}
		public override void StopConsoleSixAxisSensor(uint _0, ulong _1, ulong _2) {}
		public override void ActivateSevenSixAxisSensor(ulong _0, ulong _1) {}
		public override void StartSevenSixAxisSensor(ulong _0, ulong _1) {}
		public override void StopSevenSixAxisSensor(ulong _0, ulong _1) {}
		public override void InitializeSevenSixAxisSensor(uint _0, ulong _1, uint _2, ulong _3, ulong _4, ulong _5) {}
		public override void FinalizeSevenSixAxisSensor(ulong _0, ulong _1) {}
		public override void SetSevenSixAxisSensorFusionStrength(float _0, ulong _1, ulong _2) {}
		public override float GetSevenSixAxisSensorFusionStrength(ulong _0, ulong _1) => throw new NotImplementedException();
		public override void Unknown310(ulong _0, ulong _1) {}
		public override bool IsUsbFullKeyControllerEnabled() => throw new NotImplementedException();
		public override void EnableUsbFullKeyController(bool _0) {}
		public override bool IsUsbFullKeyControllerConnected(uint _0) => throw new NotImplementedException();
		public override bool HasBattery(uint _0) => throw new NotImplementedException();
		public override void HasLeftRightBattery(uint _0, out bool _1, out bool _2) => throw new NotImplementedException();
		public override byte GetNpadInterfaceType(uint _0) => throw new NotImplementedException();
		public override void GetNpadLeftRightInterfaceType(uint _0, out byte _1, out byte _2) => throw new NotImplementedException();
		public override ulong GetPalmaConnectionHandle(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public override void InitializePalma(ulong _0) {}
		public override KObject AcquirePalmaOperationCompleteEvent(ulong _0) => throw new NotImplementedException();
		public override void GetPalmaOperationInfo(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override void PlayPalmaActivity(ulong _0, ulong _1) {}
		public override void SetPalmaFrModeType(ulong _0, ulong _1) {}
		public override void ReadPalmaStep(ulong _0) {}
		public override void EnablePalmaStep(bool _0, ulong _1) {}
		public override void ResetPalmaStep(ulong _0) {}
		public override void ReadPalmaApplicationSection(ulong _0, ulong _1, ulong _2) {}
		public override void WritePalmaApplicationSection(ulong _0, ulong _1, Buffer<byte> _2, ulong _3) {}
		public override void ReadPalmaUniqueCode(ulong _0) {}
		public override void SetPalmaUniqueCodeInvalid(ulong _0) {}
		public override void WritePalmaActivityEntry(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4) {}
		public override void WritePalmaRgbLedPatternEntry(ulong _0, Buffer<byte> _1, ulong _2) {}
		public override void WritePalmaWaveEntry(ulong _0, ulong _1, KObject _2, ulong _3, ulong _4, ulong _5) {}
		public override void SetPalmaDataBaseIdentificationVersion(uint _0, ulong _1, int _2) {}
		public override void GetPalmaDataBaseIdentificationVersion(ulong _0) {}
		public override void SuspendPalmaFeature(ulong _0, ulong _1) {}
		public override void GetPalmaOperationResult(ulong _0) {}
		public override void ReadPalmaPlayLog(ulong _0, ushort _1) {}
		public override void ResetPalmaPlayLog(ulong _0, ushort _1) {}
		public override void SetIsPalmaAllConnectable(ulong _0, bool _1, ulong _2) {}
		public override void SetIsPalmaPairedConnectable(ulong _0, bool _1, ulong _2) {}
		public override void PairPalma(ulong _0) {}
		public override void SetPalmaBoostMode(bool _0) {}
		public override void SetNpadCommunicationMode(ulong _0, long _1, ulong _2) {}
		public override long GetNpadCommunicationMode() => throw new NotImplementedException();
	}

	public partial class IAppletResource {
		public override KObject GetSharedMemoryHandle() => IHidServer.Memory;
	}
}