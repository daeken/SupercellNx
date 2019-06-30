using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics;
using Common;
using UltimateOrb;

namespace Cpu64 {
	public abstract partial class BaseCpu {
		public readonly IKernel Kernel;
		public ulong PC, SP;
		public readonly ulong[] X = new ulong[32];
		public Vector128<float>[] V = new Vector128<float>[32];

		public ulong NZCV {
			get => (NZCV_N << 31) | (NZCV_Z << 30) | (NZCV_C << 29) | (NZCV_V << 28);
			set {
				NZCV_N = (value >> 31) & 1;
				NZCV_Z = (value >> 30) & 1;
				NZCV_C = (value >> 29) & 1;
				NZCV_V = (value >> 28) & 1;
			}
		}
		public ulong NZCV_N, NZCV_Z, NZCV_C, NZCV_V;

		public ulong TlsBase;
		
		protected BaseCpu(IKernel kernel) => Kernel = kernel;
		public abstract void Run(ulong pc, ulong sp, bool one = false);

		public unsafe void DebugRegs() {
			"========================".Debug();
			$"NZCV {NZCV_N}{NZCV_Z}{NZCV_C}{NZCV_V}".Debug();
			$"PC == {Kernel.MapAddress(PC)}    SP == 0x{SP:X}".Debug();
			for(var i = 0; i < 31; ++i)
				$"X{i} == {Kernel.MapAddress(X[i])}".Debug();
			"========================".Debug();
		}
		
		public T SignExt<T>(ulong value, int size) {
			if(typeof(T) == typeof(long))
				return (T) (object) ((value & (1UL << (size - 1))) != 0 ? (long) value - (1L << size) : (long) value);
			if(typeof(T) == typeof(int))
				return (T) (object) ((value & (1UL << (size - 1))) != 0 ? (int) value - (1 << size) : (int) value);
			throw new NotImplementedException($"Unknown return for SignExt: {typeof(T)}");
		}

		protected ulong MakeWMask(uint n, uint imms, uint immr, long m, int immediate) =>
			MakeMasks(n, imms, immr, (int) m, immediate != 0).Item1;
		protected ulong MakeTMask(uint n, uint imms, uint immr, long m, int immediate) =>
			MakeMasks(n, imms, immr, (int) m, immediate != 0).Item2;

		int HighestSetBit(ulong v, int bits) {
			for(var i = bits - 1; i >= 0; --i)
				if((v & (1UL << i)) != 0)
					return i;
			return -1;
		}
		ulong ZeroExtend(ulong v, int bits) => v & Ones(bits);
		ulong Ones(int bits) => Enumerable.Range(0, bits).Select(i => 1UL << i).Aggregate((a, b) => a | b);
		ulong Replicate(ulong v, int bits, int start, int rep, int ext) {
			var repval = (v >> start) & Ones(rep);
			var times = ext / rep;
			var val = 0UL;
			for(var i = 0; i < times; ++i)
				val = (val << rep) | repval;
			return v | (val << start);
		}
		ulong RollRight(ulong v, int size, int rotate) => ((v << (size - rotate)) | (v >> rotate)) & Ones(size);
		(ulong, ulong) MakeMasks(uint n, uint imms, uint immr, int m, bool immediate) {
			var len = HighestSetBit((n << 6) | (imms ^ 0b111111U), 7);
			Debug.Assert(len > 0);
			Debug.Assert(m >= 1 << len);

			var levels = ZeroExtend(Ones(len), 6);
			Debug.Assert(!immediate || (imms & levels) != levels);

			var S = imms & levels;
			var R = immr & levels;

			var diff = (S - R) & 0b111111;
			var esize = 1 << len;
			var d = diff & Ones(len);

			var welem = ZeroExtend(Ones((int) (S + 1)), esize);
			var telem = ZeroExtend(Ones((int) (d + 1)), esize);

			var wmask = Replicate(RollRight(welem, esize, (int) R), esize, 0, esize, m);
			var tmask = Replicate(telem, esize, 0, esize, m);
			return (wmask, tmask);
		}

		public uint ReverseBits(uint v) {
			var x = 0U;
			for(var i = 0; i < 32; ++i)
				x |= ((v >> i) & 1) << (31 - i);
			return x;
		}

		public ulong ReverseBits(ulong v) {
			var x = 0UL;
			for(var i = 0; i < 64; ++i)
				x |= ((v >> i) & 1) << (63 - i);
			return x;
		}

		public uint CountLeadingZeros(uint v) {
			for(var i = 0; i < 32; ++i)
				if(((v >> (31 - i)) & 1) == 1)
					return (uint) i;
			return 32;
		}

