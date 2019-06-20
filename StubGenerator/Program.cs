using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Common;
using MoreLinq.Extensions;
using PrettyPrinter;

namespace StubGenerator {
	class Program {
		static void Main(string[] args) {
			var path = "ISA_v85A_A64_xml_00bet9";
			var insts = Directory.GetFiles(path, "*.xml").Select(Parse).SelectMany(x => x);
			foreach(var (name, bits, asm, names) in insts.OrderBy(x => x.Name.ToLower())) {
				$"(def {name}".Debug();
				$"\t\"{bits}\"".Debug();
				$"\t\"{asm}\"".Debug();
				$"\t{names}".Debug();
				"\t(block)".Debug();
				"\t(unimplemented))".Debug();
				"".Debug();
			}
		}

		static List<(string Name, string Bits, string Asm, string Names)> Parse(string fn) {
			var doc = new XmlDocument();
			doc.Load(fn);
			var insts = new List<(string Name, string Bits, string Asm, string Names)>();
			foreach(var node in doc.ChildNodes) {
				if(!(node is XmlNode xn) || node is XmlDocumentType || xn.Name != "instructionsection") continue;

				if(xn.Attributes == null || xn.Attributes["id"]?.Value == "shared_pseudocode") continue;
				if(xn.Find(x => x.Name == "aliasto") != null) continue;

				foreach(var cn in xn.FindAll(x => x.Name == "iclass")) {
					var fields = new List<(int Width, int Shift, string? Bits, string? Name)>();
					var named = new Dictionary<string, int>();
					foreach(var box in cn.Find(x => x.Name == "regdiagram")?.FindAll(x => x.Name == "box") ?? new List<XmlNode>()) {
						var width = int.Parse(box.Attributes["width"]?.Value ?? "1");
						var shift = int.Parse(box.Attributes["hibit"]?.Value ?? throw new NotSupportedException()) + 1 - width;
						var name = box.Attributes["name"]?.Value;
						if(name != null) named[name] = fields.Count;
						var bits = box.Attributes["constraint"] == null ? box.InnerText.Replace("(", "").Replace(")", "") : "";
						Debug.Assert(bits.Length == 0 || bits.Length == width);
						fields.Add((width, shift, bits == "" ? null : bits, name));
					}
					foreach(var enc in cn.FindAll(x => x.Name == "encoding")) {
						var cfields = fields.ToList();
						foreach(var box in enc.FindAll(x => x.Name == "box")) {
							Debug.Assert(box.Attributes["name"] != null);
							var name = box.Attributes["name"].Value;
							var (width, shift, _, _) = cfields[named[name]];
							cfields[named[name]] = (width, shift, box.InnerText, name);
						}
						cfields = cfields.OrderByDescending(x => x.Shift).ToList();

						var namemap = new Dictionary<string, string>();
						var bits = string.Join(' ', cfields.Select((x, i) => {
							if(x.Bits != null) return x.Bits;
							var c = (char) ('a' + i);
							if(x.Name != null) namemap[x.Name] = new string(c, 1);
							return new string(c, x.Width);
						}));
						
						var asm = enc.Find(x => x.Name == "asmtemplate")?.InnerText?.Replace("  ", " ") ?? "UNKNOWN";
						insts.Add((
							enc.Attributes["name"].Value.Trim(' ', '_').Replace("_", "-"), 
							bits, 
							asm, 
							namemap.Count == 0 ? "(names)" : $"(names {string.Join(' ', namemap.Select(x => $"({x.Key} {x.Value})"))})"
						));
					}
				}
			}
			return insts;
		}
	}
}