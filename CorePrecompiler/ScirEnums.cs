namespace CorePrecompiler {
	public enum BinaryOp {
		Add, 
		Subtract, 
		Multiply,
		Divide,
		Modulus, 
		BitwiseAnd, 
		BitwiseOr, 
		BitwiseXor, 
		LogicalAnd, 
		LogicalOr, 
		ShiftRightArithmetic,
		ShiftRightLogical, 
		ShiftLeft, 
		Eq, 
		Ne, 
		Gt, 
		Ge, 
		Lt, 
		Le
	}

	public enum UnaryOp {
		Negate, 
		BitwiseNot, 
		LogicalNot, 
		Abs, 
		Sqrt
	}
}