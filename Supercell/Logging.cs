using System;
using Common;

namespace Supercell {
	public class Logging {
		public void Exclusive(Action cb) {
			lock(this)
				cb();
		}

		public void Log(string msg) {
			lock(this)
				Console.WriteLine($"[{Thread.CurrentThread.Id}]  {msg}");
		}
	}
}