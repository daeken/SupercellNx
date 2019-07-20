#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Idle.Detail {
	[IpcService("idle:sys")]
	public unsafe partial class IPolicyManagerSystem : _Base_IPolicyManagerSystem {}
	public unsafe class _Base_IPolicyManagerSystem : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAutoPowerDownEvent
					var ret = GetAutoPowerDownEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPolicyManagerSystem: {im.CommandId}");
			}
		}
		
		public virtual KObject GetAutoPowerDownEvent() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5() => throw new NotImplementedException();
	}
}
