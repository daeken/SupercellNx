using System;
using System.Runtime.InteropServices;

namespace UnicornSharp {
	internal enum Err {
		UC_ERR_OK = 0,   // No error: everything was fine
		UC_ERR_NOMEM,      // Out-Of-Memory error: uc_open(), uc_emulate()
		UC_ERR_ARCH,     // Unsupported architecture: uc_open()
		UC_ERR_HANDLE,   // Invalid handle
		UC_ERR_MODE,     // Invalid/unsupported mode: uc_open()
		UC_ERR_VERSION,  // Unsupported version (bindings)
		UC_ERR_READ_UNMAPPED, // Quit emulation due to READ on unmapped memory: uc_emu_start()
		UC_ERR_WRITE_UNMAPPED, // Quit emulation due to WRITE on unmapped memory: uc_emu_start()
		UC_ERR_FETCH_UNMAPPED, // Quit emulation due to FETCH on unmapped memory: uc_emu_start()
		UC_ERR_HOOK,    // Invalid hook type: uc_hook_add()
		UC_ERR_INSN_INVALID, // Quit emulation due to invalid instruction: uc_emu_start()
		UC_ERR_MAP, // Invalid memory mapping: uc_mem_map()
		UC_ERR_WRITE_PROT, // Quit emulation due to UC_MEM_WRITE_PROT violation: uc_emu_start()
		UC_ERR_READ_PROT, // Quit emulation due to UC_MEM_READ_PROT violation: uc_emu_start()
		UC_ERR_FETCH_PROT, // Quit emulation due to UC_MEM_FETCH_PROT violation: uc_emu_start()
		UC_ERR_ARG,     // Inavalid argument provided to uc_xxx function (See specific function API)
		UC_ERR_READ_UNALIGNED,  // Unaligned read
		UC_ERR_WRITE_UNALIGNED,  // Unaligned write
		UC_ERR_FETCH_UNALIGNED,  // Unaligned fetch
		UC_ERR_HOOK_EXIST,  // hook for this event already existed
		UC_ERR_RESOURCE,    // Insufficient resource: uc_emu_start()
		UC_ERR_EXCEPTION // Unhandled CPU exception
	}

	[Flags]
	internal enum HookType {
		// Hook all interrupt/syscall events
		UC_HOOK_INTR = 1 << 0,
		// Hook a particular instruction - only a very small subset of instructions supported here
		UC_HOOK_INSN = 1 << 1,
		// Hook a range of code
		UC_HOOK_CODE = 1 << 2,
		// Hook basic blocks
		UC_HOOK_BLOCK = 1 << 3,
		// Hook for memory read on unmapped memory
		UC_HOOK_MEM_READ_UNMAPPED = 1 << 4,
		// Hook for invalid memory write events
		UC_HOOK_MEM_WRITE_UNMAPPED = 1 << 5,
		// Hook for invalid memory fetch for execution events
		UC_HOOK_MEM_FETCH_UNMAPPED = 1 << 6,
		// Hook for memory read on read-protected memory
		UC_HOOK_MEM_READ_PROT = 1 << 7,
		// Hook for memory write on write-protected memory
		UC_HOOK_MEM_WRITE_PROT = 1 << 8,
		// Hook for memory fetch on non-executable memory
		UC_HOOK_MEM_FETCH_PROT = 1 << 9,
		// Hook memory read events.
		UC_HOOK_MEM_READ = 1 << 10,
		// Hook memory write events.
		UC_HOOK_MEM_WRITE = 1 << 11,
		// Hook memory fetch for execution events
		UC_HOOK_MEM_FETCH = 1 << 12,
		// Hook memory read events, but only successful access.
		// The callback will be triggered after successful read.
		UC_HOOK_MEM_READ_AFTER = 1 << 13
	}

	internal enum MemType {
		UC_MEM_READ = 16,   // Memory is read from
		UC_MEM_WRITE,       // Memory is written to
		UC_MEM_FETCH,       // Memory is fetched
		UC_MEM_READ_UNMAPPED,    // Unmapped memory is read from
		UC_MEM_WRITE_UNMAPPED,   // Unmapped memory is written to
		UC_MEM_FETCH_UNMAPPED,   // Unmapped memory is fetched
		UC_MEM_WRITE_PROT,  // Write to write protected, but mapped, memory
		UC_MEM_READ_PROT,   // Read from read protected, but mapped, memory
		UC_MEM_FETCH_PROT,  // Fetch from non-executable, but mapped, memory
		UC_MEM_READ_AFTER   // Memory is read from (successful access)
	}
	
	internal static class Native {
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern uint uc_version(out uint major, out uint minor);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern bool supported(uint arch);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_open(uint arch, uint mode, out IntPtr uc);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_close(IntPtr uc);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_query(IntPtr uc, uint type, out ulong result);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_errno(IntPtr uc);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr uc_strerror(Err err);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_reg_write(IntPtr uc, int regid, ref ulong value);
		
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_reg_read(IntPtr uc, int regid, out ulong value);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_reg_write_batch(IntPtr uc, int[] regs, IntPtr values, int count);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_reg_read_batch(IntPtr uc, int[] regs, IntPtr values, int count);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_write(IntPtr uc, ulong addr, byte[] bytes, ulong size);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_read(IntPtr uc, ulong addr, byte[] bytes, ulong size);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_emu_start(IntPtr uc, ulong begin, ulong until, ulong timeout, ulong count);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_emu_stop(IntPtr uc);
		
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_hook_add(IntPtr uc, out IntPtr hh, HookType type, Action<IntPtr, uint, IntPtr> callback, IntPtr userdata, ulong begin, ulong end);
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_hook_add(IntPtr uc, out IntPtr hh, HookType type, Action<IntPtr, ulong, ulong, IntPtr> callback, IntPtr userdata, ulong begin, ulong end);
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_hook_add(IntPtr uc, out IntPtr hh, HookType type, Action<IntPtr, MemType, ulong, ulong, ulong, IntPtr> callback, IntPtr userdata, ulong begin, ulong end);
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_hook_add(IntPtr uc, out IntPtr hh, HookType type, Func<IntPtr, MemType, ulong, ulong, ulong, IntPtr, bool> callback, IntPtr userdata, ulong begin, ulong end);
		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_hook_add(IntPtr uc, out IntPtr hh, HookType type, Action callback, IntPtr userdata, ulong begin, ulong end, int insn);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_hook_del(IntPtr uc, IntPtr hh);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_map(IntPtr uc, ulong addr, ulong size, uint perms);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_map_ptr(IntPtr uc, ulong addr, ulong size, uint perms, IntPtr ptr);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_unmap(IntPtr uc, ulong addr, ulong size);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_protect(IntPtr uc, ulong addr, ulong size, uint perms);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_mem_regions(IntPtr uc, out IntPtr regions, out uint count);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_context_alloc(IntPtr uc, out IntPtr context);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_free(IntPtr ptr);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_context_save(IntPtr uc, IntPtr context);

		[DllImport("unicorn", CallingConvention = CallingConvention.Cdecl)]
		internal static extern Err uc_context_restore(IntPtr uc, IntPtr context);
	}
}