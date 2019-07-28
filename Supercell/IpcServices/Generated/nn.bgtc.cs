#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bgtc {
	public unsafe partial class IStateControlService : _Base_IStateControlService {}
	public unsafe class _Base_IStateControlService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					var ret = Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStateControlService: {im.CommandId}");
			}
		}
		
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual KObject Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3() => "Stub hit for Nn.Bgtc.IStateControlService.Unknown3 [3]".Debug();
		public virtual void Unknown4() => "Stub hit for Nn.Bgtc.IStateControlService.Unknown4 [4]".Debug();
		public virtual void Unknown5(object _0) => "Stub hit for Nn.Bgtc.IStateControlService.Unknown5 [5]".Debug();
	}
	
	public unsafe partial class ITaskService : _Base_ITaskService {}
	public unsafe class _Base_ITaskService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Unknown11
					Unknown11(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // Unknown13
					Unknown13();
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 15: { // Unknown15
					Unknown15(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // Unknown101
					var ret = Unknown101();
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // Unknown102
					var ret = Unknown102();
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // Unknown103
					var ret = Unknown103();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ITaskService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1() => "Stub hit for Nn.Bgtc.ITaskService.Unknown1 [1]".Debug();
		public virtual void Unknown2() => "Stub hit for Nn.Bgtc.ITaskService.Unknown2 [2]".Debug();
		public virtual KObject Unknown3() => throw new NotImplementedException();
		public virtual object Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(Buffer<byte> _0) => "Stub hit for Nn.Bgtc.ITaskService.Unknown5 [5]".Debug();
		public virtual object Unknown6() => throw new NotImplementedException();
		public virtual void Unknown11(object _0) => "Stub hit for Nn.Bgtc.ITaskService.Unknown11 [11]".Debug();
		public virtual object Unknown12() => throw new NotImplementedException();
		public virtual void Unknown13() => "Stub hit for Nn.Bgtc.ITaskService.Unknown13 [13]".Debug();
		public virtual KObject Unknown14() => throw new NotImplementedException();
		public virtual void Unknown15(object _0) => "Stub hit for Nn.Bgtc.ITaskService.Unknown15 [15]".Debug();
		public virtual object Unknown101() => throw new NotImplementedException();
		public virtual object Unknown102() => throw new NotImplementedException();
		public virtual object Unknown103() => throw new NotImplementedException();
	}
}
