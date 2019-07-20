#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Account.Profile {
	public unsafe partial class IProfile : _Base_IProfile {}
	public unsafe class _Base_IProfile : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Get
					Get(out var _0, im.GetBuffer<byte>(0x1A, 0));
					om.SetBytes(0, _0);
					break;
				}
				case 1: { // GetBase
					GetBase(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 10: { // GetImageSize
					var ret = GetImageSize();
					om.SetData(0, ret);
					break;
				}
				case 11: { // LoadImage
					LoadImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProfile: {im.CommandId}");
			}
		}
		
		public virtual void Get(out byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetBase(out byte[] _0) => throw new NotImplementedException();
		public virtual uint GetImageSize() => throw new NotImplementedException();
		public virtual void LoadImage(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IProfileEditor : _Base_IProfileEditor {}
	public unsafe class _Base_IProfileEditor : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Get
					Get(out var _0, im.GetBuffer<byte>(0x1A, 0));
					om.SetBytes(0, _0);
					break;
				}
				case 1: { // GetBase
					GetBase(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 10: { // GetImageSize
					var ret = GetImageSize();
					om.SetData(0, ret);
					break;
				}
				case 11: { // LoadImage
					LoadImage(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 100: { // Store
					Store(im.GetBytes(0, 0x38), im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 101: { // StoreWithImage
					StoreWithImage(im.GetBytes(0, 0x38), im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProfileEditor: {im.CommandId}");
			}
		}
		
		public virtual void Get(out byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetBase(out byte[] _0) => throw new NotImplementedException();
		public virtual uint GetImageSize() => throw new NotImplementedException();
		public virtual void LoadImage(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Store(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StoreWithImage(byte[] _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
}
