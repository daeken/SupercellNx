#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Tma {
	[IpcService("htc")]
	public unsafe partial class IHtcManager : _Base_IHtcManager {}
	public unsafe class _Base_IHtcManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetEnvironmentVariable
					GetEnvironmentVariable(im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1: { // GetEnvironmentVariableLength
					var ret = GetEnvironmentVariableLength(im.GetBuffer<byte>(0x5, 0));
					om.SetData(0, ret);
					break;
				}
				case 2: { // BindHostConnectionEvent
					var ret = BindHostConnectionEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 3: { // BindHostDisconnectionEvent
					var ret = BindHostDisconnectionEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 4: { // BindHostConnectionEventForSystem
					var ret = BindHostConnectionEventForSystem();
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // BindHostDisconnectionEventForSystem
					var ret = BindHostDisconnectionEventForSystem();
					om.Copy(0, ret.Handle);
					break;
				}
				case 6: { // GetBridgeIpAddress
					GetBridgeIpAddress(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 7: { // GetBridgePort
					GetBridgePort(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 8: { // SetUsbDetachedForDebug
					SetUsbDetachedForDebug(im.GetData<byte>(0));
					break;
				}
				case 9: { // GetBridgeSubnetMask
					GetBridgeSubnetMask(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 10: { // GetBridgeMacAddress
					GetBridgeMacAddress(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHtcManager: {im.CommandId}");
			}
		}
		
		public virtual void GetEnvironmentVariable(Buffer<byte> _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual uint GetEnvironmentVariableLength(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject BindHostConnectionEvent() => throw new NotImplementedException();
		public virtual KObject BindHostDisconnectionEvent() => throw new NotImplementedException();
		public virtual KObject BindHostConnectionEventForSystem() => throw new NotImplementedException();
		public virtual KObject BindHostDisconnectionEventForSystem() => throw new NotImplementedException();
		public virtual void GetBridgeIpAddress(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetBridgePort(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetUsbDetachedForDebug(byte _0) => throw new NotImplementedException();
		public virtual void GetBridgeSubnetMask(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetBridgeMacAddress(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	[IpcService("htcs")]
	public unsafe partial class IHtcsManager : _Base_IHtcsManager {}
	public unsafe class _Base_IHtcsManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetBytes(0, 0x42), im.GetData<uint>(68), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetBytes(0, 0x42), im.GetData<uint>(68), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 4: { // Unknown4
					Unknown4(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetData<uint>(0), out var _0, out var _1, out var _2);
					om.SetBytes(0, _0);
					om.SetData(68, _1);
					om.SetData(72, _2);
					break;
				}
				case 6: { // Unknown6
					Unknown6(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 7: { // Unknown7
					Unknown7(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 8: { // Unknown8
					Unknown8(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 9: { // Unknown9
					Unknown9(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 10: { // GetPeerNameAny
					GetPeerNameAny(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 11: { // GetDefaultHostName
					GetDefaultHostName(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 12: { // CreateSocketOld
					CreateSocketOld(out var _0, out var _1);
					om.SetData(0, _0);
					om.Move(0, _1.Handle);
					break;
				}
				case 13: { // CreateSocket
					CreateSocket(im.GetData<byte>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.Move(0, _1.Handle);
					break;
				}
				case 100: { // RegisterProcessId
					RegisterProcessId(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 101: { // MonitorManager
					MonitorManager(im.GetData<ulong>(0), im.Pid);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHtcsManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(out uint _0, out uint _1) => throw new NotImplementedException();
		public virtual void Unknown1(uint _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void Unknown2(byte[] _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Unknown3(byte[] _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Unknown4(uint _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Unknown5(uint _0, out byte[] _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Unknown6(uint _0, uint _1, out uint _2, out ulong _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void Unknown7(uint _0, uint _1, Buffer<byte> _2, out uint _3, out ulong _4) => throw new NotImplementedException();
		public virtual void Unknown8(uint _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void Unknown9(uint _0, uint _1, uint _2, out uint _3, out uint _4) => throw new NotImplementedException();
		public virtual void GetPeerNameAny(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetDefaultHostName(out byte[] _0) => throw new NotImplementedException();
		public virtual void CreateSocketOld(out uint _0, out IpcInterface _1) => throw new NotImplementedException();
		public virtual void CreateSocket(byte _0, out uint _1, out IpcInterface _2) => throw new NotImplementedException();
		public virtual void RegisterProcessId(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void MonitorManager(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISocket : _Base_ISocket {}
	public unsafe class _Base_ISocket : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // _Close
					_Close(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 1: { // Connect
					Connect(im.GetBytes(0, 0x42), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 2: { // Bind
					Bind(im.GetBytes(0, 0x42), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 3: { // Listen
					Listen(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 4: { // Accept
					Accept(out var _0, out var _1, out var _2);
					om.SetBytes(0, _0);
					om.SetData(68, _1);
					om.Move(0, _2.Handle);
					break;
				}
				case 5: { // Recv
					Recv(im.GetData<uint>(0), out var _0, out var _1, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 6: { // Send
					Send(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 7: { // Shutdown
					Shutdown(im.GetData<uint>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 8: { // Fcntl
					Fcntl(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISocket: {im.CommandId}");
			}
		}
		
		public virtual void _Close(out uint _0, out uint _1) => throw new NotImplementedException();
		public virtual void Connect(byte[] _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void Bind(byte[] _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void Listen(uint _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void Accept(out byte[] _0, out uint _1, out IpcInterface _2) => throw new NotImplementedException();
		public virtual void Recv(uint _0, out uint _1, out ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Send(uint _0, Buffer<byte> _1, out uint _2, out ulong _3) => throw new NotImplementedException();
		public virtual void Shutdown(uint _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void Fcntl(uint _0, uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
	}
}
