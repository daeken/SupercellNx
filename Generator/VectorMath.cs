namespace Generator {
	class VectorMath : Builtin {
		public override void Define() {
			Expression("vec-frsqrte", _ => EType.Vector, 
				list => $"VectorFrsqrte({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])})", 
				list => $"({GenerateExpression(list[1])}).Frsqrte({GenerateExpression(list[2])}, {GenerateExpression(list[3])})");
		}
	}
}