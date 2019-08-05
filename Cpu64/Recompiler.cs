using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Threading;
using Common;
using UltimateOrb.Utilities;
using UnicornSharp;
#if FULLSIGIL
using Sigil;
using Emitter = Sigil.Emit<Cpu64.BlockFunc>;
using Label = Sigil.Label;
#else
using SigilLite;
using Emitter = SigilLite.Emit<Cpu64.BlockFunc>;
using Label = SigilLite.Label;
#endif

namespace Cpu64 {
	public unsafe partial class Recompiler : BaseCpu {
		class RegisterMap {
			readonly Recompiler Recompiler;
			public RuntimeValue<ulong> this[int reg] {
				get => Recompiler.Field<ulong>($"X{reg}");
				set {
					if(reg == 31) {
						value.Emit();
						Ilg.Pop();
						return;
					}
					Recompiler.Field($"X{reg}", value);
				}
			}
			
			public RegisterMap(Recompiler recompiler) => Recompiler = recompiler;
		}

		class VectorMap {
			readonly Recompiler Recompiler;
			public RuntimeValue<Vector128<float>> this[int reg] {
				get => Recompiler.Field<Vector128<float>>($"V{reg}");
				set => Recompiler.Field($"V{reg}", value);
			}
			
			public VectorMap(Recompiler recompiler) => Recompiler = recompiler;
		}

