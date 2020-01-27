using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using LLVMSharp;
using UltimateOrb;

namespace Cpu64 {
	public unsafe class LlvmRuntimeValue<T> where T : struct {
		readonly Func<LLVMValueRef> Generate;
		public static LlvmRecompiler Recompiler => LlvmRecompiler.Instance;
		public static LLVMBuilderRef Builder => LlvmRecompiler.Builder;
		public static LLVMTypeRef LlvmType<TT>() => typeof(TT).ToLLVMType();

		public LlvmRuntimeValue(Func<LLVMValueRef> generate) => Generate = generate;

		public static bool IsSigned<IT>() {
			var t = typeof(IT);
			if(t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Vector128<>))
				t = t.GetGenericArguments()[0];
			return t == typeof(sbyte) || t == typeof(short) || t == typeof(int) || t == typeof(long) ||
			       t == typeof(Int128) || t == typeof(float) || t == typeof(double);
		}

		public static bool IsInt<IT>() {
			var t = typeof(IT);
			if(t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Vector128<>))
				t = t.GetGenericArguments()[0];
			return t == typeof(sbyte) || t == typeof(short) || t == typeof(int) || t == typeof(long) ||
			       t == typeof(byte) || t == typeof(ushort) || t == typeof(uint) || t == typeof(ulong) ||
				   t == typeof(Int128) || t == typeof(UInt128);
		}

		public static LlvmRuntimeValue<T> Zero() => Zero<T>();
		public static LlvmRuntimeValue<ZT> Zero<ZT>() where ZT : struct {
			if(typeof(ZT).IsConstructedGenericType && typeof(ZT).GetGenericTypeDefinition() == typeof(Vector128<>))
				return new LlvmRuntimeValue<ZT>(() => {
					var et = typeof(ZT).GetGenericArguments()[0];
					var zero = et == typeof(float) || et == typeof(double)
						? Builder.BuildFPCast(Recompiler.Const(0), et.ToLLVMType(), "")
						: LLVMValueRef.CreateConstInt(et.ToLLVMType(), 0, false);
					return Builder.BuildBitCast(
						LLVMValueRef.CreateConstVector(Enumerable
						                               .Range(0, typeof(ZT).ElementCount()).Select(_ => zero)
						                               .ToArray()),
						LlvmType<ZT>(), "");
				});
			return Recompiler.Const(0).Cast<ZT>();
		}
		
		public LLVMValueRef Emit() {
			var value = Generate();
			Recompiler.Emitted();
			return value;
		}
		public LLVMValueRef EmitThen(Func<LLVMValueRef, LLVMValueRef> next) => next(Generate());
		public static implicit operator LLVMValueRef(LlvmRuntimeValue<T> value) => value.Emit();

		public static LlvmRuntimeValue<T> operator +(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildAdd(a, b, ""))
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildFAdd(a, b, ""));

		public static LlvmRuntimeValue<T> operator -(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildSub(a, b, ""))
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildFSub(a, b, ""));

		public static LlvmRuntimeValue<T> operator *(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildMul(a, b, ""))
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildFMul(a, b, ""));

		public static LlvmRuntimeValue<T> operator *(LlvmRuntimeValue<T> a, LlvmRuntimeValue<byte> b) =>
			typeof(T) == typeof(byte)
				? a * (LlvmRuntimeValue<T>) (object) b
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildMul(a, b.CreateVector(), ""));
		public static LlvmRuntimeValue<T> operator *(LlvmRuntimeValue<T> a, LlvmRuntimeValue<ushort> b) =>
			typeof(T) == typeof(ushort)
				? a * (LlvmRuntimeValue<T>) (object) b
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildMul(a, b.CreateVector(), ""));
		public static LlvmRuntimeValue<T> operator *(LlvmRuntimeValue<T> a, LlvmRuntimeValue<uint> b) =>
			typeof(T) == typeof(uint)
				? a * (LlvmRuntimeValue<T>) (object) b
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildMul(a, b.CreateVector(), ""));
		public static LlvmRuntimeValue<T> operator *(LlvmRuntimeValue<T> a, LlvmRuntimeValue<ulong> b) =>
			typeof(T) == typeof(ulong)
				? a * (LlvmRuntimeValue<T>) (object) b
				: new LlvmRuntimeValue<T>(() => LlvmRecompiler.Builder.BuildMul(a, b.CreateVector(), ""));

		public static LlvmRuntimeValue<T> operator /(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			LlvmRecompiler.Ternary(b.IsZero(), Zero<T>(),
				IsInt<T>()
					?
						IsSigned<T>() ? new LlvmRuntimeValue<T>(() => Builder.BuildSDiv(a, b, ""))
						: new LlvmRuntimeValue<T>(() => Builder.BuildUDiv(a, b, ""))
					: new LlvmRuntimeValue<T>(() => Builder.BuildFDiv(a, b, "")));

		public static LlvmRuntimeValue<T> operator %(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? IsSigned<T>()
					? new LlvmRuntimeValue<T>(() => Builder.BuildSRem(a, b, ""))
					: new LlvmRuntimeValue<T>(() => Builder.BuildURem(a, b, ""))
				: new LlvmRuntimeValue<T>(() => Builder.BuildFRem(a, b, ""));
		
		public LlvmRuntimeValue<T> Abs() => new LlvmRuntimeValue<T>(() => {
			if(IsInt<T>()) throw new NotImplementedException();

			if(typeof(T) == typeof(float)) return Recompiler.Intrinsic<Func<float, float>>("llvm.fabs.f32", this);
			if(typeof(T) == typeof(double)) return Recompiler.Intrinsic<Func<double, double>>("llvm.fabs.f64", this);
			throw new NotImplementedException();
		});

		public LlvmRuntimeValue<T> Sqrt() => new LlvmRuntimeValue<T>(() => {
			if(typeof(T) == typeof(float)) return Recompiler.Intrinsic<Func<float, float>>("sqrtf", this);
			if(typeof(T) == typeof(double)) return Recompiler.Intrinsic<Func<double, double>>("sqrt", this);
			throw new NotImplementedException($"Sqrt on {typeof(T).Name}");
		});

		public static LlvmRuntimeValue<T> operator &(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => Builder.BuildAnd(a, b, ""));

		public static LlvmRuntimeValue<T> operator |(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => Builder.BuildOr(a, b, ""));

		public static LlvmRuntimeValue<T> operator ^(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() => Builder.BuildXor(a, b, ""));

		public LlvmRuntimeValue<T> AndNot(LlvmRuntimeValue<T> b) =>
			new LlvmRuntimeValue<T>(() =>
				Builder.BuildBitCast(
					Builder.BuildAnd(Bitcast<UInt128>(), Builder.BuildNot(b.Bitcast<UInt128>(), ""), ""),
					LlvmType<T>(), ""));

		public static LlvmRuntimeValue<T> operator ~(LlvmRuntimeValue<T> v) =>
			new LlvmRuntimeValue<T>(() => Builder.BuildNot(v, ""));

		public static LlvmRuntimeValue<T> operator -(LlvmRuntimeValue<T> v) =>
			IsInt<T>()
				? new LlvmRuntimeValue<T>(() => Builder.BuildNeg(v, ""))
				: new LlvmRuntimeValue<T>(() => Builder.BuildFNeg(v, ""));

		public static LlvmRuntimeValue<uint> operator !(LlvmRuntimeValue<T> v) =>
			new LlvmRuntimeValue<T>(() => Builder.BuildICmp(LLVMIntPredicate.LLVMIntEQ,  v, Recompiler.Const(0U).Cast<T>(), ""));

		public static LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<T> a, LlvmRuntimeValue<uint> b) =>
			LlvmRecompiler.Ternary((LlvmRuntimeValue<bool>) (b >= (uint) Marshal.SizeOf<T>() * 8), Recompiler.Const(0).Cast<T>(),
				new LlvmRuntimeValue<T>(() => Builder.BuildShl(a, b.Cast<T>(), "")));
		public static LlvmRuntimeValue<T> operator <<(LlvmRuntimeValue<T> a, int b) => b == 0 ? a : ShiftLeft(a, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(int b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(long b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(byte b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(uint b) => b == 0 ? this : ShiftLeft(this, b);
		public LlvmRuntimeValue<T> ShiftLeft(ulong b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<T> b) => ShiftLeft(this, b);
		public LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<uint> b) => ShiftLeft(this, b);
		public LlvmRuntimeValue<T> ShiftLeft(LlvmRuntimeValue<ulong> b) => ShiftLeft(this, b);

		public static LlvmRuntimeValue<T> ShiftRight(LlvmRuntimeValue<T> a, LlvmRuntimeValue<uint> b) =>
			LlvmRecompiler.Ternary((LlvmRuntimeValue<bool>) (b >= (uint) Marshal.SizeOf<T>() * 8), Recompiler.Const(0).Cast<T>(),
				IsSigned<T>()
					? new LlvmRuntimeValue<T>(() => Builder.BuildAShr(a, b.Cast<T>(), ""))
					: new LlvmRuntimeValue<T>(() => Builder.BuildLShr(a, b.Cast<T>(), "")));
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
				? new LlvmRuntimeValue<bool>(() => Builder.BuildICmp(LLVMIntPredicate.LLVMIntEQ, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealOEQ, a, b, ""));

		public static LlvmRuntimeValue<byte> operator !=(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => Builder.BuildICmp(LLVMIntPredicate.LLVMIntNE, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealUNE, a, b, ""));

		public static LlvmRuntimeValue<byte> operator <(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => Builder.BuildICmp(
					IsSigned<T>() ? LLVMIntPredicate.LLVMIntSLT : LLVMIntPredicate.LLVMIntULT, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealOLT, a, b, ""));
		public static LlvmRuntimeValue<byte> operator >(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => Builder.BuildICmp(
					IsSigned<T>() ? LLVMIntPredicate.LLVMIntSGT : LLVMIntPredicate.LLVMIntUGT, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealOGT, a, b, ""));
		public static LlvmRuntimeValue<byte> operator <=(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => Builder.BuildICmp(
					IsSigned<T>() ? LLVMIntPredicate.LLVMIntSLE : LLVMIntPredicate.LLVMIntULE, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealOLE, a, b, ""));
		public static LlvmRuntimeValue<byte> operator >=(LlvmRuntimeValue<T> a, LlvmRuntimeValue<T> b) =>
			IsInt<T>()
				? new LlvmRuntimeValue<bool>(() => Builder.BuildICmp(
					IsSigned<T>() ? LLVMIntPredicate.LLVMIntSGE : LLVMIntPredicate.LLVMIntUGE, a, b, ""))
				: new LlvmRuntimeValue<bool>(() => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealOGE, a, b, ""));
		
		public LlvmRuntimeValue<bool> IsZero() =>
			typeof(T).IsConstructedGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Vector128<>)
				? Bitcast<UInt128>() == Zero<UInt128>()
				: this == Zero<T>();

		public LlvmRuntimeValue<OT> Cast<OT>() where OT : struct {
			if((object) this is LlvmRuntimeValue<OT> v) return v;
			Debug.Assert(typeof(T) != typeof(OT));
			if(typeof(OT).IsConstructedGenericType && typeof(OT).GetGenericTypeDefinition() == typeof(Vector128<>) ||
			   typeof(T).IsConstructedGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Vector128<>))
				return new LlvmRuntimeValue<OT>(() => Builder.BuildBitCast(this, LlvmType<OT>(), ""));
			var isize = Marshal.SizeOf<T>();
			var osize = Marshal.SizeOf<OT>();
			var ot = LlvmType<OT>();
			if(typeof(T) == typeof(bool))
				return new LlvmRuntimeValue<OT>(() => Builder.BuildZExt(this, ot, ""));
			if(typeof(OT) == typeof(bool))
				return new LlvmRuntimeValue<OT>(() => Builder.BuildICmp(LLVMIntPredicate.LLVMIntNE, this, Recompiler.Const(0).Cast<T>(), ""));
			return new LlvmRuntimeValue<OT>(() => {
				if(typeof(OT) == typeof(float) || typeof(OT) == typeof(double)) {
					if(IsInt<T>())
						return IsSigned<T>()
							? Builder.BuildSIToFP(this, ot, "")
							: Builder.BuildUIToFP(this, ot, "");
					return Builder.BuildFPCast(this, ot, "");
				}
				if(typeof(T) == typeof(float) || typeof(T) == typeof(double)) {
					Debug.Assert(IsInt<OT>());
					return IsSigned<OT>()
						? Builder.BuildFPToSI(this, ot, "")
						: Builder.BuildFPToUI(this, ot, "");
				}

				if(isize == osize) return Builder.BuildBitCast(this, ot, "");
				if(isize > osize) return Builder.BuildTrunc(this, ot, "");
				if(IsSigned<OT>()) return Builder.BuildSExt(this, ot, "");
				return Builder.BuildZExt(this, ot, "");
			});
		}

		public static implicit operator LlvmRuntimeValue<bool>(LlvmRuntimeValue<T> value) => value.Cast<bool>();
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
		
		public static implicit operator LlvmRuntimeValue<float>(LlvmRuntimeValue<T> value) => value.Cast<float>();
		public static implicit operator LlvmRuntimeValue<double>(LlvmRuntimeValue<T> value) => value.Cast<double>();
		
		public static implicit operator LlvmRuntimeValue<Vector128<byte>>(LlvmRuntimeValue<T> value) => value.Cast<Vector128<byte>>();
		public static implicit operator LlvmRuntimeValue<Vector128<ushort>>(LlvmRuntimeValue<T> value) => value.Cast<Vector128<ushort>>();
		public static implicit operator LlvmRuntimeValue<Vector128<uint>>(LlvmRuntimeValue<T> value) => value.Cast<Vector128<uint>>();
		public static implicit operator LlvmRuntimeValue<Vector128<ulong>>(LlvmRuntimeValue<T> value) => value.Cast<Vector128<ulong>>();
		public static implicit operator LlvmRuntimeValue<Vector128<float>>(LlvmRuntimeValue<T> value) => value.Cast<Vector128<float>>();
		public static implicit operator LlvmRuntimeValue<Vector128<double>>(LlvmRuntimeValue<T> value) => value.Cast<Vector128<double>>();

		public LlvmRuntimeValue<T> Store() {
			var value = Emit();
			return new LlvmRuntimeValue<T>(() => value);
		}

		public LlvmRuntimeValue<OutT> Bitcast<OutT>() where OutT : struct =>
			new LlvmRuntimeValue<OutT>(() => Builder.BuildBitCast(this, LlvmType<OutT>(), ""));

		public static implicit operator LlvmRuntimeValue<T>(T value) => Recompiler.Const(value);

		public LlvmRuntimeValue<Vector128<T>> CreateVector() =>
			new LlvmRuntimeValue<Vector128<T>>(() => {
				var value = Emit();
				var vec = LLVM.GetUndef(LlvmType<Vector128<T>>());
				for(var i = 0; i < typeof(Vector128<T>).ElementCount(); ++i)
					vec = Builder.BuildInsertElement(vec, value, Recompiler.Const(i), "");
				return vec;
			});
		
		public LlvmRuntimeValue<Vector128<float>> Frsqrte(int size, int count) => new LlvmRuntimeValue<Vector128<float>>(() => {
			Debug.Assert(typeof(T) == typeof(Vector128<float>));
			if(size == 64) {
				var ivec = Cast<Vector128<double>>().Store();
				var vec = LLVM.GetUndef(LlvmType<Vector128<double>>());
				for(var i = 0; i < 2; ++i)
					vec = Builder.BuildInsertElement(vec,
						Recompiler.Const(1.0) / ivec.Element<double>((uint) i).Sqrt(), Recompiler.Const(i), "");
				return vec;
			} else {
				var ivec = Store();
				var vec = LLVM.GetUndef(LlvmType<Vector128<float>>());
				for(var i = 0; i < 4; ++i) {
					if(i < count)
						vec = Builder.BuildInsertElement(vec,
							Recompiler.Const(1.0f) / ivec.Element<float>((uint) i).Sqrt(), Recompiler.Const(i), "");
					else
						vec = Builder.BuildInsertElement(vec, Recompiler.Const(0.0f), Recompiler.Const(i), "");
				}
				return vec;
			}
		});

		public LlvmRuntimeValue<T> Insert<ElementT>(uint index, LlvmRuntimeValue<ElementT> value) where ElementT : struct {
			if(!typeof(T).IsConstructedGenericType || typeof(T).GetGenericTypeDefinition() != typeof(Vector128<>))
				throw new NotSupportedException();
			var vet = typeof(T).GetGenericArguments()[0];
			return new LlvmRuntimeValue<T>(() => {
				var vectorVal = Emit();
				if(vet != typeof(ElementT))
					vectorVal = Builder.BuildBitCast(vectorVal, LlvmType<Vector128<ElementT>>(), "");
				var ret = Builder.BuildInsertElement(vectorVal, value, Recompiler.Const(index), "");
				return vet != typeof(ElementT) ? Builder.BuildBitCast(ret, LlvmType<T>(), "") : ret;
			});
		}

		public LlvmRuntimeValue<ElementT> Element<ElementT>(uint index) where ElementT : struct =>
			new LlvmRuntimeValue<ElementT>(() =>
				Builder.BuildExtractElement(Cast<Vector128<ElementT>>(), Recompiler.Const(index), ""));

		public LlvmRuntimeValue<byte> IsNaN() => new LlvmRuntimeValue<bool>(() =>
			EmitThen(v => Builder.BuildFCmp(LLVMRealPredicate.LLVMRealUNO, v, v, ""))).Cast<byte>();

		public override bool Equals(object obj) => throw new NotImplementedException();
		public override int GetHashCode() => throw new NotImplementedException();
	}

	public class LlvmRuntimePointer<T> where T : struct {
		public static LLVMTypeRef LlvmType<TT>() => typeof(TT).ToLLVMType();
		public readonly LlvmRuntimeValue<ulong> Address, Pointer;
		public readonly bool Safe, Volatile;

		public LlvmRuntimeValue<T> Value {
			get => new LlvmRuntimeValue<T>(() => {
				//if(!Safe) LlvmRecompiler.CallCheckPointer(Address);
				var load = LlvmRecompiler.Builder.BuildLoad(Pointer, "");
				load.Alignment = 1;
				if(Volatile)
					load.Volatile = true;
				return load;
			});
			set {
				//if(!Safe) LlvmRecompiler.CallCheckPointer(Address);
				var inst = LlvmRecompiler.Builder.BuildStore(value, Pointer);
				inst.Alignment = 1;
				if(Volatile)
					inst.Volatile = true;
			}
		}

		public LlvmRuntimePointer(LlvmRuntimeValue<ulong> address, bool safe = false, bool @volatile = false) {
			Address = address;
			Pointer = new LlvmRuntimeValue<ulong>(() => LlvmRecompiler.Builder.BuildIntToPtr(address,
				LLVMTypeRef.CreatePointer(LlvmType<T>(), 0), ""));
			Safe = safe;
			Volatile = @volatile;
		}

		public static implicit operator LlvmRuntimeValue<T>(LlvmRuntimePointer<T> value) => value.Value;
		public static implicit operator LlvmRuntimePointer<T>(LlvmRuntimeValue<ulong> address) => new LlvmRuntimePointer<T>(address);

		public LLVMValueRef Emit() => throw new NotImplementedException();
	}
}