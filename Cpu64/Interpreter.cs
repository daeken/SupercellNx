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
		public ulong NZCV;
		public ulong PC, SP;

		public Interpreter() {
			W = new InterpreterWRegs(this);
		}

		void StoreMemory(ulong addr, uint value) => $"StoreMemory32(0x{addr:X}, 0x{value:X})".Debug();
		void StoreMemory(ulong addr, ulong value) => $"StoreMemory64(0x{addr:X}, 0x{value:X})".Debug();

		T LoadMemory<T>(ulong addr) where T : new() {
			$"Attempting to load {typeof(T)} from 0x{addr:X}".Debug();
			return new T();
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
				var n = result >> 31;
				var z = result == 0 ? 1U : 0;
				var c = result == usum ? 1U : 0;
				var v = result == ssum ? 1U : 0;
				NZCV = (n << 31) | (z << 30) | (c << 29) | (v << 28);
				return usum;
			}
		}

		ulong AddWithCarrySetNzcv(ulong operand1, ulong operand2, uint carryIn) {
			unchecked {
				var usum = operand1 + operand2 + carryIn;
				var ssum = (long) operand1 + (long) operand2 + carryIn;
				var result = usum & 0x7FFFFFFFU;
				var n = result >> 31;
				var z = result == 0 ? 1U : 0;
				var c = result == usum ? 1U : 0;
				var v = (long) result == ssum ? 1U : 0;
				NZCV = (n << 31) | (z << 30) | (c << 29) | (v << 28);
				return usum;
			}
		}
	}
}