#pragma warning disable 162, 219
using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using UltimateOrb;
using Common;

namespace Cpu64 {
	public partial class Interpreter : BaseCpu {
		public unsafe bool Interpret(uint inst, ulong pc) {
			unchecked {
				/* ADCS */
				if((inst & 0x7FE0FC00U) == 0x3A000000U) {
					var size = (inst >> 31) & 0x1U;
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) ((byte) (State->NZCV_C)));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) ((byte) (State->NZCV_C)));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
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
						var m = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						if(rd == 31)
							SP = (ulong) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) + ((uint) (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (uint) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm))))));
						else
							W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) + ((uint) (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (uint) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm))))));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (int) (imm)))));
							else
								(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (int) (imm)))));
						} else {
							var m = (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
							if(rd == 31)
								SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x2 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFFFFFF)))), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>((uint) ((uint) (m)), 32)))), _ => m })) << (int) (imm)))));
							else
								(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x2 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFFFFFF)))), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>((uint) ((uint) (m)), 32)))), _ => m })) << (int) (imm)))));
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
							SP = (ulong) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) + ((uint) (uint) (simm))));
						else
							W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) + ((uint) (uint) (simm))));
					} else {
						if(rd == 31)
							SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (simm)));
						else
							(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (simm)));
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
							SP = (ulong) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) + ((uint) (uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? SP : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? SP : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? SP : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? SP : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? SP : W[(int) rm])) >> (int) (imm))) })))));
						else
							W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) + ((uint) (uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? SP : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? SP : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? SP : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? SP : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? SP : W[(int) rm])) >> (int) (imm))) })))));
					} else {
						if(rd == 31)
							SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])) >> (int) (imm))) }))));
						else
							(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? SP : (&State->X0)[(int) rm])) >> (int) (imm))) }))));
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
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? SP : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) (simm));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) (simm));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
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
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) })));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
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
					(&State->X0)[(int) rd] = addr;
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
							SP = (ulong) (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) & ((uint) ((uint) ((uint) (imm)))))));
						else
							W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) & ((uint) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SP = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) & ((ulong) (imm))));
						else
							(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) & ((ulong) (imm))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) & ((uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) }))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) & ((ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))));
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
						var result = (uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) & ((uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) })))));
						W[(int) rd] = (uint) (result);
						State->NZCV_N = (uint) ((result) >> (int) (0x1F));
						State->NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						State->NZCV_C = 0x0;
						State->NZCV_V = 0x0;
					} else {
						var result = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) & ((ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))));
						(&State->X0)[(int) rd] = result;
						State->NZCV_N = (ulong) ((result) >> (int) (0x3F));
						State->NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						State->NZCV_C = 0x0;
						State->NZCV_V = 0x0;
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
						var result = (uint) ((((ulong) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) & ((ulong) (imm))));
						W[(int) rd] = (uint) (result);
						State->NZCV_N = (uint) ((result) >> (int) (0x1F));
						State->NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						State->NZCV_C = 0x0;
						State->NZCV_V = 0x0;
					} else {
						var result = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) & ((ulong) (imm))));
						(&State->X0)[(int) rd] = result;
						State->NZCV_N = (ulong) ((result) >> (int) (0x3F));
						State->NZCV_Z = (byte) (((result) == (0x0)) ? 1U : 0U);
						State->NZCV_C = 0x0;
						State->NZCV_V = 0x0;
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
						W[(int) rd] = (uint) ((uint) ((uint) ((int) (((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))) >> (int) ((ulong) (((ulong) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))) % ((ulong) (long) (0x20))))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])))) >> (int) ((ulong) (((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))) % ((ulong) (long) (0x40)))))));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
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
						var bot = (uint) ((((uint) ((uint) ((((uint) (dst)) & ((uint) ((uint) (~(wmask)))))))) | ((uint) ((uint) ((((uint) ((uint) (((src) << (32 - (int) (immr))) | ((src) >> (int) (immr))))) & ((uint) (wmask))))))));
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((((uint) (dst)) & ((uint) ((uint) (~(tmask)))))))) | ((uint) ((uint) ((((uint) (bot)) & ((uint) (tmask)))))))));
					} else {
						var dst = (ulong) ((rd) == 31 ? 0UL : (&State->X0)[(int) rd]);
						var src = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((((ulong) ((ulong) ((((ulong) (dst)) & ((ulong) ((ulong) (~(wmask)))))))) | ((ulong) ((ulong) ((((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr))))) & ((ulong) (wmask))))))));
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((((ulong) (dst)) & ((ulong) ((ulong) (~(tmask)))))))) | ((ulong) ((ulong) ((((ulong) (bot)) & ((ulong) (tmask))))))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) & ((uint) ((uint) (~((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) }))))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) & ((ulong) ((ulong) (~((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))))));
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
					var v = (Vector128<float>) (Sse.AndNot((Vector128<float>) ((&State->V0)[rm]), (Vector128<float>) ((&State->V0)[rn])));
					if(((byte) (((Q) == (0x1)) ? 1U : 0U)) != 0) {
						(&State->V0)[rd] = v;
					} else {
						(&State->V0)[rd] = (Vector128<float>) (v);
					}
					return true;
				}
				/* BL */
				if((inst & 0xFC000000U) == 0x94000000U) {
					var imm = (inst >> 0) & 0x3FFFFFFU;
					var offset = (long) (SignExt<long>((uint) (((uint) ((uint) (imm))) << (int) (0x2)), 28));
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (offset)));
					(&State->X0)[(int) 0x1E] = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (0x4)));
					Branch(addr);
					return true;
				}
				/* BLR */
				if((inst & 0xFFFFFC1FU) == 0xD63F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					(&State->X0)[(int) 0x1E] = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) (0x4)));
					Branch((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]));
					return true;
				}
				/* BR */
				if((inst & 0xFFFFFC1FU) == 0xD61F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]));
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
						var cl = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
						var ch = (uint) (((ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))) == 31 ? 0U : W[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))]);
						var nl = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
						var nh = (uint) (((ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))) == 31 ? 0U : W[(int) (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))]);
						var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
						var data = (ulong) (*(ulong*) (address));
						if(((byte) (((data) == ((ulong) ((((ulong) ((ulong) (((ulong) ((ulong) (ch))) << (int) (0x20)))) | ((ulong) ((ulong) ((ulong) (cl)))))))) ? 1U : 0U)) != 0) {
							*(ulong*) (address) = (ulong) ((((ulong) ((ulong) (((ulong) ((ulong) (nh))) << (int) (0x20)))) | ((ulong) ((ulong) ((ulong) (nl))))));
						} else {
						}
						W[(int) rs] = (uint) ((uint) ((uint) (data)));
						W[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))] = (uint) ((uint) ((uint) ((ulong) ((data) >> (int) (0x20)))));
					} else {
						var cl = (ulong) ((rs) == 31 ? 0UL : (&State->X0)[(int) rs]);
						var ch = (ulong) (((ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))) == 31 ? 0UL : (&State->X0)[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))]);
						var nl = (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]);
						var nh = (ulong) (((ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))) == 31 ? 0UL : (&State->X0)[(int) (ulong) (((ulong) (byte) (rt)) + ((ulong) (long) (0x1)))]);
						var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
						var dl = (ulong) (*(ulong*) (address));
						var dh = (ulong) (*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))));
						if(((byte) ((((byte) ((byte) (((dl) == (cl)) ? 1U : 0U))) & ((byte) ((byte) (((dh) == (ch)) ? 1U : 0U)))))) != 0) {
							*(ulong*) (address) = nl;
							*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = nh;
						} else {
						}
						(&State->X0)[(int) rs] = dl;
						(&State->X0)[(int) (ulong) (((ulong) (byte) (rs)) + ((ulong) (long) (0x1)))] = dh;
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
						if(((byte) ((((uint) ((rs) == 31 ? 0U : W[(int) rs])) != ((uint) ((uint) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
					} else {
						if(((byte) ((((ulong) ((rs) == 31 ? 0UL : (&State->X0)[(int) rs])) != ((ulong) ((ulong) (0x0)))) ? 1U : 0U)) != 0) {
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
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((uint) ((uint) ((uint) ((imm) << (int) (0x2)))), 21)))));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						if(((byte) ((((uint) ((rs) == 31 ? 0U : W[(int) rs])) == ((uint) ((uint) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
					} else {
						if(((byte) ((((ulong) ((rs) == 31 ? 0UL : (&State->X0)[(int) rs])) == ((ulong) ((ulong) (0x0)))) ? 1U : 0U)) != 0) {
							Branch(addr);
						} else {
							Branch(pc + 4);
						}
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) 0x1F] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) ((uint) (imm))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x0));
									var bits = (int) (32);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (uint) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								})));
						} else {
							(&State->X0)[(int) 0x1F] = (ulong) (Extensions.StmtBlock<ulong>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) ((ulong) (imm))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x0));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								}));
						}
					} else {
						NZCV = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) 0x1F] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((uint) (imm))))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
									var bits = (int) (32);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (uint) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								})));
						} else {
							(&State->X0)[(int) 0x1F] = (ulong) (Extensions.StmtBlock<ulong>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((ulong) (imm))))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								}));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) 0x1F] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((rm) == 31 ? 0U : W[(int) rm])))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
									var bits = (int) (32);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (uint) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								})));
						} else {
							(&State->X0)[(int) 0x1F] = (ulong) (Extensions.StmtBlock<ulong>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								}));
						}
					} else {
						NZCV = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					}
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
						W[(int) rd] = (uint) ((uint) (CountLeadingZeros((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (CountLeadingZeros((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
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
					(&State->V0)[rd] = (Vector128<float>) (VectorCountBits((Vector128<float>) ((&State->V0)[rn]), (long) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => 0x8, _ => 0x10 })));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							(&State->X0)[(int) rd] = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]));
						} else {
							(&State->X0)[(int) rd] = (ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]);
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							(&State->X0)[(int) rd] = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))) + ((uint) (uint) ((uint) ((uint) (0x1))))));
						} else {
							(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))) + ((ulong) (long) (0x1)));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							(&State->X0)[(int) rd] = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) (~((uint) ((rm) == 31 ? 0U : W[(int) rm]))));
						} else {
							(&State->X0)[(int) rd] = (ulong) (~((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]));
						} else {
							(&State->X0)[(int) rd] = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						}
					} else {
						if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
							W[(int) rd] = (uint) ((uint) ((uint) ((int) (-((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))))))));
						} else {
							(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) (-((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))))));
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
					var src = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
					(&State->V0)[rd] = (Vector128<float>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x1))))) == (0x1)) ? 1U : 0U) != 0) ? ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create((byte) ((byte) (src))).As<byte, float>())) : ((Vector128<float>) ((Vector128<float>) (Vector128.Create((byte) ((byte) (src))).As<byte, float>()))))) : ((Vector128<float>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x3))))) == (0x2)) ? 1U : 0U) != 0) ? ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create((ushort) ((ushort) (src))).As<ushort, float>())) : ((Vector128<float>) ((Vector128<float>) (Vector128.Create((ushort) ((ushort) (src))).As<ushort, float>()))))) : ((Vector128<float>) (((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x7))))) == (0x4)) ? 1U : 0U) != 0) ? ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create((uint) ((uint) (src))).As<uint, float>())) : ((Vector128<float>) ((Vector128<float>) (Vector128.Create((uint) ((uint) (src))).As<uint, float>()))))) : ((Vector128<float>) ((Q != 0) ? ((Vector128<float>) (Vector128.Create(src).As<ulong, float>())) : throw new NotImplementedException())))))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) ^ ((uint) ((uint) (~((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) }))))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) ^ ((ulong) ((ulong) (~((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))))));
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
							SP = (ulong) (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) ^ ((uint) ((uint) ((uint) (imm)))))));
						else
							W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) ^ ((uint) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SP = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) ^ ((ulong) (imm))));
						else
							(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) ^ ((ulong) (imm))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) ^ ((uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) }))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) ^ ((ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))));
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
					(&State->V0)[rd] = (Vector128<float>) (VectorExtract((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm]), Q, index));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) (((uint) ((rn) == 31 ? 0U : W[(int) rn])) << (int) ((ulong) (((ulong) (long) (0x20)) - ((ulong) (byte) (lsb))))))) | ((uint) ((uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (lsb)))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) (((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])) << (int) ((ulong) (((ulong) (long) (0x40)) - ((ulong) (byte) (lsb))))))) | ((ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (lsb))))));
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
							(&State->V0)[(int) (rd)] = new Vector128<ushort>().WithElement(0, (ushort) ((ushort) ((ushort) (((ushort) (ushort) ((ushort) ((&State->V0)[rn].As<float, ushort>().GetElement(0)))) + ((ushort) (ushort) ((ushort) ((&State->V0)[rm].As<float, ushort>().GetElement(0)))))))).As<ushort, float>();
							break;
						}
						case 0x0: {
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((float) (float) ((float) ((&State->V0)[rn].GetElement(0)))) + ((float) (float) ((float) ((&State->V0)[rm].GetElement(0))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((double) (double) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))) + ((double) (double) ((double) ((&State->V0)[rm].As<float, double>().GetElement(0)))))).As<double, float>();
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
							(&State->V0)[rd] = (Vector128<float>) ((Vector128<float>) (Sse.Add((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm]))));
							break;
						}
						case 0x1: {
							(&State->V0)[rd] = (Vector128<float>) (Sse.Add((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm])));
							break;
						}
						case 0x3: {
							(&State->V0)[rd] = (Vector128<float>) (Sse2.Add(((Vector128<float>) ((&State->V0)[rn])).As<float, double>(), ((Vector128<float>) ((&State->V0)[rm])).As<float, double>()).As<double, float>());
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
						(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((float) (float) ((float) ((&State->V0)[(int) (rn)].Element<float>(0x0)))) + ((float) (float) ((float) ((&State->V0)[(int) (rn)].Element<float>(0x1))))));
					} else {
						(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((double) (double) ((double) ((&State->V0)[(int) (rn)].Element<double>(0x0)))) + ((double) (double) ((double) ((&State->V0)[(int) (rn)].Element<double>(0x1)))))).As<double, float>();
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
							var a = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var b = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							var c = (float) ((&State->V0)[(int) (rm)].Element<float>(0x0));
							var d = (float) ((&State->V0)[(int) (rm)].Element<float>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((float) ((float) (0x0))).As<float, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((float) (float) (a)) + ((float) (float) (b))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((float) (float) (c)) + ((float) (float) (d))));
							break;
						}
						case 0x1: {
							var a = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var b = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							var c = (float) ((&State->V0)[(int) (rn)].Element<float>(0x2));
							var d = (float) ((&State->V0)[(int) (rn)].Element<float>(0x3));
							var e = (float) ((&State->V0)[(int) (rm)].Element<float>(0x0));
							var f = (float) ((&State->V0)[(int) (rm)].Element<float>(0x1));
							var g = (float) ((&State->V0)[(int) (rm)].Element<float>(0x2));
							var h = (float) ((&State->V0)[(int) (rm)].Element<float>(0x3));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((float) ((float) (0x0))).As<float, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((float) (float) (a)) + ((float) (float) (b))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((float) (float) (c)) + ((float) (float) (d))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x2, (float) (((float) (float) (e)) + ((float) (float) (f))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x3, (float) (((float) (float) (g)) + ((float) (float) (h))));
							break;
						}
						case 0x3: {
							var a = (double) ((&State->V0)[(int) (rn)].Element<double>(0x0));
							var b = (double) ((&State->V0)[(int) (rn)].Element<double>(0x1));
							var c = (double) ((&State->V0)[(int) (rm)].Element<double>(0x0));
							var d = (double) ((&State->V0)[(int) (rm)].Element<double>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((float) ((float) (0x0))).As<float, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (double) (((double) (double) (a)) + ((double) (double) (b))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (double) (((double) (double) (c)) + ((double) (double) (d))));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						switch(type) {
							case 0x0: {
								var __macro_fcmp_a = (float) ((&State->V0)[rn].GetElement(0));
								var __macro_fcmp_b = (float) ((&State->V0)[rm].GetElement(0));
								NZCV = (uint) ((uint) ((long) (((long) (((byte) ((((byte) ((byte) (float.IsNaN(__macro_fcmp_a) ? 1U : 0U))) | ((byte) ((byte) (float.IsNaN(__macro_fcmp_b) ? 1U : 0U))))) != 0) ? (0x3) : ((long) (((byte) (((__macro_fcmp_a) == (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x6) : ((long) (((byte) (((__macro_fcmp_a) < (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x8) : (0x2))))))) << (int) (0x1C))));
								break;
							}
							case 0x1: {
								var __macro_fcmp_a = (double) ((&State->V0)[rn].As<float, double>().GetElement(0));
								var __macro_fcmp_b = (double) ((&State->V0)[rm].As<float, double>().GetElement(0));
								NZCV = (uint) ((uint) ((long) (((long) (((byte) ((((byte) ((byte) (double.IsNaN(__macro_fcmp_a) ? 1U : 0U))) | ((byte) ((byte) (double.IsNaN(__macro_fcmp_b) ? 1U : 0U))))) != 0) ? (0x3) : ((long) (((byte) (((__macro_fcmp_a) == (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x6) : ((long) (((byte) (((__macro_fcmp_a) < (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x8) : (0x2))))))) << (int) (0x1C))));
								break;
							}
							default: {
								throw new NotImplementedException();
								break;
							}
						}
					} else {
						NZCV = (ulong) (((ulong) ((ulong) (nzcv))) << (int) (0x1C));
					}
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
							var a1 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var a2 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							var b1 = (float) ((&State->V0)[(int) (rm)].Element<float>(0x0));
							var b2 = (float) ((&State->V0)[(int) (rm)].Element<float>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (float) (((byte) (((a1) == (b1)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((a1) >= (b1)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x3 => (float) (((byte) ((((float) (MathF.Abs(a1))) >= ((float) (MathF.Abs(b1)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x6 => (float) (((byte) (((a1) > (b1)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x7 => (float) (((byte) ((((float) (MathF.Abs(a1))) > ((float) (MathF.Abs(b1)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => throw new NotImplementedException() }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (float) (((byte) (((a2) == (b2)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((a2) >= (b2)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x3 => (float) (((byte) ((((float) (MathF.Abs(a2))) >= ((float) (MathF.Abs(b2)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x6 => (float) (((byte) (((a2) > (b2)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x7 => (float) (((byte) ((((float) (MathF.Abs(a2))) > ((float) (MathF.Abs(b2)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => throw new NotImplementedException() }));
							break;
						}
						case 0x1: {
							var a1 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var a2 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							var a3 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x2));
							var a4 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x3));
							var b1 = (float) ((&State->V0)[(int) (rm)].Element<float>(0x0));
							var b2 = (float) ((&State->V0)[(int) (rm)].Element<float>(0x1));
							var b3 = (float) ((&State->V0)[(int) (rm)].Element<float>(0x2));
							var b4 = (float) ((&State->V0)[(int) (rm)].Element<float>(0x3));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (float) (((byte) (((a1) == (b1)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((a1) >= (b1)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x3 => (float) (((byte) ((((float) (MathF.Abs(a1))) >= ((float) (MathF.Abs(b1)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x6 => (float) (((byte) (((a1) > (b1)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x7 => (float) (((byte) ((((float) (MathF.Abs(a1))) > ((float) (MathF.Abs(b1)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => throw new NotImplementedException() }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (float) (((byte) (((a2) == (b2)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((a2) >= (b2)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x3 => (float) (((byte) ((((float) (MathF.Abs(a2))) >= ((float) (MathF.Abs(b2)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x6 => (float) (((byte) (((a2) > (b2)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x7 => (float) (((byte) ((((float) (MathF.Abs(a2))) > ((float) (MathF.Abs(b2)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => throw new NotImplementedException() }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x2, (float) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (float) (((byte) (((a3) == (b3)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((a3) >= (b3)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x3 => (float) (((byte) ((((float) (MathF.Abs(a3))) >= ((float) (MathF.Abs(b3)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x6 => (float) (((byte) (((a3) > (b3)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x7 => (float) (((byte) ((((float) (MathF.Abs(a3))) > ((float) (MathF.Abs(b3)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => throw new NotImplementedException() }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x3, (float) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (float) (((byte) (((a4) == (b4)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((a4) >= (b4)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x3 => (float) (((byte) ((((float) (MathF.Abs(a4))) >= ((float) (MathF.Abs(b4)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x6 => (float) (((byte) (((a4) > (b4)) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x7 => (float) (((byte) ((((float) (MathF.Abs(a4))) > ((float) (MathF.Abs(b4)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => throw new NotImplementedException() }));
							break;
						}
						case 0x3: {
							var a1 = (double) ((&State->V0)[(int) (rn)].Element<double>(0x0));
							var a2 = (double) ((&State->V0)[(int) (rn)].Element<double>(0x1));
							var b1 = (double) ((&State->V0)[(int) (rm)].Element<double>(0x0));
							var b2 = (double) ((&State->V0)[(int) (rm)].Element<double>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (double) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (double) (((byte) (((a1) == (b1)) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x2 => (double) (((byte) (((a1) >= (b1)) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x3 => (double) (((byte) ((((double) (Math.Abs(a1))) >= ((double) (Math.Abs(b1)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x6 => (double) (((byte) (((a1) > (b1)) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x7 => (double) (((byte) ((((double) (Math.Abs(a1))) > ((double) (Math.Abs(b1)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), _ => throw new NotImplementedException() }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (double) (((byte) ((byte) (((byte) (byte) (((byte) (((byte) (ac)) << 0)) | ((byte) (((byte) (U)) << 1)))) | ((byte) (((byte) (E)) << 2))))) switch { 0x0 => (double) (((byte) (((a2) == (b2)) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x2 => (double) (((byte) (((a2) >= (b2)) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x3 => (double) (((byte) ((((double) (Math.Abs(a2))) >= ((double) (Math.Abs(b2)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x6 => (double) (((byte) (((a2) > (b2)) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x7 => (double) (((byte) ((((double) (Math.Abs(a2))) > ((double) (Math.Abs(b2)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), _ => throw new NotImplementedException() }));
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
							var v1 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var v2 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (float) (((byte) (((v1) > ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x1 => (float) (((byte) (((v1) >= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((v1) == ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => (float) (((byte) (((v1) <= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))) }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (float) (((byte) (((v2) > ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x1 => (float) (((byte) (((v2) >= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((v2) == ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => (float) (((byte) (((v2) <= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))) }));
							break;
						}
						case 0x1: {
							var v1 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var v2 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							var v3 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x2));
							var v4 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x3));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (float) (((byte) (((v1) > ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x1 => (float) (((byte) (((v1) >= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((v1) == ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => (float) (((byte) (((v1) <= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))) }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (float) (((byte) (((v2) > ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x1 => (float) (((byte) (((v2) >= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((v2) == ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => (float) (((byte) (((v2) <= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))) }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x2, (float) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (float) (((byte) (((v3) > ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x1 => (float) (((byte) (((v3) >= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((v3) == ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => (float) (((byte) (((v3) <= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))) }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x3, (float) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (float) (((byte) (((v4) > ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x1 => (float) (((byte) (((v4) >= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), 0x2 => (float) (((byte) (((v4) == ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))), _ => (float) (((byte) (((v4) <= ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))) }));
							break;
						}
						case 0x3: {
							var v1 = (double) ((&State->V0)[(int) (rn)].Element<double>(0x0));
							var v2 = (double) ((&State->V0)[(int) (rn)].Element<double>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (double) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (double) (((byte) (((v1) > ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x1 => (double) (((byte) (((v1) >= ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x2 => (double) (((byte) (((v1) == ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), _ => (double) (((byte) (((v1) <= ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))) }));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (double) (((byte) ((byte) (((byte) (((byte) (U)) << 0)) | ((byte) (((byte) (op)) << 1))))) switch { 0x0 => (double) (((byte) (((v2) > ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x1 => (double) (((byte) (((v2) >= ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), 0x2 => (double) (((byte) (((v2) == ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))), _ => (double) (((byte) (((v2) <= ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))) }));
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
							var v1 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var v2 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((byte) (((v1) < ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((byte) (((v2) < ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							break;
						}
						case 0x1: {
							var v1 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x0));
							var v2 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x1));
							var v3 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x2));
							var v4 = (float) ((&State->V0)[(int) (rn)].Element<float>(0x3));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (float) (((byte) (((v1) < ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (float) (((byte) (((v2) < ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x2, (float) (((byte) (((v3) < ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x3, (float) (((byte) (((v4) < ((float) ((float) (0x0)))) ? 1U : 0U) != 0) ? ((float) (Bitcast<int, float>((int) ((int) (-0x1))))) : ((float) (Bitcast<int, float>((int) ((int) (0x0)))))));
							break;
						}
						case 0x3: {
							var v1 = (double) ((&State->V0)[(int) (rn)].Element<double>(0x0));
							var v2 = (double) ((&State->V0)[(int) (rn)].Element<double>(0x1));
							(&State->V0)[rd] = (Vector128<float>) (Vector128.Create((int) ((int) (0x0))).As<int, float>());
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x0, (double) (((byte) (((v1) < ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))));
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], 0x1, (double) (((byte) (((v2) < ((double) ((double) (0x0)))) ? 1U : 0U) != 0) ? ((double) (Bitcast<long, double>((long) ((long) (-0x1))))) : ((double) (Bitcast<long, double>((long) ((long) (0x0)))))));
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
							var __macro_fcmp_a = (float) ((&State->V0)[rn].GetElement(0));
							var __macro_fcmp_b = (float) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ((float) ((float) (0x0))) : ((float) ((&State->V0)[rm].GetElement(0))));
							NZCV = (uint) ((uint) ((long) (((long) (((byte) ((((byte) ((byte) (float.IsNaN(__macro_fcmp_a) ? 1U : 0U))) | ((byte) ((byte) (float.IsNaN(__macro_fcmp_b) ? 1U : 0U))))) != 0) ? (0x3) : ((long) (((byte) (((__macro_fcmp_a) == (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x6) : ((long) (((byte) (((__macro_fcmp_a) < (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x8) : (0x2))))))) << (int) (0x1C))));
							break;
						}
						case 0x1: {
							var __macro_fcmp_a = (double) ((&State->V0)[rn].As<float, double>().GetElement(0));
							var __macro_fcmp_b = (double) (((byte) (((opc) == (0x1)) ? 1U : 0U) != 0) ? ((double) ((double) (0x0))) : ((double) ((&State->V0)[rm].As<float, double>().GetElement(0))));
							NZCV = (uint) ((uint) ((long) (((long) (((byte) ((((byte) ((byte) (double.IsNaN(__macro_fcmp_a) ? 1U : 0U))) | ((byte) ((byte) (double.IsNaN(__macro_fcmp_b) ? 1U : 0U))))) != 0) ? (0x3) : ((long) (((byte) (((__macro_fcmp_a) == (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x6) : ((long) (((byte) (((__macro_fcmp_a) < (__macro_fcmp_b)) ? 1U : 0U) != 0) ? (0x8) : (0x2))))))) << (int) (0x1C))));
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
					var result = (byte) (((byte) ((cond) >> (int) (0x1))) switch { 0x0 => (byte) (State->NZCV_Z), 0x1 => (byte) (State->NZCV_C), 0x2 => (byte) (State->NZCV_N), 0x3 => (byte) (State->NZCV_V), 0x4 => (byte) ((((byte) ((byte) (State->NZCV_C))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), 0x5 => (byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U), 0x6 => (byte) ((((byte) ((byte) ((((byte) (State->NZCV_N)) == ((byte) (State->NZCV_V))) ? 1U : 0U))) & ((byte) ((byte) (((byte) (State->NZCV_Z)) != 0 ? 0U : 1U))))), _ => 0x1 });
					if(((byte) (((byte) ((((byte) ((byte) ((((ulong) (cond)) & ((ulong) (0x1)))))) & ((byte) ((byte) (((cond) != (0xF)) ? 1U : 0U))))) != 0) ? ((byte) ((result) != 0 ? 0U : 1U)) : (result))) != 0) {
						switch(type) {
							case 0x0: {
								(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((&State->V0)[rn].GetElement(0)));
								break;
							}
							case 0x1: {
								(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((&State->V0)[rn].As<float, double>().GetElement(0))).As<double, float>();
								break;
							}
							default: {
								throw new NotImplementedException();
								break;
							}
						}
					} else {
						switch(type) {
							case 0x0: {
								(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((&State->V0)[rm].GetElement(0)));
								break;
							}
							case 0x1: {
								(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((&State->V0)[rm].As<float, double>().GetElement(0))).As<double, float>();
								break;
							}
							default: {
								throw new NotImplementedException();
								break;
							}
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((ushort) ((&State->V0)[rn].As<float, ushort>().GetElement(0)))));
							break;
						}
						case 0xD: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((ushort) ((&State->V0)[rn].As<float, ushort>().GetElement(0))))).As<double, float>();
							break;
						}
						case 0x3: {
							(&State->V0)[(int) (rd)] = new Vector128<ushort>().WithElement(0, (ushort) ((ushort) ((float) ((&State->V0)[rn].GetElement(0))))).As<ushort, float>();
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((float) ((&State->V0)[rn].GetElement(0))))).As<double, float>();
							break;
						}
						case 0x7: {
							(&State->V0)[(int) (rd)] = new Vector128<ushort>().WithElement(0, (ushort) ((ushort) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0))))).As<ushort, float>();
							break;
						}
						case 0x4: {
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))));
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
							W[(int) rd] = (uint) ((uint) (FloatToFixed32((float) ((&State->V0)[rn].GetElement(0)), (int) (fbits))));
							break;
						}
						case 0x4: {
							(&State->X0)[(int) rd] = (ulong) (FloatToFixed64((float) ((&State->V0)[rn].GetElement(0)), (int) (fbits)));
							break;
						}
						case 0x1: {
							W[(int) rd] = (uint) ((uint) (FloatToFixed32((double) ((&State->V0)[rn].As<float, double>().GetElement(0)), (int) (fbits))));
							break;
						}
						case 0x5: {
							(&State->X0)[(int) rd] = (ulong) (FloatToFixed64((double) ((&State->V0)[rn].As<float, double>().GetElement(0)), (int) (fbits)));
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
							W[(int) rd] = (uint) ((uint) ((uint) ((int) ((int) ((float) ((&State->V0)[rn].GetElement(0)))))));
							break;
						}
						case 0x4: {
							(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) ((long) ((float) ((&State->V0)[rn].GetElement(0))))));
							break;
						}
						case 0x1: {
							W[(int) rd] = (uint) ((uint) ((uint) ((int) ((int) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))))));
							break;
						}
						case 0x5: {
							(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) ((long) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0))))));
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
							W[(int) rd] = (uint) ((uint) (FloatToFixed32((float) ((&State->V0)[rn].GetElement(0)), (int) (fbits))));
							break;
						}
						case 0x4: {
							(&State->X0)[(int) rd] = (ulong) (FloatToFixed64((float) ((&State->V0)[rn].GetElement(0)), (int) (fbits)));
							break;
						}
						case 0x1: {
							W[(int) rd] = (uint) ((uint) (FloatToFixed32((double) ((&State->V0)[rn].As<float, double>().GetElement(0)), (int) (fbits))));
							break;
						}
						case 0x5: {
							(&State->X0)[(int) rd] = (ulong) (FloatToFixed64((double) ((&State->V0)[rn].As<float, double>().GetElement(0)), (int) (fbits)));
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
							W[(int) rd] = (uint) ((uint) ((uint) ((float) ((&State->V0)[rn].GetElement(0)))));
							break;
						}
						case 0x4: {
							(&State->X0)[(int) rd] = (ulong) ((ulong) ((float) ((&State->V0)[rn].GetElement(0))));
							break;
						}
						case 0x1: {
							W[(int) rd] = (uint) ((uint) ((uint) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))));
							break;
						}
						case 0x5: {
							(&State->X0)[(int) rd] = (ulong) ((ulong) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0))));
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((float) (float) ((float) ((&State->V0)[rn].GetElement(0)))) / ((float) (float) ((float) ((&State->V0)[rm].GetElement(0))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((double) (double) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))) / ((double) (double) ((double) ((&State->V0)[rm].As<float, double>().GetElement(0)))))).As<double, float>();
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
							var a = (float) ((&State->V0)[rn].GetElement(0));
							var b = (float) ((&State->V0)[rm].GetElement(0));
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((byte) (((a) > (b)) ? 1U : 0U) != 0) ? (a) : (b)));
							break;
						}
						case 0x1: {
							var a = (double) ((&State->V0)[rn].As<float, double>().GetElement(0));
							var b = (double) ((&State->V0)[rm].As<float, double>().GetElement(0));
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((byte) (((a) > (b)) ? 1U : 0U) != 0) ? (a) : (b))).As<double, float>();
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
							var a = (float) ((&State->V0)[rn].GetElement(0));
							var b = (float) ((&State->V0)[rm].GetElement(0));
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((byte) (((a) < (b)) ? 1U : 0U) != 0) ? (a) : (b)));
							break;
						}
						case 0x1: {
							var a = (double) ((&State->V0)[rn].As<float, double>().GetElement(0));
							var b = (double) ((&State->V0)[rm].As<float, double>().GetElement(0));
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((byte) (((a) < (b)) ? 1U : 0U) != 0) ? (a) : (b))).As<double, float>();
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
							W[(int) rd] = (uint) ((uint) ((uint) ((ushort) ((&State->V0)[rn].As<float, ushort>().GetElement(0)))));
							break;
						}
						case 0xE6: {
							(&State->X0)[(int) rd] = (ulong) ((ulong) ((ushort) ((&State->V0)[rn].As<float, ushort>().GetElement(0))));
							break;
						}
						case 0x67: {
							(&State->V0)[(int) (rd)] = new Vector128<ushort>().WithElement(0, (ushort) ((ushort) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))).As<ushort, float>();
							break;
						}
						case 0x7: {
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (Bitcast<uint, float>((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
							break;
						}
						case 0x6: {
							W[(int) rd] = (uint) ((uint) (Bitcast<float, uint>((float) ((&State->V0)[rn].GetElement(0)))));
							break;
						}
						case 0xE7: {
							(&State->V0)[(int) (rd)] = new Vector128<ushort>().WithElement(0, (ushort) ((ushort) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])))).As<ushort, float>();
							break;
						}
						case 0xA7: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (Bitcast<ulong, double>((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])))).As<double, float>();
							break;
						}
						case 0xA6: {
							(&State->X0)[(int) rd] = (ulong) (Bitcast<double, ulong>((double) ((&State->V0)[rn].As<float, double>().GetElement(0))));
							break;
						}
						case 0xCE: {
							(&State->X0)[(int) rd] = (ulong) (Bitcast<double, ulong>((double) ((&State->V0)[(byte) ((((ulong) ((byte) ((rn) << (int) (0x1)))) | ((ulong) (0x1))))].As<float, double>().GetElement(0))));
							break;
						}
						case 0xCF: {
							(&State->V0)[(int) ((byte) ((((ulong) ((byte) ((rd) << (int) (0x1)))) | ((ulong) (0x1)))))] = new Vector128<double>().WithElement(0, (double) (Bitcast<ulong, double>((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])))).As<double, float>();
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, sv);
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (Bitcast<ulong, double>((ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((ulong) ((ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (ulong) (((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 1)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 2)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 3)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 4)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 5)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 6)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 7)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 8)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 9)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 10)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 11)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 12)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 13)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 14)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 15)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 16)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 17)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 18)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 19)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 20)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 21)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 22)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 23)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 24)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 25)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 26)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 27)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 28)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 29)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 30)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 31)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 32)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 33)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 34)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 35)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 36)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 37)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 38)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 39)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 40)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 41)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 42)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 43)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 44)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 45)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 46)))) | ((ulong) (((ulong) ((byte) ((byte) (0x0)))) << 47)))))) << 0)) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((((ulong) (imm)) & ((ulong) (0xF)))))))) << 48)))) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x4)))) & ((ulong) (0x3)))))))) << 52)))) | ((ulong) (((ulong) ((byte) ((byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (byte) (((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 0)) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 1)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 2)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 3)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 4)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 5)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 6)))) | ((byte) (((byte) ((byte) ((byte) ((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1)))))))) << 7)))))) << 54)))) | ((ulong) (((ulong) ((byte) (((byte) ((((ulong) ((byte) ((imm) >> (int) (0x6)))) & ((ulong) (0x1))))) != 0 ? 0U : 1U))) << 62)))) | ((ulong) (((ulong) ((byte) ((byte) ((byte) ((imm) >> (int) (0x7)))))) << 63))))))).As<double, float>();
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((float) (float) ((float) ((&State->V0)[rn].GetElement(0)))) * ((float) (float) ((float) ((&State->V0)[rm].GetElement(0))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((double) (double) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))) * ((double) (double) ((double) ((&State->V0)[rm].As<float, double>().GetElement(0)))))).As<double, float>();
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
							(&State->V0)[rd] = (Vector128<float>) ((Vector128<float>) (Sse.Multiply((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm]))));
							break;
						}
						case 0x1: {
							(&State->V0)[rd] = (Vector128<float>) (Sse.Multiply((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm])));
							break;
						}
						case 0x3: {
							(&State->V0)[rd] = (Vector128<float>) (Sse2.Multiply(((Vector128<float>) ((&State->V0)[rn])).As<float, double>(), ((Vector128<float>) ((&State->V0)[rm])).As<float, double>()).As<double, float>());
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (-((float) ((&State->V0)[rn].GetElement(0)))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (-((double) ((&State->V0)[rn].As<float, double>().GetElement(0))))).As<double, float>();
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (-((float) (((float) (float) ((float) ((&State->V0)[rn].GetElement(0)))) * ((float) (float) ((float) ((&State->V0)[rm].GetElement(0))))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (-((double) (((double) (double) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))) * ((double) (double) ((double) ((&State->V0)[rm].As<float, double>().GetElement(0)))))))).As<double, float>();
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
					(&State->V0)[rd] = (Vector128<float>) (((byte) ((byte) (((byte) (((byte) (Q)) << 0)) | ((byte) (((byte) (size)) << 1))))) switch { 0x0 => (Vector128<float>) (VectorFrsqrte((Vector128<float>) ((&State->V0)[rn]), 0x20, 0x2)), 0x1 => (Vector128<float>) (VectorFrsqrte((Vector128<float>) ((&State->V0)[rn]), 0x20, 0x4)), 0x3 => (Vector128<float>) (VectorFrsqrte((Vector128<float>) ((&State->V0)[rn]), 0x40, 0x2)), _ => throw new NotImplementedException() });
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
							(&State->V0)[rd] = (Vector128<float>) ((Vector128<float>) (Sse.Divide((Vector128<float>) (Sse.Subtract((Vector128<float>) (Vector128.Create((float) ((float) (0x3))).As<float, float>()), (Vector128<float>) (Sse.Multiply((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm]))))), (Vector128<float>) (Vector128.Create((float) ((float) (0x2))).As<float, float>()))));
							break;
						}
						case 0x1: {
							(&State->V0)[rd] = (Vector128<float>) (Sse.Divide((Vector128<float>) (Sse.Subtract((Vector128<float>) (Vector128.Create((float) ((float) (0x3))).As<float, float>()), (Vector128<float>) (Sse.Multiply((Vector128<float>) ((&State->V0)[rn]), (Vector128<float>) ((&State->V0)[rm]))))), (Vector128<float>) (Vector128.Create((float) ((float) (0x2))).As<float, float>())));
							break;
						}
						case 0x3: {
							(&State->V0)[rd] = (Vector128<float>) (Sse2.Divide(((Vector128<float>) (Sse2.Subtract(((Vector128<float>) (Vector128.Create((double) ((double) (0x3))).As<double, float>())).As<float, double>(), ((Vector128<float>) (Sse2.Multiply(((Vector128<float>) ((&State->V0)[rn])).As<float, double>(), ((Vector128<float>) ((&State->V0)[rm])).As<float, double>()).As<double, float>())).As<float, double>()).As<double, float>())).As<float, double>(), ((Vector128<float>) (Vector128.Create((double) ((double) (0x2))).As<double, float>())).As<float, double>()).As<double, float>());
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) Math.Sqrt((double) ((float) ((&State->V0)[rn].GetElement(0))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) Math.Sqrt((double) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))))).As<double, float>();
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (((float) (float) ((float) ((&State->V0)[rn].GetElement(0)))) - ((float) (float) ((float) ((&State->V0)[rm].GetElement(0))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (((double) (double) ((double) ((&State->V0)[rn].As<float, double>().GetElement(0)))) - ((double) (double) ((double) ((&State->V0)[rm].As<float, double>().GetElement(0)))))).As<double, float>();
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
						(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index, (byte) ((byte) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index, (ushort) ((ushort) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
								(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index, (float) (Bitcast<uint, float>((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
							} else {
								(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index, (double) (Bitcast<ulong, double>((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))));
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
						(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index1, (byte) ((&State->V0)[(int) (rn)].Element<byte>(index2)));
					} else {
						if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x2))))) == (0x2)) ? 1U : 0U)) != 0) {
							(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index1, (ushort) ((&State->V0)[(int) (rn)].Element<ushort>(index2)));
						} else {
							if(((byte) ((((byte) ((((ulong) (imm5)) & ((ulong) (0x4))))) == (0x4)) ? 1U : 0U)) != 0) {
								(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index1, (float) ((&State->V0)[(int) (rn)].Element<float>(index2)));
							} else {
								(&State->V0)[(int) (rd)] = Insert((&State->V0)[(int) (rd)], index1, (double) ((&State->V0)[(int) (rn)].Element<double>(index2)));
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
						var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
						W[(int) rt] = (uint) ((uint) (*(uint*) (address)));
					} else {
						var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
						(&State->X0)[(int) rt] = (ulong) (*(ulong*) (address));
					}
					return true;
				}
				/* LDARB */
				if((inst & 0xFFFFFC00U) == 0x08DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((byte) (*(byte*) (address))));
					return true;
				}
				/* LDARH */
				if((inst & 0xFFFFFC00U) == 0x48DFFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((ushort) (*(ushort*) (address))));
					return true;
				}
				/* LDAXB */
				if((inst & 0xBFFFFC00U) == 0x885FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) (State->Exclusive32 = *(uint*) (address)));
					} else {
						(&State->X0)[(int) rt] = (ulong) (State->Exclusive64 = *(ulong*) (address));
					}
					return true;
				}
				/* LDAXRB */
				if((inst & 0xFFFFFC00U) == 0x085FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((byte) (State->Exclusive8 = *(byte*) (address))));
					return true;
				}
				/* LDAXRH */
				if((inst & 0xFFFFFC00U) == 0x485FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((ushort) (State->Exclusive16 = *(ushort*) (address))));
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt1] = (uint) ((uint) (*(uint*) (address)));
						W[(int) rt2] = (uint) ((uint) (*(uint*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4))))));
					} else {
						(&State->X0)[(int) rt1] = (ulong) (*(ulong*) (address));
						(&State->X0)[(int) rt2] = (ulong) (*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))));
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (simm)));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt1] = (uint) ((uint) (*(uint*) (address)));
						W[(int) rt2] = (uint) ((uint) (*(uint*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4))))));
					} else {
						(&State->X0)[(int) rt1] = (ulong) (*(ulong*) (address));
						(&State->X0)[(int) rt2] = (ulong) (*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))));
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					switch(opc) {
						case 0x0: {
							(&State->V0)[(int) (rt1)] = new Vector128<float>().WithElement(0, (float) (*(float*) (address)));
							(&State->V0)[(int) (rt2)] = new Vector128<float>().WithElement(0, (float) (*(float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rt1)] = new Vector128<double>().WithElement(0, (double) (*(double*) (address))).As<double, float>();
							(&State->V0)[(int) (rt2)] = new Vector128<double>().WithElement(0, (double) (*(double*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))))).As<double, float>();
							break;
						}
						default: {
							(&State->V0)[rt1] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
							(&State->V0)[rt2] = (Vector128<float>) (Sse.LoadVector128((float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x10))))));
							break;
						}
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (simm)));
					switch(opc) {
						case 0x0: {
							(&State->V0)[(int) (rt1)] = new Vector128<float>().WithElement(0, (float) (*(float*) (address)));
							(&State->V0)[(int) (rt2)] = new Vector128<float>().WithElement(0, (float) (*(float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rt1)] = new Vector128<double>().WithElement(0, (double) (*(double*) (address))).As<double, float>();
							(&State->V0)[(int) (rt2)] = new Vector128<double>().WithElement(0, (double) (*(double*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))))).As<double, float>();
							break;
						}
						default: {
							(&State->V0)[rt1] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
							(&State->V0)[rt2] = (Vector128<float>) (Sse.LoadVector128((float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x10))))));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (simm)));
					(&State->X0)[(int) rt1] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) (address)), 32))));
					(&State->X0)[(int) rt2] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4))))), 32))));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rd] = (uint) ((uint) (*(uint*) (address)));
					} else {
						(&State->X0)[(int) rd] = (ulong) (*(ulong*) (address));
					}
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
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
						W[(int) rd] = (uint) ((uint) (*(uint*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (*(ulong*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])));
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
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
						W[(int) rd] = (uint) ((uint) (*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (*(ulong*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm)))));
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							(&State->V0)[(int) (rt)] = new Vector128<byte>().WithElement(0, (byte) (*(byte*) (address))).As<byte, float>();
							break;
						}
						case 0x2: {
							(&State->V0)[(int) (rt)] = new Vector128<ushort>().WithElement(0, (ushort) (*(ushort*) (address))).As<ushort, float>();
							break;
						}
						case 0x4: {
							(&State->V0)[(int) (rt)] = new Vector128<float>().WithElement(0, (float) (*(float*) (address)));
							break;
						}
						case 0x6: {
							(&State->V0)[(int) (rt)] = new Vector128<double>().WithElement(0, (double) (*(double*) (address))).As<double, float>();
							break;
						}
						case 0x1: {
							(&State->V0)[rt] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
							(&State->V0)[(int) (rt)] = new Vector128<byte>().WithElement(0, (byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (imm)))))).As<byte, float>();
							break;
						}
						case 0x5: {
							(&State->V0)[(int) (rt)] = new Vector128<ushort>().WithElement(0, (ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (imm)))))).As<ushort, float>();
							break;
						}
						case 0x9: {
							(&State->V0)[(int) (rt)] = new Vector128<float>().WithElement(0, (float) (*(float*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (imm))))));
							break;
						}
						case 0xD: {
							(&State->V0)[(int) (rt)] = new Vector128<double>().WithElement(0, (double) (*(double*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (imm)))))).As<double, float>();
							break;
						}
						default: {
							(&State->V0)[rt] = (Vector128<float>) (Sse.LoadVector128((float*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (uint) (imm))))));
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
					var offset = (ulong) (((ulong) ((option) switch { 0x2 => (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))), 0x3 => (ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32)))), 0x7 => (ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]), _ => throw new NotImplementedException() })) << (int) (amount));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)));
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							(&State->V0)[(int) (rt)] = new Vector128<byte>().WithElement(0, (byte) (*(byte*) (address))).As<byte, float>();
							break;
						}
						case 0x4: {
							(&State->V0)[(int) (rt)] = new Vector128<float>().WithElement(0, (float) (*(float*) (address)));
							break;
						}
						case 0x6: {
							(&State->V0)[(int) (rt)] = new Vector128<double>().WithElement(0, (double) (*(double*) (address))).As<double, float>();
							break;
						}
						case 0x1: {
							(&State->V0)[rt] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) (*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))));
					} else {
						(&State->X0)[(int) rt] = (ulong) (*(ulong*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)))));
					}
					return true;
				}
				/* LDRB-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x38400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					W[(int) rt] = (uint) ((uint) ((uint) ((byte) (*(byte*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))))));
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					return true;
				}
				/* LDRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					W[(int) rt] = (uint) ((uint) ((uint) ((byte) (*(byte*) (address)))));
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
					return true;
				}
				/* LDRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39400000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm)))))));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					W[(int) rt] = (uint) ((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))));
					return true;
				}
				/* LDRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78400400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((ushort) (*(ushort*) (address))));
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
					return true;
				}
				/* LDRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78400C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((ushort) (*(ushort*) (address))));
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
					return true;
				}
				/* LDRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79400000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm)))))));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					W[(int) rt] = (uint) ((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))));
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((byte) (*(byte*) (address)), 8)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((byte) (*(byte*) (address)), 8))));
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((byte) (*(byte*) (address)), 8)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((byte) (*(byte*) (address)), 8))));
					}
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
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
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm))))), 8)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm))))), 8))));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))), 8)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))), 8))));
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) (address)), 16)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) (address)), 16))));
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) (address)), 16)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) (address)), 16))));
					}
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
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
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm))))), 16)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm))))), 16))));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					if(((byte) (((opc) == (0x1)) ? 1U : 0U)) != 0) {
						W[(int) rt] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))), 16)))));
					} else {
						(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))), 16))));
					}
					return true;
				}
				/* LDRSW-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0xB8800400U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) (address)), 32))));
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (imm)));
					return true;
				}
				/* LDRSW-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0xB8800C00U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) (address)), 32))));
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
					return true;
				}
				/* LDRSW-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0xB9800000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x2));
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm))))), 32))));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset))))), 32))));
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
						W[(int) rd] = (uint) ((uint) (*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (*(ulong*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)))));
					}
					return true;
				}
				/* LDURB */
				if((inst & 0xFFE00C00U) == 0x38400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					(&State->X0)[(int) rd] = (ulong) ((ulong) ((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)))))));
					return true;
				}
				/* LDURH */
				if((inst & 0xFFE00C00U) == 0x78400000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					(&State->X0)[(int) rd] = (ulong) ((ulong) ((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)))))));
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
						W[(int) rd] = (uint) ((uint) ((uint) ((int) (SignExt<int>((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm))))), 8)))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) (SignExt<long>((byte) (*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm))))), 8))));
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
						W[(int) rd] = (uint) ((uint) ((uint) ((int) (SignExt<int>((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm))))), 16)))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) (SignExt<long>((ushort) (*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm))))), 16))));
					}
					return true;
				}
				/* LDURSW */
				if((inst & 0xFFE00C00U) == 0xB8800000U) {
					var rawimm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (long) (SignExt<long>(rawimm, 9));
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((long) (SignExt<long>((uint) (*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm))))), 32))));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (imm)));
					switch((byte) ((byte) (((byte) (((byte) (opc)) << 0)) | ((byte) (((byte) (size)) << 1))))) {
						case 0x0: {
							(&State->V0)[(int) (rt)] = new Vector128<byte>().WithElement(0, (byte) (*(byte*) (address))).As<byte, float>();
							break;
						}
						case 0x4: {
							(&State->V0)[(int) (rt)] = new Vector128<float>().WithElement(0, (float) (*(float*) (address)));
							break;
						}
						case 0x6: {
							(&State->V0)[(int) (rt)] = new Vector128<double>().WithElement(0, (double) (*(double*) (address))).As<double, float>();
							break;
						}
						case 0x1: {
							(&State->V0)[rt] = (Vector128<float>) (Sse.LoadVector128((float*) (address)));
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
						W[(int) rt] = (uint) ((uint) (State->Exclusive32 = *(uint*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))));
					} else {
						(&State->X0)[(int) rt] = (ulong) (State->Exclusive64 = *(ulong*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])));
					}
					return true;
				}
				/* LDXRB */
				if((inst & 0xFFFFFC00U) == 0x085F7C00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((byte) (State->Exclusive8 = *(byte*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])))));
					return true;
				}
				/* LDXRH */
				if((inst & 0xFFFFFC00U) == 0x485F7C00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rt] = (ulong) ((ulong) ((ushort) (State->Exclusive16 = *(ushort*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])))));
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
						W[(int) rd] = (uint) ((uint) (((uint) ((rn) == 31 ? 0U : W[(int) rn])) << (int) ((ulong) (((ulong) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))) % ((ulong) (long) (0x20))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])) << (int) ((ulong) (((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))) % ((ulong) (long) (0x40)))));
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
						W[(int) rd] = (uint) ((uint) (((uint) ((rn) == 31 ? 0U : W[(int) rn])) >> (int) ((ulong) (((ulong) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))) % ((ulong) (long) (0x20))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])) >> (int) ((ulong) (((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))) % ((ulong) (long) (0x40)))));
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
						W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) * ((uint) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))) + ((uint) (uint) ((uint) ((ra) == 31 ? 0U : W[(int) ra])))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) * ((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))))) + ((ulong) (ulong) ((ulong) ((ra) == 31 ? 0UL : (&State->X0)[(int) ra]))));
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
					var avec = (Vector128<float>) (Vector128.Create((float) (Bitcast<uint, float>((uint) (((uint) ((uint) (imm))) << (int) (amount))))).As<float, float>());
					if((Q) != 0) {
						(&State->V0)[rd] = avec;
					} else {
						(&State->V0)[rd] = (Vector128<float>) (avec);
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
					(&State->V0)[rd] = (Vector128<float>) (Vector128.Create(imm).As<ulong, float>());
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((((uint) ((uint) ((rd) == 31 ? 0U : W[(int) rd]))) & ((uint) ((uint) ((((uint) ((uint) ((uint) (-0x1)))) ^ ((uint) ((uint) (((uint) ((uint) (0xFFFF))) << (int) (shift)))))))))))) | ((uint) ((uint) (((uint) ((uint) (imm))) << (int) (shift)))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((((ulong) ((ulong) ((rd) == 31 ? 0UL : (&State->X0)[(int) rd]))) & ((ulong) ((ulong) ((((ulong) ((ulong) ((ulong) (-0x1)))) ^ ((ulong) ((ulong) (((ulong) ((ulong) (0xFFFF))) << (int) (shift)))))))))))) | ((ulong) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))))));
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
						(&State->X0)[(int) rd] = (ulong) (~((ulong) (((ulong) ((ulong) (imm))) << (int) (shift))));
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
						(&State->X0)[(int) rd] = (ulong) (((ulong) ((ulong) (imm))) << (int) (shift));
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
					(&State->X0)[(int) rt] = (ulong) (SR(op0, op1, cn, cm, op2));
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
					SR(op0, op1, cn, cm, op2, (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]));
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
						W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((ra) == 31 ? 0U : W[(int) ra]))) - ((uint) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) * ((uint) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((ra) == 31 ? 0UL : (&State->X0)[(int) ra]))) - ((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) * ((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) | ((uint) ((uint) (~((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) }))))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) | ((ulong) ((ulong) (~((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))))));
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
							SP = (ulong) (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) | ((uint) ((uint) ((uint) (imm)))))));
						else
							W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) | ((uint) ((uint) ((uint) (imm)))))));
					} else {
						if(rd == 31)
							SP = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) | ((ulong) (imm))));
						else
							(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) | ((ulong) (imm))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) | ((uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) }))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) | ((ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))));
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
						(&State->V0)[rd] = (Vector128<float>) ((&State->V0)[rn]);
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
						W[(int) rd] = (uint) ((uint) (ReverseBits((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (ReverseBits((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
					}
					return true;
				}
				/* RET */
				if((inst & 0xFFFFFC1FU) == 0xD65F0000U) {
					var rn = (inst >> 5) & 0x1FU;
					Branch((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]));
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
							var x = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
							W[(int) rd] = (uint) ((uint) ((((((uint) ((uint) (((uint) ((((ulong) (x)) & ((ulong) (0xFF))))) << (int) (0x18)))) | ((uint) ((uint) (((uint) ((((ulong) ((uint) ((x) >> (int) (0x8)))) & ((ulong) (0xFF))))) << (int) (0x10))))) | ((uint) ((uint) (((uint) ((((ulong) ((uint) ((x) >> (int) (0x10)))) & ((ulong) (0xFF))))) << (int) (0x8))))) | ((uint) ((uint) ((((ulong) ((uint) ((x) >> (int) (0x18)))) & ((ulong) (0xFF)))))))));
							break;
						}
						case 0x3: {
							var x = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
							(&State->X0)[(int) rd] = (ulong) ((((((((((ulong) ((ulong) (((ulong) ((((ulong) (x)) & ((ulong) (0xFF))))) << (int) (0x38)))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x8)))) & ((ulong) (0xFF))))) << (int) (0x30))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x10)))) & ((ulong) (0xFF))))) << (int) (0x28))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x18)))) & ((ulong) (0xFF))))) << (int) (0x20))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x20)))) & ((ulong) (0xFF))))) << (int) (0x18))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x28)))) & ((ulong) (0xFF))))) << (int) (0x10))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x30)))) & ((ulong) (0xFF))))) << (int) (0x8))))) | ((ulong) ((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x38)))) & ((ulong) (0xFF))))))));
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
						var x = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						W[(int) rd] = (uint) ((uint) ((((((uint) ((uint) (((uint) ((((ulong) (x)) & ((ulong) (0xFF))))) << (int) (0x8)))) | ((uint) ((uint) ((((ulong) ((uint) ((x) >> (int) (0x8)))) & ((ulong) (0xFF))))))) | ((uint) ((uint) (((uint) ((((ulong) ((uint) ((x) >> (int) (0x10)))) & ((ulong) (0xFF))))) << (int) (0x18))))) | ((uint) ((uint) (((uint) ((((ulong) ((uint) ((x) >> (int) (0x18)))) & ((ulong) (0xFF))))) << (int) (0x10)))))));
					} else {
						var x = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						(&State->X0)[(int) rd] = (ulong) ((((((((((ulong) ((ulong) (((ulong) ((((ulong) (x)) & ((ulong) (0xFF))))) << (int) (0x8)))) | ((ulong) ((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x8)))) & ((ulong) (0xFF))))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x10)))) & ((ulong) (0xFF))))) << (int) (0x18))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x18)))) & ((ulong) (0xFF))))) << (int) (0x10))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x20)))) & ((ulong) (0xFF))))) << (int) (0x28))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x28)))) & ((ulong) (0xFF))))) << (int) (0x20))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x30)))) & ((ulong) (0xFF))))) << (int) (0x38))))) | ((ulong) ((ulong) (((ulong) ((((ulong) ((ulong) ((x) >> (int) (0x38)))) & ((ulong) (0xFF))))) << (int) (0x30))))));
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
						W[(int) rd] = (uint) ((uint) ((((uint) ((rn) == 31 ? 0U : W[(int) rn])) << (32 - (int) ((ulong) (((ulong) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))) % ((ulong) (long) (0x20)))))) | (((uint) ((rn) == 31 ? 0U : W[(int) rn])) >> (int) ((ulong) (((ulong) (uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm]))) % ((ulong) (long) (0x20)))))));
					} else {
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])) << (64 - (int) ((ulong) (((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))) % ((ulong) (long) (0x40)))))) | (((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])) >> (int) ((ulong) (((ulong) (ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))) % ((ulong) (long) (0x40))))));
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
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((rm) == 31 ? 0U : W[(int) rm])))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) ((byte) (State->NZCV_C)));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) ((byte) (State->NZCV_C)));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
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
						var src = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = (uint) ((((uint) ((uint) (((src) << (32 - (int) (immr))) | ((src) >> (int) (immr))))) & ((uint) (wmask))));
						var top = (uint) (((uint) (uint) ((uint) ((uint) (0x0)))) - ((uint) (uint) ((uint) ((((ulong) ((uint) ((src) >> (int) (imms)))) & ((ulong) (0x1)))))));
						W[(int) rd] = (uint) ((uint) ((((uint) ((uint) ((((uint) (top)) & ((uint) ((uint) (~(tmask)))))))) | ((uint) ((uint) ((((uint) (bot)) & ((uint) (tmask)))))))));
					} else {
						var src = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr))))) & ((ulong) (wmask))));
						var top = (ulong) (((ulong) (ulong) ((ulong) ((ulong) (0x0)))) - ((ulong) (ulong) ((ulong) ((((ulong) ((ulong) ((src) >> (int) (imms)))) & ((ulong) (0x1)))))));
						(&State->X0)[(int) rd] = (ulong) ((((ulong) ((ulong) ((((ulong) (top)) & ((ulong) ((ulong) (~(tmask)))))))) | ((ulong) ((ulong) ((((ulong) (bot)) & ((ulong) (tmask))))))));
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))))).As<double, float>();
							break;
						}
						case 0x4: {
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))))));
							break;
						}
						case 0x5: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])))))).As<double, float>();
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
						(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((int) (Bitcast<float, int>((float) ((&State->V0)[rn].GetElement(0)))))));
					} else {
						(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((long) (Bitcast<double, long>((double) ((&State->V0)[rn].As<float, double>().GetElement(0))))))).As<double, float>();
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
						W[(int) rd] = (uint) ((uint) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((uint) ((uint) (0x0))) : ((uint) ((uint) ((float) (((float) (float) ((float) ((float) ((int) ((int) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))))))) / ((float) (float) ((float) ((float) ((int) ((int) (operand2))))))))))));
					} else {
						var operand2 = (ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]);
						(&State->X0)[(int) rd] = (ulong) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) (0x0))) : ((ulong) ((ulong) ((double) (((double) (double) ((double) ((double) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))))))) / ((double) (double) ((double) ((double) ((long) ((long) (operand2)))))))))));
					}
					return true;
				}
				/* SMADDL */
				if((inst & 0xFFE08000U) == 0x9B200000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) (((long) (long) ((long) ((long) ((ulong) ((ra) == 31 ? 0UL : (&State->X0)[(int) ra]))))) + ((long) (long) ((long) (((long) (long) ((long) (SignExt<long>((uint) ((rn) == 31 ? 0U : W[(int) rn]), 32)))) * ((long) (long) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))))))));
					return true;
				}
				/* SMULH */
				if((inst & 0xFFE0FC00U) == 0x9B407C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rd] = (ulong) ((ulong) ((long) ((long) ((Int128) (((Int128) (((Int128) (Int128) ((Int128) ((Int128) ((long) ((long) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))))))) * ((Int128) (Int128) ((Int128) ((Int128) ((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))))))))) >> (int) (0x40))))));
					return true;
				}
				/* STLR */
				if((inst & 0xBFFFFC00U) == 0x889FFC00U) {
					var size = (inst >> 30) & 0x1U;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])) = (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]);
					}
					return true;
				}
				/* STLRB */
				if((inst & 0xFFFFFC00U) == 0x089FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					*(byte*) (address) = (byte) ((byte) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
					return true;
				}
				/* STLRH */
				if((inst & 0xFFFFFC00U) == 0x489FFC00U) {
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) (address) = (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]);
					}
					W[(int) rs] = (uint) (0x0);
					return true;
				}
				/* STLXRB */
				if((inst & 0xFFE0FC00U) == 0x0800FC00U) {
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					*(byte*) (address) = (byte) ((byte) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
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
					var address = (ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt1) == 31 ? 0U : W[(int) rt1]);
						*(uint*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4)))) = (uint) ((rt2) == 31 ? 0U : W[(int) rt2]);
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : (&State->X0)[(int) rt1]);
						*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = (ulong) ((rt2) == 31 ? 0UL : (&State->X0)[(int) rt2]);
					}
					if(rd == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt1) == 31 ? 0U : W[(int) rt1]);
						*(uint*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4)))) = (uint) ((rt2) == 31 ? 0U : W[(int) rt2]);
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : (&State->X0)[(int) rt1]);
						*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = (ulong) ((rt2) == 31 ? 0UL : (&State->X0)[(int) rt2]);
					}
					if(rd == 31)
						SP = address;
					else
						(&State->X0)[(int) rd] = address;
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rt1) == 31 ? 0U : W[(int) rt1]);
						*(uint*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4)))) = (uint) ((rt2) == 31 ? 0U : W[(int) rt2]);
					} else {
						*(ulong*) (address) = (ulong) ((rt1) == 31 ? 0UL : (&State->X0)[(int) rt1]);
						*(ulong*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = (ulong) ((rt2) == 31 ? 0UL : (&State->X0)[(int) rt2]);
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
					var address = (ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]);
					switch(opc) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt1].GetElement(0));
							*(float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4)))) = (float) ((&State->V0)[rt2].GetElement(0));
							break;
						}
						case 0x1: {
							*(double*) (address) = (double) ((&State->V0)[rt1].As<float, double>().GetElement(0));
							*(double*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = (double) ((&State->V0)[rt2].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt1]));
							Sse.Store((float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x10)))), (Vector128<float>) ((&State->V0)[rt2]));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rd == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					switch(opc) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt1].GetElement(0));
							*(float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4)))) = (float) ((&State->V0)[rt2].GetElement(0));
							break;
						}
						case 0x1: {
							*(double*) (address) = (double) ((&State->V0)[rt1].As<float, double>().GetElement(0));
							*(double*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = (double) ((&State->V0)[rt2].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt1]));
							Sse.Store((float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x10)))), (Vector128<float>) ((&State->V0)[rt2]));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rd == 31)
						SP = address;
					else
						(&State->X0)[(int) rd] = address;
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					switch(opc) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt1].GetElement(0));
							*(float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x4)))) = (float) ((&State->V0)[rt2].GetElement(0));
							break;
						}
						case 0x1: {
							*(double*) (address) = (double) ((&State->V0)[rt1].As<float, double>().GetElement(0));
							*(double*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x8)))) = (double) ((&State->V0)[rt2].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt1]));
							Sse.Store((float*) ((ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (0x10)))), (Vector128<float>) ((&State->V0)[rt2]));
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
					var address = (ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]);
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
					} else {
						*(ulong*) (address) = (ulong) ((rs) == 31 ? 0UL : (&State->X0)[(int) rs]);
					}
					if(rd == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) (address) = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
					} else {
						*(ulong*) (address) = (ulong) ((rs) == 31 ? 0UL : (&State->X0)[(int) rs]);
					}
					if(rd == 31)
						SP = address;
					else
						(&State->X0)[(int) rd] = address;
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
						*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (ulong) (pimm)))) = (uint) ((rs) == 31 ? 0U : W[(int) rs]);
					} else {
						*(ulong*) ((ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (ulong) (pimm)))) = (ulong) ((rs) == 31 ? 0UL : (&State->X0)[(int) rs]);
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					if(((byte) (((size) == (0x0)) ? 1U : 0U)) != 0) {
						*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)))) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)))) = (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]);
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
					var address = (ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]);
					switch(rop) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt].As<float, byte>().GetElement(0));
							break;
						}
						case 0x4: {
							*(ushort*) (address) = (ushort) ((&State->V0)[rt].As<float, ushort>().GetElement(0));
							break;
						}
						case 0x8: {
							*(float*) (address) = (float) ((&State->V0)[rt].GetElement(0));
							break;
						}
						case 0xC: {
							*(double*) (address) = (double) ((&State->V0)[rt].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt]));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rn] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (simm)));
					switch(rop) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt].As<float, byte>().GetElement(0));
							break;
						}
						case 0x4: {
							*(ushort*) (address) = (ushort) ((&State->V0)[rt].As<float, ushort>().GetElement(0));
							break;
						}
						case 0x8: {
							*(float*) (address) = (float) ((&State->V0)[rt].GetElement(0));
							break;
						}
						case 0xC: {
							*(double*) (address) = (double) ((&State->V0)[rt].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt]));
							break;
						}
						default: {
							throw new NotImplementedException();
							break;
						}
					}
					if(rn == 31)
						SP = address;
					else
						(&State->X0)[(int) rn] = address;
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) ((ushort) ((imm) << (int) (scale)))));
					switch(rop) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt].As<float, byte>().GetElement(0));
							break;
						}
						case 0x4: {
							*(ushort*) (address) = (ushort) ((&State->V0)[rt].As<float, ushort>().GetElement(0));
							break;
						}
						case 0x8: {
							*(float*) (address) = (float) ((&State->V0)[rt].GetElement(0));
							break;
						}
						case 0xC: {
							*(double*) (address) = (double) ((&State->V0)[rt].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt]));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)));
					switch(rop) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt].As<float, byte>().GetElement(0));
							break;
						}
						case 0x4: {
							*(ushort*) (address) = (ushort) ((&State->V0)[rt].As<float, ushort>().GetElement(0));
							break;
						}
						case 0x8: {
							*(float*) (address) = (float) ((&State->V0)[rt].GetElement(0));
							break;
						}
						case 0xC: {
							*(double*) (address) = (double) ((&State->V0)[rt].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt]));
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
					var address = (ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]);
					*(byte*) (address) = (byte) ((byte) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					return true;
				}
				/* STRB-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x38000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					*(byte*) (address) = (byte) ((byte) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = address;
					else
						(&State->X0)[(int) rd] = address;
					return true;
				}
				/* STRB-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x39000000U) {
					var imm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm)))) = (byte) ((byte) ((ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt])));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)))) = (byte) ((byte) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
					return true;
				}
				/* STRH-immediate-postindex */
				if((inst & 0xFFE00C00U) == 0x78000400U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]);
					*(ushort*) (address) = (ushort) ((ushort) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					else
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) (address)) + ((ulong) (long) (simm)));
					return true;
				}
				/* STRH-immediate-preindex */
				if((inst & 0xFFE00C00U) == 0x78000C00U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rd = (inst >> 5) & 0x1FU;
					var rs = (inst >> 0) & 0x1FU;
					var simm = (long) (SignExt<long>(imm, 9));
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rd) == 31 ? SP : (&State->X0)[(int) rd]))) + ((ulong) (long) (simm)));
					*(ushort*) (address) = (ushort) ((ushort) ((uint) ((rs) == 31 ? 0U : W[(int) rs])));
					if(rd == 31)
						SP = address;
					else
						(&State->X0)[(int) rd] = address;
					return true;
				}
				/* STRH-immediate-unsigned-offset */
				if((inst & 0xFFC00000U) == 0x79000000U) {
					var rawimm = (inst >> 10) & 0xFFFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var imm = (ushort) ((rawimm) << (int) (0x1));
					*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ushort) (imm)))) = (ushort) ((ushort) ((ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt])));
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
					var offset = (ulong) (((ulong) (((byte) (((option) == (0x6)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) ((long) (SignExt<long>((uint) ((rm) == 31 ? 0U : W[(int) rm]), 32))))) : ((ulong) (((byte) ((((ulong) (option)) & ((ulong) (0x1)))) != 0) ? ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) : ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))) << (int) (amount));
					*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (ulong) (offset)))) = (ushort) ((ushort) ((uint) ((rt) == 31 ? 0U : W[(int) rt])));
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
						*(uint*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (offset)))) = (uint) ((rt) == 31 ? 0U : W[(int) rt]);
					} else {
						*(ulong*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (offset)))) = (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]);
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
					var address = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (simm)));
					switch(rop) {
						case 0x0: {
							*(float*) (address) = (float) ((&State->V0)[rt].As<float, byte>().GetElement(0));
							break;
						}
						case 0x4: {
							*(ushort*) (address) = (ushort) ((&State->V0)[rt].As<float, ushort>().GetElement(0));
							break;
						}
						case 0x8: {
							*(float*) (address) = (float) ((&State->V0)[rt].GetElement(0));
							break;
						}
						case 0xC: {
							*(double*) (address) = (double) ((&State->V0)[rt].As<float, double>().GetElement(0));
							break;
						}
						case 0x2: {
							Sse.Store((float*) (address), (Vector128<float>) ((&State->V0)[rt]));
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
					*(byte*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (offset)))) = (byte) ((byte) ((ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt])));
					return true;
				}
				/* STURH */
				if((inst & 0xFFE00C00U) == 0x78000000U) {
					var imm = (inst >> 12) & 0x1FFU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var offset = (long) (SignExt<long>(imm, 9));
					*(ushort*) ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) + ((ulong) (long) (offset)))) = (ushort) ((ushort) ((ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt])));
					return true;
				}
				/* STXR */
				if((inst & 0xBFE0FC00U) == 0x88007C00U) {
					var size = (inst >> 30) & 0x1U;
					var rs = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rt = (inst >> 0) & 0x1FU;
					var r = (string) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ("W") : ("X"));
					W[(int) rs] = (uint) ((byte) (((byte) (((size) == (0x0)) ? 1U : 0U) != 0) ? ((byte) (CompareAndSwap((uint*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])), (uint) ((rt) == 31 ? 0U : W[(int) rt]), State->Exclusive32))) : ((byte) (CompareAndSwap((ulong*) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])), (ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt]), State->Exclusive64)))));
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
							SP = (ulong) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) - ((uint) (uint) ((uint) (((uint) ((uint) (imm))) << (int) (shift))))));
						else
							W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) - ((uint) (uint) ((uint) (((uint) ((uint) (imm))) << (int) (shift))))));
					} else {
						if(rd == 31)
							SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift)))));
						else
							(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) (((ulong) ((ulong) (imm))) << (int) (shift)))));
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
						var m = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						if(rd == 31)
							SP = (ulong) (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) - ((uint) (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (uint) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm))))));
						else
							W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? SP : W[(int) rn]))) - ((uint) (uint) ((uint) (((uint) ((option) switch { 0x0 => (uint) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (uint) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm))))));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							if(rd == 31)
								SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (int) (imm)))));
							else
								(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (int) (imm)))));
						} else {
							var m = (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
							if(rd == 31)
								SP = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x2 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFFFFFF)))), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm)))));
							else
								(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x2 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFFFFFF)))), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm)))));
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
						W[(int) rd] = (uint) ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) - ((uint) (uint) ((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) })))));
					} else {
						(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) - ((ulong) (ulong) ((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) }))));
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
						var m = (uint) ((rm) == 31 ? 0U : W[(int) rm]);
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? SP : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) (((uint) ((option) switch { 0x0 => (uint) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (uint) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x4 => (uint) ((uint) ((int) (SignExt<int>((byte) ((byte) (m)), 8)))), 0x5 => (uint) ((uint) ((int) (SignExt<int>((ushort) ((ushort) (m)), 16)))), _ => m })) << (int) (imm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						if(((byte) ((((byte) ((((ulong) (option)) & ((ulong) (0x3))))) == (0x3)) ? 1U : 0U)) != 0) {
							(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (int) (imm))))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
								}));
						} else {
							var m = (ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])));
							(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
									var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? SP : (&State->X0)[(int) rn])));
									var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) (((ulong) ((option) switch { 0x0 => (ulong) ((((ulong) (m)) & ((ulong) (0xFF)))), 0x1 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFF)))), 0x2 => (ulong) ((((ulong) (m)) & ((ulong) (0xFFFFFFFF)))), 0x4 => (ulong) ((ulong) ((long) (SignExt<long>((byte) ((byte) (m)), 8)))), 0x5 => (ulong) ((ulong) ((long) (SignExt<long>((ushort) ((ushort) (m)), 16)))), 0x6 => (ulong) ((ulong) ((long) (SignExt<long>(m, 64)))), _ => m })) << (int) (imm))))));
									var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
									var bits = (int) (64);
									var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
									var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
									var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
									State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
									State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
									State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
									State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
									return usum;
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
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((shift) switch { 0x0 => (uint) (((uint) ((uint) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) << (int) (imm)), 0x1 => (uint) (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm)), 0x2 => (uint) ((uint) ((int) (((int) ((int) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))) >> (int) (imm)))), _ => (uint) ((((uint) ((rm) == 31 ? 0U : W[(int) rm])) << (32 - (int) (imm))) | (((uint) ((rm) == 31 ? 0U : W[(int) rm])) >> (int) (imm))) })))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((shift) switch { 0x0 => (ulong) (((ulong) ((ulong) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) << (int) (imm)), 0x1 => (ulong) (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm)), 0x2 => (ulong) ((ulong) ((long) (((long) ((long) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])))) >> (int) (imm)))), _ => (ulong) ((((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) << (64 - (int) (imm))) | (((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm])) >> (int) (imm))) })))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
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
						W[(int) rd] = (uint) ((uint) (Extensions.StmtBlock<uint>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (uint) ((uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (uint) ((uint) ((uint) (~((uint) ((uint) (rimm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (uint) ((uint) (0x1));
								var bits = (int) (32);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (uint) (((uint) (uint) ((uint) (((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((uint) (uint) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (int) (((int) (int) ((int) (((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((int) (int) ((int) ((int) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (uint) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((ulong) (((ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((ulong) (ulong) ((ulong) ((ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((uint) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((uint) ((usum) >> (int) (bits1))) != ((uint) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							})));
					} else {
						(&State->X0)[(int) rd] = (ulong) (Extensions.StmtBlock<ulong>(() => {
								var __macro_add_with_carry_set_nzcv_common_operand1 = (ulong) ((ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])));
								var __macro_add_with_carry_set_nzcv_common_operand2 = (ulong) ((ulong) ((ulong) (~((ulong) ((ulong) (rimm))))));
								var __macro_add_with_carry_set_nzcv_common_carryIn = (ulong) ((ulong) (0x1));
								var bits = (int) (64);
								var bits1 = (long) (((long) (int) (bits)) - ((long) (long) (0x1)));
								var usum = (ulong) (((ulong) (ulong) ((ulong) (((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand1)) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_operand2))))) + ((ulong) (ulong) (__macro_add_with_carry_set_nzcv_common_carryIn)));
								var ssum = (long) (((long) (long) ((long) (((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((long) (long) ((long) ((long) (__macro_add_with_carry_set_nzcv_common_carryIn)))));
								State->NZCV_N = (ulong) ((usum) >> (int) (bits1));
								State->NZCV_Z = (byte) (((usum) == (0x0)) ? 1U : 0U);
								State->NZCV_C = (uint) ((((ulong) ((uint) ((uint) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand1)))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_operand2))))))) + ((UInt128) (UInt128) ((UInt128) ((UInt128) (__macro_add_with_carry_set_nzcv_common_carryIn)))))) >> (int) (bits)))))) & ((ulong) (0x1))));
								State->NZCV_V = (byte) ((((byte) ((byte) ((((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1))) == ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand2) >> (int) (bits1)))) ? 1U : 0U))) & ((byte) ((byte) ((((ulong) ((usum) >> (int) (bits1))) != ((ulong) ((__macro_add_with_carry_set_nzcv_common_operand1) >> (int) (bits1)))) ? 1U : 0U)))));
								return usum;
							}));
					}
					return true;
				}
				/* SVC */
				if((inst & 0xFFE0001FU) == 0xD4000001U) {
					var imm = (inst >> 5) & 0xFFFFU;
					Svc(imm);
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
					if(((byte) ((((ulong) ((((ulong) ((ulong) (((ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt])) >> (int) (imm)))) & ((ulong) (0x1))))) == (0x0)) ? 1U : 0U)) != 0) {
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
					var imm = (byte) ((((byte) ((byte) ((upper) << (int) (0x5)))) | ((byte) (bottom))));
					var addr = (ulong) (((ulong) (ulong) ((ulong) (pc))) + ((ulong) (long) ((long) (SignExt<long>((ushort) (((ushort) ((ushort) (offset))) << (int) (0x2)), 16)))));
					if(((byte) ((((ulong) ((((ulong) ((ulong) (((ulong) ((rt) == 31 ? 0UL : (&State->X0)[(int) rt])) >> (int) (imm)))) & ((ulong) (0x1))))) != (0x0)) ? 1U : 0U)) != 0) {
						Branch(addr);
					} else {
						Branch(pc + 4);
					}
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
							(&State->V0)[(int) (rd)] = new Vector128<ushort>().WithElement(0, (ushort) ((ushort) ((uint) (VectorSumUnsigned((Vector128<float>) ((&State->V0)[rn]), esize, count))))).As<ushort, float>();
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) (Bitcast<uint, float>((uint) (VectorSumUnsigned((Vector128<float>) ((&State->V0)[rn]), esize, count)))));
							break;
						}
						case 0x2: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) (Bitcast<ulong, double>((ulong) ((ulong) ((uint) (VectorSumUnsigned((Vector128<float>) ((&State->V0)[rn]), esize, count))))))).As<double, float>();
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
						var src = (uint) ((rn) == 31 ? 0U : W[(int) rn]);
						var wmask = (uint) ((uint) ((ulong) (MakeWMask(N, imms, immr, 0x20, 0x0))));
						var tmask = (uint) ((uint) ((ulong) (MakeTMask(N, imms, immr, 0x20, 0x0))));
						var bot = (uint) ((((uint) ((uint) (((src) << (32 - (int) (immr))) | ((src) >> (int) (immr))))) & ((uint) (wmask))));
						W[(int) rd] = (uint) ((uint) ((((uint) (bot)) & ((uint) (tmask)))));
					} else {
						var src = (ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]);
						var wmask = (ulong) (MakeWMask(N, imms, immr, 0x40, 0x0));
						var tmask = (ulong) (MakeTMask(N, imms, immr, 0x40, 0x0));
						var bot = (ulong) ((((ulong) ((ulong) (((src) << (64 - (int) (immr))) | ((src) >> (int) (immr))))) & ((ulong) (wmask))));
						(&State->X0)[(int) rd] = (ulong) ((((ulong) (bot)) & ((ulong) (tmask))));
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
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))));
							break;
						}
						case 0x1: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((uint) ((rn) == 31 ? 0U : W[(int) rn])))).As<double, float>();
							break;
						}
						case 0x4: {
							(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))));
							break;
						}
						case 0x5: {
							(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn])))).As<double, float>();
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
						(&State->V0)[(int) (rd)] = new Vector128<float>().WithElement(0, (float) ((float) ((uint) (Bitcast<float, uint>((float) ((&State->V0)[rn].GetElement(0)))))));
					} else {
						(&State->V0)[(int) (rd)] = new Vector128<double>().WithElement(0, (double) ((double) ((ulong) (Bitcast<double, ulong>((double) ((&State->V0)[rn].As<float, double>().GetElement(0))))))).As<double, float>();
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
						W[(int) rd] = (uint) ((uint) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((uint) ((uint) (0x0))) : ((uint) (((uint) (uint) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))) / ((uint) (uint) (operand2))))));
					} else {
						var operand2 = (ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]);
						(&State->X0)[(int) rd] = (ulong) (((byte) (((operand2) == (0x0)) ? 1U : 0U) != 0) ? ((ulong) ((ulong) (0x0))) : ((ulong) (((ulong) (ulong) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))) / ((ulong) (ulong) (operand2)))));
					}
					return true;
				}
				/* UMADDL */
				if((inst & 0xFFE08000U) == 0x9BA00000U) {
					var rm = (inst >> 16) & 0x1FU;
					var ra = (inst >> 10) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rd] = (ulong) (((ulong) (ulong) ((ulong) ((ra) == 31 ? 0UL : (&State->X0)[(int) ra]))) + ((ulong) (ulong) ((ulong) (((ulong) (ulong) ((ulong) ((ulong) ((uint) ((rn) == 31 ? 0U : W[(int) rn]))))) * ((ulong) (ulong) ((ulong) ((ulong) ((uint) ((rm) == 31 ? 0U : W[(int) rm])))))))));
					return true;
				}
				/* UMULH */
				if((inst & 0xFFE0FC00U) == 0x9BC07C00U) {
					var rm = (inst >> 16) & 0x1FU;
					var rn = (inst >> 5) & 0x1FU;
					var rd = (inst >> 0) & 0x1FU;
					(&State->X0)[(int) rd] = (ulong) ((ulong) ((UInt128) (((UInt128) (((UInt128) (UInt128) ((UInt128) ((UInt128) ((ulong) ((rn) == 31 ? 0UL : (&State->X0)[(int) rn]))))) * ((UInt128) (UInt128) ((UInt128) ((UInt128) ((ulong) ((rm) == 31 ? 0UL : (&State->X0)[(int) rm]))))))) >> (int) (0x40))));
					return true;
				}

			}
			return false;
		}

	}
}