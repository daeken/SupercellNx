#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nim.Detail {
	[IpcService("nim")]
	public unsafe partial class INetworkInstallManager : _Base_INetworkInstallManager {}
	public unsafe class _Base_INetworkInstallManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateSystemUpdateTask
					var ret = CreateSystemUpdateTask(null);
					break;
				}
				case 1: { // DestroySystemUpdateTask
					DestroySystemUpdateTask(null);
					break;
				}
				case 2: { // ListSystemUpdateTask
					ListSystemUpdateTask(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // RequestSystemUpdateTaskRun
					RequestSystemUpdateTaskRun(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 4: { // GetSystemUpdateTaskInfo
					var ret = GetSystemUpdateTaskInfo(null);
					break;
				}
				case 5: { // CommitSystemUpdateTask
					CommitSystemUpdateTask(null);
					break;
				}
				case 6: { // CreateNetworkInstallTask
					var ret = CreateNetworkInstallTask(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 7: { // DestroyNetworkInstallTask
					DestroyNetworkInstallTask(null);
					break;
				}
				case 8: { // ListNetworkInstallTask
					ListNetworkInstallTask(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 9: { // RequestNetworkInstallTaskRun
					RequestNetworkInstallTaskRun(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 10: { // GetNetworkInstallTaskInfo
					var ret = GetNetworkInstallTaskInfo(null);
					break;
				}
				case 11: { // CommitNetworkInstallTask
					CommitNetworkInstallTask(null);
					break;
				}
				case 12: { // RequestLatestSystemUpdateMeta
					RequestLatestSystemUpdateMeta(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 14: { // ListApplicationNetworkInstallTask
					ListApplicationNetworkInstallTask(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 15: { // ListNetworkInstallTaskContentMeta
					ListNetworkInstallTaskContentMeta(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 16: { // RequestLatestVersion
					RequestLatestVersion(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 17: { // SetNetworkInstallTaskAttribute
					SetNetworkInstallTaskAttribute(null);
					break;
				}
				case 18: { // AddNetworkInstallTaskContentMeta
					AddNetworkInstallTaskContentMeta(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 19: { // GetDownloadedSystemDataPath
					GetDownloadedSystemDataPath(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 20: { // CalculateNetworkInstallTaskRequiredSize
					var ret = CalculateNetworkInstallTaskRequiredSize(null);
					break;
				}
				case 21: { // IsExFatDriverIncluded
					var ret = IsExFatDriverIncluded(null);
					break;
				}
				case 22: { // GetBackgroundDownloadStressTaskInfo
					var ret = GetBackgroundDownloadStressTaskInfo();
					break;
				}
				case 23: { // RequestDeviceAuthenticationToken
					RequestDeviceAuthenticationToken(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 24: { // RequestGameCardRegistrationStatus
					RequestGameCardRegistrationStatus(null, im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 25: { // RequestRegisterGameCard
					RequestRegisterGameCard(null, im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1), out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 26: { // RequestRegisterNotificationToken
					RequestRegisterNotificationToken(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 27: { // RequestDownloadTaskList
					RequestDownloadTaskList(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 28: { // RequestApplicationControl
					RequestApplicationControl(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 29: { // RequestLatestApplicationControl
					RequestLatestApplicationControl(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 30: { // RequestVersionList
					RequestVersionList(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 31: { // CreateApplyDeltaTask
					var ret = CreateApplyDeltaTask(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 32: { // DestroyApplyDeltaTask
					DestroyApplyDeltaTask(null);
					break;
				}
				case 33: { // ListApplicationApplyDeltaTask
					ListApplicationApplyDeltaTask(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 34: { // RequestApplyDeltaTaskRun
					RequestApplyDeltaTaskRun(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 35: { // GetApplyDeltaTaskInfo
					var ret = GetApplyDeltaTaskInfo(null);
					break;
				}
				case 36: { // ListApplyDeltaTask
					ListApplyDeltaTask(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 37: { // CommitApplyDeltaTask
					CommitApplyDeltaTask(null);
					break;
				}
				case 38: { // CalculateApplyDeltaTaskRequiredSize
					var ret = CalculateApplyDeltaTaskRequiredSize(null);
					break;
				}
				case 39: { // PrepareShutdown
					PrepareShutdown();
					break;
				}
				case 40: { // ListApplyDeltaTask2
					ListApplyDeltaTask2(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 41: { // ClearNotEnoughSpaceStateOfApplyDeltaTask
					ClearNotEnoughSpaceStateOfApplyDeltaTask(null);
					break;
				}
				case 42: { // Unknown42
					var ret = Unknown42(null);
					break;
				}
				case 43: { // Unknown43
					var ret = Unknown43();
					break;
				}
				case 44: { // Unknown44
					var ret = Unknown44(null);
					break;
				}
				case 45: { // Unknown45
					var ret = Unknown45(null);
					break;
				}
				case 46: { // Unknown46
					Unknown46();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INetworkInstallManager: {im.CommandId}");
			}
		}
		
		public virtual object CreateSystemUpdateTask(object _0) => throw new NotImplementedException();
		public virtual void DestroySystemUpdateTask(object _0) => throw new NotImplementedException();
		public virtual void ListSystemUpdateTask(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestSystemUpdateTaskRun(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object GetSystemUpdateTaskInfo(object _0) => throw new NotImplementedException();
		public virtual void CommitSystemUpdateTask(object _0) => throw new NotImplementedException();
		public virtual object CreateNetworkInstallTask(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DestroyNetworkInstallTask(object _0) => throw new NotImplementedException();
		public virtual void ListNetworkInstallTask(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RequestNetworkInstallTaskRun(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object GetNetworkInstallTaskInfo(object _0) => throw new NotImplementedException();
		public virtual void CommitNetworkInstallTask(object _0) => throw new NotImplementedException();
		public virtual void RequestLatestSystemUpdateMeta(out KObject _0, out Nn.Nim.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void ListApplicationNetworkInstallTask(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ListNetworkInstallTaskContentMeta(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void RequestLatestVersion(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void SetNetworkInstallTaskAttribute(object _0) => throw new NotImplementedException();
		public virtual void AddNetworkInstallTaskContentMeta(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetDownloadedSystemDataPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object CalculateNetworkInstallTaskRequiredSize(object _0) => throw new NotImplementedException();
		public virtual object IsExFatDriverIncluded(object _0) => throw new NotImplementedException();
		public virtual object GetBackgroundDownloadStressTaskInfo() => throw new NotImplementedException();
		public virtual void RequestDeviceAuthenticationToken(out KObject _0, out Nn.Nim.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void RequestGameCardRegistrationStatus(object _0, Buffer<byte> _1, Buffer<byte> _2, out KObject _3, out Nn.Nim.Detail.IAsyncValue _4) => throw new NotImplementedException();
		public virtual void RequestRegisterGameCard(object _0, Buffer<byte> _1, Buffer<byte> _2, out KObject _3, out Nn.Nim.Detail.IAsyncResult _4) => throw new NotImplementedException();
		public virtual void RequestRegisterNotificationToken(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestDownloadTaskList(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncData _2) => throw new NotImplementedException();
		public virtual void RequestApplicationControl(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void RequestLatestApplicationControl(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void RequestVersionList(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncData _2) => throw new NotImplementedException();
		public virtual object CreateApplyDeltaTask(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DestroyApplyDeltaTask(object _0) => throw new NotImplementedException();
		public virtual void ListApplicationApplyDeltaTask(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void RequestApplyDeltaTaskRun(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object GetApplyDeltaTaskInfo(object _0) => throw new NotImplementedException();
		public virtual void ListApplyDeltaTask(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void CommitApplyDeltaTask(object _0) => throw new NotImplementedException();
		public virtual object CalculateApplyDeltaTaskRequiredSize(object _0) => throw new NotImplementedException();
		public virtual void PrepareShutdown() => throw new NotImplementedException();
		public virtual void ListApplyDeltaTask2(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ClearNotEnoughSpaceStateOfApplyDeltaTask(object _0) => throw new NotImplementedException();
		public virtual object Unknown42(object _0) => throw new NotImplementedException();
		public virtual object Unknown43() => throw new NotImplementedException();
		public virtual object Unknown44(object _0) => throw new NotImplementedException();
		public virtual object Unknown45(object _0) => throw new NotImplementedException();
		public virtual void Unknown46() => throw new NotImplementedException();
	}
	
	[IpcService("nim:shp")]
	public unsafe partial class IShopServiceManager : _Base_IShopServiceManager {}
	public unsafe class _Base_IShopServiceManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestDeviceAuthenticationToken
					RequestDeviceAuthenticationToken(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 1: { // RequestCachedDeviceAuthenticationToken
					RequestCachedDeviceAuthenticationToken(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 100: { // RequestRegisterDeviceAccount
					RequestRegisterDeviceAccount(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 101: { // RequestUnregisterDeviceAccount
					RequestUnregisterDeviceAccount(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 102: { // RequestDeviceAccountStatus
					RequestDeviceAccountStatus(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 103: { // GetDeviceAccountInfo
					var ret = GetDeviceAccountInfo();
					break;
				}
				case 104: { // RequestDeviceRegistrationInfo
					RequestDeviceRegistrationInfo(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 105: { // RequestTransferDeviceAccount
					RequestTransferDeviceAccount(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 106: { // RequestSyncRegistration
					RequestSyncRegistration(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 107: { // IsOwnDeviceId
					var ret = IsOwnDeviceId(null);
					break;
				}
				case 200: { // RequestRegisterNotificationToken
					RequestRegisterNotificationToken(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 300: { // RequestUnlinkDevice
					RequestUnlinkDevice(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 301: { // RequestUnlinkDeviceIntegrated
					RequestUnlinkDeviceIntegrated(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 302: { // RequestLinkDevice
					RequestLinkDevice(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 303: { // HasDeviceLink
					var ret = HasDeviceLink(null);
					break;
				}
				case 304: { // RequestUnlinkDeviceAll
					RequestUnlinkDeviceAll(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 305: { // RequestCreateVirtualAccount
					RequestCreateVirtualAccount(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 306: { // RequestDeviceLinkStatus
					RequestDeviceLinkStatus(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 400: { // GetAccountByVirtualAccount
					var ret = GetAccountByVirtualAccount(null);
					break;
				}
				case 500: { // RequestSyncTicket
					RequestSyncTicket(out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 501: { // RequestDownloadTicket
					RequestDownloadTicket(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				case 502: { // RequestDownloadTicketForPrepurchasedContents
					RequestDownloadTicketForPrepurchasedContents(null, out var _0, out var _1);
					om.Copy(0, _0.Handle);
					om.Move(0, _1.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IShopServiceManager: {im.CommandId}");
			}
		}
		
		public virtual void RequestDeviceAuthenticationToken(out KObject _0, out Nn.Nim.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void RequestCachedDeviceAuthenticationToken(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual void RequestRegisterDeviceAccount(out KObject _0, out Nn.Nim.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void RequestUnregisterDeviceAccount(out KObject _0, out Nn.Nim.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void RequestDeviceAccountStatus(out KObject _0, out Nn.Nim.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual object GetDeviceAccountInfo() => throw new NotImplementedException();
		public virtual void RequestDeviceRegistrationInfo(out KObject _0, out Nn.Nim.Detail.IAsyncValue _1) => throw new NotImplementedException();
		public virtual void RequestTransferDeviceAccount(out KObject _0, out Nn.Nim.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void RequestSyncRegistration(out KObject _0, out Nn.Nim.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual object IsOwnDeviceId(object _0) => throw new NotImplementedException();
		public virtual void RequestRegisterNotificationToken(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestUnlinkDevice(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestUnlinkDeviceIntegrated(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestLinkDevice(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual object HasDeviceLink(object _0) => throw new NotImplementedException();
		public virtual void RequestUnlinkDeviceAll(out KObject _0, out Nn.Nim.Detail.IAsyncResult _1) => throw new NotImplementedException();
		public virtual void RequestCreateVirtualAccount(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestDeviceLinkStatus(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncValue _2) => throw new NotImplementedException();
		public virtual object GetAccountByVirtualAccount(object _0) => throw new NotImplementedException();
		public virtual void RequestSyncTicket(out KObject _0, out Nn.Nim.Detail.IAsyncProgressResult _1) => throw new NotImplementedException();
		public virtual void RequestDownloadTicket(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncResult _2) => throw new NotImplementedException();
		public virtual void RequestDownloadTicketForPrepurchasedContents(object _0, out KObject _1, out Nn.Nim.Detail.IAsyncValue _2) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAsyncData : _Base_IAsyncData {}
	public unsafe class _Base_IAsyncData : IpcInterface {
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
					var ret = Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncData: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAsyncProgressResult : _Base_IAsyncProgressResult {}
	public unsafe class _Base_IAsyncProgressResult : IpcInterface {
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
					var ret = Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncProgressResult: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(Buffer<byte> _0) => throw new NotImplementedException();
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
}
