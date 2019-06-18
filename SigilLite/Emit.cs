using System;
using System.Reflection;
using System.Reflection.Emit;
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

		Emit(TypeBuilder tb, string name, MethodAttributes attr) {
			var returnType = typeof(void);
			Type[] argTypes = null;
			
			var dtype = typeof(DelegateT);
			if(dtype == typeof(Action))
				returnType = typeof(void);
			else if(!dtype.IsGenericType)
				throw new NotSupportedException($"Non-generic, non-Action delegate type for Emit: {typeof(DelegateT)}");
			else if(dtype.GetGenericTypeDefinition().FullName.Split('`')[0] == "System.Action")
				argTypes = dtype.GetGenericArguments();
			else if(dtype.GetGenericTypeDefinition().FullName.Split('`')[0] == "System.Func")
				argTypes = dtype.GetGenericArguments();
			else
				throw new NotSupportedException($"Unknown delegate type for Emit: {typeof(DelegateT)}");

			var mb = tb.DefineMethod(name, attr, returnType, argTypes);
			Ilg = mb.GetILGenerator();
		}

		public void CreateMethod() {}

		Emit<DelegateT> Do(Action func) {
			func();
			return this;
		}

		public Emit<DelegateT> Add() => Do(() => Ilg.Emit(OpCodes.Add));
		public Emit<DelegateT> And() => Do(() => Ilg.Emit(OpCodes.And));

		public Emit<DelegateT> Branch(Label label) => Do(() => Ilg.Emit(OpCodes.Br, label.ILabel));
		public Emit<DelegateT> BranchIfEqual(Label label) => Do(() => Ilg.Emit(OpCodes.Beq, label.ILabel));
		public Emit<DelegateT> BranchIfGreater(Label label) => Do(() => Ilg.Emit(OpCodes.Bgt, label.ILabel));
		public Emit<DelegateT> BranchIfGreaterOrEqual(Label label) => Do(() => Ilg.Emit(OpCodes.Bge, label.ILabel));
		public Emit<DelegateT> BranchIfLess(Label label)  => Do(() => Ilg.Emit(OpCodes.Blt, label.ILabel));
		public Emit<DelegateT> UnsignedBranchIfLess(Label label)  => Do(() => Ilg.Emit(OpCodes.Blt_Un, label.ILabel));
		public Emit<DelegateT> BranchIfLessOrEqual(Label label)  => Do(() => Ilg.Emit(OpCodes.Ble, label.ILabel));
		public Emit<DelegateT> BranchIfTrue(Label label)  => Do(() => Ilg.Emit(OpCodes.Brtrue, label.ILabel));

		public Emit<DelegateT> Call(MethodInfo method) => Do(() => Ilg.EmitCall(OpCodes.Call, method, null));

		public Emit<DelegateT> CompareEqual() => Do(() => Ilg.Emit(OpCodes.Ceq));

		public Emit<DelegateT> Convert<TargetT>() {
			var tt = typeof(TargetT);
			if(tt == typeof(bool)) return Do(() => Ilg.Emit(OpCodes.Conv_I1));
			if(tt == typeof(byte)) return Do(() => Ilg.Emit(OpCodes.Conv_U1));
			if(tt == typeof(sbyte)) return Do(() => Ilg.Emit(OpCodes.Conv_I1));
			if(tt == typeof(ushort)) return Do(() => Ilg.Emit(OpCodes.Conv_U2));
			if(tt == typeof(short)) return Do(() => Ilg.Emit(OpCodes.Conv_I2));
			if(tt == typeof(uint)) return Do(() => Ilg.Emit(OpCodes.Conv_U4));
			if(tt == typeof(int)) return Do(() => Ilg.Emit(OpCodes.Conv_I4));
			if(tt == typeof(ulong)) return Do(() => Ilg.Emit(OpCodes.Conv_U8));
			if(tt == typeof(long)) return Do(() => Ilg.Emit(OpCodes.Conv_I8));
			throw new NotImplementedException($"Conversion to unknown type: {tt}");
		}

		public Label DefineLabel() => new Label(Ilg.DefineLabel());

		public Local DeclareLocal<LocalT>() => new Local(Ilg.DeclareLocal(typeof(LocalT)));

		public Emit<DelegateT> Divide() => Do(() => Ilg.Emit(OpCodes.Div));
		public Emit<DelegateT> UnsignedDivide() => Do(() => Ilg.Emit(OpCodes.Div_Un));
		
		public Emit<DelegateT> Duplicate() => Do(() => Ilg.Emit(OpCodes.Dup));

		public Emit<DelegateT> LoadArgument(int index) {
			if(index > 3)
				Ilg.Emit(OpCodes.Ldarg, index);
			else
				Ilg.Emit(index switch {
					0 => OpCodes.Ldarg_0,
					1 => OpCodes.Ldarg_1,
					2 => OpCodes.Ldarg_2,
					3 => OpCodes.Ldarg_3, 
					_ => OpCodes.Nop // Never hit
				});
			return this;
		}

		public Emit<DelegateT> LoadConstant<ConstT>(ConstT value) {
			try {
				Ilg.Emit(OpCodes.Ldc_I4, (uint) System.Convert.ChangeType(value, typeof(uint)));
			} catch(Exception) {
				Ilg.Emit(OpCodes.Ldc_I4, unchecked((uint) (int) System.Convert.ChangeType(value, typeof(int))));
			}

			return Convert<ConstT>();
		}

		public Emit<DelegateT> LoadElement<ElementT>() {
			var tt = typeof(ElementT);
			if(tt == typeof(byte)) return Do(() => Ilg.Emit(OpCodes.Ldelem_U1));
			if(tt == typeof(sbyte)) return Do(() => Ilg.Emit(OpCodes.Ldelem_I1));
			if(tt == typeof(ushort)) return Do(() => Ilg.Emit(OpCodes.Ldelem_U2));
			if(tt == typeof(short)) return Do(() => Ilg.Emit(OpCodes.Ldelem_I2));
			if(tt == typeof(uint)) return Do(() => Ilg.Emit(OpCodes.Ldelem_U4));
			if(tt == typeof(int)) return Do(() => Ilg.Emit(OpCodes.Ldelem_I4));
			throw new NotImplementedException($"Load element of unknown type: {tt}");
		}

		public Emit<DelegateT> LoadField(FieldInfo field) => Do(() => Ilg.Emit(field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, field));
		
		public Emit<DelegateT> LoadLocal(Local local) => Do(() => Ilg.Emit(OpCodes.Ldloc, local.ILocal.LocalIndex));

		public Emit<DelegateT> MarkLabel(Label label) => Do(() => Ilg.MarkLabel(label.ILabel));

		public Emit<DelegateT> Multiply() => Do(() => Ilg.Emit(OpCodes.Mul));
		
		public Emit<DelegateT> Not() => Do(() => Ilg.Emit(OpCodes.Not));
		
		public Emit<DelegateT> Or() => Do(() => Ilg.Emit(OpCodes.Or));

		public Emit<DelegateT> Remainder() => Do(() => Ilg.Emit(OpCodes.Rem));
		public Emit<DelegateT> UnsignedRemainder() => Do(() => Ilg.Emit(OpCodes.Rem_Un));
		
		public Emit<DelegateT> Return() => Do(() => Ilg.Emit(OpCodes.Ret));

		public Emit<DelegateT> ShiftLeft() => Do(() => Ilg.Emit(OpCodes.Shl));
		
		public Emit<DelegateT> ShiftRight() => Do(() => Ilg.Emit(OpCodes.Shr));
		
		public Emit<DelegateT> StoreElement<ElementT>() {
			var tt = typeof(ElementT);
			if(tt == typeof(byte) || tt == typeof(sbyte)) return Do(() => Ilg.Emit(OpCodes.Stelem_I1));
			if(tt == typeof(ushort) || tt == typeof(short)) return Do(() => Ilg.Emit(OpCodes.Stelem_I2));
			if(tt == typeof(uint) || tt == typeof(int)) return Do(() => Ilg.Emit(OpCodes.Stelem_I4));
			throw new NotImplementedException($"Store element of unknown type: {tt}");
		}
		
		public Emit<DelegateT> StoreField(FieldInfo field) => Do(() => Ilg.Emit(field.IsStatic ? OpCodes.Stsfld : OpCodes.Stfld, field));

		public Emit<DelegateT> StoreLocal(Local local) => Do(() => Ilg.Emit(OpCodes.Stloc, local.ILocal.LocalIndex));
		
		public Emit<DelegateT> Subtract() => Do(() => Ilg.Emit(OpCodes.Sub));
		
		public Emit<DelegateT> UnsignedBranchIfNotEqual(Label label) => Do(() => Ilg.Emit(OpCodes.Bne_Un, label.ILabel));
		
		public Emit<DelegateT> UnsignedShiftRight() => Do(() => Ilg.Emit(OpCodes.Shr_Un));
		
		public Emit<DelegateT> Xor() => Do(() => Ilg.Emit(OpCodes.Xor));
	}
}