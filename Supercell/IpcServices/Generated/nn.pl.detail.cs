#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pl.Detail {
	[IpcService("pl:u")]
	public unsafe partial class ISharedFontManager : _Base_ISharedFontManager {}
	public unsafe class _Base_ISharedFontManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestLoad
					RequestLoad(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetLoadState
					var ret = GetLoadState(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 2: { // GetSize
					var ret = GetSize(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 3: { // GetSharedMemoryAddressOffset
					var ret = GetSharedMemoryAddressOffset(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 4: { // GetSharedMemoryNativeHandle
					var ret = GetSharedMemoryNativeHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 5: { // GetSharedFontInOrderOfPriority
					GetSharedFontInOrderOfPriority(im.GetBytes(8, 0x8), out var _0, out var _1, im.GetBuffer<byte>(0x6, 0), im.GetBuffer<byte>(0x6, 1), im.GetBuffer<byte>(0x6, 2));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISharedFontManager: {im.CommandId}");
			}
		}
		
		public virtual void RequestLoad(uint _0) => "Stub hit for Nn.Pl.Detail.ISharedFontManager.RequestLoad [0]".Debug();
		public virtual uint GetLoadState(uint _0) => throw new NotImplementedException();
		public virtual uint GetSize(uint _0) => throw new NotImplementedException();
		public virtual uint GetSharedMemoryAddressOffset(uint _0) => throw new NotImplementedException();
		public virtual KObject GetSharedMemoryNativeHandle() => throw new NotImplementedException();
		public virtual void GetSharedFontInOrderOfPriority(byte[] _0, out byte _1, out uint _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5) => throw new NotImplementedException();
	}
}
