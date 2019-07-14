using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			if(type == typeof(void))
				return LLVMTypeRef.VoidType();
			switch(Activator.CreateInstance(type)) {
				case sbyte _: case byte _: return LLVMTypeRef.Int8Type();
				case short _: case ushort _: return LLVMTypeRef.Int16Type();
				case int _: case uint _: return LLVMTypeRef.Int32Type();
				case long _: case ulong _: return LLVMTypeRef.Int64Type();
				case Int128 _: case UInt128 _: return LLVMTypeRef.IntType(128);
				case float _: return LLVMTypeRef.FloatType();
				case double _: return LLVMTypeRef.DoubleType();
				default: throw new NotSupportedException(type.Name);
			}
		}
	}
	
	public class LlvmLabel {
		LLVMBasicBlockRef? Block;
		public readonly Func<LLVMBasicBlockRef> LazyBlock;
		public LlvmLabel(LLVMBasicBlockRef block) => Block = block;
		public LlvmLabel(Func<LLVMBasicBlockRef> block) => LazyBlock = block;
		public static implicit operator LLVMBasicBlockRef(LlvmLabel label) => label.Block ?? (label.Block = label.LazyBlock()).Value;
	}

	public class LlvmLocal<T> {
		readonly LLVMValueRef Pointer;
		public LlvmLocal() => Pointer = LLVM.BuildAlloca(LlvmRecompiler.Builder, typeof(T).ToLLVMType(), "");
		public LlvmRuntimeValue<T> Value {
			get => new LlvmRuntimeValue<T>(() => LLVM.BuildLoad(LlvmRecompiler.Builder, Pointer, ""));
			set => LLVM.BuildStore(LlvmRecompiler.Builder, value, Pointer);
		}

		public static implicit operator LlvmRuntimeValue<T>(LlvmLocal<T> local) => local.Value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct LlvmCallbacks {
		public delegate void SvcDelegate(uint svc);
		public ulong Svc;
	}

	public unsafe partial class LlvmRecompiler : BaseCpu {
		public class LlvmRegisterMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmRegisterMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<ulong> this[int reg] {
				get => new LlvmRuntimePointer<ulong>(Recompiler.FieldAddress(nameof(CpuState.X0)) + (ulong) (reg * 8))
					.Value;
				set => new LlvmRuntimePointer<ulong>(Recompiler.FieldAddress(nameof(CpuState.X0)) + (ulong) (reg * 8))
					.Value = value;
			}
		}

		public class LlvmVectorMap {
			readonly LlvmRecompiler Recompiler;
			public LlvmVectorMap(LlvmRecompiler recompiler) => Recompiler = recompiler;
			public LlvmRuntimeValue<Vector128<float>> this[int reg] {
				get => new LlvmRuntimePointer<Vector128<float>>(
						Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16))
					.Value;
				set => new LlvmRuntimePointer<Vector128<float>>(
						Recompiler.FieldAddress(nameof(CpuState.V0)) + (ulong) (reg * 16))
					.Value = value;
			}
		}

		static readonly ThreadLocal<LlvmRecompiler> TlsInstance = new ThreadLocal<LlvmRecompiler>();
		public static LlvmRecompiler Instance {
			get => TlsInstance.Value;
			set => TlsInstance.Value = value;
		}

		public LlvmRuntimeValue<ulong> SPR {
			get => Field<ulong>(nameof(CpuState.SP));
			set => Field<ulong>(nameof(CpuState.SP), value);
		}
		public readonly LlvmRegisterMap XR;
		public readonly LlvmVectorMap VR;
		public LlvmRuntimeValue<byte>[] VBR;
		public LlvmRuntimeValue<ushort>[] VHR;
		public LlvmRuntimeValue<float>[] VSR;
		public LlvmRuntimeValue<double>[] VDR;

		public LlvmRuntimeValue<byte> Exclusive8R;
		public LlvmRuntimeValue<ushort> Exclusive16R;
		public LlvmRuntimeValue<uint> Exclusive32R;
		public LlvmRuntimeValue<ulong> Exclusive64R;

		public LlvmRuntimeValue<ulong> NZCVR {
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}
		public LlvmRuntimeValue<ulong> NZCV_NR {
			get => Field<ulong>(nameof(CpuState.NZCV_N));
			set => Field<ulong>(nameof(CpuState.NZCV_N), value);
		}
		public LlvmRuntimeValue<ulong> NZCV_ZR {
			get => Field<ulong>(nameof(CpuState.NZCV_Z));
			set => Field<ulong>(nameof(CpuState.NZCV_Z), value);
		}
		public LlvmRuntimeValue<ulong> NZCV_CR {
			get => Field<ulong>(nameof(CpuState.NZCV_C));
			set => Field<ulong>(nameof(CpuState.NZCV_C), value);
		}
		public LlvmRuntimeValue<ulong> NZCV_VR {
			get => Field<ulong>(nameof(CpuState.NZCV_V));
			set => Field<ulong>(nameof(CpuState.NZCV_V), value);
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
		ulong BlockStart, CurPc;
		Dictionary<ulong, LlvmLabel> BlockLabels;
		Queue<ulong> BlocksNeeded;
		bool[] RegistersUsed;
		LlvmLocal<ulong>[] RegisterLocals;
		LlvmLabel StoreRegistersLabel;
		bool JustBranched;
		LlvmLabel SuppressedBranch;
		List<LlvmLabel> UsedLabels;

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
			var mod = dlopen("/Users/cody/projects/SupercellNx/App/bin/Debug/netcoreapp3.0/runtimes/osx/native/libLLVM.dylib", 1);
			Debug.Assert(mod != 0);
			var init = dlsym(unchecked((long) mod), "LLVMInitializeX86Target");
			Debug.Assert(init != 0);
			var tgt = init - 0x208f270 + 0x2d1df30;
			mprotect(tgt & ~0xFFFUL, 0x1000, 0x7);
			*(ulong*) tgt = (ulong) Marshal.GetFunctionPointerForDelegate<BailoutDel>(Bailout);
			
			Instance = this;
			XR = new LlvmRegisterMap(this);
			VR = new LlvmVectorMap(this);

			Callbacks = (LlvmCallbacks*) Marshal.AllocHGlobal(Marshal.SizeOf<LlvmCallbacks>());
			Callbacks->Svc = FunctionPtr<LlvmCallbacks.SvcDelegate>(svc => Kernel.Svc((int) svc));
		}

		static ulong FunctionPtr<DelegateT>(DelegateT func) {
			GCHandle.Alloc(func); // TODO: Delete this when the recompiler is destroyed
			return (ulong) Marshal.GetFunctionPointerForDelegate(func);
		}

		public override void Run(ulong pc, ulong sp, bool one = false) {
			State->SP = sp;
			while(true) {
				var block = CacheManager.GetBlock(pc);
				if(block.Func == null)
					lock(block)
						if(block.Func == null)
							RecompileMultiple(block);

				State->BranchTo = unchecked((ulong) -1);
				Debug.Assert(block.Func != null);
				DebugRegs();
				block.Func(State, this);
				
				if(!one && (State->SP < 0x100000 || State->SP >> 48 != 0))
					throw new Exception($"SP likely corrupted by block {State->PC:X}: SP == 0x{State->SP:X}");
				State->PC = pc = State->BranchTo;
				if(one)
					break;
				Debug.Assert((pc & 3) == 0);
			}
		}

		public void RecompileMultiple(Block block) {
			Module = LLVM.ModuleCreateWithName("SupercellNXLLVM");
			Builder = LLVM.CreateBuilder();

			PassManager = LLVM.CreateFunctionPassManagerForModule(Module);
			LLVM.AddInstructionCombiningPass(PassManager);
			LLVM.AddReassociatePass(PassManager);
			LLVM.AddGVNPass(PassManager);
			LLVM.AddCFGSimplificationPass(PassManager);
			LLVM.InitializeFunctionPassManager(PassManager);
			
			Function = LLVM.AddFunction(Module, $"_{block.Addr:X}",
				LLVM.FunctionType(LLVM.VoidType(), new[] { LLVM.Int64Type(), LLVM.Int64Type() }, false));
			LLVM.SetLinkage(Function, LLVMLinkage.LLVMExternalLinkage);

			RegistersUsed = new bool[31];
			//RegisterLocals = Enumerable.Range(0, 31).Select(_ => Ilg.DeclareLocal<ulong>()).ToArray();
			
			UsedLabels = new List<LlvmLabel>();
			
			LLVM.PositionBuilderAtEnd(Builder, LLVM.AppendBasicBlock(Function, "entrypoint"));

			var preRegisterLoad = DefineLabel("preRegisterLoad");
			var postRegisterLoad = DefineLabel("postRegisterLoad");
			Branch(preRegisterLoad);
			Label(postRegisterLoad);
			StoreRegistersLabel = DefineLabel("storeRegisters");
			
			BlockLabels = new Dictionary<ulong, LlvmLabel>();
			BlocksNeeded = new Queue<ulong>();
			BlocksNeeded.Enqueue(block.Addr);
			var blockCount = 0;
			var recompiled = new HashSet<ulong>();
			var topFirst = true;
			void CompileOneBlock(ulong pc) {
				blockCount++;
				if(recompiled.Contains(pc)) {
					Console.WriteLine($"Early bailout for block {blockCount}");
					return;
				}

				var first = true;
				Branched = false;
				while(!Branched) {
					Console.WriteLine($"Recompiling {pc:X}");

					var label = BlockLabels.TryGetValue(pc, out var _label)
						? _label
						: BlockLabels[pc] = DefineLabel($"_{pc:X}");
					if(!first || topFirst)
						Branch(label);
					first = topFirst = false;
					if(recompiled.Contains(pc)) break;
					recompiled.Add(pc);
					Label(label);
					
					//Field<ulong>(nameof(CpuState.PC), pc);
					if(!Recompile(*(uint*) pc, pc))
						throw new NotSupportedException($"Instruction at 0x{pc:X} failed to recompile");
					pc += 4;
				}
			}
			
			while(BlocksNeeded.TryDequeue(out var pc))
				CompileOneBlock(pc);
			
			Label(preRegisterLoad);
			for(var i = 0; i < 31; ++i) {
				if(!RegistersUsed[i]) continue;
				/*FieldAddress(nameof(CpuState.X0)).Emit();
				LoadConstant(i);
				Ilg.LoadElement<ulong>();
				Ilg.StoreLocal(RegisterLocals[i]);*/
			}
			Branch(postRegisterLoad);

			Label(StoreRegistersLabel);
			for(var i = 0; i < 31; ++i) {
				if(!RegistersUsed[i]) continue;
				/*FieldAddress(nameof(CpuState.X0)).Emit();
				Ilg.LoadConstant(i);
				Ilg.LoadLocal(RegisterLocals[i]);
				Ilg.StoreElement<ulong>();*/
			}
			LLVM.BuildRetVoid(Builder);
			
			LLVM.DumpValue(Function);
			LLVM.VerifyFunction(Function, LLVMVerifierFailureAction.LLVMPrintMessageAction);
			if(LLVM.VerifyFunction(Function, LLVMVerifierFailureAction.LLVMReturnStatusAction))
				throw new Exception("Program verification failed");
			LLVM.RunFunctionPassManager(PassManager, Function);
			LLVM.DumpValue(Function);
			
			if(LLVM.CreateExecutionEngineForModule(out ExecutionEngine, Module, out var errorMessage).Value == 1)
				throw new Exception(errorMessage);
			
			var tfunc = Marshal.GetDelegateForFunctionPointer<LlvmBlockFunc>(LLVM.GetPointerToGlobal(ExecutionEngine, Function));
			block.Func = (state, _) => tfunc(state, Callbacks);
		}

		public void Emitted() => JustBranched = false;
		
		public LlvmRuntimeValue<ulong> CpuStateRef => new LlvmRuntimeValue<ulong>(() => LLVM.GetParam(Function, 0));
		public LlvmRuntimeValue<ulong> CallbacksRef => new LlvmRuntimeValue<ulong>(() => LLVM.GetParam(Function, 1));
		
		public LlvmRuntimeValue<T> Field<T>(string name) => new LlvmRuntimePointer<T>(FieldAddress(name));
		public void Field<T>(string name, LlvmRuntimeValue<T> value) =>
			new LlvmRuntimePointer<T>(FieldAddress(name)).Value = value;
		public LlvmRuntimeValue<ulong> FieldAddress(string name) =>
			CpuStateRef + (ulong) Marshal.OffsetOf<CpuState>(name);
		
		public LlvmRuntimeValue<T> Const<T>(T value) => new LlvmRuntimeValue<T>(() => {
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
					default: throw new NotImplementedException(typeof(T).Name);
				}
			}
		});
		
		public LlvmLocal<T> DeclareLocal<T>() => new LlvmLocal<T>();

		public LlvmLabel DefineLabel(string name = "") => new LlvmLabel(() => LLVM.AppendBasicBlock(Function, name));
		public void Label(LlvmLabel label) {
			if(JustBranched && SuppressedBranch == label && !UsedLabels.Contains(label)) {
				JustBranched = false;
				return;
			}
			JustBranched = false;
			LLVM.PositionBuilderAtEnd(Builder, label);
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
			Field(nameof(CpuState.BranchTo), Const(target));
			Branch(StoreRegistersLabel);
			Branched = true;
			/*if(!BlockLabels.TryGetValue(target, out var label)) {
				label = BlockLabels[target] = DefineLabel($"_{target:X}");
				BlocksNeeded.Enqueue(target);
			}
			Branch(label);
			Branched = true;*/
		}
		void Branch(LlvmRuntimeValue<ulong> target) {
			Field(nameof(CpuState.BranchTo), target);
			Branch(StoreRegistersLabel);
			Branched = true;
		}

		void BranchIf(LlvmRuntimeValue<int> cond, LlvmLabel if_label, LlvmLabel else_label) {
			if(!JustBranched) {
				UsedLabels.Add(if_label);
				UsedLabels.Add(else_label);
				LLVM.BuildCondBr(Builder,
					LLVM.BuildICmp(Builder, LLVMIntPredicate.LLVMIntNE, cond, Const(0), ""), if_label, else_label);
			}
			JustBranched = true;
		}

		public static LlvmRuntimeValue<ValueT> Ternary<CondT, ValueT>(LlvmRuntimeValue<CondT> cond,
			LlvmRuntimeValue<ValueT> a, LlvmRuntimeValue<ValueT> b) =>
			new LlvmRuntimeValue<ValueT>(() => LLVM.BuildSelect(Builder, cond, a, b, ""));

		LLVMValueRef Call<DelegateT>(string name, params LLVMValueRef[] args) {
			var offset = Marshal.OffsetOf<LlvmCallbacks>(name);
			var dt = typeof(DelegateT);
			Debug.Assert(typeof(MulticastDelegate).IsAssignableFrom(dt));
			var mi = dt.GetMethod("Invoke");
			var ft = LLVMTypeRef.PointerType(LLVMTypeRef.FunctionType(mi.ReturnType.ToLLVMType(),
				mi.GetParameters().Select(x => x.ParameterType.ToLLVMType()).ToArray(), false), 0);
			var fp = LLVM.BuildIntToPtr(Builder, new LlvmRuntimePointer<ulong>(CallbacksRef + Const((ulong) offset)).Value, ft, "");
			return LLVM.BuildCall(Builder, fp, args, "");
		}

		void CallSvc(uint svc) {
			Console.WriteLine($"Calling SVC 0x{svc:X}");
			Call<LlvmCallbacks.SvcDelegate>(nameof(LlvmCallbacks.Svc), Const(svc));
		}

		LlvmRuntimeValue<T> SignExtRuntime<T>(LlvmRuntimeValue<ulong> value, int size) => new LlvmRuntimeValue<T>(() =>
			LLVM.BuildSExt(Builder, LLVM.BuildTrunc(Builder, value, LLVMTypeRef.IntType((uint) size), ""),
				typeof(T).ToLLVMType(), ""));
		LlvmRuntimeValue<uint> CallCountLeadingZeros(LlvmRuntimeValue<uint> value) => throw new NotImplementedException();
		LlvmRuntimeValue<ulong> CallCountLeadingZeros(LlvmRuntimeValue<ulong> value) => throw new NotImplementedException();
		
		LlvmRuntimeValue<uint> CallReverseBits(LlvmRuntimeValue<uint> value) => throw new NotImplementedException();
		LlvmRuntimeValue<ulong> CallReverseBits(LlvmRuntimeValue<ulong> value) => throw new NotImplementedException();

		LlvmRuntimeValue<ulong> CallSR(uint op0, uint op1, uint crn, uint crm, uint op2) => throw new NotImplementedException();
		void CallSR(uint op0, uint op1, uint crn, uint crm, uint op2, LlvmRuntimeValue<ulong> value) => throw new NotImplementedException();

		LlvmRuntimeValue<Vector128<float>> CallVectorCountBits(LlvmRuntimeValue<Vector128<float>> vec, long elems) =>
			throw new NotImplementedException();

		LlvmRuntimeValue<ulong> CallVectorSumUnsigned(LlvmRuntimeValue<Vector128<float>> vec, long esize, long count) =>
			throw new NotImplementedException();

		LlvmRuntimeValue<Vector128<float>> CallVectorExtract(LlvmRuntimeValue<Vector128<float>> a,
			LlvmRuntimeValue<Vector128<float>> b, uint q, uint index) =>
			throw new NotImplementedException();

		LlvmRuntimeValue<uint> CallFloatToFixed32(LlvmRuntimeValue<float> value, ulong fbits) => throw new NotImplementedException();
		LlvmRuntimeValue<uint> CallFloatToFixed32(LlvmRuntimeValue<double> value, ulong fbits) => throw new NotImplementedException();
		LlvmRuntimeValue<ulong> CallFloatToFixed64(LlvmRuntimeValue<float> value, ulong fbits) => throw new NotImplementedException();
		LlvmRuntimeValue<ulong> CallFloatToFixed64(LlvmRuntimeValue<double> value, ulong fbits) => throw new NotImplementedException();
		
		void CallFloatCompare(LlvmRuntimeValue<float> operand1, LlvmRuntimeValue<float> operand2) =>
			throw new NotImplementedException();
		void CallFloatCompare(LlvmRuntimeValue<double> operand1, LlvmRuntimeValue<double> operand2) =>
			throw new NotImplementedException();

		LlvmRuntimeValue<byte> CallCompareAndSwap<T>(LlvmRuntimePointer<T> ptr, LlvmRuntimeValue<T> value,
			LlvmRuntimeValue<T> comparand) =>
			throw new NotImplementedException();
	}
}