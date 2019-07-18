using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Common;
using MoreLinq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrettyPrinter;

namespace IpcGenerator {
	public abstract class IpcType {
		public static readonly IpcUnknownType Unknown = new IpcUnknownType();
		public static readonly IpcBoolType Bool = new IpcBoolType();
		public static readonly IpcIntType U8 = new IpcIntType(8, false),
			U16 = new IpcIntType(16, false),
			U32 = new IpcIntType(32, false),
			U64 = new IpcIntType(64, false), 
			U128 = new IpcIntType(128, false);
		public static readonly IpcIntType I8 = new IpcIntType(8, true),
			I16 = new IpcIntType(16, true),
			I32 = new IpcIntType(32, true),
			I64 = new IpcIntType(64, true);
		public static readonly IpcFloatType F32 = new IpcFloatType(32), F64 = new IpcFloatType(64);
		public int Alignment = -1;
		public string Name;
		
		public static IpcType Parse(JArray json) {
			var type = json[0].Value<string>();
			if(IpcDefinitions.ForwardTypes.TryGetValue(type, out var ft)) return ft.Resolve();
			switch(type) {
				case "unknown": return Unknown;
				case "bool": return Bool;
				case "u8": case "b8": return U8;
				case "u16": return U16;
				case "u32": return U32;
				case "u64": return U64;
				case "u128": return U128;
				case "i8":  case "s8":  return  I8;
				case "i16": case "s16": return I16;
				case "i32": case "s32": case "int": return I32;
				case "i64": case "s64": return I64;
				case "f32": return F32;
				case "f64": return F64;

				case "handle": return new IpcHandleType(json);
				case "KObject": return new IpcHandleType(new JArray("handle", new JArray("copy")));
				case "object": return new IpcObjectType(json);
				case "pid": return new IpcPid();

				case "array": case "buffer": return new IpcBufferType(json);
				case "bytes": return new IpcBytesType(json);
				case "enum": return new IpcEnumType(json);
				case "struct": return new IpcStructType(json);
				
				case "align":
					var bt = Parse(json[2].Value<JArray>());
					var clone = (IpcType) bt.MemberwiseClone();
					clone.Alignment = json[1].Value<int>();
					return clone;
				
				case "nn::util::BitFlagSet": return Unknown;
				
				default:
					$"Unknown type: {json}".Debug();
					return Unknown;
			}
		}
		
		public IpcType WithName(string name) {
			var type = (IpcType) MemberwiseClone();
			type.Name = name;
			return type;
		}
	}

	public class IpcUnknownType : IpcType {
	}

	public class IpcBoolType : IpcType {
	}

	public class IpcIntType : IpcType {
		public readonly int Bits;
		public readonly bool Signed;
		public IpcIntType(int bits, bool signed) {
			Bits = bits;
			Signed = signed;
		}

		public void Deconstruct(out int bits, out bool signed) {
			bits = Bits;
			signed = Signed;
		}
	}

	public class IpcFloatType : IpcType {
		public readonly int Bits;
		public IpcFloatType(int bits) => Bits = bits;
		public void Deconstruct(out int bits) => bits = Bits;
	}

	public enum HandleStyle {
		Unknown, 
		Copy, 
		Move
	}

	public class IpcHandleType : IpcType {
		public readonly HandleStyle Style;
		public readonly IpcType Type;
		public IpcHandleType(JArray json) {
			switch(json[1][0].Value<string>()) {
				case "copy":
					Style = HandleStyle.Copy;
					break;
				case "move":
					Style = HandleStyle.Move;
					break;
				case "unknown":
					Style = HandleStyle.Unknown;
					break;
				case { } x: throw new NotImplementedException(x);
			}
			if(json[1].Count() >= 2)
				Type = Parse(json[1][1].Value<JArray>());
		}

		public void Deconstruct(out HandleStyle style, out IpcType type) {
			style = Style;
			type = Type;
		}
	}

	public class IpcObjectType : IpcType {
		public readonly string Interface;
		public IpcObjectType(JArray json) => Interface = json[1][0].Value<string>();
		public void Deconstruct(out string iface) => iface = Interface;
	}

	public class IpcPid : IpcType {
	}

	public class IpcBufferType : IpcType {
		public readonly IpcType Type;
		public readonly int TransferType;
		public IpcBufferType(JArray json) {
			Type = Parse(json[1].Value<JArray>());
			TransferType = json[2].Value<int>();
		}

		public void Deconstruct(out IpcType type, out int transferType) {
			type = Type;
			transferType = TransferType;
		}
	}

