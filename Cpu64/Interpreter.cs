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

		uint Shift(uint value, uint shiftType, uint amount) {
			return 0;
		}

		ulong Shift(ulong value, uint shiftType, uint amount) {
			return 0;
		}

		uint AddWithCarrySetNzcv(uint operand1, uint operandb, uint carryIn) {
			return 0;
		}

		ulong AddWithCarrySetNzcv(ulong operand1, ulong operandb, uint carryIn) {
			return 0;
		}
	}
}