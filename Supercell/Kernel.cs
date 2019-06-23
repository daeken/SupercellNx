using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using Cpu64;
using PrettyPrinter;

namespace Supercell {
	public class Kernel : IKernel {
		public static readonly Kernel Instance = new Kernel();
		//public static readonly BaseCpu Cpu = new Interpreter(Instance);
		public static readonly BaseCpu Cpu = new Recompiler(Instance);
		public static readonly MemoryManager Memory = new MemoryManager();
		public static readonly ServiceManager Service = new ServiceManager();
		
		public unsafe void LoadAndRun(string[] fns) {
			(ulong Addr, Nxo Nxo) LoadBinary(ulong preferred, string path) {
				$"Loading {path}".Debug();
				var bin = Nxo.Load(File.OpenRead(path));
			
				var addr = Memory.AllocateAligned((ulong) bin.Data.Length + (bin.BssEnd - bin.BssStart + 0x2000), preferred);
				if(Path.GetFileName(path) == "sdk" && addr != preferred) throw new Exception("Couldn't map binary to preferred addr");
				$"Loaded at 0x{addr:X}".Debug();

				var root = (byte*) addr;
				foreach(var v in bin.Data)
					*root++ = v;

				return (addr, bin);
			}
			
			var binaries = fns.Where(x => !Path.GetFileName(x).Contains(".")).OrderBy(x => Path.GetFileName(x) != "sdk")
				.Select((x, i) => (x, LoadBinary((ulong) (0x7100000000 + (i << 32)), x)))
				.OrderBy(x => Path.GetFileName(x.Item1) != "rtld").Select(x => x.Item2).ToList();
			
			var stackSize = 32UL * 1024 * 1024;
			var stackBase = Memory.AllocateAligned(32 * 1024 * 1024, 0x40000000);
			Cpu.Run(binaries[0].Addr, stackBase + stackSize);
		}

		public IEnumerable<(ulong Start, ulong Size)> MemoryRegions => Memory.Regions.Values;
		public void Svc(int svc) => Service.Svc(svc);

		string DebugBuffer = "";
		[Svc(0x27)]
		public unsafe uint OutputDebugString(ulong addr, ulong size) {
			var data = new byte[size];
			for(var i = 0; i < data.Length; ++i)
				data[i] = *(byte*) (addr + (ulong) i);
			DebugBuffer += Encoding.ASCII.GetString(data);
			int j;
			while((j = DebugBuffer.IndexOf('\n')) != -1) {
				$"Debug string: {DebugBuffer.Substring(0, j).ToPrettyString()}".Debug();
				DebugBuffer = DebugBuffer.Substring(j + 1);
			}
			return 0;
		}

		[Svc(0x29)]
		public (uint, ulong) GetInfo(uint id1, uint handle, uint id2) {
			$"GetInfo({id1}, 0x{handle:X}, {id2})".Debug();
			var value = 0UL;
			switch((id1, id2)) {
				case (0, 0): value = 0xF; break;
				case (1, 0): value = 0xFFFFFFFF00000000UL; break;
				case (2, 0): value = 0xbb0000000; break;
				case (3, 0): value = 0x1000000000; break;
				case (4, 0): value = 0xaa0000000; break;
				case (5, 0): value = 0; break;
				case (6, 0): value = 0x400000; break;
				case (7, 0): value = 0x10000; break;
				case (12, 0): value = 0x10000; break;
				case (13, 0): value = 0x10000; break;
				case (14, 0): value = 0x10000; break;
				case (15, 0): value = 0x10000; break;
				case (18, 0): value = 0x10000; break;
				case (11, _): value = 0; break;
				default:
					$"Unhandled GetInfo!".Debug();
					return (0xF001, 0);
			}
			return (0, value);
		}
	}
}