#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ns.Detail {
	[IpcService("ns:am")]
	public unsafe partial class IApplicationManagerInterface : _Base_IApplicationManagerInterface {}
	public unsafe class _Base_IApplicationManagerInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ListApplicationRecord
					ListApplicationRecord(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GenerateApplicationRecordCount
					var ret = GenerateApplicationRecordCount();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetApplicationRecordUpdateSystemEvent
					var ret = GetApplicationRecordUpdateSystemEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 3: { // GetApplicationViewDeprecated
					GetApplicationViewDeprecated(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // DeleteApplicationEntity
					DeleteApplicationEntity(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // DeleteApplicationCompletely
					DeleteApplicationCompletely(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // IsAnyApplicationEntityRedundant
					var ret = IsAnyApplicationEntityRedundant();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // DeleteRedundantApplicationEntity
					DeleteRedundantApplicationEntity();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // IsApplicationEntityMovable
					var ret = IsApplicationEntityMovable(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // MoveApplicationEntity
					MoveApplicationEntity(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // CalculateApplicationOccupiedSize
					var ret = CalculateApplicationOccupiedSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // PushApplicationRecord
					PushApplicationRecord(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // ListApplicationRecordContentMeta
					ListApplicationRecordContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // LaunchApplication
					var ret = LaunchApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // GetApplicationContentPath
					GetApplicationContentPath(null, im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // TerminateApplication
					TerminateApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // ResolveApplicationContentPath
					ResolveApplicationContentPath(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // BeginInstallApplication
					BeginInstallApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // DeleteApplicationRecord
					DeleteApplicationRecord(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // RequestApplicationUpdateInfo
					RequestApplicationUpdateInfo(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 32: { // CancelApplicationDownload
					CancelApplicationDownload(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 33: { // ResumeApplicationDownload
					ResumeApplicationDownload(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 35: { // UpdateVersionList
					UpdateVersionList(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 36: { // PushLaunchVersion
					PushLaunchVersion(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 37: { // ListRequiredVersion
					ListRequiredVersion(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 38: { // CheckApplicationLaunchVersion
					CheckApplicationLaunchVersion(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 39: { // CheckApplicationLaunchRights
					CheckApplicationLaunchRights(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // GetApplicationLogoData
					GetApplicationLogoData(null, im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 41: { // CalculateApplicationDownloadRequiredSize
					var ret = CalculateApplicationDownloadRequiredSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 42: { // CleanupSdCard
					CleanupSdCard();
					om.Initialize(0, 0, 0);
					break;
				}
				case 43: { // CheckSdCardMountStatus
					CheckSdCardMountStatus();
					om.Initialize(0, 0, 0);
					break;
				}
				case 44: { // GetSdCardMountStatusChangedEvent
					var ret = GetSdCardMountStatusChangedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 45: { // GetGameCardAttachmentEvent
					var ret = GetGameCardAttachmentEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 46: { // GetGameCardAttachmentInfo
					var ret = GetGameCardAttachmentInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 47: { // GetTotalSpaceSize
					var ret = GetTotalSpaceSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 48: { // GetFreeSpaceSize
					var ret = GetFreeSpaceSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 49: { // GetSdCardRemovedEvent
					var ret = GetSdCardRemovedEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 52: { // GetGameCardUpdateDetectionEvent
					var ret = GetGameCardUpdateDetectionEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 53: { // DisableApplicationAutoDelete
					DisableApplicationAutoDelete(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 54: { // EnableApplicationAutoDelete
					EnableApplicationAutoDelete(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 55: { // GetApplicationDesiredLanguage
					var ret = GetApplicationDesiredLanguage(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 56: { // SetApplicationTerminateResult
					SetApplicationTerminateResult(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 57: { // ClearApplicationTerminateResult
					ClearApplicationTerminateResult(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 58: { // GetLastSdCardMountUnexpectedResult
					GetLastSdCardMountUnexpectedResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 59: { // ConvertApplicationLanguageToLanguageCode
					var ret = ConvertApplicationLanguageToLanguageCode(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 60: { // ConvertLanguageCodeToApplicationLanguage
					var ret = ConvertLanguageCodeToApplicationLanguage(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 61: { // GetBackgroundDownloadStressTaskInfo
					var ret = GetBackgroundDownloadStressTaskInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 62: { // GetGameCardStopper
					var ret = GetGameCardStopper();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 63: { // IsSystemProgramInstalled
					var ret = IsSystemProgramInstalled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 64: { // StartApplyDeltaTask
					StartApplyDeltaTask(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 65: { // GetRequestServerStopper
					var ret = GetRequestServerStopper();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 66: { // GetBackgroundApplyDeltaStressTaskInfo
					var ret = GetBackgroundApplyDeltaStressTaskInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 67: { // CancelApplicationApplyDelta
					CancelApplicationApplyDelta(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 68: { // ResumeApplicationApplyDelta
					ResumeApplicationApplyDelta(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 69: { // CalculateApplicationApplyDeltaRequiredSize
					var ret = CalculateApplicationApplyDeltaRequiredSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 70: { // ResumeAll
					ResumeAll();
					om.Initialize(0, 0, 0);
					break;
				}
				case 71: { // GetStorageSize
					var ret = GetStorageSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 80: { // RequestDownloadApplication
					RequestDownloadApplication(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 81: { // RequestDownloadAddOnContent
					RequestDownloadAddOnContent(null, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 82: { // DownloadApplication
					DownloadApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 83: { // CheckApplicationResumeRights
					CheckApplicationResumeRights(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 84: { // GetDynamicCommitEvent
					var ret = GetDynamicCommitEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 85: { // RequestUpdateApplication2
					RequestUpdateApplication2(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 86: { // EnableApplicationCrashReport
					EnableApplicationCrashReport(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 87: { // IsApplicationCrashReportEnabled
					var ret = IsApplicationCrashReportEnabled();
					om.Initialize(0, 0, 0);
					break;
				}
				case 90: { // BoostSystemMemoryResourceLimit
					BoostSystemMemoryResourceLimit(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 91: { // Unknown91
					var ret = Unknown91(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 92: { // Unknown92
					var ret = Unknown92(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 93: { // Unknown93
					var ret = Unknown93(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 94: { // LaunchApplication2
					var ret = LaunchApplication2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 95: { // Unknown95
					var ret = Unknown95(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 96: { // Unknown96
					var ret = Unknown96(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 97: { // Unknown97
					var ret = Unknown97(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 98: { // Unknown98
					var ret = Unknown98(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // ResetToFactorySettings
					ResetToFactorySettings();
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // ResetToFactorySettingsWithoutUserSaveData
					ResetToFactorySettingsWithoutUserSaveData();
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // ResetToFactorySettingsForRefurbishment
					ResetToFactorySettingsForRefurbishment();
					om.Initialize(0, 0, 0);
					break;
				}
				case 200: { // CalculateUserSaveDataStatistics
					var ret = CalculateUserSaveDataStatistics(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 201: { // DeleteUserSaveDataAll
					var ret = DeleteUserSaveDataAll(null);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 210: { // DeleteUserSystemSaveData
					DeleteUserSystemSaveData(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 211: { // Unknown211
					var ret = Unknown211(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 220: { // UnregisterNetworkServiceAccount
					UnregisterNetworkServiceAccount(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 221: { // Unknown221
					var ret = Unknown221(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 300: { // GetApplicationShellEvent
					var ret = GetApplicationShellEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 301: { // PopApplicationShellEventInfo
					PopApplicationShellEventInfo(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // LaunchLibraryApplet
					var ret = LaunchLibraryApplet(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 303: { // TerminateLibraryApplet
					TerminateLibraryApplet(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 304: { // LaunchSystemApplet
					var ret = LaunchSystemApplet();
					om.Initialize(0, 0, 0);
					break;
				}
				case 305: { // TerminateSystemApplet
					TerminateSystemApplet(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 306: { // LaunchOverlayApplet
					var ret = LaunchOverlayApplet();
					om.Initialize(0, 0, 0);
					break;
				}
				case 307: { // TerminateOverlayApplet
					TerminateOverlayApplet(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 400: { // GetApplicationControlData
					GetApplicationControlData(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 401: { // InvalidateAllApplicationControlCache
					InvalidateAllApplicationControlCache();
					om.Initialize(0, 0, 0);
					break;
				}
				case 402: { // RequestDownloadApplicationControlData
					RequestDownloadApplicationControlData(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 403: { // GetMaxApplicationControlCacheCount
					var ret = GetMaxApplicationControlCacheCount();
					om.Initialize(0, 0, 0);
					break;
				}
				case 404: { // InvalidateApplicationControlCache
					InvalidateApplicationControlCache(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 405: { // ListApplicationControlCacheEntryInfo
					ListApplicationControlCacheEntryInfo(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 406: { // Unknown406
					var ret = Unknown406(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 502: { // RequestCheckGameCardRegistration
					RequestCheckGameCardRegistration(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 503: { // RequestGameCardRegistrationGoldPoint
					RequestGameCardRegistrationGoldPoint(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 504: { // RequestRegisterGameCard
					RequestRegisterGameCard(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 505: { // GetGameCardMountFailureEvent
					var ret = GetGameCardMountFailureEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 506: { // IsGameCardInserted
					var ret = IsGameCardInserted();
					om.Initialize(0, 0, 0);
					break;
				}
				case 507: { // EnsureGameCardAccess
					EnsureGameCardAccess();
					om.Initialize(0, 0, 0);
					break;
				}
				case 508: { // GetLastGameCardMountFailureResult
					GetLastGameCardMountFailureResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 509: { // ListApplicationIdOnGameCard
					var ret = ListApplicationIdOnGameCard(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 600: { // CountApplicationContentMeta
					var ret = CountApplicationContentMeta(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 601: { // ListApplicationContentMetaStatus
					ListApplicationContentMetaStatus(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 602: { // ListAvailableAddOnContent
					ListAvailableAddOnContent(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 603: { // GetOwnedApplicationContentMetaStatus
					var ret = GetOwnedApplicationContentMetaStatus(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 604: { // RegisterContentsExternalKey
					RegisterContentsExternalKey(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 605: { // ListApplicationContentMetaStatusWithRightsCheck
					ListApplicationContentMetaStatusWithRightsCheck(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 606: { // GetContentMetaStorage
					var ret = GetContentMetaStorage(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 607: { // Unknown607
					var ret = Unknown607(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 700: { // PushDownloadTaskList
					PushDownloadTaskList(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 701: { // ClearTaskStatusList
					ClearTaskStatusList();
					om.Initialize(0, 0, 0);
					break;
				}
				case 702: { // RequestDownloadTaskList
					RequestDownloadTaskList();
					om.Initialize(0, 0, 0);
					break;
				}
				case 703: { // RequestEnsureDownloadTask
					RequestEnsureDownloadTask(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 704: { // ListDownloadTaskStatus
					ListDownloadTaskStatus(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 705: { // RequestDownloadTaskListData
					RequestDownloadTaskListData(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 800: { // RequestVersionList
					RequestVersionList();
					om.Initialize(0, 0, 0);
					break;
				}
				case 801: { // ListVersionList
					ListVersionList(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 802: { // RequestVersionListData
					RequestVersionListData(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 900: { // GetApplicationRecord
					var ret = GetApplicationRecord(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 901: { // GetApplicationRecordProperty
					GetApplicationRecordProperty(null, im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 902: { // EnableApplicationAutoUpdate
					EnableApplicationAutoUpdate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 903: { // DisableApplicationAutoUpdate
					DisableApplicationAutoUpdate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 904: { // TouchApplication
					TouchApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 905: { // RequestApplicationUpdate
					RequestApplicationUpdate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 906: { // IsApplicationUpdateRequested
					var ret = IsApplicationUpdateRequested(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 907: { // WithdrawApplicationUpdateRequest
					WithdrawApplicationUpdateRequest(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 908: { // ListApplicationRecordInstalledContentMeta
					ListApplicationRecordInstalledContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 909: { // WithdrawCleanupAddOnContentsWithNoRightsRecommendation
					WithdrawCleanupAddOnContentsWithNoRightsRecommendation(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 910: { // Unknown910
					var ret = Unknown910(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 911: { // Unknown911
					var ret = Unknown911(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 912: { // Unknown912
					var ret = Unknown912(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1000: { // RequestVerifyApplicationDeprecated
					RequestVerifyApplicationDeprecated(null, Kernel.Get<KObject>(im.GetCopy(0)), out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 1001: { // CorruptApplicationForDebug
					CorruptApplicationForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1002: { // RequestVerifyAddOnContentsRights
					RequestVerifyAddOnContentsRights(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 1003: { // RequestVerifyApplication
					var ret = RequestVerifyApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1004: { // CorruptContentForDebug
					var ret = CorruptContentForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1200: { // NeedsUpdateVulnerability
					var ret = NeedsUpdateVulnerability();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1300: { // IsAnyApplicationEntityInstalled
					var ret = IsAnyApplicationEntityInstalled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1301: { // DeleteApplicationContentEntities
					DeleteApplicationContentEntities(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1302: { // CleanupUnrecordedApplicationEntity
					CleanupUnrecordedApplicationEntity(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1303: { // CleanupAddOnContentsWithNoRights
					CleanupAddOnContentsWithNoRights(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1304: { // DeleteApplicationContentEntity
					DeleteApplicationContentEntity(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1308: { // Unknown1308
					var ret = Unknown1308(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1309: { // Unknown1309
					var ret = Unknown1309(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1400: { // PrepareShutdown
					PrepareShutdown();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1500: { // FormatSdCard
					FormatSdCard();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1501: { // NeedsSystemUpdateToFormatSdCard
					var ret = NeedsSystemUpdateToFormatSdCard();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1502: { // GetLastSdCardFormatUnexpectedResult
					GetLastSdCardFormatUnexpectedResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1504: { // InsertSdCard
					InsertSdCard();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1505: { // RemoveSdCard
					RemoveSdCard();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1600: { // GetSystemSeedForPseudoDeviceId
					var ret = GetSystemSeedForPseudoDeviceId();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1601: { // ResetSystemSeedForPseudoDeviceId
					ResetSystemSeedForPseudoDeviceId();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1700: { // ListApplicationDownloadingContentMeta
					ListApplicationDownloadingContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1701: { // GetApplicationView
					GetApplicationView(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1702: { // GetApplicationDownloadTaskStatus
					var ret = GetApplicationDownloadTaskStatus(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1703: { // GetApplicationViewDownloadErrorContext
					GetApplicationViewDownloadErrorContext(null, im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1800: { // IsNotificationSetupCompleted
					var ret = IsNotificationSetupCompleted();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1801: { // GetLastNotificationInfoCount
					var ret = GetLastNotificationInfoCount();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1802: { // ListLastNotificationInfo
					ListLastNotificationInfo(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1803: { // ListNotificationTask
					ListNotificationTask(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1900: { // IsActiveAccount
					var ret = IsActiveAccount(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1901: { // RequestDownloadApplicationPrepurchasedRights
					RequestDownloadApplicationPrepurchasedRights(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 1902: { // GetApplicationTicketInfo
					var ret = GetApplicationTicketInfo(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2000: { // GetSystemDeliveryInfo
					GetSystemDeliveryInfo(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2001: { // SelectLatestSystemDeliveryInfo
					var ret = SelectLatestSystemDeliveryInfo(im.GetBuffer<byte>(0x15, 0), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2002: { // VerifyDeliveryProtocolVersion
					VerifyDeliveryProtocolVersion(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2003: { // GetApplicationDeliveryInfo
					GetApplicationDeliveryInfo(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2004: { // HasAllContentsToDeliver
					var ret = HasAllContentsToDeliver(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2005: { // CompareApplicationDeliveryInfo
					var ret = CompareApplicationDeliveryInfo(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2006: { // CanDeliverApplication
					var ret = CanDeliverApplication(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2007: { // ListContentMetaKeyToDeliverApplication
					ListContentMetaKeyToDeliverApplication(null, im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2008: { // NeedsSystemUpdateToDeliverApplication
					var ret = NeedsSystemUpdateToDeliverApplication(im.GetBuffer<byte>(0x15, 0), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2009: { // EstimateRequiredSize
					var ret = EstimateRequiredSize(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2010: { // RequestReceiveApplication
					RequestReceiveApplication(null, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 2011: { // CommitReceiveApplication
					CommitReceiveApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2012: { // GetReceiveApplicationProgress
					var ret = GetReceiveApplicationProgress(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2013: { // RequestSendApplication
					RequestSendApplication(null, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 2014: { // GetSendApplicationProgress
					var ret = GetSendApplicationProgress(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2015: { // CompareSystemDeliveryInfo
					var ret = CompareSystemDeliveryInfo(im.GetBuffer<byte>(0x15, 0), im.GetBuffer<byte>(0x15, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2016: { // ListNotCommittedContentMeta
					ListNotCommittedContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2017: { // CreateDownloadTask
					CreateDownloadTask(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2018: { // Unknown2018
					var ret = Unknown2018(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2050: { // Unknown2050
					var ret = Unknown2050(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2100: { // Unknown2100
					var ret = Unknown2100(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2101: { // Unknown2101
					var ret = Unknown2101(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2150: { // Unknown2150
					var ret = Unknown2150(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2151: { // Unknown2151
					var ret = Unknown2151(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2152: { // Unknown2152
					var ret = Unknown2152(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2153: { // Unknown2153
					var ret = Unknown2153(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2154: { // Unknown2154
					var ret = Unknown2154(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2160: { // Unknown2160
					var ret = Unknown2160(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2161: { // Unknown2161
					var ret = Unknown2161(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2170: { // Unknown2170
					var ret = Unknown2170(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2171: { // Unknown2171
					var ret = Unknown2171(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2180: { // Unknown2180
					var ret = Unknown2180(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2181: { // Unknown2181
					var ret = Unknown2181(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2182: { // Unknown2182
					var ret = Unknown2182(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2190: { // Unknown2190
					var ret = Unknown2190(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2199: { // Unknown2199
					var ret = Unknown2199(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2200: { // Unknown2200
					var ret = Unknown2200(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2201: { // Unknown2201
					var ret = Unknown2201(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2250: { // Unknown2250
					var ret = Unknown2250(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2300: { // Unknown2300
					var ret = Unknown2300(null);
					om.Initialize(0, 0, 0);
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
		public virtual void DeleteApplicationEntity(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteApplicationEntity [4]".Debug();
		public virtual void DeleteApplicationCompletely(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteApplicationCompletely [5]".Debug();
		public virtual object IsAnyApplicationEntityRedundant() => throw new NotImplementedException();
		public virtual void DeleteRedundantApplicationEntity() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteRedundantApplicationEntity [7]".Debug();
		public virtual object IsApplicationEntityMovable(object _0) => throw new NotImplementedException();
		public virtual void MoveApplicationEntity(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.MoveApplicationEntity [9]".Debug();
		public virtual object CalculateApplicationOccupiedSize(object _0) => throw new NotImplementedException();
		public virtual void PushApplicationRecord(object _0, Buffer<byte> _1) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.PushApplicationRecord [16]".Debug();
		public virtual void ListApplicationRecordContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object LaunchApplication(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationContentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void TerminateApplication(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.TerminateApplication [22]".Debug();
		public virtual void ResolveApplicationContentPath(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResolveApplicationContentPath [23]".Debug();
		public virtual void BeginInstallApplication(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.BeginInstallApplication [26]".Debug();
		public virtual void DeleteApplicationRecord(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteApplicationRecord [27]".Debug();
		public virtual void RequestApplicationUpdateInfo(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void CancelApplicationDownload(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CancelApplicationDownload [32]".Debug();
		public virtual void ResumeApplicationDownload(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResumeApplicationDownload [33]".Debug();
		public virtual void UpdateVersionList(Buffer<byte> _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.UpdateVersionList [35]".Debug();
		public virtual void PushLaunchVersion(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.PushLaunchVersion [36]".Debug();
		public virtual void ListRequiredVersion(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void CheckApplicationLaunchVersion(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CheckApplicationLaunchVersion [38]".Debug();
		public virtual void CheckApplicationLaunchRights(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CheckApplicationLaunchRights [39]".Debug();
		public virtual void GetApplicationLogoData(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object CalculateApplicationDownloadRequiredSize(object _0) => throw new NotImplementedException();
		public virtual void CleanupSdCard() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CleanupSdCard [42]".Debug();
		public virtual void CheckSdCardMountStatus() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CheckSdCardMountStatus [43]".Debug();
		public virtual KObject GetSdCardMountStatusChangedEvent() => throw new NotImplementedException();
		public virtual KObject GetGameCardAttachmentEvent() => throw new NotImplementedException();
		public virtual object GetGameCardAttachmentInfo() => throw new NotImplementedException();
		public virtual object GetTotalSpaceSize(object _0) => throw new NotImplementedException();
		public virtual object GetFreeSpaceSize(object _0) => throw new NotImplementedException();
		public virtual KObject GetSdCardRemovedEvent() => throw new NotImplementedException();
		public virtual KObject GetGameCardUpdateDetectionEvent() => throw new NotImplementedException();
		public virtual void DisableApplicationAutoDelete(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DisableApplicationAutoDelete [53]".Debug();
		public virtual void EnableApplicationAutoDelete(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.EnableApplicationAutoDelete [54]".Debug();
		public virtual object GetApplicationDesiredLanguage(object _0) => throw new NotImplementedException();
		public virtual void SetApplicationTerminateResult(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.SetApplicationTerminateResult [56]".Debug();
		public virtual void ClearApplicationTerminateResult(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ClearApplicationTerminateResult [57]".Debug();
		public virtual void GetLastSdCardMountUnexpectedResult() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.GetLastSdCardMountUnexpectedResult [58]".Debug();
		public virtual object ConvertApplicationLanguageToLanguageCode(object _0) => throw new NotImplementedException();
		public virtual object ConvertLanguageCodeToApplicationLanguage(object _0) => throw new NotImplementedException();
		public virtual object GetBackgroundDownloadStressTaskInfo() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IGameCardStopper GetGameCardStopper() => throw new NotImplementedException();
		public virtual object IsSystemProgramInstalled(object _0) => throw new NotImplementedException();
		public virtual void StartApplyDeltaTask(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.StartApplyDeltaTask [64]".Debug();
		public virtual Nn.Ns.Detail.IRequestServerStopper GetRequestServerStopper() => throw new NotImplementedException();
		public virtual object GetBackgroundApplyDeltaStressTaskInfo() => throw new NotImplementedException();
		public virtual void CancelApplicationApplyDelta(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CancelApplicationApplyDelta [67]".Debug();
		public virtual void ResumeApplicationApplyDelta(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResumeApplicationApplyDelta [68]".Debug();
		public virtual object CalculateApplicationApplyDeltaRequiredSize(object _0) => throw new NotImplementedException();
		public virtual void ResumeAll() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResumeAll [70]".Debug();
		public virtual object GetStorageSize(object _0) => throw new NotImplementedException();
		public virtual void RequestDownloadApplication(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestDownloadAddOnContent(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual void DownloadApplication(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DownloadApplication [82]".Debug();
		public virtual void CheckApplicationResumeRights(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CheckApplicationResumeRights [83]".Debug();
		public virtual KObject GetDynamicCommitEvent() => throw new NotImplementedException();
		public virtual void RequestUpdateApplication2(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void EnableApplicationCrashReport(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.EnableApplicationCrashReport [86]".Debug();
		public virtual object IsApplicationCrashReportEnabled() => throw new NotImplementedException();
		public virtual void BoostSystemMemoryResourceLimit(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.BoostSystemMemoryResourceLimit [90]".Debug();
		public virtual object Unknown91(object _0) => throw new NotImplementedException();
		public virtual object Unknown92(object _0) => throw new NotImplementedException();
		public virtual object Unknown93(object _0) => throw new NotImplementedException();
		public virtual object LaunchApplication2(object _0) => throw new NotImplementedException();
		public virtual object Unknown95(object _0) => throw new NotImplementedException();
		public virtual object Unknown96(object _0) => throw new NotImplementedException();
		public virtual object Unknown97(object _0) => throw new NotImplementedException();
		public virtual object Unknown98(object _0) => throw new NotImplementedException();
		public virtual void ResetToFactorySettings() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResetToFactorySettings [100]".Debug();
		public virtual void ResetToFactorySettingsWithoutUserSaveData() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResetToFactorySettingsWithoutUserSaveData [101]".Debug();
		public virtual void ResetToFactorySettingsForRefurbishment() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResetToFactorySettingsForRefurbishment [102]".Debug();
		public virtual object CalculateUserSaveDataStatistics(object _0) => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.IProgressMonitorForDeleteUserSaveDataAll DeleteUserSaveDataAll(object _0) => throw new NotImplementedException();
		public virtual void DeleteUserSystemSaveData(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteUserSystemSaveData [210]".Debug();
		public virtual object Unknown211(object _0) => throw new NotImplementedException();
		public virtual void UnregisterNetworkServiceAccount(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.UnregisterNetworkServiceAccount [220]".Debug();
		public virtual object Unknown221(object _0) => throw new NotImplementedException();
		public virtual KObject GetApplicationShellEvent() => throw new NotImplementedException();
		public virtual void PopApplicationShellEventInfo(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object LaunchLibraryApplet(object _0) => throw new NotImplementedException();
		public virtual void TerminateLibraryApplet(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.TerminateLibraryApplet [303]".Debug();
		public virtual object LaunchSystemApplet() => throw new NotImplementedException();
		public virtual void TerminateSystemApplet(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.TerminateSystemApplet [305]".Debug();
		public virtual object LaunchOverlayApplet() => throw new NotImplementedException();
		public virtual void TerminateOverlayApplet(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.TerminateOverlayApplet [307]".Debug();
		public virtual void GetApplicationControlData(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void InvalidateAllApplicationControlCache() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.InvalidateAllApplicationControlCache [401]".Debug();
		public virtual void RequestDownloadApplicationControlData(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object GetMaxApplicationControlCacheCount() => throw new NotImplementedException();
		public virtual void InvalidateApplicationControlCache(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.InvalidateApplicationControlCache [404]".Debug();
		public virtual void ListApplicationControlCacheEntryInfo(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown406(object _0) => throw new NotImplementedException();
		public virtual void RequestCheckGameCardRegistration(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestGameCardRegistrationGoldPoint(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void RequestRegisterGameCard(object _0, out KObject _1, out Nn.Ns.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual KObject GetGameCardMountFailureEvent() => throw new NotImplementedException();
		public virtual object IsGameCardInserted() => throw new NotImplementedException();
		public virtual void EnsureGameCardAccess() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.EnsureGameCardAccess [507]".Debug();
		public virtual void GetLastGameCardMountFailureResult() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.GetLastGameCardMountFailureResult [508]".Debug();
		public virtual object ListApplicationIdOnGameCard(object _0) => throw new NotImplementedException();
		public virtual object CountApplicationContentMeta(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatus(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ListAvailableAddOnContent(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetOwnedApplicationContentMetaStatus(object _0) => throw new NotImplementedException();
		public virtual void RegisterContentsExternalKey(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.RegisterContentsExternalKey [604]".Debug();
		public virtual void ListApplicationContentMetaStatusWithRightsCheck(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetContentMetaStorage(object _0) => throw new NotImplementedException();
		public virtual object Unknown607(object _0) => throw new NotImplementedException();
		public virtual void PushDownloadTaskList(Buffer<byte> _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.PushDownloadTaskList [700]".Debug();
		public virtual void ClearTaskStatusList() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ClearTaskStatusList [701]".Debug();
		public virtual void RequestDownloadTaskList() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.RequestDownloadTaskList [702]".Debug();
		public virtual void RequestEnsureDownloadTask(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void ListDownloadTaskStatus(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestDownloadTaskListData(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void RequestVersionList() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.RequestVersionList [800]".Debug();
		public virtual void ListVersionList(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestVersionListData(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual object GetApplicationRecord(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationRecordProperty(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void EnableApplicationAutoUpdate(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.EnableApplicationAutoUpdate [902]".Debug();
		public virtual void DisableApplicationAutoUpdate(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DisableApplicationAutoUpdate [903]".Debug();
		public virtual void TouchApplication(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.TouchApplication [904]".Debug();
		public virtual void RequestApplicationUpdate(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.RequestApplicationUpdate [905]".Debug();
		public virtual object IsApplicationUpdateRequested(object _0) => throw new NotImplementedException();
		public virtual void WithdrawApplicationUpdateRequest(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.WithdrawApplicationUpdateRequest [907]".Debug();
		public virtual void ListApplicationRecordInstalledContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void WithdrawCleanupAddOnContentsWithNoRightsRecommendation(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.WithdrawCleanupAddOnContentsWithNoRightsRecommendation [909]".Debug();
		public virtual object Unknown910(object _0) => throw new NotImplementedException();
		public virtual object Unknown911(object _0) => throw new NotImplementedException();
		public virtual object Unknown912(object _0) => throw new NotImplementedException();
		public virtual void RequestVerifyApplicationDeprecated(object _0, KObject _1, out KObject _2, out Nn.Ns.Detail.IProgressAsyncResult _3) => throw new NotImplementedException();
		public virtual void CorruptApplicationForDebug(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CorruptApplicationForDebug [1001]".Debug();
		public virtual void RequestVerifyAddOnContentsRights(object _0, out KObject _1, out Nn.Ns.Detail.IProgressAsyncResult _2) => throw new NotImplementedException();
		public virtual object RequestVerifyApplication(object _0) => throw new NotImplementedException();
		public virtual object CorruptContentForDebug(object _0) => throw new NotImplementedException();
		public virtual object NeedsUpdateVulnerability() => throw new NotImplementedException();
		public virtual object IsAnyApplicationEntityInstalled(object _0) => throw new NotImplementedException();
		public virtual void DeleteApplicationContentEntities(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteApplicationContentEntities [1301]".Debug();
		public virtual void CleanupUnrecordedApplicationEntity(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CleanupUnrecordedApplicationEntity [1302]".Debug();
		public virtual void CleanupAddOnContentsWithNoRights(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CleanupAddOnContentsWithNoRights [1303]".Debug();
		public virtual void DeleteApplicationContentEntity(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.DeleteApplicationContentEntity [1304]".Debug();
		public virtual object Unknown1308(object _0) => throw new NotImplementedException();
		public virtual object Unknown1309(object _0) => throw new NotImplementedException();
		public virtual void PrepareShutdown() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.PrepareShutdown [1400]".Debug();
		public virtual void FormatSdCard() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.FormatSdCard [1500]".Debug();
		public virtual object NeedsSystemUpdateToFormatSdCard() => throw new NotImplementedException();
		public virtual void GetLastSdCardFormatUnexpectedResult() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.GetLastSdCardFormatUnexpectedResult [1502]".Debug();
		public virtual void InsertSdCard() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.InsertSdCard [1504]".Debug();
		public virtual void RemoveSdCard() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.RemoveSdCard [1505]".Debug();
		public virtual object GetSystemSeedForPseudoDeviceId() => throw new NotImplementedException();
		public virtual void ResetSystemSeedForPseudoDeviceId() => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.ResetSystemSeedForPseudoDeviceId [1601]".Debug();
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
		public virtual void VerifyDeliveryProtocolVersion(Buffer<byte> _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.VerifyDeliveryProtocolVersion [2002]".Debug();
		public virtual void GetApplicationDeliveryInfo(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object HasAllContentsToDeliver(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object CompareApplicationDeliveryInfo(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object CanDeliverApplication(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ListContentMetaKeyToDeliverApplication(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object NeedsSystemUpdateToDeliverApplication(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object EstimateRequiredSize(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void RequestReceiveApplication(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual void CommitReceiveApplication(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CommitReceiveApplication [2011]".Debug();
		public virtual object GetReceiveApplicationProgress(object _0) => throw new NotImplementedException();
		public virtual void RequestSendApplication(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual object GetSendApplicationProgress(object _0) => throw new NotImplementedException();
		public virtual object CompareSystemDeliveryInfo(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ListNotCommittedContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void CreateDownloadTask(object _0, Buffer<byte> _1) => "Stub hit for Nn.Ns.Detail.IApplicationManagerInterface.CreateDownloadTask [2017]".Debug();
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // LaunchProgram
					var ret = LaunchProgram(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // TerminateProcess
					TerminateProcess(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // TerminateProgram
					TerminateProgram(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetShellEventHandle
					var ret = GetShellEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 5: { // GetShellEventInfo
					var ret = GetShellEventInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // TerminateApplication
					TerminateApplication();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // PrepareLaunchProgramFromHost
					var ret = PrepareLaunchProgramFromHost(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // LaunchApplication
					var ret = LaunchApplication(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // LaunchApplicationWithStorageId
					var ret = LaunchApplicationWithStorageId(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDevelopInterface: {im.CommandId}");
			}
		}
		
		public virtual object LaunchProgram(object _0) => throw new NotImplementedException();
		public virtual void TerminateProcess(object _0) => "Stub hit for Nn.Ns.Detail.IDevelopInterface.TerminateProcess [1]".Debug();
		public virtual void TerminateProgram(object _0) => "Stub hit for Nn.Ns.Detail.IDevelopInterface.TerminateProgram [2]".Debug();
		public virtual KObject GetShellEventHandle() => throw new NotImplementedException();
		public virtual object GetShellEventInfo() => throw new NotImplementedException();
		public virtual void TerminateApplication() => "Stub hit for Nn.Ns.Detail.IDevelopInterface.TerminateApplication [6]".Debug();
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 7992: { // GetECommerceInterface
					var ret = GetECommerceInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7993: { // GetApplicationVersionInterface
					var ret = GetApplicationVersionInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7994: { // GetFactoryResetInterface
					var ret = GetFactoryResetInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7995: { // GetAccountProxyInterface
					var ret = GetAccountProxyInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7996: { // GetApplicationManagerInterface
					var ret = GetApplicationManagerInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7997: { // GetDownloadTaskInterface
					var ret = GetDownloadTaskInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7998: { // GetContentManagementInterface
					var ret = GetContentManagementInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 7999: { // GetDocumentInterface
					var ret = GetDocumentInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetBackgroundNetworkUpdateState
					var ret = GetBackgroundNetworkUpdateState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // OpenSystemUpdateControl
					var ret = OpenSystemUpdateControl();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // NotifyExFatDriverRequired
					NotifyExFatDriverRequired();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // ClearExFatDriverStatusForDebug
					ClearExFatDriverStatusForDebug();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // RequestBackgroundNetworkUpdate
					RequestBackgroundNetworkUpdate();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // NotifyBackgroundNetworkUpdate
					NotifyBackgroundNetworkUpdate(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // NotifyExFatDriverDownloadedForDebug
					NotifyExFatDriverDownloadedForDebug();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // GetSystemUpdateNotificationEventForContentDelivery
					var ret = GetSystemUpdateNotificationEventForContentDelivery();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 10: { // NotifySystemUpdateForContentDelivery
					NotifySystemUpdateForContentDelivery();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // PrepareShutdown
					PrepareShutdown();
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // DestroySystemUpdateTask
					DestroySystemUpdateTask();
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // RequestSendSystemUpdate
					RequestSendSystemUpdate(null, im.GetBuffer<byte>(0x15, 0), out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 18: { // GetSendSystemUpdateProgress
					var ret = GetSendSystemUpdateProgress();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemUpdateInterface: {im.CommandId}");
			}
		}
		
		public virtual object GetBackgroundNetworkUpdateState() => throw new NotImplementedException();
		public virtual Nn.Ns.Detail.ISystemUpdateControl OpenSystemUpdateControl() => throw new NotImplementedException();
		public virtual void NotifyExFatDriverRequired() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.NotifyExFatDriverRequired [2]".Debug();
		public virtual void ClearExFatDriverStatusForDebug() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.ClearExFatDriverStatusForDebug [3]".Debug();
		public virtual void RequestBackgroundNetworkUpdate() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.RequestBackgroundNetworkUpdate [4]".Debug();
		public virtual void NotifyBackgroundNetworkUpdate(object _0) => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.NotifyBackgroundNetworkUpdate [5]".Debug();
		public virtual void NotifyExFatDriverDownloadedForDebug() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.NotifyExFatDriverDownloadedForDebug [6]".Debug();
		public virtual KObject GetSystemUpdateNotificationEventForContentDelivery() => throw new NotImplementedException();
		public virtual void NotifySystemUpdateForContentDelivery() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.NotifySystemUpdateForContentDelivery [10]".Debug();
		public virtual void PrepareShutdown() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.PrepareShutdown [11]".Debug();
		public virtual void DestroySystemUpdateTask() => "Stub hit for Nn.Ns.Detail.ISystemUpdateInterface.DestroySystemUpdateTask [16]".Debug();
		public virtual void RequestSendSystemUpdate(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual object GetSendSystemUpdateProgress() => throw new NotImplementedException();
	}
	
	[IpcService("ns:vm")]
	public unsafe partial class IVulnerabilityManagerInterface : _Base_IVulnerabilityManagerInterface {}
	public unsafe class _Base_IVulnerabilityManagerInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1200: { // NeedsUpdateVulnerability
					var ret = NeedsUpdateVulnerability();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1201: { // UpdateSafeSystemVersionForDebug
					UpdateSafeSystemVersionForDebug(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1202: { // GetSafeSystemVersion
					var ret = GetSafeSystemVersion();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IVulnerabilityManagerInterface: {im.CommandId}");
			}
		}
		
		public virtual object NeedsUpdateVulnerability() => throw new NotImplementedException();
		public virtual void UpdateSafeSystemVersionForDebug(object _0) => "Stub hit for Nn.Ns.Detail.IVulnerabilityManagerInterface.UpdateSafeSystemVersionForDebug [1201]".Debug();
		public virtual object GetSafeSystemVersion() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAccountProxyInterface : _Base_IAccountProxyInterface {}
	public unsafe class _Base_IAccountProxyInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateUserAccount
					CreateUserAccount(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAccountProxyInterface: {im.CommandId}");
			}
		}
		
		public virtual void CreateUserAccount(object _0, Buffer<byte> _1) => "Stub hit for Nn.Ns.Detail.IAccountProxyInterface.CreateUserAccount [0]".Debug();
	}
	
	public unsafe partial class IApplicationVersionInterface : _Base_IApplicationVersionInterface {}
	public unsafe class _Base_IApplicationVersionInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 35: { // Unknown35
					Unknown35(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 36: { // Unknown36
					Unknown36(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 37: { // Unknown37
					Unknown37(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 800: { // Unknown800
					Unknown800();
					om.Initialize(0, 0, 0);
					break;
				}
				case 801: { // Unknown801
					Unknown801(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 802: { // Unknown802
					Unknown802(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 1000: { // Unknown1000
					Unknown1000();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationVersionInterface: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationVersionInterface.Unknown1 [1]".Debug();
		public virtual void Unknown35(Buffer<byte> _0) => "Stub hit for Nn.Ns.Detail.IApplicationVersionInterface.Unknown35 [35]".Debug();
		public virtual void Unknown36(object _0) => "Stub hit for Nn.Ns.Detail.IApplicationVersionInterface.Unknown36 [36]".Debug();
		public virtual void Unknown37(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown800() => "Stub hit for Nn.Ns.Detail.IApplicationVersionInterface.Unknown800 [800]".Debug();
		public virtual void Unknown801(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown802(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void Unknown1000() => "Stub hit for Nn.Ns.Detail.IApplicationVersionInterface.Unknown1000 [1000]".Debug();
	}
	
	public unsafe partial class IAsyncResult : _Base_IAsyncResult {}
	public unsafe class _Base_IAsyncResult : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncResult: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => "Stub hit for Nn.Ns.Detail.IAsyncResult.Unknown0 [0]".Debug();
		public virtual void Unknown1() => "Stub hit for Nn.Ns.Detail.IAsyncResult.Unknown1 [1]".Debug();
		public virtual void Unknown2(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAsyncValue : _Base_IAsyncValue {}
	public unsafe class _Base_IAsyncValue : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncValue: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown2() => "Stub hit for Nn.Ns.Detail.IAsyncValue.Unknown2 [2]".Debug();
		public virtual void Unknown3(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IContentManagementInterface : _Base_IContentManagementInterface {}
	public unsafe class _Base_IContentManagementInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 11: { // CalculateApplicationOccupiedSize
					var ret = CalculateApplicationOccupiedSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 43: { // CheckSdCardMountStatus
					CheckSdCardMountStatus();
					om.Initialize(0, 0, 0);
					break;
				}
				case 47: { // GetTotalSpaceSize
					var ret = GetTotalSpaceSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 48: { // GetFreeSpaceSize
					var ret = GetFreeSpaceSize(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 600: { // CountApplicationContentMeta
					var ret = CountApplicationContentMeta(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 601: { // ListApplicationContentMetaStatus
					ListApplicationContentMetaStatus(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 605: { // ListApplicationContentMetaStatusWithRightsCheck
					ListApplicationContentMetaStatusWithRightsCheck(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 607: { // IsAnyApplicationRunning
					var ret = IsAnyApplicationRunning();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContentManagementInterface: {im.CommandId}");
			}
		}
		
		public virtual object CalculateApplicationOccupiedSize(object _0) => throw new NotImplementedException();
		public virtual void CheckSdCardMountStatus() => "Stub hit for Nn.Ns.Detail.IContentManagementInterface.CheckSdCardMountStatus [43]".Debug();
		public virtual object GetTotalSpaceSize(object _0) => throw new NotImplementedException();
		public virtual object GetFreeSpaceSize(object _0) => throw new NotImplementedException();
		public virtual object CountApplicationContentMeta(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatus(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ListApplicationContentMetaStatusWithRightsCheck(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object IsAnyApplicationRunning() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDocumentInterface : _Base_IDocumentInterface {}
	public unsafe class _Base_IDocumentInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 21: { // GetApplicationContentPath
					GetApplicationContentPath(null, im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // ResolveApplicationContentPath
					ResolveApplicationContentPath(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDocumentInterface: {im.CommandId}");
			}
		}
		
		public virtual void GetApplicationContentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveApplicationContentPath(object _0) => "Stub hit for Nn.Ns.Detail.IDocumentInterface.ResolveApplicationContentPath [23]".Debug();
	}
	
	public unsafe partial class IDownloadTaskInterface : _Base_IDownloadTaskInterface {}
	public unsafe class _Base_IDownloadTaskInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 701: { // ClearTaskStatusList
					ClearTaskStatusList();
					om.Initialize(0, 0, 0);
					break;
				}
				case 702: { // RequestDownloadTaskList
					RequestDownloadTaskList();
					om.Initialize(0, 0, 0);
					break;
				}
				case 703: { // RequestEnsureDownloadTask
					RequestEnsureDownloadTask(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 704: { // ListDownloadTaskStatus
					ListDownloadTaskStatus(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 705: { // RequestDownloadTaskListData
					RequestDownloadTaskListData(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 706: { // TryCommitCurrentApplicationDownloadTask
					TryCommitCurrentApplicationDownloadTask();
					om.Initialize(0, 0, 0);
					break;
				}
				case 707: { // EnableAutoCommit
					EnableAutoCommit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 708: { // DisableAutoCommit
					DisableAutoCommit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 709: { // TriggerDynamicCommitEvent
					TriggerDynamicCommitEvent();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDownloadTaskInterface: {im.CommandId}");
			}
		}
		
		public virtual void ClearTaskStatusList() => "Stub hit for Nn.Ns.Detail.IDownloadTaskInterface.ClearTaskStatusList [701]".Debug();
		public virtual void RequestDownloadTaskList() => "Stub hit for Nn.Ns.Detail.IDownloadTaskInterface.RequestDownloadTaskList [702]".Debug();
		public virtual void RequestEnsureDownloadTask(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void ListDownloadTaskStatus(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestDownloadTaskListData(out KObject _0, out Nn.Ns.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void TryCommitCurrentApplicationDownloadTask() => "Stub hit for Nn.Ns.Detail.IDownloadTaskInterface.TryCommitCurrentApplicationDownloadTask [706]".Debug();
		public virtual void EnableAutoCommit() => "Stub hit for Nn.Ns.Detail.IDownloadTaskInterface.EnableAutoCommit [707]".Debug();
		public virtual void DisableAutoCommit() => "Stub hit for Nn.Ns.Detail.IDownloadTaskInterface.DisableAutoCommit [708]".Debug();
		public virtual void TriggerDynamicCommitEvent() => "Stub hit for Nn.Ns.Detail.IDownloadTaskInterface.TriggerDynamicCommitEvent [709]".Debug();
	}
	
	public unsafe partial class IECommerceInterface : _Base_IECommerceInterface {}
	public unsafe class _Base_IECommerceInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 100: { // ResetToFactorySettings
					ResetToFactorySettings();
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // ResetToFactorySettingsWithoutUserSaveData
					ResetToFactorySettingsWithoutUserSaveData();
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // ResetToFactorySettingsForRefurbishment
					ResetToFactorySettingsForRefurbishment();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFactoryResetInterface: {im.CommandId}");
			}
		}
		
		public virtual void ResetToFactorySettings() => "Stub hit for Nn.Ns.Detail.IFactoryResetInterface.ResetToFactorySettings [100]".Debug();
		public virtual void ResetToFactorySettingsWithoutUserSaveData() => "Stub hit for Nn.Ns.Detail.IFactoryResetInterface.ResetToFactorySettingsWithoutUserSaveData [101]".Debug();
		public virtual void ResetToFactorySettingsForRefurbishment() => "Stub hit for Nn.Ns.Detail.IFactoryResetInterface.ResetToFactorySettingsForRefurbishment [102]".Debug();
	}
	
	public unsafe partial class IGameCardStopper : _Base_IGameCardStopper {}
	public unsafe class _Base_IGameCardStopper : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				default:
					throw new NotImplementedException($"Unhandled command ID to IGameCardStopper: {im.CommandId}");
			}
		}
		
	}
	
	public unsafe partial class IProgressAsyncResult : _Base_IProgressAsyncResult {}
	public unsafe class _Base_IProgressAsyncResult : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProgressAsyncResult: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => "Stub hit for Nn.Ns.Detail.IProgressAsyncResult.Unknown0 [0]".Debug();
		public virtual void Unknown1() => "Stub hit for Nn.Ns.Detail.IProgressAsyncResult.Unknown1 [1]".Debug();
		public virtual void Unknown2(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown3() => "Stub hit for Nn.Ns.Detail.IProgressAsyncResult.Unknown3 [3]".Debug();
		public virtual void Unknown4(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IProgressMonitorForDeleteUserSaveDataAll : _Base_IProgressMonitorForDeleteUserSaveDataAll {}
	public unsafe class _Base_IProgressMonitorForDeleteUserSaveDataAll : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Unknown10
					var ret = Unknown10();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProgressMonitorForDeleteUserSaveDataAll: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => "Stub hit for Nn.Ns.Detail.IProgressMonitorForDeleteUserSaveDataAll.Unknown2 [2]".Debug();
		public virtual object Unknown10() => throw new NotImplementedException();
	}
	
	public unsafe partial class IRequestServerStopper : _Base_IRequestServerStopper {}
	public unsafe class _Base_IRequestServerStopper : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequestServerStopper: {im.CommandId}");
			}
		}
		
	}
	
	public unsafe partial class ISystemUpdateControl : _Base_ISystemUpdateControl {}
	public unsafe class _Base_ISystemUpdateControl : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 2: { // Unknown2
					Unknown2(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5(out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // Unknown8
					Unknown8();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // Unknown9
					var ret = Unknown9(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Unknown10
					Unknown10(im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Unknown11
					Unknown11(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // Unknown13
					Unknown13(im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // Unknown14
					Unknown14(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // Unknown15
					var ret = Unknown15();
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // Unknown16
					Unknown16(null, im.GetBuffer<byte>(0x15, 0), out var _0, out var _1);
					om.Initialize(1, 1, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 17: { // Unknown17
					var ret = Unknown17();
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // Unknown18
					Unknown18();
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // Unknown19
					var ret = Unknown19(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // Unknown20
					Unknown20(im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // Unknown21
					Unknown21();
					om.Initialize(0, 0, 0);
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
		public virtual void Unknown4() => "Stub hit for Nn.Ns.Detail.ISystemUpdateControl.Unknown4 [4]".Debug();
		public virtual void Unknown5(out KObject _0, out Nn.Ns.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual object Unknown6() => throw new NotImplementedException();
		public virtual object Unknown7() => throw new NotImplementedException();
		public virtual void Unknown8() => "Stub hit for Nn.Ns.Detail.ISystemUpdateControl.Unknown8 [8]".Debug();
		public virtual object Unknown9(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown10(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown11(object _0, KObject _1) => "Stub hit for Nn.Ns.Detail.ISystemUpdateControl.Unknown11 [11]".Debug();
		public virtual object Unknown12(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown13(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown14(object _0, KObject _1) => "Stub hit for Nn.Ns.Detail.ISystemUpdateControl.Unknown14 [14]".Debug();
		public virtual object Unknown15() => throw new NotImplementedException();
		public virtual void Unknown16(object _0, Buffer<byte> _1, out KObject _2, out Nn.Ns.Detail.IAsyncResult _3) => throw new NotImplementedException();
		public virtual object Unknown17() => throw new NotImplementedException();
		public virtual void Unknown18() => "Stub hit for Nn.Ns.Detail.ISystemUpdateControl.Unknown18 [18]".Debug();
		public virtual object Unknown19(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown20(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown21() => "Stub hit for Nn.Ns.Detail.ISystemUpdateControl.Unknown21 [21]".Debug();
	}
}
