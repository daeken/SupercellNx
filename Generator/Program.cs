using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PrettyPrinter;
using Common;
using MoreLinq;

namespace Generator {
	enum ContextTypes {
		Disassembler, 
		Interpreter, 
		Recompiler
	}
	
	class Program {
		static void Main(string[] args) {
			var ptree = ListParser.Parse(File.ReadAllText("aarch64.isa"));
			var defs = Def.ParseAll(ptree).Select(InferRuntime).ToList();
			BuildDisassembler(defs);
			BuildInterpreter(defs);
			BuildRecompiler(defs);
		}

		static Def InferRuntime(Def def) {
			void InferList(PList list) {
				switch(list[0]) {
					case PName("block"):
						foreach(var elem in list.Skip(1))
							InferList((PList) elem);
						break;
					case PName("let"):
						if(InferExpression(list[2]).Runtime)
							list.Type = list.Type.AsRuntime();
						foreach(var elem in list.Skip(3))
							InferList((PList) elem);
						break;
					case PName("if"):
						foreach(var elem in list.Skip(1))
							if(elem is PList sublist)
								InferList(sublist);
						if(list[1].Type.Runtime || !(list[2].Type is EUnit) && list[2].Type.Runtime || !(list[3].Type is EUnit) && list[3].Type.Runtime)
							list.Type = list.Type.AsRuntime();
						break;
					case PName("match"):
						foreach(var elem in list.Skip(1))
							if(elem is PList sublist)
								InferList(sublist);
						foreach(var elem in list)
							if(!(elem.Type is EUnit) && elem.Type.Runtime)
								list.Type = list.Type.AsRuntime();
						break;
					default:
						InferExpression(list);
						break;
				}
			}

			EType InferExpression(PTree tree) {
				if(tree.Type.Runtime) return tree.Type;
				switch(tree) {
					case PList list:
						var set = false;
						foreach(var elem in list)
							if(InferExpression(elem).Runtime)
								set = true;
						return list.Type = set ? list.Type.AsRuntime() : list.Type;
					default:
						return tree.Type;
				}
			}

			InferList(def.Decode);
			InferList(def.Eval);
			return def;
		}

		static ContextTypes Context;
		static int TempI;

		static string TempName() => $"temp_{TempI++}";

		static void GenerateFields(CodeBuilder c, Def def) {
			foreach(var field in def.Fields)
				c += $"var {field.Key} = (inst >> {field.Value.Shift}) & 0x{(1 << field.Value.Bits) - 1:X}U;";
		}

