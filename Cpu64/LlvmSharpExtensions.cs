using LLVMSharp;

namespace Cpu64 {
	public static unsafe class LlvmSharpExtensions {
		public static LLVMValueRef BuildAtomicCmpXchg(this LLVMBuilderRef builder, LLVMValueRef ptr, LLVMValueRef cmp,
			LLVMValueRef @new, LLVMAtomicOrdering successOrdering, LLVMAtomicOrdering failureOrdering,
			bool singleThread) =>
			LLVM.BuildAtomicCmpXchg(builder, ptr, cmp, @new, successOrdering, failureOrdering, singleThread ? 1 : 0);
	}
}