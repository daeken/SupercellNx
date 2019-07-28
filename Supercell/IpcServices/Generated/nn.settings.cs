#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Settings {
	[IpcService("set:cal")]
	public unsafe partial class IFactorySettingsServer : _Base_IFactorySettingsServer {}
	public unsafe class _Base_IFactorySettingsServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetBluetoothBdAddress
					GetBluetoothBdAddress(out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 1: { // GetConfigurationId1
					GetConfigurationId1(out var _0);
					om.Initialize(0, 0, 30);
					om.SetBytes(8, _0);
					break;
				}
				case 2: { // GetAccelerometerOffset
					GetAccelerometerOffset(out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 3: { // GetAccelerometerScale
					GetAccelerometerScale(out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 4: { // GetGyroscopeOffset
					GetGyroscopeOffset(out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetGyroscopeScale
					GetGyroscopeScale(out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 6: { // GetWirelessLanMacAddress
					GetWirelessLanMacAddress(out var _0);
					om.Initialize(0, 0, 6);
					om.SetBytes(8, _0);
					break;
				}
				case 7: { // GetWirelessLanCountryCodeCount
					var ret = GetWirelessLanCountryCodeCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 8: { // GetWirelessLanCountryCodes
					GetWirelessLanCountryCodes(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 9: { // GetSerialNumber
					GetSerialNumber(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 10: { // SetInitialSystemAppletProgramId
					SetInitialSystemAppletProgramId(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // SetOverlayDispProgramId
					SetOverlayDispProgramId(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // GetBatteryLot
					GetBatteryLot(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 14: { // GetEciDeviceCertificate
					GetEciDeviceCertificate(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetEticketDeviceCertificate
					GetEticketDeviceCertificate(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetSslKey
					GetSslKey(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // GetSslCertificate
					GetSslCertificate(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // GetGameCardKey
					GetGameCardKey(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // GetGameCardCertificate
					GetGameCardCertificate(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // GetEciDeviceKey
					GetEciDeviceKey(out var _0);
					om.Initialize(0, 0, 84);
					om.SetBytes(8, _0);
					break;
				}
				case 21: { // GetEticketDeviceKey
					GetEticketDeviceKey(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // GetSpeakerParameter
					GetSpeakerParameter(out var _0);
					om.Initialize(0, 0, 90);
					om.SetBytes(8, _0);
					break;
				}
				case 23: { // GetLcdVendorId
					var ret = GetLcdVendorId();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 24: { // GetEciDeviceCertificate2
					var ret = GetEciDeviceCertificate2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // GetEciDeviceKey2
					var ret = GetEciDeviceKey2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // GetAmiiboKey
					var ret = GetAmiiboKey(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // GetAmiiboEcqvCertificate
					var ret = GetAmiiboEcqvCertificate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 28: { // GetAmiiboEcdsaCertificate
					var ret = GetAmiiboEcdsaCertificate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 29: { // GetAmiiboEcqvBlsKey
					var ret = GetAmiiboEcqvBlsKey(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // GetAmiiboEcqvBlsCertificate
					var ret = GetAmiiboEcqvBlsCertificate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // GetAmiiboEcqvBlsRootCertificate
					var ret = GetAmiiboEcqvBlsRootCertificate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // GetUnknownId
					var ret = GetUnknownId(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 33: { // GetUnknownId2
					var ret = GetUnknownId2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFactorySettingsServer: {im.CommandId}");
			}
		}
		
		public virtual void GetBluetoothBdAddress(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetConfigurationId1(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetAccelerometerOffset(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetAccelerometerScale(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetGyroscopeOffset(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetGyroscopeScale(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetWirelessLanMacAddress(out byte[] _0) => throw new NotImplementedException();
		public virtual uint GetWirelessLanCountryCodeCount() => throw new NotImplementedException();
		public virtual void GetWirelessLanCountryCodes(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetSerialNumber(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetInitialSystemAppletProgramId(ulong _0) => "Stub hit for Nn.Settings.IFactorySettingsServer.SetInitialSystemAppletProgramId [10]".Debug();
		public virtual void SetOverlayDispProgramId(ulong _0) => "Stub hit for Nn.Settings.IFactorySettingsServer.SetOverlayDispProgramId [11]".Debug();
		public virtual void GetBatteryLot(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetEciDeviceCertificate(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetEticketDeviceCertificate(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetSslKey(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetSslCertificate(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetGameCardKey(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetGameCardCertificate(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetEciDeviceKey(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetEticketDeviceKey(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetSpeakerParameter(out byte[] _0) => throw new NotImplementedException();
		public virtual uint GetLcdVendorId() => throw new NotImplementedException();
		public virtual object GetEciDeviceCertificate2(object _0) => throw new NotImplementedException();
		public virtual object GetEciDeviceKey2(object _0) => throw new NotImplementedException();
		public virtual object GetAmiiboKey(object _0) => throw new NotImplementedException();
		public virtual object GetAmiiboEcqvCertificate(object _0) => throw new NotImplementedException();
		public virtual object GetAmiiboEcdsaCertificate(object _0) => throw new NotImplementedException();
		public virtual object GetAmiiboEcqvBlsKey(object _0) => throw new NotImplementedException();
		public virtual object GetAmiiboEcqvBlsCertificate(object _0) => throw new NotImplementedException();
		public virtual object GetAmiiboEcqvBlsRootCertificate(object _0) => throw new NotImplementedException();
		public virtual object GetUnknownId(object _0) => throw new NotImplementedException();
		public virtual object GetUnknownId2(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("set:fd")]
	public unsafe partial class IFirmwareDebugSettingsServer : _Base_IFirmwareDebugSettingsServer {}
	public unsafe class _Base_IFirmwareDebugSettingsServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 2: { // SetSettingsItemValue
					SetSettingsItemValue(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // ResetSettingsItemValue
					ResetSettingsItemValue(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // CreateSettingsItemKeyIterator
					var ret = CreateSettingsItemKeyIterator(im.GetBuffer<byte>(0x19, 0));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 10: { // ReadSettings
					ReadSettings(im.GetData<uint>(8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 11: { // ResetSettings
					ResetSettings(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // SetWebInspectorFlag
					SetWebInspectorFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // SetAllowedSslHosts
					SetAllowedSslHosts(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // SetHostFsMountPoint
					SetHostFsMountPoint(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFirmwareDebugSettingsServer: {im.CommandId}");
			}
		}
		
		public virtual void SetSettingsItemValue(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2) => "Stub hit for Nn.Settings.IFirmwareDebugSettingsServer.SetSettingsItemValue [2]".Debug();
		public virtual void ResetSettingsItemValue(Buffer<byte> _0, Buffer<byte> _1) => "Stub hit for Nn.Settings.IFirmwareDebugSettingsServer.ResetSettingsItemValue [3]".Debug();
		public virtual Nn.Settings.ISettingsItemKeyIterator CreateSettingsItemKeyIterator(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ReadSettings(uint _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ResetSettings(uint _0) => "Stub hit for Nn.Settings.IFirmwareDebugSettingsServer.ResetSettings [11]".Debug();
		public virtual void SetWebInspectorFlag(byte _0) => "Stub hit for Nn.Settings.IFirmwareDebugSettingsServer.SetWebInspectorFlag [20]".Debug();
		public virtual void SetAllowedSslHosts(Buffer<byte> _0) => "Stub hit for Nn.Settings.IFirmwareDebugSettingsServer.SetAllowedSslHosts [21]".Debug();
		public virtual void SetHostFsMountPoint(Buffer<byte> _0) => "Stub hit for Nn.Settings.IFirmwareDebugSettingsServer.SetHostFsMountPoint [22]".Debug();
	}
	
	[IpcService("set")]
	public unsafe partial class ISettingsServer : _Base_ISettingsServer {}
	public unsafe class _Base_ISettingsServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetLanguageCode
					GetLanguageCode(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 1: { // GetAvailableLanguageCodes
					GetAvailableLanguageCodes(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 2: { // MakeLanguageCode
					MakeLanguageCode(im.GetData<uint>(8), out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 3: { // GetAvailableLanguageCodeCount
					var ret = GetAvailableLanguageCodeCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 4: { // GetRegionCode
					var ret = GetRegionCode();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 5: { // GetAvailableLanguageCodes2
					GetAvailableLanguageCodes2(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 6: { // GetAvailableLanguageCodeCount2
					var ret = GetAvailableLanguageCodeCount2();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 7: { // GetKeyCodeMap
					GetKeyCodeMap(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // GetQuestFlag
					var ret = GetQuestFlag(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISettingsServer: {im.CommandId}");
			}
		}
		
		public virtual void GetLanguageCode(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetAvailableLanguageCodes(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void MakeLanguageCode(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual uint GetAvailableLanguageCodeCount() => throw new NotImplementedException();
		public virtual uint GetRegionCode() => throw new NotImplementedException();
		public virtual void GetAvailableLanguageCodes2(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetAvailableLanguageCodeCount2() => throw new NotImplementedException();
		public virtual void GetKeyCodeMap(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetQuestFlag(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("set:sys")]
	public unsafe partial class ISystemSettingsServer : _Base_ISystemSettingsServer {}
	public unsafe class _Base_ISystemSettingsServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetLanguageCode
					SetLanguageCode(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // SetNetworkSettings
					SetNetworkSettings(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetNetworkSettings
					GetNetworkSettings(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 3: { // GetFirmwareVersion
					GetFirmwareVersion(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetFirmwareVersion2
					GetFirmwareVersion2(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetFirmwareVersionDigest
					var ret = GetFirmwareVersionDigest(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // GetLockScreenFlag
					var ret = GetLockScreenFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 8: { // SetLockScreenFlag
					SetLockScreenFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // GetBacklightSettings
					GetBacklightSettings(out var _0);
					om.Initialize(0, 0, 40);
					om.SetBytes(8, _0);
					break;
				}
				case 10: { // SetBacklightSettings
					SetBacklightSettings(im.GetBytes(8, 0x28));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // SetBluetoothDevicesSettings
					SetBluetoothDevicesSettings(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // GetBluetoothDevicesSettings
					GetBluetoothDevicesSettings(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 13: { // GetExternalSteadyClockSourceId
					GetExternalSteadyClockSourceId(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 14: { // SetExternalSteadyClockSourceId
					SetExternalSteadyClockSourceId(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetUserSystemClockContext
					GetUserSystemClockContext(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 16: { // SetUserSystemClockContext
					SetUserSystemClockContext(im.GetBytes(8, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // GetAccountSettings
					var ret = GetAccountSettings();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 18: { // SetAccountSettings
					SetAccountSettings(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // GetAudioVolume
					GetAudioVolume(im.GetData<uint>(8), out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 20: { // SetAudioVolume
					SetAudioVolume(im.GetBytes(8, 0x8), im.GetData<uint>(16));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // GetEulaVersions
					GetEulaVersions(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 22: { // SetEulaVersions
					SetEulaVersions(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // GetColorSetId
					var ret = GetColorSetId();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 24: { // SetColorSetId
					SetColorSetId(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // GetConsoleInformationUploadFlag
					var ret = GetConsoleInformationUploadFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 26: { // SetConsoleInformationUploadFlag
					SetConsoleInformationUploadFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // GetAutomaticApplicationDownloadFlag
					var ret = GetAutomaticApplicationDownloadFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 28: { // SetAutomaticApplicationDownloadFlag
					SetAutomaticApplicationDownloadFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 29: { // GetNotificationSettings
					GetNotificationSettings(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 30: { // SetNotificationSettings
					SetNotificationSettings(im.GetBytes(8, 0x18));
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // GetAccountNotificationSettings
					GetAccountNotificationSettings(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 32: { // SetAccountNotificationSettings
					SetAccountNotificationSettings(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 35: { // GetVibrationMasterVolume
					var ret = GetVibrationMasterVolume();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 36: { // SetVibrationMasterVolume
					SetVibrationMasterVolume(im.GetData<float>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 37: { // GetSettingsItemValueSize
					var ret = GetSettingsItemValueSize(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 38: { // GetSettingsItemValue
					GetSettingsItemValue(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 39: { // GetTvSettings
					GetTvSettings(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 40: { // SetTvSettings
					SetTvSettings(im.GetBytes(8, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 41: { // GetEdid
					GetEdid(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 42: { // SetEdid
					SetEdid(im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 43: { // GetAudioOutputMode
					var ret = GetAudioOutputMode(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 44: { // SetAudioOutputMode
					SetAudioOutputMode(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 45: { // IsForceMuteOnHeadphoneRemoved
					var ret = IsForceMuteOnHeadphoneRemoved();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 46: { // SetForceMuteOnHeadphoneRemoved
					SetForceMuteOnHeadphoneRemoved(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 47: { // GetQuestFlag
					var ret = GetQuestFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 48: { // SetQuestFlag
					SetQuestFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 49: { // GetDataDeletionSettings
					GetDataDeletionSettings(out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 50: { // SetDataDeletionSettings
					SetDataDeletionSettings(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 51: { // GetInitialSystemAppletProgramId
					var ret = GetInitialSystemAppletProgramId();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 52: { // GetOverlayDispProgramId
					var ret = GetOverlayDispProgramId();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 53: { // GetDeviceTimeZoneLocationName
					GetDeviceTimeZoneLocationName(out var _0);
					om.Initialize(0, 0, 36);
					om.SetBytes(8, _0);
					break;
				}
				case 54: { // SetDeviceTimeZoneLocationName
					SetDeviceTimeZoneLocationName(im.GetBytes(8, 0x24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 55: { // GetWirelessCertificationFileSize
					var ret = GetWirelessCertificationFileSize();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 56: { // GetWirelessCertificationFile
					GetWirelessCertificationFile(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				case 57: { // SetRegionCode
					SetRegionCode(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 58: { // GetNetworkSystemClockContext
					GetNetworkSystemClockContext(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 59: { // SetNetworkSystemClockContext
					SetNetworkSystemClockContext(im.GetBytes(8, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 60: { // IsUserSystemClockAutomaticCorrectionEnabled
					var ret = IsUserSystemClockAutomaticCorrectionEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 61: { // SetUserSystemClockAutomaticCorrectionEnabled
					SetUserSystemClockAutomaticCorrectionEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 62: { // GetDebugModeFlag
					var ret = GetDebugModeFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 63: { // GetPrimaryAlbumStorage
					var ret = GetPrimaryAlbumStorage();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 64: { // SetPrimaryAlbumStorage
					SetPrimaryAlbumStorage(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 65: { // GetUsb30EnableFlag
					var ret = GetUsb30EnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 66: { // SetUsb30EnableFlag
					SetUsb30EnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 67: { // GetBatteryLot
					GetBatteryLot(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 68: { // GetSerialNumber
					GetSerialNumber(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 69: { // GetNfcEnableFlag
					var ret = GetNfcEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 70: { // SetNfcEnableFlag
					SetNfcEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 71: { // GetSleepSettings
					GetSleepSettings(out var _0);
					om.Initialize(0, 0, 12);
					om.SetBytes(8, _0);
					break;
				}
				case 72: { // SetSleepSettings
					SetSleepSettings(im.GetBytes(8, 0xC));
					om.Initialize(0, 0, 0);
					break;
				}
				case 73: { // GetWirelessLanEnableFlag
					var ret = GetWirelessLanEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 74: { // SetWirelessLanEnableFlag
					SetWirelessLanEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 75: { // GetInitialLaunchSettings
					GetInitialLaunchSettings(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 76: { // SetInitialLaunchSettings
					SetInitialLaunchSettings(im.GetBytes(8, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 77: { // GetDeviceNickName
					GetDeviceNickName(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 78: { // SetDeviceNickName
					SetDeviceNickName(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 79: { // GetProductModel
					var ret = GetProductModel();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 80: { // GetLdnChannel
					var ret = GetLdnChannel();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 81: { // SetLdnChannel
					SetLdnChannel(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 82: { // AcquireTelemetryDirtyFlagEventHandle
					var ret = AcquireTelemetryDirtyFlagEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 83: { // GetTelemetryDirtyFlags
					var ret = GetTelemetryDirtyFlags();
					om.Initialize(0, 0, 0);
					break;
				}
				case 84: { // GetPtmBatteryLot
					GetPtmBatteryLot(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 85: { // SetPtmBatteryLot
					SetPtmBatteryLot(im.GetBytes(8, 0x18));
					om.Initialize(0, 0, 0);
					break;
				}
				case 86: { // GetPtmFuelGaugeParameter
					GetPtmFuelGaugeParameter(out var _0);
					om.Initialize(0, 0, 24);
					om.SetBytes(8, _0);
					break;
				}
				case 87: { // SetPtmFuelGaugeParameter
					SetPtmFuelGaugeParameter(im.GetBytes(8, 0x18));
					om.Initialize(0, 0, 0);
					break;
				}
				case 88: { // GetBluetoothEnableFlag
					var ret = GetBluetoothEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 89: { // SetBluetoothEnableFlag
					SetBluetoothEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 90: { // GetMiiAuthorId
					GetMiiAuthorId(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 91: { // SetShutdownRtcValue
					SetShutdownRtcValue(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 92: { // GetShutdownRtcValue
					var ret = GetShutdownRtcValue();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 93: { // AcquireFatalDirtyFlagEventHandle
					var ret = AcquireFatalDirtyFlagEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 94: { // GetFatalDirtyFlags
					var ret = GetFatalDirtyFlags();
					om.Initialize(0, 0, 0);
					break;
				}
				case 95: { // GetAutoUpdateEnableFlag
					var ret = GetAutoUpdateEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 96: { // SetAutoUpdateEnableFlag
					SetAutoUpdateEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 97: { // GetNxControllerSettings
					GetNxControllerSettings(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 98: { // SetNxControllerSettings
					SetNxControllerSettings(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 99: { // GetBatteryPercentageFlag
					var ret = GetBatteryPercentageFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 100: { // SetBatteryPercentageFlag
					SetBatteryPercentageFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // GetExternalRtcResetFlag
					var ret = GetExternalRtcResetFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 102: { // SetExternalRtcResetFlag
					SetExternalRtcResetFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // GetUsbFullKeyEnableFlag
					var ret = GetUsbFullKeyEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 104: { // SetUsbFullKeyEnableFlag
					SetUsbFullKeyEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 105: { // SetExternalSteadyClockInternalOffset
					SetExternalSteadyClockInternalOffset(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 106: { // GetExternalSteadyClockInternalOffset
					var ret = GetExternalSteadyClockInternalOffset();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 107: { // GetBacklightSettingsEx
					GetBacklightSettingsEx(out var _0);
					om.Initialize(0, 0, 44);
					om.SetBytes(8, _0);
					break;
				}
				case 108: { // SetBacklightSettingsEx
					SetBacklightSettingsEx(im.GetBytes(8, 0x2C));
					om.Initialize(0, 0, 0);
					break;
				}
				case 109: { // GetHeadphoneVolumeWarningCount
					var ret = GetHeadphoneVolumeWarningCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 110: { // SetHeadphoneVolumeWarningCount
					SetHeadphoneVolumeWarningCount(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // GetBluetoothAfhEnableFlag
					var ret = GetBluetoothAfhEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 112: { // SetBluetoothAfhEnableFlag
					SetBluetoothAfhEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 113: { // GetBluetoothBoostEnableFlag
					var ret = GetBluetoothBoostEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 114: { // SetBluetoothBoostEnableFlag
					SetBluetoothBoostEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 115: { // GetInRepairProcessEnableFlag
					var ret = GetInRepairProcessEnableFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 116: { // SetInRepairProcessEnableFlag
					SetInRepairProcessEnableFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 117: { // GetHeadphoneVolumeUpdateFlag
					var ret = GetHeadphoneVolumeUpdateFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 118: { // SetHeadphoneVolumeUpdateFlag
					SetHeadphoneVolumeUpdateFlag(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 119: { // NeedsToUpdateHeadphoneVolume
					NeedsToUpdateHeadphoneVolume(im.GetData<byte>(8), out var _0, out var _1, out var _2);
					om.Initialize(0, 0, 3);
					om.SetData(8, _0);
					om.SetData(9, _1);
					om.SetData(10, _2);
					break;
				}
				case 120: { // GetPushNotificationActivityModeOnSleep
					var ret = GetPushNotificationActivityModeOnSleep();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 121: { // SetPushNotificationActivityModeOnSleep
					SetPushNotificationActivityModeOnSleep(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 122: { // GetServiceDiscoveryControlSettings
					var ret = GetServiceDiscoveryControlSettings();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 123: { // SetServiceDiscoveryControlSettings
					SetServiceDiscoveryControlSettings(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 124: { // GetErrorReportSharePermission
					var ret = GetErrorReportSharePermission();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 125: { // SetErrorReportSharePermission
					SetErrorReportSharePermission(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 126: { // GetAppletLaunchFlags
					var ret = GetAppletLaunchFlags();
					om.Initialize(0, 0, 0);
					break;
				}
				case 127: { // SetAppletLaunchFlags
					SetAppletLaunchFlags(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 128: { // GetConsoleSixAxisSensorAccelerationBias
					GetConsoleSixAxisSensorAccelerationBias(out var _0);
					om.Initialize(0, 0, 12);
					om.SetBytes(8, _0);
					break;
				}
				case 129: { // SetConsoleSixAxisSensorAccelerationBias
					SetConsoleSixAxisSensorAccelerationBias(im.GetBytes(8, 0xC));
					om.Initialize(0, 0, 0);
					break;
				}
				case 130: { // GetConsoleSixAxisSensorAngularVelocityBias
					GetConsoleSixAxisSensorAngularVelocityBias(out var _0);
					om.Initialize(0, 0, 12);
					om.SetBytes(8, _0);
					break;
				}
				case 131: { // SetConsoleSixAxisSensorAngularVelocityBias
					SetConsoleSixAxisSensorAngularVelocityBias(im.GetBytes(8, 0xC));
					om.Initialize(0, 0, 0);
					break;
				}
				case 132: { // GetConsoleSixAxisSensorAccelerationGain
					GetConsoleSixAxisSensorAccelerationGain(out var _0);
					om.Initialize(0, 0, 36);
					om.SetBytes(8, _0);
					break;
				}
				case 133: { // SetConsoleSixAxisSensorAccelerationGain
					SetConsoleSixAxisSensorAccelerationGain(im.GetBytes(8, 0x24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 134: { // GetConsoleSixAxisSensorAngularVelocityGain
					GetConsoleSixAxisSensorAngularVelocityGain(out var _0);
					om.Initialize(0, 0, 36);
					om.SetBytes(8, _0);
					break;
				}
				case 135: { // SetConsoleSixAxisSensorAngularVelocityGain
					SetConsoleSixAxisSensorAngularVelocityGain(im.GetBytes(8, 0x24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 136: { // GetKeyboardLayout
					var ret = GetKeyboardLayout();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 137: { // SetKeyboardLayout
					SetKeyboardLayout(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 138: { // GetWebInspectorFlag
					var ret = GetWebInspectorFlag();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 139: { // GetAllowedSslHosts
					GetAllowedSslHosts(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 140: { // GetHostFsMountPoint
					GetHostFsMountPoint(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 141: { // GetRequiresRunRepairTimeReviser
					var ret = GetRequiresRunRepairTimeReviser(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 142: { // SetRequiresRunRepairTimeReviser
					var ret = SetRequiresRunRepairTimeReviser(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 143: { // SetBlePairingSettings
					var ret = SetBlePairingSettings(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 144: { // GetBlePairingSettings
					var ret = GetBlePairingSettings(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 145: { // GetConsoleSixAxisSensorAngularVelocityTimeBias
					var ret = GetConsoleSixAxisSensorAngularVelocityTimeBias(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 146: { // SetConsoleSixAxisSensorAngularVelocityTimeBias
					var ret = SetConsoleSixAxisSensorAngularVelocityTimeBias(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 147: { // GetConsoleSixAxisSensorAngularAcceleration
					var ret = GetConsoleSixAxisSensorAngularAcceleration(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 148: { // SetConsoleSixAxisSensorAngularAcceleration
					var ret = SetConsoleSixAxisSensorAngularAcceleration(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 149: { // GetRebootlessSystemUpdateVersion
					var ret = GetRebootlessSystemUpdateVersion(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemSettingsServer: {im.CommandId}");
			}
		}
		
		public virtual void SetLanguageCode(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetLanguageCode [0]".Debug();
		public virtual void SetNetworkSettings(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetNetworkSettings [1]".Debug();
		public virtual void GetNetworkSettings(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetFirmwareVersion(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetFirmwareVersion2(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetFirmwareVersionDigest(object _0) => throw new NotImplementedException();
		public virtual byte GetLockScreenFlag() => throw new NotImplementedException();
		public virtual void SetLockScreenFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetLockScreenFlag [8]".Debug();
		public virtual void GetBacklightSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetBacklightSettings(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBacklightSettings [10]".Debug();
		public virtual void SetBluetoothDevicesSettings(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBluetoothDevicesSettings [11]".Debug();
		public virtual void GetBluetoothDevicesSettings(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetExternalSteadyClockSourceId(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetExternalSteadyClockSourceId(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetExternalSteadyClockSourceId [14]".Debug();
		public virtual void GetUserSystemClockContext(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetUserSystemClockContext(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetUserSystemClockContext [16]".Debug();
		public virtual uint GetAccountSettings() => throw new NotImplementedException();
		public virtual void SetAccountSettings(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAccountSettings [18]".Debug();
		public virtual void GetAudioVolume(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void SetAudioVolume(byte[] _0, uint _1) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAudioVolume [20]".Debug();
		public virtual void GetEulaVersions(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetEulaVersions(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetEulaVersions [22]".Debug();
		public virtual uint GetColorSetId() => throw new NotImplementedException();
		public virtual void SetColorSetId(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetColorSetId [24]".Debug();
		public virtual byte GetConsoleInformationUploadFlag() => throw new NotImplementedException();
		public virtual void SetConsoleInformationUploadFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetConsoleInformationUploadFlag [26]".Debug();
		public virtual byte GetAutomaticApplicationDownloadFlag() => throw new NotImplementedException();
		public virtual void SetAutomaticApplicationDownloadFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAutomaticApplicationDownloadFlag [28]".Debug();
		public virtual void GetNotificationSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetNotificationSettings(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetNotificationSettings [30]".Debug();
		public virtual void GetAccountNotificationSettings(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAccountNotificationSettings(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAccountNotificationSettings [32]".Debug();
		public virtual float GetVibrationMasterVolume() => throw new NotImplementedException();
		public virtual void SetVibrationMasterVolume(float _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetVibrationMasterVolume [36]".Debug();
		public virtual ulong GetSettingsItemValueSize(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetSettingsItemValue(Buffer<byte> _0, Buffer<byte> _1, out ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void GetTvSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetTvSettings(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetTvSettings [40]".Debug();
		public virtual void GetEdid(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetEdid(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetEdid [42]".Debug();
		public virtual uint GetAudioOutputMode(uint _0) => throw new NotImplementedException();
		public virtual void SetAudioOutputMode(uint _0, uint _1) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAudioOutputMode [44]".Debug();
		public virtual byte IsForceMuteOnHeadphoneRemoved() => throw new NotImplementedException();
		public virtual void SetForceMuteOnHeadphoneRemoved(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetForceMuteOnHeadphoneRemoved [46]".Debug();
		public virtual byte GetQuestFlag() => throw new NotImplementedException();
		public virtual void SetQuestFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetQuestFlag [48]".Debug();
		public virtual void GetDataDeletionSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetDataDeletionSettings(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetDataDeletionSettings [50]".Debug();
		public virtual ulong GetInitialSystemAppletProgramId() => throw new NotImplementedException();
		public virtual ulong GetOverlayDispProgramId() => throw new NotImplementedException();
		public virtual void GetDeviceTimeZoneLocationName(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetDeviceTimeZoneLocationName(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetDeviceTimeZoneLocationName [54]".Debug();
		public virtual ulong GetWirelessCertificationFileSize() => throw new NotImplementedException();
		public virtual void GetWirelessCertificationFile(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetRegionCode(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetRegionCode [57]".Debug();
		public virtual void GetNetworkSystemClockContext(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetNetworkSystemClockContext(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetNetworkSystemClockContext [59]".Debug();
		public virtual byte IsUserSystemClockAutomaticCorrectionEnabled() => throw new NotImplementedException();
		public virtual void SetUserSystemClockAutomaticCorrectionEnabled(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetUserSystemClockAutomaticCorrectionEnabled [61]".Debug();
		public virtual byte GetDebugModeFlag() => throw new NotImplementedException();
		public virtual uint GetPrimaryAlbumStorage() => throw new NotImplementedException();
		public virtual void SetPrimaryAlbumStorage(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetPrimaryAlbumStorage [64]".Debug();
		public virtual byte GetUsb30EnableFlag() => throw new NotImplementedException();
		public virtual void SetUsb30EnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetUsb30EnableFlag [66]".Debug();
		public virtual void GetBatteryLot(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetSerialNumber(out byte[] _0) => throw new NotImplementedException();
		public virtual byte GetNfcEnableFlag() => throw new NotImplementedException();
		public virtual void SetNfcEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetNfcEnableFlag [70]".Debug();
		public virtual void GetSleepSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetSleepSettings(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetSleepSettings [72]".Debug();
		public virtual byte GetWirelessLanEnableFlag() => throw new NotImplementedException();
		public virtual void SetWirelessLanEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetWirelessLanEnableFlag [74]".Debug();
		public virtual void GetInitialLaunchSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetInitialLaunchSettings(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetInitialLaunchSettings [76]".Debug();
		public virtual void GetDeviceNickName(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetDeviceNickName(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetDeviceNickName [78]".Debug();
		public virtual uint GetProductModel() => throw new NotImplementedException();
		public virtual uint GetLdnChannel() => throw new NotImplementedException();
		public virtual void SetLdnChannel(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetLdnChannel [81]".Debug();
		public virtual KObject AcquireTelemetryDirtyFlagEventHandle() => throw new NotImplementedException();
		public virtual object GetTelemetryDirtyFlags() => throw new NotImplementedException();
		public virtual void GetPtmBatteryLot(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetPtmBatteryLot(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetPtmBatteryLot [85]".Debug();
		public virtual void GetPtmFuelGaugeParameter(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetPtmFuelGaugeParameter(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetPtmFuelGaugeParameter [87]".Debug();
		public virtual byte GetBluetoothEnableFlag() => throw new NotImplementedException();
		public virtual void SetBluetoothEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBluetoothEnableFlag [89]".Debug();
		public virtual void GetMiiAuthorId(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetShutdownRtcValue(ulong _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetShutdownRtcValue [91]".Debug();
		public virtual ulong GetShutdownRtcValue() => throw new NotImplementedException();
		public virtual KObject AcquireFatalDirtyFlagEventHandle() => throw new NotImplementedException();
		public virtual object GetFatalDirtyFlags() => throw new NotImplementedException();
		public virtual byte GetAutoUpdateEnableFlag() => throw new NotImplementedException();
		public virtual void SetAutoUpdateEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAutoUpdateEnableFlag [96]".Debug();
		public virtual void GetNxControllerSettings(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetNxControllerSettings(Buffer<byte> _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetNxControllerSettings [98]".Debug();
		public virtual byte GetBatteryPercentageFlag() => throw new NotImplementedException();
		public virtual void SetBatteryPercentageFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBatteryPercentageFlag [100]".Debug();
		public virtual byte GetExternalRtcResetFlag() => throw new NotImplementedException();
		public virtual void SetExternalRtcResetFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetExternalRtcResetFlag [102]".Debug();
		public virtual byte GetUsbFullKeyEnableFlag() => throw new NotImplementedException();
		public virtual void SetUsbFullKeyEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetUsbFullKeyEnableFlag [104]".Debug();
		public virtual void SetExternalSteadyClockInternalOffset(ulong _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetExternalSteadyClockInternalOffset [105]".Debug();
		public virtual ulong GetExternalSteadyClockInternalOffset() => throw new NotImplementedException();
		public virtual void GetBacklightSettingsEx(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetBacklightSettingsEx(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBacklightSettingsEx [108]".Debug();
		public virtual uint GetHeadphoneVolumeWarningCount() => throw new NotImplementedException();
		public virtual void SetHeadphoneVolumeWarningCount(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetHeadphoneVolumeWarningCount [110]".Debug();
		public virtual byte GetBluetoothAfhEnableFlag() => throw new NotImplementedException();
		public virtual void SetBluetoothAfhEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBluetoothAfhEnableFlag [112]".Debug();
		public virtual byte GetBluetoothBoostEnableFlag() => throw new NotImplementedException();
		public virtual void SetBluetoothBoostEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetBluetoothBoostEnableFlag [114]".Debug();
		public virtual byte GetInRepairProcessEnableFlag() => throw new NotImplementedException();
		public virtual void SetInRepairProcessEnableFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetInRepairProcessEnableFlag [116]".Debug();
		public virtual byte GetHeadphoneVolumeUpdateFlag() => throw new NotImplementedException();
		public virtual void SetHeadphoneVolumeUpdateFlag(byte _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetHeadphoneVolumeUpdateFlag [118]".Debug();
		public virtual void NeedsToUpdateHeadphoneVolume(byte _0, out byte _1, out byte _2, out sbyte _3) => throw new NotImplementedException();
		public virtual uint GetPushNotificationActivityModeOnSleep() => throw new NotImplementedException();
		public virtual void SetPushNotificationActivityModeOnSleep(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetPushNotificationActivityModeOnSleep [121]".Debug();
		public virtual uint GetServiceDiscoveryControlSettings() => throw new NotImplementedException();
		public virtual void SetServiceDiscoveryControlSettings(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetServiceDiscoveryControlSettings [123]".Debug();
		public virtual uint GetErrorReportSharePermission() => throw new NotImplementedException();
		public virtual void SetErrorReportSharePermission(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetErrorReportSharePermission [125]".Debug();
		public virtual object GetAppletLaunchFlags() => throw new NotImplementedException();
		public virtual void SetAppletLaunchFlags(object _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetAppletLaunchFlags [127]".Debug();
		public virtual void GetConsoleSixAxisSensorAccelerationBias(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetConsoleSixAxisSensorAccelerationBias(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetConsoleSixAxisSensorAccelerationBias [129]".Debug();
		public virtual void GetConsoleSixAxisSensorAngularVelocityBias(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetConsoleSixAxisSensorAngularVelocityBias(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetConsoleSixAxisSensorAngularVelocityBias [131]".Debug();
		public virtual void GetConsoleSixAxisSensorAccelerationGain(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetConsoleSixAxisSensorAccelerationGain(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetConsoleSixAxisSensorAccelerationGain [133]".Debug();
		public virtual void GetConsoleSixAxisSensorAngularVelocityGain(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetConsoleSixAxisSensorAngularVelocityGain(byte[] _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetConsoleSixAxisSensorAngularVelocityGain [135]".Debug();
		public virtual uint GetKeyboardLayout() => throw new NotImplementedException();
		public virtual void SetKeyboardLayout(uint _0) => "Stub hit for Nn.Settings.ISystemSettingsServer.SetKeyboardLayout [137]".Debug();
		public virtual byte GetWebInspectorFlag() => throw new NotImplementedException();
		public virtual void GetAllowedSslHosts(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetHostFsMountPoint(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetRequiresRunRepairTimeReviser(object _0) => throw new NotImplementedException();
		public virtual object SetRequiresRunRepairTimeReviser(object _0) => throw new NotImplementedException();
		public virtual object SetBlePairingSettings(object _0) => throw new NotImplementedException();
		public virtual object GetBlePairingSettings(object _0) => throw new NotImplementedException();
		public virtual object GetConsoleSixAxisSensorAngularVelocityTimeBias(object _0) => throw new NotImplementedException();
		public virtual object SetConsoleSixAxisSensorAngularVelocityTimeBias(object _0) => throw new NotImplementedException();
		public virtual object GetConsoleSixAxisSensorAngularAcceleration(object _0) => throw new NotImplementedException();
		public virtual object SetConsoleSixAxisSensorAngularAcceleration(object _0) => throw new NotImplementedException();
		public virtual object GetRebootlessSystemUpdateVersion(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISettingsItemKeyIterator : _Base_ISettingsItemKeyIterator {}
	public unsafe class _Base_ISettingsItemKeyIterator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GoNext
					GoNext();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetKeySize
					var ret = GetKeySize();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 2: { // GetKey
					GetKey(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISettingsItemKeyIterator: {im.CommandId}");
			}
		}
		
		public virtual void GoNext() => "Stub hit for Nn.Settings.ISettingsItemKeyIterator.GoNext [0]".Debug();
		public virtual ulong GetKeySize() => throw new NotImplementedException();
		public virtual void GetKey(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
}
