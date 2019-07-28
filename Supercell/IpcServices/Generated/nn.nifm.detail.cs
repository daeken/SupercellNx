#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nifm.Detail {
	[IpcService("nifm:u")]
	[IpcService("nifm:a")]
	[IpcService("nifm:s")]
	public unsafe partial class IStaticService : _Base_IStaticService {}
	public unsafe class _Base_IStaticService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 4: { // CreateGeneralServiceOld
					var ret = CreateGeneralServiceOld();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 5: { // CreateGeneralService
					var ret = CreateGeneralService(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStaticService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Nifm.Detail.IGeneralService CreateGeneralServiceOld() => throw new NotImplementedException();
		public virtual Nn.Nifm.Detail.IGeneralService CreateGeneralService(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IGeneralService : _Base_IGeneralService {}
	public unsafe class _Base_IGeneralService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // GetClientId
					GetClientId(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // CreateScanRequest
					var ret = CreateScanRequest();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 4: { // CreateRequest
					var ret = CreateRequest(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 5: { // GetCurrentNetworkProfile
					GetCurrentNetworkProfile(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // EnumerateNetworkInterfaces
					EnumerateNetworkInterfaces(im.GetData<uint>(8), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 7: { // EnumerateNetworkProfiles
					EnumerateNetworkProfiles(im.GetData<byte>(8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 8: { // GetNetworkProfile
					GetNetworkProfile(im.GetBytes(8, 0x10), im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // SetNetworkProfile
					SetNetworkProfile(im.GetBuffer<byte>(0x19, 0), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 10: { // RemoveNetworkProfile
					RemoveNetworkProfile(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // GetScanDataOld
					GetScanDataOld(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 12: { // GetCurrentIpAddress
					GetCurrentIpAddress(out var _0);
					om.Initialize(0, 0, 4);
					om.SetBytes(8, _0);
					break;
				}
				case 13: { // GetCurrentAccessPointOld
					GetCurrentAccessPointOld(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // CreateTemporaryNetworkProfile
					CreateTemporaryNetworkProfile(im.GetBuffer<byte>(0x19, 0), out var _0, out var _1);
					om.Initialize(1, 0, 16);
					om.SetBytes(8, _0);
					om.Move(0, CreateHandle(_1));
					break;
				}
				case 15: { // GetCurrentIpConfigInfo
					GetCurrentIpConfigInfo(out var _0, out var _1);
					om.Initialize(0, 0, 22);
					om.SetBytes(8, _0);
					om.SetBytes(21, _1);
					break;
				}
				case 16: { // SetWirelessCommunicationEnabled
					SetWirelessCommunicationEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // IsWirelessCommunicationEnabled
					var ret = IsWirelessCommunicationEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 18: { // GetInternetConnectionStatus
					GetInternetConnectionStatus(out var _0);
					om.Initialize(0, 0, 3);
					om.SetBytes(8, _0);
					break;
				}
				case 19: { // SetEthernetCommunicationEnabled
					SetEthernetCommunicationEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // IsEthernetCommunicationEnabled
					var ret = IsEthernetCommunicationEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 21: { // IsAnyInternetRequestAccepted
					var ret = IsAnyInternetRequestAccepted(im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 22: { // IsAnyForegroundRequestAccepted
					var ret = IsAnyForegroundRequestAccepted();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 23: { // PutToSleep
					PutToSleep();
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // WakeUp
					WakeUp();
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // GetSsidListVersion
					GetSsidListVersion(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 26: { // SetExclusiveClient
					SetExclusiveClient(im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // GetDefaultIpSetting
					GetDefaultIpSetting(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 28: { // SetDefaultIpSetting
					SetDefaultIpSetting(im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 29: { // SetWirelessCommunicationEnabledForTest
					SetWirelessCommunicationEnabledForTest(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // SetEthernetCommunicationEnabledForTest
					SetEthernetCommunicationEnabledForTest(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // GetTelemetorySystemEventReadableHandle
					var ret = GetTelemetorySystemEventReadableHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 32: { // GetTelemetryInfo
					GetTelemetryInfo(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 33: { // ConfirmSystemAvailability
					ConfirmSystemAvailability();
					om.Initialize(0, 0, 0);
					break;
				}
				case 34: { // SetBackgroundRequestEnabled
					SetBackgroundRequestEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 35: { // GetScanData
					GetScanData(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 36: { // GetCurrentAccessPoint
					GetCurrentAccessPoint(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 37: { // Shutdown
					Shutdown();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IGeneralService: {im.CommandId}");
			}
		}
		
		public virtual void GetClientId(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual Nn.Nifm.Detail.IScanRequest CreateScanRequest() => throw new NotImplementedException();
		public virtual Nn.Nifm.Detail.IRequest CreateRequest(uint _0) => throw new NotImplementedException();
		public virtual void GetCurrentNetworkProfile(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void EnumerateNetworkInterfaces(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void EnumerateNetworkProfiles(byte _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetNetworkProfile(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetNetworkProfile(Buffer<byte> _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void RemoveNetworkProfile(byte[] _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.RemoveNetworkProfile [10]".Debug();
		public virtual void GetScanDataOld(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetCurrentIpAddress(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetCurrentAccessPointOld(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void CreateTemporaryNetworkProfile(Buffer<byte> _0, out byte[] _1, out Nn.Nifm.Detail.INetworkProfile _2) => throw new NotImplementedException();
		public virtual void GetCurrentIpConfigInfo(out byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void SetWirelessCommunicationEnabled(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetWirelessCommunicationEnabled [16]".Debug();
		public virtual byte IsWirelessCommunicationEnabled() => throw new NotImplementedException();
		public virtual void GetInternetConnectionStatus(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetEthernetCommunicationEnabled(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetEthernetCommunicationEnabled [19]".Debug();
		public virtual byte IsEthernetCommunicationEnabled() => throw new NotImplementedException();
		public virtual byte IsAnyInternetRequestAccepted(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual byte IsAnyForegroundRequestAccepted() => throw new NotImplementedException();
		public virtual void PutToSleep() => "Stub hit for Nn.Nifm.Detail.IGeneralService.PutToSleep [23]".Debug();
		public virtual void WakeUp() => "Stub hit for Nn.Nifm.Detail.IGeneralService.WakeUp [24]".Debug();
		public virtual void GetSsidListVersion(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetExclusiveClient(Buffer<byte> _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetExclusiveClient [26]".Debug();
		public virtual void GetDefaultIpSetting(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetDefaultIpSetting(Buffer<byte> _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetDefaultIpSetting [28]".Debug();
		public virtual void SetWirelessCommunicationEnabledForTest(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetWirelessCommunicationEnabledForTest [29]".Debug();
		public virtual void SetEthernetCommunicationEnabledForTest(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetEthernetCommunicationEnabledForTest [30]".Debug();
		public virtual KObject GetTelemetorySystemEventReadableHandle() => throw new NotImplementedException();
		public virtual void GetTelemetryInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ConfirmSystemAvailability() => "Stub hit for Nn.Nifm.Detail.IGeneralService.ConfirmSystemAvailability [33]".Debug();
		public virtual void SetBackgroundRequestEnabled(byte _0) => "Stub hit for Nn.Nifm.Detail.IGeneralService.SetBackgroundRequestEnabled [34]".Debug();
		public virtual void GetScanData(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetCurrentAccessPoint(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Shutdown() => "Stub hit for Nn.Nifm.Detail.IGeneralService.Shutdown [37]".Debug();
	}
	
	public unsafe partial class INetworkProfile : _Base_INetworkProfile {}
	public unsafe class _Base_INetworkProfile : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Update
					Update(im.GetBuffer<byte>(0x19, 0), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 1: { // PersistOld
					PersistOld(im.GetBytes(8, 0x10), out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 2: { // Persist
					Persist(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INetworkProfile: {im.CommandId}");
			}
		}
		
		public virtual void Update(Buffer<byte> _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void PersistOld(byte[] _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void Persist(out byte[] _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IRequest : _Base_IRequest {}
	public unsafe class _Base_IRequest : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetRequestState
					var ret = GetRequestState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetSystemEventReadableHandles
					GetSystemEventReadableHandles(out var _0, out var _1);
					om.Initialize(0, 2, 0);
					om.Copy(0, CreateHandle(_0, copy: true));
					om.Copy(1, CreateHandle(_1, copy: true));
					break;
				}
				case 3: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Submit
					Submit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // SetRequirement
					SetRequirement(im.GetBytes(8, 0x24));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // SetRequirementPreset
					SetRequirementPreset(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // SetPriority
					SetPriority(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // SetNetworkProfileId
					SetNetworkProfileId(im.GetBytes(8, 0x10));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // SetRejectable
					SetRejectable(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // SetConnectionConfirmationOption
					SetConnectionConfirmationOption(im.GetData<sbyte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // SetPersistent
					SetPersistent(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // SetInstant
					SetInstant(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // SetSustainable
					SetSustainable(im.GetData<byte>(8), im.GetData<byte>(9));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // SetRawPriority
					SetRawPriority(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // SetGreedy
					SetGreedy(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // SetSharable
					SetSharable(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // SetRequirementByRevision
					SetRequirementByRevision(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // GetRequirement
					GetRequirement(out var _0);
					om.Initialize(0, 0, 36);
					om.SetBytes(8, _0);
					break;
				}
				case 20: { // GetRevision
					var ret = GetRevision();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 21: { // GetAppletInfo
					GetAppletInfo(im.GetData<uint>(8), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 22: { // GetAdditionalInfo
					GetAdditionalInfo(out var _0, im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 23: { // SetKeptInSleep
					SetKeptInSleep(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // RegisterSocketDescriptor
					RegisterSocketDescriptor(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // UnregisterSocketDescriptor
					UnregisterSocketDescriptor(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequest: {im.CommandId}");
			}
		}
		
		public virtual uint GetRequestState() => throw new NotImplementedException();
		public virtual void GetResult() => "Stub hit for Nn.Nifm.Detail.IRequest.GetResult [1]".Debug();
		public virtual void GetSystemEventReadableHandles(out KObject _0, out KObject _1) => throw new NotImplementedException();
		public virtual void Cancel() => "Stub hit for Nn.Nifm.Detail.IRequest.Cancel [3]".Debug();
		public virtual void Submit() => "Stub hit for Nn.Nifm.Detail.IRequest.Submit [4]".Debug();
		public virtual void SetRequirement(byte[] _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRequirement [5]".Debug();
		public virtual void SetRequirementPreset(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRequirementPreset [6]".Debug();
		public virtual void SetPriority(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetPriority [8]".Debug();
		public virtual void SetNetworkProfileId(byte[] _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetNetworkProfileId [9]".Debug();
		public virtual void SetRejectable(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRejectable [10]".Debug();
		public virtual void SetConnectionConfirmationOption(sbyte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetConnectionConfirmationOption [11]".Debug();
		public virtual void SetPersistent(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetPersistent [12]".Debug();
		public virtual void SetInstant(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetInstant [13]".Debug();
		public virtual void SetSustainable(byte _0, byte _1) => "Stub hit for Nn.Nifm.Detail.IRequest.SetSustainable [14]".Debug();
		public virtual void SetRawPriority(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRawPriority [15]".Debug();
		public virtual void SetGreedy(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetGreedy [16]".Debug();
		public virtual void SetSharable(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetSharable [17]".Debug();
		public virtual void SetRequirementByRevision(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetRequirementByRevision [18]".Debug();
		public virtual void GetRequirement(out byte[] _0) => throw new NotImplementedException();
		public virtual uint GetRevision() => throw new NotImplementedException();
		public virtual void GetAppletInfo(uint _0, out uint _1, out uint _2, out uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void GetAdditionalInfo(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetKeptInSleep(byte _0) => "Stub hit for Nn.Nifm.Detail.IRequest.SetKeptInSleep [23]".Debug();
		public virtual void RegisterSocketDescriptor(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.RegisterSocketDescriptor [24]".Debug();
		public virtual void UnregisterSocketDescriptor(uint _0) => "Stub hit for Nn.Nifm.Detail.IRequest.UnregisterSocketDescriptor [25]".Debug();
	}
	
	public unsafe partial class IScanRequest : _Base_IScanRequest {}
	public unsafe class _Base_IScanRequest : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Submit
					Submit();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // IsProcessing
					var ret = IsProcessing();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 2: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetSystemEventReadableHandle
					var ret = GetSystemEventReadableHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IScanRequest: {im.CommandId}");
			}
		}
		
		public virtual void Submit() => "Stub hit for Nn.Nifm.Detail.IScanRequest.Submit [0]".Debug();
		public virtual byte IsProcessing() => throw new NotImplementedException();
		public virtual void GetResult() => "Stub hit for Nn.Nifm.Detail.IScanRequest.GetResult [2]".Debug();
		public virtual KObject GetSystemEventReadableHandle() => throw new NotImplementedException();
	}
}