		static void GenerateStatement(CodeBuilder c, PList list) {
			if(Context == ContextTypes.Recompiler && list.Type.Runtime) {
				GenerateRuntimeStatement(c, list);
				return;
			}
			switch(list[0]) {
				case PName("block"):
					list.Skip(1).ForEach(x => GenerateStatement(c, (PList) x));
					break;
				case PName("branch"):
					c += $"Branch({GenerateExpression(list[1])});";
					break;
				case PName("branch-default"):
					c += $"Branch(pc + 4);";
					break;
				case PName("let"):
					c += $"var {list[1]} = {GenerateExpression(list[2])};";
					list.Skip(3).ForEach(x => GenerateStatement(c, (PList) x));
					break;
				case PName("if"):
					c += $"if(({GenerateExpression(list[1])}) != 0) {{";
					c++;
					GenerateStatement(c, (PList) list[2]);
					c--;
					c += "} else {";
					c++;
					GenerateStatement(c, (PList) list[3]);
					c--;
					c += "}";
					break;
				case PName("match"):
					c += $"switch({GenerateExpression(list[1])}) {{";
					c++;
					for(var i = 2; i < list.Count; i += 2)
						if(i + 1 == list.Count) {
							c += "default:";
							c++;
							GenerateStatement(c, (PList) list[i]);
							c += "break;";
							c--;
						} else {
							c += $"case {GenerateExpression(list[i])}:";
							c++;
							GenerateStatement(c, (PList) list[i + 1]);
							c += "break;";
							c--;
						}
					c--;
					c += "}";
					break;
				case PName("="):
					if(list[1] is PList sub)
						switch(sub[0]) {
							case PName("gpr32"):
								c += $"W[(int) {GenerateExpression(sub[1])}] = (uint) ({GenerateExpression(list[2])});";
								return;
							case PName("gpr-or-sp32"):
								c += $"if({GenerateExpression(sub[1])} == 31)";
								c++;
								c += $"SP = (ulong) (uint) ({GenerateExpression(list[2])});";
								c--;
								c += "else";
								c++;
								c += $"W[(int) {GenerateExpression(sub[1])}] = (uint) ({GenerateExpression(list[2])});";
								c--;
								return;
							case PName("gpr64"):
								c += $"X[(int) {GenerateExpression(sub[1])}] = {GenerateExpression(list[2])};";
								return;
							case PName("gpr-or-sp64"):
								c += $"if({GenerateExpression(sub[1])} == 31)";
								c++;
								c += $"SP = {GenerateExpression(list[2])};";
								c--;
								c += "else";
								c++;
								c += $"X[(int) {GenerateExpression(sub[1])}] = {GenerateExpression(list[2])};";
								c--;
								return;
							
							case PName("vec-b"):
								c += $"V[(int) ({GenerateExpression(sub[1])})] = new Vector128<byte>().WithElement(0, {GenerateExpression(list[2])}).As<byte, float>();";
								return;
							case PName("vec-h"):
								c += $"V[(int) ({GenerateExpression(sub[1])})] = new Vector128<ushort>().WithElement(0, {GenerateExpression(list[2])}).As<ushort, float>();";
								return;
							case PName("vec-s"):
								c += $"V[(int) ({GenerateExpression(sub[1])})] = new Vector128<float>().WithElement(0, {GenerateExpression(list[2])});";
								return;
							case PName("vec-d"):
								c += $"V[(int) ({GenerateExpression(sub[1])})] = new Vector128<double>().WithElement(0, {GenerateExpression(list[2])}).As<double, float>();";
								return;
							
							case PName("sr"):
								c += $"SR({GenerateExpression(sub[1])}, {GenerateExpression(sub[2])}, {GenerateExpression(sub[3])}, {GenerateExpression(sub[4])}, {GenerateExpression(sub[5])}, {GenerateExpression(list[2])});";
								return;
						}

					c += $"{GenerateExpression(list[1], lhs: true)} = {GenerateExpression(list[2])};";
					break;
				case PName name:
					c += $"{GenerateExpression(list)};";
					break;
				default:
					throw new NotSupportedException($"Non-name for first element of list {list.ToPrettyString()}");
			}
		}

