using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using UltimateOrb;

namespace CorePrecompiler {
	public unsafe class ScirRuntimeValue<T> where T : struct {
		readonly Func<Scir> Generate;
		public static ScirRecompiler Recompiler => ScirRecompiler.Instance;

		public ScirRuntimeValue(Func<Scir> generate) => Generate = generate;

		public Scir Emit() {
			var value = Generate();
			Recompiler.Emitted();
			return value;
		}
		public Scir EmitThen(Func<Scir, Scir> next) => next(Generate());
		public static implicit operator Scir(ScirRuntimeValue<T> value) => value.Emit();
		public static implicit operator ScirRuntimeValue<T>(Scir value) => new ScirRuntimeValue<T>(() => value);

		public static ScirRuntimeValue<T> operator +(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Add, a, b);
		public static ScirRuntimeValue<T> operator -(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Subtract, a, b);
		public static ScirRuntimeValue<T> operator *(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Multiply, a, b);
		public static ScirRuntimeValue<T> operator *(ScirRuntimeValue<T> a, ScirRuntimeValue<ushort> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Multiply, a, b);
		public static ScirRuntimeValue<T> operator *(ScirRuntimeValue<T> a, ScirRuntimeValue<uint> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Multiply, a, b);
		public static ScirRuntimeValue<T> operator /(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Divide, a, b);
		public static ScirRuntimeValue<T> operator %(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.Modulus, a, b);
		
		public ScirRuntimeValue<T> Abs() => new Scir.UnaryOperation(typeof(T), UnaryOp.Abs, this);

		public ScirRuntimeValue<T> Sqrt() => new Scir.UnaryOperation(typeof(T), UnaryOp.Sqrt, this);

		public static ScirRuntimeValue<T> operator &(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.BitwiseAnd, a, b);

		public static ScirRuntimeValue<T> operator |(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.BitwiseOr, a, b);

