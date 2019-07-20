#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Usb.Hs {
	[IpcService("usb:hs")]
	public unsafe partial class IClientRootSession : _Base_IClientRootSession {}
	public unsafe class _Base_IClientRootSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BindClientProcess
					BindClientProcess(Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 1: { // Unknown1
					Unknown1(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 6: { // GetInterfaceStateChangeEvent
					var ret = GetInterfaceStateChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 7: { // GetClientIfSession
					GetClientIfSession(null, im.GetBuffer<byte>(0x6, 0), im.GetBuffer<byte>(0x6, 1), out var _2);
					om.Move(0, _2.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IClientRootSession: {im.CommandId}");
			}
		}
		
		public virtual void BindClientProcess(KObject _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown3(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual KObject GetInterfaceStateChangeEvent() => throw new NotImplementedException();
		public virtual void GetClientIfSession(object _0, Buffer<byte> _1, Buffer<byte> _2, out Nn.Usb.Hs.IClientIfSession _3) => throw new NotImplementedException();
	}
	
	public unsafe partial class IClientEpSession : _Base_IClientEpSession {}
	public unsafe class _Base_IClientEpSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Copy(0, ret.Handle);
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				case 4: { // PostBufferAsync
					var ret = PostBufferAsync(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null, out var _0, im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6(null, im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 7: { // Unknown7
					Unknown7(null);
					break;
				}
				case 8: { // Unknown8
					Unknown8(null, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IClientEpSession: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual KObject Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
		public virtual object PostBufferAsync(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown6(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown7(object _0) => throw new NotImplementedException();
		public virtual void Unknown8(object _0, KObject _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IClientIfSession : _Base_IClientIfSession {}
	public unsafe class _Base_IClientIfSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					break;
				}
				case 5: { // CtrlXferAsync
					CtrlXferAsync(null);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6();
					om.Copy(0, ret.Handle);
					break;
				}
				case 7: { // GetCtrlXferReport
					GetCtrlXferReport(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 8: { // Unknown8
					Unknown8();
					break;
				}
				case 9: { // GetClientEpSession
					GetClientEpSession(null, out var _0, out var _1);
					om.Move(0, _1.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IClientIfSession: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown4() => throw new NotImplementedException();
		public virtual void CtrlXferAsync(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown6() => throw new NotImplementedException();
		public virtual void GetCtrlXferReport(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown8() => throw new NotImplementedException();
		public virtual void GetClientEpSession(object _0, out object _1, out Nn.Usb.Hs.IClientEpSession _2) => throw new NotImplementedException();
	}
}
