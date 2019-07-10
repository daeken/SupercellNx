using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics;
using System.Threading;
using Common;
using UnicornSharp;
#if FULLSIGIL
using Sigil;
using Emitter = Sigil.Emit<System.Action<Cpu64.Dynarec>>;
using Label = Sigil.Label;
#else
using SigilLite;
using Emitter = SigilLite.Emit<System.Action<Cpu64.Dynarec>>;
using Label = SigilLite.Label;
#endif

namespace Cpu64 {
	public partial class Recompiler : BaseCpu {
		class RegisterMap<T> {
			readonly Recompiler Recompiler;
			readonly string Underlying;
			public RuntimeValue<T> this[int reg] {
				get => new RuntimeValue<T>(() => {
					if(Recompiler.Optimizing && Underlying == "X") {
						Recompiler.RegistersUsed[reg] = true;
						Ilg.LoadLocal(Recompiler.RegisterLocals[reg]);
						return;
					}
					Recompiler.Field<T[]>(Underlying).Emit();
					Ilg.LoadConstant(reg);
					Ilg.LoadElement<T>();
				});
				set {
					if(reg == 31 && Underlying == "X") {
						value.Emit();
						Ilg.Pop();
						return;
					}
					if(Recompiler.Optimizing && Underlying == "X") {
						Recompiler.RegistersUsed[reg] = true;
						value.Emit();
						Ilg.StoreLocal(Recompiler.RegisterLocals[reg]);
						return;
					}

					Recompiler.Field<T[]>(Underlying).Emit();
					Ilg.LoadConstant(reg);
					value.Emit();
					Ilg.StoreElement<T>();
				}
			}
			
			public RegisterMap(Recompiler recompiler, string underlying) {
				Recompiler = recompiler;
				Underlying = underlying;
			}
		}

		class VectorByteMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<byte> this[int reg] {
				get => new RuntimeValue<float>(() => {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(byte)));
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(byte)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);

					var local = Ilg.DeclareLocal<Vector128<byte>>();
					Ilg.LoadLocalAddress(local);
					Ilg.InitializeObject<Vector128<byte>>();
					Ilg.LoadLocal(local);
					
