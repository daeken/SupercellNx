using System;
using Xunit;

namespace CpuTest {
	public class AluTest {
		[Fact]
		public void SubsPosPos() {
			// SUBS XZR, X8, X20
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0x8000;
				cpu.X[20] = 0x4000;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0x4000;
				cpu.X[20] = 0x8000;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0;
				cpu.X[20] = 0;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0x8000;
				cpu.X[20] = 0;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0;
				cpu.X[20] = 0x8000;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0;
				cpu.X[20] = 0x80UL << 12;
			});
		}

		[Fact]
		public void SubsImm() {
			// SUBS XZR, X19, #1, LSL#12
			InsnTester.Test(0xF140067F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[19] = 0x10;
			});
			
			// SUBS XZR, X8, #0x80,LSL#12
			InsnTester.Test(0xF142011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0;
			});
		}

		[Fact]
		public void SubsNegPos() {
			// SUBS XZR, X8, X20
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0xFFFFFFFFFFFFEBE0;
				cpu.X[20] = 0x4000;
			});
		}

		[Fact]
		public void SubExtendedRegister() {
			// sub W0, W8, W9, UXTB
			InsnTester.Test(0x4B290100, (cpu, _) => {
				if(cpu == null) return;
				cpu.X[8] = 0x5F;
				cpu.X[9] = 0x646E61374B4E5A;
			});
		}

		[Fact]
		public void AddImmediate() {
			// ADD W9, W8, #0x900,LSL#12
			InsnTester.Disassembly("add W9, W8, #0x900, LSL #0xC", 0x11640109);
			InsnTester.Test(0x11640109, (cpu, _) => {
				if(cpu == null) return;
				cpu.X[8] = 0x41200000;
			});
			
			// ADD X29, SP, #0x10
			InsnTester.Disassembly("add X29, X31, #0x10, LSL #0x0", 0x910043FD);
			InsnTester.Test(0x910043FD, (cpu, _) => {
				if(cpu == null) return;
				cpu.SP = 0xDEADBE00;
			});
		}

		[Fact]
		public void Adds1() {
			// ADDS WZR, W9, #1
			InsnTester.Test(0x3100053F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[9] = 0;
			});
			// ADDS WZR, W9, #1
			InsnTester.Test(0x3100053F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[9] = 0xDEAD;
			});
			// ADDS WZR, W9, #1
			InsnTester.Test(0x3100053F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[9] = 0xDEADBEEFU;
			});
		}

		[Fact]
		public void Adrp() => InsnTester.Test(0xB000C4A9);
	}
}