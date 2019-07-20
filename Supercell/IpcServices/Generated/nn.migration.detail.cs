#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Migration.Detail {
	public unsafe partial class IAsyncContext : _Base_IAsyncContext {}
	public unsafe class _Base_IAsyncContext : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAsyncContext: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
	}
}
