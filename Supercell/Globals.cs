using System.Runtime.InteropServices;
using Supercell.Gpu;

namespace Supercell {
	public static class Globals {
		public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
		public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
		public static readonly Logging Logger = new Logging();
		public static readonly GpuCore GpuInstance = new GpuCore();
		public static readonly MemoryManager Memory = new MemoryManager();
		public static readonly MicroKernel Kernel = new MicroKernel();
		public static readonly ThreadManager Threading = new ThreadManager();
		static readonly Thread InitialThread = new Thread();
		public static readonly IpcManager Ipc = new IpcManager();
		public static readonly ServiceManager Service = new ServiceManager();
	}
}