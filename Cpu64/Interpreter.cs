using System;
using System.Collections.Generic;
using Common;

namespace Cpu64 {
	public class InterpreterWRegs {
		readonly Interpreter Interpreter;
		public InterpreterWRegs(Interpreter interpreter) => Interpreter = interpreter;

		public unsafe uint this[int index] {
			get => (uint) ((&Interpreter.State->X0)[index] & 0xFFFFFFFFU);
			set => (&Interpreter.State->X0)[index] = value;
		}
	}
	
	public unsafe partial class Interpreter : BaseCpu {
		public readonly InterpreterWRegs W;
		public ulong PC { get => State->PC; set => State->PC = value; }
		public ulong SP { get => State->SP; set => State->SP = value; }

		public Interpreter(IKernel kernel) : base(kernel) {
			W = new InterpreterWRegs(this);
		}

		public override void Run(ulong pc, ulong sp, bool one = false) {
			State->PC = pc;
			State->SP = sp;
			var errors = new List<string>();
			do {
				RunOne();
			} while(!one);
		}

		public unsafe void RunOne() {
			var before = State->PC;
			var inst = *(uint*) State->PC;
			var asm = Disassemble(inst, State->PC);
			if(asm == null)
				LogError($"Disassembly failed at {State->PC:X} --- {inst:X8}");
			//$"{PC:X}: {asm}".Debug();
			Interpret(inst, State->PC);
			if(before == State->PC)
				State->PC += 4;
		}

		void Branch(ulong addr) {
			//$"Branching to 0x{addr:X}".Debug();
			State->PC = addr;
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