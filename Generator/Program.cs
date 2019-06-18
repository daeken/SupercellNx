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
			var defs = Def.ParseAll(ptree);
			BuildDisassembler(defs);
			BuildInterpreter(defs);
		}

		static ContextTypes Context;

		static void GenerateFields(CodeBuilder c, Def def) {
			foreach(var field in def.Fields)
				c += $"var {field.Key} = (inst >> {field.Value.Shift}) & 0x{(1 << field.Value.Bits) - 1:X}U;";
		}

		static void GenerateStatement(CodeBuilder c, PList list) {
			switch(list[0]) {
				case PName("block"):
					list.Skip(1).ForEach(x => GenerateStatement(c, (PList) x));
					break;
				case PName("let"):
					c += $"var {list[1]} = {GenerateExpression(list[2])};";
					list.Skip(3).ForEach(x => GenerateStatement(c, (PList) x));
					break;
				case PName("runtime-let") when Context == ContextTypes.Interpreter:
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
				case PName("="):
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

		static string GenerateType(EType? type) {
			switch(type) {
				case null: return "void";
				case EUnit _: return "void";
				case EString _: return "string";
				case EInt i:
					switch(i.Width) {
						case int x when x > 32: return i.Signed ? "long" : "ulong";
						case int x when x > 16: return i.Signed ? "int" : "uint";
						case int x when x > 8: return i.Signed ? "short" : "ushort";
						default: return i.Signed ? "sbyte" : "byte";
					}
				default: throw new NotImplementedException();
			}
		}

		static string GenerateListExpression(PList list, bool lhs = false) {
			var expr = GenerateBaseListExpression(list);
			return lhs || list.Type == EType.Unit ? expr : $"({GenerateType(list.Type)}) ({expr})";
		}

		static string GenerateBaseListExpression(PList list) {
			switch(list[0]) {
				case PName("if"):
					return $"({GenerateExpression(list[1])} != 0) ? ({GenerateExpression(list[2])}) : ({GenerateExpression(list[3])})";
				case PName("=="): return $"(({GenerateExpression(list[1])}) == ({GenerateExpression(list[2])})) ? 1U : 0U";
				case PName("<<"): case PName(">>"): return $"({GenerateExpression(list[1])}) {list[0]} (int) ({GenerateExpression(list[2])})";
				case PName("+"): case PName("-"): case PName("|"):
					if(!(list[1].Type is EInt(var sa, var ba)) || !(list[2].Type is EInt(var sb, var bb)))
						throw new NotImplementedException();
					var stype = new EInt(sa && sb, Math.Max(ba, bb));
					return $"({GenerateType(stype)}) ({GenerateExpression(list[1])}) {list[0]} ({GenerateType(stype)}) ({GenerateExpression(list[2])})";
				case PName("pc"): return "pc";
				case PName("gpr32"): return $"W[(int) {GenerateExpression(list[1])}]";
				case PName("gpr64"): return $"X[(int) {GenerateExpression(list[1])}]";
				case PName("signext"):
					return $"SignExt<{GenerateType(list.Type)}>({GenerateExpression(list[1])}, {((EInt) list[1].Type).Width})";
				case PName("cast"):
					return $"({GenerateType(list.Type)}) ({GenerateExpression(list[1])})";
				case PName("store"):
					return $"StoreMemory({GenerateExpression(list[1])}, {GenerateExpression(list[2])})";
				case PName("load"):
					return $"LoadMemory<{GenerateType(list.Type)}>({GenerateExpression(list[1])})";
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
								return signed ? $"{{({name} < 0 ? $\"-0x{{-{name}}}\" : $\"0x{{{name}}}\")}}" : $"0x{{{name}:X}}";
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
			c += 3;
			
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
	}
}