					Ilg.LoadConstant(0);
					value.Emit();
					Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(byte)));
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(byte), typeof(float)));
					Ilg.StoreElement<Vector128<float>>();
				}
			}

			public VectorByteMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		class VectorHalfMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<ushort> this[int reg] {
				get => new RuntimeValue<float>(() => {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(ushort)));
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ushort)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);
					
					var local = Ilg.DeclareLocal<Vector128<ushort>>();
					Ilg.LoadLocalAddress(local);
					Ilg.InitializeObject<Vector128<ushort>>();
					Ilg.LoadLocal(local);
					
					Ilg.LoadConstant(0);
					value.Emit();
					Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ushort)));
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ushort), typeof(float)));
					Ilg.StoreElement<Vector128<float>>();
				}
			}

			public VectorHalfMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		class VectorSingleMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<float> this[int reg] {
				get => new RuntimeValue<float>(() => {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);

					var local = Ilg.DeclareLocal<Vector128<float>>();
					Ilg.LoadLocalAddress(local);
					Ilg.InitializeObject<Vector128<float>>();
					Ilg.LoadLocal(local);

					Ilg.LoadConstant(0);
					value.Emit();
					Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float)));
					Ilg.StoreElement<Vector128<float>>();
				}
			}

			public VectorSingleMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		class VectorDoubleMap {
			readonly Recompiler Recompiler;

			public RuntimeValue<double> this[int reg] {
				get => new RuntimeValue<double>(() => {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(double)));
					Ilg.LoadConstant(0);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(double)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg);
					
					var local = Ilg.DeclareLocal<Vector128<double>>();
					Ilg.LoadLocalAddress(local);
					Ilg.InitializeObject<Vector128<double>>();
					Ilg.LoadLocal(local);
					
					Ilg.LoadConstant(0);
					value.Emit();
					Ilg.Call(typeof(Vector128).GetMethod("WithElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(double)));
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(double), typeof(float)));
					Ilg.StoreElement<Vector128<float>>();
				}
			}

			public VectorDoubleMap(Recompiler recompiler) => Recompiler = recompiler;
		}
		
		static RuntimeValue<object> CpuRef => new RuntimeValue<object>(() => Ilg.LoadArgument(0));

		public RuntimeValue<T> Field<T>(string name) => new RuntimeValue<T>(() =>
			CpuRef.EmitThen(() => Ilg.LoadField(typeof(Dynarec).GetField(name))));
		public void Field<T>(string name, RuntimeValue<T> value) =>
			CpuRef.EmitThen(() => value.EmitThen(() => Ilg.StoreField(typeof(Dynarec).GetField(name))));
		
		readonly RegisterMap<ulong> XR;
		readonly RegisterMap<Vector128<float>> VR;
		readonly VectorByteMap VBR;
		readonly VectorHalfMap VHR;
		readonly VectorSingleMap VSR;
		readonly VectorDoubleMap VDR;
		RuntimeValue<ulong> SPR {
			get => Field<ulong>(nameof(Dynarec.SP));
			set {
				/*var local = Ilg.DeclareLocal<ulong>();
				value.Emit();
				Ilg.StoreLocal(local);
				Ilg.WriteLine($"Setting SP from {PC:X} -- {{0:X}}", local);*/
				Field(nameof(Dynarec.SP), value);
			}
		}

		RuntimeValue<uint> Exclusive32R {
			get => Field<uint>(nameof(Dynarec.Exclusive32));
			set => Field(nameof(Dynarec.Exclusive32), value);
		}
		RuntimeValue<ulong> Exclusive64R {
			get => Field<ulong>(nameof(Dynarec.Exclusive64));
			set => Field(nameof(Dynarec.Exclusive64), value);
		}

		RuntimeValue<ulong> NZCVR {
			get =>
				(Field<ulong>(nameof(Dynarec.NZCV_N)) << 31) |
				(Field<ulong>(nameof(Dynarec.NZCV_Z)) << 30) |
				(Field<ulong>(nameof(Dynarec.NZCV_C)) << 29) |
				(Field<ulong>(nameof(Dynarec.NZCV_V)) << 28);
			set {
				NZCV_NR = (value >> 31) & 1;
				NZCV_ZR = (value >> 30) & 1;
				NZCV_CR = (value >> 29) & 1;
				NZCV_VR = (value >> 28) & 1;
			}
		}
		RuntimeValue<ulong> NZCV_NR {
			get => Field<ulong>(nameof(Dynarec.NZCV_N));
			set => Field(nameof(Dynarec.NZCV_N), value);
		}
		RuntimeValue<ulong> NZCV_ZR {
			get => Field<ulong>(nameof(Dynarec.NZCV_Z));
			set => Field(nameof(Dynarec.NZCV_Z), value);
		}
		RuntimeValue<ulong> NZCV_CR {
			get => Field<ulong>(nameof(Dynarec.NZCV_C));
			set => Field(nameof(Dynarec.NZCV_C), value);
		}
		RuntimeValue<ulong> NZCV_VR {
			get => Field<ulong>(nameof(Dynarec.NZCV_V));
			set => Field(nameof(Dynarec.NZCV_V), value);
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
		Queue<ulong> BlocksNeeded;
		bool[] RegistersUsed;
		Local[] RegisterLocals;
		Label StoreRegistersLabel;

		public Recompiler() : base(null) {
			XR = new RegisterMap<ulong>(this, nameof(Dynarec.X));
			VR = new RegisterMap<Vector128<float>>(this, nameof(Dynarec.V));
			VBR = new VectorByteMap(this);
			VHR = new VectorHalfMap(this);
			VSR = new VectorSingleMap(this);
			VDR = new VectorDoubleMap(this);
		}

		public override void Run(ulong pc, ulong sp, bool one = false) => throw new NotImplementedException();

		public unsafe void Recompile(Block block, Dynarec cpu) {
			//Log($"Recompiling block at {Kernel.MapAddress(pc)}");
			//DebugRegs();
			var pc = block.Addr;
			Optimizing = false;
			BlockStart = pc;
			BlockLabels = new Dictionary<ulong, Label>();
			CurBlockRefs = new Dictionary<string, (FieldBuilder, Block)>();

			var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()),
				AssemblyBuilderAccess.Run);
			var mb = ab.DefineDynamicModule("Block");
			Tb = mb.DefineType("Block");
			var mname = $"Block_{pc:X}";
			Ilg = Emit<Action<Dynarec>>.BuildMethod(Tb, mname,
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

				Field<ulong>(nameof(PC), pc);
				if(!Recompile(inst, pc))
					throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
				pc += 4;
			}

			try {
				Ilg.Return();
			} catch(SigilVerificationException) { }

			//Ilg.Instructions().Debug();
			Ilg.CreateMethod();
			var type = Tb.CreateType();
			foreach(var (key, value) in CurBlockRefs)
				type.GetField(key).SetValue(null, value.Item2);
			block.Func = type.GetMethod(mname).CreateDelegate<Action<Dynarec>>();
		}
		
		public unsafe void RecompileMultiple(Block block) {
			Optimizing = true;
			BlockLabels = new Dictionary<ulong, Label>();
			CurBlockRefs = new Dictionary<string, (FieldBuilder, Block)>();
			BlocksNeeded = new Queue<ulong>();
			
			BlocksNeeded.Enqueue(block.Addr);
			var blockCount = 0;

			var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()),
				AssemblyBuilderAccess.Run);
			var mb = ab.DefineDynamicModule("Block");
			Tb = mb.DefineType("Block");
			var mname = $"Block_{block.Addr:X}_Optimized";
			Ilg = Emit<Action<Dynarec>>.BuildMethod(Tb, mname,
				MethodAttributes.Static | MethodAttributes.Public, CallingConventions.Standard);

			RegistersUsed = new bool[31];
			RegisterLocals = Enumerable.Range(0, 31).Select(_ => Ilg.DeclareLocal<ulong>()).ToArray();

			var preRegisterLoad = Ilg.DefineLabel();
			var postRegisterLoad = Ilg.DefineLabel();
			Ilg.Branch(preRegisterLoad);
			Ilg.MarkLabel(postRegisterLoad);
			StoreRegistersLabel = Ilg.DefineLabel();
			
			var recompiled = new HashSet<ulong>();

			void CompileOneBlock(ulong pc) {
				blockCount++;
				if(recompiled.Contains(pc)) {
					Console.WriteLine($"Early bailout for block {blockCount}");
					return;
				}

				Branched = false;
				while(!Branched) {
					recompiled.Add(pc);
					var inst = *(uint*) pc;
					var asm = Disassemble(inst, pc);
					if(asm == null) {
						Console.WriteLine($"Disassembly failed at 0x{pc:X} (multiple) --- {inst:X8}");
						Environment.Exit(1);
					}

					try {
						Ilg.MarkLabel(BlockLabels.TryGetValue(pc, out var label)
							? label
							: BlockLabels[pc] = Ilg.DefineLabel());
					} catch(Exception) { }

					Field<ulong>(nameof(PC), pc);
					if(!Recompile(inst, pc))
						throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
					pc += 4;
				}
				try {
					Ilg.Return();
				} catch(SigilVerificationException) { }
			}
			
			while(BlocksNeeded.TryDequeue(out var pc))
				CompileOneBlock(pc);

			Ilg.MarkLabel(preRegisterLoad);
			for(var i = 0; i < 31; ++i) {
				if(!RegistersUsed[i]) continue;
				Field<ulong[]>(nameof(Dynarec.X)).Emit();
				Ilg.LoadConstant(i);
				Ilg.LoadElement<ulong>();
				Ilg.StoreLocal(RegisterLocals[i]);
			}
			Ilg.Branch(postRegisterLoad);

			Ilg.MarkLabel(StoreRegistersLabel);
			for(var i = 0; i < 31; ++i) {
				if(!RegistersUsed[i]) continue;
				Field<ulong[]>(nameof(Dynarec.X)).Emit();
				Ilg.LoadConstant(i);
				Ilg.LoadLocal(RegisterLocals[i]);
				Ilg.StoreElement<ulong>();
			}
			Ilg.Return();

			//Ilg.Instructions().Debug();
			Ilg.CreateMethod();
			var type = Tb.CreateType();
			foreach(var (key, value) in CurBlockRefs)
				type.GetField(key).SetValue(null, value.Item2);
			block.Func = type.GetMethod(mname).CreateDelegate<Action<Dynarec>>();
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

		static void CallVoid(string methodName, params object[] args) {
			var methods = typeof(BaseCpu)
				.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				.Concat(
					typeof(Dynarec).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
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

		static RuntimeValue<T> Call<T>(string methodName, params object[] args) {
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

		void Branch(ulong target) {
			Branched = true;
			if(!Optimizing && BlockStart <= target && target <= CurPc) {
				Ilg.Branch(BlockLabels[target]);
				return;
			}
			if(Optimizing) {
				if(!BlockLabels.TryGetValue(target, out var label)) {
					label = BlockLabels[target] = Ilg.DefineLabel();
					BlocksNeeded.Enqueue(target);
				}
				Ilg.Branch(label);
				return;
			}

			var fname = $"_{target:X8}";
			var block = CacheManager.GetBlock(target);
			if(CurBlockRefs.TryGetValue(fname, out var br)) {
				CpuRef.Emit();
				Ilg.LoadField(br.Item1);
				Ilg.StoreField(typeof(Dynarec).GetField(nameof(Dynarec.BranchToBlock)));
			} else {
				var fb = Tb.DefineField(fname, typeof(Block), FieldAttributes.Public | FieldAttributes.Static);
				CurBlockRefs[fname] = (fb, block);
				CpuRef.Emit();
				Ilg.LoadField(fb);
				Ilg.StoreField(typeof(Dynarec).GetField(nameof(Dynarec.BranchToBlock)));
			}
			CpuRef.Emit();
			Ilg.LoadConstant(target);
			Ilg.StoreField(typeof(Dynarec).GetField(nameof(Dynarec.BranchTo)));

		}
		void Branch(RuntimeValue<ulong> addr) {
			Branched = true;
			CpuRef.Emit();
			addr.Emit();
			Ilg.StoreField(typeof(Dynarec).GetField(nameof(Dynarec.BranchTo)));
			if(Optimizing)
				Ilg.Branch(StoreRegistersLabel);
		}

		void Branch(Label label) {
			try {
				Ilg.Branch(label);
			} catch (SigilVerificationException) {
			}
		}

		void BranchIf(RuntimeValue<int> cond, Label label) => cond.EmitThen(() => Ilg.BranchIfTrue(label));

		void Label(Label label) => Ilg.MarkLabel(label);
		
		public static RuntimeValue<ValueT> Ternary<CondT, ValueT>(RuntimeValue<CondT> cond, RuntimeValue<ValueT> a, RuntimeValue<ValueT> b) =>
			new RuntimeValue<ValueT>(() => {
				Label _if = Ilg.DefineLabel(), end = Ilg.DefineLabel();
				cond.Emit();
				Ilg.BranchIfTrue(_if);
				if((object) b == null)
					CallVoid(nameof(Dynarec.Unsupported));
				else
					b.Emit();
				Ilg.Branch(end);
				Ilg.MarkLabel(_if);
				if((object) a == null)
					CallVoid(nameof(Dynarec.Unsupported));
				else
					a.Emit();
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

		RuntimeValue<uint> CallAddWithCarrySetNzcv(RuntimeValue<uint> operand1, RuntimeValue<uint> operand2, RuntimeValue<uint> carryIn) =>
			Call<uint>(nameof(Dynarec.AddWithCarrySetNzcv), operand1, operand2, carryIn);
		RuntimeValue<ulong> CallAddWithCarrySetNzcv(RuntimeValue<ulong> operand1, RuntimeValue<ulong> operand2, RuntimeValue<ulong> carryIn) =>
			Call<ulong>(nameof(Dynarec.AddWithCarrySetNzcv), operand1, operand2, carryIn);

		void CallFloatCompare(RuntimeValue<float> operand1, RuntimeValue<float> operand2) =>
			CallVoid(nameof(Dynarec.FloatCompare), operand1, operand2);
		void CallFloatCompare(RuntimeValue<double> operand1, RuntimeValue<double> operand2) =>
			CallVoid(nameof(Dynarec.FloatCompare), operand1, operand2);
		
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

		RuntimeValue<Vector128<float>> CallVectorCountBits(RuntimeValue<Vector128<float>> vec, long elems) =>
			Call<Vector128<float>>(nameof(Dynarec.VectorCountBits), vec, elems);

		RuntimeValue<ulong> CallVectorSumUnsigned(RuntimeValue<Vector128<float>> vec, long esize, long count) =>
			Call<ulong>(nameof(Dynarec.VectorSumUnsigned), vec, esize, count);

		RuntimeValue<uint> CallFloatToFixed32(RuntimeValue<float> value, ulong fbits) => Call<uint>(nameof(Dynarec.FloatToFixed32), value, (int) fbits);
		RuntimeValue<uint> CallFloatToFixed32(RuntimeValue<double> value, ulong fbits) => Call<uint>(nameof(Dynarec.FloatToFixed32), value, (int) fbits);
		RuntimeValue<ulong> CallFloatToFixed64(RuntimeValue<float> value, ulong fbits) => Call<ulong>(nameof(Dynarec.FloatToFixed64), value, (int) fbits);
		RuntimeValue<ulong> CallFloatToFixed64(RuntimeValue<double> value, ulong fbits) => Call<ulong>(nameof(Dynarec.FloatToFixed64), value, (int) fbits);

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
				Ilg.Call(typeof(Interlocked).GetMethod("CompareExchange", new[] { btype.MakeByRefType(), btype, btype }));
				Ilg.Convert<T>();
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

		public static void LogLoad<T>(RuntimeValue<ulong> addr) => CallVoid(nameof(Dynarec.LogLoad), addr, typeof(T).Name);
		public static void LogLoaded<T>(RuntimeValue<ulong> addr, RuntimeValue<T> value) => CallVoid(nameof(Dynarec.LogLoaded), addr, value, typeof(T).Name);
		public static void LogStore<T>(RuntimeValue<ulong> addr, RuntimeValue<T> value) => CallVoid(nameof(Dynarec.LogStore), addr, value, typeof(T).Name);
	}
}