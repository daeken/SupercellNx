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
			// SUBS WZR, W26, W13
			InsnTester.Disassembly("subs W31, W26, W13, LSL #0", 0x6B0D035F);
			InsnTester.Test(0x6B0D035F, (cpu, _) => {
				if(cpu == null) return;
				cpu.X[26] = 0xFFFFFFFF;
				cpu.X[13] = 0x7FFFFFFF;
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
		public void Add() {
			// ADD X9, X11, W10,SXTW
			InsnTester.Disassembly("add X9, X11, W10, SXTW #0", 0x8B2AC169);
			InsnTester.Test(0x8B2AC169, (cpu, _) => {
				if(cpu == null) return;
				cpu.X[11] = 0x1001FFF9F0;
				cpu.X[10] = 0xFFFFFFD8;
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
		public void Adds() {
			// ADDS X11, X8, X23
			InsnTester.Disassembly("adds X11, X8, X23, LSL #0", 0xAB17010B);
			InsnTester.Test(0xAB17010B, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0x8;
				cpu.X[23] = 0x1001FFF908;
			});
		}

		[Fact]
		public void Adrp() => InsnTester.Test(0xB000C4A9);

		[Fact]
		public void Smaddl() {
			// SMADDL X11, W0, W11, XZR
			InsnTester.Test(0x9B2B7C0B, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[0] = 0x7B2;
				cpu.X[11] = 0xAE147AE1;
			});
		}

		[Fact]
		public void Smulh() {
			// SMULH X8, X8, X9
			InsnTester.Disassembly("smulh X8, X8, X9", 0x9B497D08);
			InsnTester.Test(0x9B497D08, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[8] = 0x124F800;
				cpu.X[9] = 0x29F16B11C6D1E109;
			});
		}

		[Fact]
		public void Udiv() {
			// UDIV X10, X22, X9
			InsnTester.Disassembly("udiv X10, X22, X9", 0x9AC90ACA);
			InsnTester.Test(0x9AC90ACA, (cpu, pc) => {
				if(cpu == null) return;
				cpu.X[22] = 0xFFFF_FFFF_FFFF_FFFFUL;
				cpu.X[9] = 0x18UL;
			});
		}
	}
}