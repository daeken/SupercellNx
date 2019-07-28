#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Socket.Sf {
	[IpcService("bsd:u")]
	[IpcService("bsd:s")]
	public unsafe partial class IClient : _Base_IClient {}
	public unsafe class _Base_IClient : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RegisterClient
					var ret = RegisterClient((Nn.Socket.BsdBufferConfig*) im.GetDataPointer(8), im.GetData<ulong>(8), im.GetData<ulong>(16), Kernel.Get<KObject>(im.GetCopy(0)), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // StartMonitoring
					StartMonitoring(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Socket
					Socket(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 3: { // SocketExempt
					SocketExempt(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 4: { // Open
					Open(im.GetData<uint>(8), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 5: { // Select
					Select(im.GetData<uint>(8), (Nn.Socket.Timeout*) im.GetDataPointer(12), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), im.GetBuffer<byte>(0x21, 2), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1), im.GetBuffer<byte>(0x22, 2));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 6: { // Poll
					Poll(im.GetData<uint>(8), im.GetData<uint>(12), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 7: { // Sysctl
					Sysctl(im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 8: { // Recv
					Recv(im.GetData<uint>(8), im.GetData<uint>(12), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 9: { // RecvFrom
					RecvFrom(im.GetData<uint>(8), im.GetData<uint>(12), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<Nn.Socket.Sockaddr>(0x22, 1));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 10: { // Send
					Send(im.GetData<uint>(8), im.GetData<uint>(12), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 11: { // SendTo
					SendTo(im.GetData<uint>(8), im.GetData<uint>(12), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<Nn.Socket.Sockaddr>(0x21, 1), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 12: { // Accept
					Accept(im.GetData<uint>(8), out var _0, out var _1, out var _2, im.GetBuffer<Nn.Socket.Sockaddr>(0x22, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 13: { // Bind
					Bind(im.GetData<uint>(8), im.GetBuffer<Nn.Socket.Sockaddr>(0x21, 0), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 14: { // Connect
					Connect(im.GetData<uint>(8), im.GetBuffer<Nn.Socket.Sockaddr>(0x21, 0), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 15: { // GetPeerName
					GetPeerName(im.GetData<uint>(8), out var _0, out var _1, out var _2, im.GetBuffer<Nn.Socket.Sockaddr>(0x22, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 16: { // GetSockName
					GetSockName(im.GetData<uint>(8), out var _0, out var _1, out var _2, im.GetBuffer<Nn.Socket.Sockaddr>(0x22, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 17: { // GetSockOpt
					GetSockOpt(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 18: { // Listen
					Listen(im.GetData<uint>(8), im.GetData<uint>(12), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 19: { // Ioctl
					Ioctl(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), im.GetBuffer<byte>(0x21, 2), im.GetBuffer<byte>(0x21, 3), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1), im.GetBuffer<byte>(0x22, 2), im.GetBuffer<byte>(0x22, 3));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 20: { // Fcntl
					Fcntl(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 21: { // SetSockOpt
					SetSockOpt(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 22: { // Shutdown
					Shutdown(im.GetData<uint>(8), im.GetData<uint>(12), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 23: { // ShutdownAllSockets
					ShutdownAllSockets(im.GetData<uint>(8), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 24: { // Write
					Write(im.GetData<uint>(8), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 25: { // Read
					Read(im.GetData<uint>(8), out var _0, out var _1, im.GetBuffer<sbyte>(0x22, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 26: { // _Close
					_Close(im.GetData<uint>(8), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 27: { // DuplicateSocket
					DuplicateSocket(im.GetData<uint>(8), im.GetData<ulong>(16), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 28: { // GetResourceStatistics
					GetResourceStatistics(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid, out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 29: { // RecvMMsg
					RecvMMsg(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetData<UInt128>(32), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 30: { // SendMMsg
					SendMMsg(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IClient: {im.CommandId}");
			}
		}
		
		public virtual uint RegisterClient(Nn.Socket.BsdBufferConfig* config, ulong pid, ulong transferMemorySize, KObject _3, ulong _4) => throw new NotImplementedException();
		public virtual void StartMonitoring(ulong pid, ulong _1) => "Stub hit for Nn.Socket.Sf.IClient.StartMonitoring [1]".Debug();
		public virtual void Socket(uint domain, uint type, uint protocol, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void SocketExempt(uint _0, uint _1, uint _2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Open(uint _0, Buffer<byte> _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Select(uint nfds, Nn.Socket.Timeout* timeout, Buffer<byte> readfds_in, Buffer<byte> writefds_in, Buffer<byte> errorfds_in, out int ret, out uint bsd_errno, Buffer<byte> readfds_out, Buffer<byte> writefds_out, Buffer<byte> errorfds_out) => throw new NotImplementedException();
		public virtual void Poll(uint _0, uint _1, Buffer<byte> _2, out int ret, out uint bsd_errno, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void Sysctl(Buffer<byte> _0, Buffer<byte> _1, out int ret, out uint bsd_errno, out uint _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void Recv(uint socket, uint flags, out int ret, out uint bsd_errno, Buffer<byte> message) => throw new NotImplementedException();
		public virtual void RecvFrom(uint sock, uint flags, out int ret, out uint bsd_errno, out uint addrlen, Buffer<byte> message, Buffer<Nn.Socket.Sockaddr> _6) => throw new NotImplementedException();
		public virtual void Send(uint socket, uint flags, Buffer<byte> _2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void SendTo(uint socket, uint flags, Buffer<byte> _2, Buffer<Nn.Socket.Sockaddr> _3, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Accept(uint socket, out int ret, out uint bsd_errno, out uint addrlen, Buffer<Nn.Socket.Sockaddr> addr) => throw new NotImplementedException();
		public virtual void Bind(uint socket, Buffer<Nn.Socket.Sockaddr> _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Connect(uint socket, Buffer<Nn.Socket.Sockaddr> _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void GetPeerName(uint socket, out int ret, out uint bsd_errno, out uint addrlen, Buffer<Nn.Socket.Sockaddr> addr) => throw new NotImplementedException();
		public virtual void GetSockName(uint socket, out int ret, out uint bsd_errno, out uint addrlen, Buffer<Nn.Socket.Sockaddr> addr) => throw new NotImplementedException();
		public virtual void GetSockOpt(uint _0, uint _1, uint _2, out int ret, out uint bsd_errno, out uint _5, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void Listen(uint socket, uint backlog, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Ioctl(uint _0, uint _1, uint _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5, Buffer<byte> _6, out int ret, out uint bsd_errno, Buffer<byte> _9, Buffer<byte> _10, Buffer<byte> _11, Buffer<byte> _12) => throw new NotImplementedException();
		public virtual void Fcntl(uint _0, uint _1, uint _2, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void SetSockOpt(uint socket, uint level, uint option_name, Buffer<byte> _3, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Shutdown(uint socket, uint how, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void ShutdownAllSockets(uint how, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Write(uint socket, Buffer<byte> message, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void Read(uint socket, out int ret, out uint bsd_errno, Buffer<sbyte> message) => throw new NotImplementedException();
		public virtual void _Close(uint socket, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void DuplicateSocket(uint _0, ulong _1, out int ret, out uint bsd_errno) => throw new NotImplementedException();
		public virtual void GetResourceStatistics(uint _0, uint _1, ulong _2, ulong _3, out int ret, out uint bsd_errno, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void RecvMMsg(uint _0, uint _1, uint _2, UInt128 _3, out int ret, out uint bsd_errno, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void SendMMsg(uint _0, uint _1, uint _2, Buffer<byte> _3, Buffer<byte> _4, out int ret, out uint bsd_errno) => throw new NotImplementedException();
	}
}
