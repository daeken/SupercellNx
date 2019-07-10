using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.ssl.sf {
	[IpcService("ssl")]
	public class ISslService : IpcInterface {
		[IpcCommand(0)]
		void CreateContext(uint /* nn::ssl::sf::SslVersion */ unknown0, ulong unknown1, [Pid] ulong pid, [Move] out ISslContext context) => context = new ISslContext();
		[IpcCommand(1)]
		void GetContextCount(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(2)]
		void GetCertificates([Buffer(0x5)] Buffer<byte> unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(3)]
		void GetCertificateBufSize([Buffer(0x5)] Buffer<byte> unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(4)]
		void DebugIoctl(ulong unknown0, [Buffer(0x5)] Buffer<byte> unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(5)]
		void SetInterfaceVersion(uint unknown0) {}
		[IpcCommand(6)]
		void FlushSessionCache(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
	
	public class ISslContext : IpcInterface {
		[IpcCommand(0)]
		void SetOption(uint /* nn::ssl::sf::ContextOption */ unknown0, uint unknown1) => throw new NotImplementedException();
		[IpcCommand(1)]
		void GetOption(uint /* nn::ssl::sf::ContextOption */ unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(2)]
		void CreateConnection(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(3)]
		void GetConnectionCount(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(4)]
		void ImportServerPki(uint /* nn::ssl::sf::CertificateFormat */ unknown0, [Buffer(0x5)] Buffer<byte> unknown1, out ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(5)]
		void ImportClientPki([Buffer(0x5)] Buffer<byte> unknown0, [Buffer(0x5)] Buffer<byte> unknown1, out ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(6)]
		void RemoveServerPki(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(7)]
		void RemoveClientPki(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(8)]
		void RegisterInternalPki(uint /* nn::ssl::sf::InternalPki */ unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(9)]
		void AddPolicyOid([Buffer(0x5)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(10)]
		void ImportCrl([Buffer(0x5)] Buffer<byte> unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(11)]
		void RemoveCrl(ulong unknown0) => throw new NotImplementedException();
	}
}