#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Usb.Pm {
	[IpcService("usb:pm")]
	public unsafe partial class IPmService : _Base_IPmService {}
	public unsafe class _Base_IPmService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Copy(0, ret.Handle);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPmService: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject Unknown2() => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4(object _0) => throw new NotImplementedException();
		public virtual object Unknown5(object _0) => throw new NotImplementedException();
	}
}
