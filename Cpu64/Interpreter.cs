using System;
using System.Collections.Generic;
using Common;

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

		public override void Run(ulong pc, ulong sp, bool one = false) {
			PC = pc;
			SP = sp;
			var errors = new List<string>();
			do {
				RunOne();
			} while(!one);
		}

		public unsafe void RunOne() {
			var before = PC;
			var inst = *(uint*) PC;
			var asm = Disassemble(inst, PC);
			if(asm == null) {
				$"Disassembly failed at {PC:X} --- {inst:X8}".Debug();
				Environment.Exit(1);
			}
			//$"{PC:X}: {asm}".Debug();
			Interpret(inst, PC);
			if(before == PC)
				PC += 4;
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