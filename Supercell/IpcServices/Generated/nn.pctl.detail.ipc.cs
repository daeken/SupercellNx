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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateService
					var ret = CreateService(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // CreateServiceWithoutInitialize
					var ret = CreateServiceWithoutInitialize(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Initialize
					Initialize();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1001: { // CheckFreeCommunicationPermission
					CheckFreeCommunicationPermission();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1002: { // ConfirmLaunchApplicationPermission
					ConfirmLaunchApplicationPermission(im.GetData<byte>(8), im.GetData<ulong>(16), im.GetBuffer<sbyte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1003: { // ConfirmResumeApplicationPermission
					ConfirmResumeApplicationPermission(im.GetData<byte>(8), im.GetData<ulong>(16), im.GetBuffer<sbyte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1004: { // ConfirmSnsPostPermission
					ConfirmSnsPostPermission();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1005: { // ConfirmSystemSettingsPermission
					ConfirmSystemSettingsPermission();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1006: { // IsRestrictionTemporaryUnlocked
					var ret = IsRestrictionTemporaryUnlocked();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1007: { // RevertRestrictionTemporaryUnlocked
					RevertRestrictionTemporaryUnlocked();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1008: { // EnterRestrictedSystemSettings
					EnterRestrictedSystemSettings();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1009: { // LeaveRestrictedSystemSettings
					LeaveRestrictedSystemSettings();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1010: { // IsRestrictedSystemSettingsEntered
					var ret = IsRestrictedSystemSettingsEntered();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1011: { // RevertRestrictedSystemSettingsEntered
					RevertRestrictedSystemSettingsEntered();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1012: { // GetRestrictedFeatures
					var ret = GetRestrictedFeatures();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1013: { // ConfirmStereoVisionPermission
					ConfirmStereoVisionPermission();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1014: { // ConfirmPlayableApplicationVideoOld
					var ret = ConfirmPlayableApplicationVideoOld(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1015: { // ConfirmPlayableApplicationVideo
					var ret = ConfirmPlayableApplicationVideo(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1031: { // IsRestrictionEnabled
					var ret = IsRestrictionEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1032: { // GetSafetyLevel
					var ret = GetSafetyLevel();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1033: { // SetSafetyLevel
					SetSafetyLevel(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1034: { // GetSafetyLevelSettings
					GetSafetyLevelSettings(im.GetData<uint>(8), out var _0);
					om.Initialize(0, 0, 3);
					om.SetBytes(8, _0);
					break;
				}
				case 1035: { // GetCurrentSettings
					GetCurrentSettings(out var _0);
					om.Initialize(0, 0, 3);
					om.SetBytes(8, _0);
					break;
				}
				case 1036: { // SetCustomSafetyLevelSettings
					SetCustomSafetyLevelSettings(im.GetBytes(8, 0x3));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1037: { // GetDefaultRatingOrganization
					var ret = GetDefaultRatingOrganization();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1038: { // SetDefaultRatingOrganization
					SetDefaultRatingOrganization(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1039: { // GetFreeCommunicationApplicationListCount
					var ret = GetFreeCommunicationApplicationListCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1042: { // AddToFreeCommunicationApplicationList
					AddToFreeCommunicationApplicationList(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1043: { // DeleteSettings
					DeleteSettings();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1044: { // GetFreeCommunicationApplicationList
					GetFreeCommunicationApplicationList(im.GetData<uint>(8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 1045: { // UpdateFreeCommunicationApplicationList
					UpdateFreeCommunicationApplicationList(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1046: { // DisableFeaturesForReset
					DisableFeaturesForReset();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1047: { // NotifyApplicationDownloadStarted
					NotifyApplicationDownloadStarted(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1061: { // ConfirmStereoVisionRestrictionConfigurable
					ConfirmStereoVisionRestrictionConfigurable();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1062: { // GetStereoVisionRestriction
					var ret = GetStereoVisionRestriction();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1063: { // SetStereoVisionRestriction
					SetStereoVisionRestriction(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1064: { // ResetConfirmedStereoVisionPermission
					var ret = ResetConfirmedStereoVisionPermission(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1065: { // IsStereoVisionPermitted
					var ret = IsStereoVisionPermitted(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1201: { // UnlockRestrictionTemporarily
					UnlockRestrictionTemporarily(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1202: { // UnlockSystemSettingsRestriction
					UnlockSystemSettingsRestriction(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1203: { // SetPinCode
					SetPinCode(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1204: { // GenerateInquiryCode
					GenerateInquiryCode(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 1205: { // CheckMasterKey
					var ret = CheckMasterKey(im.GetBytes(8, 0x20), im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1206: { // GetPinCodeLength
					var ret = GetPinCodeLength();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1207: { // GetPinCodeChangedEvent
					var ret = GetPinCodeChangedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1208: { // GetPinCode
					GetPinCode(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 1403: { // IsPairingActive
					var ret = IsPairingActive();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1406: { // GetSettingsLastUpdated
					var ret = GetSettingsLastUpdated();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 1411: { // GetPairingAccountInfo
					GetPairingAccountInfo(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 1421: { // GetAccountNickname
					GetAccountNickname(im.GetBytes(8, 0x10), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 1424: { // GetAccountState
					var ret = GetAccountState(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1432: { // GetSynchronizationEvent
					var ret = GetSynchronizationEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1451: { // StartPlayTimer
					StartPlayTimer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1452: { // StopPlayTimer
					StopPlayTimer();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1453: { // IsPlayTimerEnabled
					var ret = IsPlayTimerEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1454: { // GetPlayTimerRemainingTime
					var ret = GetPlayTimerRemainingTime();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 1455: { // IsRestrictedByPlayTimer
					var ret = IsRestrictedByPlayTimer();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1456: { // GetPlayTimerSettings
					GetPlayTimerSettings(out var _0);
					om.Initialize(0, 0, 52);
					om.SetBytes(8, _0);
					break;
				}
				case 1457: { // GetPlayTimerEventToRequestSuspension
					var ret = GetPlayTimerEventToRequestSuspension();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1458: { // IsPlayTimerAlarmDisabled
					var ret = IsPlayTimerAlarmDisabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1471: { // NotifyWrongPinCodeInputManyTimes
					NotifyWrongPinCodeInputManyTimes();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1472: { // CancelNetworkRequest
					CancelNetworkRequest();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1473: { // GetUnlinkedEvent
					var ret = GetUnlinkedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1474: { // ClearUnlinkedEvent
					ClearUnlinkedEvent();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1601: { // DisableAllFeatures
					var ret = DisableAllFeatures();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1602: { // PostEnableAllFeatures
					var ret = PostEnableAllFeatures();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 1603: { // IsAllFeaturesDisabled
					IsAllFeaturesDisabled(out var _0, out var _1);
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					om.SetData(9, _1);
					break;
				}
				case 1901: { // DeleteFromFreeCommunicationApplicationListForDebug
					DeleteFromFreeCommunicationApplicationListForDebug(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1902: { // ClearFreeCommunicationApplicationListForDebug
					ClearFreeCommunicationApplicationListForDebug();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1903: { // GetExemptApplicationListCountForDebug
					var ret = GetExemptApplicationListCountForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1904: { // GetExemptApplicationListForDebug
					var ret = GetExemptApplicationListForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1905: { // UpdateExemptApplicationListForDebug
					var ret = UpdateExemptApplicationListForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1906: { // AddToExemptApplicationListForDebug
					var ret = AddToExemptApplicationListForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1907: { // DeleteFromExemptApplicationListForDebug
					var ret = DeleteFromExemptApplicationListForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1908: { // ClearExemptApplicationListForDebug
					var ret = ClearExemptApplicationListForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1941: { // DeletePairing
					DeletePairing();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1951: { // SetPlayTimerSettingsForDebug
					SetPlayTimerSettingsForDebug(im.GetBytes(8, 0x34));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1952: { // GetPlayTimerSpentTimeForTest
					var ret = GetPlayTimerSpentTimeForTest();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 1953: { // SetPlayTimerAlarmDisabledForDebug
					SetPlayTimerAlarmDisabledForDebug(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2001: { // RequestPairingAsync
					RequestPairingAsync(im.GetBuffer<byte>(0x9, 0), out var _0, out var _1);
					om.Initialize(0, 1, 8);
					om.SetBytes(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 2002: { // FinishRequestPairing
					FinishRequestPairing(im.GetBytes(8, 0x8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 2003: { // AuthorizePairingAsync
					AuthorizePairingAsync(im.GetBytes(8, 0x10), out var _0, out var _1);
					om.Initialize(0, 1, 8);
					om.SetBytes(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 2004: { // FinishAuthorizePairing
					FinishAuthorizePairing(im.GetBytes(8, 0x8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 2005: { // RetrievePairingInfoAsync
					RetrievePairingInfoAsync(out var _0, out var _1);
					om.Initialize(0, 1, 8);
					om.SetBytes(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 2006: { // FinishRetrievePairingInfo
					FinishRetrievePairingInfo(im.GetBytes(8, 0x8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 2007: { // UnlinkPairingAsync
					UnlinkPairingAsync(im.GetData<byte>(8), out var _0, out var _1);
					om.Initialize(0, 1, 8);
					om.SetBytes(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 2008: { // FinishUnlinkPairing
					FinishUnlinkPairing(im.GetData<byte>(8), im.GetBytes(9, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2009: { // GetAccountMiiImageAsync
					GetAccountMiiImageAsync(im.GetBytes(8, 0x10), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 1, 12);
					om.SetBytes(8, _0);
					om.SetData(16, _1);
					om.Copy(0, CreateHandle(_2, copy: true));
					break;
				}
				case 2010: { // FinishGetAccountMiiImage
					FinishGetAccountMiiImage(im.GetBytes(8, 0x8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 2011: { // GetAccountMiiImageContentTypeAsync
					GetAccountMiiImageContentTypeAsync(im.GetBytes(8, 0x10), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 1, 12);
					om.SetBytes(8, _0);
					om.SetData(16, _1);
					om.Copy(0, CreateHandle(_2, copy: true));
					break;
				}
				case 2012: { // FinishGetAccountMiiImageContentType
					FinishGetAccountMiiImageContentType(im.GetBytes(8, 0x8), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 2013: { // SynchronizeParentalControlSettingsAsync
					SynchronizeParentalControlSettingsAsync(out var _0, out var _1);
					om.Initialize(0, 1, 8);
					om.SetBytes(8, _0);
					om.Copy(0, CreateHandle(_1, copy: true));
					break;
				}
				case 2014: { // FinishSynchronizeParentalControlSettings
					FinishSynchronizeParentalControlSettings(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2015: { // FinishSynchronizeParentalControlSettingsWithLastUpdated
					var ret = FinishSynchronizeParentalControlSettingsWithLastUpdated(im.GetBytes(8, 0x8));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 2016: { // RequestUpdateExemptionListAsync
					var ret = RequestUpdateExemptionListAsync(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IParentalControlService: {im.CommandId}");
			}
		}
		
		public virtual void Initialize() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.Initialize [1]".Debug();
		public virtual void CheckFreeCommunicationPermission() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.CheckFreeCommunicationPermission [1001]".Debug();
		public virtual void ConfirmLaunchApplicationPermission(byte _0, ulong _1, Buffer<sbyte> _2) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ConfirmLaunchApplicationPermission [1002]".Debug();
		public virtual void ConfirmResumeApplicationPermission(byte _0, ulong _1, Buffer<sbyte> _2) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ConfirmResumeApplicationPermission [1003]".Debug();
		public virtual void ConfirmSnsPostPermission() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ConfirmSnsPostPermission [1004]".Debug();
		public virtual void ConfirmSystemSettingsPermission() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ConfirmSystemSettingsPermission [1005]".Debug();
		public virtual byte IsRestrictionTemporaryUnlocked() => throw new NotImplementedException();
		public virtual void RevertRestrictionTemporaryUnlocked() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.RevertRestrictionTemporaryUnlocked [1007]".Debug();
		public virtual void EnterRestrictedSystemSettings() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.EnterRestrictedSystemSettings [1008]".Debug();
		public virtual void LeaveRestrictedSystemSettings() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.LeaveRestrictedSystemSettings [1009]".Debug();
		public virtual byte IsRestrictedSystemSettingsEntered() => throw new NotImplementedException();
		public virtual void RevertRestrictedSystemSettingsEntered() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.RevertRestrictedSystemSettingsEntered [1011]".Debug();
		public virtual uint GetRestrictedFeatures() => throw new NotImplementedException();
		public virtual void ConfirmStereoVisionPermission() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ConfirmStereoVisionPermission [1013]".Debug();
		public virtual object ConfirmPlayableApplicationVideoOld(object _0) => throw new NotImplementedException();
		public virtual object ConfirmPlayableApplicationVideo(object _0) => throw new NotImplementedException();
		public virtual byte IsRestrictionEnabled() => throw new NotImplementedException();
		public virtual uint GetSafetyLevel() => throw new NotImplementedException();
		public virtual void SetSafetyLevel(uint _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetSafetyLevel [1033]".Debug();
		public virtual void GetSafetyLevelSettings(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void GetCurrentSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetCustomSafetyLevelSettings(byte[] _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetCustomSafetyLevelSettings [1036]".Debug();
		public virtual uint GetDefaultRatingOrganization() => throw new NotImplementedException();
		public virtual void SetDefaultRatingOrganization(uint _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetDefaultRatingOrganization [1038]".Debug();
		public virtual uint GetFreeCommunicationApplicationListCount() => throw new NotImplementedException();
		public virtual void AddToFreeCommunicationApplicationList(ulong _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.AddToFreeCommunicationApplicationList [1042]".Debug();
		public virtual void DeleteSettings() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.DeleteSettings [1043]".Debug();
		public virtual void GetFreeCommunicationApplicationList(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void UpdateFreeCommunicationApplicationList(Buffer<byte> _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.UpdateFreeCommunicationApplicationList [1045]".Debug();
		public virtual void DisableFeaturesForReset() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.DisableFeaturesForReset [1046]".Debug();
		public virtual void NotifyApplicationDownloadStarted(ulong _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.NotifyApplicationDownloadStarted [1047]".Debug();
		public virtual void ConfirmStereoVisionRestrictionConfigurable() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ConfirmStereoVisionRestrictionConfigurable [1061]".Debug();
		public virtual byte GetStereoVisionRestriction() => throw new NotImplementedException();
		public virtual void SetStereoVisionRestriction(byte _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetStereoVisionRestriction [1063]".Debug();
		public virtual object ResetConfirmedStereoVisionPermission(object _0) => throw new NotImplementedException();
		public virtual object IsStereoVisionPermitted(object _0) => throw new NotImplementedException();
		public virtual void UnlockRestrictionTemporarily(Buffer<byte> _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.UnlockRestrictionTemporarily [1201]".Debug();
		public virtual void UnlockSystemSettingsRestriction(Buffer<byte> _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.UnlockSystemSettingsRestriction [1202]".Debug();
		public virtual void SetPinCode(Buffer<byte> _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetPinCode [1203]".Debug();
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
		public virtual void StartPlayTimer() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.StartPlayTimer [1451]".Debug();
		public virtual void StopPlayTimer() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.StopPlayTimer [1452]".Debug();
		public virtual byte IsPlayTimerEnabled() => throw new NotImplementedException();
		public virtual ulong GetPlayTimerRemainingTime() => throw new NotImplementedException();
		public virtual byte IsRestrictedByPlayTimer() => throw new NotImplementedException();
		public virtual void GetPlayTimerSettings(out byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetPlayTimerEventToRequestSuspension() => throw new NotImplementedException();
		public virtual byte IsPlayTimerAlarmDisabled() => throw new NotImplementedException();
		public virtual void NotifyWrongPinCodeInputManyTimes() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.NotifyWrongPinCodeInputManyTimes [1471]".Debug();
		public virtual void CancelNetworkRequest() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.CancelNetworkRequest [1472]".Debug();
		public virtual KObject GetUnlinkedEvent() => throw new NotImplementedException();
		public virtual void ClearUnlinkedEvent() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ClearUnlinkedEvent [1474]".Debug();
		public virtual byte DisableAllFeatures() => throw new NotImplementedException();
		public virtual byte PostEnableAllFeatures() => throw new NotImplementedException();
		public virtual void IsAllFeaturesDisabled(out byte _0, out byte _1) => throw new NotImplementedException();
		public virtual void DeleteFromFreeCommunicationApplicationListForDebug(ulong _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.DeleteFromFreeCommunicationApplicationListForDebug [1901]".Debug();
		public virtual void ClearFreeCommunicationApplicationListForDebug() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.ClearFreeCommunicationApplicationListForDebug [1902]".Debug();
		public virtual object GetExemptApplicationListCountForDebug(object _0) => throw new NotImplementedException();
		public virtual object GetExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object UpdateExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object AddToExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object DeleteFromExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual object ClearExemptApplicationListForDebug(object _0) => throw new NotImplementedException();
		public virtual void DeletePairing() => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.DeletePairing [1941]".Debug();
		public virtual void SetPlayTimerSettingsForDebug(byte[] _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetPlayTimerSettingsForDebug [1951]".Debug();
		public virtual ulong GetPlayTimerSpentTimeForTest() => throw new NotImplementedException();
		public virtual void SetPlayTimerAlarmDisabledForDebug(byte _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.SetPlayTimerAlarmDisabledForDebug [1953]".Debug();
		public virtual void RequestPairingAsync(Buffer<byte> _0, out byte[] _1, out KObject _2) => throw new NotImplementedException();
		public virtual void FinishRequestPairing(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void AuthorizePairingAsync(byte[] _0, out byte[] _1, out KObject _2) => throw new NotImplementedException();
		public virtual void FinishAuthorizePairing(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void RetrievePairingInfoAsync(out byte[] _0, out KObject _1) => throw new NotImplementedException();
		public virtual void FinishRetrievePairingInfo(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void UnlinkPairingAsync(byte _0, out byte[] _1, out KObject _2) => throw new NotImplementedException();
		public virtual void FinishUnlinkPairing(byte _0, byte[] _1) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.FinishUnlinkPairing [2008]".Debug();
		public virtual void GetAccountMiiImageAsync(byte[] _0, out byte[] _1, out uint _2, out KObject _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void FinishGetAccountMiiImage(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetAccountMiiImageContentTypeAsync(byte[] _0, out byte[] _1, out uint _2, out KObject _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void FinishGetAccountMiiImageContentType(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SynchronizeParentalControlSettingsAsync(out byte[] _0, out KObject _1) => throw new NotImplementedException();
		public virtual void FinishSynchronizeParentalControlSettings(byte[] _0) => "Stub hit for Nn.Pctl.Detail.Ipc.IParentalControlService.FinishSynchronizeParentalControlSettings [2014]".Debug();
		public virtual ulong FinishSynchronizeParentalControlSettingsWithLastUpdated(byte[] _0) => throw new NotImplementedException();
		public virtual object RequestUpdateExemptionListAsync(object _0) => throw new NotImplementedException();
	}
}
