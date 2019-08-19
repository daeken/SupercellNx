using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UltimateOrb;

namespace UnicornSharp {
	public enum Arch {
		Arm = 1,    // ARM architecture (including Thumb, Thumb-2)
		Arm64,      // ARM-64, also called AArch64
		Mips,       // Mips architecture
		X86,        // X86 architecture (including x86 & x86-64)
		Ppc,        // PowerPC architecture (currently unsupported)
		Sparc,      // Sparc architecture
		M68k,       // M68K architecture
	}

	[Flags]
	public enum Mode {
		LittleEndian = 0,    // little-endian mode (default mode)
		BigEndian = 1 << 30, // big-endian mode
		// arm / arm64
		Arm = 0,              // ARM mode
		Thumb = 1 << 4,       // THUMB mode (including Thumb-2)
		Mclass = 1 << 5,      // ARM's Cortex-M series (currently unsupported)
		V8 = 1 << 6,          // ARMv8 A32 encodings for ARM (currently unsupported)
		// mips
		Micro = 1 << 4,       // MicroMips mode (currently unsupported)
		Mips3 = 1 << 5,       // Mips III ISA (currently unsupported)
		Mips32r6 = 1 << 6,    // Mips32r6 ISA (currently unsupported)
		Mips32 = 1 << 2,      // Mips32 ISA
		Mips64 = 1 << 3,      // Mips64 ISA
		// x86 / x64
		X86_16 = 1 << 1,          // 16-bit mode
		X86_32 = 1 << 2,          // 32-bit mode
		X86_64 = 1 << 3,          // 64-bit mode
		// ppc 
		Ppc32 = 1 << 2,       // 32-bit mode (currently unsupported)
		Ppc64 = 1 << 3,       // 64-bit mode (currently unsupported)
		Qpx = 1 << 4,         // Quad Processing eXtensions mode (currently unsupported)
		// sparc
		Sparc32 = 1 << 2,     // 32-bit mode
		Sparc64 = 1 << 3,     // 64-bit mode
		V9 = 1 << 4,          // SparcV9 mode (currently unsupported)
		// m68k
	}

	[Flags]
	public enum MemoryPermission {
		None = 0,
		Read = 1 << 0,
		Write = 1 << 1,
		Execute = 1 << 2,
		All = Read | Write | Execute
	}

	public enum Endian {
		Little = Mode.LittleEndian,
		Big = Mode.BigEndian
	}
	
	public enum ArmRegister {
		INVALID = 0,
		APSR,
		APSR_NZCV,
		CPSR,
		FPEXC,
		FPINST,
		FPSCR,
		FPSCR_NZCV,
		FPSID,
		ITSTATE,
		LR,
		PC,
		SP,
		SPSR,
		D0,
		D1,
		D2,
		D3,
		D4,
		D5,
		D6,
		D7,
		D8,
		D9,
		D10,
		D11,
		D12,
		D13,
		D14,
		D15,
		D16,
		D17,
		D18,
		D19,
		D20,
		D21,
		D22,
		D23,
		D24,
		D25,
		D26,
		D27,
		D28,
		D29,
		D30,
		D31,
		FPINST2,
		MVFR0,
		MVFR1,
		MVFR2,
		Q0,
		Q1,
		Q2,
		Q3,
		Q4,
		Q5,
		Q6,
		Q7,
		Q8,
		Q9,
		Q10,
		Q11,
		Q12,
		Q13,
		Q14,
		Q15,
		R0,
		R1,
		R2,
		R3,
		R4,
		R5,
		R6,
		R7,
		R8,
		R9,
		R10,
		R11,
		R12,
		S0,
		S1,
		S2,
		S3,
		S4,
		S5,
		S6,
		S7,
		S8,
		S9,
		S10,
		S11,
		S12,
		S13,
		S14,
		S15,
		S16,
		S17,
		S18,
		S19,
		S20,
		S21,
		S22,
		S23,
		S24,
		S25,
		S26,
		S27,
		S28,
		S29,
		S30,
		S31,
	
		C1_C0_2,
		C13_C0_2,
		C13_C0_3,
	
		ENDING,		// <-- mark the end of the list or registers
	
		//> alias registers
		R13 = SP,
		R14 = LR,
		R15 = PC,
	
