using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.socket.sf {
	[IpcService("bsd:u")]
	[IpcService("bsd:s")]
	public class IClient : IpcInterface {
		[IpcCommand(0)]
		void RegisterClient(object /* nn::socket::BsdBufferConfig */ config, ulong ipid, ulong transferMemorySize, [Move] KObject unknown0, [Pid] ulong pid, out uint bsd_errno) => bsd_errno = 0;
		[IpcCommand(1)]
		void StartMonitoring(ulong ipid, [Pid] ulong pid) {}
		[IpcCommand(2)]
		void Socket(uint domain, uint type, uint protocol, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(3)]
		void SocketExempt(uint unknown0, uint unknown1, uint unknown2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(4)]
		void Open(uint unknown0, [Buffer(0x21)] Buffer<byte> unknown1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(5)]
		void Select(uint nfds, object /* nn::socket::timeout */ timeout, [Buffer(0x21)] Buffer<byte> readfds_in, [Buffer(0x21)] Buffer<byte> writefds_in, [Buffer(0x21)] Buffer<byte> errorfds_in, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<byte> readfds_out, [Buffer(0x22)] Buffer<byte> writefds_out, [Buffer(0x22)] Buffer<byte> errorfds_out) => throw new NotImplementedException();
		[IpcCommand(6)]
		void Poll(uint unknown0, uint unknown1, [Buffer(0x21)] Buffer<byte> unknown2, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(7)]
		void Sysctl([Buffer(0x21)] Buffer<byte> unknown0, [Buffer(0x21)] Buffer<byte> unknown1, out int ret, out uint bsd_errno, out uint unknown2, [Buffer(0x22)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(8)]
		void Recv(uint socket, uint flags, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<byte> message) => throw new NotImplementedException();
		[IpcCommand(9)]
		void RecvFrom(uint sock, uint flags, out int ret, out uint bsd_errno, out uint addrlen, [Buffer(0x22)] Buffer<byte> message, [Buffer(0x22)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(10)]
		void Send(uint socket, uint flags, [Buffer(0x21)] Buffer<byte> unknown0, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(11)]
		void SendTo(uint socket, uint flags, [Buffer(0x21)] Buffer<byte> unknown0, [Buffer(0x21)] Buffer<byte> unknown1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(12)]
		void Accept(uint socket, out int ret, out uint bsd_errno, out uint addrlen, [Buffer(0x22)] Buffer<byte> addr) => throw new NotImplementedException();
		[IpcCommand(13)]
		void Bind(uint socket, [Buffer(0x21)] Buffer<byte> unknown0, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(14)]
		void Connect(uint socket, [Buffer(0x21)] Buffer<byte> unknown0, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(15)]
		void GetPeerName(uint socket, out int ret, out uint bsd_errno, out uint addrlen, [Buffer(0x22)] Buffer<byte> addr) => throw new NotImplementedException();
		[IpcCommand(16)]
		void GetSockName(uint socket, out int ret, out uint bsd_errno, out uint addrlen, [Buffer(0x22)] Buffer<byte> addr) => throw new NotImplementedException();
		[IpcCommand(17)]
		void GetSockOpt(uint unknown0, uint unknown1, uint unknown2, out int ret, out uint bsd_errno, out uint unknown3, [Buffer(0x22)] Buffer<byte> unknown4) => throw new NotImplementedException();
		[IpcCommand(18)]
		void Listen(uint socket, uint backlog, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(19)]
		void Ioctl(uint unknown0, uint unknown1, uint unknown2, [Buffer(0x21)] Buffer<byte> unknown3, [Buffer(0x21)] Buffer<byte> unknown4, [Buffer(0x21)] Buffer<byte> unknown5, [Buffer(0x21)] Buffer<byte> unknown6, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<byte> unknown7, [Buffer(0x22)] Buffer<byte> unknown8, [Buffer(0x22)] Buffer<byte> unknown9, [Buffer(0x22)] Buffer<byte> unknown10) => throw new NotImplementedException();
		[IpcCommand(20)]
		void Fcntl(uint unknown0, uint unknown1, uint unknown2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(21)]
		void SetSockOpt(uint socket, uint level, uint option_name, [Buffer(0x21)] Buffer<byte> unknown0, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(22)]
		void Shutdown(uint socket, uint how, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(23)]
		void ShutdownAllSockets(uint how, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(24)]
		void Write(uint socket, [Buffer(0x21)] Buffer<byte> message, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(25)]
		void Read(uint socket, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<sbyte> message) => throw new NotImplementedException();
		[IpcCommand(26)]
		void Close(uint socket, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(27)]
		void DuplicateSocket(uint unknown0, ulong unknown1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		[IpcCommand(28)]
		void GetResourceStatistics(uint unknown0, uint unknown1, ulong unknown2, [Pid] ulong pid, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(29)]
		void RecvMMsg(uint unknown0, uint unknown1, uint unknown2, object unknown3, out int ret, out uint bsd_errno, [Buffer(0x22)] Buffer<byte> unknown4) => throw new NotImplementedException();
		[IpcCommand(30)]
		void SendMMsg(uint unknown0, uint unknown1, uint unknown2, [Buffer(0x21)] Buffer<byte> unknown3, [Buffer(0x21)] Buffer<byte> unknown4, out int ret, out uint bsd_errno) => throw new NotImplementedException();
	}
}
