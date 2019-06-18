namespace Cpu64 {
	public partial class BaseCpu {
		public string? Disassemble(uint inst, ulong pc) {
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
			/* LDR-unsigned-offset */
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
			/* STR-preindex */
			if((inst & 0xBFE00C00U) == 0xB8000C00U) {
				var size = (inst >> 30) & 0x1U;
				var imm = (inst >> 12) & 0x1FFU;
				var rd = (inst >> 5) & 0x1FU;
				var rs = (inst >> 0) & 0x1FU;
				var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
				var simm = (long) (SignExt<long>(imm, 9));
				return $"str {r}{rs}, [X{rd}, #{(simm < 0 ? $"-0x{-simm}" : $"0x{simm}")}]!";
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

			return null;
		}
	}
}