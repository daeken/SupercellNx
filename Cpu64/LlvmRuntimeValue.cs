using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using LLVMSharp;
using UltimateOrb;

namespace Cpu64 {
	public class LlvmRuntimeValue<T> {
		readonly Func<LLVMValueRef> Generate;
		public static LlvmRecompiler Recompiler => LlvmRecompiler.Instance;
		public static LLVMBuilderRef Builder => LlvmRecompiler.Builder;

		public LlvmRuntimeValue(Func<LLVMValueRef> generate) => Generate = generate;

		public static bool IsSigned<IT>() {
			var t = typeof(IT);
			return t == typeof(sbyte) || t == typeof(short) || t == typeof(int) || t == typeof(long) || t == typeof(float) || t == typeof(double);
		}
		public static bool IsInt<IT>() => typeof(IT) != typeof(float) && typeof(IT) != typeof(double);
		
		public LLVMValueRef Emit() {
			var value = Generate();
			Recompiler.Emitted();
			return value;
		}
		public LLVMValueRef EmitThen(Func<LLVMValueRef, LLVMValueRef> next) => next(Generate());
		public static implicit operator LLVMValueRef(LlvmRuntimeValue<T> value) => value.Emit();

		public static LlvmRuntimeValue<T> operator +(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildAdd(LlvmRecompiler.Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator -(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildSub(LlvmRecompiler.Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator *(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildMul(LlvmRecompiler.Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator /(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) => IsSigned<T>()
			? new LlvmRuntimeValue<T>(() => LLVM.BuildSDiv(Builder, a, b, ""))
			: new LlvmRuntimeValue<T>(() => LLVM.BuildUDiv(Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator %(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			throw new NotImplementedException();

		public LlvmRuntimeValue<T> Sqrt() => throw new NotImplementedException();

		public static LlvmRuntimeValue<T> operator &(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildAnd(Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator |(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildOr(Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator ^(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildXor(Builder, a, b, ""));

		public static LlvmRuntimeValue<T> operator ~(LlvmRuntimeValue<T> v) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildNot(Builder, v, ""));

		public static LlvmRuntimeValue<T> operator -(LlvmRuntimeValue<T> v) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildNeg(Builder, v, ""));

		public static LlvmRuntimeValue<uint> operator !(LlvmRuntimeValue<T> v) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildICmp(Builder, LLVMIntPredicate.LLVMIntEQ,  v, Recompiler.Const(0U).Cast<T>(), ""));

		public static LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<T> a, LlvmRuntimeValue<uint> b) =>
			new LlvmRuntimeValue<T>(() => LLVM.BuildShl(Builder, a, b.Cast<T>(), ""));
		public static LlvmRuntimeValue<T> operator <<(LlvmRuntimeValue<T> a, int b) => b == 0 ? a : ShiftLeft(a, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(int b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(long b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(byte b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(uint b) => b == 0 ? this : ShiftLeft(this, b);
		public LlvmRuntimeValue<T> ShiftLeft(ulong b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<T> b) => ShiftLeft(this, b);
		public LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<uint> b) => ShiftLeft(this, b);
		public LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<ulong> b) => ShiftLeft(this, b);

		public static LlvmRuntimeValue<T> ShiftRight(LlvmRuntimeValue<T> a, LlvmRuntimeValue<uint> b) => IsSigned<T>()
			? new LlvmRuntimeValue<T>(() => LLVM.BuildAShr(Builder, a, b.Cast<T>(), ""))
			: new LlvmRuntimeValue<T>(() => LLVM.BuildLShr(Builder, a, b.Cast<T>(), ""));
		public static LlvmRuntimeValue<T> operator >>(LlvmRuntimeValue<T> a, int b) => b == 0 ? a : ShiftRight(a, (uint) b);
		public LlvmRuntimeValue<T> ShiftRight(int b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftRight(long b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftRight(byte b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftRight(uint b) => b == 0 ? this : ShiftRight(this, b);
		public LlvmRuntimeValue<T> ShiftRight(ulong b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftRight(LlvmRuntimeValue<T> b) => ShiftRight(this, b);
		public LlvmRuntimeValue<T> ShiftRight(LlvmRuntimeValue<uint> b) => ShiftRight(this, b);
		public LlvmRuntimeValue<T> ShiftRight(LlvmRuntimeValue<ulong> b) => ShiftRight(this, b);

		public static LlvmRuntimeValue<byte> operator ==(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => LLVM.BuildICmp(Builder, LLVMIntPredicate.LLVMIntEQ, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => LLVM.BuildFCmp(Builder, LLVMRealPredicate.LLVMRealOEQ, a, b, ""));

		public static LlvmRuntimeValue<byte> operator !=(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => LLVM.BuildICmp(Builder, LLVMIntPredicate.LLVMIntNE, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => LLVM.BuildFCmp(Builder, LLVMRealPredicate.LLVMRealUNE, a, b, ""));

		public static LlvmRuntimeValue<T> operator <(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) => throw new NotImplementedException();
		public static LlvmRuntimeValue<T> operator >(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) => throw new NotImplementedException();
		public static LlvmRuntimeValue<T> operator <=(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) => throw new NotImplementedException();
		public static LlvmRuntimeValue<T> operator >=(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) => throw new NotImplementedException();

		LlvmRuntimeValue<OT> Cast<OT>() {
			if((object) this is LlvmRuntimeValue<OT> v) return v;
			Debug.Assert(typeof(T) != typeof(OT));
			var isize = Marshal.SizeOf<T>();
			var osize = Marshal.SizeOf<OT>();
			var ot = typeof(OT).ToLLVMType();
			if(typeof(T) == typeof(bool))
				return new LlvmRuntimeValue<OT>(() => LLVM.BuildZExt(Builder, this, ot, ""));
			return new LlvmRuntimeValue<OT>(() => {
				if(isize == osize) return LLVM.BuildBitCast(Builder, this, ot, "");
				if(isize > osize) return LLVM.BuildTrunc(Builder, this, ot, "");
				if(IsSigned<OT>()) return LLVM.BuildSExt(Builder, this, ot, "");
				return LLVM.BuildZExt(Builder, this, ot, "");
			});
		}

		public static implicit operator LlvmRuntimeValue<sbyte>(LlvmRuntimeValue<T> value) => value.Cast<sbyte>();
		public static implicit operator LlvmRuntimeValue<byte>(LlvmRuntimeValue<T> value) => value.Cast<byte>();
		public static implicit operator LlvmRuntimeValue<short>(LlvmRuntimeValue<T> value) => value.Cast<short>();
		public static implicit operator LlvmRuntimeValue<ushort>(LlvmRuntimeValue<T> value) => value.Cast<ushort>();
		public static implicit operator LlvmRuntimeValue<int>(LlvmRuntimeValue<T> value) => value.Cast<int>();
		public static implicit operator LlvmRuntimeValue<uint>(LlvmRuntimeValue<T> value) => value.Cast<uint>();
		public static implicit operator LlvmRuntimeValue<long>(LlvmRuntimeValue<T> value) => value.Cast<long>();
		public static implicit operator LlvmRuntimeValue<ulong>(LlvmRuntimeValue<T> value) => value.Cast<ulong>();
		public static implicit operator LlvmRuntimeValue<UInt128>(LlvmRuntimeValue<T> value) => value.Cast<UInt128>();
		public static implicit operator LlvmRuntimeValue<Int128>(LlvmRuntimeValue<T> value) => value.Cast<Int128>();
		
		public static implicit operator LlvmRuntimeValue<float>(LlvmRuntimeValue<T> value) => value is LlvmRuntimeValue<float> v ? v
			: new LlvmRuntimeValue<float>(() => throw new NotImplementedException());
		public static implicit operator LlvmRuntimeValue<double>(LlvmRuntimeValue<T> value) => value is LlvmRuntimeValue<double> v ? v
			: new LlvmRuntimeValue<double>(() => throw new NotImplementedException());
		public static implicit operator LlvmRuntimeValue<Vector128<double>>(LlvmRuntimeValue<T> value) => value is LlvmRuntimeValue<Vector128<double>> v ? v
			: new LlvmRuntimeValue<Vector128<double>>(() => throw new NotImplementedException());
		public static implicit operator LlvmRuntimeValue<Vector128<float>>(LlvmRuntimeValue<T> value) => value is LlvmRuntimeValue<Vector128<float>> v ? v
			: new LlvmRuntimeValue<Vector128<float>>(() => throw new NotImplementedException());

		public LlvmRuntimeValue<T> Store() {
			var value = Emit();
			return new LlvmRuntimeValue<T>(() => value);
		}

		public LlvmRuntimeValue<OutT> Bitcast<OutT>() {
			var iv = Activator.CreateInstance<T>();
			var ov = Activator.CreateInstance<OutT>();
			switch(iv) {
				case uint _:
					switch(ov) {
						case float _: return new LlvmRuntimeValue<OutT>(() => throw new NotImplementedException());
						default: throw new NotImplementedException();
					}
				case ulong _:
					switch(ov) {
						case double _: return new LlvmRuntimeValue<OutT>(() => throw new NotImplementedException());
						default: throw new NotImplementedException();
					}
				case float _:
					switch(ov) {
						case uint _: return new LlvmRuntimeValue<OutT>(() => throw new NotImplementedException());
						case int _: return new LlvmRuntimeValue<OutT>(() => throw new NotImplementedException());
						default: throw new NotImplementedException();
					}
				case double _:
					switch(ov) {
						case ulong _: return new LlvmRuntimeValue<OutT>(() => throw new NotImplementedException());
						case long _: return new LlvmRuntimeValue<OutT>(() => throw new NotImplementedException());
						default: throw new NotImplementedException();
					}
				default: throw new NotImplementedException();
			}
		}

		public static implicit operator LlvmRuntimeValue<T>(T value) => Recompiler.Const(value);

		public LlvmRuntimeValue<Vector128<float>> CreateVector() =>
			new LlvmRuntimeValue<Vector128<float>>(() => {
				var count = 16U / (uint) Marshal.SizeOf<T>();
				var vtype = LLVMTypeRef.VectorType(typeof(T).ToLLVMType(), count);
				var value = LLVM.GetUndef(vtype);
				for(var i = 0U; i < count; ++i)
					value = LLVM.BuildInsertElement(Builder, value, this, Recompiler.Const(i), "");
				return typeof(T) == typeof(float)
					? value
					: LLVM.BuildBitCast(Builder, value, LLVMTypeRef.VectorType(typeof(float).ToLLVMType(), 4), "");
			});
		
		public LlvmRuntimeValue<ElementT> GetElement<ElementT>(int element) => throw new NotImplementedException();
		public LlvmRuntimeValue<Vector128<VT>> AsVector<VT>() where VT : struct => throw new NotImplementedException();

		public LlvmRuntimeValue<T> Insert<ElementT>(uint index, LlvmRuntimeValue<ElementT> value) =>
			new LlvmRuntimeValue<T>(() => throw new NotImplementedException());

		public LlvmRuntimeValue<ElementT> Element<ElementT>(uint index) =>
			new LlvmRuntimeValue<ElementT>(() => throw new NotImplementedException());

		public LlvmRuntimeValue<byte> IsNaN() => throw new NotImplementedException();

		public override bool Equals(object obj) => throw new NotImplementedException();
		public override int GetHashCode() => throw new NotImplementedException();
	}

	public class LlvmRuntimePointer<T> {
		readonly LlvmRuntimeValue<ulong> Address;

		public LlvmRuntimeValue<T> Value {
			get => new LlvmRuntimeValue<T>(() => LLVM.BuildLoad(LlvmRecompiler.Builder, Address, ""));
			set => LLVM.BuildStore(LlvmRecompiler.Builder, value, Address);
		}

		public LlvmRuntimePointer(LlvmRuntimeValue<ulong> address) => Address =
			new LlvmRuntimeValue<ulong>(() => LLVM.BuildIntToPtr(LlvmRecompiler.Builder, address,
				LLVMTypeRef.PointerType(typeof(T).ToLLVMType(), 0), ""));

		public static implicit operator LlvmRuntimeValue<T>(LlvmRuntimePointer<T> value) => value.Value;
		public static implicit operator LlvmRuntimePointer<T>(LlvmRuntimeValue<ulong> address) => new LlvmRuntimePointer<T>(address);

		public LLVMValueRef Emit() => throw new NotImplementedException();
	}
}