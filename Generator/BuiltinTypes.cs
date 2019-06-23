using System;
using System.Collections.Generic;
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
			["load"] = x => TypeFromName(x[2]).AsRuntime(),
			
			["svc"] = _ => EType.Unit.AsRuntime(),
			["sr"] = _ => new EInt(false, 64).AsRuntime(),

			["make-wmask"] = _ => new EInt(false, 64), 
			["make-tmask"] = _ => new EInt(false, 64), 
			["signext"] = x => TypeFromName(x[2]).AsRuntime(x[1].Type.Runtime), 
			["cast"] = x => TypeFromName(x[2]).AsRuntime(x[1].Type.Runtime), 
			["gpr32"] = _ => new EInt(false, 32).AsRuntime(), 
			["gpr-or-sp32"] = _ => new EInt(false, 32).AsRuntime(), 
			["gpr64"] = _ => new EInt(false, 64).AsRuntime(), 
			["gpr-or-sp64"] = _ => new EInt(false, 64).AsRuntime(), 
			["="] = x => x[2].Type ?? throw new NotImplementedException(), 
			["=="] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["!="] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["+"] = x => LogicalType(x[1].Type, x[2].Type), 
			["add-with-carry-set-nzcv"] = x => x[1].Type, 
			["-"] = x => LogicalType(x[1].Type, x[2].Type), 
			["*"] = x => LogicalType(x[1].Type, x[2].Type), 
			["/"] = x => LogicalType(x[1].Type, x[2].Type), 
			["~"] = x => x[1].Type, 
			["!"] = x => new EInt(false, 1).AsRuntime(x[1].Type.Runtime), 
			["|"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["&"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["^"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["<<"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			[">>"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			[">>>"] = x => x[1].Type.AsRuntime(x[1].Type.Runtime || x[2].Type.Runtime), 
			["shift"] = x => x[1].Type, 
			["count-leading-zeros"] = x => x[1].Type, 
			["reverse-bits"] = x => x[1].Type, 
			["vec"] = _ => EType.Vector.AsRuntime(), 
			["vec-s"] = _ => new EFloat(32).AsRuntime(), 
			["vec-d"] = _ => new EFloat(64).AsRuntime(), 
			["vector-all"] = _ => EType.Vector, 
			["vector-zero-top"] = _ => EType.Vector, 
		};
	}
}