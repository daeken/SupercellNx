using System;
using PrettyPrinter;

namespace CorePrecompiler {
	public abstract class Scir {
		public readonly Type Type;
		protected Scir(Type type) => Type = type;

		public class BinaryOperation : Scir {
			public readonly BinaryOp Op;
			public readonly Scir Left;
			public readonly Scir Right;

			public BinaryOperation(Type type, BinaryOp op, Scir left, Scir right) : base(type) {
				Op = op;
				Left = left;
				Right = right;
			}

			public void Deconstruct(out BinaryOp op, out Scir left, out Scir right) {
				op = Op;
				left = Left;
				right = Right;
			}

			public override string ToString() => $"BinaryOperation<{Type.ToPrettyString()}>(Op={Op}, Left={Left}, Right={Right})";
		}

		public class Bitcast : Scir {
			public readonly Scir Value;

			public Bitcast(Type type, Scir value) : base(type) {
				Value = value;
			}

			public void Deconstruct(out Scir value) {
				value = Value;
			}

			public override string ToString() => $"Bitcast<{Type.ToPrettyString()}>(Value={Value})";
		}

		public class Cast : Scir {
			public readonly Scir Value;

			public Cast(Type type, Scir value) : base(type) {
				Value = value;
			}

			public void Deconstruct(out Scir value) {
				value = Value;
			}

			public override string ToString() => $"Cast<{Type.ToPrettyString()}>(Value={Value})";
		}

		public class ConstValue<T> : Scir {
			public readonly T Value;

			public ConstValue(Type type, T value) : base(type) {
				Value = value;
			}

			public void Deconstruct(out T value) {
				value = Value;
			}

			public override string ToString() => $"ConstValue<{Type.ToPrettyString()}>(Value={Value})";
		}

		public class Load : Scir {
			public readonly Scir Address;

			public Load(Type type, Scir address) : base(type) {
				Address = address;
			}

			public void Deconstruct(out Scir address) {
				address = Address;
			}

			public override string ToString() => $"Load<{Type.ToPrettyString()}>(Address={Address})";
		}

		public class Store : Scir {
			public readonly Scir Address;
			public readonly Scir Value;

			public Store(Type type, Scir address, Scir value) : base(type) {
				Address = address;
				Value = value;
			}

			public void Deconstruct(out Scir address, out Scir value) {
				address = Address;
				value = Value;
			}

			public override string ToString() => $"Store<{Type.ToPrettyString()}>(Address={Address}, Value={Value})";
		}

		public class UnaryOperation : Scir {
			public readonly UnaryOp Op;
			public readonly Scir Value;

			public UnaryOperation(Type type, UnaryOp op, Scir value) : base(type) {
				Op = op;
				Value = value;
			}

			public void Deconstruct(out UnaryOp op, out Scir value) {
				op = Op;
				value = Value;
			}

			public override string ToString() => $"UnaryOperation<{Type.ToPrettyString()}>(Op={Op}, Value={Value})";
		}
	}
}
