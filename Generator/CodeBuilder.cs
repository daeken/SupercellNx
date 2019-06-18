using System.Text;

namespace Generator {
	public class CodeBuilder {
		readonly StringBuilder Builder = new StringBuilder();
		public string Code => Builder.ToString();
		int Indent;

		public static CodeBuilder operator +(CodeBuilder left, int depth) {
			left.Indent += depth;
			return left;
		}
		public static CodeBuilder operator -(CodeBuilder left, int depth) {
			left.Indent -= depth;
			return left;
		}

		public static CodeBuilder operator ++(CodeBuilder left) {
			left.Indent++;
			return left;
		}
		public static CodeBuilder operator --(CodeBuilder left) {
			left.Indent--;
			return left;
		}

		public static CodeBuilder operator +(CodeBuilder left, string data) {
			left.Builder.Append(new string('\t', left.Indent) + data + "\n");
			return left;
		}
	}
}