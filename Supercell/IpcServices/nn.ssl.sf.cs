using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Ssl.Sf {
	public partial class ISslService {
		public override Nn.Ssl.Sf.ISslContext CreateContext(uint _0, ulong _1, ulong _2) => new ISslContext();
		public override uint GetContextCount() => throw new NotImplementedException();
		public override void GetCertificates(Buffer<byte> _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override uint GetCertificateBufSize(Buffer<byte> _0) => throw new NotImplementedException();
		public override void DebugIoctl(ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override void SetInterfaceVersion(uint _0) => "Stub hit for Nn.Ssl.Sf.ISslService.SetInterfaceVersion [5]".Debug();
		public override object FlushSessionCache(object _0) => throw new NotImplementedException();
	}
}