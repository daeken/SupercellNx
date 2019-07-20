#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Eupld.Sf {
	[IpcService("eupld:c")]
	public unsafe partial class IControl : _Base_IControl {}
	public unsafe class _Base_IControl : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetUrl
					SetUrl(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // ImportCrt
					ImportCrt(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2: { // ImportPki
					ImportPki(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				case 3: { // SetAutoUpload
					SetAutoUpload(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IControl: {im.CommandId}");
			}
		}
		
		public virtual void SetUrl(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ImportCrt(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ImportPki(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAutoUpload(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("eupld:r")]
	public unsafe partial class IRequest : _Base_IRequest {}
	public unsafe class _Base_IRequest : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // UploadAll
					UploadAll();
					break;
				}
				case 2: { // UploadSelected
					UploadSelected(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 3: { // GetUploadStatus
					GetUploadStatus(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // CancelUpload
					CancelUpload();
					break;
				}
				case 5: { // GetResult
					GetResult();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequest: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize() => throw new NotImplementedException();
		public virtual void UploadAll() => throw new NotImplementedException();
		public virtual void UploadSelected(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetUploadStatus(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void CancelUpload() => throw new NotImplementedException();
		public virtual void GetResult() => throw new NotImplementedException();
	}
}
