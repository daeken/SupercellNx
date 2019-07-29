using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using Common;
using UltimateOrb;

namespace Cpu64 {
	public abstract unsafe partial class BaseCpu {
		public readonly IKernel Kernel;
		public CpuState* State;
		public Block BranchToBlock;

		public ulong NZCV {
			get => (State->NZCV_N << 31) | (State->NZCV_Z << 30) | (State->NZCV_C << 29) | (State->NZCV_V << 28);
			set {
				State->NZCV_N = (uint) (value >> 31) & 1;
				State->NZCV_Z = (uint) (value >> 30) & 1;
				State->NZCV_C = (uint) (value >> 29) & 1;
				State->NZCV_V = (uint) (value >> 28) & 1;
			}
		}

		protected BaseCpu(IKernel kernel) {
			Kernel = kernel;
			State = (CpuState*) Marshal.AllocHGlobal(Marshal.SizeOf<CpuState>());
			*State = new CpuState();
		}

		public abstract void Run(ulong pc, ulong sp, bool one = false);

		public void Log(string message) => Kernel.Log(message);
		public void LogError(string message) =>
			Kernel.LogExclusive(() => {
				Kernel.Log(message);
				Environment.Exit(1);
			});

		public void DebugRegs() {
			Kernel.LogExclusive(() => {
				Log("========================");
				Log($"NZCV {State->NZCV_N}{State->NZCV_Z}{State->NZCV_C}{State->NZCV_V}");
				Log($"PC == {Kernel.MapAddress(State->PC)}    SP == 0x{State->SP:X}");
				for(var i = 0; i < 31; ++i)
					Log($"X{i} == {Kernel.MapAddress((&State->X0)[i])}");
				Log("========================");
			});
		}
		
		public static T SignExt<T>(ulong value, int size) {
			if(typeof(T) == typeof(long))
				return (T) (object) ((value & (1UL << (size - 1))) != 0 ? (long) value - (1L << size) : (long) value);
			if(typeof(T) == typeof(int))
				return (T) (object) ((value & (1UL << (size - 1))) != 0 ? (int) value - (1 << size) : (int) value);
			throw new NotImplementedException($"Unknown return for SignExt: {typeof(T)}");
		}

		protected static ulong MakeWMask(uint n, uint imms, uint immr, long m, int immediate) =>
			MakeMasks(n, imms, immr, (int) m, immediate != 0).Item1;
		protected static ulong MakeTMask(uint n, uint imms, uint immr, long m, int immediate) =>
			MakeMasks(n, imms, immr, (int) m, immediate != 0).Item2;

