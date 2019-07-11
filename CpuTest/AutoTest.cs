using System;
using System.Runtime.Intrinsics;
using Xunit;

namespace CpuTest {
	public class AutoTest_Movn {
		[Fact]
		public void Movn() {
			// movn X1, #0
			InsnTester.AutoTest(0x92800001, (cpu, maddr) => {
			});
			// movn W10, #0xFFEF, LSL #16
			InsnTester.AutoTest(0x12BFFDEA, (cpu, maddr) => {
			});
			// movn W25, #0x3EB
			InsnTester.AutoTest(0x12807D79, (cpu, maddr) => {
			});
			// movn W21, #0xFFFD, LSL #16
			InsnTester.AutoTest(0x12BFFFB5, (cpu, maddr) => {
			});
			// movn X8, #0xC07F, LSL #16
			InsnTester.AutoTest(0x92B80FE8, (cpu, maddr) => {
			});
			// movn W20, #0x3EC
			InsnTester.AutoTest(0x12807D94, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldurb {
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
			// ldurb W8, [X23, #-8]
			InsnTester.AutoTest(0x385F82E8, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
			// ldurb W18, [X15, #-4]
			InsnTester.AutoTest(0x385FC1F2, (cpu, maddr) => {
				cpu.X[15] = maddr;
			});
			// ldurb W10, [X29, #-0xBC]
			InsnTester.AutoTest(0x385443AA, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldurb W13, [X13, #-2]
			InsnTester.AutoTest(0x385FE1AD, (cpu, maddr) => {
				cpu.X[13] = maddr;
			});
		}
	}

	public class AutoTest_Movk {
		[Fact]
		public void Movk() {
			// movk X6, #0
			InsnTester.AutoTest(0xF2800006, (cpu, maddr) => {
			});
			// movk X27, #0xFFFF, LSL #32
			InsnTester.AutoTest(0xF2DFFFFB, (cpu, maddr) => {
			});
			// movk W10, #0xFE4
			InsnTester.AutoTest(0x7281FC8A, (cpu, maddr) => {
			});
			// movk W10, #0x6040
			InsnTester.AutoTest(0x728C080A, (cpu, maddr) => {
			});
			// movk W4, #0x4345
			InsnTester.AutoTest(0x728868A4, (cpu, maddr) => {
			});
			// movk W9, #0x688C
			InsnTester.AutoTest(0x728D1189, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Movi {
		[Fact]
		public void Movi() {
			// movi V0.4S, #0x1
			InsnTester.AutoTest(0x4F000420, (cpu, maddr) => {
			});
			// movi V1.2D, #0xFFFFFFFFFFFFFFFF
			InsnTester.AutoTest(0x6F07E7E1, (cpu, maddr) => {
			});
			// movi D18, #0000000000000000
			InsnTester.AutoTest(0x2F00E412, (cpu, maddr) => {
			});
			// movi V1.2D, #0000000000000000
			InsnTester.AutoTest(0x6F00E401, (cpu, maddr) => {
			});
			// movi V6.2D, #0000000000000000
			InsnTester.AutoTest(0x6F00E406, (cpu, maddr) => {
			});
			// movi V17.4S, #0xBF, LSL #24
			InsnTester.AutoTest(0x4F0567F1, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Smull {
		[Fact]
		public void Smull() {
			// smull X4, W4, W4
			InsnTester.AutoTest(0x9B247C84, (cpu, maddr) => {
			});
			// smull V2.2D, V2.2S, V0.2S
			InsnTester.AutoTest(0x0EA0C042, (cpu, maddr) => {
			});
			// smull X8, W8, W10
			InsnTester.AutoTest(0x9B2A7D08, (cpu, maddr) => {
			});
			// smull X9, W24, W8
			InsnTester.AutoTest(0x9B287F09, (cpu, maddr) => {
			});
			// smull X9, W24, W22
			InsnTester.AutoTest(0x9B367F09, (cpu, maddr) => {
			});
			// smull X1, W0, W13
			InsnTester.AutoTest(0x9B2D7C01, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Lsl {
		[Fact]
		public void Lsl() {
			// lsl X9, X9, X0
			InsnTester.AutoTest(0x9AC02129, (cpu, maddr) => {
			});
			// lsl W30, W27, #0x10
			InsnTester.AutoTest(0x53103F7E, (cpu, maddr) => {
			});
			// lsl W4, W4, W6
			InsnTester.AutoTest(0x1AC62084, (cpu, maddr) => {
			});
			// lsl X27, X8, #0xB
			InsnTester.AutoTest(0xD375D11B, (cpu, maddr) => {
			});
			// lsl X28, X26, #3
			InsnTester.AutoTest(0xD37DF35C, (cpu, maddr) => {
			});
			// lsl W11, W13, W11
			InsnTester.AutoTest(0x1ACB21AB, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Frintp {
		[Fact]
		public void Frintp() {
			// frintp D0, D0
			InsnTester.AutoTest(0x1E64C000, (cpu, maddr) => {
			});
			// frintp S2, S2
			InsnTester.AutoTest(0x1E24C042, (cpu, maddr) => {
			});
			// frintp S2, S1
			InsnTester.AutoTest(0x1E24C022, (cpu, maddr) => {
			});
			// frintp S0, S0
			InsnTester.AutoTest(0x1E24C000, (cpu, maddr) => {
			});
			// frintp S3, S1
			InsnTester.AutoTest(0x1E24C023, (cpu, maddr) => {
			});
			// frintp S1, S1
			InsnTester.AutoTest(0x1E24C021, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldaxrb {
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
	}

	public class AutoTest_Ldr {
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
			// ldr W11, [X21, #0x10]
			InsnTester.AutoTest(0xB94012AB, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldr W9, [X21, #0xCB4]
			InsnTester.AutoTest(0xB94CB6A9, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldr W16, [X17, #0x100]
			InsnTester.AutoTest(0xB9410230, (cpu, maddr) => {
				cpu.X[17] = maddr;
			});
			// ldr X8, [X27, #0x48]
			InsnTester.AutoTest(0xF9402768, (cpu, maddr) => {
				cpu.X[27] = maddr;
			});
		}
	}

	public class AutoTest_Ldp {
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
			// ldp S5, S6, [X1, #8]
			InsnTester.AutoTest(0x2D411825, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldp W13, W20, [X0, #0xA8]
			InsnTester.AutoTest(0x2955500D, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldp X23, X9, [X19]
			InsnTester.AutoTest(0xA9402677, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldp S1, S3, [X20, #0x28]
			InsnTester.AutoTest(0x2D450E81, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
		}
	}

	public class AutoTest_Movz {
		[Fact]
		public void Movz() {
			// movz X4, #0
			InsnTester.AutoTest(0xD2800004, (cpu, maddr) => {
			});
			// movz W10, #0x5555, LSL #16
			InsnTester.AutoTest(0x52AAAAAA, (cpu, maddr) => {
			});
			// movz W8, #0x490
			InsnTester.AutoTest(0x52809208, (cpu, maddr) => {
			});
			// movz W10, #0xBB80
			InsnTester.AutoTest(0x5297700A, (cpu, maddr) => {
			});
			// movz W12, #0x3E2D
			InsnTester.AutoTest(0x5287C5AC, (cpu, maddr) => {
			});
			// movz W8, #0xEEF4
			InsnTester.AutoTest(0x529DDE88, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Umov {
		[Fact]
		public void Umov() {
			// umov W9, V0.H[0]
			InsnTester.AutoTest(0x0E023C09, (cpu, maddr) => {
			});
			// umov W16, V16.H[0]
			InsnTester.AutoTest(0x0E023E10, (cpu, maddr) => {
			});
			// umov W8, V5.H[0]
			InsnTester.AutoTest(0x0E023CA8, (cpu, maddr) => {
			});
			// umov W9, V1.H[0]
			InsnTester.AutoTest(0x0E023C29, (cpu, maddr) => {
			});
			// umov W8, V3.H[0]
			InsnTester.AutoTest(0x0E023C68, (cpu, maddr) => {
			});
			// umov W9, V3.H[0]
			InsnTester.AutoTest(0x0E023C69, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sqadd {
		[Fact]
		public void Sqadd() {
			// sqadd V1.2S, V3.2S, V1.2S
			InsnTester.AutoTest(0x0EA10C61, (cpu, maddr) => {
			});
			// sqadd V2.2S, V2.2S, V0.2S
			InsnTester.AutoTest(0x0EA00C42, (cpu, maddr) => {
			});
			// sqadd V0.2S, V1.2S, V0.2S
			InsnTester.AutoTest(0x0EA00C20, (cpu, maddr) => {
			});
			// sqadd V1.2S, V1.2S, V0.2S
			InsnTester.AutoTest(0x0EA00C21, (cpu, maddr) => {
			});
			// sqadd V2.2S, V3.2S, V2.2S
			InsnTester.AutoTest(0x0EA20C62, (cpu, maddr) => {
			});
			// sqadd V1.2S, V2.2S, V1.2S
			InsnTester.AutoTest(0x0EA10C41, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcvtas {
		[Fact]
		public void Fcvtas() {
			// fcvtas X0, S0
			InsnTester.AutoTest(0x9E240000, (cpu, maddr) => {
			});
			// fcvtas X0, D0
			InsnTester.AutoTest(0x9E640000, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sshll {
		[Fact]
		public void Sshll() {
			// sshll V4.2D, V4.2S, #0
			InsnTester.AutoTest(0x0F20A484, (cpu, maddr) => {
			});
			// sshll V2.4S, V2.4H, #0
			InsnTester.AutoTest(0x0F10A442, (cpu, maddr) => {
			});
			// sshll V6.4S, V6.4H, #0
			InsnTester.AutoTest(0x0F10A4C6, (cpu, maddr) => {
			});
			// sshll V0.2D, V0.2S, #0
			InsnTester.AutoTest(0x0F20A400, (cpu, maddr) => {
			});
			// sshll V2.2D, V2.2S, #0
			InsnTester.AutoTest(0x0F20A442, (cpu, maddr) => {
			});
			// sshll V1.2D, V1.2S, #0
			InsnTester.AutoTest(0x0F20A421, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldaxr {
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
			// ldaxr X10, [X9]
			InsnTester.AutoTest(0xC85FFD2A, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldaxr W8, [X2]
			InsnTester.AutoTest(0x885FFC48, (cpu, maddr) => {
				cpu.X[2] = maddr;
			});
			// ldaxr X0, [X9]
			InsnTester.AutoTest(0xC85FFD20, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldaxr W9, [X8]
			InsnTester.AutoTest(0x885FFD09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}
	}

	public class AutoTest_Bfi {
		[Fact]
		public void Bfi() {
			// bfi W1, W9, #5, #1
			InsnTester.AutoTest(0x331B0121, (cpu, maddr) => {
			});
			// bfi W26, W26, #0x10, #0x10
			InsnTester.AutoTest(0x33103F5A, (cpu, maddr) => {
			});
			// bfi X7, X11, #0x20, #0xE
			InsnTester.AutoTest(0xB3603567, (cpu, maddr) => {
			});
			// bfi W11, W12, #1, #0x1F
			InsnTester.AutoTest(0x331F798B, (cpu, maddr) => {
			});
			// bfi W1, W11, #0x18, #8
			InsnTester.AutoTest(0x33081D61, (cpu, maddr) => {
			});
			// bfi X6, X7, #1, #1
			InsnTester.AutoTest(0xB37F00E6, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sqrshrn {
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
	}

	public class AutoTest_Add {
		[Fact]
		public void Add() {
			// add W6, W5, W0
			InsnTester.AutoTest(0x0B0000A6, (cpu, maddr) => {
			});
			// add W13, W21, #0x770, LSL #12
			InsnTester.AutoTest(0x115DC2AD, (cpu, maddr) => {
			});
			// add X4, X4, #0xF7E
			InsnTester.AutoTest(0x913DF884, (cpu, maddr) => {
			});
			// add X14, X23, X24, LSL #1
			InsnTester.AutoTest(0x8B1806EE, (cpu, maddr) => {
			});
			// add X25, X8, #0x2C
			InsnTester.AutoTest(0x9100B119, (cpu, maddr) => {
			});
			// add X25, X8, #0x4D8
			InsnTester.AutoTest(0x91136119, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ucvtf {
		[Fact]
		public void Ucvtf() {
			// ucvtf S4, S1
			InsnTester.AutoTest(0x7E21D824, (cpu, maddr) => {
			});
			// ucvtf S10, W27
			InsnTester.AutoTest(0x1E23036A, (cpu, maddr) => {
			});
			// ucvtf S1, X8
			InsnTester.AutoTest(0x9E230101, (cpu, maddr) => {
			});
			// ucvtf S2, X21
			InsnTester.AutoTest(0x9E2302A2, (cpu, maddr) => {
			});
			// ucvtf S1, W3
			InsnTester.AutoTest(0x1E230061, (cpu, maddr) => {
			});
			// ucvtf S4, X13
			InsnTester.AutoTest(0x9E2301A4, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Clz {
		[Fact]
		public void Clz() {
			// clz W9, W6
			InsnTester.AutoTest(0x5AC010C9, (cpu, maddr) => {
			});
			// clz W10, W25
			InsnTester.AutoTest(0x5AC0132A, (cpu, maddr) => {
			});
			// clz W11, W10
			InsnTester.AutoTest(0x5AC0114B, (cpu, maddr) => {
			});
			// clz X11, X10
			InsnTester.AutoTest(0xDAC0114B, (cpu, maddr) => {
			});
			// clz X17, X17
			InsnTester.AutoTest(0xDAC01231, (cpu, maddr) => {
			});
			// clz W9, W20
			InsnTester.AutoTest(0x5AC01289, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fadd {
		[Fact]
		public void Fadd() {
			// fadd S2, S0, S0
			InsnTester.AutoTest(0x1E202802, (cpu, maddr) => {
			});
			// fadd V30.4S, V31.4S, V31.4S
			InsnTester.AutoTest(0x4E3FD7FE, (cpu, maddr) => {
			});
			// fadd D1, D3, D10
			InsnTester.AutoTest(0x1E6A2861, (cpu, maddr) => {
			});
			// fadd S4, S16, S22
			InsnTester.AutoTest(0x1E362A04, (cpu, maddr) => {
			});
			// fadd D1, D0, D9
			InsnTester.AutoTest(0x1E692801, (cpu, maddr) => {
			});
			// fadd S2, S0, S8
			InsnTester.AutoTest(0x1E282802, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sbfx {
		[Fact]
		public void Sbfx() {
			// sbfx W0, W8, #4, #1
			InsnTester.AutoTest(0x13041100, (cpu, maddr) => {
			});
			// sbfx X11, X11, #0x1E, #0x20
			InsnTester.AutoTest(0x935EF56B, (cpu, maddr) => {
			});
			// sbfx X5, X1, #1, #0x1F
			InsnTester.AutoTest(0x93417C25, (cpu, maddr) => {
			});
			// sbfx X8, X28, #2, #0x1E
			InsnTester.AutoTest(0x93427F88, (cpu, maddr) => {
			});
			// sbfx X13, X10, #6, #0x1A
			InsnTester.AutoTest(0x93467D4D, (cpu, maddr) => {
			});
			// sbfx X10, X21, #0xC, #0x14
			InsnTester.AutoTest(0x934C7EAA, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Tst {
		[Fact]
		public void Tst() {
			// tst W5, W7
			InsnTester.AutoTest(0x6A0700BF, (cpu, maddr) => {
			});
			// tst X10, #0x7FFFFFFFFFFFFFFF
			InsnTester.AutoTest(0xF240F95F, (cpu, maddr) => {
			});
			// tst W11, W8, LSR #5
			InsnTester.AutoTest(0x6A48157F, (cpu, maddr) => {
			});
			// tst W24, W21
			InsnTester.AutoTest(0x6A15031F, (cpu, maddr) => {
			});
			// tst W22, W10
			InsnTester.AutoTest(0x6A0A02DF, (cpu, maddr) => {
			});
			// tst W9, #0xF
			InsnTester.AutoTest(0x72000D3F, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Frintm {
		[Fact]
		public void Frintm() {
			// frintm S2, S0
			InsnTester.AutoTest(0x1E254002, (cpu, maddr) => {
			});
			// frintm S20, S19
			InsnTester.AutoTest(0x1E254274, (cpu, maddr) => {
			});
			// frintm S2, S1
			InsnTester.AutoTest(0x1E254022, (cpu, maddr) => {
			});
			// frintm S0, S0
			InsnTester.AutoTest(0x1E254000, (cpu, maddr) => {
			});
			// frintm D1, D0
			InsnTester.AutoTest(0x1E654001, (cpu, maddr) => {
			});
			// frintm S4, S3
			InsnTester.AutoTest(0x1E254064, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldurh {
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
			// ldurh W12, [X9, #-0x28]
			InsnTester.AutoTest(0x785D812C, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldurh W15, [X14, #-0x38]
			InsnTester.AutoTest(0x785C81CF, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
			// ldurh W8, [X28, #-0xA]
			InsnTester.AutoTest(0x785F6388, (cpu, maddr) => {
				cpu.X[28] = maddr;
			});
			// ldurh W11, [X10, #-2]
			InsnTester.AutoTest(0x785FE14B, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
		}
	}

	public class AutoTest_LdrhPreIndex {
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
			// ldrh W8, [X24, #2]!
			InsnTester.AutoTest(0x78402F08, (cpu, maddr) => {
				cpu.X[24] = maddr;
			});
			// ldrh W9, [X8, #0x20]!
			InsnTester.AutoTest(0x78420D09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrh W10, [X8, #-8]!
			InsnTester.AutoTest(0x785F8D0A, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrh W13, [X11, #0x40]!
			InsnTester.AutoTest(0x78440D6D, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
		}
	}

	public class AutoTest_Ldursb {
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
			// ldursb W8, [X29, #-0x40]
			InsnTester.AutoTest(0x38DC03A8, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldursb W1, [X29, #-0x1B]
			InsnTester.AutoTest(0x38DE53A1, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldursb W5, [X23, #-6]
			InsnTester.AutoTest(0x38DFA2E5, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
			// ldursb W1, [X29, #-0x1A]
			InsnTester.AutoTest(0x38DE63A1, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
		}
	}

	public class AutoTest_Adrp {
		[Fact]
		public void Adrp() {
			// adrp X2, #0xDEAD3000
			InsnTester.AutoTest(0xF0000002, (cpu, maddr) => {
			});
			// adrp X21, #0xDEACF000
			InsnTester.AutoTest(0xF0FFFFF5, (cpu, maddr) => {
			});
			// adrp X13, #0xDF04B000
			InsnTester.AutoTest(0xF0002BCD, (cpu, maddr) => {
			});
			// adrp X9, #0xDEDE1000
			InsnTester.AutoTest(0xB0001889, (cpu, maddr) => {
			});
			// adrp X8, #0xDEEDD000
			InsnTester.AutoTest(0xB0002068, (cpu, maddr) => {
			});
			// adrp X12, #0xDF061000
			InsnTester.AutoTest(0xB0002C8C, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sha1Su0 {
		[Fact]
		public void Sha1Su0() {
			// sha1su0 V5.4S, V6.4S, V7.4S
			InsnTester.AutoTest(0x5E0730C5, (cpu, maddr) => {
			});
			// sha1su0 V6.4S, V7.4S, V16.4S
			InsnTester.AutoTest(0x5E1030E6, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcmeq {
		[Fact]
		public void Fcmeq() {
			// fcmeq V0.4S, V2.4S, #0.0
			InsnTester.AutoTest(0x4EA0D840, (cpu, maddr) => {
			});
			// fcmeq V23.4S, V25.4S, #0.0
			InsnTester.AutoTest(0x4EA0DB37, (cpu, maddr) => {
			});
			// fcmeq V1.4S, V1.4S, #0.0
			InsnTester.AutoTest(0x4EA0D821, (cpu, maddr) => {
			});
			// fcmeq V4.4S, V0.4S, #0.0
			InsnTester.AutoTest(0x4EA0D804, (cpu, maddr) => {
			});
			// fcmeq V3.4S, V0.4S, #0.0
			InsnTester.AutoTest(0x4EA0D803, (cpu, maddr) => {
			});
			// fcmeq V26.4S, V26.4S, #0.0
			InsnTester.AutoTest(0x4EA0DB5A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Mov {
		[Fact]
		public void Mov() {
			// mov X3, SP
			InsnTester.AutoTest(0x910003E3, (cpu, maddr) => {
			});
			// mov V24.16B, V31.16B
			InsnTester.AutoTest(0x4EBF1FF8, (cpu, maddr) => {
			});
			// mov X27, XZR
			InsnTester.AutoTest(0xAA1F03FB, (cpu, maddr) => {
			});
			// mov V27.16B, V20.16B
			InsnTester.AutoTest(0x4EB41E9B, (cpu, maddr) => {
			});
			// mov X19, X7
			InsnTester.AutoTest(0xAA0703F3, (cpu, maddr) => {
			});
			// mov V20.16B, V18.16B
			InsnTester.AutoTest(0x4EB21E54, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ld2 {
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
	}

	public class AutoTest_Ld1 {
		[Fact]
		public void Ld1() {
			// ld1 {V5.S}[0], [X0]
			InsnTester.AutoTest(0x0D408005, (cpu, maddr) => {
			});
			// ld1 {V1.S}[3], [X27], X25
			InsnTester.AutoTest(0x4DD99361, (cpu, maddr) => {
			});
			// ld1 {V4.S}[2], [X8]
			InsnTester.AutoTest(0x4D408104, (cpu, maddr) => {
			});
			// ld1 {V2.D}[1], [X9]
			InsnTester.AutoTest(0x4D408522, (cpu, maddr) => {
			});
			// ld1 {V7.S}[2], [X11]
			InsnTester.AutoTest(0x4D408167, (cpu, maddr) => {
			});
			// ld1 {V4.S}[0], [X0]
			InsnTester.AutoTest(0x0D408004, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcvtzs {
		[Fact]
		public void Fcvtzs() {
			// fcvtzs X8, S0
			InsnTester.AutoTest(0x9E380008, (cpu, maddr) => {
			});
			// fcvtzs W10, D0, #0x18
			InsnTester.AutoTest(0x1E58A00A, (cpu, maddr) => {
			});
			// fcvtzs W13, S4
			InsnTester.AutoTest(0x1E38008D, (cpu, maddr) => {
			});
			// fcvtzs W16, S0, #0xE
			InsnTester.AutoTest(0x1E18C810, (cpu, maddr) => {
			});
			// fcvtzs X1, S0
			InsnTester.AutoTest(0x9E380001, (cpu, maddr) => {
			});
			// fcvtzs W1, S5
			InsnTester.AutoTest(0x1E3800A1, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Adcs {
		[Fact]
		public void Adcs() {
			// adcs W4, W4, W8
			InsnTester.AutoTest(0x3A080084, (cpu, maddr) => {
			});
			// adcs X11, X21, XZR
			InsnTester.AutoTest(0xBA1F02AB, (cpu, maddr) => {
			});
			// adcs X13, XZR, XZR
			InsnTester.AutoTest(0xBA1F03ED, (cpu, maddr) => {
			});
			// adcs X5, X5, X9
			InsnTester.AutoTest(0xBA0900A5, (cpu, maddr) => {
			});
			// adcs X0, XZR, XZR
			InsnTester.AutoTest(0xBA1F03E0, (cpu, maddr) => {
			});
			// adcs X4, X4, X8
			InsnTester.AutoTest(0xBA080084, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdpPostIndex {
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
			// ldp X28, X25, [SP], #0x40
			InsnTester.AutoTest(0xA8C467FC, (cpu, maddr) => {
			});
			// ldp X3, X4, [X2], #0x20
			InsnTester.AutoTest(0xA8C21043, (cpu, maddr) => {
				cpu.X[2] = maddr;
			});
			// ldp X28, X25, [SP], #0x50
			InsnTester.AutoTest(0xA8C567FC, (cpu, maddr) => {
			});
			// ldp X16, X17, [SP], #0x10
			InsnTester.AutoTest(0xA8C147F0, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Bit {
		[Fact]
		public void Bit() {
			// bit V2.16B, V1.16B, V0.16B
			InsnTester.AutoTest(0x6EA01C22, (cpu, maddr) => {
			});
			// bit V20.16B, V3.16B, V22.16B
			InsnTester.AutoTest(0x6EB61C74, (cpu, maddr) => {
			});
			// bit V22.16B, V2.16B, V19.16B
			InsnTester.AutoTest(0x6EB31C56, (cpu, maddr) => {
			});
			// bit V4.16B, V3.16B, V5.16B
			InsnTester.AutoTest(0x6EA51C64, (cpu, maddr) => {
			});
			// bit V0.16B, V2.16B, V1.16B
			InsnTester.AutoTest(0x6EA11C40, (cpu, maddr) => {
			});
			// bit V23.16B, V0.16B, V22.16B
			InsnTester.AutoTest(0x6EB61C17, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cmhs {
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
	}

	public class AutoTest_Frecpe {
		[Fact]
		public void Frecpe() {
			// frecpe V3.4S, V2.4S
			InsnTester.AutoTest(0x4EA1D843, (cpu, maddr) => {
			});
			// frecpe V19.4S, V18.4S
			InsnTester.AutoTest(0x4EA1DA53, (cpu, maddr) => {
			});
			// frecpe V5.4S, V28.4S
			InsnTester.AutoTest(0x4EA1DB85, (cpu, maddr) => {
			});
			// frecpe V19.4S, V7.4S
			InsnTester.AutoTest(0x4EA1D8F3, (cpu, maddr) => {
			});
			// frecpe V11.4S, V30.4S
			InsnTester.AutoTest(0x4EA1DBCB, (cpu, maddr) => {
			});
			// frecpe V19.4S, V3.4S
			InsnTester.AutoTest(0x4EA1D873, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cmtst {
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
			// cmtst V19.4S, V17.4S, V6.4S
			InsnTester.AutoTest(0x4EA68E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V5.4S
			InsnTester.AutoTest(0x4EA58E33, (cpu, maddr) => {
			});
			// cmtst V19.4S, V17.4S, V2.4S
			InsnTester.AutoTest(0x4EA28E33, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cmn {
		[Fact]
		public void Cmn() {
			// cmn W1, #1
			InsnTester.AutoTest(0x3100043F, (cpu, maddr) => {
			});
			// cmn W11, #0x380, LSL #12
			InsnTester.AutoTest(0x314E017F, (cpu, maddr) => {
			});
			// cmn W2, #0x800
			InsnTester.AutoTest(0x3120005F, (cpu, maddr) => {
			});
			// cmn W23, #0x40
			InsnTester.AutoTest(0x310102FF, (cpu, maddr) => {
			});
			// cmn W10, #0xD
			InsnTester.AutoTest(0x3100355F, (cpu, maddr) => {
			});
			// cmn X10, #3
			InsnTester.AutoTest(0xB1000D5F, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fmov {
		[Fact]
		public void Fmov() {
			// fmov W0, S8
			InsnTester.AutoTest(0x1E260100, (cpu, maddr) => {
			});
			// fmov V27.4S, #-1.00000000
			InsnTester.AutoTest(0x4F07F61B, (cpu, maddr) => {
			});
			// fmov S9, W21
			InsnTester.AutoTest(0x1E2702A9, (cpu, maddr) => {
			});
			// fmov V1.2S, #16.00000000
			InsnTester.AutoTest(0x0F01F601, (cpu, maddr) => {
			});
			// fmov W18, S4
			InsnTester.AutoTest(0x1E260092, (cpu, maddr) => {
			});
			// fmov S11, #3.00000000
			InsnTester.AutoTest(0x1E21100B, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Extr {
		[Fact]
		public void Extr() {
			// extr W4, W3, W2, #8
			InsnTester.AutoTest(0x13822064, (cpu, maddr) => {
			});
			// extr W10, W13, W10, #0x18
			InsnTester.AutoTest(0x138A61AA, (cpu, maddr) => {
			});
			// extr X16, X18, X0, #0x14
			InsnTester.AutoTest(0x93C05250, (cpu, maddr) => {
			});
			// extr X12, X18, X23, #0x3B
			InsnTester.AutoTest(0x93D7EE4C, (cpu, maddr) => {
			});
			// extr W6, W18, W16, #0x18
			InsnTester.AutoTest(0x13906246, (cpu, maddr) => {
			});
			// extr W2, W27, W2, #8
			InsnTester.AutoTest(0x13822362, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ubfiz {
		[Fact]
		public void Ubfiz() {
			// ubfiz W8, W8, #4, #4
			InsnTester.AutoTest(0x531C0D08, (cpu, maddr) => {
			});
			// ubfiz X12, X13, #0x28, #0x14
			InsnTester.AutoTest(0xD3584DAC, (cpu, maddr) => {
			});
			// ubfiz W8, W21, #8, #8
			InsnTester.AutoTest(0x53181EA8, (cpu, maddr) => {
			});
			// ubfiz X14, X8, #0x20, #0xE
			InsnTester.AutoTest(0xD360350E, (cpu, maddr) => {
			});
			// ubfiz W3, W4, #7, #1
			InsnTester.AutoTest(0x53190083, (cpu, maddr) => {
			});
			// ubfiz W27, W0, #2, #8
			InsnTester.AutoTest(0x531E1C1B, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cneg {
		[Fact]
		public void Cneg() {
			// cneg W9, W0, MI
			InsnTester.AutoTest(0x5A805409, (cpu, maddr) => {
			});
			// cneg X17, X17, MI
			InsnTester.AutoTest(0xDA915631, (cpu, maddr) => {
			});
			// cneg W23, W23, LT
			InsnTester.AutoTest(0x5A97A6F7, (cpu, maddr) => {
			});
			// cneg W24, W24, MI
			InsnTester.AutoTest(0x5A985718, (cpu, maddr) => {
			});
			// cneg W8, W14, LE
			InsnTester.AutoTest(0x5A8EC5C8, (cpu, maddr) => {
			});
			// cneg X19, X9, LT
			InsnTester.AutoTest(0xDA89A533, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Lsr {
		[Fact]
		public void Lsr() {
			// lsr W7, W2, W0
			InsnTester.AutoTest(0x1AC02447, (cpu, maddr) => {
			});
			// lsr X28, X19, #0x3F
			InsnTester.AutoTest(0xD37FFE7C, (cpu, maddr) => {
			});
			// lsr X19, X22, #0x30
			InsnTester.AutoTest(0xD370FED3, (cpu, maddr) => {
			});
			// lsr W6, W7, W6
			InsnTester.AutoTest(0x1AC624E6, (cpu, maddr) => {
			});
			// lsr W17, W9, W11
			InsnTester.AutoTest(0x1ACB2531, (cpu, maddr) => {
			});
			// lsr X9, X9, #0x30
			InsnTester.AutoTest(0xD370FD29, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Udiv {
		[Fact]
		public void Udiv() {
			// udiv W1, W1, W9
			InsnTester.AutoTest(0x1AC90821, (cpu, maddr) => {
			});
			// udiv W12, W13, W12
			InsnTester.AutoTest(0x1ACC09AC, (cpu, maddr) => {
			});
			// udiv W14, W12, W21
			InsnTester.AutoTest(0x1AD5098E, (cpu, maddr) => {
			});
			// udiv X8, X8, X22
			InsnTester.AutoTest(0x9AD60908, (cpu, maddr) => {
			});
			// udiv W22, W22, W8
			InsnTester.AutoTest(0x1AC80AD6, (cpu, maddr) => {
			});
			// udiv X19, X8, X9
			InsnTester.AutoTest(0x9AC90913, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Shl {
		[Fact]
		public void Shl() {
			// shl V7.4S, V2.4S, #3
			InsnTester.AutoTest(0x4F235447, (cpu, maddr) => {
			});
			// shl V21.4S, V21.4S, #0x1F
			InsnTester.AutoTest(0x4F3F56B5, (cpu, maddr) => {
			});
			// shl V4.2S, V4.2S, #4
			InsnTester.AutoTest(0x0F245484, (cpu, maddr) => {
			});
			// shl V6.4S, V3.4S, #6
			InsnTester.AutoTest(0x4F265466, (cpu, maddr) => {
			});
			// shl V7.4S, V7.4S, #0x1F
			InsnTester.AutoTest(0x4F3F54E7, (cpu, maddr) => {
			});
			// shl V4.4S, V13.4S, #0x1F
			InsnTester.AutoTest(0x4F3F55A4, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Smaddl {
		[Fact]
		public void Smaddl() {
			// smaddl X8, W6, W3, X8
			InsnTester.AutoTest(0x9B2320C8, (cpu, maddr) => {
			});
			// smaddl X20, W26, W28, X19
			InsnTester.AutoTest(0x9B3C4F54, (cpu, maddr) => {
			});
			// smaddl X5, W5, W3, X1
			InsnTester.AutoTest(0x9B2304A5, (cpu, maddr) => {
			});
			// smaddl X23, W8, W23, X9
			InsnTester.AutoTest(0x9B372517, (cpu, maddr) => {
			});
			// smaddl X10, W2, W10, X19
			InsnTester.AutoTest(0x9B2A4C4A, (cpu, maddr) => {
			});
			// smaddl X20, W24, W22, X28
			InsnTester.AutoTest(0x9B367314, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cmp {
		[Fact]
		public void Cmp() {
			// cmp W1, #0
			InsnTester.AutoTest(0x7100003F, (cpu, maddr) => {
			});
			// cmp W12, #0x7FE, LSL #12
			InsnTester.AutoTest(0x715FF99F, (cpu, maddr) => {
			});
			// cmp W18, W4, UXTH
			InsnTester.AutoTest(0x6B24225F, (cpu, maddr) => {
			});
			// cmp W14, #0x53
			InsnTester.AutoTest(0x71014DDF, (cpu, maddr) => {
			});
			// cmp W7, W26
			InsnTester.AutoTest(0x6B1A00FF, (cpu, maddr) => {
			});
			// cmp W1, W12
			InsnTester.AutoTest(0x6B0C003F, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Rev64 {
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
			// rev64 V1.4S, V1.4S
			InsnTester.AutoTest(0x4EA00821, (cpu, maddr) => {
			});
			// rev64 V5.4S, V5.4S
			InsnTester.AutoTest(0x4EA008A5, (cpu, maddr) => {
			});
			// rev64 V6.4S, V6.4S
			InsnTester.AutoTest(0x4EA008C6, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sbcs {
		[Fact]
		public void Sbcs() {
			// sbcs X4, X4, X8
			InsnTester.AutoTest(0xFA080084, (cpu, maddr) => {
			});
			// sbcs X16, X18, XZR
			InsnTester.AutoTest(0xFA1F0250, (cpu, maddr) => {
			});
			// sbcs X10, X10, X16
			InsnTester.AutoTest(0xFA10014A, (cpu, maddr) => {
			});
			// sbcs X5, X5, X13
			InsnTester.AutoTest(0xFA0D00A5, (cpu, maddr) => {
			});
			// sbcs X3, X8, X10
			InsnTester.AutoTest(0xFA0A0103, (cpu, maddr) => {
			});
			// sbcs X11, X13, X10
			InsnTester.AutoTest(0xFA0A01AB, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ld1RPostIndex {
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
			// ld1r {V9.4S}, [X12], #4
			InsnTester.AutoTest(0x4DDFC989, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ld1r {V1.4S}, [X8], #4
			InsnTester.AutoTest(0x4DDFC901, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ld1r {V6.4S}, [X16], #4
			InsnTester.AutoTest(0x4DDFCA06, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ld1r {V0.16B}, [X8], #1
			InsnTester.AutoTest(0x4DDFC100, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}
	}

	public class AutoTest_LdrPreIndex {
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
			// ldr X10, [X19, #0x10]!
			InsnTester.AutoTest(0xF8410E6A, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldr X10, [X9, #8]!
			InsnTester.AutoTest(0xF8408D2A, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldr X0, [X1, #0x18]!
			InsnTester.AutoTest(0xF8418C20, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldr X1, [X22, #0xA8]!
			InsnTester.AutoTest(0xF84A8EC1, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
		}
	}

	public class AutoTest_Zip2 {
		[Fact]
		public void Zip2() {
			// zip2 V0.4S, V0.4S, V1.4S
			InsnTester.AutoTest(0x4E817800, (cpu, maddr) => {
			});
			// zip2 V27.4S, V27.4S, V29.4S
			InsnTester.AutoTest(0x4E9D7B7B, (cpu, maddr) => {
			});
			// zip2 V4.4S, V6.4S, V3.4S
			InsnTester.AutoTest(0x4E8378C4, (cpu, maddr) => {
			});
			// zip2 V1.4S, V3.4S, V4.4S
			InsnTester.AutoTest(0x4E847861, (cpu, maddr) => {
			});
			// zip2 V2.4S, V7.4S, V1.4S
			InsnTester.AutoTest(0x4E8178E2, (cpu, maddr) => {
			});
			// zip2 V28.4S, V28.4S, V1.4S
			InsnTester.AutoTest(0x4E817B9C, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Zip1 {
		[Fact]
		public void Zip1() {
			// zip1 V0.4S, V2.4S, V1.4S
			InsnTester.AutoTest(0x4E813840, (cpu, maddr) => {
			});
			// zip1 V30.2S, V28.2S, V29.2S
			InsnTester.AutoTest(0x0E9D3B9E, (cpu, maddr) => {
			});
			// zip1 V2.4S, V19.4S, V2.4S
			InsnTester.AutoTest(0x4E823A62, (cpu, maddr) => {
			});
			// zip1 V5.4S, V17.4S, V5.4S
			InsnTester.AutoTest(0x4E853A25, (cpu, maddr) => {
			});
			// zip1 V22.4S, V18.4S, V17.4S
			InsnTester.AutoTest(0x4E913A56, (cpu, maddr) => {
			});
			// zip1 V2.2S, V20.2S, V19.2S
			InsnTester.AutoTest(0x0E933A82, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ror {
		[Fact]
		public void Ror() {
			// ror W5, W1, W3
			InsnTester.AutoTest(0x1AC32C25, (cpu, maddr) => {
			});
			// ror W10, W10, #0x11
			InsnTester.AutoTest(0x138A454A, (cpu, maddr) => {
			});
			// ror W23, W23, #0x1B
			InsnTester.AutoTest(0x13976EF7, (cpu, maddr) => {
			});
			// ror W14, W14, #0xC
			InsnTester.AutoTest(0x138E31CE, (cpu, maddr) => {
			});
			// ror W5, W5, #0x10
			InsnTester.AutoTest(0x138540A5, (cpu, maddr) => {
			});
			// ror W12, W22, W10
			InsnTester.AutoTest(0x1ACA2ECC, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fneg {
		[Fact]
		public void Fneg() {
			// fneg D0, D0
			InsnTester.AutoTest(0x1E614000, (cpu, maddr) => {
			});
			// fneg V24.4S, V16.4S
			InsnTester.AutoTest(0x6EA0FA18, (cpu, maddr) => {
			});
			// fneg S6, S9
			InsnTester.AutoTest(0x1E214126, (cpu, maddr) => {
			});
			// fneg S13, S0
			InsnTester.AutoTest(0x1E21400D, (cpu, maddr) => {
			});
			// fneg S0, S17
			InsnTester.AutoTest(0x1E214220, (cpu, maddr) => {
			});
			// fneg S0, S18
			InsnTester.AutoTest(0x1E214240, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Adds {
		[Fact]
		public void Adds() {
			// adds X4, X4, #1
			InsnTester.AutoTest(0xB1000484, (cpu, maddr) => {
			});
			// adds W13, W10, #0x10, LSL #12
			InsnTester.AutoTest(0x3140414D, (cpu, maddr) => {
			});
			// adds X11, X10, #1
			InsnTester.AutoTest(0xB100054B, (cpu, maddr) => {
			});
			// adds X12, X12, X4, LSL #32
			InsnTester.AutoTest(0xAB04818C, (cpu, maddr) => {
			});
			// adds W13, W14, W13
			InsnTester.AutoTest(0x2B0D01CD, (cpu, maddr) => {
			});
			// adds X12, X13, X12
			InsnTester.AutoTest(0xAB0C01AC, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sub {
		[Fact]
		public void Sub() {
			// sub X2, X9, X0
			InsnTester.AutoTest(0xCB000122, (cpu, maddr) => {
			});
			// sub W10, W10, #0xA00, LSL #12
			InsnTester.AutoTest(0x5168014A, (cpu, maddr) => {
			});
			// sub X10, X1, X21
			InsnTester.AutoTest(0xCB15002A, (cpu, maddr) => {
			});
			// sub W16, W14, #2
			InsnTester.AutoTest(0x510009D0, (cpu, maddr) => {
			});
			// sub X12, X12, #0x18
			InsnTester.AutoTest(0xD100618C, (cpu, maddr) => {
			});
			// sub X0, X9, #0x10
			InsnTester.AutoTest(0xD1004120, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Smulh {
		[Fact]
		public void Smulh() {
			// smulh X8, X0, X8
			InsnTester.AutoTest(0x9B487C08, (cpu, maddr) => {
			});
			// smulh X10, X10, X11
			InsnTester.AutoTest(0x9B4B7D4A, (cpu, maddr) => {
			});
			// smulh X8, X22, X8
			InsnTester.AutoTest(0x9B487EC8, (cpu, maddr) => {
			});
			// smulh X8, X8, X10
			InsnTester.AutoTest(0x9B4A7D08, (cpu, maddr) => {
			});
			// smulh X8, X23, X8
			InsnTester.AutoTest(0x9B487EE8, (cpu, maddr) => {
			});
			// smulh X10, X8, X10
			InsnTester.AutoTest(0x9B4A7D0A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Neg {
		[Fact]
		public void Neg() {
			// neg X0, X2
			InsnTester.AutoTest(0xCB0203E0, (cpu, maddr) => {
			});
			// neg X12, X10, LSL #29
			InsnTester.AutoTest(0xCB0A77EC, (cpu, maddr) => {
			});
			// neg X15, X13
			InsnTester.AutoTest(0xCB0D03EF, (cpu, maddr) => {
			});
			// neg X16, X20
			InsnTester.AutoTest(0xCB1403F0, (cpu, maddr) => {
			});
			// neg X2, X8
			InsnTester.AutoTest(0xCB0803E2, (cpu, maddr) => {
			});
			// neg W30, W17
			InsnTester.AutoTest(0x4B1103FE, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Rev {
		[Fact]
		public void Rev() {
			// rev W4, W5
			InsnTester.AutoTest(0x5AC008A4, (cpu, maddr) => {
			});
			// rev W30, W30
			InsnTester.AutoTest(0x5AC00BDE, (cpu, maddr) => {
			});
			// rev W16, W16
			InsnTester.AutoTest(0x5AC00A10, (cpu, maddr) => {
			});
			// rev W10, W9
			InsnTester.AutoTest(0x5AC0092A, (cpu, maddr) => {
			});
			// rev X10, X8
			InsnTester.AutoTest(0xDAC00D0A, (cpu, maddr) => {
			});
			// rev W28, W27
			InsnTester.AutoTest(0x5AC00B7C, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Csneg {
		[Fact]
		public void Csneg() {
			// csneg W8, W8, W2, GE
			InsnTester.AutoTest(0x5A82A508, (cpu, maddr) => {
			});
			// csneg W11, W23, W27, LO
			InsnTester.AutoTest(0x5A9B36EB, (cpu, maddr) => {
			});
			// csneg W17, W18, W1, GE
			InsnTester.AutoTest(0x5A81A651, (cpu, maddr) => {
			});
			// csneg W16, W12, W9, GT
			InsnTester.AutoTest(0x5A89C590, (cpu, maddr) => {
			});
			// csneg W8, W8, W3, GE
			InsnTester.AutoTest(0x5A83A508, (cpu, maddr) => {
			});
			// csneg W10, W9, W10, GE
			InsnTester.AutoTest(0x5A8AA52A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fsqrt {
		[Fact]
		public void Fsqrt() {
			// fsqrt S3, S0
			InsnTester.AutoTest(0x1E21C003, (cpu, maddr) => {
			});
			// fsqrt S10, S11
			InsnTester.AutoTest(0x1E21C16A, (cpu, maddr) => {
			});
			// fsqrt S13, S8
			InsnTester.AutoTest(0x1E21C10D, (cpu, maddr) => {
			});
			// fsqrt S0, S5
			InsnTester.AutoTest(0x1E21C0A0, (cpu, maddr) => {
			});
			// fsqrt S8, S0
			InsnTester.AutoTest(0x1E21C008, (cpu, maddr) => {
			});
			// fsqrt S8, S11
			InsnTester.AutoTest(0x1E21C168, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldarb {
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
			// ldarb W8, [X19]
			InsnTester.AutoTest(0x08DFFE68, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldarb W8, [X21]
			InsnTester.AutoTest(0x08DFFEA8, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldarb W8, [X22]
			InsnTester.AutoTest(0x08DFFEC8, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldarb W9, [X8]
			InsnTester.AutoTest(0x08DFFD09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}
	}

	public class AutoTest_Mul {
		[Fact]
		public void Mul() {
			// mul X0, X0, X4
			InsnTester.AutoTest(0x9B047C00, (cpu, maddr) => {
			});
			// mul V0.4S, V0.4S, V0.S[1]
			InsnTester.AutoTest(0x4FA08000, (cpu, maddr) => {
			});
			// mul X13, X16, X13
			InsnTester.AutoTest(0x9B0D7E0D, (cpu, maddr) => {
			});
			// mul X10, X26, X10
			InsnTester.AutoTest(0x9B0A7F4A, (cpu, maddr) => {
			});
			// mul X14, X14, X17
			InsnTester.AutoTest(0x9B117DCE, (cpu, maddr) => {
			});
			// mul X2, X2, X11
			InsnTester.AutoTest(0x9B0B7C42, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Dsb {
		[Fact]
		public void Dsb() {
			// dsb SY
			InsnTester.AutoTest(0xD5033F9F, (cpu, maddr) => {
			});
			// dsb ISH
			InsnTester.AutoTest(0xD5033B9F, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldarh {
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
	}

	public class AutoTest_Asr {
		[Fact]
		public void Asr() {
			// asr W2, W2, #3
			InsnTester.AutoTest(0x13037C42, (cpu, maddr) => {
			});
			// asr X10, X10, #0x3F
			InsnTester.AutoTest(0x937FFD4A, (cpu, maddr) => {
			});
			// asr W21, W8, #2
			InsnTester.AutoTest(0x13027D15, (cpu, maddr) => {
			});
			// asr W7, W7, #0xF
			InsnTester.AutoTest(0x130F7CE7, (cpu, maddr) => {
			});
			// asr W9, W4, #0x10
			InsnTester.AutoTest(0x13107C89, (cpu, maddr) => {
			});
			// asr W1, W1, #8
			InsnTester.AutoTest(0x13087C21, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcsel {
		[Fact]
		public void Fcsel() {
			// fcsel S0, S1, S0, MI
			InsnTester.AutoTest(0x1E204C20, (cpu, maddr) => {
			});
			// fcsel S20, S20, S21, GT
			InsnTester.AutoTest(0x1E35CE94, (cpu, maddr) => {
			});
			// fcsel S17, S22, S19, MI
			InsnTester.AutoTest(0x1E334ED1, (cpu, maddr) => {
			});
			// fcsel S19, S17, S3, MI
			InsnTester.AutoTest(0x1E234E33, (cpu, maddr) => {
			});
			// fcsel S0, S12, S14, GT
			InsnTester.AutoTest(0x1E2ECD80, (cpu, maddr) => {
			});
			// fcsel S16, S16, S20, MI
			InsnTester.AutoTest(0x1E344E10, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Rev16 {
		[Fact]
		public void Rev16() {
			// rev16 W5, W3
			InsnTester.AutoTest(0x5AC00465, (cpu, maddr) => {
			});
			// rev16 W11, W28
			InsnTester.AutoTest(0x5AC0078B, (cpu, maddr) => {
			});
			// rev16 W25, W25
			InsnTester.AutoTest(0x5AC00739, (cpu, maddr) => {
			});
			// rev16 W12, W12
			InsnTester.AutoTest(0x5AC0058C, (cpu, maddr) => {
			});
			// rev16 W15, W16
			InsnTester.AutoTest(0x5AC0060F, (cpu, maddr) => {
			});
			// rev16 W26, W24
			InsnTester.AutoTest(0x5AC0071A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fmax {
		[Fact]
		public void Fmax() {
			// fmax S4, S0, S1
			InsnTester.AutoTest(0x1E214804, (cpu, maddr) => {
			});
			// fmax S22, S20, S21
			InsnTester.AutoTest(0x1E354A96, (cpu, maddr) => {
			});
			// fmax S9, S0, S1
			InsnTester.AutoTest(0x1E214809, (cpu, maddr) => {
			});
			// fmax S8, S0, S9
			InsnTester.AutoTest(0x1E294808, (cpu, maddr) => {
			});
			// fmax S2, S1, S2
			InsnTester.AutoTest(0x1E224822, (cpu, maddr) => {
			});
			// fmax S3, S9, S0
			InsnTester.AutoTest(0x1E204923, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Eon {
		[Fact]
		public void Eon() {
			// eon W10, W10, W9
			InsnTester.AutoTest(0x4A29014A, (cpu, maddr) => {
			});
			// eon W12, W12, W11
			InsnTester.AutoTest(0x4A2B018C, (cpu, maddr) => {
			});
			// eon W16, W17, W16
			InsnTester.AutoTest(0x4A300230, (cpu, maddr) => {
			});
			// eon W17, W18, W17
			InsnTester.AutoTest(0x4A310251, (cpu, maddr) => {
			});
			// eon W14, W14, W13
			InsnTester.AutoTest(0x4A2D01CE, (cpu, maddr) => {
			});
			// eon W15, W15, W14
			InsnTester.AutoTest(0x4A2E01EF, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Orr {
		[Fact]
		public void Orr() {
			// orr X9, X9, #1
			InsnTester.AutoTest(0xB2400129, (cpu, maddr) => {
			});
			// orr X22, XZR, #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0xB27FFBF6, (cpu, maddr) => {
			});
			// orr X12, XZR, #0x3F
			InsnTester.AutoTest(0xB24017EC, (cpu, maddr) => {
			});
			// orr W21, WZR, #0xF0
			InsnTester.AutoTest(0x321C0FF5, (cpu, maddr) => {
			});
			// orr W10, WZR, #0x800
			InsnTester.AutoTest(0x321503EA, (cpu, maddr) => {
			});
			// orr W9, W9, W10, LSL #2
			InsnTester.AutoTest(0x2A0A0929, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldrb {
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
			// ldrb W9, [X1, #0x38]
			InsnTester.AutoTest(0x3940E029, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrb W8, [X1, #0x166]
			InsnTester.AutoTest(0x39459828, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
			// ldrb W9, [X19, #0x1DC]
			InsnTester.AutoTest(0x39477269, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldrb W5, [X1]
			InsnTester.AutoTest(0x39400025, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
		}
	}

	public class AutoTest_Ushll {
		[Fact]
		public void Ushll() {
			// ushll V6.4S, V6.4H, #0
			InsnTester.AutoTest(0x2F10A4C6, (cpu, maddr) => {
			});
			// ushll V13.4S, V13.4H, #0
			InsnTester.AutoTest(0x2F10A5AD, (cpu, maddr) => {
			});
			// ushll V0.4S, V0.4H, #0
			InsnTester.AutoTest(0x2F10A400, (cpu, maddr) => {
			});
			// ushll V3.4S, V2.4H, #0
			InsnTester.AutoTest(0x2F10A443, (cpu, maddr) => {
			});
			// ushll V2.8H, V1.8B, #0
			InsnTester.AutoTest(0x2F08A422, (cpu, maddr) => {
			});
			// ushll V2.4S, V1.4H, #0
			InsnTester.AutoTest(0x2F10A422, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdrsbPostIndex {
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
			// ldrsb X8, [X20], #1
			InsnTester.AutoTest(0x38801688, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldrsb X11, [X9], #1
			InsnTester.AutoTest(0x3880152B, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsb X15, [X16], #1
			InsnTester.AutoTest(0x3880160F, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldrsb W26, [X20], #1
			InsnTester.AutoTest(0x38C0169A, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
		}
	}

	public class AutoTest_LdrshPostIndex {
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
			// ldrsh W10, [X28], #2
			InsnTester.AutoTest(0x78C0278A, (cpu, maddr) => {
				cpu.X[28] = maddr;
			});
			// ldrsh W8, [X9], #2
			InsnTester.AutoTest(0x78C02528, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsh X20, [X6], #2
			InsnTester.AutoTest(0x788024D4, (cpu, maddr) => {
				cpu.X[6] = maddr;
			});
			// ldrsh X5, [X17], #2
			InsnTester.AutoTest(0x78802625, (cpu, maddr) => {
				cpu.X[17] = maddr;
			});
		}
	}

	public class AutoTest_Ubfx {
		[Fact]
		public void Ubfx() {
			// ubfx W9, W0, #1, #1
			InsnTester.AutoTest(0x53010409, (cpu, maddr) => {
			});
			// ubfx X15, X15, #0x1F, #0x20
			InsnTester.AutoTest(0xD35FF9EF, (cpu, maddr) => {
			});
			// ubfx W12, W8, #3, #5
			InsnTester.AutoTest(0x53031D0C, (cpu, maddr) => {
			});
			// ubfx W8, W8, #4, #0xB
			InsnTester.AutoTest(0x53043908, (cpu, maddr) => {
			});
			// ubfx W9, W22, #4, #4
			InsnTester.AutoTest(0x53041EC9, (cpu, maddr) => {
			});
			// ubfx X18, X14, #1, #0x20
			InsnTester.AutoTest(0xD34181D2, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Orn {
		[Fact]
		public void Orn() {
			// orn W3, W1, W2
			InsnTester.AutoTest(0x2A220023, (cpu, maddr) => {
			});
			// orn W10, W11, W10
			InsnTester.AutoTest(0x2A2A016A, (cpu, maddr) => {
			});
			// orn W8, W8, W0
			InsnTester.AutoTest(0x2A200108, (cpu, maddr) => {
			});
			// orn W8, W11, W26
			InsnTester.AutoTest(0x2A3A0168, (cpu, maddr) => {
			});
			// orn W11, W9, W11
			InsnTester.AutoTest(0x2A2B012B, (cpu, maddr) => {
			});
			// orn W8, W21, W0
			InsnTester.AutoTest(0x2A2002A8, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fccmp {
		[Fact]
		public void Fccmp() {
			// fccmp S8, S0, #4, MI
			InsnTester.AutoTest(0x1E204504, (cpu, maddr) => {
			});
			// fccmp S28, S23, #8, LS
			InsnTester.AutoTest(0x1E379788, (cpu, maddr) => {
			});
			// fccmp S1, S8, #0, PL
			InsnTester.AutoTest(0x1E285420, (cpu, maddr) => {
			});
			// fccmp S5, S0, #0, MI
			InsnTester.AutoTest(0x1E2044A0, (cpu, maddr) => {
			});
			// fccmp S2, S0, #0, LE
			InsnTester.AutoTest(0x1E20D440, (cpu, maddr) => {
			});
			// fccmp S1, S2, #0, EQ
			InsnTester.AutoTest(0x1E220420, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sxtb {
		[Fact]
		public void Sxtb() {
			// sxtb W4, W6
			InsnTester.AutoTest(0x13001CC4, (cpu, maddr) => {
			});
			// sxtb X20, W19
			InsnTester.AutoTest(0x93401E74, (cpu, maddr) => {
			});
			// sxtb W8, W22
			InsnTester.AutoTest(0x13001EC8, (cpu, maddr) => {
			});
			// sxtb W2, W11
			InsnTester.AutoTest(0x13001D62, (cpu, maddr) => {
			});
			// sxtb W10, W19
			InsnTester.AutoTest(0x13001E6A, (cpu, maddr) => {
			});
			// sxtb W3, W8
			InsnTester.AutoTest(0x13001D03, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sxth {
		[Fact]
		public void Sxth() {
			// sxth W2, W0
			InsnTester.AutoTest(0x13003C02, (cpu, maddr) => {
			});
			// sxth W25, W30
			InsnTester.AutoTest(0x13003FD9, (cpu, maddr) => {
			});
			// sxth W15, W24
			InsnTester.AutoTest(0x13003F0F, (cpu, maddr) => {
			});
			// sxth W9, W19
			InsnTester.AutoTest(0x13003E69, (cpu, maddr) => {
			});
			// sxth X15, W0
			InsnTester.AutoTest(0x93403C0F, (cpu, maddr) => {
			});
			// sxth W18, W15
			InsnTester.AutoTest(0x13003DF2, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Bfxil {
		[Fact]
		public void Bfxil() {
			// bfxil W6, W1, #0, #6
			InsnTester.AutoTest(0x33001426, (cpu, maddr) => {
			});
			// bfxil X16, X11, #0x15, #0x1F
			InsnTester.AutoTest(0xB355CD70, (cpu, maddr) => {
			});
			// bfxil W8, W22, #0, #5
			InsnTester.AutoTest(0x330012C8, (cpu, maddr) => {
			});
			// bfxil W8, W9, #0, #6
			InsnTester.AutoTest(0x33001528, (cpu, maddr) => {
			});
			// bfxil W10, W8, #0x10, #8
			InsnTester.AutoTest(0x33105D0A, (cpu, maddr) => {
			});
			// bfxil X10, X11, #0, #2
			InsnTester.AutoTest(0xB340056A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ccmp {
		[Fact]
		public void Ccmp() {
			// ccmp X8, #0, #0, EQ
			InsnTester.AutoTest(0xFA400900, (cpu, maddr) => {
			});
			// ccmp W23, #0x1F, #2, NE
			InsnTester.AutoTest(0x7A5F1AE2, (cpu, maddr) => {
			});
			// ccmp W8, #2, #8, LE
			InsnTester.AutoTest(0x7A42D908, (cpu, maddr) => {
			});
			// ccmp X3, #0, #4, HS
			InsnTester.AutoTest(0xFA402864, (cpu, maddr) => {
			});
			// ccmp X8, X1, #0, NE
			InsnTester.AutoTest(0xFA411100, (cpu, maddr) => {
			});
			// ccmp W17, W8, #4, LT
			InsnTester.AutoTest(0x7A48B224, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ccmn {
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
			// ccmn W8, #1, #4, GT
			InsnTester.AutoTest(0x3A41C904, (cpu, maddr) => {
			});
			// ccmn W13, #1, #0, NE
			InsnTester.AutoTest(0x3A4119A0, (cpu, maddr) => {
			});
			// ccmn W8, #1, #4, NE
			InsnTester.AutoTest(0x3A411904, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sshr {
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
			// sshr V7.4S, V7.4S, #0x1F
			InsnTester.AutoTest(0x4F2104E7, (cpu, maddr) => {
			});
			// sshr V4.4S, V4.4S, #0x1F
			InsnTester.AutoTest(0x4F210484, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fmin {
		[Fact]
		public void Fmin() {
			// fmin S0, S1, S0
			InsnTester.AutoTest(0x1E205820, (cpu, maddr) => {
			});
			// fmin S2, S17, S16
			InsnTester.AutoTest(0x1E305A22, (cpu, maddr) => {
			});
			// fmin S16, S16, S4
			InsnTester.AutoTest(0x1E245A10, (cpu, maddr) => {
			});
			// fmin S3, S1, S11
			InsnTester.AutoTest(0x1E2B5823, (cpu, maddr) => {
			});
			// fmin S2, S3, S2
			InsnTester.AutoTest(0x1E225862, (cpu, maddr) => {
			});
			// fmin S1, S0, S1
			InsnTester.AutoTest(0x1E215801, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Mvn {
		[Fact]
		public void Mvn() {
			// mvn W0, W8
			InsnTester.AutoTest(0x2A2803E0, (cpu, maddr) => {
			});
			// mvn V16.16B, V16.16B
			InsnTester.AutoTest(0x6E205A10, (cpu, maddr) => {
			});
			// mvn W24, W7
			InsnTester.AutoTest(0x2A2703F8, (cpu, maddr) => {
			});
			// mvn W8, W28
			InsnTester.AutoTest(0x2A3C03E8, (cpu, maddr) => {
			});
			// mvn X8, X24
			InsnTester.AutoTest(0xAA3803E8, (cpu, maddr) => {
			});
			// mvn W7, W3
			InsnTester.AutoTest(0x2A2303E7, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcvt {
		[Fact]
		public void Fcvt() {
			// fcvt S2, D0
			InsnTester.AutoTest(0x1E624002, (cpu, maddr) => {
			});
			// fcvt S16, D16
			InsnTester.AutoTest(0x1E624210, (cpu, maddr) => {
			});
			// fcvt D6, S16
			InsnTester.AutoTest(0x1E22C206, (cpu, maddr) => {
			});
			// fcvt D3, S1
			InsnTester.AutoTest(0x1E22C023, (cpu, maddr) => {
			});
			// fcvt D2, S0
			InsnTester.AutoTest(0x1E22C002, (cpu, maddr) => {
			});
			// fcvt D1, S3
			InsnTester.AutoTest(0x1E22C061, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fsub {
		[Fact]
		public void Fsub() {
			// fsub S4, S1, S0
			InsnTester.AutoTest(0x1E203824, (cpu, maddr) => {
			});
			// fsub V21.4S, V26.4S, V30.4S
			InsnTester.AutoTest(0x4EBED755, (cpu, maddr) => {
			});
			// fsub S25, S5, S22
			InsnTester.AutoTest(0x1E3638B9, (cpu, maddr) => {
			});
			// fsub S9, S18, S17
			InsnTester.AutoTest(0x1E313A49, (cpu, maddr) => {
			});
			// fsub S1, S19, S20
			InsnTester.AutoTest(0x1E343A61, (cpu, maddr) => {
			});
			// fsub S10, S0, S11
			InsnTester.AutoTest(0x1E2B380A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Subs {
		[Fact]
		public void Subs() {
			// subs X8, X8, #1
			InsnTester.AutoTest(0xF1000508, (cpu, maddr) => {
			});
			// subs X21, X21, #0x600, LSL #12
			InsnTester.AutoTest(0xF15802B5, (cpu, maddr) => {
			});
			// subs X8, X1, X2
			InsnTester.AutoTest(0xEB020028, (cpu, maddr) => {
			});
			// subs X8, X21, X20
			InsnTester.AutoTest(0xEB1402A8, (cpu, maddr) => {
			});
			// subs W26, W26, #1
			InsnTester.AutoTest(0x7100075A, (cpu, maddr) => {
			});
			// subs W20, W9, #1
			InsnTester.AutoTest(0x71000534, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Scvtf {
		[Fact]
		public void Scvtf() {
			// scvtf S1, S0
			InsnTester.AutoTest(0x5E21D801, (cpu, maddr) => {
			});
			// scvtf V27.2S, V27.2S
			InsnTester.AutoTest(0x0E21DB7B, (cpu, maddr) => {
			});
			// scvtf S6, W20
			InsnTester.AutoTest(0x1E220286, (cpu, maddr) => {
			});
			// scvtf S6, W24
			InsnTester.AutoTest(0x1E220306, (cpu, maddr) => {
			});
			// scvtf S3, W24
			InsnTester.AutoTest(0x1E220303, (cpu, maddr) => {
			});
			// scvtf S9, W2
			InsnTester.AutoTest(0x1E220049, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldur {
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
			// ldur W2, [X16, #-0x20]
			InsnTester.AutoTest(0xB85E0202, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldur X8, [X24, #-0x28]
			InsnTester.AutoTest(0xF85D8308, (cpu, maddr) => {
				cpu.X[24] = maddr;
			});
			// ldur W10, [X29, #-0xA0]
			InsnTester.AutoTest(0xB85603AA, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldur W0, [X29, #-0x1C]
			InsnTester.AutoTest(0xB85E43A0, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
		}
	}

	public class AutoTest_Smax {
		[Fact]
		public void Smax() {
			// smax V1.4S, V1.4S, V5.4S
			InsnTester.AutoTest(0x4EA56421, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V1.4S
			InsnTester.AutoTest(0x4EA16400, (cpu, maddr) => {
			});
			// smax V3.4S, V3.4S, V7.4S
			InsnTester.AutoTest(0x4EA76463, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V2.4S
			InsnTester.AutoTest(0x4EA26400, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V4.4S
			InsnTester.AutoTest(0x4EA46400, (cpu, maddr) => {
			});
			// smax V0.4S, V0.4S, V3.4S
			InsnTester.AutoTest(0x4EA36400, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Umulh {
		[Fact]
		public void Umulh() {
			// umulh X8, X2, X0
			InsnTester.AutoTest(0x9BC07C48, (cpu, maddr) => {
			});
			// umulh X10, X10, X23
			InsnTester.AutoTest(0x9BD77D4A, (cpu, maddr) => {
			});
			// umulh X9, X24, X26
			InsnTester.AutoTest(0x9BDA7F09, (cpu, maddr) => {
			});
			// umulh X9, X0, X8
			InsnTester.AutoTest(0x9BC87C09, (cpu, maddr) => {
			});
			// umulh X8, X24, X23
			InsnTester.AutoTest(0x9BD77F08, (cpu, maddr) => {
			});
			// umulh X14, X13, X14
			InsnTester.AutoTest(0x9BCE7DAE, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cmeq {
		[Fact]
		public void Cmeq() {
			// cmeq V1.4S, V0.4S, #0
			InsnTester.AutoTest(0x4EA09801, (cpu, maddr) => {
			});
			// cmeq V19.16B, V16.16B, V2.16B
			InsnTester.AutoTest(0x6E228E13, (cpu, maddr) => {
			});
			// cmeq V4.4S, V4.4S, #0
			InsnTester.AutoTest(0x4EA09884, (cpu, maddr) => {
			});
			// cmeq V6.16B, V4.16B, V1.16B
			InsnTester.AutoTest(0x6E218C86, (cpu, maddr) => {
			});
			// cmeq V4.16B, V4.16B, V3.16B
			InsnTester.AutoTest(0x6E238C84, (cpu, maddr) => {
			});
			// cmeq V5.4S, V4.4S, #0
			InsnTester.AutoTest(0x4EA09885, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fmul {
		[Fact]
		public void Fmul() {
			// fmul S6, S0, S0
			InsnTester.AutoTest(0x1E200806, (cpu, maddr) => {
			});
			// fmul V31.4S, V21.4S, V31.S[0]
			InsnTester.AutoTest(0x4F9F92BF, (cpu, maddr) => {
			});
			// fmul S23, S29, S6
			InsnTester.AutoTest(0x1E260BB7, (cpu, maddr) => {
			});
			// fmul V31.4S, V0.4S, V3.S[0]
			InsnTester.AutoTest(0x4F83901F, (cpu, maddr) => {
			});
			// fmul S3, S1, V2.S[0]
			InsnTester.AutoTest(0x5F829023, (cpu, maddr) => {
			});
			// fmul S16, S6, S3
			InsnTester.AutoTest(0x1E2308D0, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Negs {
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
	}

	public class AutoTest_Xtn2 {
		[Fact]
		public void Xtn2() {
			// xtn2 V7.8H, V6.4S
			InsnTester.AutoTest(0x4E6128C7, (cpu, maddr) => {
			});
			// xtn2 V7.16B, V17.8H
			InsnTester.AutoTest(0x4E212A27, (cpu, maddr) => {
			});
			// xtn2 V6.8H, V17.4S
			InsnTester.AutoTest(0x4E612A26, (cpu, maddr) => {
			});
			// xtn2 V7.16B, V6.8H
			InsnTester.AutoTest(0x4E2128C7, (cpu, maddr) => {
			});
			// xtn2 V4.16B, V3.8H
			InsnTester.AutoTest(0x4E212864, (cpu, maddr) => {
			});
			// xtn2 V17.8H, V16.4S
			InsnTester.AutoTest(0x4E612A11, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ngcs {
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
	}

	public class AutoTest_Ldrh {
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
			// ldrh W16, [X12, #0xA4]
			InsnTester.AutoTest(0x79414990, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ldrh W9, [X8, #0x14]
			InsnTester.AutoTest(0x79402909, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrh W9, [X13, #8]
			InsnTester.AutoTest(0x794011A9, (cpu, maddr) => {
				cpu.X[13] = maddr;
			});
			// ldrh W18, [X3, X12]
			InsnTester.AutoTest(0x786C6872, (cpu, maddr) => {
				cpu.X[3] = maddr;
				cpu.X[12] = 0x10;
			});
		}
	}

	public class AutoTest_LdrsbPreIndex {
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
			// ldrsb W10, [X9, #1]!
			InsnTester.AutoTest(0x38C01D2A, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsb W13, [X9, #-1]!
			InsnTester.AutoTest(0x38DFFD2D, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsb W9, [X8, #1]!
			InsnTester.AutoTest(0x38C01D09, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsb W8, [X28, #-1]!
			InsnTester.AutoTest(0x38DFFF88, (cpu, maddr) => {
				cpu.X[28] = maddr;
			});
		}
	}

	public class AutoTest_Csinv {
		[Fact]
		public void Csinv() {
			// csinv W8, W8, W3, GE
			InsnTester.AutoTest(0x5A83A108, (cpu, maddr) => {
			});
			// csinv W18, W16, WZR, LE
			InsnTester.AutoTest(0x5A9FD212, (cpu, maddr) => {
			});
			// csinv X27, X28, XZR, NE
			InsnTester.AutoTest(0xDA9F139B, (cpu, maddr) => {
			});
			// csinv W25, W9, WZR, LE
			InsnTester.AutoTest(0x5A9FD139, (cpu, maddr) => {
			});
			// csinv X23, X8, XZR, EQ
			InsnTester.AutoTest(0xDA9F0117, (cpu, maddr) => {
			});
			// csinv W10, W10, WZR, LS
			InsnTester.AutoTest(0x5A9F914A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdrswPreIndex {
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
			// ldrsw X8, [X22, #0xF4]!
			InsnTester.AutoTest(0xB88F4EC8, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldrsw X8, [X0, #0x18]!
			InsnTester.AutoTest(0xB8818C08, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsw X9, [X23, #0x48]!
			InsnTester.AutoTest(0xB8848EE9, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
			// ldrsw X8, [X23, #0x14]!
			InsnTester.AutoTest(0xB8814EE8, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
		}
	}

	public class AutoTest_Faddp {
		[Fact]
		public void Faddp() {
			// faddp S3, V5.2S
			InsnTester.AutoTest(0x7E30D8A3, (cpu, maddr) => {
			});
			// faddp V21.2S, V21.2S, V22.2S
			InsnTester.AutoTest(0x2E36D6B5, (cpu, maddr) => {
			});
			// faddp V3.2S, V3.2S, V3.2S
			InsnTester.AutoTest(0x2E23D463, (cpu, maddr) => {
			});
			// faddp V0.2S, V0.2S, V0.2S
			InsnTester.AutoTest(0x2E20D400, (cpu, maddr) => {
			});
			// faddp S7, V7.2S
			InsnTester.AutoTest(0x7E30D8E7, (cpu, maddr) => {
			});
			// faddp V4.2S, V0.2S, V0.2S
			InsnTester.AutoTest(0x2E20D404, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Rev32 {
		[Fact]
		public void Rev32() {
			// rev32 V0.16B, V0.16B
			InsnTester.AutoTest(0x6E200800, (cpu, maddr) => {
			});
			// rev32 V16.16B, V16.16B
			InsnTester.AutoTest(0x6E200A10, (cpu, maddr) => {
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
			// rev32 V7.16B, V7.16B
			InsnTester.AutoTest(0x6E2008E7, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Csinc {
		[Fact]
		public void Csinc() {
			// csinc X6, X9, X0, NE
			InsnTester.AutoTest(0x9A801526, (cpu, maddr) => {
			});
			// csinc W10, WZR, W10, GE
			InsnTester.AutoTest(0x1A8AA7EA, (cpu, maddr) => {
			});
			// csinc W9, WZR, W8, GT
			InsnTester.AutoTest(0x1A88C7E9, (cpu, maddr) => {
			});
			// csinc W10, WZR, W20, EQ
			InsnTester.AutoTest(0x1A9407EA, (cpu, maddr) => {
			});
			// csinc W9, WZR, W10, GE
			InsnTester.AutoTest(0x1A8AA7E9, (cpu, maddr) => {
			});
			// csinc W8, W8, W22, LE
			InsnTester.AutoTest(0x1A96D508, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Dup {
		[Fact]
		public void Dup() {
			// dup V0.4S, W1
			InsnTester.AutoTest(0x4E040C20, (cpu, maddr) => {
			});
			// dup V17.4S, V17.S[0]
			InsnTester.AutoTest(0x4E040631, (cpu, maddr) => {
			});
			// dup V20.4S, V17.S[1]
			InsnTester.AutoTest(0x4E0C0634, (cpu, maddr) => {
			});
			// dup V1.4S, W11
			InsnTester.AutoTest(0x4E040D61, (cpu, maddr) => {
			});
			// dup V5.2S, V5.S[0]
			InsnTester.AutoTest(0x0E0404A5, (cpu, maddr) => {
			});
			// dup V16.4S, V4.S[0]
			InsnTester.AutoTest(0x4E040490, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ands {
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
	}

	public class AutoTest_Ldar {
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
			// ldar X9, [X9]
			InsnTester.AutoTest(0xC8DFFD29, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldar X16, [X14]
			InsnTester.AutoTest(0xC8DFFDD0, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
			// ldar W0, [X8]
			InsnTester.AutoTest(0x88DFFD00, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldar X14, [X14]
			InsnTester.AutoTest(0xC8DFFDCE, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
		}
	}

	public class AutoTest_Ldxrh {
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
	}

	public class AutoTest_Ld1R {
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
			// ld1r {V4.4S}, [X8]
			InsnTester.AutoTest(0x4D40C904, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ld1r {V19.4S}, [X9]
			InsnTester.AutoTest(0x4D40C933, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ld1r {V5.4S}, [X11]
			InsnTester.AutoTest(0x4D40C965, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ld1r {V27.4S}, [X9]
			InsnTester.AutoTest(0x4D40C93B, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
		}
	}

	public class AutoTest_Fcvtms {
		[Fact]
		public void Fcvtms() {
			// fcvtms W0, S0
			InsnTester.AutoTest(0x1E300000, (cpu, maddr) => {
			});
			// fcvtms W22, S19
			InsnTester.AutoTest(0x1E300276, (cpu, maddr) => {
			});
			// fcvtms W11, S0
			InsnTester.AutoTest(0x1E30000B, (cpu, maddr) => {
			});
			// fcvtms W8, D0
			InsnTester.AutoTest(0x1E700008, (cpu, maddr) => {
			});
			// fcvtms W21, S0
			InsnTester.AutoTest(0x1E300015, (cpu, maddr) => {
			});
			// fcvtms W8, S0
			InsnTester.AutoTest(0x1E300008, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ushll2 {
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
	}

	public class AutoTest_Ldxrb {
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
	}

	public class AutoTest_Frsqrts {
		[Fact]
		public void Frsqrts() {
			// frsqrts V2.4S, V0.4S, V2.4S
			InsnTester.AutoTest(0x4EA2FC02, (cpu, maddr) => {
			});
			// frsqrts V31.4S, V30.4S, V31.4S
			InsnTester.AutoTest(0x4EBFFFDF, (cpu, maddr) => {
			});
			// frsqrts V7.4S, V19.4S, V7.4S
			InsnTester.AutoTest(0x4EA7FE67, (cpu, maddr) => {
			});
			// frsqrts V6.4S, V7.4S, V6.4S
			InsnTester.AutoTest(0x4EA6FCE6, (cpu, maddr) => {
			});
			// frsqrts V17.4S, V7.4S, V17.4S
			InsnTester.AutoTest(0x4EB1FCF1, (cpu, maddr) => {
			});
			// frsqrts V3.4S, V0.4S, V3.4S
			InsnTester.AutoTest(0x4EA3FC03, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldursw {
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
			// ldursw X8, [X29, #-0x28]
			InsnTester.AutoTest(0xB89D83A8, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
			// ldursw X8, [X8, #-4]
			InsnTester.AutoTest(0xB89FC108, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldursw X9, [X9, #-4]
			InsnTester.AutoTest(0xB89FC129, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldursw X8, [X29, #-0xD0]
			InsnTester.AutoTest(0xB89303A8, (cpu, maddr) => {
				cpu.X[29] = maddr;
			});
		}
	}

	public class AutoTest_Ldursh {
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
			// ldursh W12, [X12, #-0x10]
			InsnTester.AutoTest(0x78DF018C, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ldursh W2, [X0, #-0x40]
			InsnTester.AutoTest(0x78DC0002, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldursh W15, [X12, #-4]
			InsnTester.AutoTest(0x78DFC18F, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
			// ldursh X26, [X23, #-4]
			InsnTester.AutoTest(0x789FC2FA, (cpu, maddr) => {
				cpu.X[23] = maddr;
			});
		}
	}

	public class AutoTest_LdrhPostIndex {
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
			// ldrh W12, [X2], #2
			InsnTester.AutoTest(0x7840244C, (cpu, maddr) => {
				cpu.X[2] = maddr;
			});
			// ldrh W14, [X11], #4
			InsnTester.AutoTest(0x7840456E, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrh W8, [X9], #2
			InsnTester.AutoTest(0x78402528, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrh W10, [X8], #2
			InsnTester.AutoTest(0x7840250A, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}
	}

	public class AutoTest_Xtn {
		[Fact]
		public void Xtn() {
			// xtn V4.2S, V1.2D
			InsnTester.AutoTest(0x0EA12824, (cpu, maddr) => {
			});
			// xtn V13.4H, V10.4S
			InsnTester.AutoTest(0x0E61294D, (cpu, maddr) => {
			});
			// xtn V7.4H, V7.4S
			InsnTester.AutoTest(0x0E6128E7, (cpu, maddr) => {
			});
			// xtn V16.4H, V16.4S
			InsnTester.AutoTest(0x0E612A10, (cpu, maddr) => {
			});
			// xtn V7.4H, V4.4S
			InsnTester.AutoTest(0x0E612887, (cpu, maddr) => {
			});
			// xtn V31.4H, V12.4S
			InsnTester.AutoTest(0x0E61299F, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdrbPreIndex {
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
			// ldrb W12, [X10, #3]!
			InsnTester.AutoTest(0x38403D4C, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldrb W8, [X9, #4]!
			InsnTester.AutoTest(0x38404D28, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrb W3, [X0, #2]!
			InsnTester.AutoTest(0x38402C03, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrb W15, [X1, #1]!
			InsnTester.AutoTest(0x38401C2F, (cpu, maddr) => {
				cpu.X[1] = maddr;
			});
		}
	}

	public class AutoTest_Frsqrte {
		[Fact]
		public void Frsqrte() {
			// frsqrte V0.4S, V1.4S
			InsnTester.AutoTest(0x6EA1D820, (cpu, maddr) => {
			});
			// frsqrte V17.4S, V16.4S
			InsnTester.AutoTest(0x6EA1DA11, (cpu, maddr) => {
			});
			// frsqrte V1.4S, V0.4S
			InsnTester.AutoTest(0x6EA1D801, (cpu, maddr) => {
			});
			// frsqrte V0.4S, V4.4S
			InsnTester.AutoTest(0x6EA1D880, (cpu, maddr) => {
			});
			// frsqrte V19.4S, V7.4S
			InsnTester.AutoTest(0x6EA1D8F3, (cpu, maddr) => {
			});
			// frsqrte V6.4S, V4.4S
			InsnTester.AutoTest(0x6EA1D886, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Frintx {
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
			// frintx D0, D0
			InsnTester.AutoTest(0x1E674000, (cpu, maddr) => {
			});
			// frintx S8, S8
			InsnTester.AutoTest(0x1E274108, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Madd {
		[Fact]
		public void Madd() {
			// madd W0, W1, W1, W0
			InsnTester.AutoTest(0x1B010020, (cpu, maddr) => {
			});
			// madd X16, X10, X16, X15
			InsnTester.AutoTest(0x9B103D50, (cpu, maddr) => {
			});
			// madd X9, X26, X27, X23
			InsnTester.AutoTest(0x9B1B5F49, (cpu, maddr) => {
			});
			// madd X21, X20, X22, X28
			InsnTester.AutoTest(0x9B167295, (cpu, maddr) => {
			});
			// madd W11, W8, W26, W10
			InsnTester.AutoTest(0x1B1A290B, (cpu, maddr) => {
			});
			// madd X9, X13, X9, X14
			InsnTester.AutoTest(0x9B0939A9, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcmp {
		[Fact]
		public void Fcmp() {
			// fcmp S1, S0
			InsnTester.AutoTest(0x1E202020, (cpu, maddr) => {
			});
			// fcmp D11, #0.0
			InsnTester.AutoTest(0x1E602168, (cpu, maddr) => {
			});
			// fcmp S27, S25
			InsnTester.AutoTest(0x1E392360, (cpu, maddr) => {
			});
			// fcmp S17, S18
			InsnTester.AutoTest(0x1E322220, (cpu, maddr) => {
			});
			// fcmp S13, S11
			InsnTester.AutoTest(0x1E2B21A0, (cpu, maddr) => {
			});
			// fcmp S5, S23
			InsnTester.AutoTest(0x1E3720A0, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdrbPostIndex {
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
			// ldrb W1, [X0], #1
			InsnTester.AutoTest(0x38401401, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrb W1, [X0], #8
			InsnTester.AutoTest(0x38408401, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrb W8, [X22], #1
			InsnTester.AutoTest(0x384016C8, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldrb W16, [X12], #1
			InsnTester.AutoTest(0x38401590, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
		}
	}

	public class AutoTest_Ldrsb {
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
			// ldrsb W6, [X20, X8]
			InsnTester.AutoTest(0x38E86A86, (cpu, maddr) => {
				cpu.X[20] = maddr;
				cpu.X[8] = 0x10;
			});
			// ldrsb W18, [X17, #9]
			InsnTester.AutoTest(0x39C02632, (cpu, maddr) => {
				cpu.X[17] = maddr;
			});
			// ldrsb W9, [X20]
			InsnTester.AutoTest(0x39C00289, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
			// ldrsb W8, [X4]
			InsnTester.AutoTest(0x39C00088, (cpu, maddr) => {
				cpu.X[4] = maddr;
			});
		}
	}

	public class AutoTest_Fdiv {
		[Fact]
		public void Fdiv() {
			// fdiv S5, S2, S0
			InsnTester.AutoTest(0x1E201845, (cpu, maddr) => {
			});
			// fdiv S21, S22, S21
			InsnTester.AutoTest(0x1E351AD5, (cpu, maddr) => {
			});
			// fdiv S0, S2, S4
			InsnTester.AutoTest(0x1E241840, (cpu, maddr) => {
			});
			// fdiv S1, S8, S2
			InsnTester.AutoTest(0x1E221901, (cpu, maddr) => {
			});
			// fdiv S11, S0, S8
			InsnTester.AutoTest(0x1E28180B, (cpu, maddr) => {
			});
			// fdiv S7, S7, S19
			InsnTester.AutoTest(0x1E3318E7, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldxr {
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
			// ldxr W9, [X27]
			InsnTester.AutoTest(0x885F7F69, (cpu, maddr) => {
				cpu.X[27] = maddr;
			});
			// ldxr W9, [X25]
			InsnTester.AutoTest(0x885F7F29, (cpu, maddr) => {
				cpu.X[25] = maddr;
			});
			// ldxr W16, [X9]
			InsnTester.AutoTest(0x885F7D30, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldxr WZR, [X8]
			InsnTester.AutoTest(0x885F7D1F, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
		}
	}

	public class AutoTest_Prfm {
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
			// prfm PLDL1KEEP, [X9, #0x40]
			InsnTester.AutoTest(0xF9802120, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// prfm PLDL2STRM, [X10]
			InsnTester.AutoTest(0xF9800143, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// prfm PSTL2STRM, [X8]
			InsnTester.AutoTest(0xF9800113, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// prfm PLDL2STRM, [X11]
			InsnTester.AutoTest(0xF9800163, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
		}
	}

	public class AutoTest_LdrshPreIndex {
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
			// ldrsh W12, [X11, #2]!
			InsnTester.AutoTest(0x78C02D6C, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrsh W12, [X8, #-2]!
			InsnTester.AutoTest(0x78DFED0C, (cpu, maddr) => {
				cpu.X[8] = maddr;
			});
			// ldrsh W8, [X22, #4]!
			InsnTester.AutoTest(0x78C04EC8, (cpu, maddr) => {
				cpu.X[22] = maddr;
			});
			// ldrsh W13, [X9, #-2]!
			InsnTester.AutoTest(0x78DFED2D, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
		}
	}

	public class AutoTest_Dmb {
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
	}

	public class AutoTest_And {
		[Fact]
		public void And() {
			// and W2, W8, #1
			InsnTester.AutoTest(0x12000102, (cpu, maddr) => {
			});
			// and X26, X26, #0xFFFFFFFFFFFFFFFE
			InsnTester.AutoTest(0x927FFB5A, (cpu, maddr) => {
			});
			// and V3.16B, V3.16B, V7.16B
			InsnTester.AutoTest(0x4E271C63, (cpu, maddr) => {
			});
			// and X12, X13, #3
			InsnTester.AutoTest(0x924005AC, (cpu, maddr) => {
			});
			// and W11, W21, #0x3FFF
			InsnTester.AutoTest(0x120036AB, (cpu, maddr) => {
			});
			// and W28, W9, #0x7FFFFFFF
			InsnTester.AutoTest(0x1200793C, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Pmull {
		[Fact]
		public void Pmull() {
			// pmull V0.1Q, V1.1D, V0.1D
			InsnTester.AutoTest(0x0EE0E020, (cpu, maddr) => {
			});
			// pmull V31.1Q, V19.1D, V1.1D
			InsnTester.AutoTest(0x0EE1E27F, (cpu, maddr) => {
			});
			// pmull V22.1Q, V18.1D, V8.1D
			InsnTester.AutoTest(0x0EE8E256, (cpu, maddr) => {
			});
			// pmull V0.1Q, V0.1D, V7.1D
			InsnTester.AutoTest(0x0EE7E000, (cpu, maddr) => {
			});
			// pmull V29.1Q, V17.1D, V2.1D
			InsnTester.AutoTest(0x0EE2E23D, (cpu, maddr) => {
			});
			// pmull V4.1Q, V4.1D, V1.1D
			InsnTester.AutoTest(0x0EE1E084, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cmhi {
		[Fact]
		public void Cmhi() {
			// cmhi V2.8H, V2.8H, V0.8H
			InsnTester.AutoTest(0x6E603442, (cpu, maddr) => {
			});
			// cmhi V3.8H, V3.8H, V0.8H
			InsnTester.AutoTest(0x6E603463, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Shrn {
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
	}

	public class AutoTest_Ins {
		[Fact]
		public void Ins() {
			// ins V0.S[0], W8
			InsnTester.AutoTest(0x4E041D00, (cpu, maddr) => {
			});
			// ins V31.S[1], V24.S[1]
			InsnTester.AutoTest(0x6E0C271F, (cpu, maddr) => {
			});
			// ins V21.S[2], V16.S[0]
			InsnTester.AutoTest(0x6E140615, (cpu, maddr) => {
			});
			// ins V28.S[3], V11.S[0]
			InsnTester.AutoTest(0x6E1C057C, (cpu, maddr) => {
			});
			// ins V12.S[1], W17
			InsnTester.AutoTest(0x4E0C1E2C, (cpu, maddr) => {
			});
			// ins V3.S[3], V21.S[0]
			InsnTester.AutoTest(0x6E1C06A3, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Dc {
		[Fact]
		public void Dc() {
			// dc CVAU, X11
			InsnTester.AutoTest(0xD50B7B2B, (cpu, maddr) => {
			});
			// dc CIVAC, X10
			InsnTester.AutoTest(0xD50B7E2A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ld1PostIndex {
		[Fact]
		public void Ld1PostIndex() {
			// ld1 {V0.S}[0], [X8], #4
			InsnTester.AutoTest(0x0DDF8100, (cpu, maddr) => {
			});
			// ld1 {V16.S}[3], [X21], #4
			InsnTester.AutoTest(0x4DDF92B0, (cpu, maddr) => {
			});
			// ld1 {V2.S}[3], [X10], #4
			InsnTester.AutoTest(0x4DDF9142, (cpu, maddr) => {
			});
			// ld1 {V4.S}[0], [X8], #4
			InsnTester.AutoTest(0x0DDF8104, (cpu, maddr) => {
			});
			// ld1 {V5.S}[1], [X10], #4
			InsnTester.AutoTest(0x0DDF9145, (cpu, maddr) => {
			});
			// ld1 {V4.S}[2], [X13], #4
			InsnTester.AutoTest(0x4DDF81A4, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcmlt {
		[Fact]
		public void Fcmlt() {
			// fcmlt V19.4S, V7.4S, #0.0
			InsnTester.AutoTest(0x4EA0E8F3, (cpu, maddr) => {
			});
			// fcmlt V27.4S, V29.4S, #0.0
			InsnTester.AutoTest(0x4EA0EBBB, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Csetm {
		[Fact]
		public void Csetm() {
			// csetm W0, HI
			InsnTester.AutoTest(0x5A9F93E0, (cpu, maddr) => {
			});
			// csetm W23, LE
			InsnTester.AutoTest(0x5A9FC3F7, (cpu, maddr) => {
			});
			// csetm W0, NE
			InsnTester.AutoTest(0x5A9F03E0, (cpu, maddr) => {
			});
			// csetm X0, GT
			InsnTester.AutoTest(0xDA9FD3E0, (cpu, maddr) => {
			});
			// csetm W11, EQ
			InsnTester.AutoTest(0x5A9F13EB, (cpu, maddr) => {
			});
			// csetm W0, LO
			InsnTester.AutoTest(0x5A9F23E0, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdrPostIndex {
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
			// ldr W9, [X2], #4
			InsnTester.AutoTest(0xB8404449, (cpu, maddr) => {
				cpu.X[2] = maddr;
			});
			// ldr W17, [X13], #4
			InsnTester.AutoTest(0xB84045B1, (cpu, maddr) => {
				cpu.X[13] = maddr;
			});
			// ldr W11, [X26], #4
			InsnTester.AutoTest(0xB840474B, (cpu, maddr) => {
				cpu.X[26] = maddr;
			});
			// ldr X8, [X20], #0x20
			InsnTester.AutoTest(0xF8420688, (cpu, maddr) => {
				cpu.X[20] = maddr;
			});
		}
	}

	public class AutoTest_Fmls {
		[Fact]
		public void Fmls() {
			// fmls V6.4S, V2.4S, V0.4S
			InsnTester.AutoTest(0x4EA0CC46, (cpu, maddr) => {
			});
			// fmls V27.4S, V26.4S, V28.S[0]
			InsnTester.AutoTest(0x4F9C535B, (cpu, maddr) => {
			});
			// fmls V3.4S, V6.4S, V16.4S
			InsnTester.AutoTest(0x4EB0CCC3, (cpu, maddr) => {
			});
			// fmls V24.4S, V7.4S, V22.S[1]
			InsnTester.AutoTest(0x4FB650F8, (cpu, maddr) => {
			});
			// fmls V24.4S, V6.4S, V22.S[2]
			InsnTester.AutoTest(0x4F9658D8, (cpu, maddr) => {
			});
			// fmls V3.4S, V1.4S, V0.S[2]
			InsnTester.AutoTest(0x4F805823, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fabs {
		[Fact]
		public void Fabs() {
			// fabs S2, S0
			InsnTester.AutoTest(0x1E20C002, (cpu, maddr) => {
			});
			// fabs V25.4S, V29.4S
			InsnTester.AutoTest(0x4EA0FBB9, (cpu, maddr) => {
			});
			// fabs S17, S7
			InsnTester.AutoTest(0x1E20C0F1, (cpu, maddr) => {
			});
			// fabs D1, D9
			InsnTester.AutoTest(0x1E60C121, (cpu, maddr) => {
			});
			// fabs D17, D17
			InsnTester.AutoTest(0x1E60C231, (cpu, maddr) => {
			});
			// fabs D2, D0
			InsnTester.AutoTest(0x1E60C002, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldaxrh {
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
	}

	public class AutoTest_Csel {
		[Fact]
		public void Csel() {
			// csel W0, W2, W0, LO
			InsnTester.AutoTest(0x1A803040, (cpu, maddr) => {
			});
			// csel W16, W16, W18, HI
			InsnTester.AutoTest(0x1A928210, (cpu, maddr) => {
			});
			// csel W12, WZR, W13, LT
			InsnTester.AutoTest(0x1A8DB3EC, (cpu, maddr) => {
			});
			// csel W9, WZR, W12, LT
			InsnTester.AutoTest(0x1A8CB3E9, (cpu, maddr) => {
			});
			// csel W6, W4, W25, GE
			InsnTester.AutoTest(0x1A99A086, (cpu, maddr) => {
			});
			// csel W26, W9, W8, HI
			InsnTester.AutoTest(0x1A88813A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cinc {
		[Fact]
		public void Cinc() {
			// cinc W8, W0, EQ
			InsnTester.AutoTest(0x1A801408, (cpu, maddr) => {
			});
			// cinc W12, W10, LT
			InsnTester.AutoTest(0x1A8AA54C, (cpu, maddr) => {
			});
			// cinc W14, W18, NE
			InsnTester.AutoTest(0x1A92064E, (cpu, maddr) => {
			});
			// cinc X8, X20, EQ
			InsnTester.AutoTest(0x9A941688, (cpu, maddr) => {
			});
			// cinc W25, W9, NE
			InsnTester.AutoTest(0x1A890539, (cpu, maddr) => {
			});
			// cinc W13, W12, NE
			InsnTester.AutoTest(0x1A8C058D, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cset {
		[Fact]
		public void Cset() {
			// cset W0, MI
			InsnTester.AutoTest(0x1A9F57E0, (cpu, maddr) => {
			});
			// cset W28, GT
			InsnTester.AutoTest(0x1A9FD7FC, (cpu, maddr) => {
			});
			// cset W9, NE
			InsnTester.AutoTest(0x1A9F07E9, (cpu, maddr) => {
			});
			// cset W6, LO
			InsnTester.AutoTest(0x1A9F27E6, (cpu, maddr) => {
			});
			// cset W8, LT
			InsnTester.AutoTest(0x1A9FA7E8, (cpu, maddr) => {
			});
			// cset W8, GT
			InsnTester.AutoTest(0x1A9FD7E8, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fmla {
		[Fact]
		public void Fmla() {
			// fmla V3.4S, V1.4S, V0.4S
			InsnTester.AutoTest(0x4E20CC23, (cpu, maddr) => {
			});
			// fmla V22.4S, V20.4S, V16.S[2]
			InsnTester.AutoTest(0x4F901A96, (cpu, maddr) => {
			});
			// fmla V0.4S, V2.4S, V7.S[1]
			InsnTester.AutoTest(0x4FA71040, (cpu, maddr) => {
			});
			// fmla V1.4S, V3.4S, V2.S[3]
			InsnTester.AutoTest(0x4FA21861, (cpu, maddr) => {
			});
			// fmla V0.4S, V2.4S, V17.S[2]
			InsnTester.AutoTest(0x4F911840, (cpu, maddr) => {
			});
			// fmla V2.4S, V5.4S, V0.S[2]
			InsnTester.AutoTest(0x4F8018A2, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Frecps {
		[Fact]
		public void Frecps() {
			// frecps V1.4S, V2.4S, V1.4S
			InsnTester.AutoTest(0x4E21FC41, (cpu, maddr) => {
			});
			// frecps V30.4S, V31.4S, V30.4S
			InsnTester.AutoTest(0x4E3EFFFE, (cpu, maddr) => {
			});
			// frecps V20.4S, V19.4S, V18.4S
			InsnTester.AutoTest(0x4E32FE74, (cpu, maddr) => {
			});
			// frecps V21.4S, V17.4S, V16.4S
			InsnTester.AutoTest(0x4E30FE35, (cpu, maddr) => {
			});
			// frecps V6.4S, V2.4S, V1.4S
			InsnTester.AutoTest(0x4E21FC46, (cpu, maddr) => {
			});
			// frecps V8.4S, V31.4S, V30.4S
			InsnTester.AutoTest(0x4E3EFFE8, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Cinv {
		[Fact]
		public void Cinv() {
			// cinv W0, W8, NE
			InsnTester.AutoTest(0x5A880100, (cpu, maddr) => {
			});
			// cinv W10, W10, LT
			InsnTester.AutoTest(0x5A8AA14A, (cpu, maddr) => {
			});
			// cinv W11, W11, LT
			InsnTester.AutoTest(0x5A8BA16B, (cpu, maddr) => {
			});
			// cinv W1, W8, EQ
			InsnTester.AutoTest(0x5A881101, (cpu, maddr) => {
			});
			// cinv W8, W8, EQ
			InsnTester.AutoTest(0x5A881108, (cpu, maddr) => {
			});
			// cinv W8, W8, GE
			InsnTester.AutoTest(0x5A88B108, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Mneg {
		[Fact]
		public void Mneg() {
			// mneg X8, X0, X8
			InsnTester.AutoTest(0x9B08FC08, (cpu, maddr) => {
			});
			// mneg X15, X15, X12
			InsnTester.AutoTest(0x9B0CFDEF, (cpu, maddr) => {
			});
			// mneg X8, X15, X8
			InsnTester.AutoTest(0x9B08FDE8, (cpu, maddr) => {
			});
			// mneg X16, X18, X0
			InsnTester.AutoTest(0x9B00FE50, (cpu, maddr) => {
			});
			// mneg X17, X15, X12
			InsnTester.AutoTest(0x9B0CFDF1, (cpu, maddr) => {
			});
			// mneg X13, X10, X8
			InsnTester.AutoTest(0x9B08FD4D, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_LdrswPostIndex {
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
			// ldrsw X12, [X9], #4
			InsnTester.AutoTest(0xB880452C, (cpu, maddr) => {
				cpu.X[9] = maddr;
			});
			// ldrsw X19, [X11], #0xFFFFFFFFFFFFFFFC
			InsnTester.AutoTest(0xB89FC573, (cpu, maddr) => {
				cpu.X[11] = maddr;
			});
			// ldrsw X3, [X16], #4
			InsnTester.AutoTest(0xB8804603, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldrsw X23, [X21], #4
			InsnTester.AutoTest(0xB88046B7, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
		}
	}

	public class AutoTest_Pmull2 {
		[Fact]
		public void Pmull2() {
			// pmull2 V0.1Q, V0.2D, V1.2D
			InsnTester.AutoTest(0x4EE1E000, (cpu, maddr) => {
			});
			// pmull2 V26.1Q, V18.2D, V8.2D
			InsnTester.AutoTest(0x4EE8E25A, (cpu, maddr) => {
			});
			// pmull2 V16.1Q, V16.2D, V3.2D
			InsnTester.AutoTest(0x4EE3E210, (cpu, maddr) => {
			});
			// pmull2 V19.1Q, V19.2D, V1.2D
			InsnTester.AutoTest(0x4EE1E273, (cpu, maddr) => {
			});
			// pmull2 V25.1Q, V17.2D, V2.2D
			InsnTester.AutoTest(0x4EE2E239, (cpu, maddr) => {
			});
			// pmull2 V17.1Q, V17.2D, V2.2D
			InsnTester.AutoTest(0x4EE2E231, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fminnm {
		[Fact]
		public void Fminnm() {
			// fminnm S1, S1, S0
			InsnTester.AutoTest(0x1E207821, (cpu, maddr) => {
			});
			// fminnm S24, S23, S24
			InsnTester.AutoTest(0x1E387AF8, (cpu, maddr) => {
			});
			// fminnm S2, S0, S1
			InsnTester.AutoTest(0x1E217802, (cpu, maddr) => {
			});
			// fminnm S0, S0, S1
			InsnTester.AutoTest(0x1E217800, (cpu, maddr) => {
			});
			// fminnm S1, S0, S9
			InsnTester.AutoTest(0x1E297801, (cpu, maddr) => {
			});
			// fminnm S1, S0, S2
			InsnTester.AutoTest(0x1E227801, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sxtw {
		[Fact]
		public void Sxtw() {
			// sxtw X1, W1
			InsnTester.AutoTest(0x93407C21, (cpu, maddr) => {
			});
			// sxtw X24, W29
			InsnTester.AutoTest(0x93407FB8, (cpu, maddr) => {
			});
			// sxtw X18, W18
			InsnTester.AutoTest(0x93407E52, (cpu, maddr) => {
			});
			// sxtw X4, W2
			InsnTester.AutoTest(0x93407C44, (cpu, maddr) => {
			});
			// sxtw X20, W0
			InsnTester.AutoTest(0x93407C14, (cpu, maddr) => {
			});
			// sxtw X1, W22
			InsnTester.AutoTest(0x93407EC1, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcmgt {
		[Fact]
		public void Fcmgt() {
			// fcmgt V1.4S, V3.4S, V1.4S
			InsnTester.AutoTest(0x6EA1E461, (cpu, maddr) => {
			});
			// fcmgt V30.4S, V17.4S, V28.4S
			InsnTester.AutoTest(0x6EBCE63E, (cpu, maddr) => {
			});
			// fcmgt V16.4S, V3.4S, V5.4S
			InsnTester.AutoTest(0x6EA5E470, (cpu, maddr) => {
			});
			// fcmgt V26.4S, V30.4S, V5.4S
			InsnTester.AutoTest(0x6EA5E7DA, (cpu, maddr) => {
			});
			// fcmgt V4.4S, V4.4S, V5.4S
			InsnTester.AutoTest(0x6EA5E484, (cpu, maddr) => {
			});
			// fcmgt V10.4S, V23.4S, V7.4S
			InsnTester.AutoTest(0x6EA7E6EA, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Addv {
		[Fact]
		public void Addv() {
			// addv B1, V0.8B
			InsnTester.AutoTest(0x0E31B801, (cpu, maddr) => {
			});
			// addv S17, V17.4S
			InsnTester.AutoTest(0x4EB1BA31, (cpu, maddr) => {
			});
			// addv B0, V0.8B
			InsnTester.AutoTest(0x0E31B800, (cpu, maddr) => {
			});
			// addv S5, V5.4S
			InsnTester.AutoTest(0x4EB1B8A5, (cpu, maddr) => {
			});
			// addv S16, V16.4S
			InsnTester.AutoTest(0x4EB1BA10, (cpu, maddr) => {
			});
			// addv S6, V6.4S
			InsnTester.AutoTest(0x4EB1B8C6, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Bic {
		[Fact]
		public void Bic() {
			// bic W8, W1, W8
			InsnTester.AutoTest(0x0A280028, (cpu, maddr) => {
			});
			// bic V30.16B, V30.16B, V27.16B
			InsnTester.AutoTest(0x4E7B1FDE, (cpu, maddr) => {
			});
			// bic W14, W17, W14, ASR #31
			InsnTester.AutoTest(0x0AAE7E2E, (cpu, maddr) => {
			});
			// bic W11, W26, W12, ASR #31
			InsnTester.AutoTest(0x0AAC7F4B, (cpu, maddr) => {
			});
			// bic X11, X11, X8
			InsnTester.AutoTest(0x8A28016B, (cpu, maddr) => {
			});
			// bic W8, W26, W11, ASR #31
			InsnTester.AutoTest(0x0AAB7F48, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Bsl {
		[Fact]
		public void Bsl() {
			// bsl V5.8B, V3.8B, V0.8B
			InsnTester.AutoTest(0x2E601C65, (cpu, maddr) => {
			});
			// bsl V27.16B, V30.16B, V31.16B
			InsnTester.AutoTest(0x6E7F1FDB, (cpu, maddr) => {
			});
			// bsl V6.16B, V1.16B, V0.16B
			InsnTester.AutoTest(0x6E601C26, (cpu, maddr) => {
			});
			// bsl V26.16B, V31.16B, V8.16B
			InsnTester.AutoTest(0x6E681FFA, (cpu, maddr) => {
			});
			// bsl V3.16B, V0.16B, V4.16B
			InsnTester.AutoTest(0x6E641C03, (cpu, maddr) => {
			});
			// bsl V12.16B, V25.16B, V24.16B
			InsnTester.AutoTest(0x6E781F2C, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcmge {
		[Fact]
		public void Fcmge() {
			// fcmge V4.4S, V3.4S, #0.0
			InsnTester.AutoTest(0x6EA0C864, (cpu, maddr) => {
			});
			// fcmge V24.4S, V24.4S, V28.4S
			InsnTester.AutoTest(0x6E3CE718, (cpu, maddr) => {
			});
			// fcmge V2.4S, V1.4S, V16.4S
			InsnTester.AutoTest(0x6E30E422, (cpu, maddr) => {
			});
			// fcmge V2.4S, V7.4S, V2.4S
			InsnTester.AutoTest(0x6E22E4E2, (cpu, maddr) => {
			});
			// fcmge V0.4S, V0.4S, V4.4S
			InsnTester.AutoTest(0x6E24E400, (cpu, maddr) => {
			});
			// fcmge V27.4S, V25.4S, V8.4S
			InsnTester.AutoTest(0x6E28E73B, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Msub {
		[Fact]
		public void Msub() {
			// msub W0, W2, W0, W1
			InsnTester.AutoTest(0x1B008440, (cpu, maddr) => {
			});
			// msub W15, W18, W15, W19
			InsnTester.AutoTest(0x1B0FCE4F, (cpu, maddr) => {
			});
			// msub W10, W9, W12, W15
			InsnTester.AutoTest(0x1B0CBD2A, (cpu, maddr) => {
			});
			// msub W8, W8, W26, W27
			InsnTester.AutoTest(0x1B1AED08, (cpu, maddr) => {
			});
			// msub W15, W16, W21, W14
			InsnTester.AutoTest(0x1B15BA0F, (cpu, maddr) => {
			});
			// msub W8, W9, W8, W25
			InsnTester.AutoTest(0x1B08E528, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Umaddl {
		[Fact]
		public void Umaddl() {
			// umaddl X8, W3, W1, X8
			InsnTester.AutoTest(0x9BA12068, (cpu, maddr) => {
			});
			// umaddl X22, W10, W21, X24
			InsnTester.AutoTest(0x9BB56156, (cpu, maddr) => {
			});
			// umaddl X8, W8, W9, X0
			InsnTester.AutoTest(0x9BA90108, (cpu, maddr) => {
			});
			// umaddl X12, W12, W24, X11
			InsnTester.AutoTest(0x9BB82D8C, (cpu, maddr) => {
			});
			// umaddl X10, W11, W12, X10
			InsnTester.AutoTest(0x9BAC296A, (cpu, maddr) => {
			});
			// umaddl X25, W21, W8, X22
			InsnTester.AutoTest(0x9BA85AB9, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ldrsh {
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
			// ldrsh X17, [X16]
			InsnTester.AutoTest(0x79800211, (cpu, maddr) => {
				cpu.X[16] = maddr;
			});
			// ldrsh W21, [X19]
			InsnTester.AutoTest(0x79C00275, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldrsh W3, [X20, X23, LSL #1]
			InsnTester.AutoTest(0x78F77A83, (cpu, maddr) => {
				cpu.X[20] = maddr;
				cpu.X[23] = 0x10;
			});
			// ldrsh W13, [X19, #0x14]
			InsnTester.AutoTest(0x79C02A6D, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
		}
	}

	public class AutoTest_Sbfiz {
		[Fact]
		public void Sbfiz() {
			// sbfiz X8, X8, #1, #8
			InsnTester.AutoTest(0x937F1D08, (cpu, maddr) => {
			});
			// sbfiz X13, X13, #0x20, #0x20
			InsnTester.AutoTest(0x93607DAD, (cpu, maddr) => {
			});
			// sbfiz X13, X1, #2, #0x20
			InsnTester.AutoTest(0x937E7C2D, (cpu, maddr) => {
			});
			// sbfiz X21, X9, #3, #0x20
			InsnTester.AutoTest(0x937D7D35, (cpu, maddr) => {
			});
			// sbfiz X19, X19, #2, #0x20
			InsnTester.AutoTest(0x937E7E73, (cpu, maddr) => {
			});
			// sbfiz X18, X9, #3, #0x20
			InsnTester.AutoTest(0x937D7D32, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Umull {
		[Fact]
		public void Umull() {
			// umull X4, W8, W9
			InsnTester.AutoTest(0x9BA97D04, (cpu, maddr) => {
			});
			// umull X11, W11, W10
			InsnTester.AutoTest(0x9BAA7D6B, (cpu, maddr) => {
			});
			// umull X21, W21, W17
			InsnTester.AutoTest(0x9BB17EB5, (cpu, maddr) => {
			});
			// umull X8, W23, W24
			InsnTester.AutoTest(0x9BB87EE8, (cpu, maddr) => {
			});
			// umull X8, W2, W8
			InsnTester.AutoTest(0x9BA87C48, (cpu, maddr) => {
			});
			// umull X1, W24, W9
			InsnTester.AutoTest(0x9BA97F01, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Sdiv {
		[Fact]
		public void Sdiv() {
			// sdiv W8, W2, W1
			InsnTester.AutoTest(0x1AC10C48, (cpu, maddr) => {
			});
			// sdiv W12, W13, W12
			InsnTester.AutoTest(0x1ACC0DAC, (cpu, maddr) => {
			});
			// sdiv W9, W8, W21
			InsnTester.AutoTest(0x1AD50D09, (cpu, maddr) => {
			});
			// sdiv X18, X17, X13
			InsnTester.AutoTest(0x9ACD0E32, (cpu, maddr) => {
			});
			// sdiv X11, X12, X11
			InsnTester.AutoTest(0x9ACB0D8B, (cpu, maddr) => {
			});
			// sdiv W12, W12, W26
			InsnTester.AutoTest(0x1ADA0D8C, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcvtzu {
		[Fact]
		public void Fcvtzu() {
			// fcvtzu W3, S0
			InsnTester.AutoTest(0x1E390003, (cpu, maddr) => {
			});
			// fcvtzu W16, S0, #0x10
			InsnTester.AutoTest(0x1E19C010, (cpu, maddr) => {
			});
			// fcvtzu W5, S12
			InsnTester.AutoTest(0x1E390185, (cpu, maddr) => {
			});
			// fcvtzu W4, D0
			InsnTester.AutoTest(0x1E790004, (cpu, maddr) => {
			});
			// fcvtzu W24, S0
			InsnTester.AutoTest(0x1E390018, (cpu, maddr) => {
			});
			// fcvtzu W26, S0
			InsnTester.AutoTest(0x1E39001A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Rbit {
		[Fact]
		public void Rbit() {
			// rbit X8, X0
			InsnTester.AutoTest(0xDAC00008, (cpu, maddr) => {
			});
			// rbit X11, X12
			InsnTester.AutoTest(0xDAC0018B, (cpu, maddr) => {
			});
			// rbit W9, W1
			InsnTester.AutoTest(0x5AC00029, (cpu, maddr) => {
			});
			// rbit X8, X25
			InsnTester.AutoTest(0xDAC00328, (cpu, maddr) => {
			});
			// rbit X8, X1
			InsnTester.AutoTest(0xDAC00028, (cpu, maddr) => {
			});
			// rbit W9, W9
			InsnTester.AutoTest(0x5AC00129, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcvtpu {
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
	}

	public class AutoTest_Eor {
		[Fact]
		public void Eor() {
			// eor W8, W1, W0
			InsnTester.AutoTest(0x4A000028, (cpu, maddr) => {
			});
			// eor X15, X12, #0x7FFF000000000000
			InsnTester.AutoTest(0xD250398F, (cpu, maddr) => {
			});
			// eor X11, X11, X11, LSR #47
			InsnTester.AutoTest(0xCA4BBD6B, (cpu, maddr) => {
			});
			// eor W13, W12, W11
			InsnTester.AutoTest(0x4A0B018D, (cpu, maddr) => {
			});
			// eor W13, W14, #1
			InsnTester.AutoTest(0x520001CD, (cpu, maddr) => {
			});
			// eor W10, W10, W10, LSR #30
			InsnTester.AutoTest(0x4A4A794A, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Ext {
		[Fact]
		public void Ext() {
			// ext V1.8B, V2.8B, V3.8B, #4
			InsnTester.AutoTest(0x2E032041, (cpu, maddr) => {
			});
			// ext V26.16B, V21.16B, V21.16B, #8
			InsnTester.AutoTest(0x6E1542BA, (cpu, maddr) => {
			});
			// ext V4.16B, V2.16B, V2.16B, #8
			InsnTester.AutoTest(0x6E024044, (cpu, maddr) => {
			});
			// ext V3.16B, V2.16B, V3.16B, #8
			InsnTester.AutoTest(0x6E034043, (cpu, maddr) => {
			});
			// ext V12.16B, V16.16B, V16.16B, #8
			InsnTester.AutoTest(0x6E10420C, (cpu, maddr) => {
			});
			// ext V17.16B, V5.16B, V5.16B, #8
			InsnTester.AutoTest(0x6E0540B1, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fnmul {
		[Fact]
		public void Fnmul() {
			// fnmul S2, S2, S0
			InsnTester.AutoTest(0x1E208842, (cpu, maddr) => {
			});
			// fnmul S20, S23, S21
			InsnTester.AutoTest(0x1E358AF4, (cpu, maddr) => {
			});
			// fnmul S18, S18, S2
			InsnTester.AutoTest(0x1E228A52, (cpu, maddr) => {
			});
			// fnmul S20, S15, S4
			InsnTester.AutoTest(0x1E2489F4, (cpu, maddr) => {
			});
			// fnmul S0, S3, S8
			InsnTester.AutoTest(0x1E288860, (cpu, maddr) => {
			});
			// fnmul S6, S10, S1
			InsnTester.AutoTest(0x1E218946, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fmaxnm {
		[Fact]
		public void Fmaxnm() {
			// fmaxnm S0, S3, S0
			InsnTester.AutoTest(0x1E206860, (cpu, maddr) => {
			});
			// fmaxnm S18, S18, S20
			InsnTester.AutoTest(0x1E346A52, (cpu, maddr) => {
			});
			// fmaxnm S4, S0, S2
			InsnTester.AutoTest(0x1E226804, (cpu, maddr) => {
			});
			// fmaxnm S13, S0, S1
			InsnTester.AutoTest(0x1E21680D, (cpu, maddr) => {
			});
			// fmaxnm S9, S8, S12
			InsnTester.AutoTest(0x1E2C6909, (cpu, maddr) => {
			});
			// fmaxnm S1, S8, S1
			InsnTester.AutoTest(0x1E216901, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Fcvtps {
		[Fact]
		public void Fcvtps() {
			// fcvtps W8, S0
			InsnTester.AutoTest(0x1E280008, (cpu, maddr) => {
			});
			// fcvtps W15, S17
			InsnTester.AutoTest(0x1E28022F, (cpu, maddr) => {
			});
			// fcvtps W8, S2
			InsnTester.AutoTest(0x1E280048, (cpu, maddr) => {
			});
			// fcvtps W12, S1
			InsnTester.AutoTest(0x1E28002C, (cpu, maddr) => {
			});
			// fcvtps W11, S1
			InsnTester.AutoTest(0x1E28002B, (cpu, maddr) => {
			});
			// fcvtps W18, S6
			InsnTester.AutoTest(0x1E2800D2, (cpu, maddr) => {
			});
		}
	}

	public class AutoTest_Smlal {
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
	}

	public class AutoTest_Ldpsw {
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
			// ldpsw X15, X16, [X10, #8]
			InsnTester.AutoTest(0x6941414F, (cpu, maddr) => {
				cpu.X[10] = maddr;
			});
			// ldpsw X11, X12, [X0, #0xF0]
			InsnTester.AutoTest(0x695E300B, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldpsw X8, X19, [X21]
			InsnTester.AutoTest(0x69404EA8, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
			// ldpsw X27, X30, [X12, #0x14]
			InsnTester.AutoTest(0x6942F99B, (cpu, maddr) => {
				cpu.X[12] = maddr;
			});
		}
	}

	public class AutoTest_Ldrsw {
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
			// ldrsw X8, [X19, #0x158]
			InsnTester.AutoTest(0xB9815A68, (cpu, maddr) => {
				cpu.X[19] = maddr;
			});
			// ldrsw X8, [X0, #0x48]
			InsnTester.AutoTest(0xB9804808, (cpu, maddr) => {
				cpu.X[0] = maddr;
			});
			// ldrsw X15, [X14, #0x47C]
			InsnTester.AutoTest(0xB9847DCF, (cpu, maddr) => {
				cpu.X[14] = maddr;
			});
			// ldrsw X9, [X21, #0x28]
			InsnTester.AutoTest(0xB9802AA9, (cpu, maddr) => {
				cpu.X[21] = maddr;
			});
		}
	}

	public class AutoTest_Tbl {
		[Fact]
		public void Tbl() {
			// tbl V4.8B, {V7.16B}, V1.8B
			InsnTester.AutoTest(0x0E0100E4, (cpu, maddr) => {
			});
			// tbl V26.8B, {V26.16B, V27.16B}, V31.8B
			InsnTester.AutoTest(0x0E1F235A, (cpu, maddr) => {
			});
			// tbl V17.8B, {V17.16B}, V24.8B
			InsnTester.AutoTest(0x0E180231, (cpu, maddr) => {
			});
			// tbl V8.8B, {V29.16B}, V7.8B
			InsnTester.AutoTest(0x0E0703A8, (cpu, maddr) => {
			});
			// tbl V12.8B, {V8.16B, V9.16B}, V18.8B
			InsnTester.AutoTest(0x0E12210C, (cpu, maddr) => {
			});
			// tbl V23.8B, {V27.16B}, V17.8B
			InsnTester.AutoTest(0x0E110377, (cpu, maddr) => {
			});
		}
	}

}
