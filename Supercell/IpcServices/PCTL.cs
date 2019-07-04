using System;

namespace Supercell.IpcServices.nn.pctl.detail.ipc {
	[IpcService("pctl:a")]
	[IpcService("pctl:s")]
	[IpcService("pctl:r")]
	[IpcService("pctl")]
	public class IParentalControlServiceFactory : IpcInterface {
		[IpcCommand(0)]
		void CreateService(ulong unknown0, [Pid] ulong pid, [Move] out IParentalControlService service) =>
			service = new IParentalControlService();

		[IpcCommand(1)]
		void CreateServiceWithoutInitialize(ulong unknown0, [Pid] ulong pid,
			[Move] out IParentalControlService service) =>
			service = new IParentalControlService();
	}
	
	public class IParentalControlService : IpcInterface {
		[IpcCommand(1)]
		void Initialize() {}
		[IpcCommand(1001)]
		void CheckFreeCommunicationPermission() {}
		[IpcCommand(1002)]
		void ConfirmLaunchApplicationPermission(bool unknown0, ulong /* nn::ncm::ApplicationId */ unknown1, [Buffer(0x9)] Buffer<sbyte> unknown2) => throw new NotImplementedException();
		[IpcCommand(1003)]
		void ConfirmResumeApplicationPermission(bool unknown0, ulong /* nn::ncm::ApplicationId */ unknown1, [Buffer(0x9)] Buffer<sbyte> unknown2) => throw new NotImplementedException();
		[IpcCommand(1004)]
		void ConfirmSnsPostPermission() {}
		[IpcCommand(1005)]
		void ConfirmSystemSettingsPermission() {}
		[IpcCommand(1006)]
		void IsRestrictionTemporaryUnlocked(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1007)]
		void RevertRestrictionTemporaryUnlocked() {}
		[IpcCommand(1008)]
		void EnterRestrictedSystemSettings() {}
		[IpcCommand(1009)]
		void LeaveRestrictedSystemSettings() {}
		[IpcCommand(1010)]
		void IsRestrictedSystemSettingsEntered(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1011)]
		void RevertRestrictedSystemSettingsEntered() {}
		[IpcCommand(1012)]
		void GetRestrictedFeatures(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1013)]
		void ConfirmStereoVisionPermission() {}
		[IpcCommand(1014)]
		void ConfirmPlayableApplicationVideoOld(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1015)]
		void ConfirmPlayableApplicationVideo(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1031)]
		void IsRestrictionEnabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1032)]
		void GetSafetyLevel(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1033)]
		void SetSafetyLevel(uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1034)]
		void GetSafetyLevelSettings(uint unknown0, [Bytes(0x3 /* 3 x 1 */)] out byte[] /* nn::pctl::RestrictionSettings */ unknown1) => throw new NotImplementedException();
		[IpcCommand(1035)]
		void GetCurrentSettings([Bytes(0x3 /* 3 x 1 */)] out byte[] /* nn::pctl::RestrictionSettings */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1036)]
		void SetCustomSafetyLevelSettings([Bytes(0x3 /* 3 x 1 */)] byte[] /* nn::pctl::RestrictionSettings */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1037)]
		void GetDefaultRatingOrganization(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1038)]
		void SetDefaultRatingOrganization(uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1039)]
		void GetFreeCommunicationApplicationListCount(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1042)]
		void AddToFreeCommunicationApplicationList(ulong /* nn::ncm::ApplicationId */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1043)]
		void DeleteSettings() {}
		[IpcCommand(1044)]
		void GetFreeCommunicationApplicationList(uint unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte /* nn::pctl::FreeCommunicationApplicationInfo */> unknown2) => throw new NotImplementedException();
		[IpcCommand(1045)]
		void UpdateFreeCommunicationApplicationList([Buffer(0x5)] Buffer<byte /* nn::pctl::FreeCommunicationApplicationInfo */> unknown0) => throw new NotImplementedException();
		[IpcCommand(1046)]
		void DisableFeaturesForReset() {}
		[IpcCommand(1047)]
		void NotifyApplicationDownloadStarted(ulong /* nn::ncm::ApplicationId */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1061)]
		void ConfirmStereoVisionRestrictionConfigurable() {}
		[IpcCommand(1062)]
		void GetStereoVisionRestriction(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1063)]
		void SetStereoVisionRestriction(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1064)]
		void ResetConfirmedStereoVisionPermission(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1065)]
		void IsStereoVisionPermitted(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1201)]
		void UnlockRestrictionTemporarily([Buffer(0x9)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(1202)]
		void UnlockSystemSettingsRestriction([Buffer(0x9)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(1203)]
		void SetPinCode([Buffer(0x9)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(1204)]
		void GenerateInquiryCode([Bytes(0x20 /* 32 x 1 */)] out byte[] /* nn::pctl::InquiryCode */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1205)]
		void CheckMasterKey([Bytes(0x20 /* 32 x 1 */)] byte[] /* nn::pctl::InquiryCode */ unknown0, [Buffer(0x9)] Buffer<byte> unknown1, out bool unknown2) => throw new NotImplementedException();
		[IpcCommand(1206)]
		void GetPinCodeLength(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(1207)]
		void GetPinCodeChangedEvent([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(1208)]
		void GetPinCode(out uint unknown0, [Buffer(0xa)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(1403)]
		void IsPairingActive(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1406)]
		void GetSettingsLastUpdated(out ulong /* nn::time::PosixTime */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1411)]
		void GetPairingAccountInfo([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::pctl::detail::PairingInfoBase */ unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] /* nn::pctl::detail::PairingAccountInfoBase */ unknown1) => throw new NotImplementedException();
		[IpcCommand(1421)]
		void GetAccountNickname([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::pctl::detail::PairingAccountInfoBase */ unknown0, out uint unknown1, [Buffer(0xa)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(1424)]
		void GetAccountState([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::pctl::detail::PairingAccountInfoBase */ unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(1432)]
		void GetSynchronizationEvent([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(1451)]
		void StartPlayTimer() {}
		[IpcCommand(1452)]
		void StopPlayTimer() {}
		[IpcCommand(1453)]
		void IsPlayTimerEnabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1454)]
		void GetPlayTimerRemainingTime(out ulong /* nn::TimeMemoryType */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1455)]
		void IsRestrictedByPlayTimer(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1456)]
		void GetPlayTimerSettings([Bytes(0x68 /* 52 x 2 */)] out byte[] /* nn::pctl::PlayTimerSettings */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1457)]
		void GetPlayTimerEventToRequestSuspension([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(1458)]
		void IsPlayTimerAlarmDisabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1471)]
		void NotifyWrongPinCodeInputManyTimes() {}
		[IpcCommand(1472)]
		void CancelNetworkRequest() {}
		[IpcCommand(1473)]
		void GetUnlinkedEvent([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(1474)]
		void ClearUnlinkedEvent() {}
		[IpcCommand(1601)]
		void DisableAllFeatures(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1602)]
		void PostEnableAllFeatures(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(1603)]
		void IsAllFeaturesDisabled(out bool unknown0, out bool unknown1) => throw new NotImplementedException();
		[IpcCommand(1901)]
		void DeleteFromFreeCommunicationApplicationListForDebug(ulong /* nn::ncm::ApplicationId */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1902)]
		void ClearFreeCommunicationApplicationListForDebug() {}
		[IpcCommand(1903)]
		void GetExemptApplicationListCountForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1904)]
		void GetExemptApplicationListForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1905)]
		void UpdateExemptApplicationListForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1906)]
		void AddToExemptApplicationListForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1907)]
		void DeleteFromExemptApplicationListForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1908)]
		void ClearExemptApplicationListForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1941)]
		void DeletePairing() {}
		[IpcCommand(1951)]
		void SetPlayTimerSettingsForDebug([Bytes(0x68 /* 52 x 2 */)] byte[] /* nn::pctl::PlayTimerSettings */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1952)]
		void GetPlayTimerSpentTimeForTest(out ulong /* nn::TimeMemoryType */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1953)]
		void SetPlayTimerAlarmDisabledForDebug(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(2001)]
		void RequestPairingAsync([Buffer(0x9)] Buffer<byte> unknown0, [Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown1, [Move] out KObject unknown2) => throw new NotImplementedException();
		[IpcCommand(2002)]
		void FinishRequestPairing([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] /* nn::pctl::detail::PairingInfoBase */ unknown1) => throw new NotImplementedException();
		[IpcCommand(2003)]
		void AuthorizePairingAsync([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::pctl::detail::PairingInfoBase */ unknown0, [Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown1, [Move] out KObject unknown2) => throw new NotImplementedException();
		[IpcCommand(2004)]
		void FinishAuthorizePairing([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] /* nn::pctl::detail::PairingInfoBase */ unknown1) => throw new NotImplementedException();
		[IpcCommand(2005)]
		void RetrievePairingInfoAsync([Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(2006)]
		void FinishRetrievePairingInfo([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] /* nn::pctl::detail::PairingInfoBase */ unknown1) => throw new NotImplementedException();
		[IpcCommand(2007)]
		void UnlinkPairingAsync(bool unknown0, [Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown1, [Move] out KObject unknown2) => throw new NotImplementedException();
		[IpcCommand(2008)]
		void FinishUnlinkPairing(bool unknown0, [Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown1) => throw new NotImplementedException();
		[IpcCommand(2009)]
		void GetAccountMiiImageAsync([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::pctl::detail::PairingAccountInfoBase */ unknown0, [Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown1, out uint unknown2, [Move] out KObject unknown3, [Buffer(0x6)] Buffer<byte> unknown4) => throw new NotImplementedException();
		[IpcCommand(2010)]
		void FinishGetAccountMiiImage([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(2011)]
		void GetAccountMiiImageContentTypeAsync([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::pctl::detail::PairingAccountInfoBase */ unknown0, [Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown1, out uint unknown2, [Move] out KObject unknown3, [Buffer(0xa)] Buffer<byte> unknown4) => throw new NotImplementedException();
		[IpcCommand(2012)]
		void FinishGetAccountMiiImageContentType([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0, out uint unknown1, [Buffer(0xa)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(2013)]
		void SynchronizeParentalControlSettingsAsync([Bytes(0x20 /* 8 x 4 */)] out byte[] /* nn::pctl::detail::AsyncData */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(2014)]
		void FinishSynchronizeParentalControlSettings([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0) => throw new NotImplementedException();
		[IpcCommand(2015)]
		void FinishSynchronizeParentalControlSettingsWithLastUpdated([Bytes(0x20 /* 8 x 4 */)] byte[] /* nn::pctl::detail::AsyncData */ unknown0, out ulong /* nn::time::PosixTime */ unknown1) => throw new NotImplementedException();
		[IpcCommand(2016)]
		void RequestUpdateExemptionListAsync(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
}