using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using Common;
using UnicornSharp;

namespace Cpu64 {
	public class Unicore : BaseCpu {
		readonly UnicornArm64 Uc = new UnicornArm64();

		ulong this[int i] {
			get => Uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)];
			set => Uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)] = value;
		}

		public Unicore(IKernel kernel) : base(kernel) {}
		
		public override unsafe void Run(ulong _pc, ulong sp, bool one = false) {
			foreach(var (start, size) in Kernel.MemoryRegions) {
				$"Mapped 0x{start:X} - 0x{start+size:X}".Debug();
				Uc.Map(start, size, MemoryPermission.All, (IntPtr) start);
			}
			
			Uc.OnInterrupt += (_, intno) => {
				var inst = *(uint*) (Uc[Arm64Register.PC] - 4);
				if((inst & 0xFFE0001FU) != 0xD4000001U) throw new NotImplementedException();

				foreach(var (start, size) in Kernel.MemoryRegions)
					Uc.Unmap(start, size);
				var imm = (inst >> 5) & 0xFFFFU;
				SP = Uc[Arm64Register.SP];
				for(var i = 0; i < 31; ++i)
					X[i] = this[i];
				
				Svc(imm);
				
				Uc[Arm64Register.SP] = SP;
				for(var i = 0; i < 31; ++i)
					this[i] = X[i];
				foreach(var (start, size) in Kernel.MemoryRegions)
					Uc.Map(start, size, MemoryPermission.All, (IntPtr) start);
			};

			/*var depth = 0;
			Uc.OnCode += (_, addr, __) => {
				var inst = *(uint*) addr;
				if((inst & 0xFC000000U) == 0x94000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var offset = SignExt<long>(imm << 0x2, 28);
					var taddr = addr + (ulong) offset;
					$"{"  ".Repeat(depth++)}{Kernel.MapAddress(taddr)}".Debug();
				} else if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					$"{"  ".Repeat(depth++)}{Kernel.MapAddress(rn == 31 ? 0UL : this[(int) rn])}".Debug();
				} else if((inst & 0xFFFFFC1FU) == 0xD65F0000U)
					depth--;
			};*/

			var resetTicks = false;
			//var BW = new BinaryWriter(File.OpenWrite("uniinsns.bin"));
			//var skip = 131_000_000L;
			Uc.OnCode += (_, addr, __) => {
				if(resetTicks) {
					resetTicks = false;
					Uc[Arm64Register.X0] = 0;
				} else if(*(uint*) addr == 0xD53BE020) resetTicks = true;

				/*if(skip > 0) {
					skip--;
					return;
				}
				BW.Write(addr);
				BW.Write((byte) (Uc[Arm64Register.NZCV] >> 28));
				for(var i = 0; i < 31; ++i)
					BW.Write(this[i]);
				for(var i = 0; i < 32; ++i)
					BW.Write(Uc[Arm64Register.D0 + i]);
				BW.Write(Uc[Arm64Register.SP]);*/
			};
			
			//Uc.AddCodeHook((_, __, ___) => throw new NotImplementedException(), 0x7200000024, 0x7200000030);
			
			Uc.OnBadRead += (_, addr, size, __) => {
				$"[{Kernel.MapAddress(Uc[Arm64Register.PC])}] Bad read ({size} bytes) from {Kernel.MapAddress(addr)}".Debug();
				Environment.Exit(1);
				return false;
			};

			Uc.OnBadWrite += (_, addr, size, value, __) => {
				$"[{Kernel.MapAddress(Uc[Arm64Register.PC])}] Bad write (0x{value:X} -- {size} bytes) to {Kernel.MapAddress(addr)}".Debug();
				Environment.Exit(1);
				return false;
			};
			
			Uc[Arm64Register.SP] = sp;
			Uc[Arm64Register.PC] = _pc;
			Uc[Arm64Register.TPIDRRO_EL0] = TlsBase;
			Uc[Arm64Register.CPACR_EL1] = 3 << 20;

			try {
				Uc.Start(_pc);
			} catch (Exception) {
				$"{Uc[Arm64Register.PC]:X}".Debug();
			}
			/*BW.BaseStream.Close();
			BW.Close();*/
		}
	}
}