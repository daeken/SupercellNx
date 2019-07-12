using System;

namespace Generator {
	public class Memory : Builtin {
		public override void Define() {
			Expression("load", list => TypeFromName(list[2]).AsRuntime(),
				list => {
					if(list.Type is EVector || list.Type is EFloat(128))
						return $"Sse.LoadVector128((float*) ({GenerateExpression(list[1])}))";
					return $"*({GenerateType(list.Type)}*) ({GenerateExpression(list[1])})";
				},
				list =>
					$"((RuntimePointer<{GenerateType(list.Type.AsCompiletime())}>) ({GenerateExpression(list[1])})).Value");

			Expression("load-exclusive", list => TypeFromName(list[2]).AsRuntime(),
				list =>
					$"Exclusive{(list.Type is EInt(_, var ewidth) ? ewidth : throw new NotSupportedException())} = *({GenerateType(list.Type)}*) ({GenerateExpression(list[1])})",
				list =>
					$"Exclusive{(list.Type is EInt(_, var width) ? width : throw new NotSupportedException())}R = ((RuntimePointer<{GenerateType(list.Type.AsCompiletime())}>) ({GenerateExpression(list[1])})).Value");
			
			Expression("store", _ => EType.Unit.AsRuntime(),
				list => {
					if(list[2].Type is EVector || list[2].Type is EFloat(128))
						return $"Sse.Store((float*) ({GenerateExpression(list[1])}), {GenerateExpression(list[2])})";
					return
						$"*({GenerateType(list[2].Type)}*) ({GenerateExpression(list[1])}) = {GenerateExpression(list[2])}";
				},
				list =>
					$"((RuntimePointer<{GenerateType(list[2].Type.AsCompiletime())}>) ({GenerateExpression(list[1])})).Value = {GenerateExpression(list[2])}");
			
			Expression("store-exclusive", _ => new EInt(false, 1).AsRuntime(), 
				list => $"CompareAndSwap(({GenerateType(list[2].Type)}*) ({GenerateExpression(list[1])}), {GenerateExpression(list[2])}, Exclusive{(list[2].Type is EInt(_, var sewidth) ? sewidth : throw new NotSupportedException())})", 
				list => $"CallCompareAndSwap((RuntimePointer<{GenerateType(list[2].Type.AsCompiletime())}>) ({GenerateExpression(list[1])}), {GenerateExpression(list[2])}, Exclusive{(list[2].Type is EInt(_, var sewidth) ? sewidth : throw new NotSupportedException())}R)");
		}
	}
}