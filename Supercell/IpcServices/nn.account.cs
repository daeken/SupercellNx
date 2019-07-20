using System;
using Supercell.IpcServices.Nn.Account;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Account {
	public partial class IAccountServiceForApplication {
		public override uint GetUserCount() => throw new NotImplementedException();
		
		public override byte GetUserExistence(byte[] _0) => 1;
		
		public override void ListAllUsers(Buffer<byte> _0) => throw new NotImplementedException();
		public override void ListOpenUsers(Buffer<byte> _0) => throw new NotImplementedException();

		public override void GetLastOpenedUser(out byte[] uid) => uid = new byte[]
			{ 0xde, 0xad, 0xbe, 0xef, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		
		public override Nn.Account.Profile.IProfile GetProfile(byte[] _0) => throw new NotImplementedException();
		public override void GetProfileDigest(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public override byte IsUserRegistrationRequestPermitted(ulong _0, ulong _1) => throw new NotImplementedException();
		public override void TrySelectUserWithoutInteraction(byte _0, out byte[] _1) => throw new NotImplementedException();
		public override object ListOpenContextStoredUsers(object _0) => throw new NotImplementedException();
		
		public override void InitializeApplicationInfo(ulong _0, ulong _1) {}

		public override Nn.Account.Baas.IManagerForApplication GetBaasAccountManagerForApplication(byte[] _0) =>
			new Baas.IManagerForApplication();
		
		public override Nn.Account.Detail.IAsyncContext AuthenticateApplicationAsync() => throw new NotImplementedException();
		public override Nn.Account.Detail.IAsyncContext CheckNetworkServiceAvailabilityAsync() => throw new NotImplementedException();
		public override void StoreSaveDataThumbnail(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void ClearSaveDataThumbnail(byte[] _0) => throw new NotImplementedException();
		public override Nn.Account.Baas.IGuestLoginRequest CreateGuestLoginRequest(uint _0, KObject _1) => throw new NotImplementedException();
		public override object LoadOpenContext(object _0) => throw new NotImplementedException();
	}
}
