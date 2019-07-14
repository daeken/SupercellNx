using System;
using System.Runtime.Intrinsics;
using Xunit;

namespace CpuTest {
	public unsafe class AluTest {
		[Fact]
		public void SubsPosPos() {
			// SUBS XZR, X8, X20
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x8000;
				cpu.State->X20 = 0x4000;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x4000;
				cpu.State->X20 = 0x8000;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0;
				cpu.State->X20 = 0;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x8000;
				cpu.State->X20 = 0;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0;
				cpu.State->X20 = 0x8000;
			});
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0;
				cpu.State->X20 = 0x80UL << 12;
			});
		}

		[Fact]
		public void SubsImm() {
			// SUBS XZR, X19, #1, LSL#12
			InsnTester.Test(0xF140067F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X19 = 0x10;
			});
			
			// SUBS XZR, X8, #0x80,LSL#12
			InsnTester.Test(0xF142011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0;
			});
		}

		[Fact]
		public void SubsNegPos() {
			// SUBS XZR, X8, X20
			InsnTester.Test(0xEB14011F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0xFFFFFFFFFFFFEBE0;
				cpu.State->X20 = 0x4000;
			});
			// SUBS WZR, W26, W13
			InsnTester.Disassembly("subs W31, W26, W13, LSL #0", 0x6B0D035F);
			InsnTester.Test(0x6B0D035F, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X26 = 0xFFFFFFFF;
				cpu.State->X13 = 0x7FFFFFFF;
			});
		}

		[Fact]
		public void SubsPosNeg() {
			// SUBS WZR, W2, W8
			InsnTester.Disassembly("subs W31, W2, W8, LSL #0", 0x6B08005F);
			InsnTester.Test(0x6B08005F, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X2 = 0x40284109;
				cpu.State->X8 = 0xC018481A;
			});
		}

		[Fact]
		public void SubsNegNeg() {
			// SUBS WZR, W2, W8
			InsnTester.Disassembly("subs W31, W2, W8, LSL #0", 0x6B08005F);
			InsnTester.Test(0x6B08005F, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X2 = 0x80000000;
				cpu.State->X8 = 0xFFFFFFFFFFFFFFFF;
			});
			// SUBS WZR, W2, W8
			InsnTester.Disassembly("subs W31, W2, W8, LSL #0", 0x6B08005F);
			InsnTester.Test(0x6B08005F, (cpu, _) => {
				if(cpu == null) return;
				cpu.NZCV = 0xFU << 28;
				cpu.State->X2 = 0x80000000;
				cpu.State->X8 = 0xFFFFFFFFFFFFFFFF;
			});
		}

		[Fact]
		public void SubExtendedRegister() {
			// SUB W0, W8, W9, UXTB
			InsnTester.Test(0x4B290100, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x5F;
				cpu.State->X9 = 0x646E61374B4E5A;
			});
		}

		[Fact]
		public void Sub() {
			// SUB W10, W22, #0x10,LSL#12
			InsnTester.Disassembly("sub W10, W22, #0x10, LSL #0xC", 0x514042CA);
			InsnTester.Test(0x514042CA, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X22 = 0xA0010045;
			});
		}

		[Fact]
		public void AddImmediate() {
			// ADD W9, W8, #0x900,LSL#12
			InsnTester.Disassembly("add W9, W8, #0x900, LSL #0xC", 0x11640109);
			InsnTester.Test(0x11640109, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x41200000;
			});
			
			// ADD X29, SP, #0x10
			InsnTester.Disassembly("add X29, X31, #0x10, LSL #0x0", 0x910043FD);
			InsnTester.Test(0x910043FD, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->SP = 0xDEADBE00;
			});
		}

		[Fact]
		public void Add() {
			// ADD X9, X11, W10,SXTW
			InsnTester.Disassembly("add X9, X11, W10, SXTW #0", 0x8B2AC169);
			InsnTester.Test(0x8B2AC169, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->X11 = 0x1001FFF9F0;
				cpu.State->X10 = 0xFFFFFFD8;
			});
		}

		[Fact]
		public void Adds1() {
			// ADDS WZR, W9, #1
			InsnTester.Test(0x3100053F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X9 = 0;
			});
			// ADDS WZR, W9, #1
			InsnTester.Test(0x3100053F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X9 = 0xDEAD;
			});
			// ADDS WZR, W9, #1
			InsnTester.Test(0x3100053F, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X9 = 0xDEADBEEFU;
			});
		}

		[Fact]
		public void Adds() {
			// ADDS X11, X8, X23
			InsnTester.Disassembly("adds X11, X8, X23, LSL #0", 0xAB17010B);
			InsnTester.Test(0xAB17010B, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x8;
				cpu.State->X23 = 0x1001FFF908;
			});
			
			InsnTester.Disassembly("adds W31, W11, #0x380, LSL #0xC", 0x314E017F);
			InsnTester.Test(0xAB17010B, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X11 = ulong.MaxValue;
			});
		}

		[Fact]
		public void Adrp() => InsnTester.Test(0xB000C4A9);

		[Fact]
		public void Smaddl() {
			// SMADDL X11, W0, W11, XZR
			InsnTester.Test(0x9B2B7C0B, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X0 = 0x7B2;
				cpu.State->X11 = 0xAE147AE1;
			});
		}

		[Fact]
		public void Smulh() {
			// SMULH X8, X8, X9
			InsnTester.Disassembly("smulh X8, X8, X9", 0x9B497D08);
			InsnTester.Test(0x9B497D08, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X8 = 0x124F800;
				cpu.State->X9 = 0x29F16B11C6D1E109;
			});
		}

		[Fact]
		public void Udiv() {
			// UDIV X10, X22, X9
			InsnTester.Disassembly("udiv X10, X22, X9", 0x9AC90ACA);
			InsnTester.Test(0x9AC90ACA, (cpu, pc) => {
				if(cpu == null) return;
				cpu.State->X22 = 0xFFFF_FFFF_FFFF_FFFFUL;
				cpu.State->X9 = 0x18UL;
			});
		}

		[Fact]
		public void Fadd() {
			// FADD V3.2S, V5.2S, V3.2S
			InsnTester.Disassembly("fadd V3.2S, V5.2S, V3.2S", 0x0E23D4A3);
			InsnTester.Test(0x0E23D4A3, (cpu, _) => {
				if(cpu == null) return;
				cpu.State->V5 = new Vector128<float>().WithElement(0, 123f).WithElement(1, 234f);
				cpu.State->V3 = new Vector128<float>().WithElement(0, 345f).WithElement(1, 456f);
			});
		}
	}
}