		static int HighestSetBit(ulong v, int bits) {
			for(var i = bits - 1; i >= 0; --i)
				if((v & (1UL << i)) != 0)
					return i;
			return -1;
		}
		static ulong ZeroExtend(ulong v, int bits) => v & Ones(bits);
		static ulong Ones(int bits) => Enumerable.Range(0, bits).Select(i => 1UL << i).Aggregate((a, b) => a | b);
		static ulong Replicate(ulong v, int bits, int start, int rep, int ext) {
			var repval = (v >> start) & Ones(rep);
			var times = ext / rep;
			var val = 0UL;
			for(var i = 0; i < times; ++i)
				val = (val << rep) | repval;
			return v | (val << start);
		}
		static ulong RollRight(ulong v, int size, int rotate) => ((v << (size - rotate)) | (v >> rotate)) & Ones(size);
		static (ulong, ulong) MakeMasks(uint n, uint imms, uint immr, int m, bool immediate) {
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

		public static uint ReverseBits(uint v) {
			var x = 0U;
			for(var i = 0; i < 32; ++i)
				x |= ((v >> i) & 1) << (31 - i);
			return x;
		}

		public static ulong ReverseBits(ulong v) {
			var x = 0UL;
			for(var i = 0; i < 64; ++i)
				x |= ((v >> i) & 1) << (63 - i);
			return x;
		}

		public static uint CountLeadingZeros(uint v) {
			for(var i = 0; i < 32; ++i)
				if(((v >> (31 - i)) & 1) == 1)
					return (uint) i;
			return 32;
		}

		public static ulong CountLeadingZeros(ulong v) {
			for(var i = 0; i < 64; ++i)
				if(((v >> (63 - i)) & 1) == 1)
					return (uint) i;
			return 64;
		}

		public void Svc(uint svc) => Kernel.Svc((int) svc);

		public ulong SR(uint op0, uint op1, uint crn, uint crm, uint op2) {
			var reg = ((0b10 | op0) << 14) | (op1 << 11) | (crn << 7) | (crm << 3) | op2;
			switch(reg) {
				case 0b11_011_0000_0000_001: // CtrEl0
					return 0x8444c004;
				case 0b11_011_0100_0100_000: // FPCR
					return 0;
				case 0b11_011_0100_0100_001: // FPSR
					return 0;
				case 0b11_011_1101_0000_011: // TPIDR
					return State->TlsBase;
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

		protected static unsafe OutT Bitcast<InT, OutT>(InT value) {
			var ov = Activator.CreateInstance<OutT>();
			switch(value) {
				case int v:
					switch(ov) {
						case float _: return (OutT) (object) *(float*) &v;
						default: throw new NotImplementedException();
					}
				case uint v:
					switch(ov) {
						case float _: return (OutT) (object) *(float*) &v;
						default: throw new NotImplementedException();
					}
				case long v:
					switch(ov) {
						case double _: return (OutT) (object) *(double*) &v;
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
						case int _: return (OutT) (object) *(int*) &v;
						default: throw new NotImplementedException();
					}
				case double v:
					switch(ov) {
						case ulong _: return (OutT) (object) *(ulong*) &v;
						case long _: return (OutT) (object) *(long*) &v;
						default: throw new NotImplementedException();
					}
				default: throw new NotImplementedException();
			}
		}

		protected static Vector128<float> Insert<ElementT>(Vector128<float> vec, uint index, ElementT value)
			where ElementT : struct => vec.As<float, ElementT>().WithElement((int) index, value).As<ElementT, float>();

		public static Vector128<float> VectorCountBits(Vector128<float> vec, long elems) {
			var ret = Vector128<byte>.Zero;
			var ivec = vec.As<float, byte>();
			for(var i = 0; i < elems; ++i)
				ret = ret.WithElement(i, (byte) Popcnt.PopCount(ivec.GetElement(i)));
			return ret.As<byte, float>();
		}

		public static ulong VectorSumUnsigned(Vector128<float> vec, long esize, long count) {
			switch(esize) {
				case 8: {
					var bvec = vec.As<float, byte>();
					var sum = 0UL;
					for(var i = 0; i < count; ++i)
						sum += bvec.GetElement(i);
					return sum;
				}
				default: throw new NotSupportedException($"Unknown size for VectorSumUnsigned: {esize}");
			}
		}

		public static Vector128<float> VectorExtract(Vector128<float> _a, Vector128<float> _b, uint Q, uint _index) {
			var index = (int) _index;
			var a = _a.As<float, byte>();
			var b = _b.As<float, byte>();
			
			var r = new Vector128<byte>();
			var count = Q == 0 ? 8 : 16;

			if(count == 8) {
				for(var i = index; i < 8; ++i)
					r = r.WithElement(i - index, a.GetElement(i));
				var offset = 8 - index;
				for(var i = offset; i < 8; ++i)
					r = r.WithElement(i, a.GetElement(i - offset));
			} else {
				for(var i = index; i < 16; ++i)
					r = r.WithElement(i - index, a.GetElement(i));
				var offset = 16 - index;
				for(var i = offset; i < 16; ++i)
					r = r.WithElement(i, a.GetElement(i - offset));
			}
			
			return r.As<byte, float>();
		}

		public static Vector128<float> VectorFrsqrte(Vector128<float> input, int bits, int elements) {
			if(bits == 64) {
				var vec = input.As<float, double>();
				vec = vec.WithElement(0, FastInvsqrt(vec.GetElement(0)));
				vec = vec.WithElement(1, FastInvsqrt(vec.GetElement(1)));
				return vec.As<double, float>();
			}
			for(var i = 0; i < elements; ++i)
				input = input.WithElement(i, FastInvsqrt(input.GetElement(i)));
			return input;
		}

		public static float FastInvsqrt(float number) {
			var i = *(uint*) &number;
			i = 0x5f3759df - (i >> 1);
			var f = *(float*) &i;
			f *= 1.5f - 0.5f * f * f;
			return f;
		}

		public static double FastInvsqrt(double number) {
			var x2 = number * 0.5;
			var i = *(long*) &number;
			i = 0x5fe6eb50c7b537a9 - (i >> 1);
			var y = *(double*) &i;
			y *= 1.5 - x2 * y * y;
			return y;
		}
		
		public static uint FloatToFixed32(float fvalue, int fbits) {
			return unchecked((uint) (int) MathF.Round(fvalue * (1 << fbits)));
		}

		public static ulong FloatToFixed64(float fvalue, int fbits) {
			return unchecked((ulong) (long) MathF.Round(fvalue * (1 << fbits)));
		}

		public static uint FloatToFixed32(double fvalue, int fbits) {
			return unchecked((uint) (int) Math.Round(fvalue * (1 << fbits)));
		}

		public static ulong FloatToFixed64(double fvalue, int fbits) {
			return unchecked((ulong) (long) Math.Round(fvalue * (1 << fbits)));
		}

		public static unsafe byte CompareAndSwap(uint* ptr, uint value, uint comparand) =>
			unchecked(Interlocked.CompareExchange(ref *(int*) ptr, (int) value, (int) comparand) == (int) comparand ? (byte) 0 : (byte) 1);

		public static unsafe byte CompareAndSwap(ulong* ptr, ulong value, ulong comparand) =>
			unchecked(Interlocked.CompareExchange(ref *(long*) ptr, (long) value, (long) comparand) == (long) comparand ? (byte) 0 : (byte) 1);
	}
}