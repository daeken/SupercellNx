using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics;

namespace CorePrecompiler {
	public class Label {
	}
	
	public partial class ScirRecompiler {
		public static readonly ScirRecompiler Instance = new ScirRecompiler();

		ScirRuntimeValue<uint> NZCV_NR, NZCV_ZR, NZCV_CR, NZCV_VR;
		ScirRuntimeValue<ulong> SPR, NZCVR;
		ScirRuntimeValue<ulong>[] XR;
		ScirRuntimeValue<Vector128<float>>[] VR;
		ScirRuntimeValue<byte>[] VBR;
		ScirRuntimeValue<ushort>[] VHR;
		ScirRuntimeValue<float>[] VSR;
		ScirRuntimeValue<double>[] VDR;

		ScirRuntimeValue<byte> Exclusive8R;
		ScirRuntimeValue<ushort> Exclusive16R;
		ScirRuntimeValue<uint> Exclusive32R;
		ScirRuntimeValue<ulong> Exclusive64R;

		ScirRuntimeValue<T> SignExtRuntime<T>(ScirRuntimeValue<ulong> value, int size) where T : struct =>
			throw new NotImplementedException();
		
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
		
		public Label DefineLabel(string name = "") => throw new NotImplementedException();
		public void Label(Label label) => throw new NotImplementedException();
		public void Branch(Label label) => throw new NotImplementedException();
		void Branch(ulong target) => throw new NotImplementedException();
		void BranchLinked(ulong target) => throw new NotImplementedException();
		void BranchRegister(ulong reg) => throw new NotImplementedException();
		void BranchLinkedRegister(ulong reg) => throw new NotImplementedException();
		void BranchIf(ScirRuntimeValue<byte> cond, Label if_label, Label else_label) => throw new NotImplementedException();
		
		public static ScirRuntimeValue<ValueT> Ternary<CondT, ValueT>(ScirRuntimeValue<CondT> cond, ScirRuntimeValue<ValueT> a, ScirRuntimeValue<ValueT> b)
			where CondT : struct where ValueT : struct =>
			throw new NotImplementedException();
		
		ScirRuntimeValue<uint> CallCountLeadingZeros(ScirRuntimeValue<uint> value) =>
			throw new NotImplementedException();
		ScirRuntimeValue<ulong> CallCountLeadingZeros(ScirRuntimeValue<ulong> value) =>
			throw new NotImplementedException();

		ScirRuntimeValue<uint> CallReverseBits(ScirRuntimeValue<uint> value) =>
			throw new NotImplementedException();
		ScirRuntimeValue<ulong> CallReverseBits(ScirRuntimeValue<ulong> value) =>
			throw new NotImplementedException();

		ScirRuntimeValue<ulong> CallSR(uint op0, uint op1, uint crn, uint crm, uint op2) =>
			throw new NotImplementedException();
		void CallSR(uint op0, uint op1, uint crn, uint crm, uint op2, ScirRuntimeValue<ulong> value) =>
			throw new NotImplementedException();

		ScirRuntimeValue<Vector128<float>> CallVectorCountBits(ScirRuntimeValue<Vector128<float>> vec, long elems) =>
			throw new NotImplementedException();

		ScirRuntimeValue<ulong> CallVectorSumUnsigned(ScirRuntimeValue<Vector128<float>> vec, long esize, long count) =>
			throw new NotImplementedException();

		ScirRuntimeValue<Vector128<float>> CallVectorExtract(ScirRuntimeValue<Vector128<float>> a, ScirRuntimeValue<Vector128<float>> b, uint q, uint index) =>
			throw new NotImplementedException();

		ScirRuntimeValue<uint> CallFloatToFixed32(ScirRuntimeValue<float> value, ulong fbits) =>
			throw new NotImplementedException();
		ScirRuntimeValue<uint> CallFloatToFixed32(ScirRuntimeValue<double> value, ulong fbits) =>
			throw new NotImplementedException();
		ScirRuntimeValue<ulong> CallFloatToFixed64(ScirRuntimeValue<float> value, ulong fbits) =>
			throw new NotImplementedException();
		ScirRuntimeValue<ulong> CallFloatToFixed64(ScirRuntimeValue<double> value, ulong fbits) =>
			throw new NotImplementedException();
		
		void CallFloatCompare(ScirRuntimeValue<float> operand1, ScirRuntimeValue<float> operand2) =>
			throw new NotImplementedException();
		void CallFloatCompare(ScirRuntimeValue<double> operand1, ScirRuntimeValue<double> operand2) =>
			throw new NotImplementedException();

		ScirRuntimeValue<byte>
			CallCompareAndSwap<T>(ScirRuntimePointer<T> ptr, ScirRuntimeValue<T> value,
				ScirRuntimeValue<T> comparand) where T : struct => throw new NotImplementedException();
		
		void CallSvc(uint svc) => throw new NotImplementedException();

		public void Emitted() => throw new NotImplementedException();
		
		public void Stmt(Scir stmt) => throw new NotImplementedException();
	}
}