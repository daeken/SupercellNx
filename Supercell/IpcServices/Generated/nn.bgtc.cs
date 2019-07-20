#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bgtc {
	public unsafe partial class IStateControlService : _Base_IStateControlService {}
	public unsafe class _Base_IStateControlService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					var ret = Unknown1();
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
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStateControlService: {im.CommandId}");
			}
		}
		
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual KObject Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ITaskService : _Base_ITaskService {}
	public unsafe class _Base_ITaskService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Copy(0, ret.Handle);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6();
					break;
				}
				case 11: { // Unknown11
					Unknown11(null);
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12();
					break;
				}
				case 13: { // Unknown13
					Unknown13();
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14();
					om.Copy(0, ret.Handle);
					break;
				}
				case 15: { // Unknown15
					Unknown15(null);
					break;
				}
				case 101: { // Unknown101
					var ret = Unknown101();
					break;
				}
				case 102: { // Unknown102
					var ret = Unknown102();
					break;
				}
				case 103: { // Unknown103
					var ret = Unknown103();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ITaskService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual KObject Unknown3() => throw new NotImplementedException();
		public virtual object Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown6() => throw new NotImplementedException();
		public virtual void Unknown11(object _0) => throw new NotImplementedException();
		public virtual object Unknown12() => throw new NotImplementedException();
		public virtual void Unknown13() => throw new NotImplementedException();
		public virtual KObject Unknown14() => throw new NotImplementedException();
		public virtual void Unknown15(object _0) => throw new NotImplementedException();
		public virtual object Unknown101() => throw new NotImplementedException();
		public virtual object Unknown102() => throw new NotImplementedException();
		public virtual object Unknown103() => throw new NotImplementedException();
	}
}
