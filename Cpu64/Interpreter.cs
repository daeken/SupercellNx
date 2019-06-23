using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Common;
using UnicornSharp;

namespace Cpu64 {
	public class InterpreterWRegs {
		readonly Interpreter Interpreter;
		public InterpreterWRegs(Interpreter interpreter) => Interpreter = interpreter;

		public uint this[int index] {
			get => (uint) (Interpreter.X[index] & 0xFFFFFFFFU);
			set => Interpreter.X[index] = value;
		}
	}
	
	public partial class Interpreter : BaseCpu {
		public readonly InterpreterWRegs W;

		public Interpreter(IKernel kernel) : base(kernel) {
			W = new InterpreterWRegs(this);
		}

		public override unsafe void Run(ulong pc, ulong sp) {
			PC = pc;
			SP = sp;
			var uc = new UnicornArm64();
			uc[Arm64Register.PC] = PC;
			uc[Arm64Register.SP] = SP;
			uc[Arm64Register.NZCV] = 0;
			uc[Arm64Register.CPACR_EL1] = 3 << 20;
			foreach(var (addr, size) in Kernel.MemoryRegions) {
				uc.Map(addr, size, MemoryPermission.All, (IntPtr) addr);
				var end = addr + size;
				for(var saddr = addr; saddr < end; saddr += 8)
					uc.MemWrite(saddr, *(ulong*) saddr);
			}

			const bool useUnicorn = true;
			var count = 0;
			var errors = new List<string>();
			while(true) {
				if(PC == 0x7102F29058) {
					$"Hit {count++} -- {X[8]:X}".Debug();
					if(count == 10)
						Environment.Exit(0);
				}
				
				var before = PC;
				var inst = *(uint*) PC;
				var asm = Disassemble(inst, PC);
				if(asm == null) {
					$"Disassembly failed at {PC:X} --- {inst:X8}".Debug();
					break;
				}
				//$"{PC:X}: {asm}".Debug();
				if(useUnicorn) {
					uc[Arm64Register.PC] = PC;
					if(!asm.StartsWith("svc "))
						uc.Start(PC, 0, 0, 1);
				}
				Interpret(inst, PC);
				if(before == PC)
					PC += 4;
				if(useUnicorn) {
					if(asm.StartsWith("svc ")) {
						uc[Arm64Register.PC] = PC;
						uc[Arm64Register.SP] = SP;
						for(var i = 0; i < 31; ++i)
							uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)] = X[i];
						foreach(var (addr, size) in Kernel.MemoryRegions) {
							var end = addr + size;
							for(var saddr = addr; saddr < end; saddr += 8)
								uc.MemWrite(saddr, *(ulong*) saddr);
						}
					}

					if(PC != uc[Arm64Register.PC])
						errors.Add($"PC mismatch! Unicorn 0x{uc[Arm64Register.PC]:X} vs Supercell 0x{PC:X}");
					if(SP != uc[Arm64Register.SP])
						errors.Add($"SP mismatch! Unicorn 0x{uc[Arm64Register.SP]:X} vs Supercell 0x{SP:X}");
					if(NZCV != uc[Arm64Register.NZCV])
						errors.Add($"NZCV mismatch! Unicorn 0x{uc[Arm64Register.NZCV]:X} vs Supercell 0x{NZCV:X}");
					for(var i = 0; i < 31; ++i)
						if(X[i] != uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)])
							errors.Add($"X{i} mismatch! Unicorn 0x{uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)]:X} vs Supercell 0x{X[i]:X}");
					if(errors.Count != 0) {
						$"PC == 0x{PC:X}".Debug();
						foreach(var str in errors)
							str.Debug();
						Environment.Exit(1);
					}
				}
			}
		}

		void Branch(ulong addr) {
			//$"Branching to 0x{addr:X}".Debug();
			PC = addr;
		}

		uint Shift(uint value, uint shiftType, uint _amount) {
			var amount = (int) _amount;
			switch(shiftType) {
				case 0b00: return value << amount;
				case 0b01: return value >> amount;
				case 0b10: return unchecked((uint) ((int) value >> amount));
				default: return (value >> amount) | (value << (32 - amount));
			}
		}

		ulong Shift(ulong value, uint shiftType, uint _amount) {
			var amount = (int) _amount;
			switch(shiftType) {
				case 0b00: return value << amount;
				case 0b01: return value >> amount;
				case 0b10: return unchecked((ulong) ((long) value >> amount));
				default: return (value >> amount) | (value << (64 - amount));
			}
		}
	}
}