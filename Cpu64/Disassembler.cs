#pragma warning disable 162, 219
using System;

namespace Cpu64 {
	public partial class BaseCpu {
		public static unsafe string Disassemble(uint inst, ulong pc) {
			/* ADCS */
			if((inst & 0x7FE0FC00U) == 0x3A000000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"adcs {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* ADD-extended-register */
			if((inst & 0x7FE00000U) == 0x0B200000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var imm = (inst >> 10) & 0x7U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
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
				var simm = (uint) (((uint) ((uint) (imm))) << (int) (shift));
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
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
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
				var simm = (uint) (((uint) ((uint) (imm))) << (int) (shift));
				return $"adds {r}{rd}, {r}{rn}, #0x{imm:X}, LSL #{(shift < 0 ? $"-0x{-shift:X}" : $"0x{shift:X}")}";
			}
			/* ADDS-shifted-register */
			if((inst & 0x7F200000U) == 0x2B000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"adds {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* ADRP */
			if((inst & 0x9F000000U) == 0x90000000U) {
				var immlo = (inst >> 29) & 0x3U;
				var immhi = (inst >> 5) & 0x7FFFFU;
				var rd = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>((ulong) ((ulong) (((ulong) (ulong) (((ulong) (((ulong) ((ushort) ((ushort) (0x0)))) << 0)) | ((ulong) (((ulong) (immlo)) << 12)))) | ((ulong) (((ulong) (immhi)) << 14)))), 33));
				var addr = (ulong) (((ulong) (ulong) ((ulong) ((ulong) (((ulong) (((ulong) ((ushort) ((ushort) (0x0)))) << 0)) | ((ulong) (((ulong) ((ulong) ((ulong) ((ulong) (((ulong) (pc)) >> (int) (0xC)))))) << 12)))))) + ((ulong) (long) (imm)));
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
			/* AND-shifted-register */
			if((inst & 0x7F200000U) == 0x0A000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"and {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* ANDS-shifted-register */
			if((inst & 0x7F200000U) == 0x6A000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"ands {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
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
			/* ASRV */
			if((inst & 0x7FE0FC00U) == 0x1AC02800U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"asrv {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* B */
			if((inst & 0xFC000000U) == 0x14000000U) {
				var imm = (inst >> 0) & 0x3FFFFFFU;
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28)))));
				return $"b #0x{addr:X}";
			}
			/* B.cond */
			if((inst & 0xFF000010U) == 0x54000000U) {
				var imm = (inst >> 5) & 0x7FFFFU;
				var cond = (inst >> 0) & 0xFU;
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 21)))));
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
			/* BIC-vector-register */
			if((inst & 0xBFE0FC00U) == 0x0E601C00U) {
				var Q = (inst >> 30) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) (((Q) == (0x1)) ? 1U : 0U) != 0) ? ("16B") : ("8B"));
				return $"bic V{rd}.{t}, V{rn}.{t}, V{rm}.{t}";
			}
			/* BL */
			if((inst & 0xFC000000U) == 0x94000000U) {
				var imm = (inst >> 0) & 0x3FFFFFFU;
				var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (offset)));
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
			/* CASP */
			if((inst & 0xBFE0FC00U) == 0x08207C00U) {
				var size = (inst >> 30) & 0x1U;
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var rs2 = (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)));
				var rt2 = (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)));
				return $"casp {r}{rs}, {r}0x{rs2:X}, {r}{rt}, {r}0x{rt2:X}, [X{rn}]";
			}
			/* CASPA */
			if((inst & 0xBFE0FC00U) == 0x08607C00U) {
				var size = (inst >> 30) & 0x1U;
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var rs2 = (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)));
				var rt2 = (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)));
				return $"caspa {r}{rs}, {r}0x{rs2:X}, {r}{rt}, {r}0x{rt2:X}, [X{rn}]";
			}
			/* CASPAL */
			if((inst & 0xBFE0FC00U) == 0x0860FC00U) {
				var size = (inst >> 30) & 0x1U;
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var rs2 = (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)));
				var rt2 = (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)));
				return $"caspal {r}{rs}, {r}0x{rs2:X}, {r}{rt}, {r}0x{rt2:X}, [X{rn}]";
			}
			/* CASPL */
			if((inst & 0xBFE0FC00U) == 0x0820FC00U) {
				var size = (inst >> 30) & 0x1U;
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var rs2 = (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)));
				var rt2 = (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)));
				return $"caspl {r}{rs}, {r}0x{rs2:X}, {r}{rt}, {r}0x{rt2:X}, [X{rn}]";
			}
			/* CBNZ */
			if((inst & 0x7F000000U) == 0x35000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 5) & 0x7FFFFU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21)))));
				return $"cbnz {r}{rs}, #0x{addr:X}";
			}
			/* CBZ */
			if((inst & 0x7F000000U) == 0x34000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 5) & 0x7FFFFU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21)))));
				return $"cbz {r}{rs}, #0x{addr:X}";
			}
			/* CCMN-immediate */
			if((inst & 0x7FE00C10U) == 0x3A400800U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var nzcv = (inst >> 0) & 0xFU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"ccmn {r}{rn}, #{imm}, #{nzcv}, {condstr}";
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
			/* CLREX */
			if((inst & 0xFFFFF0FFU) == 0xD503305FU) {
				var crm = (inst >> 8) & 0xFU;
				return $"clrex";
			}
			/* CLZ */
			if((inst & 0x7FFFFC00U) == 0x5AC01000U) {
				var size = (inst >> 31) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"clz {r}{rd}, {r}{rn}";
			}
			/* CNT */
			if((inst & 0xBF3FFC00U) == 0x0E205800U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "8B", 0x1 => "16B", _ => throw new NotImplementedException() });
				return $"cnt V{rd}.{t}, V{rn}.{t}";
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
			/* CSINV */
			if((inst & 0x7FE00C00U) == 0x5A800000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"csinv {r}{rd}, {r}{rn}, {r}{rm}, {condstr}";
			}
			/* CSNEG */
			if((inst & 0x7FE00C00U) == 0x5A800400U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"csneg {r}{rd}, {r}{rn}, {r}{rm}, {condstr}";
			}
			/* DMB */
			if((inst & 0xFFFFF0FFU) == 0xD50330BFU) {
				var m = (inst >> 8) & 0xFU;
				var option = (string) ((m) switch { 0xF => "SY", 0xE => "ST", 0xD => "LD", 0xB => "ISH", 0xA => "ISHST", 0x9 => "ISHLD", 0x7 => "NSH", 0x6 => "NSHST", 0x5 => "NSHLD", 0x3 => "OSH", 0x2 => "OSHST", _ => "OSHLD" });
				return $"DMB {option}";
			}
			/* DSB */
			if((inst & 0xFFFFF0FFU) == 0xD503309FU) {
				var crm = (inst >> 8) & 0xFU;
				var option = (string) ((crm) switch { 0xF => "SY", 0xE => "ST", 0xD => "LD", 0xB => "ISH", 0xA => "ISHST", 0x9 => "ISHLD", 0x7 => "NSH", 0x6 => "NSHST", 0x5 => "NSHLD", 0x3 => "OSH", 0x2 => "OSHST", _ => "OSHLD" });
				return $"DSB {option}";
			}
			/* DUP-general */
			if((inst & 0xBFE0FC00U) == 0x0E000C00U) {
				var Q = (inst >> 30) & 0x1U;
				var imm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var size = ((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0xF))))) == (0x0)) ? 1U : 0U) != 0) ? throw new NotImplementedException() : ((long) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0xF))))) == (0x8)) ? 1U : 0U) != 0) ? (0x40) : (0x20)));
				var r = (string) (((byte) (((size) == (0x40)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var T = ((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0xF))))) == (0x0)) ? 1U : 0U) != 0) ? throw new NotImplementedException() : ((string) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U) != 0) ? ((string) ((Q != 0) ? ("16B") : ("8B"))) : ((string) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x3))))) == (0x2)) ? 1U : 0U) != 0) ? ((string) ((Q != 0) ? ("8H") : ("4H"))) : ((string) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x7))))) == (0x4)) ? 1U : 0U) != 0) ? ((string) ((Q != 0) ? ("4S") : ("2S"))) : ((string) ((Q != 0) ? ("2D") : throw new NotImplementedException()))))))));
				return $"dup V{rd}.{T}, {r}{rn}";
			}
			/* EON-shifted-register */
			if((inst & 0x7F200000U) == 0x4A200000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"eon {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* EOR-immediate */
			if((inst & 0x7F800000U) == 0x52000000U) {
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
			/* EXT */
			if((inst & 0xBFE08400U) == 0x2E000000U) {
				var Q = (inst >> 30) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var index = (inst >> 11) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var ts = (string) ((Q != 0) ? ("16B") : ("8B"));
				return $"ext V{rd}.{ts}, V{rn}.{ts}, V{rm}.{ts}, #{index}";
			}
			/* EXTR */
			if((inst & 0x7FA00000U) == 0x13800000U) {
				var size = (inst >> 31) & 0x1U;
				var o = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var lsb = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"extr {r}{rd}, {r}{rn}, {r}{rm}, #{lsb}";
			}
			/* FABS-scalar */
			if((inst & 0xFF3FFC00U) == 0x1E20C000U) {
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fabs {r}{rd}, {r}{rn}";
			}
			/* FABS-vector */
			if((inst & 0xBFBFFC00U) == 0x0EA0F800U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"fabs V{rd}.{t}, V{rn}.{t}";
			}
			/* FADD-scalar */
			if((inst & 0xFF20FC00U) == 0x1E202800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fadd {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* FADD-vector */
			if((inst & 0xBFA0FC00U) == 0x0E20D400U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var ts = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"fadd V{rd}.{ts}, V{rn}.{ts}, V{rm}.{ts}";
			}
			/* FADDP-scalar */
			if((inst & 0xFFBFFC00U) == 0x7E30D800U) {
				var size = (inst >> 22) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
				return $"faddp {r}{rd}, V{rn}.2{r}";
			}
			/* FADDP-vector */
			if((inst & 0xBFA0FC00U) == 0x2E20D400U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"faddp V{rd}.{t}, V{rn}.{t}, V{rm}.{t}";
			}
			/* FCCMP */
			if((inst & 0xFF200C10U) == 0x1E200400U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var nzcv = (inst >> 0) & 0xFU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"fccmp {r}{rn}, {r}{rm}, #{nzcv}, {condstr}";
			}
			/* FCMxx-register-vector */
			if((inst & 0x9F20F400U) == 0x0E20E400U) {
				var Q = (inst >> 30) & 0x1U;
				var U = (inst >> 29) & 0x1U;
				var E = (inst >> 23) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var ac = (inst >> 11) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var top = (string) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => "EQ", 0x2 => "GE", 0x3 => "GE", 0x6 => "GT", 0x7 => "GT", _ => throw new NotImplementedException() });
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"FCM{top} V{rd}.{t}, V{rn}.{t}, V{rm}.{t}";
			}
			/* FCMxx-zero-vector */
			if((inst & 0x9FBFEC00U) == 0x0EA0C800U) {
				var Q = (inst >> 30) & 0x1U;
				var U = (inst >> 29) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var op = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var top = (string) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => "GT", 0x1 => "GE", 0x2 => "EQ", _ => "LE" });
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"FCM{top} V{rd}.{t}, V{rn}.{t}, #0.0";
			}
			/* FCMLT-zero-vector */
			if((inst & 0xBFBFFC00U) == 0x0EA0E800U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"FCMLT V{rd}.{t}, V{rn}.{t}, #0.0";
			}
			/* FCMP */
			if((inst & 0xFF20FC17U) == 0x1E202000U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var opc = (inst >> 3) & 0x1U;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				var zero = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("/0") : (""));
				return $"fcmp {r}{rn}, {r}{rm} {zero}";
			}
			/* FCSEL */
			if((inst & 0xFF200C00U) == 0x1E200C00U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var cond = (inst >> 12) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
				return $"fcsel {r}{rd}, {r}{rn}, {r}{rm}, {condstr}";
			}
			/* FCVT */
			if((inst & 0xFF3E7C00U) == 0x1E224000U) {
				var type = (inst >> 22) & 0x3U;
				var opc = (inst >> 15) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r1 = "";
				var r2 = "";
				var tf = (byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (type)) << 2))));
				switch(tf) {
					case 0xC: {
						r1 = "S";
						r2 = "H";
						break;
					}
					case 0xD: {
						r1 = "D";
						r2 = "H";
						break;
					}
					case 0x3: {
						r1 = "H";
						r2 = "S";
						break;
					}
					case 0x1: {
						r1 = "D";
						r2 = "S";
						break;
					}
					case 0x7: {
						r1 = "H";
						r2 = "D";
						break;
					}
					case 0x4: {
						r1 = "S";
						r2 = "D";
						break;
					}
					default: {
						throw new NotImplementedException();
						break;
					}
				}
				return $"fcvt {r1}{rd}, {r2}{rn}";
			}
			/* FCVTZS-scalar-fixedpoint */
			if((inst & 0x7F3F0000U) == 0x1E180000U) {
				var size = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var scale = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var fbits = (ulong) (((ulong) (long) (0x40)) - ((ulong) (byte) (scale)));
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fcvtzs {r1}{rd}, {r2}{rn}, #0x{fbits:X}";
			}
			/* FCVTZS-scalar-integer */
			if((inst & 0x7F3FFC00U) == 0x1E380000U) {
				var size = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var st = (byte) ((byte) (((byte) (((byte) (type)) << 0)) | ((byte) (((byte) (size)) << 2))));
				var r1 = "";
				var r2 = "";
				switch(st) {
					case 0x3: {
						r1 = "W";
						r2 = "H";
						break;
					}
					case 0x7: {
						r1 = "X";
						r2 = "H";
						break;
					}
					case 0x0: {
						r1 = "W";
						r2 = "S";
						break;
					}
					case 0x4: {
						r1 = "X";
						r2 = "S";
						break;
					}
					case 0x1: {
						r1 = "W";
						r2 = "D";
						break;
					}
					case 0x5: {
						r1 = "X";
						r2 = "D";
						break;
					}
					default: {
						throw new NotImplementedException();
						break;
					}
				}
				return $"fcvtzs {r1}{rd}, {r2}{rn}";
			}
			/* FCVTZU-scalar-fixedpoint */
			if((inst & 0x7F3F0000U) == 0x1E190000U) {
				var size = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var scale = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var fbits = (ulong) (((ulong) (long) (0x40)) - ((ulong) (byte) (scale)));
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fcvtzu {r1}{rd}, {r2}{rn}, #0x{fbits:X}";
			}
			/* FCVTZU-scalar-integer */
			if((inst & 0x7F3FFC00U) == 0x1E390000U) {
				var size = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var st = (byte) ((byte) (((byte) (((byte) (type)) << 0)) | ((byte) (((byte) (size)) << 2))));
				var r1 = "";
				var r2 = "";
				switch(st) {
					case 0x3: {
						r1 = "W";
						r2 = "H";
						break;
					}
					case 0x7: {
						r1 = "X";
						r2 = "H";
						break;
					}
					case 0x0: {
						r1 = "W";
						r2 = "S";
						break;
					}
					case 0x4: {
						r1 = "X";
						r2 = "S";
						break;
					}
					case 0x1: {
						r1 = "W";
						r2 = "D";
						break;
					}
					case 0x5: {
						r1 = "X";
						r2 = "D";
						break;
					}
					default: {
						throw new NotImplementedException();
						break;
					}
				}
				return $"fcvtzu {r1}{rd}, {r2}{rn}";
			}
			/* FDIV-scalar */
			if((inst & 0xFF20FC00U) == 0x1E201800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fdiv {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* FMAXNM-scalar */
			if((inst & 0xFF20FC00U) == 0x1E206800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fmaxnm {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* FMINNM-scalar */
			if((inst & 0xFF20FC00U) == 0x1E207800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fminnm {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* FMOV-general */
			if((inst & 0x7F36FC00U) == 0x1E260000U) {
				var sf = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var mode = (inst >> 19) & 0x1U;
				var ropc = (inst >> 16) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var opc = (byte) ((byte) (((byte) (((byte) (ropc)) << 0)) | ((byte) (((byte) ((byte) ((byte) (0x3)))) << 1))));
				var tf = (byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) ((byte) ((byte) (mode)))) << 3)))) | ((byte) (((byte) (type)) << 5)))) | ((byte) (((byte) (sf)) << 7))));
				var r1 = "";
				var r2 = "";
				switch(tf) {
					case 0x66: {
						r1 = "W";
						r2 = "H";
						break;
					}
					case 0xE6: {
						r1 = "X";
						r2 = "H";
						break;
					}
					case 0x67: {
						r1 = "H";
						r2 = "W";
						break;
					}
					case 0x7: {
						r1 = "S";
						r2 = "W";
						break;
					}
					case 0x6: {
						r1 = "W";
						r2 = "S";
						break;
					}
					case 0xE7: {
						r1 = "H";
						r2 = "X";
						break;
					}
					case 0xA7: {
						r1 = "D";
						r2 = "X";
						break;
					}
					case 0xCF: {
						r1 = "V";
						r2 = "X";
						break;
					}
					case 0xCE: {
						r1 = "X";
						r2 = "V";
						break;
					}
					case 0xA6: {
						r1 = "X";
						r2 = "D";
						break;
					}
					default: {
						throw new NotImplementedException();
						break;
					}
				}
				var index1 = (string) (((byte) (((r1) == ("V")) ? 1U : 0U) != 0) ? (".D[1]") : (""));
				var index2 = (string) (((byte) (((r2) == ("V")) ? 1U : 0U) != 0) ? (".D[1]") : (""));
				return $"fmov {r1}{rd}{index1}, {r2}{rn}{index2}";
			}
			/* FMOV-scalar-immediate */
			if((inst & 0xFF201FE0U) == 0x1E201000U) {
				var type = (inst >> 22) & 0x3U;
				var imm = (inst >> 13) & 0xFFU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				var sv = (float) (Bitcast<uint, float>((uint) ((uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (((uint) ((uint) ((uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (((uint) ((byte) ((byte) (0x0)))) << 0)) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 1)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 2)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 3)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 4)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 5)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 6)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 7)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 8)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 9)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 10)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 11)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 12)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 13)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 14)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 15)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 16)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 17)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 18)))))) << 0)) | ((uint) (((uint) ((byte) ((byte) ((byte) ((((ulong) (imm)) & ((ulong) (0xF)))))))) << 19)))) | ((uint) (((uint) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x4)))) & ((ulong) (0x3)))))))) << 23)))) | ((uint) (((uint) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 0)) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 1)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 2)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 3)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 4)))))) << 25)))) | ((uint) (((uint) ((byte) (((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1))))) != 0 ? 0U : 1U))) << 30)))) | ((uint) (((uint) ((byte) ((byte) ((byte) ((imm) >> (int) (0x7)))))) << 31))))));
				return $"fmov {r}{rd}, #{sv}";
			}
			/* FMUL-scalar */
			if((inst & 0xFF20FC00U) == 0x1E200800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fmul {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* FMUL-vector */
			if((inst & 0xBFA0FC00U) == 0x2E20DC00U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var ts = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"fmul V{rd}.{ts}, V{rn}.{ts}, V{rm}.{ts}";
			}
			/* FNEG */
			if((inst & 0xFF3FFC00U) == 0x1E214000U) {
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fneg {r}{rd}, {r}{rn}";
			}
			/* FNMUL-scalar */
			if((inst & 0xFF20FC00U) == 0x1E208800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fnmul {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* FRSQRTE-vector */
			if((inst & 0xBFBFFC00U) == 0x2EA1D800U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"frsqrte V{rd}.{t}, V{rn}.{t}";
			}
			/* FRSQRTS-vector */
			if((inst & 0xBFA0FC00U) == 0x0EA0FC00U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
				return $"frsqrts V{rd}.{t}, V{rn}.{t}, V{rm}.{t}";
			}
			/* FSQRT-scalar */
			if((inst & 0xFF3FFC00U) == 0x1E21C000U) {
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fsqrt {r}{rd}, {r}{rn}";
			}
			/* FSUB-scalar */
			if((inst & 0xFF20FC00U) == 0x1E203800U) {
				var type = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
				return $"fsub {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* INS-general */
			if((inst & 0xFFE0FC00U) == 0x4E001C00U) {
				var imm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var ts = "";
				var index = (uint) ((uint) (0x0));
				var r = "W";
				if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0) {
					ts = "B";
					index = (byte) ((imm) >> (int) (0x1));
				} else {
					if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
						ts = "H";
						index = (byte) ((imm) >> (int) (0x2));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
							ts = "S";
							index = (byte) ((imm) >> (int) (0x3));
						} else {
							ts = "D";
							index = (byte) ((imm) >> (int) (0x4));
							r = "X";
						}
					}
				}
				return $"ins V{rd}.{ts}[0x{index:X}], {r}{rn}";
			}
			/* INS-vector */
			if((inst & 0xFFE08400U) == 0x6E000400U) {
				var imm5 = (inst >> 16) & 0x1FU;
				var imm4 = (inst >> 11) & 0xFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var ts = "";
				var index1 = (uint) ((uint) (0x0));
				var index2 = (uint) ((uint) (0x0));
				if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0) {
					ts = "B";
					index1 = (byte) ((imm5) >> (int) (0x1));
					index2 = imm4;
				} else {
					if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
						ts = "H";
						index1 = (byte) ((imm5) >> (int) (0x2));
						index2 = (byte) ((imm4) >> (int) (0x1));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
							ts = "S";
							index1 = (byte) ((imm5) >> (int) (0x3));
							index2 = (byte) ((imm4) >> (int) (0x2));
						} else {
							ts = "D";
							index1 = (byte) ((imm5) >> (int) (0x4));
							index2 = (byte) ((imm4) >> (int) (0x3));
						}
					}
				}
				return $"ins V{rd}.{ts}[0x{index1:X}], V{rn}.{ts}[0x{index2:X}]";
			}
			/* LDAR */
			if((inst & 0xBFFFFC00U) == 0x88DFFC00U) {
				var size = (inst >> 30) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldar {r}{rt}, [X{rn}]";
			}
			/* LDARB */
			if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldarb W{rt}, [X{rn}]";
			}
			/* LDARH */
			if((inst & 0xFFFFFC00U) == 0x48DFFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldarh W{rt}, [X{rn}]";
			}
			/* LDAXB */
			if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
				var size = (inst >> 30) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldaxb W{rt}, [X{rn}]";
			}
			/* LDAXRB */
			if((inst & 0xFFFFFC00U) == 0x085FFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldaxrb W{rt}, [X{rn}]";
			}
			/* LDAXRH */
			if((inst & 0xFFFFFC00U) == 0x485FFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldaxrh W{rt}, [X{rn}]";
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
			/* LDP-simd-signed-offset */
			if((inst & 0x3FC00000U) == 0x2D400000U) {
				var opc = (inst >> 30) & 0x3U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) ((opc) switch { 0x0 => "S", 0x1 => "D", _ => "Q" });
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) ((opc) switch { 0x0 => 0x2, 0x1 => 0x3, _ => 0x4 })));
				return $"ldp {r}{rt1}, {r}{rt2}, [X{rn}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]";
			}
			/* LDPSW-immediate-signed-offset */
			if((inst & 0xFFC00000U) == 0x69400000U) {
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) (0x2));
				return $"ldpsw X{rt1}, X{rt2}, [X{rn}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]";
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
			/* LDR-simd-immediate-postindex */
			if((inst & 0x3F600C00U) == 0x3C400400U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var simm = (long) (SignExt<long>(imm, 9));
				var r = (string) (((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "B", 0x2 => "H", 0x4 => "S", 0x6 => "D", 0x1 => "Q", _ => throw new NotImplementedException() });
				return $"ldr {r}{rt}, [X{rn}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* LDR-simd-immediate-unsigned-offset */
			if((inst & 0x3F400000U) == 0x3D400000U) {
				var size = (inst >> 30) & 0x3U;
				var ropc = (inst >> 23) & 0x1U;
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var opc = (byte) ((byte) (((byte) (((byte) ((byte) ((byte) (0x1)))) << 0)) | ((byte) (((byte) (ropc)) << 1))));
				var m = (byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 2))));
				var r = (string) ((m) switch { 0x1 => "B", 0x5 => "H", 0x9 => "S", 0xD => "D", _ => "Q" });
				var imm = (uint) (((uint) ((uint) (rawimm))) << (int) ((long) ((m) switch { 0x1 => 0x0, 0x5 => 0x1, 0x9 => 0x2, 0xD => 0x3, _ => 0x4 })));
				return $"ldr {r}{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDR-simd-register */
			if((inst & 0x3F600C00U) == 0x3C600800U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var scale = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r1 = (string) (((byte) ((((byte) ((byte) (((size) == (0x0)) ? 1U : 0U))) & ((byte) ((byte) (((opc) == (0x1)) ? 1U : 0U))))) != 0) ? ("Q") : ((string) ((size) switch { 0x0 => "B", 0x1 => "H", 0x2 => "S", 0x3 => "D", _ => throw new NotImplementedException() })));
				var r2 = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				var amount = (ulong) (((ulong) (byte) (scale)) * ((ulong) (long) ((long) (((byte) ((((byte) ((byte) (((size) == (0x0)) ? 1U : 0U))) & ((byte) ((byte) (((opc) == (0x1)) ? 1U : 0U))))) != 0) ? (0x4) : ((long) ((size) switch { 0x0 => 0x1, 0x1 => 0x1, 0x2 => 0x2, 0x3 => 0x3, _ => throw new NotImplementedException() }))))));
				return $"ldr {r1}{rt}, [X{rn}, {r2}{rm}, {extend} 0x{amount:X}]";
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
				var r2 = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"ldr {r1}{rt}, [X{rn}, {r2}{rm}, {extend} {(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}]";
			}
			/* LDRB-immediate-postindex */
			if((inst & 0xFFE00C00U) == 0x38400400U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrb W{rt}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDRB-immediate-preindex */
			if((inst & 0xFFE00C00U) == 0x38400C00U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrb W{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
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
				var r = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"ldrb W{rt}, [X{rn}, {r}{rm}, {str} {amount}]";
			}
			/* LDRH-immediate-postindex */
			if((inst & 0xFFE00C00U) == 0x78400400U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrh W{rt}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDRH-immediate-preindex */
			if((inst & 0xFFE00C00U) == 0x78400C00U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrh W{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
			}
			/* LDRH-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0x79400000U) {
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (ushort) ((rawimm) << (int) (0x1));
				return $"ldrh W{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDRH-register */
			if((inst & 0xFFE00C00U) == 0x78600800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"ldrh W{rt}, [X{rn}, {r}{rm}, {str} {amount}]";
			}
			/* LDRSB-immediate-postindex */
			if((inst & 0xFFA00C00U) == 0x38800400U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldrsb {r}{rt}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDRSB-immediate-preindex */
			if((inst & 0xFFA00C00U) == 0x38800C00U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldrsb {r}{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
			}
			/* LDRSB-immediate-unsigned-offset */
			if((inst & 0xFF800000U) == 0x39800000U) {
				var opc = (inst >> 22) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldrsb {r}{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDRSB-register */
			if((inst & 0xFFA00C00U) == 0x38A00800U) {
				var opc = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((opc) == (0x0)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"ldrsb {r}{rt}, [X{rn}, {r}{rm}, {str} {amount}]";
			}
			/* LDRSH-immediate-postindex */
			if((inst & 0xFFA00C00U) == 0x78800400U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldrsh {r}{rt}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDRSH-immediate-preindex */
			if((inst & 0xFFA00C00U) == 0x78800C00U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldrsh {r}{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
			}
			/* LDRSH-immediate-unsigned-offset */
			if((inst & 0xFF800000U) == 0x79800000U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (ushort) ((rawimm) << (int) (0x1));
				return $"ldrsh {r}{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDRSH-register */
			if((inst & 0xFFA00C00U) == 0x78A00800U) {
				var opc = (inst >> 22) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((opc) == (0x0)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"ldrsh {r}{rt}, [X{rn}, {r}{rm}, {str} {amount}]";
			}
			/* LDRSW-immediate-postindex */
			if((inst & 0xFFE00C00U) == 0xB8800400U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrsw X{rt}, [X{rn}], #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}";
			}
			/* LDRSW-immediate-preindex */
			if((inst & 0xFFE00C00U) == 0xB8800C00U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldrsw X{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]!";
			}
			/* LDRSW-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0xB9800000U) {
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (ushort) ((rawimm) << (int) (0x2));
				return $"ldrsw X{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* LDRSW-register */
			if((inst & 0xFFE00C00U) == 0xB8A00800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var scale = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
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
			/* LDURB */
			if((inst & 0xFFE00C00U) == 0x38400000U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldurb W{rd}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LDURH */
			if((inst & 0xFFE00C00U) == 0x78400000U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldurh W{rd}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LDURSB */
			if((inst & 0xFFA00C00U) == 0x38800000U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldursb {r}{rd}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LDURSH */
			if((inst & 0xFFA00C00U) == 0x78800000U) {
				var opc = (inst >> 22) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldursh {r}{rd}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LDURSW */
			if((inst & 0xFFE00C00U) == 0xB8800000U) {
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldursw X{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LDUR-simd */
			if((inst & 0x3F600C00U) == 0x3C400000U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "B", 0x2 => "H", 0x4 => "S", 0x6 => "D", 0x1 => "Q", _ => throw new NotImplementedException() });
				var imm = (long) (SignExt<long>(rawimm, 9));
				return $"ldur {r}{rt}, [X{rn}, #{(imm < 0 ? $"-0x{-imm:X}" : $"0x{imm:X}")}]";
			}
			/* LDXR */
			if((inst & 0xBFFFFC00U) == 0x885F7C00U) {
				var size = (inst >> 30) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"ldxr {r}{rt}, [X{rn}]";
			}
			/* LDXRB */
			if((inst & 0xFFFFFC00U) == 0x085F7C00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldxrb W{rt}, [X{rn}]";
			}
			/* LDXRH */
			if((inst & 0xFFFFFC00U) == 0x485F7C00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"ldxrh W{rt}, [X{rn}]";
			}
			/* LSL-register */
			if((inst & 0x7FE0FC00U) == 0x1AC02000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"lsl {r}{rd}, {r}{rn}, {r}{rm}";
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
			/* MOVI-32bit */
			if((inst & 0xBFF89C00U) == 0x0F000400U) {
				var Q = (inst >> 30) & 0x1U;
				var a = (inst >> 18) & 0x1U;
				var b = (inst >> 17) & 0x1U;
				var c = (inst >> 16) & 0x1U;
				var cmode = (inst >> 13) & 0x3U;
				var d = (inst >> 9) & 0x1U;
				var e = (inst >> 8) & 0x1U;
				var f = (inst >> 7) & 0x1U;
				var g = (inst >> 6) & 0x1U;
				var h = (inst >> 5) & 0x1U;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) ((Q != 0) ? ("4S") : ("2S"));
				var amount = (long) ((cmode) switch { 0x0 => 0x0, 0x1 => 0x8, 0x2 => 0x10, 0x3 => 0x18, _ => throw new NotImplementedException() });
				var imm = (byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (h)) << 0)) | ((byte) (((byte) (g)) << 1)))) | ((byte) (((byte) (f)) << 2)))) | ((byte) (((byte) (e)) << 3)))) | ((byte) (((byte) (d)) << 4)))) | ((byte) (((byte) (c)) << 5)))) | ((byte) (((byte) (b)) << 6)))) | ((byte) (((byte) (a)) << 7))));
				return $"movi V{rd}.{t}, #{imm}, LSL #{(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}";
			}
			/* MOVI-Vx.2D */
			if((inst & 0xFFF8FC00U) == 0x6F00E400U) {
				var a = (inst >> 18) & 0x1U;
				var b = (inst >> 17) & 0x1U;
				var c = (inst >> 16) & 0x1U;
				var d = (inst >> 9) & 0x1U;
				var e = (inst >> 8) & 0x1U;
				var f = (inst >> 7) & 0x1U;
				var g = (inst >> 6) & 0x1U;
				var h = (inst >> 5) & 0x1U;
				var rd = (inst >> 0) & 0x1FU;
				var imm = (ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (h)) << 0)) | ((byte) (((byte) (h)) << 1)))) | ((byte) (((byte) (h)) << 2)))) | ((byte) (((byte) (h)) << 3)))) | ((byte) (((byte) (h)) << 4)))) | ((byte) (((byte) (h)) << 5)))) | ((byte) (((byte) (h)) << 6)))) | ((byte) (((byte) (h)) << 7)))))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (g)) << 0)) | ((byte) (((byte) (g)) << 1)))) | ((byte) (((byte) (g)) << 2)))) | ((byte) (((byte) (g)) << 3)))) | ((byte) (((byte) (g)) << 4)))) | ((byte) (((byte) (g)) << 5)))) | ((byte) (((byte) (g)) << 6)))) | ((byte) (((byte) (g)) << 7)))))) << 8)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (f)) << 0)) | ((byte) (((byte) (f)) << 1)))) | ((byte) (((byte) (f)) << 2)))) | ((byte) (((byte) (f)) << 3)))) | ((byte) (((byte) (f)) << 4)))) | ((byte) (((byte) (f)) << 5)))) | ((byte) (((byte) (f)) << 6)))) | ((byte) (((byte) (f)) << 7)))))) << 16)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (e)) << 0)) | ((byte) (((byte) (e)) << 1)))) | ((byte) (((byte) (e)) << 2)))) | ((byte) (((byte) (e)) << 3)))) | ((byte) (((byte) (e)) << 4)))) | ((byte) (((byte) (e)) << 5)))) | ((byte) (((byte) (e)) << 6)))) | ((byte) (((byte) (e)) << 7)))))) << 24)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (d)) << 0)) | ((byte) (((byte) (d)) << 1)))) | ((byte) (((byte) (d)) << 2)))) | ((byte) (((byte) (d)) << 3)))) | ((byte) (((byte) (d)) << 4)))) | ((byte) (((byte) (d)) << 5)))) | ((byte) (((byte) (d)) << 6)))) | ((byte) (((byte) (d)) << 7)))))) << 32)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (c)) << 0)) | ((byte) (((byte) (c)) << 1)))) | ((byte) (((byte) (c)) << 2)))) | ((byte) (((byte) (c)) << 3)))) | ((byte) (((byte) (c)) << 4)))) | ((byte) (((byte) (c)) << 5)))) | ((byte) (((byte) (c)) << 6)))) | ((byte) (((byte) (c)) << 7)))))) << 40)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (b)) << 0)) | ((byte) (((byte) (b)) << 1)))) | ((byte) (((byte) (b)) << 2)))) | ((byte) (((byte) (b)) << 3)))) | ((byte) (((byte) (b)) << 4)))) | ((byte) (((byte) (b)) << 5)))) | ((byte) (((byte) (b)) << 6)))) | ((byte) (((byte) (b)) << 7)))))) << 48)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) (a)) << 0)) | ((byte) (((byte) (a)) << 1)))) | ((byte) (((byte) (a)) << 2)))) | ((byte) (((byte) (a)) << 3)))) | ((byte) (((byte) (a)) << 4)))) | ((byte) (((byte) (a)) << 5)))) | ((byte) (((byte) (a)) << 6)))) | ((byte) (((byte) (a)) << 7)))))) << 56))));
				return $"movi V{rd}, #0x{imm:X}";
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
			/* MUL-by-element */
			if((inst & 0xBF00F400U) == 0x0F008000U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x3U;
				var L = (inst >> 21) & 0x1U;
				var M = (inst >> 20) & 0x1U;
				var rv = (inst >> 16) & 0xFU;
				var H = (inst >> 11) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var rm = (byte) (((byte) (((size) == (0x2)) ? 1U : 0U) != 0) ? ((byte) ((byte) (((byte) (((byte) (rv)) << 0)) | ((byte) (((byte) (M)) << 4))))) : (rv));
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x2 => "4H", 0x3 => "8H", 0x4 => "2S", 0x5 => "4S", _ => throw new NotImplementedException() });
				var ts = (string) ((size) switch { 0x1 => "H", 0x2 => "S", _ => throw new NotImplementedException() });
				var index = (byte) ((size) switch { 0x1 => (byte) ((byte) (((byte) (byte) (((byte) (((byte) (M)) << 0)) | ((byte) (((byte) (L)) << 1)))) | ((byte) (((byte) (H)) << 2)))), 0x2 => (byte) ((byte) (((byte) (((byte) (L)) << 0)) | ((byte) (((byte) (H)) << 1)))), _ => throw new NotImplementedException() });
				return $"mul V{rd}.{t}, V{rn}.{t}, V{rm}.{ts}[{index}]";
			}
			/* MUL-vector */
			if((inst & 0xBF20FC00U) == 0x0E209C00U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "8B", 0x1 => "16B", 0x2 => "4H", 0x3 => "8H", 0x4 => "2S", 0x5 => "4S", _ => throw new NotImplementedException() });
				return $"mul V{rd}.{t}, V{rn}.{t}, V{rm}.{t}";
			}
			/* ORN-shifted-register */
			if((inst & 0x7F200000U) == 0x2A200000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x3U;
				var rm = (inst >> 16) & 0x1FU;
				var imm = (inst >> 10) & 0x3FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"orn {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
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
			/* ORR-simd-register */
			if((inst & 0xBFE0FC00U) == 0x0EA01C00U) {
				var q = (inst >> 30) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var t = (string) (((byte) (((q) == (0x0)) ? 1U : 0U) != 0) ? ("8B") : ("16B"));
				return $"orr V{rd}.{t}, V{rn}.{t}, V{rm}.{t}";
			}
			/* PRFM-immediate */
			if((inst & 0xFFC00000U) == 0xF9800000U) {
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var imm5 = (inst >> 0) & 0x1FU;
				var pimm = (ulong) (((ulong) (ushort) (imm)) * ((ulong) (long) (0x8)));
				return $"prfm #{imm5}, [X{rn}, #0x{pimm:X}]";
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
			/* REV */
			if((inst & 0x7FFFF800U) == 0x5AC00800U) {
				var size = (inst >> 31) & 0x1U;
				var opc = (inst >> 10) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"rev {r}{rd}, {r}{rn}";
			}
			/* REV16 */
			if((inst & 0x7FFFFC00U) == 0x5AC00400U) {
				var size = (inst >> 31) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"rev16 {r}{rd}, {r}{rn}";
			}
			/* RORV */
			if((inst & 0x7FE0FC00U) == 0x1AC02C00U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"rorv {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* SBCS */
			if((inst & 0x7FE0FC00U) == 0x7A000000U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"sbcs {r}{rd}, {r}{rn}, {r}{rm}";
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
			/* SCVTF-scalar-integer */
			if((inst & 0x7F3FFC00U) == 0x1E220000U) {
				var size = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var st = (byte) ((byte) (((byte) (((byte) (type)) << 0)) | ((byte) (((byte) (size)) << 2))));
				var r1 = "";
				var r2 = "";
				switch(st) {
					case 0x3: {
						r1 = "H";
						r2 = "W";
						break;
					}
					case 0x0: {
						r1 = "S";
						r2 = "W";
						break;
					}
					case 0x1: {
						r1 = "D";
						r2 = "W";
						break;
					}
					case 0x7: {
						r1 = "H";
						r2 = "X";
						break;
					}
					case 0x4: {
						r1 = "S";
						r2 = "X";
						break;
					}
					case 0x5: {
						r1 = "D";
						r2 = "X";
						break;
					}
					default: {
						throw new NotImplementedException();
						break;
					}
				}
				return $"scvtf {r1}{rd}, {r2}{rn}";
			}
			/* SCVTF-vector-integer */
			if((inst & 0xFFBFFC00U) == 0x5E21D800U) {
				var size = (inst >> 22) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
				return $"scvtf {r}{rd}, {r}{rn}";
			}
			/* SDIV */
			if((inst & 0x7FE0FC00U) == 0x1AC00C00U) {
				var size = (inst >> 31) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"sdiv {r}{rd}, {r}{rn}, {r}{rm}";
			}
			/* SMADDL */
			if((inst & 0xFFE08000U) == 0x9B200000U) {
				var rm = (inst >> 16) & 0x1FU;
				var ra = (inst >> 10) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				return $"smaddl X{rd}, W{rn}, W{rm}, X{ra}";
			}
			/* SMULH */
			if((inst & 0xFFE0FC00U) == 0x9B407C00U) {
				var rm = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				return $"smulh X{rd}, X{rn}, X{rm}";
			}
			/* SSHLL */
			if((inst & 0xBF80FC00U) == 0x0F00A400U) {
				var Q = (inst >> 30) & 0x1U;
				var immh = (inst >> 19) & 0xFU;
				var immb = (inst >> 16) & 0x7U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var variant = (string) ((Q != 0) ? ("2") : (""));
				var ta = "";
				var tb = "";
				var shift = (ulong) ((ulong) (0x0));
				if(((byte) (((immh) == (0x1)) ? 1U : 0U)) != 0) {
					ta = "8H";
					tb = (string) ((Q != 0) ? ("16B") : ("8B"));
					shift = (ulong) (((ulong) (byte) ((byte) ((byte) (((byte) (((byte) (immb)) << 0)) | ((byte) (((byte) (immh)) << 3)))))) - ((ulong) (long) (0x8)));
				} else {
					if(((byte) ((((byte) ((((ulong) (immh)) & ((ulong) (0xE))))) == (0x2)) ? 1U : 0U)) != 0) {
						ta = "4S";
						tb = (string) ((Q != 0) ? ("8H") : ("4H"));
						shift = (ulong) (((ulong) (byte) ((byte) ((byte) (((byte) (((byte) (immb)) << 0)) | ((byte) (((byte) (immh)) << 3)))))) - ((ulong) (long) (0x10)));
					} else {
						if(((byte) ((((byte) ((((ulong) (immh)) & ((ulong) (0xC))))) == (0x4)) ? 1U : 0U)) != 0) {
							ta = "2D";
							tb = (string) ((Q != 0) ? ("4S") : ("2S"));
							shift = (ulong) (((ulong) (byte) ((byte) ((byte) (((byte) (((byte) (immb)) << 0)) | ((byte) (((byte) (immh)) << 3)))))) - ((ulong) (long) (0x20)));
						} else {
							throw new NotImplementedException();
						}
					}
				}
				return $"sshll{variant} V{rd}.{ta}, V{rn}.{tb}, #0x{shift:X}";
			}
			/* STLR */
			if((inst & 0xBFFFFC00U) == 0x889FFC00U) {
				var size = (inst >> 30) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"stlr {r}{rt}, [X{rn}]";
			}
			/* STLRB */
			if((inst & 0xFFFFFC00U) == 0x089FFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"stlrb W{rt}, [X{rn}]";
			}
			/* STLRH */
			if((inst & 0xFFFFFC00U) == 0x489FFC00U) {
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"stlrh W{rt}, [X{rn}]";
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
			/* STLXRB */
			if((inst & 0xFFE0FC00U) == 0x0800FC00U) {
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				return $"stlxrr W{rs}, W{rt}, [X{rn}]";
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
			/* STP-simd-postindex */
			if((inst & 0x3FC00000U) == 0x2C800000U) {
				var opc = (inst >> 30) & 0x3U;
				var imm = (inst >> 15) & 0x7FU;
				var rt2 = (inst >> 10) & 0x1FU;
				var rd = (inst >> 5) & 0x1FU;
				var rt1 = (inst >> 0) & 0x1FU;
				var r = (string) ((opc) switch { 0x0 => "S", 0x1 => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) ((long) ((opc) switch { 0x0 => 0x2, 0x1 => 0x3, 0x2 => 0x4, _ => throw new NotImplementedException() })));
				return $"stp {r}{rt1}, {r}{rt2}, [X{rd}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
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
				var r2 = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"str {r1}{rt}, [X{rn}, {r2}{rm}, {extend} {(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}]";
			}
			/* STR-simd-postindex */
			if((inst & 0x3F600C00U) == 0x3C000400U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var rop = (byte) ((byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) (0x0)))) << 0)) | ((byte) (((byte) (opc)) << 1)))) | ((byte) (((byte) (size)) << 2))));
				var r = (string) ((rop) switch { 0x0 => "B", 0x4 => "H", 0x8 => "S", 0xC => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var simm = (long) (SignExt<long>(imm, 9));
				return $"str {r}{rt}, [X{rn}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* STR-simd-preindex */
			if((inst & 0x3F600C00U) == 0x3C000C00U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var rop = (byte) ((byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) (0x0)))) << 0)) | ((byte) (((byte) (opc)) << 1)))) | ((byte) (((byte) (size)) << 2))));
				var r = (string) ((rop) switch { 0x0 => "B", 0x4 => "H", 0x8 => "S", 0xC => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var scale = (byte) ((byte) (((byte) (((byte) (size)) << 0)) | ((byte) (((byte) (opc)) << 2))));
				var simm = (long) (SignExt<long>(imm, 9));
				return $"str {r}{rt}, [X{rn}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]!";
			}
			/* STR-simd-unsigned-offset */
			if((inst & 0x3F400000U) == 0x3D000000U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var rop = (byte) ((byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) (0x0)))) << 0)) | ((byte) (((byte) (opc)) << 1)))) | ((byte) (((byte) (size)) << 2))));
				var r = (string) ((rop) switch { 0x0 => "B", 0x4 => "H", 0x8 => "S", 0xC => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var scale = (byte) ((byte) (((byte) (((byte) (size)) << 0)) | ((byte) (((byte) (opc)) << 2))));
				return $"str {r}{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* STR-simd-register */
			if((inst & 0x3F600C00U) == 0x3C200800U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var scale = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var rop = (byte) ((byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) (0x0)))) << 0)) | ((byte) (((byte) (opc)) << 1)))) | ((byte) (((byte) (size)) << 2))));
				var r1 = (string) ((rop) switch { 0x0 => "B", 0x4 => "H", 0x8 => "S", 0xC => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var r2 = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) ((size) switch { 0x1 => 0x1, 0x2 => 0x2, 0x3 => 0x3, _ => (long) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? (0x4) : (0x0)) })));
				var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
				return $"str {r1}{rt}, [X{rn}, {r2}, {extend} {(amount < 0 ? $"-0x{-amount:X}" : $"0x{amount:X}")}]";
			}
			/* STRB-immediate-postindex */
			if((inst & 0xFFE00C00U) == 0x38000400U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var simm = (long) (SignExt<long>(imm, 9));
				return $"strb W{rs}, [X{rd}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* STRB-immediate-preindex */
			if((inst & 0xFFE00C00U) == 0x38000C00U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var simm = (long) (SignExt<long>(imm, 9));
				return $"strb W{rs}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]!";
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
				var r = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"strb W{rt}, [X{rn}, {r}{rm}, {str} {amount}]";
			}
			/* STRH-immediate-postindex */
			if((inst & 0xFFE00C00U) == 0x78000400U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var simm = (long) (SignExt<long>(imm, 9));
				return $"strh W{rs}, [X{rd}], #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}";
			}
			/* STRH-immediate-preindex */
			if((inst & 0xFFE00C00U) == 0x78000C00U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var simm = (long) (SignExt<long>(imm, 9));
				return $"strh W{rs}, [X{rd}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]!";
			}
			/* STRH-immediate-unsigned-offset */
			if((inst & 0xFFC00000U) == 0x79000000U) {
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var imm = (ushort) ((rawimm) << (int) (0x1));
				return $"strh W{rt}, [X{rn}, #0x{imm:X}]";
			}
			/* STRH-register */
			if((inst & 0xFFE00C00U) == 0x78200800U) {
				var rm = (inst >> 16) & 0x1FU;
				var option = (inst >> 13) & 0x7U;
				var amount = (inst >> 12) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
				var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
				return $"strh W{rt}, [X{rn}, {r}{rm}, {str} {amount}]";
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
			/* STUR-simd */
			if((inst & 0x3F600C00U) == 0x3C000000U) {
				var size = (inst >> 30) & 0x3U;
				var opc = (inst >> 23) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var rop = (byte) ((byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) (0x0)))) << 0)) | ((byte) (((byte) (opc)) << 1)))) | ((byte) (((byte) (size)) << 2))));
				var r = (string) ((rop) switch { 0x0 => "B", 0x4 => "H", 0x8 => "S", 0xC => "D", 0x2 => "Q", _ => throw new NotImplementedException() });
				var simm = (long) (SignExt<long>(imm, 9));
				return $"stur {r}{rt}, [X{rn}, #{(simm < 0 ? $"-0x{-simm:X}" : $"0x{simm:X}")}]";
			}
			/* STURB */
			if((inst & 0xFFE00C00U) == 0x38000000U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var offset = (long) (SignExt<long>(imm, 9));
				return $"sturb W{rt}, [X{rn}, #{(offset < 0 ? $"-0x{-offset:X}" : $"0x{offset:X}")}]";
			}
			/* STURH */
			if((inst & 0xFFE00C00U) == 0x78000000U) {
				var imm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var offset = (long) (SignExt<long>(imm, 9));
				return $"sturh W{rt}, [X{rn}, #{(offset < 0 ? $"-0x{-offset:X}" : $"0x{offset:X}")}]";
			}
			/* STXR */
			if((inst & 0xBFE0FC00U) == 0x88007C00U) {
				var size = (inst >> 30) & 0x1U;
				var rs = (inst >> 16) & 0x1FU;
				var rn = (inst >> 5) & 0x1FU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				return $"stxr W{rs}, {r}{rt}, [X{rn}]";
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
				var r2 = (string) (((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
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
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
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
				var r1 = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
				var extend = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "LSL", 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => "LSL", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
				return $"subs {r1}{rd}, {r1}{rn}, {r2}{rm}, {extend} #{imm}";
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
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
				return $"subs {r}{rd}, {r}{rn}, {r}{rm}, {shiftstr} #{imm}";
			}
			/* SUBS-immediate */
			if((inst & 0x7F800000U) == 0x71000000U) {
				var size = (inst >> 31) & 0x1U;
				var shift = (inst >> 22) & 0x1U;
				var imm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var shiftstr = (string) ((shift) switch { 0x0 => "LSL #0", 0x1 => "LSL #12", _ => throw new NotImplementedException() });
				return $"subs {r}{rd}, {r}{rn}, #0x{imm:X}, {shiftstr}";
			}
			/* SVC */
			if((inst & 0xFFE0001FU) == 0xD4000001U) {
				var imm = (inst >> 5) & 0xFFFFU;
				return $"svc #0x{imm:X}";
			}
			/* SYS */
			if((inst & 0xFFF80000U) == 0xD5080000U) {
				var op1 = (inst >> 16) & 0x7U;
				var cn = (inst >> 12) & 0xFU;
				var cm = (inst >> 8) & 0xFU;
				var op2 = (inst >> 5) & 0x7U;
				var rt = (inst >> 0) & 0x1FU;
				return $"sys #{op1}, {cn}, {cm}, #{op2}, X{rt}";
			}
			/* TBZ */
			if((inst & 0x7F000000U) == 0x36000000U) {
				var upper = (inst >> 31) & 0x1U;
				var bottom = (inst >> 19) & 0x1FU;
				var offset = (inst >> 5) & 0x3FFFU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((upper) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (byte) ((((byte) ((byte) ((upper) << (int) (0x5)))) | ((byte) (bottom))));
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((ushort) (((ushort) ((ushort) (offset))) << (int) (0x2)), 16)))));
				return $"tbz {r}{rt}, #{imm}, 0x{addr:X}";
			}
			/* TBNZ */
			if((inst & 0x7F000000U) == 0x37000000U) {
				var upper = (inst >> 31) & 0x1U;
				var bottom = (inst >> 19) & 0x1FU;
				var offset = (inst >> 5) & 0x3FFFU;
				var rt = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((upper) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (byte) ((((byte) ((byte) ((upper) << (int) (0x5)))) | ((byte) (bottom))));
				var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((ushort) (((ushort) ((ushort) (offset))) << (int) (0x2)), 16)))));
				return $"tbnz {r}{rt}, #{imm}, 0x{addr:X}";
			}
			/* UADDLV */
			if((inst & 0xBF3FFC00U) == 0x2E303800U) {
				var Q = (inst >> 30) & 0x1U;
				var size = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) ((size) switch { 0x0 => "H", 0x1 => "S", 0x2 => "D", _ => throw new NotImplementedException() });
				var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "8B", 0x1 => "16B", 0x2 => "4H", 0x3 => "8H", 0x5 => "4S", _ => throw new NotImplementedException() });
				var esize = (long) ((0x8) << (int) (size));
				var count = (long) (((long) (long) ((long) ((Q != 0) ? (0x80) : (0x40)))) / ((long) (long) (esize)));
				return $"uaddlv {r}{rd}, V{rn}.{t}";
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
			/* UCVTF-scalar-integer */
			if((inst & 0x7F3FFC00U) == 0x1E230000U) {
				var size = (inst >> 31) & 0x1U;
				var type = (inst >> 22) & 0x3U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var st = (byte) ((byte) (((byte) (((byte) (type)) << 0)) | ((byte) (((byte) (size)) << 2))));
				var r1 = "";
				var r2 = "";
				switch(st) {
					case 0x3: {
						r1 = "H";
						r2 = "W";
						break;
					}
					case 0x0: {
						r1 = "S";
						r2 = "W";
						break;
					}
					case 0x1: {
						r1 = "D";
						r2 = "W";
						break;
					}
					case 0x7: {
						r1 = "H";
						r2 = "X";
						break;
					}
					case 0x4: {
						r1 = "S";
						r2 = "X";
						break;
					}
					case 0x5: {
						r1 = "D";
						r2 = "X";
						break;
					}
					default: {
						throw new NotImplementedException();
						break;
					}
				}
				return $"ucvtf {r1}{rd}, {r2}{rn}";
			}
			/* UCVTF-vector-integer */
			if((inst & 0xFFBFFC00U) == 0x7E21D800U) {
				var size = (inst >> 22) & 0x1U;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
				return $"ucvtf {r}{rd}, {r}{rn}";
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