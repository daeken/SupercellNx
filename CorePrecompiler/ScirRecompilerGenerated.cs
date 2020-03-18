using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using UltimateOrb;
using Common;
using CorePrecompiler;
// ReSharper disable ArrangeRedundantParentheses
// ReSharper disable RedundantCast
// ReSharper disable UnusedVariable
#pragma warning disable 162, 219

namespace CorePrecompiler {
	public partial class ScirRecompiler {
		public bool Recompile(uint inst, ulong pc) {
			unchecked {
				/* ADCS */
				if((inst & 0x7FE0FC00U) == 0x3A000000U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var m = ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).Store();
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((option) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), _ => (ScirRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((option) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), _ => (ScirRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
						} else {
							var m = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).Store();
							if(rd == 31)
								SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((option) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), 0x6 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (m)), 32))))), _ => (ScirRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((option) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), 0x6 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (m)), 32))))), _ => (ScirRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
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
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (simm))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (simm))));
					} else {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (simm)));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (simm)));
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
					var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))));
					} else {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))));
					}
					return true;
				}
				/* ADD-vector */
				if((inst & 0xBF20FC00U) == 0x0E208400U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var ts = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "8B", 0x1 => "16B", 0x2 => "4H", 0x3 => "8H", 0x4 => "2S", 0x5 => "4S", 0x7 => "2D", _ => throw new NotImplementedException() });
					var v = ((ScirRuntimeValue<Vector128<float>>) ((size) switch { 0x0 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<byte>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((ScirRuntimeValue<Vector128<byte>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), 0x1 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<ushort>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((ScirRuntimeValue<Vector128<ushort>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), 0x2 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<uint>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((ScirRuntimeValue<Vector128<uint>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), 0x3 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<ulong>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((ScirRuntimeValue<Vector128<ulong>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), _ => throw new NotImplementedException() })).Store();
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? (v) : ((ScirRuntimeValue<Vector128<float>>) (v)));
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
					var simm = (uint) (((uint) ((uint) (imm))) << (int) (shift));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) (simm));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) (simm));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					return true;
				}
				/* ADRP */
				if((inst & 0x9F000000U) == 0x90000000U) {
					var immlo = (inst >> 29) & 0x3U;
					var immhi = (inst >> 5) & 0x7FFFFU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>((ulong) ((ulong) (((ulong) (ulong) (((ulong) (((ulong) ((ushort) ((ushort) (0x0)))) << 0)) | ((ulong) (((ulong) (immlo)) << 12)))) | ((ulong) (((ulong) (immhi)) << 14)))), 33));
					var addr = (ulong) (((ulong) (ulong) ((ulong) ((ulong) (((ulong) (((ulong) ((ushort) ((ushort) (0x0)))) << 0)) | ((ulong) (((ulong) ((ulong) ((ulong) ((ulong) (((ulong) (pc)) >> (int) (0xC)))))) << 12)))))) + ((ulong) (long) (imm)));
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
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) & ((ScirRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) & ((ScirRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) (imm))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) (imm))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) & ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))));
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
						var result = ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) & ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (result);
						NZCV_NR = (ScirRuntimeValue<uint>) ((result).ShiftRight(0x1F));
						NZCV_ZR = (ScirRuntimeValue<byte>) ((result) == (0x0));
						NZCV_CR = 0x0;
						NZCV_VR = 0x0;
					} else {
						var result = ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))).Store();
						XR[(int) rd] = result;
						NZCV_NR = (ScirRuntimeValue<ulong>) ((result).ShiftRight(0x3F));
						NZCV_ZR = (ScirRuntimeValue<byte>) ((result) == (0x0));
						NZCV_CR = 0x0;
						NZCV_VR = 0x0;
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
						var result = ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) (imm))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (result);
						NZCV_NR = (ScirRuntimeValue<uint>) ((result).ShiftRight(0x1F));
						NZCV_ZR = (ScirRuntimeValue<byte>) ((result) == (0x0));
						NZCV_CR = 0x0;
						NZCV_VR = 0x0;
					} else {
						var result = ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) (imm))))).Store();
						XR[(int) rd] = result;
						NZCV_NR = (ScirRuntimeValue<ulong>) ((result).ShiftRight(0x3F));
						NZCV_ZR = (ScirRuntimeValue<byte>) ((result) == (0x0));
						NZCV_CR = 0x0;
						NZCV_VR = 0x0;
					}
					return true;
				}
				/* ASRV */
				if((inst & 0x7FE0FC00U) == 0x1AC02800U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).ShiftRight((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x20))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).ShiftRight((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x40)))))));
					}
					return true;
				}
				/* B */
				if((inst & 0xFC000000U) == 0x14000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28)))));
					Branch(addr);
					return true;
				}
				/* B.cond */
				if((inst & 0xFF000010U) == 0x54000000U) {
					var imm = (inst >> 5) & 0x7FFFFU;
					var cond = (inst >> 0) & 0xFU;
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 21)))));
					var condstr = (string) ((cond) switch { 0x0 => "EQ", 0x1 => "NE", 0x2 => "CS", 0x3 => "CC", 0x4 => "MI", 0x5 => "PL", 0x6 => "VS", 0x7 => "VC", 0x8 => "HI", 0x9 => "LS", 0xA => "GE", 0xB => "LT", 0xC => "GT", 0xD => "LE", _ => "AL" });
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_108 = DefineLabel(), temp_110 = DefineLabel(), temp_109 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_108, temp_110);
					Label(temp_108);
					Branch(addr);
					Branch(temp_109);
					Label(temp_110);
					Branch(pc + 4);
					Branch(temp_109);
					Label(temp_109);
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
						var dst = ((ScirRuntimeValue<uint>) ((rd) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rd])).Store();
						var src = ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Store();
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) (dst)) & ((ScirRuntimeValue<uint>) ((uint) (~(wmask)))))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((src).ShiftLeft((ScirRuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((ScirRuntimeValue<uint>) (immr)))))) & ((ScirRuntimeValue<uint>) (wmask))))))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) (dst)) & ((ScirRuntimeValue<uint>) ((uint) (~(tmask)))))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) (bot)) & ((ScirRuntimeValue<uint>) (tmask)))))))));
					} else {
						var dst = ((ScirRuntimeValue<ulong>) ((rd) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rd])).Store();
						var src = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Store();
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (dst)) & ((ScirRuntimeValue<ulong>) ((ulong) (~(wmask)))))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((src).ShiftLeft((ScirRuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((ScirRuntimeValue<uint>) (immr)))))) & ((ScirRuntimeValue<ulong>) (wmask))))))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (dst)) & ((ScirRuntimeValue<ulong>) ((ulong) (~(tmask)))))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (bot)) & ((ScirRuntimeValue<ulong>) (tmask))))))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) & ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) & ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))));
					}
					return true;
				}
				/* BIC-vector-register */
				if((inst & 0xBFE0FC00U) == 0x0E601C00U) {
					var Q = (inst >> 30) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) (((Q) == (0x1)) ? 1U : 0U) != 0) ? ("16B") : ("8B"));
					var v = ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).AndNot((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))).Store();
					if(((byte) (((Q) == (0x1)) ? 1U : 0U)) != 0) {
						VR[(int) (rd)] = v;
					} else {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (v);
					}
					return true;
				}
				/* BL */
				if((inst & 0xFC000000U) == 0x94000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (offset)));
					BranchLinked(addr);
					return true;
				}
				/* BLR */
				if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					BranchLinkedRegister(rn);
					return true;
				}
				/* BR */
				if((inst & 0xFFFFFC1FU) == 0xD61F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					BranchRegister(rn);
					return true;
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
					throw new NotImplementedException();
					return true;
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
					throw new NotImplementedException();
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var cl = ((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])).Store();
						var ch = ((ScirRuntimeValue<uint>) (((ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))])).Store();
						var nl = ((ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt])).Store();
						var nh = ((ScirRuntimeValue<uint>) (((ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))])).Store();
						var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						var data = ((ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) (address)).Value)).Store();
						Label temp_111 = DefineLabel(), temp_113 = DefineLabel(), temp_112 = DefineLabel();
						BranchIf((ScirRuntimeValue<byte>) ((data) == ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (ch))).ShiftLeft(0x20)))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (cl)))))))), temp_111, temp_113);
						Label(temp_111);
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (nh))).ShiftLeft(0x20)))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (nl))))));
						Branch(temp_112);
						Label(temp_113);
						Branch(temp_112);
						Label(temp_112);
						XR[(int) rs] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (data)));
						XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) ((data).ShiftRight(0x20)))));
					} else {
						var cl = ((ScirRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rs])).Store();
						var ch = ((ScirRuntimeValue<ulong>) (((ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))])).Store();
						var nl = ((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])).Store();
						var nh = ((ScirRuntimeValue<ulong>) (((ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))])).Store();
						var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						var dl = ((ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) (address)).Value)).Store();
						var dh = ((ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value)).Store();
						Label temp_114 = DefineLabel(), temp_116 = DefineLabel(), temp_115 = DefineLabel();
						BranchIf((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((dl) == (cl)))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((dh) == (ch)))))), temp_114, temp_116);
						Label(temp_114);
						((ScirRuntimePointer<ulong>) (address)).Value = nl;
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = nh;
						Branch(temp_115);
						Label(temp_116);
						Branch(temp_115);
						Label(temp_115);
						XR[(int) rs] = dl;
						XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))] = dh;
					}
					return true;
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
					throw new NotImplementedException();
					return true;
				}
				/* CBNZ */
				if((inst & 0x7F000000U) == 0x35000000U) {
					var size = (inst >> 31) & 0x1U;
					var imm = (inst >> 5) & 0x7FFFFU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21)))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						Label temp_117 = DefineLabel(), temp_119 = DefineLabel(), temp_118 = DefineLabel();
						BranchIf((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])) != ((uint) ((uint) (0x0)))), temp_117, temp_119);
						Label(temp_117);
						Branch(addr);
						Branch(temp_118);
						Label(temp_119);
						Branch(pc + 4);
						Branch(temp_118);
						Label(temp_118);
					} else {
						Label temp_120 = DefineLabel(), temp_122 = DefineLabel(), temp_121 = DefineLabel();
						BranchIf((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rs])) != ((ulong) ((ulong) (0x0)))), temp_120, temp_122);
						Label(temp_120);
						Branch(addr);
						Branch(temp_121);
						Label(temp_122);
						Branch(pc + 4);
						Branch(temp_121);
						Label(temp_121);
					}
					return true;
				}
				/* CBZ */
				if((inst & 0x7F000000U) == 0x34000000U) {
					var size = (inst >> 31) & 0x1U;
					var imm = (inst >> 5) & 0x7FFFFU;
					var rs = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21)))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						Label temp_123 = DefineLabel(), temp_125 = DefineLabel(), temp_124 = DefineLabel();
						BranchIf((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])) == ((uint) ((uint) (0x0)))), temp_123, temp_125);
						Label(temp_123);
						Branch(addr);
						Branch(temp_124);
						Label(temp_125);
						Branch(pc + 4);
						Branch(temp_124);
						Label(temp_124);
					} else {
						Label temp_126 = DefineLabel(), temp_128 = DefineLabel(), temp_127 = DefineLabel();
						BranchIf((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rs])) == ((ulong) ((ulong) (0x0)))), temp_126, temp_128);
						Label(temp_126);
						Branch(addr);
						Branch(temp_127);
						Label(temp_128);
						Branch(pc + 4);
						Branch(temp_127);
						Label(temp_127);
					}
					return true;
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_129 = DefineLabel(), temp_131 = DefineLabel(), temp_130 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_129, temp_131);
					Label(temp_129);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) 0x1F] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) ((uint) (imm))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) 0x1F] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) ((ulong) (imm))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					Branch(temp_130);
					Label(temp_131);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_130);
					Label(temp_130);
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_132 = DefineLabel(), temp_134 = DefineLabel(), temp_133 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_132, temp_134);
					Label(temp_132);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) 0x1F] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((uint) (imm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) 0x1F] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((ulong) (imm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					Branch(temp_133);
					Label(temp_134);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_133);
					Label(temp_133);
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_135 = DefineLabel(), temp_137 = DefineLabel(), temp_136 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_135, temp_137);
					Label(temp_135);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) 0x1F] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) 0x1F] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					Branch(temp_136);
					Label(temp_137);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_136);
					Label(temp_136);
					return true;
				}
				/* CLREX */
				if((inst & 0xFFFFF0FFU) == 0xD503305FU) {
					var crm = (inst >> 8) & 0xFU;
					return true;
				}
				/* CLZ */
				if((inst & 0x7FFFFC00U) == 0x5AC01000U) {
					var size = (inst >> 31) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (CallCountLeadingZeros((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (CallCountLeadingZeros((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])));
					}
					return true;
				}
				/* CNT */
				if((inst & 0xBF3FFC00U) == 0x0E205800U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x3U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "8B", 0x1 => "16B", _ => throw new NotImplementedException() });
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (CallVectorCountBits((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), (long) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => 0x8, _ => 0x10 })));
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_138 = DefineLabel(), temp_140 = DefineLabel(), temp_139 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_138, temp_140);
					Label(temp_138);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_139);
					Label(temp_140);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]);
					}
					Branch(temp_139);
					Label(temp_139);
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_141 = DefineLabel(), temp_143 = DefineLabel(), temp_142 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_141, temp_143);
					Label(temp_141);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_142);
					Label(temp_143);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((uint) ((uint) (0x1))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x1)));
					}
					Branch(temp_142);
					Label(temp_142);
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_144 = DefineLabel(), temp_146 = DefineLabel(), temp_145 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_144, temp_146);
					Label(temp_144);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_145);
					Label(temp_146);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])));
					}
					Branch(temp_145);
					Label(temp_145);
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_147 = DefineLabel(), temp_149 = DefineLabel(), temp_148 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_147, temp_149);
					Label(temp_147);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_148);
					Label(temp_149);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (-((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (-((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))))));
					}
					Branch(temp_148);
					Label(temp_148);
					return true;
				}
				/* DMB */
				if((inst & 0xFFFFF0FFU) == 0xD50330BFU) {
					var m = (inst >> 8) & 0xFU;
					var option = (string) ((m) switch { 0xF => "SY", 0xE => "ST", 0xD => "LD", 0xB => "ISH", 0xA => "ISHST", 0x9 => "ISHLD", 0x7 => "NSH", 0x6 => "NSHST", 0x5 => "NSHLD", 0x3 => "OSH", 0x2 => "OSHST", _ => "OSHLD" });
					return true;
				}
				/* DSB */
				if((inst & 0xFFFFF0FFU) == 0xD503309FU) {
					var crm = (inst >> 8) & 0xFU;
					var option = (string) ((crm) switch { 0xF => "SY", 0xE => "ST", 0xD => "LD", 0xB => "ISH", 0xA => "ISHST", 0x9 => "ISHLD", 0x7 => "NSH", 0x6 => "NSHST", 0x5 => "NSHLD", 0x3 => "OSH", 0x2 => "OSHST", _ => "OSHLD" });
					return true;
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
					var src = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Store();
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (src)))).CreateVector())) : ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (src)))).CreateVector()))))) : ((ScirRuntimeValue<Vector128<float>>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x3))))) == (0x2)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (src)))).CreateVector())) : ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (src)))).CreateVector()))))) : ((ScirRuntimeValue<Vector128<float>>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x7))))) == (0x4)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (src)))).CreateVector())) : ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (src)))).CreateVector()))))) : ((ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ulong>) (src)).CreateVector())) : throw new NotImplementedException())))))));
					return true;
				}
				/* DUP-element-scalar */
				if((inst & 0xFFE0FC00U) == 0x5E000400U) {
					var imm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = "";
					var size = 0x0;
					var index = (uint) ((uint) (0x0));
					if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0xF))))) == (0x0)) ? 1U : 0U)) != 0) {
						throw new NotImplementedException();
					} else {
						if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0) {
							r = "B";
							size = 0x8;
							index = (byte) ((imm) >> (int) (0x1));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x3))))) == (0x2)) ? 1U : 0U)) != 0) {
								r = "H";
								size = 0x10;
								index = (byte) ((imm) >> (int) (0x2));
							} else {
								if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x7))))) == (0x4)) ? 1U : 0U)) != 0) {
									r = "S";
									size = 0x20;
									index = (byte) ((imm) >> (int) (0x3));
								} else {
									r = "D";
									size = 0x40;
									index = (byte) ((imm) >> (int) (0x4));
								}
							}
						}
					}
					switch(size) {
						case 0x8: {
							VBR[(int) (rd)] = (ScirRuntimeValue<byte>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<byte>(index));
							break;
						}
						case 0x10: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(index));
							break;
						}
						case 0x20: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(index));
							break;
						}
						case 0x40: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(index));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) ^ ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) ^ ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))));
					}
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
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) ^ ((ScirRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) ^ ((ScirRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) ^ ((ScirRuntimeValue<ulong>) (imm))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) ^ ((ScirRuntimeValue<ulong>) (imm))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) ^ ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) ^ ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))));
					}
					return true;
				}
				/* EXT */
				if((inst & 0xBFE08400U) == 0x2E000000U) {
					var Q = (inst >> 30) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var index = (inst >> 11) & 0xFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var ts = (string) ((Q != 0) ? ("16B") : ("8B"));
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (CallVectorExtract((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)]), Q, index));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).ShiftLeft((ulong) (((ulong) (long) (0x20)) - ((ulong) (byte) (lsb))))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(lsb)))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).ShiftLeft((ulong) (((ulong) (long) (0x40)) - ((ulong) (byte) (lsb))))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(lsb))))));
					}
					return true;
				}
				/* FABS-scalar */
				if((inst & 0xFF3FFC00U) == 0x1E20C000U) {
					var type = (inst >> 22) & 0x3U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Abs());
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Abs());
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FABS-vector */
				if((inst & 0xBFBFFC00U) == 0x0EA0F800U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							var a = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var b = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) ((a).Abs()));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) ((b).Abs()));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var b = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var c = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x2))).Store();
							var d = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x3))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) ((a).Abs()));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) ((b).Abs()));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<float>) ((c).Abs()));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<float>) ((d).Abs()));
							break;
						}
						case 0x3: {
							var a = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x0))).Store();
							var b = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<double>) ((double) ((double) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<double>) ((a).Abs()));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<double>) ((b).Abs()));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						case 0x3: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<ushort>) (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (VHR[(int) (rn)]))) + ((ScirRuntimeValue<ushort>) (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (VHR[(int) (rm)]))))));
							break;
						}
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))) + ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rm)]))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FADD-vector */
				if((inst & 0xBFA0FC00U) == 0x0E20D400U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var ts = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])));
							break;
						}
						case 0x3: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FADDP-scalar */
				if((inst & 0xFFBFFC00U) == 0x7E30D800U) {
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0)))) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1)))));
					} else {
						VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x0)))) + ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x1)))));
					}
					return true;
				}
				/* FADDP-vector */
				if((inst & 0xBFA0FC00U) == 0x2E20D400U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							var a = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var b = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var c = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x0))).Store();
							var d = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (a)) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (b))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (c)) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (d))));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var b = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var c = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x2))).Store();
							var d = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x3))).Store();
							var e = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x0))).Store();
							var f = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x1))).Store();
							var g = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x2))).Store();
							var h = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x3))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (a)) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (b))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (c)) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (d))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (e)) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (f))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (g)) + ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) (h))));
							break;
						}
						case 0x3: {
							var a = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x0))).Store();
							var b = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x1))).Store();
							var c = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<double>(0x0))).Store();
							var d = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<double>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) (a)) + ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) (b))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) (c)) + ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) (d))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_150 = DefineLabel(), temp_152 = DefineLabel(), temp_151 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_150, temp_152);
					Label(temp_150);
					switch(type) {
						case 0x0: {
							var __macro_fcmp_a = ((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((ScirRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							NZCVR = (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						case 0x1: {
							var __macro_fcmp_a = ((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((ScirRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							NZCVR = (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					Branch(temp_151);
					Label(temp_152);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_151);
					Label(temp_151);
					return true;
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
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							var a1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var a2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var b1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x0))).Store();
							var b2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) == (b1))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) >= (b1))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x3 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a1).Abs())) >= ((ScirRuntimeValue<float>) ((b1).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x6 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) > (b1))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x7 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a1).Abs())) > ((ScirRuntimeValue<float>) ((b1).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => throw new NotImplementedException() }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) == (b2))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) >= (b2))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x3 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a2).Abs())) >= ((ScirRuntimeValue<float>) ((b2).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x6 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) > (b2))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x7 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a2).Abs())) > ((ScirRuntimeValue<float>) ((b2).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => throw new NotImplementedException() }));
							break;
						}
						case 0x1: {
							var a1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var a2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var a3 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x2))).Store();
							var a4 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x3))).Store();
							var b1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x0))).Store();
							var b2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x1))).Store();
							var b3 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x2))).Store();
							var b4 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(0x3))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) == (b1))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) >= (b1))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x3 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a1).Abs())) >= ((ScirRuntimeValue<float>) ((b1).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x6 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) > (b1))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x7 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a1).Abs())) > ((ScirRuntimeValue<float>) ((b1).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => throw new NotImplementedException() }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) == (b2))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) >= (b2))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x3 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a2).Abs())) >= ((ScirRuntimeValue<float>) ((b2).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x6 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) > (b2))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x7 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a2).Abs())) > ((ScirRuntimeValue<float>) ((b2).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => throw new NotImplementedException() }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a3) == (b3))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a3) >= (b3))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x3 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a3).Abs())) >= ((ScirRuntimeValue<float>) ((b3).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x6 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a3) > (b3))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x7 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a3).Abs())) > ((ScirRuntimeValue<float>) ((b3).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => throw new NotImplementedException() }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a4) == (b4))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a4) >= (b4))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x3 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a4).Abs())) >= ((ScirRuntimeValue<float>) ((b4).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x6 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a4) > (b4))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x7 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<float>) ((a4).Abs())) > ((ScirRuntimeValue<float>) ((b4).Abs())))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => throw new NotImplementedException() }));
							break;
						}
						case 0x3: {
							var a1 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x0))).Store();
							var a2 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x1))).Store();
							var b1 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<double>(0x0))).Store();
							var b2 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<double>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<double>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) == (b1))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x2 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) >= (b1))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x3 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<double>) ((a1).Abs())) >= ((ScirRuntimeValue<double>) ((b1).Abs())))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x6 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a1) > (b1))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x7 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<double>) ((a1).Abs())) > ((ScirRuntimeValue<double>) ((b1).Abs())))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), _ => throw new NotImplementedException() }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<double>) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) == (b2))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x2 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) >= (b2))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x3 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<double>) ((a2).Abs())) >= ((ScirRuntimeValue<double>) ((b2).Abs())))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x6 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a2) > (b2))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x7 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<double>) ((a2).Abs())) > ((ScirRuntimeValue<double>) ((b2).Abs())))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), _ => throw new NotImplementedException() }));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							var v1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var v2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) > ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x1 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) >= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) == ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) <= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))) }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) > ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x1 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) >= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) == ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) <= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))) }));
							break;
						}
						case 0x1: {
							var v1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var v2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var v3 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x2))).Store();
							var v4 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x3))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) > ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x1 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) >= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) == ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) <= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))) }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) > ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x1 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) >= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) == ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) <= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))) }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v3) > ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x1 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v3) >= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v3) == ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v3) <= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))) }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<float>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v4) > ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x1 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v4) >= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), 0x2 => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v4) == ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))), _ => (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v4) <= ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0))))))) }));
							break;
						}
						case 0x3: {
							var v1 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x0))).Store();
							var v2 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<double>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) > ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x1 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) >= ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x2 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) == ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), _ => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) <= ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))) }));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<double>) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) > ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x1 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) >= ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), 0x2 => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) == ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))), _ => (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) <= ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0))))))) }));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FCMLT-zero-vector */
				if((inst & 0xBFBFFC00U) == 0x0EA0E800U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							var v1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var v2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) < ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) < ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							break;
						}
						case 0x1: {
							var v1 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x0))).Store();
							var v2 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x1))).Store();
							var v3 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x2))).Store();
							var v4 = ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(0x3))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) < ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) < ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v3) < ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v4) < ((float) ((float) (0x0))))), (float) (Bitcast<int, float>((int) ((int) (-0x1)))), (float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							break;
						}
						case 0x3: {
							var v1 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x0))).Store();
							var v2 = ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<int>) ((int) ((int) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v1) < ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0)))))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((v2) < ((double) ((double) (0x0))))), (double) (Bitcast<long, double>((long) ((long) (-0x1)))), (double) (Bitcast<long, double>((long) ((long) (0x0)))))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						case 0x0: {
							var __macro_fcmp_a = ((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((ScirRuntimeValue<float>) (((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0 ? ((float) ((float) (0x0))) : ((ScirRuntimeValue<float>) (VSR[(int) (rm)])))).Store();
							NZCVR = (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						case 0x1: {
							var __macro_fcmp_a = ((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((ScirRuntimeValue<double>) (((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0 ? ((double) ((double) (0x0))) : ((ScirRuntimeValue<double>) (VDR[(int) (rm)])))).Store();
							NZCVR = (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (ScirRuntimeValue<long>) (Ternary<byte, long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
					var result = ((ScirRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR)), 0x2 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_NR)), 0x3 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_VR)), 0x4 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (NZCV_CR))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<byte>) (NZCV_NR)) == ((ScirRuntimeValue<byte>) (NZCV_VR))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (!((ScirRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (ScirRuntimeValue<byte>) (0x1) })).Store();
					Label temp_153 = DefineLabel(), temp_155 = DefineLabel(), temp_154 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((ScirRuntimeValue<byte>) (!(result))) : (result)), temp_153, temp_155);
					Label(temp_153);
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (VSR[(int) (rn)]);
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (VDR[(int) (rn)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					Branch(temp_154);
					Label(temp_155);
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (VSR[(int) (rm)]);
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (VDR[(int) (rm)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					Branch(temp_154);
					Label(temp_154);
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
					switch(tf) {
						case 0xC: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<ushort>) (VHR[(int) (rn)])));
							break;
						}
						case 0xD: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<ushort>) (VHR[(int) (rn)])));
							break;
						}
						case 0x3: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x7: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)])));
							break;
						}
						case 0x4: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)])));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					switch((byte) ((byte) (((byte) (((byte) (type)) << 0)) | ((byte) (((byte) (size)) << 2))))) {
						case 0x0: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (CallFloatToFixed32((ScirRuntimeValue<float>) (VSR[(int) (rn)]), fbits)));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (CallFloatToFixed64((ScirRuntimeValue<float>) (VSR[(int) (rn)]), fbits));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (CallFloatToFixed32((ScirRuntimeValue<double>) (VDR[(int) (rn)]), fbits)));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (CallFloatToFixed64((ScirRuntimeValue<double>) (VDR[(int) (rn)]), fbits));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					switch(st) {
						case 0x0: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))))));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)])))));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))))));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)])))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					switch((byte) ((byte) (((byte) (((byte) (type)) << 0)) | ((byte) (((byte) (size)) << 2))))) {
						case 0x0: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (CallFloatToFixed32((ScirRuntimeValue<float>) (VSR[(int) (rn)]), fbits)));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (CallFloatToFixed64((ScirRuntimeValue<float>) (VSR[(int) (rn)]), fbits));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (CallFloatToFixed32((ScirRuntimeValue<double>) (VDR[(int) (rn)]), fbits)));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (CallFloatToFixed64((ScirRuntimeValue<double>) (VDR[(int) (rn)]), fbits));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					switch(st) {
						case 0x0: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)])));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						case 0x3: {
							throw new NotImplementedException();
							break;
						}
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))) / ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))) / ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rm)]))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMAX-scalar */
				if((inst & 0xFF20FC00U) == 0x1E204800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							var a = ((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) > (b))), a, b));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) > (b))), a, b));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMAXNM-scalar */
				if((inst & 0xFF20FC00U) == 0x1E206800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							var a = ((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) > (b))), a, b));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) > (b))), a, b));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMIN-scalar */
				if((inst & 0xFF20FC00U) == 0x1E205800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							var a = ((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) < (b))), a, b));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) < (b))), a, b));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMINNM-scalar */
				if((inst & 0xFF20FC00U) == 0x1E207800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							var a = ((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (Ternary<byte, float>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) < (b))), a, b));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var b = ((ScirRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (Ternary<byte, double>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((a) < (b))), a, b));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMLA-by-element-vector-spdp */
				if((inst & 0xBF80F400U) == 0x0F801000U) {
					var Q = (inst >> 30) & 0x1U;
					var sz = (inst >> 22) & 0x1U;
					var L = (inst >> 21) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var H = (inst >> 11) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var T = (string) (((byte) ((byte) (((byte) (((byte) (sz)) << 0)) | ((byte) (((byte) (Q)) << 1))))) switch { 0x0 => "2S", 0x2 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					var Ts = (string) ((sz != 0) ? ("D") : ("S"));
					var index = (uint) (((byte) ((byte) (((byte) (((byte) (L)) << 0)) | ((byte) (((byte) (sz)) << 1))))) switch { 0x2 => (uint) ((uint) (H)), 0x3 => throw new NotImplementedException(), _ => (uint) ((uint) ((byte) ((byte) (((byte) (((byte) (L)) << 0)) | ((byte) (((byte) (H)) << 1)))))) });
					if((sz) != 0) {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rd)])) + (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<double>(index)))).CreateVector())))))));
					} else {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rd)])) + ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(index)))).CreateVector())))));
					}
					return true;
				}
				/* FMLA-vector */
				if((inst & 0xBFA0FC00U) == 0x0E20CC00U) {
					var Q = (inst >> 30) & 0x1U;
					var sz = (inst >> 22) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var T = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (sz)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					if((sz) != 0) {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rd)])) + (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))));
					} else {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rd)])) + ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))));
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
					switch(tf) {
						case 0x66: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ushort>) (VHR[(int) (rn)]))));
							break;
						}
						case 0xE6: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (VHR[(int) (rn)])));
							break;
						}
						case 0x67: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])));
							break;
						}
						case 0x7: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Bitcast<float>());
							break;
						}
						case 0x6: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Bitcast<uint>()));
							break;
						}
						case 0xE7: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])));
							break;
						}
						case 0xA7: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Bitcast<double>());
							break;
						}
						case 0xA6: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Bitcast<ulong>());
							break;
						}
						case 0xCE: {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<double>) (VDR[(int) ((byte) ((((ulong) ((byte) ((rn) << (int) (0x1)))) | ((ulong) (0x1)))))])).Bitcast<ulong>());
							break;
						}
						case 0xCF: {
							VDR[(int) ((byte) ((((ulong) ((byte) ((rd) << (int) (0x1)))) | ((ulong) (0x1)))))] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Bitcast<double>());
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMOV-scalar-immediate */
				if((inst & 0xFF201FE0U) == 0x1E201000U) {
					var type = (inst >> 22) & 0x3U;
					var imm = (inst >> 13) & 0xFFU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					var sv = (float) (Bitcast<uint, float>((uint) ((uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (((uint) ((uint) ((uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (uint) (((uint) (((uint) ((byte) ((byte) (0x0)))) << 0)) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 1)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 2)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 3)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 4)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 5)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 6)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 7)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 8)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 9)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 10)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 11)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 12)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 13)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 14)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 15)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 16)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 17)))) | ((uint) (((uint) ((byte) ((byte) (0x0)))) << 18)))))) << 0)) | ((uint) (((uint) ((byte) ((byte) ((byte) ((((ulong) (imm)) & ((ulong) (0xF)))))))) << 19)))) | ((uint) (((uint) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x4)))) & ((ulong) (0x3)))))))) << 23)))) | ((uint) (((uint) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 0)) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 1)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 2)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 3)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 4)))))) << 25)))) | ((uint) (((uint) ((byte) (((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1))))) != 0 ? 0U : 1U))) << 30)))) | ((uint) (((uint) ((byte) ((byte) ((byte) ((imm) >> (int) (0x7)))))) << 31))))));
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = sv;
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (double) (Bitcast<ulong, double>((ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 1)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 2)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 3)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 4)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 5)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 6)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 7)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 8)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 9)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 10)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 11)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 12)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 13)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 14)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 15)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 16)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 17)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 18)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 19)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 20)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 21)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 22)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 23)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 24)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 25)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 26)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 27)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 28)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 29)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 30)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 31)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 32)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 33)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 34)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 35)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 36)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 37)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 38)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 39)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 40)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 41)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 42)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 43)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 44)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 45)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 46)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 47)))))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((((ulong) (imm)) & ((ulong) (0xF)))))))) << 48)))) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x4)))) & ((ulong) (0x3)))))))) << 52)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 0)) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 1)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 2)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 3)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 4)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 5)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 6)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 7)))))) << 54)))) | ((ulong) (((ulong) ((byte) (((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1))))) != 0 ? 0U : 1U))) << 62)))) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((imm) >> (int) (0x7)))))) << 63))))));
							break;
						}
					}
					return true;
				}
				/* FMUL-by-element-vector-spdp */
				if((inst & 0xBF80F400U) == 0x0F809000U) {
					var Q = (inst >> 30) & 0x1U;
					var sz = (inst >> 22) & 0x1U;
					var L = (inst >> 21) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var H = (inst >> 11) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var T = (string) (((byte) ((byte) (((byte) (((byte) (sz)) << 0)) | ((byte) (((byte) (Q)) << 1))))) switch { 0x0 => "2S", 0x2 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					var Ts = (string) ((sz != 0) ? ("D") : ("S"));
					var index = (uint) (((byte) ((byte) (((byte) (((byte) (L)) << 0)) | ((byte) (((byte) (sz)) << 1))))) switch { 0x2 => (uint) ((uint) (H)), 0x3 => throw new NotImplementedException(), _ => (uint) ((uint) ((byte) ((byte) (((byte) (((byte) (L)) << 0)) | ((byte) (((byte) (H)) << 1)))))) });
					if((sz) != 0) {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<double>(index)))).CreateVector()))));
					} else {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<float>(index)))).CreateVector())));
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
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))) * ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))) * ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rm)]))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FMUL-vector */
				if((inst & 0xBFA0FC00U) == 0x2E20DC00U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var ts = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])));
							break;
						}
						case 0x3: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (-((ScirRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (-((ScirRuntimeValue<double>) (VDR[(int) (rn)])));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FNMUL-scalar */
				if((inst & 0xFF20FC00U) == 0x1E208800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (-((ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))) * ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rm)]))))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (-((ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))) * ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rm)]))))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* FRSQRTE-vector */
				if((inst & 0xBFBFFC00U) == 0x2EA1D800U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Frsqrte(0x20, 0x2))), 0x1 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Frsqrte(0x20, 0x4))), 0x3 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Frsqrte(0x40, 0x2))), _ => throw new NotImplementedException() });
					return true;
				}
				/* FRSQRTS-vector */
				if((inst & 0xBFA0FC00U) == 0x0EA0FC00U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "2S", 0x1 => "4S", 0x3 => "2D", _ => throw new NotImplementedException() });
					switch((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x3)))).CreateVector())) - ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))) / ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x2)))).CreateVector()))));
							break;
						}
						case 0x1: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x3)))).CreateVector())) - ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))) / ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) ((float) (0x2)))).CreateVector())));
							break;
						}
						case 0x3: {
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<double>) ((double) ((double) (0x3)))).CreateVector())) - (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))))) / (ScirRuntimeValue<Vector128<double>>) ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<double>) ((double) ((double) (0x2)))).CreateVector()))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))).Sqrt());
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))).Sqrt());
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rn)]))) - ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rn)]))) - ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) (VDR[(int) (rm)]))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0) {
						VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
							VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (ScirRuntimeValue<float>) (((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Bitcast<float>()));
							} else {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (ScirRuntimeValue<double>) (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Bitcast<double>()));
							}
						}
					}
					return true;
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
					if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0) {
						VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (ScirRuntimeValue<byte>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<byte>(index2)));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
							VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(index2)));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (ScirRuntimeValue<float>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<float>(index2)));
							} else {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (ScirRuntimeValue<double>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<double>(index2)));
							}
						}
					}
					return true;
				}
				/* LDAR */
				if((inst & 0xBFFFFC00U) == 0x88DFFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value));
					} else {
						var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) (address)).Value);
					}
					return true;
				}
				/* LDARB */
				if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value)));
					return true;
				}
				/* LDARH */
				if((inst & 0xFFFFFC00U) == 0x48DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value)));
					return true;
				}
				/* LDAXB */
				if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Exclusive32R = ((ScirRuntimePointer<uint>) (address)).Value));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (Exclusive64R = ((ScirRuntimePointer<ulong>) (address)).Value);
					}
					return true;
				}
				/* LDAXRB */
				if((inst & 0xFFFFFC00U) == 0x085FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (Exclusive8R = ((ScirRuntimePointer<byte>) (address)).Value)));
					return true;
				}
				/* LDAXRH */
				if((inst & 0xFFFFFC00U) == 0x485FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (Exclusive16R = ((ScirRuntimePointer<ushort>) (address)).Value)));
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
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt1] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value));
						XR[(int) rt2] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value));
					} else {
						XR[(int) rt1] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) (address)).Value);
						XR[(int) rt2] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value);
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt1] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value));
						XR[(int) rt2] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value));
					} else {
						XR[(int) rt1] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) (address)).Value);
						XR[(int) rt2] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value);
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
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					switch(opc) {
						case 0x0: {
							VSR[(int) (rt1)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) (address)).Value);
							VSR[(int) (rt2)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value);
							break;
						}
						case 0x1: {
							VDR[(int) (rt1)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) (address)).Value);
							VDR[(int) (rt2)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value);
							break;
						}
						default: {
							VR[(int) (rt1)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) (address)).Value);
							VR[(int) (rt2)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x10))))).Value);
							break;
						}
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					switch(opc) {
						case 0x0: {
							VSR[(int) (rt1)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) (address)).Value);
							VSR[(int) (rt2)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value);
							break;
						}
						case 0x1: {
							VDR[(int) (rt1)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) (address)).Value);
							VDR[(int) (rt2)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value);
							break;
						}
						default: {
							VR[(int) (rt1)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) (address)).Value);
							VR[(int) (rt2)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x10))))).Value);
							break;
						}
					}
					return true;
				}
				/* LDPSW-immediate-signed-offset */
				if((inst & 0xFFC00000U) == 0x69400000U) {
					var imm = (inst >> 15) & 0x7FU;
					var rt2 = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt1 = (inst >> 0) & 0x1FU;
					var simm = (long) (((long) (SignExt<long>(imm, 7))) << (int) (0x2));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					XR[(int) rt1] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value), 32))));
					XR[(int) rt2] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value), 32))));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) (address)).Value);
					}
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value);
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value);
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
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x2: {
							VHR[(int) (rt)] = (ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) (address)).Value);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					return true;
				}
				/* LDR-simd-immediate-preindex */
				if((inst & 0x3F600C00U) == 0x3C400C00U) {
					var size = (inst >> 30) & 0x3U;
					var opc = (inst >> 23) & 0x1U;
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var r = (string) (((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "B", 0x2 => "H", 0x4 => "S", 0x6 => "D", 0x1 => "Q", _ => throw new NotImplementedException() });
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x2: {
							VHR[(int) (rt)] = (ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) (address)).Value);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
					return true;
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
					switch(m) {
						case 0x1: {
							VBR[(int) (rt)] = (ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						case 0x5: {
							VHR[(int) (rt)] = (ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						case 0x9: {
							VSR[(int) (rt)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						case 0xD: {
							VDR[(int) (rt)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						default: {
							VR[(int) (rt)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (imm))))).Value);
							break;
						}
					}
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((option) switch { 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))), 0x3 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])), 0x6 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))), 0x7 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])), _ => throw new NotImplementedException() })).ShiftLeft(amount))).Store();
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset)))).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) (address)).Value);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
					var r2 = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
					var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
					var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value);
					}
					return true;
				}
				/* LDRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value))));
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value))));
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
					return true;
				}
				/* LDRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39400000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value)));
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value));
					return true;
				}
				/* LDRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value)));
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value)));
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
					return true;
				}
				/* LDRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79400000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value)));
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value));
					return true;
				}
				/* LDRSB-immediate-postindex */
				if((inst & 0xFFA00C00U) == 0x38800400U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value), 8)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value), 8))));
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRSB-immediate-preindex */
				if((inst & 0xFFA00C00U) == 0x38800C00U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value), 8)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value), 8))));
					}
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
					return true;
				}
				/* LDRSB-immediate-unsigned-offset */
				if((inst & 0xFF800000U) == 0x39800000U) {
					var opc = (inst >> 22) & 0x1U;
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value), 8)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value), 8))));
					}
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value), 8)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value), 8))));
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
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value), 16)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value), 16))));
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRSH-immediate-preindex */
				if((inst & 0xFFA00C00U) == 0x78800C00U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value), 16)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) (address)).Value), 16))));
					}
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
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
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value), 16)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value), 16))));
					}
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value), 16)))));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value), 16))));
					}
					return true;
				}
				/* LDRSW-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0xB8800400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value), 32))));
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRSW-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0xB8800C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) (address)).Value), 32))));
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
					return true;
				}
				/* LDRSW-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0xB9800000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x2));
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value), 32))));
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value), 32))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value);
					}
					return true;
				}
				/* LDURB */
				if((inst & 0xFFE00C00U) == 0x38400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value)));
					return true;
				}
				/* LDURH */
				if((inst & 0xFFE00C00U) == 0x78400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value)));
					return true;
				}
				/* LDURSB */
				if((inst & 0xFFA00C00U) == 0x38800000U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (long) (SignExt<long>(rawimm, 9));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value), 8)))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value), 8))));
					}
					return true;
				}
				/* LDURSH */
				if((inst & 0xFFA00C00U) == 0x78800000U) {
					var opc = (inst >> 22) & 0x1U;
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var imm = (long) (SignExt<long>(rawimm, 9));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value), 16)))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) (((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value), 16))));
					}
					return true;
				}
				/* LDURSW */
				if((inst & 0xFFE00C00U) == 0xB8800000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) (((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm))))).Value), 32))));
					return true;
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (imm)))).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (ScirRuntimeValue<byte>) (((ScirRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (ScirRuntimeValue<float>) (((ScirRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (ScirRuntimeValue<double>) (((ScirRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimePointer<Vector128<float>>) (address)).Value);
							break;
						}
					}
					return true;
				}
				/* LDXR */
				if((inst & 0xBFFFFC00U) == 0x885F7C00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Exclusive32R = ((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value));
					} else {
						XR[(int) rt] = (ScirRuntimeValue<ulong>) (Exclusive64R = ((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value);
					}
					return true;
				}
				/* LDXRB */
				if((inst & 0xFFFFFC00U) == 0x085F7C00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (Exclusive8R = ((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value)));
					return true;
				}
				/* LDXRH */
				if((inst & 0xFFFFFC00U) == 0x485F7C00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					XR[(int) rt] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ushort>) (Exclusive16R = ((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value)));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).ShiftLeft((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x20))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).ShiftLeft((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x40)))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).ShiftRight((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x20))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).ShiftRight((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x40)))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) * ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ra) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) ra])))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) * ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) ra]))));
					}
					return true;
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
					var avec = ((ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<float>) ((float) (Bitcast<uint, float>((uint) (((uint) ((uint) (imm))) << (int) (amount)))))).CreateVector())).Store();
					if((Q) != 0) {
						VR[(int) (rd)] = avec;
					} else {
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (avec);
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
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ulong>) (imm)).CreateVector());
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rd) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rd]))) & ((ScirRuntimeValue<uint>) ((uint) ((((uint) ((uint) ((uint) (-0x1)))) ^ ((uint) ((uint) (((uint) ((uint) (0xFFFF))) << (int) (shift)))))))))))) | ((ScirRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift)))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rd]))) & ((ScirRuntimeValue<ulong>) ((ulong) ((((ulong) ((ulong) ((ulong) (-0x1)))) ^ ((ulong) ((ulong) (((ulong) ((ulong) (0xFFFF))) << (int) (shift)))))))))))) | ((ScirRuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((uint) (~((uint) (((uint) ((uint) (imm))) << (int) (shift)))));
					} else {
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift)));
					} else {
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
					XR[(int) rt] = (ScirRuntimeValue<ulong>) (CallSR(op0, op1, cn, cm, op2));
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
					CallSR(op0, op1, cn, cm, op2, (ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt]));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ra) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) ra]))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) * ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) ra]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) * ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))))));
					}
					return true;
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
					var v = ((ScirRuntimeValue<Vector128<float>>) ((size) switch { 0x1 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<ushort>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<ushort>(index)))))), 0x2 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<uint>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])).Element<uint>(index)))))), _ => throw new NotImplementedException() })).Store();
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? (v) : ((ScirRuntimeValue<Vector128<float>>) (v)));
					return true;
				}
				/* MUL-vector */
				if((inst & 0xBF20FC00U) == 0x0E209C00U) {
					var Q = (inst >> 30) & 0x1U;
					var size = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var t = (string) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => "8B", 0x1 => "16B", 0x2 => "4H", 0x3 => "8H", 0x4 => "2S", 0x5 => "4S", _ => throw new NotImplementedException() });
					var v = ((ScirRuntimeValue<Vector128<float>>) ((size) switch { 0x0 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<byte>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<byte>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), 0x1 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<ushort>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<ushort>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), 0x2 => (ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<float>>) ((ScirRuntimeValue<Vector128<uint>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((ScirRuntimeValue<Vector128<uint>>) ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rm)])))))), _ => throw new NotImplementedException() })).Store();
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) ((Q) != 0 ? (v) : ((ScirRuntimeValue<Vector128<float>>) (v)));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))));
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
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) | ((ScirRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) | ((ScirRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) | ((ScirRuntimeValue<ulong>) (imm))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) | ((ScirRuntimeValue<ulong>) (imm))));
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
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))));
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
						VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)]);
					} else {
						throw new NotImplementedException();
					}
					return true;
				}
				/* PRFM-immediate */
				if((inst & 0xFFC00000U) == 0xF9800000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var imm5 = (inst >> 0) & 0x1FU;
					var pimm = (ulong) (((ulong) (ushort) (imm)) * ((ulong) (long) (0x8)));
					return true;
				}
				/* RBIT */
				if((inst & 0x7FFFFC00U) == 0x5AC00000U) {
					var size = (inst >> 31) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (CallReverseBits((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (CallReverseBits((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])));
					}
					return true;
				}
				/* RET */
				if((inst & 0xFFFFFC1FU) == 0xD65F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					BranchRegister(rn);
					return true;
				}
				/* REV */
				if((inst & 0x7FFFF800U) == 0x5AC00800U) {
					var size = (inst >> 31) & 0x1U;
					var opc = (inst >> 10) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							var x = ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Store();
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (x)) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18)))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((x).ShiftRight(0x8)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((x).ShiftRight(0x10)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((x).ShiftRight(0x18)))) & ((ScirRuntimeValue<ulong>) (0xFF)))))))));
							break;
						}
						case 0x3: {
							var x = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Store();
							XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((((((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (x)) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x38)))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x8)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x30))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x10)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x28))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x18)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x20))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x20)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x28)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x30)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x38)))) & ((ScirRuntimeValue<ulong>) (0xFF))))))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* REV16 */
				if((inst & 0x7FFFFC00U) == 0x5AC00400U) {
					var size = (inst >> 31) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var x = ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (x)) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8)))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((x).ShiftRight(0x8)))) & ((ScirRuntimeValue<ulong>) (0xFF))))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((x).ShiftRight(0x10)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((x).ShiftRight(0x18)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10)))))));
					} else {
						var x = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((((((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (x)) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8)))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x8)))) & ((ScirRuntimeValue<ulong>) (0xFF))))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x10)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x18)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x20)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x28))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x28)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x20))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x30)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x38))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((x).ShiftRight(0x38)))) & ((ScirRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x30))))));
					}
					return true;
				}
				/* RORV */
				if((inst & 0x7FE0FC00U) == 0x1AC02C00U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).ShiftLeft((ScirRuntimeValue<uint>) (32 - ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x20))))))) | (((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).ShiftRight((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x20))))))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).ShiftLeft((ScirRuntimeValue<uint>) (64 - ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x40))))))) | (((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).ShiftRight((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))) % ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x40)))))));
					}
					return true;
				}
				/* SBCS */
				if((inst & 0x7FE0FC00U) == 0x7A000000U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
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
						var src = ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Store();
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((src).ShiftLeft((ScirRuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((ScirRuntimeValue<uint>) (immr)))))) & ((ScirRuntimeValue<uint>) (wmask))))).Store();
						var top = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((uint) ((uint) (0x0)))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((src).ShiftRight(imms)))) & ((ScirRuntimeValue<ulong>) (0x1)))))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) (top)) & ((ScirRuntimeValue<uint>) ((uint) (~(tmask)))))))) | ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) (bot)) & ((ScirRuntimeValue<uint>) (tmask)))))))));
					} else {
						var src = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Store();
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((src).ShiftLeft((ScirRuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((ScirRuntimeValue<uint>) (immr)))))) & ((ScirRuntimeValue<ulong>) (wmask))))).Store();
						var top = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (0x0)))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((src).ShiftRight(imms)))) & ((ScirRuntimeValue<ulong>) (0x1)))))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (top)) & ((ScirRuntimeValue<ulong>) ((ulong) (~(tmask)))))))) | ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (bot)) & ((ScirRuntimeValue<ulong>) (tmask))))))));
					}
					return true;
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
					switch(st) {
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))));
							break;
						}
						case 0x4: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))));
							break;
						}
						case 0x5: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* SCVTF-vector-integer */
				if((inst & 0xFFBFFC00U) == 0x5E21D800U) {
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Bitcast<int>())));
					} else {
						VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Bitcast<long>())));
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
						var operand2 = ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Ternary<byte, uint>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((operand2) == (0x0))), (uint) ((uint) (0x0)), (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<float>) (((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))))))) / ((ScirRuntimeValue<float>) (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (operand2))))))))))));
					} else {
						var operand2 = ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Ternary<byte, ulong>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((operand2) == (0x0))), (ulong) ((ulong) (0x0)), (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<double>) (((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))))))) / ((ScirRuntimeValue<double>) (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (operand2)))))))))));
					}
					return true;
				}
				/* SMADDL */
				if((inst & 0xFFE08000U) == 0x9B200000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) ra]))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]), 32)))) * ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))))))));
					return true;
				}
				/* SMULH */
				if((inst & 0xFFE0FC00U) == 0x9B407C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<Int128>) (((ScirRuntimeValue<Int128>) (((ScirRuntimeValue<Int128>) (ScirRuntimeValue<Int128>) ((ScirRuntimeValue<Int128>) ((ScirRuntimeValue<Int128>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))))))) * ((ScirRuntimeValue<Int128>) (ScirRuntimeValue<Int128>) ((ScirRuntimeValue<Int128>) ((ScirRuntimeValue<Int128>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))))))))).ShiftRight(0x40))))));
					return true;
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
					var iv = ((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Store();
					VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<byte>) ((byte) ((byte) (0x0)))).CreateVector());
					if(((byte) (((immh) == (0x1)) ? 1U : 0U)) != 0) {
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x0)) + ((long) (long) (0x8)))) : (0x0))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x1)) + ((long) (long) (0x8)))) : (0x1))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x2)) + ((long) (long) (0x8)))) : (0x2))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x3)) + ((long) (long) (0x8)))) : (0x3))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x4, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x4)) + ((long) (long) (0x8)))) : (0x4))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x5, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x5)) + ((long) (long) (0x8)))) : (0x5))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x6, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x6)) + ((long) (long) (0x8)))) : (0x6))))))))).ShiftLeft(shift)));
						VR[(int) (rd)] = VR[(int) (rd)].Insert(0x7, (ScirRuntimeValue<short>) (((ScirRuntimeValue<short>) ((ScirRuntimeValue<short>) ((ScirRuntimeValue<sbyte>) ((iv).Element<sbyte>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x7)) + ((long) (long) (0x8)))) : (0x7))))))))).ShiftLeft(shift)));
					} else {
						if(((byte) ((((byte) ((((ulong) (immh)) & ((ulong) (0xE))))) == (0x2)) ? 1U : 0U)) != 0) {
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<short>) ((iv).Element<short>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x0)) + ((long) (long) (0x4)))) : (0x0))))))))).ShiftLeft(shift)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<short>) ((iv).Element<short>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x1)) + ((long) (long) (0x4)))) : (0x1))))))))).ShiftLeft(shift)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<short>) ((iv).Element<short>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x2)) + ((long) (long) (0x4)))) : (0x2))))))))).ShiftLeft(shift)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<short>) ((iv).Element<short>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x3)) + ((long) (long) (0x4)))) : (0x3))))))))).ShiftLeft(shift)));
						} else {
							if(((byte) ((((byte) ((((ulong) (immh)) & ((ulong) (0xC))))) == (0x4)) ? 1U : 0U)) != 0) {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<int>) ((iv).Element<int>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x0)) + ((long) (long) (0x2)))) : (0x0))))))))).ShiftLeft(shift)));
								VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<int>) ((iv).Element<int>((uint) ((uint) ((long) ((Q != 0) ? ((long) (((long) (long) (0x1)) + ((long) (long) (0x2)))) : (0x1))))))))).ShiftLeft(shift)));
							} else {
								throw new NotImplementedException();
							}
						}
					}
					return true;
				}
				/* STLR */
				if((inst & 0xBFFFFC00U) == 0x889FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value = (ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value = (ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt]);
					}
					return true;
				}
				/* STLRB */
				if((inst & 0xFFFFFC00U) == 0x089FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					((ScirRuntimePointer<byte>) (address)).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STLRH */
				if((inst & 0xFFFFFC00U) == 0x489FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STLXR */
				if((inst & 0xBFE0FC00U) == 0x8800FC00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) (address)).Value = (ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt]);
					}
					XR[(int) rs] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (0x0);
					return true;
				}
				/* STLXRB */
				if((inst & 0xFFE0FC00U) == 0x0800FC00U) {
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					((ScirRuntimePointer<byte>) (address)).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt])));
					XR[(int) rs] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) (0x0);
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
					var address = ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) (address)).Value = (ScirRuntimeValue<uint>) ((rt1) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt1]);
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value = (ScirRuntimeValue<uint>) ((rt2) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt2]);
					} else {
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((rt1) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt1]);
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = (ScirRuntimeValue<ulong>) ((rt2) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt2]);
					}
					if(rd == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) (address)).Value = (ScirRuntimeValue<uint>) ((rt1) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt1]);
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value = (ScirRuntimeValue<uint>) ((rt2) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt2]);
					} else {
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((rt1) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt1]);
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = (ScirRuntimeValue<ulong>) ((rt2) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt2]);
					}
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) (address)).Value = (ScirRuntimeValue<uint>) ((rt1) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt1]);
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value = (ScirRuntimeValue<uint>) ((rt2) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt2]);
					} else {
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((rt1) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt1]);
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = (ScirRuntimeValue<ulong>) ((rt2) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt2]);
					}
					return true;
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
					var address = ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					switch(opc) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt1)]);
							((ScirRuntimePointer<float>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						}
						case 0x1: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt1)]);
							((ScirRuntimePointer<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							((ScirRuntimePointer<Vector128<float>>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x10))))).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rd == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					switch(opc) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt1)]);
							((ScirRuntimePointer<float>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						}
						case 0x1: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt1)]);
							((ScirRuntimePointer<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							((ScirRuntimePointer<Vector128<float>>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x10))))).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					switch(opc) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt1)]);
							((ScirRuntimePointer<float>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x4))))).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						}
						case 0x1: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt1)]);
							((ScirRuntimePointer<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x8))))).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							((ScirRuntimePointer<Vector128<float>>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (0x10))))).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
					var address = ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) (address)).Value = (ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs]);
					} else {
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rs]);
					}
					if(rd == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) (address)).Value = (ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs]);
					} else {
						((ScirRuntimePointer<ulong>) (address)).Value = (ScirRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rs]);
					}
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
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (pimm))))).Value = (ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs]);
					} else {
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (pimm))))).Value = (ScirRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rs]);
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
					var r2 = (string) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ("X") : ("W"));
					var amount = (long) (((byte) (((scale) == (0x0)) ? 1U : 0U) != 0) ? (0x0) : ((long) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? (0x2) : (0x3))));
					var extend = (string) ((option) switch { 0x2 => "UXTW", 0x6 => "SXTW", 0x7 => "SXTX", _ => "LSL" });
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value = (ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value = (ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt]);
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
					var address = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					switch(rop) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					switch(rop) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SPR = address;
					else
						XR[(int) rn] = address;
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) ((ushort) ((imm) << (int) (scale)))))).Store();
					switch(rop) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset)))).Store();
					switch(rop) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* STRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38000400U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					((ScirRuntimePointer<byte>) (address)).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])));
					if(rd == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					return true;
				}
				/* STRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					((ScirRuntimePointer<byte>) (address)).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])));
					if(rd == 31)
						SPR = address;
					else
						XR[(int) rd] = address;
					return true;
				}
				/* STRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39000000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])));
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78000400U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])));
					if(rd == 31)
						SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (address)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)));
					return true;
				}
				/* STRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<uint>) ((rs) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rs])));
					if(rd == 31)
						SPR = address;
					else
						XR[(int) rd] = address;
					return true;
				}
				/* STRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79000000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ushort>) (imm))))).Value = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])));
					return true;
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
					var offset = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((ScirRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])) : ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (offset))))).Value = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt])));
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
						((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (offset))))).Value = (ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (offset))))).Value = (ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt]);
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
					var address = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (simm)))).Store();
					switch(rop) {
						case 0x0: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((ScirRuntimePointer<ushort>) (address)).Value = (ScirRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((ScirRuntimePointer<float>) (address)).Value = (ScirRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((ScirRuntimePointer<double>) (address)).Value = (ScirRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((ScirRuntimePointer<Vector128<float>>) (address)).Value = (ScirRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* STURB */
				if((inst & 0xFFE00C00U) == 0x38000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					((ScirRuntimePointer<byte>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (offset))))).Value = (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])));
					return true;
				}
				/* STURH */
				if((inst & 0xFFE00C00U) == 0x78000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					((ScirRuntimePointer<ushort>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<long>) (offset))))).Value = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])));
					return true;
				}
				/* STXR */
				if((inst & 0xBFE0FC00U) == 0x88007C00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					XR[(int) rs] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<byte>) (((byte) (((size) == (0x0)) ? 1U : 0U)) != 0 ? ((ScirRuntimeValue<byte>) (CallCompareAndSwap((ScirRuntimePointer<uint>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])), (ScirRuntimeValue<uint>) ((rt) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rt]), Exclusive32R))) : ((ScirRuntimeValue<byte>) (CallCompareAndSwap((ScirRuntimePointer<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])), (ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt]), Exclusive64R)))));
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
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift))))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift))))));
					} else {
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift)))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift)))));
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
					var r2 = (string) (((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
					var extend = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "LSL", 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => "LSL", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var m = ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).Store();
						if(rd == 31)
							SPR = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((option) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), _ => (ScirRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
						else
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((option) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), _ => (ScirRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
						} else {
							var m = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).Store();
							if(rd == 31)
								SPR = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((option) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), 0x6 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (ScirRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((option) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), 0x6 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (ScirRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
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
					var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) - ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) - ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) }))));
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
					var r2 = (string) (((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U) != 0) ? ("X") : ("W"));
					var extend = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "LSL", 0x3 => "UXTX", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })) : ((string) ((option) switch { 0x0 => "UXTB", 0x1 => "UXTH", 0x2 => "UXTW", 0x3 => "LSL", 0x4 => "SXTB", 0x5 => "SXTH", 0x6 => "SXTW", _ => "SXTX" })));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						var m = ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((option) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (SignExtRuntime<int>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), _ => (ScirRuntimeValue<uint>) (m) })).ShiftLeft(imm))))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
									var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm))))))).Store();
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
									var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
									NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
									NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
									NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
									NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
									return (usum).Store();
								}));
						} else {
							var m = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).Store();
							XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
									var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((option) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFF))))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (m)) & ((ScirRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (m)), 8))))), 0x5 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (m)), 16))))), 0x6 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (ScirRuntimeValue<ulong>) (m) })).ShiftLeft(imm))))))).Store();
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
									var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
									NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
									NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
									NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
									NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
									return (usum).Store();
								}));
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
					var shiftstr = (string) ((shift) switch { 0x0 => "LSL", 0x1 => "LSR", 0x2 => "ASR", _ => "ROR" });
					if((mode32) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (~((ScirRuntimeValue<uint>) ((shift) switch { 0x0 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (32 - (imm)))) | (((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (~((ScirRuntimeValue<ulong>) ((shift) switch { 0x0 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((ScirRuntimeValue<uint>) (64 - (imm)))) | (((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((ScirRuntimeValue<uint>) (imm))))) })))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
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
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var shiftstr = (string) ((shift) switch { 0x0 => "LSL #0", 0x1 => "LSL #12", _ => throw new NotImplementedException() });
					var rimm = (uint) ((shift != 0) ? ((uint) (((uint) ((uint) (imm))) << (int) (0xC))) : (imm));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Extensions.StmtBlock<ScirRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((uint) (rimm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) ((ScirRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<int>) (ScirRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Extensions.StmtBlock<ScirRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((ulong) (rimm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) ((ScirRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<long>) (ScirRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (ScirRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (ScirRuntimeValue<uint>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((ScirRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (ScirRuntimeValue<byte>) ((((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((ScirRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					return true;
				}
				/* SVC */
				if((inst & 0xFFE0001FU) == 0xD4000001U) {
					var imm = (inst >> 5) & 0xFFFFU;
					CallSvc(imm);
					return true;
				}
				/* SYS */
				if((inst & 0xFFF80000U) == 0xD5080000U) {
					var op1 = (inst >> 16) & 0x7U;
					var cn = (inst >> 12) & 0xFU;
					var cm = (inst >> 8) & 0xFU;
					var op2 = (inst >> 5) & 0x7U;
					var rt = (inst >> 0) & 0x1FU;
					return true;
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
					Label temp_156 = DefineLabel(), temp_158 = DefineLabel(), temp_157 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])).ShiftRight(imm)))) & ((ScirRuntimeValue<ulong>) (0x1))))) == (0x0)), temp_156, temp_158);
					Label(temp_156);
					Branch(addr);
					Branch(temp_157);
					Label(temp_158);
					Branch(pc + 4);
					Branch(temp_157);
					Label(temp_157);
					return true;
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
					Label temp_159 = DefineLabel(), temp_161 = DefineLabel(), temp_160 = DefineLabel();
					BranchIf((ScirRuntimeValue<byte>) (((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rt])).ShiftRight(imm)))) & ((ScirRuntimeValue<ulong>) (0x1))))) != (0x0)), temp_159, temp_161);
					Label(temp_159);
					Branch(addr);
					Branch(temp_160);
					Label(temp_161);
					Branch(pc + 4);
					Branch(temp_160);
					Label(temp_160);
					return true;
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
					switch(size) {
						case 0x0: {
							VHR[(int) (rd)] = (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) ((ScirRuntimeValue<uint>) (CallVectorSumUnsigned((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), esize, count))));
							break;
						}
						case 0x1: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) (((ScirRuntimeValue<uint>) (CallVectorSumUnsigned((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), esize, count))).Bitcast<float>());
							break;
						}
						case 0x2: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) (((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) (CallVectorSumUnsigned((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), esize, count))))).Bitcast<double>());
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
						var src = ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])).Store();
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (((src).ShiftLeft((ScirRuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((ScirRuntimeValue<uint>) (immr)))))) & ((ScirRuntimeValue<uint>) (wmask))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((((ScirRuntimeValue<uint>) (bot)) & ((ScirRuntimeValue<uint>) (tmask)))));
					} else {
						var src = ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])).Store();
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = ((ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((src).ShiftLeft((ScirRuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((ScirRuntimeValue<uint>) (immr)))))) & ((ScirRuntimeValue<ulong>) (wmask))))).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) ((((ScirRuntimeValue<ulong>) (bot)) & ((ScirRuntimeValue<ulong>) (tmask))));
					}
					return true;
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
					switch(st) {
						case 0x0: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn])));
							break;
						}
						case 0x4: {
							VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])));
							break;
						}
						case 0x5: {
							VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn])));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* UCVTF-vector-integer */
				if((inst & 0xFFBFFC00U) == 0x7E21D800U) {
					var size = (inst >> 22) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("S") : ("D"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						VSR[(int) (rd)] = (ScirRuntimeValue<float>) ((ScirRuntimeValue<float>) ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<float>) (VSR[(int) (rn)])).Bitcast<uint>())));
					} else {
						VDR[(int) (rd)] = (ScirRuntimeValue<double>) ((ScirRuntimeValue<double>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<double>) (VDR[(int) (rn)])).Bitcast<ulong>())));
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
						var operand2 = ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (Ternary<byte, uint>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((operand2) == (0x0))), (uint) ((uint) (0x0)), (ScirRuntimeValue<uint>) (((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))) / ((ScirRuntimeValue<uint>) (ScirRuntimeValue<uint>) (operand2))))));
					} else {
						var operand2 = ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm])).Store();
						XR[(int) rd] = (ScirRuntimeValue<ulong>) (Ternary<byte, ulong>((ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) ((operand2) == (0x0))), (ulong) ((ulong) (0x0)), (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))) / ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) (operand2)))));
					}
					return true;
				}
				/* UMADDL */
				if((inst & 0xFFE08000U) == 0x9BA00000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) ra]))) + ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rn) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rn]))))) * ((ScirRuntimeValue<ulong>) (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<uint>) ((rm) == 31 ? 0U : (ScirRuntimeValue<uint>) XR[(int) rm])))))))));
					return true;
				}
				/* UMULH */
				if((inst & 0xFFE0FC00U) == 0x9BC07C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (ScirRuntimeValue<ulong>) ((ScirRuntimeValue<ulong>) ((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rn]))))) * ((ScirRuntimeValue<UInt128>) (ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<UInt128>) ((ScirRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (ScirRuntimeValue<ulong>) XR[(int) rm]))))))).ShiftRight(0x40))));
					return true;
				}
				/* XTN */
				if((inst & 0xFF3FFC00U) == 0x0E212800U) {
					var size = (inst >> 22) & 0x3U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var tb = (string) ((size) switch { 0x0 => "8B", 0x1 => "4H", 0x2 => "2S", _ => throw new NotImplementedException() });
					var ta = (string) ((size) switch { 0x0 => "8H", 0x1 => "4S", 0x2 => "2D", _ => throw new NotImplementedException() });
					switch(size) {
						case 0x0: {
							var a = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x0))).Store();
							var b = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x1))).Store();
							var c = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x2))).Store();
							var d = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x3))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ulong>) ((ulong) ((ulong) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (a)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (b)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (c)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (d)));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<uint>(0x0))).Store();
							var b = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<uint>(0x1))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ulong>) ((ulong) ((ulong) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (a)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (b)));
							break;
						}
						case 0x2: {
							var a = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ulong>(0x0))).Store();
							VR[(int) (rd)] = (ScirRuntimeValue<Vector128<float>>) (((ScirRuntimeValue<ulong>) ((ulong) ((ulong) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (a)));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}
				/* XTN2 */
				if((inst & 0xFF3FFC00U) == 0x4E212800U) {
					var size = (inst >> 22) & 0x3U;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var tb = (string) ((size) switch { 0x0 => "16B", 0x1 => "8H", 0x2 => "4S", _ => throw new NotImplementedException() });
					var ta = (string) ((size) switch { 0x0 => "8H", 0x1 => "4S", 0x2 => "2D", _ => throw new NotImplementedException() });
					switch(size) {
						case 0x0: {
							var a = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x0))).Store();
							var b = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x1))).Store();
							var c = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x2))).Store();
							var d = ((ScirRuntimeValue<ushort>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ushort>(0x3))).Store();
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x8, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (a)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x9, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (b)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0xA, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (c)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0xB, (ScirRuntimeValue<byte>) ((ScirRuntimeValue<byte>) (d)));
							break;
						}
						case 0x1: {
							var a = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<uint>(0x0))).Store();
							var b = ((ScirRuntimeValue<uint>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<uint>(0x1))).Store();
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x4, (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (a)));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x5, (ScirRuntimeValue<ushort>) ((ScirRuntimeValue<ushort>) (b)));
							break;
						}
						case 0x2: {
							var a = ((ScirRuntimeValue<ulong>) (((ScirRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Element<ulong>(0x0))).Store();
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (ScirRuntimeValue<uint>) ((ScirRuntimeValue<uint>) (a)));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					return true;
				}

			}
			return false;
		}
	}
}