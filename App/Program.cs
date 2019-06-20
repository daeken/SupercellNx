using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Common;
using Cpu64;
using UnicornSharp;

namespace App {
	class Program {
		[DllImport("libc")]
		static extern ulong mmap(ulong addr, ulong len, int prot, int flags, int fd, ulong offset);
		
		static unsafe void Main(string[] args) {
			var cpu = new Interpreter();

			var binaries = args.Where(x => !Path.GetFileName(x).Contains(".")).OrderBy(x => Path.GetFileName(x) != "rtld")
				.Select((x, i) => LoadBinary((ulong) (0x7100000000 + (i << 32)), x)).ToList();

			//Relocate(binaries);

			var stackSize = 32UL * 1024 * 1024;
			var stackBase = (ulong) Marshal.AllocHGlobal(32 * 1024 * 1024);
			cpu.SP = stackBase + stackSize;
			cpu.PC = binaries[0].Addr;
			
			var uc = new UnicornArm64();
			uc[Arm64Register.PC] = cpu.PC;
			uc[Arm64Register.SP] = cpu.SP;
			uc[Arm64Register.NZCV] = 0;
			uc[Arm64Register.CPACR_EL1] = 3 << 20;
			uc.Map(binaries[0].Addr, (ulong) binaries[0].Nxo.Data.Length, MemoryPermission.All);
			uc.MemWrite(binaries[0].Addr, binaries[0].Nxo.Data);
			uc.Map(stackBase, stackSize, MemoryPermission.Read | MemoryPermission.Write);

			while(true) {
				var before = cpu.PC;
				var inst = *(uint*) cpu.PC;
				var asm = cpu.Disassemble(inst, cpu.PC);
				if(asm == null) {
					$"Disassembly failed at {cpu.PC:X} --- {inst:X8}".Debug();
					break;
				}
				$"{cpu.PC:X}: {asm}".Debug();
				uc[Arm64Register.PC] = cpu.PC;
				if(!asm.StartsWith("svc "))
					uc.Start(cpu.PC, 0, 0, 1);
				cpu.Interpret(inst, cpu.PC);
				if(before == cpu.PC)
					cpu.PC += 4;
				if(asm.StartsWith("svc ")) {
					uc[Arm64Register.PC] = cpu.PC;
					uc[Arm64Register.SP] = cpu.SP;
					for(var i = 0; i < 31; ++i)
						uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)] = cpu.X[i];
				}
				if(cpu.PC != uc[Arm64Register.PC])
					throw new Exception($"PC mismatch! Unicorn 0x{uc[Arm64Register.PC]:X} vs Supercell 0x{cpu.PC:X}");
				if(cpu.SP != uc[Arm64Register.SP])
					throw new Exception($"SP mismatch! Unicorn 0x{uc[Arm64Register.SP]:X} vs Supercell 0x{cpu.SP:X}");
				if(cpu.NZCV != uc[Arm64Register.NZCV])
					throw new Exception($"NZCV mismatch! Unicorn 0x{uc[Arm64Register.NZCV]:X} vs Supercell 0x{cpu.NZCV:X}");
				for(var i = 0; i < 31; ++i)
					if(cpu.X[i] != uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)])
						throw new Exception($"X{i} mismatch! Unicorn 0x{uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)]:X} vs Supercell 0x{cpu.X[i]:X}");
			}
		}

		static unsafe (ulong Addr, Nxo Nxo) LoadBinary(ulong preferred, string path) {
			$"Loading {path}".Debug();
			var bin = Nxo.Load(File.OpenRead(path));
			
			var addr = mmap(preferred, ((ulong) bin.Data.Length & ~0xFFFU) + 0x1000U, 1 | 2, 0x1000 | 0x0001, 0, 0);
			if(Path.GetFileName(path) == "rtld" && addr != preferred) throw new Exception("Couldn't map binary to preferred addr");

			var root = (byte*) addr;
			foreach(var v in bin.Data)
				*root++ = v;

			return (addr, bin);
		}

		static unsafe void Relocate(List<(ulong Addr, Nxo Nxo)> binaries) {
			
		}
	}
}