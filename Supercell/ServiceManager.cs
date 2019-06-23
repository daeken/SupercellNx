using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common;
using MoreLinq;

namespace Supercell {
	[AttributeUsage(AttributeTargets.Method)]
	public class SvcAttribute : Attribute {
		public readonly int Svc;
		public SvcAttribute(int svc) => Svc = svc;
	}
	
	public class ServiceManager {
		readonly Dictionary<int, Action> Handlers = new Dictionary<int, Action>();
		
		public ServiceManager() {
			var cpu = Kernel.Cpu;
			Action<object> BuildRetHandler(Type rt) {
				Action<object> BuildSetter(Type s, int i) {
					if(s == typeof(uint)) return ret => cpu.X[i] = (ulong) (uint) ret;
					if(s == typeof(ulong)) return ret => cpu.X[i] = (ulong) ret;
					throw new NotSupportedException();
				}
				if(rt == typeof(void)) return _ => { };
				if(rt == typeof(uint)) return ret => cpu.X[0] = (ulong) (uint) ret;
				if(rt == typeof(ulong)) return ret => cpu.X[0] = (ulong) ret;
				if(rt.IsConstructedGenericType && rt.GetGenericTypeDefinition() == typeof(ValueTuple<,>)) {
					var setters = rt.GetGenericArguments().Select(BuildSetter).ToArray();
					return (dynamic ret) => {
						setters[0](ret.Item1);
						setters[1](ret.Item2);
					};
				}
				if(rt.IsConstructedGenericType && rt.GetGenericTypeDefinition() == typeof(ValueTuple<,,>)) {
					var setters = rt.GetGenericArguments().Select(BuildSetter).ToArray();
					return (dynamic ret) => {
						setters[0](ret.Item1);
						setters[1](ret.Item2);
						setters[2](ret.Item3);
					};
				}
				if(rt.IsConstructedGenericType && rt.GetGenericTypeDefinition() == typeof(ValueTuple<,,,>)) {
					var setters = rt.GetGenericArguments().Select(BuildSetter).ToArray();
					return (dynamic ret) => {
						setters[0](ret.Item1);
						setters[1](ret.Item2);
						setters[2](ret.Item3);
						setters[3](ret.Item4);
					};
				}
				throw new NotImplementedException(rt.FullName);
			}
			
			AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.SelectMany(x => x.GetMethods(BindingFlags.Instance | BindingFlags.Public))
				.Where(x => x.GetCustomAttributes(typeof(SvcAttribute)).Count() != 0)
				.ForEach(x => {
					var attr = x.GetCustomAttribute<SvcAttribute>();
					var argParsers = x.GetParameters().Select<ParameterInfo, Func<ulong, object>>((p, i) => {
						var t = p.ParameterType;
						if(t == typeof(uint))
							return reg => (uint) reg;
						return reg => reg;
					}).ToArray();
					var rethandler = BuildRetHandler(x.ReturnType);
					var instance = x.DeclaringType.GetField("Instance",
						BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null);
					instance ??=
						typeof(Kernel)
							.GetFields(BindingFlags.Public | BindingFlags.Static)
							.FirstOrDefault(y => y.FieldType == x.DeclaringType)?.GetValue(null);
					if(x.ReturnType == typeof(void))
						Handlers[attr.Svc] = () => {
							var args = argParsers.Select((x, i) => x(cpu.X[i])).ToArray();
							x.Invoke(instance, args);
						};
					else
						Handlers[attr.Svc] = () => {
							var args = argParsers.Select((x, i) => x(cpu.X[i])).ToArray();
							rethandler(x.Invoke(instance, args));
						};
				});
		}
		
		public void Svc(int svc) {
			if(Handlers.ContainsKey(svc))
				Handlers[svc]();
			else
				throw new NotImplementedException($"Unknown svc call 0x{svc:X}");
		}
	}
}