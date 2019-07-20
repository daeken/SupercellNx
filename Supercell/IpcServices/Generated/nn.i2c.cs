#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.I2c {
	[IpcService("i2c")]
	[IpcService("i2c:pcv")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSessionForDev
					var ret = OpenSessionForDev(im.GetData<ushort>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<uint>(12));
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // OpenSession
					var ret = OpenSession(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // HasDevice
					var ret = HasDevice(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // HasDeviceForDev
					var ret = HasDeviceForDev(im.GetData<ushort>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<uint>(12));
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.I2c.ISession OpenSessionForDev(ushort _0, uint _1, uint _2, uint _3) => throw new NotImplementedException();
		public virtual Nn.I2c.ISession OpenSession(uint _0) => throw new NotImplementedException();
		public virtual byte HasDevice(uint _0) => throw new NotImplementedException();
		public virtual byte HasDeviceForDev(ushort _0, uint _1, uint _2, uint _3) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Send
					Send(im.GetData<uint>(0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // Receive
					Receive(im.GetData<uint>(0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // ExecuteCommandList
					ExecuteCommandList(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 10: { // SendAuto
					SendAuto(im.GetData<uint>(0), im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 11: { // ReceiveAuto
					ReceiveAuto(im.GetData<uint>(0), im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 12: { // ExecuteCommandListAuto
					ExecuteCommandListAuto(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x22, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISession: {im.CommandId}");
			}
		}
		
		public virtual void Send(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Receive(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExecuteCommandList(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SendAuto(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ReceiveAuto(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExecuteCommandListAuto(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
}
