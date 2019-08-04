using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text.RegularExpressions;
using System.Threading;
using Common;
using Cpu64;
using UnicornSharp;
using Xunit;
using Xunit.Abstractions;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
//[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 8)]

namespace CpuTest {
	public unsafe static class InsnTester {
		class TestKernel : IKernel {
			public string MapAddress(ulong addr) => $"0x{addr:X}";

			public IEnumerable<(ulong Start, ulong Size)> MemoryRegions => throw new NotImplementedException();
			public void Svc(int svc) {}
			public void Log(string message) {}
			public void LogExclusive(Action cb) => cb();
			public void Kill() {}
		}
		
		static readonly ThreadLocal<List<(ulong, uint)>> _Mapped = new ThreadLocal<List<(ulong, uint)>>();
		static List<(ulong, uint)> Mapped => _Mapped.Value ?? (_Mapped.Value = new List<(ulong, uint)>());

		public static void Map(uint size, Action<ulong> func) {
			fixed(byte* ptr = new byte[size]) {
				var addr = (ulong) ptr;
				Mapped.Add((addr, size));
				func(addr);
				Mapped.Remove((addr, size));
			}
		}

		static void MapAll(UnicornArm64 uc, ulong addr, uint size) {
			var end = addr + size;
			while((end & 0xFFFUL) != 0)
				end++;
			for(var cur = addr & ~0xFFFUL; cur < end; cur += 0x1000)
				try {
					uc.Map(cur, 0x1000, MemoryPermission.All, (IntPtr) cur);
				} catch(UnicornException) {}
		}

		public static void Disassembly(string dasm, uint inst, ulong pc = 0) {
			var kernel = new TestKernel();
			var interpreter = new Interpreter(kernel);
			Assert.Equal(BaseCpu.Disassemble(inst, pc), dasm);
		}

		public static void AutoTest(ITestOutputHelper output, uint insn, Action<BaseCpu, ulong> setup) {
			var data64 = new[] { 0UL, 1UL, 0x1234UL, 0x80000000UL, 1UL << 63, ulong.MaxValue };
			var floats = new[] { 0f, 234f, 0f, 456f, 123f, -123f };

			var asm = BaseCpu.Disassemble(insn, 1UL << 32);
			Assert.NotNull(asm);

			var regs = new HashSet<int>();
			for(var i = 0; i < 31; ++i)
				if(Regex.IsMatch(asm, $"X{i}($| |,|\\])"))
					regs.Add(i);
			for(var i = 0; i < 31; ++i)
				if(Regex.IsMatch(asm, $"W{i}($| |,|\\])"))
					regs.Add(i);
			
			output.WriteLine(asm);
			var interpreter = new Interpreter(new TestKernel());
			setup(interpreter, 0xDEADBEEFUL);
			var needMap = Enumerable.Range(0, 31).Select(i => (&interpreter.State->X0)[i]).Any(x => x != 0UL) || interpreter.SP != 0;

			void MainTest(Action<BaseCpu> cb) {
				for(var i = 0; i < 6; ++i) {
					Test(insn, (cpu, _) => {
						if(cpu == null) return;
						cpu.NZCV = i % 2 == 0 ? 0xFU << 28 : 0;
						for(var j = 0; j < 31; ++j)
							(&cpu.State->X0)[j] = data64[(j + i) % data64.Length];
						var k = i;
						for(var j = 0; j < 32; ++j)
							(&cpu.State->V0)[j] = new Vector128<float>()
								.WithElement(0, floats[k++ % floats.Length])
								.WithElement(1, floats[k++ % floats.Length])
								.WithElement(2, floats[k++ % floats.Length])
								.WithElement(3, floats[k++ % floats.Length]);
						cb(cpu);
						foreach(var reg in regs)
							output.WriteLine($"X{reg} == 0x{(&cpu.State->X0)[reg]:X}");
					});
				}
			}

			if(needMap) {
				var size = 0x40000U;
				Map(size, maddr => {
					var bytes = new Span<byte>((void*) maddr, (int) size);
					for(var j = 0; j < bytes.Length; ++j)
						bytes[j] = (byte) (j % 255 + 1);
					MainTest(cpu => setup(cpu, maddr + (size >> 1)));
				});
			} else
				MainTest(_ => {});
		}
		
