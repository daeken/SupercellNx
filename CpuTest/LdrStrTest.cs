using System;
using Common;
using Xunit;
using Xunit.Abstractions;

namespace CpuTest {
	public class LdrStrTest {
		readonly ITestOutputHelper Output;
		public LdrStrTest(ITestOutputHelper output) => Output = output;
		
		[Fact]
		public unsafe void LdrSxtw() {
			void MTest(int offset) {
				var size = 4096;
				// LDR X0, [X8,W19,SXTW#3]
				InsnTester.Map((uint) size, maddr => InsnTester.Test(0xF873D900, (cpu, addr) => {
					var bytes = new Span<byte>((void*) maddr, size);
					for(var i = 0; i < bytes.Length; ++i)
						bytes[i] = (byte) (i % 255 + 1);
					if(cpu == null) return;
					cpu.X[8] = maddr + 512;
					cpu.X[19] = unchecked((ulong) offset);
				}));
			}
			MTest(13);
			MTest(-17);
			MTest(0);
		}
		
		[Fact]
		public unsafe void Ldrsb() {
			void MTest(byte value) {
				var size = 4096;
				// LDRSB W8, [X0,#0x84]
				InsnTester.Map((uint) size, maddr => InsnTester.Test(0x39C21008, (cpu, addr) => {
					var bytes = new Span<byte>((void*) maddr, size) { [0x84] = value };
					if(cpu == null) return;
					cpu.X[0] = maddr;
				}));
			}
			MTest(0xFF);
			MTest(0);
			MTest(0x80);
			MTest(0x56);
		}

		[Fact]
		public unsafe void Ldp() {
			var size = 4096;
			// LDP W11, W13, [X11,#4]
			InsnTester.Disassembly("ldp W11, W13, [X11, #0x4]", 0x2940B56B);
			InsnTester.Map((uint) size, maddr => InsnTester.Test(0x2940B56B, (cpu, addr) => {
				var bytes = new Span<byte>((void*) maddr, size);
				for(var i = 0; i < bytes.Length; ++i)
					bytes[i] = (byte) (i % 255 + 1);
				if(cpu == null) return;
				cpu.X[11] = maddr;
			}));
		}

		[Fact]
		public unsafe void LdrSimd() {
			var size = 40960;
			// LDR S1, [X8,#0xD08]
			InsnTester.Disassembly("ldr S1, [X8, #0xD08]", 0xBD4D0901);
			InsnTester.Map((uint) size, maddr => InsnTester.Test(0xBD4D0901, (cpu, addr) => {
				var bytes = new Span<byte>((void*) maddr, size);
				for(var i = 0; i < bytes.Length; ++i)
					bytes[i] = (byte) (i % 255 + 1);
				if(cpu == null) return;
				cpu.X[8] = maddr;
			}));
		}

		[Fact]
		public unsafe void LdpSimd() {
			var size = 4096;
			// LDP Q1, Q0, [X29,#-0x30]
			InsnTester.Disassembly("ldp Q1, Q0, [X29, #-0x30]", 0xAD7E83A1);
			InsnTester.Map((uint) size, maddr => InsnTester.Test(0xAD7E83A1, (cpu, addr) => {
				var bytes = new Span<byte>((void*) maddr, size);
				for(var i = 0; i < bytes.Length; ++i)
					bytes[i] = (byte) (i % 255 + 1);
				if(cpu == null) return;
				cpu.X[29] = maddr + 0x60;
			}));
		}
	}
}