		SB = R9,
		SL = R10,
		FP = R11,
		IP = R12
	}

	public enum Arm64Register {
		INVALID = 0,

		X29,
		X30,
		NZCV,
		SP,
		WSP,
		WZR,
		XZR,
		B0,
		B1,
		B2,
		B3,
		B4,
		B5,
		B6,
		B7,
		B8,
		B9,
		B10,
		B11,
		B12,
		B13,
		B14,
		B15,
		B16,
		B17,
		B18,
		B19,
		B20,
		B21,
		B22,
		B23,
		B24,
		B25,
		B26,
		B27,
		B28,
		B29,
		B30,
		B31,
		D0,
		D1,
		D2,
		D3,
		D4,
		D5,
		D6,
		D7,
		D8,
		D9,
		D10,
		D11,
		D12,
		D13,
		D14,
		D15,
		D16,
		D17,
		D18,
		D19,
		D20,
		D21,
		D22,
		D23,
		D24,
		D25,
		D26,
		D27,
		D28,
		D29,
		D30,
		D31,
		H0,
		H1,
		H2,
		H3,
		H4,
		H5,
		H6,
		H7,
		H8,
		H9,
		H10,
		H11,
		H12,
		H13,
		H14,
		H15,
		H16,
		H17,
		H18,
		H19,
		H20,
		H21,
		H22,
		H23,
		H24,
		H25,
		H26,
		H27,
		H28,
		H29,
		H30,
		H31,
		Q0,
		Q1,
		Q2,
		Q3,
		Q4,
		Q5,
		Q6,
		Q7,
		Q8,
		Q9,
		Q10,
		Q11,
		Q12,
		Q13,
		Q14,
		Q15,
		Q16,
		Q17,
		Q18,
		Q19,
		Q20,
		Q21,
		Q22,
		Q23,
		Q24,
		Q25,
		Q26,
		Q27,
		Q28,
		Q29,
		Q30,
		Q31,
		S0,
		S1,
		S2,
		S3,
		S4,
		S5,
		S6,
		S7,
		S8,
		S9,
		S10,
		S11,
		S12,
		S13,
		S14,
		S15,
		S16,
		S17,
		S18,
		S19,
		S20,
		S21,
		S22,
		S23,
		S24,
		S25,
		S26,
		S27,
		S28,
		S29,
		S30,
		S31,
		W0,
		W1,
		W2,
		W3,
		W4,
		W5,
		W6,
		W7,
		W8,
		W9,
		W10,
		W11,
		W12,
		W13,
		W14,
		W15,
		W16,
		W17,
		W18,
		W19,
		W20,
		W21,
		W22,
		W23,
		W24,
		W25,
		W26,
		W27,
		W28,
		W29,
		W30,
		X0,
		X1,
		X2,
		X3,
		X4,
		X5,
		X6,
		X7,
		X8,
		X9,
		X10,
		X11,
		X12,
		X13,
		X14,
		X15,
		X16,
		X17,
		X18,
		X19,
		X20,
		X21,
		X22,
		X23,
		X24,
		X25,
		X26,
		X27,
		X28,

		V0,
		V1,
		V2,
		V3,
		V4,
		V5,
		V6,
		V7,
		V8,
		V9,
		V10,
		V11,
		V12,
		V13,
		V14,
		V15,
		V16,
		V17,
		V18,
		V19,
		V20,
		V21,
		V22,
		V23,
		V24,
		V25,
		V26,
		V27,
		V28,
		V29,
		V30,
		V31,

		PC,			// program counter register

		CPACR_EL1,

		TPIDR_EL0,
		TPIDRRO_EL0,
		TPIDR_EL1,

		ENDING,		// <-- mark the end of the list of registers

//> alias registers

		IP0 = X16,
		IP1 = X17,
		FP = X29,
		LR = X30
	}

