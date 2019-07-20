#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Socket {
	public unsafe struct SockaddrIn {
		public byte SinLen;
		public byte SinFamily;
		public ushort SinPort;
		public uint SinAddr;
		public fixed byte SinZero[8];
	}
	
	public unsafe struct Sockaddr {
		public byte SaLen;
		public byte SaFamily;
		public byte _Addr;
	}
	
	public unsafe struct Timeout {
		public ulong Sec;
		public ulong Usec;
		public ulong Off;
	}
	
	public unsafe struct BsdBufferConfig {
		public uint Version;
		public uint TcpTxBufSize;
		public uint TcpRxBufSize;
		public uint TcpTxBufMaxSize;
		public uint TcpRxBufMaxSize;
		public uint UdpTxBufSize;
		public uint UdpRxBufSize;
		public uint SbEfficiency;
	}
}
