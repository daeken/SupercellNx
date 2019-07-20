#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ldn.Detail {
	[IpcService("ldn:m")]
	public unsafe partial class IMonitorServiceCreator : _Base_IMonitorServiceCreator {}
	public unsafe class _Base_IMonitorServiceCreator : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateMonitorService
					var ret = CreateMonitorService();
					om.Move(0, ret.Handle);
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateSystemLocalCommunicationService
					var ret = CreateSystemLocalCommunicationService();
					om.Move(0, ret.Handle);
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateUserLocalCommunicationService
					var ret = CreateUserLocalCommunicationService();
					om.Move(0, ret.Handle);
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetStateForMonitor
					var ret = GetStateForMonitor();
					om.SetData(0, ret);
					break;
				}
				case 1: { // GetNetworkInfoForMonitor
					GetNetworkInfoForMonitor(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 2: { // GetIpv4AddressForMonitor
					GetIpv4AddressForMonitor(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 3: { // GetDisconnectReasonForMonitor
					var ret = GetDisconnectReasonForMonitor();
					om.SetData(0, ret);
					break;
				}
				case 4: { // GetSecurityParameterForMonitor
					GetSecurityParameterForMonitor(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 5: { // GetNetworkConfigForMonitor
					GetNetworkConfigForMonitor(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // InitializeMonitor
					InitializeMonitor();
					break;
				}
				case 101: { // FinalizeMonitor
					FinalizeMonitor();
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
		public virtual void InitializeMonitor() => throw new NotImplementedException();
		public virtual void FinalizeMonitor() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystemLocalCommunicationService : _Base_ISystemLocalCommunicationService {}
	public unsafe class _Base_ISystemLocalCommunicationService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetState
					var ret = GetState();
					om.SetData(0, ret);
					break;
				}
				case 1: { // GetNetworkInfo
					GetNetworkInfo(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 2: { // GetIpv4Address
					GetIpv4Address(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 3: { // GetDisconnectReason
					var ret = GetDisconnectReason();
					om.SetData(0, ret);
					break;
				}
				case 4: { // GetSecurityParameter
					GetSecurityParameter(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 5: { // GetNetworkConfig
					GetNetworkConfig(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // AttachStateChangeEvent
					var ret = AttachStateChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 101: { // GetNetworkInfoLatestUpdate
					GetNetworkInfoLatestUpdate(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 102: { // Scan
					Scan(im.GetData<ushort>(0), im.GetBytes(2, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 103: { // ScanPrivate
					ScanPrivate(im.GetData<ushort>(0), im.GetBytes(2, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 200: { // OpenAccessPoint
					OpenAccessPoint();
					break;
				}
				case 201: { // CloseAccessPoint
					CloseAccessPoint();
					break;
				}
				case 202: { // CreateNetwork
					CreateNetwork(im.GetBytes(0, 0x44), im.GetBytes(68, 0x30), im.GetBytes(116, 0x20));
					break;
				}
				case 203: { // CreateNetworkPrivate
					CreateNetworkPrivate(im.GetBytes(0, 0x44), im.GetBytes(68, 0x20), im.GetBytes(100, 0x30), im.GetBytes(148, 0x20), im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 204: { // DestroyNetwork
					DestroyNetwork();
					break;
				}
				case 205: { // Reject
					Reject(im.GetData<uint>(0));
					break;
				}
				case 206: { // SetAdvertiseData
					SetAdvertiseData(im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 207: { // SetStationAcceptPolicy
					SetStationAcceptPolicy(im.GetData<byte>(0));
					break;
				}
				case 208: { // AddAcceptFilterEntry
					AddAcceptFilterEntry(im.GetBytes(0, 0x6));
					break;
				}
				case 209: { // ClearAcceptFilter
					ClearAcceptFilter();
					break;
				}
				case 300: { // OpenStation
					OpenStation();
					break;
				}
				case 301: { // CloseStation
					CloseStation();
					break;
				}
				case 302: { // Connect
					Connect(im.GetBytes(0, 0x44), im.GetBytes(68, 0x30), im.GetData<uint>(116), im.GetData<uint>(120), im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 303: { // ConnectPrivate
					ConnectPrivate(im.GetBytes(0, 0x44), im.GetBytes(68, 0x20), im.GetBytes(100, 0x30), im.GetData<uint>(148), im.GetData<uint>(152), im.GetBytes(156, 0x20));
					break;
				}
				case 304: { // Disconnect
					Disconnect();
					break;
				}
				case 400: { // InitializeSystem
					InitializeSystem(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 401: { // FinalizeSystem
					FinalizeSystem();
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
		public virtual void OpenAccessPoint() => throw new NotImplementedException();
		public virtual void CloseAccessPoint() => throw new NotImplementedException();
		public virtual void CreateNetwork(byte[] _0, byte[] _1, byte[] _2) => throw new NotImplementedException();
		public virtual void CreateNetworkPrivate(byte[] _0, byte[] _1, byte[] _2, byte[] _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void DestroyNetwork() => throw new NotImplementedException();
		public virtual void Reject(uint _0) => throw new NotImplementedException();
		public virtual void SetAdvertiseData(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetStationAcceptPolicy(byte _0) => throw new NotImplementedException();
		public virtual void AddAcceptFilterEntry(byte[] _0) => throw new NotImplementedException();
		public virtual void ClearAcceptFilter() => throw new NotImplementedException();
		public virtual void OpenStation() => throw new NotImplementedException();
		public virtual void CloseStation() => throw new NotImplementedException();
		public virtual void Connect(byte[] _0, byte[] _1, uint _2, uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void ConnectPrivate(byte[] _0, byte[] _1, byte[] _2, uint _3, uint _4, byte[] _5) => throw new NotImplementedException();
		public virtual void Disconnect() => throw new NotImplementedException();
		public virtual void InitializeSystem(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void FinalizeSystem() => throw new NotImplementedException();
	}
	
	public unsafe partial class IUserLocalCommunicationService : _Base_IUserLocalCommunicationService {}
	public unsafe class _Base_IUserLocalCommunicationService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetState
					var ret = GetState();
					om.SetData(0, ret);
					break;
				}
				case 1: { // GetNetworkInfo
					GetNetworkInfo(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 2: { // GetIpv4Address
					GetIpv4Address(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 3: { // GetDisconnectReason
					var ret = GetDisconnectReason();
					om.SetData(0, ret);
					break;
				}
				case 4: { // GetSecurityParameter
					GetSecurityParameter(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 5: { // GetNetworkConfig
					GetNetworkConfig(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // AttachStateChangeEvent
					var ret = AttachStateChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 101: { // GetNetworkInfoLatestUpdate
					GetNetworkInfoLatestUpdate(im.GetBuffer<byte>(0x1A, 0), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 102: { // Scan
					Scan(im.GetData<ushort>(0), im.GetBytes(2, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 103: { // ScanPrivate
					ScanPrivate(im.GetData<ushort>(0), im.GetBytes(2, 0x60), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 200: { // OpenAccessPoint
					OpenAccessPoint();
					break;
				}
				case 201: { // CloseAccessPoint
					CloseAccessPoint();
					break;
				}
				case 202: { // CreateNetwork
					CreateNetwork(im.GetBytes(0, 0x44), im.GetBytes(68, 0x30), im.GetBytes(116, 0x20));
					break;
				}
				case 203: { // CreateNetworkPrivate
					CreateNetworkPrivate(im.GetBytes(0, 0x44), im.GetBytes(68, 0x20), im.GetBytes(100, 0x30), im.GetBytes(148, 0x20), im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 204: { // DestroyNetwork
					DestroyNetwork();
					break;
				}
				case 205: { // Reject
					Reject(im.GetData<uint>(0));
					break;
				}
				case 206: { // SetAdvertiseData
					SetAdvertiseData(im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 207: { // SetStationAcceptPolicy
					SetStationAcceptPolicy(im.GetData<byte>(0));
					break;
				}
				case 208: { // AddAcceptFilterEntry
					AddAcceptFilterEntry(im.GetBytes(0, 0x6));
					break;
				}
				case 209: { // ClearAcceptFilter
					ClearAcceptFilter();
					break;
				}
				case 300: { // OpenStation
					OpenStation();
					break;
				}
				case 301: { // CloseStation
					CloseStation();
					break;
				}
				case 302: { // Connect
					Connect(im.GetBytes(0, 0x44), im.GetBytes(68, 0x30), im.GetData<uint>(116), im.GetData<uint>(120), im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 303: { // ConnectPrivate
					ConnectPrivate(im.GetBytes(0, 0x44), im.GetBytes(68, 0x20), im.GetBytes(100, 0x30), im.GetData<uint>(148), im.GetData<uint>(152), im.GetBytes(156, 0x20));
					break;
				}
				case 304: { // Disconnect
					Disconnect();
					break;
				}
				case 400: { // Initialize
					Initialize(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 401: { // Finalize
					Finalize();
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
		public virtual void OpenAccessPoint() => throw new NotImplementedException();
		public virtual void CloseAccessPoint() => throw new NotImplementedException();
		public virtual void CreateNetwork(byte[] _0, byte[] _1, byte[] _2) => throw new NotImplementedException();
		public virtual void CreateNetworkPrivate(byte[] _0, byte[] _1, byte[] _2, byte[] _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void DestroyNetwork() => throw new NotImplementedException();
		public virtual void Reject(uint _0) => throw new NotImplementedException();
		public virtual void SetAdvertiseData(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetStationAcceptPolicy(byte _0) => throw new NotImplementedException();
		public virtual void AddAcceptFilterEntry(byte[] _0) => throw new NotImplementedException();
		public virtual void ClearAcceptFilter() => throw new NotImplementedException();
		public virtual void OpenStation() => throw new NotImplementedException();
		public virtual void CloseStation() => throw new NotImplementedException();
		public virtual void Connect(byte[] _0, byte[] _1, uint _2, uint _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void ConnectPrivate(byte[] _0, byte[] _1, byte[] _2, uint _3, uint _4, byte[] _5) => throw new NotImplementedException();
		public virtual void Disconnect() => throw new NotImplementedException();
		public virtual void Initialize(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void Finalize() => throw new NotImplementedException();
	}
}