	public delegate void UnicornAction<in UT>(UT uc);
	public delegate void UnicornAction<in UT, in T1>(UT uc, T1 _1);
	public delegate void UnicornAction<in UT, in T1, in T2>(UT uc, T1 _1, T2 _2);
	public delegate void UnicornAction<in UT, in T1, in T2, in T3>(UT uc, T1 _1, T2 _2, T3 _3);
	public delegate void UnicornAction<in UT, in T1, in T2, in T3, in T4>(UT uc, T1 _1, T2 _2, T3 _3, T4 _4);
	public delegate void UnicornAction<in UT, in T1, in T2, in T3, in T4, in T5>(UT uc, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5);
	public delegate RetT UnicornFunc<in UT, out RetT>(UT uc);
	public delegate RetT UnicornFunc<in UT, out RetT, in T1>(UT uc, T1 _1);
	public delegate RetT UnicornFunc<in UT, out RetT, in T1, in T2>(UT uc, T1 _1, T2 _2);
	public delegate RetT UnicornFunc<in UT, out RetT, in T1, in T2, in T3>(UT uc, T1 _1, T2 _2, T3 _3);
	public delegate RetT UnicornFunc<in UT, out RetT, in T1, in T2, in T3, in T4>(UT uc, T1 _1, T2 _2, T3 _3, T4 _4);
	public delegate RetT UnicornFunc<in UT, out RetT, in T1, in T2, in T3, in T4, in T5>(UT uc, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5);
	
	public abstract class BaseUnicorn<UT> {
		internal readonly IntPtr uc;

		public ulong this[int register] {
			get {
				CheckError(Native.uc_reg_read(uc, register, out ulong val));
				return val;
			}
			set => CheckError(Native.uc_reg_write(uc, register, ref value));
		}

		public UInt128 GetLarge(int register) {
			CheckError(Native.uc_reg_read(uc, register, out UInt128 val));
			return val;
		}
		public void SetLarge(int register, UInt128 value) {
			CheckError(Native.uc_reg_write(uc, register, ref value));
		}

		internal readonly Dictionary<object, (IntPtr HookHandle, object Delegate)> hookHandles = new Dictionary<object, (IntPtr HookHandle, object Delegate)>();
		
		public event UnicornAction<UT, ulong, int> OnCode {
			add => AddCodeHook(value, 1, 0);
			remove => RemoveHook(value);
		}

		public event UnicornAction<UT, ulong, int> OnMemRead {
			add => AddMemReadHook(value, 1, 0);
			remove => RemoveHook(value);
		}
		
		public event UnicornAction<UT, ulong, int, ulong> OnMemWrite {
			add => AddMemWriteHook(value, 1, 0);
			remove => RemoveHook(value);
		}

		public event UnicornFunc<UT, bool, ulong, int, bool> OnBadRead {
			add => AddBadReadHook(value, 1, 0);
			remove => RemoveHook(value);
		}

		public event UnicornFunc<UT, bool, ulong, int, ulong, bool> OnBadWrite {
			add => AddBadWriteHook(value, 1, 0);
			remove => RemoveHook(value);
		}

		public event UnicornAction<UT, uint> OnInterrupt {
			add => AddInterruptHook(value, 1, 0);
			remove => RemoveHook(value);
		}

		protected BaseUnicorn(Arch arch, Mode mode) {
			CheckError(Native.uc_open((uint) arch, (uint) mode, out uc));
		}

		~BaseUnicorn() {
			CheckError(Native.uc_close(uc));
		}

		public void Map(ulong addr, ulong size, MemoryPermission perms) {
			CheckError(Native.uc_mem_map(uc, addr, size, (uint) perms));
		}

		public void Map(ulong addr, ulong size, MemoryPermission perms, IntPtr ptr) {
			CheckError(Native.uc_mem_map_ptr(uc, addr, size, (uint) perms, ptr));
		}

		public void Map(uint addr, uint size, MemoryPermission perms) {
			CheckError(Native.uc_mem_map(uc, addr, size, (uint) perms));
		}

		public void Map(uint addr, uint size, MemoryPermission perms, IntPtr ptr) {
			CheckError(Native.uc_mem_map_ptr(uc, addr, size, (uint) perms, ptr));
		}

		public void Unmap(ulong addr, ulong size) {
			CheckError(Native.uc_mem_unmap(uc, addr, size));
		}

		public void Unmap(uint addr, uint size) {
			CheckError(Native.uc_mem_unmap(uc, addr, size));
		}

		public void Protect(ulong addr, ulong size, MemoryPermission perms) {
			CheckError(Native.uc_mem_protect(uc, addr, size, (uint) perms));
		}

