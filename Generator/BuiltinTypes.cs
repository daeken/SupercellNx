using System;
using System.Collections.Generic;
using Common;
using PrettyPrinter;

namespace Generator {
	public class BuiltinTypes {
		static EType TypeFromName(PTree expr) {
			if(!(expr is PName name)) throw new NotSupportedException($"Attempted to make type from expr {expr.ToPrettyString()}");

			var ns = name.Name;
			return ns[0] == 'i' ? new EInt(true, int.Parse(ns.Substring(1))) : new EInt(false, int.Parse(ns.Substring(1)));
		}

		static EType LogicalType(EType a, EType b) {
			if(!(a is EInt ai)) throw new NotSupportedException("Logical expression contains lhs that is non-int");
			if(!(b is EInt bi)) throw new NotSupportedException("Logical expression contains rhs that is non-int");
			return new EInt(
					ai.Signed == bi.Signed && ai.Signed, 
					Math.Max(ai.Width, bi.Width)
				);
		}
		
		public static readonly IReadOnlyDictionary<string, Func<PList, EType>> Builtins = new Dictionary<string, Func<PList, EType>> {
			["unimplemented"] = _ => EType.Unit, 
			["pc"] = _ => new EInt(false, 64), 
			["nzcv"] = _ => new EInt(false, 1), 
			["branch"] = _ => EType.Unit, 
			["branch-default"] = _ => EType.Unit, 
			["store"] = _ => EType.Unit, 
			["load"] = x => TypeFromName(x[2]), 
			["signext"] = x => TypeFromName(x[2]), 
			["cast"] = x => TypeFromName(x[2]), 
			["gpr32"] = _ => new EInt(false, 32), 
			["gpr-or-sp32"] = _ => new EInt(false, 32), 
			["gpr64"] = _ => new EInt(false, 64), 
			["gpr-or-sp64"] = _ => new EInt(false, 64), 
			["="] = x => x[2].Type ?? throw new NotImplementedException(), 
			["=="] = _ => new EInt(false, 1), 
			["!="] = _ => new EInt(false, 1), 
			["+"] = x => LogicalType(x[1].Type, x[2].Type), 
			["add-with-carry-set-nzcv"] = x => x[1].Type, 
			["-"] = x => LogicalType(x[1].Type, x[2].Type), 
			["~"] = x => x[1].Type, 
			["!"] = x => new EInt(false, 1), 
			["|"] = x => x[1].Type, 
			["&"] = x => x[1].Type, 
			["^"] = x => x[1].Type, 
			["<<"] = x => x[1].Type, 
			[">>"] = x => x[1].Type, 
			["shift"] = x => x[1].Type, 
		};
	}
}