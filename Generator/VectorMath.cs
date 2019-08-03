using System;

namespace Generator {
	class VectorMath : Builtin {
		public override void Define() {
			Expression("vec-frsqrte", list => EType.Vector.AsRuntime(list.AnyRuntime), 
				list => $"VectorFrsqrte({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])})", 
				list => $"({GenerateExpression(list[1])}).Frsqrte({GenerateExpression(list[2])}, {GenerateExpression(list[3])})");
			
			Expression("vec+", list => EType.Vector.AsRuntime(list.AnyRuntime), 
				list => list[3] switch {
					PInt(32) => $"Sse.Add({GenerateExpression(list[1])}, {GenerateExpression(list[2])})", 
					PInt(64) => $"Sse2.Add(({GenerateExpression(list[1])}).As<float, double>(), ({GenerateExpression(list[2])}).As<float, double>()).As<double, float>()",
					_ => throw new NotSupportedException()
				}, 
				list => list[3] switch {
					PInt(32) => $"({GenerateExpression(list[1])}) + ({GenerateExpression(list[2])})", 
					PInt(64) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<double>>) ({GenerateExpression(list[1])}) + (RuntimeValue<Vector128<double>>) ({GenerateExpression(list[2])}))", 
					_ => throw new NotSupportedException()
				});
			
			Expression("vec-", list => EType.Vector.AsRuntime(list.AnyRuntime), 
				list => list[3] switch {
					PInt(32) => $"Sse.Subtract({GenerateExpression(list[1])}, {GenerateExpression(list[2])})", 
					PInt(64) => $"Sse2.Subtract(({GenerateExpression(list[1])}).As<float, double>(), ({GenerateExpression(list[2])}).As<float, double>()).As<double, float>()",
					_ => throw new NotSupportedException()
				}, 
				list => list[3] switch {
					PInt(32) => $"({GenerateExpression(list[1])}) - ({GenerateExpression(list[2])})", 
					PInt(64) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<double>>) ({GenerateExpression(list[1])}) - (RuntimeValue<Vector128<double>>) ({GenerateExpression(list[2])}))", 
					_ => throw new NotSupportedException()
				});
			
			Expression("vec*", list => EType.Vector.AsRuntime(list.AnyRuntime), 
				list => list[3] switch {
					PInt(32) => $"Sse.Multiply({GenerateExpression(list[1])}, {GenerateExpression(list[2])})", 
					PInt(64) => $"Sse2.Multiply(({GenerateExpression(list[1])}).As<float, double>(), ({GenerateExpression(list[2])}).As<float, double>()).As<double, float>()",
					_ => throw new NotSupportedException()
				}, 
				list => list[3] switch {
					PInt(32) => $"({GenerateExpression(list[1])}) * ({GenerateExpression(list[2])})", 
					PInt(64) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<double>>) ({GenerateExpression(list[1])}) * (RuntimeValue<Vector128<double>>) ({GenerateExpression(list[2])}))", 
					_ => throw new NotSupportedException()
				});

			string CastVector(PTree elem, string type) =>
				elem.Type is EVector
					? $"({GenerateExpression(elem)}).As<float, {type}>()"
					: $"({GenerateExpression(elem)})";
			string RuntimeCastVector(PTree elem, string type) =>
				elem.Type is EVector
					? $"((RuntimeValue<Vector128<{type}>>) ({GenerateExpression(elem)}))"
					: $"({GenerateExpression(elem)})";
			Expression("vec-uint*", list => EType.Vector.AsRuntime(list.AnyRuntime), 
				list => list[3] switch {
					PInt(8) => $"({GenerateExpression(list[1])}).As<float, byte>().Multiply({CastVector(list[2], "byte")}).As<byte, float>()", 
					PInt(16) => $"({GenerateExpression(list[1])}).As<float, ushort>().Multiply({CastVector(list[2], "ushort")}).As<ushort, float>()", 
					PInt(32) => $"({GenerateExpression(list[1])}).As<float, uint>().Multiply({CastVector(list[2], "uint")}).As<uint, float>()", 
					PInt(64) => $"({GenerateExpression(list[1])}).As<float, ulong>().Multiply({CastVector(list[2], "ulong")}).As<float, ulong>()).As<ulong, float>()", 
					_ => throw new NotSupportedException()
				}, 
				list => list[3] switch {
					PInt(8) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<byte>>) ({GenerateExpression(list[1])}) * {RuntimeCastVector(list[2], "byte")})", 
					PInt(16) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<ushort>>) ({GenerateExpression(list[1])}) * {RuntimeCastVector(list[2], "ushort")})", 
					PInt(32) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<uint>>) ({GenerateExpression(list[1])}) * {RuntimeCastVector(list[2], "uint")})", 
					PInt(64) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<ulong>>) ({GenerateExpression(list[1])}) * {RuntimeCastVector(list[2], "ulong")})", 
					_ => throw new NotSupportedException()
				});
			
			Expression("vec/", list => EType.Vector.AsRuntime(list.AnyRuntime), 
				list => list[3] switch {
					PInt(32) => $"Sse.Divide({GenerateExpression(list[1])}, {GenerateExpression(list[2])})", 
					PInt(64) => $"Sse2.Divide(({GenerateExpression(list[1])}).As<float, double>(), ({GenerateExpression(list[2])}).As<float, double>()).As<double, float>()",
					_ => throw new NotSupportedException()
				}, 
				list => list[3] switch {
					PInt(32) => $"({GenerateExpression(list[1])}) / ({GenerateExpression(list[2])})", 
					PInt(64) => $"(RuntimeValue<Vector128<float>>) ((RuntimeValue<Vector128<double>>) ({GenerateExpression(list[1])}) / (RuntimeValue<Vector128<double>>) ({GenerateExpression(list[2])}))", 
					_ => throw new NotSupportedException()
				});
			
			Expression("vec&~", list => list[1].Type, 
				list => $"Sse.AndNot({GenerateExpression(list[2])}, {GenerateExpression(list[1])})", 
				list => $"({GenerateExpression(list[1])}).AndNot({GenerateExpression(list[2])})");
		}
	}
}