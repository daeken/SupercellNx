using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.nifm.detail {
	[IpcService("nifm:a")]
	[IpcService("nifm:s")]
	[IpcService("nifm:u")]
	public class IStaticService : IpcInterface {
		[IpcCommand(4)]
		void CreateGeneralService([Move] out IGeneralService service) => service = new IGeneralService();
		[IpcCommand(5)]
		void CreateGeneralService(ulong unknown0, [Pid] ulong pid, [Move] out IGeneralService service) => service = new IGeneralService();
	}
	
	public class IGeneralService : IpcInterface {
		[IpcCommand(1)]
		void GetClientId([Buffer(0x1a)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(2)]
		void CreateScanRequest(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(4)]
		void CreateRequest(uint unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(5)]
		void GetCurrentNetworkProfile([Buffer(0x1a)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(6)]
		void EnumerateNetworkInterfaces(uint unknown0, out uint unknown1, [Buffer(0xa)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(7)]
		void EnumerateNetworkProfiles(byte unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(8)]
		void GetNetworkProfile([Bytes(0x10 /* 16 x 1 */)] byte[] /* nn::util::Uuid */ unknown0, [Buffer(0x1a)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(9)]
		void SetNetworkProfile([Buffer(0x19)] Buffer<byte> unknown0, [Bytes(0x10 /* 16 x 1 */)] out byte[] /* nn::util::Uuid */ unknown1) => throw new NotImplementedException();
		[IpcCommand(10)]
		void RemoveNetworkProfile([Bytes(0x10 /* 16 x 1 */)] byte[] /* nn::util::Uuid */ unknown0) => throw new NotImplementedException();
		[IpcCommand(11)]
		void GetScanData(out uint unknown0, [Buffer(0x6)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(12)]
		void GetCurrentIpAddress([Bytes(0x4 /* 4 x 1 */)] out byte[] /* nn::nifm::IpV4Address */ unknown0) => throw new NotImplementedException();
		[IpcCommand(13)]
		void GetCurrentAccessPoint([Buffer(0x1a)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(14)]
		void CreateTemporaryNetworkProfile([Buffer(0x19)] Buffer<byte> unknown0, [Bytes(0x10 /* 16 x 1 */)] out byte[] /* nn::util::Uuid */ unknown1, out object unknown2) => throw new NotImplementedException();
		[IpcCommand(15)]
		void GetCurrentIpConfigInfo([Bytes(0xd /* 13 x 1 */)] out byte[] /* nn::nifm::IpAddressSetting */ unknown0, [Bytes(0x9 /* 9 x 1 */)] out byte[] /* nn::nifm::DnsSetting */ unknown1) => throw new NotImplementedException();
		[IpcCommand(16)]
		void SetWirelessCommunicationEnabled(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(17)]
		void IsWirelessCommunicationEnabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(18)]
		void GetInternetConnectionStatus([Bytes(0x3 /* 3 x 1 */)] out byte[] /* nn::nifm::detail::sf::InternetConnectionStatus */ unknown0) => throw new NotImplementedException();
		[IpcCommand(19)]
		void SetEthernetCommunicationEnabled(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(20)]
		void IsEthernetCommunicationEnabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(21)]
		void IsAnyInternetRequestAccepted([Buffer(0x19)] Buffer<byte> unknown0, out bool unknown1) => throw new NotImplementedException();
		[IpcCommand(22)]
		void IsAnyForegroundRequestAccepted(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(23)]
		void PutToSleep() => throw new NotImplementedException();
		[IpcCommand(24)]
		void WakeUp() => throw new NotImplementedException();
		[IpcCommand(25)]
		void GetSsidListVersion([Bytes(0x10 /* 16 x 1 */)] out byte[] /* nn::nifm::SsidListVersion */ unknown0) => throw new NotImplementedException();
		[IpcCommand(26)]
		void SetExclusiveClient([Buffer(0x19)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(27)]
		void GetDefaultIpSetting([Buffer(0x1a)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(28)]
		void SetDefaultIpSetting([Buffer(0x19)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(29)]
		void SetWirelessCommunicationEnabledForTest(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(30)]
		void SetEthernetCommunicationEnabledForTest(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(31)]
		void GetTelemetorySystemEventReadableHandle([Move] out KObject unknown0) => throw new NotImplementedException();
		[IpcCommand(32)]
		void GetTelemetryInfo([Buffer(0x16)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(33)]
		void ConfirmSystemAvailability() => throw new NotImplementedException();
		[IpcCommand(34)]
		void SetBackgroundRequestEnabled(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(35)]
		void GetScanData35(out uint unknown0, [Buffer(0x6)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(36)]
		void GetCurrentAccessPoint36([Buffer(0x1a)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(37)]
		void Shutdown() => throw new NotImplementedException();
	}
}