		class VectorByteMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<byte> this[int reg] {
				get => new RuntimeValue<float>(() => {
					Recompiler.Field<Vector128<float>>($"V{reg}").Emit();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(byte)));
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(byte)));
				});
				set =>
					Recompiler.Field($"V{reg}", new RuntimeValue<Vector128<float>>(() => {
						var local = Ilg.DeclareLocal<Vector128<byte>>();
						Ilg.LoadLocalAddress(local);
						Ilg.InitializeObject<Vector128<byte>>();
						Ilg.LoadLocal(local);

						Ilg.LoadConstant(0);
						value.Emit();
						Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(byte)));
						Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(byte), typeof(float)));
					}));
			}

			public VectorByteMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		class VectorHalfMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<ushort> this[int reg] {
				get => new RuntimeValue<float>(() => {
					Recompiler.Field<Vector128<float>>($"V{reg}").Emit();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(ushort)));
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ushort)));
				});
				set =>
					Recompiler.Field($"V{reg}", new RuntimeValue<Vector128<float>>(() => {
						var local = Ilg.DeclareLocal<Vector128<ushort>>();
						Ilg.LoadLocalAddress(local);
						Ilg.InitializeObject<Vector128<ushort>>();
						Ilg.LoadLocal(local);

						Ilg.LoadConstant(0);
						value.Emit();
						Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(ushort)));
						Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(ushort), typeof(float)));
					}));
			}

			public VectorHalfMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		class VectorSingleMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<float> this[int reg] {
				get => new RuntimeValue<float>(() => {
					Recompiler.Field<Vector128<float>>($"V{reg}").Emit();
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float)));
				});
				set =>
					Recompiler.Field($"V{reg}", new RuntimeValue<Vector128<float>>(() => {
						var local = Ilg.DeclareLocal<Vector128<float>>();
						Ilg.LoadLocalAddress(local);
						Ilg.InitializeObject<Vector128<float>>();
						Ilg.LoadLocal(local);

						Ilg.LoadConstant(0);
						value.Emit();
						Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(float)));
					}));
			}

			public VectorSingleMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		class VectorDoubleMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<double> this[int reg] {
				get => new RuntimeValue<double>(() => {
					Recompiler.Field<Vector128<float>>($"V{reg}").Emit();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(double)));
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(double)));
				});
				set =>
					Recompiler.Field($"V{reg}", new RuntimeValue<Vector128<float>>(() => {
						var local = Ilg.DeclareLocal<Vector128<double>>();
						Ilg.LoadLocalAddress(local);
						Ilg.InitializeObject<Vector128<double>>();
						Ilg.LoadLocal(local);

						Ilg.LoadConstant(0);
						value.Emit();
						Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(double)));
						Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static)
							.MakeGenericMethod(typeof(double), typeof(float)));
					}));
			}

			public VectorDoubleMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		static RuntimeValue<object> CpuStateRef => new RuntimeValue<object>(() => Ilg.LoadArgument(0));
		static RuntimeValue<object> CpuRef => new RuntimeValue<object>(() => Ilg.LoadArgument(1));

		public RuntimeValue<T> Field<T>(string name) => new RuntimeValue<T>(() =>
			CpuStateRef.EmitThen(() => Ilg.LoadField(typeof(CpuState).GetField(name))));
		public void Field<T>(string name, RuntimeValue<T> value) =>
			CpuStateRef.EmitThen(() => value.EmitThen(() => Ilg.StoreField(typeof(CpuState).GetField(name))));
		
		public RuntimeValue<ulong> FieldAddress(string name) => new RuntimeValue<ulong>(() =>
			CpuStateRef.EmitThen(() => {
				Ilg.LoadConstant((uint) Marshal.OffsetOf<CpuState>(name));
				Ilg.Add();
			}));
		
		readonly RegisterMap XR;
		readonly VectorMap VR;
		readonly VectorByteMap VBR;
		readonly VectorHalfMap VHR;
		readonly VectorSingleMap VSR;
		readonly VectorDoubleMap VDR;
		RuntimeValue<ulong> SPR {
			get => Field<ulong>(nameof(CpuState.SP));
			set => Field(nameof(CpuState.SP), value);
		}

		RuntimeValue<byte> Exclusive8R {
			get => Field<byte>(nameof(CpuState.Exclusive8));
			set => Field(nameof(CpuState.Exclusive8), value);
		}
		RuntimeValue<ushort> Exclusive16R {
			get => Field<ushort>(nameof(CpuState.Exclusive16));
			set => Field(nameof(CpuState.Exclusive16), value);
		}
		RuntimeValue<uint> Exclusive32R {
			get => Field<uint>(nameof(CpuState.Exclusive32));
			set => Field(nameof(CpuState.Exclusive32), value);
		}
		RuntimeValue<ulong> Exclusive64R {
			get => Field<ulong>(nameof(CpuState.Exclusive64));
			set => Field(nameof(CpuState.Exclusive64), value);
		}

		RuntimeValue<ulong> NZCVR {
			get =>
				(Field<ulong>(nameof(CpuState.NZCV_N)) << 31) |
				(Field<ulong>(nameof(CpuState.NZCV_Z)) << 30) |
				(Field<ulong>(nameof(CpuState.NZCV_C)) << 29) |
				(Field<ulong>(nameof(CpuState.NZCV_V)) << 28);
			set {
				NZCV_NR = (value >> 31) & 1;
				NZCV_ZR = (value >> 30) & 1;
				NZCV_CR = (value >> 29) & 1;
				NZCV_VR = (value >> 28) & 1;
			}
		}
		RuntimeValue<ulong> NZCV_NR {
			get => Field<ulong>(nameof(CpuState.NZCV_N));
			set => Field(nameof(CpuState.NZCV_N), value);
		}
		RuntimeValue<ulong> NZCV_ZR {
			get => Field<ulong>(nameof(CpuState.NZCV_Z));
			set => Field(nameof(CpuState.NZCV_Z), value);
		}
		RuntimeValue<ulong> NZCV_CR {
			get => Field<ulong>(nameof(CpuState.NZCV_C));
			set => Field(nameof(CpuState.NZCV_C), value);
		}
		RuntimeValue<ulong> NZCV_VR {
			get => Field<ulong>(nameof(CpuState.NZCV_V));
			set => Field(nameof(CpuState.NZCV_V), value);
		}
		
		TypeBuilder Tb;
		static readonly ThreadLocal<Emitter> TlsIlg = new ThreadLocal<Emitter>();
		public static Emitter Ilg {
			get => TlsIlg.Value;
			set => TlsIlg.Value = value;
		}

		bool Optimizing;
		bool Branched;
		ulong BlockStart, CurPc;
		Dictionary<ulong, Label> BlockLabels;
		Dictionary<string, (FieldBuilder, Block)> CurBlockRefs;

		public Recompiler(IKernel kernel) : base(kernel) {
			XR = new RegisterMap(this);
			VR = new VectorMap(this);
			VBR = new VectorByteMap(this);
			VHR = new VectorHalfMap(this);
			VSR = new VectorSingleMap(this);
			VDR = new VectorDoubleMap(this);
		}

		public override void Run(ulong pc, ulong sp, bool one = false) => throw new NotImplementedException();

		public void Recompile(Block block, Dynarec cpu) {
			//DebugRegs();
			var pc = block.Addr;
			//Log($"Recompiling block at {Kernel.MapAddress(pc)}");
			Optimizing = false;
			BlockStart = pc;
			BlockLabels = new Dictionary<ulong, Label>();
			CurBlockRefs = new Dictionary<string, (FieldBuilder, Block)>();

			var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()),
				AssemblyBuilderAccess.Run);
			var mb = ab.DefineDynamicModule("Block");
			Tb = mb.DefineType("Block");
			var mname = $"Block_{pc:X}";
			Ilg = Emit<BlockFunc>.BuildMethod(Tb, mname,
				MethodAttributes.Static | MethodAttributes.Public, CallingConventions.Standard);

			Branched = false;
			while(!Branched) {
				CurPc = pc;
				var inst = *(uint*) pc;
				var asm = Disassemble(inst, pc);
				if(asm == null)
					cpu.LogError($"Disassembly failed at {cpu.Kernel.MapAddress(pc)} --- {inst:X8}");

				var blabel = BlockLabels[pc] = Ilg.DefineLabel();
				Ilg.MarkLabel(blabel);

				Field<ulong>(nameof(CpuState.PC), pc);
				if(!Recompile(inst, pc))
					throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
				pc += 4;
			}

			try {
				Ilg.Return();
			} catch(SigilVerificationException) { }

			/*if(BlockStart == 0x7200953334) {
				Console.WriteLine(Ilg.Instructions());
				throw new Exception();
			}*/

			Ilg.CreateMethod();
			var type = Tb.CreateType();
			foreach(var (key, value) in CurBlockRefs)
				type.GetField(key).SetValue(null, value.Item2);
			block.Func = type.GetMethod(mname).CreateDelegate<BlockFunc>();
		}
		
		static void LoadConstant(object c) {
			switch(c) {
				case bool v: Ilg.LoadConstant(v); break;
				case byte v: Ilg.LoadConstant(v); break;
				case sbyte v: Ilg.LoadConstant(v); break;
				case ushort v: Ilg.LoadConstant(v); break;
				case short v: Ilg.LoadConstant(v); break;
				case uint v: Ilg.LoadConstant(v); break;
				case int v: Ilg.LoadConstant(v); break;
				case string v: Ilg.LoadConstant(v); break;
				case long v: Ilg.LoadConstant(v); break;
				default: throw new NotImplementedException($"Unknown type for object LoadConstant: {c.GetType()}");
			}
		}

		public static void CallVoid(string methodName, params object[] args) {
			var methods = typeof(BaseCpu)
				.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				.Concat(
					typeof(CpuState).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
					                              BindingFlags.NonPublic));
			var mi = methods.First(m => m.Name == methodName && m.ReturnType == typeof(void) &&
			                            m.GetParameters().Length == args.Length &&
			                            m.GetParameters().Select(x => x.ParameterType)
				                            .Zip(args,
					                            (t, o) => o.GetType() == t ||
					                                      o.GetType() == typeof(RuntimeValue<>).MakeGenericType(t))
				                            .All(x => x));
			if(!mi.IsStatic)
				CpuRef.Emit();
			foreach(var a in args)
				if(a is RuntimeValue v) v.Emit();
				else LoadConstant(a);
			Ilg.Call(mi);
		}

		public static RuntimeValue<T> Call<T>(string methodName, params object[] args) {
			var methods = typeof(BaseCpu)
				.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				.Concat(
					typeof(Dynarec).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
					                              BindingFlags.NonPublic));
			var mi = methods.First(m => m.Name == methodName && m.ReturnType == typeof(T) &&
			                            m.GetParameters().Length == args.Length
			                            && m.GetParameters().Select(x => x.ParameterType)
				                            .Zip(args,
					                            (t, o) => o.GetType() == t ||
					                                      o.GetType() == typeof(RuntimeValue<>).MakeGenericType(t))
				                            .All(x => x));
			return new RuntimeValue<T>(() => {
				if(!mi.IsStatic)
					CpuRef.Emit();
				foreach(var a in args)
					if(a is RuntimeValue v) v.Emit();
					else LoadConstant(a);
				Ilg.Call(mi);
			});
		}

		void WithLink(Action func) {
			XR[30] = CurPc + 4;
			func();
		}
		void Branch(ulong target) {
			Branched = true;
			//Console.WriteLine($"Branch from {CurPc:X} -> {target:X}");
			if(BlockStart <= target && target <= CurPc) {
				//Console.WriteLine("Shortcut");
				Ilg.Branch(BlockLabels[target]);
				return;
			}

			var fname = $"_{target:X8}";
			var block = CacheManager.GetBlock(target);
			if(CurBlockRefs.TryGetValue(fname, out var br)) {
				CpuRef.Emit();
				Ilg.LoadField(br.Item1);
				Ilg.StoreField(typeof(CpuState).GetField(nameof(Dynarec.BranchToBlock)));
			} else {
				var fb = Tb.DefineField(fname, typeof(Block), FieldAttributes.Public | FieldAttributes.Static);
				CurBlockRefs[fname] = (fb, block);
				CpuRef.Emit();
				Ilg.LoadField(fb);
				Ilg.StoreField(typeof(Dynarec).GetField(nameof(Dynarec.BranchToBlock)));
			}
			CpuStateRef.Emit();
			Ilg.LoadConstant(target);
			Ilg.StoreField(typeof(CpuState).GetField(nameof(CpuState.BranchTo)));
		}
		void BranchLinked(ulong target) => WithLink(() => Branch(target));
		
		void BranchRegister(ulong reg) {
			Branched = true;
			CpuStateRef.Emit();
			XR[(int) reg].Emit();
			Ilg.StoreField(typeof(CpuState).GetField(nameof(CpuState.BranchTo)));
		}
		void BranchLinkedRegister(ulong reg) => WithLink(() => BranchRegister(reg));

		Label DefineLabel() => Ilg.DefineLabel();
		void Branch(Label label) {
			try {
				Ilg.Branch(label);
			} catch (SigilVerificationException) {
			}
		}

		void BranchIf(RuntimeValue<int> cond, Label if_label, Label else_label) => cond.EmitThen(() => {
			Ilg.BranchIfTrue(if_label);
			Ilg.Branch(else_label);
		});

		void Label(Label label) => Ilg.MarkLabel(label);
		
		public static RuntimeValue<ValueT> Ternary<CondT, ValueT>(RuntimeValue<CondT> cond, RuntimeValue<ValueT> a, RuntimeValue<ValueT> b) =>
			new RuntimeValue<ValueT>(() => {
				Label _if = Ilg.DefineLabel(), end = Ilg.DefineLabel();
				cond.Emit();
				Ilg.BranchIfTrue(_if);
				Ilg.Nop();
				if((object) b == null)
					CallVoid(nameof(Dynarec.Unsupported));
				else
					b.Emit();
				Ilg.Nop();
				Ilg.Branch(end);
				Ilg.MarkLabel(_if);
				Ilg.Nop();
				if((object) a == null)
					CallVoid(nameof(Dynarec.Unsupported));
				else
					a.Emit();
				Ilg.Nop();
				Ilg.MarkLabel(end);
			});
		
		RuntimeValue<uint> Shift(RuntimeValue<uint> value, uint shiftType, uint _amount) {
			var amount = (int) _amount;
			switch(shiftType) {
				case 0b00: return value.ShiftLeft(amount);
				case 0b01: return value.ShiftRight(amount);
				case 0b10: return ((RuntimeValue<int>) value).ShiftRight(amount);
				default: return value.ShiftRight(amount) | value.ShiftLeft(32 - amount);
			}
		}

		RuntimeValue<ulong> Shift(RuntimeValue<ulong> value, uint shiftType, uint _amount) {
			var amount = (int) _amount;
			switch(shiftType) {
				case 0b00: return value.ShiftLeft(amount);
				case 0b01: return value.ShiftRight(amount);
				case 0b10: return ((RuntimeValue<long>) value).ShiftRight(amount);
				default: return value.ShiftRight(amount) | value.ShiftLeft(63 - amount);
			}
		}

		RuntimeValue<T> SignExtRuntime<T>(RuntimeValue<ulong> value, int size) {
			if(typeof(T) == typeof(int))
				return Call<T>(nameof(Dynarec.SignExtRuntimeInt), value, size);
			if(typeof(T) == typeof(long))
				return Call<T>(nameof(Dynarec.SignExtRuntimeLong), value, size);
			throw new NotSupportedException();
		}
		
		RuntimeValue<uint> CallCountLeadingZeros(RuntimeValue<uint> value) => Call<uint>(nameof(Dynarec.CountLeadingZeros), value);
		RuntimeValue<ulong> CallCountLeadingZeros(RuntimeValue<ulong> value) => Call<ulong>(nameof(Dynarec.CountLeadingZeros), value);
		
		RuntimeValue<uint> CallReverseBits(RuntimeValue<uint> value) => Call<uint>(nameof(Dynarec.ReverseBits), value);
		RuntimeValue<ulong> CallReverseBits(RuntimeValue<ulong> value) => Call<ulong>(nameof(Dynarec.ReverseBits), value);

		RuntimeValue<ulong> CallSR(uint op0, uint op1, uint crn, uint crm, uint op2) => Call<ulong>(nameof(Dynarec.SR), op0, op1, crn, crm, op2);
		void CallSR(uint op0, uint op1, uint crn, uint crm, uint op2, RuntimeValue<ulong> value) => CallVoid(nameof(Dynarec.SR), op0, op1, crn, crm, op2, value);

		void CallSvc(uint svc) => CallVoid(nameof(Svc), svc);

		RuntimeValue<Vector128<float>> CallVectorCountBits(RuntimeValue<Vector128<float>> vec, long elems) =>
			Call<Vector128<float>>(nameof(Dynarec.VectorCountBits), vec, elems);

		RuntimeValue<ulong> CallVectorSumUnsigned(RuntimeValue<Vector128<float>> vec, long esize, long count) =>
			Call<ulong>(nameof(Dynarec.VectorSumUnsigned), vec, esize, count);

		RuntimeValue<Vector128<float>> CallVectorExtract(RuntimeValue<Vector128<float>> a,
			RuntimeValue<Vector128<float>> b, uint q, uint index) =>
			Call<Vector128<float>>(nameof(VectorExtract), a, b, q, index);

		public static void CallCheckPointer(RuntimeValue<ulong> addr) => CallVoid(nameof(Dynarec.CheckPointer), addr);

		RuntimeValue<uint> CallFloatToFixed32(RuntimeValue<float> value, ulong fbits) => Call<uint>(nameof(Dynarec.FloatToFixed32), value, (int) fbits);
		RuntimeValue<uint> CallFloatToFixed32(RuntimeValue<double> value, ulong fbits) => Call<uint>(nameof(Dynarec.FloatToFixed32), value, (int) fbits);
		RuntimeValue<ulong> CallFloatToFixed64(RuntimeValue<float> value, ulong fbits) => Call<ulong>(nameof(Dynarec.FloatToFixed64), value, (int) fbits);
		RuntimeValue<ulong> CallFloatToFixed64(RuntimeValue<double> value, ulong fbits) => Call<ulong>(nameof(Dynarec.FloatToFixed64), value, (int) fbits);

		public static class InterlockedProxy {
			public static int CompareExchange(IntPtr ptr, int value, int comparand) =>
				Interlocked.CompareExchange(ref *(int*) ptr, value, comparand);
			public static long CompareExchange(IntPtr ptr, long value, long comparand) =>
				Interlocked.CompareExchange(ref *(long*) ptr, value, comparand);
			public static float CompareExchange(IntPtr ptr, float value, float comparand) =>
				Interlocked.CompareExchange(ref *(float*) ptr, value, comparand);
			public static double CompareExchange(IntPtr ptr, double value, double comparand) =>
				Interlocked.CompareExchange(ref *(double*) ptr, value, comparand);
		}
		
		RuntimeValue<byte> CallCompareAndSwap<T>(RuntimePointer<T> ptr, RuntimeValue<T> value, RuntimeValue<T> comparand)
			=> new RuntimeValue<byte>(() => {
				Type btype;
				if(typeof(T) == typeof(uint))
					btype = typeof(int);
				else if(typeof(T) == typeof(ulong))
					btype = typeof(long);
				else
					throw new NotSupportedException($"Unknown type for CallCompareAndSwap: {typeof(T).Name}");
				
				ptr.Emit();
				Ilg.Convert<IntPtr>();
				value.Emit();
				if(typeof(T) == typeof(uint))
					Ilg.Convert<int>();
				else if(typeof(T) == typeof(ulong))
					Ilg.Convert<long>();
				comparand.Emit();
				Ilg.Duplicate();
				var local = Ilg.DeclareLocal<T>();
				Ilg.StoreLocal(local);
				if(typeof(T) == typeof(uint))
					Ilg.Convert<int>();
				else if(typeof(T) == typeof(ulong))
					Ilg.Convert<long>();
				Ilg.Call(typeof(InterlockedProxy).GetMethod("CompareExchange", new[] { typeof(IntPtr), btype, btype }));
				if(typeof(T) == typeof(uint))
					Ilg.Convert<uint>();
				else if(typeof(T) == typeof(int))
					Ilg.Convert<int>();
				else if(typeof(T) == typeof(ulong))
					Ilg.Convert<ulong>();
				else if(typeof(T) == typeof(long))
					Ilg.Convert<long>();
				else
					throw new NotSupportedException();
				Ilg.LoadLocal(local);
				var if_ = Ilg.DefineLabel();
				var end = Ilg.DefineLabel();
				Ilg.BranchIfEqual(if_);
				Ilg.LoadConstant(1);
				Ilg.Branch(end);
				Ilg.MarkLabel(if_);
				Ilg.LoadConstant(0);
				Ilg.MarkLabel(end);
			});
	}
}