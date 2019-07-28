#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Idle.Detail {
	[IpcService("idle:sys")]
	public unsafe partial class IPolicyManagerSystem : _Base_IPolicyManagerSystem {}
	public unsafe class _Base_IPolicyManagerSystem : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetAutoPowerDownEvent
					var ret = GetAutoPowerDownEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
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
					Unknown3(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPolicyManagerSystem: {im.CommandId}");
			}
		}
		
		public virtual KObject GetAutoPowerDownEvent() => throw new NotImplementedException();
		public virtual void Unknown1() => "Stub hit for Nn.Idle.Detail.IPolicyManagerSystem.Unknown1 [1]".Debug();
		public virtual void Unknown2() => "Stub hit for Nn.Idle.Detail.IPolicyManagerSystem.Unknown2 [2]".Debug();
		public virtual void Unknown3(object _0) => "Stub hit for Nn.Idle.Detail.IPolicyManagerSystem.Unknown3 [3]".Debug();
		public virtual void Unknown4() => "Stub hit for Nn.Idle.Detail.IPolicyManagerSystem.Unknown4 [4]".Debug();
		public virtual void Unknown5() => "Stub hit for Nn.Idle.Detail.IPolicyManagerSystem.Unknown5 [5]".Debug();
	}
}
