#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Sf.Hipc.Detail {
	public unsafe partial class IHipcManager : _Base_IHipcManager {}
	public unsafe class _Base_IHipcManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHipcManager: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual IpcInterface Unknown1(object _0) => throw new NotImplementedException();
		public virtual IpcInterface Unknown2() => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
		public virtual IpcInterface Unknown4(object _0) => throw new NotImplementedException();
	}
}
