#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Lbl.Detail {
	[IpcService("lbl")]
	public unsafe partial class ILblController : _Base_ILblController {}
	public unsafe class _Base_ILblController : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // TurnOnBacklight
					TurnOnBacklight(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // TurnOffBacklight
					TurnOffBacklight(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // GetBacklightStatus
					var ret = GetBacklightStatus();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // Unknown9
					Unknown9();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Unknown10
					Unknown10();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // Unknown12
					Unknown12();
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
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // Unknown15
					Unknown15(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // ReadRawLightSensor
					var ret = ReadRawLightSensor();
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // Unknown17
					Unknown17(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // Unknown19
					Unknown19(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // Unknown20
					var ret = Unknown20();
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // Unknown21
					Unknown21(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // Unknown22
					var ret = Unknown22();
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25();
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // EnableVrMode
					EnableVrMode();
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // DisableVrMode
					DisableVrMode();
					om.Initialize(0, 0, 0);
					break;
				}
				case 28: { // GetVrMode
					var ret = GetVrMode();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILblController: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown0 [0]".Debug();
		public virtual void Unknown1() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown1 [1]".Debug();
		public virtual void Unknown2(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown2 [2]".Debug();
		public virtual object Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown4 [4]".Debug();
		public virtual object Unknown5() => throw new NotImplementedException();
		public virtual void TurnOnBacklight(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.TurnOnBacklight [6]".Debug();
		public virtual void TurnOffBacklight(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.TurnOffBacklight [7]".Debug();
		public virtual object GetBacklightStatus() => throw new NotImplementedException();
		public virtual void Unknown9() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown9 [9]".Debug();
		public virtual void Unknown10() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown10 [10]".Debug();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual void Unknown12() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown12 [12]".Debug();
		public virtual void Unknown13() => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown13 [13]".Debug();
		public virtual object Unknown14() => throw new NotImplementedException();
		public virtual void Unknown15(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown15 [15]".Debug();
		public virtual object ReadRawLightSensor() => throw new NotImplementedException();
		public virtual void Unknown17(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown17 [17]".Debug();
		public virtual object Unknown18(object _0) => throw new NotImplementedException();
		public virtual void Unknown19(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown19 [19]".Debug();
		public virtual object Unknown20() => throw new NotImplementedException();
		public virtual void Unknown21(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown21 [21]".Debug();
		public virtual object Unknown22() => throw new NotImplementedException();
		public virtual object Unknown23() => throw new NotImplementedException();
		public virtual void Unknown24(object _0) => "Stub hit for Nn.Lbl.Detail.ILblController.Unknown24 [24]".Debug();
		public virtual object Unknown25() => throw new NotImplementedException();
		public virtual void EnableVrMode() => "Stub hit for Nn.Lbl.Detail.ILblController.EnableVrMode [26]".Debug();
		public virtual void DisableVrMode() => "Stub hit for Nn.Lbl.Detail.ILblController.DisableVrMode [27]".Debug();
		public virtual object GetVrMode() => throw new NotImplementedException();
	}
}
