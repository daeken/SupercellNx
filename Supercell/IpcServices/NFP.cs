using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.nfp.detail {
	[IpcService("nfp:user")]
	public class IUserManager : IpcInterface {
		[IpcCommand(0)]
		void CreateUserInterface([Move] out IUser service) => service = new IUser();
	}
	
	public class IUser : IpcInterface {
		[IpcCommand(0)]
		void Initialize(ulong unknown0, ulong unknown1, [Pid] ulong pid, [Buffer(0x5)] Buffer<byte> unknown2) {}
		[IpcCommand(1)]
		void Finalize() {}
		[IpcCommand(2)]
		void ListDevices(out uint unknown0, [Buffer(0xa)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(3)]
		void StartDetection([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(4)]
		void StopDetection([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(5)]
		void Mount([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, uint unknown1, uint unknown2) => throw new NotImplementedException();
		[IpcCommand(6)]
		void Unmount([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(7)]
		void OpenApplicationArea([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, uint unknown1) => throw new NotImplementedException();
		[IpcCommand(8)]
		void GetApplicationArea([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(9)]
		void SetApplicationArea([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Buffer(0x5)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(10)]
		void Flush([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(11)]
		void Restore([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(12)]
		void CreateApplicationArea([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, uint unknown1, [Buffer(0x5)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(13)]
		void GetTagInfo([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Buffer(0x1a)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(14)]
		void GetRegisterInfo([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Buffer(0x1a)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(15)]
		void GetCommonInfo([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Buffer(0x1a)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(16)]
		void GetModelInfo([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Buffer(0x1a)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(17)]
		void AttachActivateEvent([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(18)]
		void AttachDeactivateEvent([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(19)]
		void GetState(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(20)]
		void GetDeviceState([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(21)]
		void GetNpadId([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(22)]
		void GetApplicationArea2([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(23)]
		void AttachAvailabilityChangeEvent([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(24)]
		void RecreateApplicationArea([Bytes(0x20 /* 8 x 4 */)] byte[] unknown0, uint unknown1, [Buffer(0x5)] Buffer<byte> unknown2) => throw new NotImplementedException();
	}
}