		public static unsafe void Test(uint insn, Action<BaseCpu, ulong> pre = null, Action<BaseCpu, bool, ulong> post = null, Action<string> checkAsm = null) {
			var mem = new Span<uint>(new[] { 0U, 0U, insn, 0xD61F0000U }); // BR X0 terminates

			var kernel = new TestKernel();
			fixed(uint* ptr = mem) {
				var addr = (ulong) ptr + 8;
				var asm = BaseCpu.Disassemble(insn, addr);
				Assert.NotNull(asm);
				var interpreter = new Interpreter(kernel);
				var recompiler = new Dynarec(kernel);
				var llvmRecompiler = new LlvmRecompiler(kernel);
				var uc = new UnicornArm64 { [Arm64Register.CPACR_EL1] = 3 << 20 };
				MapAll(uc, addr, 16);
				foreach(var (maddr, msize) in Mapped)
					MapAll(uc, maddr, msize);

				checkAsm?.Invoke(asm);

				interpreter.PC = addr;
				pre?.Invoke(interpreter, addr);
				SetUc(uc, interpreter);
				interpreter.RunOne();
				post?.Invoke(interpreter, false, addr);
				pre?.Invoke(null, addr);
				CheckUc(uc, interpreter, false);

				CacheManager.Clear();
				recompiler.State->PC = addr;
				pre?.Invoke(recompiler, addr);
				SetUc(uc, recompiler);
				recompiler.Run(recompiler.State->PC, recompiler.State->SP, true);
				post?.Invoke(recompiler, true, addr);
				pre?.Invoke(null, addr);
				CheckUc(uc, recompiler, true);

				CacheManager.Clear();
				llvmRecompiler.State->PC = addr;
				pre?.Invoke(llvmRecompiler, addr);
				SetUc(uc, llvmRecompiler);
				llvmRecompiler.Run(llvmRecompiler.State->PC, llvmRecompiler.State->SP, true);
				post?.Invoke(llvmRecompiler, true, addr);
				pre?.Invoke(null, addr);
				CheckUc(uc, llvmRecompiler, true);
			}
		}

