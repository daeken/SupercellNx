#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Sf.Hipc.Detail {
	public unsafe partial class IHipcManager : _Base_IHipcManager {}
	public unsafe class _Base_IHipcManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
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
