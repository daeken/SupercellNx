using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Common;
using PrettyPrinter;

namespace SigilLite {
	public class Label {
		internal readonly System.Reflection.Emit.Label ILabel;

		internal Label(System.Reflection.Emit.Label ilabel) => ILabel = ilabel;
	}

	public class Local {
		internal readonly LocalBuilder ILocal;

		internal Local(LocalBuilder ilocal) => ILocal = ilocal;
	}
	
	public class SigilVerificationException : Exception {}
	
	public class Emit<DelegateT> {
		public static Emit<DelegateT> BuildMethod(TypeBuilder tb, string name, MethodAttributes attr, CallingConventions _) => new Emit<DelegateT>(tb, name, attr);

		readonly ILGenerator Ilg;
		bool LastWasBranch;

		Emit(TypeBuilder tb, string name, MethodAttributes attr) {
			if(!typeof(MulticastDelegate).IsAssignableFrom(typeof(DelegateT)))
				throw new NotSupportedException($"Non-delegate type for Emit: {typeof(DelegateT).Name}");
			
			var mi = typeof(DelegateT).GetMethod("Invoke");
			var mb = tb.DefineMethod(name, attr, mi.ReturnType, mi.GetParameters().Select(x => x.ParameterType).ToArray());
			Ilg = mb.GetILGenerator();
		}