		static void SetUc(UnicornArm64 uc, BaseCpu cpu) {
			uc[Arm64Register.PC] = cpu.State->PC;
			uc[Arm64Register.SP] = cpu.State->SP;
			uc[Arm64Register.NZCV] = cpu.NZCV;
			for(var i = 0; i < 31; ++i)
				uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)] = (&cpu.State->X0)[i];
			for(var i = 0; i < 32; ++i)
				uc[Arm64Register.D0 + i] = (&cpu.State->V0)[i].As<float, ulong>().GetElement(0);
		}

		static string Hex<T>(T value) => $"{value:X}";
		static string Bin(ulong value, int bits) {
			var ret = "";
			while(bits > 0)
				ret += $"{(value >> --bits) & 1}";
			return ret;
		}

		static void CheckUc(UnicornArm64 uc, BaseCpu cpu, bool isRecompiler) {
			uc.Start(uc[Arm64Register.PC], 0, 0, 1);
			if(!isRecompiler)
				Assert.Equal(Hex(uc[Arm64Register.PC]), Hex(cpu.State->PC));
			Assert.Equal(Hex(uc[Arm64Register.SP]), Hex(cpu.State->SP));
			Assert.Equal(Bin(uc[Arm64Register.NZCV] >> 28, 4), Bin(cpu.NZCV >> 28, 4));
			
			Assert.Equal(Hex(uc[Arm64Register.X0]), Hex((&cpu.State->X0)[0]));
			Assert.Equal(Hex(uc[Arm64Register.X1]), Hex((&cpu.State->X0)[1]));
			Assert.Equal(Hex(uc[Arm64Register.X2]), Hex((&cpu.State->X0)[2]));
			Assert.Equal(Hex(uc[Arm64Register.X3]), Hex((&cpu.State->X0)[3]));
			Assert.Equal(Hex(uc[Arm64Register.X4]), Hex((&cpu.State->X0)[4]));
			Assert.Equal(Hex(uc[Arm64Register.X5]), Hex((&cpu.State->X0)[5]));
			Assert.Equal(Hex(uc[Arm64Register.X6]), Hex((&cpu.State->X0)[6]));
			Assert.Equal(Hex(uc[Arm64Register.X7]), Hex((&cpu.State->X0)[7]));
			Assert.Equal(Hex(uc[Arm64Register.X8]), Hex((&cpu.State->X0)[8]));
			Assert.Equal(Hex(uc[Arm64Register.X9]), Hex((&cpu.State->X0)[9]));
			
			Assert.Equal(Hex(uc[Arm64Register.X10]), Hex((&cpu.State->X0)[10]));
			Assert.Equal(Hex(uc[Arm64Register.X11]), Hex((&cpu.State->X0)[11]));
			Assert.Equal(Hex(uc[Arm64Register.X12]), Hex((&cpu.State->X0)[12]));
			Assert.Equal(Hex(uc[Arm64Register.X13]), Hex((&cpu.State->X0)[13]));
			Assert.Equal(Hex(uc[Arm64Register.X14]), Hex((&cpu.State->X0)[14]));
			Assert.Equal(Hex(uc[Arm64Register.X15]), Hex((&cpu.State->X0)[15]));
			Assert.Equal(Hex(uc[Arm64Register.X16]), Hex((&cpu.State->X0)[16]));
			Assert.Equal(Hex(uc[Arm64Register.X17]), Hex((&cpu.State->X0)[17]));
			Assert.Equal(Hex(uc[Arm64Register.X18]), Hex((&cpu.State->X0)[18]));
			Assert.Equal(Hex(uc[Arm64Register.X19]), Hex((&cpu.State->X0)[19]));
			
			Assert.Equal(Hex(uc[Arm64Register.X20]), Hex((&cpu.State->X0)[20]));
			Assert.Equal(Hex(uc[Arm64Register.X21]), Hex((&cpu.State->X0)[21]));
			Assert.Equal(Hex(uc[Arm64Register.X22]), Hex((&cpu.State->X0)[22]));
			Assert.Equal(Hex(uc[Arm64Register.X23]), Hex((&cpu.State->X0)[23]));
			Assert.Equal(Hex(uc[Arm64Register.X24]), Hex((&cpu.State->X0)[24]));
			Assert.Equal(Hex(uc[Arm64Register.X25]), Hex((&cpu.State->X0)[25]));
			Assert.Equal(Hex(uc[Arm64Register.X26]), Hex((&cpu.State->X0)[26]));
			Assert.Equal(Hex(uc[Arm64Register.X27]), Hex((&cpu.State->X0)[27]));
			Assert.Equal(Hex(uc[Arm64Register.X28]), Hex((&cpu.State->X0)[28]));
			Assert.Equal(Hex(uc[Arm64Register.X29]), Hex((&cpu.State->X0)[29]));
			
			Assert.Equal(Hex(uc[Arm64Register.X30]), Hex((&cpu.State->X0)[30]));
			
			Assert.Equal(Hex(uc[Arm64Register.D0]),  Hex((&cpu.State->V0)[0].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D1]),  Hex((&cpu.State->V0)[1].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D2]),  Hex((&cpu.State->V0)[2].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D3]),  Hex((&cpu.State->V0)[3].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D4]),  Hex((&cpu.State->V0)[4].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D5]),  Hex((&cpu.State->V0)[5].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D6]),  Hex((&cpu.State->V0)[6].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D7]),  Hex((&cpu.State->V0)[7].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D8]),  Hex((&cpu.State->V0)[8].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D9]),  Hex((&cpu.State->V0)[9].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D10]), Hex((&cpu.State->V0)[10].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D11]), Hex((&cpu.State->V0)[11].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D12]), Hex((&cpu.State->V0)[12].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D13]), Hex((&cpu.State->V0)[13].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D14]), Hex((&cpu.State->V0)[14].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D15]), Hex((&cpu.State->V0)[15].As<float, ulong>().GetElement(0)));
			
			Assert.Equal(Hex(uc[Arm64Register.D16]), Hex((&cpu.State->V0)[16].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D17]), Hex((&cpu.State->V0)[17].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D18]), Hex((&cpu.State->V0)[18].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D19]), Hex((&cpu.State->V0)[19].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D20]), Hex((&cpu.State->V0)[20].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D21]), Hex((&cpu.State->V0)[21].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D22]), Hex((&cpu.State->V0)[22].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D23]), Hex((&cpu.State->V0)[23].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D24]), Hex((&cpu.State->V0)[24].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D25]), Hex((&cpu.State->V0)[25].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D26]), Hex((&cpu.State->V0)[26].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D27]), Hex((&cpu.State->V0)[27].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D28]), Hex((&cpu.State->V0)[28].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D29]), Hex((&cpu.State->V0)[29].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D30]), Hex((&cpu.State->V0)[30].As<float, ulong>().GetElement(0)));
			Assert.Equal(Hex(uc[Arm64Register.D31]), Hex((&cpu.State->V0)[31].As<float, ulong>().GetElement(0)));
		}
	}
}