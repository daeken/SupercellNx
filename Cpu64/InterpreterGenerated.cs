#pragma warning disable 162, 219
using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

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
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					throw new NotImplementedException();
					throw new NotImplementedException();
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
					var simm = (ushort) ((imm) << (int) (shift));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SP = (ulong) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) (simm)));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) (simm));
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
							SP = (ulong) ((uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() }))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) rn])) + (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
					} else {
						var b = (ulong) ((rm) == 31 ? SP : X[(int) rm]);
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
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
							SP = (ulong) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) ((uint) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) & (uint) ((uint) ((uint) (imm))));
					} else {
						if(rd == 31)
							SP = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) (imm));
						else
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) & (ulong) (imm));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) ((NZCV >> 30) & 1U), 0x1 => (byte) ((NZCV >> 29) & 1U), 0x2 => (byte) (NZCV >> 31), 0x3 => (byte) ((NZCV >> 28) & 1U), 0x4 => (byte) ((byte) ((byte) ((NZCV >> 29) & 1U)) & (byte) ((byte) (((byte) ((NZCV >> 30) & 1U)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV >> 31)) == ((byte) ((NZCV >> 28) & 1U))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV >> 31)) == ((byte) ((NZCV >> 28) & 1U))) ? 1U : 0U)) & (byte) ((byte) (((byte) ((NZCV >> 30) & 1U)) != 0 ? 0U : 1U))), _ => 0x1 });
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
						W[(int) rd] = (uint) ((uint) (bot) & (uint) (tmask));
					} else {
						var dst = (uint) ((rd) == 31 ? 0U : W[(int) rd]);
						var src = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (uint) ((ulong) ((uint) ((ulong) (dst) & (ulong) ((ulong) (~(wmask))))) | (ulong) ((ulong) ((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr)))) & (ulong) (wmask))));
						X[(int) rd] = (uint) ((uint) ((uint) ((ulong) (dst) & (ulong) ((ulong) (~(tmask))))) | (uint) ((uint) ((ulong) (bot) & (ulong) (tmask))));
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
				/* CSINC */
				if((inst & 0x7FE00C00U) == 0x1A800400U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var cond = (inst >> 12) & 0xFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) ((NZCV >> 30) & 1U), 0x1 => (byte) ((NZCV >> 29) & 1U), 0x2 => (byte) (NZCV >> 31), 0x3 => (byte) ((NZCV >> 28) & 1U), 0x4 => (byte) ((byte) ((byte) ((NZCV >> 29) & 1U)) & (byte) ((byte) (((byte) ((NZCV >> 30) & 1U)) != 0 ? 0U : 1U))), 0x5 => (byte) ((((byte) (NZCV >> 31)) == ((byte) ((NZCV >> 28) & 1U))) ? 1U : 0U), 0x6 => (byte) ((byte) ((byte) ((((byte) (NZCV >> 31)) == ((byte) ((NZCV >> 28) & 1U))) ? 1U : 0U)) & (byte) ((byte) (((byte) ((NZCV >> 30) & 1U)) != 0 ? 0U : 1U))), _ => 0x1 });
					if(((byte) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						} else {
							X[(int) rd] = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])) + (uint) ((uint) ((uint) (0x1))));
						} else {
							X[(int) rd] = (ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])) + (ulong) (0x1));
						}
					}
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
				/* LDP-signed-offset */
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
						W[(int) rt1] = (uint) (*(uint*) (address));
						W[(int) rt2] = (uint) (*(uint*) ((ulong) ((ulong) (address) + (ulong) (0x4))));
					} else {
						X[(int) rt1] = (ulong) (*(ulong*) (address));
						X[(int) rt2] = (ulong) (*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))));
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
						W[(int) rd] = (uint) (*(uint*) ((ulong) ((rn) == 31 ? SP : X[(int) rn])));
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
						W[(int) rd] = (uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
					} else {
						X[(int) rd] = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
					}
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
					var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
					throw new NotImplementedException();
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
						W[(int) rd] = (uint) (*(uint*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
					} else {
						X[(int) rd] = (ulong) (*(ulong*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (imm))));
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
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) * (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) + (uint) ((uint) ((ra) == 31 ? 0U : W[(int) ra])));
					} else {
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) * (ulong) ((ulong) ((rm) == 31 ? 0UL : X[(int) rm])))) + (ulong) ((ulong) ((ra) == 31 ? 0UL : X[(int) ra])));
					}
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
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) ((uint) ((rd) == 31 ? 0U : W[(int) rd])) & (uint) ((uint) ((((uint) ((uint) (-0x1))) << (32 - (int) ((ulong) ((ulong) (0x10) - (ulong) (shift))))) | (((uint) ((uint) (-0x1))) >> (int) ((ulong) ((ulong) (0x10) - (ulong) (shift)))))))) | (uint) ((uint) (((uint) ((uint) (imm))) << (int) (shift))));
					} else {
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((ulong) ((ulong) ((rd) == 31 ? 0UL : X[(int) rd])) & (ulong) ((ulong) ((((ulong) ((ulong) (-0x1))) << (64 - (int) ((ulong) ((ulong) (0x10) - (ulong) (shift))))) | (((ulong) ((ulong) (-0x1))) >> (int) ((ulong) ((ulong) (0x10) - (ulong) (shift)))))))) | (ulong) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))));
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
						W[(int) rd] = (uint) (((uint) ((uint) (imm))) << (int) (shift));
					} else {
						X[(int) rd] = (ulong) (((ulong) ((ulong) (imm))) << (int) (shift));
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
							SP = (ulong) ((uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) ((uint) (imm)))));
						else
							W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) ((uint) (imm))));
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
						W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) | (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => (uint) (((b) << (32 - (int) (imm))) | ((b) >> (int) (imm))) })));
					} else {
						var b = (ulong) ((rm) == 31 ? 0UL : X[(int) rm]);
						X[(int) rd] = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : X[(int) rn])) | (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) ((b) << (int) (imm)), 0x1 => (ulong) ((b) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) (b))) >> (int) (imm)))), _ => (ulong) (((b) << (64 - (int) (imm))) | ((b) >> (int) (imm))) })));
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
						W[(int) rd] = (uint) ((uint) ((uint) ((uint) (top) & (uint) ((uint) (~(tmask))))) | (uint) ((uint) ((uint) (bot) & (uint) (tmask))));
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
						if(rd == 31)
							SP = address;
						else
							X[(int) rd] = address;
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : X[(int) rt1]);
						*(ulong*) ((ulong) ((ulong) (address) + (ulong) (0x8))) = (ulong) ((rt2) == 31 ? 0UL : X[(int) rt2]);
						if(rd == 31)
							SP = address;
						else
							X[(int) rd] = address;
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
					throw new NotImplementedException();
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
				/* STURB */
				if((inst & 0xFFE00C00U) == 0x38000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					*(byte*) ((ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : X[(int) rn])) + (ulong) (offset))) = (byte) ((byte) ((ulong) ((rt) == 31 ? 0UL : X[(int) rt])));
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
						W[(int) rd] = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])) - (uint) ((uint) ((shift) switch { 0x0 => (uint) ((b) << (int) (imm)), 0x1 => (uint) ((b) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) (b))) >> (int) (imm)))), _ => throw new NotImplementedException() })));
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
						W[(int) rd] = (uint) (AddWithCarrySetNzcv(operand1, operand2, 0x1));
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
					var rimm = (ushort) ((shift != 0) ? ((ushort) ((imm) << (int) (0xC))) : (imm));
					if((mode32) != 0) {
						var operand1 = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var operand2 = (uint) (~((uint) ((uint) (imm))));
						W[(int) rd] = (uint) (AddWithCarrySetNzcv(operand1, operand2, 0x1));
					} else {
						var operand1 = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var operand2 = (ulong) (~((ulong) ((ulong) (imm))));
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
						W[(int) rd] = (uint) ((uint) (bot) & (uint) (tmask));
					} else {
						var src = (ulong) ((rn) == 31 ? 0UL : X[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr)))) & (ulong) (wmask));
						X[(int) rd] = (ulong) ((ulong) (bot) & (ulong) (tmask));
					}
					return true;
				}

			}
			return false;
		}

	}
}