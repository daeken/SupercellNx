using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using PrettyPrinter;

namespace Generator {
	public class BuiltinTypes {
		static EType TypeFromName(PTree expr) {
			if(!(expr is PName name)) throw new NotSupportedException($"Attempted to make type from expr {expr.ToPrettyString()}");

			var ns = name.Name;
			if(ns[0] == 'f') return new EFloat(int.Parse(ns.Substring(1)));
			if(ns == "vec") return EType.Vector;
			return ns[0] == 'i' ? new EInt(true, int.Parse(ns.Substring(1))) : new EInt(false, int.Parse(ns.Substring(1)));
		}

		static EType LogicalType(EType a, EType b) {
			if(a is EInt || b is EInt) {
				if(!(a is EInt ai)) throw new NotSupportedException("Logical expression contains lhs that is non-int");
				if(!(b is EInt bi)) throw new NotSupportedException("Logical expression contains rhs that is non-int");
				return new EInt(
					ai.Signed == bi.Signed && ai.Signed,
					Math.Max(ai.Width, bi.Width)
				) { Runtime = ai.Runtime || bi.Runtime };
			}
			if(a is EFloat || b is EFloat) {
				if(!(a is EFloat af)) throw new NotSupportedException("Logical expression contains lhs that is non-float");
				if(!(b is EFloat bf)) throw new NotSupportedException("Logical expression contains rhs that is non-float");
				return new EFloat(Math.Max(af.Width, bf.Width)) { Runtime = af.Runtime || bf.Runtime };
			}
			throw new NotImplementedException("Logical expression has non-int/non-float type");
		}
		
		public static readonly IReadOnlyDictionary<string, Func<PList, EType>> Builtins = new Dictionary<string, Func<PList, EType>> {
			["unimplemented"] = _ => EType.Unit, 
			["pc"] = _ => new EInt(false, 64), 
			["nzcv"] = _ => new EInt(false, 1).AsRuntime(), 
			["branch"] = _ => EType.Unit.AsRuntime(), 
			["branch-default"] = _ => EType.Unit.AsRuntime(), 
			["store"] = _ => EType.Unit.AsRuntime(), 
			["store-exclusive"] = _ => new EInt(false, 1).AsRuntime(), 
			["load"] = x => TypeFromName(x[2]).AsRuntime(),
			["load-exclusive"] = x => TypeFromName(x[2]).AsRuntime(),
			
			["svc"] = _ => EType.Unit.AsRuntime(),
			["sr"] = _ => new EInt(false, 64).AsRuntime(),

			["make-wmask"] = _ => new EInt(false, 64), 
			["make-tmask"] = _ => new EInt(false, 64), 
			["signext"] = x => TypeFromName(x[2]).AsRuntime(x[1].Type.Runtime), 
			["cast"] = x => TypeFromName(x[2]).AsRuntime(x[1].Type.Runtime), 
			["bitcast"] = x => TypeFromName(x[2]).AsRuntime(x[1].Type.Runtime), 
			["gpr32"] = _ => new EInt(false, 32).AsRuntime(), 
			["gpr-or-sp32"] = _ => new EInt(false, 32).AsRuntime(), 
			["gpr64"] = _ => new EInt(false, 64).AsRuntime(), 
			["gpr-or-sp64"] = _ => new EInt(false, 64).AsRuntime(), 
			["="] = x => x[2].Type ?? throw new NotImplementedException(), 
			["=="] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["!="] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			[">"] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["<"] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["+"] = x => LogicalType(x[1].Type, x[2].Type), 
			["add-with-carry-set-nzcv"] = x => x[1].Type, 
			["fcmp"] = _ => EType.Unit, 
			["-"] = x => LogicalType(x[1].Type, x[2].Type), 
			["-!"] = x => x[1].Type, 
			["*"] = x => LogicalType(x[1].Type, x[2].Type), 
			["/"] = x => LogicalType(x[1].Type, x[2].Type), 
			["sqrt"] = x => x[1].Type, 
			["~"] = x => x[1].Type, 
			["!"] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime), 
			["|"] = x => x[1].Type.AsRuntime(x.Skip(1).Any(y => y.Type.Runtime)), 
			["&"] = x => x[1].Type.AsRuntime(x.Skip(1).Any(y => y.Type.Runtime)), 
			["^"] = x => x[1].Type.AsRuntime(x.Skip(1).Any(y => y.Type.Runtime)), 
			["<<"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			[">>"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			[">>>"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime),
			[":"] = x =>
				new EInt(false,
					x.Skip(1).Select(y => y.Type is EInt(_, var width) ? width : throw new NotSupportedException())
						.Sum()).AsRuntime(x.Skip(1).Any(y => y.Type.Runtime)),
			["replicate"] = x => new EInt(false,
				x[1].Type is EInt(_, var elemWidth) && x[2] is PInt(var count)
					? elemWidth * (int) count
					: throw new NotSupportedException()).AsRuntime(x[1].Type.Runtime),
			["shift"] = x => x[1].Type, 
			["count-leading-zeros"] = x => x[1].Type, 
			["reverse-bits"] = x => x[1].Type, 
			["vec"] = _ => EType.Vector.AsRuntime(), 
			["vec-b"] = _ => new EFloat(8).AsRuntime(), 
			["vec-h"] = _ => new EFloat(16).AsRuntime(), 
			["vec-s"] = _ => new EFloat(32).AsRuntime(), 
			["vec-d"] = _ => new EFloat(64).AsRuntime(), 
			["vector-all"] = _ => EType.Vector.AsRuntime(), 
			["vector-zero-top"] = _ => EType.Vector.AsRuntime(), 
			["vector-insert"] = _ => EType.Unit, 
			["vector-element"] = x => TypeFromName(x[3]).AsRuntime(), 
			["vector-extract"] = x => EType.Vector.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["vector-count-bits"] = _ => EType.Vector, 
			["vector-sum-unsigned"] = _ => new EInt(false, 32), 
			["vec+"] = x => EType.Vector.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["vec*"] = x => EType.Vector.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["float-to-fixed-point"] = x => TypeFromName(x[2]).AsRuntime(x[1].Type.Runtime || x[3].Type.Runtime), 
		};
	}
}