	public class IpcBytesType : IpcType {
		public readonly int Size = -1;
		public IpcBytesType(JArray json) {
			if(json.Count >= 2) Size = json[1].Value<int>();
			if(json.Count == 3) Alignment = json[1].Value<int>();
		}
		
		public void Deconstruct(out int size) => size = Size;
	}

	public class IpcEnumType : IpcType {
		public readonly IpcType UnderlyingType;
		public readonly IReadOnlyDictionary<string, int> Options;
		public IpcEnumType(JArray json) {
			UnderlyingType = Parse(new JArray(json[2]));
			Options = json[1].Select(x => (x[0].Value<string>(), x[1].Value<int>())).ToDictionary();
		}
	}

	public class IpcStructType : IpcType {
		public readonly IReadOnlyDictionary<string, IpcType> Fields;
		public IpcStructType(JArray json) =>
			Fields = json[1].Select(x => (x[0].Value<string>(), Parse(x[1].Value<JArray>()))).ToDictionary();
	}
	
	public class IpcParameter {
		public readonly string Name;
		public readonly IpcType Type;

		public IpcParameter(JArray arr) {
			Name = arr[0]?.Value<string>();
			Type = IpcType.Parse(arr[1].Value<JArray>());
		}
	}
	
	public class IpcCommand {
		public readonly int CommandId;
		public readonly IReadOnlyList<IpcParameter> Inputs, Outputs;
		public readonly string LastVersion, VersionAdded, VersionRemoved;

		public IpcCommand(JObject obj) {
			CommandId = obj["cmdId"].Value<int>();
			Inputs = obj["inputs"].Select(x => new IpcParameter(x.Value<JArray>())).ToList();
			Outputs = obj["outputs"].Select(x => new IpcParameter(x.Value<JArray>())).ToList();
			LastVersion = obj["lastVersion"]?.Value<string>();
			VersionAdded = obj["versionAdded"]?.Value<string>();
			VersionRemoved = obj["versionRemoved"]?.Value<string>();
		}
	}
	
	public class IpcInterface {
		public readonly string Name;
		public readonly IReadOnlyList<string> Services;
		public readonly IReadOnlyList<IpcCommand> Commands;

		public IpcInterface(string name, IReadOnlyDictionary<string, IReadOnlyList<string>> svcs, JObject obj) {
			Name = name;
			if(svcs.TryGetValue(name, out var svcNames))
				Services = svcNames;
			Commands = obj["cmds"].Select(x => new IpcCommand(x.Value<JObject>())).ToList();
		}
	}

	public class ForwardType {
		readonly string Name;
		readonly Func<IpcType> Resolver;
		IpcType Type;
		public ForwardType(string name, Func<IpcType> resolver) {
			Name = name;
			Resolver = resolver;
		}
		public IpcType Resolve() => Type ??= Resolver().WithName(Name);
	}
	
	public static class IpcDefinitions {
		public static IReadOnlyDictionary<string, IReadOnlyList<string>> Services;
		public static IReadOnlyDictionary<string, ForwardType> ForwardTypes;
		public static IReadOnlyDictionary<string, IpcType> Typedefs;
		public static IReadOnlyDictionary<string, IpcInterface> Interfaces;

		public static IReadOnlyDictionary<string, (IReadOnlyDictionary<string, IpcType> Typedefs,
			IReadOnlyDictionary<string, IpcInterface> Interfaces)> Namespaces;

		public static void Parse(List<JObject> top) {
			Services = top[2].Properties().Select(svc => (svc.Name,
				(IReadOnlyList<string>) svc.Value.Value<JArray>().Select(x => x.ToString()).ToList())).ToDictionary();
			ForwardTypes = top[0].Properties()
				.Select(td => (td.Name, new ForwardType(td.Name, () => IpcType.Parse(td.Value.Value<JArray>()))))
				.ToDictionary();
			ForwardTypes = ForwardTypes.Select(x => (x.Key, x.Value))
				.Concat(ForwardTypes.Keys.Where(x => x.StartsWith("nn::util::BitFlagSet"))
					.Select(x => (x.Split(',')[1].Split('>')[0].Trim(), ForwardTypes[x]))).ToDictionary();
			Typedefs = ForwardTypes.Select(x => (x.Key, x.Value.Resolve())).ToDictionary();
			Interfaces = top[1].Properties()
				.Select(iface => (iface.Name, new IpcInterface(iface.Name, Services, iface.Value.Value<JObject>())))
				.ToDictionary();
			Namespaces = Typedefs.Keys.Concat(Interfaces.Keys)
				.Select(x => x.StartsWith("nn::util::BitFlagSet") ? x.Split(',')[1].Split('>')[0].Trim() : x)
				.Select(x => x.Split("::"))
				.Select(x => string.Join("::", x.Take(x.Length - 1))).Distinct()
				.Select(x => (x,
					((IReadOnlyDictionary<string, IpcType>) Typedefs.Where(y =>
								y.Key.StartsWith(x + "::") && !y.Key.Substring(x.Length + 2).Contains("::"))
							.Select(y => (y.Key.Substring(x.Length + 2), y.Value)).ToDictionary(),
						(IReadOnlyDictionary<string, IpcInterface>) Interfaces.Where(y =>
								y.Key.StartsWith(x + "::") && !y.Key.Substring(x.Length + 2).Contains("::"))
							.Select(y => (y.Key.Substring(x.Length + 2), y.Value)).ToDictionary()))).ToDictionary();
		}
	}

