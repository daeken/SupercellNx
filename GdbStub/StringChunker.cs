using System;
using System.Globalization;
using System.Linq;

namespace GdbStub {
	public class StringChunker {
		readonly string Data;
		int Pos;

		public StringChunker(string data) => Data = data;

		public char ReadChar() => Data[Pos++];

		public string ReadUntil(char end, bool required = true, bool skipEnd = true) {
			var start = Pos;
			while(Pos != Data.Length && Data[Pos] != end) Pos++;
			if(required && Pos == Data.Length) throw new Exception($"Ran out of data processing '{Data}'");
			var val = Data.Substring(start, Pos - start);
			if(skipEnd) Pos++;
			return val;
		}

		public string ReadToEnd() {
			var start = Pos;
			Pos = Data.Length;
			return Data.Substring(start);
		}

		public string ReadHexStringUntil(char end, bool required = true, bool skipEnd = true) {
			var sub = ReadUntil(end, required, skipEnd);
			return string.Join("", Enumerable.Range(0, sub.Length).Where((x, i) => i % 2 == 0).Select(i => (char) byte.Parse(sub.Substring(i, 2), NumberStyles.HexNumber)));
		}

		public void SkipWhitespace() {
			while(Pos < Data.Length && Data[Pos] == ' ') Pos++;
		}

		public byte ParseHexByte(string data) =>
			byte.Parse(data, NumberStyles.HexNumber);

		public uint ParseHexUint(string data) =>
			uint.Parse(data, NumberStyles.HexNumber);

		public ulong ParseHexUlong(string data) =>
			ulong.Parse(data, NumberStyles.HexNumber);
	}
}