using System;
using System.Collections.Generic;
using System.Linq;

namespace GdbStub {
	public abstract class RegisterSet {
		public abstract List<(Type Type, string Name)> Registers { get; }
		public abstract string PcRegister { get; }
		public abstract string SpRegister { get; }

		public readonly Dictionary<string, int> NameToNumber;
		public readonly Dictionary<int, string> NumberToName;

		public RegisterSet() {
			NameToNumber = Registers.Select((x, i) => (x, i)).ToDictionary(x => x.Item1.Name, x => x.Item2);
			NumberToName = Registers.Select((x, i) => (x, i)).ToDictionary(x => x.Item2, x => x.Item1.Name);
		}
		
		public int RegisterNumber(string name) =>
			Registers.Select((x, i) => (x, i)).First(x => x.Item1.Name == name).Item2;
	}

	public class X86RegisterSet : RegisterSet {
		public static readonly X86RegisterSet Instance = new X86RegisterSet();

		public override List<(Type Type, string Name)> Registers { get; } = new List<(Type Type, string Name)> {
			(typeof(uint), "EAX"), 
			(typeof(uint), "ECX"), 
			(typeof(uint), "EDX"), 
			(typeof(uint), "EBX"), 
			(typeof(uint), "ESP"), 
			(typeof(uint), "EBP"), 
			(typeof(uint), "ESI"), 
			(typeof(uint), "EDI"), 
			(typeof(uint), "EIP"), 
			(typeof(uint), "EFLAGS"), 
			(typeof(ushort), "CS"), 
			(typeof(ushort), "DS"), 
			(typeof(ushort), "ES"), 
			(typeof(ushort), "FS"), 
			(typeof(ushort), "GS"), 
			(typeof(ushort), "SS")
		};

		public override string PcRegister => "EIP";
		public override string SpRegister => "ESP";
	}

	public class Arm64RegisterSet : RegisterSet {
		public static readonly Arm64RegisterSet Instance = new Arm64RegisterSet();

		public override List<(Type Type, string Name)> Registers { get; } = new List<(Type Type, string Name)> {
			(typeof(ulong), "X0"), 
			(typeof(ulong), "X1"), 
			(typeof(ulong), "X2"), 
			(typeof(ulong), "X3"), 
			(typeof(ulong), "X4"), 
			(typeof(ulong), "X5"), 
			(typeof(ulong), "X6"), 
			(typeof(ulong), "X7"), 
			(typeof(ulong), "X8"), 
			(typeof(ulong), "X9"), 
			(typeof(ulong), "X10"), 
			(typeof(ulong), "X11"), 
			(typeof(ulong), "X12"), 
			(typeof(ulong), "X13"), 
			(typeof(ulong), "X14"), 
			(typeof(ulong), "X15"), 
			(typeof(ulong), "X16"), 
			(typeof(ulong), "X17"), 
			(typeof(ulong), "X18"), 
			(typeof(ulong), "X19"), 
			(typeof(ulong), "X20"), 
			(typeof(ulong), "X21"), 
			(typeof(ulong), "X22"), 
			(typeof(ulong), "X23"), 
			(typeof(ulong), "X24"), 
			(typeof(ulong), "X25"), 
			(typeof(ulong), "X26"), 
			(typeof(ulong), "X27"), 
			(typeof(ulong), "X28"), 
			(typeof(ulong), "X29"), 
			(typeof(ulong), "X30"), 
			(typeof(uint), "CPSR")
		};

		public override string PcRegister => "PC";
		public override string SpRegister => "SP";
	}
}