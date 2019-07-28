#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Hid {
	[IpcService("hid:dbg")]
	public unsafe partial class IHidDebugServer : _Base_IHidDebugServer {}
	public unsafe class _Base_IHidDebugServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // DeactivateDebugPad
					DeactivateDebugPad();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // SetDebugPadAutoPilotState
					SetDebugPadAutoPilotState(im.GetBytes(8, 0x18));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // UnsetDebugPadAutoPilotState
					UnsetDebugPadAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // DeactivateTouchScreen
					DeactivateTouchScreen();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // SetTouchScreenAutoPilotState
					SetTouchScreenAutoPilotState(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // UnsetTouchScreenAutoPilotState
					UnsetTouchScreenAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // DeactivateMouse
					DeactivateMouse();
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // SetMouseAutoPilotState
					SetMouseAutoPilotState(im.GetBytes(8, 0x1C));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // UnsetMouseAutoPilotState
					UnsetMouseAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // DeactivateKeyboard
					DeactivateKeyboard();
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // SetKeyboardAutoPilotState
					SetKeyboardAutoPilotState(im.GetBytes(8, 0x28));
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // UnsetKeyboardAutoPilotState
					UnsetKeyboardAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 50: { // DeactivateXpad
					DeactivateXpad(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 51: { // SetXpadAutoPilotState
					SetXpadAutoPilotState(im.GetData<uint>(8), im.GetBytes(12, 0x1C));
					om.Initialize(0, 0, 0);
					break;
				}
				case 52: { // UnsetXpadAutoPilotState
					UnsetXpadAutoPilotState(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 60: { // DeactivateJoyXpad
					DeactivateJoyXpad(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 91: { // DeactivateGesture
					DeactivateGesture();
					om.Initialize(0, 0, 0);
					break;
				}
				case 110: { // DeactivateHomeButton
					DeactivateHomeButton();
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // SetHomeButtonAutoPilotState
					SetHomeButtonAutoPilotState(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 112: { // UnsetHomeButtonAutoPilotState
					UnsetHomeButtonAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 120: { // DeactivateSleepButton
					DeactivateSleepButton();
					om.Initialize(0, 0, 0);
					break;
				}
				case 121: { // SetSleepButtonAutoPilotState
					SetSleepButtonAutoPilotState(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 122: { // UnsetSleepButtonAutoPilotState
					UnsetSleepButtonAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 123: { // DeactivateInputDetector
					DeactivateInputDetector();
					om.Initialize(0, 0, 0);
					break;
				}
				case 130: { // DeactivateCaptureButton
					DeactivateCaptureButton();
					om.Initialize(0, 0, 0);
					break;
				}
				case 131: { // SetCaptureButtonAutoPilotState
					SetCaptureButtonAutoPilotState(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 132: { // UnsetCaptureButtonAutoPilotState
					UnsetCaptureButtonAutoPilotState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 133: { // SetShiftAccelerometerCalibrationValue
					SetShiftAccelerometerCalibrationValue(im.GetData<uint>(8), im.GetData<float>(12), im.GetData<float>(16), im.GetData<ulong>(24), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 134: { // GetShiftAccelerometerCalibrationValue
					GetShiftAccelerometerCalibrationValue(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid, out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 135: { // SetShiftGyroscopeCalibrationValue
					SetShiftGyroscopeCalibrationValue(im.GetData<uint>(8), im.GetData<float>(12), im.GetData<float>(16), im.GetData<ulong>(24), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 136: { // GetShiftGyroscopeCalibrationValue
					GetShiftGyroscopeCalibrationValue(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid, out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 140: { // DeactivateConsoleSixAxisSensor
					DeactivateConsoleSixAxisSensor();
					om.Initialize(0, 0, 0);
					break;
				}
				case 141: { // GetConsoleSixAxisSensorSamplingFrequency
					var ret = GetConsoleSixAxisSensorSamplingFrequency(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 142: { // DeactivateSevenSixAxisSensor
					var ret = DeactivateSevenSixAxisSensor(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 201: { // ActivateFirmwareUpdate
					ActivateFirmwareUpdate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // DeactivateFirmwareUpdate
					DeactivateFirmwareUpdate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 203: { // StartFirmwareUpdate
					StartFirmwareUpdate(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 204: { // GetFirmwareUpdateStage
					GetFirmwareUpdateStage(out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 205: { // GetFirmwareVersion
					GetFirmwareVersion(im.GetData<uint>(8), null, out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 206: { // GetDestinationFirmwareVersion
					GetDestinationFirmwareVersion(im.GetData<uint>(8), null, out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 207: { // DiscardFirmwareInfoCacheForRevert
					DiscardFirmwareInfoCacheForRevert();
					om.Initialize(0, 0, 0);
					break;
				}
				case 208: { // StartFirmwareUpdateForRevert
					StartFirmwareUpdateForRevert(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 209: { // GetAvailableFirmwareVersionForRevert
					GetAvailableFirmwareVersionForRevert(im.GetData<ulong>(8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 210: { // IsFirmwareUpdatingDevice
					var ret = IsFirmwareUpdatingDevice(im.GetData<ulong>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 221: { // UpdateControllerColor
					UpdateControllerColor(im.GetBytes(8, 0x4), im.GetBytes(12, 0x4), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 222: { // ConnectUsbPadsAsync
					ConnectUsbPadsAsync();
					om.Initialize(0, 0, 0);
					break;
				}
				case 223: { // DisconnectUsbPadsAsync
					DisconnectUsbPadsAsync();
					om.Initialize(0, 0, 0);
					break;
				}
				case 224: { // UpdateDesignInfo
					var ret = UpdateDesignInfo(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 225: { // GetUniquePadDriverState
					var ret = GetUniquePadDriverState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 226: { // GetSixAxisSensorDriverStates
					var ret = GetSixAxisSensorDriverStates(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // GetAbstractedPadHandles
					var ret = GetAbstractedPadHandles(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // GetAbstractedPadState
					var ret = GetAbstractedPadState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 303: { // GetAbstractedPadsState
					var ret = GetAbstractedPadsState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 321: { // SetAutoPilotVirtualPadState
					var ret = SetAutoPilotVirtualPadState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 322: { // UnsetAutoPilotVirtualPadState
					var ret = UnsetAutoPilotVirtualPadState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 323: { // UnsetAllAutoPilotVirtualPadState
					var ret = UnsetAllAutoPilotVirtualPadState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 350: { // AddRegisteredDevice
					var ret = AddRegisteredDevice(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidDebugServer: {im.CommandId}");
			}
		}
		
		public virtual void DeactivateDebugPad() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateDebugPad [0]".Debug();
		public virtual void SetDebugPadAutoPilotState(byte[] _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetDebugPadAutoPilotState [1]".Debug();
		public virtual void UnsetDebugPadAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetDebugPadAutoPilotState [2]".Debug();
		public virtual void DeactivateTouchScreen() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateTouchScreen [10]".Debug();
		public virtual void SetTouchScreenAutoPilotState(Buffer<byte> _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetTouchScreenAutoPilotState [11]".Debug();
		public virtual void UnsetTouchScreenAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetTouchScreenAutoPilotState [12]".Debug();
		public virtual void DeactivateMouse() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateMouse [20]".Debug();
		public virtual void SetMouseAutoPilotState(byte[] _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetMouseAutoPilotState [21]".Debug();
		public virtual void UnsetMouseAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetMouseAutoPilotState [22]".Debug();
		public virtual void DeactivateKeyboard() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateKeyboard [30]".Debug();
		public virtual void SetKeyboardAutoPilotState(byte[] _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetKeyboardAutoPilotState [31]".Debug();
		public virtual void UnsetKeyboardAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetKeyboardAutoPilotState [32]".Debug();
		public virtual void DeactivateXpad(uint _0) => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateXpad [50]".Debug();
		public virtual void SetXpadAutoPilotState(uint _0, byte[] _1) => "Stub hit for Nn.Hid.IHidDebugServer.SetXpadAutoPilotState [51]".Debug();
		public virtual void UnsetXpadAutoPilotState(uint _0) => "Stub hit for Nn.Hid.IHidDebugServer.UnsetXpadAutoPilotState [52]".Debug();
		public virtual void DeactivateJoyXpad(uint _0) => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateJoyXpad [60]".Debug();
		public virtual void DeactivateGesture() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateGesture [91]".Debug();
		public virtual void DeactivateHomeButton() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateHomeButton [110]".Debug();
		public virtual void SetHomeButtonAutoPilotState(ulong _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetHomeButtonAutoPilotState [111]".Debug();
		public virtual void UnsetHomeButtonAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetHomeButtonAutoPilotState [112]".Debug();
		public virtual void DeactivateSleepButton() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateSleepButton [120]".Debug();
		public virtual void SetSleepButtonAutoPilotState(ulong _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetSleepButtonAutoPilotState [121]".Debug();
		public virtual void UnsetSleepButtonAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetSleepButtonAutoPilotState [122]".Debug();
		public virtual void DeactivateInputDetector() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateInputDetector [123]".Debug();
		public virtual void DeactivateCaptureButton() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateCaptureButton [130]".Debug();
		public virtual void SetCaptureButtonAutoPilotState(ulong _0) => "Stub hit for Nn.Hid.IHidDebugServer.SetCaptureButtonAutoPilotState [131]".Debug();
		public virtual void UnsetCaptureButtonAutoPilotState() => "Stub hit for Nn.Hid.IHidDebugServer.UnsetCaptureButtonAutoPilotState [132]".Debug();
		public virtual void SetShiftAccelerometerCalibrationValue(uint _0, float _1, float _2, ulong _3, ulong _4) => "Stub hit for Nn.Hid.IHidDebugServer.SetShiftAccelerometerCalibrationValue [133]".Debug();
		public virtual void GetShiftAccelerometerCalibrationValue(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void SetShiftGyroscopeCalibrationValue(uint _0, float _1, float _2, ulong _3, ulong _4) => "Stub hit for Nn.Hid.IHidDebugServer.SetShiftGyroscopeCalibrationValue [135]".Debug();
		public virtual void GetShiftGyroscopeCalibrationValue(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void DeactivateConsoleSixAxisSensor() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateConsoleSixAxisSensor [140]".Debug();
		public virtual object GetConsoleSixAxisSensorSamplingFrequency(object _0) => throw new NotImplementedException();
		public virtual object DeactivateSevenSixAxisSensor(object _0) => throw new NotImplementedException();
		public virtual void ActivateFirmwareUpdate() => "Stub hit for Nn.Hid.IHidDebugServer.ActivateFirmwareUpdate [201]".Debug();
		public virtual void DeactivateFirmwareUpdate() => "Stub hit for Nn.Hid.IHidDebugServer.DeactivateFirmwareUpdate [202]".Debug();
		public virtual void StartFirmwareUpdate(ulong _0) => "Stub hit for Nn.Hid.IHidDebugServer.StartFirmwareUpdate [203]".Debug();
		public virtual void GetFirmwareUpdateStage(out ulong _0, out ulong _1) => throw new NotImplementedException();
		public virtual void GetFirmwareVersion(uint _0, object _1, out byte[] _2) => throw new NotImplementedException();
		public virtual void GetDestinationFirmwareVersion(uint _0, object _1, out byte[] _2) => throw new NotImplementedException();
		public virtual void DiscardFirmwareInfoCacheForRevert() => "Stub hit for Nn.Hid.IHidDebugServer.DiscardFirmwareInfoCacheForRevert [207]".Debug();
		public virtual void StartFirmwareUpdateForRevert(ulong _0) => "Stub hit for Nn.Hid.IHidDebugServer.StartFirmwareUpdateForRevert [208]".Debug();
		public virtual void GetAvailableFirmwareVersionForRevert(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsFirmwareUpdatingDevice(ulong _0) => throw new NotImplementedException();
		public virtual void UpdateControllerColor(byte[] _0, byte[] _1, ulong _2) => "Stub hit for Nn.Hid.IHidDebugServer.UpdateControllerColor [221]".Debug();
		public virtual void ConnectUsbPadsAsync() => "Stub hit for Nn.Hid.IHidDebugServer.ConnectUsbPadsAsync [222]".Debug();
		public virtual void DisconnectUsbPadsAsync() => "Stub hit for Nn.Hid.IHidDebugServer.DisconnectUsbPadsAsync [223]".Debug();
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateAppletResource
					var ret = CreateAppletResource(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // ActivateDebugPad
					ActivateDebugPad(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // ActivateTouchScreen
					ActivateTouchScreen(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // ActivateMouse
					ActivateMouse(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // ActivateKeyboard
					ActivateKeyboard(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // Unknown32
					Unknown32(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // AcquireXpadIdEventHandle
					var ret = AcquireXpadIdEventHandle(im.GetData<ulong>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 41: { // ReleaseXpadIdEventHandle
					ReleaseXpadIdEventHandle(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 51: { // ActivateXpad
					ActivateXpad(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 55: { // GetXpadIds
					GetXpadIds(out var _0, im.GetBuffer<uint>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 56: { // ActivateJoyXpad
					ActivateJoyXpad(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 58: { // GetJoyXpadLifoHandle
					var ret = GetJoyXpadLifoHandle(im.GetData<uint>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 59: { // GetJoyXpadIds
					GetJoyXpadIds(out var _0, im.GetBuffer<uint>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 60: { // ActivateSixAxisSensor
					ActivateSixAxisSensor(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 61: { // DeactivateSixAxisSensor
					DeactivateSixAxisSensor(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 62: { // GetSixAxisSensorLifoHandle
					var ret = GetSixAxisSensorLifoHandle(im.GetData<uint>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 63: { // ActivateJoySixAxisSensor
					ActivateJoySixAxisSensor(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 64: { // DeactivateJoySixAxisSensor
					DeactivateJoySixAxisSensor(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 65: { // GetJoySixAxisSensorLifoHandle
					var ret = GetJoySixAxisSensorLifoHandle(im.GetData<uint>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 66: { // StartSixAxisSensor
					StartSixAxisSensor(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 67: { // StopSixAxisSensor
					StopSixAxisSensor(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 68: { // IsSixAxisSensorFusionEnabled
					var ret = IsSixAxisSensorFusionEnabled(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 69: { // EnableSixAxisSensorFusion
					EnableSixAxisSensorFusion(im.GetData<bool>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 70: { // SetSixAxisSensorFusionParameters
					SetSixAxisSensorFusionParameters(im.GetData<uint>(8), im.GetData<float>(12), im.GetData<float>(16), im.GetData<ulong>(24), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 71: { // GetSixAxisSensorFusionParameters
					GetSixAxisSensorFusionParameters(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid, out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 72: { // ResetSixAxisSensorFusionParameters
					ResetSixAxisSensorFusionParameters(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 73: { // SetAccelerometerParameters
					SetAccelerometerParameters(im.GetData<uint>(8), im.GetData<float>(12), im.GetData<float>(16), im.GetData<ulong>(24), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 74: { // GetAccelerometerParameters
					GetAccelerometerParameters(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid, out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 75: { // ResetAccelerometerParameters
					ResetAccelerometerParameters(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 76: { // SetAccelerometerPlayMode
					SetAccelerometerPlayMode(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 77: { // GetAccelerometerPlayMode
					var ret = GetAccelerometerPlayMode(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 78: { // ResetAccelerometerPlayMode
					ResetAccelerometerPlayMode(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 79: { // SetGyroscopeZeroDriftMode
					SetGyroscopeZeroDriftMode(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 80: { // GetGyroscopeZeroDriftMode
					var ret = GetGyroscopeZeroDriftMode(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 81: { // ResetGyroscopeZeroDriftMode
					ResetGyroscopeZeroDriftMode(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 82: { // IsSixAxisSensorAtRest
					var ret = IsSixAxisSensorAtRest(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 83: { // Unknown83
					var ret = Unknown83(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 91: { // ActivateGesture
					ActivateGesture(im.GetData<int>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // SetSupportedNpadStyleSet
					SetSupportedNpadStyleSet(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // GetSupportedNpadStyleSet
					var ret = GetSupportedNpadStyleSet(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 102: { // SetSupportedNpadIdType
					SetSupportedNpadIdType(im.GetData<ulong>(8), im.Pid, im.GetBuffer<uint>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // ActivateNpad
					ActivateNpad(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 104: { // DeactivateNpad
					DeactivateNpad(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 106: { // AcquireNpadStyleSetUpdateEventHandle
					var ret = AcquireNpadStyleSetUpdateEventHandle(im.GetData<uint>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.Pid);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 107: { // DisconnectNpad
					DisconnectNpad(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 108: { // ActivateNpadWithRevision
					ActivateNpadWithRevision(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 120: { // SetNpadJoyHoldType
					SetNpadJoyHoldType(im.GetData<ulong>(8), im.GetData<long>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 121: { // GetNpadJoyHoldType
					var ret = GetNpadJoyHoldType(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 122: { // SetNpadJoyAssignmentModeSingleByDefault
					SetNpadJoyAssignmentModeSingleByDefault(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 123: { // SetNpadJoyAssignmentModeSingle
					SetNpadJoyAssignmentModeSingle(im.GetData<uint>(8), im.GetData<ulong>(16), im.GetData<long>(24), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 124: { // SetNpadJoyAssignmentModeDual
					SetNpadJoyAssignmentModeDual(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 125: { // MergeSingleJoyAsDualJoy
					MergeSingleJoyAsDualJoy(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 126: { // StartLrAssignmentMode
					StartLrAssignmentMode(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 127: { // StopLrAssignmentMode
					StopLrAssignmentMode(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 128: { // SetNpadHandheldActivationMode
					SetNpadHandheldActivationMode(im.GetData<ulong>(8), im.GetData<long>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 129: { // GetNpadHandheldActivationMode
					var ret = GetNpadHandheldActivationMode(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 130: { // SwapNpadAssignment
					SwapNpadAssignment(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 131: { // IsUnintendedHomeButtonInputProtectionEnabled
					var ret = IsUnintendedHomeButtonInputProtectionEnabled(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 132: { // EnableUnintendedHomeButtonInputProtection
					EnableUnintendedHomeButtonInputProtection(im.GetData<bool>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 133: { // SetNpadJoyAssignmentModeSingleWithDestination
					SetNpadJoyAssignmentModeSingleWithDestination(im.GetData<uint>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.Pid, out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 200: { // GetVibrationDeviceInfo
					GetVibrationDeviceInfo(im.GetData<uint>(8), out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 201: { // SendVibrationValue
					SendVibrationValue(im.GetData<uint>(8), null, im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // GetActualVibrationValue
					var ret = GetActualVibrationValue(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 203: { // CreateActiveVibrationDeviceList
					var ret = CreateActiveVibrationDeviceList();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 204: { // PermitVibration
					PermitVibration(im.GetData<bool>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 205: { // IsVibrationPermitted
					var ret = IsVibrationPermitted();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 206: { // SendVibrationValues
					SendVibrationValues(im.GetData<ulong>(8), im.GetBuffer<uint>(0x9, 0), im.GetBuffer<byte>(0x9, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 207: { // SendVibrationGcErmCommand
					SendVibrationGcErmCommand(im.GetData<uint>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 208: { // GetActualVibrationGcErmCommand
					var ret = GetActualVibrationGcErmCommand(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 209: { // BeginPermitVibrationSession
					BeginPermitVibrationSession(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 210: { // EndPermitVibrationSession
					EndPermitVibrationSession();
					om.Initialize(0, 0, 0);
					break;
				}
				case 300: { // ActivateConsoleSixAxisSensor
					ActivateConsoleSixAxisSensor(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // StartConsoleSixAxisSensor
					StartConsoleSixAxisSensor(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // StopConsoleSixAxisSensor
					StopConsoleSixAxisSensor(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 303: { // ActivateSevenSixAxisSensor
					ActivateSevenSixAxisSensor(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 304: { // StartSevenSixAxisSensor
					StartSevenSixAxisSensor(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 305: { // StopSevenSixAxisSensor
					StopSevenSixAxisSensor(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 306: { // InitializeSevenSixAxisSensor
					InitializeSevenSixAxisSensor(im.GetData<uint>(8), im.GetData<ulong>(16), im.GetData<uint>(24), im.GetData<ulong>(32), im.GetData<ulong>(40), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 307: { // FinalizeSevenSixAxisSensor
					FinalizeSevenSixAxisSensor(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 308: { // SetSevenSixAxisSensorFusionStrength
					SetSevenSixAxisSensorFusionStrength(im.GetData<float>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 309: { // GetSevenSixAxisSensorFusionStrength
					var ret = GetSevenSixAxisSensorFusionStrength(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 310: { // Unknown310
					Unknown310(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 400: { // IsUsbFullKeyControllerEnabled
					var ret = IsUsbFullKeyControllerEnabled();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 401: { // EnableUsbFullKeyController
					EnableUsbFullKeyController(im.GetData<bool>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 402: { // IsUsbFullKeyControllerConnected
					var ret = IsUsbFullKeyControllerConnected(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 403: { // HasBattery
					var ret = HasBattery(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 404: { // HasLeftRightBattery
					HasLeftRightBattery(im.GetData<uint>(8), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 405: { // GetNpadInterfaceType
					var ret = GetNpadInterfaceType(im.GetData<uint>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 406: { // GetNpadLeftRightInterfaceType
					GetNpadLeftRightInterfaceType(im.GetData<uint>(8), out var _0, out var _1);
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					om.SetData(9, _1);
					break;
				}
				case 500: { // GetPalmaConnectionHandle
					var ret = GetPalmaConnectionHandle(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 501: { // InitializePalma
					InitializePalma(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 502: { // AcquirePalmaOperationCompleteEvent
					var ret = AcquirePalmaOperationCompleteEvent(im.GetData<ulong>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 503: { // GetPalmaOperationInfo
					GetPalmaOperationInfo(im.GetData<ulong>(8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 504: { // PlayPalmaActivity
					PlayPalmaActivity(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 505: { // SetPalmaFrModeType
					SetPalmaFrModeType(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 506: { // ReadPalmaStep
					ReadPalmaStep(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 507: { // EnablePalmaStep
					EnablePalmaStep(im.GetData<bool>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 508: { // ResetPalmaStep
					ResetPalmaStep(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 509: { // ReadPalmaApplicationSection
					ReadPalmaApplicationSection(im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 510: { // WritePalmaApplicationSection
					WritePalmaApplicationSection(im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x19, 0), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 511: { // ReadPalmaUniqueCode
					ReadPalmaUniqueCode(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 512: { // SetPalmaUniqueCodeInvalid
					SetPalmaUniqueCodeInvalid(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 513: { // WritePalmaActivityEntry
					WritePalmaActivityEntry(im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.GetData<ulong>(32), im.GetData<ulong>(40));
					om.Initialize(0, 0, 0);
					break;
				}
				case 514: { // WritePalmaRgbLedPatternEntry
					WritePalmaRgbLedPatternEntry(im.GetData<ulong>(8), im.GetBuffer<byte>(0x5, 0), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 515: { // WritePalmaWaveEntry
					WritePalmaWaveEntry(im.GetData<ulong>(8), im.GetData<ulong>(16), Kernel.Get<KObject>(im.GetCopy(0)), im.GetData<ulong>(24), im.GetData<ulong>(32), im.GetData<ulong>(40));
					om.Initialize(0, 0, 0);
					break;
				}
				case 516: { // SetPalmaDataBaseIdentificationVersion
					SetPalmaDataBaseIdentificationVersion(im.GetData<uint>(8), im.GetData<ulong>(16), im.GetData<int>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 517: { // GetPalmaDataBaseIdentificationVersion
					GetPalmaDataBaseIdentificationVersion(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 518: { // SuspendPalmaFeature
					SuspendPalmaFeature(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 519: { // GetPalmaOperationResult
					GetPalmaOperationResult(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 520: { // ReadPalmaPlayLog
					ReadPalmaPlayLog(im.GetData<ulong>(8), im.GetData<ushort>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 521: { // ResetPalmaPlayLog
					ResetPalmaPlayLog(im.GetData<ulong>(8), im.GetData<ushort>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 522: { // SetIsPalmaAllConnectable
					SetIsPalmaAllConnectable(im.GetData<ulong>(8), im.GetData<bool>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 523: { // SetIsPalmaPairedConnectable
					SetIsPalmaPairedConnectable(im.GetData<ulong>(8), im.GetData<bool>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 524: { // PairPalma
					PairPalma(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 525: { // SetPalmaBoostMode
					SetPalmaBoostMode(im.GetData<bool>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1000: { // SetNpadCommunicationMode
					SetNpadCommunicationMode(im.GetData<ulong>(8), im.GetData<long>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1001: { // GetNpadCommunicationMode
					var ret = GetNpadCommunicationMode();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidServer: {im.CommandId}");
			}
		}
		
		public virtual Nn.Hid.IAppletResource CreateAppletResource(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateDebugPad(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateDebugPad [1]".Debug();
		public virtual void ActivateTouchScreen(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateTouchScreen [11]".Debug();
		public virtual void ActivateMouse(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateMouse [21]".Debug();
		public virtual void ActivateKeyboard(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateKeyboard [31]".Debug();
		public virtual void Unknown32(ulong _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.Unknown32 [32]".Debug();
		public virtual KObject AcquireXpadIdEventHandle(ulong _0) => throw new NotImplementedException();
		public virtual void ReleaseXpadIdEventHandle(ulong _0) => "Stub hit for Nn.Hid.IHidServer.ReleaseXpadIdEventHandle [41]".Debug();
		public virtual void ActivateXpad(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ActivateXpad [51]".Debug();
		public virtual void GetXpadIds(out long _0, Buffer<uint> _1) => throw new NotImplementedException();
		public virtual void ActivateJoyXpad(uint _0) => "Stub hit for Nn.Hid.IHidServer.ActivateJoyXpad [56]".Debug();
		public virtual KObject GetJoyXpadLifoHandle(uint _0) => throw new NotImplementedException();
		public virtual void GetJoyXpadIds(out long _0, Buffer<uint> _1) => throw new NotImplementedException();
		public virtual void ActivateSixAxisSensor(uint _0) => "Stub hit for Nn.Hid.IHidServer.ActivateSixAxisSensor [60]".Debug();
		public virtual void DeactivateSixAxisSensor(uint _0) => "Stub hit for Nn.Hid.IHidServer.DeactivateSixAxisSensor [61]".Debug();
		public virtual KObject GetSixAxisSensorLifoHandle(uint _0) => throw new NotImplementedException();
		public virtual void ActivateJoySixAxisSensor(uint _0) => "Stub hit for Nn.Hid.IHidServer.ActivateJoySixAxisSensor [63]".Debug();
		public virtual void DeactivateJoySixAxisSensor(uint _0) => "Stub hit for Nn.Hid.IHidServer.DeactivateJoySixAxisSensor [64]".Debug();
		public virtual KObject GetJoySixAxisSensorLifoHandle(uint _0) => throw new NotImplementedException();
		public virtual void StartSixAxisSensor(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.StartSixAxisSensor [66]".Debug();
		public virtual void StopSixAxisSensor(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.StopSixAxisSensor [67]".Debug();
		public virtual bool IsSixAxisSensorFusionEnabled(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void EnableSixAxisSensorFusion(bool _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.EnableSixAxisSensorFusion [69]".Debug();
		public virtual void SetSixAxisSensorFusionParameters(uint _0, float _1, float _2, ulong _3, ulong _4) => "Stub hit for Nn.Hid.IHidServer.SetSixAxisSensorFusionParameters [70]".Debug();
		public virtual void GetSixAxisSensorFusionParameters(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void ResetSixAxisSensorFusionParameters(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ResetSixAxisSensorFusionParameters [72]".Debug();
		public virtual void SetAccelerometerParameters(uint _0, float _1, float _2, ulong _3, ulong _4) => "Stub hit for Nn.Hid.IHidServer.SetAccelerometerParameters [73]".Debug();
		public virtual void GetAccelerometerParameters(uint _0, ulong _1, ulong _2, out float _3, out float _4) => throw new NotImplementedException();
		public virtual void ResetAccelerometerParameters(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ResetAccelerometerParameters [75]".Debug();
		public virtual void SetAccelerometerPlayMode(uint _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.SetAccelerometerPlayMode [76]".Debug();
		public virtual uint GetAccelerometerPlayMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ResetAccelerometerPlayMode(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ResetAccelerometerPlayMode [78]".Debug();
		public virtual void SetGyroscopeZeroDriftMode(uint _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.SetGyroscopeZeroDriftMode [79]".Debug();
		public virtual uint GetGyroscopeZeroDriftMode(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ResetGyroscopeZeroDriftMode(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ResetGyroscopeZeroDriftMode [81]".Debug();
		public virtual bool IsSixAxisSensorAtRest(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual bool Unknown83(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ActivateGesture(int _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ActivateGesture [91]".Debug();
		public virtual void SetSupportedNpadStyleSet(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetSupportedNpadStyleSet [100]".Debug();
		public virtual uint GetSupportedNpadStyleSet(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetSupportedNpadIdType(ulong _0, ulong _1, Buffer<uint> _2) => "Stub hit for Nn.Hid.IHidServer.SetSupportedNpadIdType [102]".Debug();
		public virtual void ActivateNpad(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateNpad [103]".Debug();
		public virtual void DeactivateNpad(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.DeactivateNpad [104]".Debug();
		public virtual KObject AcquireNpadStyleSetUpdateEventHandle(uint _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void DisconnectNpad(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.DisconnectNpad [107]".Debug();
		public virtual void ActivateNpadWithRevision(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ActivateNpadWithRevision [108]".Debug();
		public virtual void SetNpadJoyHoldType(ulong _0, long _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetNpadJoyHoldType [120]".Debug();
		public virtual long GetNpadJoyHoldType(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetNpadJoyAssignmentModeSingleByDefault(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetNpadJoyAssignmentModeSingleByDefault [122]".Debug();
		public virtual void SetNpadJoyAssignmentModeSingle(uint _0, ulong _1, long _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.SetNpadJoyAssignmentModeSingle [123]".Debug();
		public virtual void SetNpadJoyAssignmentModeDual(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetNpadJoyAssignmentModeDual [124]".Debug();
		public virtual void MergeSingleJoyAsDualJoy(uint _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.MergeSingleJoyAsDualJoy [125]".Debug();
		public virtual void StartLrAssignmentMode(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.StartLrAssignmentMode [126]".Debug();
		public virtual void StopLrAssignmentMode(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.StopLrAssignmentMode [127]".Debug();
		public virtual void SetNpadHandheldActivationMode(ulong _0, long _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetNpadHandheldActivationMode [128]".Debug();
		public virtual long GetNpadHandheldActivationMode(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SwapNpadAssignment(uint _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.SwapNpadAssignment [130]".Debug();
		public virtual bool IsUnintendedHomeButtonInputProtectionEnabled(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void EnableUnintendedHomeButtonInputProtection(bool _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.EnableUnintendedHomeButtonInputProtection [132]".Debug();
		public virtual void SetNpadJoyAssignmentModeSingleWithDestination(uint _0, ulong _1, ulong _2, ulong _3, out bool _4, out uint _5) => throw new NotImplementedException();
		public virtual void GetVibrationDeviceInfo(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void SendVibrationValue(uint _0, object _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.SendVibrationValue [201]".Debug();
		public virtual object GetActualVibrationValue(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual Nn.Hid.IActiveVibrationDeviceList CreateActiveVibrationDeviceList() => throw new NotImplementedException();
		public virtual void PermitVibration(bool _0) => "Stub hit for Nn.Hid.IHidServer.PermitVibration [204]".Debug();
		public virtual bool IsVibrationPermitted() => throw new NotImplementedException();
		public virtual void SendVibrationValues(ulong _0, Buffer<uint> _1, Buffer<byte> _2) => "Stub hit for Nn.Hid.IHidServer.SendVibrationValues [206]".Debug();
		public virtual void SendVibrationGcErmCommand(uint _0, ulong _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.SendVibrationGcErmCommand [207]".Debug();
		public virtual ulong GetActualVibrationGcErmCommand(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void BeginPermitVibrationSession(ulong _0) => "Stub hit for Nn.Hid.IHidServer.BeginPermitVibrationSession [209]".Debug();
		public virtual void EndPermitVibrationSession() => "Stub hit for Nn.Hid.IHidServer.EndPermitVibrationSession [210]".Debug();
		public virtual void ActivateConsoleSixAxisSensor(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateConsoleSixAxisSensor [300]".Debug();
		public virtual void StartConsoleSixAxisSensor(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.StartConsoleSixAxisSensor [301]".Debug();
		public virtual void StopConsoleSixAxisSensor(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.StopConsoleSixAxisSensor [302]".Debug();
		public virtual void ActivateSevenSixAxisSensor(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.ActivateSevenSixAxisSensor [303]".Debug();
		public virtual void StartSevenSixAxisSensor(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.StartSevenSixAxisSensor [304]".Debug();
		public virtual void StopSevenSixAxisSensor(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.StopSevenSixAxisSensor [305]".Debug();
		public virtual void InitializeSevenSixAxisSensor(uint _0, ulong _1, uint _2, ulong _3, ulong _4, ulong _5) => "Stub hit for Nn.Hid.IHidServer.InitializeSevenSixAxisSensor [306]".Debug();
		public virtual void FinalizeSevenSixAxisSensor(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.FinalizeSevenSixAxisSensor [307]".Debug();
		public virtual void SetSevenSixAxisSensorFusionStrength(float _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetSevenSixAxisSensorFusionStrength [308]".Debug();
		public virtual float GetSevenSixAxisSensorFusionStrength(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void Unknown310(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.Unknown310 [310]".Debug();
		public virtual bool IsUsbFullKeyControllerEnabled() => throw new NotImplementedException();
		public virtual void EnableUsbFullKeyController(bool _0) => "Stub hit for Nn.Hid.IHidServer.EnableUsbFullKeyController [401]".Debug();
		public virtual bool IsUsbFullKeyControllerConnected(uint _0) => throw new NotImplementedException();
		public virtual bool HasBattery(uint _0) => throw new NotImplementedException();
		public virtual void HasLeftRightBattery(uint _0, out bool _1, out bool _2) => throw new NotImplementedException();
		public virtual byte GetNpadInterfaceType(uint _0) => throw new NotImplementedException();
		public virtual void GetNpadLeftRightInterfaceType(uint _0, out byte _1, out byte _2) => throw new NotImplementedException();
		public virtual ulong GetPalmaConnectionHandle(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void InitializePalma(ulong _0) => "Stub hit for Nn.Hid.IHidServer.InitializePalma [501]".Debug();
		public virtual KObject AcquirePalmaOperationCompleteEvent(ulong _0) => throw new NotImplementedException();
		public virtual void GetPalmaOperationInfo(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void PlayPalmaActivity(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.PlayPalmaActivity [504]".Debug();
		public virtual void SetPalmaFrModeType(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.SetPalmaFrModeType [505]".Debug();
		public virtual void ReadPalmaStep(ulong _0) => "Stub hit for Nn.Hid.IHidServer.ReadPalmaStep [506]".Debug();
		public virtual void EnablePalmaStep(bool _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.EnablePalmaStep [507]".Debug();
		public virtual void ResetPalmaStep(ulong _0) => "Stub hit for Nn.Hid.IHidServer.ResetPalmaStep [508]".Debug();
		public virtual void ReadPalmaApplicationSection(ulong _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.ReadPalmaApplicationSection [509]".Debug();
		public virtual void WritePalmaApplicationSection(ulong _0, ulong _1, Buffer<byte> _2, ulong _3) => "Stub hit for Nn.Hid.IHidServer.WritePalmaApplicationSection [510]".Debug();
		public virtual void ReadPalmaUniqueCode(ulong _0) => "Stub hit for Nn.Hid.IHidServer.ReadPalmaUniqueCode [511]".Debug();
		public virtual void SetPalmaUniqueCodeInvalid(ulong _0) => "Stub hit for Nn.Hid.IHidServer.SetPalmaUniqueCodeInvalid [512]".Debug();
		public virtual void WritePalmaActivityEntry(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4) => "Stub hit for Nn.Hid.IHidServer.WritePalmaActivityEntry [513]".Debug();
		public virtual void WritePalmaRgbLedPatternEntry(ulong _0, Buffer<byte> _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.WritePalmaRgbLedPatternEntry [514]".Debug();
		public virtual void WritePalmaWaveEntry(ulong _0, ulong _1, KObject _2, ulong _3, ulong _4, ulong _5) => "Stub hit for Nn.Hid.IHidServer.WritePalmaWaveEntry [515]".Debug();
		public virtual void SetPalmaDataBaseIdentificationVersion(uint _0, ulong _1, int _2) => "Stub hit for Nn.Hid.IHidServer.SetPalmaDataBaseIdentificationVersion [516]".Debug();
		public virtual void GetPalmaDataBaseIdentificationVersion(ulong _0) => "Stub hit for Nn.Hid.IHidServer.GetPalmaDataBaseIdentificationVersion [517]".Debug();
		public virtual void SuspendPalmaFeature(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidServer.SuspendPalmaFeature [518]".Debug();
		public virtual void GetPalmaOperationResult(ulong _0) => "Stub hit for Nn.Hid.IHidServer.GetPalmaOperationResult [519]".Debug();
		public virtual void ReadPalmaPlayLog(ulong _0, ushort _1) => "Stub hit for Nn.Hid.IHidServer.ReadPalmaPlayLog [520]".Debug();
		public virtual void ResetPalmaPlayLog(ulong _0, ushort _1) => "Stub hit for Nn.Hid.IHidServer.ResetPalmaPlayLog [521]".Debug();
		public virtual void SetIsPalmaAllConnectable(ulong _0, bool _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetIsPalmaAllConnectable [522]".Debug();
		public virtual void SetIsPalmaPairedConnectable(ulong _0, bool _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetIsPalmaPairedConnectable [523]".Debug();
		public virtual void PairPalma(ulong _0) => "Stub hit for Nn.Hid.IHidServer.PairPalma [524]".Debug();
		public virtual void SetPalmaBoostMode(bool _0) => "Stub hit for Nn.Hid.IHidServer.SetPalmaBoostMode [525]".Debug();
		public virtual void SetNpadCommunicationMode(ulong _0, long _1, ulong _2) => "Stub hit for Nn.Hid.IHidServer.SetNpadCommunicationMode [1000]".Debug();
		public virtual long GetNpadCommunicationMode() => throw new NotImplementedException();
	}
	
	[IpcService("hid:sys")]
	public unsafe partial class IHidSystemServer : _Base_IHidSystemServer {}
	public unsafe class _Base_IHidSystemServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 31: { // SendKeyboardLockKeyEvent
					SendKeyboardLockKeyEvent(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // AcquireHomeButtonEventHandle
					var ret = AcquireHomeButtonEventHandle(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 111: { // ActivateHomeButton
					ActivateHomeButton(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 121: { // AcquireSleepButtonEventHandle
					var ret = AcquireSleepButtonEventHandle(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 131: { // ActivateSleepButton
					ActivateSleepButton(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 141: { // AcquireCaptureButtonEventHandle
					var ret = AcquireCaptureButtonEventHandle(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 151: { // ActivateCaptureButton
					ActivateCaptureButton(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 210: { // AcquireNfcDeviceUpdateEventHandle
					var ret = AcquireNfcDeviceUpdateEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 211: { // GetNpadsWithNfc
					GetNpadsWithNfc(out var _0, im.GetBuffer<uint>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 212: { // AcquireNfcActivateEventHandle
					var ret = AcquireNfcActivateEventHandle(im.GetData<uint>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 213: { // ActivateNfc
					ActivateNfc(im.GetData<byte>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 214: { // GetXcdHandleForNpadWithNfc
					var ret = GetXcdHandleForNpadWithNfc(im.GetData<uint>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 215: { // IsNfcActivated
					var ret = IsNfcActivated(im.GetData<uint>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 230: { // AcquireIrSensorEventHandle
					var ret = AcquireIrSensorEventHandle(im.GetData<uint>(8));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 231: { // ActivateIrSensor
					ActivateIrSensor(im.GetData<byte>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // ActivateNpadSystem
					ActivateNpadSystem(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 303: { // ApplyNpadSystemCommonPolicy
					ApplyNpadSystemCommonPolicy(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 304: { // EnableAssigningSingleOnSlSrPress
					EnableAssigningSingleOnSlSrPress(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 305: { // DisableAssigningSingleOnSlSrPress
					DisableAssigningSingleOnSlSrPress(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 306: { // GetLastActiveNpad
					var ret = GetLastActiveNpad();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 307: { // GetNpadSystemExtStyle
					GetNpadSystemExtStyle(im.GetData<uint>(8), out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 308: { // ApplyNpadSystemCommonPolicyFull
					var ret = ApplyNpadSystemCommonPolicyFull(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 309: { // GetNpadFullKeyGripColor
					var ret = GetNpadFullKeyGripColor(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 311: { // SetNpadPlayerLedBlinkingDevice
					SetNpadPlayerLedBlinkingDevice(im.GetData<uint>(8), null, im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 321: { // GetUniquePadsFromNpad
					GetUniquePadsFromNpad(im.GetData<uint>(8), out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 322: { // GetIrSensorState
					var ret = GetIrSensorState(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 323: { // GetXcdHandleForNpadWithIrSensor
					var ret = GetXcdHandleForNpadWithIrSensor(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 500: { // SetAppletResourceUserId
					SetAppletResourceUserId(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 501: { // RegisterAppletResourceUserId
					RegisterAppletResourceUserId(im.GetData<byte>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 502: { // UnregisterAppletResourceUserId
					UnregisterAppletResourceUserId(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 503: { // EnableAppletToGetInput
					EnableAppletToGetInput(im.GetData<byte>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 504: { // SetAruidValidForVibration
					SetAruidValidForVibration(im.GetData<byte>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 505: { // EnableAppletToGetSixAxisSensor
					EnableAppletToGetSixAxisSensor(im.GetData<byte>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 510: { // SetVibrationMasterVolume
					SetVibrationMasterVolume(im.GetData<float>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 511: { // GetVibrationMasterVolume
					var ret = GetVibrationMasterVolume();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 512: { // BeginPermitVibrationSession
					BeginPermitVibrationSession(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 513: { // EndPermitVibrationSession
					EndPermitVibrationSession();
					om.Initialize(0, 0, 0);
					break;
				}
				case 520: { // EnableHandheldHids
					EnableHandheldHids();
					om.Initialize(0, 0, 0);
					break;
				}
				case 521: { // DisableHandheldHids
					DisableHandheldHids();
					om.Initialize(0, 0, 0);
					break;
				}
				case 540: { // AcquirePlayReportControllerUsageUpdateEvent
					var ret = AcquirePlayReportControllerUsageUpdateEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 541: { // GetPlayReportControllerUsages
					GetPlayReportControllerUsages(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 542: { // AcquirePlayReportRegisteredDeviceUpdateEvent
					var ret = AcquirePlayReportRegisteredDeviceUpdateEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 543: { // GetRegisteredDevicesOld
					GetRegisteredDevicesOld(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 544: { // AcquireConnectionTriggerTimeoutEvent
					var ret = AcquireConnectionTriggerTimeoutEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 545: { // SendConnectionTrigger
					SendConnectionTrigger(im.GetBytes(8, 0x6));
					om.Initialize(0, 0, 0);
					break;
				}
				case 546: { // AcquireDeviceRegisteredEventForControllerSupport
					var ret = AcquireDeviceRegisteredEventForControllerSupport();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 547: { // GetAllowedBluetoothLinksCount
					var ret = GetAllowedBluetoothLinksCount();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 548: { // GetRegisteredDevices
					var ret = GetRegisteredDevices(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 700: { // ActivateUniquePad
					ActivateUniquePad(im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 702: { // AcquireUniquePadConnectionEventHandle
					var ret = AcquireUniquePadConnectionEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 703: { // GetUniquePadIds
					GetUniquePadIds(out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 751: { // AcquireJoyDetachOnBluetoothOffEventHandle
					var ret = AcquireJoyDetachOnBluetoothOffEventHandle(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 800: { // ListSixAxisSensorHandles
					ListSixAxisSensorHandles(im.GetData<ulong>(8), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 801: { // IsSixAxisSensorUserCalibrationSupported
					var ret = IsSixAxisSensorUserCalibrationSupported(null);
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 802: { // ResetSixAxisSensorCalibrationValues
					ResetSixAxisSensorCalibrationValues(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 803: { // StartSixAxisSensorUserCalibration
					StartSixAxisSensorUserCalibration(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 804: { // CancelSixAxisSensorUserCalibration
					CancelSixAxisSensorUserCalibration(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 805: { // GetUniquePadBluetoothAddress
					GetUniquePadBluetoothAddress(im.GetData<ulong>(8), out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 806: { // DisconnectUniquePad
					DisconnectUniquePad(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 807: { // GetUniquePadType
					var ret = GetUniquePadType(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 808: { // GetUniquePadInterface
					var ret = GetUniquePadInterface(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 809: { // GetUniquePadSerialNumber
					var ret = GetUniquePadSerialNumber(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 810: { // GetUniquePadControllerNumber
					var ret = GetUniquePadControllerNumber(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 811: { // GetSixAxisSensorUserCalibrationStage
					var ret = GetSixAxisSensorUserCalibrationStage(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 821: { // StartAnalogStickManualCalibration
					StartAnalogStickManualCalibration(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 822: { // RetryCurrentAnalogStickManualCalibrationStage
					RetryCurrentAnalogStickManualCalibrationStage(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 823: { // CancelAnalogStickManualCalibration
					CancelAnalogStickManualCalibration(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 824: { // ResetAnalogStickManualCalibration
					ResetAnalogStickManualCalibration(im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 825: { // GetAnalogStickState
					var ret = GetAnalogStickState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 826: { // GetAnalogStickManualCalibrationStage
					var ret = GetAnalogStickManualCalibrationStage(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 827: { // IsAnalogStickButtonPressed
					var ret = IsAnalogStickButtonPressed(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 828: { // IsAnalogStickInReleasePosition
					var ret = IsAnalogStickInReleasePosition(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 829: { // IsAnalogStickInCircumference
					var ret = IsAnalogStickInCircumference(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 850: { // IsUsbFullKeyControllerEnabled
					var ret = IsUsbFullKeyControllerEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 851: { // EnableUsbFullKeyController
					EnableUsbFullKeyController(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 852: { // IsUsbConnected
					var ret = IsUsbConnected(im.GetData<ulong>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 900: { // ActivateInputDetector
					ActivateInputDetector(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 901: { // NotifyInputDetector
					NotifyInputDetector(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1000: { // InitializeFirmwareUpdate
					InitializeFirmwareUpdate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1001: { // GetFirmwareVersion
					GetFirmwareVersion(im.GetData<ulong>(8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 1002: { // GetAvailableFirmwareVersion
					GetAvailableFirmwareVersion(im.GetData<ulong>(8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 1003: { // IsFirmwareUpdateAvailable
					var ret = IsFirmwareUpdateAvailable(im.GetData<ulong>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1004: { // CheckFirmwareUpdateRequired
					var ret = CheckFirmwareUpdateRequired(im.GetData<ulong>(8));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 1005: { // StartFirmwareUpdate
					var ret = StartFirmwareUpdate(im.GetData<ulong>(8));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 1006: { // AbortFirmwareUpdate
					AbortFirmwareUpdate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1007: { // GetFirmwareUpdateState
					GetFirmwareUpdateState(im.GetData<ulong>(8), out var _0);
					om.Initialize(0, 0, 4);
					om.SetBytes(8, _0);
					break;
				}
				case 1008: { // ActivateAudioControl
					ActivateAudioControl();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1009: { // AcquireAudioControlEventHandle
					var ret = AcquireAudioControlEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1010: { // GetAudioControlStates
					GetAudioControlStates(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 1011: { // DeactivateAudioControl
					DeactivateAudioControl();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1050: { // IsSixAxisSensorAccurateUserCalibrationSupported
					var ret = IsSixAxisSensorAccurateUserCalibrationSupported(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1051: { // StartSixAxisSensorAccurateUserCalibration
					var ret = StartSixAxisSensorAccurateUserCalibration(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1052: { // CancelSixAxisSensorAccurateUserCalibration
					var ret = CancelSixAxisSensorAccurateUserCalibration(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1053: { // GetSixAxisSensorAccurateUserCalibrationState
					var ret = GetSixAxisSensorAccurateUserCalibrationState(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1100: { // GetHidbusSystemServiceObject
					var ret = GetHidbusSystemServiceObject(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHidSystemServer: {im.CommandId}");
			}
		}
		
		public virtual void SendKeyboardLockKeyEvent(object _0) => "Stub hit for Nn.Hid.IHidSystemServer.SendKeyboardLockKeyEvent [31]".Debug();
		public virtual KObject AcquireHomeButtonEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateHomeButton(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateHomeButton [111]".Debug();
		public virtual KObject AcquireSleepButtonEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateSleepButton(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateSleepButton [131]".Debug();
		public virtual KObject AcquireCaptureButtonEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ActivateCaptureButton(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateCaptureButton [151]".Debug();
		public virtual KObject AcquireNfcDeviceUpdateEventHandle() => throw new NotImplementedException();
		public virtual void GetNpadsWithNfc(out ulong _0, Buffer<uint> _1) => throw new NotImplementedException();
		public virtual KObject AcquireNfcActivateEventHandle(uint _0) => throw new NotImplementedException();
		public virtual void ActivateNfc(byte _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateNfc [213]".Debug();
		public virtual ulong GetXcdHandleForNpadWithNfc(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual byte IsNfcActivated(uint _0) => throw new NotImplementedException();
		public virtual KObject AcquireIrSensorEventHandle(uint _0) => throw new NotImplementedException();
		public virtual void ActivateIrSensor(byte _0, uint _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateIrSensor [231]".Debug();
		public virtual void ActivateNpadSystem(uint _0) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateNpadSystem [301]".Debug();
		public virtual void ApplyNpadSystemCommonPolicy(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.ApplyNpadSystemCommonPolicy [303]".Debug();
		public virtual void EnableAssigningSingleOnSlSrPress(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.EnableAssigningSingleOnSlSrPress [304]".Debug();
		public virtual void DisableAssigningSingleOnSlSrPress(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.DisableAssigningSingleOnSlSrPress [305]".Debug();
		public virtual uint GetLastActiveNpad() => throw new NotImplementedException();
		public virtual void GetNpadSystemExtStyle(uint _0, out ulong _1, out ulong _2) => throw new NotImplementedException();
		public virtual object ApplyNpadSystemCommonPolicyFull(object _0) => throw new NotImplementedException();
		public virtual object GetNpadFullKeyGripColor(object _0) => throw new NotImplementedException();
		public virtual void SetNpadPlayerLedBlinkingDevice(uint _0, object _1, ulong _2, ulong _3) => "Stub hit for Nn.Hid.IHidSystemServer.SetNpadPlayerLedBlinkingDevice [311]".Debug();
		public virtual void GetUniquePadsFromNpad(uint _0, out ulong _1, Buffer<ulong> _2) => throw new NotImplementedException();
		public virtual ulong GetIrSensorState(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual ulong GetXcdHandleForNpadWithIrSensor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetAppletResourceUserId(ulong _0) => "Stub hit for Nn.Hid.IHidSystemServer.SetAppletResourceUserId [500]".Debug();
		public virtual void RegisterAppletResourceUserId(byte _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.RegisterAppletResourceUserId [501]".Debug();
		public virtual void UnregisterAppletResourceUserId(ulong _0) => "Stub hit for Nn.Hid.IHidSystemServer.UnregisterAppletResourceUserId [502]".Debug();
		public virtual void EnableAppletToGetInput(byte _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.EnableAppletToGetInput [503]".Debug();
		public virtual void SetAruidValidForVibration(byte _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.SetAruidValidForVibration [504]".Debug();
		public virtual void EnableAppletToGetSixAxisSensor(byte _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.EnableAppletToGetSixAxisSensor [505]".Debug();
		public virtual void SetVibrationMasterVolume(float _0) => "Stub hit for Nn.Hid.IHidSystemServer.SetVibrationMasterVolume [510]".Debug();
		public virtual float GetVibrationMasterVolume() => throw new NotImplementedException();
		public virtual void BeginPermitVibrationSession(ulong _0) => "Stub hit for Nn.Hid.IHidSystemServer.BeginPermitVibrationSession [512]".Debug();
		public virtual void EndPermitVibrationSession() => "Stub hit for Nn.Hid.IHidSystemServer.EndPermitVibrationSession [513]".Debug();
		public virtual void EnableHandheldHids() => "Stub hit for Nn.Hid.IHidSystemServer.EnableHandheldHids [520]".Debug();
		public virtual void DisableHandheldHids() => "Stub hit for Nn.Hid.IHidSystemServer.DisableHandheldHids [521]".Debug();
		public virtual KObject AcquirePlayReportControllerUsageUpdateEvent() => throw new NotImplementedException();
		public virtual void GetPlayReportControllerUsages(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AcquirePlayReportRegisteredDeviceUpdateEvent() => throw new NotImplementedException();
		public virtual void GetRegisteredDevicesOld(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject AcquireConnectionTriggerTimeoutEvent() => throw new NotImplementedException();
		public virtual void SendConnectionTrigger(byte[] _0) => "Stub hit for Nn.Hid.IHidSystemServer.SendConnectionTrigger [545]".Debug();
		public virtual KObject AcquireDeviceRegisteredEventForControllerSupport() => throw new NotImplementedException();
		public virtual ulong GetAllowedBluetoothLinksCount() => throw new NotImplementedException();
		public virtual object GetRegisteredDevices(object _0) => throw new NotImplementedException();
		public virtual void ActivateUniquePad(ulong _0, ulong _1, ulong _2) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateUniquePad [700]".Debug();
		public virtual KObject AcquireUniquePadConnectionEventHandle() => throw new NotImplementedException();
		public virtual void GetUniquePadIds(out ulong _0, Buffer<ulong> _1) => throw new NotImplementedException();
		public virtual KObject AcquireJoyDetachOnBluetoothOffEventHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ListSixAxisSensorHandles(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual byte IsSixAxisSensorUserCalibrationSupported(object _0) => throw new NotImplementedException();
		public virtual void ResetSixAxisSensorCalibrationValues(object _0) => "Stub hit for Nn.Hid.IHidSystemServer.ResetSixAxisSensorCalibrationValues [802]".Debug();
		public virtual void StartSixAxisSensorUserCalibration(object _0) => "Stub hit for Nn.Hid.IHidSystemServer.StartSixAxisSensorUserCalibration [803]".Debug();
		public virtual void CancelSixAxisSensorUserCalibration(object _0) => "Stub hit for Nn.Hid.IHidSystemServer.CancelSixAxisSensorUserCalibration [804]".Debug();
		public virtual void GetUniquePadBluetoothAddress(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void DisconnectUniquePad(ulong _0) => "Stub hit for Nn.Hid.IHidSystemServer.DisconnectUniquePad [806]".Debug();
		public virtual object GetUniquePadType(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadInterface(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadSerialNumber(object _0) => throw new NotImplementedException();
		public virtual object GetUniquePadControllerNumber(object _0) => throw new NotImplementedException();
		public virtual object GetSixAxisSensorUserCalibrationStage(object _0) => throw new NotImplementedException();
		public virtual void StartAnalogStickManualCalibration(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.StartAnalogStickManualCalibration [821]".Debug();
		public virtual void RetryCurrentAnalogStickManualCalibrationStage(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.RetryCurrentAnalogStickManualCalibrationStage [822]".Debug();
		public virtual void CancelAnalogStickManualCalibration(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.CancelAnalogStickManualCalibration [823]".Debug();
		public virtual void ResetAnalogStickManualCalibration(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.ResetAnalogStickManualCalibration [824]".Debug();
		public virtual object GetAnalogStickState(object _0) => throw new NotImplementedException();
		public virtual object GetAnalogStickManualCalibrationStage(object _0) => throw new NotImplementedException();
		public virtual object IsAnalogStickButtonPressed(object _0) => throw new NotImplementedException();
		public virtual object IsAnalogStickInReleasePosition(object _0) => throw new NotImplementedException();
		public virtual object IsAnalogStickInCircumference(object _0) => throw new NotImplementedException();
		public virtual byte IsUsbFullKeyControllerEnabled() => throw new NotImplementedException();
		public virtual void EnableUsbFullKeyController(byte _0) => "Stub hit for Nn.Hid.IHidSystemServer.EnableUsbFullKeyController [851]".Debug();
		public virtual byte IsUsbConnected(ulong _0) => throw new NotImplementedException();
		public virtual void ActivateInputDetector(ulong _0, ulong _1) => "Stub hit for Nn.Hid.IHidSystemServer.ActivateInputDetector [900]".Debug();
		public virtual void NotifyInputDetector(object _0) => "Stub hit for Nn.Hid.IHidSystemServer.NotifyInputDetector [901]".Debug();
		public virtual void InitializeFirmwareUpdate() => "Stub hit for Nn.Hid.IHidSystemServer.InitializeFirmwareUpdate [1000]".Debug();
		public virtual void GetFirmwareVersion(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void GetAvailableFirmwareVersion(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsFirmwareUpdateAvailable(ulong _0) => throw new NotImplementedException();
		public virtual ulong CheckFirmwareUpdateRequired(ulong _0) => throw new NotImplementedException();
		public virtual ulong StartFirmwareUpdate(ulong _0) => throw new NotImplementedException();
		public virtual void AbortFirmwareUpdate() => "Stub hit for Nn.Hid.IHidSystemServer.AbortFirmwareUpdate [1006]".Debug();
		public virtual void GetFirmwareUpdateState(ulong _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void ActivateAudioControl() => "Stub hit for Nn.Hid.IHidSystemServer.ActivateAudioControl [1008]".Debug();
		public virtual KObject AcquireAudioControlEventHandle() => throw new NotImplementedException();
		public virtual void GetAudioControlStates(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeactivateAudioControl() => "Stub hit for Nn.Hid.IHidSystemServer.DeactivateAudioControl [1011]".Debug();
		public virtual object IsSixAxisSensorAccurateUserCalibrationSupported(object _0) => throw new NotImplementedException();
		public virtual object StartSixAxisSensorAccurateUserCalibration(object _0) => throw new NotImplementedException();
		public virtual object CancelSixAxisSensorAccurateUserCalibration(object _0) => throw new NotImplementedException();
		public virtual object GetSixAxisSensorAccurateUserCalibrationState(object _0) => throw new NotImplementedException();
		public virtual object GetHidbusSystemServiceObject(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("hid:tmp")]
	public unsafe partial class IHidTemporaryServer : _Base_IHidTemporaryServer {}
	public unsafe class _Base_IHidTemporaryServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetConsoleSixAxisSensorCalibrationValues
					GetConsoleSixAxisSensorCalibrationValues(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid, out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ActivateVibrationDevice
					ActivateVibrationDevice(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IActiveVibrationDeviceList: {im.CommandId}");
			}
		}
		
		public virtual void ActivateVibrationDevice(uint _0) => "Stub hit for Nn.Hid.IActiveVibrationDeviceList.ActivateVibrationDevice [0]".Debug();
	}
	
	public unsafe partial class IAppletResource : _Base_IAppletResource {}
	public unsafe class _Base_IAppletResource : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSharedMemoryHandle
					var ret = GetSharedMemoryHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAppletResource: {im.CommandId}");
			}
		}
		
		public virtual KObject GetSharedMemoryHandle() => throw new NotImplementedException();
	}
}
