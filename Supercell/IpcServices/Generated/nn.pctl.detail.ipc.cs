#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pctl.Detail.Ipc {
	[IpcService("pctl")]
	[IpcService("pctl:a")]
	[IpcService("pctl:s")]
	[IpcService("pctl:r")]
	public unsafe partial class IParentalControlServiceFactory : _Base_IParentalControlServiceFactory {}
	public unsafe class _Base_IParentalControlServiceFactory : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateService
					var ret = CreateService(im.GetData<ulong>(0), im.Pid);
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // CreateServiceWithoutInitialize
					var ret = CreateServiceWithoutInitialize(im.GetData<ulong>(0), im.Pid);
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IParentalControlServiceFactory: {im.CommandId}");
			}
		}
		
		public virtual Nn.Pctl.Detail.Ipc.IParentalControlService CreateService(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual Nn.Pctl.Detail.Ipc.IParentalControlService CreateServiceWithoutInitialize(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IParentalControlService : _Base_IParentalControlService {}
	public unsafe class _Base_IParentalControlService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Initialize
					Initialize();
					break;
				}
				case 1001: { // CheckFreeCommunicationPermission
					CheckFreeCommunicationPermission();
					break;
				}
				case 1002: { // ConfirmLaunchApplicationPermission
					ConfirmLaunchApplicationPermission(im.GetData<byte>(0), im.GetData<ulong>(8), im.GetBuffer<sbyte>(0x9, 0));
					break;
				}
				case 1003: { // ConfirmResumeApplicationPermission
					ConfirmResumeApplicationPermission(im.GetData<byte>(0), im.GetData<ulong>(8), im.GetBuffer<sbyte>(0x9, 0));
					break;
				}
				case 1004: { // ConfirmSnsPostPermission
					ConfirmSnsPostPermission();
					break;
				}
				case 1005: { // ConfirmSystemSettingsPermission
					ConfirmSystemSettingsPermission();
					break;
				}
				case 1006: { // IsRestrictionTemporaryUnlocked
					var ret = IsRestrictionTemporaryUnlocked();
					om.SetData(0, ret);
					break;
				}
				case 1007: { // RevertRestrictionTemporaryUnlocked
					RevertRestrictionTemporaryUnlocked();
					break;
				}
				case 1008: { // EnterRestrictedSystemSettings
					EnterRestrictedSystemSettings();
					break;
				}
				case 1009: { // LeaveRestrictedSystemSettings
					LeaveRestrictedSystemSettings();
					break;
				}
				case 1010: { // IsRestrictedSystemSettingsEntered
					var ret = IsRestrictedSystemSettingsEntered();
					om.SetData(0, ret);
					break;
				}
				case 1011: { // RevertRestrictedSystemSettingsEntered
					RevertRestrictedSystemSettingsEntered();
					break;
				}
				case 1012: { // GetRestrictedFeatures
					var ret = GetRestrictedFeatures();
					om.SetData(0, ret);
					break;
				}
				case 1013: { // ConfirmStereoVisionPermission
					ConfirmStereoVisionPermission();
					break;
				}
				case 1014: { // ConfirmPlayableApplicationVideoOld
					var ret = ConfirmPlayableApplicationVideoOld(null);
					break;
				}
				case 1015: { // ConfirmPlayableApplicationVideo
					var ret = ConfirmPlayableApplicationVideo(null);
					break;
				}
				case 1031: { // IsRestrictionEnabled
					var ret = IsRestrictionEnabled();
					om.SetData(0, ret);
					break;
				}
				case 1032: { // GetSafetyLevel
					var ret = GetSafetyLevel();
					om.SetData(0, ret);
					break;
				}
				case 1033: { // SetSafetyLevel
					SetSafetyLevel(im.GetData<uint>(0));
					break;
				}
				case 1034: { // GetSafetyLevelSettings
					GetSafetyLevelSettings(im.GetData<uint>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1035: { // GetCurrentSettings
					GetCurrentSettings(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1036: { // SetCustomSafetyLevelSettings
					SetCustomSafetyLevelSettings(im.GetBytes(0, 0x3));
					break;
				}
				case 1037: { // GetDefaultRatingOrganization
					var ret = GetDefaultRatingOrganization();
					om.SetData(0, ret);
					break;
				}
				case 1038: { // SetDefaultRatingOrganization
					SetDefaultRatingOrganization(im.GetData<uint>(0));
					break;
				}
				case 1039: { // GetFreeCommunicationApplicationListCount
					var ret = GetFreeCommunicationApplicationListCount();
					om.SetData(0, ret);
					break;
				}
				case 1042: { // AddToFreeCommunicationApplicationList
					AddToFreeCommunicationApplicationList(im.GetData<ulong>(0));
					break;
				}
				case 1043: { // DeleteSettings
					DeleteSettings();
					break;
				}
				case 1044: { // GetFreeCommunicationApplicationList
					GetFreeCommunicationApplicationList(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1045: { // UpdateFreeCommunicationApplicationList
					UpdateFreeCommunicationApplicationList(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1046: { // DisableFeaturesForReset
					DisableFeaturesForReset();
					break;
				}
				case 1047: { // NotifyApplicationDownloadStarted
					NotifyApplicationDownloadStarted(im.GetData<ulong>(0));
					break;
				}
				case 1061: { // ConfirmStereoVisionRestrictionConfigurable
					ConfirmStereoVisionRestrictionConfigurable();
					break;
				}
				case 1062: { // GetStereoVisionRestriction
					var ret = GetStereoVisionRestriction();
					om.SetData(0, ret);
					break;
				}
				case 1063: { // SetStereoVisionRestriction
					SetStereoVisionRestriction(im.GetData<byte>(0));
					break;
				}
				case 1064: { // ResetConfirmedStereoVisionPermission
					var ret = ResetConfirmedStereoVisionPermission(null);
					break;
				}
				case 1065: { // IsStereoVisionPermitted
					var ret = IsStereoVisionPermitted(null);
					break;
				}
				case 1201: { // UnlockRestrictionTemporarily
					UnlockRestrictionTemporarily(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 1202: { // UnlockSystemSettingsRestriction
					UnlockSystemSettingsRestriction(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 1203: { // SetPinCode
					SetPinCode(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 1204: { // GenerateInquiryCode
					GenerateInquiryCode(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1205: { // CheckMasterKey
					var ret = CheckMasterKey(im.GetBytes(0, 0x20), im.GetBuffer<byte>(0x9, 0));
					om.SetData(0, ret);
					break;
				}
				case 1206: { // GetPinCodeLength
					var ret = GetPinCodeLength();
					om.SetData(0, ret);
					break;
				}
				case 1207: { // GetPinCodeChangedEvent
					var ret = GetPinCodeChangedEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1208: { // GetPinCode
					GetPinCode(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 1403: { // IsPairingActive
					var ret = IsPairingActive();
					om.SetData(0, ret);
					break;
				}
				case 1406: { // GetSettingsLastUpdated
					var ret = GetSettingsLastUpdated();
					om.SetData(0, ret);
					break;
				}
				case 1411: { // GetPairingAccountInfo
					GetPairingAccountInfo(im.GetBytes(0, 0x10), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1421: { // GetAccountNickname
					GetAccountNickname(im.GetBytes(0, 0x10), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 1424: { // GetAccountState
					var ret = GetAccountState(im.GetBytes(0, 0x10));
					om.SetData(0, ret);
					break;
				}
				case 1432: { // GetSynchronizationEvent
					var ret = GetSynchronizationEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1451: { // StartPlayTimer
					StartPlayTimer();
					break;
				}
				case 1452: { // StopPlayTimer
					StopPlayTimer();
					break;
				}
				case 1453: { // IsPlayTimerEnabled
					var ret = IsPlayTimerEnabled();
					om.SetData(0, ret);
					break;
				}
				case 1454: { // GetPlayTimerRemainingTime
					var ret = GetPlayTimerRemainingTime();
					om.SetData(0, ret);
					break;
				}
				case 1455: { // IsRestrictedByPlayTimer
					var ret = IsRestrictedByPlayTimer();
					om.SetData(0, ret);
					break;
				}
				case 1456: { // GetPlayTimerSettings
					GetPlayTimerSettings(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1457: { // GetPlayTimerEventToRequestSuspension
					var ret = GetPlayTimerEventToRequestSuspension();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1458: { // IsPlayTimerAlarmDisabled
					var ret = IsPlayTimerAlarmDisabled();
					om.SetData(0, ret);
					break;
				}
				case 1471: { // NotifyWrongPinCodeInputManyTimes
					NotifyWrongPinCodeInputManyTimes();
					break;
				}
				case 1472: { // CancelNetworkRequest
					CancelNetworkRequest();
					break;
				}
				case 1473: { // GetUnlinkedEvent
					var ret = GetUnlinkedEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1474: { // ClearUnlinkedEvent
					ClearUnlinkedEvent();
					break;
				}
				case 1601: { // DisableAllFeatures
					var ret = DisableAllFeatures();
					om.SetData(0, ret);
					break;
				}
				case 1602: { // PostEnableAllFeatures
					var ret = PostEnableAllFeatures();
					om.SetData(0, ret);
					break;
				}
				case 1603: { // IsAllFeaturesDisabled
					IsAllFeaturesDisabled(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(1, _1);
					break;
				}
				case 1901: { // DeleteFromFreeCommunicationApplicationListForDebug
					DeleteFromFreeCommunicationApplicationListForDebug(im.GetData<ulong>(0));
					break;
				}
				case 1902: { // ClearFreeCommunicationApplicationListForDebug
					ClearFreeCommunicationApplicationListForDebug();
					break;
				}
				case 1903: { // GetExemptApplicationListCountForDebug
					var ret = GetExemptApplicationListCountForDebug(null);
					break;
				}
				case 1904: { // GetExemptApplicationListForDebug
					var ret = GetExemptApplicationListForDebug(null);
					break;
				}
				case 1905: { // UpdateExemptApplicationListForDebug
					var ret = UpdateExemptApplicationListForDebug(null);
					break;
				}
				case 1906: { // AddToExemptApplicationListForDebug
					var ret = AddToExemptApplicationListForDebug(null);
					break;
				}
				case 1907: { // DeleteFromExemptApplicationListForDebug
					var ret = DeleteFromExemptApplicationListForDebug(null);
					break;
				}
				case 1908: { // ClearExemptApplicationListForDebug
					var ret = ClearExemptApplicationListForDebug(null);
					break;
				}
				case 1941: { // DeletePairing
					DeletePairing();
					break;
				}
				case 1951: { // SetPlayTimerSettingsForDebug
					SetPlayTimerSettingsForDebug(im.GetBytes(0, 0x34));
					break;
				}
				case 1952: { // GetPlayTimerSpentTimeForTest
					var ret = GetPlayTimerSpentTimeForTest();
					om.SetData(0, ret);
					break;
				}
				case 1953: { // SetPlayTimerAlarmDisabledForDebug
					SetPlayTimerAlarmDisabledForDebug(im.GetData<byte>(0));
					break;
				}
				case 2001: { // RequestPairingAsync
					RequestPairingAsync(im.GetBuffer<byte>(0x9, 0), out var _0, out var _1);
					om.SetBytes(0, _0);
					om.Copy(0, _1.Handle);
					break;
				}
				case 2002: { // FinishRequestPairing
					FinishRequestPairing(im.GetBytes(0, 0x8), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 2003: { // AuthorizePairingAsync
					AuthorizePairingAsync(im.GetBytes(0, 0x10), out var _0, out var _1);
					om.SetBytes(0, _0);
					om.Copy(0, _1.Handle);
					break;
				}
				case 2004: { // FinishAuthorizePairing
					FinishAuthorizePairing(im.GetBytes(0, 0x8), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 2005: { // RetrievePairingInfoAsync
					RetrievePairingInfoAsync(out var _0, out var _1);
					om.SetBytes(0, _0);
					om.Copy(0, _1.Handle);
					break;
				}
				case 2006: { // FinishRetrievePairingInfo
					FinishRetrievePairingInfo(im.GetBytes(0, 0x8), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 2007: { // UnlinkPairingAsync
					UnlinkPairingAsync(im.GetData<byte>(0), out var _0, out var _1);
					om.SetBytes(0, _0);
					om.Copy(0, _1.Handle);
					break;
				}
				case 2008: { // FinishUnlinkPairing
					FinishUnlinkPairing(im.GetData<byte>(0), im.GetBytes(1, 0x8));
					break;
				}
				case 2009: { // GetAccountMiiImageAsync
					GetAccountMiiImageAsync(im.GetBytes(0, 0x10), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.SetBytes(0, _0);
					om.SetData(8, _1);
					om.Copy(0, _2.Handle);
					break;
				}
				case 2010: { // FinishGetAccountMiiImage
					FinishGetAccountMiiImage(im.GetBytes(0, 0x8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 2011: { // GetAccountMiiImageContentTypeAsync
					GetAccountMiiImageContentTypeAsync(im.GetBytes(0, 0x10), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0xA, 0));
					om.SetBytes(0, _0);
					om.SetData(8, _1);
					om.Copy(0, _2.Handle);
					break;
				}
				case 2012: { // FinishGetAccountMiiImageContentType
					FinishGetAccountMiiImageContentType(im.GetBytes(0, 0x8), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 2013: { // SynchronizeParentalControlSettingsAsync
					SynchronizeParentalControlSettingsAsync(out var _0, out var _1);
					om.SetBytes(0, _0);
					om.Copy(0, _1.Handle);
					break;
				}
				case 2014: { // FinishSynchronizeParentalControlSettings
					FinishSynchronizeParentalControlSettings(im.GetBytes(0, 0x8));
					break;
				}
				case 2015: { // FinishSynchronizeParentalControlSettingsWithLastUpdated
					var ret = FinishSynchronizeParentalControlSettingsWithLastUpdated(im.GetBytes(0, 0x8));
					om.SetData(0, ret);
					break;
				}
				case 2016: { // RequestUpdateExemptionListAsync
					var ret = RequestUpdateExemptionListAsync(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IParentalControlService: {im.CommandId}");
			}
		}
		
		public virtual void Initialize() => throw new NotImplementedException();
		public virtual void CheckFreeCommunicationPermission() => throw new NotImplementedException();
		public virtual void ConfirmLaunchApplicationPermission(byte _0, ulong _1, Buffer<sbyte> _2) => throw new NotImplementedException();
		public virtual void ConfirmResumeApplicationPermission(byte _0, ulong _1, Buffer<sbyte> _2) => throw new NotImplementedException();
		public virtual void ConfirmSnsPostPermission() => throw new NotImplementedException();
		public virtual void ConfirmSystemSettingsPermission() => throw new NotImplementedException();
		public virtual byte IsRestrictionTemporaryUnlocked() => throw new NotImplementedException();
		public virtual void RevertRestrictionTemporaryUnlocked() => throw new NotImplementedException();
		public virtual void EnterRestrictedSystemSettings() => throw new NotImplementedException();
		public virtual void LeaveRestrictedSystemSettings() => throw new NotImplementedException();
		public virtual byte IsRestrictedSystemSettingsEntered() => throw new NotImplementedException();
		public virtual void RevertRestrictedSystemSettingsEntered() => throw new NotImplementedException();
		public virtual uint GetRestrictedFeatures() => throw new NotImplementedException();
		public virtual void ConfirmStereoVisionPermission() => throw new NotImplementedException();
		public virtual object ConfirmPlayableApplicationVideoOld(object _0) => throw new NotImplementedException();
		public virtual object ConfirmPlayableApplicationVideo(object _0) => throw new NotImplementedException();
		public virtual byte IsRestrictionEnabled() => throw new NotImplementedException();
		public virtual uint GetSafetyLevel() => throw new NotImplementedException();
		public virtual void SetSafetyLevel(uint _0) => throw new NotImplementedException();
		public virtual void GetSafetyLevelSettings(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void GetCurrentSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetCustomSafetyLevelSettings(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetDefaultRatingOrganization() => throw new NotImplementedException();
		public virtual void SetDefaultRatingOrganization(uint _0) => throw new NotImplementedException();
		public virtual uint GetFreeCommunicationApplicationListCount() => throw new NotImplementedException();
		public virtual void AddToFreeCommunicationApplicationList(ulong _0) => throw new NotImplementedException();
		public virtual void DeleteSettings() => throw new NotImplementedException();
		public virtual void GetFreeCommunicationApplicationList(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void UpdateFreeCommunicationApplicationList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void DisableFeaturesForReset() => throw new NotImplementedException();
		public virtual void NotifyApplicationDownloadStarted(ulong _0) => throw new NotImplementedException();
		public virtual void ConfirmStereoVisionRestrictionConfigurable() => throw new NotImplementedException();
		public virtual byte GetStereoVisionRestriction() => throw new NotImplementedException();
		public virtual void SetStereoVisionRestriction(byte _0) => throw new NotImplementedException();
		public virtual object ResetConfirmedStereoVisionPermission(object _0) => throw new NotImplementedException();
		public virtual object IsStereoVisionPermitted(object _0) => throw new NotImplementedException();
		public virtual void UnlockRestrictionTemporarily(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void UnlockSystemSettingsRestriction(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetPinCode(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GenerateInquiryCode(out byte[] _0) => throw new NotImplementedException();
		public virtual byte CheckMasterKey(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetPinCodeLength() => throw new NotImplementedException();
		public virtual KObject GetPinCodeChangedEvent() => throw new NotImplementedException();
		public virtual void GetPinCode(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual byte IsPairingActive() => throw new NotImplementedException();
		public virtual ulong GetSettingsLastUpdated() => throw new NotImplementedException();
		public virtual void GetPairingAccountInfo(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void GetAccountNickname(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual uint GetAccountState(byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetSynchronizationEvent() => throw new NotImplementedException();
		public virtual void StartPlayTimer() => throw new NotImplementedException();
		public virtual void StopPlayTimer() => throw new NotImplementedException();
		public virtual byte IsPlayTimerEnabled() => throw new NotImplementedException();
		public virtual ulong GetPlayTimerRemainingTime() => throw new NotImplementedException();
		public virtual byte IsRestrictedByPlayTimer() => throw new NotImplementedException();
		public virtual void GetPlayTimerSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetPlayTimerEventToRequestSuspension() => throw new NotImplementedException();
		public virtual byte IsPlayTimerAlarmDisabled() => throw new NotImplementedException();
		public virtual void NotifyWrongPinCodeInputManyTimes() => throw new NotImplementedException();
		public virtual void CancelNetworkRequest() => throw new NotImplementedException();
		public virtual KObject GetUnlinkedEvent() => throw new NotImplementedException();
		public virtual void ClearUnlinkedEvent() => throw new NotImplementedException();
		public virtual byte DisableAllFeatures() => throw new NotImplementedException();
		public virtual byte PostEnableAllFeatures() => throw new NotImplementedException();
		public virtual void IsAllFeaturesDisabled(out byte _0, out byte _1) => throw new NotImplementedException();
		public virtual void DeleteFromFreeCommunicationApplicationListForDebug(ulong _0) => throw new NotImplementedException();
		public virtual void ClearFreeCommunicationApplicationListForDebug() => throw new NotImplementedException();
		public virtual object GetExemptApplicationListCountForDebug(object _0) => throw new NotImplementedException();
		public virtual object GetExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object UpdateExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object AddToExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object DeleteFromExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object ClearExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual void DeletePairing() => throw new NotImplementedException();
		public virtual void SetPlayTimerSettingsForDebug(byte[] _0) => throw new NotImplementedException();
		public virtual ulong GetPlayTimerSpentTimeForTest() => throw new NotImplementedException();
		public virtual void SetPlayTimerAlarmDisabledForDebug(byte _0) => throw new NotImplementedException();
		public virtual void RequestPairingAsync(Buffer<byte> _0, out byte[] _1, out KObject _2) => throw new NotImplementedException();
		public virtual void FinishRequestPairing(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void AuthorizePairingAsync(byte[] _0, out byte[] _1, out KObject _2) => throw new NotImplementedException();
		public virtual void FinishAuthorizePairing(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void RetrievePairingInfoAsync(out byte[] _0, out KObject _1) => throw new NotImplementedException();
		public virtual void FinishRetrievePairingInfo(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void UnlinkPairingAsync(byte _0, out byte[] _1, out KObject _2) => throw new NotImplementedException();
		public virtual void FinishUnlinkPairing(byte _0, byte[] _1) => throw new NotImplementedException();
		public virtual void GetAccountMiiImageAsync(byte[] _0, out byte[] _1, out uint _2, out KObject _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void FinishGetAccountMiiImage(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetAccountMiiImageContentTypeAsync(byte[] _0, out byte[] _1, out uint _2, out KObject _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void FinishGetAccountMiiImageContentType(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SynchronizeParentalControlSettingsAsync(out byte[] _0, out KObject _1) => throw new NotImplementedException();
		public virtual void FinishSynchronizeParentalControlSettings(byte[] _0) => throw new NotImplementedException();
		public virtual ulong FinishSynchronizeParentalControlSettingsWithLastUpdated(byte[] _0) => throw new NotImplementedException();
		public virtual object RequestUpdateExemptionListAsync(object _0) => throw new NotImplementedException();
	}
}