		static void GenerateRuntimeStatement(CodeBuilder c, PList list) {
			Debug.Assert(Context == ContextTypes.Recompiler);
			switch(list[0]) {
				case PName("block"):
					list.Skip(1).ForEach(x => {
						if(x.Type.Runtime)
							c += "// Runtime block!";
						GenerateStatement(c, (PList) x);
					});
					break;
				case PName("branch"):
					c += $"Branch({GenerateExpression(list[1])});";
					break;
				case PName("branch-default"):
					c += "Branch(pc + 4);";
					break;
				case PName("let"):
					c += $"var {list[1]} = {GenerateExpression(list[2])};";
					list.Skip(3).ForEach(x => {
						if(x.Type.Runtime)
							c += "// Runtime let!";
						GenerateStatement(c, (PList) x);
					});
					break;
				case PName("if") when !list[1].Type.Runtime:
					c += $"if(({GenerateExpression(list[1])}) != 0) {{";
					c++;
					if(list[2].Type.Runtime)
						c += "// Runtime if!";
					GenerateStatement(c, (PList) list[2]);
					c--;
					c += "} else {";
					c++;
					if(list[3].Type.Runtime)
						c += "// Runtime else!";
					GenerateStatement(c, (PList) list[3]);
					c--;
					c += "}";
					break;
				case PName("if"):
					var end_label = TempName();
					var else_label = TempName();
					c += $"Label {end_label} = Ilg.DefineLabel(), {else_label} = Ilg.DefineLabel();";
					c += $"BranchIf(({GenerateExpression(list[1])}) == 0, {else_label});";
					GenerateStatement(c, (PList) list[2]);
					c += $"Branch({end_label});";
					c += $"Label({else_label});";
					GenerateStatement(c, (PList) list[3]);
					c += $"Label({end_label});";
					break;
				case PName("match"):
					c += $"switch({GenerateExpression(list[1])}) {{";
					c++;
					for(var i = 2; i < list.Count; i += 2)
						if(i + 1 == list.Count) {
							c += "default:";
							c++;
							GenerateStatement(c, (PList) list[i]);
							c += "break;";
							c--;
						} else {
							c += $"case {GenerateExpression(list[i])}:";
							c++;
							GenerateStatement(c, (PList) list[i + 1]);
							c += "break;";
							c--;
						}
					c--;
					c += "}";
					break;
				case PName("="):
					if(list[1] is PList sub)
						switch(sub[0]) {
							case PName("gpr32"):
								c += $"XR[(int) {GenerateExpression(sub[1])}] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ({GenerateExpression(list[2])});";
								return;
							case PName("gpr-or-sp32"):
								c += $"if({GenerateExpression(sub[1])} == 31)";
								c++;
								c += $"SPR = (RuntimeValue<ulong>) (RuntimeValue<uint>) ({GenerateExpression(list[2])});";
								c--;
								c += "else";
								c++;
								c += $"XR[(int) {GenerateExpression(sub[1])}] = (RuntimeValue<ulong>) (RuntimeValue<uint>) ({GenerateExpression(list[2])});";
								c--;
								return;
							case PName("gpr64"):
								c += $"XR[(int) {GenerateExpression(sub[1])}] = {GenerateExpression(list[2])};";
								return;
							case PName("gpr-or-sp64"):
								c += $"if({GenerateExpression(sub[1])} == 31)";
								c++;
								c += $"SPR = {GenerateExpression(list[2])};";
								c--;
								c += "else";
								c++;
								c += $"XR[(int) {GenerateExpression(sub[1])}] = {GenerateExpression(list[2])};";
								c--;
								return;
							case PName("sr"):
								c += $"CallSR({GenerateExpression(sub[1])}, {GenerateExpression(sub[2])}, {GenerateExpression(sub[3])}, {GenerateExpression(sub[4])}, {GenerateExpression(sub[5])}, {GenerateExpression(list[2])});";
								return;
						}

					c += $"{GenerateExpression(list[1], lhs: true)} = {GenerateExpression(list[2])};";
					break;
				case PName name:
					c += $"{GenerateExpression(list)};";
					break;
				default:
					throw new NotSupportedException($"Non-name for first element of list {list.ToPrettyString()}");
			}
		}

		static string ToHex(long value) => value < 0 ? $"-0x{-value:X}" : $"0x{value:X}";
		static string GenerateExpression(PTree v, bool lhs = false) {
			switch(v) {
				case PName name: return name.Name;
				case PInt value: return ((EInt) value.Type).Signed ? ToHex(value.Value) : ToHex(value.Value) + "U";
				case PString str: return str.String.ToPrettyString();
				case PList list: return GenerateListExpression(list, lhs: lhs);
				default: throw new NotImplementedException();
			}
		}

		static string GenerateType(EType type) {
			string __GenerateType() {
				switch(type) {
					case null: return "void";
					case EUnit _: return "void";
					case EString _: return "string";
					case EInt i:
						switch(i.Width) {
							case int x when x > 64: return i.Signed ? "Int128" : "UInt128";
							case int x when x > 32: return i.Signed ? "long" : "ulong";
							case int x when x > 16: return i.Signed ? "int" : "uint";
							case int x when x > 8: return i.Signed ? "short" : "ushort";
							default: return i.Signed ? "sbyte" : "byte";
						}
					case EFloat f:
						switch(f.Width) {
							case int x when x > 64: return "Vector128<float>";
							case int x when x > 32: return "double";
							default: return "float";
						}
					case EVector _: return "Vector128<float>";
					default: throw new NotImplementedException();
				}
			}

			return Context == ContextTypes.Recompiler && type.Runtime
				? $"RuntimeValue<{__GenerateType()}>"
				: __GenerateType();
		}

