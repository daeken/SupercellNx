using System;

namespace Supercell.IpcServices.nn.aocsrv.detail {
	[IpcService("aoc:u")]
	public class IAddOnContentManager : IpcInterface {
		[IpcCommand(0)]
		void CountAddOnContentByApplicationId(ulong /* nn::ncm::ApplicationId */ unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(1)]
		void ListAddOnContentByApplicationId(uint unknown0, uint unknown1, ulong /* nn::ncm::ApplicationId */ unknown2, out uint unknown3, [Buffer(0x6)] Buffer<uint> unknown4) => throw new NotImplementedException();
		[IpcCommand(2)]
		void CountAddOnContent(ulong unknown0, [Pid] ulong pid, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(3)]
		void ListAddOnContent(uint unknown0, uint unknown1, ulong unknown2, [Pid] ulong pid, out uint unknown3, [Buffer(0x6)] Buffer<uint> unknown4) => throw new NotImplementedException();
		[IpcCommand(4)]
		void GetAddOnContentBaseIdByApplicationId(ulong /* nn::ncm::ApplicationId */ unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(5)]
		void GetAddOnContentBaseId(ulong unknown0, [Pid] ulong pid, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(6)]
		void PrepareAddOnContentByApplicationId(uint unknown0, ulong /* nn::ncm::ApplicationId */ unknown1) {}
		[IpcCommand(7)]
		void PrepareAddOnContent(uint unknown0, ulong unknown1, [Pid] ulong pid) {}
		[IpcCommand(8)]
		void GetAddOnContentListChangedEvent([Move] out KObject unknown0) => throw new NotImplementedException();
	}
}
