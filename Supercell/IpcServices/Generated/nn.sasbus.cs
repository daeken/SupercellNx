#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Sasbus {
	[IpcService("sasbus")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSession
					var ret = OpenSession(null);
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Sasbus.ISession OpenSession(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(null, im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISession: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown1(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, KObject _1) => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
	}
}
