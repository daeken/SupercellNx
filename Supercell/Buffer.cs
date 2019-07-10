using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Supercell {
	public class Buffer<T> : IEnumerable<T> where T : struct {
		public readonly ulong Address;
		public readonly int Size;

		public int Length => Size / Marshal.SizeOf<T>();

		public T Value {
			get => Span[0];
			set => Span[0] = value;
		}

		public T this[int index] {
			get => Span[index];
			set => Span[index] = value;
		}

		public Buffer(ulong address, ulong size) {
			Address = address;
			Size = (int) size;
		}
		
		public Buffer<OtherT> As<OtherT>() where OtherT : struct => new Buffer<OtherT>(Address, (ulong) Size);
		public unsafe Span<T> Span => new Span<T>((void *) Address, Size / Marshal.SizeOf<T>());
		public static implicit operator Span<T>(Buffer<T> buffer) => buffer.Span;
		public static implicit operator T(Buffer<T> buffer) => buffer.Value;
		
		public static Buffer<T> operator+(Buffer<T> buffer, int offset) {
			var esize = Marshal.SizeOf<T>();
			return new Buffer<T>(buffer.Address + (ulong) (esize * offset), (ulong) buffer.Size - (ulong) (esize * offset));
		}
		public static Buffer<T> operator+(Buffer<T> buffer, uint offset) {
			var esize = Marshal.SizeOf<T>();
			return new Buffer<T>(buffer.Address + (ulong) (esize * offset), (ulong) buffer.Size - (ulong) (esize * offset));
		}

		public static unsafe void ScopedSpan(Span<T> span, Action<Buffer<T>> func) {
			fixed(byte* ptr = MemoryMarshal.Cast<T, byte>(span))
				func(new Buffer<T>((ulong) ptr, (ulong) span.Length));
		}

		public IEnumerator<T> GetEnumerator() {
			var count = Size / Marshal.SizeOf<T>();
			for(var i = 0; i < count; ++i)
				yield return this[i];
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}