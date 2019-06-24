using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#if FULLSIGIL
using Sigil;
using Label = Sigil.Label;
#else
using SigilLite;
using Label = SigilLite.Label;
#endif
using UltimateOrb;
// ReSharper disable ArrangeRedundantParentheses
// ReSharper disable RedundantCast
// ReSharper disable UnusedVariable
#pragma warning disable 162, 219

namespace Cpu64 {
	public partial class Recompiler {
		public bool Recompile(uint inst, ulong pc) {
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
						// Runtime if!
						var m = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimeValue<uint>) ((option) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x4 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), _ => (RuntimeValue<uint>) (m) })).ShiftLeft(imm)))));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimeValue<uint>) ((option) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x4 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), _ => (RuntimeValue<uint>) (m) })).ShiftLeft(imm)))));
					} else {
						// Runtime else!
						if(((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U)) != 0) {
							// Runtime if!
							if(rd == 31)
								SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])).ShiftLeft(imm))));
							else
								XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])).ShiftLeft(imm))));
						} else {
							// Runtime else!
							var m = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])));
							// Runtime let!
							if(rd == 31)
								SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((option) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFFFFFF))), 0x4 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), 0x6 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (RuntimeValue<ulong>) (m) })).ShiftLeft(imm))));
							else
								XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((option) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFFFFFF))), 0x4 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), 0x6 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (RuntimeValue<ulong>) (m) })).ShiftLeft(imm))));
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
					var simm = (ushort) ((imm) << (int) (shift));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<ushort>) (simm)));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<ushort>) (simm)));
					} else {
						// Runtime else!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (simm));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (simm));
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
						// Runtime if!
						var b = (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rm) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rm]));
						// Runtime let!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => throw new NotImplementedException() }))));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => throw new NotImplementedException() }))));
					} else {
						// Runtime else!
						var b = (RuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm]);
						// Runtime let!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => throw new NotImplementedException() })));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => throw new NotImplementedException() })));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallAddWithCarrySetNzcv((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn])), simm, 0x0)));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (CallAddWithCarrySetNzcv((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]), simm, 0x0));
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
					XR[(int) rd] = addr;
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
						// Runtime if!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (imm)))));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (imm)))));
					} else {
						// Runtime else!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
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
						// Runtime if!
						var b = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<uint>) ((RuntimeValue<uint>) (((b).ShiftLeft((RuntimeValue<uint>) (32 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) }))));
					} else {
						// Runtime else!
						var b = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((b).ShiftLeft((RuntimeValue<uint>) (64 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) })));
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
						// Runtime if!
						var result = (RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) (result);
						// Runtime let!
						NZCV_NR = (RuntimeValue<uint>) ((result).ShiftRight(0x1F));
						// Runtime let!
						NZCV_ZR = (RuntimeValue<byte>) ((result) == (0x0));
						// Runtime let!
						NZCV_CR = 0x0;
						// Runtime let!
						NZCV_VR = 0x0;
					} else {
						// Runtime else!
						var result = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
						// Runtime let!
						XR[(int) rd] = result;
						// Runtime let!
						NZCV_NR = (RuntimeValue<ulong>) ((result).ShiftRight(0x3F));
						// Runtime let!
						NZCV_ZR = (RuntimeValue<byte>) ((result) == (0x0));
						// Runtime let!
						NZCV_CR = 0x0;
						// Runtime let!
						NZCV_VR = 0x0;
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
					// Runtime block!
					var result = (RuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_ZR)), 0x1 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)), 0x2 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_NR)), 0x3 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_VR)), 0x4 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), 0x5 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))), 0x6 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), _ => (RuntimeValue<byte>) (0x1) });
					// Runtime block!
					Label temp_0 = Ilg.DefineLabel(), temp_1 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))) != 0 ? ((RuntimeValue<byte>) (!(result))) : (result))) == 0, temp_1);
					Branch(addr);
					Branch(temp_0);
					Label(temp_1);
					Branch(pc + 4);
					Label(temp_0);
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
						// Runtime if!
						// Runtime block!
						var dst = (RuntimeValue<uint>) ((rd) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rd]);
						// Runtime block!
						var src = (RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						// Runtime block!
						var bot = (RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) (dst) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) (~(wmask))))) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((src).ShiftLeft((RuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((RuntimeValue<uint>) (immr))))) & (RuntimeValue<uint>) (RuntimeValue<uint>) (wmask))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) (bot) & (RuntimeValue<uint>) (RuntimeValue<uint>) (tmask)));
					} else {
						// Runtime else!
						// Runtime block!
						var dst = (RuntimeValue<uint>) ((rd) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rd]);
						// Runtime block!
						var src = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						// Runtime block!
						var bot = (RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (dst) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((ulong) (~(wmask))))) | (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((src).ShiftLeft((RuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((RuntimeValue<uint>) (immr))))) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (wmask))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (dst) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((ulong) (~(tmask))))) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (bot) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (tmask))));
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
						// Runtime if!
						var b = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (~((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<uint>) ((RuntimeValue<uint>) (((b).ShiftLeft((RuntimeValue<uint>) (32 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) }))))));
					} else {
						// Runtime else!
						var b = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (~((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((b).ShiftLeft((RuntimeValue<uint>) (64 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) })))));
					}
					return true;
				}
				/* BL */
				if((inst & 0xFC000000U) == 0x94000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
					var addr = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (offset));
					// Runtime block!
					XR[(int) 0x1E] = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (0x4));
					// Runtime block!
					Branch(addr);
					return true;
				}
				/* BLR */
				if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					// Runtime block!
					XR[(int) 0x1E] = (ulong) ((ulong) ((ulong) (pc)) + (ulong) (0x4));
					// Runtime block!
					Branch((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]));
					return true;
				}
				/* BR */
				if((inst & 0xFFFFFC1FU) == 0xD61F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]));
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
						// Runtime if!
						Label temp_2 = Ilg.DefineLabel(), temp_3 = Ilg.DefineLabel();
						BranchIf(((RuntimeValue<byte>) (((RuntimeValue<uint>) ((rs) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rs])) != ((uint) ((uint) (0x0))))) == 0, temp_3);
						Branch(addr);
						Branch(temp_2);
						Label(temp_3);
						Branch(pc + 4);
						Label(temp_2);
					} else {
						// Runtime else!
						Label temp_4 = Ilg.DefineLabel(), temp_5 = Ilg.DefineLabel();
						BranchIf(((RuntimeValue<byte>) (((RuntimeValue<ulong>) ((rs) == 31 ? 0UL : XR[(int) rs])) != ((ulong) ((ulong) (0x0))))) == 0, temp_5);
						Branch(addr);
						Branch(temp_4);
						Label(temp_5);
						Branch(pc + 4);
						Label(temp_4);
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
						// Runtime if!
						Label temp_6 = Ilg.DefineLabel(), temp_7 = Ilg.DefineLabel();
						BranchIf(((RuntimeValue<byte>) (((RuntimeValue<uint>) ((rs) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rs])) == ((uint) ((uint) (0x0))))) == 0, temp_7);
						Branch(addr);
						Branch(temp_6);
						Label(temp_7);
						Branch(pc + 4);
						Label(temp_6);
					} else {
						// Runtime else!
						Label temp_8 = Ilg.DefineLabel(), temp_9 = Ilg.DefineLabel();
						BranchIf(((RuntimeValue<byte>) (((RuntimeValue<ulong>) ((rs) == 31 ? 0UL : XR[(int) rs])) == ((ulong) ((ulong) (0x0))))) == 0, temp_9);
						Branch(addr);
						Branch(temp_8);
						Label(temp_9);
						Branch(pc + 4);
						Label(temp_8);
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
					var result = (RuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_ZR)), 0x1 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)), 0x2 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_NR)), 0x3 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_VR)), 0x4 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), 0x5 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))), 0x6 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), _ => (RuntimeValue<byte>) (0x1) });
					// Runtime let!
					Label temp_10 = Ilg.DefineLabel(), temp_11 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))) != 0 ? ((RuntimeValue<byte>) (!(result))) : (result))) == 0, temp_11);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) 0x1F] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallAddWithCarrySetNzcv((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]), (uint) (~((uint) ((uint) (imm)))), 0x1)));
					} else {
						// Runtime else!
						XR[(int) 0x1F] = (RuntimeValue<ulong>) (CallAddWithCarrySetNzcv((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]), (ulong) (~((ulong) ((ulong) (imm)))), 0x1));
					}
					Branch(temp_10);
					Label(temp_11);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Label(temp_10);
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
					var result = (RuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_ZR)), 0x1 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)), 0x2 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_NR)), 0x3 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_VR)), 0x4 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), 0x5 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))), 0x6 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), _ => (RuntimeValue<byte>) (0x1) });
					// Runtime let!
					Label temp_12 = Ilg.DefineLabel(), temp_13 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))) != 0 ? ((RuntimeValue<byte>) (!(result))) : (result))) == 0, temp_13);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) 0x1F] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallAddWithCarrySetNzcv((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]), (RuntimeValue<uint>) (~((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]))), 0x1)));
					} else {
						// Runtime else!
						XR[(int) 0x1F] = (RuntimeValue<ulong>) (CallAddWithCarrySetNzcv((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]), (RuntimeValue<ulong>) (~((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]))), 0x1));
					}
					Branch(temp_12);
					Label(temp_13);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Label(temp_12);
					return true;
				}
				/* CLZ */
				if((inst & 0x7FFFFC00U) == 0x5AC01000U) {
					var size = (inst >> 31) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallCountLeadingZeros((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (CallCountLeadingZeros((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])));
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
					var result = (RuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_ZR)), 0x1 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)), 0x2 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_NR)), 0x3 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_VR)), 0x4 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), 0x5 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))), 0x6 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), _ => (RuntimeValue<byte>) (0x1) });
					// Runtime let!
					Label temp_14 = Ilg.DefineLabel(), temp_15 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))) != 0 ? ((RuntimeValue<byte>) (!(result))) : (result))) == 0, temp_15);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
					}
					Branch(temp_14);
					Label(temp_15);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
					}
					Label(temp_14);
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
					var result = (RuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_ZR)), 0x1 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)), 0x2 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_NR)), 0x3 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_VR)), 0x4 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (NZCV_CR)) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), 0x5 => (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))), 0x6 => (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (((RuntimeValue<byte>) (NZCV_NR)) == ((RuntimeValue<byte>) (NZCV_VR)))) & (RuntimeValue<byte>) (RuntimeValue<byte>) ((RuntimeValue<byte>) (!((RuntimeValue<byte>) (NZCV_ZR)))))), _ => (RuntimeValue<byte>) (0x1) });
					// Runtime let!
					Label temp_16 = Ilg.DefineLabel(), temp_17 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((byte) ((byte) ((byte) ((ulong) (cond) & (ulong) (0x1))) & (byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))) != 0 ? ((RuntimeValue<byte>) (!(result))) : (result))) == 0, temp_17);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
					}
					Branch(temp_16);
					Label(temp_17);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (0x1)))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x1));
					}
					Label(temp_16);
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
					var src = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
					// Runtime let!
					VR[(int) (rd)] = (RuntimeValue<Vector128<float>>) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x1))) == (0x1)) ? 1U : 0U)) != 0 ? ((RuntimeValue<Vector128<float>>) ((Q) != 0 ? ((RuntimeValue<Vector128<float>>) (((RuntimeValue<byte>) ((RuntimeValue<byte>) (src))).CreateVector())) : ((RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<float>>) (((RuntimeValue<byte>) ((RuntimeValue<byte>) (src))).CreateVector()))))) : ((RuntimeValue<Vector128<float>>) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x3))) == (0x2)) ? 1U : 0U)) != 0 ? ((RuntimeValue<Vector128<float>>) ((Q) != 0 ? ((RuntimeValue<Vector128<float>>) (((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (src))).CreateVector())) : ((RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<float>>) (((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (src))).CreateVector()))))) : ((RuntimeValue<Vector128<float>>) (((byte) ((((byte) ((ulong) (imm) & (ulong) (0x7))) == (0x4)) ? 1U : 0U)) != 0 ? ((RuntimeValue<Vector128<float>>) ((Q) != 0 ? ((RuntimeValue<Vector128<float>>) (((RuntimeValue<uint>) ((RuntimeValue<uint>) (src))).CreateVector())) : ((RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<float>>) (((RuntimeValue<uint>) ((RuntimeValue<uint>) (src))).CreateVector()))))) : ((RuntimeValue<Vector128<float>>) ((Q) != 0 ? ((RuntimeValue<Vector128<float>>) ((src).CreateVector())) : throw new NotImplementedException())))))));
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
						// Runtime if!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) ^ (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (imm)))));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) ^ (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (imm)))));
					} else {
						// Runtime else!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) ^ (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) ^ (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
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
						// Runtime if!
						var b = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) ^ (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<uint>) ((RuntimeValue<uint>) (((b).ShiftLeft((RuntimeValue<uint>) (32 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) }))));
					} else {
						// Runtime else!
						var b = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) ^ (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((b).ShiftLeft((RuntimeValue<uint>) (64 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) })));
					}
					return true;
				}
				/* LDARB */
				if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]);
					// Runtime let!
					XR[(int) rt] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<byte>) (((RuntimePointer<byte>) (address)).Value)));
					return true;
				}
				/* LDAXB */
				if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]);
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rt] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) (address)).Value));
					} else {
						// Runtime else!
						XR[(int) rt] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) (address)).Value);
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
					var address = (RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]);
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						// Runtime block!
						XR[(int) rt1] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) (address)).Value));
						// Runtime block!
						XR[(int) rt2] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value));
					} else {
						// Runtime else!
						// Runtime block!
						XR[(int) rt1] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) (address)).Value);
						// Runtime block!
						XR[(int) rt2] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value);
					}
					// Runtime let!
					if(rn == 31)
						SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					else
						XR[(int) rn] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						// Runtime block!
						XR[(int) rt1] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) (address)).Value));
						// Runtime block!
						XR[(int) rt2] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value));
					} else {
						// Runtime else!
						// Runtime block!
						XR[(int) rt1] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) (address)).Value);
						// Runtime block!
						XR[(int) rt2] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value);
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
					var address = (RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]);
					// Runtime let!
					switch(opc) {
						case 0x0:
							// Runtime block!
							VSR[(int) (rt1)] = (RuntimeValue<float>) (((RuntimePointer<float>) (address)).Value);
							// Runtime block!
							VSR[(int) (rt2)] = (RuntimeValue<float>) (((RuntimePointer<float>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value);
							break;
						case 0x1:
							// Runtime block!
							VDR[(int) (rt1)] = (RuntimeValue<double>) (((RuntimePointer<double>) (address)).Value);
							// Runtime block!
							VDR[(int) (rt2)] = (RuntimeValue<double>) (((RuntimePointer<double>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value);
							break;
						default:
							// Runtime block!
							VR[(int) (rt1)] = (RuntimeValue<Vector128<float>>) (((RuntimePointer<Vector128<float>>) (address)).Value);
							// Runtime block!
							VR[(int) (rt2)] = (RuntimeValue<Vector128<float>>) (((RuntimePointer<Vector128<float>>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x10)))).Value);
							break;
					}
					// Runtime let!
					if(rn == 31)
						SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					else
						XR[(int) rn] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) (address)).Value));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) (address)).Value);
					}
					// Runtime let!
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
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
					// Runtime block!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value);
					}
					// Runtime block!
					if(rn == 31)
						SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm));
					else
						XR[(int) rn] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value);
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
					var offset = (RuntimeValue<ulong>) (((RuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]), 32))))) : ((RuntimeValue<ulong>) (((byte) ((ulong) (option) & (ulong) (0x1))) != 0 ? ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])) : ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						XR[(int) rt] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (offset)))).Value));
					} else {
						// Runtime else!
						XR[(int) rt] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (offset)))).Value);
					}
					return true;
				}
				/* LDRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm));
					// Runtime let!
					XR[(int) rt] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<byte>) (((RuntimePointer<byte>) (address)).Value))));
					// Runtime let!
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
					return true;
				}
				/* LDRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					// Runtime block!
					XR[(int) rt] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<byte>) (((RuntimePointer<byte>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value))));
					// Runtime block!
					if(rn == 31)
						SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm));
					else
						XR[(int) rn] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm));
					return true;
				}
				/* LDRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39400000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					XR[(int) rt] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<byte>) (((RuntimePointer<byte>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value)));
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
				/* LDRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79400000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					XR[(int) rt] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ushort>) (((RuntimePointer<ushort>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value)));
					return true;
				}
				/* LDRSW-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0xB9800000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x2));
					XR[(int) rt] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value), 32))));
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
					var offset = (RuntimeValue<ulong>) (((RuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]), 32))))) : ((RuntimeValue<ulong>) (((byte) ((ulong) (option) & (ulong) (0x1))) != 0 ? ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])) : ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount));
					// Runtime let!
					XR[(int) rt] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (offset)))).Value), 32))));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm)))).Value));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm)))).Value);
					}
					return true;
				}
				/* LDURB */
				if((inst & 0xFFE00C00U) == 0x38400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<byte>) (((RuntimePointer<byte>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (imm)))).Value)));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])).ShiftRight((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])).ShiftRight((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) * (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((ra) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) ra]))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) * (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])))) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((ra) == 31 ? 0UL : XR[(int) ra])));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rd) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rd])) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((((uint) ((uint) (-0x1))) << (32 - (int) ((ulong) ((ulong) (0x10) - (ulong) (shift))))) | (((uint) ((uint) (-0x1))) >> (int) ((ulong) ((ulong) (0x10) - (ulong) (shift)))))))) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift)))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? 0UL : XR[(int) rd])) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((ulong) ((((ulong) ((ulong) (-0x1))) << (64 - (int) ((ulong) ((ulong) (0x10) - (ulong) (shift))))) | (((ulong) ((ulong) (-0x1))) >> (int) ((ulong) ((ulong) (0x10) - (ulong) (shift)))))))) | (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((uint) (~((uint) (((uint) ((uint) (imm))) << (int) (shift)))));
					} else {
						// Runtime else!
						XR[(int) rd] = (ulong) (~((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift)));
					} else {
						// Runtime else!
						XR[(int) rd] = (ulong) (((ulong) ((ulong) (imm))) << (int) (shift));
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
					XR[(int) rt] = (RuntimeValue<ulong>) (CallSR(op0, op1, cn, cm, op2));
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
					CallSR(op0, op1, cn, cm, op2, (RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt]));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((ra) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) ra])) - (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) * (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]))))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((ra) == 31 ? 0UL : XR[(int) ra])) - (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) * (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])))));
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
						// Runtime if!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (imm)))));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (imm)))));
					} else {
						// Runtime else!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) | (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) | (RuntimeValue<ulong>) (RuntimeValue<ulong>) (imm));
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
						// Runtime if!
						var b = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<uint>) ((RuntimeValue<uint>) (((b).ShiftLeft((RuntimeValue<uint>) (32 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) }))));
					} else {
						// Runtime else!
						var b = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) | (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((b).ShiftLeft((RuntimeValue<uint>) (64 - (imm)))) | ((b).ShiftRight((RuntimeValue<uint>) (imm))))) })));
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
						// Runtime if!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallReverseBits((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]))));
					} else {
						// Runtime else!
						XR[(int) rd] = (RuntimeValue<ulong>) (CallReverseBits((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])));
					}
					return true;
				}
				/* RET */
				if((inst & 0xFFFFFC1FU) == 0xD65F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]));
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
						// Runtime if!
						// Runtime block!
						var src = (RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						// Runtime block!
						var bot = (RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((src).ShiftLeft((RuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((RuntimeValue<uint>) (immr))))) & (RuntimeValue<uint>) (RuntimeValue<uint>) (wmask));
						// Runtime block!
						var top = (RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) ((uint) (0x0))) - (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((src).ShiftRight(imms))) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0x1))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) (top) & (RuntimeValue<uint>) (RuntimeValue<uint>) ((uint) (~(tmask))))) | (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) (bot) & (RuntimeValue<uint>) (RuntimeValue<uint>) (tmask)))));
					} else {
						// Runtime else!
						// Runtime block!
						var src = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						// Runtime block!
						var bot = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((src).ShiftLeft((RuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((RuntimeValue<uint>) (immr))))) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (wmask));
						// Runtime block!
						var top = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((ulong) ((ulong) (0x0))) - (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((src).ShiftRight(imms))) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0x1))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (top) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((ulong) (~(tmask))))) | (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (bot) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (tmask))));
					}
					return true;
				}
				/* STLRB */
				if((inst & 0xFFFFFC00U) == 0x089FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]);
					// Runtime let!
					((RuntimePointer<byte>) (address)).Value = (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<uint>) ((rt) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STLXR */
				if((inst & 0xBFE0FC00U) == 0x8800FC00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = (RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]);
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						((RuntimePointer<uint>) (address)).Value = (RuntimeValue<uint>) ((rt) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt]);
					} else {
						// Runtime else!
						((RuntimePointer<ulong>) (address)).Value = (RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt]);
					}
					// Runtime let!
					XR[(int) rs] = (RuntimeValue<ulong>) (RuntimeValue<uint>) (0x0);
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
					var address = (RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]);
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						// Runtime block!
						((RuntimePointer<uint>) (address)).Value = (RuntimeValue<uint>) ((rt1) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt1]);
						// Runtime block!
						((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value = (RuntimeValue<uint>) ((rt2) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt2]);
					} else {
						// Runtime else!
						// Runtime block!
						((RuntimePointer<ulong>) (address)).Value = (RuntimeValue<ulong>) ((rt1) == 31 ? 0UL : XR[(int) rt1]);
						// Runtime block!
						((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value = (RuntimeValue<ulong>) ((rt2) == 31 ? 0UL : XR[(int) rt2]);
					}
					// Runtime let!
					if(rd == 31)
						SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					else
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						// Runtime block!
						((RuntimePointer<uint>) (address)).Value = (RuntimeValue<uint>) ((rt1) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt1]);
						// Runtime block!
						((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value = (RuntimeValue<uint>) ((rt2) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt2]);
					} else {
						// Runtime else!
						// Runtime block!
						((RuntimePointer<ulong>) (address)).Value = (RuntimeValue<ulong>) ((rt1) == 31 ? 0UL : XR[(int) rt1]);
						// Runtime block!
						((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value = (RuntimeValue<ulong>) ((rt2) == 31 ? 0UL : XR[(int) rt2]);
					}
					// Runtime let!
					if(rd == 31)
						SPR = address;
					else
						XR[(int) rd] = address;
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						// Runtime block!
						((RuntimePointer<uint>) (address)).Value = (RuntimeValue<uint>) ((rt1) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt1]);
						// Runtime block!
						((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value = (RuntimeValue<uint>) ((rt2) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt2]);
					} else {
						// Runtime else!
						// Runtime block!
						((RuntimePointer<ulong>) (address)).Value = (RuntimeValue<ulong>) ((rt1) == 31 ? 0UL : XR[(int) rt1]);
						// Runtime block!
						((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value = (RuntimeValue<ulong>) ((rt2) == 31 ? 0UL : XR[(int) rt2]);
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					// Runtime let!
					switch(opc) {
						case 0x0:
							// Runtime block!
							((RuntimePointer<float>) (address)).Value = (RuntimeValue<float>) (VSR[(int) (rt1)]);
							// Runtime block!
							((RuntimePointer<float>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value = (RuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						case 0x1:
							// Runtime block!
							((RuntimePointer<double>) (address)).Value = (RuntimeValue<double>) (VDR[(int) (rt1)]);
							// Runtime block!
							((RuntimePointer<double>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value = (RuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						case 0x2:
							// Runtime block!
							((RuntimePointer<Vector128<float>>) (address)).Value = (RuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							// Runtime block!
							((RuntimePointer<Vector128<float>>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x10)))).Value = (RuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
							break;
						default:
							throw new NotImplementedException();
							break;
					}
					// Runtime let!
					if(rd == 31)
						SPR = address;
					else
						XR[(int) rd] = address;
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					// Runtime let!
					switch(opc) {
						case 0x0:
							// Runtime block!
							((RuntimePointer<float>) (address)).Value = (RuntimeValue<float>) (VSR[(int) (rt1)]);
							// Runtime block!
							((RuntimePointer<float>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x4)))).Value = (RuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						case 0x1:
							// Runtime block!
							((RuntimePointer<double>) (address)).Value = (RuntimeValue<double>) (VDR[(int) (rt1)]);
							// Runtime block!
							((RuntimePointer<double>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x8)))).Value = (RuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						case 0x2:
							// Runtime block!
							((RuntimePointer<Vector128<float>>) (address)).Value = (RuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							// Runtime block!
							((RuntimePointer<Vector128<float>>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (0x10)))).Value = (RuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
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
					var address = (RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]);
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						((RuntimePointer<uint>) (address)).Value = (RuntimeValue<uint>) ((rs) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rs]);
					} else {
						// Runtime else!
						((RuntimePointer<ulong>) (address)).Value = (RuntimeValue<ulong>) ((rs) == 31 ? 0UL : XR[(int) rs]);
					}
					// Runtime let!
					if(rd == 31)
						SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					else
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (address) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
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
					var address = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (simm));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						((RuntimePointer<uint>) (address)).Value = (RuntimeValue<uint>) ((rs) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rs]);
					} else {
						// Runtime else!
						((RuntimePointer<ulong>) (address)).Value = (RuntimeValue<ulong>) ((rs) == 31 ? 0UL : XR[(int) rs]);
					}
					// Runtime let!
					if(rd == 31)
						SPR = address;
					else
						XR[(int) rd] = address;
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
						// Runtime if!
						((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (pimm)))).Value = (RuntimeValue<uint>) ((rs) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rs]);
					} else {
						// Runtime else!
						((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (pimm)))).Value = (RuntimeValue<ulong>) ((rs) == 31 ? 0UL : XR[(int) rs]);
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
					var offset = (RuntimeValue<ulong>) (((RuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]), 32))))) : ((RuntimeValue<ulong>) (((byte) ((ulong) (option) & (ulong) (0x1))) != 0 ? ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])) : ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount));
					// Runtime let!
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						// Runtime if!
						((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (offset)))).Value = (RuntimeValue<uint>) ((rt) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt]);
					} else {
						// Runtime else!
						((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) (offset)))).Value = (RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt]);
					}
					return true;
				}
				/* STRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39000000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					((RuntimePointer<byte>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value = (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt])));
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
				/* STRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79000000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					((RuntimePointer<ushort>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ushort>) (imm)))).Value = (RuntimeValue<ushort>) ((RuntimeValue<ushort>) ((RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt])));
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
						// Runtime if!
						((RuntimePointer<uint>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (offset)))).Value = (RuntimeValue<uint>) ((rt) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rt]);
					} else {
						// Runtime else!
						((RuntimePointer<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (offset)))).Value = (RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt]);
					}
					return true;
				}
				/* STURB */
				if((inst & 0xFFE00C00U) == 0x38000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					((RuntimePointer<byte>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (offset)))).Value = (RuntimeValue<byte>) ((RuntimeValue<byte>) ((RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt])));
					return true;
				}
				/* STURH */
				if((inst & 0xFFE00C00U) == 0x78000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					((RuntimePointer<ushort>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<long>) (offset)))).Value = (RuntimeValue<ushort>) ((RuntimeValue<ushort>) ((RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt])));
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
						// Runtime if!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) - (RuntimeValue<uint>) (RuntimeValue<ushort>) (simm)));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) - (RuntimeValue<uint>) (RuntimeValue<ushort>) (simm)));
					} else {
						// Runtime else!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) - (RuntimeValue<ulong>) (RuntimeValue<ushort>) (simm));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) - (RuntimeValue<ulong>) (RuntimeValue<ushort>) (simm));
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
						// Runtime if!
						var m = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						if(rd == 31)
							SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (~((RuntimeValue<uint>) (((RuntimeValue<uint>) ((option) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x4 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), _ => (RuntimeValue<uint>) (m) })).ShiftLeft(imm)))))));
						else
							XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) rn]))) + (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (~((RuntimeValue<uint>) (((RuntimeValue<uint>) ((option) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<ulong>) (RuntimeValue<uint>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x4 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (SignExtRuntime<int>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), _ => (RuntimeValue<uint>) (m) })).ShiftLeft(imm)))))));
					} else {
						// Runtime else!
						if(((byte) ((((byte) ((ulong) (option) & (ulong) (0x3))) == (0x3)) ? 1U : 0U)) != 0) {
							// Runtime if!
							if(rd == 31)
								SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (~((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])).ShiftLeft(imm))))));
							else
								XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (~((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])).ShiftLeft(imm))))));
						} else {
							// Runtime else!
							var m = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])));
							// Runtime let!
							if(rd == 31)
								SPR = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (~((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((option) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFFFFFF))), 0x4 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), 0x6 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (RuntimeValue<ulong>) (m) })).ShiftLeft(imm))))));
							else
								XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (~((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((option) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFF))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFF))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (m) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0xFFFFFFFF))), 0x4 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<byte>) ((RuntimeValue<byte>) (m)), 8))))), 0x5 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>((RuntimeValue<ushort>) ((RuntimeValue<ushort>) (m)), 16))))), 0x6 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (RuntimeValue<ulong>) (m) })).ShiftLeft(imm))))));
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
						// Runtime if!
						var b = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])) - (RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((shift) switch { 0x0 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<int>) (((RuntimeValue<int>) ((RuntimeValue<int>) (b))).ShiftRight(imm))))), _ => throw new NotImplementedException() }))));
					} else {
						// Runtime else!
						var b = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])) - (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((shift) switch { 0x0 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftLeft(imm))), 0x1 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((b).ShiftRight(imm))), 0x2 => (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<long>) (((RuntimeValue<long>) ((RuntimeValue<long>) (b))).ShiftRight(imm))))), _ => throw new NotImplementedException() })));
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
						// Runtime if!
						// Runtime block!
						var operand1 = (RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]);
						// Runtime block!
						var operand2 = (RuntimeValue<uint>) (~((RuntimeValue<uint>) (Shift((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]), shift, imm))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallAddWithCarrySetNzcv(operand1, operand2, 0x1)));
					} else {
						// Runtime else!
						// Runtime block!
						var operand1 = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
						// Runtime block!
						var operand2 = (RuntimeValue<ulong>) (~((RuntimeValue<ulong>) (Shift((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]), shift, imm))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (CallAddWithCarrySetNzcv(operand1, operand2, 0x1));
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
					// Runtime let!
					if((mode32) != 0) {
						// Runtime if!
						// Runtime block!
						var operand1 = (RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]);
						var operand2 = (uint) (~((uint) ((uint) (imm))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (CallAddWithCarrySetNzcv(operand1, operand2, 0x1)));
					} else {
						// Runtime else!
						// Runtime block!
						var operand1 = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
						var operand2 = (ulong) (~((ulong) ((ulong) (imm))));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (CallAddWithCarrySetNzcv(operand1, operand2, 0x1));
					}
					return true;
				}
				/* SVC */
				if((inst & 0xFFE0001FU) == 0xD4000001U) {
					var imm = (inst >> 5) & 0xFFFFU;
					CallVoid(nameof(Svc), imm);
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
					Label temp_18 = Ilg.DefineLabel(), temp_19 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt])).ShiftRight(imm))) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0x1))) == (0x0))) == 0, temp_19);
					Branch(addr);
					Branch(temp_18);
					Label(temp_19);
					Branch(pc + 4);
					Label(temp_18);
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
					Label temp_20 = Ilg.DefineLabel(), temp_21 = Ilg.DefineLabel();
					BranchIf(((RuntimeValue<byte>) (((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((RuntimeValue<ulong>) ((rt) == 31 ? 0UL : XR[(int) rt])).ShiftRight(imm))) & (RuntimeValue<ulong>) (RuntimeValue<long>) (0x1))) != (0x0))) == 0, temp_21);
					Branch(addr);
					Branch(temp_20);
					Label(temp_21);
					Branch(pc + 4);
					Label(temp_20);
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
						// Runtime if!
						// Runtime block!
						var src = (RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						// Runtime block!
						var bot = (RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (((src).ShiftLeft((RuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((RuntimeValue<uint>) (immr))))) & (RuntimeValue<uint>) (RuntimeValue<uint>) (wmask));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<uint>) (RuntimeValue<uint>) (bot) & (RuntimeValue<uint>) (RuntimeValue<uint>) (tmask)));
					} else {
						// Runtime else!
						// Runtime block!
						var src = (RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						// Runtime block!
						var bot = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (((src).ShiftLeft((RuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((RuntimeValue<uint>) (immr))))) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (wmask));
						// Runtime block!
						XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) (bot) & (RuntimeValue<ulong>) (RuntimeValue<ulong>) (tmask));
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
						// Runtime if!
						var operand2 = (RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ((RuntimeValue<uint>) (Ternary<byte, uint>((RuntimeValue<byte>) ((RuntimeValue<byte>) ((operand2) == (0x0))), (uint) ((uint) (0x0)), (RuntimeValue<uint>) ((RuntimeValue<uint>) ((RuntimeValue<float>) ((RuntimeValue<float>) ((RuntimeValue<float>) ((RuntimeValue<float>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])))) / (RuntimeValue<float>) ((RuntimeValue<float>) ((RuntimeValue<float>) (operand2)))))))));
					} else {
						// Runtime else!
						var operand2 = (RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm]);
						// Runtime let!
						XR[(int) rd] = (RuntimeValue<ulong>) (Ternary<byte, ulong>((RuntimeValue<byte>) ((RuntimeValue<byte>) ((operand2) == (0x0))), (ulong) ((ulong) (0x0)), (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<double>) ((RuntimeValue<double>) ((RuntimeValue<double>) ((RuntimeValue<double>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])))) / (RuntimeValue<double>) ((RuntimeValue<double>) ((RuntimeValue<double>) (operand2))))))));
					}
					return true;
				}
				/* UMADDL */
				if((inst & 0xFFE08000U) == 0x9BA00000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((ra) == 31 ? 0UL : XR[(int) ra])) + (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rn) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rn])))) * (RuntimeValue<ulong>) (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<uint>) ((rm) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) rm])))))));
					return true;
				}
				/* UMULH */
				if((inst & 0xFFE0FC00U) == 0x9BC07C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (RuntimeValue<ulong>) ((RuntimeValue<ulong>) ((RuntimeValue<UInt128>) (((RuntimeValue<UInt128>) ((RuntimeValue<UInt128>) (RuntimeValue<UInt128>) ((RuntimeValue<UInt128>) ((RuntimeValue<UInt128>) ((RuntimeValue<ulong>) ((rn) == 31 ? 0UL : XR[(int) rn])))) * (RuntimeValue<UInt128>) (RuntimeValue<UInt128>) ((RuntimeValue<UInt128>) ((RuntimeValue<UInt128>) ((RuntimeValue<ulong>) ((rm) == 31 ? 0UL : XR[(int) rm])))))).ShiftRight(0x40))));
					return true;
				}

			}
			return false;
		}
	}
}