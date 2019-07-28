#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ldn.Detail {
	[IpcService("ldn:m")]
	public unsafe partial class IMonitorServiceCreator : _Base_IMonitorServiceCreator {}
	public unsafe class _Base_IMonitorServiceCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateMonitorService
					var ret = CreateMonitorService();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IMonitorServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ldn.Detail.IMonitorService CreateMonitorService() => throw new NotImplementedException();
	}
	
	[IpcService("ldn:s")]
	public unsafe partial class ISystemServiceCreator : _Base_ISystemServiceCreator {}
	public unsafe class _Base_ISystemServiceCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateSystemLocalCommunicationService
					var ret = CreateSystemLocalCommunicationService();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ldn.Detail.ISystemLocalCommunicationService CreateSystemLocalCommunicationService() => throw new NotImplementedException();
	}
	
	[IpcService("ldn:u")]
	public unsafe partial class IUserServiceCreator : _Base_IUserServiceCreator {}
	public unsafe class _Base_IUserServiceCreator : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateUserLocalCommunicationService
					var ret = CreateUserLocalCommunicationService();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUserServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ldn.Detail.IUserLocalCommunicationService CreateUserLocalCommunicationService() => throw new NotImplementedException();
	}
	
	public unsafe partial class IMonitorService : _Base_IMonitorService {}
	public unsafe class _Base_IMonitorService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetStateForMonitor
					var ret = GetStateForMonitor();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetNetworkInfoForMonitor
					GetNetworkInfoForMonitor(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetIpv4AddressForMonitor
					GetIpv4AddressForMonitor(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 3: { // GetDisconnectReasonForMonitor
					var ret = GetDisconnectReasonForMonitor();
					om.Initialize(0, 0, 2);
					om.SetData(8, ret);
					break;
				}
				case 4: { // GetSecurityParameterForMonitor
					GetSecurityParameterForMonitor(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetNetworkConfigForMonitor
					GetNetworkConfigForMonitor(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 100: { // InitializeMonitor
					InitializeMonitor();
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // FinalizeMonitor
					FinalizeMonitor();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IMonitorService: {im.CommandId}");
			}
		}
		
		public virtual uint GetStateForMonitor() => throw new NotImplementedException();
		public virtual void GetNetworkInfoForMonitor(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetIpv4AddressForMonitor(out uint _0, out uint _1) => throw new NotImplementedException();
		public virtual ushort GetDisconnectReasonForMonitor() => throw new NotImplementedException();
		public virtual void GetSecurityParameterForMonitor(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetNetworkConfigForMonitor(out byte[] _0) => throw new NotImplementedException();
		public virtual void InitializeMonitor() => "Stub hit for Nn.Ldn.Detail.IMonitorService.InitializeMonitor [100]".Debug();
		public virtual void FinalizeMonitor() => "Stub hit for Nn.Ldn.Detail.IMonitorService.FinalizeMonitor [101]".Debug();
	}
	
	public unsafe partial class ISystemLocalCommunicationService : _Base_ISystemLocalCommunicationService {}
	public unsafe class _Base_ISystemLocalCommunicationService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetNetworkInfo
					GetNetworkInfo(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetIpv4Address
					GetIpv4Address(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 3: { // GetDisconnectReason
					var ret = GetDisconnectReason();
					om.Initialize(0, 0, 2);
					om.SetData(8, ret);
					break;
				}
				case 4: { // GetSecurityParameter
					GetSecurityParameter(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetNetworkConfig
					GetNetworkConfig(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 100: { // AttachStateChangeEvent
					var ret = AttachStateChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 101: { // GetNetworkInfoLatestUpdate
					GetNetworkInfoLatestUpdate(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // Scan
					Scan(im.GetData<ushort>(8), im.GetBytes(10, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					break;
				}
				case 103: { // ScanPrivate
					ScanPrivate(im.GetData<ushort>(8), im.GetBytes(10, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					break;
				}
				case 200: { // OpenAccessPoint
					OpenAccessPoint();
					om.Initialize(0, 0, 0);
					break;
				}
				case 201: { // CloseAccessPoint
					CloseAccessPoint();
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // CreateNetwork
					CreateNetwork(im.GetBytes(8, 0x44), im.GetBytes(76, 0x30), im.GetBytes(124, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 203: { // CreateNetworkPrivate
					CreateNetworkPrivate(im.GetBytes(8, 0x44), im.GetBytes(76, 0x20), im.GetBytes(108, 0x30), im.GetBytes(156, 0x20), im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 204: { // DestroyNetwork
					DestroyNetwork();
					om.Initialize(0, 0, 0);
					break;
				}
				case 205: { // Reject
					Reject(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 206: { // SetAdvertiseData
					SetAdvertiseData(im.GetBuffer<byte>(0x21, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 207: { // SetStationAcceptPolicy
					SetStationAcceptPolicy(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 208: { // AddAcceptFilterEntry
					AddAcceptFilterEntry(im.GetBytes(8, 0x6));
					om.Initialize(0, 0, 0);
					break;
				}
				case 209: { // ClearAcceptFilter
					ClearAcceptFilter();
					om.Initialize(0, 0, 0);
					break;
				}
				case 300: { // OpenStation
					OpenStation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // CloseStation
					CloseStation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // Connect
					Connect(im.GetBytes(8, 0x44), im.GetBytes(76, 0x30), im.GetData<uint>(124), im.GetData<uint>(128), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 303: { // ConnectPrivate
					ConnectPrivate(im.GetBytes(8, 0x44), im.GetBytes(76, 0x20), im.GetBytes(108, 0x30), im.GetData<uint>(156), im.GetData<uint>(160), im.GetBytes(164, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 304: { // Disconnect
					Disconnect();
					om.Initialize(0, 0, 0);
					break;
				}
				case 400: { // InitializeSystem
					InitializeSystem(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 401: { // FinalizeSystem
					FinalizeSystem();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemLocalCommunicationService: {im.CommandId}");
			}
		}
		
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual void GetNetworkInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetIpv4Address(out uint _0, out uint _1) => throw new NotImplementedException();
		public virtual ushort GetDisconnectReason() => throw new NotImplementedException();
		public virtual void GetSecurityParameter(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetNetworkConfig(out byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachStateChangeEvent() => throw new NotImplementedException();
		public virtual void GetNetworkInfoLatestUpdate(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Scan(ushort _0, byte[] _1, out ushort _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void ScanPrivate(ushort _0, byte[] _1, out ushort _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void OpenAccessPoint() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.OpenAccessPoint [200]".Debug();
		public virtual void CloseAccessPoint() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.CloseAccessPoint [201]".Debug();
		public virtual void CreateNetwork(byte[] _0, byte[] _1, byte[] _2) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.CreateNetwork [202]".Debug();
		public virtual void CreateNetworkPrivate(byte[] _0, byte[] _1, byte[] _2, byte[] _3, Buffer<byte> _4) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.CreateNetworkPrivate [203]".Debug();
		public virtual void DestroyNetwork() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.DestroyNetwork [204]".Debug();
		public virtual void Reject(uint _0) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.Reject [205]".Debug();
		public virtual void SetAdvertiseData(Buffer<byte> _0) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.SetAdvertiseData [206]".Debug();
		public virtual void SetStationAcceptPolicy(byte _0) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.SetStationAcceptPolicy [207]".Debug();
		public virtual void AddAcceptFilterEntry(byte[] _0) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.AddAcceptFilterEntry [208]".Debug();
		public virtual void ClearAcceptFilter() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.ClearAcceptFilter [209]".Debug();
		public virtual void OpenStation() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.OpenStation [300]".Debug();
		public virtual void CloseStation() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.CloseStation [301]".Debug();
		public virtual void Connect(byte[] _0, byte[] _1, uint _2, uint _3, Buffer<byte> _4) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.Connect [302]".Debug();
		public virtual void ConnectPrivate(byte[] _0, byte[] _1, byte[] _2, uint _3, uint _4, byte[] _5) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.ConnectPrivate [303]".Debug();
		public virtual void Disconnect() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.Disconnect [304]".Debug();
		public virtual void InitializeSystem(ulong _0, ulong _1) => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.InitializeSystem [400]".Debug();
		public virtual void FinalizeSystem() => "Stub hit for Nn.Ldn.Detail.ISystemLocalCommunicationService.FinalizeSystem [401]".Debug();
	}
	
	public unsafe partial class IUserLocalCommunicationService : _Base_IUserLocalCommunicationService {}
	public unsafe class _Base_IUserLocalCommunicationService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // GetNetworkInfo
					GetNetworkInfo(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetIpv4Address
					GetIpv4Address(out var _0, out var _1);
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 3: { // GetDisconnectReason
					var ret = GetDisconnectReason();
					om.Initialize(0, 0, 2);
					om.SetData(8, ret);
					break;
				}
				case 4: { // GetSecurityParameter
					GetSecurityParameter(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // GetNetworkConfig
					GetNetworkConfig(out var _0);
					om.Initialize(0, 0, 32);
					om.SetBytes(8, _0);
					break;
				}
				case 100: { // AttachStateChangeEvent
					var ret = AttachStateChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 101: { // GetNetworkInfoLatestUpdate
					GetNetworkInfoLatestUpdate(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // Scan
					Scan(im.GetData<ushort>(8), im.GetBytes(10, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					break;
				}
				case 103: { // ScanPrivate
					ScanPrivate(im.GetData<ushort>(8), im.GetBytes(10, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.Initialize(0, 0, 2);
					om.SetData(8, _0);
					break;
				}
				case 200: { // OpenAccessPoint
					OpenAccessPoint();
					om.Initialize(0, 0, 0);
					break;
				}
				case 201: { // CloseAccessPoint
					CloseAccessPoint();
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // CreateNetwork
					CreateNetwork(im.GetBytes(8, 0x44), im.GetBytes(76, 0x30), im.GetBytes(124, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 203: { // CreateNetworkPrivate
					CreateNetworkPrivate(im.GetBytes(8, 0x44), im.GetBytes(76, 0x20), im.GetBytes(108, 0x30), im.GetBytes(156, 0x20), im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 204: { // DestroyNetwork
					DestroyNetwork();
					om.Initialize(0, 0, 0);
					break;
				}
				case 205: { // Reject
					Reject(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 206: { // SetAdvertiseData
					SetAdvertiseData(im.GetBuffer<byte>(0x21, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 207: { // SetStationAcceptPolicy
					SetStationAcceptPolicy(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 208: { // AddAcceptFilterEntry
					AddAcceptFilterEntry(im.GetBytes(8, 0x6));
					om.Initialize(0, 0, 0);
					break;
				}
				case 209: { // ClearAcceptFilter
					ClearAcceptFilter();
					om.Initialize(0, 0, 0);
					break;
				}
				case 300: { // OpenStation
					OpenStation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 301: { // CloseStation
					CloseStation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 302: { // Connect
					Connect(im.GetBytes(8, 0x44), im.GetBytes(76, 0x30), im.GetData<uint>(124), im.GetData<uint>(128), im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 303: { // ConnectPrivate
					ConnectPrivate(im.GetBytes(8, 0x44), im.GetBytes(76, 0x20), im.GetBytes(108, 0x30), im.GetData<uint>(156), im.GetData<uint>(160), im.GetBytes(164, 0x20));
					om.Initialize(0, 0, 0);
					break;
				}
				case 304: { // Disconnect
					Disconnect();
					om.Initialize(0, 0, 0);
					break;
				}
				case 400: { // Initialize
					Initialize(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				case 401: { // Finalize
					Finalize();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IUserLocalCommunicationService: {im.CommandId}");
			}
		}
		
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual void GetNetworkInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetIpv4Address(out uint _0, out uint _1) => throw new NotImplementedException();
		public virtual ushort GetDisconnectReason() => throw new NotImplementedException();
		public virtual void GetSecurityParameter(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetNetworkConfig(out byte[] _0) => throw new NotImplementedException();
		public virtual KObject AttachStateChangeEvent() => throw new NotImplementedException();
		public virtual void GetNetworkInfoLatestUpdate(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Scan(ushort _0, byte[] _1, out ushort _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void ScanPrivate(ushort _0, byte[] _1, out ushort _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void OpenAccessPoint() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.OpenAccessPoint [200]".Debug();
		public virtual void CloseAccessPoint() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.CloseAccessPoint [201]".Debug();
		public virtual void CreateNetwork(byte[] _0, byte[] _1, byte[] _2) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.CreateNetwork [202]".Debug();
		public virtual void CreateNetworkPrivate(byte[] _0, byte[] _1, byte[] _2, byte[] _3, Buffer<byte> _4) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.CreateNetworkPrivate [203]".Debug();
		public virtual void DestroyNetwork() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.DestroyNetwork [204]".Debug();
		public virtual void Reject(uint _0) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.Reject [205]".Debug();
		public virtual void SetAdvertiseData(Buffer<byte> _0) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.SetAdvertiseData [206]".Debug();
		public virtual void SetStationAcceptPolicy(byte _0) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.SetStationAcceptPolicy [207]".Debug();
		public virtual void AddAcceptFilterEntry(byte[] _0) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.AddAcceptFilterEntry [208]".Debug();
		public virtual void ClearAcceptFilter() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.ClearAcceptFilter [209]".Debug();
		public virtual void OpenStation() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.OpenStation [300]".Debug();
		public virtual void CloseStation() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.CloseStation [301]".Debug();
		public virtual void Connect(byte[] _0, byte[] _1, uint _2, uint _3, Buffer<byte> _4) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.Connect [302]".Debug();
		public virtual void ConnectPrivate(byte[] _0, byte[] _1, byte[] _2, uint _3, uint _4, byte[] _5) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.ConnectPrivate [303]".Debug();
		public virtual void Disconnect() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.Disconnect [304]".Debug();
		public virtual void Initialize(ulong _0, ulong _1) => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.Initialize [400]".Debug();
		public virtual void Finalize() => "Stub hit for Nn.Ldn.Detail.IUserLocalCommunicationService.Finalize [401]".Debug();
	}
}
