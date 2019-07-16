using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using UltimateOrb;
using Common;
using Label = Cpu64.LlvmLabel;
// ReSharper disable ArrangeRedundantParentheses
// ReSharper disable RedundantCast
// ReSharper disable UnusedVariable
#pragma warning disable 162, 219

namespace Cpu64 {
	public partial class LlvmRecompiler {
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
						var m = ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).Store();
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((option) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), _ => (LlvmRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((option) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), _ => (LlvmRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
						} else {
							var m = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).Store();
							if(rd == 31)
								SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((option) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), 0x6 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (m)), 32))))), _ => (LlvmRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((option) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), 0x6 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (m)), 32))))), _ => (LlvmRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
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
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (simm))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (simm))));
					} else {
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (simm)));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (simm)));
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
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))));
					} else {
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? SPR : XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))));
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
					var simm = (uint) (((uint) ((uint) (imm))) << (int) (shift));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) (simm));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) (simm));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) & ((LlvmRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) & ((LlvmRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) (imm))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) (imm))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) & ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))));
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
						var result = ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) & ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (result);
						NZCV_NR = (LlvmRuntimeValue<uint>) ((result).ShiftRight(0x1F));
						NZCV_ZR = (LlvmRuntimeValue<byte>) ((result) == (0x0));
						NZCV_CR = 0x0;
						NZCV_VR = 0x0;
					} else {
						var result = ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))).Store();
						XR[(int) rd] = result;
						NZCV_NR = (LlvmRuntimeValue<ulong>) ((result).ShiftRight(0x3F));
						NZCV_ZR = (LlvmRuntimeValue<byte>) ((result) == (0x0));
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
						var result = ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) (imm))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (result);
						NZCV_NR = (LlvmRuntimeValue<uint>) ((result).ShiftRight(0x1F));
						NZCV_ZR = (LlvmRuntimeValue<byte>) ((result) == (0x0));
						NZCV_CR = 0x0;
						NZCV_VR = 0x0;
					} else {
						var result = ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) (imm))))).Store();
						XR[(int) rd] = result;
						NZCV_NR = (LlvmRuntimeValue<ulong>) ((result).ShiftRight(0x3F));
						NZCV_ZR = (LlvmRuntimeValue<byte>) ((result) == (0x0));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).ShiftRight((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x20))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).ShiftRight((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x40)))))));
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_54 = DefineLabel(), temp_56 = DefineLabel(), temp_55 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_54, temp_56);
					Label(temp_54);
					Branch(addr);
					Branch(temp_55);
					Label(temp_56);
					Branch(pc + 4);
					Branch(temp_55);
					Label(temp_55);
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
						var dst = ((LlvmRuntimeValue<uint>) ((rd) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rd])).Store();
						var src = ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Store();
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) (dst)) & ((LlvmRuntimeValue<uint>) ((uint) (~(wmask)))))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((src).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((LlvmRuntimeValue<uint>) (immr)))))) & ((LlvmRuntimeValue<uint>) (wmask))))))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) (dst)) & ((LlvmRuntimeValue<uint>) ((uint) (~(tmask)))))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) (bot)) & ((LlvmRuntimeValue<uint>) (tmask)))))))));
					} else {
						var dst = ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rd])).Store();
						var src = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Store();
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (dst)) & ((LlvmRuntimeValue<ulong>) ((ulong) (~(wmask)))))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((src).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((LlvmRuntimeValue<uint>) (immr)))))) & ((LlvmRuntimeValue<ulong>) (wmask))))))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (dst)) & ((LlvmRuntimeValue<ulong>) ((ulong) (~(tmask)))))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (bot)) & ((LlvmRuntimeValue<ulong>) (tmask))))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) & ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) & ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))));
					}
					return true;
				}
				/* BL */
				if((inst & 0xFC000000U) == 0x94000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (offset)));
					XR[(int) 0x1E] = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (0x4)));
					Branch(addr);
					return true;
				}
				/* BLR */
				if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					XR[(int) 0x1E] = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (0x4)));
					Branch((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]));
					return true;
				}
				/* BR */
				if((inst & 0xFFFFFC1FU) == 0xD61F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]));
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
						var cl = ((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])).Store();
						var ch = ((LlvmRuntimeValue<uint>) (((ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))])).Store();
						var nl = ((LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt])).Store();
						var nh = ((LlvmRuntimeValue<uint>) (((ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))])).Store();
						var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						var data = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) (address)).Value)).Store();
						Label temp_57 = DefineLabel(), temp_59 = DefineLabel(), temp_58 = DefineLabel();
						BranchIf((LlvmRuntimeValue<byte>) ((data) == ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (ch))).ShiftLeft(0x20)))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (cl)))))))), temp_57, temp_59);
						Label(temp_57);
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (nh))).ShiftLeft(0x20)))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (nl))))));
						Branch(temp_58);
						Label(temp_59);
						Branch(temp_58);
						Label(temp_58);
						XR[(int) rs] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (data)));
						XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) ((data).ShiftRight(0x20)))));
					} else {
						var cl = ((LlvmRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rs])).Store();
						var ch = ((LlvmRuntimeValue<ulong>) (((ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))])).Store();
						var nl = ((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])).Store();
						var nh = ((LlvmRuntimeValue<ulong>) (((ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))])).Store();
						var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						var dl = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) (address)).Value)).Store();
						var dh = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value)).Store();
						Label temp_60 = DefineLabel(), temp_62 = DefineLabel(), temp_61 = DefineLabel();
						BranchIf((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((dl) == (cl)))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((dh) == (ch)))))), temp_60, temp_62);
						Label(temp_60);
						((LlvmRuntimePointer<ulong>) (address)).Value = nl;
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = nh;
						Branch(temp_61);
						Label(temp_62);
						Branch(temp_61);
						Label(temp_61);
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
						Label temp_63 = DefineLabel(), temp_65 = DefineLabel(), temp_64 = DefineLabel();
						BranchIf((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])) != ((uint) ((uint) (0x0)))), temp_63, temp_65);
						Label(temp_63);
						Branch(addr);
						Branch(temp_64);
						Label(temp_65);
						Branch(pc + 4);
						Branch(temp_64);
						Label(temp_64);
					} else {
						Label temp_66 = DefineLabel(), temp_68 = DefineLabel(), temp_67 = DefineLabel();
						BranchIf((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rs])) != ((ulong) ((ulong) (0x0)))), temp_66, temp_68);
						Label(temp_66);
						Branch(addr);
						Branch(temp_67);
						Label(temp_68);
						Branch(pc + 4);
						Branch(temp_67);
						Label(temp_67);
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
						Label temp_69 = DefineLabel(), temp_71 = DefineLabel(), temp_70 = DefineLabel();
						BranchIf((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])) == ((uint) ((uint) (0x0)))), temp_69, temp_71);
						Label(temp_69);
						Branch(addr);
						Branch(temp_70);
						Label(temp_71);
						Branch(pc + 4);
						Branch(temp_70);
						Label(temp_70);
					} else {
						Label temp_72 = DefineLabel(), temp_74 = DefineLabel(), temp_73 = DefineLabel();
						BranchIf((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rs])) == ((ulong) ((ulong) (0x0)))), temp_72, temp_74);
						Label(temp_72);
						Branch(addr);
						Branch(temp_73);
						Label(temp_74);
						Branch(pc + 4);
						Branch(temp_73);
						Label(temp_73);
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_75 = DefineLabel(), temp_77 = DefineLabel(), temp_76 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_75, temp_77);
					Label(temp_75);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) 0x1F] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) ((uint) (imm))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) 0x1F] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) ((ulong) (imm))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					Branch(temp_76);
					Label(temp_77);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_76);
					Label(temp_76);
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_78 = DefineLabel(), temp_80 = DefineLabel(), temp_79 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_78, temp_80);
					Label(temp_78);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) 0x1F] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((uint) (imm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) 0x1F] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((ulong) (imm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					Branch(temp_79);
					Label(temp_80);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_79);
					Label(temp_79);
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_81 = DefineLabel(), temp_83 = DefineLabel(), temp_82 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_81, temp_83);
					Label(temp_81);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) 0x1F] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) 0x1F] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							}));
					}
					Branch(temp_82);
					Label(temp_83);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_82);
					Label(temp_82);
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (CallCountLeadingZeros((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (CallCountLeadingZeros((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])));
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
					VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (CallVectorCountBits((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), (long) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => 0x8, _ => 0x10 })));
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_84 = DefineLabel(), temp_86 = DefineLabel(), temp_85 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_84, temp_86);
					Label(temp_84);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_85);
					Label(temp_86);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]);
					}
					Branch(temp_85);
					Label(temp_85);
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_87 = DefineLabel(), temp_89 = DefineLabel(), temp_88 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_87, temp_89);
					Label(temp_87);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_88);
					Label(temp_89);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((uint) ((uint) (0x1))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x1)));
					}
					Branch(temp_88);
					Label(temp_88);
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_90 = DefineLabel(), temp_92 = DefineLabel(), temp_91 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_90, temp_92);
					Label(temp_90);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_91);
					Label(temp_92);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])));
					}
					Branch(temp_91);
					Label(temp_91);
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_93 = DefineLabel(), temp_95 = DefineLabel(), temp_94 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_93, temp_95);
					Label(temp_93);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]);
					}
					Branch(temp_94);
					Label(temp_95);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (-((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (-((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))))));
					}
					Branch(temp_94);
					Label(temp_94);
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
					var src = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Store();
					VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (src)))).CreateVector())) : ((LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (src)))).CreateVector()))))) : ((LlvmRuntimeValue<Vector128<float>>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x3))))) == (0x2)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (src)))).CreateVector())) : ((LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (src)))).CreateVector()))))) : ((LlvmRuntimeValue<Vector128<float>>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x7))))) == (0x4)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (src)))).CreateVector())) : ((LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (src)))).CreateVector()))))) : ((LlvmRuntimeValue<Vector128<float>>) ((Q) != 0 ? ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<ulong>) (src)).CreateVector())) : throw new NotImplementedException())))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))));
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
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<ulong>) (imm))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<ulong>) (imm))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) ^ ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))));
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
					VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (CallVectorExtract((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)]), Q, index));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).ShiftLeft((ulong) (((ulong) (long) (0x20)) - ((ulong) (byte) (lsb))))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(lsb)))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).ShiftLeft((ulong) (((ulong) (long) (0x40)) - ((ulong) (byte) (lsb))))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(lsb))))));
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
							VHR[(int) (rd)] = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimeValue<ushort>) (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (VHR[(int) (rn)]))) + ((LlvmRuntimeValue<ushort>) (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (VHR[(int) (rm)]))))));
							break;
						}
						case 0x0: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))) + ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rm)]))));
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
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)])));
							break;
						}
						case 0x3: {
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<double>>) ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) + (LlvmRuntimeValue<Vector128<double>>) ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
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
						VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x0)))) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x1)))));
					} else {
						VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VR[(int) (rn)].Element<double>(0x0)))) + ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VR[(int) (rn)].Element<double>(0x1)))));
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
							var a = ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x0))).Store();
							var b = ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x1))).Store();
							var c = ((LlvmRuntimeValue<float>) (VR[(int) (rm)].Element<float>(0x0))).Store();
							var d = ((LlvmRuntimeValue<float>) (VR[(int) (rm)].Element<float>(0x1))).Store();
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (a)) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (b))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (c)) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (d))));
							break;
						}
						case 0x1: {
							var a = ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x0))).Store();
							var b = ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x1))).Store();
							var c = ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x2))).Store();
							var d = ((LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(0x3))).Store();
							var e = ((LlvmRuntimeValue<float>) (VR[(int) (rm)].Element<float>(0x0))).Store();
							var f = ((LlvmRuntimeValue<float>) (VR[(int) (rm)].Element<float>(0x1))).Store();
							var g = ((LlvmRuntimeValue<float>) (VR[(int) (rm)].Element<float>(0x2))).Store();
							var h = ((LlvmRuntimeValue<float>) (VR[(int) (rm)].Element<float>(0x3))).Store();
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (a)) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (b))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (c)) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (d))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x2, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (e)) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (f))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x3, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (g)) + ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) (h))));
							break;
						}
						case 0x3: {
							var a = ((LlvmRuntimeValue<double>) (VR[(int) (rn)].Element<double>(0x0))).Store();
							var b = ((LlvmRuntimeValue<double>) (VR[(int) (rn)].Element<double>(0x1))).Store();
							var c = ((LlvmRuntimeValue<double>) (VR[(int) (rm)].Element<double>(0x0))).Store();
							var d = ((LlvmRuntimeValue<double>) (VR[(int) (rm)].Element<double>(0x1))).Store();
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<float>) ((float) ((float) (0x0)))).CreateVector());
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x0, (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) (a)) + ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) (b))));
							VR[(int) (rd)] = VR[(int) (rd)].Insert(0x1, (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) (c)) + ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) (d))));
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_96 = DefineLabel(), temp_98 = DefineLabel(), temp_97 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_96, temp_98);
					Label(temp_96);
					switch(type) {
						case 0x0: {
							var __macro_fcmp_a = ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((LlvmRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							NZCVR = (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						case 0x1: {
							var __macro_fcmp_a = ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((LlvmRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							NZCVR = (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					Branch(temp_97);
					Label(temp_98);
					NZCVR = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					Branch(temp_97);
					Label(temp_97);
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
							var __macro_fcmp_a = ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((LlvmRuntimeValue<float>) (((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0 ? ((float) ((float) (0x0))) : ((LlvmRuntimeValue<float>) (VSR[(int) (rm)])))).Store();
							NZCVR = (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
							break;
						}
						case 0x1: {
							var __macro_fcmp_a = ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var __macro_fcmp_b = ((LlvmRuntimeValue<double>) (((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0 ? ((double) ((double) (0x0))) : ((LlvmRuntimeValue<double>) (VDR[(int) (rm)])))).Store();
							NZCVR = (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a).IsNaN()))) | ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_b).IsNaN())))))), 0x3, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) == (__macro_fcmp_b))), 0x6, (LlvmRuntimeValue<long>) (Ternary<byte, long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((__macro_fcmp_a) < (__macro_fcmp_b))), 0x8, 0x2))))))).ShiftLeft(0x1C))));
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
					var result = ((LlvmRuntimeValue<byte>) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_ZR)), 0x1 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR)), 0x2 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_NR)), 0x3 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_VR)), 0x4 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (NZCV_CR))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), 0x5 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR)))), 0x6 => (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<byte>) (NZCV_NR)) == ((LlvmRuntimeValue<byte>) (NZCV_VR))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (!((LlvmRuntimeValue<byte>) (NZCV_ZR)))))))), _ => (LlvmRuntimeValue<byte>) (0x1) })).Store();
					Label temp_99 = DefineLabel(), temp_101 = DefineLabel(), temp_100 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U)))))) != 0 ? ((LlvmRuntimeValue<byte>) (!(result))) : (result)), temp_99, temp_101);
					Label(temp_99);
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (VSR[(int) (rn)]);
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (VDR[(int) (rn)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					Branch(temp_100);
					Label(temp_101);
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (VSR[(int) (rm)]);
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (VDR[(int) (rm)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					Branch(temp_100);
					Label(temp_100);
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<ushort>) (VHR[(int) (rn)])));
							break;
						}
						case 0xD: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<ushort>) (VHR[(int) (rn)])));
							break;
						}
						case 0x3: {
							VHR[(int) (rd)] = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x7: {
							VHR[(int) (rd)] = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])));
							break;
						}
						case 0x4: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])));
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
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (CallFloatToFixed32((LlvmRuntimeValue<float>) (VSR[(int) (rn)]), fbits)));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (CallFloatToFixed64((LlvmRuntimeValue<float>) (VSR[(int) (rn)]), fbits));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (CallFloatToFixed32((LlvmRuntimeValue<double>) (VDR[(int) (rn)]), fbits)));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (CallFloatToFixed64((LlvmRuntimeValue<double>) (VDR[(int) (rn)]), fbits));
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
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))))));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])))));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))))));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])))));
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
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (CallFloatToFixed32((LlvmRuntimeValue<float>) (VSR[(int) (rn)]), fbits)));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (CallFloatToFixed64((LlvmRuntimeValue<float>) (VSR[(int) (rn)]), fbits));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (CallFloatToFixed32((LlvmRuntimeValue<double>) (VDR[(int) (rn)]), fbits)));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (CallFloatToFixed64((LlvmRuntimeValue<double>) (VDR[(int) (rn)]), fbits));
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
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))));
							break;
						}
						case 0x4: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x1: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))));
							break;
						}
						case 0x5: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])));
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))) / ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))) / ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rm)]))));
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
							var a = ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var b = ((LlvmRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (Ternary<byte, float>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((a) > (b))), a, b));
							break;
						}
						case 0x1: {
							var a = ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var b = ((LlvmRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (Ternary<byte, double>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((a) > (b))), a, b));
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
							var a = ((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Store();
							var b = ((LlvmRuntimeValue<float>) (VSR[(int) (rm)])).Store();
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (Ternary<byte, float>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((a) < (b))), a, b));
							break;
						}
						case 0x1: {
							var a = ((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Store();
							var b = ((LlvmRuntimeValue<double>) (VDR[(int) (rm)])).Store();
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (Ternary<byte, double>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((a) < (b))), a, b));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
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
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ushort>) (VHR[(int) (rn)]))));
							break;
						}
						case 0xE6: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (VHR[(int) (rn)])));
							break;
						}
						case 0x67: {
							VHR[(int) (rd)] = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])));
							break;
						}
						case 0x7: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Bitcast<float>());
							break;
						}
						case 0x6: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Bitcast<uint>()));
							break;
						}
						case 0xE7: {
							VHR[(int) (rd)] = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])));
							break;
						}
						case 0xA7: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Bitcast<double>());
							break;
						}
						case 0xA6: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Bitcast<ulong>());
							break;
						}
						case 0xCE: {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<double>) (VDR[(int) ((byte) ((((ulong) ((byte) ((rn) << (int) (0x1)))) | ((ulong) (0x1)))))])).Bitcast<ulong>());
							break;
						}
						case 0xCF: {
							VDR[(int) ((byte) ((((ulong) ((byte) ((rd) << (int) (0x1)))) | ((ulong) (0x1)))))] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Bitcast<double>());
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
				/* FMUL-scalar */
				if((inst & 0xFF20FC00U) == 0x1E200800U) {
					var type = (inst >> 22) & 0x3U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) ((type) switch { 0x3 => "H", 0x0 => "S", 0x1 => "D", _ => throw new NotImplementedException() });
					switch(type) {
						case 0x0: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))) * ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))) * ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rm)]))));
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
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)])));
							break;
						}
						case 0x3: {
							VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<double>>) ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])) * (LlvmRuntimeValue<Vector128<double>>) ((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rm)]))));
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (-((LlvmRuntimeValue<float>) (VSR[(int) (rn)])));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (-((LlvmRuntimeValue<double>) (VDR[(int) (rn)])));
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (-((LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))) * ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rm)]))))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (-((LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))) * ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rm)]))))));
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
					VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Frsqrte(0x20, 0x2))), 0x1 => (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Frsqrte(0x20, 0x4))), 0x3 => (LlvmRuntimeValue<Vector128<float>>) ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)])).Frsqrte(0x40, 0x2))), _ => throw new NotImplementedException() });
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))).Sqrt());
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))).Sqrt());
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rn)]))) - ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) (VSR[(int) (rm)]))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rn)]))) - ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) (VDR[(int) (rm)]))));
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
						VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
							VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Bitcast<float>()));
							} else {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index, (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Bitcast<double>()));
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
						VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (LlvmRuntimeValue<byte>) (VR[(int) (rn)].Element<byte>(index2)));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
							VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (LlvmRuntimeValue<ushort>) (VR[(int) (rn)].Element<ushort>(index2)));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (LlvmRuntimeValue<float>) (VR[(int) (rn)].Element<float>(index2)));
							} else {
								VR[(int) (rd)] = VR[(int) (rd)].Insert(index1, (LlvmRuntimeValue<double>) (VR[(int) (rn)].Element<double>(index2)));
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
						var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value));
					} else {
						var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) (address)).Value);
					}
					return true;
				}
				/* LDARB */
				if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value)));
					return true;
				}
				/* LDARH */
				if((inst & 0xFFFFFC00U) == 0x48DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value)));
					return true;
				}
				/* LDAXB */
				if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Exclusive32R = ((LlvmRuntimePointer<uint>) (address)).Value));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (Exclusive64R = ((LlvmRuntimePointer<ulong>) (address)).Value);
					}
					return true;
				}
				/* LDAXRB */
				if((inst & 0xFFFFFC00U) == 0x085FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (Exclusive8R = ((LlvmRuntimePointer<byte>) (address)).Value)));
					return true;
				}
				/* LDAXRH */
				if((inst & 0xFFFFFC00U) == 0x485FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (Exclusive16R = ((LlvmRuntimePointer<ushort>) (address)).Value)));
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
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt1] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value));
						XR[(int) rt2] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value));
					} else {
						XR[(int) rt1] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) (address)).Value);
						XR[(int) rt2] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value);
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt1] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value));
						XR[(int) rt2] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value));
					} else {
						XR[(int) rt1] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) (address)).Value);
						XR[(int) rt2] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					switch(opc) {
						case 0x0: {
							VSR[(int) (rt1)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) (address)).Value);
							VSR[(int) (rt2)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value);
							break;
						}
						case 0x1: {
							VDR[(int) (rt1)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) (address)).Value);
							VDR[(int) (rt2)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value);
							break;
						}
						default: {
							VR[(int) (rt1)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) (address)).Value);
							VR[(int) (rt2)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x10))))).Value);
							break;
						}
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					switch(opc) {
						case 0x0: {
							VSR[(int) (rt1)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) (address)).Value);
							VSR[(int) (rt2)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value);
							break;
						}
						case 0x1: {
							VDR[(int) (rt1)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) (address)).Value);
							VDR[(int) (rt2)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value);
							break;
						}
						default: {
							VR[(int) (rt1)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) (address)).Value);
							VR[(int) (rt2)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x10))))).Value);
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					XR[(int) rt1] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value), 32))));
					XR[(int) rt2] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value), 32))));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) (address)).Value);
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value);
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x2: {
							VHR[(int) (rt)] = (LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) (address)).Value);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
							VBR[(int) (rt)] = (LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						case 0x5: {
							VHR[(int) (rt)] = (LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						case 0x9: {
							VSR[(int) (rt)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						case 0xD: {
							VDR[(int) (rt)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (imm))))).Value);
							break;
						}
						default: {
							VR[(int) (rt)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (imm))))).Value);
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((option) switch { 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))), 0x3 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])), 0x6 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))), 0x7 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])), _ => throw new NotImplementedException() })).ShiftLeft(amount))).Store();
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset)))).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) (address)).Value);
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value);
					}
					return true;
				}
				/* LDRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value))));
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value))));
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
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value)));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value));
					return true;
				}
				/* LDRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value)));
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value)));
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
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value)));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value));
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
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value), 8)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value), 8))));
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value), 8)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value), 8))));
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
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value), 8)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value), 8))));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value), 8)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value), 8))));
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
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value), 16)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value), 16))));
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value), 16)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) (address)).Value), 16))));
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
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value), 16)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value), 16))));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value), 16)))));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value), 16))));
					}
					return true;
				}
				/* LDRSW-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0xB8800400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value), 32))));
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)));
					return true;
				}
				/* LDRSW-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0xB8800C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) (address)).Value), 32))));
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
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value), 32))));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value), 32))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value);
					}
					return true;
				}
				/* LDURB */
				if((inst & 0xFFE00C00U) == 0x38400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value)));
					return true;
				}
				/* LDURH */
				if((inst & 0xFFE00C00U) == 0x78400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value)));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value), 8)))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value), 8))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value), 16)))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) (((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value), 16))));
					}
					return true;
				}
				/* LDURSW */
				if((inst & 0xFFE00C00U) == 0xB8800000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) (((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm))))).Value), 32))));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (imm)))).Store();
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							VBR[(int) (rt)] = (LlvmRuntimeValue<byte>) (((LlvmRuntimePointer<byte>) (address)).Value);
							break;
						}
						case 0x4: {
							VSR[(int) (rt)] = (LlvmRuntimeValue<float>) (((LlvmRuntimePointer<float>) (address)).Value);
							break;
						}
						case 0x6: {
							VDR[(int) (rt)] = (LlvmRuntimeValue<double>) (((LlvmRuntimePointer<double>) (address)).Value);
							break;
						}
						case 0x1: {
							VR[(int) (rt)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimePointer<Vector128<float>>) (address)).Value);
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
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Exclusive32R = ((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value));
					} else {
						XR[(int) rt] = (LlvmRuntimeValue<ulong>) (Exclusive64R = ((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value);
					}
					return true;
				}
				/* LDXRB */
				if((inst & 0xFFFFFC00U) == 0x085F7C00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (Exclusive8R = ((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value)));
					return true;
				}
				/* LDXRH */
				if((inst & 0xFFFFFC00U) == 0x485F7C00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ushort>) (Exclusive16R = ((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value)));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).ShiftLeft((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x20))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).ShiftLeft((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x40)))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).ShiftRight((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x20))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).ShiftRight((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x40)))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) * ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((ra) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) ra])))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) * ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) ra]))));
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
					var avec = ((LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<float>) ((float) (Bitcast<uint, float>((uint) (((uint) ((uint) (imm))) << (int) (amount)))))).CreateVector())).Store();
					if((Q) != 0) {
						VR[(int) (rd)] = avec;
					} else {
						VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (avec);
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
					VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (((LlvmRuntimeValue<ulong>) (imm)).CreateVector());
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rd) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rd]))) & ((LlvmRuntimeValue<uint>) ((uint) ((((uint) ((uint) ((uint) (-0x1)))) ^ ((uint) ((uint) (((uint) ((uint) (0xFFFF))) << (int) (shift)))))))))))) | ((LlvmRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift)))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rd]))) & ((LlvmRuntimeValue<ulong>) ((ulong) ((((ulong) ((ulong) ((ulong) (-0x1)))) ^ ((ulong) ((ulong) (((ulong) ((ulong) (0xFFFF))) << (int) (shift)))))))))))) | ((LlvmRuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((uint) (~((uint) (((uint) ((uint) (imm))) << (int) (shift)))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift)));
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
					XR[(int) rt] = (LlvmRuntimeValue<ulong>) (CallSR(op0, op1, cn, cm, op2));
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
					CallSR(op0, op1, cn, cm, op2, (LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt]));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((ra) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) ra]))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) * ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) ra]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) * ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))));
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
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) | ((LlvmRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) | ((LlvmRuntimeValue<uint>) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) | ((LlvmRuntimeValue<ulong>) (imm))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) | ((LlvmRuntimeValue<ulong>) (imm))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))));
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
						VR[(int) (rd)] = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)]);
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (CallReverseBits((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (CallReverseBits((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])));
					}
					return true;
				}
				/* RET */
				if((inst & 0xFFFFFC1FU) == 0xD65F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]));
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
							var x = ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Store();
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (x)) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18)))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((x).ShiftRight(0x8)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((x).ShiftRight(0x10)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((x).ShiftRight(0x18)))) & ((LlvmRuntimeValue<ulong>) (0xFF)))))))));
							break;
						}
						case 0x3: {
							var x = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Store();
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((((((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (x)) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x38)))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x8)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x30))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x10)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x28))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x18)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x20))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x20)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x28)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x30)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x38)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))))));
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
						var x = ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (x)) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8)))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((x).ShiftRight(0x8)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((x).ShiftRight(0x10)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((x).ShiftRight(0x18)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10)))))));
					} else {
						var x = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((((((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (x)) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x8)))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x8)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x10)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x18))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x18)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x10))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x20)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x28))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x28)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x20))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x30)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x38))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((x).ShiftRight(0x38)))) & ((LlvmRuntimeValue<ulong>) (0xFF))))).ShiftLeft(0x30))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x20))))))) | (((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).ShiftRight((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x20))))))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x40))))))) | (((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).ShiftRight((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))) % ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x40)))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<byte>) (NZCV_CR)))).Store();
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
						var src = ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Store();
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((src).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((LlvmRuntimeValue<uint>) (immr)))))) & ((LlvmRuntimeValue<uint>) (wmask))))).Store();
						var top = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((uint) ((uint) (0x0)))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((src).ShiftRight(imms)))) & ((LlvmRuntimeValue<ulong>) (0x1)))))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) (top)) & ((LlvmRuntimeValue<uint>) ((uint) (~(tmask)))))))) | ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) (bot)) & ((LlvmRuntimeValue<uint>) (tmask)))))))));
					} else {
						var src = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Store();
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((src).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((LlvmRuntimeValue<uint>) (immr)))))) & ((LlvmRuntimeValue<ulong>) (wmask))))).Store();
						var top = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (0x0)))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((src).ShiftRight(imms)))) & ((LlvmRuntimeValue<ulong>) (0x1)))))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (top)) & ((LlvmRuntimeValue<ulong>) ((ulong) (~(tmask)))))))) | ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (bot)) & ((LlvmRuntimeValue<ulong>) (tmask))))))));
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))));
							break;
						}
						case 0x4: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))));
							break;
						}
						case 0x5: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))));
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
						VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Bitcast<int>())));
					} else {
						VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Bitcast<long>())));
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
						var operand2 = ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Ternary<byte, uint>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((operand2) == (0x0))), (uint) ((uint) (0x0)), (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<float>) (((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))))))) / ((LlvmRuntimeValue<float>) (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (operand2))))))))))));
					} else {
						var operand2 = ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Ternary<byte, ulong>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((operand2) == (0x0))), (ulong) ((ulong) (0x0)), (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<double>) (((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))))))) / ((LlvmRuntimeValue<double>) (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (operand2)))))))))));
					}
					return true;
				}
				/* SMADDL */
				if((inst & 0xFFE08000U) == 0x9B200000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) ra]))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]), 32)))) * ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))))))));
					return true;
				}
				/* SMULH */
				if((inst & 0xFFE0FC00U) == 0x9B407C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<Int128>) (((LlvmRuntimeValue<Int128>) (((LlvmRuntimeValue<Int128>) (LlvmRuntimeValue<Int128>) ((LlvmRuntimeValue<Int128>) ((LlvmRuntimeValue<Int128>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))))))) * ((LlvmRuntimeValue<Int128>) (LlvmRuntimeValue<Int128>) ((LlvmRuntimeValue<Int128>) ((LlvmRuntimeValue<Int128>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))))))))).ShiftRight(0x40))))));
					return true;
				}
				/* STLR */
				if((inst & 0xBFFFFC00U) == 0x889FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value = (LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))).Value = (LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt]);
					}
					return true;
				}
				/* STLRB */
				if((inst & 0xFFFFFC00U) == 0x089FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					((LlvmRuntimePointer<byte>) (address)).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STLRH */
				if((inst & 0xFFFFFC00U) == 0x489FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STLXR */
				if((inst & 0xBFE0FC00U) == 0x8800FC00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) (address)).Value = (LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt]);
					}
					XR[(int) rs] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (0x0);
					return true;
				}
				/* STLXRB */
				if((inst & 0xFFE0FC00U) == 0x0800FC00U) {
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					((LlvmRuntimePointer<byte>) (address)).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt])));
					XR[(int) rs] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) (0x0);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) (address)).Value = (LlvmRuntimeValue<uint>) ((rt1) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt1]);
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value = (LlvmRuntimeValue<uint>) ((rt2) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt2]);
					} else {
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((rt1) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt1]);
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = (LlvmRuntimeValue<ulong>) ((rt2) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt2]);
					}
					if(rd == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) (address)).Value = (LlvmRuntimeValue<uint>) ((rt1) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt1]);
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value = (LlvmRuntimeValue<uint>) ((rt2) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt2]);
					} else {
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((rt1) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt1]);
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = (LlvmRuntimeValue<ulong>) ((rt2) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt2]);
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) (address)).Value = (LlvmRuntimeValue<uint>) ((rt1) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt1]);
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value = (LlvmRuntimeValue<uint>) ((rt2) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt2]);
					} else {
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((rt1) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt1]);
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = (LlvmRuntimeValue<ulong>) ((rt2) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt2]);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					switch(opc) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt1)]);
							((LlvmRuntimePointer<float>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						}
						case 0x1: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt1)]);
							((LlvmRuntimePointer<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							((LlvmRuntimePointer<Vector128<float>>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x10))))).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rd == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					switch(opc) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt1)]);
							((LlvmRuntimePointer<float>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						}
						case 0x1: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt1)]);
							((LlvmRuntimePointer<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							((LlvmRuntimePointer<Vector128<float>>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x10))))).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					switch(opc) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt1)]);
							((LlvmRuntimePointer<float>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x4))))).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt2)]);
							break;
						}
						case 0x1: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt1)]);
							((LlvmRuntimePointer<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x8))))).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt2)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt1)]);
							((LlvmRuntimePointer<Vector128<float>>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (0x10))))).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt2)]);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) (address)).Value = (LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs]);
					} else {
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rs]);
					}
					if(rd == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) (address)).Value = (LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs]);
					} else {
						((LlvmRuntimePointer<ulong>) (address)).Value = (LlvmRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rs]);
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
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (pimm))))).Value = (LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs]);
					} else {
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (pimm))))).Value = (LlvmRuntimeValue<ulong>) ((rs) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rs]);
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value = (LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value = (LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt]);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])).Store();
					switch(rop) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rn] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					switch(rop) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) ((ushort) ((imm) << (int) (scale)))))).Store();
					switch(rop) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
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
					var address = ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					((LlvmRuntimePointer<byte>) (address)).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])));
					if(rd == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					return true;
				}
				/* STRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					((LlvmRuntimePointer<byte>) (address)).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])));
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
					((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt])));
					return true;
				}
				/* STRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78000400U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd])).Store();
					((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])));
					if(rd == 31)
						SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					else
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (address)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)));
					return true;
				}
				/* STRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rd) == 31 ? SPR : XR[(int) rd]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<uint>) ((rs) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rs])));
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
					((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ushort>) (imm))))).Value = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])));
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
					var offset = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((byte) (((option) == (0x6)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm]), 32))))) : ((LlvmRuntimeValue<ulong>) (((byte) ((((ulong) (option)) & ((ulong) (0x1))))) != 0 ? ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])) : ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))).ShiftLeft(amount))).Store();
					((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (offset))))).Value = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt])));
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
						((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (offset))))).Value = (LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt]);
					} else {
						((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (offset))))).Value = (LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt]);
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
					var address = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (simm)))).Store();
					switch(rop) {
						case 0x0: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VBR[(int) (rt)]);
							break;
						}
						case 0x4: {
							((LlvmRuntimePointer<ushort>) (address)).Value = (LlvmRuntimeValue<ushort>) (VHR[(int) (rt)]);
							break;
						}
						case 0x8: {
							((LlvmRuntimePointer<float>) (address)).Value = (LlvmRuntimeValue<float>) (VSR[(int) (rt)]);
							break;
						}
						case 0xC: {
							((LlvmRuntimePointer<double>) (address)).Value = (LlvmRuntimeValue<double>) (VDR[(int) (rt)]);
							break;
						}
						case 0x2: {
							((LlvmRuntimePointer<Vector128<float>>) (address)).Value = (LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rt)]);
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
					((LlvmRuntimePointer<byte>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (offset))))).Value = (LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])));
					return true;
				}
				/* STURH */
				if((inst & 0xFFE00C00U) == 0x78000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					((LlvmRuntimePointer<ushort>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<long>) (offset))))).Value = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])));
					return true;
				}
				/* STXR */
				if((inst & 0xBFE0FC00U) == 0x88007C00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					XR[(int) rs] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<byte>) (((byte) (((size) == (0x0)) ? 1U : 0U)) != 0 ? ((LlvmRuntimeValue<byte>) (CallCompareAndSwap((LlvmRuntimePointer<uint>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])), (LlvmRuntimeValue<uint>) ((rt) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rt]), Exclusive32R))) : ((LlvmRuntimeValue<byte>) (CallCompareAndSwap((LlvmRuntimePointer<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])), (LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt]), Exclusive64R)))));
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
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift))))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((uint) (((uint) ((uint) (imm))) << (int) (shift))))));
					} else {
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift)))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift)))));
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
						var m = ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).Store();
						if(rd == 31)
							SPR = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((option) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), _ => (LlvmRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
						else
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((option) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), _ => (LlvmRuntimeValue<uint>) (m) })).ShiftLeft(imm))))));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm)))));
						} else {
							var m = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).Store();
							if(rd == 31)
								SPR = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((option) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), 0x6 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (LlvmRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
							else
								XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((option) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), 0x6 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (LlvmRuntimeValue<ulong>) (m) })).ShiftLeft(imm)))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) - ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) - ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) }))));
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
						var m = ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((option) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x4 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (SignExtRuntime<int>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), _ => (LlvmRuntimeValue<uint>) (m) })).ShiftLeft(imm))))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
									var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft(imm))))))).Store();
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
									var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
									NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
									NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
									NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
									NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
									return (usum).Store();
								}));
						} else {
							var m = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).Store();
							XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? SPR : XR[(int) rn])))).Store();
									var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((option) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFF))))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFF))))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (m)) & ((LlvmRuntimeValue<ulong>) (0xFFFFFFFF))))), 0x4 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (m)), 8))))), 0x5 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) (m)), 16))))), 0x6 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (SignExtRuntime<long>(m, 64))))), _ => (LlvmRuntimeValue<ulong>) (m) })).ShiftLeft(imm))))))).Store();
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
									var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
									NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
									NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
									NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
									NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (~((LlvmRuntimeValue<uint>) ((shift) switch { 0x0 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (imm)))) | (((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (~((LlvmRuntimeValue<ulong>) ((shift) switch { 0x0 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftLeft(imm))), 0x1 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight(imm))), 0x2 => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])))).ShiftRight(imm))))), _ => (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (imm)))) | (((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).ShiftRight((LlvmRuntimeValue<uint>) (imm))))) })))))).Store();
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand2).ShiftRight(bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Extensions.StmtBlock<LlvmRuntimeValue<uint>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((uint) (rimm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) ((LlvmRuntimeValue<int>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<int>) (LlvmRuntimeValue<int>) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<uint>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<uint>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
								return (usum).Store();
							})));
					} else {
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Extensions.StmtBlock<LlvmRuntimeValue<ulong>>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])))).Store();
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((ulong) (rimm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (__macro_add_with_carry_set_nzcv_common_carryIn)))).Store();
								var ssum = ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) ((LlvmRuntimeValue<long>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<long>) (LlvmRuntimeValue<long>) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).Store();
								NZCV_NR = (LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1));
								NZCV_ZR = (LlvmRuntimeValue<byte>) ((usum) == (0x0));
								NZCV_CR = (LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))).ShiftRight(bits)))))) & ((LlvmRuntimeValue<ulong>) (0x1))));
								NZCV_VR = (LlvmRuntimeValue<byte>) ((((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))))) & ((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((usum).ShiftRight(bits1))) != ((LlvmRuntimeValue<ulong>) ((__macro_add_with_carry_set_nzcv_common_operand1).ShiftRight(bits1))))))));
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
					Label temp_102 = DefineLabel(), temp_104 = DefineLabel(), temp_103 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])).ShiftRight(imm)))) & ((LlvmRuntimeValue<ulong>) (0x1))))) == (0x0)), temp_102, temp_104);
					Label(temp_102);
					Branch(addr);
					Branch(temp_103);
					Label(temp_104);
					Branch(pc + 4);
					Branch(temp_103);
					Label(temp_103);
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
					Label temp_105 = DefineLabel(), temp_107 = DefineLabel(), temp_106 = DefineLabel();
					BranchIf((LlvmRuntimeValue<byte>) (((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) ((rt) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rt])).ShiftRight(imm)))) & ((LlvmRuntimeValue<ulong>) (0x1))))) != (0x0)), temp_105, temp_107);
					Label(temp_105);
					Branch(addr);
					Branch(temp_106);
					Label(temp_107);
					Branch(pc + 4);
					Branch(temp_106);
					Label(temp_106);
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
							VHR[(int) (rd)] = (LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<ushort>) ((LlvmRuntimeValue<uint>) (CallVectorSumUnsigned((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), esize, count))));
							break;
						}
						case 0x1: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) (((LlvmRuntimeValue<uint>) (CallVectorSumUnsigned((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), esize, count))).Bitcast<float>());
							break;
						}
						case 0x2: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) (((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) (CallVectorSumUnsigned((LlvmRuntimeValue<Vector128<float>>) (VR[(int) (rn)]), esize, count))))).Bitcast<double>());
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
						var src = ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])).Store();
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (((src).ShiftLeft((LlvmRuntimeValue<uint>) (32 - (immr)))) | ((src).ShiftRight((LlvmRuntimeValue<uint>) (immr)))))) & ((LlvmRuntimeValue<uint>) (wmask))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((((LlvmRuntimeValue<uint>) (bot)) & ((LlvmRuntimeValue<uint>) (tmask)))));
					} else {
						var src = ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])).Store();
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = ((LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((src).ShiftLeft((LlvmRuntimeValue<uint>) (64 - (immr)))) | ((src).ShiftRight((LlvmRuntimeValue<uint>) (immr)))))) & ((LlvmRuntimeValue<ulong>) (wmask))))).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((((LlvmRuntimeValue<ulong>) (bot)) & ((LlvmRuntimeValue<ulong>) (tmask))));
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
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])));
							break;
						}
						case 0x1: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn])));
							break;
						}
						case 0x4: {
							VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])));
							break;
						}
						case 0x5: {
							VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn])));
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
						VSR[(int) (rd)] = (LlvmRuntimeValue<float>) ((LlvmRuntimeValue<float>) ((LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<float>) (VSR[(int) (rn)])).Bitcast<uint>())));
					} else {
						VDR[(int) (rd)] = (LlvmRuntimeValue<double>) ((LlvmRuntimeValue<double>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<double>) (VDR[(int) (rn)])).Bitcast<ulong>())));
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
						var operand2 = ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) (Ternary<byte, uint>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((operand2) == (0x0))), (uint) ((uint) (0x0)), (LlvmRuntimeValue<uint>) (((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))) / ((LlvmRuntimeValue<uint>) (LlvmRuntimeValue<uint>) (operand2))))));
					} else {
						var operand2 = ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm])).Store();
						XR[(int) rd] = (LlvmRuntimeValue<ulong>) (Ternary<byte, ulong>((LlvmRuntimeValue<byte>) ((LlvmRuntimeValue<byte>) ((operand2) == (0x0))), (ulong) ((ulong) (0x0)), (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))) / ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) (operand2)))));
					}
					return true;
				}
				/* UMADDL */
				if((inst & 0xFFE08000U) == 0x9BA00000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((ra) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) ra]))) + ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) (((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rn) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rn]))))) * ((LlvmRuntimeValue<ulong>) (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<uint>) ((rm) == 31 ? 0U : (LlvmRuntimeValue<uint>) XR[(int) rm])))))))));
					return true;
				}
				/* UMULH */
				if((inst & 0xFFE0FC00U) == 0x9BC07C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					XR[(int) rd] = (LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<ulong>) ((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<ulong>) ((rn) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rn]))))) * ((LlvmRuntimeValue<UInt128>) (LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<UInt128>) ((LlvmRuntimeValue<ulong>) ((rm) == 31 ? 0UL : (LlvmRuntimeValue<ulong>) XR[(int) rm]))))))).ShiftRight(0x40))));
					return true;
				}

			}
			return false;
		}
	}
}