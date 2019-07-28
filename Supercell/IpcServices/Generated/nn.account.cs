#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Account {
	[IpcService("acc:su")]
	public unsafe partial class IAccountServiceForAdministrator : _Base_IAccountServiceForAdministrator {}
	public unsafe class _Base_IAccountServiceForAdministrator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetUserCount
					var ret = GetUserCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetUserExistence
					var ret = GetUserExistence(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 2: { // ListAllUsers
					ListAllUsers(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // ListOpenUsers
					ListOpenUsers(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetLastOpenedUser
					GetLastOpenedUser(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetProfile
					var ret = GetProfile(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 6: { // GetProfileDigest
					GetProfileDigest(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 50: { // IsUserRegistrationRequestPermitted
					var ret = IsUserRegistrationRequestPermitted(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 51: { // TrySelectUserWithoutInteraction
					TrySelectUserWithoutInteraction(im.GetData<byte>(8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 60: { // ListOpenContextStoredUsers
					var ret = ListOpenContextStoredUsers(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // GetUserRegistrationNotifier
					var ret = GetUserRegistrationNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 101: { // GetUserStateChangeNotifier
					var ret = GetUserStateChangeNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 102: { // GetBaasAccountManagerForSystemService
					var ret = GetBaasAccountManagerForSystemService(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 103: { // GetBaasUserAvailabilityChangeNotifier
					var ret = GetBaasUserAvailabilityChangeNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 104: { // GetProfileUpdateNotifier
					var ret = GetProfileUpdateNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 105: { // CheckNetworkServiceAvailabilityAsync
					var ret = CheckNetworkServiceAvailabilityAsync(im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 110: { // StoreSaveDataThumbnail
					StoreSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // ClearSaveDataThumbnail
					ClearSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 112: { // LoadSaveDataThumbnail
					LoadSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetData<ulong>(24), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 113: { // GetSaveDataThumbnailExistence
					var ret = GetSaveDataThumbnailExistence(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 190: { // GetUserLastOpenedApplication
					GetUserLastOpenedApplication(im.GetBytes(8, 0x10), out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 191: { // ActivateOpenContextHolder
					var ret = ActivateOpenContextHolder(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 200: { // BeginUserRegistration
					BeginUserRegistration(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 201: { // CompleteUserRegistration
					CompleteUserRegistration(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // CancelUserRegistration
					CancelUserRegistration(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 203: { // DeleteUser
					DeleteUser(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 204: { // SetUserPosition
					SetUserPosition(im.GetData<uint>(8), im.GetBytes(12, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 205: { // GetProfileEditor
					var ret = GetProfileEditor(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 206: { // CompleteUserRegistrationForcibly
					CompleteUserRegistrationForcibly(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 210: { // CreateFloatingRegistrationRequest
					var ret = CreateFloatingRegistrationRequest(im.GetData<uint>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 230: { // AuthenticateServiceAsync
					var ret = AuthenticateServiceAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 250: { // GetBaasAccountAdministrator
					var ret = GetBaasAccountAdministrator(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 290: { // ProxyProcedureForGuestLoginWithNintendoAccount
					var ret = ProxyProcedureForGuestLoginWithNintendoAccount(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 291: { // ProxyProcedureForFloatingRegistrationWithNintendoAccount
					var ret = ProxyProcedureForFloatingRegistrationWithNintendoAccount(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 299: { // SuspendBackgroundDaemon
					var ret = SuspendBackgroundDaemon();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 997: { // DebugInvalidateTokenCacheForUser
					DebugInvalidateTokenCacheForUser(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 998: { // DebugSetUserStateClose
					DebugSetUserStateClose(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 999: { // DebugSetUserStateOpen
					DebugSetUserStateOpen(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAccountServiceForAdministrator: {im.CommandId}");
			}
		}
		
		public virtual uint GetUserCount() => throw new NotImplementedException();
		public virtual byte GetUserExistence(byte[] _0) => throw new NotImplementedException();
		public virtual void ListAllUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ListOpenUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetLastOpenedUser(out byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Profile.IProfile GetProfile(byte[] _0) => throw new NotImplementedException();
		public virtual void GetProfileDigest(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsUserRegistrationRequestPermitted(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void TrySelectUserWithoutInteraction(byte _0, out byte[] _1) => throw new NotImplementedException();
		public virtual object ListOpenContextStoredUsers(object _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetUserRegistrationNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetUserStateChangeNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Baas.IManagerForSystemService GetBaasAccountManagerForSystemService(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetBaasUserAvailabilityChangeNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetProfileUpdateNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext CheckNetworkServiceAvailabilityAsync(ulong _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void StoreSaveDataThumbnail(byte[] _0, ulong _1, Buffer<byte> _2) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.StoreSaveDataThumbnail [110]".Debug();
		public virtual void ClearSaveDataThumbnail(byte[] _0, ulong _1) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.ClearSaveDataThumbnail [111]".Debug();
		public virtual void LoadSaveDataThumbnail(byte[] _0, ulong _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object GetSaveDataThumbnailExistence(object _0) => throw new NotImplementedException();
		public virtual void GetUserLastOpenedApplication(byte[] _0, out uint _1, out ulong _2) => throw new NotImplementedException();
		public virtual object ActivateOpenContextHolder(object _0) => throw new NotImplementedException();
		public virtual void BeginUserRegistration(out byte[] _0) => throw new NotImplementedException();
		public virtual void CompleteUserRegistration(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.CompleteUserRegistration [201]".Debug();
		public virtual void CancelUserRegistration(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.CancelUserRegistration [202]".Debug();
		public virtual void DeleteUser(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.DeleteUser [203]".Debug();
		public virtual void SetUserPosition(uint _0, byte[] _1) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.SetUserPosition [204]".Debug();
		public virtual Nn.Account.Profile.IProfileEditor GetProfileEditor(byte[] _0) => throw new NotImplementedException();
		public virtual void CompleteUserRegistrationForcibly(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.CompleteUserRegistrationForcibly [206]".Debug();
		public virtual Nn.Account.Baas.IFloatingRegistrationRequest CreateFloatingRegistrationRequest(uint _0, KObject _1) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext AuthenticateServiceAsync() => throw new NotImplementedException();
		public virtual Nn.Account.Baas.IAdministrator GetBaasAccountAdministrator(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IOAuthProcedureForExternalNsa ProxyProcedureForGuestLoginWithNintendoAccount(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IOAuthProcedureForExternalNsa ProxyProcedureForFloatingRegistrationWithNintendoAccount(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.ISessionObject SuspendBackgroundDaemon() => throw new NotImplementedException();
		public virtual void DebugInvalidateTokenCacheForUser(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.DebugInvalidateTokenCacheForUser [997]".Debug();
		public virtual void DebugSetUserStateClose(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.DebugSetUserStateClose [998]".Debug();
		public virtual void DebugSetUserStateOpen(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForAdministrator.DebugSetUserStateOpen [999]".Debug();
	}
	
	[IpcService("acc:u0")]
	public unsafe partial class IAccountServiceForApplication : _Base_IAccountServiceForApplication {}
	public unsafe class _Base_IAccountServiceForApplication : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetUserCount
					var ret = GetUserCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetUserExistence
					var ret = GetUserExistence(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 2: { // ListAllUsers
					ListAllUsers(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // ListOpenUsers
					ListOpenUsers(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetLastOpenedUser
					GetLastOpenedUser(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetProfile
					var ret = GetProfile(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 6: { // GetProfileDigest
					GetProfileDigest(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 50: { // IsUserRegistrationRequestPermitted
					var ret = IsUserRegistrationRequestPermitted(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 51: { // TrySelectUserWithoutInteraction
					TrySelectUserWithoutInteraction(im.GetData<byte>(8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 60: { // ListOpenContextStoredUsers
					var ret = ListOpenContextStoredUsers(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // InitializeApplicationInfo
					InitializeApplicationInfo(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // GetBaasAccountManagerForApplication
					var ret = GetBaasAccountManagerForApplication(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 102: { // AuthenticateApplicationAsync
					var ret = AuthenticateApplicationAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 103: { // CheckNetworkServiceAvailabilityAsync
					var ret = CheckNetworkServiceAvailabilityAsync();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 110: { // StoreSaveDataThumbnail
					StoreSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // ClearSaveDataThumbnail
					ClearSaveDataThumbnail(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 120: { // CreateGuestLoginRequest
					var ret = CreateGuestLoginRequest(im.GetData<uint>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 130: { // LoadOpenContext
					var ret = LoadOpenContext(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAccountServiceForApplication: {im.CommandId}");
			}
		}
		
		public virtual uint GetUserCount() => throw new NotImplementedException();
		public virtual byte GetUserExistence(byte[] _0) => throw new NotImplementedException();
		public virtual void ListAllUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ListOpenUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetLastOpenedUser(out byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Profile.IProfile GetProfile(byte[] _0) => throw new NotImplementedException();
		public virtual void GetProfileDigest(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsUserRegistrationRequestPermitted(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void TrySelectUserWithoutInteraction(byte _0, out byte[] _1) => throw new NotImplementedException();
		public virtual object ListOpenContextStoredUsers(object _0) => throw new NotImplementedException();
		public virtual void InitializeApplicationInfo(ulong _0, ulong _1) => "Stub hit for Nn.Account.IAccountServiceForApplication.InitializeApplicationInfo [100]".Debug();
		public virtual Nn.Account.Baas.IManagerForApplication GetBaasAccountManagerForApplication(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext AuthenticateApplicationAsync() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext CheckNetworkServiceAvailabilityAsync() => throw new NotImplementedException();
		public virtual void StoreSaveDataThumbnail(byte[] _0, Buffer<byte> _1) => "Stub hit for Nn.Account.IAccountServiceForApplication.StoreSaveDataThumbnail [110]".Debug();
		public virtual void ClearSaveDataThumbnail(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForApplication.ClearSaveDataThumbnail [111]".Debug();
		public virtual Nn.Account.Baas.IGuestLoginRequest CreateGuestLoginRequest(uint _0, KObject _1) => throw new NotImplementedException();
		public virtual object LoadOpenContext(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("acc:u1")]
	public unsafe partial class IAccountServiceForSystemService : _Base_IAccountServiceForSystemService {}
	public unsafe class _Base_IAccountServiceForSystemService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetUserCount
					var ret = GetUserCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetUserExistence
					var ret = GetUserExistence(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 2: { // ListAllUsers
					ListAllUsers(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // ListOpenUsers
					ListOpenUsers(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetLastOpenedUser
					GetLastOpenedUser(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetProfile
					var ret = GetProfile(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 6: { // GetProfileDigest
					GetProfileDigest(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 50: { // IsUserRegistrationRequestPermitted
					var ret = IsUserRegistrationRequestPermitted(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 51: { // TrySelectUserWithoutInteraction
					TrySelectUserWithoutInteraction(im.GetData<byte>(8), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 60: { // ListOpenContextStoredUsers
					var ret = ListOpenContextStoredUsers(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 100: { // GetUserRegistrationNotifier
					var ret = GetUserRegistrationNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 101: { // GetUserStateChangeNotifier
					var ret = GetUserStateChangeNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 102: { // GetBaasAccountManagerForSystemService
					var ret = GetBaasAccountManagerForSystemService(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 103: { // GetBaasUserAvailabilityChangeNotifier
					var ret = GetBaasUserAvailabilityChangeNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 104: { // GetProfileUpdateNotifier
					var ret = GetProfileUpdateNotifier();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 105: { // CheckNetworkServiceAvailabilityAsync
					var ret = CheckNetworkServiceAvailabilityAsync(im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 110: { // StoreSaveDataThumbnail
					StoreSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // ClearSaveDataThumbnail
					ClearSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetData<ulong>(24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 112: { // LoadSaveDataThumbnail
					LoadSaveDataThumbnail(im.GetBytes(8, 0x10), im.GetData<ulong>(24), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 113: { // GetSaveDataThumbnailExistence
					var ret = GetSaveDataThumbnailExistence(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 190: { // GetUserLastOpenedApplication
					GetUserLastOpenedApplication(im.GetBytes(8, 0x10), out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 191: { // ActivateOpenContextHolder
					var ret = ActivateOpenContextHolder(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 997: { // DebugInvalidateTokenCacheForUser
					DebugInvalidateTokenCacheForUser(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 998: { // DebugSetUserStateClose
					DebugSetUserStateClose(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 999: { // DebugSetUserStateOpen
					DebugSetUserStateOpen(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAccountServiceForSystemService: {im.CommandId}");
			}
		}
		
		public virtual uint GetUserCount() => throw new NotImplementedException();
		public virtual byte GetUserExistence(byte[] _0) => throw new NotImplementedException();
		public virtual void ListAllUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ListOpenUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetLastOpenedUser(out byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Profile.IProfile GetProfile(byte[] _0) => throw new NotImplementedException();
		public virtual void GetProfileDigest(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual byte IsUserRegistrationRequestPermitted(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void TrySelectUserWithoutInteraction(byte _0, out byte[] _1) => throw new NotImplementedException();
		public virtual object ListOpenContextStoredUsers(object _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetUserRegistrationNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetUserStateChangeNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Baas.IManagerForSystemService GetBaasAccountManagerForSystemService(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetBaasUserAvailabilityChangeNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.INotifier GetProfileUpdateNotifier() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext CheckNetworkServiceAvailabilityAsync(ulong _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void StoreSaveDataThumbnail(byte[] _0, ulong _1, Buffer<byte> _2) => "Stub hit for Nn.Account.IAccountServiceForSystemService.StoreSaveDataThumbnail [110]".Debug();
		public virtual void ClearSaveDataThumbnail(byte[] _0, ulong _1) => "Stub hit for Nn.Account.IAccountServiceForSystemService.ClearSaveDataThumbnail [111]".Debug();
		public virtual void LoadSaveDataThumbnail(byte[] _0, ulong _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object GetSaveDataThumbnailExistence(object _0) => throw new NotImplementedException();
		public virtual void GetUserLastOpenedApplication(byte[] _0, out uint _1, out ulong _2) => throw new NotImplementedException();
		public virtual object ActivateOpenContextHolder(object _0) => throw new NotImplementedException();
		public virtual void DebugInvalidateTokenCacheForUser(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForSystemService.DebugInvalidateTokenCacheForUser [997]".Debug();
		public virtual void DebugSetUserStateClose(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForSystemService.DebugSetUserStateClose [998]".Debug();
		public virtual void DebugSetUserStateOpen(byte[] _0) => "Stub hit for Nn.Account.IAccountServiceForSystemService.DebugSetUserStateOpen [999]".Debug();
	}
	
	[IpcService("acc:aa")]
	public unsafe partial class IBaasAccessTokenAccessor : _Base_IBaasAccessTokenAccessor {}
	public unsafe class _Base_IBaasAccessTokenAccessor : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // EnsureCacheAsync
					var ret = EnsureCacheAsync(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // LoadCache
					LoadCache(im.GetBytes(8, 0x10), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 2: { // GetDeviceAccountId
					var ret = GetDeviceAccountId(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 50: { // RegisterNotificationTokenAsync
					var ret = RegisterNotificationTokenAsync(im.GetBytes(8, 0x28), im.GetBytes(48, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 51: { // UnregisterNotificationTokenAsync
					var ret = UnregisterNotificationTokenAsync(im.GetBytes(8, 0x10));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBaasAccessTokenAccessor: {im.CommandId}");
			}
		}
		
		public virtual Nn.Account.Detail.IAsyncContext EnsureCacheAsync(byte[] _0) => throw new NotImplementedException();
		public virtual void LoadCache(byte[] _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual ulong GetDeviceAccountId(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext RegisterNotificationTokenAsync(byte[] _0, byte[] _1) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext UnregisterNotificationTokenAsync(byte[] _0) => throw new NotImplementedException();
	}
}
