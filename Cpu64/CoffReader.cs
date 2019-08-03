using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LLVMSharp;
using MoreLinq;
using PrettyPrinter;

namespace Cpu64 {
	public unsafe class CoffReader {
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct CoffHeader {
			public ushort Magic, NumSections;
			public uint Timestamp, SymbolPointer, NumSymbols;
			public ushort OptionalHeaderSize, Flags;
			public byte End;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct CoffSymbol {
			public fixed byte Name[8];
			public uint Value;
			public short SectionNumber;
			public ushort Type;
			public byte StorageClass, NumAux;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct CoffSectionHeader {
			public fixed byte Name[8];
			public uint PhysAddr, VirtAddr, Size, DataOffset, RelocOffset, LineOffset;
			public ushort NumRelocs, NumLines;
			public uint Flags;
			public byte End;
		}

		enum RelocationType : ushort {
			Absolute = 0x0000,
			Addr64 = 0x0001,
			Addr32 = 0x0002,
			Addr32Nb = 0x0003,
			Rel32 = 0x0004,
			Rel32_1 = 0x0005,
			Rel32_2 = 0x0006,
			Rel32_3 = 0x0007,
			Rel32_4 = 0x0008,
			Rel32_5 = 0x0009,
			Section = 0x000A,
			SecRel = 0x000B,
			SecRel7 = 0x000C,
			Token = 0x000D,
			SRel32 = 0x000E,
			Pair = 0x000F,
			SSpan32 = 0x0010
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct CoffRelocation {
			public uint VirtAddr, SymbolIndex;
			public RelocationType Type;
		}
		
		[DllImport("libc")]
		static extern void mprotect(ulong addr, ulong len, int prot);
		[DllImport("kernel32")]
		static extern void VirtualProtect(ulong addr, ulong len, int prot, out int oldProt);

		static bool Initialized;
		static LLVMModuleRef Module;
		static LLVMExecutionEngineRef ExecutionEngine;

		static ulong GetIntrinsic(string name) {
			var func = LLVM.GetNamedFunction(Module, name);
			func = func.Pointer == IntPtr.Zero
				? LLVM.AddFunction(Module, name,
					LLVMTypeRef.FunctionType(LLVMTypeRef.VoidType(), new LLVMTypeRef[0], false))
				: func;
			return (ulong) LLVM.GetPointerToGlobal(ExecutionEngine, func);
		}

		public void* Load(byte[] file, ulong blockAddr) {
			if(!Initialized) {
				Initialized = true;
				if(LLVM.CreateExecutionEngineForModule(out ExecutionEngine,
					Module = LLVM.ModuleCreateWithName("CoffReader"), out var err))
					throw new Exception("LLVM Error: " + err);
			}
			
			fixed(byte* _ptr = file) {
				var ptr = _ptr;
				var header = (CoffHeader*) ptr;
				var cur = &header->End;
				var off = 0;
				var segments = new List<(string Name, byte[] Data, List<CoffRelocation> Relocations, int Offset)>();
				for(var i = 0; i < header->NumSections; ++i) {
					var sectHeader = (CoffSectionHeader*) cur;
					cur = &sectHeader->End;
					var name = Encoding.ASCII.GetString(new Span<byte>(sectHeader->Name, 8)).TrimEnd('\0');
					var size = sectHeader->Size;
					while(size % 16 != 0) size++;
					var sdata = (sectHeader->Flags & 0x80) != 0
						? new byte[size]
						: new Span<byte>(ptr + sectHeader->DataOffset, (int) size).ToArray();
					segments.Add((name, sdata, Enumerable.Range(0, sectHeader->NumRelocs)
						.Select(j => ((CoffRelocation*) (ptr + sectHeader->RelocOffset))[j]).ToList(), off));
					off += (int) size;
				}

				var csym = (CoffSymbol*) (ptr + header->SymbolPointer);
				var strtabPtr = (byte*) &csym[header->NumSymbols];
				var strtabLength = *(int*) strtabPtr;

				string GetString(byte* name) =>
					Marshal.PtrToStringAnsi((IntPtr) (*(uint*) name == 0 ? strtabPtr + *(uint*) (name + 4) : name));
				
				var symbols = new Dictionary<int, (string Name, CoffSymbol Symbol)>();
				for(var i = 0; i < header->NumSymbols; ++i) {
					var sym = csym[i];
					symbols[i] = (GetString(sym.Name), sym);
					i += sym.NumAux;
				}

				var addr = (byte*) Marshal.AllocHGlobal(off);
				Debug.Assert(addr != null);
				segments.ForEach(seg =>
					Marshal.Copy(seg.Data, 0, (IntPtr) (addr + seg.Offset), seg.Data.Length));
				
				foreach(var seg in segments) {
					foreach(var reloc in seg.Relocations) {
						var sym = symbols[(int) reloc.SymbolIndex];
						var value = sym.Symbol.SectionNumber switch {
							-1 => sym.Symbol.Value,
							0 => GetIntrinsic(sym.Name),
							_ => (ulong) (addr + segments[sym.Symbol.SectionNumber - 1].Offset + sym.Symbol.Value)
						};
						var target = addr + seg.Offset + reloc.VirtAddr;
						switch(reloc.Type) {
							case RelocationType.Addr64:
								*(ulong*) target = value;
								break;
							case RelocationType.Addr32Nb:
								*(uint*) target = (uint) (value - (ulong) addr);
								break;
							default:
								throw new NotImplementedException($"Unknown relocation type {reloc.Type}");
						}
					}
				}

				var paddr = (ulong) addr & ~0xFFFUL;
				var psize = (ulong) off + ((ulong) addr - paddr);
				while((psize & 0xFFFUL) != 0) psize++;
				if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
					VirtualProtect(paddr, psize, 0x40, out _); // PAGE_EXECUTE_READWRITE
				else
					mprotect(paddr, psize, 7); // RWX
				return addr + segments.First(x => x.Name == ".text").Offset;
			}
		}
	}
}