	class Program {
		const string Root = "../Supercell/IpcServices/Generated/";
		
		static void Main(string[] args) {
			Console.WriteLine("Starting SwIPC parse...");
			Process.Start("python",  "-c \"from SwIPC.idparser import getAll; getAll()\"")?.WaitForExit();
			Console.WriteLine("Done!");

			IpcDefinitions.Parse(JsonConvert.DeserializeObject<List<JObject>>(File.ReadAllText("SwIPC/ipcdefs/cache")));
			Console.WriteLine("Definitions loaded");

			try { Directory.Delete(Root, true); } catch(DirectoryNotFoundException) {}
			Directory.CreateDirectory(Root);
			IpcDefinitions.Namespaces.ForEach(kv => Build(kv.Key, kv.Value.Typedefs, kv.Value.Interfaces));
		}
		
		static void Build(string ns, IReadOnlyDictionary<string, IpcType> types, IReadOnlyDictionary<string, IpcInterface> ifaces) {
			bool CustomType(IpcType type) => type is IpcStructType || type is IpcEnumType;

			string GenType(IpcType type, string modifiers = null, bool inStruct = false) {
				if(modifiers != null) modifiers += " ";
				if(CustomType(type)) return Rename(type.Name);
				switch(type) {
					case IpcIntType(var size, var signed):
						if(signed)
							return modifiers + (size switch { 8 => "sbyte", 16 => "short", 32 => "int", 64 => "long", _ =>
								throw new NotImplementedException() });
						else
							return modifiers + (size switch { 8 => "byte", 16 => "ushort", 32 => "uint", 64 => "ulong", _ =>
								throw new NotImplementedException() });
					case IpcBoolType _: return modifiers + "bool";
					case IpcBufferType(var btype, _) when inStruct: return $"{modifiers}{GenType(btype)}[]";
					case IpcBufferType(var btype, var ttype): return $"[Buffer(0x{ttype:X})] {modifiers}Buffer<{GenType(btype)}>";
					case IpcBytesType(var size): return size == -1 ? $"{modifiers}byte[]" : $"[Bytes(0x{size:X})] {modifiers}byte[]";
					default: throw new NotImplementedException(type.ToPrettyString());
				}
			}

			string Rename(string name) => string.Join(".",
				string.Join("",
						name.Replace("::", ".").Split('_').Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1)))
					.Split('.').Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1)));
			
			if(ns == "")
				ns = "Bare";
			//$"Building {ns} -- {types.Count} typedefs, {ifaces.Count} interfaces".Debug();
			using var fp = File.OpenWrite(Path.Combine(Root, $"{ns.Replace("::", ".")}.cs"));
			using var sw = new StreamWriter(fp);
			var cb = new CodeBuilder();
			sw.WriteLine($"namespace Supercell.IpcServices.{Rename(ns)} {{");
			cb++;
			foreach(var (name, type) in types) {
				switch(type) {
					case IpcStructType def: {
						cb += $"public struct {Rename(name)} {{";
						cb++;
						foreach(var (fname, ftype) in def.Fields)
							cb += $"{GenType(ftype, "public", true)} {Rename(fname)};";
						cb--;
						cb += "}";
						break;
					}

					case IpcEnumType def: {
						cb += $"public enum {Rename(name)} : {GenType(def.UnderlyingType)} {{";
						cb++;
						foreach(var (oname, value) in def.Options)
							cb += $"{Rename(oname)} = 0x{value:X}, ";
						cb--;
						cb += "}";
						break;
					}
					default: continue;
				}

				cb += "";
			}
			sw.WriteLine(cb.Code.TrimEnd());
			sw.WriteLine("}");
		}
	}
}