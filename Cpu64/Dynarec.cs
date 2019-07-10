//#define DUMPINSNS
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
using Emitter = Sigil.Emit<System.Action<Cpu64.Recompiler>>;
using Label = Sigil.Label;
#else
using SigilLite;
using Emitter = SigilLite.Emit<System.Action<Cpu64.Recompiler>>;
using Label = SigilLite.Label;
#endif

namespace Cpu64 {
	public class Dynarec : BaseCpu {
		public Block BranchToBlock;
		public ulong BranchTo;
		
		public Dynarec(IKernel kernel) : base(kernel) {}

		public override unsafe void Run(ulong pc, ulong sp, bool one = false) {
			try {
				SP = sp;
				while(true) {
					var block = BranchToBlock ?? CacheManager.GetBlock(pc);
					if(block.Func == null)
						lock(block)
							if(block.Func == null) // Seems redundant, but really just prevents unnecessary locking
								Recompiler.Instance.Recompile(block, this);

					//LogIf(0, () => Log($"Running block at 0x{pc:X}"));

					BranchToBlock = null;
					BranchTo = unchecked((ulong) -1);
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
			} catch(Exception) {
#if DUMPINSNS
				BW.BaseStream.Close();
				BW.Close();
#endif
				throw;
			}
		}

#if DUMPINSNS
		BinaryWriter BW = new BinaryWriter(File.OpenWrite("recinsns.bin"));
		ulong Count;
		long Skip = 131_000_000L;
		public void Test() {
			//if(Count++ < 131_200_000) return;
			//if(Count++ > 10_000_000) return;
			if(Skip > 0) {
				Skip--;
				return;
			}

			BW.Write(PC);
			BW.Write((byte) (NZCV >> 28));
			for(var i = 0; i < 31; ++i)
				BW.Write(X[i]);
			for(var i = 0; i < 32; ++i)
				BW.Write(V[i].As<float, ulong>().GetElement(0));
			BW.Write(SP);
			BW.Flush();
			//((FileStream) BW.BaseStream).Flush(true);
			BW.BaseStream.Flush();
		}
#endif
		
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