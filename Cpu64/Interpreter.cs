using System;
using System.Runtime.Intrinsics;
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
		public ulong[] X = new ulong[32];
		public readonly InterpreterWRegs W;
		public Vector128<float>[] V = new Vector128<float>[32];
		public ulong NZCV;
		public ulong PC, SP;

		public Interpreter() {
			W = new InterpreterWRegs(this);
		}

		void Branch(ulong addr) {
			$"Branching to 0x{addr:X}".Debug();
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

		uint AddWithCarrySetNzcv(uint operand1, uint operand2, uint carryIn) {
			unchecked {
				var usum = operand1 + operand2 + carryIn;
				var ssum = (int) operand1 + (int) operand2 + (int) carryIn;
				var result = usum & 0x7FFFFFFFU;
				var n = result >> 30;
				var z = result == 0 ? 1U : 0;
				var c = result == usum ? 1U : 0;
				var v = (int) (result << 1) >> 1 == ssum ? 0U : 1;
				NZCV = (n << 31) | (z << 30) | (c << 29) | (v << 28);
				return usum;
			}
		}

		ulong AddWithCarrySetNzcv(ulong operand1, ulong operand2, uint carryIn) {
			unchecked {
				var usum = operand1 + operand2 + carryIn;
				var ssum = (long) operand1 + (long) operand2 + carryIn;
				var result = (usum << 1) >> 1;
				var n = result >> 62;
				var z = result == 0 ? 1U : 0;
				var c = result == usum ? 1U : 0;
				var v = (long) (result << 1) >> 1 == ssum ? 0U : 1;
				NZCV = (n << 31) | (z << 30) | (c << 29) | (v << 28);
				return usum;
			}
		}

		void Svc(uint svc) {
			throw new NotImplementedException($"Unknown SVC 0x{svc:X}");
		}
	}
}