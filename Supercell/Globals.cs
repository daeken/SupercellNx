namespace Supercell {
	public static class Globals {
		public static readonly MemoryManager Memory = new MemoryManager();
		public static readonly MicroKernel Kernel = new MicroKernel();
		public static readonly ThreadManager Threading = new ThreadManager();
		static readonly Thread InitialThread = new Thread();
		public static readonly IpcManager Ipc = new IpcManager();
		public static readonly ServiceManager Service = new ServiceManager();
	}
}