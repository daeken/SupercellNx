using System;
using UltimateOrb;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Socket.Sf {
	public unsafe partial class IClient {
		public override uint RegisterClient(Nn.Socket.BsdBufferConfig* config, ulong pid, ulong transferMemorySize,
			KObject _3, ulong _4) => 0;
		
		public override void StartMonitoring(ulong pid, ulong _1) {}
		
		public override void Socket(uint domain, uint type, uint protocol, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void SocketExempt(uint _0, uint _1, uint _2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Open(uint _0, Buffer<byte> _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Select(uint nfds, Nn.Socket.Timeout* timeout, Buffer<byte> readfds_in, Buffer<byte> writefds_in, Buffer<byte> errorfds_in, out int ret, out uint bsd_errno, Buffer<byte> readfds_out, Buffer<byte> writefds_out, Buffer<byte> errorfds_out) => throw new NotImplementedException();
		public override void Poll(uint _0, uint _1, Buffer<byte> _2, out int ret, out uint bsd_errno, Buffer<byte> _5) => throw new NotImplementedException();
		public override void Sysctl(Buffer<byte> _0, Buffer<byte> _1, out int ret, out uint bsd_errno, out uint _4, Buffer<byte> _5) => throw new NotImplementedException();
		public override void Recv(uint socket, uint flags, out int ret, out uint bsd_errno, Buffer<byte> message) => throw new NotImplementedException();
		public override void RecvFrom(uint sock, uint flags, out int ret, out uint bsd_errno, out uint addrlen, Buffer<byte> message, Buffer<Nn.Socket.Sockaddr> _6) => throw new NotImplementedException();
		public override void Send(uint socket, uint flags, Buffer<byte> _2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void SendTo(uint socket, uint flags, Buffer<byte> _2, Buffer<Nn.Socket.Sockaddr> _3, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Accept(uint socket, out int ret, out uint bsd_errno, out uint addrlen, Buffer<Nn.Socket.Sockaddr> addr) => throw new NotImplementedException();
		public override void Bind(uint socket, Buffer<Nn.Socket.Sockaddr> _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Connect(uint socket, Buffer<Nn.Socket.Sockaddr> _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void GetPeerName(uint socket, out int ret, out uint bsd_errno, out uint addrlen, Buffer<Nn.Socket.Sockaddr> addr) => throw new NotImplementedException();
		public override void GetSockName(uint socket, out int ret, out uint bsd_errno, out uint addrlen, Buffer<Nn.Socket.Sockaddr> addr) => throw new NotImplementedException();
		public override void GetSockOpt(uint _0, uint _1, uint _2, out int ret, out uint bsd_errno, out uint _5, Buffer<byte> _6) => throw new NotImplementedException();
		public override void Listen(uint socket, uint backlog, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Ioctl(uint _0, uint _1, uint _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5, Buffer<byte> _6, out int ret, out uint bsd_errno, Buffer<byte> _9, Buffer<byte> _10, Buffer<byte> _11, Buffer<byte> _12) => throw new NotImplementedException();
		public override void Fcntl(uint _0, uint _1, uint _2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void SetSockOpt(uint socket, uint level, uint option_name, Buffer<byte> _3, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Shutdown(uint socket, uint how, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void ShutdownAllSockets(uint how, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Write(uint socket, Buffer<byte> message, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void Read(uint socket, out int ret, out uint bsd_errno, Buffer<sbyte> message) => throw new NotImplementedException();
		public override void _Close(uint socket, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void DuplicateSocket(uint _0, ulong _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public override void GetResourceStatistics(uint _0, uint _1, ulong _2, ulong _3, out int ret, out uint bsd_errno, Buffer<byte> _6) => throw new NotImplementedException();
		public override void RecvMMsg(uint _0, uint _1, uint _2, UInt128 _3, out int ret, out uint bsd_errno, Buffer<byte> _6) => throw new NotImplementedException();
		public override void SendMMsg(uint _0, uint _1, uint _2, Buffer<byte> _3, Buffer<byte> _4, out int ret, out uint bsd_errno) => throw new NotImplementedException();
	}
}
