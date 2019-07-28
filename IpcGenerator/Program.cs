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
				case "pid": return new IpcPidType();

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

	public class IpcPidType : IpcType {
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

		public IpcParameter(string name, IpcType type) {
			Name = name;
			Type = type;
		}
	}
	
	public class IpcCommand {
		public readonly int CommandId;
		public readonly string Name;
		public IReadOnlyList<IpcParameter> Inputs, Outputs;
		public readonly uint LastVersion, VersionAdded, VersionRemoved;

		static uint ParseVersion(string version, uint @default = 0) {
			if(version == null) return @default;
			var elems = version.Split('.').Select(int.Parse).ToList();
			return (uint) ((elems[0] << 16) | (elems[1] << 8) | elems[2]);
		}
		
		public IpcCommand(JObject obj) {
			CommandId = obj["cmdId"].Value<int>();
			Name = obj["name"].Value<string>();
			Inputs = obj["inputs"].Select(x => new IpcParameter(x.Value<JArray>())).ToList();
			Outputs = obj["outputs"].Select(x => new IpcParameter(x.Value<JArray>())).ToList();
			LastVersion = ParseVersion(obj["lastVersion"]?.Value<string>(), uint.MaxValue);
			VersionAdded = ParseVersion(obj["versionAdded"]?.Value<string>());
			VersionRemoved = ParseVersion(obj["versionRemoved"]?.Value<string>(), uint.MaxValue);
		}
	}
	
	public class IpcInterface {
		public readonly string Name;
		public readonly IReadOnlyList<string> Services;
		public readonly IReadOnlyList<IpcCommand> Commands;

		public IpcInterface(string name, IReadOnlyDictionary<string, IReadOnlyList<string>> svcs, JObject obj) {
			Name = name;
			Services = svcs.TryGetValue(name, out var svcNames) ? svcNames : new List<string>();
			Commands = obj["cmds"].Select(x => new IpcCommand(x.Value<JObject>())).ToList();
		}

		public IpcInterface(string name, IReadOnlyList<string> services, IReadOnlyList<IpcCommand> commands) {
			Name = name;
			Services = services;
			Commands = commands;
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

		static IpcInterface RemoveDuplicates(IpcInterface iface) =>
			new IpcInterface(iface.Name, iface.Services, iface.Commands.Where((command, i) =>
				!iface.Commands.Select((x, j) => (x, j)).Where(x =>
						x.x != command && (x.x.Name == command.Name || x.x.CommandId == command.CommandId))
					.Any(other =>
						other.x.LastVersion > command.LastVersion || other.x.VersionRemoved > command.VersionRemoved ||
						other.x.VersionAdded > command.VersionAdded ||
						(other.j < i && other.x.LastVersion == command.LastVersion &&
						 other.x.VersionRemoved == command.VersionRemoved &&
						 other.x.VersionAdded == command.VersionAdded))).Select(RemoveDuplicateArgs).ToList());

		static IpcCommand RemoveDuplicateArgs(IpcCommand command) {
			var present = new HashSet<string>();
			var dupes = new HashSet<string>();
			foreach(var param in command.Inputs.Concat(command.Outputs))
				if(present.Contains(param.Name))
					dupes.Add(param.Name);
				else
					present.Add(param.Name);
			var per = dupes.Where(x => x != null).Select(x => (x, 0)).ToDictionary();
			var all = command.Inputs.Concat(command.Outputs).Select(x =>
				new IpcParameter(x.Name != null && per.ContainsKey(x.Name) ? $"{x.Name}{per[x.Name]++}" : x.Name, x.Type)).ToList();
			command.Inputs = all.GetRange(0, command.Inputs.Count);
			command.Outputs = all.GetRange(command.Inputs.Count, command.Outputs.Count);
			return command;
		}

		static void Build(string ns, IReadOnlyDictionary<string, IpcType> types, IReadOnlyDictionary<string, IpcInterface> ifaces) {
			string GenType(IpcType type, string modifiers = null, bool inStruct = false) {
				if(modifiers != null) modifiers += " ";
				switch(type) {
					case IpcIntType(var size, var signed):
						if(signed)
							return modifiers + (size switch {
								8 => "sbyte", 16 => "short", 32 => "int", 64 => "long", 128 => "Int128", _ =>
								throw new NotImplementedException()
							});
						else
							return modifiers + (size switch {
								8 => "byte", 16 => "ushort", 32 => "uint", 64 => "ulong", 128 => "UInt128", _ =>
								throw new NotImplementedException()
							});
					case IpcFloatType(var size): return modifiers + (size == 64 ? "double" : "float");
					case IpcBoolType _: return modifiers + "bool";
					case IpcBufferType(IpcBytesType _, _): return $"Buffer<byte>";
					case IpcBufferType(IpcUnknownType _, _): return $"Buffer<byte>";
					case IpcBufferType(var btype, _): return $"Buffer<{GenType(btype).TrimEnd('*')}>";
					case IpcBytesType(_) when inStruct: throw new NotSupportedException();
					case IpcBytesType(_): return $"{modifiers}byte[]";
					case IpcHandleType(HandleStyle.Copy, var htype): return $"{modifiers}{(htype == null ? "KObject" : GenType(htype))}";
					case IpcHandleType(HandleStyle.Move, var htype): return $"{modifiers}{(htype == null ? "IpcInterface" : GenType(htype))}";
					case IpcObjectType(var iface): return modifiers + (iface == "unknown" ? "IpcInterface" : Rename(iface));
					case IpcPidType _: return modifiers + "ulong";
					case IpcEnumType et: return modifiers + Rename(et.Name);
					case IpcStructType et when inStruct: return modifiers + Rename(et.Name);
					case IpcStructType et: return modifiers + Rename(et.Name) + "*";
					case IpcUnknownType _: return modifiers + "object";
					default: throw new NotImplementedException(type.ToPrettyString());
				}
			}

			string Rename(string name) {
				if(name.ToLower() == "close") return "_Close";
				return string.Join(".",
					string.Join("",
							name.Replace("::", ".").Split('_')
								.Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1)))
						.Split('.').Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1)));
			}

			if(ns == "")
				ns = "Bare";
			//$"Building {ns} -- {types.Count} typedefs, {ifaces.Count} interfaces".Debug();
			using var fp = File.OpenWrite(Path.Combine(Root, $"{ns.Replace("::", ".")}.cs"));
			using var sw = new StreamWriter(fp);
			var cb = new CodeBuilder();
			sw.WriteLine("#pragma warning disable 169, 465");
			sw.WriteLine("using System;");
			sw.WriteLine("using UltimateOrb;");
			sw.WriteLine("using static Supercell.Globals;");
			sw.WriteLine($"namespace Supercell.IpcServices.{Rename(ns)} {{");
			cb++;
			foreach(var (name, type) in types) {
				switch(type) {
					case IpcStructType def: {
						cb += $"public unsafe struct {Rename(name)} {{";
						cb++;
						foreach(var (fname, ftype) in def.Fields) {
							if(ftype is IpcBytesType bytes) {
								if(bytes.Size == -1)
									cb += $"public byte _{Rename(fname)};";
								else
									cb += $"public fixed byte {Rename(fname)}[{bytes.Size}];";
							} else if(ftype is IpcBufferType btype) {
								
							} else
								cb += $"{GenType(ftype, "public", true)} {Rename(fname)};";
						}
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

			foreach(var (name, _iface) in ifaces.OrderBy(x => x.Value.Services.Count != 0 ? 0 : 1).ThenBy(x => x.Key)) {
				var iface = RemoveDuplicates(_iface);
				foreach(var sname in iface.Services)
					cb += $"[IpcService({sname.ToPrettyString()})]";
				cb += $"public unsafe partial class {Rename(name)} : _Base_{Rename(name)} {{}}";
				cb += $"public unsafe class _Base_{Rename(name)} : IpcInterface {{";
				cb++;
				cb += "public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {";
				cb++;
				cb += "switch(im.CommandId) {";
				cb++;
				
				foreach(var command in iface.Commands) {
					cb += $"case {command.CommandId}: {{ // {Rename(command.Name)}";
					cb++;

					var hasRet = command.Outputs.Count == 1 &&
					             !(command.Outputs[0].Type is IpcBufferType || command.Outputs[0].Type is IpcBytesType);
					var args = new List<string>();
					var outI = 0;
					var inputOffset = 8;
					var moveInOffset = 0;
					var copyInOffset = 0;
					var outputOffset = 8;
					var moveOutOffset = 0;
					var copyOutOffset = 0;
					var outputHandlers = new List<string>();
					var bufferNums = new Dictionary<int, int>();

					string GenInputArg(IpcType type) {
						void Align(int align) {
							while(inputOffset % align != 0)
								inputOffset++;
						}
						switch(type) {
							case IpcBoolType _: {
								var ret = $"im.GetData<bool>({inputOffset})";
								inputOffset += 4;
								return ret;
							}
							case IpcBufferType(var btype, var ttype):
								if(!bufferNums.ContainsKey(ttype))
									bufferNums[ttype] = 0;
								var cbo = bufferNums[ttype];
								bufferNums[ttype]++;
								return $"im.Get{GenType(type)}(0x{ttype:X}, {cbo})";
							case IpcBytesType(var size): {
								var ret = $"im.GetBytes({inputOffset}, 0x{size:X})";
								inputOffset += size;
								return ret;
							}
							case IpcEnumType et: {
								if(!(et.UnderlyingType is IpcIntType(var size, _)))
									throw new NotImplementedException();
								Align(size / 8);
								var ret = $"im.GetData<{GenType(et)}>({inputOffset})";
								inputOffset += size / 8;
								return ret;
							}
							case IpcFloatType(var size): {
								Align(size / 8);
								var ret = $"im.GetData<{GenType(type)}>({inputOffset})";
								inputOffset += size / 8;
								return ret;
							}
							case IpcHandleType(var style, var htype):
								return style == HandleStyle.Copy
									? $"Kernel.Get<{(htype == null ? "KObject" : GenType(htype))}>(im.GetCopy({copyInOffset++}))"
									: $"Kernel.Get<{(htype == null ? "KObject" : GenType(htype))}>(im.GetMove({moveInOffset++}))";
							case IpcIntType(var size, var signed): {
								Align(type.Alignment == -1 ? size / 8 : type.Alignment);
								var ret = $"im.GetData<{GenType(type)}>({inputOffset})";
								inputOffset += size / 8;
								return ret;
							}
							case IpcObjectType(var iname):
								return $"Kernel.Get<{Rename(iname)}>(im.GetMove({moveInOffset++}))";
							case IpcPidType _: return "im.Pid";
							case IpcStructType st: return $"({GenType(st)}) im.GetDataPointer({inputOffset})"; // TODO: Inc offset
							case IpcUnknownType _: return "null";
							default: throw new NotImplementedException($"Unknown type for GenInputArg: {type}");
						}
					}

					string GenOutputArg(IpcType type, bool isRet = false) {
						void Align(int align) {
							while(outputOffset % align != 0)
								outputOffset++;
						}
						var vname = isRet ? "ret" : $"_{outI++}";
						switch(type) {
							case IpcBoolType _:
								outputHandlers.Add($"om.SetData({outputOffset}, {vname});");
								outputOffset += 4;
								break;
							case IpcBufferType(_, var ttype):
								if(!bufferNums.ContainsKey(ttype))
									bufferNums[ttype] = 0;
								var cbo = bufferNums[ttype];
								bufferNums[ttype]++;
								return $"im.Get{GenType(type)}(0x{ttype:X}, {cbo})";
							case IpcBytesType(var size):
								Debug.Assert(size != -1);
								outputHandlers.Add($"om.SetBytes({outputOffset}, {vname});");
								outputOffset += size;
								break;
							case IpcEnumType et:
								if(!(et.UnderlyingType is IpcIntType(var esize, _)))
									throw new NotImplementedException();
								Align(esize / 8);
								outputHandlers.Add($"om.SetData({outputOffset}, {vname});");
								outputOffset += esize / 8;
								break;
							case IpcStructType _:
								Align(type.Alignment == -1 ? 8 : type.Alignment);
								return $"({GenType(type)}) om.GetDataPointer({outputOffset})"; // TODO: Inc offset
							case IpcFloatType(var size):
								Align(type.Alignment == -1 ? size / 8 : type.Alignment);
								outputHandlers.Add($"om.SetData({outputOffset}, {vname});");
								outputOffset += size / 8;
								break;
							case IpcIntType(var size, _):
								Align(type.Alignment == -1 ? size / 8 : type.Alignment);
								outputHandlers.Add($"om.SetData({outputOffset}, {vname});");
								outputOffset += size / 8;
								break;
							case IpcHandleType(var style, _):
								if(style == HandleStyle.Copy)
									outputHandlers.Add($"om.Copy({copyOutOffset++}, CreateHandle({vname}, copy: true));");
								else
									outputHandlers.Add($"om.Move({moveOutOffset++}, CreateHandle({vname}));");
								break;
							case IpcObjectType(_):
								outputHandlers.Add($"om.Move({moveOutOffset++}, CreateHandle({vname}));");
								break;
							case IpcUnknownType _: break;
							default: throw new NotImplementedException($"Unknown type for GenOutputArg: {type}");
						}
						return $"out var {vname}";
					}
					foreach(var elem in command.Inputs)
						if(GenInputArg(elem.Type) is var arg)
							args.Add(arg);
					if(!hasRet) {
						foreach(var elem in command.Outputs)
							if(GenOutputArg(elem.Type) is var arg)
								args.Add(arg);
					} else
						GenOutputArg(command.Outputs[0].Type, true);

					cb += $"{(hasRet ? "var ret = " : "")}{Rename(command.Name)}({string.Join(", ", args)});";
					cb += $"om.Initialize({moveOutOffset}, {copyOutOffset}, {outputOffset - 8});";
					foreach(var line in outputHandlers)
						cb += line;
					cb += "break;";
					cb--;
					cb += "}";
				}
				
				cb += "default:";
				cb++;
				cb += $"throw new NotImplementedException($\"Unhandled command ID to {Rename(name)}: {{im.CommandId}}\");";
				cb--;

				cb--;
				cb += "}";
				cb--;
				cb += "}";
				cb += "";
				foreach(var command in iface.Commands) {
					var rettype = command.Outputs.Count == 1 &&
					              !(command.Outputs[0].Type is IpcBufferType || command.Outputs[0].Type is IpcBytesType)
						? GenType(command.Outputs[0].Type)
						: "void";
					var args = command.Inputs.Select((x, i) => $"{GenType(x.Type)} {x.Name ?? $"_{i}"}");
					if(rettype == "void")
						args = args.Concat(command.Outputs.Select((x, i) => $"{GenType(x.Type, x.Type is IpcStructType ? "" : "out")} {(x.Name == null && x.Type is IpcPidType ? "pid" : x.Name ?? $"_{command.Inputs.Count + i}")}"));
					var impl = command.Outputs.Count == 0 ? $"\"Stub hit for {Rename(ns)}.{Rename(name)}.{Rename(command.Name)} [{command.CommandId}]\".Debug()" : "throw new NotImplementedException()";
					cb += $"public virtual {rettype} {Rename(command.Name)}({string.Join(", ", args)}) => {impl};";
				}
				cb--;
				cb += "}";
				cb += "";
			}
			
			sw.WriteLine(cb.Code.TrimEnd());
			sw.WriteLine("}");
		}
	}
}