using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using Common;

namespace Cpu64 {
	public class Dynarec : BaseCpu {
		readonly Recompiler Recompiler;

		public Dynarec(IKernel kernel) : base(kernel) =>
			Recompiler = new Recompiler(kernel);

		public override unsafe void Run(ulong pc, ulong sp, bool one = false) {
			State->SP = sp;
			while(true) {
				var block = BranchToBlock ?? CacheManager.GetBlock(pc);
				if(block.Func == null)
					lock(block)
						if(block.Func == null) // Seems redundant, but really just prevents unnecessary locking
							Recompiler.Recompile(block, this);

				//LogIf(0, () => Log($"Running block at 0x{pc:X}"));

				BranchToBlock = null;
				State->BranchTo = unchecked((ulong) -1);
				block.HitCount++;
				//Log($"Running block 0x{pc:X}");
				try {
					block.Func(State, this);
				} catch(NullReferenceException) {
					Kernel.LogExclusive(() => {
						Log("Null reference!");
						DebugRegs();
						Environment.Exit(1);
					});
				}
				//Log($"Finished block at 0x{pc:X}");

				if(!one && (State->SP < 0x100000 || State->SP >> 48 != 0))
					throw new Exception($"SP likely corrupted by block {State->PC:X}: SP == 0x{State->SP:X}");
				//Log($"Branch to 0x{State->BranchTo:X} from 0x{State->PC:X}");
				State->PC = pc = State->BranchTo;
				if(one)
					break;
				Debug.Assert((pc & 3) == 0);
			}
		}
		
		public static int SignExtRuntimeInt(ulong value, int size) => SignExt<int>(value, size);
		public static long SignExtRuntimeLong(ulong value, int size) => SignExt<long>(value, size);

		public static void Unsupported() => throw new NotSupportedException();
	}
}