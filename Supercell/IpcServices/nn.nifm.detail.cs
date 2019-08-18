using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Nifm.Detail {
	public unsafe partial class IStaticService {
		public override Nn.Nifm.Detail.IGeneralService CreateGeneralServiceOld() => new IGeneralService();
		public override Nn.Nifm.Detail.IGeneralService CreateGeneralService(ulong _0, ulong _1) => new IGeneralService();
	}

	public partial class IGeneralService {
		public override void GetClientId(Buffer<byte> _0) => throw new NotImplementedException();
		public override Nn.Nifm.Detail.IScanRequest CreateScanRequest() => throw new NotImplementedException();
		public override Nn.Nifm.Detail.IRequest CreateRequest(uint _0) => new IRequest();
		public override void GetCurrentNetworkProfile(Buffer<byte> _0) => throw new NotImplementedException();
		public override void EnumerateNetworkInterfaces(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override void EnumerateNetworkProfiles(byte _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override void GetNetworkProfile(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void SetNetworkProfile(Buffer<byte> _0, out byte[] _1) => throw new NotImplementedException();
		public override void RemoveNetworkProfile(byte[] _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.RemoveNetworkProfile [10]".Debug();
		public override void GetScanDataOld(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void GetCurrentIpAddress(out byte[] _0) => throw new NotImplementedException();
		public override void GetCurrentAccessPointOld(Buffer<byte> _0) => throw new NotImplementedException();
		public override void CreateTemporaryNetworkProfile(Buffer<byte> _0, out byte[] _1, out Nn.Nifm.Detail.INetworkProfile _2) => throw new NotImplementedException();
		public override void GetCurrentIpConfigInfo(out byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public override void SetWirelessCommunicationEnabled(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetWirelessCommunicationEnabled [16]".Debug();
		public override byte IsWirelessCommunicationEnabled() => throw new NotImplementedException();
		public override void GetInternetConnectionStatus(out byte[] _0) => throw new NotImplementedException();
		public override void SetEthernetCommunicationEnabled(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetEthernetCommunicationEnabled [19]".Debug();
		public override byte IsEthernetCommunicationEnabled() => throw new NotImplementedException();
		public override byte IsAnyInternetRequestAccepted(Buffer<byte> _0) => throw new NotImplementedException();
		public override byte IsAnyForegroundRequestAccepted() => throw new NotImplementedException();
		public override void PutToSleep() => "Stub hit for Nn.Nifm.Detail.IGeneralService.PutToSleep [23]".Debug();
		public override void WakeUp() => "Stub hit for Nn.Nifm.Detail.IGeneralService.WakeUp [24]".Debug();
		public override void GetSsidListVersion(out byte[] _0) => throw new NotImplementedException();
		public override void SetExclusiveClient(Buffer<byte> _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetExclusiveClient [26]".Debug();
		public override void GetDefaultIpSetting(Buffer<byte> _0) => throw new NotImplementedException();
		public override void SetDefaultIpSetting(Buffer<byte> _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetDefaultIpSetting [28]".Debug();
		public override void SetWirelessCommunicationEnabledForTest(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetWirelessCommunicationEnabledForTest [29]".Debug();
		public override void SetEthernetCommunicationEnabledForTest(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetEthernetCommunicationEnabledForTest [30]".Debug();
		public override KObject GetTelemetorySystemEventReadableHandle() => throw new NotImplementedException();
		public override void GetTelemetryInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public override void ConfirmSystemAvailability() => "Stub hit for Nn.Nifm.Detail.IGeneralService.ConfirmSystemAvailability [33]".Debug();
		public override void SetBackgroundRequestEnabled(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetBackgroundRequestEnabled [34]".Debug();
		public override void GetScanData(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void GetCurrentAccessPoint(Buffer<byte> _0) => throw new NotImplementedException();
		public override void Shutdown() => "Stub hit for Nn.Nifm.Detail.IGeneralService.Shutdown [37]".Debug();
	}

	public partial class IRequest {
		public override uint GetRequestState() => 1;
		public override void GetResult() => "Stub hit for Nn.Nifm.Detail.IRequest.GetResult [1]".Debug();

		public override void GetSystemEventReadableHandles(out KObject _0, out KObject _1) {
			_0 = new Event();
			_1 = new Event();
		}
		
		public override void Cancel() => "Stub hit for Nn.Nifm.Detail.IRequest.Cancel [3]".Debug();
		public override void Submit() => "Stub hit for Nn.Nifm.Detail.IRequest.Submit [4]".Debug();
		public override void SetRequirement(byte[] _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRequirement [5]".Debug();
		public override void SetRequirementPreset(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRequirementPreset [6]".Debug();
		public override void SetPriority(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetPriority [8]".Debug();
		public override void SetNetworkProfileId(byte[] _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetNetworkProfileId [9]".Debug();
		public override void SetRejectable(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRejectable [10]".Debug();
		public override void SetConnectionConfirmationOption(sbyte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetConnectionConfirmationOption [11]".Debug();
		public override void SetPersistent(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetPersistent [12]".Debug();
		public override void SetInstant(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetInstant [13]".Debug();
		public override void SetSustainable(byte _0, byte _1) => "Stub hit for Nn.Nifm.Detail.IRequest.SetSustainable [14]".Debug();
		public override void SetRawPriority(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRawPriority [15]".Debug();
		public override void SetGreedy(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetGreedy [16]".Debug();
		public override void SetSharable(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetSharable [17]".Debug();
		public override void SetRequirementByRevision(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRequirementByRevision [18]".Debug();
		public override void GetRequirement(out byte[] _0) => throw new NotImplementedException();
		public override uint GetRevision() => throw new NotImplementedException();
		public override void GetAppletInfo(uint _0, out uint _1, out uint _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public override void GetAdditionalInfo(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void SetKeptInSleep(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetKeptInSleep [23]".Debug();
		public override void RegisterSocketDescriptor(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.RegisterSocketDescriptor [24]".Debug();
		public override void UnregisterSocketDescriptor(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.UnregisterSocketDescriptor [25]".Debug();
	}
}