		static string GenerateListExpression(PList list, bool lhs = false) {
			if(Context == ContextTypes.Recompiler && list.Type.Runtime) {
				var expr = GenerateBaseListRuntimeExpression(list);
				return lhs || list.Type is EUnit ? expr : $"({GenerateType(list.Type)}) ({expr})";
			} else {
				var expr = GenerateBaseListExpression(list);
				return lhs || list.Type is EUnit ? expr : $"({GenerateType(list.Type)}) ({expr})";
			}
		}

		static string GenerateBaseListExpression(PList list) {
			switch(list[0]) {
				case PName("if"):
					var a = GenerateExpression(list[2]);
					var b = GenerateExpression(list[3]);
					if(!a.StartsWith("throw")) a = $"({a})";
					if(!b.StartsWith("throw")) b = $"({b})";
					return $"({GenerateExpression(list[1])} != 0) ? {a} : {b}";
				case PName("match"):
					var opts = new List<string>();
					for(var i = 2; i < list.Count; i += 2)
						opts.Add(i + 1 == list.Count
							? $"_ => {GenerateExpression(list[i])}"
							: $"{GenerateExpression(list[i])} => {GenerateExpression(list[i + 1])}");
					return $"({GenerateExpression(list[1])}) switch {{ {string.Join(", ", opts)} }}";
				case PName("=="): case PName("!="): return $"(({GenerateExpression(list[1])}) {list[0]} ({GenerateExpression(list[2])})) ? 1U : 0U";
				case PName("<<"): case PName(">>"): return $"({GenerateExpression(list[1])}) {list[0]} (int) ({GenerateExpression(list[2])})";
				case PName(">>>"):
					if(!(list[1].Type is EInt(false, var bs))) throw new NotSupportedException();
					return
						$"(({GenerateExpression(list[1])}) << ({bs} - (int) ({GenerateExpression(list[2])}))) | (({GenerateExpression(list[1])}) >> (int) ({GenerateExpression(list[2])}))";
				case PName("+"): case PName("-"): case PName("*"): case PName("/"): case PName("|"): case PName("&"): case PName("^"):
					if(list[1].Type is EInt(var sa, var ba) && list[2].Type is EInt(var sb, var bb)) {
						var stype = new EInt(sa && sb, Math.Max(ba, bb));
						return $"({GenerateType(stype)}) ({GenerateExpression(list[1])}) {list[0]} ({GenerateType(stype)}) ({GenerateExpression(list[2])})";
					}
					if(list[1].Type is EFloat(var wa) && list[2].Type is EFloat(var wb)) {
						var stype = new EFloat(Math.Max(wa, wb));
						return $"({GenerateType(stype)}) ({GenerateExpression(list[1])}) {list[0]} ({GenerateType(stype)}) ({GenerateExpression(list[2])})";
					}
					throw new NotImplementedException();
				case PName("sqrt"):
					return $"({GenerateType(list.Type)}) Math.Sqrt((double) ({GenerateExpression(list[1])}))";
				case PName(":"):
					var offset = 0;
					return list.Skip(1).Reverse().Select(x => {
						if(!(x.Type is EInt(_, var width))) throw new NotSupportedException();
						var ret = $"((({GenerateType(list.Type)}) ({GenerateExpression(x)})) << {offset})";
						offset += width;
						return ret;
					}).Aggregate((a, x) => $"({GenerateType(list.Type)}) ((({GenerateType(list.Type)}) {a}) | (({GenerateType(list.Type)}) {x}))");
				case PName("replicate"):
					if(!(list[1].Type is EInt(_, var width))) throw new NotSupportedException();
					if(!(list[2] is PInt(var count))) throw new NotSupportedException();
					return Enumerable.Range(0, (int) count)
							.Select(i => $"((({GenerateType(list.Type)}) ({GenerateExpression(list[1])})) << {i * width})")
							.Aggregate((a, x) => $"({GenerateType(list.Type)}) ((({GenerateType(list.Type)}) {a}) | (({GenerateType(list.Type)}) {x}))");
				case PName("add-with-carry-set-nzcv"):
					return $"AddWithCarrySetNzcv({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])})";
				case PName("fcmp"):
					return $"FloatCompare({GenerateExpression(list[1])}, {GenerateExpression(list[2])})";
				case PName("~"): return $"~({GenerateExpression(list[1])})";
				case PName("-!"): return $"-({GenerateExpression(list[1])})";
				case PName("!"): return $"({GenerateExpression(list[1])}) != 0 ? 0U : 1U";
				case PName("shift"):
					return $"Shift({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])})";
				case PName("count-leading-zeros"): return $"CountLeadingZeros({GenerateExpression(list[1])})";
				case PName("reverse-bits"): return $"ReverseBits({GenerateExpression(list[1])})";
				case PName("pc"): return "pc";
				case PName("nzcv"):
					if(list.Count == 1) return "NZCV";
					switch(list[1]) {
						case PName("n"): return "NZCV_N";
						case PName("z"): return "NZCV_Z";
						case PName("c"): return "NZCV_C";
						case PName("v"): return "NZCV_V";
						default: throw new NotSupportedException($"Unknown field of NZCV: {list[1]}");
					}
				case PName("gpr32"): return $"({GenerateExpression(list[1])}) == 31 ? 0U : W[(int) {GenerateExpression(list[1])}]";
				case PName("gpr-or-sp32"): return $"({GenerateExpression(list[1])}) == 31 ? (uint) (SP & 0xFFFFFFFFUL) : W[(int) {GenerateExpression(list[1])}]";
				case PName("gpr64"): return $"({GenerateExpression(list[1])}) == 31 ? 0UL : X[(int) {GenerateExpression(list[1])}]";
				case PName("gpr-or-sp64"): return $"({GenerateExpression(list[1])}) == 31 ? SP : X[(int) {GenerateExpression(list[1])}]";
				case PName("vec"): return $"V[{GenerateExpression(list[1])}]";
				case PName("vec-b"): return $"V[{GenerateExpression(list[1])}].As<float, byte>().GetElement(0)";
				case PName("vec-h"): return $"V[{GenerateExpression(list[1])}].As<float, ushort>().GetElement(0)";
				case PName("vec-s"): return $"V[{GenerateExpression(list[1])}].GetElement(0)";
				case PName("vec-d"): return $"V[{GenerateExpression(list[1])}].As<float, double>().GetElement(0)";
				case PName("make-tmask"):
					return $"MakeTMask({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])}, {GenerateExpression(list[5])}, {GenerateExpression(list[4])})";
				case PName("make-wmask"):
					return $"MakeWMask({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])}, {GenerateExpression(list[5])}, {GenerateExpression(list[4])})";
				case PName("signext"):
					return $"SignExt<{GenerateType(list.Type)}>({GenerateExpression(list[1])}, {((EInt) list[1].Type).Width})";
				case PName("cast"):
					return $"({GenerateType(list.Type)}) ({GenerateExpression(list[1])})";
				case PName("bitcast"):
					return $"Bitcast<{GenerateType(list[1].Type)}, {GenerateType(list.Type)}>({GenerateExpression(list[1])})";
				case PName("store"):
					if(list[2].Type is EVector || list[2].Type is EFloat(128))
						return $"Sse.Store((float*) ({GenerateExpression(list[1])}), {GenerateExpression(list[2])})";
					return $"*({GenerateType(list[2].Type)}*) ({GenerateExpression(list[1])}) = {GenerateExpression(list[2])}";
				case PName("load"):
					if(list.Type is EVector || list.Type is EFloat(128))
						return $"Sse.LoadVector128((float*) ({GenerateExpression(list[1])}))";
					return $"*({GenerateType(list.Type)}*) ({GenerateExpression(list[1])})";
				
				case PName("svc"): return $"Svc({GenerateExpression(list[1])})";
				case PName("sr"): return $"SR({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])}, {GenerateExpression(list[4])}, {GenerateExpression(list[5])})";
				
				case PName("vector-all"): return $"Vector128.Create({GenerateExpression(list[1])}).As<{GenerateType(list[1].Type)}, float>()";
				case PName("vector-zero-top"): return GenerateExpression(list[1]);
				case PName("vector-insert"): return $"V[(int) ({GenerateExpression(list[1])})] = Insert(V[(int) ({GenerateExpression(list[1])})], {GenerateExpression(list[2])}, {GenerateExpression(list[3])})";
				
				case PName("unimplemented"): return "throw new NotImplementedException()";
				case PName name: throw new NotImplementedException($"Unknown name for GenerateListExpression: {name}");
				default: throw new NotSupportedException($"Non-name for first element of list {list.ToPrettyString()}");
			}
		}

