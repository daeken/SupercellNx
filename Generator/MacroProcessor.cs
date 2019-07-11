using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;
using PrettyPrinter;

namespace Generator {
	public class MacroProcessor {
		public static PList Rewrite(PList top) {
			var macros = new Dictionary<string, (List<string>, PTree)>();
			foreach(var elem in top) {
				if(!(elem is PList list) || !(list[0] is PName("defm"))) continue;
				if(!(list[1] is PName(var name))) throw new Exception();
				var varnames = ((PList) list[2]).Select(x => ((PName) x).Name).ToList();
				macros[name] = (varnames, list[3]);
			}

			PTree Repl(PTree elem, Dictionary<string, PTree> replacements) {
				switch(elem) {
					case PList list: return new PList(list.Select(x => Repl(x, replacements)));
					case PName(var name): return replacements.TryGetValue(name, out var repl) ? repl : elem;
					default: return elem;
				}
			}

			PTree Sub(PTree elem) {
				if(!(elem is PList list)) return elem;
				if(!(list[0] is PName(var name)) || !macros.TryGetValue(name, out var v)) return new PList(list.Select(Sub));
				var (args, block) = v;
				if(args.Count != list.Count - 1) throw new NotSupportedException($"Macro {name.ToPrettyString()} expects {args.Count} arguments, got {list.Count - 1}");
				return Sub(Repl(block, args.Select((vn, i) => (vn, list[i + 1])).ToDictionary()));
			}
			
			return (PList) Sub(top);
		}
	}
}