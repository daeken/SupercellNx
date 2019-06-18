using Common;

namespace Cpu64 {
	public class InterpreterWRegs {
		readonly Interpreter Interpreter;
		public InterpreterWRegs(Interpreter interpreter) => Interpreter = interpreter;

		public uint this[int index] {
			get => (uint) (Interpreter.X[index] & 0xFFFFFFFFU);
			set => Interpreter.X[index] = (Interpreter.X[index] >> 32 << 32) | value;
		}
	}
	
	public partial class Interpreter : BaseCpu {
		public ulong[] X = new ulong[32];
		public readonly InterpreterWRegs W;

		public Interpreter() {
			W = new InterpreterWRegs(this);
		}

		public void StoreMemory(ulong addr, uint value) => $"StoreMemory32(0x{addr:X}, 0x{value:X})".Debug();
		public void StoreMemory(ulong addr, ulong value) => $"StoreMemory64(0x{addr:X}, 0x{value:X})".Debug();

		public T LoadMemory<T>(ulong addr) where T : new() {
			$"Attempting to load {typeof(T)} from 0x{addr:X}".Debug();
			return new T();
		}
	}
}