		static string GenerateBaseListRuntimeExpression(PList list) {
			Debug.Assert(Context == ContextTypes.Recompiler);
			switch(list[0]) {
				case PName("if"):
					var a = GenerateExpression(list[2]);
					var b = GenerateExpression(list[3]);
					if(list[1].Type.Runtime) {
						if(a.StartsWith("throw")) a = "null";
						if(b.StartsWith("throw")) b = "null";
						return $"Ternary<{GenerateType(list[1].Type.AsCompiletime())}, {GenerateType(list[2].Type.AsCompiletime())}>((RuntimeValue<{GenerateType(list[1].Type.AsCompiletime())}>) ({GenerateExpression(list[1])}), {a}, {b})";
					} else {
						if(!a.StartsWith("throw")) a = $"({a})";
						if(!b.StartsWith("throw")) b = $"({b})";
						return $"({GenerateExpression(list[1])}) != 0 ? {a} : {b}";
					}
				case PName("match"):
					string Expr(PTree expr) {
						var str = GenerateExpression(expr);
						return str.StartsWith("throw ") ? str : $"({GenerateType(list.Type)}) ({str})";
					}
					var opts = new List<string>();
					for(var i = 2; i < list.Count; i += 2)
						opts.Add(i + 1 == list.Count
							? $"_ => {Expr(list[i])}"
							: $"{GenerateExpression(list[i])} => {Expr(list[i + 1])}");
					return $"({GenerateExpression(list[1])}) switch {{ {string.Join(", ", opts)} }}";
				case PName("=="): case PName("!="): return $"({GenerateExpression(list[1])}) {list[0]} ({GenerateExpression(list[2])})";
				case PName("<<"): return $"({GenerateExpression(list[1])}).ShiftLeft({GenerateExpression(list[2])})";
				case PName(">>"): return $"({GenerateExpression(list[1])}).ShiftRight({GenerateExpression(list[2])})";
				case PName(">>>"):
					if(!(list[1].Type is EInt(false, var bs))) throw new NotSupportedException();
					return
						$"(({GenerateExpression(list[1])}).ShiftLeft((RuntimeValue<uint>) ({bs} - ({GenerateExpression(list[2])})))) | (({GenerateExpression(list[1])}).ShiftRight((RuntimeValue<uint>) ({GenerateExpression(list[2])})))";
				case PName("+"): case PName("-"): case PName("*"): case PName("/"): case PName("|"): case PName("&"): case PName("^"):
					if(list[1].Type is EInt(var sa, var ba) && list[2].Type is EInt(var sb, var bb)) {
						var stype = new EInt(sa && sb, Math.Max(ba, bb)) { Runtime = list[1].Type.Runtime || list[2].Type.Runtime };
						if(stype.Runtime)
							return $"({GenerateType(stype)}) ({GenerateType(list[1].Type.AsRuntime())}) ({GenerateExpression(list[1])}) {list[0]} ({GenerateType(stype)}) ({GenerateType(list[2].Type.AsRuntime())}) ({GenerateExpression(list[2])})";
						return $"({GenerateType(stype)}) ({GenerateExpression(list[1])}) {list[0]} ({GenerateType(stype)}) ({GenerateExpression(list[2])})";
					}
					if(list[1].Type is EFloat(var wa) && list[2].Type is EFloat(var wb)) {
						var stype = new EFloat(Math.Max(wa, wb)) { Runtime = list[1].Type.Runtime || list[2].Type.Runtime };
						return $"({GenerateType(stype)}) ({GenerateExpression(list[1])}) {list[0]} ({GenerateType(stype)}) ({GenerateExpression(list[2])})";
					}
					throw new NotImplementedException();
				case PName("sqrt"):
					return $"({GenerateType(list.Type)}) (({GenerateType(new EFloat(64).AsRuntime(list[1].Type.Runtime))}) ({GenerateExpression(list[1])})).Sqrt()";
				case PName("add-with-carry-set-nzcv"):
					return $"CallAddWithCarrySetNzcv({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])})";
				case PName("fcmp"):
					return $"CallFloatCompare({GenerateExpression(list[1])}, {GenerateExpression(list[2])})";
				case PName("~"): return $"~({GenerateExpression(list[1])})";
				case PName("-!"): return $"-({GenerateExpression(list[1])})";
				case PName("!"): return $"!({GenerateExpression(list[1])})";
				case PName("shift"):
					return $"Shift({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])})";
				case PName("count-leading-zeros"): return $"CallCountLeadingZeros({GenerateExpression(list[1])})";
				case PName("reverse-bits"): return $"CallReverseBits({GenerateExpression(list[1])})";
				case PName("pc"): return "pc";
				case PName("nzcv"):
					if(list.Count == 1) return "NZCVR";
					switch(list[1]) {
						case PName("n"): return "NZCV_NR";
						case PName("z"): return "NZCV_ZR";
						case PName("c"): return "NZCV_CR";
						case PName("v"): return "NZCV_VR";
						default: throw new NotSupportedException($"Unknown field of NZCV: {list[1]}");
					}
				case PName("gpr32"): return $"({GenerateExpression(list[1])}) == 31 ? 0U : (RuntimeValue<uint>) XR[(int) {GenerateExpression(list[1])}]";
				case PName("gpr-or-sp32"): return $"(RuntimeValue<uint>) (({GenerateExpression(list[1])}) == 31 ? (SPR & 0xFFFFFFFFUL) : XR[(int) {GenerateExpression(list[1])}])";
				case PName("gpr64"): return $"({GenerateExpression(list[1])}) == 31 ? 0UL : XR[(int) {GenerateExpression(list[1])}]";
				case PName("gpr-or-sp64"): return $"({GenerateExpression(list[1])}) == 31 ? SPR : XR[(int) {GenerateExpression(list[1])}]";
				case PName("vec"): return $"VR[(int) ({GenerateExpression(list[1])})]";
				case PName("vec-b"): return $"VBR[(int) ({GenerateExpression(list[1])})]";
				case PName("vec-h"): return $"VHR[(int) ({GenerateExpression(list[1])})]";
				case PName("vec-s"): return $"VSR[(int) ({GenerateExpression(list[1])})]";
				case PName("vec-d"): return $"VDR[(int) ({GenerateExpression(list[1])})]";
				case PName("make-tmask"):
					return $"MakeTMask({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])}, {GenerateExpression(list[5])}, {GenerateExpression(list[4])})";
				case PName("make-wmask"):
					return $"MakeWMask({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])}, {GenerateExpression(list[5])}, {GenerateExpression(list[4])})";
				case PName("signext"):
					return $"SignExtRuntime<{GenerateType(list.Type.AsCompiletime())}>({GenerateExpression(list[1])}, {((EInt) list[1].Type).Width})";
				case PName("cast"):
					return $"({GenerateType(list.Type)}) ({GenerateExpression(list[1])})";
				case PName("bitcast"):
					return $"({GenerateExpression(list[1])}).Bitcast<{GenerateType(list.Type.AsCompiletime())}>()";
				case PName("store"):
					return $"((RuntimePointer<{GenerateType(list[2].Type.AsCompiletime())}>) ({GenerateExpression(list[1])})).Value = {GenerateExpression(list[2])}";
				case PName("load"):
					return $"((RuntimePointer<{GenerateType(list.Type.AsCompiletime())}>) ({GenerateExpression(list[1])})).Value";
				
				case PName("svc"): return $"CallVoid(nameof(Svc), {GenerateExpression(list[1])})";
				case PName("sr"): return $"CallSR({GenerateExpression(list[1])}, {GenerateExpression(list[2])}, {GenerateExpression(list[3])}, {GenerateExpression(list[4])}, {GenerateExpression(list[5])})";
				
				case PName("vector-all"):
					return $"(({GenerateType(list[1].Type.AsRuntime())}) ({GenerateExpression(list[1])})).CreateVector()";
				case PName("vector-zero-top"): return GenerateExpression(list[1]);
				
				case PName("vector-insert"):
					return $"VR[(int) ({GenerateExpression(list[1])})] = VR[(int) ({GenerateExpression(list[1])})].Insert({GenerateExpression(list[2])}, {GenerateExpression(list[3])})";
				
				case PName("unimplemented"): return "throw new NotImplementedException()";
				case PName name: throw new NotImplementedException($"Unknown name for GenerateListExpression: {name}");
				default: throw new NotSupportedException($"Non-name for first element of list {list.ToPrettyString()}");
			}
		}

