#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Socket.Sf {
	[IpcService("bsd:u")]
	[IpcService("bsd:s")]
	public unsafe partial class IClient : _Base_IClient {}
	public unsafe class _Base_IClient : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RegisterClient
					var ret = RegisterClient(im.GetBytes(0, 0x20), im.GetData<ulong>(32), im.GetData<ulong>(40), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					om.SetData(0, ret);
					break;
				}
				case 1: { // StartMonitoring
					StartMonitoring(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 2: { // Socket
					Socket(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 3: { // SocketExempt
					SocketExempt(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 4: { // Open
					Open(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 5: { // Select
					Select(im.GetData<uint>(0), im.GetBytes(4, 0x18), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), im.GetBuffer<byte>(0x21, 2), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1), im.GetBuffer<byte>(0x22, 2));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 6: { // Poll
					Poll(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 7: { // Sysctl
					Sysctl(im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 8: { // Recv
					Recv(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 9: { // RecvFrom
					RecvFrom(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 10: { // Send
					Send(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 11: { // SendTo
					SendTo(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 12: { // Accept
					Accept(im.GetData<uint>(0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 13: { // Bind
					Bind(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 14: { // Connect
					Connect(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 15: { // GetPeerName
					GetPeerName(im.GetData<uint>(0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 16: { // GetSockName
					GetSockName(im.GetData<uint>(0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 17: { // GetSockOpt
					GetSockOpt(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 18: { // Listen
					Listen(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 19: { // Ioctl
					Ioctl(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), im.GetBuffer<byte>(0x21, 2), im.GetBuffer<byte>(0x21, 3), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1), im.GetBuffer<byte>(0x22, 2), im.GetBuffer<byte>(0x22, 3));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 20: { // Fcntl
					Fcntl(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 21: { // SetSockOpt
					SetSockOpt(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 22: { // Shutdown
					Shutdown(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 23: { // ShutdownAllSockets
					ShutdownAllSockets(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 24: { // Write
					Write(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 25: { // Read
					Read(im.GetData<uint>(0), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 26: { // _Close
					_Close(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 27: { // DuplicateSocket
					DuplicateSocket(im.GetData<uint>(0), im.GetData<ulong>(8), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 28: { // GetResourceStatistics
					GetResourceStatistics(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid, out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 29: { // RecvMMsg
					RecvMMsg(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetBytes(12, 0x10), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 30: { // SendMMsg
					SendMMsg(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IClient: {im.CommandId}");
			}
		}
		
		public virtual uint RegisterClient(byte[] _0, ulong _1, ulong _2, ulong _3, KObject _4) => throw new NotImplementedException();
		public virtual void StartMonitoring(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void Socket(uint _0, uint _1, uint _2, out uint _3, out uint _4) => throw new NotImplementedException();
		public virtual void SocketExempt(uint _0, uint _1, uint _2, out uint _3, out uint _4) => throw new NotImplementedException();
		public virtual void Open(uint _0, Buffer<byte> _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Select(uint _0, byte[] _1, Buffer<byte> _2, Buffer<byte> _3, Buffer<byte> _4, out uint _5, out uint _6, Buffer<byte> _7, Buffer<byte> _8, Buffer<byte> _9) => throw new NotImplementedException();
		public virtual void Poll(uint _0, uint _1, Buffer<byte> _2, out uint _3, out uint _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void Sysctl(Buffer<byte> _0, Buffer<byte> _1, out uint _2, out uint _3, out uint _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void Recv(uint _0, uint _1, out uint _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void RecvFrom(uint _0, uint _1, out uint _2, out uint _3, out uint _4, Buffer<byte> _5, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void Send(uint _0, uint _1, Buffer<byte> _2, out uint _3, out uint _4) => throw new NotImplementedException();
		public virtual void SendTo(uint _0, uint _1, Buffer<byte> _2, Buffer<byte> _3, out uint _4, out uint _5) => throw new NotImplementedException();
		public virtual void Accept(uint _0, out uint _1, out uint _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void Bind(uint _0, Buffer<byte> _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Connect(uint _0, Buffer<byte> _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void GetPeerName(uint _0, out uint _1, out uint _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void GetSockName(uint _0, out uint _1, out uint _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void GetSockOpt(uint _0, uint _1, uint _2, out uint _3, out uint _4, out uint _5, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void Listen(uint _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Ioctl(uint _0, uint _1, uint _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5, Buffer<byte> _6, out uint _7, out uint _8, Buffer<byte> _9, Buffer<byte> _10, Buffer<byte> _11, Buffer<byte> _12) => throw new NotImplementedException();
		public virtual void Fcntl(uint _0, uint _1, uint _2, out uint _3, out uint _4) => throw new NotImplementedException();
		public virtual void SetSockOpt(uint _0, uint _1, uint _2, Buffer<byte> _3, out uint _4, out uint _5) => throw new NotImplementedException();
		public virtual void Shutdown(uint _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void ShutdownAllSockets(uint _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void Write(uint _0, Buffer<byte> _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Read(uint _0, out uint _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void _Close(uint _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void DuplicateSocket(uint _0, ulong _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void GetResourceStatistics(uint _0, uint _1, ulong _2, ulong _3, out uint _4, out uint _5, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void RecvMMsg(uint _0, uint _1, uint _2, byte[] _3, out uint _4, out uint _5, Buffer<byte> _6) => throw new NotImplementedException();
		public virtual void SendMMsg(uint _0, uint _1, uint _2, Buffer<byte> _3, Buffer<byte> _4, out uint _5, out uint _6) => throw new NotImplementedException();
	}
}
