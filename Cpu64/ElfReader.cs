using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Cpu64 {
	public unsafe class ElfReader : IBinaryReader {
		/*[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct ElfHeader {
			public uint Magic;
			public byte Class, Data, Version, Abi, AbiVersion;
			byte _Pad0, _Pad1, _Pad2, _Pad3, _Pad4, _Pad5, _Pad6;
			public ushort Type, Machine;
			public uint EVersion;
			public ulong Entry, PhOff, ShOff;
			public uint Flags;
			public ushort EhSize, PhEntSize, PhNum, ShEntSize, ShNum, ShStrNdx;
		}*/
		
		[DllImport("libdl.so", CharSet = CharSet.Ansi)]
		static extern ulong dlopen(string name, int flags);
		[DllImport("libdl.so", CharSet = CharSet.Ansi)]
		static extern ulong dlsym(ulong handle, string name);

		public void* Load(byte[] file, ulong blockAddr) {
			var fn = $"_{blockAddr:X}.o";
			using(var fp = File.OpenWrite(fn))
				fp.Write(file);
			var handle = dlopen("./" + fn, 2); // RTLD_NOW
			if(handle == 0)
				throw new Exception("Loading file failed?");
			var addr = (void*) dlsym(handle, $"_{blockAddr:X}");
			if(addr == null)
				throw new Exception("Finding symbol failed?");
			File.Delete(fn);
			return addr;
		}
	}
}