		public ulong CountLeadingZeros(ulong v) {
			for(var i = 0; i < 64; ++i)
				if(((v >> (63 - i)) & 1) == 1)
					return (uint) i;
			return 64;
		}

		public uint AddWithCarrySetNzcv(uint operand1, uint operand2, uint carryIn) {
			unchecked {
				var usum = operand1 + operand2 + carryIn;
				var ssum = (int) operand1 + (int) operand2 + (int) carryIn;
				var result = usum & 0x7FFFFFFFU;
				var n = result >> 30;
				var z = result == 0 ? 1U : 0;
				var c = (uint) ((((ulong) operand1 + operand2 + carryIn) >> 32) & 1);
				var v = (int) (result << 1) >> 1 == ssum ? 0U : 1;
				NZCV = (n << 31) | (z << 30) | (c << 29) | (v << 28);
				//$"{operand1:X} + {operand2:X} + {carryIn} -> {usum:X} {n}{z}{c}{v}".Debug();
				return usum;
			}
		}

		public ulong AddWithCarrySetNzcv(ulong operand1, ulong operand2, ulong carryIn) {
			unchecked {
				var usum = operand1 + operand2 + carryIn;
				var ssum = (long) operand1 + (long) operand2 + (long) carryIn;
				var result = (usum << 1) >> 1;
				var n = result >> 62;
				var z = result == 0 ? 1U : 0;
				var c = (uint) ((((UInt128) operand1 + operand2 + carryIn) >> 64) & 1);
				var v = (long) (result << 1) >> 1 == ssum ? 0U : 1;
				NZCV = (n << 31) | (z << 30) | (c << 29) | (v << 28);
				//$"{operand1:X} + {operand2:X} + {carryIn} -> {usum:X} {n}{z}{c}{v}".Debug();
				return usum;
			}
		}

		public void FloatCompare(float operand1, float operand2) {
			if(float.IsNaN(operand1) || float.IsNaN(operand2))
				NZCV = 0b0011UL << 28;
			else if(operand1 == operand2)
				NZCV = 0b0110UL << 28;
			else if(operand1 < operand2)
				NZCV = 0b1000UL << 28;
			else
				NZCV = 0b0010UL << 28;
		}
		
		public void FloatCompare(double operand1, double operand2) {
			if(double.IsNaN(operand1) || double.IsNaN(operand2))
				NZCV = 0b0011UL << 28;
			else if(operand1 == operand2)
				NZCV = 0b0110UL << 28;
			else if(operand1 < operand2)
				NZCV = 0b1000UL << 28;
			else
				NZCV = 0b0010UL << 28;
		}
		
		public void Svc(uint svc) => Kernel.Svc((int) svc);

		public ulong SR(uint op0, uint op1, uint crn, uint crm, uint op2) {
			var reg = ((0b10 | op0) << 14) | (op1 << 11) | (crn << 7) | (crm << 3) | op2;
			switch(reg) {
				case 0b11_011_0100_0100_000: // FPCR
					return 0;
				case 0b11_011_0100_0100_001: // FPSR
					return 0;
				case 0b11_011_1101_0000_011: // TPIDR
					return TlsBase;
				case 0b11_011_1110_0000_001: // CntpctEl0
					return 0;
				default:
					throw new NotSupportedException($"Unknown SR: S{op0|2}_{op1}_{crn}_{crm}_{op2}");
			}
		}

		public void SR(uint op0, uint op1, uint crn, uint crm, uint op2, ulong value) {
			var reg = ((0b10 | op0) << 14) | (op1 << 11) | (crn << 7) | (crm << 3) | op2;
			switch(reg) {
				case 0b11_011_0100_0100_000: // FPCR
					break;
				case 0b11_011_0100_0100_001: // FPSR
					break;
				case 0b11_011_1101_0000_010: // TPIDR_EL0
					break;
				default:
					throw new NotSupportedException($"Unknown SR: S{op0|2}_{op1}_{crn}_{crm}_{op2}");
			}
		}

		protected unsafe OutT Bitcast<InT, OutT>(InT value) {
			var ov = Activator.CreateInstance<OutT>();
			switch(value) {
				case uint v:
					switch(ov) {
						case float _: return (OutT) (object) *(float*) &v;
						default: throw new NotImplementedException();
					}
				case ulong v:
					switch(ov) {
						case double _: return (OutT) (object) *(double*) &v;
						default: throw new NotImplementedException();
					}
				case float v:
					switch(ov) {
						case uint _: return (OutT) (object) *(uint*) &v;
						default: throw new NotImplementedException();
					}
				case double v:
					switch(ov) {
						case ulong _: return (OutT) (object) *(ulong*) &v;
						default: throw new NotImplementedException();
					}
				default: throw new NotImplementedException();
			}
		}
	}
}