		static void BuildDisassembler(List<Def> defs) {
			Context = ContextTypes.Disassembler;
			
			var c = new CodeBuilder();
			c += 3;
			
			foreach(var def in defs) {
				string RewriteFormat(string fmt) =>
					Regex.Replace(fmt, @"\$(\$|[a-zA-Z\-][a-zA-Z\-0-9]*)", 
						match => {
							if(match.Groups[1].Value == "$$")
								return "$";
							var name = match.Groups[1].Value;
							if(def.Locals[name] is EInt(var signed, var size) && size > 8)
								return signed ? $"{{({name} < 0 ? $\"-0x{{-{name}:X}}\" : $\"0x{{{name}:X}}\")}}" : $"0x{{{name}:X}}";
							return $"{{{name}}}";
						});
				
				c += $"/* {def.Name} */";
				c += $"if((inst & 0x{def.Mask:X8}U) == 0x{def.Match:X8}U) {{";
				c++;
				GenerateFields(c, def);
				GenerateStatement(c, def.Decode);
				c += $"return $\"{RewriteFormat(def.Disassembly)}\";";
				c--;
				c += "}";
			}
			
			using var fp = File.Open("../Cpu64/Disassembler.cs", FileMode.Truncate);
			using var sw = new StreamWriter(fp);
			sw.Write(File.ReadAllText("../GeneratorStubs/DisassemblerStub.cs").Replace("/*%CODE%*/", c.Code));
		}
		
