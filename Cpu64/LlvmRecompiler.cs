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
using PrettyPrinter;
using UltimateOrb;

namespace Cpu64 {
	public static class LlvmExtensions {
		public static LLVMTypeRef ToLLVMType(this Type type) {
			if(type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Vector128<>)) {
				var et = type.GetGenericArguments()[0];
				return LLVMTypeRef.CreateVector(et.ToLLVMType(), 16U / (uint) Marshal.SizeOf(et));
			}
			if(typeof(MulticastDelegate).IsAssignableFrom(type)) {
				var mi = type.GetMethod("Invoke");
				return LLVMTypeRef.CreateFunction(mi.ReturnType.ToLLVMType(),
					mi.GetParameters().Select(x => x.ParameterType.ToLLVMType()).ToArray(), false);
			}
			if(type == typeof(void))
				return LLVMTypeRef.Void;
			if(type.IsPointer) return LLVMTypeRef.Int64;
			switch(Activator.CreateInstance(type)) {
				case sbyte _: case byte _: return LLVMTypeRef.Int8;
				case short _: case ushort _: return LLVMTypeRef.Int16;
				case int _: case uint _: return LLVMTypeRef.Int32;
				case long _: case ulong _: return LLVMTypeRef.Int64;
				case Int128 _: case UInt128 _: return LLVMTypeRef.CreateInt(128);
				case float _: return LLVMTypeRef.Float;
				case double _: return LLVMTypeRef.Double;
				case bool _: return LLVMTypeRef.Int1;
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

		public delegate void CheckPointerDelegate(ulong addr);
		public ulong CheckPointer;
	}

	public unsafe partial class LlvmRecompiler : BaseCpu {
		public static LLVMTypeRef LlvmType<T>() => typeof(T).ToLLVMType();

		public class BlockContext : ICloneable {
			public ulong? LR;

			public object Clone() => MemberwiseClone();
			public BlockContext Copy() => (BlockContext) MemberwiseClone();
			public BlockContext CopyWith(Action<BlockContext> func) {
				var copy = Copy();
				func(copy);
				return copy;
			}
		}
		
