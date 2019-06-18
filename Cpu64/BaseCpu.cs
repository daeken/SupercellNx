using System;

namespace Cpu64 {
	public abstract partial class BaseCpu {
		public T SignExt<T>(ulong value, int size) {
			if(typeof(T) == typeof(long))
				return (T) (object) ((value & (1UL << (size - 1))) != 0 ? (long) value - (1L << size) : (long) value);
			throw new NotImplementedException($"Unknown return for SignExt: {typeof(T)}");
		}
	}
}