		static void BuildInterpreter(List<Def> defs) {
			Context = ContextTypes.Interpreter;
			
			var c = new CodeBuilder();
			c += 4;
			
			foreach(var def in defs) {
				c += $"/* {def.Name} */";
				c += $"if((inst & 0x{def.Mask:X8}U) == 0x{def.Match:X8}U) {{";
				c++;
				GenerateFields(c, def);
				GenerateStatement(c, def.Decode);
				GenerateStatement(c, def.Eval);
				c += "return true;";
				c--;
				c += "}";
			}
			
			using var fp = File.Open("../Cpu64/InterpreterGenerated.cs", FileMode.Truncate);
			using var sw = new StreamWriter(fp);
			sw.Write(File.ReadAllText("../GeneratorStubs/InterpreterStub.cs").Replace("/*%CODE%*/", c.Code));
		}
		
		static void BuildRecompiler(List<Def> defs) {
			Context = ContextTypes.Recompiler;
			
			var c = new CodeBuilder();
			c += 4;
			
			foreach(var def in defs) {
				c += $"/* {def.Name} */";
				c += $"if((inst & 0x{def.Mask:X8}U) == 0x{def.Match:X8}U) {{";
				c++;
				GenerateFields(c, def);
				GenerateStatement(c, def.Decode);
				GenerateStatement(c, def.Eval);
				c += "return true;";
				c--;
				c += "}";
			}
			
			using var fp = File.Open("../Cpu64/RecompilerGenerated.cs", FileMode.Truncate);
			using var sw = new StreamWriter(fp);
			sw.Write(File.ReadAllText("../GeneratorStubs/RecompilerStub.cs").Replace("/*%CODE%*/", c.Code));
		}
	}
}