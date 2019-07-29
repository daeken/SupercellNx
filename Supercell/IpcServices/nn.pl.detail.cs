using System;

namespace Supercell.IpcServices.Nn.Pl.Detail {
	public partial class ISharedFontManager {
		public override void RequestLoad(uint _0) => "Stub hit for Nn.Pl.Detail.ISharedFontManager.RequestLoad [0]".Debug();
		public override uint GetLoadState(uint _0) => 1;
		public override uint GetSize(uint _0) => throw new NotImplementedException();
		public override uint GetSharedMemoryAddressOffset(uint _0) => throw new NotImplementedException();
		public override KObject GetSharedMemoryNativeHandle() => throw new NotImplementedException();
		public override void GetSharedFontInOrderOfPriority(byte[] _0, out byte _1, out uint _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5) => throw new NotImplementedException();
	}
}