		public void Protect(uint addr, uint size, MemoryPermission perms) {
			CheckError(Native.uc_mem_protect(uc, addr, size, (uint) perms));
		}

		public void MemWrite(ulong addr, byte[] data) {
			CheckError(Native.uc_mem_write(uc, addr, data, (ulong) data.Length));
		}

		public void MemWrite(ulong addr, byte value) {
			var data = new [] { value };
			CheckError(Native.uc_mem_write(uc, addr, data, 1));
		}

		public void MemWrite(ulong addr, ushort value) {
			var data = BitConverter.GetBytes(value);
			CheckError(Native.uc_mem_write(uc, addr, data, 2));
		}

		public void MemWrite(ulong addr, uint value) {
			var data = BitConverter.GetBytes(value);
			CheckError(Native.uc_mem_write(uc, addr, data, 4));
		}

		public void MemWrite(ulong addr, ulong value) {
			var data = BitConverter.GetBytes(value);
			CheckError(Native.uc_mem_write(uc, addr, data, 8));
		}

		public void MemWrite(uint addr, byte[] data) {
			CheckError(Native.uc_mem_write(uc, addr, data, (ulong) data.Length));
		}

		public void MemWrite(uint addr, byte value) {
			var data = new [] { value };
			CheckError(Native.uc_mem_write(uc, addr, data, 1));
		}

		public void MemWrite(uint addr, ushort value) {
			var data = BitConverter.GetBytes(value);
			CheckError(Native.uc_mem_write(uc, addr, data, 2));
		}

		public void MemWrite(uint addr, uint value) {
			var data = BitConverter.GetBytes(value);
			CheckError(Native.uc_mem_write(uc, addr, data, 4));
		}

		public void MemWrite(uint addr, ulong value) {
			var data = BitConverter.GetBytes(value);
			CheckError(Native.uc_mem_write(uc, addr, data, 8));
		}

		public void MemRead(ulong addr, byte[] data) {
			CheckError(Native.uc_mem_read(uc, addr, data, (ulong) data.Length));
		}

		public void MemRead(ulong addr, out byte value) {
			var data = new byte[1];
			CheckError(Native.uc_mem_read(uc, addr, data, 1));
			value = data[0];
		}

		public void MemRead(ulong addr, out ushort value) {
			var data = new byte[2];
			CheckError(Native.uc_mem_read(uc, addr, data, 2));
			value = BitConverter.ToUInt16(data, 0);
		}

		public void MemRead(ulong addr, out uint value) {
			var data = new byte[4];
			CheckError(Native.uc_mem_read(uc, addr, data, 4));
			value = BitConverter.ToUInt32(data, 0);
		}

		public void MemRead(ulong addr, out ulong value) {
			var data = new byte[8];
			CheckError(Native.uc_mem_read(uc, addr, data, 8));
			value = BitConverter.ToUInt64(data, 0);
		}

		public void MemRead(uint addr, byte[] data) {
			CheckError(Native.uc_mem_read(uc, addr, data, (ulong) data.Length));
		}

		public byte[] MemRead(ulong addr, int size) {
			var data = new byte[size];
			MemRead(addr, data);
			return data;
		}

		public byte[] MemRead(uint addr, int size) {
			var data = new byte[size];
			MemRead(addr, data);
			return data;
		}

		public void Start(ulong begin, ulong end, ulong timeout = 0, ulong count = 0) {
			CheckError(Native.uc_emu_start(uc, begin, end, timeout, count));
		}

		public void Start(uint begin, uint end, ulong timeout = 0, ulong count = 0) {
			CheckError(Native.uc_emu_start(uc, begin, end, timeout, count));
		}

		public void Start(ulong addr) {
			Start(addr, 0xFFFFFFFFFFFFFFFFU);
		}

		public void Start(uint addr) {
			Start(addr, 0xFFFFFFFFU);
		}

		public void AddCodeHook(UnicornAction<UT, ulong, int> func, ulong begin, ulong end) {
			Native.IUUI del = (_, addr, size, __) =>
				func((UT) (object) this, addr, (int) size);
			CheckError(Native.uc_hook_add(uc, out var hh, HookType.UC_HOOK_CODE, del, IntPtr.Zero, begin, end));
			hookHandles[func] = (hh, del);
		}

