using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using Common;
using PrettyPrinter;
#if FULLSIGIL
using Sigil;
using Emitter = Sigil.Emit<Cpu64.BlockFunc>;
#else
using SigilLite;
using Emitter = SigilLite.Emit<Cpu64.BlockFunc>;
#endif
using UltimateOrb;
using JetBrains.Annotations;
using Extensions = Common.Extensions;

namespace Cpu64 {
	public interface RuntimeValue {
		void Emit();
		void EmitThen(Action next);
	}
	
	public class RuntimeValue<T> : RuntimeValue {
		readonly Action Generate;
		static Emitter Ilg => Recompiler.Ilg;

		public RuntimeValue(Action generate) => Generate = generate;

		public bool IsSigned {
			get {
				var t = typeof(T);
				return t == typeof(sbyte) || t == typeof(short) || t == typeof(int) || t == typeof(long) || t == typeof(float) || t == typeof(double);
			}
		}

		public void Emit() => Generate();

		public void EmitThen(Action next) {
			Generate();
			next();
		}

		public static RuntimeValue<T> operator +(RuntimeValue<T> a, RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethod(
						"op_Addition", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(UInt128), typeof(UInt128) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<float>))
					Ilg.Call(typeof(Sse).GetMethod("Add", BindingFlags.Public | BindingFlags.Static));
				else if(typeof(T) == typeof(Vector128<double>))
					Ilg.Call(typeof(Sse2).GetMethod("Add", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<double>), typeof(Vector128<double>) }, new ParameterModifier[0]));
				else
					Ilg.Add();
			})));

		public static RuntimeValue<T> operator -(RuntimeValue<T> a, RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethod(
						"op_Subtraction", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(UInt128), typeof(UInt128) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<float>))
					Ilg.Call(typeof(Sse).GetMethod("Subtract", BindingFlags.Public | BindingFlags.Static));
				else if(typeof(T) == typeof(Vector128<double>))
					Ilg.Call(typeof(Sse2).GetMethod("Subtract", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<double>), typeof(Vector128<double>) }, new ParameterModifier[0]));
				else
					Ilg.Subtract();
			})));

		public static RuntimeValue<T> operator *(RuntimeValue<T> a, RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethod(
						"op_Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(UInt128), typeof(UInt128) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Int128))
					Ilg.Call(typeof(Int128).GetMethod(
						"op_Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Int128), typeof(Int128) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<float>))
					Ilg.Call(typeof(Sse).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static));
				else if(typeof(T) == typeof(Vector128<double>))
					Ilg.Call(typeof(Sse2).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<double>), typeof(Vector128<double>) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<byte>))
					Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<byte>), typeof(Vector128<byte>) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<ushort>))
					Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<ushort>), typeof(Vector128<ushort>) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<uint>))
					Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<uint>), typeof(Vector128<uint>) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<ulong>))
					Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<ulong>), typeof(Vector128<ulong>) }, new ParameterModifier[0]));
				else
					Ilg.Multiply();
			})));

		public static RuntimeValue<T> operator *(RuntimeValue<T> a, RuntimeValue<byte> b) =>
			typeof(T) == typeof(byte)
				? a * (RuntimeValue<T>) (object) b
				: new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
					Debug.Assert(typeof(T) == typeof(Vector128<byte>));
					Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<byte>), typeof(byte) }, new ParameterModifier[0]));
				})));
		public static RuntimeValue<T> operator *(RuntimeValue<T> a, RuntimeValue<ushort> b) =>
			typeof(T) == typeof(ushort)
				? a * (RuntimeValue<T>) (object) b
				: new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				Debug.Assert(typeof(T) == typeof(Vector128<ushort>));
				Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
					new[] { typeof(Vector128<ushort>), typeof(ushort) }, new ParameterModifier[0]));
			})));
		public static RuntimeValue<T> operator *(RuntimeValue<T> a, RuntimeValue<uint> b) =>
			typeof(T) == typeof(uint)
				? a * (RuntimeValue<T>) (object) b
				: new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				Debug.Assert(typeof(T) == typeof(Vector128<uint>));
				Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
					new[] { typeof(Vector128<uint>), typeof(uint) }, new ParameterModifier[0]));
			})));

		public static RuntimeValue<T> operator *(RuntimeValue<T> a, RuntimeValue<ulong> b) =>
			typeof(T) == typeof(ulong)
				? a * (RuntimeValue<T>) (object) b
				: new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
					Debug.Assert(typeof(T) == typeof(Vector128<ulong>));
					Ilg.Call(typeof(Extensions).GetMethod("Multiply", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<ulong>), typeof(ulong) }, new ParameterModifier[0]));
				})));

		public static RuntimeValue<T> operator /(RuntimeValue<T> a, RuntimeValue<T> b) => 
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethod(
						"op_Division", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(UInt128), typeof(UInt128) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Int128))
					Ilg.Call(typeof(Int128).GetMethod(
						"op_Division", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Int128), typeof(Int128) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Vector128<float>))
					Ilg.Call(typeof(Sse).GetMethod("Divide", BindingFlags.Public | BindingFlags.Static));
				else if(typeof(T) == typeof(Vector128<double>))
					Ilg.Call(typeof(Sse2).GetMethod("Divide", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Vector128<double>), typeof(Vector128<double>) }, new ParameterModifier[0]));
				else if(a.IsSigned || b.IsSigned)
					Ilg.Divide();
				else
					Ilg.UnsignedDivide();
			})));

		public static RuntimeValue<T> operator %(RuntimeValue<T> a, RuntimeValue<T> b) => a.IsSigned || b.IsSigned
			? new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => Ilg.Remainder())))
			: new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => Ilg.UnsignedRemainder())));

		public RuntimeValue<T> Abs() => new RuntimeValue<T>(() => EmitThen(() => {
			if(typeof(T) == typeof(float))
				Ilg.Call(typeof(MathF).GetMethod("Abs", BindingFlags.Public | BindingFlags.Static));
			else if(typeof(T) == typeof(double))
				Ilg.Call(typeof(Math).GetMethod("Abs", BindingFlags.Public | BindingFlags.Static));
			else
				throw new NotImplementedException();
		}));

		public RuntimeValue<T> Sqrt() {
			switch(this) {
				case RuntimeValue<ushort> v: throw new NotImplementedException();
				case RuntimeValue<float> v: return new RuntimeValue<T>(() => {
					this.Emit();
					Ilg.Call(typeof(MathF).GetMethod("Sqrt"));
				});
				case RuntimeValue<double> v: return new RuntimeValue<T>(() => {
					this.Emit();
					Ilg.Call(typeof(Math).GetMethod("Sqrt"));
				});
				default: throw new NotImplementedException();
			}
		}

		public static RuntimeValue<T> operator &(RuntimeValue<T> a, RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => Ilg.And())));

		public static RuntimeValue<T> operator |(RuntimeValue<T> a, RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => Ilg.Or())));

		public static RuntimeValue<T> operator ^(RuntimeValue<T> a, RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => Ilg.Xor())));

		public static RuntimeValue<T> operator ~(RuntimeValue<T> v) =>
			new RuntimeValue<T>(() => v.EmitThen(() => Ilg.Not()));
		
		public RuntimeValue<T> AndNot(RuntimeValue<T> b) =>
			new RuntimeValue<T>(() => b.EmitThen(() => EmitThen(() => {
				if(typeof(T).IsConstructedGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Vector128<>))
					Recompiler.Ilg.Call(typeof(Sse).GetMethod("AndNot", new[] { typeof(Vector128<float>), typeof(Vector128<float>) }));
				else
					throw new NotImplementedException();
			})));

		public static RuntimeValue<T> operator -(RuntimeValue<T> v) =>
			new RuntimeValue<T>(() => v.EmitThen(() => Ilg.Negate()));

		public static RuntimeValue<uint> operator !(RuntimeValue<T> v) =>
			Recompiler.Ternary(v, (RuntimeValue<uint>) 0U, 1U);

		public static RuntimeValue<T> ShiftLeft(RuntimeValue<T> a, RuntimeValue<uint> b) =>
			new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethod(
						"op_LeftShift", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(UInt128), typeof(int) }, new ParameterModifier[0]));
				else if(typeof(T) == typeof(Int128))
					Ilg.Call(typeof(Int128).GetMethod(
						"op_LeftShift", BindingFlags.Public | BindingFlags.Static, null,
						new[] { typeof(Int128), typeof(int) }, new ParameterModifier[0]));
				else
					Ilg.ShiftLeft();
			})));
		public static RuntimeValue<T> operator <<(RuntimeValue<T> a, int b) => b == 0 ? a : ShiftLeft(a, (uint) b);
		public RuntimeValue<T> ShiftLeft(int b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public RuntimeValue<T> ShiftLeft(long b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public RuntimeValue<T> ShiftLeft(byte b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public RuntimeValue<T> ShiftLeft(uint b) => b == 0 ? this : ShiftLeft(this, b);
		public RuntimeValue<T> ShiftLeft(ulong b) => b == 0 ? this : ShiftLeft(this, (uint) b);
		public RuntimeValue<T> ShiftLeft(RuntimeValue<T> b) => ShiftLeft(this, b);
		public RuntimeValue<T> ShiftLeft(RuntimeValue<uint> b) => ShiftLeft(this, b);
		public RuntimeValue<T> ShiftLeft(RuntimeValue<ulong> b) => ShiftLeft(this, b);

		public static RuntimeValue<T> ShiftRight(RuntimeValue<T> a, RuntimeValue<uint> b) =>
			a.IsSigned || typeof(T) == typeof(UInt128) || typeof(T) == typeof(Int128)
				? new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => {
					if(typeof(T) == typeof(UInt128))
						Ilg.Call(typeof(UInt128).GetMethod(
							"op_RightShift", BindingFlags.Public | BindingFlags.Static, null,
							new[] { typeof(UInt128), typeof(int) }, new ParameterModifier[0]));
					else if(typeof(T) == typeof(Int128))
						Ilg.Call(typeof(Int128).GetMethod(
							"op_RightShift", BindingFlags.Public | BindingFlags.Static, null,
							new[] { typeof(Int128), typeof(int) }, new ParameterModifier[0]));
					else
						Ilg.ShiftRight();
				})))
				: new RuntimeValue<T>(() => a.EmitThen(() => b.EmitThen(() => Ilg.UnsignedShiftRight())));
		public static RuntimeValue<T> operator >>(RuntimeValue<T> a, int b) => b == 0 ? a : ShiftRight(a, (uint) b);
		public RuntimeValue<T> ShiftRight(int b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public RuntimeValue<T> ShiftRight(long b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public RuntimeValue<T> ShiftRight(byte b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public RuntimeValue<T> ShiftRight(uint b) => b == 0 ? this : ShiftRight(this, b);
		public RuntimeValue<T> ShiftRight(ulong b) => b == 0 ? this : ShiftRight(this, (uint) b);
		public RuntimeValue<T> ShiftRight(RuntimeValue<T> b) => ShiftRight(this, b);
		public RuntimeValue<T> ShiftRight(RuntimeValue<uint> b) => ShiftRight(this, b);
		public RuntimeValue<T> ShiftRight(RuntimeValue<ulong> b) => ShiftRight(this, b);

		static RuntimeValue<T> Comp(RuntimeValue<T> a, RuntimeValue<T> b, Action<Label> op) => new RuntimeValue<T>(
			() => {
				Label _if = Ilg.DefineLabel(), end = Ilg.DefineLabel();
				a.Emit();
				b.Emit();
				op(_if);
				Ilg.LoadConstant(0);
				Ilg.Branch(end);
				Ilg.MarkLabel(_if);
				Ilg.LoadConstant(1);
				Ilg.MarkLabel(end);
			});

		public static RuntimeValue<T> operator ==(RuntimeValue<T> a, RuntimeValue<T> b) =>
			Comp(a, b, l => Ilg.BranchIfEqual(l));

		public static RuntimeValue<T> operator !=(RuntimeValue<T> a, RuntimeValue<T> b) =>
			Comp(a, b, l => Ilg.UnsignedBranchIfNotEqual(l));

		public static RuntimeValue<T> operator <(RuntimeValue<T> a, RuntimeValue<T> b) => a.IsSigned || b.IsSigned
			? Comp(a, b, l => Ilg.BranchIfLess(l))
			: Comp(a, b, l => Ilg.UnsignedBranchIfLess(l));

		public static RuntimeValue<T> operator >(RuntimeValue<T> a, RuntimeValue<T> b) => a.IsSigned || b.IsSigned
			? Comp(a, b, l => Ilg.BranchIfGreater(l))
			: Comp(a, b, l => Ilg.UnsignedBranchIfGreater(l));

		public static RuntimeValue<T> operator <=(RuntimeValue<T> a, RuntimeValue<T> b) => a.IsSigned || b.IsSigned
			? Comp(a, b, l => Ilg.BranchIfLessOrEqual(l))
			: Comp(a, b, l => Ilg.UnsignedBranchIfLessOrEqual(l));

		public static RuntimeValue<T> operator >=(RuntimeValue<T> a, RuntimeValue<T> b) => a.IsSigned || b.IsSigned
			? Comp(a, b, l => Ilg.BranchIfGreaterOrEqual(l))
			: Comp(a, b, l => Ilg.UnsignedBranchIfGreaterOrEqual(l));

		public static implicit operator RuntimeValue<byte>(RuntimeValue<T> value) => value is RuntimeValue<byte> v ? v
			: new RuntimeValue<byte>(() => {
				value.Emit();
				Ilg.Convert<byte>();
			});
		public static implicit operator RuntimeValue<ushort>(RuntimeValue<T> value) => value is RuntimeValue<ushort> v ? v
			: new RuntimeValue<ushort>(() => {
				value.Emit();
				Ilg.Convert<ushort>();
			});
		public static implicit operator RuntimeValue<uint>(RuntimeValue<T> value) => value is RuntimeValue<uint> v ? v
			: new RuntimeValue<uint>(() => {
				value.Emit();
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethods(BindingFlags.Public | BindingFlags.Static).First(x =>
						x.ReturnType == typeof(uint)));
				else
					Ilg.Convert<uint>();
			});
		public static implicit operator RuntimeValue<ulong>(RuntimeValue<T> value) => value is RuntimeValue<ulong> v ? v
			: new RuntimeValue<ulong>(() => {
				value.Emit();
				if(typeof(T) == typeof(UInt128))
					Ilg.Call(typeof(UInt128).GetMethods(BindingFlags.Public | BindingFlags.Static).First(x =>
						x.ReturnType == typeof(ulong)));
				else if(typeof(T) == typeof(Int128))
					Ilg.Call(typeof(Int128).GetMethods(BindingFlags.Public | BindingFlags.Static).First(x =>
						x.ReturnType == typeof(ulong)));
				else
					Ilg.Convert<ulong>();
			});
		public static implicit operator RuntimeValue<sbyte>(RuntimeValue<T> value) => value is RuntimeValue<sbyte> v ? v
			: new RuntimeValue<sbyte>(() => {
				value.Emit();
				Ilg.Convert<sbyte>();
			});
		public static implicit operator RuntimeValue<short>(RuntimeValue<T> value) => value is RuntimeValue<short> v ? v
			: new RuntimeValue<short>(() => {
				value.Emit();
				Ilg.Convert<short>();
			});
		public static implicit operator RuntimeValue<int>(RuntimeValue<T> value) => value is RuntimeValue<int> v ? v
			: new RuntimeValue<int>(() => {
				value.Emit();
				Ilg.Convert<int>();
			});

		public static implicit operator RuntimeValue<long>(RuntimeValue<T> value) => value is RuntimeValue<long> v
			? v
			: typeof(T) == typeof(Int128)
				? new RuntimeValue<long>(() => {
					value.Emit();
					Ilg.Call(typeof(Int128).GetMethods(BindingFlags.Public | BindingFlags.Static)
						.First(x => x.Name == "op_Explicit" && x.ReturnType == typeof(long)));
				})
				: new RuntimeValue<long>(() => {
					value.Emit();
					Ilg.Convert<long>();
				});
		public static implicit operator RuntimeValue<UInt128>(RuntimeValue<T> value) => value is RuntimeValue<UInt128> v ? v
			: new RuntimeValue<UInt128>(() => {
				value.Emit();
				Ilg.Call(typeof(UInt128).GetMethod(
					"op_Implicit", BindingFlags.Public | BindingFlags.Static, null, 
					new[] { typeof(T) }, new ParameterModifier[0]));
			});
		public static implicit operator RuntimeValue<Int128>(RuntimeValue<T> value) => value is RuntimeValue<Int128> v ? v
			: new RuntimeValue<Int128>(() => {
				value.Emit();
				Ilg.Call(typeof(Int128).GetMethod(
					"op_Implicit", BindingFlags.Public | BindingFlags.Static, null, 
					new[] { typeof(T) }, new ParameterModifier[0]));
			});
		public static implicit operator RuntimeValue<float>(RuntimeValue<T> value) => value is RuntimeValue<float> v ? v
			: new RuntimeValue<float>(() => {
				value.Emit();
				Ilg.Convert<float>();
			});
		public static implicit operator RuntimeValue<double>(RuntimeValue<T> value) => value is RuntimeValue<double> v ? v
			: new RuntimeValue<double>(() => {
				value.Emit();
				Ilg.Convert<double>();
			});
		public static implicit operator RuntimeValue<Vector128<byte>>(RuntimeValue<T> value) => value is RuntimeValue<Vector128<byte>> v ? v
			: new RuntimeValue<Vector128<byte>>(() => {
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
					.MakeGenericMethod(typeof(T).GetGenericArguments()[0], typeof(byte)));
			});
		public static implicit operator RuntimeValue<Vector128<ushort>>(RuntimeValue<T> value) => value is RuntimeValue<Vector128<ushort>> v ? v
			: new RuntimeValue<Vector128<ushort>>(() => {
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
					.MakeGenericMethod(typeof(T).GetGenericArguments()[0], typeof(ushort)));
			});
		public static implicit operator RuntimeValue<Vector128<uint>>(RuntimeValue<T> value) => value is RuntimeValue<Vector128<uint>> v ? v
			: new RuntimeValue<Vector128<uint>>(() => {
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
					.MakeGenericMethod(typeof(T).GetGenericArguments()[0], typeof(uint)));
			});
		public static implicit operator RuntimeValue<Vector128<ulong>>(RuntimeValue<T> value) => value is RuntimeValue<Vector128<ulong>> v ? v
			: new RuntimeValue<Vector128<ulong>>(() => {
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
					.MakeGenericMethod(typeof(T).GetGenericArguments()[0], typeof(ulong)));
			});
		public static implicit operator RuntimeValue<Vector128<double>>(RuntimeValue<T> value) => value is RuntimeValue<Vector128<double>> v ? v
			: new RuntimeValue<Vector128<double>>(() => {
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
					.MakeGenericMethod(typeof(T).GetGenericArguments()[0], typeof(double)));
			});
		public static implicit operator RuntimeValue<Vector128<float>>(RuntimeValue<T> value) => value is RuntimeValue<Vector128<float>> v ? v
			: new RuntimeValue<Vector128<float>>(() => {
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
					.MakeGenericMethod(typeof(T).GetGenericArguments()[0], typeof(float)));
			});

		public RuntimeValue<T> Store() {
			var local = Ilg.DeclareLocal<T>();
			Emit();
			Ilg.StoreLocal(local);
			return new RuntimeValue<T>(() => Ilg.LoadLocal(local));
		}

		public RuntimeValue<OutT> Bitcast<OutT>() {
			var iv = Activator.CreateInstance<T>();
			var ov = Activator.CreateInstance<OutT>();
			switch(iv) {
				case uint _:
					switch(ov) {
						case float _: return new RuntimeValue<OutT>(() => {
							var local = Ilg.DeclareLocal<uint>();
							Emit();
							Ilg.StoreLocal(local);
							Ilg.LoadLocalAddress(local);
							Ilg.Convert<UIntPtr>();
							Ilg.LoadIndirect<float>();
						});
						default: throw new NotImplementedException();
					}
				case ulong _:
					switch(ov) {
						case double _: return new RuntimeValue<OutT>(() => {
							var local = Ilg.DeclareLocal<ulong>();
							Emit();
							Ilg.StoreLocal(local);
							Ilg.LoadLocalAddress(local);
							Ilg.Convert<UIntPtr>();
							Ilg.LoadIndirect<double>();
						});
						default: throw new NotImplementedException();
					}
				case float _:
					switch(ov) {
						case uint _: return new RuntimeValue<OutT>(() => {
							var local = Ilg.DeclareLocal<float>();
							Emit();
							Ilg.StoreLocal(local);
							Ilg.LoadLocalAddress(local);
							Ilg.Convert<UIntPtr>();
							Ilg.LoadIndirect<uint>();
						});
						case int _: return new RuntimeValue<OutT>(() => {
							var local = Ilg.DeclareLocal<float>();
							Emit();
							Ilg.StoreLocal(local);
							Ilg.LoadLocalAddress(local);
							Ilg.Convert<UIntPtr>();
							Ilg.LoadIndirect<int>();
						});
						default: throw new NotImplementedException();
					}
				case double _:
					switch(ov) {
						case ulong _: return new RuntimeValue<OutT>(() => {
							var local = Ilg.DeclareLocal<double>();
							Emit();
							Ilg.StoreLocal(local);
							Ilg.LoadLocalAddress(local);
							Ilg.Convert<UIntPtr>();
							Ilg.LoadIndirect<ulong>();
						});
						case long _: return new RuntimeValue<OutT>(() => {
							var local = Ilg.DeclareLocal<double>();
							Emit();
							Ilg.StoreLocal(local);
							Ilg.LoadLocalAddress(local);
							Ilg.Convert<UIntPtr>();
							Ilg.LoadIndirect<long>();
						});
						default: throw new NotImplementedException();
					}
				default: throw new NotImplementedException();
			}
		}

		public static implicit operator RuntimeValue<T>(T value) {
			if(value is UInt128 uv128)
				return (RuntimeValue<T>) (object) (RuntimeValue<UInt128>) (RuntimeValue<ulong>) unchecked((ulong) uv128.LoInt64Bits);
			return new RuntimeValue<T>(value switch {
				byte v => (Action) (() => Ilg.LoadConstant(v)),
				ushort v => (Action) (() => Ilg.LoadConstant(v)),
				uint v => (Action) (() => Ilg.LoadConstant(v)),
				ulong v => (Action) (() => Ilg.LoadConstant(v)),
				sbyte v => (Action) (() => Ilg.LoadConstant(v)),
				short v => (Action) (() => Ilg.LoadConstant(v)),
				int v => (Action) (() => Ilg.LoadConstant(v)),
				long v => (Action) (() => Ilg.LoadConstant(v)),
				float v => (Action) (() => Ilg.LoadConstant(v)),
				double v => (Action) (() => Ilg.LoadConstant(v)),
				_ => throw new NotImplementedException($"Unknown literal cast type: {typeof(T).FullName}")
			});
		}

		public RuntimeValue<Vector128<float>> CreateVector() => new RuntimeValue<Vector128<float>>(() => {
			Emit();
			Ilg.Call(typeof(Vector128).GetMethod("Create", new[] { typeof(T) }));
			Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(T), typeof(float)));
		});
		
		public RuntimeValue<Vector128<float>> Frsqrte(int size, int count) {
			Debug.Assert(typeof(T) == typeof(Vector128<float>));
			return Recompiler.Call<Vector128<float>>(nameof(BaseCpu.VectorFrsqrte), this, size, count);
		}
		
		public RuntimeValue<ElementT> GetElement<ElementT>(int element) => throw new NotImplementedException();
		public RuntimeValue<Vector128<VT>> AsVector<VT>() where VT : struct => throw new NotImplementedException();
		
		public RuntimeValue<T> Insert<ElementT>(uint index, RuntimeValue<ElementT> value) {
			if(typeof(ElementT) == typeof(float))
				return new RuntimeValue<T>(() => {
					Emit();
					Ilg.LoadConstant((int) index);
					value.Emit();
					Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float)));
				});
			return new RuntimeValue<T>(() => {
				Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(ElementT)));
				Ilg.LoadConstant((int) index);
				value.Emit();
				Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ElementT)));
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ElementT), typeof(float)));
			});
		}

		public RuntimeValue<ElementT> Element<ElementT>(uint index) {
			Debug.Assert(typeof(T) == typeof(Vector128<float>));
			if(typeof(ElementT) == typeof(float))
				return new RuntimeValue<ElementT>(() => {
					Emit();
					Ilg.LoadConstant((int) index);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ElementT)));
				});
			return new RuntimeValue<ElementT>(() => {
				Emit();
				Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(ElementT)));
				Ilg.LoadConstant((int) index);
				Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ElementT)));
			});
		}
		
		public RuntimeValue<byte> IsNaN() => new RuntimeValue<byte>(() => {
			Emit();
			if(typeof(T) == typeof(float))
				Ilg.Call(typeof(float).GetMethod("IsNaN"));
			else if(typeof(T) == typeof(double))
				Ilg.Call(typeof(double).GetMethod("IsNaN"));
			else
				throw new NotSupportedException();
			Ilg.Convert<byte>();
		});

		public override bool Equals(object obj) => throw new NotImplementedException();
		public override int GetHashCode() => throw new NotImplementedException();
	}

	public class RuntimePointer<T> {
		readonly RuntimeValue<ulong> Address;

		public RuntimeValue<T> Value {
			get => new RuntimeValue<T>(() => {
				Address.Emit();
				Recompiler.Ilg.Convert<IntPtr>();
				if(typeof(T) == typeof(Vector128<float>))
					Recompiler.Ilg.Call(typeof(Sse).GetMethod("LoadVector128", new[] { typeof(float*) }));
				else
					Recompiler.Ilg.LoadIndirect<T>();
			});
			set {
				Address.Emit();
				Recompiler.Ilg.Convert<IntPtr>();
				value.Emit();
				if(typeof(T) == typeof(Vector128<float>))
					Recompiler.Ilg.Call(typeof(Sse).GetMethod("Store", new[] { typeof(float*), typeof(Vector128<float>) }));
				else
					Recompiler.Ilg.StoreIndirect<T>();
			}
		}

		RuntimePointer(RuntimeValue<ulong> address) => Address = address;

		public static implicit operator RuntimeValue<T>(RuntimePointer<T> value) => value.Value;
		public static implicit operator RuntimePointer<T>(RuntimeValue<ulong> address) => new RuntimePointer<T>(address);

		public void Emit() {
			Address.Emit();
			Recompiler.Ilg.Convert<IntPtr>();
		}
	}
}