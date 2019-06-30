#pragma warning disable 162, 219
using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using UltimateOrb;

namespace Cpu64 {
	public partial class Interpreter : BaseCpu {
		public unsafe bool Interpret(uint inst, ulong pc) {
			unchecked {
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var m = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (uint) ((ulong) (m) & (ulong) (0xFFFF)), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (uint) ((ulong) (m) & (ulong) (0xFFFF)), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm)))));
					} else {
						if(((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) << (int) (imm))));
							else
								X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) << (int) (imm))));
						} else {
							var m = (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
							if(rd == 31)
								SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (ulong) ((ulong) (m) & (ulong) (0xFFFF)), 0x2 => (ulong) ((ulong) (m) & (ulong) (0xFFFFFFFF)), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm))));
							else
								X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (ulong) ((ulong) (m) & (ulong) (0xFFFF)), 0x2 => (ulong) ((ulong) (m) & (ulong) (0xFFFFFFFF)), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm))));
						}
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) (simm)));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) (simm)));
					} else {
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (simm));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (simm));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rm]);
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) (b))) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() }))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) (b))) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() }))));
					} else {
						var b = (ulong) ((rm) == 31 ? SP : X[(int) rm]);
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) (b))) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) (b))) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (AddWithCarrySetNzcv((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn]), simm, 0x0)));
					} else {
						X[(int) rd] = (ulong) (AddWithCarrySetNzcv((ulong) ((rn) == 31 ? SP : X[(int) rn]), simm, 0x0));
					}
					return true;
				}
				/* ADRP */
				if((inst & 0x9F000000U) == 0x90000000U) {
					var immlo = (inst >> 29) & 0x3U;
					var immhi = (inst >> 5) & 0x7FFFFU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>((ulong) ((ulong) (((ulong) (ulong) (((ulong) (((ulong) ((ushort) ((ushort) (0x0)))) << 0)) | ((ulong) (((ulong) (immlo)) << 12)))) | ((ulong) (((ulong) (immhi)) << 14)))), 33));
					var addr = (ulong) ((ulong) ((ulong) ((ulong) (((ulong) (((ulong) ((ushort) ((ushort) (0x0)))) << 0)) | ((ulong) (((ulong) ((ulong) ((ulong) ((ulong) (((ulong) (pc)) >> (int) (0xC)))))) << 12))))) + (ulong) (imm));
					X[(int) rd] = addr;
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) ((uint) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) ((uint) (imm)))));
					} else {
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) (imm));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) (imm));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) }))));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						var result = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) })));
						W[(int) rd] = (uint) (result);
						NZCV_N = (uint) ((result) >> (int) (0x1F));
						NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						NZCV_C = 0x0;
						NZCV_V = 0x0;
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						var result = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })));
						X[(int) rd] = result;
						NZCV_N = (ulong) ((result) >> (int) (0x3F));
						NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						NZCV_C = 0x0;
						NZCV_V = 0x0;
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var result = (uint) ((ulong) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (ulong) (imm));
						W[(int) rd] = (uint) (result);
						NZCV_N = (uint) ((result) >> (int) (0x1F));
						NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						NZCV_C = 0x0;
						NZCV_V = 0x0;
					} else {
						var result = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) (imm));
						X[(int) rd] = result;
						NZCV_N = (ulong) ((result) >> (int) (0x3F));
						NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						NZCV_C = 0x0;
						NZCV_V = 0x0;
					}
					return true;
				}
				/* B */
				if((inst & 0xFC000000U) == 0x14000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28))));
					Branch(addr);
					return true;
				}
				/* B.cond */
				if((inst & 0xFF000010U) == 0x54000000U) {
					var imm = (inst >> 5) & 0x7FFFFU;
					var cond = (inst >> 0) & 0xFU;
					var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 21))));
					var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						Branch(addr);
					} else {
						Branch(pc + 4);
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var dst = (uint) ((rd) == 31 ? 0U : W[(int) rd]);
						var src = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = (uint) ((uint) ((uint) ((uint) (dst) & (uint) ((uint) (~(wmask))))) | (uint) ((uint) ((uint) ((uint) (((src) << (32 - (int) (immr))) | ((src) >> (int) (immr)))) & (uint) (wmask))));
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((uint) (dst) & (uint) ((uint) (~(tmask))))) | (uint) ((uint) ((uint) (bot) & (uint) (tmask)))));
					} else {
						var dst = (ulong) ((rd) == 31 ? 0UL : X[(int) rd]);
						var src = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((ulong) ((ulong) ((ulong) (dst) & (ulong) ((ulong) (~(wmask))))) | (ulong) ((ulong) ((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr)))) & (ulong) (wmask))));
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ulong) (dst) & (ulong) ((ulong) (~(tmask))))) | (ulong) ((ulong) ((ulong) (bot) & (ulong) (tmask))));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) (~((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) }))))));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) ((ulong) (~((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })))));
					}
					return true;
				}
				/* BL */
				if((inst & 0xFC000000U) == 0x94000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
					var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (offset));
					X[(int) 0x1E] = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (0x4));
					Branch(addr);
					return true;
				}
				/* BLR */
				if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					X[(int) 0x1E] = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (0x4));
					Branch((ulong) ((rn) == 31 ? 0UL : X[(int) rn]));
					return true;
				}
				/* BR */
				if((inst & 0xFFFFFC1FU) == 0xD61F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((ulong) ((rn) == 31 ? 0UL : X[(int) rn]));
					return true;
				}
				/* CBNZ */
				if((inst & 0x7F000000U) == 0x35000000U) {
					var size = (inst >> 31) & 0x1U;
					var imm = (inst >> 5) & 0x7FFFFU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(((byte) ((((uint) ((rs) == 31 ? 0U : W[(int) rs])) != ((uint) ((uint) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
					} else {
						if(((byte) ((((ulong) ((rs) == 31 ? 0UL : X[(int) rs])) != ((ulong) ((ulong) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
					}
					return true;
				}
				/* CBZ */
				if((inst & 0x7F000000U) == 0x34000000U) {
					var size = (inst >> 31) & 0x1U;
					var imm = (inst >> 5) & 0x7FFFFU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(((byte) ((((uint) ((rs) == 31 ? 0U : W[(int) rs])) == ((uint) ((uint) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
					} else {
						if(((byte) ((((ulong) ((rs) == 31 ? 0UL : X[(int) rs])) == ((ulong) ((ulong) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) 0x1F] = (uint) ((uint) (AddWithCarrySetNzcv((uint) ((rn) == 31 ? 0U : W[(int) rn]), (uint) (~((uint) ((uint) (imm)))), 0x1)));
						} else {
							X[(int) 0x1F] = (ulong) (AddWithCarrySetNzcv((ulong) ((rn) == 31 ? 0UL : X[(int) rn]), (ulong) (~((ulong) ((ulong) (imm)))), 0x1));
						}
					} else {
						NZCV = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) 0x1F] = (uint) ((uint) (AddWithCarrySetNzcv((uint) ((rn) == 31 ? 0U : W[(int) rn]), (uint) (~((uint) ((rm) == 31 ? 0U : W[(int) rm]))), 0x1)));
						} else {
							X[(int) 0x1F] = (ulong) (AddWithCarrySetNzcv((ulong) ((rn) == 31 ? 0UL : X[(int) rn]), (ulong) (~((ulong) ((rm) == 31 ? 0UL : X[(int) rm]))), 0x1));
						}
					} else {
						NZCV = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					}
					return true;
				}
				/* CLZ */
				if((inst & 0x7FFFFC00U) == 0x5AC01000U) {
					var size = (inst >> 31) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (CountLeadingZeros((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
					} else {
						X[(int) rd] = (ulong) (CountLeadingZeros((ulong) ((rn) == 31 ? 0UL : X[(int) rn])));
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							X[(int) rd] = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]));
						} else {
							X[(int) rd] = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						}
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							X[(int) rd] = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])) + (uint) ((uint) ((uint) (0x1)))));
						} else {
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) + (ulong) (0x1));
						}
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							X[(int) rd] = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) (~((uint) ((rm) == 31 ? 0U : W[(int) rm]))));
						} else {
							X[(int) rd] = (ulong) (~((ulong) ((rm) == 31 ? 0UL : X[(int) rm])));
						}
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							X[(int) rd] = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((uint) ((int) (-((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))))))));
						} else {
							X[(int) rd] = (ulong) ((ulong) ((long) (-((long) ((long) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])))))));
						}
					}
					return true;
				}
				/* DMB */
				if((inst & 0xFFFFF0FFU) == 0xD50330BFU) {
					var m = (inst >> 8) & 0xFU;
					var option = (string) ((m) switch { 0xF => "SY", 0xE => "ST", 0xD => "LD", 0xB => "ISH", 0xA => "ISHST", 0x9 => "ISHLD", 0x7 => "NSH", 0x6 => "NSHST", 0x5 => "NSHLD", 0x3 => "OSH", 0x2 => "OSHST", _ => "OSHLD" });
					return true;
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
					var src = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
					V[rd] = (Vector128<float>) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x1))) == (0x1)) ? 1U : 0U) != 0) ? ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create((byte) ((byte) (src))).As<byte, float>())) : ((Vector128<float>) ((Vector128<float>) (Vector128.Create((byte) ((byte) (src))).As<byte, float>()))))) : ((Vector128<float>) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x3))) == (0x2)) ? 1U : 0U) != 0) ? ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create((ushort) ((ushort) (src))).As<ushort, float>())) : ((Vector128<float>) ((Vector128<float>) (Vector128.Create((ushort) ((ushort) (src))).As<ushort, float>()))))) : ((Vector128<float>) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x7))) == (0x4)) ? 1U : 0U) != 0) ? ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create((uint) ((uint) (src))).As<uint, float>())) : ((Vector128<float>) ((Vector128<float>) (Vector128.Create((uint) ((uint) (src))).As<uint, float>()))))) : ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create(src).As<ulong, float>())) : throw new NotImplementedException())))))));
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) ^ (uint) ((uint) ((uint) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) ^ (uint) ((uint) ((uint) (imm)))));
					} else {
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) ^ (ulong) (imm));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) ^ (ulong) (imm));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) ^ (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) }))));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) ^ (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) (((uint) ((rn) == 31 ? 0U : W[(int) rn])) << (int) ((ulong) ((ulong) (0x20) - (ulong) (lsb))))) | (uint) ((uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (lsb)))));
					} else {
						X[(int) rd] = (ulong) ((ulong) ((ulong) (((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) << (int) ((ulong) ((ulong) (0x40) - (ulong) (lsb))))) | (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) >> (int) (lsb))));
					}
					return true;
				}
				/* FADD-scalar */
				if((inst & 0xFF20FC00U) == 0x1E202800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x3:
							V[(int) ((rd) >> 3)] = V[(int) ((rd) >> 3)].As<float, ushort>().WithElement((int) ((rd) & 7), (ushort) ((ushort) ((float) ((float) ((float) (V[rn >> 3].As<float, ushort>().GetElement((int) rn & 7))) + (float) ((float) (V[rm >> 3].As<float, ushort>().GetElement((int) rm & 7))))))).As<ushort, float>();
							break;
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((float) (V[rn >> 2].GetElement((int) rn & 3))) + (float) ((float) (V[rm >> 2].GetElement((int) rm & 3)))));
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))) + (double) ((double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1))))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						switch(type) {
							case 0x0:
								FloatCompare((float) (V[rn >> 2].GetElement((int) rn & 3)), (float) (V[rm >> 2].GetElement((int) rm & 3)));
								break;
							case 0x1:
								FloatCompare((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1)), (double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1)));
								break;
							default:
								throw new NotImplementedException();
								break;
						}
					} else {
						NZCV = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					}
					return true;
				}
				/* FCMP */
				if((inst & 0xFF20FC17U) == 0x1E202000U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var opc = (inst >> 3) & 0x1U;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					var zero = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("/0") : (""));
					switch(type) {
						case 0x0:
							FloatCompare((float) (V[rn >> 2].GetElement((int) rn & 3)), (float) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ((float) ((float) (0x0))) : ((float) (V[rm >> 2].GetElement((int) rm & 3)))));
							break;
						case 0x1:
							FloatCompare((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1)), (double) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ((double) ((double) (0x0))) : ((double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1)))));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (NZCV_Z), 0x1 => (byte) (NZCV_C), 0x2 => (byte) (NZCV_N), 0x3 => (byte) (NZCV_V), 0x4 => (byte) ((byte) ((byte) (NZCV_C)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV_N)) == ((byte) (NZCV_V))) ? 1U : 0U)) & (byte) ((byte) (((byte) (NZCV_Z)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						switch(type) {
							case 0x0:
								V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) (V[rn >> 2].GetElement((int) rn & 3)));
								break;
							case 0x1:
								V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))).As<double, float>();
								break;
							default:
								throw new NotImplementedException();
								break;
						}
					} else {
						switch(type) {
							case 0x0:
								V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) (V[rm >> 2].GetElement((int) rm & 3)));
								break;
							case 0x1:
								V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1))).As<double, float>();
								break;
							default:
								throw new NotImplementedException();
								break;
						}
					}
					return true;
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
						case 0xC:
							r1 = "S";
							r2 = "H";
							break;
						case 0xD:
							r1 = "D";
							r2 = "H";
							break;
						case 0x3:
							r1 = "H";
							r2 = "S";
							break;
						case 0x1:
							r1 = "D";
							r2 = "S";
							break;
						case 0x7:
							r1 = "H";
							r2 = "D";
							break;
						case 0x4:
							r1 = "S";
							r2 = "D";
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					switch(tf) {
						case 0xC:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((float) (V[rn >> 3].As<float, ushort>().GetElement((int) rn & 7)))));
							break;
						case 0xD:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((float) (V[rn >> 3].As<float, ushort>().GetElement((int) rn & 7))))).As<double, float>();
							break;
						case 0x3:
							V[(int) ((rd) >> 3)] = V[(int) ((rd) >> 3)].As<float, ushort>().WithElement((int) ((rd) & 7), (ushort) ((ushort) ((float) (V[rn >> 2].GetElement((int) rn & 3))))).As<ushort, float>();
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((float) (V[rn >> 2].GetElement((int) rn & 3))))).As<double, float>();
							break;
						case 0x7:
							V[(int) ((rd) >> 3)] = V[(int) ((rd) >> 3)].As<float, ushort>().WithElement((int) ((rd) & 7), (ushort) ((ushort) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))))).As<ushort, float>();
							break;
						case 0x4:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1)))));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* FDIV-scalar */
				if((inst & 0xFF20FC00U) == 0x1E201800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x3:
							throw new NotImplementedException();
							break;
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((float) (V[rn >> 2].GetElement((int) rn & 3))) / (float) ((float) (V[rm >> 2].GetElement((int) rm & 3)))));
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))) / (double) ((double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1))))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
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
						case 0x66:
							r1 = "W";
							r2 = "H";
							break;
						case 0xE6:
							r1 = "X";
							r2 = "H";
							break;
						case 0x67:
							r1 = "H";
							r2 = "W";
							break;
						case 0x7:
							r1 = "S";
							r2 = "W";
							break;
						case 0x6:
							r1 = "W";
							r2 = "S";
							break;
						case 0xE7:
							r1 = "H";
							r2 = "X";
							break;
						case 0xA7:
							r1 = "D";
							r2 = "X";
							break;
						case 0xCF:
							r1 = "V";
							r2 = "X";
							break;
						case 0xCE:
							r1 = "X";
							r2 = "V";
							break;
						case 0xA6:
							r1 = "X";
							r2 = "D";
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					var index1 = (string) (((byte) (((r1) == ("V")) ? 1U : 0U) != 0) ? (".D[1]") : (""));
					var index2 = (string) (((byte) (((r2) == ("V")) ? 1U : 0U) != 0) ? (".D[1]") : (""));
					switch(tf) {
						case 0x66:
							W[(int) rd] = (uint) ((uint) ((uint) ((float) (V[rn >> 3].As<float, ushort>().GetElement((int) rn & 7)))));
							break;
						case 0xE6:
							X[(int) rd] = (ulong) ((ulong) ((float) (V[rn >> 3].As<float, ushort>().GetElement((int) rn & 7))));
							break;
						case 0x67:
							V[(int) ((rd) >> 3)] = V[(int) ((rd) >> 3)].As<float, ushort>().WithElement((int) ((rd) & 7), (ushort) ((ushort) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))).As<ushort, float>();
							break;
						case 0x7:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) (Bitcast<uint, float>((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
							break;
						case 0x6:
							W[(int) rd] = (uint) ((uint) (Bitcast<float, uint>((float) (V[rn >> 2].GetElement((int) rn & 3)))));
							break;
						case 0xE7:
							V[(int) ((rd) >> 3)] = V[(int) ((rd) >> 3)].As<float, ushort>().WithElement((int) ((rd) & 7), (ushort) ((ushort) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))).As<ushort, float>();
							break;
						case 0xA7:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) (Bitcast<ulong, double>((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))).As<double, float>();
							break;
						case 0xA6:
							X[(int) rd] = (ulong) (Bitcast<double, ulong>((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))));
							break;
						case 0xCE:
							X[(int) rd] = (ulong) (Bitcast<double, ulong>((double) (V[(byte) ((ulong) ((byte) ((rn) << (int) (0x1))) | (ulong) (0x1)) >> 1].As<float, double>().GetElement((int) (byte) ((ulong) ((byte) ((rn) << (int) (0x1))) | (ulong) (0x1)) & 1))));
							break;
						case 0xCF:
							V[(int) (((byte) ((ulong) ((byte) ((rd) << (int) (0x1))) | (ulong) (0x1))) >> 1)] = V[(int) (((byte) ((ulong) ((byte) ((rd) << (int) (0x1))) | (ulong) (0x1))) >> 1)].As<float, double>().WithElement((int) (((byte) ((ulong) ((byte) ((rd) << (int) (0x1))) | (ulong) (0x1))) & 1), (double) (Bitcast<ulong, double>((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* FMOV-scalar-immediate */
				if((inst & 0xFF201FE0U) == 0x1E201000U) {
					var type = (inst >> 22) & 0x3U;
					var imm = (inst >> 13) & 0xFFU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					var sv = (float) (Bitcast<uint, float>((uint) ((uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (((uint) ((uint) ((uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (((uint) ((byte) ((byte) (0x0)))) << 0)) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 1)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 2)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 3)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 4)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 5)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 6)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 7)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 8)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 9)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 10)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 11)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 12)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 13)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 14)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 15)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 16)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 17)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 18)))))) << 0)) | ((uint) (((uint) ((byte) ((byte) ((byte) ((ulong) (imm) & (ulong) (0xF)))))) << 19)))) | ((uint) (((uint) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x4))) & (ulong) (0x3)))))) << 23)))) | ((uint) (((uint) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 0)) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 1)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 2)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 3)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 4)))))) << 25)))) | ((uint) (((uint) ((byte) (((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1))) != 0 ? 0U : 1U))) << 30)))) | ((uint) (((uint) ((byte) ((byte) ((byte) ((imm) >> (int) (0x7)))))) << 31))))));
					switch(type) {
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), sv);
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) (Bitcast<ulong, double>((ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 1)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 2)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 3)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 4)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 5)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 6)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 7)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 8)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 9)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 10)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 11)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 12)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 13)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 14)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 15)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 16)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 17)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 18)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 19)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 20)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 21)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 22)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 23)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 24)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 25)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 26)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 27)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 28)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 29)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 30)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 31)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 32)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 33)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 34)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 35)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 36)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 37)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 38)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 39)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 40)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 41)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 42)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 43)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 44)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 45)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 46)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 47)))))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((ulong) (imm) & (ulong) (0xF)))))) << 48)))) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x4))) & (ulong) (0x3)))))) << 52)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 0)) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 1)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 2)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 3)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 4)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 5)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 6)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1)))))) << 7)))))) << 54)))) | ((ulong) (((ulong) ((byte) (((byte) ((ulong) ((byte) ((imm) >> (int) (0x6))) & (ulong) (0x1))) != 0 ? 0U : 1U))) << 62)))) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((imm) >> (int) (0x7)))))) << 63))))))).As<double, float>();
							break;
					}
					return true;
				}
				/* FMUL-scalar */
				if((inst & 0xFF20FC00U) == 0x1E200800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x3:
							throw new NotImplementedException();
							break;
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((float) (V[rn >> 2].GetElement((int) rn & 3))) * (float) ((float) (V[rm >> 2].GetElement((int) rm & 3)))));
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))) * (double) ((double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1))))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* FNEG */
				if((inst & 0xFF3FFC00U) == 0x1E214000U) {
					var type = (inst >> 22) & 0x3U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) (-((float) (V[rn >> 2].GetElement((int) rn & 3)))));
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) (-((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* FSQRT-scalar */
				if((inst & 0xFF3FFC00U) == 0x1E21C000U) {
					var type = (inst >> 22) & 0x3U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x3:
							throw new NotImplementedException();
							break;
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) Math.Sqrt((double) ((float) (V[rn >> 2].GetElement((int) rn & 3))))));
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) Math.Sqrt((double) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1)))))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* FSUB-scalar */
				if((inst & 0xFF20FC00U) == 0x1E203800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x3:
							throw new NotImplementedException();
							break;
						case 0x0:
							V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((float) (V[rn >> 2].GetElement((int) rn & 3))) - (float) ((float) (V[rm >> 2].GetElement((int) rm & 3)))));
							break;
						case 0x1:
							V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))) - (double) ((double) (V[rm >> 1].As<float, double>().GetElement((int) rm & 1))))).As<double, float>();
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* INS */
				if((inst & 0xFFE0FC00U) == 0x4E001C00U) {
					var imm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var ts = "";
					var index = (uint) ((uint) (0x0));
					var r = "W";
					if(((byte) ((((byte) ((ulong) (imm) & (ulong) (0x1))) == (0x1)) ? 1U : 0U)) != 0) {
						ts = "B";
						index = (byte) ((imm) >> (int) (0x1));
					} else {
						if(((byte) ((((byte) ((ulong) (imm) & (ulong) (0x2))) == (0x2)) ? 1U : 0U)) != 0) {
							ts = "H";
							index = (byte) ((imm) >> (int) (0x2));
						} else {
							if(((byte) ((((byte) ((ulong) (imm) & (ulong) (0x4))) == (0x4)) ? 1U : 0U)) != 0) {
								ts = "S";
								index = (byte) ((imm) >> (int) (0x3));
							} else {
								ts = "D";
								index = (byte) ((imm) >> (int) (0x4));
								r = "X";
							}
						}
					}
					if(((byte) ((((byte) ((ulong) (imm) & (ulong) (0x1))) == (0x1)) ? 1U : 0U)) != 0) {
						V[(int) ((index) >> 4)] = V[(int) ((index) >> 4)].As<float, byte>().WithElement((int) ((index) & 15), (byte) ((byte) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))).As<byte, float>();
					} else {
						if(((byte) ((((byte) ((ulong) (imm) & (ulong) (0x2))) == (0x2)) ? 1U : 0U)) != 0) {
							V[(int) ((index) >> 3)] = V[(int) ((index) >> 3)].As<float, ushort>().WithElement((int) ((index) & 7), (ushort) ((ushort) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))).As<ushort, float>();
						} else {
							if(((byte) ((((byte) ((ulong) (imm) & (ulong) (0x4))) == (0x4)) ? 1U : 0U)) != 0) {
								V[(int) ((index) >> 2)] = V[(int) ((index) >> 2)].WithElement((int) ((index) & 3), (float) ((float) ((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))))));
							} else {
								V[(int) ((index) >> 1)] = V[(int) ((index) >> 1)].As<float, double>().WithElement((int) ((index) & 1), (double) ((double) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))))).As<double, float>();
							}
						}
					}
					return true;
				}
				/* LDARB */
				if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					X[(int) rt] = (ulong) ((ulong) ((byte) (*(byte*) (address))));
					return true;
				}
				/* LDARH */
				if((inst & 0xFFFFFC00U) == 0x48DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					X[(int) rt] = (ulong) ((ulong) ((ushort) (*(ushort*) (address))));
					return true;
				}
				/* LDAXB */
				if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) (*(uint*) (address)));
					} else {
						X[(int) rt] = (ulong) (*(ulong*) (address));
					}
					return true;
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
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt1] = (uint) ((uint) (*(uint*) (address)));
						W[(int) rt2] = (uint) ((uint) (*(uint*) ((ulong) ((ulong) (address) + (ulong) (0x4)))));
					} else {
						X[(int) rt1] = (ulong) (*(ulong*) (address));
						X[(int) rt2] = (ulong) (*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))));
					}
					if(rn == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rn] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (simm));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt1] = (uint) ((uint) (*(uint*) (address)));
						W[(int) rt2] = (uint) ((uint) (*(uint*) ((ulong) ((ulong) (address) + (ulong) (0x4)))));
					} else {
						X[(int) rt1] = (ulong) (*(ulong*) (address));
						X[(int) rt2] = (ulong) (*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))));
					}
					return true;
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
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					switch(opc) {
						case 0x0:
							V[(int) ((rt1) >> 2)] = V[(int) ((rt1) >> 2)].WithElement((int) ((rt1) & 3), (float) (*(float*) (address)));
							V[(int) ((rt2) >> 2)] = V[(int) ((rt2) >> 2)].WithElement((int) ((rt2) & 3), (float) (*(float*) ((ulong) ((ulong) (address) + (ulong) (0x4)))));
							break;
						case 0x1:
							V[(int) ((rt1) >> 1)] = V[(int) ((rt1) >> 1)].As<float, double>().WithElement((int) ((rt1) & 1), (double) (*(double*) (address))).As<double, float>();
							V[(int) ((rt2) >> 1)] = V[(int) ((rt2) >> 1)].As<float, double>().WithElement((int) ((rt2) & 1), (double) (*(double*) ((ulong) ((ulong) (address) + (ulong) (0x8))))).As<double, float>();
							break;
						default:
							V[rt1] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
							V[rt2] = (Vector128<float>) (Sse.LoadVector128((float*) ((ulong) ((ulong) (address) + (ulong) (0x10)))));
							break;
					}
					if(rn == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rn] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (simm));
					switch(opc) {
						case 0x0:
							V[(int) ((rt1) >> 2)] = V[(int) ((rt1) >> 2)].WithElement((int) ((rt1) & 3), (float) (*(float*) (address)));
							V[(int) ((rt2) >> 2)] = V[(int) ((rt2) >> 2)].WithElement((int) ((rt2) & 3), (float) (*(float*) ((ulong) ((ulong) (address) + (ulong) (0x4)))));
							break;
						case 0x1:
							V[(int) ((rt1) >> 1)] = V[(int) ((rt1) >> 1)].As<float, double>().WithElement((int) ((rt1) & 1), (double) (*(double*) (address))).As<double, float>();
							V[(int) ((rt2) >> 1)] = V[(int) ((rt2) >> 1)].As<float, double>().WithElement((int) ((rt2) & 1), (double) (*(double*) ((ulong) ((ulong) (address) + (ulong) (0x8))))).As<double, float>();
							break;
						default:
							V[rt1] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
							V[rt2] = (Vector128<float>) (Sse.LoadVector128((float*) ((ulong) ((ulong) (address) + (ulong) (0x10)))));
							break;
					}
					return true;
				}
				/* LDR-immediate-preindex */
				if((inst & 0xBFE00C00U) == 0xB8400C00U) {
					var size = (inst >> 30) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (*(uint*) (address)));
					} else {
						X[(int) rd] = (ulong) (*(ulong*) (address));
					}
					if(rn == 31)
						SP = address;
					else
						X[(int) rn] = address;
					return true;
				}
				/* LDR-immediate-postindex */
				if((inst & 0xBFE00C00U) == 0xB8400400U) {
					var size = (inst >> 30) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (long) (SignExt<long>(rawimm, 9));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (*(uint*) ((ulong) ((rn) == 31 ? SP : X[(int) rn]))));
					} else {
						X[(int) rd] = (ulong) (*(ulong*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])));
					}
					if(rn == 31)
						SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					else
						X[(int) rn] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					return true;
				}
				/* LDR-immediate-unsigned-offset */
				if((inst & 0xBFC00000U) == 0xB9400000U) {
					var size = (inst >> 30) & 0x1U;
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (ushort) ((rawimm) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))));
					} else {
						X[(int) rd] = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
					}
					return true;
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
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0:
							V[(int) ((rt) >> 4)] = V[(int) ((rt) >> 4)].As<float, byte>().WithElement((int) ((rt) & 15), (byte) (*(byte*) (address))).As<byte, float>();
							break;
						case 0x2:
							V[(int) ((rt) >> 3)] = V[(int) ((rt) >> 3)].As<float, ushort>().WithElement((int) ((rt) & 7), (ushort) (*(ushort*) (address))).As<ushort, float>();
							break;
						case 0x4:
							V[(int) ((rt) >> 2)] = V[(int) ((rt) >> 2)].WithElement((int) ((rt) & 3), (float) (*(float*) (address)));
							break;
						case 0x6:
							V[(int) ((rt) >> 1)] = V[(int) ((rt) >> 1)].As<float, double>().WithElement((int) ((rt) & 1), (double) (*(double*) (address))).As<double, float>();
							break;
						case 0x1:
							V[rt] = (Vector128<float>) (*(Vector128<float>*) (address));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					if(rn == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rn] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
				}
				/* LDR-simd-immediate-unsigned-offset */
				if((inst & 0x3F400000U) == 0x3D400000U) {
					var size = (inst >> 30) & 0x3U;
					var ropc = (inst >> 23) & 0x1U;
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var opc = (byte) ((byte) (((byte) (((byte) ((byte) ((byte) (0x1)))) << 0)) | ((byte) (((byte) (ropc)) << 1))));
					var m = (byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 2))));
					var r = (string) ((m) switch { 0x1 => "B", 0x5 => "H", 0x9 => "S", 0xD => "D", _ => "Q" });
					switch(m) {
						case 0x1:
							V[(int) ((rt) >> 4)] = V[(int) ((rt) >> 4)].As<float, byte>().WithElement((int) ((rt) & 15), (byte) (*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))))).As<byte, float>();
							break;
						case 0x5:
							V[(int) ((rt) >> 3)] = V[(int) ((rt) >> 3)].As<float, ushort>().WithElement((int) ((rt) & 7), (ushort) (*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ushort) ((imm) << (int) (0x1))))))).As<ushort, float>();
							break;
						case 0x9:
							V[(int) ((rt) >> 2)] = V[(int) ((rt) >> 2)].WithElement((int) ((rt) & 3), (float) (*(float*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ushort) ((imm) << (int) (0x2)))))));
							break;
						case 0xD:
							V[(int) ((rt) >> 1)] = V[(int) ((rt) >> 1)].As<float, double>().WithElement((int) ((rt) & 1), (double) (*(double*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ushort) ((imm) << (int) (0x3))))))).As<double, float>();
							break;
						default:
							V[rt] = (Vector128<float>) (*(Vector128<float>*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ushort) ((imm) << (int) (0x4))))));
							break;
					}
					return true;
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset)))));
					} else {
						X[(int) rt] = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))));
					}
					return true;
				}
				/* LDRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					W[(int) rt] = (uint) ((uint) ((uint) ((byte) (*(byte*) ((ulong) ((rn) == 31 ? SP : X[(int) rn]))))));
					if(rn == 31)
						SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					else
						X[(int) rn] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					return true;
				}
				/* LDRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					W[(int) rt] = (uint) ((uint) ((uint) ((byte) (*(byte*) (address)))));
					if(rn == 31)
						SP = address;
					else
						X[(int) rn] = address;
					return true;
				}
				/* LDRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39400000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					X[(int) rt] = (ulong) ((ulong) ((byte) (*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))))));
					return true;
				}
				/* LDRB-register */
				if((inst & 0xFFE00C00U) == 0x38600800U) {
					var rm = (inst >> 16) & 0x1FU;
					var option = (inst >> 13) & 0x7U;
					var amount = (inst >> 12) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
					var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					W[(int) rt] = (uint) ((byte) (*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset)))));
					return true;
				}
				/* LDRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					W[(int) rt] = (uint) ((uint) ((uint) ((ushort) (*(ushort*) ((ulong) ((rn) == 31 ? SP : X[(int) rn]))))));
					if(rn == 31)
						SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					else
						X[(int) rn] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm));
					return true;
				}
				/* LDRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79400000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					X[(int) rt] = (ulong) ((ulong) ((ushort) (*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))))));
					return true;
				}
				/* LDRH-register */
				if((inst & 0xFFE00C00U) == 0x78600800U) {
					var rm = (inst >> 16) & 0x1FU;
					var option = (inst >> 13) & 0x7U;
					var amount = (inst >> 12) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ("X") : ("W"));
					var str = (string) ((option) switch { 0x2 => "UXTW", 0x3 => "LSL", 0x6 => "SXTW", 0x7 => "SXTX", _ => throw new NotImplementedException() });
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					W[(int) rt] = (uint) ((ushort) (*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset)))));
					return true;
				}
				/* LDRSB-immediate-unsigned-offset */
				if((inst & 0xFF800000U) == 0x39800000U) {
					var size = (inst >> 22) & 0x1U;
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((byte) (*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))), 8)))));
					} else {
						X[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((byte) (*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))), 8))));
					}
					return true;
				}
				/* LDRSH-immediate-postindex */
				if((inst & 0xFFA00C00U) == 0x78800400U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) (address)), 16)))));
					} else {
						X[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) (address)), 16))));
					}
					if(rn == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (imm));
					else
						X[(int) rn] = (ulong) ((ulong) (address) + (ulong) (imm));
					return true;
				}
				/* LDRSH-immediate-unsigned-offset */
				if((inst & 0xFF800000U) == 0x79800000U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (ushort) ((rawimm) << (int) (0x1));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))), 16)))));
					} else {
						X[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))), 16))));
					}
					return true;
				}
				/* LDRSW-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0xB9800000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x2));
					X[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))), 32))));
					return true;
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					X[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset)))), 32))));
					return true;
				}
				/* LDUR */
				if((inst & 0xBFE00C00U) == 0xB8400000U) {
					var size = (inst >> 30) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (long) (SignExt<long>(rawimm, 9));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))));
					} else {
						X[(int) rd] = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
					}
					return true;
				}
				/* LDURB */
				if((inst & 0xFFE00C00U) == 0x38400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					X[(int) rd] = (ulong) ((ulong) ((byte) (*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))))));
					return true;
				}
				/* LDURH */
				if((inst & 0xFFE00C00U) == 0x78400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					X[(int) rd] = (ulong) ((ulong) ((ushort) (*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))))));
					return true;
				}
				/* LDXR */
				if((inst & 0xBFFFFC00U) == 0x885F7C00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) (*(uint*) ((ulong) ((rn) == 31 ? SP : X[(int) rn]))));
					} else {
						X[(int) rt] = (ulong) (*(ulong*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])));
					}
					return true;
				}
				/* LSL-register */
				if((inst & 0x7FE0FC00U) == 0x1AC02000U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (((uint) ((rn) == 31 ? 0U : W[(int) rn])) << (int) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))));
					} else {
						X[(int) rd] = (ulong) (((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) << (int) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])));
					}
					return true;
				}
				/* LSRV */
				if((inst & 0x7FE0FC00U) == 0x1AC02400U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (((uint) ((rn) == 31 ? 0U : W[(int) rn])) >> (int) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))));
					} else {
						X[(int) rd] = (ulong) (((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) >> (int) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])));
					}
					return true;
				}
				/* MADD */
				if((inst & 0x7FE08000U) == 0x1B000000U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) * (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) + (uint) ((uint) ((ra) == 31 ? 0U : W[(int) ra]))));
					} else {
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) * (ulong) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])))) + (ulong) ((ulong) ((ra) == 31 ? 0UL : X[(int) ra])));
					}
					return true;
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
					V[rd] = (Vector128<float>) (Vector128.Create(imm).As<ulong, float>());
					return true;
				}
				/* MOVK */
				if((inst & 0x7F800000U) == 0x72800000U) {
					var size = (inst >> 31) & 0x1U;
					var hw = (inst >> 21) & 0x3U;
					var imm = (inst >> 5) & 0xFFFFU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var shift = (byte) ((hw) << (int) (0x4));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((uint) ((uint) ((rd) == 31 ? 0U : W[(int) rd])) & (uint) ((uint) ((uint) ((uint) ((uint) (-0x1))) ^ (uint) ((uint) (((uint) ((uint) (0xFFFF))) << (int) (shift))))))) | (uint) ((uint) (((uint) ((uint) (imm))) << (int) (shift)))));
					} else {
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ulong) ((ulong) ((rd) == 31 ? 0UL : X[(int) rd])) & (ulong) ((ulong) ((ulong) ((ulong) ((ulong) (-0x1))) ^ (ulong) ((ulong) (((ulong) ((ulong) (0xFFFF))) << (int) (shift))))))) | (ulong) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))));
					}
					return true;
				}
				/* MOVN */
				if((inst & 0x7F800000U) == 0x12800000U) {
					var size = (inst >> 31) & 0x1U;
					var hw = (inst >> 21) & 0x3U;
					var imm = (inst >> 5) & 0xFFFFU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var shift = (byte) ((hw) << (int) (0x4));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (~((uint) (((uint) ((uint) (imm))) << (int) (shift)))));
					} else {
						X[(int) rd] = (ulong) (~((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))));
					}
					return true;
				}
				/* MOVZ */
				if((inst & 0x7F800000U) == 0x52800000U) {
					var size = (inst >> 31) & 0x1U;
					var hw = (inst >> 21) & 0x3U;
					var imm = (inst >> 5) & 0xFFFFU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var shift = (byte) ((hw) << (int) (0x4));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (((uint) ((uint) (imm))) << (int) (shift)));
					} else {
						X[(int) rd] = (ulong) (((ulong) ((ulong) (imm))) << (int) (shift));
					}
					return true;
				}
				/* MRS */
				if((inst & 0xFFF00000U) == 0xD5300000U) {
					var op0 = (inst >> 19) & 0x1U;
					var op1 = (inst >> 16) & 0x7U;
					var cn = (inst >> 12) & 0xFU;
					var cm = (inst >> 8) & 0xFU;
					var op2 = (inst >> 5) & 0x7U;
					var rt = (inst >> 0) & 0x1FU;
					X[(int) rt] = (ulong) (SR(op0, op1, cn, cm, op2));
					return true;
				}
				/* MSR-register */
				if((inst & 0xFFF00000U) == 0xD5100000U) {
					var op0 = (inst >> 19) & 0x1U;
					var op1 = (inst >> 16) & 0x7U;
					var cn = (inst >> 12) & 0xFU;
					var cm = (inst >> 8) & 0xFU;
					var op2 = (inst >> 5) & 0x7U;
					var rt = (inst >> 0) & 0x1FU;
					SR(op0, op1, cn, cm, op2, (ulong) ((rt) == 31 ? 0UL : X[(int) rt]));
					return true;
				}
				/* MSUB */
				if((inst & 0x7FE08000U) == 0x1B008000U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((ra) == 31 ? 0U : W[(int) ra])) - (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) * (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))))));
					} else {
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ra) == 31 ? 0UL : X[(int) ra])) - (ulong) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) * (ulong) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])))));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) (~((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) }))))));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) | (ulong) ((ulong) (~((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })))));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) ((uint) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) ((uint) (imm)))));
					} else {
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) | (ulong) (imm));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) | (ulong) (imm));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) }))));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) | (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })));
					}
					return true;
				}
				/* ORR-simd-register */
				if((inst & 0xBFE0FC00U) == 0x0EA01C00U) {
					var q = (inst >> 30) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) (((q) == (0x0)) ? 1U : 0U) != 0) ? ("8B") : ("16B"));
					if(((byte) (((rm) == (rn)) ? 1U : 0U)) != 0) {
						V[rd] = (Vector128<float>) (V[rn]);
					} else {
						throw new NotImplementedException();
					}
					return true;
				}
				/* RBIT */
				if((inst & 0x7FFFFC00U) == 0x5AC00000U) {
					var size = (inst >> 31) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (ReverseBits((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
					} else {
						X[(int) rd] = (ulong) (ReverseBits((ulong) ((rn) == 31 ? 0UL : X[(int) rn])));
					}
					return true;
				}
				/* RET */
				if((inst & 0xFFFFFC1FU) == 0xD65F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((ulong) ((rn) == 31 ? 0UL : X[(int) rn]));
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var src = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = (uint) ((uint) ((uint) (((src) << (32 - (int) (immr))) | ((src) >> (int) (immr)))) & (uint) (wmask));
						var top = (uint) ((uint) ((uint) ((uint) (0x0))) - (uint) ((uint) ((ulong) ((uint) ((src) >> (int) (imms))) & (ulong) (0x1))));
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((uint) (top) & (uint) ((uint) (~(tmask))))) | (uint) ((uint) ((uint) (bot) & (uint) (tmask)))));
					} else {
						var src = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr)))) & (ulong) (wmask));
						var top = (ulong) ((ulong) ((ulong) ((ulong) (0x0))) - (ulong) ((ulong) ((ulong) ((ulong) ((src) >> (int) (imms))) & (ulong) (0x1))));
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ulong) (top) & (ulong) ((ulong) (~(tmask))))) | (ulong) ((ulong) ((ulong) (bot) & (ulong) (tmask))));
					}
					return true;
				}
				/* SDIV */
				if((inst & 0x7FE0FC00U) == 0x1AC00C00U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var operand2 = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((uint) ((uint) (0x0))) : ((uint) ((uint) ((float) ((float) ((float) ((float) ((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))))) / (float) ((float) ((float) ((int) ((int) (operand2)))))))))));
					} else {
						var operand2 = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) (0x0))) : ((ulong) ((ulong) ((double) ((double) ((double) ((double) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))))) / (double) ((double) ((double) ((long) ((long) (operand2))))))))));
					}
					return true;
				}
				/* SMADDL */
				if((inst & 0xFFE08000U) == 0x9B200000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					X[(int) rd] = (ulong) ((ulong) ((long) ((long) ((long) ((long) ((ulong) ((ra) == 31 ? 0UL : X[(int) ra])))) + (long) ((long) (SignExt<long>((uint) ((uint) ((int) ((int) ((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))) * (int) ((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))))))), 32))))));
					return true;
				}
				/* SMULH */
				if((inst & 0xFFE0FC00U) == 0x9B407C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					X[(int) rd] = (ulong) ((ulong) ((long) ((long) ((Int128) (((Int128) ((Int128) ((Int128) ((Int128) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))))) * (Int128) ((Int128) ((Int128) ((long) ((long) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])))))))) >> (int) (0x40))))));
					return true;
				}
				/* STLR */
				if((inst & 0xBFFFFC00U) == 0x889FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) = (ulong) ((rt) == 31 ? 0UL : X[(int) rt]);
					}
					return true;
				}
				/* STLRB */
				if((inst & 0xFFFFFC00U) == 0x089FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					*(byte*) (address) = (byte) ((byte) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
					return true;
				}
				/* STLRH */
				if((inst & 0xFFFFFC00U) == 0x489FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					*(ushort*) (address) = (ushort) ((ushort) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
					return true;
				}
				/* STLXR */
				if((inst & 0xBFE0FC00U) == 0x8800FC00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) (address) = (ulong) ((rt) == 31 ? 0UL : X[(int) rt]);
					}
					W[(int) rs] = (uint) (0x0);
					return true;
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
					var address = (ulong) ((rd) == 31 ? SP : X[(int) rd]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt1) == 31 ? 0U : W[(int) rt1]);
						*(uint*) ((ulong) ((ulong) (address) + (ulong) (0x4))) = (uint) ((rt2) == 31 ? 0U : W[(int) rt2]);
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : X[(int) rt1]);
						*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))) = (ulong) ((rt2) == 31 ? 0UL : X[(int) rt2]);
					}
					if(rd == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rd] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt1) == 31 ? 0U : W[(int) rt1]);
						*(uint*) ((ulong) ((ulong) (address) + (ulong) (0x4))) = (uint) ((rt2) == 31 ? 0U : W[(int) rt2]);
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : X[(int) rt1]);
						*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))) = (ulong) ((rt2) == 31 ? 0UL : X[(int) rt2]);
					}
					if(rd == 31)
						SP = address;
					else
						X[(int) rd] = address;
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt1) == 31 ? 0U : W[(int) rt1]);
						*(uint*) ((ulong) ((ulong) (address) + (ulong) (0x4))) = (uint) ((rt2) == 31 ? 0U : W[(int) rt2]);
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : X[(int) rt1]);
						*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))) = (ulong) ((rt2) == 31 ? 0UL : X[(int) rt2]);
					}
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					switch(opc) {
						case 0x0:
							*(float*) (address) = (float) (V[rt1 >> 2].GetElement((int) rt1 & 3));
							*(float*) ((ulong) ((ulong) (address) + (ulong) (0x4))) = (float) (V[rt2 >> 2].GetElement((int) rt2 & 3));
							break;
						case 0x1:
							*(double*) (address) = (double) (V[rt1 >> 1].As<float, double>().GetElement((int) rt1 & 1));
							*(double*) ((ulong) ((ulong) (address) + (ulong) (0x8))) = (double) (V[rt2 >> 1].As<float, double>().GetElement((int) rt2 & 1));
							break;
						case 0x2:
							Sse.Store((float*) (address), (Vector128<float>) (V[rt1]));
							Sse.Store((float*) ((ulong) ((ulong) (address) + (ulong) (0x10))), (Vector128<float>) (V[rt2]));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					if(rd == 31)
						SP = address;
					else
						X[(int) rd] = address;
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					switch(opc) {
						case 0x0:
							*(float*) (address) = (float) (V[rt1 >> 2].GetElement((int) rt1 & 3));
							*(float*) ((ulong) ((ulong) (address) + (ulong) (0x4))) = (float) (V[rt2 >> 2].GetElement((int) rt2 & 3));
							break;
						case 0x1:
							*(double*) (address) = (double) (V[rt1 >> 1].As<float, double>().GetElement((int) rt1 & 1));
							*(double*) ((ulong) ((ulong) (address) + (ulong) (0x8))) = (double) (V[rt2 >> 1].As<float, double>().GetElement((int) rt2 & 1));
							break;
						case 0x2:
							Sse.Store((float*) (address), (Vector128<float>) (V[rt1]));
							Sse.Store((float*) ((ulong) ((ulong) (address) + (ulong) (0x10))), (Vector128<float>) (V[rt2]));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* STR-immediate-postindex */
				if((inst & 0xBFE00C00U) == 0xB8000400U) {
					var size = (inst >> 30) & 0x1U;
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((rd) == 31 ? SP : X[(int) rd]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
					} else {
						*(ulong*) (address) = (ulong) ((rs) == 31 ? 0UL : X[(int) rs]);
					}
					if(rd == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rd] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
				}
				/* STR-immediate-preindex */
				if((inst & 0xBFE00C00U) == 0xB8000C00U) {
					var size = (inst >> 30) & 0x1U;
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
					} else {
						*(ulong*) (address) = (ulong) ((rs) == 31 ? 0UL : X[(int) rs]);
					}
					if(rd == 31)
						SP = address;
					else
						X[(int) rd] = address;
					return true;
				}
				/* STR-immediate-unsigned-offset */
				if((inst & 0xBFC00000U) == 0xB9000000U) {
					var size = (inst >> 30) & 0x1U;
					var imm = (inst >> 10) & 0xFFFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var pimm = (ulong) (((ulong) ((ulong) (imm))) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (pimm))) = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
					} else {
						*(ulong*) ((ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (pimm))) = (ulong) ((rs) == 31 ? 0UL : X[(int) rs]);
					}
					return true;
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (ulong) ((rt) == 31 ? 0UL : X[(int) rt]);
					}
					return true;
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
					var address = (ulong) ((rn) == 31 ? SP : X[(int) rn]);
					switch(rop) {
						case 0x0:
							*(float*) (address) = (float) (V[rt >> 4].As<float, byte>().GetElement((int) rt & 15));
							break;
						case 0x4:
							*(float*) (address) = (float) (V[rt >> 3].As<float, ushort>().GetElement((int) rt & 7));
							break;
						case 0x8:
							*(float*) (address) = (float) (V[rt >> 2].GetElement((int) rt & 3));
							break;
						case 0xC:
							*(double*) (address) = (double) (V[rt >> 1].As<float, double>().GetElement((int) rt & 1));
							break;
						case 0x2:
							Sse.Store((float*) (address), (Vector128<float>) (V[rt]));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					if(rn == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rn] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (simm));
					switch(rop) {
						case 0x0:
							*(float*) (address) = (float) (V[rt >> 4].As<float, byte>().GetElement((int) rt & 15));
							break;
						case 0x4:
							*(float*) (address) = (float) (V[rt >> 3].As<float, ushort>().GetElement((int) rt & 7));
							break;
						case 0x8:
							*(float*) (address) = (float) (V[rt >> 2].GetElement((int) rt & 3));
							break;
						case 0xC:
							*(double*) (address) = (double) (V[rt >> 1].As<float, double>().GetElement((int) rt & 1));
							break;
						case 0x2:
							Sse.Store((float*) (address), (Vector128<float>) (V[rt]));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					if(rn == 31)
						SP = address;
					else
						X[(int) rn] = address;
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ushort) ((imm) << (int) (scale))));
					switch(rop) {
						case 0x0:
							*(float*) (address) = (float) (V[rt >> 4].As<float, byte>().GetElement((int) rt & 15));
							break;
						case 0x4:
							*(float*) (address) = (float) (V[rt >> 3].As<float, ushort>().GetElement((int) rt & 7));
							break;
						case 0x8:
							*(float*) (address) = (float) (V[rt >> 2].GetElement((int) rt & 3));
							break;
						case 0xC:
							*(double*) (address) = (double) (V[rt >> 1].As<float, double>().GetElement((int) rt & 1));
							break;
						case 0x2:
							Sse.Store((float*) (address), (Vector128<float>) (V[rt]));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* STRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38000400U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((rd) == 31 ? SP : X[(int) rd]);
					*(byte*) (address) = (byte) ((byte) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rd] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
				}
				/* STRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					*(byte*) (address) = (byte) ((byte) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = address;
					else
						X[(int) rd] = address;
					return true;
				}
				/* STRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39000000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))) = (byte) ((byte) ((ulong) ((rt) == 31 ? 0UL : X[(int) rt])));
					return true;
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (byte) ((byte) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
					return true;
				}
				/* STRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78000400U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((rd) == 31 ? SP : X[(int) rd]);
					*(ushort*) (address) = (ushort) ((ushort) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = (ulong) ((ulong) (address) + (ulong) (simm));
					else
						X[(int) rd] = (ulong) ((ulong) (address) + (ulong) (simm));
					return true;
				}
				/* STRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((ulong) ((ulong) ((rd) == 31 ? SP : X[(int) rd])) + (ulong) (simm));
					*(ushort*) (address) = (ushort) ((ushort) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = address;
					else
						X[(int) rd] = address;
					return true;
				}
				/* STRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79000000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))) = (ushort) ((ushort) ((ulong) ((rt) == 31 ? 0UL : X[(int) rt])));
					return true;
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((ulong) (option) & (ulong) (0x1)) != 0) ? ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (ushort) ((ushort) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
					return true;
				}
				/* STUR */
				if((inst & 0xBFE00C00U) == 0xB8000000U) {
					var size = (inst >> 30) & 0x1U;
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var offset = (long) (SignExt<long>(imm, 9));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (ulong) ((rt) == 31 ? 0UL : X[(int) rt]);
					}
					return true;
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
					var address = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (simm));
					switch(rop) {
						case 0x0:
							*(float*) (address) = (float) (V[rt >> 4].As<float, byte>().GetElement((int) rt & 15));
							break;
						case 0x4:
							*(float*) (address) = (float) (V[rt >> 3].As<float, ushort>().GetElement((int) rt & 7));
							break;
						case 0x8:
							*(float*) (address) = (float) (V[rt >> 2].GetElement((int) rt & 3));
							break;
						case 0xC:
							*(double*) (address) = (double) (V[rt >> 1].As<float, double>().GetElement((int) rt & 1));
							break;
						case 0x2:
							Sse.Store((float*) (address), (Vector128<float>) (V[rt]));
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					return true;
				}
				/* STURB */
				if((inst & 0xFFE00C00U) == 0x38000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (byte) ((byte) ((ulong) ((rt) == 31 ? 0UL : X[(int) rt])));
					return true;
				}
				/* STURH */
				if((inst & 0xFFE00C00U) == 0x78000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					*(ushort*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (ushort) ((ushort) ((ulong) ((rt) == 31 ? 0UL : X[(int) rt])));
					return true;
				}
				/* STXR */
				if((inst & 0xBFE0FC00U) == 0x88007C00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) = (ulong) ((rt) == 31 ? 0UL : X[(int) rt]);
					}
					W[(int) rs] = (uint) (0x0);
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) - (uint) (simm)));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) - (uint) (simm)));
					} else {
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) (simm));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) (simm));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var m = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						if(rd == 31)
							SP = (ulong) (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) - (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (uint) ((ulong) (m) & (ulong) (0xFFFF)), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) - (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (uint) ((ulong) (m) & (ulong) (0xFFFF)), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm)))));
					} else {
						if(((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) << (int) (imm))));
							else
								X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) << (int) (imm))));
						} else {
							var m = (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
							if(rd == 31)
								SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (ulong) ((ulong) (m) & (ulong) (0xFFFF)), 0x2 => (ulong) ((ulong) (m) & (ulong) (0xFFFFFFFF)), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm))));
							else
								X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (ulong) ((ulong) (m) & (ulong) (0xFFFF)), 0x2 => (ulong) ((ulong) (m) & (ulong) (0xFFFFFFFF)), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm))));
						}
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var b = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) - (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() }))));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) - (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
					}
					return true;
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
					var r2 = (string) (((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
					var extend = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "LSL", 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => "LSL", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var m = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) (AddWithCarrySetNzcv((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn]), (uint) (~((uint) (((uint) ((option) switch { 0x0 => (uint) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (uint) ((ulong) (m) & (ulong) (0xFFFF)), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm)))), 0x1)));
					} else {
						if(((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U)) != 0) {
							X[(int) rd] = (ulong) (AddWithCarrySetNzcv((ulong) ((rn) == 31 ? SP : X[(int) rn]), (ulong) (~((ulong) (((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) << (int) (imm)))), 0x1));
						} else {
							var m = (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
							X[(int) rd] = (ulong) (AddWithCarrySetNzcv((ulong) ((rn) == 31 ? SP : X[(int) rn]), (ulong) (~((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((ulong) (m) & (ulong) (0xFF)), 0x1 => (ulong) ((ulong) (m) & (ulong) (0xFFFF)), 0x2 => (ulong) ((ulong) (m) & (ulong) (0xFFFFFFFF)), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm)))), 0x1));
						}
					}
					return true;
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
					if((mode32) != 0) {
						var operand1 = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var operand2 = (uint) (~((uint) (Shift((uint) ((rm) == 31 ? 0U : W[(int) rm]), shift, imm))));
						W[(int) rd] = (uint) ((uint) (AddWithCarrySetNzcv(operand1, operand2, 0x1)));
					} else {
						var operand1 = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var operand2 = (ulong) (~((ulong) (Shift((ulong) ((rm) == 31 ? 0UL : X[(int) rm]), shift, imm))));
						X[(int) rd] = (ulong) (AddWithCarrySetNzcv(operand1, operand2, 0x1));
					}
					return true;
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
					var rimm = (uint) ((shift != 0) ? ((uint) (((uint) ((uint) (imm))) << (int) (0xC))) : (imm));
					if((mode32) != 0) {
						var operand1 = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var operand2 = (uint) (~((uint) ((uint) (rimm))));
						W[(int) rd] = (uint) ((uint) (AddWithCarrySetNzcv(operand1, operand2, 0x1)));
					} else {
						var operand1 = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var operand2 = (ulong) (~((ulong) ((ulong) (rimm))));
						X[(int) rd] = (ulong) (AddWithCarrySetNzcv(operand1, operand2, 0x1));
					}
					return true;
				}
				/* SVC */
				if((inst & 0xFFE0001FU) == 0xD4000001U) {
					var imm = (inst >> 5) & 0xFFFFU;
					Svc(imm);
					return true;
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
					if(((byte) ((((ulong) ((ulong) ((ulong) (((ulong) ((rt) == 31 ? 0UL : X[(int) rt])) >> (int) (imm))) & (ulong) (0x1))) == (0x0)) ? 1U : 0U)) != 0) {
						Branch(addr);
					} else {
						Branch(pc + 4);
					}
					return true;
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
					if(((byte) ((((ulong) ((ulong) ((ulong) (((ulong) ((rt) == 31 ? 0UL : X[(int) rt])) >> (int) (imm))) & (ulong) (0x1))) != (0x0)) ? 1U : 0U)) != 0) {
						Branch(addr);
					} else {
						Branch(pc + 4);
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var src = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = (uint) ((uint) ((uint) (((src) << (32 - (int) (immr))) | ((src) >> (int) (immr)))) & (uint) (wmask));
						W[(int) rd] = (uint) ((uint) ((uint) (bot) & (uint) (tmask)));
					} else {
						var src = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr)))) & (ulong) (wmask));
						X[(int) rd] = (ulong) ((ulong) (bot) & (ulong) (tmask));
					}
					return true;
				}
				/* UCVTF */
				if((inst & 0xFFBFFC00U) == 0x7E21D800U) {
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						V[(int) ((rd) >> 2)] = V[(int) ((rd) >> 2)].WithElement((int) ((rd) & 3), (float) ((float) ((uint) (Bitcast<float, uint>((float) (V[rn >> 2].GetElement((int) rn & 3)))))));
					} else {
						V[(int) ((rd) >> 1)] = V[(int) ((rd) >> 1)].As<float, double>().WithElement((int) ((rd) & 1), (double) ((double) ((ulong) (Bitcast<double, ulong>((double) (V[rn >> 1].As<float, double>().GetElement((int) rn & 1))))))).As<double, float>();
					}
					return true;
				}
				/* UDIV */
				if((inst & 0x7FE0FC00U) == 0x1AC00800U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var operand2 = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((uint) ((uint) (0x0))) : ((uint) ((uint) ((float) ((float) ((float) ((float) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))) / (float) ((float) ((float) (operand2)))))))));
					} else {
						var operand2 = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) (0x0))) : ((ulong) ((ulong) ((double) ((double) ((double) ((double) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))) / (double) ((double) ((double) (operand2))))))));
					}
					return true;
				}
				/* UMADDL */
				if((inst & 0xFFE08000U) == 0x9BA00000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					X[(int) rd] = (ulong) ((ulong) ((ulong) ((ra) == 31 ? 0UL : X[(int) ra])) + (ulong) ((ulong) ((ulong) ((ulong) ((ulong) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))) * (ulong) ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))));
					return true;
				}
				/* UMULH */
				if((inst & 0xFFE0FC00U) == 0x9BC07C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					X[(int) rd] = (ulong) ((ulong) ((UInt128) (((UInt128) ((UInt128) ((UInt128) ((UInt128) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])))) * (UInt128) ((UInt128) ((UInt128) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])))))) >> (int) (0x40))));
					return true;
				}

			}
			return false;
		}

	}
}