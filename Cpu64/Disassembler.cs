#pragma warning disable 162, 219
using System;

namespace Cpu64 {
	public partial class BaseCpu {
		public unsafe string? Disassemble(uint inst, ulong pc) {
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
				return $"add {r}{rd}, {r}{rn}, #0x{imm:X}, LSL #{(shift < 0 ? $"-0x{-shift}" : $"0x{shift}")}";
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
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) ((imm) << (int) (0x2)), 19))));
				return $"cbnz {r}{rs}, #0x{addr:X}";
			}
			/* LDR-immediate-postindex */
			if((inst & 0xBFE00C00U) == 0xB8400400U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldr {r}{rd}, [X{rn}], #{(imm < 0 ? $"-0x{-imm}" : $"0x{imm}")}";
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
			/* STP-signed-offset */
			if((inst & 0x7FC00000U) == 0x29000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}, #{(simm < 0 ? $"-0x{-simm}" : $"0x{simm}")}]";
			}
			/* STR-immediate-preindex */
			if((inst & 0xBFE00C00U) == 0xB8000C00U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (SignExt<long>(imm, 9));
				return $"str {r}{rs}, [X{rd}, #{(simm < 0 ? $"-0x{-simm}" : $"0x{simm}")}]!";
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
				return $"sub {r}{rd}, {r}{rn}, #0x{imm:X}, LSL #{(shift < 0 ? $"-0x{-shift}" : $"0x{shift}")}";
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
				return $"subs {r}{rd}, {r}{rn}, {r2}{rm}, {extend} #{(amount < 0 ? $"-0x{-amount}" : $"0x{amount}")}";
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

			return null;
		}
	}
}