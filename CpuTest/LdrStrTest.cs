using System;
using Xunit;

namespace CpuTest {
	public class LdrStrTest {
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
	}
}