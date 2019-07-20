#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Account.Http {
	public unsafe partial class IOAuthProcedure : _Base_IOAuthProcedure {}
	public unsafe class _Base_IOAuthProcedure : IpcInterface {
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
				default:
					throw new NotImplementedException($"Unhandled command ID to IOAuthProcedure: {im.CommandId}");
			}
		}
		
		public virtual Nn.Account.Detail.IAsyncContext PrepareAsync() => throw new NotImplementedException();
		public virtual void GetRequest(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ApplyResponse(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Account.Detail.IAsyncContext ApplyResponseAsync(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Suspend(out byte[] _0) => throw new NotImplementedException();
	}
}
