using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.account {
	[IpcService("acc:u0")]
	public class IAccountServiceForApplication : IpcInterface {
		[IpcCommand(0)]
		void GetUserCount(out uint count) => count = 1;
		[IpcCommand(1)]
		void GetUserExistence([Bytes(0x80 /* 16 x 8 */)] byte[] /* nn::account::Uid */ uid, out bool exists) => exists = true;
		[IpcCommand(2)]
		void ListAllUsers([Buffer(0xa)] Buffer<byte> uid) => throw new NotImplementedException();
		[IpcCommand(3)]
		void ListOpenUsers([Buffer(0xa)] Buffer<byte> uid) => throw new NotImplementedException();
		[IpcCommand(4)]
		void GetLastOpenedUser([Bytes(0x10)] out byte[] uid) => uid = new byte[] { 0xde, 0xad, 0xbe, 0xef, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		[IpcCommand(5)]
		void GetProfile([Bytes(0x80 /* 16 x 8 */)] byte[] uid, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6)]
		void GetProfileDigest([Bytes(0x80 /* 16 x 8 */)] byte[] uid, [Bytes(0x10 /* 16 x 1 */)] out byte[] profileDigest) => throw new NotImplementedException();
		[IpcCommand(50)]
		void IsUserRegistrationRequestPermitted(ulong unknown0, [Pid] ulong pid, out bool unknown1) => throw new NotImplementedException();
		[IpcCommand(51)]
		void TrySelectUserWithoutInteraction(bool unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] uid) => throw new NotImplementedException();
		[IpcCommand(60)]
		void ListOpenContextStoredUsers(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(100)]
		void InitializeApplicationInfo(ulong unknown0, [Pid] ulong pid) {}
		[IpcCommand(101)]
		void GetBaasAccountManagerForApplication([Bytes(0x80 /* 16 x 8 */)] byte[] uid, [Move] out IManagerForApplication manager) => manager = new IManagerForApplication();
		[IpcCommand(102)]
		void AuthenticateApplicationAsync(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(103)]
		void CheckNetworkServiceAvailabilityAsync(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(110)]
		void StoreSaveDataThumbnail([Bytes(0x80 /* 16 x 8 */)] byte[] uid, [Buffer(0x5)] Buffer<byte> thumbnail) => throw new NotImplementedException();
		[IpcCommand(111)]
		void ClearSaveDataThumbnail([Bytes(0x80 /* 16 x 8 */)] byte[] uid) => throw new NotImplementedException();
		[IpcCommand(120)]
		void CreateGuestLoginRequest(uint unknown0, [Move] KObject unknown1, out object unknown2) => throw new NotImplementedException();
		[IpcCommand(130)]
		void LoadOpenContext(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
	
	public class IManagerForApplication : IpcInterface {
		[IpcCommand(0)]
		void CheckAvailability() => throw new NotImplementedException();
		[IpcCommand(1)]
		void GetAccountId(out ulong /* nn::account::NetworkServiceAccountId */ unknown0) => throw new NotImplementedException();
		[IpcCommand(2)]
		void EnsureIdTokenCacheAsync(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(3)]
		void LoadIdTokenCache(out uint unknown0, [Buffer(0x6)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(130)]
		void GetNintendoAccountUserResourceCacheForApplication(out ulong /* nn::account::NintendoAccountId */ unknown0, [Buffer(0x1a)] Buffer<byte> unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(150)]
		void CreateAuthorizationRequest(uint unknown0, [Move] KObject unknown1, [Buffer(0x19)] Buffer<byte> unknown2, out object unknown3) => throw new NotImplementedException();
		[IpcCommand(160)]
		void StoreOpenContext(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
}
