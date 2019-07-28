#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Migration.User {
	[IpcService("mig:usr")]
	public unsafe partial class IService : _Base_IService {}
	public unsafe class _Base_IService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 10: { // TryGetLastMigrationInfo
					var ret = TryGetLastMigrationInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // CreateServer
					var ret = CreateServer(null, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 101: { // ResumeServer
					var ret = ResumeServer(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 200: { // CreateClient
					var ret = CreateClient(null, Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 201: { // ResumeClient
					var ret = ResumeClient(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IService: {im.CommandId}");
			}
		}
		
		public virtual object TryGetLastMigrationInfo() => throw new NotImplementedException();
		public virtual Nn.Migration.User.IServer CreateServer(object _0, KObject _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.Migration.User.IServer ResumeServer(object _0, KObject _1) => throw new NotImplementedException();
		public virtual Nn.Migration.User.IClient CreateClient(object _0, KObject _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.Migration.User.IClient ResumeClient(object _0, KObject _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAsyncContext : _Base_IAsyncContext {}
	public unsafe class _Base_IAsyncContext : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSystemEvent
					var ret = GetSystemEvent(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Cancel
					var ret = Cancel(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // HasDone
					var ret = HasDone(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetResult
					var ret = GetResult(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncContext: {im.CommandId}");
			}
		}
		
		public virtual object GetSystemEvent(object _0) => throw new NotImplementedException();
		public virtual object Cancel(object _0) => throw new NotImplementedException();
		public virtual object HasDone(object _0) => throw new NotImplementedException();
		public virtual object GetResult(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IClient : _Base_IClient {}
	public unsafe class _Base_IClient : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetClientProfile
					GetClientProfile(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // CreateLoginSession
					var ret = CreateLoginSession();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // GetNetworkServiceAccountId
					var ret = GetNetworkServiceAccountId();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // GetUserNickname
					var ret = GetUserNickname();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetUserProfileImage
					GetUserProfileImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // PrepareAsync
					var ret = PrepareAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 101: { // GetConnectionRequirement
					var ret = GetConnectionRequirement();
					om.Initialize(0, 0, 0);
					break;
				}
				case 200: { // ScanServersAsync
					var ret = ScanServersAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 201: { // ListServers
					ListServers(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 210: { // ConnectByServerIdAsync
					var ret = ConnectByServerIdAsync(null);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 300: { // GetStorageShortfall
					var ret = GetStorageShortfall();
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // GetTotalTransferInfo
					var ret = GetTotalTransferInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // GetImmigrantUid
					var ret = GetImmigrantUid();
					om.Initialize(0, 0, 0);
					break;
				}
				case 310: { // GetCurrentTransferInfo
					var ret = GetCurrentTransferInfo();
					om.Initialize(0, 0, 0);
					break;
				}
				case 311: { // GetCurrentRelatedApplications
					GetCurrentRelatedApplications(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 320: { // TransferNextAsync
					var ret = TransferNextAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 350: { // SuspendAsync
					var ret = SuspendAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 400: { // CompleteAsync
					var ret = CompleteAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 500: { // Abort
					Abort();
					om.Initialize(0, 0, 0);
					break;
				}
				case 999: { // DebugSynchronizeStateInFinalizationAsync
					var ret = DebugSynchronizeStateInFinalizationAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IClient: {im.CommandId}");
			}
		}
		
		public virtual void GetClientProfile(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object CreateLoginSession() => throw new NotImplementedException();
		public virtual object GetNetworkServiceAccountId() => throw new NotImplementedException();
		public virtual object GetUserNickname() => throw new NotImplementedException();
		public virtual void GetUserProfileImage(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext PrepareAsync() => throw new NotImplementedException();
		public virtual object GetConnectionRequirement() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext ScanServersAsync() => throw new NotImplementedException();
		public virtual void ListServers(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext ConnectByServerIdAsync(object _0) => throw new NotImplementedException();
		public virtual object GetStorageShortfall() => throw new NotImplementedException();
		public virtual object GetTotalTransferInfo() => throw new NotImplementedException();
		public virtual object GetImmigrantUid() => throw new NotImplementedException();
		public virtual object GetCurrentTransferInfo() => throw new NotImplementedException();
		public virtual void GetCurrentRelatedApplications(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext TransferNextAsync() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext SuspendAsync() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext CompleteAsync() => throw new NotImplementedException();
		public virtual void Abort() => "Stub hit for Nn.Migration.User.IClient.Abort [500]".Debug();
		public virtual Nn.Migration.Detail.IAsyncContext DebugSynchronizeStateInFinalizationAsync() => throw new NotImplementedException();
	}
	
	public unsafe partial class IServer : _Base_IServer {}
	public unsafe class _Base_IServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetUid
					var ret = GetUid();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetServerProfile
					GetServerProfile(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // PrepareAsync
					var ret = PrepareAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 101: { // GetConnectionRequirement
					var ret = GetConnectionRequirement();
					om.Initialize(0, 0, 0);
					break;
				}
				case 200: { // WaitConnectionAsync
					var ret = WaitConnectionAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 201: { // GetClientProfile
					GetClientProfile(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // AcceptConnectionAsync
					var ret = AcceptConnectionAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 203: { // DeclineConnectionAsync
					var ret = DeclineConnectionAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 300: { // ProcessTransferAsync
					var ret = ProcessTransferAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 400: { // CompleteAsync
					var ret = CompleteAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 500: { // Abort
					Abort();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IServer: {im.CommandId}");
			}
		}
		
		public virtual object GetUid() => throw new NotImplementedException();
		public virtual void GetServerProfile(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext PrepareAsync() => throw new NotImplementedException();
		public virtual object GetConnectionRequirement() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext WaitConnectionAsync() => throw new NotImplementedException();
		public virtual void GetClientProfile(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext AcceptConnectionAsync() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext DeclineConnectionAsync() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext ProcessTransferAsync() => throw new NotImplementedException();
		public virtual Nn.Migration.Detail.IAsyncContext CompleteAsync() => throw new NotImplementedException();
		public virtual void Abort() => "Stub hit for Nn.Migration.User.IServer.Abort [500]".Debug();
	}
}
