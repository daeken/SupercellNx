#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Friends.Detail.Ipc {
	[IpcService("friend:u")]
	[IpcService("friend:v")]
	[IpcService("friend:m")]
	[IpcService("friend:s")]
	[IpcService("friend:a")]
	public unsafe partial class IServiceCreator : _Base_IServiceCreator {}
	public unsafe class _Base_IServiceCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateFriendService
					var ret = CreateFriendService();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // CreateNotificationService
					var ret = CreateNotificationService(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // CreateDaemonSuspendSessionService
					var ret = CreateDaemonSuspendSessionService();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Friends.Detail.Ipc.IFriendService CreateFriendService() => throw new NotImplementedException();
		public virtual Nn.Friends.Detail.Ipc.INotificationService CreateNotificationService(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Friends.Detail.Ipc.IDaemonSuspendSessionService CreateDaemonSuspendSessionService() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDaemonSuspendSessionService : _Base_IDaemonSuspendSessionService {}
	public unsafe class _Base_IDaemonSuspendSessionService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				default:
					throw new NotImplementedException($"Unhandled command ID to IDaemonSuspendSessionService: {im.CommandId}");
			}
		}
		
	}
	
	public unsafe partial class IFriendService : _Base_IFriendService {}
	public unsafe class _Base_IFriendService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCompletionEvent
					var ret = GetCompletionEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10100: { // GetFriendListIds
					GetFriendListIds(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetBytes(28, 0x10), im.GetData<ulong>(48), im.Pid, out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 10101: { // GetFriendList
					GetFriendList(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetBytes(28, 0x10), im.GetData<ulong>(48), im.Pid, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 10102: { // UpdateFriendInfo
					UpdateFriendInfo(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.Pid, im.GetBuffer<ulong>(0x9, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10110: { // GetFriendProfileImage
					GetFriendProfileImage(im.GetBytes(8, 0x10), im.GetData<ulong>(24), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 10200: { // SendFriendRequestForApplication
					SendFriendRequestForApplication(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.GetData<ulong>(32), im.Pid, im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10211: { // AddFacedFriendRequestForApplication
					AddFacedFriendRequestForApplication(im.GetBytes(8, 0x40), im.GetBytes(72, 0x21), im.GetBytes(105, 0x10), im.GetData<ulong>(128), im.Pid, im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10400: { // GetBlockedUserListIds
					GetBlockedUserListIds(im.GetData<uint>(8), im.GetBytes(12, 0x10), out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 10500: { // GetProfileList
					GetProfileList(im.GetBytes(8, 0x10), im.GetBuffer<ulong>(0x9, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10600: { // DeclareOpenOnlinePlaySession
					DeclareOpenOnlinePlaySession(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10601: { // DeclareCloseOnlinePlaySession
					DeclareCloseOnlinePlaySession(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10610: { // UpdateUserPresence
					UpdateUserPresence(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.Pid, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10700: { // GetPlayHistoryRegistrationKey
					GetPlayHistoryRegistrationKey(im.GetData<byte>(8), im.GetBytes(9, 0x10), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10701: { // GetPlayHistoryRegistrationKeyWithNetworkServiceAccountId
					GetPlayHistoryRegistrationKeyWithNetworkServiceAccountId(im.GetData<byte>(8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10702: { // AddPlayHistory
					AddPlayHistory(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.Pid, im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1), im.GetBuffer<byte>(0x19, 2));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11000: { // GetProfileImageUrl
					GetProfileImageUrl(im.GetBytes(8, 0xA0), im.GetData<uint>(168), out var _0);
					om.Initialize(0, 0, 160);
					om.SetBytes(8, _0);
					break;
				}
				case 20100: { // GetFriendCount
					var ret = GetFriendCount(im.GetBytes(8, 0x10), im.GetBytes(24, 0x10), im.GetData<ulong>(40), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20101: { // GetNewlyFriendCount
					var ret = GetNewlyFriendCount(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20102: { // GetFriendDetailedInfo
					GetFriendDetailedInfo(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20103: { // SyncFriendList
					SyncFriendList(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20104: { // RequestSyncFriendList
					RequestSyncFriendList(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20110: { // LoadFriendSetting
					LoadFriendSetting(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20200: { // GetReceivedFriendRequestCount
					GetReceivedFriendRequestCount(im.GetBytes(8, 0x10), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 20201: { // GetFriendRequestList
					GetFriendRequestList(im.GetData<uint>(8), im.GetData<uint>(12), im.GetBytes(16, 0x10), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 20300: { // GetFriendCandidateList
					GetFriendCandidateList(im.GetData<uint>(8), im.GetBytes(12, 0x10), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 20301: { // GetNintendoNetworkIdInfo
					GetNintendoNetworkIdInfo(im.GetData<uint>(8), im.GetBytes(12, 0x10), out var _0, im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 20302: { // GetSnsAccountLinkage
					var ret = GetSnsAccountLinkage(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 20303: { // GetSnsAccountProfile
					var ret = GetSnsAccountProfile(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 20304: { // GetSnsAccountFriendList
					var ret = GetSnsAccountFriendList(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 20400: { // GetBlockedUserList
					GetBlockedUserList(im.GetData<uint>(8), im.GetBytes(12, 0x10), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 20401: { // SyncBlockedUserList
					SyncBlockedUserList(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20500: { // GetProfileExtraList
					GetProfileExtraList(im.GetBytes(8, 0x10), im.GetBuffer<ulong>(0x9, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20501: { // GetRelationship
					GetRelationship(im.GetBytes(8, 0x10), im.GetData<ulong>(24), out var _0);
					om.Initialize(0, 0, 8);
					om.SetBytes(8, _0);
					break;
				}
				case 20600: { // GetUserPresenceView
					GetUserPresenceView(im.GetBytes(8, 0x10), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20700: { // GetPlayHistoryList
					GetPlayHistoryList(im.GetData<uint>(8), im.GetBytes(12, 0x10), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 20701: { // GetPlayHistoryStatistics
					GetPlayHistoryStatistics(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 20800: { // LoadUserSetting
					LoadUserSetting(im.GetBytes(8, 0x10), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20801: { // SyncUserSetting
					SyncUserSetting(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20900: { // RequestListSummaryOverlayNotification
					RequestListSummaryOverlayNotification();
					om.Initialize(0, 0, 0);
					break;
				}
				case 21000: { // GetExternalApplicationCatalog
					GetExternalApplicationCatalog(im.GetBytes(8, 0x8), im.GetBytes(16, 0x10), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30100: { // DropFriendNewlyFlags
					DropFriendNewlyFlags(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30101: { // DeleteFriend
					DeleteFriend(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30110: { // DropFriendNewlyFlag
					DropFriendNewlyFlag(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30120: { // ChangeFriendFavoriteFlag
					ChangeFriendFavoriteFlag(im.GetData<byte>(8), im.GetBytes(9, 0x10), im.GetData<ulong>(32));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30121: { // ChangeFriendOnlineNotificationFlag
					ChangeFriendOnlineNotificationFlag(im.GetData<byte>(8), im.GetBytes(9, 0x10), im.GetData<ulong>(32));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30200: { // SendFriendRequest
					SendFriendRequest(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetData<ulong>(32));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30201: { // SendFriendRequestWithApplicationInfo
					SendFriendRequestWithApplicationInfo(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetData<ulong>(32), im.GetBytes(40, 0x10), im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30202: { // CancelFriendRequest
					CancelFriendRequest(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30203: { // AcceptFriendRequest
					AcceptFriendRequest(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30204: { // RejectFriendRequest
					RejectFriendRequest(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30205: { // ReadFriendRequest
					ReadFriendRequest(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30210: { // GetFacedFriendRequestRegistrationKey
					GetFacedFriendRequestRegistrationKey(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 64);
					om.SetBytes(8, _0);
					break;
				}
				case 30211: { // AddFacedFriendRequest
					AddFacedFriendRequest(im.GetBytes(8, 0x40), im.GetBytes(72, 0x21), im.GetBytes(105, 0x10), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30212: { // CancelFacedFriendRequest
					CancelFacedFriendRequest(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30213: { // GetFacedFriendRequestProfileImage
					GetFacedFriendRequestProfileImage(im.GetBytes(8, 0x10), im.GetData<ulong>(24), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 30214: { // GetFacedFriendRequestProfileImageFromPath
					GetFacedFriendRequestProfileImageFromPath(im.GetBuffer<byte>(0x9, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 30215: { // SendFriendRequestWithExternalApplicationCatalogId
					SendFriendRequestWithExternalApplicationCatalogId(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetData<ulong>(32), im.GetBytes(40, 0x10), im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30216: { // ResendFacedFriendRequest
					ResendFacedFriendRequest(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30217: { // SendFriendRequestWithNintendoNetworkIdInfo
					SendFriendRequestWithNintendoNetworkIdInfo(im.GetBytes(8, 0x20), im.GetBytes(40, 0x10), im.GetBytes(56, 0x20), im.GetBytes(88, 0x10), im.GetData<uint>(104), im.GetBytes(108, 0x10), im.GetData<ulong>(128));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30300: { // GetSnsAccountLinkPageUrl
					var ret = GetSnsAccountLinkPageUrl(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 30301: { // UnlinkSnsAccount
					var ret = UnlinkSnsAccount(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 30400: { // BlockUser
					BlockUser(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetData<ulong>(32));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30401: { // BlockUserWithApplicationInfo
					BlockUserWithApplicationInfo(im.GetData<uint>(8), im.GetBytes(12, 0x10), im.GetData<ulong>(32), im.GetBytes(40, 0x10), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30402: { // UnblockUser
					UnblockUser(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30500: { // GetProfileExtraFromFriendCode
					GetProfileExtraFromFriendCode(im.GetBytes(8, 0x20), im.GetBytes(40, 0x10), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30700: { // DeletePlayHistory
					DeletePlayHistory(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30810: { // ChangePresencePermission
					ChangePresencePermission(im.GetData<uint>(8), im.GetBytes(12, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30811: { // ChangeFriendRequestReception
					ChangeFriendRequestReception(im.GetData<byte>(8), im.GetBytes(9, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30812: { // ChangePlayLogPermission
					ChangePlayLogPermission(im.GetData<uint>(8), im.GetBytes(12, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30820: { // IssueFriendCode
					IssueFriendCode(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30830: { // ClearPlayLog
					ClearPlayLog(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 49900: { // DeleteNetworkServiceAccountCache
					DeleteNetworkServiceAccountCache(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFriendService: {im.CommandId}");
			}
		}
		
		public virtual KObject GetCompletionEvent() => throw new NotImplementedException();
		public virtual void Cancel() => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.Cancel [1]".Debug();
		public virtual void GetFriendListIds(uint _0, byte[] _1, byte[] _2, ulong _3, ulong _4, out uint _5, Buffer<ulong> _6) => throw new NotImplementedException();
		public virtual void GetFriendList(uint _0, byte[] _1, byte[] _2, ulong _3, ulong _4, out uint _5, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void UpdateFriendInfo(byte[] _0, ulong _1, ulong _2, Buffer<ulong> _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void GetFriendProfileImage(byte[] _0, ulong _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void SendFriendRequestForApplication(byte[] _0, ulong _1, ulong _2, ulong _3, Buffer<byte> _4, Buffer<byte> _5) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SendFriendRequestForApplication [10200]".Debug();
		public virtual void AddFacedFriendRequestForApplication(byte[] _0, byte[] _1, byte[] _2, ulong _3, ulong _4, Buffer<byte> _5, Buffer<byte> _6, Buffer<byte> _7) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.AddFacedFriendRequestForApplication [10211]".Debug();
		public virtual void GetBlockedUserListIds(uint _0, byte[] _1, out uint _2, Buffer<ulong> _3) => throw new NotImplementedException();
		public virtual void GetProfileList(byte[] _0, Buffer<ulong> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void DeclareOpenOnlinePlaySession(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DeclareOpenOnlinePlaySession [10600]".Debug();
		public virtual void DeclareCloseOnlinePlaySession(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DeclareCloseOnlinePlaySession [10601]".Debug();
		public virtual void UpdateUserPresence(byte[] _0, ulong _1, ulong _2, Buffer<byte> _3) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.UpdateUserPresence [10610]".Debug();
		public virtual void GetPlayHistoryRegistrationKey(byte _0, byte[] _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetPlayHistoryRegistrationKeyWithNetworkServiceAccountId(byte _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void AddPlayHistory(byte[] _0, ulong _1, ulong _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.AddPlayHistory [10702]".Debug();
		public virtual void GetProfileImageUrl(byte[] _0, uint _1, out byte[] _2) => throw new NotImplementedException();
		public virtual uint GetFriendCount(byte[] _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual uint GetNewlyFriendCount(byte[] _0) => throw new NotImplementedException();
		public virtual void GetFriendDetailedInfo(byte[] _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SyncFriendList(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SyncFriendList [20103]".Debug();
		public virtual void RequestSyncFriendList(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.RequestSyncFriendList [20104]".Debug();
		public virtual void LoadFriendSetting(byte[] _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetReceivedFriendRequestCount(byte[] _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void GetFriendRequestList(uint _0, uint _1, byte[] _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void GetFriendCandidateList(uint _0, byte[] _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void GetNintendoNetworkIdInfo(uint _0, byte[] _1, out uint _2, Buffer<byte> _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual object GetSnsAccountLinkage(object _0) => throw new NotImplementedException();
		public virtual object GetSnsAccountProfile(object _0) => throw new NotImplementedException();
		public virtual object GetSnsAccountFriendList(object _0) => throw new NotImplementedException();
		public virtual void GetBlockedUserList(uint _0, byte[] _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void SyncBlockedUserList(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SyncBlockedUserList [20401]".Debug();
		public virtual void GetProfileExtraList(byte[] _0, Buffer<ulong> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetRelationship(byte[] _0, ulong _1, out byte[] _2) => throw new NotImplementedException();
		public virtual void GetUserPresenceView(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetPlayHistoryList(uint _0, byte[] _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void GetPlayHistoryStatistics(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void LoadUserSetting(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SyncUserSetting(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SyncUserSetting [20801]".Debug();
		public virtual void RequestListSummaryOverlayNotification() => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.RequestListSummaryOverlayNotification [20900]".Debug();
		public virtual void GetExternalApplicationCatalog(byte[] _0, byte[] _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void DropFriendNewlyFlags(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DropFriendNewlyFlags [30100]".Debug();
		public virtual void DeleteFriend(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DeleteFriend [30101]".Debug();
		public virtual void DropFriendNewlyFlag(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DropFriendNewlyFlag [30110]".Debug();
		public virtual void ChangeFriendFavoriteFlag(byte _0, byte[] _1, ulong _2) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ChangeFriendFavoriteFlag [30120]".Debug();
		public virtual void ChangeFriendOnlineNotificationFlag(byte _0, byte[] _1, ulong _2) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ChangeFriendOnlineNotificationFlag [30121]".Debug();
		public virtual void SendFriendRequest(uint _0, byte[] _1, ulong _2) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SendFriendRequest [30200]".Debug();
		public virtual void SendFriendRequestWithApplicationInfo(uint _0, byte[] _1, ulong _2, byte[] _3, Buffer<byte> _4, Buffer<byte> _5) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SendFriendRequestWithApplicationInfo [30201]".Debug();
		public virtual void CancelFriendRequest(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.CancelFriendRequest [30202]".Debug();
		public virtual void AcceptFriendRequest(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.AcceptFriendRequest [30203]".Debug();
		public virtual void RejectFriendRequest(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.RejectFriendRequest [30204]".Debug();
		public virtual void ReadFriendRequest(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ReadFriendRequest [30205]".Debug();
		public virtual void GetFacedFriendRequestRegistrationKey(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void AddFacedFriendRequest(byte[] _0, byte[] _1, byte[] _2, Buffer<byte> _3) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.AddFacedFriendRequest [30211]".Debug();
		public virtual void CancelFacedFriendRequest(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.CancelFacedFriendRequest [30212]".Debug();
		public virtual void GetFacedFriendRequestProfileImage(byte[] _0, ulong _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void GetFacedFriendRequestProfileImageFromPath(Buffer<byte> _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SendFriendRequestWithExternalApplicationCatalogId(uint _0, byte[] _1, ulong _2, byte[] _3, Buffer<byte> _4, Buffer<byte> _5) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SendFriendRequestWithExternalApplicationCatalogId [30215]".Debug();
		public virtual void ResendFacedFriendRequest(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ResendFacedFriendRequest [30216]".Debug();
		public virtual void SendFriendRequestWithNintendoNetworkIdInfo(byte[] _0, byte[] _1, byte[] _2, byte[] _3, uint _4, byte[] _5, ulong _6) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.SendFriendRequestWithNintendoNetworkIdInfo [30217]".Debug();
		public virtual object GetSnsAccountLinkPageUrl(object _0) => throw new NotImplementedException();
		public virtual object UnlinkSnsAccount(object _0) => throw new NotImplementedException();
		public virtual void BlockUser(uint _0, byte[] _1, ulong _2) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.BlockUser [30400]".Debug();
		public virtual void BlockUserWithApplicationInfo(uint _0, byte[] _1, ulong _2, byte[] _3, Buffer<byte> _4) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.BlockUserWithApplicationInfo [30401]".Debug();
		public virtual void UnblockUser(byte[] _0, ulong _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.UnblockUser [30402]".Debug();
		public virtual void GetProfileExtraFromFriendCode(byte[] _0, byte[] _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void DeletePlayHistory(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DeletePlayHistory [30700]".Debug();
		public virtual void ChangePresencePermission(uint _0, byte[] _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ChangePresencePermission [30810]".Debug();
		public virtual void ChangeFriendRequestReception(byte _0, byte[] _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ChangeFriendRequestReception [30811]".Debug();
		public virtual void ChangePlayLogPermission(uint _0, byte[] _1) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ChangePlayLogPermission [30812]".Debug();
		public virtual void IssueFriendCode(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.IssueFriendCode [30820]".Debug();
		public virtual void ClearPlayLog(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.ClearPlayLog [30830]".Debug();
		public virtual void DeleteNetworkServiceAccountCache(byte[] _0) => "Stub hit for Nn.Friends.Detail.Ipc.IFriendService.DeleteNetworkServiceAccountCache [49900]".Debug();
	}
	
	public unsafe partial class IFriendServiceCreator : _Base_IFriendServiceCreator {}
	public unsafe class _Base_IFriendServiceCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Create
					var ret = Create();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFriendServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Friends.Detail.Ipc.IFriendService Create() => throw new NotImplementedException();
	}
	
	public unsafe partial class INotificationService : _Base_INotificationService {}
	public unsafe class _Base_INotificationService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetEvent
					var ret = GetEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Clear
					Clear();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Pop
					Pop(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INotificationService: {im.CommandId}");
			}
		}
		
		public virtual KObject GetEvent() => throw new NotImplementedException();
		public virtual void Clear() => "Stub hit for Nn.Friends.Detail.Ipc.INotificationService.Clear [1]".Debug();
		public virtual void Pop(out byte[] _0) => throw new NotImplementedException();
	}
}
