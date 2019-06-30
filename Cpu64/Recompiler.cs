using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Emitter = Sigil.Emit<System.Action<Cpu64.Recompiler>>;
using Label = Sigil.Label;
#else
using SigilLite;
using Emitter = SigilLite.Emit<System.Action<Cpu64.Recompiler>>;
using Label = SigilLite.Label;
#endif

namespace Cpu64 {
	public class Block {
		public readonly ulong Addr;
		public ulong End;
		public Action<Recompiler> Func;

		public Block(ulong addr) => Addr = End = addr;
	}

	public partial class Recompiler : BaseCpu {
		class RegisterMap<T> {
			readonly Recompiler Recompiler;
			readonly string Underlying;
			public RuntimeValue<T> this[int reg] {
				get => new RuntimeValue<T>(() => {
						Recompiler.Field<T[]>(Underlying).Emit();
						Ilg.LoadConstant(reg);
						Ilg.LoadElement<T>();
					});
				set {
					//$"Setting {Underlying}[{reg}]".Debug();
					//Ilg.WriteLine($"Setting {Underlying}[{reg}]");
					Recompiler.Field<T[]>(Underlying).Emit();
					Ilg.LoadConstant(reg);
					value.Emit();
					Ilg.StoreElement<T>();
					//Ilg.WriteLine($"Set {Underlying}[{reg}]");
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
					Ilg.LoadConstant(reg >> 4);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(byte)));
					Ilg.LoadConstant(reg & 15);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(byte)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 4);
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 4);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(byte)));
					Ilg.LoadConstant(reg & 15);
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
					Ilg.LoadConstant(reg >> 3);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(ushort)));
					Ilg.LoadConstant(reg & 7);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(ushort)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 3);
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 3);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(ushort)));
					Ilg.LoadConstant(reg & 7);
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
					Ilg.LoadConstant(reg >> 2);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.LoadConstant(reg & 3);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 2);
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 2);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.LoadConstant(reg & 3);
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
					Ilg.LoadConstant(reg >> 1);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(double)));
					Ilg.LoadConstant(reg & 1);
					Ilg.Call(typeof(Vector128).GetMethod("GetElement", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(double)));
				});
				set {
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 1);
					Recompiler.Field<Vector128<float>[]>("V").Emit();
					Ilg.LoadConstant(reg >> 1);
					Ilg.LoadElement<Vector128<float>>();
					Ilg.Call(typeof(Vector128).GetMethod("As", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(typeof(float), typeof(double)));
					Ilg.LoadConstant(reg & 1);
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
			CpuRef.EmitThen(() => Ilg.LoadField(typeof(Recompiler).GetField(name))));
		public void Field<T>(string name, RuntimeValue<T> value) =>
			CpuRef.EmitThen(() => value.EmitThen(() => Ilg.StoreField(typeof(Recompiler).GetField(name))));
		
		readonly RegisterMap<ulong> XR;
		readonly RegisterMap<Vector128<float>> VR;
		readonly VectorByteMap VBR;
		readonly VectorHalfMap VHR;
		readonly VectorSingleMap VSR;
		readonly VectorDoubleMap VDR;
		RuntimeValue<ulong> SPR {
			get => Field<ulong>(nameof(SP));
			set {
				/*var local = Ilg.DeclareLocal<ulong>();
				value.Emit();
				Ilg.StoreLocal(local);
				Ilg.WriteLine($"Setting SP from {PC:X} -- {{0:X}}", local);*/
				Field(nameof(SP), value);
			}
		}

		RuntimeValue<ulong> NZCVR {
			get =>
				(Field<ulong>(nameof(NZCV_N)) << 31) |
				(Field<ulong>(nameof(NZCV_Z)) << 30) |
				(Field<ulong>(nameof(NZCV_C)) << 29) |
				(Field<ulong>(nameof(NZCV_V)) << 28);
			set {
				NZCV_NR = (value >> 31) & 1;
				NZCV_ZR = (value >> 30) & 1;
				NZCV_CR = (value >> 29) & 1;
				NZCV_VR = (value >> 28) & 1;
			}
		}
		RuntimeValue<ulong> NZCV_NR {
			get => Field<ulong>(nameof(NZCV_N));
			set => Field(nameof(NZCV_N), value);
		}
		RuntimeValue<ulong> NZCV_ZR {
			get => Field<ulong>(nameof(NZCV_Z));
			set => Field(nameof(NZCV_Z), value);
		}
		RuntimeValue<ulong> NZCV_CR {
			get => Field<ulong>(nameof(NZCV_C));
			set => Field(nameof(NZCV_C), value);
		}
		RuntimeValue<ulong> NZCV_VR {
			get => Field<ulong>(nameof(NZCV_V));
			set => Field(nameof(NZCV_V), value);
		}
		
		TypeBuilder Tb;
		static readonly ThreadLocal<Emitter> TlsIlg = new ThreadLocal<Emitter>();
		public static Emitter Ilg {
			get => TlsIlg.Value;
			set => TlsIlg.Value = value;
		}

		public Block BranchToBlock;
		public ulong BranchTo;

		bool Branched;
		ulong BlockStart, CurPc;
		Dictionary<ulong, Label> BlockInstLabels;
		Dictionary<string, (FieldBuilder, Block)> CurBlockRefs;

		public Recompiler(IKernel kernel) : base(kernel) {
			XR = new RegisterMap<ulong>(this, nameof(X));
			VR = new RegisterMap<Vector128<float>>(this, nameof(V));
			VBR = new VectorByteMap(this);
			VHR = new VectorHalfMap(this);
			VSR = new VectorSingleMap(this);
			VDR = new VectorDoubleMap(this);
		}
		
		public override unsafe void Run(ulong pc, ulong sp, bool one = false) {
			SP = sp;
			while(true) {
				var block = BranchToBlock ?? CacheManager.GetBlock(pc);
				lock(block)
					if(block.Func == null) {
						$"Recompiling block at {Kernel.MapAddress(pc)}".Debug();
						//DebugRegs();
						BlockStart = pc;
						BlockInstLabels = new Dictionary<ulong, Label>();
						CurBlockRefs = new Dictionary<string, (FieldBuilder, Block)>();
						
						var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
						var mb = ab.DefineDynamicModule("Block");
						Tb = mb.DefineType("Block");
						var mname = $"Block_{pc:X}";
						Ilg = Emit<Action<Recompiler>>.BuildMethod(Tb, mname, MethodAttributes.Static | MethodAttributes.Public, CallingConventions.Standard);

						Branched = false;
						while(!Branched) {
							PC = CurPc = pc;
							var inst = *(uint*) pc;
							var asm = Disassemble(inst, pc);
							if(asm == null) {
								$"Disassembly failed at {Kernel.MapAddress(pc)} --- {inst:X8}".Debug();
								Environment.Exit(1);
							}

							var blabel = BlockInstLabels[pc] = Ilg.DefineLabel();
							Ilg.MarkLabel(blabel);

							Field<ulong>(nameof(PC), pc);
							CallVoid(nameof(Test));

							LogIf(0, () => {
								$"{Kernel.MapAddress(pc)}:  {asm}".Debug();
								//CallVoid(nameof(DebugRegs));
							});

							if(!Recompile(inst, pc))
								throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
							pc += 4;
						}
						try { Ilg.Return(); } catch (SigilVerificationException) { }

						//Ilg.Instructions().Debug();
						Ilg.CreateMethod();
						var type = Tb.CreateType();
						foreach(var (key, value) in CurBlockRefs)
							type.GetField(key).SetValue(null, value.Item2);
						var func = type.GetMethod(mname).CreateDelegate<Action<Recompiler>>();

						block.End = pc;
						block.Func = func;
						pc = BlockStart;
					}
				LogIf(0, () => $"Running block at 0x{pc:X}".Debug());
				
				BranchToBlock = null;
				BranchTo = unchecked((ulong) -1);
				block.Func(this);

				if(!one && (SP < 0x100000 || SP >> 48 != 0))
					throw new Exception($"SP likely corrupted by block {PC:X}: SP == 0x{SP:X}");
				PC = pc = BranchTo;
				Debug.Assert((pc & 3) == 0);
				if(one)
					break;
			}
		}

		bool PlanZ;
		public void Test() {
			return;
			if(PC == 0x7200990864) PlanZ = true;
			if(!PlanZ) return;
			var regs = Enumerable.Range(0, 31).Select(i => $"X{i} == {X[i]:X}");
			$"{Kernel.MapAddress(PC)}  {NZCV >> 28:X} {string.Join(' ', regs)} SP == {SP:X}".Debug();
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
				default: throw new NotImplementedException($"Unknown type for object LoadConstant: {c.GetType()}");
			}
		}

		static void CallVoid(string methodName, params object[] args) {
			var methods = typeof(BaseCpu)
				.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				.Concat(
					typeof(Recompiler).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
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
					typeof(Recompiler).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
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
			if(BlockStart <= target && target <= CurPc) {
				Ilg.Branch(BlockInstLabels[target]);
				return;
			}

			var fname = $"_{target:X8}";
			var block = CacheManager.GetBlock(target);
			if(CurBlockRefs.TryGetValue(fname, out var br)) {
				CpuRef.Emit();
				Ilg.LoadField(br.Item1);
				Ilg.StoreField(typeof(Recompiler).GetField(nameof(BranchToBlock)));
			} else {
				var fb = Tb.DefineField(fname, typeof(Block), FieldAttributes.Public | FieldAttributes.Static);
				CurBlockRefs[fname] = (fb, block);
				CpuRef.Emit();
				Ilg.LoadField(fb);
				Ilg.StoreField(typeof(Recompiler).GetField(nameof(BranchToBlock)));
			}
			CpuRef.Emit();
			Ilg.LoadConstant(target);
			Ilg.StoreField(typeof(Recompiler).GetField(nameof(BranchTo)));

		}
		void Branch(RuntimeValue<ulong> addr) {
			Branched = true;
			CpuRef.Emit();
			addr.Emit();
			Ilg.StoreField(typeof(Recompiler).GetField(nameof(BranchTo)));
		}

		void Branch(Label label) {
			try {
				Ilg.Branch(label);
			} catch (SigilVerificationException) {
			}
		}

		void BranchIf(RuntimeValue<int> cond, Label label) => cond.EmitThen(() => Ilg.BranchIfTrue(label));

		void Label(Label label) => Ilg.MarkLabel(label);
		
		public void Unsupported() => throw new NotSupportedException();
		
		public static RuntimeValue<ValueT> Ternary<CondT, ValueT>(RuntimeValue<CondT> cond, RuntimeValue<ValueT> a, RuntimeValue<ValueT> b) =>
			new RuntimeValue<ValueT>(() => {
				Label _if = Ilg.DefineLabel(), end = Ilg.DefineLabel();
				cond.Emit();
				Ilg.BranchIfTrue(_if);
				if((object) b == null)
					CallVoid(nameof(Unsupported));
				else
					b.Emit();
				Ilg.Branch(end);
				Ilg.MarkLabel(_if);
				if((object) a == null)
					CallVoid(nameof(Unsupported));
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
			Call<uint>(nameof(AddWithCarrySetNzcv), operand1, operand2, carryIn);
		RuntimeValue<ulong> CallAddWithCarrySetNzcv(RuntimeValue<ulong> operand1, RuntimeValue<ulong> operand2, RuntimeValue<ulong> carryIn) =>
			Call<ulong>(nameof(AddWithCarrySetNzcv), operand1, operand2, carryIn);

		void CallFloatCompare(RuntimeValue<float> operand1, RuntimeValue<float> operand2) =>
			CallVoid(nameof(FloatCompare), operand1, operand2);
		void CallFloatCompare(RuntimeValue<double> operand1, RuntimeValue<double> operand2) =>
			CallVoid(nameof(FloatCompare), operand1, operand2);
		
		RuntimeValue<T> SignExtRuntime<T>(RuntimeValue<ulong> value, int size) {
			if(typeof(T) == typeof(int))
				return Call<T>(nameof(SignExtRuntimeInt), value, size);
			if(typeof(T) == typeof(long))
				return Call<T>(nameof(SignExtRuntimeLong), value, size);
			throw new NotSupportedException();
		}
		public int SignExtRuntimeInt(ulong value, int size) => SignExt<int>(value, size);
		public long SignExtRuntimeLong(ulong value, int size) => SignExt<long>(value, size);
		
		RuntimeValue<uint> CallCountLeadingZeros(RuntimeValue<uint> value) => Call<uint>(nameof(CountLeadingZeros), value);
		RuntimeValue<ulong> CallCountLeadingZeros(RuntimeValue<ulong> value) => Call<ulong>(nameof(CountLeadingZeros), value);
		
		RuntimeValue<uint> CallReverseBits(RuntimeValue<uint> value) => Call<uint>(nameof(ReverseBits), value);
		RuntimeValue<ulong> CallReverseBits(RuntimeValue<ulong> value) => Call<ulong>(nameof(ReverseBits), value);

		RuntimeValue<ulong> CallSR(uint op0, uint op1, uint crn, uint crm, uint op2) => Call<ulong>(nameof(SR), op0, op1, crn, crm, op2);
		void CallSR(uint op0, uint op1, uint crn, uint crm, uint op2, RuntimeValue<ulong> value) => CallVoid(nameof(SR), op0, op1, crn, crm, op2, value);

		void LogIf(ulong addr, Action func) {
			return;
			//if(addr >= 0x7100B51004 && addr <= 0x71008D50D0)
			if(
				(PC >= 0x7100B4A07C + 0x7000 && PC <= 0x7100B4A20C + 0x7000) ||
				(addr >= 0x7102465A50 + 0x7000 && addr <= 0x7102465A80 + 0x7000) ||
				(PC >= 0x7100A39CC8 + 0x7000 && PC <= 0x7100A39DBC + 0x7000)
			)
				func();
		}

		public static void LogLoad<T>(RuntimeValue<ulong> addr) => CallVoid(nameof(LogLoad), addr, typeof(T).Name);
		public void LogLoad(ulong addr, string type) => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loading {type} from {Kernel.MapAddress(addr)}".Debug());
		public static void LogLoaded<T>(RuntimeValue<ulong> addr, RuntimeValue<T> value) => CallVoid(nameof(LogLoaded), addr, value, typeof(T).Name);
		public void LogLoaded(ulong addr, byte value, string type)             => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, ushort value, string type)           => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, uint value, string type)             => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, ulong value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, sbyte value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, short value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, int value, string type)              => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, long value, string type)             => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, float value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{  value} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, double value, string type)           => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{  value} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		public void LogLoaded(ulong addr, Vector128<float> value, string type) => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Loaded 0x{  value} ({type}) from {Kernel.MapAddress(addr)}".Debug());
		
		public static void LogStore<T>(RuntimeValue<ulong> addr, RuntimeValue<T> value) => CallVoid(nameof(LogStore), addr, value, typeof(T).Name);
		public void LogStore(ulong addr, byte value, string type)             => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, ushort value, string type)           => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, uint value, string type)             => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, ulong value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, sbyte value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, short value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, int value, string type)              => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, long value, string type)             => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, float value, string type)            => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing {  value  } ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, double value, string type)           => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing {  value  } ({type}) to {Kernel.MapAddress(addr)}".Debug());
		public void LogStore(ulong addr, Vector128<float> value, string type) => LogIf(addr, () => $"[{Kernel.MapAddress(PC)}] Storing {  value  } ({type}) to {Kernel.MapAddress(addr)}".Debug());
	}
}