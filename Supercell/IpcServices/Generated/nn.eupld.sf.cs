#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Eupld.Sf {
	[IpcService("eupld:c")]
	public unsafe partial class IControl : _Base_IControl {}
	public unsafe class _Base_IControl : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetUrl
					SetUrl(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // ImportCrt
					ImportCrt(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // ImportPki
					ImportPki(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // SetAutoUpload
					SetAutoUpload(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IControl: {im.CommandId}");
			}
		}
		
		public virtual void SetUrl(Buffer<byte> _0) => "Stub hit for Nn.Eupld.Sf.IControl.SetUrl [0]".Debug();
		public virtual void ImportCrt(Buffer<byte> _0) => "Stub hit for Nn.Eupld.Sf.IControl.ImportCrt [1]".Debug();
		public virtual void ImportPki(Buffer<byte> _0, Buffer<byte> _1) => "Stub hit for Nn.Eupld.Sf.IControl.ImportPki [2]".Debug();
		public virtual void SetAutoUpload(object _0) => "Stub hit for Nn.Eupld.Sf.IControl.SetAutoUpload [3]".Debug();
	}
	
	[IpcService("eupld:r")]
	public unsafe partial class IRequest : _Base_IRequest {}
	public unsafe class _Base_IRequest : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // UploadAll
					UploadAll();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // UploadSelected
					UploadSelected(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetUploadStatus
					GetUploadStatus(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // CancelUpload
					CancelUpload();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequest: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize() => throw new NotImplementedException();
		public virtual void UploadAll() => "Stub hit for Nn.Eupld.Sf.IRequest.UploadAll [1]".Debug();
		public virtual void UploadSelected(Buffer<byte> _0) => "Stub hit for Nn.Eupld.Sf.IRequest.UploadSelected [2]".Debug();
		public virtual void GetUploadStatus(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void CancelUpload() => "Stub hit for Nn.Eupld.Sf.IRequest.CancelUpload [4]".Debug();
		public virtual void GetResult() => "Stub hit for Nn.Eupld.Sf.IRequest.GetResult [5]".Debug();
	}
}
