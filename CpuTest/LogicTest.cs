using System.Runtime.Intrinsics;
using Xunit;

namespace CpuTest {
	public unsafe class LogicTest {
		[Fact]
		public void Csel() {
			// CSEL W0, WZR, W9, EQ
			InsnTester.Test(0x1A8903E0, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->NZCV_Z = 0;
				cpu.State->X9 = 0xDEADBEEFU;
			});
			// CSEL W0, WZR, W9, EQ
			InsnTester.Test(0x1A8903E0, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->NZCV_Z = 1;
				cpu.State->X9 = 0xDEADBEEFU;
			});
		}

		[Fact]
		public void Movi() {
			// MOVI V0.4S, #1
			InsnTester.Disassembly("movi V0.4S, #1, LSL #0x0", 0x4F000420);
			InsnTester.Test(0x4F000420);
		}

		[Fact]
		public void Movk() {
			// MOVK X12, #0x3E00
			InsnTester.Test(0xF287C00C, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X12 = 0x100000001;
			});
		}

		[Fact]
		public void Fmov() {
			// FMOV W9, S0
			InsnTester.Test(0x1E260009, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X9 = 0xDEADBEEFCAFEBABE;
				cpu.State->V0 = new Vector128<float>().WithElement(0, 123f).WithElement(1, 234f).WithElement(2, 345f).WithElement(3, 456f);
			});
		}

		[Fact]
		public void Sxtb() {
			// SXTB W17, W8
			InsnTester.Disassembly("sbfm W17, W8, #0, #7", 0x13001D11);
			InsnTester.Test(0x13001D11, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X8 = 0xFFFFFFFFFFFFFFFF;
			});
		}
	}
}