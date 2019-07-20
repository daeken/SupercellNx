#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Account.Nas {
	public unsafe partial class IAuthorizationRequest : _Base_IAuthorizationRequest {}
	public unsafe class _Base_IAuthorizationRequest : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetSessionId
					GetSessionId(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 10: { // InvokeWithoutInteractionAsync
					var ret = InvokeWithoutInteractionAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 19: { // IsAuthorized
					var ret = IsAuthorized();
					om.SetData(0, ret);
					break;
				}
				case 20: { // GetAuthorizationCode
					GetAuthorizationCode(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 21: { // GetIdToken
					GetIdToken(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 22: { // GetState
					GetState(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAuthorizationRequest: {im.CommandId}");
			}
		}
		
		public virtual void GetSessionId(out byte[] _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext InvokeWithoutInteractionAsync() => throw new NotImplementedException();
		public virtual byte IsAuthorized() => throw new NotImplementedException();
		public virtual void GetAuthorizationCode(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetIdToken(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetState(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IOAuthProcedureForExternalNsa : _Base_IOAuthProcedureForExternalNsa {}
	public unsafe class _Base_IOAuthProcedureForExternalNsa : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // PrepareAsync
					var ret = PrepareAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetRequest
					GetRequest(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x1A, 1));
					break;
				}
				case 2: { // ApplyResponse
					ApplyResponse(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 3: { // ApplyResponseAsync
					var ret = ApplyResponseAsync(im.GetBuffer<byte>(0x9, 0));
					om.Move(0, ret.Handle);
					break;
				}
				case 10: { // Suspend
					Suspend(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 101: { // GetLinkedNintendoAccountId
					var ret = GetLinkedNintendoAccountId();
					om.SetData(0, ret);
					break;
				}
				case 102: { // GetNickname
					GetNickname(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 103: { // GetProfileImage
					GetProfileImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOAuthProcedureForExternalNsa: {im.CommandId}");
			}
		}
		
		public virtual Nn.Account.Detail.IAsyncContext PrepareAsync() => throw new NotImplementedException();
		public virtual void GetRequest(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ApplyResponse(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext ApplyResponseAsync(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Suspend(out byte[] _0) => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual ulong GetLinkedNintendoAccountId() => throw new NotImplementedException();
		public virtual void GetNickname(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetProfileImage(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IOAuthProcedureForGuestLogin : _Base_IOAuthProcedureForGuestLogin {}
	public unsafe class _Base_IOAuthProcedureForGuestLogin : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // PrepareAsync
					var ret = PrepareAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetRequest
					GetRequest(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x1A, 1));
					break;
				}
				case 2: { // ApplyResponse
					ApplyResponse(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 3: { // ApplyResponseAsync
					var ret = ApplyResponseAsync(im.GetBuffer<byte>(0x9, 0));
					om.Move(0, ret.Handle);
					break;
				}
				case 10: { // Suspend
					Suspend(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // GetAccountId
					var ret = GetAccountId();
					om.SetData(0, ret);
					break;
				}
				case 101: { // GetLinkedNintendoAccountId
					var ret = GetLinkedNintendoAccountId();
					om.SetData(0, ret);
					break;
				}
				case 102: { // GetNickname
					GetNickname(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 103: { // GetProfileImage
					GetProfileImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOAuthProcedureForGuestLogin: {im.CommandId}");
			}
		}
		
		public virtual Nn.Account.Detail.IAsyncContext PrepareAsync() => throw new NotImplementedException();
		public virtual void GetRequest(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ApplyResponse(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext ApplyResponseAsync(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Suspend(out byte[] _0) => throw new NotImplementedException();
		public virtual ulong GetAccountId() => throw new NotImplementedException();
		public virtual ulong GetLinkedNintendoAccountId() => throw new NotImplementedException();
		public virtual void GetNickname(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetProfileImage(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IOAuthProcedureForNintendoAccountLinkage : _Base_IOAuthProcedureForNintendoAccountLinkage {}
	public unsafe class _Base_IOAuthProcedureForNintendoAccountLinkage : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // PrepareAsync
					var ret = PrepareAsync();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetRequest
					GetRequest(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x1A, 1));
					break;
				}
				case 2: { // ApplyResponse
					ApplyResponse(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 3: { // ApplyResponseAsync
					var ret = ApplyResponseAsync(im.GetBuffer<byte>(0x9, 0));
					om.Move(0, ret.Handle);
					break;
				}
				case 10: { // Suspend
					Suspend(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // GetRequestWithTheme
					GetRequestWithTheme(im.GetData<uint>(0), im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0x1A, 1));
					break;
				}
				case 101: { // IsNetworkServiceAccountReplaced
					var ret = IsNetworkServiceAccountReplaced();
					om.SetData(0, ret);
					break;
				}
				case 199: { // GetUrlForIntroductionOfExtraMembership
					GetUrlForIntroductionOfExtraMembership(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOAuthProcedureForNintendoAccountLinkage: {im.CommandId}");
			}
		}
		
		public virtual Nn.Account.Detail.IAsyncContext PrepareAsync() => throw new NotImplementedException();
		public virtual void GetRequest(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ApplyResponse(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext ApplyResponseAsync(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Suspend(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetRequestWithTheme(uint _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual byte IsNetworkServiceAccountReplaced() => throw new NotImplementedException();
		public virtual void GetUrlForIntroductionOfExtraMembership(Buffer<byte> _0) => throw new NotImplementedException();
	}
}
