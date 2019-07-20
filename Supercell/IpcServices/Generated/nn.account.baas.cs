#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Account.Baas {
	public unsafe partial class IAdministrator : _Base_IAdministrator {}
	public unsafe class _Base_IAdministrator : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CheckAvailability
					CheckAvailability();
					break;
				}
				case 1: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 2: { // EnsureIdTokenCacheAsync
					var ret = EnsureIdTokenCacheAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // LoadIdTokenCache
					LoadIdTokenCache(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 100: { // SetSystemProgramIdentification
					SetSystemProgramIdentification(im.GetData<ulong>(0), im.Pid, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 110: { // GetServiceEntryRequirementCache
					var ret = GetServiceEntryRequirementCache(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 111: { // InvalidateServiceEntryRequirementCache
					InvalidateServiceEntryRequirementCache(im.GetData<ulong>(0));
					break;
				}
				case 112: { // InvalidateTokenCache
					InvalidateTokenCache(im.GetData<ulong>(0));
					break;
				}
				case 120: { // GetNintendoAccountId
					var ret = GetNintendoAccountId();
					om.SetData(0, ret);
					break;
				}
				case 130: { // GetNintendoAccountUserResourceCache
					GetNintendoAccountUserResourceCache(out var _0, im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 131: { // RefreshNintendoAccountUserResourceCacheAsync
					var ret = RefreshNintendoAccountUserResourceCacheAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 132: { // RefreshNintendoAccountUserResourceCacheAsyncIfSecondsElapsed
					RefreshNintendoAccountUserResourceCacheAsyncIfSecondsElapsed(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.Move(0, _1.Handle);
					break;
				}
				case 140: { // GetNetworkServiceLicenseCache
					var ret = GetNetworkServiceLicenseCache(null);
					break;
				}
				case 141: { // RefreshNetworkServiceLicenseCacheAsync
					var ret = RefreshNetworkServiceLicenseCacheAsync(null);
					break;
				}
				case 142: { // RefreshNetworkServiceLicenseCacheAsyncIfSecondsElapsed
					var ret = RefreshNetworkServiceLicenseCacheAsyncIfSecondsElapsed(null);
					break;
				}
				case 150: { // CreateAuthorizationRequest
					var ret = CreateAuthorizationRequest(im.GetData<uint>(0), Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Move(0, ret.Handle);
					break;
				}
				case 200: { // IsRegistered
					var ret = IsRegistered();
					om.SetData(0, ret);
					break;
				}
				case 201: { // RegisterAsync
					var ret = RegisterAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 202: { // UnregisterAsync
					var ret = UnregisterAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 203: { // DeleteRegistrationInfoLocally
					DeleteRegistrationInfoLocally();
					break;
				}
				case 220: { // SynchronizeProfileAsync
					var ret = SynchronizeProfileAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 221: { // UploadProfileAsync
					var ret = UploadProfileAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 222: { // SynchronizeProfileAsyncIfSecondsElapsed
					SynchronizeProfileAsyncIfSecondsElapsed(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.Move(0, _1.Handle);
					break;
				}
				case 250: { // IsLinkedWithNintendoAccount
					var ret = IsLinkedWithNintendoAccount();
					om.SetData(0, ret);
					break;
				}
				case 251: { // CreateProcedureToLinkWithNintendoAccount
					var ret = CreateProcedureToLinkWithNintendoAccount();
					om.Move(0, ret.Handle);
					break;
				}
				case 252: { // ResumeProcedureToLinkWithNintendoAccount
					var ret = ResumeProcedureToLinkWithNintendoAccount(im.GetBytes(0, 0x10));
					om.Move(0, ret.Handle);
					break;
				}
				case 255: { // CreateProcedureToUpdateLinkageStateOfNintendoAccount
					var ret = CreateProcedureToUpdateLinkageStateOfNintendoAccount();
					om.Move(0, ret.Handle);
					break;
				}
				case 256: { // ResumeProcedureToUpdateLinkageStateOfNintendoAccount
					var ret = ResumeProcedureToUpdateLinkageStateOfNintendoAccount(im.GetBytes(0, 0x10));
					om.Move(0, ret.Handle);
					break;
				}
				case 260: { // CreateProcedureToLinkNnidWithNintendoAccount
					var ret = CreateProcedureToLinkNnidWithNintendoAccount();
					om.Move(0, ret.Handle);
					break;
				}
				case 261: { // ResumeProcedureToLinkNnidWithNintendoAccount
					var ret = ResumeProcedureToLinkNnidWithNintendoAccount(im.GetBytes(0, 0x10));
					om.Move(0, ret.Handle);
					break;
				}
				case 280: { // ProxyProcedureToAcquireApplicationAuthorizationForNintendoAccount
					var ret = ProxyProcedureToAcquireApplicationAuthorizationForNintendoAccount(im.GetBytes(0, 0x10));
					om.Move(0, ret.Handle);
					break;
				}
				case 997: { // DebugUnlinkNintendoAccountAsync
					var ret = DebugUnlinkNintendoAccountAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 998: { // DebugSetAvailabilityErrorDetail
					DebugSetAvailabilityErrorDetail(im.GetData<uint>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAdministrator: {im.CommandId}");
			}
		}
		
		public virtual void CheckAvailability() => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext EnsureIdTokenCacheAsync() => throw new NotImplementedException();
		public virtual void LoadIdTokenCache(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetSystemProgramIdentification(ulong _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual uint GetServiceEntryRequirementCache(ulong _0) => throw new NotImplementedException();
		public virtual void InvalidateServiceEntryRequirementCache(ulong _0) => throw new NotImplementedException();
		public virtual void InvalidateTokenCache(ulong _0) => throw new NotImplementedException();
		public virtual ulong GetNintendoAccountId() => throw new NotImplementedException();
		public virtual void GetNintendoAccountUserResourceCache(out ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext RefreshNintendoAccountUserResourceCacheAsync() => throw new NotImplementedException();
		public virtual void RefreshNintendoAccountUserResourceCacheAsyncIfSecondsElapsed(uint _0, out byte _1, out Nn.Account.Detail.IAsyncContext _2) => throw new NotImplementedException();
		public virtual object GetNetworkServiceLicenseCache(object _0) => throw new NotImplementedException();
		public virtual object RefreshNetworkServiceLicenseCacheAsync(object _0) => throw new NotImplementedException();
		public virtual object RefreshNetworkServiceLicenseCacheAsyncIfSecondsElapsed(object _0) => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IAuthorizationRequest CreateAuthorizationRequest(uint _0, KObject _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual byte IsRegistered() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext RegisterAsync() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext UnregisterAsync() => throw new NotImplementedException();
		public virtual void DeleteRegistrationInfoLocally() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext SynchronizeProfileAsync() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext UploadProfileAsync() => throw new NotImplementedException();
		public virtual void SynchronizeProfileAsyncIfSecondsElapsed(uint _0, out byte _1, out Nn.Account.Detail.IAsyncContext _2) => throw new NotImplementedException();
		public virtual byte IsLinkedWithNintendoAccount() => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IOAuthProcedureForNintendoAccountLinkage CreateProcedureToLinkWithNintendoAccount() => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IOAuthProcedureForNintendoAccountLinkage ResumeProcedureToLinkWithNintendoAccount(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Http.IOAuthProcedure CreateProcedureToUpdateLinkageStateOfNintendoAccount() => throw new NotImplementedException();
		public virtual Nn.Account.Http.IOAuthProcedure ResumeProcedureToUpdateLinkageStateOfNintendoAccount(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Http.IOAuthProcedure CreateProcedureToLinkNnidWithNintendoAccount() => throw new NotImplementedException();
		public virtual Nn.Account.Http.IOAuthProcedure ResumeProcedureToLinkNnidWithNintendoAccount(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Http.IOAuthProcedure ProxyProcedureToAcquireApplicationAuthorizationForNintendoAccount(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext DebugUnlinkNintendoAccountAsync() => throw new NotImplementedException();
		public virtual void DebugSetAvailabilityErrorDetail(uint _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IFloatingRegistrationRequest : _Base_IFloatingRegistrationRequest {}
	public unsafe class _Base_IFloatingRegistrationRequest : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSessionId
					GetSessionId(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 12: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 13: { // GetLinkedNintendoAccountId
					var ret = GetLinkedNintendoAccountId();
					om.SetData(0, ret);
					break;
				}
				case 14: { // GetNickname
					GetNickname(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 15: { // GetProfileImage
					GetProfileImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 21: { // LoadIdTokenCache
					LoadIdTokenCache(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 100: { // RegisterUser
					RegisterUser(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 101: { // RegisterUserWithUid
					RegisterUserWithUid(im.GetBytes(0, 0x10));
					break;
				}
				case 102: { // RegisterNetworkServiceAccountAsync
					var ret = RegisterNetworkServiceAccountAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 103: { // RegisterNetworkServiceAccountWithUidAsync
					var ret = RegisterNetworkServiceAccountWithUidAsync(im.GetBytes(0, 0x10));
					om.Move(0, ret.Handle);
					break;
				}
				case 110: { // SetSystemProgramIdentification
					SetSystemProgramIdentification(im.GetData<ulong>(0), im.Pid, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 111: { // EnsureIdTokenCacheAsync
					var ret = EnsureIdTokenCacheAsync();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFloatingRegistrationRequest: {im.CommandId}");
			}
		}
		
		public virtual void GetSessionId(out byte[] _0) => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual ulong GetLinkedNintendoAccountId() => throw new NotImplementedException();
		public virtual void GetNickname(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetProfileImage(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void LoadIdTokenCache(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RegisterUser(out byte[] _0) => throw new NotImplementedException();
		public virtual void RegisterUserWithUid(byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext RegisterNetworkServiceAccountAsync() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext RegisterNetworkServiceAccountWithUidAsync(byte[] _0) => throw new NotImplementedException();
		public virtual void SetSystemProgramIdentification(ulong _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext EnsureIdTokenCacheAsync() => throw new NotImplementedException();
	}
	
	public unsafe partial class IGuestLoginRequest : _Base_IGuestLoginRequest {}
	public unsafe class _Base_IGuestLoginRequest : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSessionId
					GetSessionId(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 12: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 13: { // GetLinkedNintendoAccountId
					var ret = GetLinkedNintendoAccountId();
					om.SetData(0, ret);
					break;
				}
				case 14: { // GetNickname
					GetNickname(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 15: { // GetProfileImage
					GetProfileImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 21: { // LoadIdTokenCache
					LoadIdTokenCache(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IGuestLoginRequest: {im.CommandId}");
			}
		}
		
		public virtual void GetSessionId(out byte[] _0) => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual ulong GetLinkedNintendoAccountId() => throw new NotImplementedException();
		public virtual void GetNickname(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetProfileImage(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void LoadIdTokenCache(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IManagerForApplication : _Base_IManagerForApplication {}
	public unsafe class _Base_IManagerForApplication : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CheckAvailability
					CheckAvailability();
					break;
				}
				case 1: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 2: { // EnsureIdTokenCacheAsync
					var ret = EnsureIdTokenCacheAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // LoadIdTokenCache
					LoadIdTokenCache(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 130: { // GetNintendoAccountUserResourceCacheForApplication
					GetNintendoAccountUserResourceCacheForApplication(out var _0, im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 150: { // CreateAuthorizationRequest
					var ret = CreateAuthorizationRequest(im.GetData<uint>(0), Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x19, 0));
					om.Move(0, ret.Handle);
					break;
				}
				case 160: { // StoreOpenContext
					var ret = StoreOpenContext(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerForApplication: {im.CommandId}");
			}
		}
		
		public virtual void CheckAvailability() => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext EnsureIdTokenCacheAsync() => throw new NotImplementedException();
		public virtual void LoadIdTokenCache(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetNintendoAccountUserResourceCacheForApplication(out ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IAuthorizationRequest CreateAuthorizationRequest(uint _0, KObject _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object StoreOpenContext(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IManagerForSystemService : _Base_IManagerForSystemService {}
	public unsafe class _Base_IManagerForSystemService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CheckAvailability
					CheckAvailability();
					break;
				}
				case 1: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 2: { // EnsureIdTokenCacheAsync
					var ret = EnsureIdTokenCacheAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // LoadIdTokenCache
					LoadIdTokenCache(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 100: { // SetSystemProgramIdentification
					SetSystemProgramIdentification(im.GetData<ulong>(0), im.Pid, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 110: { // GetServiceEntryRequirementCache
					var ret = GetServiceEntryRequirementCache(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 111: { // InvalidateServiceEntryRequirementCache
					InvalidateServiceEntryRequirementCache(im.GetData<ulong>(0));
					break;
				}
				case 112: { // InvalidateTokenCache
					InvalidateTokenCache(im.GetData<ulong>(0));
					break;
				}
				case 120: { // GetNintendoAccountId
					var ret = GetNintendoAccountId();
					om.SetData(0, ret);
					break;
				}
				case 130: { // GetNintendoAccountUserResourceCache
					GetNintendoAccountUserResourceCache(out var _0, im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 131: { // RefreshNintendoAccountUserResourceCacheAsync
					var ret = RefreshNintendoAccountUserResourceCacheAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 132: { // RefreshNintendoAccountUserResourceCacheAsyncIfSecondsElapsed
					RefreshNintendoAccountUserResourceCacheAsyncIfSecondsElapsed(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.Move(0, _1.Handle);
					break;
				}
				case 140: { // GetNetworkServiceLicenseCache
					var ret = GetNetworkServiceLicenseCache(null);
					break;
				}
				case 141: { // RefreshNetworkServiceLicenseCacheAsync
					var ret = RefreshNetworkServiceLicenseCacheAsync(null);
					break;
				}
				case 142: { // RefreshNetworkServiceLicenseCacheAsyncIfSecondsElapsed
					var ret = RefreshNetworkServiceLicenseCacheAsyncIfSecondsElapsed(null);
					break;
				}
				case 150: { // CreateAuthorizationRequest
					var ret = CreateAuthorizationRequest(im.GetData<uint>(0), Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerForSystemService: {im.CommandId}");
			}
		}
		
		public virtual void CheckAvailability() => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext EnsureIdTokenCacheAsync() => throw new NotImplementedException();
		public virtual void LoadIdTokenCache(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetSystemProgramIdentification(ulong _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual uint GetServiceEntryRequirementCache(ulong _0) => throw new NotImplementedException();
		public virtual void InvalidateServiceEntryRequirementCache(ulong _0) => throw new NotImplementedException();
		public virtual void InvalidateTokenCache(ulong _0) => throw new NotImplementedException();
		public virtual ulong GetNintendoAccountId() => throw new NotImplementedException();
		public virtual void GetNintendoAccountUserResourceCache(out ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext RefreshNintendoAccountUserResourceCacheAsync() => throw new NotImplementedException();
		public virtual void RefreshNintendoAccountUserResourceCacheAsyncIfSecondsElapsed(uint _0, out byte _1, out Nn.Account.Detail.IAsyncContext _2) => throw new NotImplementedException();
		public virtual object GetNetworkServiceLicenseCache(object _0) => throw new NotImplementedException();
		public virtual object RefreshNetworkServiceLicenseCacheAsync(object _0) => throw new NotImplementedException();
		public virtual object RefreshNetworkServiceLicenseCacheAsyncIfSecondsElapsed(object _0) => throw new NotImplementedException();
		public virtual Nn.Account.Nas.IAuthorizationRequest CreateAuthorizationRequest(uint _0, KObject _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
	}
}
