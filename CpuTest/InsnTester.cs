using System;
using System.Collections.Generic;
using Common;
using Cpu64;
using UnicornSharp;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace CpuTest {
	public static class InsnTester {
		class TestKernel : IKernel {
			public string MapAddress(ulong addr) => $"0x{addr:X}";

			public IEnumerable<(ulong Start, ulong Size)> MemoryRegions => throw new NotImplementedException();
			public void Svc(int svc) {}
		}
		
		static readonly List<(ulong, uint)> Mapped = new List<(ulong, uint)>();
		
		public static unsafe void Map(uint size, Action<ulong> func) {
			fixed(byte* ptr = new byte[size]) {
				var addr = (ulong) ptr;
				Mapped.Add((addr, size));
				func(addr);
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
			Assert.Equal(interpreter.Disassemble(inst, pc), dasm);
		}
		
		public static unsafe void Test(uint insn, Action<BaseCpu, ulong> pre = null, Action<BaseCpu, bool, ulong> post = null, Action<string> checkAsm = null) {
			var mem = new Span<uint>(new[] { 0U, 0U, insn, 0x14000001U }); // B +4 terminates

			var kernel = new TestKernel();
			fixed(uint* ptr = mem) {
				var addr = (ulong) ptr + 8;
				var interpreter = new Interpreter(kernel);
				var recompiler = new Recompiler(kernel);
				var uc = new UnicornArm64 { [Arm64Register.CPACR_EL1] = 3 << 20 };
				MapAll(uc, addr, 16);
				foreach(var (maddr, msize) in Mapped)
					MapAll(uc, maddr, msize);

				checkAsm?.Invoke(interpreter.Disassemble(insn, addr));

				interpreter.PC = addr;
				pre?.Invoke(interpreter, addr);
				SetUc(uc, interpreter);
				interpreter.RunOne();
				interpreter.RunOne();
				post?.Invoke(interpreter, false, addr);
				pre?.Invoke(null, addr);
				CheckUc(uc, interpreter, false);

				recompiler.PC = addr;
				pre?.Invoke(recompiler, addr);
				SetUc(uc, recompiler);
				recompiler.Run(recompiler.PC, recompiler.SP, true);
				post?.Invoke(recompiler, true, addr);
				pre?.Invoke(null, addr);
				CheckUc(uc, recompiler, true);
			}
		}

		static void SetUc(UnicornArm64 uc, BaseCpu cpu) {
			uc[Arm64Register.PC] = cpu.PC;
			uc[Arm64Register.SP] = cpu.SP;
			uc[Arm64Register.NZCV] = cpu.NZCV;
			for(var i = 0; i < 31; ++i)
				uc[i < 29 ? Arm64Register.X0 + i : Arm64Register.X29 + (i - 29)] = cpu.X[i];
		}

		static string Hex<T>(T value) => $"{value:X}";
		static string Bin(ulong value, int bits) {
			var ret = "";
			while(bits > 0)
				ret += $"{(value >> --bits) & 1}";
			return ret;
		}

		static void CheckUc(UnicornArm64 uc, BaseCpu cpu, bool isRecompiler) {
			uc.Start(uc[Arm64Register.PC], 0, 0, 2);
			Assert.Equal(Hex(uc[Arm64Register.PC]), Hex(cpu.PC));
			Assert.Equal(Hex(uc[Arm64Register.SP]), Hex(cpu.SP));
			Assert.Equal(Bin(uc[Arm64Register.NZCV] >> 28, 4), Bin(cpu.NZCV >> 28, 4));
			
			Assert.Equal(Hex(uc[Arm64Register.X0]), Hex(cpu.X[0]));
			Assert.Equal(Hex(uc[Arm64Register.X1]), Hex(cpu.X[1]));
			Assert.Equal(Hex(uc[Arm64Register.X2]), Hex(cpu.X[2]));
			Assert.Equal(Hex(uc[Arm64Register.X3]), Hex(cpu.X[3]));
			Assert.Equal(Hex(uc[Arm64Register.X4]), Hex(cpu.X[4]));
			Assert.Equal(Hex(uc[Arm64Register.X5]), Hex(cpu.X[5]));
			Assert.Equal(Hex(uc[Arm64Register.X6]), Hex(cpu.X[6]));
			Assert.Equal(Hex(uc[Arm64Register.X7]), Hex(cpu.X[7]));
			Assert.Equal(Hex(uc[Arm64Register.X8]), Hex(cpu.X[8]));
			Assert.Equal(Hex(uc[Arm64Register.X9]), Hex(cpu.X[9]));
			
			Assert.Equal(Hex(uc[Arm64Register.X10]), Hex(cpu.X[10]));
			Assert.Equal(Hex(uc[Arm64Register.X11]), Hex(cpu.X[11]));
			Assert.Equal(Hex(uc[Arm64Register.X12]), Hex(cpu.X[12]));
			Assert.Equal(Hex(uc[Arm64Register.X13]), Hex(cpu.X[13]));
			Assert.Equal(Hex(uc[Arm64Register.X14]), Hex(cpu.X[14]));
			Assert.Equal(Hex(uc[Arm64Register.X15]), Hex(cpu.X[15]));
			Assert.Equal(Hex(uc[Arm64Register.X16]), Hex(cpu.X[16]));
			Assert.Equal(Hex(uc[Arm64Register.X17]), Hex(cpu.X[17]));
			Assert.Equal(Hex(uc[Arm64Register.X18]), Hex(cpu.X[18]));
			Assert.Equal(Hex(uc[Arm64Register.X19]), Hex(cpu.X[19]));
			
			Assert.Equal(Hex(uc[Arm64Register.X20]), Hex(cpu.X[20]));
			Assert.Equal(Hex(uc[Arm64Register.X21]), Hex(cpu.X[21]));
			Assert.Equal(Hex(uc[Arm64Register.X22]), Hex(cpu.X[22]));
			Assert.Equal(Hex(uc[Arm64Register.X23]), Hex(cpu.X[23]));
			Assert.Equal(Hex(uc[Arm64Register.X24]), Hex(cpu.X[24]));
			Assert.Equal(Hex(uc[Arm64Register.X25]), Hex(cpu.X[25]));
			Assert.Equal(Hex(uc[Arm64Register.X26]), Hex(cpu.X[26]));
			Assert.Equal(Hex(uc[Arm64Register.X27]), Hex(cpu.X[27]));
			Assert.Equal(Hex(uc[Arm64Register.X28]), Hex(cpu.X[28]));
			Assert.Equal(Hex(uc[Arm64Register.X29]), Hex(cpu.X[29]));
			
			Assert.Equal(Hex(uc[Arm64Register.X30]), Hex(cpu.X[30]));
		}
	}
}