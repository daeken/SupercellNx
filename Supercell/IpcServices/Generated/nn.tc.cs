#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Tc {
	[IpcService("tc")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetOperatingMode
					SetOperatingMode(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetThermalEvent
					var ret = GetThermalEvent(null);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unknown6
					Unknown6();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // Unknown7
					Unknown7();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual void SetOperatingMode(object _0) => "Stub hit for Nn.Tc.IManager.SetOperatingMode [0]".Debug();
		public virtual KObject GetThermalEvent(object _0) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => "Stub hit for Nn.Tc.IManager.Unknown3 [3]".Debug();
		public virtual void Unknown4(object _0) => "Stub hit for Nn.Tc.IManager.Unknown4 [4]".Debug();
		public virtual void Unknown5(object _0) => "Stub hit for Nn.Tc.IManager.Unknown5 [5]".Debug();
		public virtual void Unknown6() => "Stub hit for Nn.Tc.IManager.Unknown6 [6]".Debug();
		public virtual void Unknown7() => "Stub hit for Nn.Tc.IManager.Unknown7 [7]".Debug();
		public virtual object Unknown8() => throw new NotImplementedException();
	}
}
