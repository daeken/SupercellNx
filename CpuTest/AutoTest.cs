using System;
using System.Runtime.Intrinsics;
using Xunit;

namespace CpuTest {
	public class AutoTest {
		[Fact]
		public void Movn() {
			// movn X1, #0
			InsnTester.AutoTest(0x92800001, (cpu, maddr) => {
			});
			// movn W10, #0xFFEF, LSL #16
			InsnTester.AutoTest(0x12BFFDEA, (cpu, maddr) => {
			});
			// movn X9, #0x37, LSL #16
			InsnTester.AutoTest(0x92A006E9, (cpu, maddr) => {
			});
			// movn W10, #0x7EB7
			InsnTester.AutoTest(0x128FD6EA, (cpu, maddr) => {
			});
			// movn W30, #0x306E
			InsnTester.AutoTest(0x12860DDE, (cpu, maddr) => {
			});
			// movn W25, #0xEC7
			InsnTester.AutoTest(0x1281D8F9, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldurb() {
			// ldurb W1, [X0, #-1]
			InsnTester.AutoTest(0x385FF001, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldurb W21, [X28, #-0x10]
			InsnTester.AutoTest(0x385F0395, (cpu, maddr) => {
				cpu.X[28] = maddr;
			});
			// ldurb W10, [X8, #-0xE0]
			InsnTester.AutoTest(0x3852010A, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldurb W8, [X20, #-0x28]
			InsnTester.AutoTest(0x385D8288, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldurb W2, [X5, #-3]
			InsnTester.AutoTest(0x385FD0A2, (cpu, maddr) => {
				cpu.X[5] = maddr;
			});
			// ldurb W9, [X11, #-3]
			InsnTester.AutoTest(0x385FD169, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
		}

		[Fact]
		public void Movk() {
			// movk X6, #0
			InsnTester.AutoTest(0xF2800006, (cpu, maddr) => {
			});
			// movk X27, #0xFFFF, LSL #32
			InsnTester.AutoTest(0xF2DFFFFB, (cpu, maddr) => {
			});
			// movk W8, #0x302
			InsnTester.AutoTest(0x72806048, (cpu, maddr) => {
			});
			// movk W8, #0x6D20
			InsnTester.AutoTest(0x728DA408, (cpu, maddr) => {
			});
			// movk W9, #0x2E41
			InsnTester.AutoTest(0x7285C829, (cpu, maddr) => {
			});
			// movk W9, #0x7461
			InsnTester.AutoTest(0x728E8C29, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Movi() {
			// movi V0.4S, #0x1
			InsnTester.AutoTest(0x4F000420, (cpu, maddr) => {
			});
			// movi V1.2D, #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(0x6F07E7E1, (cpu, maddr) => {
			});
			// movi V20.2D, #0000000000000000
			InsnTester.AutoTest(0x6F00E414, (cpu, maddr) => {
			});
			// movi V17.2D, #0000000000000000
			InsnTester.AutoTest(0x6F00E411, (cpu, maddr) => {
			});
			// movi V4.4S, #0xBF, LSL #24
			InsnTester.AutoTest(0x4F0567E4, (cpu, maddr) => {
			});
			// movi D11, #0000000000000000
			InsnTester.AutoTest(0x2F00E40B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smull() {
			// smull X4, W4, W4
			InsnTester.AutoTest(0x9B247C84, (cpu, maddr) => {
			});
			// smull V2.2D, V2.2S, V0.2S
			InsnTester.AutoTest(0x0EA0C042, (cpu, maddr) => {
			});
			// smull X14, W14, W11
			InsnTester.AutoTest(0x9B2B7DCE, (cpu, maddr) => {
			});
			// smull X8, W23, W8
			InsnTester.AutoTest(0x9B287EE8, (cpu, maddr) => {
			});
			// smull X11, W11, W9
			InsnTester.AutoTest(0x9B297D6B, (cpu, maddr) => {
			});
			// smull X12, W12, W13
			InsnTester.AutoTest(0x9B2D7D8C, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Lsl() {
			// lsl X9, X9, X0
			InsnTester.AutoTest(0x9AC02129, (cpu, maddr) => {
			});
			// lsl W30, W27, #0x10
			InsnTester.AutoTest(0x53103F7E, (cpu, maddr) => {
			});
			// lsl W12, W26, W11
			InsnTester.AutoTest(0x1ACB234C, (cpu, maddr) => {
			});
			// lsl W8, W23, W22
			InsnTester.AutoTest(0x1AD622E8, (cpu, maddr) => {
			});
			// lsl X11, X6, #2
			InsnTester.AutoTest(0xD37EF4CB, (cpu, maddr) => {
			});
			// lsl X2, X24, #0xC
			InsnTester.AutoTest(0xD374CF02, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frintp() {
			// frintp D0, D0
			InsnTester.AutoTest(0x1E64C000, (cpu, maddr) => {
			});
			// frintp S2, S2
			InsnTester.AutoTest(0x1E24C042, (cpu, maddr) => {
			});
			// frintp S2, S0
			InsnTester.AutoTest(0x1E24C002, (cpu, maddr) => {
			});
			// frintp S0, S0
			InsnTester.AutoTest(0x1E24C000, (cpu, maddr) => {
			});
			// frintp S1, S1
			InsnTester.AutoTest(0x1E24C021, (cpu, maddr) => {
			});
			// frintp S3, S0
			InsnTester.AutoTest(0x1E24C003, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldaxrb() {
			// ldaxrb W8, [X0]
			InsnTester.AutoTest(0x085FFC08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxrb W10, [X0]
			InsnTester.AutoTest(0x085FFC0A, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxrb W9, [X0]
			InsnTester.AutoTest(0x085FFC09, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxrb W10, [X8]
			InsnTester.AutoTest(0x085FFD0A, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}

		[Fact]
		public void Ldr() {
			// ldr X0, [X0]
			InsnTester.AutoTest(0xF9400000, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldr W15, [X16, W15, SXTW #2]
			InsnTester.AutoTest(0xB86FDA0F, (cpu, maddr) => {
				cpu.X[16] = maddr;
				cpu.X[15] = 0x10;
			});
			// ldr W13, [X0, #0xD48]
			InsnTester.AutoTest(0xB94D480D, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldr X9, [X9, #0xD70]
			InsnTester.AutoTest(0xF946B929, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldr W9, [X19, #0x9DC]
			InsnTester.AutoTest(0xB949DE69, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldr W10, [X8, #0x16C]
			InsnTester.AutoTest(0xB9416D0A, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}

		[Fact]
		public void Ldp() {
			// ldp X8, X2, [X0]
			InsnTester.AutoTest(0xA9400808, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldp X23, X22, [X27, #-0x10]
			InsnTester.AutoTest(0xA97F5B77, (cpu, maddr) => {
				cpu.X[27] = maddr;
			});
			// ldp W3, W4, [X8, #0x18]
			InsnTester.AutoTest(0x29431103, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldp S13, S14, [X8]
			InsnTester.AutoTest(0x2D40390D, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldp S2, S0, [X29, #-0x48]
			InsnTester.AutoTest(0x2D7703A2, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldp W8, W9, [X19, #0x18]
			InsnTester.AutoTest(0x29432668, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
		}

		[Fact]
		public void Movz() {
			// movz X4, #0
			InsnTester.AutoTest(0xD2800004, (cpu, maddr) => {
			});
			// movz W10, #0x5555, LSL #16
			InsnTester.AutoTest(0x52AAAAAA, (cpu, maddr) => {
			});
			// movz W1, #0x7531
			InsnTester.AutoTest(0x528EA621, (cpu, maddr) => {
			});
			// movz W8, #0x6240
			InsnTester.AutoTest(0x528C4808, (cpu, maddr) => {
			});
			// movz W11, #0x4EB8
			InsnTester.AutoTest(0x5289D70B, (cpu, maddr) => {
			});
			// movz W8, #0xCA
			InsnTester.AutoTest(0x52801948, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umov() {
			// umov W9, V0.H[0]
			InsnTester.AutoTest(0x0E023C09, (cpu, maddr) => {
			});
			// umov W16, V16.H[0]
			InsnTester.AutoTest(0x0E023E10, (cpu, maddr) => {
			});
			// umov W11, V2.H[0]
			InsnTester.AutoTest(0x0E023C4B, (cpu, maddr) => {
			});
			// umov W9, V6.H[0]
			InsnTester.AutoTest(0x0E023CC9, (cpu, maddr) => {
			});
			// umov W8, V3.H[0]
			InsnTester.AutoTest(0x0E023C68, (cpu, maddr) => {
			});
			// umov W12, V5.H[0]
			InsnTester.AutoTest(0x0E023CAC, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sqadd() {
			// sqadd V1.2S, V3.2S, V1.2S
			InsnTester.AutoTest(0x0EA10C61, (cpu, maddr) => {
			});
			// sqadd V2.2S, V2.2S, V0.2S
			InsnTester.AutoTest(0x0EA00C42, (cpu, maddr) => {
			});
			// sqadd V1.2S, V2.2S, V1.2S
			InsnTester.AutoTest(0x0EA10C41, (cpu, maddr) => {
			});
			// sqadd V1.2S, V1.2S, V0.2S
			InsnTester.AutoTest(0x0EA00C21, (cpu, maddr) => {
			});
			// sqadd V2.2S, V3.2S, V2.2S
			InsnTester.AutoTest(0x0EA20C62, (cpu, maddr) => {
			});
			// sqadd V0.2S, V1.2S, V0.2S
			InsnTester.AutoTest(0x0EA00C20, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtas() {
			// fcvtas X0, S0
			InsnTester.AutoTest(0x9E240000, (cpu, maddr) => {
			});
			// fcvtas X0, D0
			InsnTester.AutoTest(0x9E640000, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sshll() {
			// sshll V4.2D, V4.2S, #0
			InsnTester.AutoTest(0x0F20A484, (cpu, maddr) => {
			});
			// sshll V2.4S, V2.4H, #0
			InsnTester.AutoTest(0x0F10A442, (cpu, maddr) => {
			});
			// sshll V5.4S, V5.4H, #0
			InsnTester.AutoTest(0x0F10A4A5, (cpu, maddr) => {
			});
			// sshll V5.2D, V5.2S, #0
			InsnTester.AutoTest(0x0F20A4A5, (cpu, maddr) => {
			});
			// sshll V4.4S, V4.4H, #0
			InsnTester.AutoTest(0x0F10A484, (cpu, maddr) => {
			});
			// sshll V3.4S, V3.4H, #0
			InsnTester.AutoTest(0x0F10A463, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldaxr() {
			// ldaxr X8, [X0]
			InsnTester.AutoTest(0xC85FFC08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxr W10, [X28]
			InsnTester.AutoTest(0x885FFF8A, (cpu, maddr) => {
				cpu.X[28] = maddr;
			});
			// ldaxr W10, [X19]
			InsnTester.AutoTest(0x885FFE6A, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldaxr W11, [X25]
			InsnTester.AutoTest(0x885FFF2B, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
			// ldaxr W17, [X9]
			InsnTester.AutoTest(0x885FFD31, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldaxr X12, [X10]
			InsnTester.AutoTest(0xC85FFD4C, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
		}

		[Fact]
		public void Bfi() {
			// bfi W1, W9, #5, #1
			InsnTester.AutoTest(0x331B0121, (cpu, maddr) => {
			});
			// bfi W26, W26, #0x10, #0x10
			InsnTester.AutoTest(0x33103F5A, (cpu, maddr) => {
			});
			// bfi W8, W11, #0x10, #0x10
			InsnTester.AutoTest(0x33103D68, (cpu, maddr) => {
			});
			// bfi X9, X8, #2, #1
			InsnTester.AutoTest(0xB37E0109, (cpu, maddr) => {
			});
			// bfi W24, W12, #0x10, #8
			InsnTester.AutoTest(0x33101D98, (cpu, maddr) => {
			});
			// bfi X16, X3, #0x2E, #0xE
			InsnTester.AutoTest(0xB3523470, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sqrshrn() {
			// sqrshrn V2.2S, V2.2D, #0xF
			InsnTester.AutoTest(0x0F319C42, (cpu, maddr) => {
			});
			// sqrshrn V0.2S, V0.2D, #0x1E
			InsnTester.AutoTest(0x0F229C00, (cpu, maddr) => {
			});
			// sqrshrn V0.2S, V0.2D, #0xF
			InsnTester.AutoTest(0x0F319C00, (cpu, maddr) => {
			});
			// sqrshrn V6.2S, V2.2D, #0xE
			InsnTester.AutoTest(0x0F329C46, (cpu, maddr) => {
			});
			// sqrshrn V1.2S, V1.2D, #0xF
			InsnTester.AutoTest(0x0F319C21, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Add() {
			// add W6, W5, W0
			InsnTester.AutoTest(0x0B0000A6, (cpu, maddr) => {
			});
			// add W13, W21, #0x770, LSL #12
			InsnTester.AutoTest(0x115DC2AD, (cpu, maddr) => {
			});
			// add X18, X18, #0x744
			InsnTester.AutoTest(0x911D1252, (cpu, maddr) => {
			});
			// add X8, SP, #0x1C
			InsnTester.AutoTest(0x910073E8, (cpu, maddr) => {
			});
			// add X9, X24, #0x24
			InsnTester.AutoTest(0x91009309, (cpu, maddr) => {
			});
			// add X0, X20, #0x11
			InsnTester.AutoTest(0x91004680, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ucvtf() {
			// ucvtf S4, S1
			InsnTester.AutoTest(0x7E21D824, (cpu, maddr) => {
			});
			// ucvtf S10, W27
			InsnTester.AutoTest(0x1E23036A, (cpu, maddr) => {
			});
			// ucvtf S2, W14
			InsnTester.AutoTest(0x1E2301C2, (cpu, maddr) => {
			});
			// ucvtf D0, X24
			InsnTester.AutoTest(0x9E630300, (cpu, maddr) => {
			});
			// ucvtf S0, W1
			InsnTester.AutoTest(0x1E230020, (cpu, maddr) => {
			});
			// ucvtf S10, W0
			InsnTester.AutoTest(0x1E23000A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Clz() {
			// clz W9, W6
			InsnTester.AutoTest(0x5AC010C9, (cpu, maddr) => {
			});
			// clz W10, W25
			InsnTester.AutoTest(0x5AC0132A, (cpu, maddr) => {
			});
			// clz W12, W11
			InsnTester.AutoTest(0x5AC0116C, (cpu, maddr) => {
			});
			// clz X9, X9
			InsnTester.AutoTest(0xDAC01129, (cpu, maddr) => {
			});
			// clz W12, W15
			InsnTester.AutoTest(0x5AC011EC, (cpu, maddr) => {
			});
			// clz X11, X8
			InsnTester.AutoTest(0xDAC0110B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fadd() {
			// fadd S2, S0, S0
			InsnTester.AutoTest(0x1E202802, (cpu, maddr) => {
			});
			// fadd V30.4S, V31.4S, V31.4S
			InsnTester.AutoTest(0x4E3FD7FE, (cpu, maddr) => {
			});
			// fadd S2, S24, S7
			InsnTester.AutoTest(0x1E272B02, (cpu, maddr) => {
			});
			// fadd V0.4S, V22.4S, V0.4S
			InsnTester.AutoTest(0x4E20D6C0, (cpu, maddr) => {
			});
			// fadd S21, S21, S24
			InsnTester.AutoTest(0x1E382AB5, (cpu, maddr) => {
			});
			// fadd S8, S16, S2
			InsnTester.AutoTest(0x1E222A08, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sbfx() {
			// sbfx W0, W8, #4, #1
			InsnTester.AutoTest(0x13041100, (cpu, maddr) => {
			});
			// sbfx X11, X11, #0x1E, #0x20
			InsnTester.AutoTest(0x935EF56B, (cpu, maddr) => {
			});
			// sbfx X16, X15, #0x12, #8
			InsnTester.AutoTest(0x935265F0, (cpu, maddr) => {
			});
			// sbfx X10, X10, #0x1F, #0x20
			InsnTester.AutoTest(0x935FF94A, (cpu, maddr) => {
			});
			// sbfx W8, W8, #3, #1
			InsnTester.AutoTest(0x13030D08, (cpu, maddr) => {
			});
			// sbfx X26, X10, #8, #0x18
			InsnTester.AutoTest(0x93487D5A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Tst() {
			// tst W5, W7
			InsnTester.AutoTest(0x6A0700BF, (cpu, maddr) => {
			});
			// tst X10, #0x7FFFFFFFFFFFFFFF
			InsnTester.AutoTest(0xF240F95F, (cpu, maddr) => {
			});
			// tst W8, W0
			InsnTester.AutoTest(0x6A00011F, (cpu, maddr) => {
			});
			// tst W0, #4
			InsnTester.AutoTest(0x721E001F, (cpu, maddr) => {
			});
			// tst W23, W22
			InsnTester.AutoTest(0x6A1602FF, (cpu, maddr) => {
			});
			// tst X8, #0x8000000000000000
			InsnTester.AutoTest(0xF241011F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frintm() {
			// frintm S2, S0
			InsnTester.AutoTest(0x1E254002, (cpu, maddr) => {
			});
			// frintm S20, S19
			InsnTester.AutoTest(0x1E254274, (cpu, maddr) => {
			});
			// frintm S19, S16
			InsnTester.AutoTest(0x1E254213, (cpu, maddr) => {
			});
			// frintm S0, S0
			InsnTester.AutoTest(0x1E254000, (cpu, maddr) => {
			});
			// frintm D5, D5
			InsnTester.AutoTest(0x1E6540A5, (cpu, maddr) => {
			});
			// frintm S18, S4
			InsnTester.AutoTest(0x1E254092, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldurh() {
			// ldurh W0, [X8, #1]
			InsnTester.AutoTest(0x78401100, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldurh W18, [X15, #-0x10]
			InsnTester.AutoTest(0x785F01F2, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ldurh W10, [X25, #1]
			InsnTester.AutoTest(0x7840132A, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
			// ldurh W8, [X29, #-0x50]
			InsnTester.AutoTest(0x785B03A8, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldurh W9, [X29, #-0x70]
			InsnTester.AutoTest(0x785903A9, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldurh W16, [X11, #-0xA]
			InsnTester.AutoTest(0x785F6170, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
		}

		[Fact]
		public void LdrhPreIndex() {
			// ldrh W9, [X8, #6]!
			InsnTester.AutoTest(0x78406D09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrh W13, [X10, #-0x20]!
			InsnTester.AutoTest(0x785E0D4D, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrh W21, [X19, #8]!
			InsnTester.AutoTest(0x78408E75, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldrh W9, [X8, #2]!
			InsnTester.AutoTest(0x78402D09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrh W9, [X23, #0x40]!
			InsnTester.AutoTest(0x78440EE9, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
			// ldrh W12, [X11, #2]!
			InsnTester.AutoTest(0x78402D6C, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
		}

		[Fact]
		public void Ldursb() {
			// ldursb W1, [X8, #-1]
			InsnTester.AutoTest(0x38DFF101, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldursb W18, [X15, #-0x30]
			InsnTester.AutoTest(0x38DD01F2, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ldursb W1, [X29, #-0x1D]
			InsnTester.AutoTest(0x38DE33A1, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldursb W1, [X29, #-0x12]
			InsnTester.AutoTest(0x38DEE3A1, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldursb W1, [X26, #-1]
			InsnTester.AutoTest(0x38DFF341, (cpu, maddr) => {
				cpu.X[26] = maddr;
			});
			// ldursb W9, [X1, #-1]
			InsnTester.AutoTest(0x38DFF029, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
		}

		[Fact]
		public void Adrp() {
			// adrp X2, #0xDEAD3000
			InsnTester.AutoTest(0xF0000002, (cpu, maddr) => {
			});
			// adrp X21, #0xDEACF000
			InsnTester.AutoTest(0xF0FFFFF5, (cpu, maddr) => {
			});
			// adrp X1, #0xDFE8B000
			InsnTester.AutoTest(0xF0009DC1, (cpu, maddr) => {
			});
			// adrp X2, #0xE0685000
			InsnTester.AutoTest(0xB000DDA2, (cpu, maddr) => {
			});
			// adrp X10, #0xDFB60000
			InsnTester.AutoTest(0x9000848A, (cpu, maddr) => {
			});
			// adrp X8, #0xDFB63000
			InsnTester.AutoTest(0xF0008488, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sha1Su0() {
			// sha1su0 V5.4S, V6.4S, V7.4S
			InsnTester.AutoTest(0x5E0730C5, (cpu, maddr) => {
			});
			// sha1su0 V6.4S, V7.4S, V16.4S
			InsnTester.AutoTest(0x5E1030E6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmeq() {
			// fcmeq V0.4S, V2.4S, #0.0
			InsnTester.AutoTest(0x4EA0D840, (cpu, maddr) => {
			});
			// fcmeq V23.4S, V25.4S, #0.0
			InsnTester.AutoTest(0x4EA0DB37, (cpu, maddr) => {
			});
			// fcmeq V25.4S, V26.4S, #0.0
			InsnTester.AutoTest(0x4EA0DB59, (cpu, maddr) => {
			});
			// fcmeq V1.4S, V4.4S, #0.0
			InsnTester.AutoTest(0x4EA0D881, (cpu, maddr) => {
			});
			// fcmeq V1.4S, V3.4S, #0.0
			InsnTester.AutoTest(0x4EA0D861, (cpu, maddr) => {
			});
			// fcmeq V6.4S, V1.4S, #0.0
			InsnTester.AutoTest(0x4EA0D826, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Mov() {
			// mov X3, SP
			InsnTester.AutoTest(0x910003E3, (cpu, maddr) => {
			});
			// mov V24.16B, V31.16B
			InsnTester.AutoTest(0x4EBF1FF8, (cpu, maddr) => {
			});
			// mov X22, X9
			InsnTester.AutoTest(0xAA0903F6, (cpu, maddr) => {
			});
			// mov V10.16B, V24.16B
			InsnTester.AutoTest(0x4EB81F0A, (cpu, maddr) => {
			});
			// mov X18, X1
			InsnTester.AutoTest(0xAA0103F2, (cpu, maddr) => {
			});
			// mov S0, V16.S[2]
			InsnTester.AutoTest(0x5E140600, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ld2() {
			// ld2 {V3.2S, V4.2S}, [X15]
			InsnTester.AutoTest(0x0C4089E3, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ld2 {V4.2D, V5.2D}, [X15]
			InsnTester.AutoTest(0x4C408DE4, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ld2 {V6.2D, V7.2D}, [X13]
			InsnTester.AutoTest(0x4C408DA6, (cpu, maddr) => {
				cpu.X[13] = maddr;
			});
		}

		[Fact]
		public void Ld1() {
			// ld1 {V5.S}[0], [X0]
			InsnTester.AutoTest(0x0D408005, (cpu, maddr) => {
			});
			// ld1 {V1.S}[3], [X27], X25
			InsnTester.AutoTest(0x4DD99361, (cpu, maddr) => {
			});
			// ld1 {V4.S}[1], [X1]
			InsnTester.AutoTest(0x0D409024, (cpu, maddr) => {
			});
			// ld1 {V5.S}[2], [X10]
			InsnTester.AutoTest(0x4D408145, (cpu, maddr) => {
			});
			// ld1 {V16.S}[0], [X15]
			InsnTester.AutoTest(0x0D4081F0, (cpu, maddr) => {
			});
			// ld1 {V2.S}[3], [X25]
			InsnTester.AutoTest(0x4D409322, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtzs() {
			// fcvtzs X8, S0
			InsnTester.AutoTest(0x9E380008, (cpu, maddr) => {
			});
			// fcvtzs W10, D0, #0x18
			InsnTester.AutoTest(0x1E58A00A, (cpu, maddr) => {
			});
			// fcvtzs W9, D0, #4
			InsnTester.AutoTest(0x1E58F009, (cpu, maddr) => {
			});
			// fcvtzs W2, S1
			InsnTester.AutoTest(0x1E380022, (cpu, maddr) => {
			});
			// fcvtzs X11, S1
			InsnTester.AutoTest(0x9E38002B, (cpu, maddr) => {
			});
			// fcvtzs W9, S18
			InsnTester.AutoTest(0x1E380249, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Adcs() {
			// adcs W4, W4, W8
			InsnTester.AutoTest(0x3A080084, (cpu, maddr) => {
			});
			// adcs X11, X21, XZR
			InsnTester.AutoTest(0xBA1F02AB, (cpu, maddr) => {
			});
			// adcs X5, X5, X9
			InsnTester.AutoTest(0xBA0900A5, (cpu, maddr) => {
			});
			// adcs X9, X11, X9
			InsnTester.AutoTest(0xBA090169, (cpu, maddr) => {
			});
			// adcs X9, X9, X17
			InsnTester.AutoTest(0xBA110129, (cpu, maddr) => {
			});
			// adcs X9, X9, X2
			InsnTester.AutoTest(0xBA020129, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdpPostIndex() {
			// ldp W8, W9, [X1], #8
			InsnTester.AutoTest(0x28C12428, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldp S16, S17, [X16], #0x10
			InsnTester.AutoTest(0x2CC24610, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldp W13, W14, [X10], #8
			InsnTester.AutoTest(0x28C1394D, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldp X28, X21, [SP], #0x20
			InsnTester.AutoTest(0xA8C257FC, (cpu, maddr) => {
			});
			// ldp W4, W5, [X1], #8
			InsnTester.AutoTest(0x28C11424, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldp Q4, Q5, [SP], #0x20
			InsnTester.AutoTest(0xACC117E4, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bit() {
			// bit V2.16B, V1.16B, V0.16B
			InsnTester.AutoTest(0x6EA01C22, (cpu, maddr) => {
			});
			// bit V20.16B, V3.16B, V22.16B
			InsnTester.AutoTest(0x6EB61C74, (cpu, maddr) => {
			});
			// bit V5.16B, V3.16B, V7.16B
			InsnTester.AutoTest(0x6EA71C65, (cpu, maddr) => {
			});
			// bit V7.16B, V0.16B, V5.16B
			InsnTester.AutoTest(0x6EA51C07, (cpu, maddr) => {
			});
			// bit V21.16B, V1.16B, V22.16B
			InsnTester.AutoTest(0x6EB61C35, (cpu, maddr) => {
			});
			// bit V16.16B, V2.16B, V7.16B
			InsnTester.AutoTest(0x6EA71C50, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmhs() {
			// cmhs V3.2S, V1.2S, V3.2S
			InsnTester.AutoTest(0x2EA33C23, (cpu, maddr) => {
			});
			// cmhs V5.2S, V1.2S, V5.2S
			InsnTester.AutoTest(0x2EA53C25, (cpu, maddr) => {
			});
			// cmhs V4.2S, V1.2S, V4.2S
			InsnTester.AutoTest(0x2EA43C24, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frecpe() {
			// frecpe V3.4S, V2.4S
			InsnTester.AutoTest(0x4EA1D843, (cpu, maddr) => {
			});
			// frecpe V19.4S, V18.4S
			InsnTester.AutoTest(0x4EA1DA53, (cpu, maddr) => {
			});
			// frecpe V23.4S, V21.4S
			InsnTester.AutoTest(0x4EA1DAB7, (cpu, maddr) => {
			});
			// frecpe V16.4S, V7.4S
			InsnTester.AutoTest(0x4EA1D8F0, (cpu, maddr) => {
			});
			// frecpe V31.4S, V30.4S
			InsnTester.AutoTest(0x4EA1DBDF, (cpu, maddr) => {
			});
			// frecpe V11.4S, V30.4S
			InsnTester.AutoTest(0x4EA1DBCB, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmtst() {
			// cmtst V18.4S, V17.4S, V0.4S
			InsnTester.AutoTest(0x4EA08E32, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V3.4S
			InsnTester.AutoTest(0x4EA38E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V4.4S
			InsnTester.AutoTest(0x4EA48E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V1.4S
			InsnTester.AutoTest(0x4EA18E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V2.4S
			InsnTester.AutoTest(0x4EA28E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V6.4S
			InsnTester.AutoTest(0x4EA68E33, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmn() {
			// cmn W1, #1
			InsnTester.AutoTest(0x3100043F, (cpu, maddr) => {
			});
			// cmn W11, #0x380, LSL #12
			InsnTester.AutoTest(0x314E017F, (cpu, maddr) => {
			});
			// cmn W23, #0x12E
			InsnTester.AutoTest(0x3104BAFF, (cpu, maddr) => {
			});
			// cmn X1, #4
			InsnTester.AutoTest(0xB100103F, (cpu, maddr) => {
			});
			// cmn W15, #4
			InsnTester.AutoTest(0x310011FF, (cpu, maddr) => {
			});
			// cmn W9, W8
			InsnTester.AutoTest(0x2B08013F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmov() {
			// fmov W0, S8
			InsnTester.AutoTest(0x1E260100, (cpu, maddr) => {
			});
			// fmov V27.4S, #-1.00000000
			InsnTester.AutoTest(0x4F07F61B, (cpu, maddr) => {
			});
			// fmov W10, S3
			InsnTester.AutoTest(0x1E26006A, (cpu, maddr) => {
			});
			// fmov S3, #-7.00000000
			InsnTester.AutoTest(0x1E339003, (cpu, maddr) => {
			});
			// fmov W26, S2
			InsnTester.AutoTest(0x1E26005A, (cpu, maddr) => {
			});
			// fmov W10, S12
			InsnTester.AutoTest(0x1E26018A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Extr() {
			// extr W4, W3, W2, #8
			InsnTester.AutoTest(0x13822064, (cpu, maddr) => {
			});
			// extr W10, W13, W10, #0x18
			InsnTester.AutoTest(0x138A61AA, (cpu, maddr) => {
			});
			// extr X10, X10, X13, #0x3F
			InsnTester.AutoTest(0x93CDFD4A, (cpu, maddr) => {
			});
			// extr X11, X13, X24, #0x32
			InsnTester.AutoTest(0x93D8C9AB, (cpu, maddr) => {
			});
			// extr X14, X1, X0, #0x3F
			InsnTester.AutoTest(0x93C0FC2E, (cpu, maddr) => {
			});
			// extr W11, W11, W10, #0x18
			InsnTester.AutoTest(0x138A616B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ubfiz() {
			// ubfiz W8, W8, #4, #4
			InsnTester.AutoTest(0x531C0D08, (cpu, maddr) => {
			});
			// ubfiz X12, X13, #0x28, #0x14
			InsnTester.AutoTest(0xD3584DAC, (cpu, maddr) => {
			});
			// ubfiz W15, W15, #0x12, #3
			InsnTester.AutoTest(0x530E09EF, (cpu, maddr) => {
			});
			// ubfiz W9, W9, #0x10, #1
			InsnTester.AutoTest(0x53100129, (cpu, maddr) => {
			});
			// ubfiz W10, W10, #0xC, #4
			InsnTester.AutoTest(0x53140D4A, (cpu, maddr) => {
			});
			// ubfiz W11, W11, #2, #4
			InsnTester.AutoTest(0x531E0D6B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cneg() {
			// cneg W9, W0, MI
			InsnTester.AutoTest(0x5A805409, (cpu, maddr) => {
			});
			// cneg X17, X17, MI
			InsnTester.AutoTest(0xDA915631, (cpu, maddr) => {
			});
			// cneg W10, W14, MI
			InsnTester.AutoTest(0x5A8E55CA, (cpu, maddr) => {
			});
			// cneg W8, W2, LT
			InsnTester.AutoTest(0x5A82A448, (cpu, maddr) => {
			});
			// cneg W16, W16, GE
			InsnTester.AutoTest(0x5A90B610, (cpu, maddr) => {
			});
			// cneg W9, W24, MI
			InsnTester.AutoTest(0x5A985709, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Lsr() {
			// lsr W7, W2, W0
			InsnTester.AutoTest(0x1AC02447, (cpu, maddr) => {
			});
			// lsr X28, X19, #0x3F
			InsnTester.AutoTest(0xD37FFE7C, (cpu, maddr) => {
			});
			// lsr W9, W9, W24
			InsnTester.AutoTest(0x1AD82529, (cpu, maddr) => {
			});
			// lsr X12, X10, #0x18
			InsnTester.AutoTest(0xD358FD4C, (cpu, maddr) => {
			});
			// lsr W12, W12, W21
			InsnTester.AutoTest(0x1AD5258C, (cpu, maddr) => {
			});
			// lsr W2, W8, #8
			InsnTester.AutoTest(0x53087D02, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Udiv() {
			// udiv W1, W1, W9
			InsnTester.AutoTest(0x1AC90821, (cpu, maddr) => {
			});
			// udiv W12, W13, W12
			InsnTester.AutoTest(0x1ACC09AC, (cpu, maddr) => {
			});
			// udiv W17, W22, W5
			InsnTester.AutoTest(0x1AC50AD1, (cpu, maddr) => {
			});
			// udiv W17, W9, W16
			InsnTester.AutoTest(0x1AD00931, (cpu, maddr) => {
			});
			// udiv X21, X26, X27
			InsnTester.AutoTest(0x9ADB0B55, (cpu, maddr) => {
			});
			// udiv X8, X8, X2
			InsnTester.AutoTest(0x9AC20908, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Shl() {
			// shl V7.4S, V2.4S, #3
			InsnTester.AutoTest(0x4F235447, (cpu, maddr) => {
			});
			// shl V21.4S, V21.4S, #0x1F
			InsnTester.AutoTest(0x4F3F56B5, (cpu, maddr) => {
			});
			// shl V2.2D, V2.2D, #3
			InsnTester.AutoTest(0x4F435442, (cpu, maddr) => {
			});
			// shl V7.4S, V2.4S, #6
			InsnTester.AutoTest(0x4F265447, (cpu, maddr) => {
			});
			// shl V7.4S, V7.4S, #0x1F
			InsnTester.AutoTest(0x4F3F54E7, (cpu, maddr) => {
			});
			// shl V6.4S, V6.4S, #0x1F
			InsnTester.AutoTest(0x4F3F54C6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smaddl() {
			// smaddl X8, W6, W3, X8
			InsnTester.AutoTest(0x9B2320C8, (cpu, maddr) => {
			});
			// smaddl X20, W26, W28, X19
			InsnTester.AutoTest(0x9B3C4F54, (cpu, maddr) => {
			});
			// smaddl X8, W0, W8, X19
			InsnTester.AutoTest(0x9B284C08, (cpu, maddr) => {
			});
			// smaddl X8, W8, W24, X21
			InsnTester.AutoTest(0x9B385508, (cpu, maddr) => {
			});
			// smaddl X24, W8, W9, X10
			InsnTester.AutoTest(0x9B292918, (cpu, maddr) => {
			});
			// smaddl X1, W22, W8, X0
			InsnTester.AutoTest(0x9B2802C1, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmp() {
			// cmp W1, #0
			InsnTester.AutoTest(0x7100003F, (cpu, maddr) => {
			});
			// cmp W12, #0x7FE, LSL #12
			InsnTester.AutoTest(0x715FF99F, (cpu, maddr) => {
			});
			// cmp X20, #8
			InsnTester.AutoTest(0xF100229F, (cpu, maddr) => {
			});
			// cmp X10, X12, LSR #4
			InsnTester.AutoTest(0xEB4C115F, (cpu, maddr) => {
			});
			// cmp W26, W11
			InsnTester.AutoTest(0x6B0B035F, (cpu, maddr) => {
			});
			// cmp W25, #0x1E
			InsnTester.AutoTest(0x71007B3F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev64() {
			// rev64 V0.4S, V0.4S
			InsnTester.AutoTest(0x4EA00800, (cpu, maddr) => {
			});
			// rev64 V7.4S, V7.4S
			InsnTester.AutoTest(0x4EA008E7, (cpu, maddr) => {
			});
			// rev64 V2.4S, V2.4S
			InsnTester.AutoTest(0x4EA00842, (cpu, maddr) => {
			});
			// rev64 V5.4S, V5.4S
			InsnTester.AutoTest(0x4EA008A5, (cpu, maddr) => {
			});
			// rev64 V6.4S, V6.4S
			InsnTester.AutoTest(0x4EA008C6, (cpu, maddr) => {
			});
			// rev64 V1.4S, V1.4S
			InsnTester.AutoTest(0x4EA00821, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sbcs() {
			// sbcs X4, X4, X8
			InsnTester.AutoTest(0xFA080084, (cpu, maddr) => {
			});
			// sbcs X16, X18, XZR
			InsnTester.AutoTest(0xFA1F0250, (cpu, maddr) => {
			});
			// sbcs X18, X10, XZR
			InsnTester.AutoTest(0xFA1F0152, (cpu, maddr) => {
			});
			// sbcs X11, X13, X11
			InsnTester.AutoTest(0xFA0B01AB, (cpu, maddr) => {
			});
			// sbcs X4, X4, X12
			InsnTester.AutoTest(0xFA0C0084, (cpu, maddr) => {
			});
			// sbcs X7, X7, X15
			InsnTester.AutoTest(0xFA0F00E7, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ld1RPostIndex() {
			// ld1r {V5.2S}, [X1], #4
			InsnTester.AutoTest(0x0DDFC825, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ld1r {V27.4S}, [X8], #4
			InsnTester.AutoTest(0x4DDFC91B, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ld1r {V1.4S}, [X8], #4
			InsnTester.AutoTest(0x4DDFC901, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ld1r {V6.4S}, [X16], #4
			InsnTester.AutoTest(0x4DDFCA06, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ld1r {V9.4S}, [X12], #4
			InsnTester.AutoTest(0x4DDFC989, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ld1r {V0.16B}, [X8], #1
			InsnTester.AutoTest(0x4DDFC100, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}

		[Fact]
		public void LdrPreIndex() {
			// ldr W6, [X0, #4]!
			InsnTester.AutoTest(0xB8404C06, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldr X10, [X20, #-0x10]!
			InsnTester.AutoTest(0xF85F0E8A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldr X0, [X22, #0x18]!
			InsnTester.AutoTest(0xF8418EC0, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldr X1, [X19, #0x10]!
			InsnTester.AutoTest(0xF8410E61, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldr X8, [X23, #0x60]!
			InsnTester.AutoTest(0xF8460EE8, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
			// ldr X0, [X8, #0x10]!
			InsnTester.AutoTest(0xF8410D00, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}

		[Fact]
		public void Zip2() {
			// zip2 V0.4S, V0.4S, V1.4S
			InsnTester.AutoTest(0x4E817800, (cpu, maddr) => {
			});
			// zip2 V27.4S, V27.4S, V29.4S
			InsnTester.AutoTest(0x4E9D7B7B, (cpu, maddr) => {
			});
			// zip2 V19.4S, V19.4S, V22.4S
			InsnTester.AutoTest(0x4E967A73, (cpu, maddr) => {
			});
			// zip2 V17.4S, V17.4S, V18.4S
			InsnTester.AutoTest(0x4E927A31, (cpu, maddr) => {
			});
			// zip2 V2.4S, V7.4S, V2.4S
			InsnTester.AutoTest(0x4E8278E2, (cpu, maddr) => {
			});
			// zip2 V19.4S, V19.4S, V20.4S
			InsnTester.AutoTest(0x4E947A73, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Zip1() {
			// zip1 V0.4S, V2.4S, V1.4S
			InsnTester.AutoTest(0x4E813840, (cpu, maddr) => {
			});
			// zip1 V30.2S, V28.2S, V29.2S
			InsnTester.AutoTest(0x0E9D3B9E, (cpu, maddr) => {
			});
			// zip1 V0.4S, V31.4S, V10.4S
			InsnTester.AutoTest(0x4E8A3BE0, (cpu, maddr) => {
			});
			// zip1 V17.4S, V1.4S, V4.4S
			InsnTester.AutoTest(0x4E843831, (cpu, maddr) => {
			});
			// zip1 V6.4S, V1.4S, V2.4S
			InsnTester.AutoTest(0x4E823826, (cpu, maddr) => {
			});
			// zip1 V25.4S, V23.4S, V22.4S
			InsnTester.AutoTest(0x4E963AF9, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ror() {
			// ror W5, W1, W3
			InsnTester.AutoTest(0x1AC32C25, (cpu, maddr) => {
			});
			// ror W10, W10, #0x11
			InsnTester.AutoTest(0x138A454A, (cpu, maddr) => {
			});
			// ror W16, W16, #0x19
			InsnTester.AutoTest(0x13906610, (cpu, maddr) => {
			});
			// ror X11, X9, #0x20
			InsnTester.AutoTest(0x93C9812B, (cpu, maddr) => {
			});
			// ror W18, W18, #0xB
			InsnTester.AutoTest(0x13922E52, (cpu, maddr) => {
			});
			// ror W6, W6, #9
			InsnTester.AutoTest(0x138624C6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fneg() {
			// fneg D0, D0
			InsnTester.AutoTest(0x1E614000, (cpu, maddr) => {
			});
			// fneg V24.4S, V16.4S
			InsnTester.AutoTest(0x6EA0FA18, (cpu, maddr) => {
			});
			// fneg S17, S4
			InsnTester.AutoTest(0x1E214091, (cpu, maddr) => {
			});
			// fneg S29, S29
			InsnTester.AutoTest(0x1E2143BD, (cpu, maddr) => {
			});
			// fneg S29, S30
			InsnTester.AutoTest(0x1E2143DD, (cpu, maddr) => {
			});
			// fneg S16, S5
			InsnTester.AutoTest(0x1E2140B0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Adds() {
			// adds X4, X4, #1
			InsnTester.AutoTest(0xB1000484, (cpu, maddr) => {
			});
			// adds W13, W10, #0x10, LSL #12
			InsnTester.AutoTest(0x3140414D, (cpu, maddr) => {
			});
			// adds X10, X8, X12
			InsnTester.AutoTest(0xAB0C010A, (cpu, maddr) => {
			});
			// adds X12, X13, X12
			InsnTester.AutoTest(0xAB0C01AC, (cpu, maddr) => {
			});
			// adds X10, X10, X5
			InsnTester.AutoTest(0xAB05014A, (cpu, maddr) => {
			});
			// adds X15, X15, X3, LSL #32
			InsnTester.AutoTest(0xAB0381EF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sub() {
			// sub X2, X9, X0
			InsnTester.AutoTest(0xCB000122, (cpu, maddr) => {
			});
			// sub W10, W10, #0xA00, LSL #12
			InsnTester.AutoTest(0x5168014A, (cpu, maddr) => {
			});
			// sub W17, W14, W12
			InsnTester.AutoTest(0x4B0C01D1, (cpu, maddr) => {
			});
			// sub W22, W10, #1
			InsnTester.AutoTest(0x51000556, (cpu, maddr) => {
			});
			// sub W9, W20, #0x80
			InsnTester.AutoTest(0x51020289, (cpu, maddr) => {
			});
			// sub W5, W8, #0x1C
			InsnTester.AutoTest(0x51007105, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smulh() {
			// smulh X8, X0, X8
			InsnTester.AutoTest(0x9B487C08, (cpu, maddr) => {
			});
			// smulh X10, X10, X11
			InsnTester.AutoTest(0x9B4B7D4A, (cpu, maddr) => {
			});
			// smulh X9, X21, X9
			InsnTester.AutoTest(0x9B497EA9, (cpu, maddr) => {
			});
			// smulh X9, X22, X9
			InsnTester.AutoTest(0x9B497EC9, (cpu, maddr) => {
			});
			// smulh X11, X10, X13
			InsnTester.AutoTest(0x9B4D7D4B, (cpu, maddr) => {
			});
			// smulh X13, X13, X15
			InsnTester.AutoTest(0x9B4F7DAD, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Neg() {
			// neg X0, X2
			InsnTester.AutoTest(0xCB0203E0, (cpu, maddr) => {
			});
			// neg X12, X10, LSL #29
			InsnTester.AutoTest(0xCB0A77EC, (cpu, maddr) => {
			});
			// neg W2, W0
			InsnTester.AutoTest(0x4B0003E2, (cpu, maddr) => {
			});
			// neg W9, W9, LSL #3
			InsnTester.AutoTest(0x4B090FE9, (cpu, maddr) => {
			});
			// neg W11, W13
			InsnTester.AutoTest(0x4B0D03EB, (cpu, maddr) => {
			});
			// neg W22, W27
			InsnTester.AutoTest(0x4B1B03F6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev() {
			// rev W4, W5
			InsnTester.AutoTest(0x5AC008A4, (cpu, maddr) => {
			});
			// rev W30, W30
			InsnTester.AutoTest(0x5AC00BDE, (cpu, maddr) => {
			});
			// rev W13, W12
			InsnTester.AutoTest(0x5AC0098D, (cpu, maddr) => {
			});
			// rev W24, W24
			InsnTester.AutoTest(0x5AC00B18, (cpu, maddr) => {
			});
			// rev X9, X8
			InsnTester.AutoTest(0xDAC00D09, (cpu, maddr) => {
			});
			// rev W0, W9
			InsnTester.AutoTest(0x5AC00920, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Csneg() {
			// csneg W8, W8, W2, GE
			InsnTester.AutoTest(0x5A82A508, (cpu, maddr) => {
			});
			// csneg W11, W23, W27, LO
			InsnTester.AutoTest(0x5A9B36EB, (cpu, maddr) => {
			});
			// csneg W9, W2, W6, GE
			InsnTester.AutoTest(0x5A86A449, (cpu, maddr) => {
			});
			// csneg W8, W3, W7, GE
			InsnTester.AutoTest(0x5A87A468, (cpu, maddr) => {
			});
			// csneg W8, W12, W8, GT
			InsnTester.AutoTest(0x5A88C588, (cpu, maddr) => {
			});
			// csneg W10, WZR, W11, NE
			InsnTester.AutoTest(0x5A8B17EA, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fsqrt() {
			// fsqrt S3, S0
			InsnTester.AutoTest(0x1E21C003, (cpu, maddr) => {
			});
			// fsqrt S10, S11
			InsnTester.AutoTest(0x1E21C16A, (cpu, maddr) => {
			});
			// fsqrt S9, S11
			InsnTester.AutoTest(0x1E21C169, (cpu, maddr) => {
			});
			// fsqrt S11, S10
			InsnTester.AutoTest(0x1E21C14B, (cpu, maddr) => {
			});
			// fsqrt S8, S11
			InsnTester.AutoTest(0x1E21C168, (cpu, maddr) => {
			});
			// fsqrt S10, S9
			InsnTester.AutoTest(0x1E21C12A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldarb() {
			// ldarb W8, [X0]
			InsnTester.AutoTest(0x08DFFC08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldarb W10, [X10]
			InsnTester.AutoTest(0x08DFFD4A, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldarb W0, [X0]
			InsnTester.AutoTest(0x08DFFC00, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldarb W8, [X24]
			InsnTester.AutoTest(0x08DFFF08, (cpu, maddr) => {
				cpu.X[24] = maddr;
			});
			// ldarb W8, [X19]
			InsnTester.AutoTest(0x08DFFE68, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldarb W8, [X28]
			InsnTester.AutoTest(0x08DFFF88, (cpu, maddr) => {
				cpu.X[28] = maddr;
			});
		}

		[Fact]
		public void Mul() {
			// mul X0, X0, X4
			InsnTester.AutoTest(0x9B047C00, (cpu, maddr) => {
			});
			// mul V0.4S, V0.4S, V0.S[1]
			InsnTester.AutoTest(0x4FA08000, (cpu, maddr) => {
			});
			// mul X9, X9, X28
			InsnTester.AutoTest(0x9B1C7D29, (cpu, maddr) => {
			});
			// mul W19, W19, W8
			InsnTester.AutoTest(0x1B087E73, (cpu, maddr) => {
			});
			// mul W8, W0, W24
			InsnTester.AutoTest(0x1B187C08, (cpu, maddr) => {
			});
			// mul X1, X17, X13
			InsnTester.AutoTest(0x9B0D7E21, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Dsb() {
			// dsb SY
			InsnTester.AutoTest(0xD5033F9F, (cpu, maddr) => {
			});
			// dsb ISH
			InsnTester.AutoTest(0xD5033B9F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldarh() {
			// ldarh W0, [X0]
			InsnTester.AutoTest(0x48DFFC00, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldarh W8, [X20]
			InsnTester.AutoTest(0x48DFFE88, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldarh W8, [X8]
			InsnTester.AutoTest(0x48DFFD08, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}

		[Fact]
		public void Asr() {
			// asr W2, W2, #3
			InsnTester.AutoTest(0x13037C42, (cpu, maddr) => {
			});
			// asr X10, X10, #0x3F
			InsnTester.AutoTest(0x937FFD4A, (cpu, maddr) => {
			});
			// asr W29, W27, #0x18
			InsnTester.AutoTest(0x13187F7D, (cpu, maddr) => {
			});
			// asr W5, W1, #1
			InsnTester.AutoTest(0x13017C25, (cpu, maddr) => {
			});
			// asr W12, W12, #1
			InsnTester.AutoTest(0x13017D8C, (cpu, maddr) => {
			});
			// asr X22, X8, #2
			InsnTester.AutoTest(0x9342FD16, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcsel() {
			// fcsel S0, S1, S0, MI
			InsnTester.AutoTest(0x1E204C20, (cpu, maddr) => {
			});
			// fcsel S20, S20, S21, GT
			InsnTester.AutoTest(0x1E35CE94, (cpu, maddr) => {
			});
			// fcsel S11, S0, S1, MI
			InsnTester.AutoTest(0x1E214C0B, (cpu, maddr) => {
			});
			// fcsel S13, S12, S6, GT
			InsnTester.AutoTest(0x1E26CD8D, (cpu, maddr) => {
			});
			// fcsel S17, S7, S17, GT
			InsnTester.AutoTest(0x1E31CCF1, (cpu, maddr) => {
			});
			// fcsel S18, S22, S21, MI
			InsnTester.AutoTest(0x1E354ED2, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev16() {
			// rev16 W5, W3
			InsnTester.AutoTest(0x5AC00465, (cpu, maddr) => {
			});
			// rev16 W11, W28
			InsnTester.AutoTest(0x5AC0078B, (cpu, maddr) => {
			});
			// rev16 W11, W15
			InsnTester.AutoTest(0x5AC005EB, (cpu, maddr) => {
			});
			// rev16 W6, W8
			InsnTester.AutoTest(0x5AC00506, (cpu, maddr) => {
			});
			// rev16 W11, W8
			InsnTester.AutoTest(0x5AC0050B, (cpu, maddr) => {
			});
			// rev16 W16, W17
			InsnTester.AutoTest(0x5AC00630, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmax() {
			// fmax S4, S0, S1
			InsnTester.AutoTest(0x1E214804, (cpu, maddr) => {
			});
			// fmax S22, S20, S21
			InsnTester.AutoTest(0x1E354A96, (cpu, maddr) => {
			});
			// fmax S3, S2, S0
			InsnTester.AutoTest(0x1E204843, (cpu, maddr) => {
			});
			// fmax S15, S0, S1
			InsnTester.AutoTest(0x1E21480F, (cpu, maddr) => {
			});
			// fmax S1, S1, S12
			InsnTester.AutoTest(0x1E2C4821, (cpu, maddr) => {
			});
			// fmax S18, S17, S16
			InsnTester.AutoTest(0x1E304A32, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Eon() {
			// eon W10, W10, W9
			InsnTester.AutoTest(0x4A29014A, (cpu, maddr) => {
			});
			// eon W12, W12, W11
			InsnTester.AutoTest(0x4A2B018C, (cpu, maddr) => {
			});
			// eon W14, W14, W13
			InsnTester.AutoTest(0x4A2D01CE, (cpu, maddr) => {
			});
			// eon W17, W18, W17
			InsnTester.AutoTest(0x4A310251, (cpu, maddr) => {
			});
			// eon W15, W15, W14
			InsnTester.AutoTest(0x4A2E01EF, (cpu, maddr) => {
			});
			// eon W16, W17, W16
			InsnTester.AutoTest(0x4A300230, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Orr() {
			// orr X9, X9, #1
			InsnTester.AutoTest(0xB2400129, (cpu, maddr) => {
			});
			// orr X22, XZR, #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0xB27FFBF6, (cpu, maddr) => {
			});
			// orr W0, WZR, #0x1F0
			InsnTester.AutoTest(0x321C13E0, (cpu, maddr) => {
			});
			// orr W24, WZR, #0xFF7FFFFF
			InsnTester.AutoTest(0x32087BF8, (cpu, maddr) => {
			});
			// orr W9, W26, #4
			InsnTester.AutoTest(0x321E0349, (cpu, maddr) => {
			});
			// orr W3, W3, W15
			InsnTester.AutoTest(0x2A0F0063, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldrb() {
			// ldrb W9, [X1]
			InsnTester.AutoTest(0x39400029, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrb W14, [X13, W14, SXTW]
			InsnTester.AutoTest(0x386EC9AE, (cpu, maddr) => {
				cpu.X[13] = maddr;
				cpu.X[14] = 0x10;
			});
			// ldrb W8, [X26, #5]
			InsnTester.AutoTest(0x39401748, (cpu, maddr) => {
				cpu.X[26] = maddr;
			});
			// ldrb W0, [X18, #0x490]
			InsnTester.AutoTest(0x39524240, (cpu, maddr) => {
				cpu.X[18] = maddr;
			});
			// ldrb W9, [X8, #0xE]
			InsnTester.AutoTest(0x39403909, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrb W8, [X0, #0x29C]
			InsnTester.AutoTest(0x394A7008, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
		}

		[Fact]
		public void Ushll() {
			// ushll V6.4S, V6.4H, #0
			InsnTester.AutoTest(0x2F10A4C6, (cpu, maddr) => {
			});
			// ushll V13.4S, V13.4H, #0
			InsnTester.AutoTest(0x2F10A5AD, (cpu, maddr) => {
			});
			// ushll V2.4S, V1.4H, #0
			InsnTester.AutoTest(0x2F10A422, (cpu, maddr) => {
			});
			// ushll V2.8H, V1.8B, #0
			InsnTester.AutoTest(0x2F08A422, (cpu, maddr) => {
			});
			// ushll V3.4S, V2.4H, #0
			InsnTester.AutoTest(0x2F10A443, (cpu, maddr) => {
			});
			// ushll V16.4S, V16.4H, #0
			InsnTester.AutoTest(0x2F10A610, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrsbPostIndex() {
			// ldrsb W9, [X8], #1
			InsnTester.AutoTest(0x38C01509, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsb W11, [X8], #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(0x38DFF50B, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsb W26, [X20], #1
			InsnTester.AutoTest(0x38C0169A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldrsb W10, [X9], #1
			InsnTester.AutoTest(0x38C0152A, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsb W11, [X9], #1
			InsnTester.AutoTest(0x38C0152B, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsb W11, [X8], #0xB
			InsnTester.AutoTest(0x38C0B50B, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}

		[Fact]
		public void LdrshPostIndex() {
			// ldrsh W2, [X1], #2
			InsnTester.AutoTest(0x78C02422, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrsh W10, [X26], #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0x78DFE74A, (cpu, maddr) => {
				cpu.X[26] = maddr;
			});
			// ldrsh W14, [X11], #0x18
			InsnTester.AutoTest(0x78C1856E, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrsh W14, [X12], #2
			InsnTester.AutoTest(0x78C0258E, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ldrsh W17, [X15], #2
			InsnTester.AutoTest(0x78C025F1, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ldrsh X10, [X25], #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0x789FE72A, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
		}

		[Fact]
		public void Ubfx() {
			// ubfx W9, W0, #1, #1
			InsnTester.AutoTest(0x53010409, (cpu, maddr) => {
			});
			// ubfx X15, X15, #0x1F, #0x20
			InsnTester.AutoTest(0xD35FF9EF, (cpu, maddr) => {
			});
			// ubfx X10, X8, #0x28, #8
			InsnTester.AutoTest(0xD368BD0A, (cpu, maddr) => {
			});
			// ubfx W9, W0, #0xA, #1
			InsnTester.AutoTest(0x530A2809, (cpu, maddr) => {
			});
			// ubfx X16, X20, #0x10, #3
			InsnTester.AutoTest(0xD3504A90, (cpu, maddr) => {
			});
			// ubfx X8, X27, #0xC, #0x14
			InsnTester.AutoTest(0xD34C7F68, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Orn() {
			// orn W3, W1, W2
			InsnTester.AutoTest(0x2A220023, (cpu, maddr) => {
			});
			// orn W10, W11, W10
			InsnTester.AutoTest(0x2A2A016A, (cpu, maddr) => {
			});
			// orn W3, W12, W15
			InsnTester.AutoTest(0x2A2F0183, (cpu, maddr) => {
			});
			// orn W21, W1, W2
			InsnTester.AutoTest(0x2A220035, (cpu, maddr) => {
			});
			// orn W11, W9, W11
			InsnTester.AutoTest(0x2A2B012B, (cpu, maddr) => {
			});
			// orn W8, W20, W21
			InsnTester.AutoTest(0x2A350288, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fccmp() {
			// fccmp S8, S0, #4, MI
			InsnTester.AutoTest(0x1E204504, (cpu, maddr) => {
			});
			// fccmp S28, S23, #8, LS
			InsnTester.AutoTest(0x1E379788, (cpu, maddr) => {
			});
			// fccmp S0, S9, #0, NE
			InsnTester.AutoTest(0x1E291400, (cpu, maddr) => {
			});
			// fccmp S4, S2, #2, LS
			InsnTester.AutoTest(0x1E229482, (cpu, maddr) => {
			});
			// fccmp S0, S1, #4, LS
			InsnTester.AutoTest(0x1E219404, (cpu, maddr) => {
			});
			// fccmp S12, S8, #2, GE
			InsnTester.AutoTest(0x1E28A582, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sxtb() {
			// sxtb W4, W6
			InsnTester.AutoTest(0x13001CC4, (cpu, maddr) => {
			});
			// sxtb X20, W19
			InsnTester.AutoTest(0x93401E74, (cpu, maddr) => {
			});
			// sxtb W8, W28
			InsnTester.AutoTest(0x13001F88, (cpu, maddr) => {
			});
			// sxtb W4, W5
			InsnTester.AutoTest(0x13001CA4, (cpu, maddr) => {
			});
			// sxtb X8, W0
			InsnTester.AutoTest(0x93401C08, (cpu, maddr) => {
			});
			// sxtb W1, W9
			InsnTester.AutoTest(0x13001D21, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sxth() {
			// sxth W2, W0
			InsnTester.AutoTest(0x13003C02, (cpu, maddr) => {
			});
			// sxth W25, W30
			InsnTester.AutoTest(0x13003FD9, (cpu, maddr) => {
			});
			// sxth W26, W0
			InsnTester.AutoTest(0x13003C1A, (cpu, maddr) => {
			});
			// sxth X10, W5
			InsnTester.AutoTest(0x93403CAA, (cpu, maddr) => {
			});
			// sxth X7, W3
			InsnTester.AutoTest(0x93403C67, (cpu, maddr) => {
			});
			// sxth X10, W10
			InsnTester.AutoTest(0x93403D4A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bfxil() {
			// bfxil W6, W1, #0, #6
			InsnTester.AutoTest(0x33001426, (cpu, maddr) => {
			});
			// bfxil X16, X11, #0x15, #0x1F
			InsnTester.AutoTest(0xB355CD70, (cpu, maddr) => {
			});
			// bfxil W9, W8, #2, #1
			InsnTester.AutoTest(0x33020909, (cpu, maddr) => {
			});
			// bfxil W14, W10, #0xC, #6
			InsnTester.AutoTest(0x330C454E, (cpu, maddr) => {
			});
			// bfxil X20, X25, #0, #0x20
			InsnTester.AutoTest(0xB3407F34, (cpu, maddr) => {
			});
			// bfxil W7, W22, #0, #6
			InsnTester.AutoTest(0x330016C7, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ccmp() {
			// ccmp X8, #0, #0, EQ
			InsnTester.AutoTest(0xFA400900, (cpu, maddr) => {
			});
			// ccmp W23, #0x1F, #2, NE
			InsnTester.AutoTest(0x7A5F1AE2, (cpu, maddr) => {
			});
			// ccmp W12, #1, #8, GE
			InsnTester.AutoTest(0x7A41A988, (cpu, maddr) => {
			});
			// ccmp X19, X8, #0, NE
			InsnTester.AutoTest(0xFA481260, (cpu, maddr) => {
			});
			// ccmp W23, W13, #0, EQ
			InsnTester.AutoTest(0x7A4D02E0, (cpu, maddr) => {
			});
			// ccmp X22, #0, #4, NE
			InsnTester.AutoTest(0xFA401AC4, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ccmn() {
			// ccmn X1, #1, #4, NE
			InsnTester.AutoTest(0xBA411824, (cpu, maddr) => {
			});
			// ccmn W22, #0x11, #4, NE
			InsnTester.AutoTest(0x3A511AC4, (cpu, maddr) => {
			});
			// ccmn W8, #1, #4, EQ
			InsnTester.AutoTest(0x3A410904, (cpu, maddr) => {
			});
			// ccmn X9, #1, #4, NE
			InsnTester.AutoTest(0xBA411924, (cpu, maddr) => {
			});
			// ccmn W8, #1, #4, LO
			InsnTester.AutoTest(0x3A413904, (cpu, maddr) => {
			});
			// ccmn W8, #1, #4, NE
			InsnTester.AutoTest(0x3A411904, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sshr() {
			// sshr V0.16B, V1.16B, #7
			InsnTester.AutoTest(0x4F090420, (cpu, maddr) => {
			});
			// sshr V21.4S, V21.4S, #0x1F
			InsnTester.AutoTest(0x4F2106B5, (cpu, maddr) => {
			});
			// sshr V3.4S, V3.4S, #0x1F
			InsnTester.AutoTest(0x4F210463, (cpu, maddr) => {
			});
			// sshr V5.4S, V21.4S, #0x1F
			InsnTester.AutoTest(0x4F2106A5, (cpu, maddr) => {
			});
			// sshr V0.4S, V0.4S, #0x1F
			InsnTester.AutoTest(0x4F210400, (cpu, maddr) => {
			});
			// sshr V7.4S, V7.4S, #0x1F
			InsnTester.AutoTest(0x4F2104E7, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmin() {
			// fmin S0, S1, S0
			InsnTester.AutoTest(0x1E205820, (cpu, maddr) => {
			});
			// fmin S2, S17, S16
			InsnTester.AutoTest(0x1E305A22, (cpu, maddr) => {
			});
			// fmin S4, S1, S2
			InsnTester.AutoTest(0x1E225824, (cpu, maddr) => {
			});
			// fmin S12, S0, S10
			InsnTester.AutoTest(0x1E2A580C, (cpu, maddr) => {
			});
			// fmin S2, S0, S2
			InsnTester.AutoTest(0x1E225802, (cpu, maddr) => {
			});
			// fmin S9, S9, S0
			InsnTester.AutoTest(0x1E205929, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Mvn() {
			// mvn W0, W8
			InsnTester.AutoTest(0x2A2803E0, (cpu, maddr) => {
			});
			// mvn V16.16B, V16.16B
			InsnTester.AutoTest(0x6E205A10, (cpu, maddr) => {
			});
			// mvn W7, W12
			InsnTester.AutoTest(0x2A2C03E7, (cpu, maddr) => {
			});
			// mvn W16, W16
			InsnTester.AutoTest(0x2A3003F0, (cpu, maddr) => {
			});
			// mvn W8, W3
			InsnTester.AutoTest(0x2A2303E8, (cpu, maddr) => {
			});
			// mvn W11, W13
			InsnTester.AutoTest(0x2A2D03EB, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvt() {
			// fcvt S2, D0
			InsnTester.AutoTest(0x1E624002, (cpu, maddr) => {
			});
			// fcvt S16, D16
			InsnTester.AutoTest(0x1E624210, (cpu, maddr) => {
			});
			// fcvt D0, S8
			InsnTester.AutoTest(0x1E22C100, (cpu, maddr) => {
			});
			// fcvt D19, S19
			InsnTester.AutoTest(0x1E22C273, (cpu, maddr) => {
			});
			// fcvt D11, S8
			InsnTester.AutoTest(0x1E22C10B, (cpu, maddr) => {
			});
			// fcvt S3, D3
			InsnTester.AutoTest(0x1E624063, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fsub() {
			// fsub S4, S1, S0
			InsnTester.AutoTest(0x1E203824, (cpu, maddr) => {
			});
			// fsub V21.4S, V26.4S, V30.4S
			InsnTester.AutoTest(0x4EBED755, (cpu, maddr) => {
			});
			// fsub S12, S5, S20
			InsnTester.AutoTest(0x1E3438AC, (cpu, maddr) => {
			});
			// fsub S7, S7, S1
			InsnTester.AutoTest(0x1E2138E7, (cpu, maddr) => {
			});
			// fsub S1, S0, S4
			InsnTester.AutoTest(0x1E243801, (cpu, maddr) => {
			});
			// fsub S16, S19, S18
			InsnTester.AutoTest(0x1E323A70, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Subs() {
			// subs X8, X8, #1
			InsnTester.AutoTest(0xF1000508, (cpu, maddr) => {
			});
			// subs X21, X21, #0x600, LSL #12
			InsnTester.AutoTest(0xF15802B5, (cpu, maddr) => {
			});
			// subs W10, W21, W9
			InsnTester.AutoTest(0x6B0902AA, (cpu, maddr) => {
			});
			// subs W22, W20, #1
			InsnTester.AutoTest(0x71000696, (cpu, maddr) => {
			});
			// subs W21, W28, #1
			InsnTester.AutoTest(0x71000795, (cpu, maddr) => {
			});
			// subs W9, W12, W9
			InsnTester.AutoTest(0x6B090189, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Scvtf() {
			// scvtf S1, S0
			InsnTester.AutoTest(0x5E21D801, (cpu, maddr) => {
			});
			// scvtf V27.2S, V27.2S
			InsnTester.AutoTest(0x0E21DB7B, (cpu, maddr) => {
			});
			// scvtf V11.2S, V11.2S
			InsnTester.AutoTest(0x0E21D96B, (cpu, maddr) => {
			});
			// scvtf S2, S0
			InsnTester.AutoTest(0x5E21D802, (cpu, maddr) => {
			});
			// scvtf S0, S8
			InsnTester.AutoTest(0x5E21D900, (cpu, maddr) => {
			});
			// scvtf D1, W2
			InsnTester.AutoTest(0x1E620041, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldur() {
			// ldur X7, [X4, #6]
			InsnTester.AutoTest(0xF8406087, (cpu, maddr) => {
				cpu.X[4] = maddr;
			});
			// ldur W11, [X29, #-0xF0]
			InsnTester.AutoTest(0xB85103AB, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldur X8, [X29, #-0x40]
			InsnTester.AutoTest(0xF85C03A8, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldur X9, [X8, #-0x20]
			InsnTester.AutoTest(0xF85E0109, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldur S1, [X29, #-0x3C]
			InsnTester.AutoTest(0xBC5C43A1, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldur W9, [X22, #-0x14]
			InsnTester.AutoTest(0xB85EC2C9, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
		}

		[Fact]
		public void Smax() {
			// smax V1.4S, V1.4S, V5.4S
			InsnTester.AutoTest(0x4EA56421, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V1.4S
			InsnTester.AutoTest(0x4EA16400, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V4.4S
			InsnTester.AutoTest(0x4EA46400, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V2.4S
			InsnTester.AutoTest(0x4EA26400, (cpu, maddr) => {
			});
			// smax V3.4S, V3.4S, V7.4S
			InsnTester.AutoTest(0x4EA76463, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V3.4S
			InsnTester.AutoTest(0x4EA36400, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umulh() {
			// umulh X8, X2, X0
			InsnTester.AutoTest(0x9BC07C48, (cpu, maddr) => {
			});
			// umulh X10, X10, X23
			InsnTester.AutoTest(0x9BD77D4A, (cpu, maddr) => {
			});
			// umulh X8, X13, X12
			InsnTester.AutoTest(0x9BCC7DA8, (cpu, maddr) => {
			});
			// umulh X12, X11, X9
			InsnTester.AutoTest(0x9BC97D6C, (cpu, maddr) => {
			});
			// umulh X10, X10, X22
			InsnTester.AutoTest(0x9BD67D4A, (cpu, maddr) => {
			});
			// umulh X11, X12, X11
			InsnTester.AutoTest(0x9BCB7D8B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmeq() {
			// cmeq V1.4S, V0.4S, #0
			InsnTester.AutoTest(0x4EA09801, (cpu, maddr) => {
			});
			// cmeq V19.16B, V16.16B, V2.16B
			InsnTester.AutoTest(0x6E228E13, (cpu, maddr) => {
			});
			// cmeq V5.16B, V5.16B, V4.16B
			InsnTester.AutoTest(0x6E248CA5, (cpu, maddr) => {
			});
			// cmeq V5.4S, V4.4S, #0
			InsnTester.AutoTest(0x4EA09885, (cpu, maddr) => {
			});
			// cmeq V3.16B, V2.16B, V0.16B
			InsnTester.AutoTest(0x6E208C43, (cpu, maddr) => {
			});
			// cmeq V18.16B, V7.16B, V3.16B
			InsnTester.AutoTest(0x6E238CF2, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmul() {
			// fmul S6, S0, S0
			InsnTester.AutoTest(0x1E200806, (cpu, maddr) => {
			});
			// fmul V31.4S, V21.4S, V31.S[0]
			InsnTester.AutoTest(0x4F9F92BF, (cpu, maddr) => {
			});
			// fmul S14, S24, S19
			InsnTester.AutoTest(0x1E330B0E, (cpu, maddr) => {
			});
			// fmul S19, S3, S6
			InsnTester.AutoTest(0x1E260873, (cpu, maddr) => {
			});
			// fmul S7, S18, S2
			InsnTester.AutoTest(0x1E220A47, (cpu, maddr) => {
			});
			// fmul S26, S24, S0
			InsnTester.AutoTest(0x1E200B1A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Negs() {
			// negs X2, X2
			InsnTester.AutoTest(0xEB0203E2, (cpu, maddr) => {
			});
			// negs X17, X17
			InsnTester.AutoTest(0xEB1103F1, (cpu, maddr) => {
			});
			// negs X4, X5
			InsnTester.AutoTest(0xEB0503E4, (cpu, maddr) => {
			});
			// negs X0, X0
			InsnTester.AutoTest(0xEB0003E0, (cpu, maddr) => {
			});
			// negs X15, X15
			InsnTester.AutoTest(0xEB0F03EF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Xtn2() {
			// xtn2 V7.8H, V6.4S
			InsnTester.AutoTest(0x4E6128C7, (cpu, maddr) => {
			});
			// xtn2 V7.16B, V17.8H
			InsnTester.AutoTest(0x4E212A27, (cpu, maddr) => {
			});
			// xtn2 V6.16B, V5.8H
			InsnTester.AutoTest(0x4E2128A6, (cpu, maddr) => {
			});
			// xtn2 V4.16B, V3.8H
			InsnTester.AutoTest(0x4E212864, (cpu, maddr) => {
			});
			// xtn2 V7.8H, V16.4S
			InsnTester.AutoTest(0x4E612A07, (cpu, maddr) => {
			});
			// xtn2 V5.8H, V16.4S
			InsnTester.AutoTest(0x4E612A05, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ngcs() {
			// ngcs X3, X3
			InsnTester.AutoTest(0xFA0303E3, (cpu, maddr) => {
			});
			// ngcs X14, X14
			InsnTester.AutoTest(0xFA0E03EE, (cpu, maddr) => {
			});
			// ngcs X1, X1
			InsnTester.AutoTest(0xFA0103E1, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldrh() {
			// ldrh W7, [X1]
			InsnTester.AutoTest(0x79400027, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrh W10, [X11, W10, UXTW #1]
			InsnTester.AutoTest(0x786A596A, (cpu, maddr) => {
				cpu.X[11] = maddr;
				cpu.X[10] = 0x10;
			});
			// ldrh W18, [X3, #6]
			InsnTester.AutoTest(0x79400C72, (cpu, maddr) => {
				cpu.X[3] = maddr;
			});
			// ldrh W9, [X1, #0x96]
			InsnTester.AutoTest(0x79412C29, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrh W12, [X21, #0x60]
			InsnTester.AutoTest(0x7940C2AC, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldrh W8, [X24, #0x160]
			InsnTester.AutoTest(0x7942C308, (cpu, maddr) => {
				cpu.X[24] = maddr;
			});
		}

		[Fact]
		public void LdrsbPreIndex() {
			// ldrsb W9, [X0, #1]!
			InsnTester.AutoTest(0x38C01C09, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsb X11, [X10, #0x11]!
			InsnTester.AutoTest(0x38811D4B, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrsb W8, [X21, #1]!
			InsnTester.AutoTest(0x38C01EA8, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldrsb W12, [X8, #-1]!
			InsnTester.AutoTest(0x38DFFD0C, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsb W9, [X8, #1]!
			InsnTester.AutoTest(0x38C01D09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsb W3, [X12, #0x18]!
			InsnTester.AutoTest(0x38C18D83, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
		}

		[Fact]
		public void Csinv() {
			// csinv W8, W8, W3, GE
			InsnTester.AutoTest(0x5A83A108, (cpu, maddr) => {
			});
			// csinv W18, W16, WZR, LE
			InsnTester.AutoTest(0x5A9FD212, (cpu, maddr) => {
			});
			// csinv W17, W11, W17, GT
			InsnTester.AutoTest(0x5A91C171, (cpu, maddr) => {
			});
			// csinv X1, X24, XZR, NE
			InsnTester.AutoTest(0xDA9F1301, (cpu, maddr) => {
			});
			// csinv W8, W8, WZR, GE
			InsnTester.AutoTest(0x5A9FA108, (cpu, maddr) => {
			});
			// csinv W17, W16, WZR, LE
			InsnTester.AutoTest(0x5A9FD211, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrswPreIndex() {
			// ldrsw X4, [X0, #8]!
			InsnTester.AutoTest(0xB8808C04, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsw X25, [X9, #-0x14]!
			InsnTester.AutoTest(0xB89ECD39, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsw X10, [X22, #0x28]!
			InsnTester.AutoTest(0xB8828ECA, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldrsw X12, [X8, #8]!
			InsnTester.AutoTest(0xB8808D0C, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsw X12, [X11, #0xC]!
			InsnTester.AutoTest(0xB880CD6C, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrsw X10, [X21, #0x28]!
			InsnTester.AutoTest(0xB8828EAA, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
		}

		[Fact]
		public void Faddp() {
			// faddp S3, V5.2S
			InsnTester.AutoTest(0x7E30D8A3, (cpu, maddr) => {
			});
			// faddp V21.2S, V21.2S, V22.2S
			InsnTester.AutoTest(0x2E36D6B5, (cpu, maddr) => {
			});
			// faddp V1.2S, V0.2S, V0.2S
			InsnTester.AutoTest(0x2E20D401, (cpu, maddr) => {
			});
			// faddp S21, V21.2S
			InsnTester.AutoTest(0x7E30DAB5, (cpu, maddr) => {
			});
			// faddp S17, V17.2S
			InsnTester.AutoTest(0x7E30DA31, (cpu, maddr) => {
			});
			// faddp V2.2S, V1.2S, V1.2S
			InsnTester.AutoTest(0x2E21D422, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev32() {
			// rev32 V0.16B, V0.16B
			InsnTester.AutoTest(0x6E200800, (cpu, maddr) => {
			});
			// rev32 V16.16B, V16.16B
			InsnTester.AutoTest(0x6E200A10, (cpu, maddr) => {
			});
			// rev32 V3.16B, V3.16B
			InsnTester.AutoTest(0x6E200863, (cpu, maddr) => {
			});
			// rev32 V1.16B, V1.16B
			InsnTester.AutoTest(0x6E200821, (cpu, maddr) => {
			});
			// rev32 V6.16B, V6.16B
			InsnTester.AutoTest(0x6E2008C6, (cpu, maddr) => {
			});
			// rev32 V2.16B, V2.16B
			InsnTester.AutoTest(0x6E200842, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Csinc() {
			// csinc X6, X9, X0, NE
			InsnTester.AutoTest(0x9A801526, (cpu, maddr) => {
			});
			// csinc W10, WZR, W10, GE
			InsnTester.AutoTest(0x1A8AA7EA, (cpu, maddr) => {
			});
			// csinc W20, W10, W9, LT
			InsnTester.AutoTest(0x1A89B554, (cpu, maddr) => {
			});
			// csinc W8, W8, W9, LE
			InsnTester.AutoTest(0x1A89D508, (cpu, maddr) => {
			});
			// csinc W17, W6, W18, LO
			InsnTester.AutoTest(0x1A9234D1, (cpu, maddr) => {
			});
			// csinc W8, WZR, W9, GE
			InsnTester.AutoTest(0x1A89A7E8, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Dup() {
			// dup V0.4S, W1
			InsnTester.AutoTest(0x4E040C20, (cpu, maddr) => {
			});
			// dup V17.4S, V17.S[0]
			InsnTester.AutoTest(0x4E040631, (cpu, maddr) => {
			});
			// dup V0.4S, V1.S[0]
			InsnTester.AutoTest(0x4E040420, (cpu, maddr) => {
			});
			// dup V6.2S, V5.S[1]
			InsnTester.AutoTest(0x0E0C04A6, (cpu, maddr) => {
			});
			// dup V16.4S, V31.S[0]
			InsnTester.AutoTest(0x4E0407F0, (cpu, maddr) => {
			});
			// dup V0.4S, V1.S[2]
			InsnTester.AutoTest(0x4E140420, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ands() {
			// ands W28, W8, #4
			InsnTester.AutoTest(0x721E011C, (cpu, maddr) => {
			});
			// ands W11, W11, #0xFFFFFFFE
			InsnTester.AutoTest(0x721F796B, (cpu, maddr) => {
			});
			// ands W10, W10, #1
			InsnTester.AutoTest(0x7200014A, (cpu, maddr) => {
			});
			// ands X13, X13, #7
			InsnTester.AutoTest(0xF24009AD, (cpu, maddr) => {
			});
			// ands W13, W10, #0x4000
			InsnTester.AutoTest(0x7212014D, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldar() {
			// ldar W8, [X8]
			InsnTester.AutoTest(0x88DFFD08, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldar X28, [X27]
			InsnTester.AutoTest(0xC8DFFF7C, (cpu, maddr) => {
				cpu.X[27] = maddr;
			});
			// ldar W10, [X20]
			InsnTester.AutoTest(0x88DFFE8A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldar W14, [X13]
			InsnTester.AutoTest(0x88DFFDAE, (cpu, maddr) => {
				cpu.X[13] = maddr;
			});
			// ldar X10, [X8]
			InsnTester.AutoTest(0xC8DFFD0A, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldar W11, [X9]
			InsnTester.AutoTest(0x88DFFD2B, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
		}

		[Fact]
		public void Ldxrh() {
			// ldxrh W8, [X0]
			InsnTester.AutoTest(0x485F7C08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldxrh W10, [X20]
			InsnTester.AutoTest(0x485F7E8A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldxrh W9, [X0]
			InsnTester.AutoTest(0x485F7C09, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldxrh W9, [X20]
			InsnTester.AutoTest(0x485F7E89, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
		}

		[Fact]
		public void Ld1R() {
			// ld1r {V6.4S}, [X8]
			InsnTester.AutoTest(0x4D40C906, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ld1r {V19.4S}, [X10]
			InsnTester.AutoTest(0x4D40C953, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ld1r {V5.4S}, [X10]
			InsnTester.AutoTest(0x4D40C945, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ld1r {V23.4S}, [X10]
			InsnTester.AutoTest(0x4D40C957, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ld1r {V16.4S}, [X10]
			InsnTester.AutoTest(0x4D40C950, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ld1r {V18.4S}, [X14]
			InsnTester.AutoTest(0x4D40C9D2, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
		}

		[Fact]
		public void Fcvtms() {
			// fcvtms W0, S0
			InsnTester.AutoTest(0x1E300000, (cpu, maddr) => {
			});
			// fcvtms W22, S19
			InsnTester.AutoTest(0x1E300276, (cpu, maddr) => {
			});
			// fcvtms W16, S3
			InsnTester.AutoTest(0x1E300070, (cpu, maddr) => {
			});
			// fcvtms W5, S16
			InsnTester.AutoTest(0x1E300205, (cpu, maddr) => {
			});
			// fcvtms W10, S0
			InsnTester.AutoTest(0x1E30000A, (cpu, maddr) => {
			});
			// fcvtms W19, S0
			InsnTester.AutoTest(0x1E300013, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ushll2() {
			// ushll2 V1.4S, V1.8H, #0
			InsnTester.AutoTest(0x6F10A421, (cpu, maddr) => {
			});
			// ushll2 V1.8H, V1.16B, #0
			InsnTester.AutoTest(0x6F08A421, (cpu, maddr) => {
			});
			// ushll2 V2.4S, V2.8H, #0
			InsnTester.AutoTest(0x6F10A442, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldxrb() {
			// ldxrb W8, [X0]
			InsnTester.AutoTest(0x085F7C08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldxrb W9, [X0]
			InsnTester.AutoTest(0x085F7C09, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
		}

		[Fact]
		public void Frsqrts() {
			// frsqrts V2.4S, V0.4S, V2.4S
			InsnTester.AutoTest(0x4EA2FC02, (cpu, maddr) => {
			});
			// frsqrts V31.4S, V30.4S, V31.4S
			InsnTester.AutoTest(0x4EBFFFDF, (cpu, maddr) => {
			});
			// frsqrts V3.4S, V4.4S, V3.4S
			InsnTester.AutoTest(0x4EA3FC83, (cpu, maddr) => {
			});
			// frsqrts V27.4S, V26.4S, V27.4S
			InsnTester.AutoTest(0x4EBBFF5B, (cpu, maddr) => {
			});
			// frsqrts V7.4S, V6.4S, V7.4S
			InsnTester.AutoTest(0x4EA7FCC7, (cpu, maddr) => {
			});
			// frsqrts V5.4S, V17.4S, V19.4S
			InsnTester.AutoTest(0x4EB3FE25, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldursw() {
			// ldursw X8, [X9, #1]
			InsnTester.AutoTest(0xB8801128, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldursw X21, [X29, #-0x14]
			InsnTester.AutoTest(0xB89EC3B5, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldursw X0, [X17, #-4]
			InsnTester.AutoTest(0xB89FC220, (cpu, maddr) => {
				cpu.X[17] = maddr;
			});
			// ldursw X8, [X8, #-4]
			InsnTester.AutoTest(0xB89FC108, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldursw X16, [X10, #-0xC0]
			InsnTester.AutoTest(0xB8940150, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldursw X9, [X25, #-0x1C]
			InsnTester.AutoTest(0xB89E4329, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
		}

		[Fact]
		public void Ldursh() {
			// ldursh X8, [X9, #1]
			InsnTester.AutoTest(0x78801128, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldursh W14, [X23, #-0x10]
			InsnTester.AutoTest(0x78DF02EE, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
			// ldursh W19, [X14, #-0x30]
			InsnTester.AutoTest(0x78DD01D3, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
			// ldursh W9, [X1, #-2]
			InsnTester.AutoTest(0x78DFE029, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldursh W10, [X10, #-4]
			InsnTester.AutoTest(0x78DFC14A, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldursh X18, [X17, #-2]
			InsnTester.AutoTest(0x789FE232, (cpu, maddr) => {
				cpu.X[17] = maddr;
			});
		}

		[Fact]
		public void LdrhPostIndex() {
			// ldrh W5, [X6], #2
			InsnTester.AutoTest(0x784024C5, (cpu, maddr) => {
				cpu.X[6] = maddr;
			});
			// ldrh W13, [X11], #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0x785FE56D, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrh W8, [X25], #2
			InsnTester.AutoTest(0x78402728, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
			// ldrh W5, [X8], #2
			InsnTester.AutoTest(0x78402505, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrh W14, [X13], #2
			InsnTester.AutoTest(0x784025AE, (cpu, maddr) => {
				cpu.X[13] = maddr;
			});
			// ldrh W9, [X0], #2
			InsnTester.AutoTest(0x78402409, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
		}

		[Fact]
		public void Xtn() {
			// xtn V4.2S, V1.2D
			InsnTester.AutoTest(0x0EA12824, (cpu, maddr) => {
			});
			// xtn V13.4H, V10.4S
			InsnTester.AutoTest(0x0E61294D, (cpu, maddr) => {
			});
			// xtn V4.4H, V4.4S
			InsnTester.AutoTest(0x0E612884, (cpu, maddr) => {
			});
			// xtn V1.2S, V0.2D
			InsnTester.AutoTest(0x0EA12801, (cpu, maddr) => {
			});
			// xtn V18.2S, V7.2D
			InsnTester.AutoTest(0x0EA128F2, (cpu, maddr) => {
			});
			// xtn V4.4H, V24.4S
			InsnTester.AutoTest(0x0E612B04, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrbPreIndex() {
			// ldrb W4, [X5, #1]!
			InsnTester.AutoTest(0x38401CA4, (cpu, maddr) => {
				cpu.X[5] = maddr;
			});
			// ldrb W11, [X10, #-0x10]!
			InsnTester.AutoTest(0x385F0D4B, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrb W8, [X22, #0x15]!
			InsnTester.AutoTest(0x38415EC8, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldrb W15, [X14, #1]!
			InsnTester.AutoTest(0x38401DCF, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
			// ldrb W11, [X10, #0xC0]!
			InsnTester.AutoTest(0x384C0D4B, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrb W10, [X9, #3]!
			InsnTester.AutoTest(0x38403D2A, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
		}

		[Fact]
		public void Frsqrte() {
			// frsqrte V0.4S, V1.4S
			InsnTester.AutoTest(0x6EA1D820, (cpu, maddr) => {
			});
			// frsqrte V17.4S, V16.4S
			InsnTester.AutoTest(0x6EA1DA11, (cpu, maddr) => {
			});
			// frsqrte V1.4S, V4.4S
			InsnTester.AutoTest(0x6EA1D881, (cpu, maddr) => {
			});
			// frsqrte V7.4S, V5.4S
			InsnTester.AutoTest(0x6EA1D8A7, (cpu, maddr) => {
			});
			// frsqrte V18.4S, V17.4S
			InsnTester.AutoTest(0x6EA1DA32, (cpu, maddr) => {
			});
			// frsqrte V26.4S, V25.4S
			InsnTester.AutoTest(0x6EA1DB3A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frintx() {
			// frintx S2, S1
			InsnTester.AutoTest(0x1E274022, (cpu, maddr) => {
			});
			// frintx D8, D8
			InsnTester.AutoTest(0x1E674108, (cpu, maddr) => {
			});
			// frintx S0, S0
			InsnTester.AutoTest(0x1E274000, (cpu, maddr) => {
			});
			// frintx D2, D1
			InsnTester.AutoTest(0x1E674022, (cpu, maddr) => {
			});
			// frintx S8, S8
			InsnTester.AutoTest(0x1E274108, (cpu, maddr) => {
			});
			// frintx D0, D0
			InsnTester.AutoTest(0x1E674000, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Madd() {
			// madd W0, W1, W1, W0
			InsnTester.AutoTest(0x1B010020, (cpu, maddr) => {
			});
			// madd X16, X10, X16, X15
			InsnTester.AutoTest(0x9B103D50, (cpu, maddr) => {
			});
			// madd X24, X26, X9, X8
			InsnTester.AutoTest(0x9B092358, (cpu, maddr) => {
			});
			// madd X8, X12, X9, X8
			InsnTester.AutoTest(0x9B092188, (cpu, maddr) => {
			});
			// madd W11, W11, W12, W13
			InsnTester.AutoTest(0x1B0C356B, (cpu, maddr) => {
			});
			// madd W0, W25, W23, W0
			InsnTester.AutoTest(0x1B170320, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmp() {
			// fcmp S1, S0
			InsnTester.AutoTest(0x1E202020, (cpu, maddr) => {
			});
			// fcmp D11, #0.0
			InsnTester.AutoTest(0x1E602168, (cpu, maddr) => {
			});
			// fcmp S14, S13
			InsnTester.AutoTest(0x1E2D21C0, (cpu, maddr) => {
			});
			// fcmp S6, S4
			InsnTester.AutoTest(0x1E2420C0, (cpu, maddr) => {
			});
			// fcmp S0, S10
			InsnTester.AutoTest(0x1E2A2000, (cpu, maddr) => {
			});
			// fcmp S26, S8
			InsnTester.AutoTest(0x1E282340, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrbPostIndex() {
			// ldrb W8, [X0], #1
			InsnTester.AutoTest(0x38401408, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrb W18, [X11], #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(0x385FF572, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrb W10, [X20], #1
			InsnTester.AutoTest(0x3840168A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldrb W12, [X10], #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(0x385FF54C, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrb W2, [X1], #1
			InsnTester.AutoTest(0x38401422, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrb W11, [X1], #1
			InsnTester.AutoTest(0x3840142B, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
		}

		[Fact]
		public void Ldrsb() {
			// ldrsb X8, [X8]
			InsnTester.AutoTest(0x39800108, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsb W15, [X10, W15, SXTW]
			InsnTester.AutoTest(0x38EFC94F, (cpu, maddr) => {
				cpu.X[10] = maddr;
				cpu.X[15] = 0x10;
			});
			// ldrsb W9, [X0, #1]
			InsnTester.AutoTest(0x39C00409, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsb W15, [X16, #2]
			InsnTester.AutoTest(0x39C00A0F, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldrsb X8, [X27, #0x10]
			InsnTester.AutoTest(0x39804368, (cpu, maddr) => {
				cpu.X[27] = maddr;
			});
			// ldrsb X8, [X22, #0x11]
			InsnTester.AutoTest(0x398046C8, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
		}

		[Fact]
		public void Fdiv() {
			// fdiv S5, S2, S0
			InsnTester.AutoTest(0x1E201845, (cpu, maddr) => {
			});
			// fdiv S21, S22, S21
			InsnTester.AutoTest(0x1E351AD5, (cpu, maddr) => {
			});
			// fdiv D10, D0, D1
			InsnTester.AutoTest(0x1E61180A, (cpu, maddr) => {
			});
			// fdiv S18, S19, S18
			InsnTester.AutoTest(0x1E321A72, (cpu, maddr) => {
			});
			// fdiv S7, S7, S16
			InsnTester.AutoTest(0x1E3018E7, (cpu, maddr) => {
			});
			// fdiv S0, S4, S12
			InsnTester.AutoTest(0x1E2C1880, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldxr() {
			// ldxr W8, [X0]
			InsnTester.AutoTest(0x885F7C08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldxr X26, [X27]
			InsnTester.AutoTest(0xC85F7F7A, (cpu, maddr) => {
				cpu.X[27] = maddr;
			});
			// ldxr W8, [X25]
			InsnTester.AutoTest(0x885F7F28, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
			// ldxr WZR, [X8]
			InsnTester.AutoTest(0x885F7D1F, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldxr W9, [X10]
			InsnTester.AutoTest(0x885F7D49, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldxr W12, [X9]
			InsnTester.AutoTest(0x885F7D2C, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
		}

		[Fact]
		public void Prfm() {
			// prfm PLDL2STRM, [X8]
			InsnTester.AutoTest(0xF9800103, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// prfm PSTL1KEEP, [X9, #0x40]
			InsnTester.AutoTest(0xF9802130, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// prfm PSTL2STRM, [X9]
			InsnTester.AutoTest(0xF9800133, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// prfm PSTL1KEEP, [X8, #0x40]
			InsnTester.AutoTest(0xF9802110, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// prfm PLDL1KEEP, [X9, #0x40]
			InsnTester.AutoTest(0xF9802120, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// prfm PLDL2STRM, [X9]
			InsnTester.AutoTest(0xF9800123, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
		}

		[Fact]
		public void LdrshPreIndex() {
			// ldrsh W6, [X5, #8]!
			InsnTester.AutoTest(0x78C08CA6, (cpu, maddr) => {
				cpu.X[5] = maddr;
			});
			// ldrsh W13, [X12, #-0x60]!
			InsnTester.AutoTest(0x78DA0D8D, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ldrsh W2, [X3, #0x6C]!
			InsnTester.AutoTest(0x78C6CC62, (cpu, maddr) => {
				cpu.X[3] = maddr;
			});
			// ldrsh W9, [X22, #4]!
			InsnTester.AutoTest(0x78C04EC9, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldrsh W9, [X24, #-2]!
			InsnTester.AutoTest(0x78DFEF09, (cpu, maddr) => {
				cpu.X[24] = maddr;
			});
			// ldrsh W17, [X18, #-0x60]!
			InsnTester.AutoTest(0x78DA0E51, (cpu, maddr) => {
				cpu.X[18] = maddr;
			});
		}

		[Fact]
		public void Dmb() {
			// dmb ISH
			InsnTester.AutoTest(0xD5033BBF, (cpu, maddr) => {
			});
			// dmb ISHST
			InsnTester.AutoTest(0xD5033ABF, (cpu, maddr) => {
			});
			// dmb ISHLD
			InsnTester.AutoTest(0xD50339BF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void And() {
			// and W2, W8, #1
			InsnTester.AutoTest(0x12000102, (cpu, maddr) => {
			});
			// and X26, X26, #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0x927FFB5A, (cpu, maddr) => {
			});
			// and X24, X24, X6
			InsnTester.AutoTest(0x8A060318, (cpu, maddr) => {
			});
			// and W10, W23, #0xFFFF
			InsnTester.AutoTest(0x12003EEA, (cpu, maddr) => {
			});
			// and W5, W1, #2
			InsnTester.AutoTest(0x121F0025, (cpu, maddr) => {
			});
			// and W25, W8, #0x1F8000
			InsnTester.AutoTest(0x12111519, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Pmull() {
			// pmull V0.1Q, V1.1D, V0.1D
			InsnTester.AutoTest(0x0EE0E020, (cpu, maddr) => {
			});
			// pmull V31.1Q, V19.1D, V1.1D
			InsnTester.AutoTest(0x0EE1E27F, (cpu, maddr) => {
			});
			// pmull V16.1Q, V6.1D, V7.1D
			InsnTester.AutoTest(0x0EE7E0D0, (cpu, maddr) => {
			});
			// pmull V3.1Q, V0.1D, V3.1D
			InsnTester.AutoTest(0x0EE3E003, (cpu, maddr) => {
			});
			// pmull V29.1Q, V17.1D, V2.1D
			InsnTester.AutoTest(0x0EE2E23D, (cpu, maddr) => {
			});
			// pmull V1.1Q, V2.1D, V0.1D
			InsnTester.AutoTest(0x0EE0E041, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmhi() {
			// cmhi V2.8H, V2.8H, V0.8H
			InsnTester.AutoTest(0x6E603442, (cpu, maddr) => {
			});
			// cmhi V3.8H, V3.8H, V0.8H
			InsnTester.AutoTest(0x6E603463, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Shrn() {
			// shrn V3.2S, V0.2D, #0x20
			InsnTester.AutoTest(0x0F208403, (cpu, maddr) => {
			});
			// shrn V17.2S, V6.2D, #0x20
			InsnTester.AutoTest(0x0F2084D1, (cpu, maddr) => {
			});
			// shrn V1.2S, V4.2D, #0x20
			InsnTester.AutoTest(0x0F208481, (cpu, maddr) => {
			});
			// shrn V5.2S, V1.2D, #0x20
			InsnTester.AutoTest(0x0F208425, (cpu, maddr) => {
			});
			// shrn V2.2S, V0.2D, #0x20
			InsnTester.AutoTest(0x0F208402, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ins() {
			// ins V0.S[0], W8
			InsnTester.AutoTest(0x4E041D00, (cpu, maddr) => {
			});
			// ins V31.S[1], V24.S[1]
			InsnTester.AutoTest(0x6E0C271F, (cpu, maddr) => {
			});
			// ins V6.S[2], V2.S[0]
			InsnTester.AutoTest(0x6E140446, (cpu, maddr) => {
			});
			// ins V27.S[1], V26.S[0]
			InsnTester.AutoTest(0x6E0C075B, (cpu, maddr) => {
			});
			// ins V3.S[3], V22.S[3]
			InsnTester.AutoTest(0x6E1C66C3, (cpu, maddr) => {
			});
			// ins V1.S[1], V2.S[0]
			InsnTester.AutoTest(0x6E0C0441, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Dc() {
			// dc CVAU, X11
			InsnTester.AutoTest(0xD50B7B2B, (cpu, maddr) => {
			});
			// dc CIVAC, X10
			InsnTester.AutoTest(0xD50B7E2A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ld1PostIndex() {
			// ld1 {V0.S}[0], [X8], #4
			InsnTester.AutoTest(0x0DDF8100, (cpu, maddr) => {
			});
			// ld1 {V16.S}[3], [X21], #4
			InsnTester.AutoTest(0x4DDF92B0, (cpu, maddr) => {
			});
			// ld1 {V2.S}[0], [X10], #4
			InsnTester.AutoTest(0x0DDF8142, (cpu, maddr) => {
			});
			// ld1 {V4.S}[0], [X8], #4
			InsnTester.AutoTest(0x0DDF8104, (cpu, maddr) => {
			});
			// ld1 {V2.S}[0], [X9], #4
			InsnTester.AutoTest(0x0DDF8122, (cpu, maddr) => {
			});
			// ld1 {V5.S}[1], [X10], #4
			InsnTester.AutoTest(0x0DDF9145, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmlt() {
			// fcmlt V19.4S, V7.4S, #0.0
			InsnTester.AutoTest(0x4EA0E8F3, (cpu, maddr) => {
			});
			// fcmlt V27.4S, V29.4S, #0.0
			InsnTester.AutoTest(0x4EA0EBBB, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Csetm() {
			// csetm W0, HI
			InsnTester.AutoTest(0x5A9F93E0, (cpu, maddr) => {
			});
			// csetm W23, LE
			InsnTester.AutoTest(0x5A9FC3F7, (cpu, maddr) => {
			});
			// csetm W5, EQ
			InsnTester.AutoTest(0x5A9F13E5, (cpu, maddr) => {
			});
			// csetm W22, LT
			InsnTester.AutoTest(0x5A9FA3F6, (cpu, maddr) => {
			});
			// csetm W14, HS
			InsnTester.AutoTest(0x5A9F33EE, (cpu, maddr) => {
			});
			// csetm W8, NE
			InsnTester.AutoTest(0x5A9F03E8, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrPostIndex() {
			// ldr W5, [X0], #4
			InsnTester.AutoTest(0xB8404405, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldr W23, [X20], #0xFFFFFFFFFFFFFFFC
			InsnTester.AutoTest(0xB85FC697, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldr X22, [X21], #8
			InsnTester.AutoTest(0xF84086B6, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldr X1, [SP], #8
			InsnTester.AutoTest(0xF84087E1, (cpu, maddr) => {
			});
			// ldr W8, [X20], #4
			InsnTester.AutoTest(0xB8404688, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldr S2, [X12], #4
			InsnTester.AutoTest(0xBC404582, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
		}

		[Fact]
		public void Fmls() {
			// fmls V6.4S, V2.4S, V0.4S
			InsnTester.AutoTest(0x4EA0CC46, (cpu, maddr) => {
			});
			// fmls V27.4S, V26.4S, V28.S[0]
			InsnTester.AutoTest(0x4F9C535B, (cpu, maddr) => {
			});
			// fmls V1.4S, V17.4S, V5.4S
			InsnTester.AutoTest(0x4EA5CE21, (cpu, maddr) => {
			});
			// fmls V6.4S, V7.4S, V2.S[1]
			InsnTester.AutoTest(0x4FA250E6, (cpu, maddr) => {
			});
			// fmls V25.4S, V18.4S, V5.S[0]
			InsnTester.AutoTest(0x4F855259, (cpu, maddr) => {
			});
			// fmls V6.4S, V25.4S, V7.4S
			InsnTester.AutoTest(0x4EA7CF26, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fabs() {
			// fabs S2, S0
			InsnTester.AutoTest(0x1E20C002, (cpu, maddr) => {
			});
			// fabs V25.4S, V29.4S
			InsnTester.AutoTest(0x4EA0FBB9, (cpu, maddr) => {
			});
			// fabs S6, S6
			InsnTester.AutoTest(0x1E20C0C6, (cpu, maddr) => {
			});
			// fabs D4, D0
			InsnTester.AutoTest(0x1E60C004, (cpu, maddr) => {
			});
			// fabs S4, S4
			InsnTester.AutoTest(0x1E20C084, (cpu, maddr) => {
			});
			// fabs S9, S0
			InsnTester.AutoTest(0x1E20C009, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldaxrh() {
			// ldaxrh W8, [X0]
			InsnTester.AutoTest(0x485FFC08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxrh W10, [X20]
			InsnTester.AutoTest(0x485FFE8A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldaxrh W9, [X0]
			InsnTester.AutoTest(0x485FFC09, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxrh W10, [X0]
			InsnTester.AutoTest(0x485FFC0A, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldaxrh W9, [X20]
			InsnTester.AutoTest(0x485FFE89, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
		}

		[Fact]
		public void Csel() {
			// csel W0, W2, W0, LO
			InsnTester.AutoTest(0x1A803040, (cpu, maddr) => {
			});
			// csel W16, W16, W18, HI
			InsnTester.AutoTest(0x1A928210, (cpu, maddr) => {
			});
			// csel X7, X11, X10, EQ
			InsnTester.AutoTest(0x9A8A0167, (cpu, maddr) => {
			});
			// csel W11, W14, W11, EQ
			InsnTester.AutoTest(0x1A8B01CB, (cpu, maddr) => {
			});
			// csel W22, W8, W27, GT
			InsnTester.AutoTest(0x1A9BC116, (cpu, maddr) => {
			});
			// csel W11, W9, WZR, LT
			InsnTester.AutoTest(0x1A9FB12B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cinc() {
			// cinc W8, W0, EQ
			InsnTester.AutoTest(0x1A801408, (cpu, maddr) => {
			});
			// cinc W12, W10, LT
			InsnTester.AutoTest(0x1A8AA54C, (cpu, maddr) => {
			});
			// cinc W10, W8, LS
			InsnTester.AutoTest(0x1A88850A, (cpu, maddr) => {
			});
			// cinc W8, W8, HS
			InsnTester.AutoTest(0x1A883508, (cpu, maddr) => {
			});
			// cinc W8, W26, NE
			InsnTester.AutoTest(0x1A9A0748, (cpu, maddr) => {
			});
			// cinc W14, W15, NE
			InsnTester.AutoTest(0x1A8F05EE, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cset() {
			// cset W0, MI
			InsnTester.AutoTest(0x1A9F57E0, (cpu, maddr) => {
			});
			// cset W28, GT
			InsnTester.AutoTest(0x1A9FD7FC, (cpu, maddr) => {
			});
			// cset W9, LT
			InsnTester.AutoTest(0x1A9FA7E9, (cpu, maddr) => {
			});
			// cset W13, GE
			InsnTester.AutoTest(0x1A9FB7ED, (cpu, maddr) => {
			});
			// cset W24, MI
			InsnTester.AutoTest(0x1A9F57F8, (cpu, maddr) => {
			});
			// cset W14, LT
			InsnTester.AutoTest(0x1A9FA7EE, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmla() {
			// fmla V3.4S, V1.4S, V0.4S
			InsnTester.AutoTest(0x4E20CC23, (cpu, maddr) => {
			});
			// fmla V22.4S, V20.4S, V16.S[2]
			InsnTester.AutoTest(0x4F901A96, (cpu, maddr) => {
			});
			// fmla V24.4S, V7.4S, V20.S[1]
			InsnTester.AutoTest(0x4FB410F8, (cpu, maddr) => {
			});
			// fmla V3.4S, V1.4S, V2.S[1]
			InsnTester.AutoTest(0x4FA21023, (cpu, maddr) => {
			});
			// fmla V2.4S, V1.4S, V16.S[2]
			InsnTester.AutoTest(0x4F901822, (cpu, maddr) => {
			});
			// fmla V21.4S, V29.4S, V7.4S
			InsnTester.AutoTest(0x4E27CFB5, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frecps() {
			// frecps V1.4S, V2.4S, V1.4S
			InsnTester.AutoTest(0x4E21FC41, (cpu, maddr) => {
			});
			// frecps V30.4S, V31.4S, V30.4S
			InsnTester.AutoTest(0x4E3EFFFE, (cpu, maddr) => {
			});
			// frecps V8.4S, V31.4S, V26.4S
			InsnTester.AutoTest(0x4E3AFFE8, (cpu, maddr) => {
			});
			// frecps V6.4S, V17.4S, V6.4S
			InsnTester.AutoTest(0x4E26FE26, (cpu, maddr) => {
			});
			// frecps V8.4S, V31.4S, V25.4S
			InsnTester.AutoTest(0x4E39FFE8, (cpu, maddr) => {
			});
			// frecps V7.4S, V5.4S, V4.4S
			InsnTester.AutoTest(0x4E24FCA7, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cinv() {
			// cinv W0, W8, NE
			InsnTester.AutoTest(0x5A880100, (cpu, maddr) => {
			});
			// cinv W10, W10, LT
			InsnTester.AutoTest(0x5A8AA14A, (cpu, maddr) => {
			});
			// cinv W9, W10, HS
			InsnTester.AutoTest(0x5A8A3149, (cpu, maddr) => {
			});
			// cinv W9, W9, LT
			InsnTester.AutoTest(0x5A89A129, (cpu, maddr) => {
			});
			// cinv W8, W8, LT
			InsnTester.AutoTest(0x5A88A108, (cpu, maddr) => {
			});
			// cinv X1, X8, NE
			InsnTester.AutoTest(0xDA880101, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Mneg() {
			// mneg X8, X0, X8
			InsnTester.AutoTest(0x9B08FC08, (cpu, maddr) => {
			});
			// mneg X15, X15, X12
			InsnTester.AutoTest(0x9B0CFDEF, (cpu, maddr) => {
			});
			// mneg X16, X16, X17
			InsnTester.AutoTest(0x9B11FE10, (cpu, maddr) => {
			});
			// mneg X14, X10, X12
			InsnTester.AutoTest(0x9B0CFD4E, (cpu, maddr) => {
			});
			// mneg W12, W12, W20
			InsnTester.AutoTest(0x1B14FD8C, (cpu, maddr) => {
			});
			// mneg X17, X15, X13
			InsnTester.AutoTest(0x9B0DFDF1, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrswPostIndex() {
			// ldrsw X7, [X2], #4
			InsnTester.AutoTest(0xB8804447, (cpu, maddr) => {
				cpu.X[2] = maddr;
			});
			// ldrsw X15, [X16], #0xFFFFFFFFFFFFFFFC
			InsnTester.AutoTest(0xB89FC60F, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldrsw X2, [X9], #0xFFFFFFFFFFFFFFFC
			InsnTester.AutoTest(0xB89FC522, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsw X10, [X7], #4
			InsnTester.AutoTest(0xB88044EA, (cpu, maddr) => {
				cpu.X[7] = maddr;
			});
			// ldrsw X0, [X15], #4
			InsnTester.AutoTest(0xB88045E0, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ldrsw X8, [X1], #4
			InsnTester.AutoTest(0xB8804428, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
		}

		[Fact]
		public void Pmull2() {
			// pmull2 V0.1Q, V0.2D, V1.2D
			InsnTester.AutoTest(0x4EE1E000, (cpu, maddr) => {
			});
			// pmull2 V26.1Q, V18.2D, V8.2D
			InsnTester.AutoTest(0x4EE8E25A, (cpu, maddr) => {
			});
			// pmull2 V17.1Q, V17.2D, V2.2D
			InsnTester.AutoTest(0x4EE2E231, (cpu, maddr) => {
			});
			// pmull2 V27.1Q, V19.2D, V1.2D
			InsnTester.AutoTest(0x4EE1E27B, (cpu, maddr) => {
			});
			// pmull2 V19.1Q, V19.2D, V1.2D
			InsnTester.AutoTest(0x4EE1E273, (cpu, maddr) => {
			});
			// pmull2 V16.1Q, V16.2D, V3.2D
			InsnTester.AutoTest(0x4EE3E210, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fminnm() {
			// fminnm S1, S1, S0
			InsnTester.AutoTest(0x1E207821, (cpu, maddr) => {
			});
			// fminnm S24, S23, S24
			InsnTester.AutoTest(0x1E387AF8, (cpu, maddr) => {
			});
			// fminnm S9, S0, S2
			InsnTester.AutoTest(0x1E227809, (cpu, maddr) => {
			});
			// fminnm S2, S0, S1
			InsnTester.AutoTest(0x1E217802, (cpu, maddr) => {
			});
			// fminnm S4, S4, S0
			InsnTester.AutoTest(0x1E207884, (cpu, maddr) => {
			});
			// fminnm S3, S16, S17
			InsnTester.AutoTest(0x1E317A03, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sxtw() {
			// sxtw X1, W1
			InsnTester.AutoTest(0x93407C21, (cpu, maddr) => {
			});
			// sxtw X24, W29
			InsnTester.AutoTest(0x93407FB8, (cpu, maddr) => {
			});
			// sxtw X23, W25
			InsnTester.AutoTest(0x93407F37, (cpu, maddr) => {
			});
			// sxtw X22, W15
			InsnTester.AutoTest(0x93407DF6, (cpu, maddr) => {
			});
			// sxtw X8, W9
			InsnTester.AutoTest(0x93407D28, (cpu, maddr) => {
			});
			// sxtw X12, W24
			InsnTester.AutoTest(0x93407F0C, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmgt() {
			// fcmgt V1.4S, V3.4S, V1.4S
			InsnTester.AutoTest(0x6EA1E461, (cpu, maddr) => {
			});
			// fcmgt V30.4S, V17.4S, V28.4S
			InsnTester.AutoTest(0x6EBCE63E, (cpu, maddr) => {
			});
			// fcmgt V27.4S, V25.4S, V7.4S
			InsnTester.AutoTest(0x6EA7E73B, (cpu, maddr) => {
			});
			// fcmgt V7.4S, V31.4S, V7.4S
			InsnTester.AutoTest(0x6EA7E7E7, (cpu, maddr) => {
			});
			// fcmgt V6.2S, V0.2S, V4.2S
			InsnTester.AutoTest(0x2EA4E406, (cpu, maddr) => {
			});
			// fcmgt V5.4S, V6.4S, V2.4S
			InsnTester.AutoTest(0x6EA2E4C5, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Addv() {
			// addv B1, V0.8B
			InsnTester.AutoTest(0x0E31B801, (cpu, maddr) => {
			});
			// addv S17, V17.4S
			InsnTester.AutoTest(0x4EB1BA31, (cpu, maddr) => {
			});
			// addv H2, V2.8H
			InsnTester.AutoTest(0x4E71B842, (cpu, maddr) => {
			});
			// addv S7, V7.4S
			InsnTester.AutoTest(0x4EB1B8E7, (cpu, maddr) => {
			});
			// addv S2, V2.4S
			InsnTester.AutoTest(0x4EB1B842, (cpu, maddr) => {
			});
			// addv S6, V6.4S
			InsnTester.AutoTest(0x4EB1B8C6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bic() {
			// bic W8, W1, W8
			InsnTester.AutoTest(0x0A280028, (cpu, maddr) => {
			});
			// bic V30.16B, V30.16B, V27.16B
			InsnTester.AutoTest(0x4E7B1FDE, (cpu, maddr) => {
			});
			// bic V3.16B, V4.16B, V2.16B
			InsnTester.AutoTest(0x4E621C83, (cpu, maddr) => {
			});
			// bic W10, W10, W12
			InsnTester.AutoTest(0x0A2C014A, (cpu, maddr) => {
			});
			// bic X13, X14, X13
			InsnTester.AutoTest(0x8A2D01CD, (cpu, maddr) => {
			});
			// bic V16.16B, V21.16B, V16.16B
			InsnTester.AutoTest(0x4E701EB0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bsl() {
			// bsl V5.8B, V3.8B, V0.8B
			InsnTester.AutoTest(0x2E601C65, (cpu, maddr) => {
			});
			// bsl V27.16B, V30.16B, V31.16B
			InsnTester.AutoTest(0x6E7F1FDB, (cpu, maddr) => {
			});
			// bsl V19.16B, V8.16B, V4.16B
			InsnTester.AutoTest(0x6E641D13, (cpu, maddr) => {
			});
			// bsl V4.16B, V1.16B, V5.16B
			InsnTester.AutoTest(0x6E651C24, (cpu, maddr) => {
			});
			// bsl V3.16B, V21.16B, V20.16B
			InsnTester.AutoTest(0x6E741EA3, (cpu, maddr) => {
			});
			// bsl V7.16B, V16.16B, V2.16B
			InsnTester.AutoTest(0x6E621E07, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmge() {
			// fcmge V4.4S, V3.4S, #0.0
			InsnTester.AutoTest(0x6EA0C864, (cpu, maddr) => {
			});
			// fcmge V24.4S, V24.4S, V28.4S
			InsnTester.AutoTest(0x6E3CE718, (cpu, maddr) => {
			});
			// fcmge V5.4S, V6.4S, V5.4S
			InsnTester.AutoTest(0x6E25E4C5, (cpu, maddr) => {
			});
			// fcmge V27.4S, V25.4S, V8.4S
			InsnTester.AutoTest(0x6E28E73B, (cpu, maddr) => {
			});
			// fcmge V21.4S, V4.4S, #0.0
			InsnTester.AutoTest(0x6EA0C895, (cpu, maddr) => {
			});
			// fcmge V26.4S, V23.4S, #0.0
			InsnTester.AutoTest(0x6EA0CAFA, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Msub() {
			// msub W0, W2, W0, W1
			InsnTester.AutoTest(0x1B008440, (cpu, maddr) => {
			});
			// msub W15, W18, W15, W19
			InsnTester.AutoTest(0x1B0FCE4F, (cpu, maddr) => {
			});
			// msub W9, W10, W9, W19
			InsnTester.AutoTest(0x1B09CD49, (cpu, maddr) => {
			});
			// msub W9, W8, W1, W9
			InsnTester.AutoTest(0x1B01A509, (cpu, maddr) => {
			});
			// msub W8, W8, W9, W0
			InsnTester.AutoTest(0x1B098108, (cpu, maddr) => {
			});
			// msub W5, W10, W12, W8
			InsnTester.AutoTest(0x1B0CA145, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umaddl() {
			// umaddl X8, W3, W1, X8
			InsnTester.AutoTest(0x9BA12068, (cpu, maddr) => {
			});
			// umaddl X22, W10, W21, X24
			InsnTester.AutoTest(0x9BB56156, (cpu, maddr) => {
			});
			// umaddl X8, W27, W9, X8
			InsnTester.AutoTest(0x9BA92368, (cpu, maddr) => {
			});
			// umaddl X16, W15, W20, X14
			InsnTester.AutoTest(0x9BB439F0, (cpu, maddr) => {
			});
			// umaddl X11, W10, W8, X11
			InsnTester.AutoTest(0x9BA82D4B, (cpu, maddr) => {
			});
			// umaddl X12, W12, W8, X11
			InsnTester.AutoTest(0x9BA82D8C, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldrsh() {
			// ldrsh W0, [X0]
			InsnTester.AutoTest(0x79C00000, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsh W15, [X20, W15, SXTW #1]
			InsnTester.AutoTest(0x78EFDA8F, (cpu, maddr) => {
				cpu.X[20] = maddr;
				cpu.X[15] = 0x10;
			});
			// ldrsh X24, [X1, W24, UXTW #1]
			InsnTester.AutoTest(0x78B85838, (cpu, maddr) => {
				cpu.X[1] = maddr;
				cpu.X[24] = 0x10;
			});
			// ldrsh W8, [X19, X10, LSL #1]
			InsnTester.AutoTest(0x78EA7A68, (cpu, maddr) => {
				cpu.X[19] = maddr;
				cpu.X[10] = 0x10;
			});
			// ldrsh W25, [X19, #0x1E]
			InsnTester.AutoTest(0x79C03E79, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldrsh W1, [X20, #0x90]
			InsnTester.AutoTest(0x79C12281, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
		}

		[Fact]
		public void Sbfiz() {
			// sbfiz X8, X8, #1, #8
			InsnTester.AutoTest(0x937F1D08, (cpu, maddr) => {
			});
			// sbfiz X13, X13, #0x20, #0x20
			InsnTester.AutoTest(0x93607DAD, (cpu, maddr) => {
			});
			// sbfiz X24, X8, #3, #0x20
			InsnTester.AutoTest(0x937D7D18, (cpu, maddr) => {
			});
			// sbfiz X30, X27, #1, #0x20
			InsnTester.AutoTest(0x937F7F7E, (cpu, maddr) => {
			});
			// sbfiz X9, X4, #1, #0x20
			InsnTester.AutoTest(0x937F7C89, (cpu, maddr) => {
			});
			// sbfiz X2, X1, #1, #0x20
			InsnTester.AutoTest(0x937F7C22, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umull() {
			// umull X4, W8, W9
			InsnTester.AutoTest(0x9BA97D04, (cpu, maddr) => {
			});
			// umull X11, W11, W10
			InsnTester.AutoTest(0x9BAA7D6B, (cpu, maddr) => {
			});
			// umull X20, W20, W17
			InsnTester.AutoTest(0x9BB17E94, (cpu, maddr) => {
			});
			// umull X9, W8, W25
			InsnTester.AutoTest(0x9BB97D09, (cpu, maddr) => {
			});
			// umull X14, W17, W13
			InsnTester.AutoTest(0x9BAD7E2E, (cpu, maddr) => {
			});
			// umull X22, W23, W13
			InsnTester.AutoTest(0x9BAD7EF6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sdiv() {
			// sdiv W8, W2, W1
			InsnTester.AutoTest(0x1AC10C48, (cpu, maddr) => {
			});
			// sdiv W12, W13, W12
			InsnTester.AutoTest(0x1ACC0DAC, (cpu, maddr) => {
			});
			// sdiv W21, W11, W21
			InsnTester.AutoTest(0x1AD50D75, (cpu, maddr) => {
			});
			// sdiv W13, W13, W12
			InsnTester.AutoTest(0x1ACC0DAD, (cpu, maddr) => {
			});
			// sdiv W0, W8, W19
			InsnTester.AutoTest(0x1AD30D00, (cpu, maddr) => {
			});
			// sdiv W17, W16, W10
			InsnTester.AutoTest(0x1ACA0E11, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtzu() {
			// fcvtzu W3, S0
			InsnTester.AutoTest(0x1E390003, (cpu, maddr) => {
			});
			// fcvtzu W16, S0, #0x10
			InsnTester.AutoTest(0x1E19C010, (cpu, maddr) => {
			});
			// fcvtzu W1, S0
			InsnTester.AutoTest(0x1E390001, (cpu, maddr) => {
			});
			// fcvtzu W10, S1
			InsnTester.AutoTest(0x1E39002A, (cpu, maddr) => {
			});
			// fcvtzu W12, S4
			InsnTester.AutoTest(0x1E39008C, (cpu, maddr) => {
			});
			// fcvtzu W8, D0
			InsnTester.AutoTest(0x1E790008, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rbit() {
			// rbit X8, X0
			InsnTester.AutoTest(0xDAC00008, (cpu, maddr) => {
			});
			// rbit X11, X12
			InsnTester.AutoTest(0xDAC0018B, (cpu, maddr) => {
			});
			// rbit W8, W0
			InsnTester.AutoTest(0x5AC00008, (cpu, maddr) => {
			});
			// rbit W10, W9
			InsnTester.AutoTest(0x5AC0012A, (cpu, maddr) => {
			});
			// rbit W19, W15
			InsnTester.AutoTest(0x5AC001F3, (cpu, maddr) => {
			});
			// rbit X8, X1
			InsnTester.AutoTest(0xDAC00028, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtpu() {
			// fcvtpu X0, S0
			InsnTester.AutoTest(0x9E290000, (cpu, maddr) => {
			});
			// fcvtpu X9, S0
			InsnTester.AutoTest(0x9E290009, (cpu, maddr) => {
			});
			// fcvtpu W8, S0
			InsnTester.AutoTest(0x1E290008, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Eor() {
			// eor W8, W1, W0
			InsnTester.AutoTest(0x4A000028, (cpu, maddr) => {
			});
			// eor X15, X12, #0x7FFF000000000000
			InsnTester.AutoTest(0xD250398F, (cpu, maddr) => {
			});
			// eor W10, W10, #0x7F
			InsnTester.AutoTest(0x5200194A, (cpu, maddr) => {
			});
			// eor W18, W18, W6
			InsnTester.AutoTest(0x4A060252, (cpu, maddr) => {
			});
			// eor W8, W19, W8
			InsnTester.AutoTest(0x4A080268, (cpu, maddr) => {
			});
			// eor W12, W11, W11, LSR #30
			InsnTester.AutoTest(0x4A4B796C, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ext() {
			// ext V1.8B, V2.8B, V3.8B, #4
			InsnTester.AutoTest(0x2E032041, (cpu, maddr) => {
			});
			// ext V26.16B, V21.16B, V21.16B, #8
			InsnTester.AutoTest(0x6E1542BA, (cpu, maddr) => {
			});
			// ext V6.16B, V1.16B, V1.16B, #8
			InsnTester.AutoTest(0x6E014026, (cpu, maddr) => {
			});
			// ext V1.16B, V1.16B, V1.16B, #8
			InsnTester.AutoTest(0x6E014021, (cpu, maddr) => {
			});
			// ext V27.16B, V25.16B, V25.16B, #8
			InsnTester.AutoTest(0x6E19433B, (cpu, maddr) => {
			});
			// ext V1.16B, V0.16B, V1.16B, #8
			InsnTester.AutoTest(0x6E014001, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fnmul() {
			// fnmul S2, S2, S0
			InsnTester.AutoTest(0x1E208842, (cpu, maddr) => {
			});
			// fnmul S20, S23, S21
			InsnTester.AutoTest(0x1E358AF4, (cpu, maddr) => {
			});
			// fnmul S23, S4, S2
			InsnTester.AutoTest(0x1E228897, (cpu, maddr) => {
			});
			// fnmul S7, S0, S3
			InsnTester.AutoTest(0x1E238807, (cpu, maddr) => {
			});
			// fnmul S17, S4, S1
			InsnTester.AutoTest(0x1E218891, (cpu, maddr) => {
			});
			// fnmul S3, S2, S3
			InsnTester.AutoTest(0x1E238843, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmaxnm() {
			// fmaxnm S0, S3, S0
			InsnTester.AutoTest(0x1E206860, (cpu, maddr) => {
			});
			// fmaxnm S18, S18, S20
			InsnTester.AutoTest(0x1E346A52, (cpu, maddr) => {
			});
			// fmaxnm S2, S2, S9
			InsnTester.AutoTest(0x1E296842, (cpu, maddr) => {
			});
			// fmaxnm S10, S0, S5
			InsnTester.AutoTest(0x1E25680A, (cpu, maddr) => {
			});
			// fmaxnm S2, S4, S1
			InsnTester.AutoTest(0x1E216882, (cpu, maddr) => {
			});
			// fmaxnm S7, S1, S6
			InsnTester.AutoTest(0x1E266827, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtps() {
			// fcvtps W8, S0
			InsnTester.AutoTest(0x1E280008, (cpu, maddr) => {
			});
			// fcvtps W15, S17
			InsnTester.AutoTest(0x1E28022F, (cpu, maddr) => {
			});
			// fcvtps W18, S6
			InsnTester.AutoTest(0x1E2800D2, (cpu, maddr) => {
			});
			// fcvtps W1, S0
			InsnTester.AutoTest(0x1E280001, (cpu, maddr) => {
			});
			// fcvtps W11, S1
			InsnTester.AutoTest(0x1E28002B, (cpu, maddr) => {
			});
			// fcvtps W8, S2
			InsnTester.AutoTest(0x1E280048, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smlal() {
			// smlal V2.2D, V0.2S, V5.2S
			InsnTester.AutoTest(0x0EA58002, (cpu, maddr) => {
			});
			// smlal V2.2D, V3.2S, V6.S[0]
			InsnTester.AutoTest(0x0F862062, (cpu, maddr) => {
			});
			// smlal V2.2D, V1.2S, V5.2S
			InsnTester.AutoTest(0x0EA58022, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldpsw() {
			// ldpsw X6, X5, [X5]
			InsnTester.AutoTest(0x694014A6, (cpu, maddr) => {
				cpu.X[5] = maddr;
			});
			// ldpsw X14, X15, [X11, #-0x10]
			InsnTester.AutoTest(0x697E3D6E, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldpsw X24, X25, [X19, #-4]
			InsnTester.AutoTest(0x697FE678, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldpsw X11, X12, [X0, #0x50]
			InsnTester.AutoTest(0x694A300B, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldpsw X8, X9, [X19, #4]
			InsnTester.AutoTest(0x6940A668, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldpsw X8, X9, [X19]
			InsnTester.AutoTest(0x69402668, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
		}

		[Fact]
		public void Ldrsw() {
			// ldrsw X2, [X8]
			InsnTester.AutoTest(0xB9800102, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsw X12, [X21, W28, SXTW #2]
			InsnTester.AutoTest(0xB8BCDAAC, (cpu, maddr) => {
				cpu.X[21] = maddr;
				cpu.X[28] = 0x10;
			});
			// ldrsw X9, [X0, #0x2FC]
			InsnTester.AutoTest(0xB982FC09, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsw X26, [X10, #0x14]
			InsnTester.AutoTest(0xB980155A, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrsw X9, [X19, #0xF8]
			InsnTester.AutoTest(0xB980FA69, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldrsw X9, [X19, #0x158]
			InsnTester.AutoTest(0xB9815A69, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
		}

		[Fact]
		public void Tbl() {
			// tbl V4.8B, {V7.16B}, V1.8B
			InsnTester.AutoTest(0x0E0100E4, (cpu, maddr) => {
			});
			// tbl V26.8B, {V26.16B, V27.16B}, V31.8B
			InsnTester.AutoTest(0x0E1F235A, (cpu, maddr) => {
			});
			// tbl V16.8B, {V5.16B}, V6.8B
			InsnTester.AutoTest(0x0E0600B0, (cpu, maddr) => {
			});
			// tbl V31.8B, {V30.16B}, V16.8B
			InsnTester.AutoTest(0x0E1003DF, (cpu, maddr) => {
			});
			// tbl V4.8B, {V5.16B, V6.16B}, V0.8B
			InsnTester.AutoTest(0x0E0020A4, (cpu, maddr) => {
			});
			// tbl V28.8B, {V25.16B}, V6.8B
			InsnTester.AutoTest(0x0E06033C, (cpu, maddr) => {
			});
		}

	}
}