		public void AddMemReadHook(UnicornAction<UT, ulong, int> func, ulong begin, ulong end) {
			Native.IMUUUI del = (_, __, addr, size, ___, ____) =>
				func((UT) (object) this, addr, (int) size);
			CheckError(Native.uc_hook_add(uc, out var hh, HookType.UC_HOOK_MEM_READ, del, IntPtr.Zero, begin, end));
			hookHandles[func] = (hh, del);
		}

		public void AddMemWriteHook(UnicornAction<UT, ulong, int, ulong> func, ulong begin, ulong end) {
			Native.IMUUUI del = (_, __, addr, size, value, ___) =>
				func((UT) (object) this, addr, (int) size, value);
			CheckError(Native.uc_hook_add(uc, out var hh, HookType.UC_HOOK_MEM_WRITE, del, IntPtr.Zero, begin, end));
			hookHandles[func] = (hh, del);
		}

		public void AddBadReadHook(UnicornFunc<UT, bool, ulong, int, bool> func, ulong begin, ulong end) {
			Native.IMUUUIrB del = (_, type, addr, size, __, ___) =>
				func((UT) (object) this, addr, (int) size, type == MemType.UC_MEM_READ_PROT);
			CheckError(Native.uc_hook_add(uc, out var hh, HookType.UC_HOOK_MEM_READ_PROT | HookType.UC_HOOK_MEM_READ_UNMAPPED, del, IntPtr.Zero, begin, end));
			hookHandles[func] = (hh, del);
		}

		public void AddBadWriteHook(UnicornFunc<UT, bool, ulong, int, ulong, bool> func, ulong begin, ulong end) {
			Native.IMUUUIrB del = (_, type, addr, size, value, __) =>
				func((UT) (object) this, addr, (int) size, value, type == MemType.UC_MEM_WRITE_PROT);
			CheckError(Native.uc_hook_add(uc, out var hh, HookType.UC_HOOK_MEM_WRITE_PROT | HookType.UC_HOOK_MEM_WRITE_UNMAPPED, del, IntPtr.Zero, begin, end));
			hookHandles[func] = (hh, del);
		}

		public void AddInterruptHook(UnicornAction<UT, uint> func, ulong begin, ulong end) {
			Native.IUI del = (_, intno, __) => func((UT) (object) this, intno);
			CheckError(Native.uc_hook_add(uc, out var hh, HookType.UC_HOOK_INTR, del, IntPtr.Zero, begin, end));
			hookHandles[func] = (hh, del);
		}

		public void RemoveHook(object func) {
			if(!hookHandles.ContainsKey(func))
				return;
			Native.uc_hook_del(uc, hookHandles[func].HookHandle);
			hookHandles.Remove(func);
		}

		internal void CheckError(Err err) {
			if(err != Err.UC_ERR_OK)
				throw new UnicornException(err);
		}
	}
	
	public class UnicornArm : BaseUnicorn<UnicornArm> {
		public uint this[ArmRegister register] {
			get => (uint) this[(int) register];
			set => this[(int) register] = value;
		}

		public UnicornArm(bool thumb = false, Endian endianness = Endian.Little) : base(Arch.Arm, (Mode) ((int) (thumb ? Mode.Thumb : Mode.Arm) | (int) endianness)) {
		}
	}

	public class UnicornArm64 : BaseUnicorn<UnicornArm64> {
		public ulong this[Arm64Register register] {
			get => this[(int) register];
			set => this[(int) register] = value;
		}

		public UInt128 GetLarge(Arm64Register register) => GetLarge((int) register);
		public void SetLarge(Arm64Register register, UInt128 value) => SetLarge((int) register, value);

		public UnicornArm64(Endian endianness = Endian.Little) : base(Arch.Arm64, (Mode) ((int) Mode.Arm | (int) endianness)) {
		}
	}

	public class UnicornException : Exception {
		readonly Err Errno;
		
		internal UnicornException(Err errno) {
			Errno = errno;
		}

		public override string Message => Marshal.PtrToStringAnsi(Native.uc_strerror(Errno)) ?? "Unknown Unicorn error";
	}
}