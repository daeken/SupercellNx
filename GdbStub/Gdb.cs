using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GdbStub {
	public class Gdb<TargetT> where TargetT : IDebugTarget {
		readonly TargetT Target;
		readonly NetworkStream Client;
		readonly string HexFormat;

		public Gdb(TargetT target, IPEndPoint endpoint) {
			Target = target;
			HexFormat = $"{{0:X0{Target.RegisterSize / 4}}}";
			var listener = new TcpListener(endpoint);
			listener.Start();
			Error.WriteLine($"Waiting on {endpoint} for GDB client");
			Client = new NetworkStream(listener.AcceptSocket());
			Error.WriteLine($"Got connection");

			Target.Trapped += type => SendSignal(type);
		}

		string RevHex(string hex) =>
			string.Join("", Enumerable.Range(0, hex.Length).Where(i => i % 2 == 0).Select(i => hex[hex.Length - i - 2].ToString() + hex[hex.Length - i - 1].ToString()));

		string Hex(object value) => RevHex(string.Format(HexFormat, value));

		string CalculateChecksum(string cmd) => $"{cmd.Select(x => (byte) x).Aggregate((a, x) => unchecked((byte) (a + x))):x2}";

		void Reply(string resp) {
			//Error.WriteLine($"Replying with: '{resp}'");
			Client.Write(Encoding.ASCII.GetBytes($"${resp}#{CalculateChecksum(resp)}"));
		}

		void SendSignal(TrapType trap) {
			var tr = Target.Registers;
			var signal = 0;
			switch(trap) {
				case TrapType.Breakpoint:
				case TrapType.SingleStep:
					signal = 5;
					break;
				case TrapType.Segfault:
					signal = 11;
					break;
			}

			Reply($"T{signal:X02}{tr.RegisterNumber(tr.PcRegister):X02}:{Hex(Target[tr.PcRegister])};{tr.RegisterNumber(tr.SpRegister):X02}:{Hex(Target[tr.SpRegister])};thread:{Target.ThreadId:X}");
		}

		void ProcessCommand(string cmd) {
			//Error.WriteLine($"Got command: '{cmd}'");
			var sc = new StringChunker(cmd);

			switch(sc.ReadChar()) {
				case '!':
					Reply("OK");
					break;
				case 'q':
					switch(sc.ReadUntil(':', required: false)) {
						case "Supported":
							var features = sc.ReadToEnd().Split(';');
							//Error.WriteLine($"Client supports: {string.Join(", ", features)}");
							Reply("PacketSize=10000");
							break;
						case "C":
							Reply($"QC {Target.ThreadId:X}");
							break;
						case "fThreadInfo":
							Reply($"m {string.Join(',', Target.Threads.Keys.Select(x => $"{x:X}"))}");
							break;
						case "sThreadInfo":
							Reply("l");
							break;
						case string x:
							Error.WriteLine($"Unknown query type: '{x}'");
							break;
					}
					break;
				case 'H':
					switch(sc.ReadChar()) {
						case 'g': // Set thread
							var t = sc.ParseHexUint(sc.ReadToEnd());
							//Error.WriteLine($"[Fake] Setting thread to {t}");
							Reply("OK");
							break;
						case 'c': // Continue
							Target.Continue();
							break;
						default:
							Reply("E01");
							break;
					}
					break;
				case 'v':
					switch(sc.ReadUntil(';', required: false)) {
						case "Cont?":
							Reply("vCont;c;s;t");
							break;
						case "Cont":
							switch(sc.ReadUntil(':', required: false)) {
								case "c":
									Target.Continue();
									break;
								case "s":
									Target.SingleStep();
									break;
							}
							break;
					}
					break;
				case 'p':
					sc.SkipWhitespace();
					var rnum = (int) sc.ParseHexUint(sc.ReadToEnd());
					if(!Target.Registers.NumberToName.ContainsKey(rnum)) {
						Reply(new string('x', Target.RegisterSize / 4));
						break;
					}
					var name = Target.Registers.NumberToName[rnum];
					//Error.WriteLine($"Attempting to read register {name}");
					Reply(Hex(Target[name]));
					break;
				case 'g':
					var ret = "";
					foreach(var reg in Target.Registers.Registers)
						ret += Hex(Target[reg.Name]);
					Reply(ret);
					break;
				case 'm':
					var data = Target.ReadMemory(sc.ParseHexUlong(sc.ReadUntil(',')), sc.ParseHexUint(sc.ReadToEnd()));
					var mret = string.Join("", data.Select(x => $"{x:X02}"));
					Reply(mret);
					break;
				case 'M':
					var addr = sc.ParseHexUlong(sc.ReadUntil(','));
					var size = sc.ParseHexUint(sc.ReadUntil(':'));
					var buf = new byte[size];
					for(var i = 0; i < size; ++i)
						buf[i] = sc.ParseHexByte(sc.ReadChar().ToString() + sc.ReadChar());
					Target.WriteMemory(addr, buf);
					Reply("OK");
					break;
				case '?':
					SendSignal(TrapType.None);
					break;
				case 'c':
					Target.Continue();
					break;
				case '\xFF':
				case 'k':
					Environment.Exit(0);
					break;
			}
		}

		public void Run() {
			while(true) {
				switch((char) Client.ReadByte()) {
					case '+': // ACK -- ignore
						break;
					case '\x03': // Remote break
						Target.BreakIn();
						break;
					case '$':
						var buf = "";
						while(true) {
							var x = (char) Client.ReadByte();
							if(x == '#')
								break;
							buf += x;
						}
						var recvChecksum = $"{(char) Client.ReadByte()}{(char) Client.ReadByte()}";
						Debug.Assert(recvChecksum == CalculateChecksum(buf));
						Client.WriteByte((byte) '+');
						ProcessCommand(buf);
						break;
					case char x:
						throw new Exception($"Invalid start of gdb message: {(byte) x:X}");
				}
			}
		}
	}
}