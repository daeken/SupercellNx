#pragma warning disable 162, 219
using System;

namespace Cpu64 {
	public partial class BaseCpu {
		public unsafe string Disassemble(uint inst, ulong pc) {
			/* ADD-extended-register */
			if((inst & 0x7FE00000U) == 0x0B200000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var imm = (inst >> 10) & 0x7U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var extend = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "LSL", 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => "LSL", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
				return $"add {r1}{rd}, {r1}{rn}, {r2}{rm}, {extend} #{imm}";
			}
			/* ADD-immediate */
			if((inst & 0x7F800000U) == 0x11000000U) {
				var size = (inst >> 31) & 0x1U;
				var sh = (inst >> 22) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shift = (long) (((byte) (((sh) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : (0xC));
				var simm = (ushort) ((imm) << (int) (shift));
				return $"add {r}{rd}, {r}{rn}, #0x{imm:X}, LSL #{(shift < 0 ? $"-0x{-shift:X}" : $"0x{shift:X}")}";
			}
			/* ADD-shifted-register */
			if((inst & 0x7F200000U) == 0x0B000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => throw new NotImplementedException() });
				return $"add {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* ADDS-immediate */
			if((inst & 0x7F800000U) == 0x31000000U) {
				var size = (inst >> 31) & 0x1U;
				var sh = (inst >> 22) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shift = (long) (((byte) (((sh) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : (0xC));
				var simm = (ushort) ((imm) << (int) (shift));
				return $"adds {r}{rd}, {r}{rn}, #0x{imm:X}, LSL #{(shift < 0 ? $"-0x{-shift:X}" : $"0x{shift:X}")}";
			}
			/* ADRP */
			if((inst & 0x9F000000U) == 0x90000000U) {
				var immlo = (inst >> 29) & 0x3U;
				var immhi = (inst >> 5) & 0x7FFFFU;
				var rd = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>((ulong) ((ulong) ((ulong) (((ulong) ((ulong) (immhi))) << (int) (0xE))) | (ulong) ((ushort) (((ushort) ((ushort) (immlo))) << (int) (0xC)))), 33));
				var addr = (ulong) ((ulong) ((ulong) (((ulong) (((ulong) (pc)) >> (int) (0xC))) << (int) (0xC))) + (ulong) (imm));
				return $"adrp X{rd}, #0x{addr:X}";
			}
			/* AND-immediate */
			if((inst & 0x7F800000U) == 0x12000000U) {
				var size = (inst >> 31) & 0x1U;
				var up = (inst >> 22) & 0x1U;
				var immr = (inst >> 16) & 0x3FU;
				var imms = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (ulong) (MakeWMask(up, imms, immr, (long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x20) : (0x40)), 0x1));
				return $"and {r}{rd}, {r}{rn}, #0x{imm:X}";
			}
			/* ANDS-immediate */
			if((inst & 0x7F800000U) == 0x72000000U) {
				var size = (inst >> 31) & 0x1U;
				var up = (inst >> 22) & 0x1U;
				var immr = (inst >> 16) & 0x3FU;
				var imms = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (ulong) (MakeWMask(up, imms, immr, (long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x20) : (0x40)), 0x1));
				return $"ands {r}{rd}, {r}{rn}, #0x{imm:X}";
			}
			/* B */
			if((inst & 0xFC000000U) == 0x14000000U) {
				var imm = (inst >> 0) & 0x3FFFFFFU;
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28))));
				return $"b #0x{addr:X}";
			}
			/* B.cond */
			if((inst & 0xFF000010U) == 0x54000000U) {
				var imm = (inst >> 5) & 0x7FFFFU;
				var cond = (inst >> 0) & 0xFU;
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 21))));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"b.{condstr} #0x{addr:X}";
			}
			/* BFM */
			if((inst & 0x7F800000U) == 0x33000000U) {
				var size = (inst >> 31) & 0x1U;
				var N = (inst >> 22) & 0x1U;
				var immr = (inst >> 16) & 0x3FU;
				var imms = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"bfm {r}{rd}, {r}{rn}, #{immr}, #{imms}";
			}
			/* BIC */
			if((inst & 0x7F200000U) == 0x0A200000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"bic {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* BL */
			if((inst & 0xFC000000U) == 0x94000000U) {
				var imm = (inst >> 0) & 0x3FFFFFFU;
				var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (offset));
				return $"bl #0x{addr:X}";
			}
			/* BLR */
			if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
				var rn = (inst >> 5) & 0x1FU;
				return $"blr X{rn}";
			}
			/* BR */
			if((inst & 0xFFFFFC1FU) == 0xD61F0000U) {
				var rn = (inst >> 5) & 0x1FU;
				return $"br X{rn}";
			}
			/* CBNZ */
			if((inst & 0x7F000000U) == 0x35000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 5) & 0x7FFFFU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21))));
				return $"cbnz {r}{rs}, #0x{addr:X}";
			}
			/* CBZ */
			if((inst & 0x7F000000U) == 0x34000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 5) & 0x7FFFFU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21))));
				return $"cbz {r}{rs}, #0x{addr:X}";
			}
			/* CCMP-immediate */
			if((inst & 0x7FE00C10U) == 0x7A400800U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var nzcv = (inst >> 0) & 0xFU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"ccmp {r}{rn}, #{imm}, #{nzcv}, {condstr}";
			}
			/* CCMP-register */
			if((inst & 0x7FE00C10U) == 0x7A400000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var nzcv = (inst >> 0) & 0xFU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"ccmp {r}{rn}, {r}{rm}, #{nzcv}, {condstr}";
			}
			/* CLZ */
			if((inst & 0x7FFFFC00U) == 0x5AC01000U) {
				var size = (inst >> 31) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"clz {r}{rd}, {r}{rn}";
			}
			/* CSEL */
			if((inst & 0x7FE00C00U) == 0x1A800000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"csel {r}{rd}, {r}{rn}, {r}{rm}, {condstr}";
			}
			/* CSINC */
			if((inst & 0x7FE00C00U) == 0x1A800400U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"csinc {r}{rd}, {r}{rn}, {r}{rm}, {condstr}";
			}
			/* DUP-general */
			if((inst & 0xBFE0FC00U) == 0x0E000C00U) {
				var Q = (inst >> 30) & 0x1U;
				var imm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var size = ((byte) ((((byte) ((ulong) (imm) & (ulong) (0xF))) == (0x0)) ? 1U : 0U) != 0) ? throw new NotImplementedException() : ((long) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0xF))) == (0x8)) ? 1U : 0U) != 0) ? (0x40) : (0x20)));
				var r = (string) (((byte) (((size) == (0x40)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var T = ((byte) ((((byte) ((ulong) (imm) & (ulong) (0xF))) == (0x0)) ? 1U : 0U) != 0) ? throw new NotImplementedException() : ((string) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x1))) == (0x1)) ? 1U : 0U) != 0) ? ((string) ((Q != 0) ? ("16B") : ("8B"))) : ((string) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x3))) == (0x2)) ? 1U : 0U) != 0) ? ((string) ((Q != 0) ? ("8H") : ("4H"))) : ((string) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x7))) == (0x4)) ? 1U : 0U) != 0) ? ((string) ((Q != 0) ? ("4S") : ("2S"))) : ((string) ((Q != 0) ? ("2D") : throw new NotImplementedException()))))))));
				return $"dup V{rd}.{T}, {r}{rn}";
			}
			/* EOR-shifted-register */
			if((inst & 0x7F200000U) == 0x4A000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"eor {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* LDARB */
			if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldarb W{rt}, [X{rn}]";
			}
			/* LDAXB */
			if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
				var size = (inst >> 30) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldaxb W{rt}, [X{rn}]";
			}
			/* LDP-immediate-postindex */
			if((inst & 0x7FC00000U) == 0x28C00000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"ldp {r}{rt1}, {r}{rt2}, [X{rn}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* LDP-immediate-signed-offset */
			if((inst & 0x7FC00000U) == 0x29400000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"ldp {r}{rt1}, {r}{rt2}, [X{rn}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]";
			}
			/* LDP-simd-postindex */
			if((inst & 0x3FC00000U) == 0x2CC00000U) {
				var opc = (inst >> 30) & 0x3U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) ((opc) switch { 0x0 => "S", 0x1 => "D", _ => "Q" });
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) ((opc) switch { 0x0 => 0x2, 0x1 => 0x3, _ => 0x4 })));
				return $"ldp {r}{rt1}, {r}{rt2}, [X{rn}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* LDR-immediate-preindex */
			if((inst & 0xBFE00C00U) == 0xB8400C00U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldr {r}{rd}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
			}
			/* LDR-immediate-postindex */
			if((inst & 0xBFE00C00U) == 0xB8400400U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldr {r}{rd}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDR-immediate-unsigned-offset */
			if((inst & 0xBFC00000U) == 0xB9400000U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (ushort) ((rawimm) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"ldr {r}{rd}, [X{rn}, #0x{imm:X}]";
			}
			/* LDR-register */
			if((inst & 0xBFE00C00U) == 0xB8600800U) {
				var size = (inst >> 30) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var scale = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
				var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"ldr {r1}{rt}, [X{rn}, {r2}{rm}, {extend} {(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}]";
			}
			/* LDRB-immediate-preindex */
			if((inst & 0xFFE00C00U) == 0x38400C00U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrb W{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
			}
			/* LDRB-immediate-postindex */
			if((inst & 0xFFE00C00U) == 0x38400400U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrb W{rt}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDRB-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0x39400000U) {
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldrb W{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDRB-register */
			if((inst & 0xFFE00C00U) == 0x38600800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"ldrb W{rt}, [X{rn}, {r}{rm}, {extend} {amount}]";
			}
			/* LDRH-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0x79400000U) {
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (ushort) ((rawimm) << (int) (0x1));
				return $"ldrh W{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDRSW-register */
			if((inst & 0xFFE00C00U) == 0xB8A00800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var scale = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
				var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : (0x2));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"ldrsw X{rt}, [X{rn}, {r}{rm}, {extend} {(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}]";
			}
			/* LDUR */
			if((inst & 0xBFE00C00U) == 0xB8400000U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldur {r}{rd}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LSRV */
			if((inst & 0x7FE0FC00U) == 0x1AC02400U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"lsrv {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* MADD */
			if((inst & 0x7FE08000U) == 0x1B000000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var ra = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"madd {r}{rd}, {r}{rn}, {r}{rm}, {r}{ra}";
			}
			/* MOVK */
			if((inst & 0x7F800000U) == 0x72800000U) {
				var size = (inst >> 31) & 0x1U;
				var hw = (inst >> 21) & 0x3U;
				var imm = (inst >> 5) & 0xFFFFU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shift = (byte) ((hw) << (int) (0x4));
				return $"movk {r}{rd}, #0x{imm:X}, LSL #{shift}";
			}
			/* MOVN */
			if((inst & 0x7F800000U) == 0x12800000U) {
				var size = (inst >> 31) & 0x1U;
				var hw = (inst >> 21) & 0x3U;
				var imm = (inst >> 5) & 0xFFFFU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shift = (byte) ((hw) << (int) (0x4));
				return $"movn {r}{rd}, #0x{imm:X}, LSL #{shift}";
			}
			/* MOVZ */
			if((inst & 0x7F800000U) == 0x52800000U) {
				var size = (inst >> 31) & 0x1U;
				var hw = (inst >> 21) & 0x3U;
				var imm = (inst >> 5) & 0xFFFFU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shift = (byte) ((hw) << (int) (0x4));
				return $"movz {r}{rd}, #0x{imm:X}, LSL #{shift}";
			}
			/* MRS */
			if((inst & 0xFFF00000U) == 0xD5300000U) {
				var op0 = (inst >> 19) & 0x1U;
				var op1 = (inst >> 16) & 0x7U;
				var cn = (inst >> 12) & 0xFU;
				var cm = (inst >> 8) & 0xFU;
				var op2 = (inst >> 5) & 0x7U;
				var rt = (inst >> 0) & 0x1FU;
				return $"mrs S{op0} {op1} {cn} {cm} {op2}, X{rt}";
			}
			/* MSR-register */
			if((inst & 0xFFF00000U) == 0xD5100000U) {
				var op0 = (inst >> 19) & 0x1U;
				var op1 = (inst >> 16) & 0x7U;
				var cn = (inst >> 12) & 0xFU;
				var cm = (inst >> 8) & 0xFU;
				var op2 = (inst >> 5) & 0x7U;
				var rt = (inst >> 0) & 0x1FU;
				return $"msr S{op0} {op1} {cn} {cm} {op2}, X{rt}";
			}
			/* MSUB */
			if((inst & 0x7FE08000U) == 0x1B008000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var ra = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"msub {r}{rd}, {r}{rn}, {r}{rm}, {r}{ra}";
			}
			/* ORR-immediate */
			if((inst & 0x7F800000U) == 0x32000000U) {
				var size = (inst >> 31) & 0x1U;
				var up = (inst >> 22) & 0x1U;
				var immr = (inst >> 16) & 0x3FU;
				var imms = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (ulong) (MakeWMask(up, imms, immr, (long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x20) : (0x40)), 0x1));
				return $"orr {r}{rd}, {r}{rn}, #0x{imm:X}";
			}
			/* ORR-shifted-register */
			if((inst & 0x7F200000U) == 0x2A000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"orr {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* RBIT */
			if((inst & 0x7FFFFC00U) == 0x5AC00000U) {
				var size = (inst >> 31) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"rbit {r}{rd}, {r}{rn}";
			}
			/* RET */
			if((inst & 0xFFFFFC1FU) == 0xD65F0000U) {
				var rn = (inst >> 5) & 0x1FU;
				return $"ret X{rn}";
			}
			/* SBFM */
			if((inst & 0x7F800000U) == 0x13000000U) {
				var size = (inst >> 31) & 0x1U;
				var N = (inst >> 22) & 0x1U;
				var immr = (inst >> 16) & 0x3FU;
				var imms = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"sbfm {r}{rd}, {r}{rn}, #{immr}, #{imms}";
			}
			/* STLXR */
			if((inst & 0xBFE0FC00U) == 0x8800FC00U) {
				var size = (inst >> 30) & 0x1U;
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"stlxr W{rs}, {r}{rt}, [X{rn}]";
			}
			/* STP-postindex */
			if((inst & 0x7FC00000U) == 0x28800000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* STP-preindex */
			if((inst & 0x7FC00000U) == 0x29800000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]!";
			}
			/* STP-signed-offset */
			if((inst & 0x7FC00000U) == 0x29000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]";
			}
			/* STP-simd-preindex */
			if((inst & 0x3FC00000U) == 0x2D800000U) {
				var opc = (inst >> 30) & 0x3U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) ((opc) switch { 0x0 => "S", 0x1 => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) ((opc) switch { 0x0 => 0x2, 0x1 => 0x3, 0x2 => 0x4, _ => throw new NotImplementedException() })));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]!";
			}
			/* STP-simd-signed-offset */
			if((inst & 0x3FC00000U) == 0x2D000000U) {
				var opc = (inst >> 30) & 0x3U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) ((opc) switch { 0x0 => "S", 0x1 => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) ((opc) switch { 0x0 => 0x2, 0x1 => 0x3, 0x2 => 0x4, _ => throw new NotImplementedException() })));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]";
			}
			/* STR-immediate-postindex */
			if((inst & 0xBFE00C00U) == 0xB8000400U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (SignExt<long>(imm, 9));
				return $"str {r}{rs}, [X{rd}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* STR-immediate-preindex */
			if((inst & 0xBFE00C00U) == 0xB8000C00U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (SignExt<long>(imm, 9));
				return $"str {r}{rs}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]!";
			}
			/* STR-immediate-unsigned-offset */
			if((inst & 0xBFC00000U) == 0xB9000000U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var pimm = (ulong) (((ulong) ((ulong) (imm))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"str {r}{rs}, [X{rd}, #0x{pimm:X}]";
			}
			/* STR-register */
			if((inst & 0xBFE00C00U) == 0xB8200800U) {
				var size = (inst >> 30) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var scale = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
				var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"str {r1}{rt}, [X{rn}, {r2}{rm}, {extend} {(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}]";
			}
			/* STRB-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0x39000000U) {
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"strb W{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* STRB-register */
			if((inst & 0xFFE00C00U) == 0x38200800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"strb W{rt}, [X{rn}, {r}{rm}, {str} {amount}";
			}
			/* STRH-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0x79000000U) {
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"strh W{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* STRH-register */
			if((inst & 0xFFE00C00U) == 0x78200800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"strh W{rt}, [X{rn}, {r}{rm}, {str} {amount}";
			}
			/* STUR */
			if((inst & 0xBFE00C00U) == 0xB8000000U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var offset = (long) (SignExt<long>(imm, 9));
				return $"stur {r}{rt}, [X{rn}, #{(offset < 0 ? $"-0x{-offset:X}" : $"0x{offset:X}")}]";
			}
			/* STURB */
			if((inst & 0xFFE00C00U) == 0x38000000U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var offset = (long) (SignExt<long>(imm, 9));
				return $"sturb W{rt}, [X{rn}, #{(offset < 0 ? $"-0x{-offset:X}" : $"0x{offset:X}")}]";
			}
			/* SUB-immediate */
			if((inst & 0x7F800000U) == 0x51000000U) {
				var size = (inst >> 31) & 0x1U;
				var sh = (inst >> 22) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shift = (long) (((byte) (((sh) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : (0xC));
				var simm = (ushort) ((imm) << (int) (shift));
				return $"sub {r}{rd}, {r}{rn}, #0x{imm:X}, LSL #{(shift < 0 ? $"-0x{-shift:X}" : $"0x{shift:X}")}";
			}
			/* SUB-extended-register */
			if((inst & 0x7FE00000U) == 0x4B200000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var imm = (inst >> 10) & 0x7U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var extend = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "LSL", 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => "LSL", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
				return $"sub {r1}{rd}, {r1}{rn}, {r2}{rm}, {extend} #{imm}";
			}
			/* SUB-shifted-register */
			if((inst & 0x7F200000U) == 0x4B000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => throw new NotImplementedException() });
				return $"sub {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* SUBS-extended-register */
			if((inst & 0x7FE00000U) == 0x6B200000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var imm = (inst >> 10) & 0x7U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var mode32 = (byte) (((size) == (0x0)) ? 1U : 0U);
				var r = (string) ((mode32 != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((byte) (mode32) & (byte) ((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) != (0x3)) ? 1U : 0U))) != 0) ? ("W") : ("X"));
				var extend = (string) ((mode32 != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => (string) (((byte) (((rn) == (0x1F)) ? 1U : 0U) != 0) ? ("LSL") : ("UXTW")), 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => (string) (((byte) (((rn) == (0x1F)) ? 1U : 0U) != 0) ? ("LSL") : ("UXTX")), 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
				var amount = 0xDEAD;
				return $"subs {r}{rd}, {r}{rn}, {r2}{rm}, {extend} #{(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}";
			}
			/* SUBS-shifted-register */
			if((inst & 0x7F200000U) == 0x6B000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var mode32 = (byte) (((size) == (0x0)) ? 1U : 0U);
				var r = (string) ((mode32 != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => throw new NotImplementedException() });
				return $"subs {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* SUBS-immediate */
			if((inst & 0x7F800000U) == 0x71000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var mode32 = (byte) (((size) == (0x0)) ? 1U : 0U);
				var r = (string) ((mode32 != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL #0", 0x1 => "LSL #12", _ => throw new NotImplementedException() });
				return $"subs {r}{rd}, {r}{rn}, #0x{imm:X}, {shiftstr}";
			}
			/* SVC */
			if((inst & 0xFFE0001FU) == 0xD4000001U) {
				var imm = (inst >> 5) & 0xFFFFU;
				return $"svc #0x{imm:X}";
			}
			/* TBZ */
			if((inst & 0x7F000000U) == 0x36000000U) {
				var upper = (inst >> 31) & 0x1U;
				var bottom = (inst >> 19) & 0x1FU;
				var offset = (inst >> 5) & 0x3FFFU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((upper) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (byte) ((byte) ((byte) ((upper) << (int) (0x5))) | (byte) (bottom));
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((ushort) (((ushort) ((ushort) (offset))) << (int) (0x2)), 16))));
				return $"tbz {r}{rt}, #{imm}, 0x{addr:X}";
			}
			/* TBNZ */
			if((inst & 0x7F000000U) == 0x37000000U) {
				var upper = (inst >> 31) & 0x1U;
				var bottom = (inst >> 19) & 0x1FU;
				var offset = (inst >> 5) & 0x3FFFU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((upper) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (byte) ((byte) ((byte) ((upper) << (int) (0x5))) | (byte) (bottom));
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((ushort) (((ushort) ((ushort) (offset))) << (int) (0x2)), 16))));
				return $"tbnz {r}{rt}, #{imm}, 0x{addr:X}";
			}
			/* UBFM */
			if((inst & 0x7F800000U) == 0x53000000U) {
				var size = (inst >> 31) & 0x1U;
				var N = (inst >> 22) & 0x1U;
				var immr = (inst >> 16) & 0x3FU;
				var imms = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ubfm {r}{rd}, {r}{rn}, #{immr}, #{imms}";
			}
			/* UDIV */
			if((inst & 0x7FE0FC00U) == 0x1AC00800U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"udiv {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* UMADDL */
			if((inst & 0xFFE08000U) == 0x9BA00000U) {
				var rm = (inst >> 16) & 0x1FU;
				var ra = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				return $"umaddl X{rd}, W{rn}, W{rm}, X{ra}";
			}
			/* UMULH */
			if((inst & 0xFFE0FC00U) == 0x9BC07C00U) {
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				return $"umulh X{rd}, X{rn}, X{rm}";
			}

			return null;
		}
	}
}