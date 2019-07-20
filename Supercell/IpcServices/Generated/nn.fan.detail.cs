#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Fan.Detail {
	[IpcService("fan")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5(null);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6(null);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Fan.Detail.IController Unknown0(object _0) => throw new NotImplementedException();
		public virtual object Unknown1(object _0) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual object Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
		public virtual object Unknown5(object _0) => throw new NotImplementedException();
		public virtual object Unknown6(object _0) => throw new NotImplementedException();
		public virtual object Unknown7(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IController : _Base_IController {}
	public unsafe class _Base_IController : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					break;
				}
				case 6: { // Unknown6
					Unknown6();
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IController: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0) => throw new NotImplementedException();
		public virtual object Unknown1(object _0) => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5() => throw new NotImplementedException();
		public virtual void Unknown6() => throw new NotImplementedException();
		public virtual object Unknown7() => throw new NotImplementedException();
	}
}
