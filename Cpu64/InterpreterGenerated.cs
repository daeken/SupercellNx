namespace Cpu64 {
	public partial class Interpreter : BaseCpu {
		public bool Interpret(uint inst, ulong pc) {
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
					W[(int) rd] = (uint) ((uint) ((uint) (W[(int) rn])) + (uint) (simm));
				} else {
					X[(int) rd] = (ulong) ((ulong) ((ulong) (X[(int) rn])) + (ulong) (simm));
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
				X[(int) rd] = addr;
				return true;
			}
			/* LDR-unsigned-offset */
			if((inst & 0xBFC00000U) == 0xB9400000U) {
				var size = (inst >> 30) & 0x1U;
				var rawimm = (inst >> 10) & 0xFFFU;
				var rn = (inst >> 5) & 0x1FU;
				var rd = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var imm = (ushort) ((rawimm) << (int) ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
				if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
					W[(int) rd] = (uint) (LoadMemory<uint>((ulong) ((ulong) ((ulong) (X[(int) rn])) + (ulong) (imm))));
				} else {
					X[(int) rd] = (ulong) (LoadMemory<ulong>((ulong) ((ulong) ((ulong) (X[(int) rn])) + (ulong) (imm))));
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
				var address = (ulong) ((ulong) ((ulong) (X[(int) rd])) + (ulong) (simm));
				if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
					StoreMemory(address, (uint) (W[(int) rt1]));
					StoreMemory((ulong) ((ulong) (address) + (ulong) (0x4)), (uint) (W[(int) rt2]));
				} else {
					StoreMemory(address, (ulong) (X[(int) rt1]));
					StoreMemory((ulong) ((ulong) (address) + (ulong) (0x8)), (ulong) (X[(int) rt2]));
				}
				return true;
			}
			/* STR-preindex */
			if((inst & 0xBFE00C00U) == 0xB8000C00U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (SignExt<long>(imm, 9));
				var address = (ulong) ((ulong) ((ulong) (X[(int) rd])) + (ulong) (simm));
				if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
					StoreMemory(address, (uint) (W[(int) rs]));
				} else {
					StoreMemory(address, (ulong) (X[(int) rs]));
				}
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
					W[(int) rd] = (uint) ((uint) ((uint) (W[(int) rn])) - (uint) (simm));
				} else {
					X[(int) rd] = (ulong) ((ulong) ((ulong) (X[(int) rn])) - (ulong) (simm));
				}
				return true;
			}

			return false;
		}

	}
}