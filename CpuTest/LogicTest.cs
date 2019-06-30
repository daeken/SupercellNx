using Xunit;

namespace CpuTest {
	public class LogicTest {
		[Fact]
		public void Csel() {
			// CSEL W0, WZR, W9, EQ
			InsnTester.Test(0x1A8903E0, (cpu, _) => {
				if(cpu == null) return;
				cpu.NZCV_Z = 0;
				cpu.X[9] = 0xDEADBEEFU;
			});
			// CSEL W0, WZR, W9, EQ
			InsnTester.Test(0x1A8903E0, (cpu, _) => {
				if(cpu == null) return;
				cpu.NZCV_Z = 1;
				cpu.X[9] = 0xDEADBEEFU;
			});
		}

		[Fact]
		public void Movk() {
			// movk X12, #0x3E00
			InsnTester.Test(0xF287C00C, (cpu, _) => {
				if(cpu == null) return;
				cpu.X[12] = 0x100000001;
			});
		}
	}
}