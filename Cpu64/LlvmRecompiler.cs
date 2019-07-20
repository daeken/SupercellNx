using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Threading;
using Common;
using LLVMSharp;
using UltimateOrb;

namespace Cpu64 {
	public static class LlvmExtensions {
		public static LLVMTypeRef ToLLVMType(this Type type) {
			if(type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Vector128<>)) {
				var et = type.GetGenericArguments()[0];
				return LLVMTypeRef.VectorType(et.ToLLVMType(), 16U / (uint) Marshal.SizeOf(et));
			}
			if(typeof(MulticastDelegate).IsAssignableFrom(type)) {
				var mi = type.GetMethod("Invoke");
				return LLVMTypeRef.FunctionType(mi.ReturnType.ToLLVMType(),
					mi.GetParameters().Select(x => x.ParameterType.ToLLVMType()).ToArray(), false);
			}
			if(type == typeof(void))
				return LLVMTypeRef.VoidType();
			if(type.IsPointer) return LLVMTypeRef.Int64Type();
			switch(Activator.CreateInstance(type)) {
				case sbyte _: case byte _: return LLVMTypeRef.Int8Type();
				case short _: case ushort _: return LLVMTypeRef.Int16Type();
				case int _: case uint _: return LLVMTypeRef.Int32Type();
				case long _: case ulong _: return LLVMTypeRef.Int64Type();
				case Int128 _: case UInt128 _: return LLVMTypeRef.IntType(128);
				case float _: return LLVMTypeRef.FloatType();
				case double _: return LLVMTypeRef.DoubleType();
				case bool _: return LLVMTypeRef.IntType(1);
				default: throw new NotSupportedException(type.Name);
			}
		}

