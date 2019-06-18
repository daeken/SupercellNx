using System;
using System.IO;
using System.Runtime.InteropServices;
using Common;
using Cpu64;

namespace App {
	class Program {
		[DllImport("libc")]
		static extern ulong mmap(ulong addr, ulong len, int prot, int flags, int fd, ulong offset);
		
		static unsafe void Main(string[] args) {
			var main = Nxo.Load(File.OpenRead(args[0]));
			
			var addr = mmap(0x7100000000, ((ulong) main.Data.Length & ~0xFFFU) + 0x1000U, 1 | 2, 0x1000 | 0x0001, 0, 0);
			if(addr != 0x7100000000) throw new Exception("Couldn't map binary to base addr");

			var root = (byte*) addr;
			foreach(var v in main.Data)
				*root++ = v;

			var cpu = new Interpreter();
			cpu.SP = (ulong) (Marshal.AllocHGlobal(1024 * 1024) + 1024 * 1024);
			cpu.PC = 0x7100000024UL;
			while(true) {
				var before = cpu.PC;
				var inst = *(uint*) cpu.PC;
				var asm = cpu.Disassemble(inst, cpu.PC);
				if(asm == null) {
					$"Disassembly failed at {cpu.PC:X} --- {inst:X8}".Debug();
					break;
				}
				$"{cpu.PC:X}: {asm}".Debug();
				cpu.Interpret(inst, cpu.PC);
				if(before == cpu.PC)
					cpu.PC += 4;
			}
		}
	}
}