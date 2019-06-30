using System.IO;
using System.Threading.Tasks;

namespace GdbStub {
	public static class Extensions {
		public static async Task<byte> ReadByteAsync(this Stream stream) {
			var buf = new byte[1];
			while(await stream.ReadAsync(buf, 0, 1) == 0) {}
			return buf[0];
		}
	}
}