#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ns.Detail {
	[IpcService("ns:am")]
	public unsafe partial class IApplicationManagerInterface : _Base_IApplicationManagerInterface {}
	public unsafe class _Base_IApplicationManagerInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ListApplicationRecord
					ListApplicationRecord(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1: { // GenerateApplicationRecordCount
					var ret = GenerateApplicationRecordCount();
					break;
				}
				case 2: { // GetApplicationRecordUpdateSystemEvent
					var ret = GetApplicationRecordUpdateSystemEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 3: { // GetApplicationViewDeprecated
					GetApplicationViewDeprecated(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // DeleteApplicationEntity
					DeleteApplicationEntity(null);
					break;
				}
				case 5: { // DeleteApplicationCompletely
					DeleteApplicationCompletely(null);
					break;
				}
				case 6: { // IsAnyApplicationEntityRedundant
					var ret = IsAnyApplicationEntityRedundant();
					break;
				}
				case 7: { // DeleteRedundantApplicationEntity
					DeleteRedundantApplicationEntity();
					break;
				}
				case 8: { // IsApplicationEntityMovable
					var ret = IsApplicationEntityMovable(null);
					break;
				}
				case 9: { // MoveApplicationEntity
					MoveApplicationEntity(null);
					break;
				}
				case 11: { // CalculateApplicationOccupiedSize
					var ret = CalculateApplicationOccupiedSize(null);
					break;
				}
				case 16: { // PushApplicationRecord
					PushApplicationRecord(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 17: { // ListApplicationRecordContentMeta
					ListApplicationRecordContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 19: { // LaunchApplication
					var ret = LaunchApplication(null);
					break;
				}
				case 21: { // GetApplicationContentPath
					GetApplicationContentPath(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 22: { // TerminateApplication
					TerminateApplication(null);
					break;
				}
				case 23: { // ResolveApplicationContentPath
					ResolveApplicationContentPath(null);
					break;
				}
				case 26: { // BeginInstallApplication
					BeginInstallApplication(null);
					break;
				}
				case 27: { // DeleteApplicationRecord
					DeleteApplicationRecord(null);
					break;
				}
				case 30: { // RequestApplicationUpdateInfo
					RequestApplicationUpdateInfo(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 32: { // CancelApplicationDownload
					CancelApplicationDownload(null);
					break;
				}
				case 33: { // ResumeApplicationDownload
					ResumeApplicationDownload(null);
					break;
				}
				case 35: { // UpdateVersionList
					UpdateVersionList(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 36: { // PushLaunchVersion
					PushLaunchVersion(null);
					break;
				}
				case 37: { // ListRequiredVersion
					ListRequiredVersion(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 38: { // CheckApplicationLaunchVersion
					CheckApplicationLaunchVersion(null);
					break;
				}
				case 39: { // CheckApplicationLaunchRights
					CheckApplicationLaunchRights(null);
					break;
				}
				case 40: { // GetApplicationLogoData
					GetApplicationLogoData(null, im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 41: { // CalculateApplicationDownloadRequiredSize
					var ret = CalculateApplicationDownloadRequiredSize(null);
					break;
				}
				case 42: { // CleanupSdCard
					CleanupSdCard();
					break;
				}
				case 43: { // CheckSdCardMountStatus
					CheckSdCardMountStatus();
					break;
				}
				case 44: { // GetSdCardMountStatusChangedEvent
					var ret = GetSdCardMountStatusChangedEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 45: { // GetGameCardAttachmentEvent
					var ret = GetGameCardAttachmentEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 46: { // GetGameCardAttachmentInfo
					var ret = GetGameCardAttachmentInfo();
					break;
				}
				case 47: { // GetTotalSpaceSize
					var ret = GetTotalSpaceSize(null);
					break;
				}
				case 48: { // GetFreeSpaceSize
					var ret = GetFreeSpaceSize(null);
					break;
				}
				case 49: { // GetSdCardRemovedEvent
					var ret = GetSdCardRemovedEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 52: { // GetGameCardUpdateDetectionEvent
					var ret = GetGameCardUpdateDetectionEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 53: { // DisableApplicationAutoDelete
					DisableApplicationAutoDelete(null);
					break;
				}
				case 54: { // EnableApplicationAutoDelete
					EnableApplicationAutoDelete(null);
					break;
				}
				case 55: { // GetApplicationDesiredLanguage
					var ret = GetApplicationDesiredLanguage(null);
					break;
				}
				case 56: { // SetApplicationTerminateResult
					SetApplicationTerminateResult(null);
					break;
				}
				case 57: { // ClearApplicationTerminateResult
					ClearApplicationTerminateResult(null);
					break;
				}
				case 58: { // GetLastSdCardMountUnexpectedResult
					GetLastSdCardMountUnexpectedResult();
					break;
				}
				case 59: { // ConvertApplicationLanguageToLanguageCode
					var ret = ConvertApplicationLanguageToLanguageCode(null);
					break;
				}
				case 60: { // ConvertLanguageCodeToApplicationLanguage
					var ret = ConvertLanguageCodeToApplicationLanguage(null);
					break;
				}
				case 61: { // GetBackgroundDownloadStressTaskInfo
					var ret = GetBackgroundDownloadStressTaskInfo();
					break;
				}
				case 62: { // GetGameCardStopper
					var ret = GetGameCardStopper();
					om.Move(0, ret.Handle);
					break;
				}
				case 63: { // IsSystemProgramInstalled
					var ret = IsSystemProgramInstalled(null);
					break;
				}
				case 64: { // StartApplyDeltaTask
					StartApplyDeltaTask(null);
					break;
				}
				case 65: { // GetRequestServerStopper
					var ret = GetRequestServerStopper();
					om.Move(0, ret.Handle);
					break;
				}
				case 66: { // GetBackgroundApplyDeltaStressTaskInfo
					var ret = GetBackgroundApplyDeltaStressTaskInfo();
					break;
				}
				case 67: { // CancelApplicationApplyDelta
					CancelApplicationApplyDelta(null);
					break;
				}
				case 68: { // ResumeApplicationApplyDelta
					ResumeApplicationApplyDelta(null);
					break;
				}
				case 69: { // CalculateApplicationApplyDeltaRequiredSize
					var ret = CalculateApplicationApplyDeltaRequiredSize(null);
					break;
				}
				case 70: { // ResumeAll
					ResumeAll();
					break;
				}
				case 71: { // GetStorageSize
					var ret = GetStorageSize(null);
					break;
				}
				case 80: { // RequestDownloadApplication
					RequestDownloadApplication(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 81: { // RequestDownloadAddOnContent
					RequestDownloadAddOnContent(null, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 82: { // DownloadApplication
					DownloadApplication(null);
					break;
				}
				case 83: { // CheckApplicationResumeRights
					CheckApplicationResumeRights(null);
					break;
				}
				case 84: { // GetDynamicCommitEvent
					var ret = GetDynamicCommitEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 85: { // RequestUpdateApplication2
					RequestUpdateApplication2(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 86: { // EnableApplicationCrashReport
					EnableApplicationCrashReport(null);
					break;
				}
				case 87: { // IsApplicationCrashReportEnabled
					var ret = IsApplicationCrashReportEnabled();
					break;
				}
				case 90: { // BoostSystemMemoryResourceLimit
					BoostSystemMemoryResourceLimit(null);
					break;
				}
				case 91: { // Unknown91
					var ret = Unknown91(null);
					break;
				}
				case 92: { // Unknown92
					var ret = Unknown92(null);
					break;
				}
				case 93: { // Unknown93
					var ret = Unknown93(null);
					break;
				}
				case 94: { // LaunchApplication2
					var ret = LaunchApplication2(null);
					break;
				}
				case 95: { // Unknown95
					var ret = Unknown95(null);
					break;
				}
				case 96: { // Unknown96
					var ret = Unknown96(null);
					break;
				}
				case 97: { // Unknown97
					var ret = Unknown97(null);
					break;
				}
				case 98: { // Unknown98
					var ret = Unknown98(null);
					break;
				}
				case 100: { // ResetToFactorySettings
					ResetToFactorySettings();
					break;
				}
				case 101: { // ResetToFactorySettingsWithoutUserSaveData
					ResetToFactorySettingsWithoutUserSaveData();
					break;
				}
				case 102: { // ResetToFactorySettingsForRefurbishment
					ResetToFactorySettingsForRefurbishment();
					break;
				}
				case 200: { // CalculateUserSaveDataStatistics
					var ret = CalculateUserSaveDataStatistics(null);
					break;
				}
				case 201: { // DeleteUserSaveDataAll
					var ret = DeleteUserSaveDataAll(null);
					om.Move(0, ret.Handle);
					break;
				}
				case 210: { // DeleteUserSystemSaveData
					DeleteUserSystemSaveData(null);
					break;
				}
				case 211: { // Unknown211
					var ret = Unknown211(null);
					break;
				}
				case 220: { // UnregisterNetworkServiceAccount
					UnregisterNetworkServiceAccount(null);
					break;
				}
				case 221: { // Unknown221
					var ret = Unknown221(null);
					break;
				}
				case 300: { // GetApplicationShellEvent
					var ret = GetApplicationShellEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 301: { // PopApplicationShellEventInfo
					PopApplicationShellEventInfo(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 302: { // LaunchLibraryApplet
					var ret = LaunchLibraryApplet(null);
					break;
				}
				case 303: { // TerminateLibraryApplet
					TerminateLibraryApplet(null);
					break;
				}
				case 304: { // LaunchSystemApplet
					var ret = LaunchSystemApplet();
					break;
				}
				case 305: { // TerminateSystemApplet
					TerminateSystemApplet(null);
					break;
				}
				case 306: { // LaunchOverlayApplet
					var ret = LaunchOverlayApplet();
					break;
				}
				case 307: { // TerminateOverlayApplet
					TerminateOverlayApplet(null);
					break;
				}
				case 400: { // GetApplicationControlData
					GetApplicationControlData(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 401: { // InvalidateAllApplicationControlCache
					InvalidateAllApplicationControlCache();
					break;
				}
				case 402: { // RequestDownloadApplicationControlData
					RequestDownloadApplicationControlData(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 403: { // GetMaxApplicationControlCacheCount
					var ret = GetMaxApplicationControlCacheCount();
					break;
				}
				case 404: { // InvalidateApplicationControlCache
					InvalidateApplicationControlCache(null);
					break;
				}
				case 405: { // ListApplicationControlCacheEntryInfo
					ListApplicationControlCacheEntryInfo(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 406: { // Unknown406
					var ret = Unknown406(null);
					break;
				}
				case 502: { // RequestCheckGameCardRegistration
					RequestCheckGameCardRegistration(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 503: { // RequestGameCardRegistrationGoldPoint
					RequestGameCardRegistrationGoldPoint(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 504: { // RequestRegisterGameCard
					RequestRegisterGameCard(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 505: { // GetGameCardMountFailureEvent
					var ret = GetGameCardMountFailureEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 506: { // IsGameCardInserted
					var ret = IsGameCardInserted();
					break;
				}
				case 507: { // EnsureGameCardAccess
					EnsureGameCardAccess();
					break;
				}
				case 508: { // GetLastGameCardMountFailureResult
					GetLastGameCardMountFailureResult();
					break;
				}
				case 509: { // ListApplicationIdOnGameCard
					var ret = ListApplicationIdOnGameCard(null);
					break;
				}
				case 600: { // CountApplicationContentMeta
					var ret = CountApplicationContentMeta(null);
					break;
				}
				case 601: { // ListApplicationContentMetaStatus
					ListApplicationContentMetaStatus(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 602: { // ListAvailableAddOnContent
					ListAvailableAddOnContent(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 603: { // GetOwnedApplicationContentMetaStatus
					var ret = GetOwnedApplicationContentMetaStatus(null);
					break;
				}
				case 604: { // RegisterContentsExternalKey
					RegisterContentsExternalKey(null);
					break;
				}
				case 605: { // ListApplicationContentMetaStatusWithRightsCheck
					ListApplicationContentMetaStatusWithRightsCheck(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 606: { // GetContentMetaStorage
					var ret = GetContentMetaStorage(null);
					break;
				}
				case 607: { // Unknown607
					var ret = Unknown607(null);
					break;
				}
				case 700: { // PushDownloadTaskList
					PushDownloadTaskList(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 701: { // ClearTaskStatusList
					ClearTaskStatusList();
					break;
				}
				case 702: { // RequestDownloadTaskList
					RequestDownloadTaskList();
					break;
				}
				case 703: { // RequestEnsureDownloadTask
					RequestEnsureDownloadTask(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 704: { // ListDownloadTaskStatus
					ListDownloadTaskStatus(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 705: { // RequestDownloadTaskListData
					RequestDownloadTaskListData(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 800: { // RequestVersionList
					RequestVersionList();
					break;
				}
				case 801: { // ListVersionList
					ListVersionList(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 802: { // RequestVersionListData
					RequestVersionListData(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 900: { // GetApplicationRecord
					var ret = GetApplicationRecord(null);
					break;
				}
				case 901: { // GetApplicationRecordProperty
					GetApplicationRecordProperty(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 902: { // EnableApplicationAutoUpdate
					EnableApplicationAutoUpdate(null);
					break;
				}
				case 903: { // DisableApplicationAutoUpdate
					DisableApplicationAutoUpdate(null);
					break;
				}
				case 904: { // TouchApplication
					TouchApplication(null);
					break;
				}
				case 905: { // RequestApplicationUpdate
					RequestApplicationUpdate(null);
					break;
				}
				case 906: { // IsApplicationUpdateRequested
					var ret = IsApplicationUpdateRequested(null);
					break;
				}
				case 907: { // WithdrawApplicationUpdateRequest
					WithdrawApplicationUpdateRequest(null);
					break;
				}
				case 908: { // ListApplicationRecordInstalledContentMeta
					ListApplicationRecordInstalledContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 909: { // WithdrawCleanupAddOnContentsWithNoRightsRecommendation
					WithdrawCleanupAddOnContentsWithNoRightsRecommendation(null);
					break;
				}
				case 910: { // Unknown910
					var ret = Unknown910(null);
					break;
				}
				case 911: { // Unknown911
					var ret = Unknown911(null);
					break;
				}
				case 912: { // Unknown912
					var ret = Unknown912(null);
					break;
				}
				case 1000: { // RequestVerifyApplicationDeprecated
					RequestVerifyApplicationDeprecated(null, Kernel.Get<KObject>(im.GetCopy(0)), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 1001: { // CorruptApplicationForDebug
					CorruptApplicationForDebug(null);
					break;
				}
				case 1002: { // RequestVerifyAddOnContentsRights
					RequestVerifyAddOnContentsRights(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 1003: { // RequestVerifyApplication
					var ret = RequestVerifyApplication(null);
					break;
				}
				case 1004: { // CorruptContentForDebug
					var ret = CorruptContentForDebug(null);
					break;
				}
				case 1200: { // NeedsUpdateVulnerability
					var ret = NeedsUpdateVulnerability();
					break;
				}
				case 1300: { // IsAnyApplicationEntityInstalled
					var ret = IsAnyApplicationEntityInstalled(null);
					break;
				}
				case 1301: { // DeleteApplicationContentEntities
					DeleteApplicationContentEntities(null);
					break;
				}
				case 1302: { // CleanupUnrecordedApplicationEntity
					CleanupUnrecordedApplicationEntity(null);
					break;
				}
				case 1303: { // CleanupAddOnContentsWithNoRights
					CleanupAddOnContentsWithNoRights(null);
					break;
				}
				case 1304: { // DeleteApplicationContentEntity
					DeleteApplicationContentEntity(null);
					break;
				}
				case 1308: { // Unknown1308
					var ret = Unknown1308(null);
					break;
				}
				case 1309: { // Unknown1309
					var ret = Unknown1309(null);
					break;
				}
				case 1400: { // PrepareShutdown
					PrepareShutdown();
					break;
				}
				case 1500: { // FormatSdCard
					FormatSdCard();
					break;
				}
				case 1501: { // NeedsSystemUpdateToFormatSdCard
					var ret = NeedsSystemUpdateToFormatSdCard();
					break;
				}
				case 1502: { // GetLastSdCardFormatUnexpectedResult
					GetLastSdCardFormatUnexpectedResult();
					break;
				}
				case 1504: { // InsertSdCard
					InsertSdCard();
					break;
				}
				case 1505: { // RemoveSdCard
					RemoveSdCard();
					break;
				}
				case 1600: { // GetSystemSeedForPseudoDeviceId
					var ret = GetSystemSeedForPseudoDeviceId();
					break;
				}
				case 1601: { // ResetSystemSeedForPseudoDeviceId
					ResetSystemSeedForPseudoDeviceId();
					break;
				}
				case 1700: { // ListApplicationDownloadingContentMeta
					ListApplicationDownloadingContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1701: { // GetApplicationView
					GetApplicationView(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1702: { // GetApplicationDownloadTaskStatus
					var ret = GetApplicationDownloadTaskStatus(null);
					break;
				}
				case 1703: { // GetApplicationViewDownloadErrorContext
					GetApplicationViewDownloadErrorContext(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 1800: { // IsNotificationSetupCompleted
					var ret = IsNotificationSetupCompleted();
					break;
				}
				case 1801: { // GetLastNotificationInfoCount
					var ret = GetLastNotificationInfoCount();
					break;
				}
				case 1802: { // ListLastNotificationInfo
					ListLastNotificationInfo(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1803: { // ListNotificationTask
					ListNotificationTask(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1900: { // IsActiveAccount
					var ret = IsActiveAccount(null);
					break;
				}
				case 1901: { // RequestDownloadApplicationPrepurchasedRights
					RequestDownloadApplicationPrepurchasedRights(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 1902: { // GetApplicationTicketInfo
					var ret = GetApplicationTicketInfo(null);
					break;
				}
				case 2000: { // GetSystemDeliveryInfo
					GetSystemDeliveryInfo(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 2001: { // SelectLatestSystemDeliveryInfo
					var ret = SelectLatestSystemDeliveryInfo(im.GetBuffer<byte>(0x15, 0), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				case 2002: { // VerifyDeliveryProtocolVersion
					VerifyDeliveryProtocolVersion(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				case 2003: { // GetApplicationDeliveryInfo
					GetApplicationDeliveryInfo(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2004: { // HasAllContentsToDeliver
					var ret = HasAllContentsToDeliver(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2005: { // CompareApplicationDeliveryInfo
					var ret = CompareApplicationDeliveryInfo(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				case 2006: { // CanDeliverApplication
					var ret = CanDeliverApplication(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				case 2007: { // ListContentMetaKeyToDeliverApplication
					ListContentMetaKeyToDeliverApplication(null, im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2008: { // NeedsSystemUpdateToDeliverApplication
					var ret = NeedsSystemUpdateToDeliverApplication(im.GetBuffer<byte>(0x15, 0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2009: { // EstimateRequiredSize
					var ret = EstimateRequiredSize(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2010: { // RequestReceiveApplication
					RequestReceiveApplication(null, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 2011: { // CommitReceiveApplication
					CommitReceiveApplication(null);
					break;
				}
				case 2012: { // GetReceiveApplicationProgress
					var ret = GetReceiveApplicationProgress(null);
					break;
				}
				case 2013: { // RequestSendApplication
					RequestSendApplication(null, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 2014: { // GetSendApplicationProgress
					var ret = GetSendApplicationProgress(null);
					break;
				}
				case 2015: { // CompareSystemDeliveryInfo
					var ret = CompareSystemDeliveryInfo(im.GetBuffer<byte>(0x15, 0), im.GetBuffer<byte>(0x15, 1));
					break;
				}
				case 2016: { // ListNotCommittedContentMeta
					ListNotCommittedContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2017: { // CreateDownloadTask
					CreateDownloadTask(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2018: { // Unknown2018
					var ret = Unknown2018(null);
					break;
				}
				case 2050: { // Unknown2050
					var ret = Unknown2050(null);
					break;
				}
				case 2100: { // Unknown2100
					var ret = Unknown2100(null);
					break;
				}
				case 2101: { // Unknown2101
					var ret = Unknown2101(null);
					break;
				}
				case 2150: { // Unknown2150
					var ret = Unknown2150(null);
					break;
				}
				case 2151: { // Unknown2151
					var ret = Unknown2151(null);
					break;
				}
				case 2152: { // Unknown2152
					var ret = Unknown2152(null);
					break;
				}
				case 2153: { // Unknown2153
					var ret = Unknown2153(null);
					break;
				}
				case 2154: { // Unknown2154
					var ret = Unknown2154(null);
					break;
				}
				case 2160: { // Unknown2160
					var ret = Unknown2160(null);
					break;
				}
				case 2161: { // Unknown2161
					var ret = Unknown2161(null);
					break;
				}
				case 2170: { // Unknown2170
					var ret = Unknown2170(null);
					break;
				}
				case 2171: { // Unknown2171
					var ret = Unknown2171(null);
					break;
				}
				case 2180: { // Unknown2180
					var ret = Unknown2180(null);
					break;
				}
				case 2181: { // Unknown2181
					var ret = Unknown2181(null);
					break;
				}
				case 2182: { // Unknown2182
					var ret = Unknown2182(null);
					break;
				}
				case 2190: { // Unknown2190
					var ret = Unknown2190(null);
					break;
				}
				case 2199: { // Unknown2199
					var ret = Unknown2199(null);
					break;
				}
				case 2200: { // Unknown2200
					var ret = Unknown2200(null);
					break;
				}
				case 2201: { // Unknown2201
					var ret = Unknown2201(null);
					break;
				}
				case 2250: { // Unknown2250
					var ret = Unknown2250(null);
					break;
				}
				case 2300: { // Unknown2300
					var ret = Unknown2300(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationManagerInterface: {im.CommandId}");
			}
		}
		
		public virtual void ListApplicationRecord(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GenerateApplicationRecordCount() => throw new NotImplementedException();
		public virtual KObject GetApplicationRecordUpdateSystemEvent() => throw new NotImplementedException();
		public virtual void GetApplicationViewDeprecated(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteApplicationEntity(object _0) => throw new NotImplementedException();
		public virtual void DeleteApplicationCompletely(object _0) => throw new NotImplementedException();
		public virtual object IsAnyApplicationEntityRedundant() => throw new NotImplementedException();
		public virtual void DeleteRedundantApplicationEntity() => throw new NotImplementedException();
		public virtual object IsApplicationEntityMovable(object _0) => throw new NotImplementedException();
		public virtual void MoveApplicationEntity(object _0) => throw new NotImplementedException();
		public virtual object CalculateApplicationOccupiedSize(object _0) => throw new NotImplementedException();
		public virtual void PushApplicationRecord(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ListApplicationRecordContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object LaunchApplication(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationContentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void TerminateApplication(object _0) => throw new NotImplementedException();
		public virtual void ResolveApplicationContentPath(object _0) => throw new NotImplementedException();
		public virtual void BeginInstallApplication(object _0) => throw new NotImplementedException();
		public virtual void DeleteApplicationRecord(object _0) => throw new NotImplementedException();
		public virtual void RequestApplicationUpdateInfo(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void CancelApplicationDownload(object _0) => throw new NotImplementedException();
		public virtual void ResumeApplicationDownload(object _0) => throw new NotImplementedException();
		public virtual void UpdateVersionList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void PushLaunchVersion(object _0) => throw new NotImplementedException();
		public virtual void ListRequiredVersion(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void CheckApplicationLaunchVersion(object _0) => throw new NotImplementedException();
		public virtual void CheckApplicationLaunchRights(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationLogoData(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object CalculateApplicationDownloadRequiredSize(object _0) => throw new NotImplementedException();
		public virtual void CleanupSdCard() => throw new NotImplementedException();
		public virtual void CheckSdCardMountStatus() => throw new NotImplementedException();
		public virtual KObject GetSdCardMountStatusChangedEvent() => throw new NotImplementedException();
		public virtual KObject GetGameCardAttachmentEvent() => throw new NotImplementedException();
		public virtual object GetGameCardAttachmentInfo() => throw new NotImplementedException();
		public virtual object GetTotalSpaceSize(object _0) => throw new NotImplementedException();
		public virtual object GetFreeSpaceSize(object _0) => throw new NotImplementedException();
		public virtual KObject GetSdCardRemovedEvent() => throw new NotImplementedException();
		public virtual KObject GetGameCardUpdateDetectionEvent() => throw new NotImplementedException();
		public virtual void DisableApplicationAutoDelete(object _0) => throw new NotImplementedException();
		public virtual void EnableApplicationAutoDelete(object _0) => throw new NotImplementedException();
		public virtual object GetApplicationDesiredLanguage(object _0) => throw new NotImplementedException();
		public virtual void SetApplicationTerminateResult(object _0) => throw new NotImplementedException();
		public virtual void ClearApplicationTerminateResult(object _0) => throw new NotImplementedException();
		public virtual void GetLastSdCardMountUnexpectedResult() => throw new NotImplementedException();
		public virtual object ConvertApplicationLanguageToLanguageCode(object _0) => throw new NotImplementedException();
		public virtual object ConvertLanguageCodeToApplicationLanguage(object _0) => throw new NotImplementedException();
		public virtual object GetBackgroundDownloadStressTaskInfo() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IGameCardStopper GetGameCardStopper() => throw new NotImplementedException();
		public virtual object IsSystemProgramInstalled(object _0) => throw new NotImplementedException();
		public virtual void StartApplyDeltaTask(object _0) => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IRequestServerStopper GetRequestServerStopper() => throw new NotImplementedException();
		public virtual object GetBackgroundApplyDeltaStressTaskInfo() => throw new NotImplementedException();
		public virtual void CancelApplicationApplyDelta(object _0) => throw new NotImplementedException();
		public virtual void ResumeApplicationApplyDelta(object _0) => throw new NotImplementedException();
		public virtual object CalculateApplicationApplyDeltaRequiredSize(object _0) => throw new NotImplementedException();
		public virtual void ResumeAll() => throw new NotImplementedException();
		public virtual object GetStorageSize(object _0) => throw new NotImplementedException();
		public virtual void RequestDownloadApplication(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestDownloadAddOnContent(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual void DownloadApplication(object _0) => throw new NotImplementedException();
		public virtual void CheckApplicationResumeRights(object _0) => throw new NotImplementedException();
		public virtual KObject GetDynamicCommitEvent() => throw new NotImplementedException();
		public virtual void RequestUpdateApplication2(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void EnableApplicationCrashReport(object _0) => throw new NotImplementedException();
		public virtual object IsApplicationCrashReportEnabled() => throw new NotImplementedException();
		public virtual void BoostSystemMemoryResourceLimit(object _0) => throw new NotImplementedException();
		public virtual object Unknown91(object _0) => throw new NotImplementedException();
		public virtual object Unknown92(object _0) => throw new NotImplementedException();
		public virtual object Unknown93(object _0) => throw new NotImplementedException();
		public virtual object LaunchApplication2(object _0) => throw new NotImplementedException();
		public virtual object Unknown95(object _0) => throw new NotImplementedException();
		public virtual object Unknown96(object _0) => throw new NotImplementedException();
		public virtual object Unknown97(object _0) => throw new NotImplementedException();
		public virtual object Unknown98(object _0) => throw new NotImplementedException();
		public virtual void ResetToFactorySettings() => throw new NotImplementedException();
		public virtual void ResetToFactorySettingsWithoutUserSaveData() => throw new NotImplementedException();
		public virtual void ResetToFactorySettingsForRefurbishment() => throw new NotImplementedException();
		public virtual object CalculateUserSaveDataStatistics(object _0) => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IProgressMonitorForDeleteUserSaveDataAll DeleteUserSaveDataAll(object _0) => throw new NotImplementedException();
		public virtual void DeleteUserSystemSaveData(object _0) => throw new NotImplementedException();
		public virtual object Unknown211(object _0) => throw new NotImplementedException();
		public virtual void UnregisterNetworkServiceAccount(object _0) => throw new NotImplementedException();
		public virtual object Unknown221(object _0) => throw new NotImplementedException();
		public virtual KObject GetApplicationShellEvent() => throw new NotImplementedException();
		public virtual void PopApplicationShellEventInfo(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object LaunchLibraryApplet(object _0) => throw new NotImplementedException();
		public virtual void TerminateLibraryApplet(object _0) => throw new NotImplementedException();
		public virtual object LaunchSystemApplet() => throw new NotImplementedException();
		public virtual void TerminateSystemApplet(object _0) => throw new NotImplementedException();
		public virtual object LaunchOverlayApplet() => throw new NotImplementedException();
		public virtual void TerminateOverlayApplet(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationControlData(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void InvalidateAllApplicationControlCache() => throw new NotImplementedException();
		public virtual void RequestDownloadApplicationControlData(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object GetMaxApplicationControlCacheCount() => throw new NotImplementedException();
		public virtual void InvalidateApplicationControlCache(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationControlCacheEntryInfo(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown406(object _0) => throw new NotImplementedException();
		public virtual void RequestCheckGameCardRegistration(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestGameCardRegistrationGoldPoint(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void RequestRegisterGameCard(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual KObject GetGameCardMountFailureEvent() => throw new NotImplementedException();
		public virtual object IsGameCardInserted() => throw new NotImplementedException();
		public virtual void EnsureGameCardAccess() => throw new NotImplementedException();
		public virtual void GetLastGameCardMountFailureResult() => throw new NotImplementedException();
		public virtual object ListApplicationIdOnGameCard(object _0) => throw new NotImplementedException();
		public virtual object CountApplicationContentMeta(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatus(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ListAvailableAddOnContent(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetOwnedApplicationContentMetaStatus(object _0) => throw new NotImplementedException();
		public virtual void RegisterContentsExternalKey(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatusWithRightsCheck(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetContentMetaStorage(object _0) => throw new NotImplementedException();
		public virtual object Unknown607(object _0) => throw new NotImplementedException();
		public virtual void PushDownloadTaskList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ClearTaskStatusList() => throw new NotImplementedException();
		public virtual void RequestDownloadTaskList() => throw new NotImplementedException();
		public virtual void RequestEnsureDownloadTask(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void ListDownloadTaskStatus(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestDownloadTaskListData(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void RequestVersionList() => throw new NotImplementedException();
		public virtual void ListVersionList(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestVersionListData(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual object GetApplicationRecord(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationRecordProperty(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void EnableApplicationAutoUpdate(object _0) => throw new NotImplementedException();
		public virtual void DisableApplicationAutoUpdate(object _0) => throw new NotImplementedException();
		public virtual void TouchApplication(object _0) => throw new NotImplementedException();
		public virtual void RequestApplicationUpdate(object _0) => throw new NotImplementedException();
		public virtual object IsApplicationUpdateRequested(object _0) => throw new NotImplementedException();
		public virtual void WithdrawApplicationUpdateRequest(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationRecordInstalledContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void WithdrawCleanupAddOnContentsWithNoRightsRecommendation(object _0) => throw new NotImplementedException();
		public virtual object Unknown910(object _0) => throw new NotImplementedException();
		public virtual object Unknown911(object _0) => throw new NotImplementedException();
		public virtual object Unknown912(object _0) => throw new NotImplementedException();
		public virtual void RequestVerifyApplicationDeprecated(object _0, KObject _1, out KObject _2, out Nn.Ns.Detail.IProgressAsyncResult _3) => throw new NotImplementedException();
		public virtual void CorruptApplicationForDebug(object _0) => throw new NotImplementedException();
		public virtual void RequestVerifyAddOnContentsRights(object _0, out KObject _1, out Nn.Ns.Detail.IProgressAsyncResult _2) => throw new NotImplementedException();
		public virtual object RequestVerifyApplication(object _0) => throw new NotImplementedException();
		public virtual object CorruptContentForDebug(object _0) => throw new NotImplementedException();
		public virtual object NeedsUpdateVulnerability() => throw new NotImplementedException();
		public virtual object IsAnyApplicationEntityInstalled(object _0) => throw new NotImplementedException();
		public virtual void DeleteApplicationContentEntities(object _0) => throw new NotImplementedException();
		public virtual void CleanupUnrecordedApplicationEntity(object _0) => throw new NotImplementedException();
		public virtual void CleanupAddOnContentsWithNoRights(object _0) => throw new NotImplementedException();
		public virtual void DeleteApplicationContentEntity(object _0) => throw new NotImplementedException();
		public virtual object Unknown1308(object _0) => throw new NotImplementedException();
		public virtual object Unknown1309(object _0) => throw new NotImplementedException();
		public virtual void PrepareShutdown() => throw new NotImplementedException();
		public virtual void FormatSdCard() => throw new NotImplementedException();
		public virtual object NeedsSystemUpdateToFormatSdCard() => throw new NotImplementedException();
		public virtual void GetLastSdCardFormatUnexpectedResult() => throw new NotImplementedException();
		public virtual void InsertSdCard() => throw new NotImplementedException();
		public virtual void RemoveSdCard() => throw new NotImplementedException();
		public virtual object GetSystemSeedForPseudoDeviceId() => throw new NotImplementedException();
		public virtual void ResetSystemSeedForPseudoDeviceId() => throw new NotImplementedException();
		public virtual void ListApplicationDownloadingContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetApplicationView(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object GetApplicationDownloadTaskStatus(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationViewDownloadErrorContext(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object IsNotificationSetupCompleted() => throw new NotImplementedException();
		public virtual object GetLastNotificationInfoCount() => throw new NotImplementedException();
		public virtual void ListLastNotificationInfo(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ListNotificationTask(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object IsActiveAccount(object _0) => throw new NotImplementedException();
		public virtual void RequestDownloadApplicationPrepurchasedRights(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object GetApplicationTicketInfo(object _0) => throw new NotImplementedException();
		public virtual void GetSystemDeliveryInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object SelectLatestSystemDeliveryInfo(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void VerifyDeliveryProtocolVersion(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetApplicationDeliveryInfo(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object HasAllContentsToDeliver(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object CompareApplicationDeliveryInfo(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object CanDeliverApplication(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ListContentMetaKeyToDeliverApplication(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object NeedsSystemUpdateToDeliverApplication(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object EstimateRequiredSize(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void RequestReceiveApplication(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual void CommitReceiveApplication(object _0) => throw new NotImplementedException();
		public virtual object GetReceiveApplicationProgress(object _0) => throw new NotImplementedException();
		public virtual void RequestSendApplication(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual object GetSendApplicationProgress(object _0) => throw new NotImplementedException();
		public virtual object CompareSystemDeliveryInfo(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ListNotCommittedContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void CreateDownloadTask(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown2018(object _0) => throw new NotImplementedException();
		public virtual object Unknown2050(object _0) => throw new NotImplementedException();
		public virtual object Unknown2100(object _0) => throw new NotImplementedException();
		public virtual object Unknown2101(object _0) => throw new NotImplementedException();
		public virtual object Unknown2150(object _0) => throw new NotImplementedException();
		public virtual object Unknown2151(object _0) => throw new NotImplementedException();
		public virtual object Unknown2152(object _0) => throw new NotImplementedException();
		public virtual object Unknown2153(object _0) => throw new NotImplementedException();
		public virtual object Unknown2154(object _0) => throw new NotImplementedException();
		public virtual object Unknown2160(object _0) => throw new NotImplementedException();
		public virtual object Unknown2161(object _0) => throw new NotImplementedException();
		public virtual object Unknown2170(object _0) => throw new NotImplementedException();
		public virtual object Unknown2171(object _0) => throw new NotImplementedException();
		public virtual object Unknown2180(object _0) => throw new NotImplementedException();
		public virtual object Unknown2181(object _0) => throw new NotImplementedException();
		public virtual object Unknown2182(object _0) => throw new NotImplementedException();
		public virtual object Unknown2190(object _0) => throw new NotImplementedException();
		public virtual object Unknown2199(object _0) => throw new NotImplementedException();
		public virtual object Unknown2200(object _0) => throw new NotImplementedException();
		public virtual object Unknown2201(object _0) => throw new NotImplementedException();
		public virtual object Unknown2250(object _0) => throw new NotImplementedException();
		public virtual object Unknown2300(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("ns:dev")]
	public unsafe partial class IDevelopInterface : _Base_IDevelopInterface {}
	public unsafe class _Base_IDevelopInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // LaunchProgram
					var ret = LaunchProgram(null);
					break;
				}
				case 1: { // TerminateProcess
					TerminateProcess(null);
					break;
				}
				case 2: { // TerminateProgram
					TerminateProgram(null);
					break;
				}
				case 4: { // GetShellEventHandle
					var ret = GetShellEventHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // GetShellEventInfo
					var ret = GetShellEventInfo();
					break;
				}
				case 6: { // TerminateApplication
					TerminateApplication();
					break;
				}
				case 7: { // PrepareLaunchProgramFromHost
					var ret = PrepareLaunchProgramFromHost(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 8: { // LaunchApplication
					var ret = LaunchApplication(null);
					break;
				}
				case 9: { // LaunchApplicationWithStorageId
					var ret = LaunchApplicationWithStorageId(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDevelopInterface: {im.CommandId}");
			}
		}
		
		public virtual object LaunchProgram(object _0) => throw new NotImplementedException();
		public virtual void TerminateProcess(object _0) => throw new NotImplementedException();
		public virtual void TerminateProgram(object _0) => throw new NotImplementedException();
		public virtual KObject GetShellEventHandle() => throw new NotImplementedException();
		public virtual object GetShellEventInfo() => throw new NotImplementedException();
		public virtual void TerminateApplication() => throw new NotImplementedException();
		public virtual object PrepareLaunchProgramFromHost(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object LaunchApplication(object _0) => throw new NotImplementedException();
		public virtual object LaunchApplicationWithStorageId(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("ns:am2")]
	[IpcService("ns:ec")]
	[IpcService("ns:rid")]
	[IpcService("ns:rt")]
	[IpcService("ns:web")]
	public unsafe partial class IServiceGetterInterface : _Base_IServiceGetterInterface {}
	public unsafe class _Base_IServiceGetterInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 7992: { // GetECommerceInterface
					var ret = GetECommerceInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7993: { // GetApplicationVersionInterface
					var ret = GetApplicationVersionInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7994: { // GetFactoryResetInterface
					var ret = GetFactoryResetInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7995: { // GetAccountProxyInterface
					var ret = GetAccountProxyInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7996: { // GetApplicationManagerInterface
					var ret = GetApplicationManagerInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7997: { // GetDownloadTaskInterface
					var ret = GetDownloadTaskInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7998: { // GetContentManagementInterface
					var ret = GetContentManagementInterface();
					om.Move(0, ret.Handle);
					break;
				}
				case 7999: { // GetDocumentInterface
					var ret = GetDocumentInterface();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IServiceGetterInterface: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ns.Detail.IECommerceInterface GetECommerceInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IApplicationVersionInterface GetApplicationVersionInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IFactoryResetInterface GetFactoryResetInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IAccountProxyInterface GetAccountProxyInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IApplicationManagerInterface GetApplicationManagerInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IDownloadTaskInterface GetDownloadTaskInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IContentManagementInterface GetContentManagementInterface() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IDocumentInterface GetDocumentInterface() => throw new NotImplementedException();
	}
	
	[IpcService("ns:su")]
	public unsafe partial class ISystemUpdateInterface : _Base_ISystemUpdateInterface {}
	public unsafe class _Base_ISystemUpdateInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetBackgroundNetworkUpdateState
					var ret = GetBackgroundNetworkUpdateState();
					break;
				}
				case 1: { // OpenSystemUpdateControl
					var ret = OpenSystemUpdateControl();
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // NotifyExFatDriverRequired
					NotifyExFatDriverRequired();
					break;
				}
				case 3: { // ClearExFatDriverStatusForDebug
					ClearExFatDriverStatusForDebug();
					break;
				}
				case 4: { // RequestBackgroundNetworkUpdate
					RequestBackgroundNetworkUpdate();
					break;
				}
				case 5: { // NotifyBackgroundNetworkUpdate
					NotifyBackgroundNetworkUpdate(null);
					break;
				}
				case 6: { // NotifyExFatDriverDownloadedForDebug
					NotifyExFatDriverDownloadedForDebug();
					break;
				}
				case 9: { // GetSystemUpdateNotificationEventForContentDelivery
					var ret = GetSystemUpdateNotificationEventForContentDelivery();
					om.Copy(0, ret.Handle);
					break;
				}
				case 10: { // NotifySystemUpdateForContentDelivery
					NotifySystemUpdateForContentDelivery();
					break;
				}
				case 11: { // PrepareShutdown
					PrepareShutdown();
					break;
				}
				case 16: { // DestroySystemUpdateTask
					DestroySystemUpdateTask();
					break;
				}
				case 17: { // RequestSendSystemUpdate
					RequestSendSystemUpdate(null, im.GetBuffer<byte>(0x15, 0), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 18: { // GetSendSystemUpdateProgress
					var ret = GetSendSystemUpdateProgress();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemUpdateInterface: {im.CommandId}");
			}
		}
		
		public virtual object GetBackgroundNetworkUpdateState() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.ISystemUpdateControl OpenSystemUpdateControl() => throw new NotImplementedException();
		public virtual void NotifyExFatDriverRequired() => throw new NotImplementedException();
		public virtual void ClearExFatDriverStatusForDebug() => throw new NotImplementedException();
		public virtual void RequestBackgroundNetworkUpdate() => throw new NotImplementedException();
		public virtual void NotifyBackgroundNetworkUpdate(object _0) => throw new NotImplementedException();
		public virtual void NotifyExFatDriverDownloadedForDebug() => throw new NotImplementedException();
		public virtual KObject GetSystemUpdateNotificationEventForContentDelivery() => throw new NotImplementedException();
		public virtual void NotifySystemUpdateForContentDelivery() => throw new NotImplementedException();
		public virtual void PrepareShutdown() => throw new NotImplementedException();
		public virtual void DestroySystemUpdateTask() => throw new NotImplementedException();
		public virtual void RequestSendSystemUpdate(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual object GetSendSystemUpdateProgress() => throw new NotImplementedException();
	}
	
	[IpcService("ns:vm")]
	public unsafe partial class IVulnerabilityManagerInterface : _Base_IVulnerabilityManagerInterface {}
	public unsafe class _Base_IVulnerabilityManagerInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1200: { // NeedsUpdateVulnerability
					var ret = NeedsUpdateVulnerability();
					break;
				}
				case 1201: { // UpdateSafeSystemVersionForDebug
					UpdateSafeSystemVersionForDebug(null);
					break;
				}
				case 1202: { // GetSafeSystemVersion
					var ret = GetSafeSystemVersion();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IVulnerabilityManagerInterface: {im.CommandId}");
			}
		}
		
		public virtual object NeedsUpdateVulnerability() => throw new NotImplementedException();
		public virtual void UpdateSafeSystemVersionForDebug(object _0) => throw new NotImplementedException();
		public virtual object GetSafeSystemVersion() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAccountProxyInterface : _Base_IAccountProxyInterface {}
	public unsafe class _Base_IAccountProxyInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateUserAccount
					CreateUserAccount(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAccountProxyInterface: {im.CommandId}");
			}
		}
		
		public virtual void CreateUserAccount(object _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IApplicationVersionInterface : _Base_IApplicationVersionInterface {}
	public unsafe class _Base_IApplicationVersionInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					break;
				}
				case 35: { // Unknown35
					Unknown35(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 36: { // Unknown36
					Unknown36(null);
					break;
				}
				case 37: { // Unknown37
					Unknown37(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 800: { // Unknown800
					Unknown800();
					break;
				}
				case 801: { // Unknown801
					Unknown801(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 802: { // Unknown802
					Unknown802(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 1000: { // Unknown1000
					Unknown1000();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationVersionInterface: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0) => throw new NotImplementedException();
		public virtual void Unknown35(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown36(object _0) => throw new NotImplementedException();
		public virtual void Unknown37(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown800() => throw new NotImplementedException();
		public virtual void Unknown801(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown802(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void Unknown1000() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAsyncResult : _Base_IAsyncResult {}
	public unsafe class _Base_IAsyncResult : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncResult: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAsyncValue : _Base_IAsyncValue {}
	public unsafe class _Base_IAsyncValue : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncValue: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IContentManagementInterface : _Base_IContentManagementInterface {}
	public unsafe class _Base_IContentManagementInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 11: { // CalculateApplicationOccupiedSize
					var ret = CalculateApplicationOccupiedSize(null);
					break;
				}
				case 43: { // CheckSdCardMountStatus
					CheckSdCardMountStatus();
					break;
				}
				case 47: { // GetTotalSpaceSize
					var ret = GetTotalSpaceSize(null);
					break;
				}
				case 48: { // GetFreeSpaceSize
					var ret = GetFreeSpaceSize(null);
					break;
				}
				case 600: { // CountApplicationContentMeta
					var ret = CountApplicationContentMeta(null);
					break;
				}
				case 601: { // ListApplicationContentMetaStatus
					ListApplicationContentMetaStatus(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 605: { // ListApplicationContentMetaStatusWithRightsCheck
					ListApplicationContentMetaStatusWithRightsCheck(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 607: { // IsAnyApplicationRunning
					var ret = IsAnyApplicationRunning();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContentManagementInterface: {im.CommandId}");
			}
		}
		
		public virtual object CalculateApplicationOccupiedSize(object _0) => throw new NotImplementedException();
		public virtual void CheckSdCardMountStatus() => throw new NotImplementedException();
		public virtual object GetTotalSpaceSize(object _0) => throw new NotImplementedException();
		public virtual object GetFreeSpaceSize(object _0) => throw new NotImplementedException();
		public virtual object CountApplicationContentMeta(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatus(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatusWithRightsCheck(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object IsAnyApplicationRunning() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDocumentInterface : _Base_IDocumentInterface {}
	public unsafe class _Base_IDocumentInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 21: { // GetApplicationContentPath
					GetApplicationContentPath(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 23: { // ResolveApplicationContentPath
					ResolveApplicationContentPath(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDocumentInterface: {im.CommandId}");
			}
		}
		
		public virtual void GetApplicationContentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveApplicationContentPath(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDownloadTaskInterface : _Base_IDownloadTaskInterface {}
	public unsafe class _Base_IDownloadTaskInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 701: { // ClearTaskStatusList
					ClearTaskStatusList();
					break;
				}
				case 702: { // RequestDownloadTaskList
					RequestDownloadTaskList();
					break;
				}
				case 703: { // RequestEnsureDownloadTask
					RequestEnsureDownloadTask(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 704: { // ListDownloadTaskStatus
					ListDownloadTaskStatus(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 705: { // RequestDownloadTaskListData
					RequestDownloadTaskListData(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 706: { // TryCommitCurrentApplicationDownloadTask
					TryCommitCurrentApplicationDownloadTask();
					break;
				}
				case 707: { // EnableAutoCommit
					EnableAutoCommit();
					break;
				}
				case 708: { // DisableAutoCommit
					DisableAutoCommit();
					break;
				}
				case 709: { // TriggerDynamicCommitEvent
					TriggerDynamicCommitEvent();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDownloadTaskInterface: {im.CommandId}");
			}
		}
		
		public virtual void ClearTaskStatusList() => throw new NotImplementedException();
		public virtual void RequestDownloadTaskList() => throw new NotImplementedException();
		public virtual void RequestEnsureDownloadTask(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void ListDownloadTaskStatus(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestDownloadTaskListData(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void TryCommitCurrentApplicationDownloadTask() => throw new NotImplementedException();
		public virtual void EnableAutoCommit() => throw new NotImplementedException();
		public virtual void DisableAutoCommit() => throw new NotImplementedException();
		public virtual void TriggerDynamicCommitEvent() => throw new NotImplementedException();
	}
	
	public unsafe partial class IECommerceInterface : _Base_IECommerceInterface {}
	public unsafe class _Base_IECommerceInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IECommerceInterface: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
	}
	
	public unsafe partial class IFactoryResetInterface : _Base_IFactoryResetInterface {}
	public unsafe class _Base_IFactoryResetInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 100: { // ResetToFactorySettings
					ResetToFactorySettings();
					break;
				}
				case 101: { // ResetToFactorySettingsWithoutUserSaveData
					ResetToFactorySettingsWithoutUserSaveData();
					break;
				}
				case 102: { // ResetToFactorySettingsForRefurbishment
					ResetToFactorySettingsForRefurbishment();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFactoryResetInterface: {im.CommandId}");
			}
		}
		
		public virtual void ResetToFactorySettings() => throw new NotImplementedException();
		public virtual void ResetToFactorySettingsWithoutUserSaveData() => throw new NotImplementedException();
		public virtual void ResetToFactorySettingsForRefurbishment() => throw new NotImplementedException();
	}
	
	public unsafe partial class IGameCardStopper : _Base_IGameCardStopper {}
	public unsafe class _Base_IGameCardStopper : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				default:
					throw new NotImplementedException($"Unhandled command ID to IGameCardStopper: {im.CommandId}");
			}
		}
		
	}
	
	public unsafe partial class IProgressAsyncResult : _Base_IProgressAsyncResult {}
	public unsafe class _Base_IProgressAsyncResult : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				case 4: { // Unknown4
					Unknown4(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProgressAsyncResult: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IProgressMonitorForDeleteUserSaveDataAll : _Base_IProgressMonitorForDeleteUserSaveDataAll {}
	public unsafe class _Base_IProgressMonitorForDeleteUserSaveDataAll : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 10: { // Unknown10
					var ret = Unknown10();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProgressMonitorForDeleteUserSaveDataAll: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual object Unknown10() => throw new NotImplementedException();
	}
	
	public unsafe partial class IRequestServerStopper : _Base_IRequestServerStopper {}
	public unsafe class _Base_IRequestServerStopper : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequestServerStopper: {im.CommandId}");
			}
		}
		
	}
	
	public unsafe partial class ISystemUpdateControl : _Base_ISystemUpdateControl {}
	public unsafe class _Base_ISystemUpdateControl : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 2: { // Unknown2
					Unknown2(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6();
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7();
					break;
				}
				case 8: { // Unknown8
					Unknown8();
					break;
				}
				case 9: { // Unknown9
					var ret = Unknown9(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				case 10: { // Unknown10
					Unknown10(im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 11: { // Unknown11
					Unknown11(null, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				case 13: { // Unknown13
					Unknown13(im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 14: { // Unknown14
					Unknown14(null, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 15: { // Unknown15
					var ret = Unknown15();
					break;
				}
				case 16: { // Unknown16
					Unknown16(null, im.GetBuffer<byte>(0x15, 0), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 17: { // Unknown17
					var ret = Unknown17();
					break;
				}
				case 18: { // Unknown18
					Unknown18();
					break;
				}
				case 19: { // Unknown19
					var ret = Unknown19(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				case 20: { // Unknown20
					Unknown20(im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 21: { // Unknown21
					Unknown21();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemUpdateControl: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void Unknown2(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual object Unknown6() => throw new NotImplementedException();
		public virtual object Unknown7() => throw new NotImplementedException();
		public virtual void Unknown8() => throw new NotImplementedException();
		public virtual object Unknown9(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown10(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown11(object _0, KObject _1) => throw new NotImplementedException();
		public virtual object Unknown12(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown13(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown14(object _0, KObject _1) => throw new NotImplementedException();
		public virtual object Unknown15() => throw new NotImplementedException();
		public virtual void Unknown16(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual object Unknown17() => throw new NotImplementedException();
		public virtual void Unknown18() => throw new NotImplementedException();
		public virtual object Unknown19(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown20(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown21() => throw new NotImplementedException();
	}
}
