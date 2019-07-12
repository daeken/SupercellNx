using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using Common;

namespace Cpu64 {
	public class Dynarec : BaseCpu {
		public Block BranchToBlock;
		public ulong BranchTo;
		readonly Recompiler Recompiler = new Recompiler();

		public Dynarec(IKernel kernel) : base(kernel) {}

		public override unsafe void Run(ulong pc, ulong sp, bool one = false) {
			SP = sp;
			while(true) {
				var block = BranchToBlock ?? CacheManager.GetBlock(pc);
				if(block.Func == null)
					lock(block)
						if(block.Func == null) // Seems redundant, but really just prevents unnecessary locking
							Recompiler.Recompile(block, this);

				//LogIf(0, () => Log($"Running block at 0x{pc:X}"));

				BranchToBlock = null;
				BranchTo = unchecked((ulong) -1);
				block.HitCount++;
				try {
					block.Func(this);
				} catch(NullReferenceException) {
					Kernel.LogExclusive(() => {
						Log("Null reference!");
						DebugRegs();
						Environment.Exit(1);
					});
				}

				if(!one && (SP < 0x100000 || SP >> 48 != 0))
					throw new Exception($"SP likely corrupted by block {PC:X}: SP == 0x{SP:X}");
				PC = pc = BranchTo;
				Debug.Assert((pc & 3) == 0);
				if(one)
					break;
			}
		}
		
		public int SignExtRuntimeInt(ulong value, int size) => SignExt<int>(value, size);
		public long SignExtRuntimeLong(ulong value, int size) => SignExt<long>(value, size);
		
		public void Unsupported() => throw new NotSupportedException();
		
		void LogIf(ulong addr, Action func) {
		}

		public void LogLoad(ulong addr, string type)                           => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loading {type} from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, byte value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, ushort value, string type)           => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, uint value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, ulong value, string type)            => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, sbyte value, string type)            => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, short value, string type)            => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, int value, string type)              => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, long value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{value:X} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, float value, string type)            => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{  value} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, double value, string type)           => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{  value} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogLoaded(ulong addr, Vector128<float> value, string type) => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Loaded 0x{  value} ({type}) from {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, byte value, string type)              => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, ushort value, string type)            => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, uint value, string type)              => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, ulong value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, sbyte value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, short value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, int value, string type)               => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, long value, string type)              => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing 0x{value:X} ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, float value, string type)             => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing {  value  } ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, double value, string type)            => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing {  value  } ({type}) to {Kernel.MapAddress(addr)}"));
		public void LogStore(ulong addr, Vector128<float> value, string type)  => LogIf(addr, () => Log($"[{Kernel.MapAddress(PC)}] Storing {  value  } ({type}) to {Kernel.MapAddress(addr)}"));
	}
}