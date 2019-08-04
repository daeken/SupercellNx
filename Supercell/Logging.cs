using System;
using System.Threading;
using Common;

namespace Supercell {
	public class Logging {
		public void Kill() {
			Monitor.Enter(this);
		}
		
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