		public class LlvmLocal<T> where T : struct {
			readonly LLVMValueRef Pointer;
			public LlvmLocal(string name = "") => Pointer = Builder.BuildAlloca(LlvmType<T>(), name);
			public LlvmRuntimeValue<T> Value {
				get => new LlvmRuntimeValue<T>(() => Builder.BuildLoad(Pointer, ""));
				set => Builder.BuildStore(value, Pointer);
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
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<ulong>(), 0), "");
					return Builder.BuildLoad(ptr, $"X{reg}_");*/
					return Recompiler.RegisterLocals[reg].Value;
				});
				set {
					if(reg == 31) {
						value.Emit();
						return;
					}
					Recompiler.RegistersUsed[reg] = true;
					/*var addr = Recompiler.FieldAddress(nameof(CpuState.X0)) + (ulong) (reg * 8);
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<ulong>(), 0), $"X{reg}_");
					Builder.BuildStore(value, ptr);*/
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
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<Vector128<float>>(), 0), "");
					return Builder.BuildLoad(ptr, $"V{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<Vector128<float>>(), 0), $"V{reg}_");
					Builder.BuildStore(value, ptr);
				}
			}
		}

		public class LlvmVectorByteMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorByteMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<byte> this[int reg] {
				get => new LlvmRuntimeValue<Vector128<byte>>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<byte>(), 0), "");
					return Builder.BuildLoad(ptr, $"B{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<byte>>();
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(type, 0), $"B{reg}_");
					var bvec = Builder.BuildInsertElement(LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					for(var i = 1; i < 16; ++i)
						bvec = Builder.BuildInsertElement(bvec, Recompiler.Const((byte) 0), Recompiler.Const(i), "");
					Builder.BuildStore(bvec, ptr);
				}
			}
		}

		public class LlvmVectorHalfMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorHalfMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<ushort> this[int reg] {
				get => new LlvmRuntimeValue<ushort>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<ushort>(), 0), "");
					return Builder.BuildLoad(ptr, $"H{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<ushort>>();
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(type, 0), $"H{reg}_");
					var bvec = Builder.BuildInsertElement(LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					for(var i = 1; i < 8; ++i)
						bvec = Builder.BuildInsertElement(bvec, Recompiler.Const((ushort) 0), Recompiler.Const(i), "");
					Builder.BuildStore(bvec, ptr);
				}
			}
		}

		public class LlvmVectorFloatMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorFloatMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<float> this[int reg] {
				get => new LlvmRuntimeValue<ushort>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<float>(), 0), "");
					return Builder.BuildLoad(ptr, $"S{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<float>>();
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(type, 0), $"S{reg}_");
					var bvec = Builder.BuildInsertElement(LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					for(var i = 1; i < 4; ++i)
						bvec = Builder.BuildInsertElement(bvec, Recompiler.Const(0f), Recompiler.Const(i), "");
					Builder.BuildStore(bvec, ptr);
				}
			}
		}

		public class LlvmVectorDoubleMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorDoubleMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<double> this[int reg] {
				get => new LlvmRuntimeValue<double>(() => {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(LlvmType<double>(), 0), "");
					return Builder.BuildLoad(ptr, $"D{reg}_");
				});
				set {
					var addr = Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16);
					var type = LlvmType<Vector128<double>>();
					var ptr = Builder.BuildIntToPtr(addr, LLVMTypeRef.CreatePointer(type, 0), $"D{reg}_");
					var bvec = Builder.BuildInsertElement(LLVM.GetUndef(type), value, Recompiler.Const(0), "");
					bvec = Builder.BuildInsertElement(bvec, Recompiler.Const(0d), Recompiler.Const(1), "");
					Builder.BuildStore(bvec, ptr);
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

		public LlvmRuntimeValue<byte> Exclusive8R {
			get => Field<byte>(nameof(CpuState.Exclusive8));
			set => Field(nameof(CpuState.Exclusive8), value);
		}
		public LlvmRuntimeValue<ushort> Exclusive16R {
			get => Field<ushort>(nameof(CpuState.Exclusive16));
			set => Field(nameof(CpuState.Exclusive16), value);
		}
		public LlvmRuntimeValue<uint> Exclusive32R {
			get => Field<uint>(nameof(CpuState.Exclusive32));
			set => Field(nameof(CpuState.Exclusive32), value);
		}
		public LlvmRuntimeValue<ulong> Exclusive64R {
			get => Field<ulong>(nameof(CpuState.Exclusive64));
			set => Field(nameof(CpuState.Exclusive64), value);
		}

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

		public LlvmRuntimeValue<byte> DebuggingR =>
			new LlvmRuntimePointer<byte>(FieldAddress(nameof(CpuState.Debugging)), safe: true, @volatile: true);

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
		Queue<(BlockContext, ulong)> BlocksNeeded;
		bool[] RegistersUsed;
		LlvmLocal<ulong>[] RegisterLocals;
		List<(LlvmLabel Before, LlvmLabel After)> LoadRegistersLabels;
		List<(LlvmLabel Before, LlvmLabel After)> StoreRegistersLabels;
		bool JustBranched;
		LlvmLabel SuppressedBranch;
		List<LlvmLabel> UsedLabels;
		LLVMBasicBlockRef CurrentBlock;
		ulong CurrentPC;
		BlockContext Context;

		internal static bool CallbacksInitialized;
		internal static readonly LlvmCallbacks* Callbacks =
			(LlvmCallbacks*) Marshal.AllocHGlobal(Marshal.SizeOf<LlvmCallbacks>());

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

			var options = new LLVMMCJITCompilerOptions { NoFramePointerElim = 1 };
			LLVM.InitializeMCJITCompilerOptions(&options, (UIntPtr) Marshal.SizeOf<LLVMMCJITCompilerOptions>());
			
		}

		class LlvmException : Exception {
			public LlvmException(string msg) : base(msg) {}
		}
		delegate void BailoutDel(string a, string b, int c, string d);
		static void Bailout(string func, string file, int line, string message) =>
			throw new LlvmException($"Assertion failed in `{func}` ({file}:{line}):  {message}");

		public LlvmRecompiler(IKernel kernel) : base(kernel) {
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

			if(CallbacksInitialized) return;
			CallbacksInitialized = true;
			Callbacks->Svc = FunctionPtr<LlvmCallbacks.SvcDelegate>(svc => Kernel.Svc((int) svc));
			Callbacks->GetSR = FunctionPtr<LlvmCallbacks.GetSRDelegate>((state, op0, op1, crn, crm, op2) => {
				var reg = ((0b10 | op0) << 14) | (op1 << 11) | (crn << 7) | (crm << 3) | op2;
				if(reg == 0b11_011_1101_0000_011) // TPIDR
					return state->TlsBase;
				return SR(op0, op1, crn, crm, op2);
			});
			Callbacks->SetSR = FunctionPtr<LlvmCallbacks.SetSRDelegate>(SR);

			Callbacks->CheckPointer = FunctionPtr<LlvmCallbacks.CheckPointerDelegate>(Kernel.CheckPointer);

			Callbacks->Debug = FunctionPtr<LlvmCallbacks.DebugDelegate>(Kernel.DebugWait);
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
			Module = LLVMModuleRef.CreateWithName("SupercellNXLLVM");
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
			LLVM.AddPartiallyInlineLibCallsPass(PassManager);
			LLVM.InitializeFunctionPassManager(PassManager);

			Function = Module.AddFunction($"_{block.Addr:X}", LlvmType<Action<ulong, ulong>>());
			LLVM.SetLinkage(Function, LLVMLinkage.LLVMExternalLinkage);

			UsedLabels = new List<LlvmLabel>();
			
			Builder.PositionAtEnd(Function.AppendBasicBlock("entrypoint"));

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
			BlocksNeeded = new Queue<(BlockContext, ulong)>();
			BlocksNeeded.Enqueue((new BlockContext(), block.Addr));
			var blockCount = 0;
			var recompiled = new HashSet<ulong>();
			var topFirst = true;
			void CompileOneBlock(BlockContext context, ulong pc) {
				blockCount++;
				if(recompiled.Contains(pc))
					return;

				Context = context;
				var first = true;
				Branched = false;
				while(!Branched) {
					CurrentPC = pc;
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
#if GDB
					var preDebug = DefineLabel();
					var postDebug = DefineLabel();
					BranchIf(DebuggingR, preDebug, postDebug);
					Label(preDebug);
					LlvmLabel preStore = DefineLabel("preSvcStore_"), postStore = DefineLabel("postSvcStore_");
					LlvmLabel preLoad = DefineLabel("preSvcLoad_"), postLoad = DefineLabel("postSvcLoad_");
					StoreRegistersLabels.Add((preStore, postStore));
					LoadRegistersLabels.Add((preLoad, postLoad));
					Branch(preStore);
					Label(postStore);
					Call<LlvmCallbacks.DebugDelegate>(nameof(LlvmCallbacks.Debug));
					Branch(preLoad);
					Label(postLoad);
					Branch(postDebug);
					Label(postDebug);
#endif
					if(!Recompile(*(uint*) pc, pc)) {
						Kernel.Kill();
						throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
					}

					pc += 4;
				}
			}
			
			while(BlocksNeeded.TryDequeue(out var cpc))
				CompileOneBlock(cpc.Item1, cpc.Item2);

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
			if(Function.VerifyFunction(LLVMVerifierFailureAction.LLVMReturnStatusAction))
				throw new Exception("Program verification failed");
			LLVM.RunFunctionPassManager(PassManager, Function);
			//LLVM.DumpValue(Function);
			
			if(Module.TryCreateExecutionEngine(out ExecutionEngine, out var errorMessage))
				throw new Exception(errorMessage);

			sbyte* errMsg;
			LLVMOpaqueMemoryBuffer* memBuf;
			if(LLVM.TargetMachineEmitToMemoryBuffer(LLVM.GetExecutionEngineTargetMachine(ExecutionEngine), Module,
				LLVMCodeGenFileType.LLVMObjectFile, &errMsg, &memBuf) != 1)
				throw new LlvmException(Marshal.PtrToStringAuto((IntPtr) errMsg));

			var outCode = new byte[(uint) LLVM.GetBufferSize(memBuf)];
			Marshal.Copy((IntPtr) LLVM.GetBufferStart(memBuf), outCode, 0, outCode.Length);
			block.ObjectCode = outCode;

			var tfunc = Marshal.GetDelegateForFunctionPointer<LlvmBlockFunc>(ExecutionEngine.GetPointerToGlobal(Function));
			block.Func = (state, _) => tfunc(state, Callbacks);
		}

		public LLVMValueRef Intrinsic<T>(string name, params LLVMValueRef[] args) {
			var func = Module.GetNamedFunction(name);
			func = func.Pointer == IntPtr.Zero ? Module.AddFunction(name, LlvmType<T>()) : func;
			return Builder.BuildCall(func, args, "");
		}

		public void Emitted() => JustBranched = false;
		
		public LlvmRuntimeValue<ulong> CpuStateRef => new LlvmRuntimeValue<ulong>(() => LLVM.GetParam(Function, 0));
		public LlvmRuntimeValue<ulong> CallbacksRef => new LlvmRuntimeValue<ulong>(() => LLVM.GetParam(Function, 1));

		public LlvmRuntimeValue<T> Field<T>(string name) where T : struct =>
			new LlvmRuntimePointer<T>(FieldAddress(name), safe: true);
		public void Field<T>(string name, LlvmRuntimeValue<T> value) where T : struct =>
			new LlvmRuntimePointer<T>(FieldAddress(name), safe: true).Value = value;
		public LlvmRuntimeValue<ulong> FieldAddress(string name) =>
			CpuStateRef + (ulong) Marshal.OffsetOf<CpuState>(name);
		
		public LlvmRuntimeValue<T> Const<T>(T value) where T : struct => new LlvmRuntimeValue<T>(() => {
			unchecked {
				switch(value) {
					case sbyte v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int8, (ulong) v, false);
					case byte v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int8, v, false);
					case short v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int16, (ulong) v, false);
					case ushort v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int16, v, false);
					case int v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, (ulong) v, false);
					case uint v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, v, false);
					case long v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int64, (ulong) v, false);
					case ulong v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int64, v, false);
					case Int128 v:
						Debug.Assert(v >= 0 && (v >> 64) == 0);
						return LLVMValueRef.CreateConstInt(LLVMTypeRef.CreateInt(128), (ulong) v, false);
					case UInt128 v:
						Debug.Assert(v >= 0 && (v >> 64) == 0);
						return LLVMValueRef.CreateConstInt(LLVMTypeRef.CreateInt(128), (ulong) v, false);
					case float v:
						return Builder.BuildBitCast(LLVMValueRef.CreateConstInt(LLVMTypeRef.Int32, *(uint*) &v, false), LLVMTypeRef.Float, "");
					case double v:
						return Builder.BuildBitCast(
							LLVMValueRef.CreateConstInt(LLVMTypeRef.Int64, *(ulong*) &v, false), LLVMTypeRef.Double, "");
					case bool v: return LLVMValueRef.CreateConstInt(LLVMTypeRef.Int1, v ? 1UL : 0, false);
					default: throw new NotImplementedException(typeof(T).Name);
				}
			}
		});
		
		public LlvmLocal<T> DeclareLocal<T>() where T : struct => new LlvmLocal<T>();

		public LlvmLabel DefineLabel(string name = "") => new LlvmLabel(() => Function.AppendBasicBlock(name));
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
				Builder.BuildBr(label);
				UsedLabels.Add(label);
			} else
				SuppressedBranch = label;
			JustBranched = true;
		}

		void WithLink(Action func) {
			var next = CurrentPC + 4;
			XR[30] = next;
			// Handle RTLD case where the next instruction after branch is bad
			if(Disassemble(*(uint*) next, next) == null) {
				func();
				return;
			}
			if(!BlockLabels.TryGetValue(next, out _)) {
				BlockLabels[next] = DefineLabel($"_{next:X}");
				BlocksNeeded.Enqueue((Context, next));
			}

			var old = Context;
			Context = old.CopyWith(x => x.LR = next);
			func();
			Context = old;
		}
		
		void Branch(ulong target) {
			/*Field(nameof(CpuState.BranchTo), Const(target));
			Branch(StoreRegistersLabel);
			Branched = true;*/
			
			if(!BlockLabels.TryGetValue(target, out var label)) {
				label = BlockLabels[target] = DefineLabel($"_{target:X}");
				BlocksNeeded.Enqueue((Context, target));
			}
			Branch(label);
			Branched = true;
		}
		void BranchLinked(ulong target) => WithLink(() => Branch(target));
		
		void BranchRegister(ulong reg) {
			void Base() {
				var target = XR[(int) reg];
				Field(nameof(CpuState.BranchTo), target);
				Branch(StoreRegistersLabels[0].Before);
				Branched = true;
			}
			if(reg != 30 || Context.LR == null) {
				Base();
				return;
			}

			var if_ = DefineLabel();
			var else_ = DefineLabel();
			BranchIf(XR[30] == Context.LR.Value, if_, else_);
			
			Label(if_);
			Branch(Context.LR.Value);
			
			Label(else_);
			Base();
		}
		void BranchLinkedRegister(ulong target) => WithLink(() => BranchRegister(target));

		void BranchIf(LlvmRuntimeValue<byte> cond, LlvmLabel if_label, LlvmLabel else_label) {
			if(!JustBranched) {
				UsedLabels.Add(if_label);
				UsedLabels.Add(else_label);
				Builder.BuildCondBr(
					Builder.BuildICmp(LLVMIntPredicate.LLVMIntNE, cond, Const((byte) 0), ""), if_label, else_label);
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
				var phi = Builder.BuildPhi(LlvmType<ValueT>(), "");
				phi.AddIncoming(new[] { av, bv }, new[] { ab, bb }, 2);
				return phi;
			});

		LLVMValueRef Call<DelegateT>(string name, params LLVMValueRef[] args) {
			var offset = Marshal.OffsetOf<LlvmCallbacks>(name);
			var dt = typeof(DelegateT);
			Debug.Assert(typeof(MulticastDelegate).IsAssignableFrom(dt));
			var mi = dt.GetMethod("Invoke");
			var ft = LLVMTypeRef.CreatePointer(LLVMTypeRef.CreateFunction(mi.ReturnType.ToLLVMType(),
				mi.GetParameters().Select(x => x.ParameterType.ToLLVMType()).ToArray(), false), 0);
			return Builder.BuildCall(
				Builder.BuildIntToPtr(
					Builder.BuildLoad(
						Builder.BuildIntToPtr(CallbacksRef + Const((ulong) offset),
							LLVMTypeRef.CreatePointer(LLVMTypeRef.Int64, 0), ""), ""), ft, ""), args, "");
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

		public static void CallCheckPointer(LlvmRuntimeValue<ulong> address) =>
			Instance.Call<LlvmCallbacks.CheckPointerDelegate>(nameof(LlvmCallbacks.CheckPointer), address);

		LlvmRuntimeValue<T> SignExtRuntime<T>(LlvmRuntimeValue<ulong> value, int size) where T : struct =>
			new LlvmRuntimeValue<T>(() =>
				Builder.BuildSExt(Builder.BuildTrunc(value, LLVMTypeRef.CreateInt((uint) size), ""),
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
				var mask = LLVM.GetUndef(LLVMTypeRef.CreateVector(LlvmType<int>(), 16));
				for(var i = 0; i < elems; ++i)
					mask = Builder.BuildInsertElement(mask, Const(i < elems ? i : 16), Const(i), "");
				return Builder.BuildShuffleVector(ret, LlvmRuntimeValue<Vector128<byte>>.Zero(), mask, "");
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
					.Select(i => Builder.BuildExtractElement(svec, Const(i), ""))
					.Select(e => esize == 64 ? e : Builder.BuildZExt(e, LlvmType<ulong>(), ""))
					.Aggregate((a, b) => Builder.BuildAdd(a, b, ""));
			});

		LlvmRuntimeValue<Vector128<float>> CallVectorExtract(LlvmRuntimeValue<Vector128<float>> a, LlvmRuntimeValue<Vector128<float>> b, uint q, uint index) =>
			new LlvmRuntimeValue<Vector128<byte>>(() => {
				var avec = a.Cast<Vector128<byte>>().Emit();
				var bvec = b.Cast<Vector128<byte>>().Emit();
				var count = q == 0 ? 8 : 16;
				var mask = LLVM.GetUndef(LLVMTypeRef.CreateVector(LlvmType<int>(), 16));
				for(var i = 0; i < 16; ++i)
					if(count == 16 || i + index < 8)
						mask = Builder.BuildInsertElement(mask, Const((int) (i + index)), Const(i), "");
					else
						mask = Builder.BuildInsertElement(mask, Const((int) (i + index + 8)), Const(i), "");
				var ovec = Builder.BuildShuffleVector(avec, bvec, mask, "");
				if(count == 16)
					return ovec;
				mask = LLVM.GetUndef(LLVMTypeRef.CreateVector(LlvmType<int>(), 16));
				for(var i = 0; i < 16; ++i)
					mask = Builder.BuildInsertElement(mask, Const(i < 8 ? i : 16), Const(i), "");
				return Builder.BuildShuffleVector(ovec, LlvmRuntimeValue<Vector128<byte>>.Zero(), mask, "");
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
			() => Builder.BuildSelect(
				Builder.BuildExtractValue(
					Builder.BuildAtomicCmpXchg(ptr.Pointer, comparand, value,
						LLVMAtomicOrdering.LLVMAtomicOrderingSequentiallyConsistent,
						LLVMAtomicOrdering.LLVMAtomicOrderingSequentiallyConsistent,
						false), 1, ""), Const((byte) 0), Const((byte) 1), ""));
	}
}