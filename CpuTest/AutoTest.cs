using System;
using System.Runtime.Intrinsics;
using Xunit;
using Xunit.Abstractions;

namespace CpuTest {
	public unsafe class AutoTest {
		readonly ITestOutputHelper Output;
		public AutoTest(ITestOutputHelper output) => Output = output;

		[Fact]
		public void Movn() {
			// movn X1, #0
			InsnTester.AutoTest(Output, 0x92800001, (cpu, maddr) => {
			});
			// movn W10, #0xFFEF, LSL #16
			InsnTester.AutoTest(Output, 0x12BFFDEA, (cpu, maddr) => {
			});
			// movn X10, #0x2710
			InsnTester.AutoTest(Output, 0x9284E20A, (cpu, maddr) => {
			});
			// movn W11, #0x13
			InsnTester.AutoTest(Output, 0x1280026B, (cpu, maddr) => {
			});
			// movn W9, #0x1B
			InsnTester.AutoTest(Output, 0x12800369, (cpu, maddr) => {
			});
			// movn W0, #0xFDE7
			InsnTester.AutoTest(Output, 0x129FBCE0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldurb() {
			// ldurb W1, [X0, #-1]
			InsnTester.AutoTest(Output, 0x385FF001, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldurb W21, [X28, #-0x10]
			InsnTester.AutoTest(Output, 0x385F0395, (cpu, maddr) => {
				cpu.State->X28 = maddr;
			});
			// ldurb W22, [X5, #-0x1B]
			InsnTester.AutoTest(Output, 0x385E50B6, (cpu, maddr) => {
				cpu.State->X5 = maddr;
			});
			// ldurb W6, [X5, #-1]
			InsnTester.AutoTest(Output, 0x385FF0A6, (cpu, maddr) => {
				cpu.State->X5 = maddr;
			});
			// ldurb W8, [X24, #-0x3F]
			InsnTester.AutoTest(Output, 0x385C1308, (cpu, maddr) => {
				cpu.State->X24 = maddr;
			});
			// ldurb W0, [X15, #-5]
			InsnTester.AutoTest(Output, 0x385FB1E0, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
		}

		[Fact]
		public void Movk() {
			// movk X6, #0
			InsnTester.AutoTest(Output, 0xF2800006, (cpu, maddr) => {
			});
			// movk X27, #0xFFFF, LSL #32
			InsnTester.AutoTest(Output, 0xF2DFFFFB, (cpu, maddr) => {
			});
			// movk W8, #0x1201
			InsnTester.AutoTest(Output, 0x72824028, (cpu, maddr) => {
			});
			// movk W19, #0x1006
			InsnTester.AutoTest(Output, 0x728200D3, (cpu, maddr) => {
			});
			// movk W25, #0x364
			InsnTester.AutoTest(Output, 0x72806C99, (cpu, maddr) => {
			});
			// movk W14, #0xD7D7
			InsnTester.AutoTest(Output, 0x729AFAEE, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Movi() {
			// movi V0.4S, #0x1
			InsnTester.AutoTest(Output, 0x4F000420, (cpu, maddr) => {
			});
			// movi V1.2D, #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(Output, 0x6F07E7E1, (cpu, maddr) => {
			});
			// movi V3.4S, #0x80, LSL #24
			InsnTester.AutoTest(Output, 0x4F046403, (cpu, maddr) => {
			});
			// movi V7.2D, #0000000000000000
			InsnTester.AutoTest(Output, 0x6F00E407, (cpu, maddr) => {
			});
			// movi D29, #0000000000000000
			InsnTester.AutoTest(Output, 0x2F00E41D, (cpu, maddr) => {
			});
			// movi V1.4S, #0xBF, LSL #24
			InsnTester.AutoTest(Output, 0x4F0567E1, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smull() {
			// smull X4, W4, W4
			InsnTester.AutoTest(Output, 0x9B247C84, (cpu, maddr) => {
			});
			// smull V2.2D, V2.2S, V0.2S
			InsnTester.AutoTest(Output, 0x0EA0C042, (cpu, maddr) => {
			});
			// smull X10, W10, W10
			InsnTester.AutoTest(Output, 0x9B2A7D4A, (cpu, maddr) => {
			});
			// smull X9, W1, W22
			InsnTester.AutoTest(Output, 0x9B367C29, (cpu, maddr) => {
			});
			// smull X9, W9, W0
			InsnTester.AutoTest(Output, 0x9B207D29, (cpu, maddr) => {
			});
			// smull X7, W1, W6
			InsnTester.AutoTest(Output, 0x9B267C27, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Lsl() {
			// lsl X9, X9, X0
			InsnTester.AutoTest(Output, 0x9AC02129, (cpu, maddr) => {
			});
			// lsl W30, W27, #0x10
			InsnTester.AutoTest(Output, 0x53103F7E, (cpu, maddr) => {
			});
			// lsl W25, W20, #1
			InsnTester.AutoTest(Output, 0x531F7A99, (cpu, maddr) => {
			});
			// lsl W27, W8, W26
			InsnTester.AutoTest(Output, 0x1ADA211B, (cpu, maddr) => {
			});
			// lsl W27, W8, W28
			InsnTester.AutoTest(Output, 0x1ADC211B, (cpu, maddr) => {
			});
			// lsl X9, X25, #3
			InsnTester.AutoTest(Output, 0xD37DF329, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frintp() {
			// frintp D0, D0
			InsnTester.AutoTest(Output, 0x1E64C000, (cpu, maddr) => {
			});
			// frintp S2, S2
			InsnTester.AutoTest(Output, 0x1E24C042, (cpu, maddr) => {
			});
			// frintp S0, S0
			InsnTester.AutoTest(Output, 0x1E24C000, (cpu, maddr) => {
			});
			// frintp S3, S1
			InsnTester.AutoTest(Output, 0x1E24C023, (cpu, maddr) => {
			});
			// frintp S3, S0
			InsnTester.AutoTest(Output, 0x1E24C003, (cpu, maddr) => {
			});
			// frintp S1, S1
			InsnTester.AutoTest(Output, 0x1E24C021, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldaxrb() {
			// ldaxrb W8, [X0]
			InsnTester.AutoTest(Output, 0x085FFC08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxrb W10, [X0]
			InsnTester.AutoTest(Output, 0x085FFC0A, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxrb W9, [X0]
			InsnTester.AutoTest(Output, 0x085FFC09, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxrb W10, [X8]
			InsnTester.AutoTest(Output, 0x085FFD0A, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void Ldr() {
			// ldr X0, [X0]
			InsnTester.AutoTest(Output, 0xF9400000, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldr W15, [X16, W15, SXTW #2]
			InsnTester.AutoTest(Output, 0xB86FDA0F, (cpu, maddr) => {
				cpu.State->X16 = maddr;
				cpu.State->X15 = 0x10;
			});
			// ldr W3, [X0]
			InsnTester.AutoTest(Output, 0xB9400003, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldr S17, [SP, #0x14C]
			InsnTester.AutoTest(Output, 0xBD414FF1, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
			// ldr S2, [X3, #0x6C]
			InsnTester.AutoTest(Output, 0xBD406C62, (cpu, maddr) => {
				cpu.State->X3 = maddr;
			});
			// ldr W0, [X8, #0x73C]
			InsnTester.AutoTest(Output, 0xB9473D00, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void Ldp() {
			// ldp X8, X2, [X0]
			InsnTester.AutoTest(Output, 0xA9400808, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldp X23, X22, [X27, #-0x10]
			InsnTester.AutoTest(Output, 0xA97F5B77, (cpu, maddr) => {
				cpu.State->X27 = maddr;
			});
			// ldp X1, X3, [X29, #-0x60]
			InsnTester.AutoTest(Output, 0xA97A0FA1, (cpu, maddr) => {
				cpu.State->X29 = maddr;
			});
			// ldp W19, W17, [X17, #8]
			InsnTester.AutoTest(Output, 0x29414633, (cpu, maddr) => {
				cpu.State->X17 = maddr;
			});
			// ldp X14, X12, [SP, #0x60]
			InsnTester.AutoTest(Output, 0xA94633EE, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
			// ldp W9, W12, [SP, #0x44]
			InsnTester.AutoTest(Output, 0x2948B3E9, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
		}

		[Fact]
		public void Movz() {
			// movz X4, #0
			InsnTester.AutoTest(Output, 0xD2800004, (cpu, maddr) => {
			});
			// movz W10, #0x5555, LSL #16
			InsnTester.AutoTest(Output, 0x52AAAAAA, (cpu, maddr) => {
			});
			// movz W8, #0x8A48
			InsnTester.AutoTest(Output, 0x52914908, (cpu, maddr) => {
			});
			// movz W27, #0x1A
			InsnTester.AutoTest(Output, 0x5280035B, (cpu, maddr) => {
			});
			// movz W8, #0xEBE4
			InsnTester.AutoTest(Output, 0x529D7C88, (cpu, maddr) => {
			});
			// movz W3, #0x39E8
			InsnTester.AutoTest(Output, 0x52873D03, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umov() {
			// umov W9, V0.H[0]
			InsnTester.AutoTest(Output, 0x0E023C09, (cpu, maddr) => {
			});
			// umov W16, V16.H[0]
			InsnTester.AutoTest(Output, 0x0E023E10, (cpu, maddr) => {
			});
			// umov W8, V0.H[0]
			InsnTester.AutoTest(Output, 0x0E023C08, (cpu, maddr) => {
			});
			// umov W8, V5.H[0]
			InsnTester.AutoTest(Output, 0x0E023CA8, (cpu, maddr) => {
			});
			// umov W9, V1.H[0]
			InsnTester.AutoTest(Output, 0x0E023C29, (cpu, maddr) => {
			});
			// umov W10, V2.H[0]
			InsnTester.AutoTest(Output, 0x0E023C4A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sqadd() {
			// sqadd V1.2S, V3.2S, V1.2S
			InsnTester.AutoTest(Output, 0x0EA10C61, (cpu, maddr) => {
			});
			// sqadd V2.2S, V2.2S, V0.2S
			InsnTester.AutoTest(Output, 0x0EA00C42, (cpu, maddr) => {
			});
			// sqadd V1.2S, V1.2S, V0.2S
			InsnTester.AutoTest(Output, 0x0EA00C21, (cpu, maddr) => {
			});
			// sqadd V1.2S, V2.2S, V1.2S
			InsnTester.AutoTest(Output, 0x0EA10C41, (cpu, maddr) => {
			});
			// sqadd V0.2S, V1.2S, V0.2S
			InsnTester.AutoTest(Output, 0x0EA00C20, (cpu, maddr) => {
			});
			// sqadd V2.2S, V3.2S, V2.2S
			InsnTester.AutoTest(Output, 0x0EA20C62, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtas() {
			// fcvtas X0, S0
			InsnTester.AutoTest(Output, 0x9E240000, (cpu, maddr) => {
			});
			// fcvtas X0, D0
			InsnTester.AutoTest(Output, 0x9E640000, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sshll() {
			// sshll V4.2D, V4.2S, #0
			InsnTester.AutoTest(Output, 0x0F20A484, (cpu, maddr) => {
			});
			// sshll V2.4S, V2.4H, #0
			InsnTester.AutoTest(Output, 0x0F10A442, (cpu, maddr) => {
			});
			// sshll V3.2D, V3.2S, #0
			InsnTester.AutoTest(Output, 0x0F20A463, (cpu, maddr) => {
			});
			// sshll V3.4S, V3.4H, #0
			InsnTester.AutoTest(Output, 0x0F10A463, (cpu, maddr) => {
			});
			// sshll V2.2D, V2.2S, #0
			InsnTester.AutoTest(Output, 0x0F20A442, (cpu, maddr) => {
			});
			// sshll V5.4S, V5.4H, #0
			InsnTester.AutoTest(Output, 0x0F10A4A5, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldaxr() {
			// ldaxr X8, [X0]
			InsnTester.AutoTest(Output, 0xC85FFC08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxr W10, [X28]
			InsnTester.AutoTest(Output, 0x885FFF8A, (cpu, maddr) => {
				cpu.State->X28 = maddr;
			});
			// ldaxr W8, [X2]
			InsnTester.AutoTest(Output, 0x885FFC48, (cpu, maddr) => {
				cpu.State->X2 = maddr;
			});
			// ldaxr X0, [X9]
			InsnTester.AutoTest(Output, 0xC85FFD20, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldaxr W0, [X8]
			InsnTester.AutoTest(Output, 0x885FFD00, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldaxr W10, [X27]
			InsnTester.AutoTest(Output, 0x885FFF6A, (cpu, maddr) => {
				cpu.State->X27 = maddr;
			});
		}

		[Fact]
		public void Bfi() {
			// bfi W1, W9, #5, #1
			InsnTester.AutoTest(Output, 0x331B0121, (cpu, maddr) => {
			});
			// bfi W26, W26, #0x10, #0x10
			InsnTester.AutoTest(Output, 0x33103F5A, (cpu, maddr) => {
			});
			// bfi W9, W8, #0x18, #4
			InsnTester.AutoTest(Output, 0x33080D09, (cpu, maddr) => {
			});
			// bfi W10, W9, #1, #0x1F
			InsnTester.AutoTest(Output, 0x331F792A, (cpu, maddr) => {
			});
			// bfi W10, W11, #8, #6
			InsnTester.AutoTest(Output, 0x3318156A, (cpu, maddr) => {
			});
			// bfi W9, W11, #3, #1
			InsnTester.AutoTest(Output, 0x331D0169, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sqrshrn() {
			// sqrshrn V2.2S, V2.2D, #0xF
			InsnTester.AutoTest(Output, 0x0F319C42, (cpu, maddr) => {
			});
			// sqrshrn V0.2S, V0.2D, #0x1E
			InsnTester.AutoTest(Output, 0x0F229C00, (cpu, maddr) => {
			});
			// sqrshrn V0.2S, V0.2D, #0xF
			InsnTester.AutoTest(Output, 0x0F319C00, (cpu, maddr) => {
			});
			// sqrshrn V6.2S, V2.2D, #0xE
			InsnTester.AutoTest(Output, 0x0F329C46, (cpu, maddr) => {
			});
			// sqrshrn V1.2S, V1.2D, #0xF
			InsnTester.AutoTest(Output, 0x0F319C21, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Add() {
			// add W6, W5, W0
			InsnTester.AutoTest(Output, 0x0B0000A6, (cpu, maddr) => {
			});
			// add W13, W21, #0x770, LSL #12
			InsnTester.AutoTest(Output, 0x115DC2AD, (cpu, maddr) => {
			});
			// add X25, X26, #0x190
			InsnTester.AutoTest(Output, 0x91064359, (cpu, maddr) => {
			});
			// add W18, W18, #0x100
			InsnTester.AutoTest(Output, 0x11040252, (cpu, maddr) => {
			});
			// add X10, X8, #0xB8
			InsnTester.AutoTest(Output, 0x9102E10A, (cpu, maddr) => {
			});
			// add X8, X8, W11, SXTW #1
			InsnTester.AutoTest(Output, 0x8B2BC508, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ucvtf() {
			// ucvtf S4, S1
			InsnTester.AutoTest(Output, 0x7E21D824, (cpu, maddr) => {
			});
			// ucvtf S10, W27
			InsnTester.AutoTest(Output, 0x1E23036A, (cpu, maddr) => {
			});
			// ucvtf S8, W27
			InsnTester.AutoTest(Output, 0x1E230368, (cpu, maddr) => {
			});
			// ucvtf S8, W24
			InsnTester.AutoTest(Output, 0x1E230308, (cpu, maddr) => {
			});
			// ucvtf S9, W28
			InsnTester.AutoTest(Output, 0x1E230389, (cpu, maddr) => {
			});
			// ucvtf S5, W8
			InsnTester.AutoTest(Output, 0x1E230105, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Clz() {
			// clz W9, W6
			InsnTester.AutoTest(Output, 0x5AC010C9, (cpu, maddr) => {
			});
			// clz W10, W25
			InsnTester.AutoTest(Output, 0x5AC0132A, (cpu, maddr) => {
			});
			// clz W21, W6
			InsnTester.AutoTest(Output, 0x5AC010D5, (cpu, maddr) => {
			});
			// clz W12, W12
			InsnTester.AutoTest(Output, 0x5AC0118C, (cpu, maddr) => {
			});
			// clz W19, W19
			InsnTester.AutoTest(Output, 0x5AC01273, (cpu, maddr) => {
			});
			// clz W13, W12
			InsnTester.AutoTest(Output, 0x5AC0118D, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fadd() {
			// fadd S2, S0, S0
			InsnTester.AutoTest(Output, 0x1E202802, (cpu, maddr) => {
			});
			// fadd V30.4S, V31.4S, V31.4S
			InsnTester.AutoTest(Output, 0x4E3FD7FE, (cpu, maddr) => {
			});
			// fadd S16, S16, S3
			InsnTester.AutoTest(Output, 0x1E232A10, (cpu, maddr) => {
			});
			// fadd S22, S17, S4
			InsnTester.AutoTest(Output, 0x1E242A36, (cpu, maddr) => {
			});
			// fadd D1, D19, D1
			InsnTester.AutoTest(Output, 0x1E612A61, (cpu, maddr) => {
			});
			// fadd S3, S4, S18
			InsnTester.AutoTest(Output, 0x1E322883, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sbfx() {
			// sbfx W0, W8, #4, #1
			InsnTester.AutoTest(Output, 0x13041100, (cpu, maddr) => {
			});
			// sbfx X11, X11, #0x1E, #0x20
			InsnTester.AutoTest(Output, 0x935EF56B, (cpu, maddr) => {
			});
			// sbfx X18, X10, #3, #0x1D
			InsnTester.AutoTest(Output, 0x93437D52, (cpu, maddr) => {
			});
			// sbfx X23, X2, #1, #0x1F
			InsnTester.AutoTest(Output, 0x93417C57, (cpu, maddr) => {
			});
			// sbfx W17, W17, #1, #0xF
			InsnTester.AutoTest(Output, 0x13013E31, (cpu, maddr) => {
			});
			// sbfx X7, X3, #1, #0x1F
			InsnTester.AutoTest(Output, 0x93417C67, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Tst() {
			// tst W5, W7
			InsnTester.AutoTest(Output, 0x6A0700BF, (cpu, maddr) => {
			});
			// tst X10, #0x7FFFFFFFFFFFFFFF
			InsnTester.AutoTest(Output, 0xF240F95F, (cpu, maddr) => {
			});
			// tst W9, #0x1000000
			InsnTester.AutoTest(Output, 0x7208013F, (cpu, maddr) => {
			});
			// tst W17, #0x400
			InsnTester.AutoTest(Output, 0x7216023F, (cpu, maddr) => {
			});
			// tst W25, #4
			InsnTester.AutoTest(Output, 0x721E033F, (cpu, maddr) => {
			});
			// tst W13, W12
			InsnTester.AutoTest(Output, 0x6A0C01BF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frintm() {
			// frintm S2, S0
			InsnTester.AutoTest(Output, 0x1E254002, (cpu, maddr) => {
			});
			// frintm S20, S19
			InsnTester.AutoTest(Output, 0x1E254274, (cpu, maddr) => {
			});
			// frintm S1, S1
			InsnTester.AutoTest(Output, 0x1E254021, (cpu, maddr) => {
			});
			// frintm D0, D0
			InsnTester.AutoTest(Output, 0x1E654000, (cpu, maddr) => {
			});
			// frintm D1, D1
			InsnTester.AutoTest(Output, 0x1E654021, (cpu, maddr) => {
			});
			// frintm D3, D3
			InsnTester.AutoTest(Output, 0x1E654063, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldurh() {
			// ldurh W0, [X8, #1]
			InsnTester.AutoTest(Output, 0x78401100, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldurh W18, [X15, #-0x10]
			InsnTester.AutoTest(Output, 0x785F01F2, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
			// ldurh W8, [X22, #-7]
			InsnTester.AutoTest(Output, 0x785F92C8, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldurh W16, [X11, #-2]
			InsnTester.AutoTest(Output, 0x785FE170, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldurh W11, [X9, #-2]
			InsnTester.AutoTest(Output, 0x785FE12B, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldurh W20, [X8, #-2]
			InsnTester.AutoTest(Output, 0x785FE114, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void LdrhPreIndex() {
			// ldrh W9, [X8, #6]!
			InsnTester.AutoTest(Output, 0x78406D09, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrh W13, [X10, #-0x20]!
			InsnTester.AutoTest(Output, 0x785E0D4D, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrh W8, [X20, #2]!
			InsnTester.AutoTest(Output, 0x78402E88, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldrh W8, [X24, #2]!
			InsnTester.AutoTest(Output, 0x78402F08, (cpu, maddr) => {
				cpu.State->X24 = maddr;
			});
			// ldrh W3, [X18, #0x34]!
			InsnTester.AutoTest(Output, 0x78434E43, (cpu, maddr) => {
				cpu.State->X18 = maddr;
			});
			// ldrh W8, [X24, #0x6C]!
			InsnTester.AutoTest(Output, 0x7846CF08, (cpu, maddr) => {
				cpu.State->X24 = maddr;
			});
		}

		[Fact]
		public void Ldursb() {
			// ldursb W1, [X8, #-1]
			InsnTester.AutoTest(Output, 0x38DFF101, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldursb W18, [X15, #-0x30]
			InsnTester.AutoTest(Output, 0x38DD01F2, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
			// ldursb W9, [X1, #-1]
			InsnTester.AutoTest(Output, 0x38DFF029, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
			// ldursb W18, [X17, #-2]
			InsnTester.AutoTest(Output, 0x38DFE232, (cpu, maddr) => {
				cpu.State->X17 = maddr;
			});
			// ldursb W12, [X10, #-2]
			InsnTester.AutoTest(Output, 0x38DFE14C, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldursb W1, [X29, #-0x1D]
			InsnTester.AutoTest(Output, 0x38DE33A1, (cpu, maddr) => {
				cpu.State->X29 = maddr;
			});
		}

		[Fact]
		public void Adrp() {
			// adrp X2, #0xDEAD3000
			InsnTester.AutoTest(Output, 0xF0000002, (cpu, maddr) => {
			});
			// adrp X21, #0xDEACF000
			InsnTester.AutoTest(Output, 0xF0FFFFF5, (cpu, maddr) => {
			});
			// adrp X8, #0xDFA92000
			InsnTester.AutoTest(Output, 0xD0007E08, (cpu, maddr) => {
			});
			// adrp X20, #0xE04CD000
			InsnTester.AutoTest(Output, 0xB000CFF4, (cpu, maddr) => {
			});
			// adrp X10, #0xDF00D000
			InsnTester.AutoTest(Output, 0xB00029EA, (cpu, maddr) => {
			});
			// adrp X2, #0xDFC10000
			InsnTester.AutoTest(Output, 0x90008A02, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sha1Su0() {
			// sha1su0 V5.4S, V6.4S, V7.4S
			InsnTester.AutoTest(Output, 0x5E0730C5, (cpu, maddr) => {
			});
			// sha1su0 V6.4S, V7.4S, V16.4S
			InsnTester.AutoTest(Output, 0x5E1030E6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmeq() {
			// fcmeq V0.4S, V2.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0D840, (cpu, maddr) => {
			});
			// fcmeq V23.4S, V25.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0DB37, (cpu, maddr) => {
			});
			// fcmeq V2.4S, V1.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0D822, (cpu, maddr) => {
			});
			// fcmeq V1.4S, V4.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0D881, (cpu, maddr) => {
			});
			// fcmeq V2.4S, V7.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0D8E2, (cpu, maddr) => {
			});
			// fcmeq V2.4S, V2.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0D842, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Mov() {
			// mov X3, SP
			InsnTester.AutoTest(Output, 0x910003E3, (cpu, maddr) => {
			});
			// mov V24.16B, V31.16B
			InsnTester.AutoTest(Output, 0x4EBF1FF8, (cpu, maddr) => {
			});
			// mov W14, W15
			InsnTester.AutoTest(Output, 0x2A0F03EE, (cpu, maddr) => {
			});
			// mov X18, X25
			InsnTester.AutoTest(Output, 0xAA1903F2, (cpu, maddr) => {
			});
			// mov W1, W28
			InsnTester.AutoTest(Output, 0x2A1C03E1, (cpu, maddr) => {
			});
			// mov X2, X13
			InsnTester.AutoTest(Output, 0xAA0D03E2, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ld2() {
			// ld2 {V3.2S, V4.2S}, [X15]
			InsnTester.AutoTest(Output, 0x0C4089E3, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
			// ld2 {V4.2D, V5.2D}, [X15]
			InsnTester.AutoTest(Output, 0x4C408DE4, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
			// ld2 {V6.2D, V7.2D}, [X13]
			InsnTester.AutoTest(Output, 0x4C408DA6, (cpu, maddr) => {
				cpu.State->X13 = maddr;
			});
		}

		[Fact]
		public void Ld1() {
			// ld1 {V5.S}[0], [X0]
			InsnTester.AutoTest(Output, 0x0D408005, (cpu, maddr) => {
			});
			// ld1 {V1.S}[3], [X27], X25
			InsnTester.AutoTest(Output, 0x4DD99361, (cpu, maddr) => {
			});
			// ld1 {V1.S}[0], [X11]
			InsnTester.AutoTest(Output, 0x0D408161, (cpu, maddr) => {
			});
			// ld1 {V1.S}[3], [X17]
			InsnTester.AutoTest(Output, 0x4D409221, (cpu, maddr) => {
			});
			// ld1 {V3.S}[0], [X18]
			InsnTester.AutoTest(Output, 0x0D408243, (cpu, maddr) => {
			});
			// ld1 {V5.S}[1], [X11]
			InsnTester.AutoTest(Output, 0x0D409165, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtzs() {
			// fcvtzs X8, S0
			InsnTester.AutoTest(Output, 0x9E380008, (cpu, maddr) => {
			});
			// fcvtzs W10, D0, #0x18
			InsnTester.AutoTest(Output, 0x1E58A00A, (cpu, maddr) => {
			});
			// fcvtzs W10, S0
			InsnTester.AutoTest(Output, 0x1E38000A, (cpu, maddr) => {
			});
			// fcvtzs X13, S4
			InsnTester.AutoTest(Output, 0x9E38008D, (cpu, maddr) => {
			});
			// fcvtzs W9, D0, #8
			InsnTester.AutoTest(Output, 0x1E58E009, (cpu, maddr) => {
			});
			// fcvtzs W8, D2, #8
			InsnTester.AutoTest(Output, 0x1E58E048, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Adcs() {
			// adcs W4, W4, W8
			InsnTester.AutoTest(Output, 0x3A080084, (cpu, maddr) => {
			});
			// adcs X11, X21, XZR
			InsnTester.AutoTest(Output, 0xBA1F02AB, (cpu, maddr) => {
			});
			// adcs X9, X9, X17
			InsnTester.AutoTest(Output, 0xBA110129, (cpu, maddr) => {
			});
			// adcs X6, X6, X14
			InsnTester.AutoTest(Output, 0xBA0E00C6, (cpu, maddr) => {
			});
			// adcs X0, XZR, XZR
			InsnTester.AutoTest(Output, 0xBA1F03E0, (cpu, maddr) => {
			});
			// adcs X13, X3, X13
			InsnTester.AutoTest(Output, 0xBA0D006D, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdpPostIndex() {
			// ldp W8, W9, [X1], #8
			InsnTester.AutoTest(Output, 0x28C12428, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
			// ldp S16, S17, [X16], #0x10
			InsnTester.AutoTest(Output, 0x2CC24610, (cpu, maddr) => {
				cpu.State->X16 = maddr;
			});
			// ldp X14, X15, [X2], #0x10
			InsnTester.AutoTest(Output, 0xA8C13C4E, (cpu, maddr) => {
				cpu.State->X2 = maddr;
			});
			// ldp X24, X23, [SP], #0x40
			InsnTester.AutoTest(Output, 0xA8C45FF8, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
			// ldp W11, W12, [X9], #8
			InsnTester.AutoTest(Output, 0x28C1312B, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldp D13, D12, [SP], #0x40
			InsnTester.AutoTest(Output, 0x6CC433ED, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
		}

		[Fact]
		public void Bit() {
			// bit V2.16B, V1.16B, V0.16B
			InsnTester.AutoTest(Output, 0x6EA01C22, (cpu, maddr) => {
			});
			// bit V20.16B, V3.16B, V22.16B
			InsnTester.AutoTest(Output, 0x6EB61C74, (cpu, maddr) => {
			});
			// bit V5.16B, V3.16B, V4.16B
			InsnTester.AutoTest(Output, 0x6EA41C65, (cpu, maddr) => {
			});
			// bit V16.16B, V1.16B, V4.16B
			InsnTester.AutoTest(Output, 0x6EA41C30, (cpu, maddr) => {
			});
			// bit V2.16B, V1.16B, V3.16B
			InsnTester.AutoTest(Output, 0x6EA31C22, (cpu, maddr) => {
			});
			// bit V7.16B, V0.16B, V5.16B
			InsnTester.AutoTest(Output, 0x6EA51C07, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmhs() {
			// cmhs V3.2S, V1.2S, V3.2S
			InsnTester.AutoTest(Output, 0x2EA33C23, (cpu, maddr) => {
			});
			// cmhs V5.2S, V1.2S, V5.2S
			InsnTester.AutoTest(Output, 0x2EA53C25, (cpu, maddr) => {
			});
			// cmhs V4.2S, V1.2S, V4.2S
			InsnTester.AutoTest(Output, 0x2EA43C24, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frecpe() {
			// frecpe V3.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4EA1D843, (cpu, maddr) => {
			});
			// frecpe V19.4S, V18.4S
			InsnTester.AutoTest(Output, 0x4EA1DA53, (cpu, maddr) => {
			});
			// frecpe V18.4S, V17.4S
			InsnTester.AutoTest(Output, 0x4EA1DA32, (cpu, maddr) => {
			});
			// frecpe V18.4S, V6.4S
			InsnTester.AutoTest(Output, 0x4EA1D8D2, (cpu, maddr) => {
			});
			// frecpe V5.4S, V28.4S
			InsnTester.AutoTest(Output, 0x4EA1DB85, (cpu, maddr) => {
			});
			// frecpe V31.4S, V25.4S
			InsnTester.AutoTest(Output, 0x4EA1DB3F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmtst() {
			// cmtst V18.4S, V17.4S, V0.4S
			InsnTester.AutoTest(Output, 0x4EA08E32, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V3.4S
			InsnTester.AutoTest(Output, 0x4EA38E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V1.4S
			InsnTester.AutoTest(Output, 0x4EA18E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V5.4S
			InsnTester.AutoTest(Output, 0x4EA58E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V6.4S
			InsnTester.AutoTest(Output, 0x4EA68E33, (cpu, maddr) => {
			});
			// cmtst V17.4S, V17.4S, V7.4S
			InsnTester.AutoTest(Output, 0x4EA78E31, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmn() {
			// cmn W1, #1
			InsnTester.AutoTest(Output, 0x3100043F, (cpu, maddr) => {
			});
			// cmn W11, #0x380, LSL #12
			InsnTester.AutoTest(Output, 0x314E017F, (cpu, maddr) => {
			});
			// cmn X1, #3
			InsnTester.AutoTest(Output, 0xB1000C3F, (cpu, maddr) => {
			});
			// cmn W9, #0xF
			InsnTester.AutoTest(Output, 0x31003D3F, (cpu, maddr) => {
			});
			// cmn X9, #0x10
			InsnTester.AutoTest(Output, 0xB100413F, (cpu, maddr) => {
			});
			// cmn X10, #1
			InsnTester.AutoTest(Output, 0xB100055F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmov() {
			// fmov W0, S8
			InsnTester.AutoTest(Output, 0x1E260100, (cpu, maddr) => {
			});
			// fmov V27.4S, #-1.00000000
			InsnTester.AutoTest(Output, 0x4F07F61B, (cpu, maddr) => {
			});
			// fmov S0, #6.00000000
			InsnTester.AutoTest(Output, 0x1E231000, (cpu, maddr) => {
			});
			// fmov X11, D8
			InsnTester.AutoTest(Output, 0x9E66010B, (cpu, maddr) => {
			});
			// fmov S0, #2.00000000
			InsnTester.AutoTest(Output, 0x1E201000, (cpu, maddr) => {
			});
			// fmov S13, W27
			InsnTester.AutoTest(Output, 0x1E27036D, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Extr() {
			// extr W4, W3, W2, #8
			InsnTester.AutoTest(Output, 0x13822064, (cpu, maddr) => {
			});
			// extr W10, W13, W10, #0x18
			InsnTester.AutoTest(Output, 0x138A61AA, (cpu, maddr) => {
			});
			// extr X12, X21, X23, #0x3F
			InsnTester.AutoTest(Output, 0x93D7FEAC, (cpu, maddr) => {
			});
			// extr X10, X9, X8, #0x28
			InsnTester.AutoTest(Output, 0x93C8A12A, (cpu, maddr) => {
			});
			// extr X2, X4, X2, #0x20
			InsnTester.AutoTest(Output, 0x93C28082, (cpu, maddr) => {
			});
			// extr X10, X21, X24, #0x3E
			InsnTester.AutoTest(Output, 0x93D8FAAA, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ubfiz() {
			// ubfiz W8, W8, #4, #4
			InsnTester.AutoTest(Output, 0x531C0D08, (cpu, maddr) => {
			});
			// ubfiz X12, X13, #0x28, #0x14
			InsnTester.AutoTest(Output, 0xD3584DAC, (cpu, maddr) => {
			});
			// ubfiz W10, W8, #4, #2
			InsnTester.AutoTest(Output, 0x531C050A, (cpu, maddr) => {
			});
			// ubfiz W21, W0, #8, #6
			InsnTester.AutoTest(Output, 0x53181415, (cpu, maddr) => {
			});
			// ubfiz W10, W10, #8, #8
			InsnTester.AutoTest(Output, 0x53181D4A, (cpu, maddr) => {
			});
			// ubfiz W12, W12, #5, #2
			InsnTester.AutoTest(Output, 0x531B058C, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cneg() {
			// cneg W9, W0, MI
			InsnTester.AutoTest(Output, 0x5A805409, (cpu, maddr) => {
			});
			// cneg X17, X17, MI
			InsnTester.AutoTest(Output, 0xDA915631, (cpu, maddr) => {
			});
			// cneg W14, W4, LT
			InsnTester.AutoTest(Output, 0x5A84A48E, (cpu, maddr) => {
			});
			// cneg X8, X8, MI
			InsnTester.AutoTest(Output, 0xDA885508, (cpu, maddr) => {
			});
			// cneg W17, W14, MI
			InsnTester.AutoTest(Output, 0x5A8E55D1, (cpu, maddr) => {
			});
			// cneg W14, W11, EQ
			InsnTester.AutoTest(Output, 0x5A8B156E, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Lsr() {
			// lsr W7, W2, W0
			InsnTester.AutoTest(Output, 0x1AC02447, (cpu, maddr) => {
			});
			// lsr X28, X19, #0x3F
			InsnTester.AutoTest(Output, 0xD37FFE7C, (cpu, maddr) => {
			});
			// lsr X19, X10, #0x16
			InsnTester.AutoTest(Output, 0xD356FD53, (cpu, maddr) => {
			});
			// lsr W11, W9, #1
			InsnTester.AutoTest(Output, 0x53017D2B, (cpu, maddr) => {
			});
			// lsr X26, X27, #0x1F
			InsnTester.AutoTest(Output, 0xD35FFF7A, (cpu, maddr) => {
			});
			// lsr W19, W19, #7
			InsnTester.AutoTest(Output, 0x53077E73, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Udiv() {
			// udiv W1, W1, W9
			InsnTester.AutoTest(Output, 0x1AC90821, (cpu, maddr) => {
			});
			// udiv W12, W13, W12
			InsnTester.AutoTest(Output, 0x1ACC09AC, (cpu, maddr) => {
			});
			// udiv W5, W5, W7
			InsnTester.AutoTest(Output, 0x1AC708A5, (cpu, maddr) => {
			});
			// udiv W15, W19, W10
			InsnTester.AutoTest(Output, 0x1ACA0A6F, (cpu, maddr) => {
			});
			// udiv W14, W12, W21
			InsnTester.AutoTest(Output, 0x1AD5098E, (cpu, maddr) => {
			});
			// udiv W18, W18, W17
			InsnTester.AutoTest(Output, 0x1AD10A52, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Shl() {
			// shl V7.4S, V2.4S, #3
			InsnTester.AutoTest(Output, 0x4F235447, (cpu, maddr) => {
			});
			// shl V21.4S, V21.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F3F56B5, (cpu, maddr) => {
			});
			// shl V6.4S, V6.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F3F54C6, (cpu, maddr) => {
			});
			// shl V0.4S, V0.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F3F5400, (cpu, maddr) => {
			});
			// shl V6.4S, V3.4S, #6
			InsnTester.AutoTest(Output, 0x4F265466, (cpu, maddr) => {
			});
			// shl V16.16B, V16.16B, #7
			InsnTester.AutoTest(Output, 0x4F0F5610, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smaddl() {
			// smaddl X8, W6, W3, X8
			InsnTester.AutoTest(Output, 0x9B2320C8, (cpu, maddr) => {
			});
			// smaddl X20, W26, W28, X19
			InsnTester.AutoTest(Output, 0x9B3C4F54, (cpu, maddr) => {
			});
			// smaddl X8, W2, W9, X8
			InsnTester.AutoTest(Output, 0x9B292048, (cpu, maddr) => {
			});
			// smaddl X9, W13, W27, X9
			InsnTester.AutoTest(Output, 0x9B3B25A9, (cpu, maddr) => {
			});
			// smaddl X10, W9, W10, X5
			InsnTester.AutoTest(Output, 0x9B2A152A, (cpu, maddr) => {
			});
			// smaddl X8, W9, W8, X21
			InsnTester.AutoTest(Output, 0x9B285528, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmp() {
			// cmp W1, #0
			InsnTester.AutoTest(Output, 0x7100003F, (cpu, maddr) => {
			});
			// cmp W12, #0x7FE, LSL #12
			InsnTester.AutoTest(Output, 0x715FF99F, (cpu, maddr) => {
			});
			// cmp W2, #0x93
			InsnTester.AutoTest(Output, 0x71024C5F, (cpu, maddr) => {
			});
			// cmp W9, W8, ASR #3
			InsnTester.AutoTest(Output, 0x6B880D3F, (cpu, maddr) => {
			});
			// cmp X6, #0xA
			InsnTester.AutoTest(Output, 0xF10028DF, (cpu, maddr) => {
			});
			// cmp W18, W4, UXTH
			InsnTester.AutoTest(Output, 0x6B24225F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev64() {
			// rev64 V0.4S, V0.4S
			InsnTester.AutoTest(Output, 0x4EA00800, (cpu, maddr) => {
			});
			// rev64 V7.4S, V7.4S
			InsnTester.AutoTest(Output, 0x4EA008E7, (cpu, maddr) => {
			});
			// rev64 V1.4S, V1.4S
			InsnTester.AutoTest(Output, 0x4EA00821, (cpu, maddr) => {
			});
			// rev64 V3.4S, V3.4S
			InsnTester.AutoTest(Output, 0x4EA00863, (cpu, maddr) => {
			});
			// rev64 V2.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4EA00842, (cpu, maddr) => {
			});
			// rev64 V4.4S, V4.4S
			InsnTester.AutoTest(Output, 0x4EA00884, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sbcs() {
			// sbcs X4, X4, X8
			InsnTester.AutoTest(Output, 0xFA080084, (cpu, maddr) => {
			});
			// sbcs X16, X18, XZR
			InsnTester.AutoTest(Output, 0xFA1F0250, (cpu, maddr) => {
			});
			// sbcs X18, X10, XZR
			InsnTester.AutoTest(Output, 0xFA1F0152, (cpu, maddr) => {
			});
			// sbcs X7, X7, X15
			InsnTester.AutoTest(Output, 0xFA0F00E7, (cpu, maddr) => {
			});
			// sbcs X21, X9, X8
			InsnTester.AutoTest(Output, 0xFA080135, (cpu, maddr) => {
			});
			// sbcs X1, X8, X3
			InsnTester.AutoTest(Output, 0xFA030101, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ld1RPostIndex() {
			// ld1r {V5.2S}, [X1], #4
			InsnTester.AutoTest(Output, 0x0DDFC825, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
			// ld1r {V27.4S}, [X8], #4
			InsnTester.AutoTest(Output, 0x4DDFC91B, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ld1r {V1.4S}, [X8], #4
			InsnTester.AutoTest(Output, 0x4DDFC901, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ld1r {V6.4S}, [X16], #4
			InsnTester.AutoTest(Output, 0x4DDFCA06, (cpu, maddr) => {
				cpu.State->X16 = maddr;
			});
			// ld1r {V0.16B}, [X8], #1
			InsnTester.AutoTest(Output, 0x4DDFC100, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ld1r {V9.4S}, [X12], #4
			InsnTester.AutoTest(Output, 0x4DDFC989, (cpu, maddr) => {
				cpu.State->X12 = maddr;
			});
		}

		[Fact]
		public void LdrPreIndex() {
			// ldr W6, [X0, #4]!
			InsnTester.AutoTest(Output, 0xB8404C06, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldr X10, [X20, #-0x10]!
			InsnTester.AutoTest(Output, 0xF85F0E8A, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldr X22, [X21, #0x10]!
			InsnTester.AutoTest(Output, 0xF8410EB6, (cpu, maddr) => {
				cpu.State->X21 = maddr;
			});
			// ldr X0, [X8, #8]!
			InsnTester.AutoTest(Output, 0xF8408D00, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldr X25, [X22, #0xA0]!
			InsnTester.AutoTest(Output, 0xF84A0ED9, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldr X8, [X21, #-0x10]!
			InsnTester.AutoTest(Output, 0xF85F0EA8, (cpu, maddr) => {
				cpu.State->X21 = maddr;
			});
		}

		[Fact]
		public void Zip2() {
			// zip2 V0.4S, V0.4S, V1.4S
			InsnTester.AutoTest(Output, 0x4E817800, (cpu, maddr) => {
			});
			// zip2 V27.4S, V27.4S, V29.4S
			InsnTester.AutoTest(Output, 0x4E9D7B7B, (cpu, maddr) => {
			});
			// zip2 V3.4S, V3.4S, V4.4S
			InsnTester.AutoTest(Output, 0x4E847863, (cpu, maddr) => {
			});
			// zip2 V0.4S, V0.4S, V4.4S
			InsnTester.AutoTest(Output, 0x4E847800, (cpu, maddr) => {
			});
			// zip2 V1.4S, V1.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4E827821, (cpu, maddr) => {
			});
			// zip2 V2.4S, V4.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4E827882, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Zip1() {
			// zip1 V0.4S, V2.4S, V1.4S
			InsnTester.AutoTest(Output, 0x4E813840, (cpu, maddr) => {
			});
			// zip1 V30.2S, V28.2S, V29.2S
			InsnTester.AutoTest(Output, 0x0E9D3B9E, (cpu, maddr) => {
			});
			// zip1 V3.4S, V9.4S, V11.4S
			InsnTester.AutoTest(Output, 0x4E8B3923, (cpu, maddr) => {
			});
			// zip1 V2.4S, V1.4S, V4.4S
			InsnTester.AutoTest(Output, 0x4E843822, (cpu, maddr) => {
			});
			// zip1 V5.4S, V0.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4E823805, (cpu, maddr) => {
			});
			// zip1 V5.4S, V16.4S, V17.4S
			InsnTester.AutoTest(Output, 0x4E913A05, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ror() {
			// ror W5, W1, W3
			InsnTester.AutoTest(Output, 0x1AC32C25, (cpu, maddr) => {
			});
			// ror W10, W10, #0x11
			InsnTester.AutoTest(Output, 0x138A454A, (cpu, maddr) => {
			});
			// ror W14, W14, #0xB
			InsnTester.AutoTest(Output, 0x138E2DCE, (cpu, maddr) => {
			});
			// ror W10, W10, #0x19
			InsnTester.AutoTest(Output, 0x138A654A, (cpu, maddr) => {
			});
			// ror W17, W17, #0x1A
			InsnTester.AutoTest(Output, 0x13916A31, (cpu, maddr) => {
			});
			// ror W18, W18, #0xB
			InsnTester.AutoTest(Output, 0x13922E52, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fneg() {
			// fneg D0, D0
			InsnTester.AutoTest(Output, 0x1E614000, (cpu, maddr) => {
			});
			// fneg V24.4S, V16.4S
			InsnTester.AutoTest(Output, 0x6EA0FA18, (cpu, maddr) => {
			});
			// fneg S11, S6
			InsnTester.AutoTest(Output, 0x1E2140CB, (cpu, maddr) => {
			});
			// fneg S4, S12
			InsnTester.AutoTest(Output, 0x1E214184, (cpu, maddr) => {
			});
			// fneg S14, S14
			InsnTester.AutoTest(Output, 0x1E2141CE, (cpu, maddr) => {
			});
			// fneg S0, S11
			InsnTester.AutoTest(Output, 0x1E214160, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Adds() {
			// adds X4, X4, #1
			InsnTester.AutoTest(Output, 0xB1000484, (cpu, maddr) => {
			});
			// adds W13, W10, #0x10, LSL #12
			InsnTester.AutoTest(Output, 0x3140414D, (cpu, maddr) => {
			});
			// adds W8, W8, W0
			InsnTester.AutoTest(Output, 0x2B000108, (cpu, maddr) => {
			});
			// adds X13, X13, X5
			InsnTester.AutoTest(Output, 0xAB0501AD, (cpu, maddr) => {
			});
			// adds X14, X14, X6
			InsnTester.AutoTest(Output, 0xAB0601CE, (cpu, maddr) => {
			});
			// adds X14, X14, X3
			InsnTester.AutoTest(Output, 0xAB0301CE, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sub() {
			// sub X2, X9, X0
			InsnTester.AutoTest(Output, 0xCB000122, (cpu, maddr) => {
			});
			// sub W10, W10, #0xA00, LSL #12
			InsnTester.AutoTest(Output, 0x5168014A, (cpu, maddr) => {
			});
			// sub X4, X29, #0x5C
			InsnTester.AutoTest(Output, 0xD10173A4, (cpu, maddr) => {
			});
			// sub X3, X29, #0x20
			InsnTester.AutoTest(Output, 0xD10083A3, (cpu, maddr) => {
			});
			// sub W7, W7, W21
			InsnTester.AutoTest(Output, 0x4B1500E7, (cpu, maddr) => {
			});
			// sub SP, SP, #0x70
			InsnTester.AutoTest(Output, 0xD101C3FF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smulh() {
			// smulh X8, X0, X8
			InsnTester.AutoTest(Output, 0x9B487C08, (cpu, maddr) => {
			});
			// smulh X10, X10, X11
			InsnTester.AutoTest(Output, 0x9B4B7D4A, (cpu, maddr) => {
			});
			// smulh X9, X19, X9
			InsnTester.AutoTest(Output, 0x9B497E69, (cpu, maddr) => {
			});
			// smulh X8, X22, X8
			InsnTester.AutoTest(Output, 0x9B487EC8, (cpu, maddr) => {
			});
			// smulh X8, X8, X11
			InsnTester.AutoTest(Output, 0x9B4B7D08, (cpu, maddr) => {
			});
			// smulh X9, X8, X9
			InsnTester.AutoTest(Output, 0x9B497D09, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Neg() {
			// neg X0, X2
			InsnTester.AutoTest(Output, 0xCB0203E0, (cpu, maddr) => {
			});
			// neg X12, X10, LSL #29
			InsnTester.AutoTest(Output, 0xCB0A77EC, (cpu, maddr) => {
			});
			// neg X23, X22
			InsnTester.AutoTest(Output, 0xCB1603F7, (cpu, maddr) => {
			});
			// neg W12, W3
			InsnTester.AutoTest(Output, 0x4B0303EC, (cpu, maddr) => {
			});
			// neg W4, W19
			InsnTester.AutoTest(Output, 0x4B1303E4, (cpu, maddr) => {
			});
			// neg W9, W8, LSL #7
			InsnTester.AutoTest(Output, 0x4B081FE9, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev() {
			// rev W4, W5
			InsnTester.AutoTest(Output, 0x5AC008A4, (cpu, maddr) => {
			});
			// rev W30, W30
			InsnTester.AutoTest(Output, 0x5AC00BDE, (cpu, maddr) => {
			});
			// rev X12, X12
			InsnTester.AutoTest(Output, 0xDAC00D8C, (cpu, maddr) => {
			});
			// rev X11, X11
			InsnTester.AutoTest(Output, 0xDAC00D6B, (cpu, maddr) => {
			});
			// rev W28, W30
			InsnTester.AutoTest(Output, 0x5AC00BDC, (cpu, maddr) => {
			});
			// rev X8, X8
			InsnTester.AutoTest(Output, 0xDAC00D08, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Csneg() {
			// csneg W8, W8, W2, GE
			InsnTester.AutoTest(Output, 0x5A82A508, (cpu, maddr) => {
			});
			// csneg W11, W23, W27, LO
			InsnTester.AutoTest(Output, 0x5A9B36EB, (cpu, maddr) => {
			});
			// csneg W8, W10, W8, GT
			InsnTester.AutoTest(Output, 0x5A88C548, (cpu, maddr) => {
			});
			// csneg W12, W10, W22, GT
			InsnTester.AutoTest(Output, 0x5A96C54C, (cpu, maddr) => {
			});
			// csneg W21, W21, W8, LE
			InsnTester.AutoTest(Output, 0x5A88D6B5, (cpu, maddr) => {
			});
			// csneg W8, W9, W8, GT
			InsnTester.AutoTest(Output, 0x5A88C528, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fsqrt() {
			// fsqrt S3, S0
			InsnTester.AutoTest(Output, 0x1E21C003, (cpu, maddr) => {
			});
			// fsqrt S10, S11
			InsnTester.AutoTest(Output, 0x1E21C16A, (cpu, maddr) => {
			});
			// fsqrt D0, D1
			InsnTester.AutoTest(Output, 0x1E61C020, (cpu, maddr) => {
			});
			// fsqrt S0, S1
			InsnTester.AutoTest(Output, 0x1E21C020, (cpu, maddr) => {
			});
			// fsqrt S12, S0
			InsnTester.AutoTest(Output, 0x1E21C00C, (cpu, maddr) => {
			});
			// fsqrt S8, S0
			InsnTester.AutoTest(Output, 0x1E21C008, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldarb() {
			// ldarb W8, [X0]
			InsnTester.AutoTest(Output, 0x08DFFC08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldarb W10, [X10]
			InsnTester.AutoTest(Output, 0x08DFFD4A, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldarb W9, [X8]
			InsnTester.AutoTest(Output, 0x08DFFD09, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldarb W8, [X26]
			InsnTester.AutoTest(Output, 0x08DFFF48, (cpu, maddr) => {
				cpu.State->X26 = maddr;
			});
			// ldarb W8, [X27]
			InsnTester.AutoTest(Output, 0x08DFFF68, (cpu, maddr) => {
				cpu.State->X27 = maddr;
			});
			// ldarb W8, [X22]
			InsnTester.AutoTest(Output, 0x08DFFEC8, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
		}

		[Fact]
		public void Mul() {
			// mul X0, X0, X4
			InsnTester.AutoTest(Output, 0x9B047C00, (cpu, maddr) => {
			});
			// mul V0.4S, V0.4S, V0.S[1]
			InsnTester.AutoTest(Output, 0x4FA08000, (cpu, maddr) => {
			});
			// mul X0, X28, X0
			InsnTester.AutoTest(Output, 0x9B007F80, (cpu, maddr) => {
			});
			// mul X19, X21, X9
			InsnTester.AutoTest(Output, 0x9B097EB3, (cpu, maddr) => {
			});
			// mul W3, W12, W3
			InsnTester.AutoTest(Output, 0x1B037D83, (cpu, maddr) => {
			});
			// mul W8, W12, W13
			InsnTester.AutoTest(Output, 0x1B0D7D88, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Dsb() {
			// dsb SY
			InsnTester.AutoTest(Output, 0xD5033F9F, (cpu, maddr) => {
			});
			// dsb ISH
			InsnTester.AutoTest(Output, 0xD5033B9F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldarh() {
			// ldarh W0, [X0]
			InsnTester.AutoTest(Output, 0x48DFFC00, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldarh W8, [X20]
			InsnTester.AutoTest(Output, 0x48DFFE88, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldarh W8, [X8]
			InsnTester.AutoTest(Output, 0x48DFFD08, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void Asr() {
			// asr W2, W2, #3
			InsnTester.AutoTest(Output, 0x13037C42, (cpu, maddr) => {
			});
			// asr X10, X10, #0x3F
			InsnTester.AutoTest(Output, 0x937FFD4A, (cpu, maddr) => {
			});
			// asr W4, W2, #1
			InsnTester.AutoTest(Output, 0x13017C44, (cpu, maddr) => {
			});
			// asr W23, W23, W1
			InsnTester.AutoTest(Output, 0x1AC12AF7, (cpu, maddr) => {
			});
			// asr X14, X8, X11
			InsnTester.AutoTest(Output, 0x9ACB290E, (cpu, maddr) => {
			});
			// asr W15, W15, #3
			InsnTester.AutoTest(Output, 0x13037DEF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcsel() {
			// fcsel S0, S1, S0, MI
			InsnTester.AutoTest(Output, 0x1E204C20, (cpu, maddr) => {
			});
			// fcsel S20, S20, S21, GT
			InsnTester.AutoTest(Output, 0x1E35CE94, (cpu, maddr) => {
			});
			// fcsel S2, S1, S13, EQ
			InsnTester.AutoTest(Output, 0x1E2D0C22, (cpu, maddr) => {
			});
			// fcsel D3, D20, D3, VS
			InsnTester.AutoTest(Output, 0x1E636E83, (cpu, maddr) => {
			});
			// fcsel S3, S1, S4, GT
			InsnTester.AutoTest(Output, 0x1E24CC23, (cpu, maddr) => {
			});
			// fcsel S3, S10, S3, GT
			InsnTester.AutoTest(Output, 0x1E23CD43, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev16() {
			// rev16 W5, W3
			InsnTester.AutoTest(Output, 0x5AC00465, (cpu, maddr) => {
			});
			// rev16 W11, W28
			InsnTester.AutoTest(Output, 0x5AC0078B, (cpu, maddr) => {
			});
			// rev16 W26, W24
			InsnTester.AutoTest(Output, 0x5AC0071A, (cpu, maddr) => {
			});
			// rev16 W12, W12
			InsnTester.AutoTest(Output, 0x5AC0058C, (cpu, maddr) => {
			});
			// rev16 W3, W11
			InsnTester.AutoTest(Output, 0x5AC00563, (cpu, maddr) => {
			});
			// rev16 W10, W9
			InsnTester.AutoTest(Output, 0x5AC0052A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmax() {
			// fmax S4, S0, S1
			InsnTester.AutoTest(Output, 0x1E214804, (cpu, maddr) => {
			});
			// fmax S22, S20, S21
			InsnTester.AutoTest(Output, 0x1E354A96, (cpu, maddr) => {
			});
			// fmax S6, S1, S2
			InsnTester.AutoTest(Output, 0x1E224826, (cpu, maddr) => {
			});
			// fmax S0, S0, S15
			InsnTester.AutoTest(Output, 0x1E2F4800, (cpu, maddr) => {
			});
			// fmax S1, S1, S12
			InsnTester.AutoTest(Output, 0x1E2C4821, (cpu, maddr) => {
			});
			// fmax S1, S1, S0
			InsnTester.AutoTest(Output, 0x1E204821, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Eon() {
			// eon W10, W10, W9
			InsnTester.AutoTest(Output, 0x4A29014A, (cpu, maddr) => {
			});
			// eon W12, W12, W11
			InsnTester.AutoTest(Output, 0x4A2B018C, (cpu, maddr) => {
			});
			// eon W15, W15, W14
			InsnTester.AutoTest(Output, 0x4A2E01EF, (cpu, maddr) => {
			});
			// eon W14, W14, W13
			InsnTester.AutoTest(Output, 0x4A2D01CE, (cpu, maddr) => {
			});
			// eon W17, W18, W17
			InsnTester.AutoTest(Output, 0x4A310251, (cpu, maddr) => {
			});
			// eon W16, W17, W16
			InsnTester.AutoTest(Output, 0x4A300230, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Orr() {
			// orr X9, X9, #1
			InsnTester.AutoTest(Output, 0xB2400129, (cpu, maddr) => {
			});
			// orr X22, XZR, #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(Output, 0xB27FFBF6, (cpu, maddr) => {
			});
			// orr X21, X21, X7
			InsnTester.AutoTest(Output, 0xAA0702B5, (cpu, maddr) => {
			});
			// orr X14, X4, X2
			InsnTester.AutoTest(Output, 0xAA02008E, (cpu, maddr) => {
			});
			// orr W11, W11, #0x80000
			InsnTester.AutoTest(Output, 0x320D016B, (cpu, maddr) => {
			});
			// orr X1, X13, X10
			InsnTester.AutoTest(Output, 0xAA0A01A1, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldrb() {
			// ldrb W9, [X1]
			InsnTester.AutoTest(Output, 0x39400029, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
			// ldrb W14, [X13, W14, SXTW]
			InsnTester.AutoTest(Output, 0x386EC9AE, (cpu, maddr) => {
				cpu.State->X13 = maddr;
				cpu.State->X14 = 0x10;
			});
			// ldrb W9, [X0, #6]
			InsnTester.AutoTest(Output, 0x39401809, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrb W10, [SP, #0xC7]
			InsnTester.AutoTest(Output, 0x39431FEA, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
			// ldrb W8, [X19, #0xBEA]
			InsnTester.AutoTest(Output, 0x396FAA68, (cpu, maddr) => {
				cpu.State->X19 = maddr;
			});
			// ldrb W9, [X2, #0x1C]
			InsnTester.AutoTest(Output, 0x39407049, (cpu, maddr) => {
				cpu.State->X2 = maddr;
			});
		}

		[Fact]
		public void Ushll() {
			// ushll V6.4S, V6.4H, #0
			InsnTester.AutoTest(Output, 0x2F10A4C6, (cpu, maddr) => {
			});
			// ushll V13.4S, V13.4H, #0
			InsnTester.AutoTest(Output, 0x2F10A5AD, (cpu, maddr) => {
			});
			// ushll V3.4S, V2.4H, #0
			InsnTester.AutoTest(Output, 0x2F10A443, (cpu, maddr) => {
			});
			// ushll V0.4S, V0.4H, #0
			InsnTester.AutoTest(Output, 0x2F10A400, (cpu, maddr) => {
			});
			// ushll V21.4S, V21.4H, #0
			InsnTester.AutoTest(Output, 0x2F10A6B5, (cpu, maddr) => {
			});
			// ushll V2.8H, V1.8B, #0
			InsnTester.AutoTest(Output, 0x2F08A422, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrsbPostIndex() {
			// ldrsb W9, [X8], #1
			InsnTester.AutoTest(Output, 0x38C01509, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrsb W11, [X8], #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(Output, 0x38DFF50B, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrsb X12, [X10], #1
			InsnTester.AutoTest(Output, 0x3880154C, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrsb W11, [X9], #1
			InsnTester.AutoTest(Output, 0x38C0152B, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldrsb X8, [X20], #1
			InsnTester.AutoTest(Output, 0x38801688, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldrsb W26, [X20], #1
			InsnTester.AutoTest(Output, 0x38C0169A, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
		}

		[Fact]
		public void LdrshPostIndex() {
			// ldrsh W2, [X1], #2
			InsnTester.AutoTest(Output, 0x78C02422, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
			// ldrsh W10, [X26], #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(Output, 0x78DFE74A, (cpu, maddr) => {
				cpu.State->X26 = maddr;
			});
			// ldrsh W12, [X0], #2
			InsnTester.AutoTest(Output, 0x78C0240C, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrsh W13, [X9], #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(Output, 0x78DFE52D, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldrsh W11, [X10], #2
			InsnTester.AutoTest(Output, 0x78C0254B, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrsh W9, [X1], #2
			InsnTester.AutoTest(Output, 0x78C02429, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
		}

		[Fact]
		public void Ubfx() {
			// ubfx W9, W0, #1, #1
			InsnTester.AutoTest(Output, 0x53010409, (cpu, maddr) => {
			});
			// ubfx X15, X15, #0x1F, #0x20
			InsnTester.AutoTest(Output, 0xD35FF9EF, (cpu, maddr) => {
			});
			// ubfx W11, W9, #3, #1
			InsnTester.AutoTest(Output, 0x53030D2B, (cpu, maddr) => {
			});
			// ubfx W0, W8, #0xF, #5
			InsnTester.AutoTest(Output, 0x530F4D00, (cpu, maddr) => {
			});
			// ubfx W13, W13, #0xC, #1
			InsnTester.AutoTest(Output, 0x530C31AD, (cpu, maddr) => {
			});
			// ubfx W8, W20, #1, #1
			InsnTester.AutoTest(Output, 0x53010688, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Orn() {
			// orn W3, W1, W2
			InsnTester.AutoTest(Output, 0x2A220023, (cpu, maddr) => {
			});
			// orn W10, W11, W10
			InsnTester.AutoTest(Output, 0x2A2A016A, (cpu, maddr) => {
			});
			// orn W18, W10, W11
			InsnTester.AutoTest(Output, 0x2A2B0152, (cpu, maddr) => {
			});
			// orn W1, W17, W18
			InsnTester.AutoTest(Output, 0x2A320221, (cpu, maddr) => {
			});
			// orn W8, W17, W13
			InsnTester.AutoTest(Output, 0x2A2D0228, (cpu, maddr) => {
			});
			// orn W8, W26, W0
			InsnTester.AutoTest(Output, 0x2A200348, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fccmp() {
			// fccmp S8, S0, #4, MI
			InsnTester.AutoTest(Output, 0x1E204504, (cpu, maddr) => {
			});
			// fccmp S28, S23, #8, LS
			InsnTester.AutoTest(Output, 0x1E379788, (cpu, maddr) => {
			});
			// fccmp S2, S0, #0, LE
			InsnTester.AutoTest(Output, 0x1E20D440, (cpu, maddr) => {
			});
			// fccmp S0, S9, #2, GE
			InsnTester.AutoTest(Output, 0x1E29A402, (cpu, maddr) => {
			});
			// fccmp S3, S7, #8, PL
			InsnTester.AutoTest(Output, 0x1E275468, (cpu, maddr) => {
			});
			// fccmp S1, S9, #8, LS
			InsnTester.AutoTest(Output, 0x1E299428, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sxtb() {
			// sxtb W4, W6
			InsnTester.AutoTest(Output, 0x13001CC4, (cpu, maddr) => {
			});
			// sxtb X20, W19
			InsnTester.AutoTest(Output, 0x93401E74, (cpu, maddr) => {
			});
			// sxtb W18, W15
			InsnTester.AutoTest(Output, 0x13001DF2, (cpu, maddr) => {
			});
			// sxtb W17, W8
			InsnTester.AutoTest(Output, 0x13001D11, (cpu, maddr) => {
			});
			// sxtb X8, W16
			InsnTester.AutoTest(Output, 0x93401E08, (cpu, maddr) => {
			});
			// sxtb W9, W8
			InsnTester.AutoTest(Output, 0x13001D09, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sxth() {
			// sxth W2, W0
			InsnTester.AutoTest(Output, 0x13003C02, (cpu, maddr) => {
			});
			// sxth W25, W30
			InsnTester.AutoTest(Output, 0x13003FD9, (cpu, maddr) => {
			});
			// sxth W5, W3
			InsnTester.AutoTest(Output, 0x13003C65, (cpu, maddr) => {
			});
			// sxth W23, W26
			InsnTester.AutoTest(Output, 0x13003F57, (cpu, maddr) => {
			});
			// sxth X4, W14
			InsnTester.AutoTest(Output, 0x93403DC4, (cpu, maddr) => {
			});
			// sxth W21, W0
			InsnTester.AutoTest(Output, 0x13003C15, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bfxil() {
			// bfxil W6, W1, #0, #6
			InsnTester.AutoTest(Output, 0x33001426, (cpu, maddr) => {
			});
			// bfxil X16, X11, #0x15, #0x1F
			InsnTester.AutoTest(Output, 0xB355CD70, (cpu, maddr) => {
			});
			// bfxil W12, W9, #2, #0x1E
			InsnTester.AutoTest(Output, 0x33027D2C, (cpu, maddr) => {
			});
			// bfxil W0, W17, #0, #1
			InsnTester.AutoTest(Output, 0x33000220, (cpu, maddr) => {
			});
			// bfxil W22, W8, #0, #3
			InsnTester.AutoTest(Output, 0x33000916, (cpu, maddr) => {
			});
			// bfxil W8, W1, #6, #5
			InsnTester.AutoTest(Output, 0x33062828, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ccmp() {
			// ccmp X8, #0, #0, EQ
			InsnTester.AutoTest(Output, 0xFA400900, (cpu, maddr) => {
			});
			// ccmp W23, #0x1F, #2, NE
			InsnTester.AutoTest(Output, 0x7A5F1AE2, (cpu, maddr) => {
			});
			// ccmp X8, X26, #4, NE
			InsnTester.AutoTest(Output, 0xFA5A1104, (cpu, maddr) => {
			});
			// ccmp X10, X14, #0, LO
			InsnTester.AutoTest(Output, 0xFA4E3140, (cpu, maddr) => {
			});
			// ccmp W1, W4, #4, LT
			InsnTester.AutoTest(Output, 0x7A44B024, (cpu, maddr) => {
			});
			// ccmp X9, X2, #2, HS
			InsnTester.AutoTest(Output, 0xFA422122, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ccmn() {
			// ccmn X1, #1, #4, NE
			InsnTester.AutoTest(Output, 0xBA411824, (cpu, maddr) => {
			});
			// ccmn W22, #0x11, #4, NE
			InsnTester.AutoTest(Output, 0x3A511AC4, (cpu, maddr) => {
			});
			// ccmn W8, #1, #4, LO
			InsnTester.AutoTest(Output, 0x3A413904, (cpu, maddr) => {
			});
			// ccmn W9, #1, #4, NE
			InsnTester.AutoTest(Output, 0x3A411924, (cpu, maddr) => {
			});
			// ccmn W8, #1, #4, EQ
			InsnTester.AutoTest(Output, 0x3A410904, (cpu, maddr) => {
			});
			// ccmn W13, #1, #0, NE
			InsnTester.AutoTest(Output, 0x3A4119A0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sshr() {
			// sshr V0.16B, V1.16B, #7
			InsnTester.AutoTest(Output, 0x4F090420, (cpu, maddr) => {
			});
			// sshr V21.4S, V21.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F2106B5, (cpu, maddr) => {
			});
			// sshr V7.4S, V7.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F2104E7, (cpu, maddr) => {
			});
			// sshr V17.4S, V6.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F2104D1, (cpu, maddr) => {
			});
			// sshr V16.4S, V16.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F210610, (cpu, maddr) => {
			});
			// sshr V0.4S, V0.4S, #0x1F
			InsnTester.AutoTest(Output, 0x4F210400, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmin() {
			// fmin S0, S1, S0
			InsnTester.AutoTest(Output, 0x1E205820, (cpu, maddr) => {
			});
			// fmin S2, S17, S16
			InsnTester.AutoTest(Output, 0x1E305A22, (cpu, maddr) => {
			});
			// fmin S2, S11, S10
			InsnTester.AutoTest(Output, 0x1E2A5962, (cpu, maddr) => {
			});
			// fmin S0, S0, S15
			InsnTester.AutoTest(Output, 0x1E2F5800, (cpu, maddr) => {
			});
			// fmin S9, S1, S5
			InsnTester.AutoTest(Output, 0x1E255829, (cpu, maddr) => {
			});
			// fmin S2, S3, S2
			InsnTester.AutoTest(Output, 0x1E225862, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Mvn() {
			// mvn W0, W8
			InsnTester.AutoTest(Output, 0x2A2803E0, (cpu, maddr) => {
			});
			// mvn V16.16B, V16.16B
			InsnTester.AutoTest(Output, 0x6E205A10, (cpu, maddr) => {
			});
			// mvn W17, W1
			InsnTester.AutoTest(Output, 0x2A2103F1, (cpu, maddr) => {
			});
			// mvn X11, X9
			InsnTester.AutoTest(Output, 0xAA2903EB, (cpu, maddr) => {
			});
			// mvn W15, W13
			InsnTester.AutoTest(Output, 0x2A2D03EF, (cpu, maddr) => {
			});
			// mvn W0, W13
			InsnTester.AutoTest(Output, 0x2A2D03E0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvt() {
			// fcvt S2, D0
			InsnTester.AutoTest(Output, 0x1E624002, (cpu, maddr) => {
			});
			// fcvt S16, D16
			InsnTester.AutoTest(Output, 0x1E624210, (cpu, maddr) => {
			});
			// fcvt D16, S3
			InsnTester.AutoTest(Output, 0x1E22C070, (cpu, maddr) => {
			});
			// fcvt S5, D5
			InsnTester.AutoTest(Output, 0x1E6240A5, (cpu, maddr) => {
			});
			// fcvt S14, D0
			InsnTester.AutoTest(Output, 0x1E62400E, (cpu, maddr) => {
			});
			// fcvt D6, S5
			InsnTester.AutoTest(Output, 0x1E22C0A6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fsub() {
			// fsub S4, S1, S0
			InsnTester.AutoTest(Output, 0x1E203824, (cpu, maddr) => {
			});
			// fsub V21.4S, V26.4S, V30.4S
			InsnTester.AutoTest(Output, 0x4EBED755, (cpu, maddr) => {
			});
			// fsub S3, S0, S11
			InsnTester.AutoTest(Output, 0x1E2B3803, (cpu, maddr) => {
			});
			// fsub S2, S4, S8
			InsnTester.AutoTest(Output, 0x1E283882, (cpu, maddr) => {
			});
			// fsub V4.4S, V4.4S, V3.4S
			InsnTester.AutoTest(Output, 0x4EA3D484, (cpu, maddr) => {
			});
			// fsub S3, S18, S17
			InsnTester.AutoTest(Output, 0x1E313A43, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Subs() {
			// subs X8, X8, #1
			InsnTester.AutoTest(Output, 0xF1000508, (cpu, maddr) => {
			});
			// subs X21, X21, #0x600, LSL #12
			InsnTester.AutoTest(Output, 0xF15802B5, (cpu, maddr) => {
			});
			// subs W9, W26, W8
			InsnTester.AutoTest(Output, 0x6B080349, (cpu, maddr) => {
			});
			// subs W17, W17, W12
			InsnTester.AutoTest(Output, 0x6B0C0231, (cpu, maddr) => {
			});
			// subs X25, X20, X21
			InsnTester.AutoTest(Output, 0xEB150299, (cpu, maddr) => {
			});
			// subs W8, W8, W10
			InsnTester.AutoTest(Output, 0x6B0A0108, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Scvtf() {
			// scvtf S1, S0
			InsnTester.AutoTest(Output, 0x5E21D801, (cpu, maddr) => {
			});
			// scvtf V27.2S, V27.2S
			InsnTester.AutoTest(Output, 0x0E21DB7B, (cpu, maddr) => {
			});
			// scvtf D0, W2
			InsnTester.AutoTest(Output, 0x1E620040, (cpu, maddr) => {
			});
			// scvtf S5, W8
			InsnTester.AutoTest(Output, 0x1E220105, (cpu, maddr) => {
			});
			// scvtf S30, W10
			InsnTester.AutoTest(Output, 0x1E22015E, (cpu, maddr) => {
			});
			// scvtf S21, W21
			InsnTester.AutoTest(Output, 0x1E2202B5, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldur() {
			// ldur X7, [X4, #6]
			InsnTester.AutoTest(Output, 0xF8406087, (cpu, maddr) => {
				cpu.State->X4 = maddr;
			});
			// ldur W11, [X29, #-0xF0]
			InsnTester.AutoTest(Output, 0xB85103AB, (cpu, maddr) => {
				cpu.State->X29 = maddr;
			});
			// ldur Q0, [X8, #0x4C]
			InsnTester.AutoTest(Output, 0x3CC4C100, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldur X11, [SP, #0x26]
			InsnTester.AutoTest(Output, 0xF84263EB, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
			// ldur X21, [X21, #-0x10]
			InsnTester.AutoTest(Output, 0xF85F02B5, (cpu, maddr) => {
				cpu.State->X21 = maddr;
			});
			// ldur X25, [X29, #-0xF0]
			InsnTester.AutoTest(Output, 0xF85103B9, (cpu, maddr) => {
				cpu.State->X29 = maddr;
			});
		}

		[Fact]
		public void Smax() {
			// smax V1.4S, V1.4S, V5.4S
			InsnTester.AutoTest(Output, 0x4EA56421, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V1.4S
			InsnTester.AutoTest(Output, 0x4EA16400, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V3.4S
			InsnTester.AutoTest(Output, 0x4EA36400, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4EA26400, (cpu, maddr) => {
			});
			// smax V3.4S, V3.4S, V7.4S
			InsnTester.AutoTest(Output, 0x4EA76463, (cpu, maddr) => {
			});
			// smax V2.4S, V2.4S, V6.4S
			InsnTester.AutoTest(Output, 0x4EA66442, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umulh() {
			// umulh X8, X2, X0
			InsnTester.AutoTest(Output, 0x9BC07C48, (cpu, maddr) => {
			});
			// umulh X10, X10, X23
			InsnTester.AutoTest(Output, 0x9BD77D4A, (cpu, maddr) => {
			});
			// umulh X3, X2, X12
			InsnTester.AutoTest(Output, 0x9BCC7C43, (cpu, maddr) => {
			});
			// umulh X8, X23, X24
			InsnTester.AutoTest(Output, 0x9BD87EE8, (cpu, maddr) => {
			});
			// umulh X9, X9, X11
			InsnTester.AutoTest(Output, 0x9BCB7D29, (cpu, maddr) => {
			});
			// umulh X9, X27, X11
			InsnTester.AutoTest(Output, 0x9BCB7F69, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmeq() {
			// cmeq V1.4S, V0.4S, #0
			InsnTester.AutoTest(Output, 0x4EA09801, (cpu, maddr) => {
			});
			// cmeq V19.16B, V16.16B, V2.16B
			InsnTester.AutoTest(Output, 0x6E228E13, (cpu, maddr) => {
			});
			// cmeq V18.16B, V7.16B, V5.16B
			InsnTester.AutoTest(Output, 0x6E258CF2, (cpu, maddr) => {
			});
			// cmeq V16.16B, V5.16B, V3.16B
			InsnTester.AutoTest(Output, 0x6E238CB0, (cpu, maddr) => {
			});
			// cmeq V16.4S, V7.4S, #0
			InsnTester.AutoTest(Output, 0x4EA098F0, (cpu, maddr) => {
			});
			// cmeq V4.16B, V4.16B, V3.16B
			InsnTester.AutoTest(Output, 0x6E238C84, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmul() {
			// fmul S6, S0, S0
			InsnTester.AutoTest(Output, 0x1E200806, (cpu, maddr) => {
			});
			// fmul V31.4S, V21.4S, V31.S[0]
			InsnTester.AutoTest(Output, 0x4F9F92BF, (cpu, maddr) => {
			});
			// fmul S20, S6, S24
			InsnTester.AutoTest(Output, 0x1E3808D4, (cpu, maddr) => {
			});
			// fmul S7, S13, S3
			InsnTester.AutoTest(Output, 0x1E2309A7, (cpu, maddr) => {
			});
			// fmul S0, S0, S5
			InsnTester.AutoTest(Output, 0x1E250800, (cpu, maddr) => {
			});
			// fmul S16, S15, S2
			InsnTester.AutoTest(Output, 0x1E2209F0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Negs() {
			// negs X2, X2
			InsnTester.AutoTest(Output, 0xEB0203E2, (cpu, maddr) => {
			});
			// negs X17, X17
			InsnTester.AutoTest(Output, 0xEB1103F1, (cpu, maddr) => {
			});
			// negs X4, X5
			InsnTester.AutoTest(Output, 0xEB0503E4, (cpu, maddr) => {
			});
			// negs X0, X0
			InsnTester.AutoTest(Output, 0xEB0003E0, (cpu, maddr) => {
			});
			// negs X15, X15
			InsnTester.AutoTest(Output, 0xEB0F03EF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Xtn2() {
			// xtn2 V7.8H, V6.4S
			InsnTester.AutoTest(Output, 0x4E6128C7, (cpu, maddr) => {
			});
			// xtn2 V7.16B, V17.8H
			InsnTester.AutoTest(Output, 0x4E212A27, (cpu, maddr) => {
			});
			// xtn2 V5.8H, V16.4S
			InsnTester.AutoTest(Output, 0x4E612A05, (cpu, maddr) => {
			});
			// xtn2 V6.16B, V5.8H
			InsnTester.AutoTest(Output, 0x4E2128A6, (cpu, maddr) => {
			});
			// xtn2 V7.8H, V16.4S
			InsnTester.AutoTest(Output, 0x4E612A07, (cpu, maddr) => {
			});
			// xtn2 V4.16B, V3.8H
			InsnTester.AutoTest(Output, 0x4E212864, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ngcs() {
			// ngcs X3, X3
			InsnTester.AutoTest(Output, 0xFA0303E3, (cpu, maddr) => {
			});
			// ngcs X14, X14
			InsnTester.AutoTest(Output, 0xFA0E03EE, (cpu, maddr) => {
			});
			// ngcs X1, X1
			InsnTester.AutoTest(Output, 0xFA0103E1, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldrh() {
			// ldrh W7, [X1]
			InsnTester.AutoTest(Output, 0x79400027, (cpu, maddr) => {
				cpu.State->X1 = maddr;
			});
			// ldrh W10, [X11, W10, UXTW #1]
			InsnTester.AutoTest(Output, 0x786A596A, (cpu, maddr) => {
				cpu.State->X11 = maddr;
				cpu.State->X10 = 0x10;
			});
			// ldrh W8, [X8, #0x128]
			InsnTester.AutoTest(Output, 0x79425108, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrh W11, [SP, #0x18]
			InsnTester.AutoTest(Output, 0x794033EB, (cpu, maddr) => {
				cpu.State->SP = maddr;
			});
			// ldrh W9, [X5, #2]
			InsnTester.AutoTest(Output, 0x794004A9, (cpu, maddr) => {
				cpu.State->X5 = maddr;
			});
			// ldrh W4, [X14, X2]
			InsnTester.AutoTest(Output, 0x786269C4, (cpu, maddr) => {
				cpu.State->X14 = maddr;
				cpu.State->X2 = 0x10;
			});
		}

		[Fact]
		public void LdrsbPreIndex() {
			// ldrsb W9, [X0, #1]!
			InsnTester.AutoTest(Output, 0x38C01C09, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrsb X11, [X10, #0x11]!
			InsnTester.AutoTest(Output, 0x38811D4B, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrsb W10, [X9, #1]!
			InsnTester.AutoTest(Output, 0x38C01D2A, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldrsb W8, [X21, #1]!
			InsnTester.AutoTest(Output, 0x38C01EA8, (cpu, maddr) => {
				cpu.State->X21 = maddr;
			});
			// ldrsb W27, [X11, #2]!
			InsnTester.AutoTest(Output, 0x38C02D7B, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldrsb W13, [X9, #-1]!
			InsnTester.AutoTest(Output, 0x38DFFD2D, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
		}

		[Fact]
		public void Csinv() {
			// csinv W8, W8, W3, GE
			InsnTester.AutoTest(Output, 0x5A83A108, (cpu, maddr) => {
			});
			// csinv W18, W16, WZR, LE
			InsnTester.AutoTest(Output, 0x5A9FD212, (cpu, maddr) => {
			});
			// csinv W8, W9, WZR, GE
			InsnTester.AutoTest(Output, 0x5A9FA128, (cpu, maddr) => {
			});
			// csinv W12, W13, W24, LE
			InsnTester.AutoTest(Output, 0x5A98D1AC, (cpu, maddr) => {
			});
			// csinv W8, W9, W8, LS
			InsnTester.AutoTest(Output, 0x5A889128, (cpu, maddr) => {
			});
			// csinv W25, W9, WZR, LE
			InsnTester.AutoTest(Output, 0x5A9FD139, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrswPreIndex() {
			// ldrsw X4, [X0, #8]!
			InsnTester.AutoTest(Output, 0xB8808C04, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrsw X25, [X9, #-0x14]!
			InsnTester.AutoTest(Output, 0xB89ECD39, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldrsw X8, [X28, #0x2C]!
			InsnTester.AutoTest(Output, 0xB882CF88, (cpu, maddr) => {
				cpu.State->X28 = maddr;
			});
			// ldrsw X3, [X18, #8]!
			InsnTester.AutoTest(Output, 0xB8808E43, (cpu, maddr) => {
				cpu.State->X18 = maddr;
			});
			// ldrsw X8, [X21, #0x1C]!
			InsnTester.AutoTest(Output, 0xB881CEA8, (cpu, maddr) => {
				cpu.State->X21 = maddr;
			});
			// ldrsw X9, [X8, #0x68]!
			InsnTester.AutoTest(Output, 0xB8868D09, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void Faddp() {
			// faddp S3, V5.2S
			InsnTester.AutoTest(Output, 0x7E30D8A3, (cpu, maddr) => {
			});
			// faddp V21.2S, V21.2S, V22.2S
			InsnTester.AutoTest(Output, 0x2E36D6B5, (cpu, maddr) => {
			});
			// faddp V17.2S, V17.2S, V18.2S
			InsnTester.AutoTest(Output, 0x2E32D631, (cpu, maddr) => {
			});
			// faddp S23, V20.2S
			InsnTester.AutoTest(Output, 0x7E30DA97, (cpu, maddr) => {
			});
			// faddp V2.2S, V1.2S, V1.2S
			InsnTester.AutoTest(Output, 0x2E21D422, (cpu, maddr) => {
			});
			// faddp V18.2S, V18.2S, V19.2S
			InsnTester.AutoTest(Output, 0x2E33D652, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rev32() {
			// rev32 V0.16B, V0.16B
			InsnTester.AutoTest(Output, 0x6E200800, (cpu, maddr) => {
			});
			// rev32 V16.16B, V16.16B
			InsnTester.AutoTest(Output, 0x6E200A10, (cpu, maddr) => {
			});
			// rev32 V1.16B, V1.16B
			InsnTester.AutoTest(Output, 0x6E200821, (cpu, maddr) => {
			});
			// rev32 V5.16B, V5.16B
			InsnTester.AutoTest(Output, 0x6E2008A5, (cpu, maddr) => {
			});
			// rev32 V7.16B, V7.16B
			InsnTester.AutoTest(Output, 0x6E2008E7, (cpu, maddr) => {
			});
			// rev32 V3.16B, V3.16B
			InsnTester.AutoTest(Output, 0x6E200863, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Csinc() {
			// csinc X6, X9, X0, NE
			InsnTester.AutoTest(Output, 0x9A801526, (cpu, maddr) => {
			});
			// csinc W10, WZR, W10, GE
			InsnTester.AutoTest(Output, 0x1A8AA7EA, (cpu, maddr) => {
			});
			// csinc X1, X9, X11, NE
			InsnTester.AutoTest(Output, 0x9A8B1521, (cpu, maddr) => {
			});
			// csinc W12, W13, W8, LT
			InsnTester.AutoTest(Output, 0x1A88B5AC, (cpu, maddr) => {
			});
			// csinc W9, W15, W9, LT
			InsnTester.AutoTest(Output, 0x1A89B5E9, (cpu, maddr) => {
			});
			// csinc X8, X9, X25, NE
			InsnTester.AutoTest(Output, 0x9A991528, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Dup() {
			// dup V0.4S, W1
			InsnTester.AutoTest(Output, 0x4E040C20, (cpu, maddr) => {
			});
			// dup V17.4S, V17.S[0]
			InsnTester.AutoTest(Output, 0x4E040631, (cpu, maddr) => {
			});
			// dup V20.4S, V25.S[0]
			InsnTester.AutoTest(Output, 0x4E040734, (cpu, maddr) => {
			});
			// dup V31.2S, V24.S[1]
			InsnTester.AutoTest(Output, 0x0E0C071F, (cpu, maddr) => {
			});
			// dup V3.2D, V2.D[1]
			InsnTester.AutoTest(Output, 0x4E180443, (cpu, maddr) => {
			});
			// dup V21.4S, V21.S[0]
			InsnTester.AutoTest(Output, 0x4E0406B5, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ands() {
			// ands W28, W8, #4
			InsnTester.AutoTest(Output, 0x721E011C, (cpu, maddr) => {
			});
			// ands W11, W11, #0xFFFFFFFE
			InsnTester.AutoTest(Output, 0x721F796B, (cpu, maddr) => {
			});
			// ands W10, W10, #1
			InsnTester.AutoTest(Output, 0x7200014A, (cpu, maddr) => {
			});
			// ands X13, X13, #7
			InsnTester.AutoTest(Output, 0xF24009AD, (cpu, maddr) => {
			});
			// ands W13, W10, #0x4000
			InsnTester.AutoTest(Output, 0x7212014D, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldar() {
			// ldar W8, [X8]
			InsnTester.AutoTest(Output, 0x88DFFD08, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldar X28, [X27]
			InsnTester.AutoTest(Output, 0xC8DFFF7C, (cpu, maddr) => {
				cpu.State->X27 = maddr;
			});
			// ldar W9, [X27]
			InsnTester.AutoTest(Output, 0x88DFFF69, (cpu, maddr) => {
				cpu.State->X27 = maddr;
			});
			// ldar X24, [X28]
			InsnTester.AutoTest(Output, 0xC8DFFF98, (cpu, maddr) => {
				cpu.State->X28 = maddr;
			});
			// ldar X9, [X8]
			InsnTester.AutoTest(Output, 0xC8DFFD09, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldar X0, [X8]
			InsnTester.AutoTest(Output, 0xC8DFFD00, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void Ldxrh() {
			// ldxrh W8, [X0]
			InsnTester.AutoTest(Output, 0x485F7C08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldxrh W10, [X20]
			InsnTester.AutoTest(Output, 0x485F7E8A, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldxrh W9, [X0]
			InsnTester.AutoTest(Output, 0x485F7C09, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldxrh W9, [X20]
			InsnTester.AutoTest(Output, 0x485F7E89, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
		}

		[Fact]
		public void Ld1R() {
			// ld1r {V6.4S}, [X8]
			InsnTester.AutoTest(Output, 0x4D40C906, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ld1r {V19.4S}, [X10]
			InsnTester.AutoTest(Output, 0x4D40C953, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ld1r {V25.4S}, [X10]
			InsnTester.AutoTest(Output, 0x4D40C959, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ld1r {V7.16B}, [X8]
			InsnTester.AutoTest(Output, 0x4D40C107, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ld1r {V0.4S}, [X11]
			InsnTester.AutoTest(Output, 0x4D40C960, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ld1r {V5.4S}, [X11]
			InsnTester.AutoTest(Output, 0x4D40C965, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
		}

		[Fact]
		public void Fcvtms() {
			// fcvtms W0, S0
			InsnTester.AutoTest(Output, 0x1E300000, (cpu, maddr) => {
			});
			// fcvtms W22, S19
			InsnTester.AutoTest(Output, 0x1E300276, (cpu, maddr) => {
			});
			// fcvtms W8, S0
			InsnTester.AutoTest(Output, 0x1E300008, (cpu, maddr) => {
			});
			// fcvtms W21, S16
			InsnTester.AutoTest(Output, 0x1E300215, (cpu, maddr) => {
			});
			// fcvtms W9, S16
			InsnTester.AutoTest(Output, 0x1E300209, (cpu, maddr) => {
			});
			// fcvtms W19, S0
			InsnTester.AutoTest(Output, 0x1E300013, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ushll2() {
			// ushll2 V1.4S, V1.8H, #0
			InsnTester.AutoTest(Output, 0x6F10A421, (cpu, maddr) => {
			});
			// ushll2 V1.8H, V1.16B, #0
			InsnTester.AutoTest(Output, 0x6F08A421, (cpu, maddr) => {
			});
			// ushll2 V2.4S, V2.8H, #0
			InsnTester.AutoTest(Output, 0x6F10A442, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldxrb() {
			// ldxrb W8, [X0]
			InsnTester.AutoTest(Output, 0x085F7C08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldxrb W9, [X0]
			InsnTester.AutoTest(Output, 0x085F7C09, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
		}

		[Fact]
		public void Frsqrts() {
			// frsqrts V2.4S, V0.4S, V2.4S
			InsnTester.AutoTest(Output, 0x4EA2FC02, (cpu, maddr) => {
			});
			// frsqrts V31.4S, V30.4S, V31.4S
			InsnTester.AutoTest(Output, 0x4EBFFFDF, (cpu, maddr) => {
			});
			// frsqrts V3.4S, V4.4S, V3.4S
			InsnTester.AutoTest(Output, 0x4EA3FC83, (cpu, maddr) => {
			});
			// frsqrts V7.4S, V6.4S, V7.4S
			InsnTester.AutoTest(Output, 0x4EA7FCC7, (cpu, maddr) => {
			});
			// frsqrts V16.4S, V7.4S, V16.4S
			InsnTester.AutoTest(Output, 0x4EB0FCF0, (cpu, maddr) => {
			});
			// frsqrts V7.4S, V4.4S, V7.4S
			InsnTester.AutoTest(Output, 0x4EA7FC87, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldursw() {
			// ldursw X8, [X9, #1]
			InsnTester.AutoTest(Output, 0xB8801128, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldursw X21, [X29, #-0x14]
			InsnTester.AutoTest(Output, 0xB89EC3B5, (cpu, maddr) => {
				cpu.State->X29 = maddr;
			});
			// ldursw X10, [X23, #-0x10]
			InsnTester.AutoTest(Output, 0xB89F02EA, (cpu, maddr) => {
				cpu.State->X23 = maddr;
			});
			// ldursw X8, [X29, #-0x3C]
			InsnTester.AutoTest(Output, 0xB89C43A8, (cpu, maddr) => {
				cpu.State->X29 = maddr;
			});
			// ldursw X16, [X10, #-0xC0]
			InsnTester.AutoTest(Output, 0xB8940150, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldursw X13, [X11, #-4]
			InsnTester.AutoTest(Output, 0xB89FC16D, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
		}

		[Fact]
		public void Ldursh() {
			// ldursh X8, [X9, #1]
			InsnTester.AutoTest(Output, 0x78801128, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldursh W14, [X23, #-0x10]
			InsnTester.AutoTest(Output, 0x78DF02EE, (cpu, maddr) => {
				cpu.State->X23 = maddr;
			});
			// ldursh W6, [X15, #-0x1E]
			InsnTester.AutoTest(Output, 0x78DE21E6, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
			// ldursh X24, [X14, #-2]
			InsnTester.AutoTest(Output, 0x789FE1D8, (cpu, maddr) => {
				cpu.State->X14 = maddr;
			});
			// ldursh W12, [X11, #-2]
			InsnTester.AutoTest(Output, 0x78DFE16C, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldursh W5, [X4, #-2]
			InsnTester.AutoTest(Output, 0x78DFE085, (cpu, maddr) => {
				cpu.State->X4 = maddr;
			});
		}

		[Fact]
		public void LdrhPostIndex() {
			// ldrh W5, [X6], #2
			InsnTester.AutoTest(Output, 0x784024C5, (cpu, maddr) => {
				cpu.State->X6 = maddr;
			});
			// ldrh W13, [X11], #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(Output, 0x785FE56D, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldrh W16, [X15], #0xFFFFFFFFFFFFFFF0
			InsnTester.AutoTest(Output, 0x785F05F0, (cpu, maddr) => {
				cpu.State->X15 = maddr;
			});
			// ldrh W24, [X19], #2
			InsnTester.AutoTest(Output, 0x78402678, (cpu, maddr) => {
				cpu.State->X19 = maddr;
			});
			// ldrh W0, [X8], #2
			InsnTester.AutoTest(Output, 0x78402500, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrh W10, [X2], #2
			InsnTester.AutoTest(Output, 0x7840244A, (cpu, maddr) => {
				cpu.State->X2 = maddr;
			});
		}

		[Fact]
		public void Xtn() {
			// xtn V4.2S, V1.2D
			InsnTester.AutoTest(Output, 0x0EA12824, (cpu, maddr) => {
			});
			// xtn V13.4H, V10.4S
			InsnTester.AutoTest(Output, 0x0E61294D, (cpu, maddr) => {
			});
			// xtn V3.4H, V3.4S
			InsnTester.AutoTest(Output, 0x0E612863, (cpu, maddr) => {
			});
			// xtn V0.4H, V13.4S
			InsnTester.AutoTest(Output, 0x0E6129A0, (cpu, maddr) => {
			});
			// xtn V1.2S, V0.2D
			InsnTester.AutoTest(Output, 0x0EA12801, (cpu, maddr) => {
			});
			// xtn V21.4H, V7.4S
			InsnTester.AutoTest(Output, 0x0E6128F5, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrbPreIndex() {
			// ldrb W4, [X5, #1]!
			InsnTester.AutoTest(Output, 0x38401CA4, (cpu, maddr) => {
				cpu.State->X5 = maddr;
			});
			// ldrb W11, [X10, #-0x10]!
			InsnTester.AutoTest(Output, 0x385F0D4B, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrb W11, [X10, #0x81]!
			InsnTester.AutoTest(Output, 0x38481D4B, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrb W8, [X0, #0xB0]!
			InsnTester.AutoTest(Output, 0x384B0C08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrb W10, [X9, #8]!
			InsnTester.AutoTest(Output, 0x38408D2A, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldrb W14, [X13, #-1]!
			InsnTester.AutoTest(Output, 0x385FFDAE, (cpu, maddr) => {
				cpu.State->X13 = maddr;
			});
		}

		[Fact]
		public void Frsqrte() {
			// frsqrte V0.4S, V1.4S
			InsnTester.AutoTest(Output, 0x6EA1D820, (cpu, maddr) => {
			});
			// frsqrte V17.4S, V16.4S
			InsnTester.AutoTest(Output, 0x6EA1DA11, (cpu, maddr) => {
			});
			// frsqrte V6.4S, V2.4S
			InsnTester.AutoTest(Output, 0x6EA1D846, (cpu, maddr) => {
			});
			// frsqrte V1.4S, V5.4S
			InsnTester.AutoTest(Output, 0x6EA1D8A1, (cpu, maddr) => {
			});
			// frsqrte V4.4S, V5.4S
			InsnTester.AutoTest(Output, 0x6EA1D8A4, (cpu, maddr) => {
			});
			// frsqrte V2.4S, V1.4S
			InsnTester.AutoTest(Output, 0x6EA1D822, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frintx() {
			// frintx S2, S1
			InsnTester.AutoTest(Output, 0x1E274022, (cpu, maddr) => {
			});
			// frintx D8, D8
			InsnTester.AutoTest(Output, 0x1E674108, (cpu, maddr) => {
			});
			// frintx D0, D0
			InsnTester.AutoTest(Output, 0x1E674000, (cpu, maddr) => {
			});
			// frintx S0, S0
			InsnTester.AutoTest(Output, 0x1E274000, (cpu, maddr) => {
			});
			// frintx S8, S8
			InsnTester.AutoTest(Output, 0x1E274108, (cpu, maddr) => {
			});
			// frintx D2, D1
			InsnTester.AutoTest(Output, 0x1E674022, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Madd() {
			// madd W0, W1, W1, W0
			InsnTester.AutoTest(Output, 0x1B010020, (cpu, maddr) => {
			});
			// madd X16, X10, X16, X15
			InsnTester.AutoTest(Output, 0x9B103D50, (cpu, maddr) => {
			});
			// madd X2, X23, X8, X0
			InsnTester.AutoTest(Output, 0x9B0802E2, (cpu, maddr) => {
			});
			// madd W6, W6, W10, W19
			InsnTester.AutoTest(Output, 0x1B0A4CC6, (cpu, maddr) => {
			});
			// madd W14, W14, W26, W16
			InsnTester.AutoTest(Output, 0x1B1A41CE, (cpu, maddr) => {
			});
			// madd W8, W14, W14, W8
			InsnTester.AutoTest(Output, 0x1B0E21C8, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmp() {
			// fcmp S1, S0
			InsnTester.AutoTest(Output, 0x1E202020, (cpu, maddr) => {
			});
			// fcmp D11, #0.0
			InsnTester.AutoTest(Output, 0x1E602168, (cpu, maddr) => {
			});
			// fcmp S17, S8
			InsnTester.AutoTest(Output, 0x1E282220, (cpu, maddr) => {
			});
			// fcmp S3, S14
			InsnTester.AutoTest(Output, 0x1E2E2060, (cpu, maddr) => {
			});
			// fcmp S0, S13
			InsnTester.AutoTest(Output, 0x1E2D2000, (cpu, maddr) => {
			});
			// fcmp S25, #0.0
			InsnTester.AutoTest(Output, 0x1E202328, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrbPostIndex() {
			// ldrb W8, [X0], #1
			InsnTester.AutoTest(Output, 0x38401408, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrb W18, [X11], #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(Output, 0x385FF572, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldrb W12, [X8], #0x70
			InsnTester.AutoTest(Output, 0x3847050C, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrb W0, [X17], #1
			InsnTester.AutoTest(Output, 0x38401620, (cpu, maddr) => {
				cpu.State->X17 = maddr;
			});
			// ldrb W24, [X18], #1
			InsnTester.AutoTest(Output, 0x38401658, (cpu, maddr) => {
				cpu.State->X18 = maddr;
			});
			// ldrb W13, [X11], #2
			InsnTester.AutoTest(Output, 0x3840256D, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
		}

		[Fact]
		public void Ldrsb() {
			// ldrsb X8, [X8]
			InsnTester.AutoTest(Output, 0x39800108, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrsb W15, [X10, W15, SXTW]
			InsnTester.AutoTest(Output, 0x38EFC94F, (cpu, maddr) => {
				cpu.State->X10 = maddr;
				cpu.State->X15 = 0x10;
			});
			// ldrsb W22, [X21, X9]
			InsnTester.AutoTest(Output, 0x38E96AB6, (cpu, maddr) => {
				cpu.State->X21 = maddr;
				cpu.State->X9 = 0x10;
			});
			// ldrsb W9, [X25, X28]
			InsnTester.AutoTest(Output, 0x38FC6B29, (cpu, maddr) => {
				cpu.State->X25 = maddr;
				cpu.State->X28 = 0x10;
			});
			// ldrsb W8, [X19, #0x19A]
			InsnTester.AutoTest(Output, 0x39C66A68, (cpu, maddr) => {
				cpu.State->X19 = maddr;
			});
			// ldrsb W12, [X0, #3]
			InsnTester.AutoTest(Output, 0x39C00C0C, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
		}

		[Fact]
		public void Fdiv() {
			// fdiv S5, S2, S0
			InsnTester.AutoTest(Output, 0x1E201845, (cpu, maddr) => {
			});
			// fdiv S21, S22, S21
			InsnTester.AutoTest(Output, 0x1E351AD5, (cpu, maddr) => {
			});
			// fdiv S2, S7, S0
			InsnTester.AutoTest(Output, 0x1E2018E2, (cpu, maddr) => {
			});
			// fdiv D10, D5, D6
			InsnTester.AutoTest(Output, 0x1E6618AA, (cpu, maddr) => {
			});
			// fdiv S20, S7, S3
			InsnTester.AutoTest(Output, 0x1E2318F4, (cpu, maddr) => {
			});
			// fdiv S15, S0, S11
			InsnTester.AutoTest(Output, 0x1E2B180F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldxr() {
			// ldxr W8, [X0]
			InsnTester.AutoTest(Output, 0x885F7C08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldxr X26, [X27]
			InsnTester.AutoTest(Output, 0xC85F7F7A, (cpu, maddr) => {
				cpu.State->X27 = maddr;
			});
			// ldxr W11, [X10]
			InsnTester.AutoTest(Output, 0x885F7D4B, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldxr X9, [X20]
			InsnTester.AutoTest(Output, 0xC85F7E89, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldxr X0, [X8]
			InsnTester.AutoTest(Output, 0xC85F7D00, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldxr X8, [X21]
			InsnTester.AutoTest(Output, 0xC85F7EA8, (cpu, maddr) => {
				cpu.State->X21 = maddr;
			});
		}

		[Fact]
		public void Prfm() {
			// prfm PLDL2STRM, [X8]
			InsnTester.AutoTest(Output, 0xF9800103, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// prfm PSTL1KEEP, [X9, #0x40]
			InsnTester.AutoTest(Output, 0xF9802130, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// prfm PSTL2STRM, [X11]
			InsnTester.AutoTest(Output, 0xF9800173, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// prfm PSTL1KEEP, [X8, #0x40]
			InsnTester.AutoTest(Output, 0xF9802110, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// prfm PLDL2STRM, [X10]
			InsnTester.AutoTest(Output, 0xF9800143, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// prfm PSTL2STRM, [X10]
			InsnTester.AutoTest(Output, 0xF9800153, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
		}

		[Fact]
		public void LdrshPreIndex() {
			// ldrsh W6, [X5, #8]!
			InsnTester.AutoTest(Output, 0x78C08CA6, (cpu, maddr) => {
				cpu.State->X5 = maddr;
			});
			// ldrsh W13, [X12, #-0x60]!
			InsnTester.AutoTest(Output, 0x78DA0D8D, (cpu, maddr) => {
				cpu.State->X12 = maddr;
			});
			// ldrsh W9, [X11, #-2]!
			InsnTester.AutoTest(Output, 0x78DFED69, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldrsh W9, [X22, #4]!
			InsnTester.AutoTest(Output, 0x78C04EC9, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldrsh W10, [X9, #2]!
			InsnTester.AutoTest(Output, 0x78C02D2A, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldrsh W13, [X9, #-2]!
			InsnTester.AutoTest(Output, 0x78DFED2D, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
		}

		[Fact]
		public void Dmb() {
			// dmb ISH
			InsnTester.AutoTest(Output, 0xD5033BBF, (cpu, maddr) => {
			});
			// dmb ISHST
			InsnTester.AutoTest(Output, 0xD5033ABF, (cpu, maddr) => {
			});
			// dmb ISHLD
			InsnTester.AutoTest(Output, 0xD50339BF, (cpu, maddr) => {
			});
		}

		[Fact]
		public void And() {
			// and W2, W8, #1
			InsnTester.AutoTest(Output, 0x12000102, (cpu, maddr) => {
			});
			// and X26, X26, #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(Output, 0x927FFB5A, (cpu, maddr) => {
			});
			// and W11, W0, #3
			InsnTester.AutoTest(Output, 0x1200040B, (cpu, maddr) => {
			});
			// and W8, W10, #2
			InsnTester.AutoTest(Output, 0x121F0148, (cpu, maddr) => {
			});
			// and W17, W2, #0xFF0000
			InsnTester.AutoTest(Output, 0x12101C51, (cpu, maddr) => {
			});
			// and W18, W4, #0xFFFF
			InsnTester.AutoTest(Output, 0x12003C92, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Pmull() {
			// pmull V0.1Q, V1.1D, V0.1D
			InsnTester.AutoTest(Output, 0x0EE0E020, (cpu, maddr) => {
			});
			// pmull V31.1Q, V19.1D, V1.1D
			InsnTester.AutoTest(Output, 0x0EE1E27F, (cpu, maddr) => {
			});
			// pmull V20.1Q, V16.1D, V3.1D
			InsnTester.AutoTest(Output, 0x0EE3E214, (cpu, maddr) => {
			});
			// pmull V2.1Q, V0.1D, V1.1D
			InsnTester.AutoTest(Output, 0x0EE1E002, (cpu, maddr) => {
			});
			// pmull V21.1Q, V17.1D, V2.1D
			InsnTester.AutoTest(Output, 0x0EE2E235, (cpu, maddr) => {
			});
			// pmull V22.1Q, V18.1D, V8.1D
			InsnTester.AutoTest(Output, 0x0EE8E256, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cmhi() {
			// cmhi V2.8H, V2.8H, V0.8H
			InsnTester.AutoTest(Output, 0x6E603442, (cpu, maddr) => {
			});
			// cmhi V3.8H, V3.8H, V0.8H
			InsnTester.AutoTest(Output, 0x6E603463, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Shrn() {
			// shrn V3.2S, V0.2D, #0x20
			InsnTester.AutoTest(Output, 0x0F208403, (cpu, maddr) => {
			});
			// shrn V17.2S, V6.2D, #0x20
			InsnTester.AutoTest(Output, 0x0F2084D1, (cpu, maddr) => {
			});
			// shrn V1.2S, V4.2D, #0x20
			InsnTester.AutoTest(Output, 0x0F208481, (cpu, maddr) => {
			});
			// shrn V5.2S, V1.2D, #0x20
			InsnTester.AutoTest(Output, 0x0F208425, (cpu, maddr) => {
			});
			// shrn V2.2S, V0.2D, #0x20
			InsnTester.AutoTest(Output, 0x0F208402, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ins() {
			// ins V0.S[0], W8
			InsnTester.AutoTest(Output, 0x4E041D00, (cpu, maddr) => {
			});
			// ins V31.S[1], V24.S[1]
			InsnTester.AutoTest(Output, 0x6E0C271F, (cpu, maddr) => {
			});
			// ins V19.S[3], V18.S[3]
			InsnTester.AutoTest(Output, 0x6E1C6653, (cpu, maddr) => {
			});
			// ins V3.S[0], V2.S[0]
			InsnTester.AutoTest(Output, 0x6E040443, (cpu, maddr) => {
			});
			// ins V4.D[1], V1.D[0]
			InsnTester.AutoTest(Output, 0x6E180424, (cpu, maddr) => {
			});
			// ins V16.S[0], V7.S[0]
			InsnTester.AutoTest(Output, 0x6E0404F0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Dc() {
			// dc CVAU, X11
			InsnTester.AutoTest(Output, 0xD50B7B2B, (cpu, maddr) => {
			});
			// dc CIVAC, X10
			InsnTester.AutoTest(Output, 0xD50B7E2A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ld1PostIndex() {
			// ld1 {V0.S}[0], [X8], #4
			InsnTester.AutoTest(Output, 0x0DDF8100, (cpu, maddr) => {
			});
			// ld1 {V16.S}[3], [X21], #4
			InsnTester.AutoTest(Output, 0x4DDF92B0, (cpu, maddr) => {
			});
			// ld1 {V1.S}[0], [X1], #4
			InsnTester.AutoTest(Output, 0x0DDF8021, (cpu, maddr) => {
			});
			// ld1 {V0.S}[3], [X17], #4
			InsnTester.AutoTest(Output, 0x4DDF9220, (cpu, maddr) => {
			});
			// ld1 {V3.S}[1], [X12], #4
			InsnTester.AutoTest(Output, 0x0DDF9183, (cpu, maddr) => {
			});
			// ld1 {V0.S}[3], [X8], #4
			InsnTester.AutoTest(Output, 0x4DDF9100, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmlt() {
			// fcmlt V19.4S, V7.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0E8F3, (cpu, maddr) => {
			});
			// fcmlt V27.4S, V29.4S, #0.0
			InsnTester.AutoTest(Output, 0x4EA0EBBB, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Csetm() {
			// csetm W0, HI
			InsnTester.AutoTest(Output, 0x5A9F93E0, (cpu, maddr) => {
			});
			// csetm W23, LE
			InsnTester.AutoTest(Output, 0x5A9FC3F7, (cpu, maddr) => {
			});
			// csetm W11, LT
			InsnTester.AutoTest(Output, 0x5A9FA3EB, (cpu, maddr) => {
			});
			// csetm W23, NE
			InsnTester.AutoTest(Output, 0x5A9F03F7, (cpu, maddr) => {
			});
			// csetm X0, EQ
			InsnTester.AutoTest(Output, 0xDA9F13E0, (cpu, maddr) => {
			});
			// csetm W14, HI
			InsnTester.AutoTest(Output, 0x5A9F93EE, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrPostIndex() {
			// ldr W5, [X0], #4
			InsnTester.AutoTest(Output, 0xB8404405, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldr W23, [X20], #0xFFFFFFFFFFFFFFFC
			InsnTester.AutoTest(Output, 0xB85FC697, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldr X1, [X22], #8
			InsnTester.AutoTest(Output, 0xF84086C1, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldr X8, [X22], #0x30
			InsnTester.AutoTest(Output, 0xF84306C8, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldr D2, [X9], #0xFFFFFFFFFFFFFFF8
			InsnTester.AutoTest(Output, 0xFC5F8522, (cpu, maddr) => {
				cpu.State->X9 = maddr;
			});
			// ldr X0, [X20], #0x30
			InsnTester.AutoTest(Output, 0xF8430680, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
		}

		[Fact]
		public void Fmls() {
			// fmls V6.4S, V2.4S, V0.4S
			InsnTester.AutoTest(Output, 0x4EA0CC46, (cpu, maddr) => {
			});
			// fmls V27.4S, V26.4S, V28.S[0]
			InsnTester.AutoTest(Output, 0x4F9C535B, (cpu, maddr) => {
			});
			// fmls V3.4S, V0.4S, V2.S[2]
			InsnTester.AutoTest(Output, 0x4F825803, (cpu, maddr) => {
			});
			// fmls V30.4S, V24.4S, V8.S[2]
			InsnTester.AutoTest(Output, 0x4F885B1E, (cpu, maddr) => {
			});
			// fmls V2.4S, V16.4S, V4.4S
			InsnTester.AutoTest(Output, 0x4EA4CE02, (cpu, maddr) => {
			});
			// fmls V20.4S, V18.4S, V5.S[0]
			InsnTester.AutoTest(Output, 0x4F855254, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fabs() {
			// fabs S2, S0
			InsnTester.AutoTest(Output, 0x1E20C002, (cpu, maddr) => {
			});
			// fabs V25.4S, V29.4S
			InsnTester.AutoTest(Output, 0x4EA0FBB9, (cpu, maddr) => {
			});
			// fabs S0, S1
			InsnTester.AutoTest(Output, 0x1E20C020, (cpu, maddr) => {
			});
			// fabs S3, S3
			InsnTester.AutoTest(Output, 0x1E20C063, (cpu, maddr) => {
			});
			// fabs S1, S9
			InsnTester.AutoTest(Output, 0x1E20C121, (cpu, maddr) => {
			});
			// fabs S0, S6
			InsnTester.AutoTest(Output, 0x1E20C0C0, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldaxrh() {
			// ldaxrh W8, [X0]
			InsnTester.AutoTest(Output, 0x485FFC08, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxrh W10, [X20]
			InsnTester.AutoTest(Output, 0x485FFE8A, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
			// ldaxrh W9, [X0]
			InsnTester.AutoTest(Output, 0x485FFC09, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxrh W10, [X0]
			InsnTester.AutoTest(Output, 0x485FFC0A, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldaxrh W9, [X20]
			InsnTester.AutoTest(Output, 0x485FFE89, (cpu, maddr) => {
				cpu.State->X20 = maddr;
			});
		}

		[Fact]
		public void Csel() {
			// csel W0, W2, W0, LO
			InsnTester.AutoTest(Output, 0x1A803040, (cpu, maddr) => {
			});
			// csel W16, W16, W18, HI
			InsnTester.AutoTest(Output, 0x1A928210, (cpu, maddr) => {
			});
			// csel X1, X25, X23, EQ
			InsnTester.AutoTest(Output, 0x9A970321, (cpu, maddr) => {
			});
			// csel W30, WZR, W17, LT
			InsnTester.AutoTest(Output, 0x1A91B3FE, (cpu, maddr) => {
			});
			// csel X9, X8, X10, NE
			InsnTester.AutoTest(Output, 0x9A8A1109, (cpu, maddr) => {
			});
			// csel W4, W25, W4, LO
			InsnTester.AutoTest(Output, 0x1A843324, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cinc() {
			// cinc W8, W0, EQ
			InsnTester.AutoTest(Output, 0x1A801408, (cpu, maddr) => {
			});
			// cinc W12, W10, LT
			InsnTester.AutoTest(Output, 0x1A8AA54C, (cpu, maddr) => {
			});
			// cinc W19, W19, NE
			InsnTester.AutoTest(Output, 0x1A930673, (cpu, maddr) => {
			});
			// cinc W8, W17, LT
			InsnTester.AutoTest(Output, 0x1A91A628, (cpu, maddr) => {
			});
			// cinc W5, W23, NE
			InsnTester.AutoTest(Output, 0x1A9706E5, (cpu, maddr) => {
			});
			// cinc X7, X2, LT
			InsnTester.AutoTest(Output, 0x9A82A447, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cset() {
			// cset W0, MI
			InsnTester.AutoTest(Output, 0x1A9F57E0, (cpu, maddr) => {
			});
			// cset W28, GT
			InsnTester.AutoTest(Output, 0x1A9FD7FC, (cpu, maddr) => {
			});
			// cset W18, GE
			InsnTester.AutoTest(Output, 0x1A9FB7F2, (cpu, maddr) => {
			});
			// cset W13, LO
			InsnTester.AutoTest(Output, 0x1A9F27ED, (cpu, maddr) => {
			});
			// cset W4, HI
			InsnTester.AutoTest(Output, 0x1A9F97E4, (cpu, maddr) => {
			});
			// cset W26, LT
			InsnTester.AutoTest(Output, 0x1A9FA7FA, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmla() {
			// fmla V3.4S, V1.4S, V0.4S
			InsnTester.AutoTest(Output, 0x4E20CC23, (cpu, maddr) => {
			});
			// fmla V22.4S, V20.4S, V16.S[2]
			InsnTester.AutoTest(Output, 0x4F901A96, (cpu, maddr) => {
			});
			// fmla V1.4S, V6.4S, V0.S[2]
			InsnTester.AutoTest(Output, 0x4F8018C1, (cpu, maddr) => {
			});
			// fmla V16.4S, V17.4S, V3.S[2]
			InsnTester.AutoTest(Output, 0x4F831A30, (cpu, maddr) => {
			});
			// fmla V18.4S, V3.4S, V16.S[2]
			InsnTester.AutoTest(Output, 0x4F901872, (cpu, maddr) => {
			});
			// fmla V31.4S, V2.4S, V3.S[2]
			InsnTester.AutoTest(Output, 0x4F83185F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Frecps() {
			// frecps V1.4S, V2.4S, V1.4S
			InsnTester.AutoTest(Output, 0x4E21FC41, (cpu, maddr) => {
			});
			// frecps V30.4S, V31.4S, V30.4S
			InsnTester.AutoTest(Output, 0x4E3EFFFE, (cpu, maddr) => {
			});
			// frecps V25.4S, V21.4S, V18.4S
			InsnTester.AutoTest(Output, 0x4E32FEB9, (cpu, maddr) => {
			});
			// frecps V18.4S, V17.4S, V6.4S
			InsnTester.AutoTest(Output, 0x4E26FE32, (cpu, maddr) => {
			});
			// frecps V26.4S, V23.4S, V3.4S
			InsnTester.AutoTest(Output, 0x4E23FEFA, (cpu, maddr) => {
			});
			// frecps V12.4S, V11.4S, V30.4S
			InsnTester.AutoTest(Output, 0x4E3EFD6C, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Cinv() {
			// cinv W0, W8, NE
			InsnTester.AutoTest(Output, 0x5A880100, (cpu, maddr) => {
			});
			// cinv W10, W10, LT
			InsnTester.AutoTest(Output, 0x5A8AA14A, (cpu, maddr) => {
			});
			// cinv X0, X8, GE
			InsnTester.AutoTest(Output, 0xDA88B100, (cpu, maddr) => {
			});
			// cinv W22, W8, LE
			InsnTester.AutoTest(Output, 0x5A88C116, (cpu, maddr) => {
			});
			// cinv W8, W8, GE
			InsnTester.AutoTest(Output, 0x5A88B108, (cpu, maddr) => {
			});
			// cinv W11, W11, LT
			InsnTester.AutoTest(Output, 0x5A8BA16B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Mneg() {
			// mneg X8, X0, X8
			InsnTester.AutoTest(Output, 0x9B08FC08, (cpu, maddr) => {
			});
			// mneg X15, X15, X12
			InsnTester.AutoTest(Output, 0x9B0CFDEF, (cpu, maddr) => {
			});
			// mneg X0, X0, X18
			InsnTester.AutoTest(Output, 0x9B12FC00, (cpu, maddr) => {
			});
			// mneg X15, X11, X13
			InsnTester.AutoTest(Output, 0x9B0DFD6F, (cpu, maddr) => {
			});
			// mneg X0, X0, X17
			InsnTester.AutoTest(Output, 0x9B11FC00, (cpu, maddr) => {
			});
			// mneg X14, X10, X12
			InsnTester.AutoTest(Output, 0x9B0CFD4E, (cpu, maddr) => {
			});
		}

		[Fact]
		public void LdrswPostIndex() {
			// ldrsw X7, [X2], #4
			InsnTester.AutoTest(Output, 0xB8804447, (cpu, maddr) => {
				cpu.State->X2 = maddr;
			});
			// ldrsw X15, [X16], #0xFFFFFFFFFFFFFFFC
			InsnTester.AutoTest(Output, 0xB89FC60F, (cpu, maddr) => {
				cpu.State->X16 = maddr;
			});
			// ldrsw X19, [X18], #4
			InsnTester.AutoTest(Output, 0xB8804653, (cpu, maddr) => {
				cpu.State->X18 = maddr;
			});
			// ldrsw X23, [X26], #4
			InsnTester.AutoTest(Output, 0xB8804757, (cpu, maddr) => {
				cpu.State->X26 = maddr;
			});
			// ldrsw X14, [X10], #4
			InsnTester.AutoTest(Output, 0xB880454E, (cpu, maddr) => {
				cpu.State->X10 = maddr;
			});
			// ldrsw X8, [X23], #0x84
			InsnTester.AutoTest(Output, 0xB88846E8, (cpu, maddr) => {
				cpu.State->X23 = maddr;
			});
		}

		[Fact]
		public void Pmull2() {
			// pmull2 V0.1Q, V0.2D, V1.2D
			InsnTester.AutoTest(Output, 0x4EE1E000, (cpu, maddr) => {
			});
			// pmull2 V26.1Q, V18.2D, V8.2D
			InsnTester.AutoTest(Output, 0x4EE8E25A, (cpu, maddr) => {
			});
			// pmull2 V16.1Q, V16.2D, V3.2D
			InsnTester.AutoTest(Output, 0x4EE3E210, (cpu, maddr) => {
			});
			// pmull2 V19.1Q, V19.2D, V1.2D
			InsnTester.AutoTest(Output, 0x4EE1E273, (cpu, maddr) => {
			});
			// pmull2 V17.1Q, V17.2D, V2.2D
			InsnTester.AutoTest(Output, 0x4EE2E231, (cpu, maddr) => {
			});
			// pmull2 V25.1Q, V17.2D, V2.2D
			InsnTester.AutoTest(Output, 0x4EE2E239, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fminnm() {
			// fminnm S1, S1, S0
			InsnTester.AutoTest(Output, 0x1E207821, (cpu, maddr) => {
			});
			// fminnm S24, S23, S24
			InsnTester.AutoTest(Output, 0x1E387AF8, (cpu, maddr) => {
			});
			// fminnm S3, S16, S17
			InsnTester.AutoTest(Output, 0x1E317A03, (cpu, maddr) => {
			});
			// fminnm S1, S8, S1
			InsnTester.AutoTest(Output, 0x1E217901, (cpu, maddr) => {
			});
			// fminnm S1, S0, S10
			InsnTester.AutoTest(Output, 0x1E2A7801, (cpu, maddr) => {
			});
			// fminnm S9, S0, S2
			InsnTester.AutoTest(Output, 0x1E227809, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sxtw() {
			// sxtw X1, W1
			InsnTester.AutoTest(Output, 0x93407C21, (cpu, maddr) => {
			});
			// sxtw X24, W29
			InsnTester.AutoTest(Output, 0x93407FB8, (cpu, maddr) => {
			});
			// sxtw X14, W4
			InsnTester.AutoTest(Output, 0x93407C8E, (cpu, maddr) => {
			});
			// sxtw X26, W25
			InsnTester.AutoTest(Output, 0x93407F3A, (cpu, maddr) => {
			});
			// sxtw X1, W27
			InsnTester.AutoTest(Output, 0x93407F61, (cpu, maddr) => {
			});
			// sxtw X22, W8
			InsnTester.AutoTest(Output, 0x93407D16, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmgt() {
			// fcmgt V1.4S, V3.4S, V1.4S
			InsnTester.AutoTest(Output, 0x6EA1E461, (cpu, maddr) => {
			});
			// fcmgt V30.4S, V17.4S, V28.4S
			InsnTester.AutoTest(Output, 0x6EBCE63E, (cpu, maddr) => {
			});
			// fcmgt V26.4S, V8.4S, V5.4S
			InsnTester.AutoTest(Output, 0x6EA5E51A, (cpu, maddr) => {
			});
			// fcmgt V3.4S, V23.4S, V8.4S
			InsnTester.AutoTest(Output, 0x6EA8E6E3, (cpu, maddr) => {
			});
			// fcmgt V2.4S, V3.4S, V2.4S
			InsnTester.AutoTest(Output, 0x6EA2E462, (cpu, maddr) => {
			});
			// fcmgt V7.4S, V3.4S, V24.4S
			InsnTester.AutoTest(Output, 0x6EB8E467, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Addv() {
			// addv B1, V0.8B
			InsnTester.AutoTest(Output, 0x0E31B801, (cpu, maddr) => {
			});
			// addv S17, V17.4S
			InsnTester.AutoTest(Output, 0x4EB1BA31, (cpu, maddr) => {
			});
			// addv S7, V7.4S
			InsnTester.AutoTest(Output, 0x4EB1B8E7, (cpu, maddr) => {
			});
			// addv S1, V1.4S
			InsnTester.AutoTest(Output, 0x4EB1B821, (cpu, maddr) => {
			});
			// addv S6, V6.4S
			InsnTester.AutoTest(Output, 0x4EB1B8C6, (cpu, maddr) => {
			});
			// addv S3, V3.4S
			InsnTester.AutoTest(Output, 0x4EB1B863, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bic() {
			// bic W8, W1, W8
			InsnTester.AutoTest(Output, 0x0A280028, (cpu, maddr) => {
			});
			// bic V30.16B, V30.16B, V27.16B
			InsnTester.AutoTest(Output, 0x4E7B1FDE, (cpu, maddr) => {
			});
			// bic W2, W6, W2
			InsnTester.AutoTest(Output, 0x0A2200C2, (cpu, maddr) => {
			});
			// bic V2.16B, V2.16B, V0.16B
			InsnTester.AutoTest(Output, 0x4E601C42, (cpu, maddr) => {
			});
			// bic W2, W13, W2, ASR #31
			InsnTester.AutoTest(Output, 0x0AA27DA2, (cpu, maddr) => {
			});
			// bic W7, W12, W7, ASR #31
			InsnTester.AutoTest(Output, 0x0AA77D87, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Bsl() {
			// bsl V5.8B, V3.8B, V0.8B
			InsnTester.AutoTest(Output, 0x2E601C65, (cpu, maddr) => {
			});
			// bsl V27.16B, V30.16B, V31.16B
			InsnTester.AutoTest(Output, 0x6E7F1FDB, (cpu, maddr) => {
			});
			// bsl V5.16B, V6.16B, V7.16B
			InsnTester.AutoTest(Output, 0x6E671CC5, (cpu, maddr) => {
			});
			// bsl V25.16B, V30.16B, V27.16B
			InsnTester.AutoTest(Output, 0x6E7B1FD9, (cpu, maddr) => {
			});
			// bsl V26.16B, V31.16B, V30.16B
			InsnTester.AutoTest(Output, 0x6E7E1FFA, (cpu, maddr) => {
			});
			// bsl V6.16B, V7.16B, V17.16B
			InsnTester.AutoTest(Output, 0x6E711CE6, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcmge() {
			// fcmge V4.4S, V3.4S, #0.0
			InsnTester.AutoTest(Output, 0x6EA0C864, (cpu, maddr) => {
			});
			// fcmge V24.4S, V24.4S, V28.4S
			InsnTester.AutoTest(Output, 0x6E3CE718, (cpu, maddr) => {
			});
			// fcmge V6.4S, V4.4S, #0.0
			InsnTester.AutoTest(Output, 0x6EA0C886, (cpu, maddr) => {
			});
			// fcmge V27.4S, V25.4S, V8.4S
			InsnTester.AutoTest(Output, 0x6E28E73B, (cpu, maddr) => {
			});
			// fcmge V29.4S, V27.4S, #0.0
			InsnTester.AutoTest(Output, 0x6EA0CB7D, (cpu, maddr) => {
			});
			// fcmge V2.4S, V3.4S, V2.4S
			InsnTester.AutoTest(Output, 0x6E22E462, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Msub() {
			// msub W0, W2, W0, W1
			InsnTester.AutoTest(Output, 0x1B008440, (cpu, maddr) => {
			});
			// msub W15, W18, W15, W19
			InsnTester.AutoTest(Output, 0x1B0FCE4F, (cpu, maddr) => {
			});
			// msub W9, W12, W8, W9
			InsnTester.AutoTest(Output, 0x1B08A589, (cpu, maddr) => {
			});
			// msub W9, W9, W26, W8
			InsnTester.AutoTest(Output, 0x1B1AA129, (cpu, maddr) => {
			});
			// msub W10, W14, W10, W13
			InsnTester.AutoTest(Output, 0x1B0AB5CA, (cpu, maddr) => {
			});
			// msub W14, W14, W13, W9
			InsnTester.AutoTest(Output, 0x1B0DA5CE, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umaddl() {
			// umaddl X8, W3, W1, X8
			InsnTester.AutoTest(Output, 0x9BA12068, (cpu, maddr) => {
			});
			// umaddl X22, W10, W21, X24
			InsnTester.AutoTest(Output, 0x9BB56156, (cpu, maddr) => {
			});
			// umaddl X22, W22, W7, X19
			InsnTester.AutoTest(Output, 0x9BA74ED6, (cpu, maddr) => {
			});
			// umaddl X17, W17, W20, X9
			InsnTester.AutoTest(Output, 0x9BB42631, (cpu, maddr) => {
			});
			// umaddl X9, W26, W28, X19
			InsnTester.AutoTest(Output, 0x9BBC4F49, (cpu, maddr) => {
			});
			// umaddl X9, W19, W9, X20
			InsnTester.AutoTest(Output, 0x9BA95269, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldrsh() {
			// ldrsh W0, [X0]
			InsnTester.AutoTest(Output, 0x79C00000, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrsh W15, [X20, W15, SXTW #1]
			InsnTester.AutoTest(Output, 0x78EFDA8F, (cpu, maddr) => {
				cpu.State->X20 = maddr;
				cpu.State->X15 = 0x10;
			});
			// ldrsh W8, [X8, #6]
			InsnTester.AutoTest(Output, 0x79C00D08, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrsh W9, [X17, #0x80]
			InsnTester.AutoTest(Output, 0x79C10229, (cpu, maddr) => {
				cpu.State->X17 = maddr;
			});
			// ldrsh X14, [X21, X13]
			InsnTester.AutoTest(Output, 0x78AD6AAE, (cpu, maddr) => {
				cpu.State->X21 = maddr;
				cpu.State->X13 = 0x10;
			});
			// ldrsh W0, [X8, #4]
			InsnTester.AutoTest(Output, 0x79C00900, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
		}

		[Fact]
		public void Sbfiz() {
			// sbfiz X8, X8, #1, #8
			InsnTester.AutoTest(Output, 0x937F1D08, (cpu, maddr) => {
			});
			// sbfiz X13, X13, #0x20, #0x20
			InsnTester.AutoTest(Output, 0x93607DAD, (cpu, maddr) => {
			});
			// sbfiz X2, X21, #2, #0x20
			InsnTester.AutoTest(Output, 0x937E7EA2, (cpu, maddr) => {
			});
			// sbfiz X12, X8, #3, #0x20
			InsnTester.AutoTest(Output, 0x937D7D0C, (cpu, maddr) => {
			});
			// sbfiz X14, X6, #2, #0x20
			InsnTester.AutoTest(Output, 0x937E7CCE, (cpu, maddr) => {
			});
			// sbfiz X7, X7, #2, #0x20
			InsnTester.AutoTest(Output, 0x937E7CE7, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Umull() {
			// umull X4, W8, W9
			InsnTester.AutoTest(Output, 0x9BA97D04, (cpu, maddr) => {
			});
			// umull X11, W11, W10
			InsnTester.AutoTest(Output, 0x9BAA7D6B, (cpu, maddr) => {
			});
			// umull X22, W23, W13
			InsnTester.AutoTest(Output, 0x9BAD7EF6, (cpu, maddr) => {
			});
			// umull X1, W21, W8
			InsnTester.AutoTest(Output, 0x9BA87EA1, (cpu, maddr) => {
			});
			// umull X23, W23, W13
			InsnTester.AutoTest(Output, 0x9BAD7EF7, (cpu, maddr) => {
			});
			// umull X15, W12, W13
			InsnTester.AutoTest(Output, 0x9BAD7D8F, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Sdiv() {
			// sdiv W8, W2, W1
			InsnTester.AutoTest(Output, 0x1AC10C48, (cpu, maddr) => {
			});
			// sdiv W12, W13, W12
			InsnTester.AutoTest(Output, 0x1ACC0DAC, (cpu, maddr) => {
			});
			// sdiv W0, W8, W9
			InsnTester.AutoTest(Output, 0x1AC90D00, (cpu, maddr) => {
			});
			// sdiv W9, W10, W24
			InsnTester.AutoTest(Output, 0x1AD80D49, (cpu, maddr) => {
			});
			// sdiv W12, W10, W8
			InsnTester.AutoTest(Output, 0x1AC80D4C, (cpu, maddr) => {
			});
			// sdiv X10, X11, X10
			InsnTester.AutoTest(Output, 0x9ACA0D6A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtzu() {
			// fcvtzu W3, S0
			InsnTester.AutoTest(Output, 0x1E390003, (cpu, maddr) => {
			});
			// fcvtzu W16, S0, #0x10
			InsnTester.AutoTest(Output, 0x1E19C010, (cpu, maddr) => {
			});
			// fcvtzu X0, D0
			InsnTester.AutoTest(Output, 0x9E790000, (cpu, maddr) => {
			});
			// fcvtzu X9, D0, #0xE
			InsnTester.AutoTest(Output, 0x9E59C809, (cpu, maddr) => {
			});
			// fcvtzu W11, S8
			InsnTester.AutoTest(Output, 0x1E39010B, (cpu, maddr) => {
			});
			// fcvtzu W10, S0
			InsnTester.AutoTest(Output, 0x1E39000A, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Rbit() {
			// rbit X8, X0
			InsnTester.AutoTest(Output, 0xDAC00008, (cpu, maddr) => {
			});
			// rbit X11, X12
			InsnTester.AutoTest(Output, 0xDAC0018B, (cpu, maddr) => {
			});
			// rbit X9, X9
			InsnTester.AutoTest(Output, 0xDAC00129, (cpu, maddr) => {
			});
			// rbit W10, W10
			InsnTester.AutoTest(Output, 0x5AC0014A, (cpu, maddr) => {
			});
			// rbit X11, X11
			InsnTester.AutoTest(Output, 0xDAC0016B, (cpu, maddr) => {
			});
			// rbit W11, W15
			InsnTester.AutoTest(Output, 0x5AC001EB, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtpu() {
			// fcvtpu X0, S0
			InsnTester.AutoTest(Output, 0x9E290000, (cpu, maddr) => {
			});
			// fcvtpu X9, S0
			InsnTester.AutoTest(Output, 0x9E290009, (cpu, maddr) => {
			});
			// fcvtpu W8, S0
			InsnTester.AutoTest(Output, 0x1E290008, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Eor() {
			// eor W8, W1, W0
			InsnTester.AutoTest(Output, 0x4A000028, (cpu, maddr) => {
			});
			// eor X15, X12, #0x7FFF000000000000
			InsnTester.AutoTest(Output, 0xD250398F, (cpu, maddr) => {
			});
			// eor W0, W8, #0x7FFF0000
			InsnTester.AutoTest(Output, 0x52103900, (cpu, maddr) => {
			});
			// eor W18, W18, W6
			InsnTester.AutoTest(Output, 0x4A060252, (cpu, maddr) => {
			});
			// eor W18, W0, W18
			InsnTester.AutoTest(Output, 0x4A120012, (cpu, maddr) => {
			});
			// eor W27, W27, #0x80000000
			InsnTester.AutoTest(Output, 0x5201037B, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ext() {
			// ext V1.8B, V2.8B, V3.8B, #4
			InsnTester.AutoTest(Output, 0x2E032041, (cpu, maddr) => {
			});
			// ext V26.16B, V21.16B, V21.16B, #8
			InsnTester.AutoTest(Output, 0x6E1542BA, (cpu, maddr) => {
			});
			// ext V18.16B, V17.16B, V17.16B, #8
			InsnTester.AutoTest(Output, 0x6E114232, (cpu, maddr) => {
			});
			// ext V27.16B, V25.16B, V25.16B, #8
			InsnTester.AutoTest(Output, 0x6E19433B, (cpu, maddr) => {
			});
			// ext V28.16B, V3.16B, V3.16B, #8
			InsnTester.AutoTest(Output, 0x6E03407C, (cpu, maddr) => {
			});
			// ext V2.16B, V2.16B, V2.16B, #8
			InsnTester.AutoTest(Output, 0x6E024042, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fnmul() {
			// fnmul S2, S2, S0
			InsnTester.AutoTest(Output, 0x1E208842, (cpu, maddr) => {
			});
			// fnmul S20, S23, S21
			InsnTester.AutoTest(Output, 0x1E358AF4, (cpu, maddr) => {
			});
			// fnmul S6, S4, S2
			InsnTester.AutoTest(Output, 0x1E228886, (cpu, maddr) => {
			});
			// fnmul S3, S6, S8
			InsnTester.AutoTest(Output, 0x1E2888C3, (cpu, maddr) => {
			});
			// fnmul S1, S1, S3
			InsnTester.AutoTest(Output, 0x1E238821, (cpu, maddr) => {
			});
			// fnmul S0, S0, S6
			InsnTester.AutoTest(Output, 0x1E268800, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fmaxnm() {
			// fmaxnm S0, S3, S0
			InsnTester.AutoTest(Output, 0x1E206860, (cpu, maddr) => {
			});
			// fmaxnm S18, S18, S20
			InsnTester.AutoTest(Output, 0x1E346A52, (cpu, maddr) => {
			});
			// fmaxnm S8, S8, S0
			InsnTester.AutoTest(Output, 0x1E206908, (cpu, maddr) => {
			});
			// fmaxnm S1, S8, S0
			InsnTester.AutoTest(Output, 0x1E206901, (cpu, maddr) => {
			});
			// fmaxnm S2, S2, S17
			InsnTester.AutoTest(Output, 0x1E316842, (cpu, maddr) => {
			});
			// fmaxnm S2, S9, S2
			InsnTester.AutoTest(Output, 0x1E226922, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Fcvtps() {
			// fcvtps W8, S0
			InsnTester.AutoTest(Output, 0x1E280008, (cpu, maddr) => {
			});
			// fcvtps W15, S17
			InsnTester.AutoTest(Output, 0x1E28022F, (cpu, maddr) => {
			});
			// fcvtps W12, S1
			InsnTester.AutoTest(Output, 0x1E28002C, (cpu, maddr) => {
			});
			// fcvtps W18, S6
			InsnTester.AutoTest(Output, 0x1E2800D2, (cpu, maddr) => {
			});
			// fcvtps W8, S2
			InsnTester.AutoTest(Output, 0x1E280048, (cpu, maddr) => {
			});
			// fcvtps W1, S0
			InsnTester.AutoTest(Output, 0x1E280001, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Smlal() {
			// smlal V2.2D, V0.2S, V5.2S
			InsnTester.AutoTest(Output, 0x0EA58002, (cpu, maddr) => {
			});
			// smlal V2.2D, V3.2S, V6.S[0]
			InsnTester.AutoTest(Output, 0x0F862062, (cpu, maddr) => {
			});
			// smlal V2.2D, V1.2S, V5.2S
			InsnTester.AutoTest(Output, 0x0EA58022, (cpu, maddr) => {
			});
		}

		[Fact]
		public void Ldpsw() {
			// ldpsw X6, X5, [X5]
			InsnTester.AutoTest(Output, 0x694014A6, (cpu, maddr) => {
				cpu.State->X5 = maddr;
			});
			// ldpsw X14, X15, [X11, #-0x10]
			InsnTester.AutoTest(Output, 0x697E3D6E, (cpu, maddr) => {
				cpu.State->X11 = maddr;
			});
			// ldpsw X10, X8, [X19, #8]
			InsnTester.AutoTest(Output, 0x6941226A, (cpu, maddr) => {
				cpu.State->X19 = maddr;
			});
			// ldpsw X18, X14, [X14]
			InsnTester.AutoTest(Output, 0x694039D2, (cpu, maddr) => {
				cpu.State->X14 = maddr;
			});
			// ldpsw X10, X11, [X19, #0xAC]
			InsnTester.AutoTest(Output, 0x6955AE6A, (cpu, maddr) => {
				cpu.State->X19 = maddr;
			});
			// ldpsw X1, X14, [X12, #0x30]
			InsnTester.AutoTest(Output, 0x69463981, (cpu, maddr) => {
				cpu.State->X12 = maddr;
			});
		}

		[Fact]
		public void Ldrsw() {
			// ldrsw X2, [X8]
			InsnTester.AutoTest(Output, 0xB9800102, (cpu, maddr) => {
				cpu.State->X8 = maddr;
			});
			// ldrsw X12, [X21, W28, SXTW #2]
			InsnTester.AutoTest(Output, 0xB8BCDAAC, (cpu, maddr) => {
				cpu.State->X21 = maddr;
				cpu.State->X28 = 0x10;
			});
			// ldrsw X13, [X0, #8]
			InsnTester.AutoTest(Output, 0xB980080D, (cpu, maddr) => {
				cpu.State->X0 = maddr;
			});
			// ldrsw X22, [X22]
			InsnTester.AutoTest(Output, 0xB98002D6, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldrsw X8, [X22, #0x1C]
			InsnTester.AutoTest(Output, 0xB9801EC8, (cpu, maddr) => {
				cpu.State->X22 = maddr;
			});
			// ldrsw X26, [X8, X21, LSL #2]
			InsnTester.AutoTest(Output, 0xB8B5791A, (cpu, maddr) => {
				cpu.State->X8 = maddr;
				cpu.State->X21 = 0x10;
			});
		}

		[Fact]
		public void Tbl() {
			// tbl V4.8B, {V7.16B}, V1.8B
			InsnTester.AutoTest(Output, 0x0E0100E4, (cpu, maddr) => {
			});
			// tbl V26.8B, {V26.16B, V27.16B}, V31.8B
			InsnTester.AutoTest(Output, 0x0E1F235A, (cpu, maddr) => {
			});
			// tbl V28.8B, {V27.16B}, V16.8B
			InsnTester.AutoTest(Output, 0x0E10037C, (cpu, maddr) => {
			});
			// tbl V5.8B, {V23.16B}, V16.8B
			InsnTester.AutoTest(Output, 0x0E1002E5, (cpu, maddr) => {
			});
			// tbl V1.8B, {V5.16B}, V1.8B
			InsnTester.AutoTest(Output, 0x0E0100A1, (cpu, maddr) => {
			});
			// tbl V12.8B, {V8.16B, V9.16B}, V18.8B
			InsnTester.AutoTest(Output, 0x0E12210C, (cpu, maddr) => {
			});
		}
	}
}
