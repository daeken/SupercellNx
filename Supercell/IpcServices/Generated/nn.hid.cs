#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Hid {
	[IpcService("hid:dbg")]
	public unsafe partial class IHidDebugServer : _Base_IHidDebugServer {}
	public unsafe class _Base_IHidDebugServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // DeactivateDebugPad
					DeactivateDebugPad();
					break;
				}
				case 1: { // SetDebugPadAutoPilotState
					SetDebugPadAutoPilotState(im.GetBytes(0, 0x18));
					break;
				}
				case 2: { // UnsetDebugPadAutoPilotState
					UnsetDebugPadAutoPilotState();
					break;
				}
				case 10: { // DeactivateTouchScreen
					DeactivateTouchScreen();
					break;
				}
				case 11: { // SetTouchScreenAutoPilotState
					SetTouchScreenAutoPilotState(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 12: { // UnsetTouchScreenAutoPilotState
					UnsetTouchScreenAutoPilotState();
					break;
				}
				case 20: { // DeactivateMouse
					DeactivateMouse();
					break;
				}
				case 21: { // SetMouseAutoPilotState
					SetMouseAutoPilotState(im.GetBytes(0, 0x1C));
					break;
				}
				case 22: { // UnsetMouseAutoPilotState
					UnsetMouseAutoPilotState();
					break;
				}
				case 30: { // DeactivateKeyboard
					DeactivateKeyboard();
					break;
				}
				case 31: { // SetKeyboardAutoPilotState
					SetKeyboardAutoPilotState(im.GetBytes(0, 0x28));
					break;
				}
				case 32: { // UnsetKeyboardAutoPilotState
					UnsetKeyboardAutoPilotState();
					break;
				}
				case 50: { // DeactivateXpad
					DeactivateXpad(im.GetData<uint>(0));
					break;
				}
				case 51: { // SetXpadAutoPilotState
					SetXpadAutoPilotState(im.GetData<uint>(0), im.GetBytes(4, 0x1C));
					break;
				}
				case 52: { // UnsetXpadAutoPilotState
					UnsetXpadAutoPilotState(im.GetData<uint>(0));
					break;
				}
				case 60: { // DeactivateJoyXpad
					DeactivateJoyXpad(im.GetData<uint>(0));
					break;
				}
				case 91: { // DeactivateGesture
					DeactivateGesture();
					break;
				}
				case 110: { // DeactivateHomeButton
					DeactivateHomeButton();
					break;
				}
				case 111: { // SetHomeButtonAutoPilotState
					SetHomeButtonAutoPilotState(im.GetData<ulong>(0));
					break;
				}
				case 112: { // UnsetHomeButtonAutoPilotState
					UnsetHomeButtonAutoPilotState();
					break;
				}
				case 120: { // DeactivateSleepButton
					DeactivateSleepButton();
					break;
				}
				case 121: { // SetSleepButtonAutoPilotState
					SetSleepButtonAutoPilotState(im.GetData<ulong>(0));
					break;
				}
				case 122: { // UnsetSleepButtonAutoPilotState
					UnsetSleepButtonAutoPilotState();
					break;
				}
				case 123: { // DeactivateInputDetector
					DeactivateInputDetector();
					break;
				}
				case 130: { // DeactivateCaptureButton
					DeactivateCaptureButton();
					break;
				}
				case 131: { // SetCaptureButtonAutoPilotState
					SetCaptureButtonAutoPilotState(im.GetData<ulong>(0));
					break;
				}
				case 132: { // UnsetCaptureButtonAutoPilotState
					UnsetCaptureButtonAutoPilotState();
					break;
				}
				case 133: { // SetShiftAccelerometerCalibrationValue
					SetShiftAccelerometerCalibrationValue(im.GetData<uint>(0), im.GetData<float>(4), im.GetData<float>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 134: { // GetShiftAccelerometerCalibrationValue
					GetShiftAccelerometerCalibrationValue(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid, out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 135: { // SetShiftGyroscopeCalibrationValue
					SetShiftGyroscopeCalibrationValue(im.GetData<uint>(0), im.GetData<float>(4), im.GetData<float>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 136: { // GetShiftGyroscopeCalibrationValue
					GetShiftGyroscopeCalibrationValue(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid, out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 140: { // DeactivateConsoleSixAxisSensor
					DeactivateConsoleSixAxisSensor();
					break;
				}
				case 141: { // GetConsoleSixAxisSensorSamplingFrequency
					var ret = GetConsoleSixAxisSensorSamplingFrequency(null);
					break;
				}
				case 142: { // DeactivateSevenSixAxisSensor
					var ret = DeactivateSevenSixAxisSensor(null);
					break;
				}
				case 201: { // ActivateFirmwareUpdate
					ActivateFirmwareUpdate();
					break;
				}
				case 202: { // DeactivateFirmwareUpdate
					DeactivateFirmwareUpdate();
					break;
				}
				case 203: { // StartFirmwareUpdate
					StartFirmwareUpdate(im.GetData<ulong>(0));
					break;
				}
				case 204: { // GetFirmwareUpdateStage
					GetFirmwareUpdateStage(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 205: { // GetFirmwareVersion
					GetFirmwareVersion(im.GetData<uint>(0), null, out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 206: { // GetDestinationFirmwareVersion
					GetDestinationFirmwareVersion(im.GetData<uint>(0), null, out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 207: { // DiscardFirmwareInfoCacheForRevert
					DiscardFirmwareInfoCacheForRevert();
					break;
				}
				case 208: { // StartFirmwareUpdateForRevert
					StartFirmwareUpdateForRevert(im.GetData<ulong>(0));
					break;
				}
				case 209: { // GetAvailableFirmwareVersionForRevert
					GetAvailableFirmwareVersionForRevert(im.GetData<ulong>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 210: { // IsFirmwareUpdatingDevice
					var ret = IsFirmwareUpdatingDevice(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 221: { // UpdateControllerColor
					UpdateControllerColor(im.GetBytes(0, 0x4), im.GetBytes(4, 0x4), im.GetData<ulong>(8));
					break;
				}
				case 222: { // ConnectUsbPadsAsync
					ConnectUsbPadsAsync();
					break;
				}
				case 223: { // DisconnectUsbPadsAsync
					DisconnectUsbPadsAsync();
					break;
				}
				case 224: { // UpdateDesignInfo
					var ret = UpdateDesignInfo(null);
					break;
				}
				case 225: { // GetUniquePadDriverState
					var ret = GetUniquePadDriverState(null);
					break;
				}
				case 226: { // GetSixAxisSensorDriverStates
					var ret = GetSixAxisSensorDriverStates(null);
					break;
				}
				case 301: { // GetAbstractedPadHandles
					var ret = GetAbstractedPadHandles(null);
					break;
				}
				case 302: { // GetAbstractedPadState
					var ret = GetAbstractedPadState(null);
					break;
				}
				case 303: { // GetAbstractedPadsState
					var ret = GetAbstractedPadsState(null);
					break;
				}
				case 321: { // SetAutoPilotVirtualPadState
					var ret = SetAutoPilotVirtualPadState(null);
					break;
				}
				case 322: { // UnsetAutoPilotVirtualPadState
					var ret = UnsetAutoPilotVirtualPadState(null);
					break;
				}
				case 323: { // UnsetAllAutoPilotVirtualPadState
					var ret = UnsetAllAutoPilotVirtualPadState(null);
					break;
				}
				case 350: { // AddRegisteredDevice
					var ret = AddRegisteredDevice(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidDebugServer: {im.CommandId}");
			}
		}
		
		public virtual void DeactivateDebugPad() => throw new NotImplementedException();
		public virtual void SetDebugPadAutoPilotState(byte[] _0) => throw new NotImplementedException();
		public virtual void UnsetDebugPadAutoPilotState() => throw new NotImplementedException();
		public virtual void DeactivateTouchScreen() => throw new NotImplementedException();
		public virtual void SetTouchScreenAutoPilotState(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void UnsetTouchScreenAutoPilotState() => throw new NotImplementedException();
		public virtual void DeactivateMouse() => throw new NotImplementedException();
		public virtual void SetMouseAutoPilotState(byte[] _0) => throw new NotImplementedException();
		public virtual void UnsetMouseAutoPilotState() => throw new NotImplementedException();
		public virtual void DeactivateKeyboard() => throw new NotImplementedException();
		public virtual void SetKeyboardAutoPilotState(byte[] _0) => throw new NotImplementedException();
		public virtual void UnsetKeyboardAutoPilotState() => throw new NotImplementedException();
		public virtual void DeactivateXpad(uint _0) => throw new NotImplementedException();
		public virtual void SetXpadAutoPilotState(uint _0, byte[] _1) => throw new NotImplementedException();
		public virtual void UnsetXpadAutoPilotState(uint _0) => throw new NotImplementedException();
		public virtual void DeactivateJoyXpad(uint _0) => throw new NotImplementedException();
		public virtual void DeactivateGesture() => throw new NotImplementedException();
		public virtual void DeactivateHomeButton() => throw new NotImplementedException();
		public virtual void SetHomeButtonAutoPilotState(ulong _0) => throw new NotImplementedException();
		public virtual void UnsetHomeButtonAutoPilotState() => throw new NotImplementedException();
		public virtual void DeactivateSleepButton() => throw new NotImplementedException();
		public virtual void SetSleepButtonAutoPilotState(ulong _0) => throw new NotImplementedException();
		public virtual void UnsetSleepButtonAutoPilotState() => throw new NotImplementedException();
		public virtual void DeactivateInputDetector() => throw new NotImplementedException();
		public virtual void DeactivateCaptureButton() => throw new NotImplementedException();
		public virtual void SetCaptureButtonAutoPilotState(ulong _0) => throw new NotImplementedException();
		public virtual void UnsetCaptureButtonAutoPilotState() => throw new NotImplementedException();
		public virtual void SetShiftAccelerometerCalibrationValue(uint _0, float _1, float _2, ulong _3, ulong _4) => throw new NotImplementedException();
		public virtual void GetShiftAccelerometerCalibrationValue(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void SetShiftGyroscopeCalibrationValue(uint _0, float _1, float _2, ulong _3, ulong _4) => throw new NotImplementedException();
		public virtual void GetShiftGyroscopeCalibrationValue(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void DeactivateConsoleSixAxisSensor() => throw new NotImplementedException();
		public virtual object GetConsoleSixAxisSensorSamplingFrequency(object _0) => throw new NotImplementedException();
		public virtual object DeactivateSevenSixAxisSensor(object _0) => throw new NotImplementedException();
		public virtual void ActivateFirmwareUpdate() => throw new NotImplementedException();
		public virtual void DeactivateFirmwareUpdate() => throw new NotImplementedException();
		public virtual void StartFirmwareUpdate(ulong _0) => throw new NotImplementedException();
		public virtual void GetFirmwareUpdateStage(out ulong _0, out ulong _1) => throw new NotImplementedException();
		public virtual void GetFirmwareVersion(uint _0, object _1, out byte[] _2) => throw new NotImplementedException();
		public virtual void GetDestinationFirmwareVersion(uint _0, object _1, out byte[] _2) => throw new NotImplementedException();
		public virtual void DiscardFirmwareInfoCacheForRevert() => throw new NotImplementedException();
		public virtual void StartFirmwareUpdateForRevert(ulong _0) => throw new NotImplementedException();
		public virtual void GetAvailableFirmwareVersionForRevert(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsFirmwareUpdatingDevice(ulong _0) => throw new NotImplementedException();
		public virtual void UpdateControllerColor(byte[] _0, byte[] _1, ulong _2) => throw new NotImplementedException();
		public virtual void ConnectUsbPadsAsync() => throw new NotImplementedException();
		public virtual void DisconnectUsbPadsAsync() => throw new NotImplementedException();
		public virtual object UpdateDesignInfo(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadDriverState(object _0) => throw new NotImplementedException();
		public virtual object GetSixAxisSensorDriverStates(object _0) => throw new NotImplementedException();
		public virtual object GetAbstractedPadHandles(object _0) => throw new NotImplementedException();
		public virtual object GetAbstractedPadState(object _0) => throw new NotImplementedException();
		public virtual object GetAbstractedPadsState(object _0) => throw new NotImplementedException();
		public virtual object SetAutoPilotVirtualPadState(object _0) => throw new NotImplementedException();
		public virtual object UnsetAutoPilotVirtualPadState(object _0) => throw new NotImplementedException();
		public virtual object UnsetAllAutoPilotVirtualPadState(object _0) => throw new NotImplementedException();
		public virtual object AddRegisteredDevice(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("hid")]
	public unsafe partial class IHidServer : _Base_IHidServer {}
	public unsafe class _Base_IHidServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateAppletResource
					var ret = CreateAppletResource(im.GetData<ulong>(0), im.Pid);
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // ActivateDebugPad
					ActivateDebugPad(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 11: { // ActivateTouchScreen
					ActivateTouchScreen(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 21: { // ActivateMouse
					ActivateMouse(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 31: { // ActivateKeyboard
					ActivateKeyboard(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 32: { // Unknown32
					Unknown32(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 40: { // AcquireXpadIdEventHandle
					var ret = AcquireXpadIdEventHandle(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 41: { // ReleaseXpadIdEventHandle
					ReleaseXpadIdEventHandle(im.GetData<ulong>(0));
					break;
				}
				case 51: { // ActivateXpad
					ActivateXpad(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 55: { // GetXpadIds
					GetXpadIds(out var _0, im.GetBuffer<uint>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 56: { // ActivateJoyXpad
					ActivateJoyXpad(im.GetData<uint>(0));
					break;
				}
				case 58: { // GetJoyXpadLifoHandle
					var ret = GetJoyXpadLifoHandle(im.GetData<uint>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 59: { // GetJoyXpadIds
					GetJoyXpadIds(out var _0, im.GetBuffer<uint>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 60: { // ActivateSixAxisSensor
					ActivateSixAxisSensor(im.GetData<uint>(0));
					break;
				}
				case 61: { // DeactivateSixAxisSensor
					DeactivateSixAxisSensor(im.GetData<uint>(0));
					break;
				}
				case 62: { // GetSixAxisSensorLifoHandle
					var ret = GetSixAxisSensorLifoHandle(im.GetData<uint>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 63: { // ActivateJoySixAxisSensor
					ActivateJoySixAxisSensor(im.GetData<uint>(0));
					break;
				}
				case 64: { // DeactivateJoySixAxisSensor
					DeactivateJoySixAxisSensor(im.GetData<uint>(0));
					break;
				}
				case 65: { // GetJoySixAxisSensorLifoHandle
					var ret = GetJoySixAxisSensorLifoHandle(im.GetData<uint>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 66: { // StartSixAxisSensor
					StartSixAxisSensor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 67: { // StopSixAxisSensor
					StopSixAxisSensor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 68: { // IsSixAxisSensorFusionEnabled
					var ret = IsSixAxisSensorFusionEnabled(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 69: { // EnableSixAxisSensorFusion
					EnableSixAxisSensorFusion(im.GetData<bool>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 70: { // SetSixAxisSensorFusionParameters
					SetSixAxisSensorFusionParameters(im.GetData<uint>(0), im.GetData<float>(4), im.GetData<float>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 71: { // GetSixAxisSensorFusionParameters
					GetSixAxisSensorFusionParameters(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid, out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 72: { // ResetSixAxisSensorFusionParameters
					ResetSixAxisSensorFusionParameters(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 73: { // SetAccelerometerParameters
					SetAccelerometerParameters(im.GetData<uint>(0), im.GetData<float>(4), im.GetData<float>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 74: { // GetAccelerometerParameters
					GetAccelerometerParameters(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid, out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 75: { // ResetAccelerometerParameters
					ResetAccelerometerParameters(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 76: { // SetAccelerometerPlayMode
					SetAccelerometerPlayMode(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 77: { // GetAccelerometerPlayMode
					var ret = GetAccelerometerPlayMode(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 78: { // ResetAccelerometerPlayMode
					ResetAccelerometerPlayMode(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 79: { // SetGyroscopeZeroDriftMode
					SetGyroscopeZeroDriftMode(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 80: { // GetGyroscopeZeroDriftMode
					var ret = GetGyroscopeZeroDriftMode(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 81: { // ResetGyroscopeZeroDriftMode
					ResetGyroscopeZeroDriftMode(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 82: { // IsSixAxisSensorAtRest
					var ret = IsSixAxisSensorAtRest(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 83: { // Unknown83
					var ret = Unknown83(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 91: { // ActivateGesture
					ActivateGesture(im.GetData<int>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 100: { // SetSupportedNpadStyleSet
					SetSupportedNpadStyleSet(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 101: { // GetSupportedNpadStyleSet
					var ret = GetSupportedNpadStyleSet(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 102: { // SetSupportedNpadIdType
					SetSupportedNpadIdType(im.GetData<ulong>(0), im.Pid, im.GetBuffer<uint>(0x9, 0));
					break;
				}
				case 103: { // ActivateNpad
					ActivateNpad(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 104: { // DeactivateNpad
					DeactivateNpad(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 106: { // AcquireNpadStyleSetUpdateEventHandle
					var ret = AcquireNpadStyleSetUpdateEventHandle(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 107: { // DisconnectNpad
					DisconnectNpad(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 108: { // ActivateNpadWithRevision
					ActivateNpadWithRevision(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 120: { // SetNpadJoyHoldType
					SetNpadJoyHoldType(im.GetData<ulong>(0), im.GetData<long>(8), im.Pid);
					break;
				}
				case 121: { // GetNpadJoyHoldType
					var ret = GetNpadJoyHoldType(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 122: { // SetNpadJoyAssignmentModeSingleByDefault
					SetNpadJoyAssignmentModeSingleByDefault(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 123: { // SetNpadJoyAssignmentModeSingle
					SetNpadJoyAssignmentModeSingle(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<long>(16), im.Pid);
					break;
				}
				case 124: { // SetNpadJoyAssignmentModeDual
					SetNpadJoyAssignmentModeDual(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 125: { // MergeSingleJoyAsDualJoy
					MergeSingleJoyAsDualJoy(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 126: { // StartLrAssignmentMode
					StartLrAssignmentMode(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 127: { // StopLrAssignmentMode
					StopLrAssignmentMode(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 128: { // SetNpadHandheldActivationMode
					SetNpadHandheldActivationMode(im.GetData<ulong>(0), im.GetData<long>(8), im.Pid);
					break;
				}
				case 129: { // GetNpadHandheldActivationMode
					var ret = GetNpadHandheldActivationMode(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 130: { // SwapNpadAssignment
					SwapNpadAssignment(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 131: { // IsUnintendedHomeButtonInputProtectionEnabled
					var ret = IsUnintendedHomeButtonInputProtectionEnabled(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 132: { // EnableUnintendedHomeButtonInputProtection
					EnableUnintendedHomeButtonInputProtection(im.GetData<bool>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 133: { // SetNpadJoyAssignmentModeSingleWithDestination
					SetNpadJoyAssignmentModeSingleWithDestination(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid, out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 200: { // GetVibrationDeviceInfo
					GetVibrationDeviceInfo(im.GetData<uint>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 201: { // SendVibrationValue
					SendVibrationValue(im.GetData<uint>(0), null, im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 202: { // GetActualVibrationValue
					var ret = GetActualVibrationValue(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 203: { // CreateActiveVibrationDeviceList
					var ret = CreateActiveVibrationDeviceList();
					om.Move(0, ret.Handle);
					break;
				}
				case 204: { // PermitVibration
					PermitVibration(im.GetData<bool>(0));
					break;
				}
				case 205: { // IsVibrationPermitted
					var ret = IsVibrationPermitted();
					om.SetData(0, ret);
					break;
				}
				case 206: { // SendVibrationValues
					SendVibrationValues(im.GetData<ulong>(0), im.GetBuffer<uint>(0x9, 0), im.GetBuffer<byte>(0x9, 1));
					break;
				}
				case 207: { // SendVibrationGcErmCommand
					SendVibrationGcErmCommand(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 208: { // GetActualVibrationGcErmCommand
					var ret = GetActualVibrationGcErmCommand(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 209: { // BeginPermitVibrationSession
					BeginPermitVibrationSession(im.GetData<ulong>(0));
					break;
				}
				case 210: { // EndPermitVibrationSession
					EndPermitVibrationSession();
					break;
				}
				case 300: { // ActivateConsoleSixAxisSensor
					ActivateConsoleSixAxisSensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 301: { // StartConsoleSixAxisSensor
					StartConsoleSixAxisSensor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 302: { // StopConsoleSixAxisSensor
					StopConsoleSixAxisSensor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 303: { // ActivateSevenSixAxisSensor
					ActivateSevenSixAxisSensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 304: { // StartSevenSixAxisSensor
					StartSevenSixAxisSensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 305: { // StopSevenSixAxisSensor
					StopSevenSixAxisSensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 306: { // InitializeSevenSixAxisSensor
					InitializeSevenSixAxisSensor(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<uint>(16), im.GetData<ulong>(24), im.GetData<ulong>(32), im.Pid);
					break;
				}
				case 307: { // FinalizeSevenSixAxisSensor
					FinalizeSevenSixAxisSensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 308: { // SetSevenSixAxisSensorFusionStrength
					SetSevenSixAxisSensorFusionStrength(im.GetData<float>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 309: { // GetSevenSixAxisSensorFusionStrength
					var ret = GetSevenSixAxisSensorFusionStrength(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 310: { // Unknown310
					Unknown310(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 400: { // IsUsbFullKeyControllerEnabled
					var ret = IsUsbFullKeyControllerEnabled();
					om.SetData(0, ret);
					break;
				}
				case 401: { // EnableUsbFullKeyController
					EnableUsbFullKeyController(im.GetData<bool>(0));
					break;
				}
				case 402: { // IsUsbFullKeyControllerConnected
					var ret = IsUsbFullKeyControllerConnected(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 403: { // HasBattery
					var ret = HasBattery(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 404: { // HasLeftRightBattery
					HasLeftRightBattery(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 405: { // GetNpadInterfaceType
					var ret = GetNpadInterfaceType(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 406: { // GetNpadLeftRightInterfaceType
					GetNpadLeftRightInterfaceType(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(1, _1);
					break;
				}
				case 500: { // GetPalmaConnectionHandle
					var ret = GetPalmaConnectionHandle(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 501: { // InitializePalma
					InitializePalma(im.GetData<ulong>(0));
					break;
				}
				case 502: { // AcquirePalmaOperationCompleteEvent
					var ret = AcquirePalmaOperationCompleteEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 503: { // GetPalmaOperationInfo
					GetPalmaOperationInfo(im.GetData<ulong>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 504: { // PlayPalmaActivity
					PlayPalmaActivity(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 505: { // SetPalmaFrModeType
					SetPalmaFrModeType(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 506: { // ReadPalmaStep
					ReadPalmaStep(im.GetData<ulong>(0));
					break;
				}
				case 507: { // EnablePalmaStep
					EnablePalmaStep(im.GetData<bool>(0), im.GetData<ulong>(8));
					break;
				}
				case 508: { // ResetPalmaStep
					ResetPalmaStep(im.GetData<ulong>(0));
					break;
				}
				case 509: { // ReadPalmaApplicationSection
					ReadPalmaApplicationSection(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				case 510: { // WritePalmaApplicationSection
					WritePalmaApplicationSection(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetBuffer<byte>(0x19, 0), im.GetData<ulong>(16));
					break;
				}
				case 511: { // ReadPalmaUniqueCode
					ReadPalmaUniqueCode(im.GetData<ulong>(0));
					break;
				}
				case 512: { // SetPalmaUniqueCodeInvalid
					SetPalmaUniqueCodeInvalid(im.GetData<ulong>(0));
					break;
				}
				case 513: { // WritePalmaActivityEntry
					WritePalmaActivityEntry(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.GetData<ulong>(32));
					break;
				}
				case 514: { // WritePalmaRgbLedPatternEntry
					WritePalmaRgbLedPatternEntry(im.GetData<ulong>(0), im.GetBuffer<byte>(0x5, 0), im.GetData<ulong>(8));
					break;
				}
				case 515: { // WritePalmaWaveEntry
					WritePalmaWaveEntry(im.GetData<ulong>(0), im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)), im.GetData<ulong>(16), im.GetData<ulong>(24), im.GetData<ulong>(32));
					break;
				}
				case 516: { // SetPalmaDataBaseIdentificationVersion
					SetPalmaDataBaseIdentificationVersion(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<int>(16));
					break;
				}
				case 517: { // GetPalmaDataBaseIdentificationVersion
					GetPalmaDataBaseIdentificationVersion(im.GetData<ulong>(0));
					break;
				}
				case 518: { // SuspendPalmaFeature
					SuspendPalmaFeature(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 519: { // GetPalmaOperationResult
					GetPalmaOperationResult(im.GetData<ulong>(0));
					break;
				}
				case 520: { // ReadPalmaPlayLog
					ReadPalmaPlayLog(im.GetData<ulong>(0), im.GetData<ushort>(8));
					break;
				}
				case 521: { // ResetPalmaPlayLog
					ResetPalmaPlayLog(im.GetData<ulong>(0), im.GetData<ushort>(8));
					break;
				}
				case 522: { // SetIsPalmaAllConnectable
					SetIsPalmaAllConnectable(im.GetData<ulong>(0), im.GetData<bool>(8), im.Pid);
					break;
				}
				case 523: { // SetIsPalmaPairedConnectable
					SetIsPalmaPairedConnectable(im.GetData<ulong>(0), im.GetData<bool>(8), im.Pid);
					break;
				}
				case 524: { // PairPalma
					PairPalma(im.GetData<ulong>(0));
					break;
				}
				case 525: { // SetPalmaBoostMode
					SetPalmaBoostMode(im.GetData<bool>(0));
					break;
				}
				case 1000: { // SetNpadCommunicationMode
					SetNpadCommunicationMode(im.GetData<ulong>(0), im.GetData<long>(8), im.Pid);
					break;
				}
				case 1001: { // GetNpadCommunicationMode
					var ret = GetNpadCommunicationMode();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidServer: {im.CommandId}");
			}
		}
		
		public virtual Nn.Hid.IAppletResource CreateAppletResource(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateDebugPad(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateTouchScreen(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateMouse(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateKeyboard(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void Unknown32(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual KObject AcquireXpadIdEventHandle(ulong _0) => throw new NotImplementedException();
		public virtual void ReleaseXpadIdEventHandle(ulong _0) => throw new NotImplementedException();
		public virtual void ActivateXpad(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void GetXpadIds(out long _0, Buffer<uint> _1) => throw new NotImplementedException();
		public virtual void ActivateJoyXpad(uint _0) => throw new NotImplementedException();
		public virtual KObject GetJoyXpadLifoHandle(uint _0) => throw new NotImplementedException();
		public virtual void GetJoyXpadIds(out long _0, Buffer<uint> _1) => throw new NotImplementedException();
		public virtual void ActivateSixAxisSensor(uint _0) => throw new NotImplementedException();
		public virtual void DeactivateSixAxisSensor(uint _0) => throw new NotImplementedException();
		public virtual KObject GetSixAxisSensorLifoHandle(uint _0) => throw new NotImplementedException();
		public virtual void ActivateJoySixAxisSensor(uint _0) => throw new NotImplementedException();
		public virtual void DeactivateJoySixAxisSensor(uint _0) => throw new NotImplementedException();
		public virtual KObject GetJoySixAxisSensorLifoHandle(uint _0) => throw new NotImplementedException();
		public virtual void StartSixAxisSensor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void StopSixAxisSensor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual bool IsSixAxisSensorFusionEnabled(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void EnableSixAxisSensorFusion(bool _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void SetSixAxisSensorFusionParameters(uint _0, float _1, float _2, ulong _3, ulong _4) => throw new NotImplementedException();
		public virtual void GetSixAxisSensorFusionParameters(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void ResetSixAxisSensorFusionParameters(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetAccelerometerParameters(uint _0, float _1, float _2, ulong _3, ulong _4) => throw new NotImplementedException();
		public virtual void GetAccelerometerParameters(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void ResetAccelerometerParameters(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetAccelerometerPlayMode(uint _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual uint GetAccelerometerPlayMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ResetAccelerometerPlayMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetGyroscopeZeroDriftMode(uint _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual uint GetGyroscopeZeroDriftMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ResetGyroscopeZeroDriftMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual bool IsSixAxisSensorAtRest(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual bool Unknown83(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ActivateGesture(int _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetSupportedNpadStyleSet(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual uint GetSupportedNpadStyleSet(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetSupportedNpadIdType(ulong _0, ulong _1, Buffer<uint> _2) => throw new NotImplementedException();
		public virtual void ActivateNpad(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DeactivateNpad(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual KObject AcquireNpadStyleSetUpdateEventHandle(uint _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void DisconnectNpad(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ActivateNpadWithRevision(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetNpadJoyHoldType(ulong _0, long _1, ulong _2) => throw new NotImplementedException();
		public virtual long GetNpadJoyHoldType(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetNpadJoyAssignmentModeSingleByDefault(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetNpadJoyAssignmentModeSingle(uint _0, ulong _1, long _2, ulong _3) => throw new NotImplementedException();
		public virtual void SetNpadJoyAssignmentModeDual(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void MergeSingleJoyAsDualJoy(uint _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void StartLrAssignmentMode(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void StopLrAssignmentMode(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetNpadHandheldActivationMode(ulong _0, long _1, ulong _2) => throw new NotImplementedException();
		public virtual long GetNpadHandheldActivationMode(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SwapNpadAssignment(uint _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual bool IsUnintendedHomeButtonInputProtectionEnabled(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void EnableUnintendedHomeButtonInputProtection(bool _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void SetNpadJoyAssignmentModeSingleWithDestination(uint _0, ulong _1, ulong _2, ulong _3, out bool _4, out uint _5) => throw new NotImplementedException();
		public virtual void GetVibrationDeviceInfo(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void SendVibrationValue(uint _0, object _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual object GetActualVibrationValue(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual Nn.Hid.IActiveVibrationDeviceList CreateActiveVibrationDeviceList() => throw new NotImplementedException();
		public virtual void PermitVibration(bool _0) => throw new NotImplementedException();
		public virtual bool IsVibrationPermitted() => throw new NotImplementedException();
		public virtual void SendVibrationValues(ulong _0, Buffer<uint> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SendVibrationGcErmCommand(uint _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual ulong GetActualVibrationGcErmCommand(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void BeginPermitVibrationSession(ulong _0) => throw new NotImplementedException();
		public virtual void EndPermitVibrationSession() => throw new NotImplementedException();
		public virtual void ActivateConsoleSixAxisSensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void StartConsoleSixAxisSensor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void StopConsoleSixAxisSensor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ActivateSevenSixAxisSensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void StartSevenSixAxisSensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void StopSevenSixAxisSensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void InitializeSevenSixAxisSensor(uint _0, ulong _1, uint _2, ulong _3, ulong _4, ulong _5) => throw new NotImplementedException();
		public virtual void FinalizeSevenSixAxisSensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetSevenSixAxisSensorFusionStrength(float _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual float GetSevenSixAxisSensorFusionStrength(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void Unknown310(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual bool IsUsbFullKeyControllerEnabled() => throw new NotImplementedException();
		public virtual void EnableUsbFullKeyController(bool _0) => throw new NotImplementedException();
		public virtual bool IsUsbFullKeyControllerConnected(uint _0) => throw new NotImplementedException();
		public virtual bool HasBattery(uint _0) => throw new NotImplementedException();
		public virtual void HasLeftRightBattery(uint _0, out bool _1, out bool _2) => throw new NotImplementedException();
		public virtual byte GetNpadInterfaceType(uint _0) => throw new NotImplementedException();
		public virtual void GetNpadLeftRightInterfaceType(uint _0, out byte _1, out byte _2) => throw new NotImplementedException();
		public virtual ulong GetPalmaConnectionHandle(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void InitializePalma(ulong _0) => throw new NotImplementedException();
		public virtual KObject AcquirePalmaOperationCompleteEvent(ulong _0) => throw new NotImplementedException();
		public virtual void GetPalmaOperationInfo(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void PlayPalmaActivity(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetPalmaFrModeType(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ReadPalmaStep(ulong _0) => throw new NotImplementedException();
		public virtual void EnablePalmaStep(bool _0, ulong _1) => throw new NotImplementedException();
		public virtual void ResetPalmaStep(ulong _0) => throw new NotImplementedException();
		public virtual void ReadPalmaApplicationSection(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void WritePalmaApplicationSection(ulong _0, ulong _1, Buffer<byte> _2, ulong _3) => throw new NotImplementedException();
		public virtual void ReadPalmaUniqueCode(ulong _0) => throw new NotImplementedException();
		public virtual void SetPalmaUniqueCodeInvalid(ulong _0) => throw new NotImplementedException();
		public virtual void WritePalmaActivityEntry(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4) => throw new NotImplementedException();
		public virtual void WritePalmaRgbLedPatternEntry(ulong _0, Buffer<byte> _1, ulong _2) => throw new NotImplementedException();
		public virtual void WritePalmaWaveEntry(ulong _0, ulong _1, KObject _2, ulong _3, ulong _4, ulong _5) => throw new NotImplementedException();
		public virtual void SetPalmaDataBaseIdentificationVersion(uint _0, ulong _1, int _2) => throw new NotImplementedException();
		public virtual void GetPalmaDataBaseIdentificationVersion(ulong _0) => throw new NotImplementedException();
		public virtual void SuspendPalmaFeature(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void GetPalmaOperationResult(ulong _0) => throw new NotImplementedException();
		public virtual void ReadPalmaPlayLog(ulong _0, ushort _1) => throw new NotImplementedException();
		public virtual void ResetPalmaPlayLog(ulong _0, ushort _1) => throw new NotImplementedException();
		public virtual void SetIsPalmaAllConnectable(ulong _0, bool _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetIsPalmaPairedConnectable(ulong _0, bool _1, ulong _2) => throw new NotImplementedException();
		public virtual void PairPalma(ulong _0) => throw new NotImplementedException();
		public virtual void SetPalmaBoostMode(bool _0) => throw new NotImplementedException();
		public virtual void SetNpadCommunicationMode(ulong _0, long _1, ulong _2) => throw new NotImplementedException();
		public virtual long GetNpadCommunicationMode() => throw new NotImplementedException();
	}
	
	[IpcService("hid:sys")]
	public unsafe partial class IHidSystemServer : _Base_IHidSystemServer {}
	public unsafe class _Base_IHidSystemServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 31: { // SendKeyboardLockKeyEvent
					SendKeyboardLockKeyEvent(null);
					break;
				}
				case 101: { // AcquireHomeButtonEventHandle
					var ret = AcquireHomeButtonEventHandle(im.GetData<ulong>(0), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 111: { // ActivateHomeButton
					ActivateHomeButton(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 121: { // AcquireSleepButtonEventHandle
					var ret = AcquireSleepButtonEventHandle(im.GetData<ulong>(0), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 131: { // ActivateSleepButton
					ActivateSleepButton(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 141: { // AcquireCaptureButtonEventHandle
					var ret = AcquireCaptureButtonEventHandle(im.GetData<ulong>(0), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 151: { // ActivateCaptureButton
					ActivateCaptureButton(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 210: { // AcquireNfcDeviceUpdateEventHandle
					var ret = AcquireNfcDeviceUpdateEventHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				case 211: { // GetNpadsWithNfc
					GetNpadsWithNfc(out var _0, im.GetBuffer<uint>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 212: { // AcquireNfcActivateEventHandle
					var ret = AcquireNfcActivateEventHandle(im.GetData<uint>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 213: { // ActivateNfc
					ActivateNfc(im.GetData<byte>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 214: { // GetXcdHandleForNpadWithNfc
					var ret = GetXcdHandleForNpadWithNfc(im.GetData<uint>(0), im.GetData<ulong>(8));
					om.SetData(0, ret);
					break;
				}
				case 215: { // IsNfcActivated
					var ret = IsNfcActivated(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 230: { // AcquireIrSensorEventHandle
					var ret = AcquireIrSensorEventHandle(im.GetData<uint>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 231: { // ActivateIrSensor
					ActivateIrSensor(im.GetData<byte>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 301: { // ActivateNpadSystem
					ActivateNpadSystem(im.GetData<uint>(0));
					break;
				}
				case 303: { // ApplyNpadSystemCommonPolicy
					ApplyNpadSystemCommonPolicy(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 304: { // EnableAssigningSingleOnSlSrPress
					EnableAssigningSingleOnSlSrPress(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 305: { // DisableAssigningSingleOnSlSrPress
					DisableAssigningSingleOnSlSrPress(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 306: { // GetLastActiveNpad
					var ret = GetLastActiveNpad();
					om.SetData(0, ret);
					break;
				}
				case 307: { // GetNpadSystemExtStyle
					GetNpadSystemExtStyle(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 308: { // ApplyNpadSystemCommonPolicyFull
					var ret = ApplyNpadSystemCommonPolicyFull(null);
					break;
				}
				case 309: { // GetNpadFullKeyGripColor
					var ret = GetNpadFullKeyGripColor(null);
					break;
				}
				case 311: { // SetNpadPlayerLedBlinkingDevice
					SetNpadPlayerLedBlinkingDevice(im.GetData<uint>(0), null, im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 321: { // GetUniquePadsFromNpad
					GetUniquePadsFromNpad(im.GetData<uint>(0), out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 322: { // GetIrSensorState
					var ret = GetIrSensorState(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 323: { // GetXcdHandleForNpadWithIrSensor
					var ret = GetXcdHandleForNpadWithIrSensor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 500: { // SetAppletResourceUserId
					SetAppletResourceUserId(im.GetData<ulong>(0));
					break;
				}
				case 501: { // RegisterAppletResourceUserId
					RegisterAppletResourceUserId(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 502: { // UnregisterAppletResourceUserId
					UnregisterAppletResourceUserId(im.GetData<ulong>(0));
					break;
				}
				case 503: { // EnableAppletToGetInput
					EnableAppletToGetInput(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 504: { // SetAruidValidForVibration
					SetAruidValidForVibration(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 505: { // EnableAppletToGetSixAxisSensor
					EnableAppletToGetSixAxisSensor(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 510: { // SetVibrationMasterVolume
					SetVibrationMasterVolume(im.GetData<float>(0));
					break;
				}
				case 511: { // GetVibrationMasterVolume
					var ret = GetVibrationMasterVolume();
					om.SetData(0, ret);
					break;
				}
				case 512: { // BeginPermitVibrationSession
					BeginPermitVibrationSession(im.GetData<ulong>(0));
					break;
				}
				case 513: { // EndPermitVibrationSession
					EndPermitVibrationSession();
					break;
				}
				case 520: { // EnableHandheldHids
					EnableHandheldHids();
					break;
				}
				case 521: { // DisableHandheldHids
					DisableHandheldHids();
					break;
				}
				case 540: { // AcquirePlayReportControllerUsageUpdateEvent
					var ret = AcquirePlayReportControllerUsageUpdateEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 541: { // GetPlayReportControllerUsages
					GetPlayReportControllerUsages(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 542: { // AcquirePlayReportRegisteredDeviceUpdateEvent
					var ret = AcquirePlayReportRegisteredDeviceUpdateEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 543: { // GetRegisteredDevicesOld
					GetRegisteredDevicesOld(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 544: { // AcquireConnectionTriggerTimeoutEvent
					var ret = AcquireConnectionTriggerTimeoutEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 545: { // SendConnectionTrigger
					SendConnectionTrigger(im.GetBytes(0, 0x6));
					break;
				}
				case 546: { // AcquireDeviceRegisteredEventForControllerSupport
					var ret = AcquireDeviceRegisteredEventForControllerSupport();
					om.Copy(0, ret.Handle);
					break;
				}
				case 547: { // GetAllowedBluetoothLinksCount
					var ret = GetAllowedBluetoothLinksCount();
					om.SetData(0, ret);
					break;
				}
				case 548: { // GetRegisteredDevices
					var ret = GetRegisteredDevices(null);
					break;
				}
				case 700: { // ActivateUniquePad
					ActivateUniquePad(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 702: { // AcquireUniquePadConnectionEventHandle
					var ret = AcquireUniquePadConnectionEventHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				case 703: { // GetUniquePadIds
					GetUniquePadIds(out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 751: { // AcquireJoyDetachOnBluetoothOffEventHandle
					var ret = AcquireJoyDetachOnBluetoothOffEventHandle(im.GetData<ulong>(0), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 800: { // ListSixAxisSensorHandles
					ListSixAxisSensorHandles(im.GetData<ulong>(0), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 801: { // IsSixAxisSensorUserCalibrationSupported
					var ret = IsSixAxisSensorUserCalibrationSupported(null);
					om.SetData(0, ret);
					break;
				}
				case 802: { // ResetSixAxisSensorCalibrationValues
					ResetSixAxisSensorCalibrationValues(null);
					break;
				}
				case 803: { // StartSixAxisSensorUserCalibration
					StartSixAxisSensorUserCalibration(null);
					break;
				}
				case 804: { // CancelSixAxisSensorUserCalibration
					CancelSixAxisSensorUserCalibration(null);
					break;
				}
				case 805: { // GetUniquePadBluetoothAddress
					GetUniquePadBluetoothAddress(im.GetData<ulong>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 806: { // DisconnectUniquePad
					DisconnectUniquePad(im.GetData<ulong>(0));
					break;
				}
				case 807: { // GetUniquePadType
					var ret = GetUniquePadType(null);
					break;
				}
				case 808: { // GetUniquePadInterface
					var ret = GetUniquePadInterface(null);
					break;
				}
				case 809: { // GetUniquePadSerialNumber
					var ret = GetUniquePadSerialNumber(null);
					break;
				}
				case 810: { // GetUniquePadControllerNumber
					var ret = GetUniquePadControllerNumber(null);
					break;
				}
				case 811: { // GetSixAxisSensorUserCalibrationStage
					var ret = GetSixAxisSensorUserCalibrationStage(null);
					break;
				}
				case 821: { // StartAnalogStickManualCalibration
					StartAnalogStickManualCalibration(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 822: { // RetryCurrentAnalogStickManualCalibrationStage
					RetryCurrentAnalogStickManualCalibrationStage(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 823: { // CancelAnalogStickManualCalibration
					CancelAnalogStickManualCalibration(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 824: { // ResetAnalogStickManualCalibration
					ResetAnalogStickManualCalibration(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 825: { // GetAnalogStickState
					var ret = GetAnalogStickState(null);
					break;
				}
				case 826: { // GetAnalogStickManualCalibrationStage
					var ret = GetAnalogStickManualCalibrationStage(null);
					break;
				}
				case 827: { // IsAnalogStickButtonPressed
					var ret = IsAnalogStickButtonPressed(null);
					break;
				}
				case 828: { // IsAnalogStickInReleasePosition
					var ret = IsAnalogStickInReleasePosition(null);
					break;
				}
				case 829: { // IsAnalogStickInCircumference
					var ret = IsAnalogStickInCircumference(null);
					break;
				}
				case 850: { // IsUsbFullKeyControllerEnabled
					var ret = IsUsbFullKeyControllerEnabled();
					om.SetData(0, ret);
					break;
				}
				case 851: { // EnableUsbFullKeyController
					EnableUsbFullKeyController(im.GetData<byte>(0));
					break;
				}
				case 852: { // IsUsbConnected
					var ret = IsUsbConnected(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 900: { // ActivateInputDetector
					ActivateInputDetector(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 901: { // NotifyInputDetector
					NotifyInputDetector(null);
					break;
				}
				case 1000: { // InitializeFirmwareUpdate
					InitializeFirmwareUpdate();
					break;
				}
				case 1001: { // GetFirmwareVersion
					GetFirmwareVersion(im.GetData<ulong>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1002: { // GetAvailableFirmwareVersion
					GetAvailableFirmwareVersion(im.GetData<ulong>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1003: { // IsFirmwareUpdateAvailable
					var ret = IsFirmwareUpdateAvailable(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 1004: { // CheckFirmwareUpdateRequired
					var ret = CheckFirmwareUpdateRequired(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 1005: { // StartFirmwareUpdate
					var ret = StartFirmwareUpdate(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 1006: { // AbortFirmwareUpdate
					AbortFirmwareUpdate();
					break;
				}
				case 1007: { // GetFirmwareUpdateState
					GetFirmwareUpdateState(im.GetData<ulong>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1008: { // ActivateAudioControl
					ActivateAudioControl();
					break;
				}
				case 1009: { // AcquireAudioControlEventHandle
					var ret = AcquireAudioControlEventHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1010: { // GetAudioControlStates
					GetAudioControlStates(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 1011: { // DeactivateAudioControl
					DeactivateAudioControl();
					break;
				}
				case 1050: { // IsSixAxisSensorAccurateUserCalibrationSupported
					var ret = IsSixAxisSensorAccurateUserCalibrationSupported(null);
					break;
				}
				case 1051: { // StartSixAxisSensorAccurateUserCalibration
					var ret = StartSixAxisSensorAccurateUserCalibration(null);
					break;
				}
				case 1052: { // CancelSixAxisSensorAccurateUserCalibration
					var ret = CancelSixAxisSensorAccurateUserCalibration(null);
					break;
				}
				case 1053: { // GetSixAxisSensorAccurateUserCalibrationState
					var ret = GetSixAxisSensorAccurateUserCalibrationState(null);
					break;
				}
				case 1100: { // GetHidbusSystemServiceObject
					var ret = GetHidbusSystemServiceObject(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidSystemServer: {im.CommandId}");
			}
		}
		
		public virtual void SendKeyboardLockKeyEvent(object _0) => throw new NotImplementedException();
		public virtual KObject AcquireHomeButtonEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateHomeButton(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual KObject AcquireSleepButtonEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateSleepButton(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual KObject AcquireCaptureButtonEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateCaptureButton(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual KObject AcquireNfcDeviceUpdateEventHandle() => throw new NotImplementedException();
		public virtual void GetNpadsWithNfc(out ulong _0, Buffer<uint> _1) => throw new NotImplementedException();
		public virtual KObject AcquireNfcActivateEventHandle(uint _0) => throw new NotImplementedException();
		public virtual void ActivateNfc(byte _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual ulong GetXcdHandleForNpadWithNfc(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual byte IsNfcActivated(uint _0) => throw new NotImplementedException();
		public virtual KObject AcquireIrSensorEventHandle(uint _0) => throw new NotImplementedException();
		public virtual void ActivateIrSensor(byte _0, uint _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void ActivateNpadSystem(uint _0) => throw new NotImplementedException();
		public virtual void ApplyNpadSystemCommonPolicy(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void EnableAssigningSingleOnSlSrPress(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DisableAssigningSingleOnSlSrPress(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetLastActiveNpad() => throw new NotImplementedException();
		public virtual void GetNpadSystemExtStyle(uint _0, out ulong _1, out ulong _2) => throw new NotImplementedException();
		public virtual object ApplyNpadSystemCommonPolicyFull(object _0) => throw new NotImplementedException();
		public virtual object GetNpadFullKeyGripColor(object _0) => throw new NotImplementedException();
		public virtual void SetNpadPlayerLedBlinkingDevice(uint _0, object _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void GetUniquePadsFromNpad(uint _0, out ulong _1, Buffer<ulong> _2) => throw new NotImplementedException();
		public virtual ulong GetIrSensorState(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual ulong GetXcdHandleForNpadWithIrSensor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetAppletResourceUserId(ulong _0) => throw new NotImplementedException();
		public virtual void RegisterAppletResourceUserId(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void UnregisterAppletResourceUserId(ulong _0) => throw new NotImplementedException();
		public virtual void EnableAppletToGetInput(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetAruidValidForVibration(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void EnableAppletToGetSixAxisSensor(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetVibrationMasterVolume(float _0) => throw new NotImplementedException();
		public virtual float GetVibrationMasterVolume() => throw new NotImplementedException();
		public virtual void BeginPermitVibrationSession(ulong _0) => throw new NotImplementedException();
		public virtual void EndPermitVibrationSession() => throw new NotImplementedException();
		public virtual void EnableHandheldHids() => throw new NotImplementedException();
		public virtual void DisableHandheldHids() => throw new NotImplementedException();
		public virtual KObject AcquirePlayReportControllerUsageUpdateEvent() => throw new NotImplementedException();
		public virtual void GetPlayReportControllerUsages(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AcquirePlayReportRegisteredDeviceUpdateEvent() => throw new NotImplementedException();
		public virtual void GetRegisteredDevicesOld(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AcquireConnectionTriggerTimeoutEvent() => throw new NotImplementedException();
		public virtual void SendConnectionTrigger(byte[] _0) => throw new NotImplementedException();
		public virtual KObject AcquireDeviceRegisteredEventForControllerSupport() => throw new NotImplementedException();
		public virtual ulong GetAllowedBluetoothLinksCount() => throw new NotImplementedException();
		public virtual object GetRegisteredDevices(object _0) => throw new NotImplementedException();
		public virtual void ActivateUniquePad(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual KObject AcquireUniquePadConnectionEventHandle() => throw new NotImplementedException();
		public virtual void GetUniquePadIds(out ulong _0, Buffer<ulong> _1) => throw new NotImplementedException();
		public virtual KObject AcquireJoyDetachOnBluetoothOffEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ListSixAxisSensorHandles(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual byte IsSixAxisSensorUserCalibrationSupported(object _0) => throw new NotImplementedException();
		public virtual void ResetSixAxisSensorCalibrationValues(object _0) => throw new NotImplementedException();
		public virtual void StartSixAxisSensorUserCalibration(object _0) => throw new NotImplementedException();
		public virtual void CancelSixAxisSensorUserCalibration(object _0) => throw new NotImplementedException();
		public virtual void GetUniquePadBluetoothAddress(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void DisconnectUniquePad(ulong _0) => throw new NotImplementedException();
		public virtual object GetUniquePadType(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadInterface(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadSerialNumber(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadControllerNumber(object _0) => throw new NotImplementedException();
		public virtual object GetSixAxisSensorUserCalibrationStage(object _0) => throw new NotImplementedException();
		public virtual void StartAnalogStickManualCalibration(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void RetryCurrentAnalogStickManualCalibrationStage(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void CancelAnalogStickManualCalibration(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ResetAnalogStickManualCalibration(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual object GetAnalogStickState(object _0) => throw new NotImplementedException();
		public virtual object GetAnalogStickManualCalibrationStage(object _0) => throw new NotImplementedException();
		public virtual object IsAnalogStickButtonPressed(object _0) => throw new NotImplementedException();
		public virtual object IsAnalogStickInReleasePosition(object _0) => throw new NotImplementedException();
		public virtual object IsAnalogStickInCircumference(object _0) => throw new NotImplementedException();
		public virtual byte IsUsbFullKeyControllerEnabled() => throw new NotImplementedException();
		public virtual void EnableUsbFullKeyController(byte _0) => throw new NotImplementedException();
		public virtual byte IsUsbConnected(ulong _0) => throw new NotImplementedException();
		public virtual void ActivateInputDetector(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void NotifyInputDetector(object _0) => throw new NotImplementedException();
		public virtual void InitializeFirmwareUpdate() => throw new NotImplementedException();
		public virtual void GetFirmwareVersion(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void GetAvailableFirmwareVersion(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsFirmwareUpdateAvailable(ulong _0) => throw new NotImplementedException();
		public virtual ulong CheckFirmwareUpdateRequired(ulong _0) => throw new NotImplementedException();
		public virtual ulong StartFirmwareUpdate(ulong _0) => throw new NotImplementedException();
		public virtual void AbortFirmwareUpdate() => throw new NotImplementedException();
		public virtual void GetFirmwareUpdateState(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void ActivateAudioControl() => throw new NotImplementedException();
		public virtual KObject AcquireAudioControlEventHandle() => throw new NotImplementedException();
		public virtual void GetAudioControlStates(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeactivateAudioControl() => throw new NotImplementedException();
		public virtual object IsSixAxisSensorAccurateUserCalibrationSupported(object _0) => throw new NotImplementedException();
		public virtual object StartSixAxisSensorAccurateUserCalibration(object _0) => throw new NotImplementedException();
		public virtual object CancelSixAxisSensorAccurateUserCalibration(object _0) => throw new NotImplementedException();
		public virtual object GetSixAxisSensorAccurateUserCalibrationState(object _0) => throw new NotImplementedException();
		public virtual object GetHidbusSystemServiceObject(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("hid:tmp")]
	public unsafe partial class IHidTemporaryServer : _Base_IHidTemporaryServer {}
	public unsafe class _Base_IHidTemporaryServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetConsoleSixAxisSensorCalibrationValues
					GetConsoleSixAxisSensorCalibrationValues(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid, out var _0);
					om.SetBytes(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidTemporaryServer: {im.CommandId}");
			}
		}
		
		public virtual void GetConsoleSixAxisSensorCalibrationValues(uint _0, ulong _1, ulong _2, out byte[] _3) => throw new NotImplementedException();
	}
	
	public unsafe partial class IActiveVibrationDeviceList : _Base_IActiveVibrationDeviceList {}
	public unsafe class _Base_IActiveVibrationDeviceList : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ActivateVibrationDevice
					ActivateVibrationDevice(im.GetData<uint>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IActiveVibrationDeviceList: {im.CommandId}");
			}
		}
		
		public virtual void ActivateVibrationDevice(uint _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAppletResource : _Base_IAppletResource {}
	public unsafe class _Base_IAppletResource : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSharedMemoryHandle
					var ret = GetSharedMemoryHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAppletResource: {im.CommandId}");
			}
		}
		
		public virtual KObject GetSharedMemoryHandle() => throw new NotImplementedException();
	}
}
