#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Audio {
	public unsafe struct AudioInBuffer {
		public ulong Next;
		public ulong Samples;
		public ulong Capacity;
		public ulong Size;
		public ulong Offset;
	}
	
	public unsafe struct AudioOutBuffer {
		public ulong Next;
		public ulong Samples;
		public ulong Capacity;
		public ulong Size;
		public ulong Offset;
	}
}
