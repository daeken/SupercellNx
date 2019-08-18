using System.Runtime.InteropServices;

namespace Supercell.IpcServices.Nn.Audio.Detail {
	enum MemoryPoolState {
		Invalid = 0,
		Unknown = 1,
		RequestDetach = 2,
		Detached = 3,
		RequestAttach = 4,
		Attached = 5,
		Released = 6
	}

	[StructLayout(LayoutKind.Sequential, Size = 0x10, Pack = 4)]
	struct MemoryPoolOut {
		public MemoryPoolState State;
	}

	[StructLayout(LayoutKind.Sequential, Size = 0x20, Pack = 4)]
	struct MemoryPoolIn {
		public ulong Address, Size;
		public MemoryPoolState State;
	}
}