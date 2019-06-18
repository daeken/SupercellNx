#pragma warning disable 162, 219
using System;

namespace Cpu64 {
	public partial class Interpreter : BaseCpu {
		public unsafe bool Interpret(uint inst, ulong pc) {
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
				if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
					if(rd == 31)
						SP = (ulong) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) + (uint) (simm)));
					else
						W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) + (uint) (simm));
				} else {
					if(rd == 31)
						SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) + (ulong) (simm));
					else
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) + (ulong) (simm));
				}
				return true;
			}
			/* ADRP */
			if((inst & 0x9F000000U) == 0x90000000U) {
				var immlo = (inst >> 29) & 0x3U;
				var immhi = (inst >> 5) & 0x7FFFFU;
				var rd = (inst >> 0) & 0x1FU;
				var imm = (long) (SignExt<long>((ulong) ((ulong) ((ulong) (((ulong) ((ulong) (immhi))) << (int) (0xE))) | (ulong) ((ushort) (((ushort) ((ushort) (immlo))) << (int) (0xC)))), 33));
				var addr = (ulong) ((ulong) ((ulong) (((ulong) (((ulong) (pc)) >> (int) (0xC))) << (int) (0xC))) + (ulong) (imm));
				if(rd != 31)
					X[(int) rd] = addr;
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
				var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) ((NZCV >> 30) & 1U), 0x1 => (byte) ((NZCV >> 29) & 1U), 0x2 => (byte) (NZCV >> 31), 0x3 => (byte) ((NZCV >> 28) & 1U), 0x4 => (byte) ((byte) ((byte) ((NZCV >> 29) & 1U)) & (byte) ((byte) (((byte) ((NZCV >> 30) & 1U)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV >> 31)) == ((byte) ((NZCV >> 28) & 1U))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV >> 31)) == ((byte) ((NZCV >> 28) & 1U))) ? 1U : 0U)) & (byte) ((byte) (((byte) ((NZCV >> 30) & 1U)) != 0 ? 0U : 1U))), _ => 0x1 });
				if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
					Branch(addr);
				} else {
					Branch(pc + 4);
				}
				return true;
			}
			/* BLR */
			if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
				var rn = (inst >> 5) & 0x1FU;
				if(0x1E != 31)
					X[(int) 0x1E] = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (0x4));
				Branch((ulong) ((rn) == 31 ? 0UL : X[(int) rn]));
				return true;
			}
			/* CBNZ */
			if((inst & 0x7F000000U) == 0x35000000U) {
				var size = (inst >> 31) & 0x1U;
				var imm = (inst >> 5) & 0x7FFFFU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) ((long) (SignExt<long>((uint) ((imm) << (int) (0x2)), 19))));
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
			/* LDR-immediate-postindex */
			if((inst & 0xBFE00C00U) == 0xB8400400U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 12) & 0x1FFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (long) (SignExt<long>(rawimm, 9));
				if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
					if(rd != 31)
						W[(int) rd] = (uint) (*(uint*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])));
				} else {
					if(rd != 31)
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
					if(rd == 31)
						SP = (ulong) ((uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm)))));
					else
						W[(int) rd] = (uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
				} else {
					if(rd == 31)
						SP = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
					else
						X[(int) rd] = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
				}
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
						SP = (ulong) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) - (uint) (simm)));
					else
						W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) - (uint) (simm));
				} else {
					if(rd == 31)
						SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) (simm));
					else
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) - (ulong) (simm));
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
				var mode32 = (byte) (((size) == (0x0)) ? 1U : 0U);
				var r = (string) ((mode32 != 0) ? ("W") : ("X"));
				var r2 = (string) (((byte) ((byte) (mode32) & (byte) ((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) != (0x3)) ? 1U : 0U))) != 0) ? ("W") : ("X"));
				var extend = (string) ((mode32 != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => (string) (((byte) (((rn) == (0x1F)) ? 1U : 0U) != 0) ? ("LSL") : ("UXTW")), 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => (string) (((byte) (((rn) == (0x1F)) ? 1U : 0U) != 0) ? ("LSL") : ("UXTX")), 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
				var amount = 0xDEAD;
				throw new NotImplementedException();
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
					if(rd != 31)
						W[(int) rd] = (uint) (AddWithCarrySetNzcv(operand1, operand2, 0x1));
				} else {
					var operand1 = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
					var operand2 = (ulong) (~((ulong) (Shift((ulong) ((rm) == 31 ? 0UL : X[(int) rm]), shift, imm))));
					if(rd != 31)
						X[(int) rd] = (ulong) (AddWithCarrySetNzcv(operand1, operand2, 0x1));
				}
				return true;
			}

			return false;
		}

	}
}