		void GEmit(OpCode opcode) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode);
		}

		void GEmit(OpCode opcode, System.Reflection.Emit.Label label) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, label);
		}

		void GEmit(OpCode opcode, ConstructorInfo ci) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, ci);
		}

		void GEmitCall(OpCode opcode, MethodInfo mi, Type[] types) {
			if(ShouldEmit(opcode))
				Ilg.EmitCall(opcode, mi, types);
		}

		void GEmit(OpCode opcode, FieldInfo fi) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, fi);
		}

		void GEmit(OpCode opcode, Type type) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, type);
		}
		void GEmit(OpCode opcode, string constant) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, constant);
		}
		void GEmit(OpCode opcode, uint constant) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, constant);
		}
		void GEmit(OpCode opcode, int constant) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, constant);
		}
		void GEmit(OpCode opcode, ulong constant) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, unchecked((long) constant));
		}
		void GEmit(OpCode opcode, float constant) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, constant);
		}
		void GEmit(OpCode opcode, double constant) {
			if(ShouldEmit(opcode))
				Ilg.Emit(opcode, constant);
		}

		bool ShouldEmit(OpCode opcode) {
			if(opcode == OpCodes.Br || opcode == OpCodes.Br_S) {
				if(LastWasBranch) {
					LastWasBranch = false;
					return false;
				}
				LastWasBranch = true;
			} else
				LastWasBranch = false;
			return true;
		}

		public void CreateMethod() {}

		Emit<DelegateT> Do(Action func) {
			func();
			return this;
		}

		public Emit<DelegateT> Add() => Do(() => GEmit(OpCodes.Add));
		public Emit<DelegateT> And() => Do(() => GEmit(OpCodes.And));

		public Emit<DelegateT> Branch(Label label) => Do(() => GEmit(OpCodes.Br, label.ILabel));
		public Emit<DelegateT> BranchIfEqual(Label label) => Do(() => GEmit(OpCodes.Beq, label.ILabel));
		public Emit<DelegateT> UnsignedBranchIfGreater(Label label) => Do(() => GEmit(OpCodes.Bgt_Un, label.ILabel));
		public Emit<DelegateT> BranchIfGreater(Label label) => Do(() => GEmit(OpCodes.Bgt, label.ILabel));
		public Emit<DelegateT> UnsignedBranchIfGreaterOrEqual(Label label) => Do(() => GEmit(OpCodes.Bge_Un, label.ILabel));
		public Emit<DelegateT> BranchIfGreaterOrEqual(Label label) => Do(() => GEmit(OpCodes.Bge, label.ILabel));
		public Emit<DelegateT> UnsignedBranchIfLess(Label label)  => Do(() => GEmit(OpCodes.Blt_Un, label.ILabel));
		public Emit<DelegateT> BranchIfLess(Label label)  => Do(() => GEmit(OpCodes.Blt, label.ILabel));
		public Emit<DelegateT> UnsignedBranchIfLessOrEqual(Label label)  => Do(() => GEmit(OpCodes.Ble_Un, label.ILabel));
		public Emit<DelegateT> BranchIfLessOrEqual(Label label)  => Do(() => GEmit(OpCodes.Ble, label.ILabel));
		public Emit<DelegateT> BranchIfTrue(Label label)  => Do(() => GEmit(OpCodes.Brtrue, label.ILabel));

		public Emit<DelegateT> Call(MethodInfo method) => Do(() => GEmitCall(OpCodes.Call, method, null));

		public Emit<DelegateT> CompareEqual() => Do(() => GEmit(OpCodes.Ceq));

		public Emit<DelegateT> Convert<TargetT>() {
			var tt = typeof(TargetT);
			if(tt == typeof(bool)) return Do(() => GEmit(OpCodes.Conv_I1));
			if(tt == typeof(byte)) return Do(() => GEmit(OpCodes.Conv_U1));
			if(tt == typeof(sbyte)) return Do(() => GEmit(OpCodes.Conv_I1));
			if(tt == typeof(ushort)) return Do(() => GEmit(OpCodes.Conv_U2));
			if(tt == typeof(short)) return Do(() => GEmit(OpCodes.Conv_I2));
			if(tt == typeof(uint)) return Do(() => GEmit(OpCodes.Conv_U4));
			if(tt == typeof(int)) return Do(() => GEmit(OpCodes.Conv_I4));
			if(tt == typeof(ulong)) return Do(() => GEmit(OpCodes.Conv_U8));
			if(tt == typeof(long)) return Do(() => GEmit(OpCodes.Conv_I8));
			if(tt == typeof(IntPtr)) return Do(() => GEmit(OpCodes.Conv_I));
			if(tt == typeof(UIntPtr)) return Do(() => GEmit(OpCodes.Conv_U));
			if(tt == typeof(float)) return Do(() => GEmit(OpCodes.Conv_R4));
			if(tt == typeof(double)) return Do(() => GEmit(OpCodes.Conv_R8));
			throw new NotImplementedException($"Conversion to unknown type: {tt}");
		}

		public Label DefineLabel() => new Label(Ilg.DefineLabel());

		public Local DeclareLocal<LocalT>() => new Local(Ilg.DeclareLocal(typeof(LocalT)));

		public Emit<DelegateT> Divide() => Do(() => GEmit(OpCodes.Div));
		public Emit<DelegateT> UnsignedDivide() => Do(() => GEmit(OpCodes.Div_Un));
		
		public Emit<DelegateT> Duplicate() => Do(() => GEmit(OpCodes.Dup));

		public Emit<DelegateT> InitializeObject<ObjT>() => Do(() => GEmit(OpCodes.Initobj, typeof(ObjT)));

		public Emit<DelegateT> LoadArgument(int index) {
			if(index > 3)
				GEmit(OpCodes.Ldarg, index);
			else
				GEmit(index switch {
					0 => OpCodes.Ldarg_0,
					1 => OpCodes.Ldarg_1,
					2 => OpCodes.Ldarg_2,
					3 => OpCodes.Ldarg_3, 
					_ => OpCodes.Nop // Never hit
				});
			return this;
		}

		public Emit<DelegateT> LoadConstant<ConstT>(ConstT value) {
			switch(value) {
				case byte v:
					GEmit(OpCodes.Ldc_I4, v);
					return Convert<byte>();
				case ushort v:
					GEmit(OpCodes.Ldc_I4, v);
					return Convert<ushort>();
				case short v:
					GEmit(OpCodes.Ldc_I4, v);
					return Convert<short>();
				case uint v:
					GEmit(OpCodes.Ldc_I4, v);
					return Convert<uint>();
				case int v:
					GEmit(OpCodes.Ldc_I4, v);
					return this;
				case ulong v:
					GEmit(OpCodes.Ldc_I8, v);
					return this;
				case long v:
					GEmit(OpCodes.Ldc_I8, unchecked((ulong) v));
					return this;
				case float v:
					GEmit(OpCodes.Ldc_R4, v);
					return this;
				case double v:
					GEmit(OpCodes.Ldc_R8, v);
					return this;
				case string v:
					GEmit(OpCodes.Ldstr, v);
					return this;
				default:
					throw new NotImplementedException($"Constant of {typeof(ConstT).Name}");
			}
		}

		public Emit<DelegateT> LoadElement<ElementT>() {
			var tt = typeof(ElementT);
			if(tt == typeof(byte)) return Do(() => GEmit(OpCodes.Ldelem_U1));
			if(tt == typeof(sbyte)) return Do(() => GEmit(OpCodes.Ldelem_I1));
			if(tt == typeof(ushort)) return Do(() => GEmit(OpCodes.Ldelem_U2));
			if(tt == typeof(short)) return Do(() => GEmit(OpCodes.Ldelem_I2));
			if(tt == typeof(uint)) return Do(() => GEmit(OpCodes.Ldelem_U4));
			if(tt == typeof(int)) return Do(() => GEmit(OpCodes.Ldelem_I4));
			if(tt == typeof(ulong)) return Do(() => GEmit(OpCodes.Ldelem_I8));
			if(tt == typeof(long)) return Do(() => GEmit(OpCodes.Ldelem_I8));
			GEmit(OpCodes.Ldelem, tt);
			return this;
		}

		public Emit<DelegateT> LoadIndirect<ElementT>() {
			var tt = typeof(ElementT);
			if(tt == typeof(byte)) return Do(() => GEmit(OpCodes.Ldind_U1));
			if(tt == typeof(sbyte)) return Do(() => GEmit(OpCodes.Ldind_I1));
			if(tt == typeof(ushort)) return Do(() => GEmit(OpCodes.Ldind_U2));
			if(tt == typeof(short)) return Do(() => GEmit(OpCodes.Ldind_I2));
			if(tt == typeof(uint)) return Do(() => GEmit(OpCodes.Ldind_U4));
			if(tt == typeof(int)) return Do(() => GEmit(OpCodes.Ldind_I4));
			if(tt == typeof(ulong)) return Do(() => GEmit(OpCodes.Ldind_I8));
			if(tt == typeof(long)) return Do(() => GEmit(OpCodes.Ldind_I8));
			if(tt == typeof(float)) return Do(() => GEmit(OpCodes.Ldind_R4));
			if(tt == typeof(double)) return Do(() => GEmit(OpCodes.Ldind_R8));
			throw new NotImplementedException($"Load indirect of unknown type: {tt}");
		}

		public Emit<DelegateT> LoadField(FieldInfo field) => Do(() => GEmit(field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, field));
		
		public Emit<DelegateT> LoadLocal(Local local) => Do(() => GEmit(OpCodes.Ldloc, local.ILocal.LocalIndex));
		public Emit<DelegateT> LoadLocalAddress(Local local) => Do(() => GEmit(OpCodes.Ldloca, local.ILocal.LocalIndex));

		public Emit<DelegateT> LoadObject<T>() => Do(() => GEmit(OpCodes.Ldobj, typeof(T)));

		public Emit<DelegateT> MarkLabel(Label label) => Do(() => Ilg.MarkLabel(label.ILabel));

		public Emit<DelegateT> Multiply() => Do(() => GEmit(OpCodes.Mul));
		
		public Emit<DelegateT> Negate() => Do(() => GEmit(OpCodes.Neg));

		public Emit<DelegateT> NewObject<ObjT>() => Do(() => GEmit(OpCodes.Newobj, typeof(ObjT).GetConstructor(new Type[0])));
		
		public Emit<DelegateT> Not() => Do(() => GEmit(OpCodes.Not));
		
		public Emit<DelegateT> Or() => Do(() => GEmit(OpCodes.Or));

		public Emit<DelegateT> Pop() => Do(() => GEmit(OpCodes.Pop));

		public Emit<DelegateT> Remainder() => Do(() => GEmit(OpCodes.Rem));
		public Emit<DelegateT> UnsignedRemainder() => Do(() => GEmit(OpCodes.Rem_Un));
		
		public Emit<DelegateT> Return() => Do(() => GEmit(OpCodes.Ret));

		public Emit<DelegateT> ShiftLeft() => Do(() => GEmit(OpCodes.Shl));
		
		public Emit<DelegateT> ShiftRight() => Do(() => GEmit(OpCodes.Shr));
		
		public Emit<DelegateT> StoreElement<ElementT>() {
			var tt = typeof(ElementT);
			if(tt == typeof(byte) || tt == typeof(sbyte)) return Do(() => GEmit(OpCodes.Stelem_I1));
			if(tt == typeof(ushort) || tt == typeof(short)) return Do(() => GEmit(OpCodes.Stelem_I2));
			if(tt == typeof(uint) || tt == typeof(int)) return Do(() => GEmit(OpCodes.Stelem_I4));
			if(tt == typeof(ulong) || tt == typeof(long)) return Do(() => GEmit(OpCodes.Stelem_I8));
			GEmit(OpCodes.Stelem, tt);
			return this;
		}
		
		public Emit<DelegateT> StoreIndirect<ElementT>() {
			var tt = typeof(ElementT);
			if(tt == typeof(byte) || tt == typeof(sbyte)) return Do(() => GEmit(OpCodes.Stind_I1));
			if(tt == typeof(ushort) || tt == typeof(short)) return Do(() => GEmit(OpCodes.Stind_I2));
			if(tt == typeof(uint) || tt == typeof(int)) return Do(() => GEmit(OpCodes.Stind_I4));
			if(tt == typeof(ulong) || tt == typeof(long)) return Do(() => GEmit(OpCodes.Stind_I8));
			if(tt == typeof(float)) return Do(() => GEmit(OpCodes.Stind_R4));
			if(tt == typeof(double)) return Do(() => GEmit(OpCodes.Stind_R8));
			throw new NotImplementedException($"Store indirect of unknown type: {tt}");
		}
		
		public Emit<DelegateT> StoreField(FieldInfo field) => Do(() => GEmit(field.IsStatic ? OpCodes.Stsfld : OpCodes.Stfld, field));

		public Emit<DelegateT> StoreLocal(Local local) => Do(() => GEmit(OpCodes.Stloc, local.ILocal.LocalIndex));
		
		public Emit<DelegateT> StoreObject<T>() => Do(() => GEmit(OpCodes.Stobj, typeof(T)));

		public Emit<DelegateT> Subtract() => Do(() => GEmit(OpCodes.Sub));
		
		public Emit<DelegateT> UnsignedBranchIfNotEqual(Label label) => Do(() => GEmit(OpCodes.Bne_Un, label.ILabel));
		
		public Emit<DelegateT> UnsignedShiftRight() => Do(() => GEmit(OpCodes.Shr_Un));
		
		public Emit<DelegateT> Xor() => Do(() => GEmit(OpCodes.Xor));
	}
}