		public static ScirRuntimeValue<T> operator ^(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			new Scir.BinaryOperation(typeof(T), BinaryOp.BitwiseXor, a, b);

		public ScirRuntimeValue<T> AndNot(ScirRuntimeValue<T> b) => this & ~b;

		public static ScirRuntimeValue<T> operator ~(ScirRuntimeValue<T> v) =>
			new Scir.UnaryOperation(typeof(T), UnaryOp.BitwiseNot, v);

		public static ScirRuntimeValue<T> operator -(ScirRuntimeValue<T> v) =>
			new Scir.UnaryOperation(typeof(T), UnaryOp.Negate, v);

		public static ScirRuntimeValue<uint> operator !(ScirRuntimeValue<T> v) =>
			new Scir.UnaryOperation(typeof(T), UnaryOp.LogicalNot, v);

		public static ScirRuntimeValue<T> ShiftLeft(ScirRuntimeValue<T> a, ScirRuntimeValue<uint> b) =>
			throw new NotImplementedException();
		public static ScirRuntimeValue<T> operator <<(ScirRuntimeValue<T> a, int b) => b == 0 ? a : ShiftLeft(a, (uint) b);
		public ScirRuntimeValue<T> ShiftLeft(int b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public ScirRuntimeValue<T> ShiftLeft(long b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public ScirRuntimeValue<T> ShiftLeft(byte b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public ScirRuntimeValue<T> ShiftLeft(uint b) => b == 0 ? this : ShiftLeft(this, b);
		public ScirRuntimeValue<T> ShiftLeft(ulong b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public ScirRuntimeValue<T> ShiftLeft(ScirRuntimeValue<T> b) => ShiftLeft(this, b);
		public ScirRuntimeValue<T> ShiftLeft(ScirRuntimeValue<uint> b) => ShiftLeft(this, b);
		public ScirRuntimeValue<T> ShiftLeft(ScirRuntimeValue<ulong> b) => ShiftLeft(this, b);

		public static ScirRuntimeValue<T> ShiftRight(ScirRuntimeValue<T> a, ScirRuntimeValue<uint> b) =>
			throw new NotImplementedException();
		public static ScirRuntimeValue<T> operator >>(ScirRuntimeValue<T> a, int b) => b == 0 ? a : ShiftRight(a, (uint) b);
		public ScirRuntimeValue<T> ShiftRight(int b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public ScirRuntimeValue<T> ShiftRight(long b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public ScirRuntimeValue<T> ShiftRight(byte b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public ScirRuntimeValue<T> ShiftRight(uint b) => b == 0 ? this : ShiftRight(this, b);
		public ScirRuntimeValue<T> ShiftRight(ulong b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public ScirRuntimeValue<T> ShiftRight(ScirRuntimeValue<T> b) => ShiftRight(this, b);
		public ScirRuntimeValue<T> ShiftRight(ScirRuntimeValue<uint> b) => ShiftRight(this, b);
		public ScirRuntimeValue<T> ShiftRight(ScirRuntimeValue<ulong> b) => ShiftRight(this, b);

		public static ScirRuntimeValue<byte> operator ==(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			throw new NotImplementedException();

		public static ScirRuntimeValue<byte> operator !=(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			throw new NotImplementedException();

		public static ScirRuntimeValue<byte> operator <(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			throw new NotImplementedException();
		public static ScirRuntimeValue<byte> operator >(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			throw new NotImplementedException();
		public static ScirRuntimeValue<byte> operator <=(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			throw new NotImplementedException();
		public static ScirRuntimeValue<byte> operator >=(ScirRuntimeValue<T> a, ScirRuntimeValue<T> b) =>
			throw new NotImplementedException();
		
		public ScirRuntimeValue<OutT> Cast<OutT>() where OutT : struct {
			if((object) this is ScirRuntimeValue<OutT> v) return v;
			return new Scir.Cast(typeof(OutT), this);
		}

		public static implicit operator ScirRuntimeValue<bool>(ScirRuntimeValue<T> value) => value.Cast<bool>();
		public static implicit operator ScirRuntimeValue<sbyte>(ScirRuntimeValue<T> value) => value.Cast<sbyte>();
		public static implicit operator ScirRuntimeValue<byte>(ScirRuntimeValue<T> value) => value.Cast<byte>();
		public static implicit operator ScirRuntimeValue<short>(ScirRuntimeValue<T> value) => value.Cast<short>();
		public static implicit operator ScirRuntimeValue<ushort>(ScirRuntimeValue<T> value) => value.Cast<ushort>();
		public static implicit operator ScirRuntimeValue<int>(ScirRuntimeValue<T> value) => value.Cast<int>();
		public static implicit operator ScirRuntimeValue<uint>(ScirRuntimeValue<T> value) => value.Cast<uint>();
		public static implicit operator ScirRuntimeValue<long>(ScirRuntimeValue<T> value) => value.Cast<long>();
		public static implicit operator ScirRuntimeValue<ulong>(ScirRuntimeValue<T> value) => value.Cast<ulong>();
		public static implicit operator ScirRuntimeValue<UInt128>(ScirRuntimeValue<T> value) => value.Cast<UInt128>();
		public static implicit operator ScirRuntimeValue<Int128>(ScirRuntimeValue<T> value) => value.Cast<Int128>();
		
		public static implicit operator ScirRuntimeValue<float>(ScirRuntimeValue<T> value) => value.Cast<float>();
		public static implicit operator ScirRuntimeValue<double>(ScirRuntimeValue<T> value) => value.Cast<double>();
		
		public static implicit operator ScirRuntimeValue<Vector128<byte>>(ScirRuntimeValue<T> value) => value.Cast<Vector128<byte>>();
		public static implicit operator ScirRuntimeValue<Vector128<ushort>>(ScirRuntimeValue<T> value) => value.Cast<Vector128<ushort>>();
		public static implicit operator ScirRuntimeValue<Vector128<uint>>(ScirRuntimeValue<T> value) => value.Cast<Vector128<uint>>();
		public static implicit operator ScirRuntimeValue<Vector128<ulong>>(ScirRuntimeValue<T> value) => value.Cast<Vector128<ulong>>();
		public static implicit operator ScirRuntimeValue<Vector128<float>>(ScirRuntimeValue<T> value) => value.Cast<Vector128<float>>();
		public static implicit operator ScirRuntimeValue<Vector128<double>>(ScirRuntimeValue<T> value) => value.Cast<Vector128<double>>();

		public ScirRuntimeValue<T> Store() {
			var value = Emit();
			return new ScirRuntimeValue<T>(() => value);
		}

		public ScirRuntimeValue<OutT> Bitcast<OutT>() where OutT : struct {
			if((object) this is ScirRuntimeValue<OutT> v) return v;
			return new Scir.Bitcast(typeof(OutT), this);
		}

		public static implicit operator ScirRuntimeValue<T>(T value) => throw new NotImplementedException();
		
		public ScirRuntimeValue<Vector128<T>> CreateVector() =>
			throw new NotImplementedException();

		public ScirRuntimeValue<Vector128<float>> Frsqrte(int size, int count) => new ScirRuntimeValue<Vector128<float>>(() => {
			Debug.Assert(typeof(T) == typeof(Vector128<float>));
			throw new NotImplementedException();
		});

		public ScirRuntimeValue<T> Insert<ElementT>(uint index, ScirRuntimeValue<ElementT> value) where ElementT : struct {
			if(!typeof(T).IsConstructedGenericType || typeof(T).GetGenericTypeDefinition() != typeof(Vector128<>))
				throw new NotSupportedException();
			var vet = typeof(T).GetGenericArguments()[0];
			throw new NotImplementedException();
		}

		public ScirRuntimeValue<ElementT> Element<ElementT>(uint index) where ElementT : struct =>
			throw new NotImplementedException();
		
		public ScirRuntimeValue<byte> IsNaN() =>
			throw new NotImplementedException();

		public override bool Equals(object obj) => throw new NotImplementedException();
		public override int GetHashCode() => throw new NotImplementedException();
	}

	public class ScirRuntimePointer<T> where T : struct {
		public readonly ScirRuntimeValue<ulong> Address;
		public readonly bool Safe, Volatile;

		public ScirRuntimeValue<T> Value {
			get => new Scir.Load(typeof(T), Address);
			set => ScirRecompiler.Instance.Stmt(new Scir.Store(typeof(T), Address, value));
		}

		public ScirRuntimePointer(ScirRuntimeValue<ulong> address, bool safe = false, bool @volatile = false) {
			Address = address;
			Safe = safe;
			Volatile = @volatile;
			throw new NotImplementedException();
		}

		public static implicit operator ScirRuntimeValue<T>(ScirRuntimePointer<T> value) => value.Value;
		public static implicit operator ScirRuntimePointer<T>(ScirRuntimeValue<ulong> address) => new ScirRuntimePointer<T>(address);
	}
}