		public static int ElementCount(this Type type) => 16 / Marshal.SizeOf(type.GetGenericArguments()[0]);
	}
	
	public class LlvmLabel {
		LLVMBasicBlockRef? Block;
		public readonly Func<LLVMBasicBlockRef> LazyBlock;
		public LlvmLabel(LLVMBasicBlockRef block) => Block = block;
		public LlvmLabel(Func<LLVMBasicBlockRef> block) => LazyBlock = block;
		public static implicit operator LLVMBasicBlockRef(LlvmLabel label) => label.Block ?? (label.Block = label.LazyBlock()).Value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct LlvmCallbacks {
		public delegate void SvcDelegate(uint svc);
		public ulong Svc;

		public delegate ulong GetSRDelegate(CpuState* state, uint op0, uint op1, uint crn, uint crm, uint op2);
		public ulong GetSR;

		public delegate void SetSRDelegate(uint op0, uint op1, uint crn, uint crm, uint op2, ulong value);
		public ulong SetSR;

		public delegate void DebugDelegate();
		public ulong Debug;

		public delegate void LogLoadDelegate(ulong typeStr, ulong address);
		public ulong LogLoad;

		public delegate void LogStoreDelegate(ulong typeStr, ulong address);
		public ulong LogStore;
	}

	public unsafe partial class LlvmRecompiler : BaseCpu {
		public static LLVMTypeRef LlvmType<T>() => typeof(T).ToLLVMType();
		
		public class LlvmLocal<T> where T : struct {
			readonly LLVMValueRef Pointer;
			public LlvmLocal(string name = "") => Pointer = LLVM.BuildAlloca(Builder, LlvmType<T>(), name);
			public LlvmRuntimeValue<T> Value {
				get => new LlvmRuntimeValue<T>(() => LLVM.BuildLoad(Builder, Pointer, ""));
				set => LLVM.BuildStore(LlvmRecompiler.Builder, value, Pointer);
			}

			public static implicit operator LlvmRuntimeValue<T>(LlvmLocal<T> local) => local.Value;
		}
		
		public class LlvmRegisterMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmRegisterMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<ulong> this[int reg] {
				get => new LlvmRuntimeValue<ulong>(() => {
					if(reg == 31) return Recompiler.Const(0UL);
					Recompiler.RegistersUsed[reg] = true;
					/*var addr = Recompiler.FieldAddress(nameof(CpuState.X0)) + (ulong) (reg * 8);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<ulong>(), 0), "");
					return LLVM.BuildLoad(Builder, ptr, $"X{reg}_");*/
					return Recompiler.RegisterLocals[reg].Value;
				});
				set {
					if(reg == 31) {
						value.Emit();
						return;
					}
					Recompiler.RegistersUsed[reg] = true;
					/*var addr = Recompiler.FieldAddress(nameof(CpuState.X0)) + (ulong) (reg * 8);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<ulong>(), 0), $"X{reg}_");
					LLVM.BuildStore(Builder, value, ptr);*/
					Recompiler.RegisterLocals[reg].Value = value;
				}
			}
		}

		public class LlvmVectorMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<Vector128<float>> this[int reg] {
				get => new LlvmRuntimeValue<Vector128<float>>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<Vector128<float>>(), 0), "");
					return LLVM.BuildLoad(Builder, ptr, $"V{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<Vector128<float>>(), 0), $"V{reg}_");
					LLVM.BuildStore(Builder, value, ptr);
				}
			}
		}

		public class LlvmVectorByteMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorByteMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<byte> this[int reg] {
				get => new LlvmRuntimeValue<Vector128<byte>>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<byte>(), 0), "");
					return LLVM.BuildLoad(Builder, ptr, $"B{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<byte>>();
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(type, 0), $"B{reg}_");
					var bvec = LLVM.BuildInsertElement(Builder, LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					for(var i = 1; i < 16; ++i)
						bvec = LLVM.BuildInsertElement(Builder, bvec, Recompiler.Const((byte) 0), Recompiler.Const(i), "");
					LLVM.BuildStore(Builder, bvec, ptr);
				}
			}
		}

		public class LlvmVectorHalfMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorHalfMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<ushort> this[int reg] {
				get => new LlvmRuntimeValue<ushort>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<ushort>(), 0), "");
					return LLVM.BuildLoad(Builder, ptr, $"H{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<ushort>>();
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(type, 0), $"H{reg}_");
					var bvec = LLVM.BuildInsertElement(Builder, LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					for(var i = 1; i < 8; ++i)
						bvec = LLVM.BuildInsertElement(Builder, bvec, Recompiler.Const((ushort) 0), Recompiler.Const(i), "");
					LLVM.BuildStore(Builder, bvec, ptr);
				}
			}
		}

		public class LlvmVectorFloatMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorFloatMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<float> this[int reg] {
				get => new LlvmRuntimeValue<ushort>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<float>(), 0), "");
					return LLVM.BuildLoad(Builder, ptr, $"S{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<float>>();
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(type, 0), $"S{reg}_");
					var bvec = LLVM.BuildInsertElement(Builder, LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					for(var i = 1; i < 4; ++i)
						bvec = LLVM.BuildInsertElement(Builder, bvec, Recompiler.Const(0f), Recompiler.Const(i), "");
					LLVM.BuildStore(Builder, bvec, ptr);
				}
			}
		}

		public class LlvmVectorDoubleMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorDoubleMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<double> this[int reg] {
				get => new LlvmRuntimeValue<double>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(LlvmType<double>(), 0), "");
					return LLVM.BuildLoad(Builder, ptr, $"D{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<double>>();
					var ptr = LLVM.BuildIntToPtr(Builder, addr, LLVMTypeRef.PointerType(type, 0), $"D{reg}_");
					var bvec = LLVM.BuildInsertElement(Builder, LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					bvec = LLVM.BuildInsertElement(Builder, bvec, Recompiler.Const(0d), Recompiler.Const(1), "");
					LLVM.BuildStore(Builder, bvec, ptr);
				}
			}
		}

		static readonly ThreadLocal<LlvmRecompiler> TlsInstance = new ThreadLocal<LlvmRecompiler>();
		public static LlvmRecompiler Instance {
			get => TlsInstance.Value;
			private set => TlsInstance.Value = value;
		}

		public LlvmRuntimeValue<ulong> SPR {
			get => Field<ulong>(nameof(CpuState.SP));
			set => Field(nameof(CpuState.SP), value);
		}
		public readonly LlvmRegisterMap XR;
		public readonly LlvmVectorMap VR;
		public readonly LlvmVectorByteMap VBR;
		public readonly LlvmVectorHalfMap VHR;
		public readonly LlvmVectorFloatMap VSR;
		public readonly LlvmVectorDoubleMap VDR;

		public LlvmRuntimeValue<byte> Exclusive8R;
		public LlvmRuntimeValue<ushort> Exclusive16R;
		public LlvmRuntimeValue<uint> Exclusive32R;
		public LlvmRuntimeValue<ulong> Exclusive64R;

		public LlvmRuntimeValue<ulong> NZCVR {
			get => (NZCV_NR << 31) | (NZCV_ZR << 30) | (NZCV_CR << 29) | (NZCV_VR << 28);
			set {
				NZCV_NR = (value >> 31) & 1;
				NZCV_ZR = (value >> 30) & 1;
				NZCV_CR = (value >> 29) & 1;
				NZCV_VR = (value >> 28) & 1;
			}
		}
		public LlvmRuntimeValue<ulong> NZCV_NR {
			get => Field<ulong>(nameof(CpuState.NZCV_N));
			set => Field(nameof(CpuState.NZCV_N), value);
		}
		public LlvmRuntimeValue<ulong> NZCV_ZR {
			get => Field<ulong>(nameof(CpuState.NZCV_Z));
			set => Field(nameof(CpuState.NZCV_Z), value);
		}
		public LlvmRuntimeValue<ulong> NZCV_CR {
			get => Field<ulong>(nameof(CpuState.NZCV_C));
			set => Field(nameof(CpuState.NZCV_C), value);
		}
		public LlvmRuntimeValue<ulong> NZCV_VR {
			get => Field<ulong>(nameof(CpuState.NZCV_V));
			set => Field(nameof(CpuState.NZCV_V), value);
		}

		static readonly ThreadLocal<LLVMBuilderRef> TlsBuilder = new ThreadLocal<LLVMBuilderRef>();
		public static LLVMBuilderRef Builder {
			get => TlsBuilder.Value;
			set => TlsBuilder.Value = value;
		}
		static readonly ThreadLocal<LLVMModuleRef> TlsModule = new ThreadLocal<LLVMModuleRef>();
		public static LLVMModuleRef Module {
			get => TlsModule.Value;
			set => TlsModule.Value = value;
		}
		LLVMPassManagerRef PassManager;
		LLVMExecutionEngineRef ExecutionEngine;

		LLVMValueRef Function;
		
		bool Branched;
		Dictionary<ulong, LlvmLabel> BlockLabels;
		Queue<ulong> BlocksNeeded;
		bool[] RegistersUsed;
		LlvmLocal<ulong>[] RegisterLocals;
		List<(LlvmLabel Before, LlvmLabel After)> LoadRegistersLabels;
		List<(LlvmLabel Before, LlvmLabel After)> StoreRegistersLabels;
		bool JustBranched;
		LlvmLabel SuppressedBranch;
		List<LlvmLabel> UsedLabels;
		LLVMBasicBlockRef CurrentBlock;

		readonly LlvmCallbacks *Callbacks;

		[DllImport("libc", CharSet = CharSet.Ansi)]
		static extern ulong dlopen(string name, int mode);
		[DllImport("libc", CharSet = CharSet.Ansi)]
		static extern ulong dlsym(long handle, string name);
		[DllImport("libc")]
		static extern void mprotect(ulong addr, ulong size, int prot);

		static LlvmRecompiler() {
			LLVM.LinkInMCJIT();
			LLVM.InitializeX86TargetInfo();
			LLVM.InitializeX86Target();
			LLVM.InitializeX86TargetMC();
			LLVM.InitializeX86AsmParser();
			LLVM.InitializeX86AsmPrinter();
			
			LLVM.InitializeMCJITCompilerOptions(new LLVMMCJITCompilerOptions { NoFramePointerElim = 1 });
		}

		class LlvmException : Exception {
			public LlvmException(string msg) : base(msg) {}
		}
		delegate void BailoutDel(string a, string b, int c, string d);
		static void Bailout(string func, string file, int line, string message) =>
			throw new LlvmException($"Assertion failed in `{func}` ({file}:{line}):  {message}");

		public LlvmRecompiler(IKernel kernel = null) : base(kernel) {
			/*var mod = dlopen("/Users/cody/projects/SupercellNx/App/bin/Debug/netcoreapp3.0/runtimes/osx/native/libLLVM.dylib", 1);
			Debug.Assert(mod != 0);
			var init = dlsym(unchecked((long) mod), "LLVMInitializeX86Target");
			Debug.Assert(init != 0);
			var tgt = init - 0x208f270 + 0x2d1df30;
			mprotect(tgt & ~0xFFFUL, 0x1000, 0x7);
			BailoutDel bailout = Bailout;
			GCHandle.Alloc(bailout);
			*(ulong*) tgt = (ulong) Marshal.GetFunctionPointerForDelegate(bailout);*/
			
			XR = new LlvmRegisterMap(this);
			VR = new LlvmVectorMap(this);
			VBR = new LlvmVectorByteMap(this);
			VHR = new LlvmVectorHalfMap(this);
			VSR = new LlvmVectorFloatMap(this);
			VDR = new LlvmVectorDoubleMap(this);

			Callbacks = (LlvmCallbacks*) Marshal.AllocHGlobal(Marshal.SizeOf<LlvmCallbacks>());
			Callbacks->Svc = FunctionPtr<LlvmCallbacks.SvcDelegate>(svc => {
				if(Kernel == null) {
					Console.WriteLine("SVC!");
					Environment.Exit(1);
				}
				Kernel.Svc((int) svc);
			});
			Callbacks->GetSR = FunctionPtr<LlvmCallbacks.GetSRDelegate>((state, op0, op1, crn, crm, op2) => {
				var reg = ((0b10 | op0) << 14) | (op1 << 11) | (crn << 7) | (crm << 3) | op2;
				if(reg == 0b11_011_1101_0000_011) // TPIDR
					return state->TlsBase;
				return SR(op0, op1, crn, crm, op2);
			});
			Callbacks->SetSR = FunctionPtr<LlvmCallbacks.SetSRDelegate>(SR);

			/*var bw = new BinaryWriter(File.OpenWrite("recinsns.bin"));
			var skip = 132_500_000;
			Callbacks->Debug = FunctionPtr<LlvmCallbacks.DebugDelegate>(() => {
				if(skip > 0) {
					skip--;
					if(skip == 0)
						Console.WriteLine($"Stopped skipping at 0x{State->PC:X}");
					return;
				}
				bw.Write(State->PC);
				bw.Write((byte) ((State->NZCV_N << 3) | (State->NZCV_Z << 2) | (State->NZCV_C << 1) | (State->NZCV_V << 0)));
				for(var i = 0; i < 31; ++i)
					bw.Write((&State->X0)[i]);
				for(var i = 0; i < 32; ++i)
					bw.Write((&State->V0)[i].As<float, ulong>().GetElement(0));
				bw.Write(State->SP);
				bw.Flush();
				((FileStream) bw.BaseStream).Flush(true);
			});*/

			Callbacks->LogLoad =
				FunctionPtr<LlvmCallbacks.LogLoadDelegate>((tstr, address) => {
					//if(skip > 0) return;
					var span = new Span<byte>((byte*) tstr, 64);
					var str = "";
					for(var i = 0; i < 64; ++i) {
						if(span[i] == 0) break;
						str += new string((char) span[i], 1);
					}

					Console.WriteLine($"Load {str} from 0x{address:X}");
				});

			Callbacks->LogStore =
				FunctionPtr<LlvmCallbacks.LogStoreDelegate>((tstr, address) => {
					//if(skip > 0) return;
					var span = new Span<byte>((byte*) tstr, 64);
					var str = "";
					for(var i = 0; i < 64; ++i) {
						if(span[i] == 0) break;
						str += new string((char) span[i], 1);
					}

					Console.WriteLine($"Store {str} to 0x{address:X}");
				});
		}

		static ulong FunctionPtr<DelegateT>(DelegateT func) {
			GCHandle.Alloc(func); // TODO: Delete this when the recompiler is destroyed
			return (ulong) Marshal.GetFunctionPointerForDelegate(func);
		}

		public override void Run(ulong pc, ulong sp, bool one = false) {
			Instance = this;
			State->SP = sp;
			while(true) {
				var block = CacheManager.GetBlock(pc);
				if(block.Func == null)
					lock(block)
						if(block.Func == null)
							RecompileMultiple(block);

				State->BranchTo = unchecked((ulong) -1);
				Debug.Assert(block.Func != null);
				//Console.WriteLine($"Running block starting with 0x{block.Addr:X}");
				block.Func(State, this);
				//Console.WriteLine($"Finished block 0x{block.Addr:X}");
				
				if(!one && (State->SP < 0x100000 || State->SP >> 48 != 0))
					throw new Exception($"SP likely corrupted by block {State->PC:X}: SP == 0x{State->SP:X}");
				State->PC = pc = State->BranchTo;
				if(one)
					break;
				Debug.Assert((pc & 3) == 0);
			}
		}

		public void RecompileMultiple(Block block) {
			Instance = this;
			Module = LLVM.ModuleCreateWithName("SupercellNXLLVM");
			Builder = LLVM.CreateBuilder();

			PassManager = LLVM.CreateFunctionPassManagerForModule(Module);
			LLVM.AddInstructionCombiningPass(PassManager);
			LLVM.AddReassociatePass(PassManager);
			LLVM.AddCFGSimplificationPass(PassManager);
			LLVM.AddGVNPass(PassManager);
			LLVM.AddPromoteMemoryToRegisterPass(PassManager);
			LLVM.AddSLPVectorizePass(PassManager);
			LLVM.AddDeadStoreEliminationPass(PassManager);
			LLVM.AddAggressiveDCEPass(PassManager);
			LLVM.InitializeFunctionPassManager(PassManager);

			Function = LLVM.AddFunction(Module, $"_{block.Addr:X}", LlvmType<Action<ulong, ulong>>());
			LLVM.SetLinkage(Function, LLVMLinkage.LLVMExternalLinkage);

			UsedLabels = new List<LlvmLabel>();
			
			LLVM.PositionBuilderAtEnd(Builder, LLVM.AppendBasicBlock(Function, "entrypoint"));

			RegistersUsed = new bool[31];
			RegisterLocals = Enumerable.Range(0, 31).Select(i => new LlvmLocal<ulong>($"X{i}")).ToArray();
			var preRegisterLoad = DefineLabel("preRegisterLoad");
			var postRegisterLoad = DefineLabel("postRegisterLoad");
			var retLabel = DefineLabel("return");
			Branch(preRegisterLoad);
			Label(postRegisterLoad);
			StoreRegistersLabels = new List<(LlvmLabel, LlvmLabel)> { (DefineLabel("storeRegisters_"), retLabel) };
			LoadRegistersLabels = new List<(LlvmLabel, LlvmLabel)> { (preRegisterLoad, postRegisterLoad) };

			BlockLabels = new Dictionary<ulong, LlvmLabel>();
			BlocksNeeded = new Queue<ulong>();
			BlocksNeeded.Enqueue(block.Addr);
			var blockCount = 0;
			var recompiled = new HashSet<ulong>();
			var topFirst = true;
			void CompileOneBlock(ulong pc) {
				blockCount++;
				if(recompiled.Contains(pc))
					return;

				var first = true;
				Branched = false;
				while(!Branched) {
					//Console.WriteLine($"Recompiling {pc:X}");

					var label = BlockLabels.TryGetValue(pc, out var _label)
						? _label
						: BlockLabels[pc] = DefineLabel($"_{pc:X}");
					if(!first || topFirst)
						Branch(label);
					first = topFirst = false;
					if(recompiled.Contains(pc)) break;
					recompiled.Add(pc);
					Label(label);
					
					Field<ulong>(nameof(CpuState.PC), pc);
					//Call<LlvmCallbacks.DebugDelegate>(nameof(LlvmCallbacks.Debug));
					if(!Recompile(*(uint*) pc, pc))
						throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
					pc += 4;
				}
			}
			
			while(BlocksNeeded.TryDequeue(out var pc))
				CompileOneBlock(pc);

			foreach(var (before, after) in LoadRegistersLabels) {
				Label(before);
				for(var i = 0; i < 31; ++i)
					if(RegistersUsed[i]) RegisterLocals[i].Value = Field<ulong>($"X{i}");
				Branch(after);
			}

			foreach(var (before, after) in StoreRegistersLabels) {
				Label(before);
				for(var i = 0; i < 31; ++i)
					if(RegistersUsed[i]) Field($"X{i}", RegisterLocals[i].Value);
				Branch(after);
			}
			
			Label(StoreRegistersLabels[0].After);
			LLVM.BuildRetVoid(Builder);
			
			//LLVM.DumpValue(Function);
			LLVM.VerifyFunction(Function, LLVMVerifierFailureAction.LLVMPrintMessageAction);
			if(LLVM.VerifyFunction(Function, LLVMVerifierFailureAction.LLVMReturnStatusAction))
				throw new Exception("Program verification failed");
			LLVM.RunFunctionPassManager(PassManager, Function);
			//LLVM.DumpValue(Function);
			
			if(LLVM.CreateExecutionEngineForModule(out ExecutionEngine, Module, out var errorMessage).Value == 1)
				throw new Exception(errorMessage);
			
			var tfunc = Marshal.GetDelegateForFunctionPointer<LlvmBlockFunc>(LLVM.GetPointerToGlobal(ExecutionEngine, Function));
			block.Func = (state, _) => tfunc(state, Callbacks);
		}

		public LLVMValueRef Intrinsic<T>(string name, params LLVMValueRef[] args) {
			var func = LLVM.GetNamedFunction(Module, name);
			func = func.Pointer == IntPtr.Zero ? LLVM.AddFunction(Module, name, LlvmType<T>()) : func;
			return LLVM.BuildCall(Builder, func, args, "");
		}

		public void Emitted() => JustBranched = false;
		
		public LlvmRuntimeValue<ulong> CpuStateRef => new LlvmRuntimeValue<ulong>(() => LLVM.GetParam(Function, 0));
		public LlvmRuntimeValue<ulong> CallbacksRef => new LlvmRuntimeValue<ulong>(() => LLVM.GetParam(Function, 1));

		public LlvmRuntimeValue<T> Field<T>(string name) where T : struct =>
			new LlvmRuntimePointer<T>(FieldAddress(name));
		public void Field<T>(string name, LlvmRuntimeValue<T> value) where T : struct =>
			new LlvmRuntimePointer<T>(FieldAddress(name)).Value = value;
		public LlvmRuntimeValue<ulong> FieldAddress(string name) =>
			CpuStateRef + (ulong) Marshal.OffsetOf<CpuState>(name);
		
		public LlvmRuntimeValue<T> Const<T>(T value) where T : struct => new LlvmRuntimeValue<T>(() => {
			unchecked {
				switch(value) {
					case sbyte v: return LLVM.ConstInt(LLVMTypeRef.Int8Type(), (ulong) v, false);
					case byte v: return LLVM.ConstInt(LLVMTypeRef.Int8Type(), v, false);
					case short v: return LLVM.ConstInt(LLVMTypeRef.Int16Type(), (ulong) v, false);
					case ushort v: return LLVM.ConstInt(LLVMTypeRef.Int16Type(), v, false);
					case int v: return LLVM.ConstInt(LLVMTypeRef.Int32Type(), (ulong) v, false);
					case uint v: return LLVM.ConstInt(LLVMTypeRef.Int32Type(), v, false);
					case long v: return LLVM.ConstInt(LLVMTypeRef.Int64Type(), (ulong) v, false);
					case ulong v: return LLVM.ConstInt(LLVMTypeRef.Int64Type(), v, false);
					case Int128 v:
						Debug.Assert(v >= 0 && (v >> 64) == 0);
						return LLVM.ConstInt(LLVMTypeRef.IntType(128), (ulong) v, false);
					case UInt128 v:
						Debug.Assert(v >= 0 && (v >> 64) == 0);
						return LLVM.ConstInt(LLVMTypeRef.IntType(128), (ulong) v, false);
					case float v:
						return LLVM.BuildBitCast(Builder,
							LLVM.ConstInt(LLVMTypeRef.Int32Type(), *(uint*) &v, false), LLVMTypeRef.FloatType(), "");
					case double v:
						return LLVM.BuildBitCast(Builder,
							LLVM.ConstInt(LLVMTypeRef.Int64Type(), *(ulong*) &v, false), LLVMTypeRef.DoubleType(), "");
					case bool v: return LLVM.ConstInt(LLVMTypeRef.Int1Type(), v ? 1UL : 0, false);
					default: throw new NotImplementedException(typeof(T).Name);
				}
			}
		});
		
		public LlvmLocal<T> DeclareLocal<T>() where T : struct => new LlvmLocal<T>();

		public LlvmLabel DefineLabel(string name = "") => new LlvmLabel(() => LLVM.AppendBasicBlock(Function, name));
		public void Label(LlvmLabel label) {
			if(JustBranched && SuppressedBranch == label && !UsedLabels.Contains(label)) {
				JustBranched = false;
				return;
			}
			JustBranched = false;
			LLVM.PositionBuilderAtEnd(Builder, CurrentBlock = label);
		}

		public void Branch(LlvmLabel label) {
			if(!JustBranched) {
				LLVM.BuildBr(Builder, label);
				UsedLabels.Add(label);
			} else
				SuppressedBranch = label;
			JustBranched = true;
		}

		void Branch(ulong target) {
			/*Field(nameof(CpuState.BranchTo), Const(target));
			Branch(StoreRegistersLabel);
			Branched = true;*/
			
			if(!BlockLabels.TryGetValue(target, out var label)) {
				label = BlockLabels[target] = DefineLabel($"_{target:X}");
				BlocksNeeded.Enqueue(target);
			}
			Branch(label);
			Branched = true;
		}
		void Branch(LlvmRuntimeValue<ulong> target) {
			Field(nameof(CpuState.BranchTo), target);
			Branch(StoreRegistersLabels[0].Before);
			Branched = true;
		}

		void BranchIf(LlvmRuntimeValue<byte> cond, LlvmLabel if_label, LlvmLabel else_label) {
			if(!JustBranched) {
				UsedLabels.Add(if_label);
				UsedLabels.Add(else_label);
				LLVM.BuildCondBr(Builder,
					LLVM.BuildICmp(Builder, LLVMIntPredicate.LLVMIntNE, cond, Const((byte) 0), ""), if_label, else_label);
			}
			JustBranched = true;
		}

		public static LlvmRuntimeValue<ValueT> Ternary<CondT, ValueT>(LlvmRuntimeValue<CondT> cond, LlvmRuntimeValue<ValueT> a, LlvmRuntimeValue<ValueT> b)
			where CondT : struct where ValueT : struct =>
			new LlvmRuntimeValue<ValueT>(() => {
				var if_ = Instance.DefineLabel();
				var else_ = Instance.DefineLabel();
				var end = Instance.DefineLabel();
				Instance.BranchIf(cond, if_, else_);
				Instance.Label(if_);
				var av = a.Emit();
				var ab = Instance.CurrentBlock;
				Instance.Branch(end);
				Instance.Label(else_);
				var bv = b.Emit();
				var bb = Instance.CurrentBlock;
				Instance.Branch(end);
				Instance.Label(end);
				var phi = LLVM.BuildPhi(Builder, LlvmType<ValueT>(), "");
				LLVM.AddIncoming(phi, new[] { av, bv }, new LLVMBasicBlockRef[] { ab, bb }, 2);
				return phi;
			});

		LLVMValueRef Call<DelegateT>(string name, params LLVMValueRef[] args) {
			var offset = Marshal.OffsetOf<LlvmCallbacks>(name);
			var dt = typeof(DelegateT);
			Debug.Assert(typeof(MulticastDelegate).IsAssignableFrom(dt));
			var mi = dt.GetMethod("Invoke");
			var ft = LLVMTypeRef.PointerType(LLVMTypeRef.FunctionType(mi.ReturnType.ToLLVMType(),
				mi.GetParameters().Select(x => x.ParameterType.ToLLVMType()).ToArray(), false), 0);
			return LLVM.BuildCall(Builder,
				LLVM.BuildIntToPtr(Builder,
					LLVM.BuildLoad(Builder,
						LLVM.BuildIntToPtr(Builder, CallbacksRef + Const((ulong) offset),
							LLVMTypeRef.PointerType(LLVMTypeRef.Int64Type(), 0), ""), ""), ft, ""), args, "");
		}

		void CallSvc(uint svc) {
			LlvmLabel preStore = DefineLabel("preSvcStore_"), postStore = DefineLabel("postSvcStore_");
			LlvmLabel preLoad = DefineLabel("preSvcLoad_"), postLoad = DefineLabel("postSvcLoad_");
			StoreRegistersLabels.Add((preStore, postStore));
			LoadRegistersLabels.Add((preLoad, postLoad));
			Branch(preStore);
			Label(postStore);
			Call<LlvmCallbacks.SvcDelegate>(nameof(LlvmCallbacks.Svc), Const(svc));
			Branch(preLoad);
			Label(postLoad);
		}

		public static void CallLogStore(LlvmRuntimeValue<ulong> tstr, LlvmRuntimeValue<ulong> address) =>
			Instance.Call<LlvmCallbacks.LogStoreDelegate>(nameof(LlvmCallbacks.LogStore), tstr, address);
		public static void CallLogLoad(LlvmRuntimeValue<ulong> tstr, LlvmRuntimeValue<ulong> address) =>
			Instance.Call<LlvmCallbacks.LogLoadDelegate>(nameof(LlvmCallbacks.LogLoad), tstr, address);

		LlvmRuntimeValue<T> SignExtRuntime<T>(LlvmRuntimeValue<ulong> value, int size) where T : struct =>
			new LlvmRuntimeValue<T>(() =>
				LLVM.BuildSExt(Builder, LLVM.BuildTrunc(Builder, value, LLVMTypeRef.IntType((uint) size), ""),
					LlvmType<T>(), ""));

		LlvmRuntimeValue<uint> CallCountLeadingZeros(LlvmRuntimeValue<uint> value) =>
			new LlvmRuntimeValue<uint>(() => Intrinsic<Func<uint, bool, uint>>("llvm.ctlz.i32", value, Const(false)));
		LlvmRuntimeValue<ulong> CallCountLeadingZeros(LlvmRuntimeValue<ulong> value) =>
			new LlvmRuntimeValue<ulong>(() => Intrinsic<Func<ulong, bool, ulong>>("llvm.ctlz.i64", value, Const(false)));

		LlvmRuntimeValue<uint> CallReverseBits(LlvmRuntimeValue<uint> value) =>
			new LlvmRuntimeValue<uint>(() => Intrinsic<Func<uint, uint>>("llvm.bitreverse.i32", value));
		LlvmRuntimeValue<ulong> CallReverseBits(LlvmRuntimeValue<ulong> value) =>
			new LlvmRuntimeValue<ulong>(() => Intrinsic<Func<ulong, ulong>>("llvm.bitreverse.i64", value));

		LlvmRuntimeValue<ulong> CallSR(uint op0, uint op1, uint crn, uint crm, uint op2) =>
			new LlvmRuntimeValue<ulong>(() => Call<LlvmCallbacks.GetSRDelegate>(nameof(LlvmCallbacks.GetSR),
				CpuStateRef, Const(op0), Const(op1), Const(crn), Const(crm), Const(op2)));
		void CallSR(uint op0, uint op1, uint crn, uint crm, uint op2, LlvmRuntimeValue<ulong> value) =>
			Call<LlvmCallbacks.SetSRDelegate>(nameof(LlvmCallbacks.SetSR), Const(op0), Const(op1), Const(crn),
				Const(crm), Const(op2), value);

		LlvmRuntimeValue<Vector128<float>> CallVectorCountBits(LlvmRuntimeValue<Vector128<float>> vec, long elems) =>
			new LlvmRuntimeValue<byte>(() => {
				var ret = Intrinsic<Func<Vector128<byte>, Vector128<byte>>>("llvm.ctpop.v16i8",
					vec.Cast<Vector128<byte>>().Emit());
				if(elems == 16)
					return ret;
				var mask = LLVM.GetUndef(LLVMTypeRef.VectorType(LlvmType<int>(), 16));
				for(var i = 0; i < elems; ++i)
					mask = LLVM.BuildInsertElement(Builder, mask, Const(i < elems ? i : 16), Const(i), "");
				return LLVM.BuildShuffleVector(Builder, ret, LlvmRuntimeValue<Vector128<byte>>.Zero(), mask, "");
			}).Cast<Vector128<float>>();

		LlvmRuntimeValue<ulong> CallVectorSumUnsigned(LlvmRuntimeValue<Vector128<float>> vec, long esize, long count) =>
			new LlvmRuntimeValue<ulong>(() => {
				var svec = esize switch {
					8 => vec.Cast<Vector128<byte>>().Emit(),
					16 => vec.Cast<Vector128<ushort>>().Emit(),
					32 => vec.Cast<Vector128<uint>>().Emit(),
					64 => vec.Cast<Vector128<ulong>>().Emit(),
					_ => throw new NotSupportedException($"Summation of vector of {esize} elements")
				};
				return Enumerable.Range(0, (int) count)
					.Select(i => LLVM.BuildExtractElement(Builder, svec, Const(i), ""))
					.Select(e => esize == 64 ? e : LLVM.BuildZExt(Builder, e, LlvmType<ulong>(), ""))
					.Aggregate((a, b) => LLVM.BuildAdd(Builder, a, b, ""));
			});

		LlvmRuntimeValue<Vector128<float>> CallVectorExtract(LlvmRuntimeValue<Vector128<float>> a, LlvmRuntimeValue<Vector128<float>> b, uint q, uint index) =>
			new LlvmRuntimeValue<Vector128<byte>>(() => {
				var avec = a.Cast<Vector128<byte>>().Emit();
				var bvec = b.Cast<Vector128<byte>>().Emit();
				var count = q == 0 ? 8 : 16;
				var mask = LLVM.GetUndef(LLVMTypeRef.VectorType(LlvmType<int>(), 16));
				for(var i = 0; i < 16; ++i)
					if(count == 16 || i + index < 8)
						mask = LLVM.BuildInsertElement(Builder, mask, Const((int) (i + index)), Const(i), "");
					else
						mask = LLVM.BuildInsertElement(Builder, mask, Const((int) (i + index + 8)), Const(i), "");
				var ovec = LLVM.BuildShuffleVector(Builder, avec, bvec, mask, "");
				if(count == 16)
					return ovec;
				mask = LLVM.GetUndef(LLVMTypeRef.VectorType(LlvmType<int>(), 16));
				for(var i = 0; i < 16; ++i)
					mask = LLVM.BuildInsertElement(Builder, mask, Const(i < 8 ? i : 16), Const(i), "");
				return LLVM.BuildShuffleVector(Builder, ovec, LlvmRuntimeValue<Vector128<byte>>.Zero(), mask, "");
			}).Cast<Vector128<float>>();

		LlvmRuntimeValue<uint> CallFloatToFixed32(LlvmRuntimeValue<float> value, ulong fbits) =>
			new LlvmRuntimeValue<float>(() =>
					Intrinsic<Func<float, float>>("roundf", value * Const((float) (1L << (int) fbits)))).Cast<int>()
				.Cast<uint>();
		LlvmRuntimeValue<uint> CallFloatToFixed32(LlvmRuntimeValue<double> value, ulong fbits) =>
			new LlvmRuntimeValue<double>(() =>
					Intrinsic<Func<double, double>>("round", value * Const((double) (1L << (int) fbits)))).Cast<int>()
				.Cast<uint>();
		LlvmRuntimeValue<ulong> CallFloatToFixed64(LlvmRuntimeValue<float> value, ulong fbits) =>
			new LlvmRuntimeValue<float>(() =>
					Intrinsic<Func<float, float>>("roundf", value * Const((float) (1L << (int) fbits)))).Cast<long>()
				.Cast<ulong>();
		LlvmRuntimeValue<ulong> CallFloatToFixed64(LlvmRuntimeValue<double> value, ulong fbits) =>
			new LlvmRuntimeValue<double>(() =>
					Intrinsic<Func<double, double>>("round", value * Const((double) (1L << (int) fbits)))).Cast<long>()
				.Cast<ulong>();
		
		void CallFloatCompare(LlvmRuntimeValue<float> operand1, LlvmRuntimeValue<float> operand2) =>
			throw new NotImplementedException();
		void CallFloatCompare(LlvmRuntimeValue<double> operand1, LlvmRuntimeValue<double> operand2) =>
			throw new NotImplementedException();

		LlvmRuntimeValue<byte>
			CallCompareAndSwap<T>(LlvmRuntimePointer<T> ptr, LlvmRuntimeValue<T> value,
				LlvmRuntimeValue<T> comparand) where T : struct => new LlvmRuntimeValue<byte>(
			() => LLVM.BuildSelect(Builder,
				LLVM.BuildExtractValue(Builder,
					LLVM.BuildAtomicCmpXchg(Builder, ptr.Address, comparand, value,
						LLVMAtomicOrdering.LLVMAtomicOrderingMonotonic,
						LLVMAtomicOrdering.LLVMAtomicOrderingMonotonic,
						false), 1, ""), Const((byte) 0), Const((byte) 1), ""));
	}
}