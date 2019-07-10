using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.friends.detail.ipc {
	[IpcService("friend:u")]
	[IpcService("friend:v")]
	[IpcService("friend:m")]
	[IpcService("friend:s")]
	[IpcService("friend:a")]
	public class IServiceCreator : IpcInterface {
		[IpcCommand(0)]
		void CreateFriendService([Move] out IFriendService service) => service = new IFriendService();
		[IpcCommand(1)]
		void CreateNotificationService([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(2)]
		void CreateDaemonSuspendSessionService(out object unknown0) => throw new NotImplementedException();
	}
	
	public class IFriendService : IpcInterface {
		[IpcCommand(0)]
		void GetCompletionEvent([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(1)]
		void Cancel() => throw new NotImplementedException();
		[IpcCommand(10100)]
		void GetFriendListIds(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::detail::ipc::SizedFriendFilter */ unknown2, ulong unknown3, [Pid] ulong pid, out uint unknown4, [Buffer(0xa)] Buffer<ulong /* nn::account::NetworkServiceAccountId */> unknown5) => throw new NotImplementedException();
		[IpcCommand(10101)]
		void GetFriendList(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::detail::ipc::SizedFriendFilter */ unknown2, ulong unknown3, [Pid] ulong pid, out uint unknown4, [Buffer(0x6)] Buffer<byte> friend) => throw new NotImplementedException();
		[IpcCommand(10102)]
		void UpdateFriendInfo([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong unknown1, [Pid] ulong pid, [Buffer(0x9)] Buffer<ulong /* nn::account::NetworkServiceAccountId */> unknown2, [Buffer(0x6)] Buffer<byte> friend) => throw new NotImplementedException();
		[IpcCommand(10110)]
		void GetFriendProfileImage([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, out uint unknown2, [Buffer(0x6)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(10200)]
		void SendFriendRequestForApplication([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, ulong unknown2, [Pid] ulong pid, [Buffer(0x19)] Buffer<byte> screenName, [Buffer(0x19)] Buffer<byte> screenName2) => throw new NotImplementedException();
		[IpcCommand(10211)]
		void AddFacedFriendRequestForApplication([Bytes(0x40 /* 64 x 1 */)] byte[] /* nn::friends::FacedFriendRequestRegistrationKey */ unknown0, [Bytes(0x21 /* 33 x 1 */)] byte[] /* nn::account::Nickname */ unknown1, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown2, ulong unknown3, [Pid] ulong pid, [Buffer(0x19)] Buffer<byte> screenName, [Buffer(0x19)] Buffer<byte> screenName2, [Buffer(0x5)] Buffer<byte> unknown6) => throw new NotImplementedException();
		[IpcCommand(10400)]
		void GetBlockedUserListIds(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, out uint unknown2, [Buffer(0xa)] Buffer<ulong /* nn::account::NetworkServiceAccountId */> unknown3) => throw new NotImplementedException();
		[IpcCommand(10500)]
		void GetProfileList([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Buffer(0x9)] Buffer<ulong /* nn::account::NetworkServiceAccountId */> unknown1, [Buffer(0x6)] Buffer<byte> profile) => throw new NotImplementedException();
		[IpcCommand(10600)]
		void DeclareOpenOnlinePlaySession([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(10601)]
		void DeclareCloseOnlinePlaySession([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(10610)]
		void UpdateUserPresence([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong unknown1, [Pid] ulong pid, [Buffer(0x19)] Buffer<byte> userPresence) => throw new NotImplementedException();
		[IpcCommand(10700)]
		void GetPlayHistoryRegistrationKey(bool unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, [Buffer(0x1a)] Buffer<byte> playHistoryRegKey) => throw new NotImplementedException();
		[IpcCommand(10701)]
		void GetPlayHistoryRegistrationKeyWithNetworkServiceAccountId(bool unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, [Buffer(0x1a)] Buffer<byte> playHistoryRegKey) => throw new NotImplementedException();
		[IpcCommand(10702)]
		void AddPlayHistory([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong unknown1, [Pid] ulong pid, [Buffer(0x19)] Buffer<byte> palyHistoryRegKey, [Buffer(0x19)] Buffer<byte> screenName, [Buffer(0x19)] Buffer<byte> screenName2) => throw new NotImplementedException();
		[IpcCommand(11000)]
		void GetProfileImageUrl([Bytes(0xa0 /* 160 x 1 */)] byte[] /* nn::friends::Url */ unknown0, uint unknown1, [Bytes(0xa0 /* 160 x 1 */)] out byte[] /* nn::friends::Url */ unknown2) => throw new NotImplementedException();
		[IpcCommand(20100)]
		void GetFriendCount([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::detail::ipc::SizedFriendFilter */ unknown1, ulong unknown2, [Pid] ulong pid, out uint unknown3) => throw new NotImplementedException();
		[IpcCommand(20101)]
		void GetNewlyFriendCount([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(20102)]
		void GetFriendDetailedInfo([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, [Buffer(0x1a)] Buffer<byte> friendDetailedInfo) => throw new NotImplementedException();
		[IpcCommand(20103)]
		void SyncFriendList([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(20104)]
		void RequestSyncFriendList([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(20110)]
		void LoadFriendSetting([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, [Buffer(0x1a)] Buffer<byte> friendSetting) => throw new NotImplementedException();
		[IpcCommand(20200)]
		void GetReceivedFriendRequestCount([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, out uint unknown1, out uint unknown2) => throw new NotImplementedException();
		[IpcCommand(20201)]
		void GetFriendRequestList(uint unknown0, uint unknown1, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown2, out uint unknown3, [Buffer(0x6)] Buffer<byte> friendRequest) => throw new NotImplementedException();
		[IpcCommand(20300)]
		void GetFriendCandidateList(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, out uint unknown2, [Buffer(0x6)] Buffer<byte> friendCandidate) => throw new NotImplementedException();
		[IpcCommand(20301)]
		void GetNintendoNetworkIdInfo(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, out uint unknown2, [Buffer(0x1a)] Buffer<byte> nnid, [Buffer(0x6)] Buffer<byte> nnidFriend) => throw new NotImplementedException();
		[IpcCommand(20302)]
		void GetSnsAccountLinkage(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(20303)]
		void GetSnsAccountProfile(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(20304)]
		void GetSnsAccountFriendList(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(20400)]
		void GetBlockedUserList(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, out uint unknown2, [Buffer(0x6)] Buffer<byte> blockedUser) => throw new NotImplementedException();
		[IpcCommand(20401)]
		void SyncBlockedUserList([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(20500)]
		void GetProfileExtraList([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Buffer(0x9)] Buffer<ulong /* nn::account::NetworkServiceAccountId */> unknown1, [Buffer(0x6)] Buffer<byte> profileExtra) => throw new NotImplementedException();
		[IpcCommand(20501)]
		void GetRelationship([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, [Bytes(0x8 /* 8 x 1 */)] out byte[] relationship) => throw new NotImplementedException();
		[IpcCommand(20600)]
		void GetUserPresenceView([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Buffer(0x1a)] Buffer<byte> userPresenceView) => throw new NotImplementedException();
		[IpcCommand(20700)]
		void GetPlayHistoryList(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, out uint unknown2, [Buffer(0x6)] Buffer<byte> playHistory) => throw new NotImplementedException();
		[IpcCommand(20701)]
		void GetPlayHistoryStatistics([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] playHistoryStats) => throw new NotImplementedException();
		[IpcCommand(20800)]
		void LoadUserSetting([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Buffer(0x1a)] Buffer<byte> userSetting) => throw new NotImplementedException();
		[IpcCommand(20801)]
		void SyncUserSetting([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(20900)]
		void RequestListSummaryOverlayNotification() => throw new NotImplementedException();
		[IpcCommand(21000)]
		void GetExternalApplicationCatalog([Bytes(0x8 /* 8 x 1 */)] byte[] /* nn::settings::LanguageCode */ unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::ExternalApplicationCatalogId */ unknown1, [Buffer(0x1a)] Buffer<byte> externalAppCatalog) => throw new NotImplementedException();
		[IpcCommand(30100)]
		void DropFriendNewlyFlags([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(30101)]
		void DeleteFriend([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30110)]
		void DropFriendNewlyFlag([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30120)]
		void ChangeFriendFavoriteFlag(bool unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2) => throw new NotImplementedException();
		[IpcCommand(30121)]
		void ChangeFriendOnlineNotificationFlag(bool unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2) => throw new NotImplementedException();
		[IpcCommand(30200)]
		void SendFriendRequest(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2) => throw new NotImplementedException();
		[IpcCommand(30201)]
		void SendFriendRequestWithApplicationInfo(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::ApplicationInfo */ unknown3, [Buffer(0x19)] Buffer<byte> screenName, [Buffer(0x19)] Buffer<byte> screenName2) => throw new NotImplementedException();
		[IpcCommand(30202)]
		void CancelFriendRequest([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::friends::RequestId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30203)]
		void AcceptFriendRequest([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::friends::RequestId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30204)]
		void RejectFriendRequest([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::friends::RequestId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30205)]
		void ReadFriendRequest([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::friends::RequestId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30210)]
		void GetFacedFriendRequestRegistrationKey([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, [Bytes(0x40 /* 64 x 1 */)] out byte[] facedFriendRequestRegKey) => throw new NotImplementedException();
		[IpcCommand(30211)]
		void AddFacedFriendRequest([Bytes(0x40 /* 64 x 1 */)] byte[] /* nn::friends::FacedFriendRequestRegistrationKey */ unknown0, [Bytes(0x21 /* 33 x 1 */)] byte[] /* nn::account::Nickname */ unknown1, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown2, [Buffer(0x5)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(30212)]
		void CancelFacedFriendRequest([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30213)]
		void GetFacedFriendRequestProfileImage([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1, out uint unknown2, [Buffer(0x6)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(30214)]
		void GetFacedFriendRequestProfileImageFromPath([Buffer(0x9)] Buffer<byte> unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(30215)]
		void SendFriendRequestWithExternalApplicationCatalogId(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::ExternalApplicationCatalogId */ unknown3, [Buffer(0x19)] Buffer<byte> screenName, [Buffer(0x19)] Buffer<byte> screenName2) => throw new NotImplementedException();
		[IpcCommand(30216)]
		void ResendFacedFriendRequest([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30217)]
		void SendFriendRequestWithNintendoNetworkIdInfo([Bytes(0x20 /* 32 x 1 */)] byte[] /* nn::friends::MiiName */ unknown0, [Bytes(0x10 /* 16 x 1 */)] byte[] /* nn::friends::MiiImageUrlParam */ unknown1, [Bytes(0x20 /* 32 x 1 */)] byte[] /* nn::friends::MiiName */ unknown2, [Bytes(0x10 /* 16 x 1 */)] byte[] /* nn::friends::MiiImageUrlParam */ unknown3, uint unknown4, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown5, ulong /* nn::account::NetworkServiceAccountId */ unknown6) => throw new NotImplementedException();
		[IpcCommand(30300)]
		void GetSnsAccountLinkPageUrl(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(30301)]
		void UnlinkSnsAccount(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(30400)]
		void BlockUser(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2) => throw new NotImplementedException();
		[IpcCommand(30401)]
		void BlockUserWithApplicationInfo(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, ulong /* nn::account::NetworkServiceAccountId */ unknown2, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::friends::ApplicationInfo */ unknown3, [Buffer(0x19)] Buffer<byte> screenName) => throw new NotImplementedException();
		[IpcCommand(30402)]
		void UnblockUser([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0, ulong /* nn::account::NetworkServiceAccountId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30500)]
		void GetProfileExtraFromFriendCode([Bytes(0x20 /* 32 x 1 */)] byte[] /* nn::friends::FriendCode */ unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1, [Buffer(0x1a)] Buffer<byte> profileExtra) => throw new NotImplementedException();
		[IpcCommand(30700)]
		void DeletePlayHistory([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(30810)]
		void ChangePresencePermission(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30811)]
		void ChangeFriendRequestReception(bool unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30812)]
		void ChangePlayLogPermission(uint unknown0, [Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown1) => throw new NotImplementedException();
		[IpcCommand(30820)]
		void IssueFriendCode([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(30830)]
		void ClearPlayLog([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(49900)]
		void DeleteNetworkServiceAccountCache([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ unknown0) => throw new NotImplementedException();
	}
}
