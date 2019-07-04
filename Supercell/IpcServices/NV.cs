using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nns.nvdrv {
	[IpcService("nvdrv")]
	[IpcService("nvdrv:a")]
	[IpcService("nvdrv:s")]
	[IpcService("nvdrv:t")]
	public class INvDrvServices : IpcInterface {
		[IpcCommand(0)]
		void Open([Buffer(0x5)] Span<byte> path, out uint fd, out uint error_code) => throw new NotImplementedException();
		[IpcCommand(1)]
		void Ioctl(uint fd, uint rq_id, [Buffer(0x21)] Span<byte> unknown0, out uint error_code, [Buffer(0x22)] Span<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(2)]
		void Close(uint fd, out uint error_code) => throw new NotImplementedException();

		[IpcCommand(3)]
		void Initialize(uint transfer_memory_size, [Move] KObject current_process, [Move] KObject transfer_memory,
			out uint error_code) {
			error_code = 0;
		}
		
		[IpcCommand(4)]
		void QueryEvent(uint fd, uint event_id, out uint unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(5)]
		void MapSharedMem(uint fd, uint nvmap_handle, [Move] KObject unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(6)]
		void GetStatus([Bytes(0x24)] out byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(7)]
		void ForceSetClientPID(ulong pid, out uint error_code) => throw new NotImplementedException();

		[IpcCommand(8)]
		void SetClientPID(ulong unknown0, [Pid] ulong pid, out uint error_code) {
			error_code = 0;
		}
		
		[IpcCommand(9)]
		void DumpGraphicsMemoryInfo() => throw new NotImplementedException();
		[IpcCommand(10)]
		void Unknown10(uint unknown0, [Move] KObject unknown1, out uint unknown2) => throw new NotImplementedException();
		[IpcCommand(11)]
		void Ioctl2(uint unknown0, uint unknown1, [Buffer(0x21)] Span<byte> unknown2, [Buffer(0x21)] Span<byte> unknown3, out uint unknown4, [Buffer(0x22)] Span<byte> unknown5) => throw new NotImplementedException();
		[IpcCommand(12)]
		void Ioctl3(uint unknown0, uint unknown1, [Buffer(0x21)] Span<byte> unknown2, out uint unknown3, [Buffer(0x22)] Span<byte> unknown4, [Buffer(0x22)] Span<byte> unknown5) => throw new NotImplementedException();

		[IpcCommand(13)]
		void Unknown13(ulong unknown0) {
		}
	}
}
