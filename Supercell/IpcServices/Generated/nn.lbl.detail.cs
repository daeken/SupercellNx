#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Lbl.Detail {
	[IpcService("lbl")]
	public unsafe partial class ILblController : _Base_ILblController {}
	public unsafe class _Base_ILblController : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5();
					break;
				}
				case 6: { // TurnOnBacklight
					TurnOnBacklight(null);
					break;
				}
				case 7: { // TurnOffBacklight
					TurnOffBacklight(null);
					break;
				}
				case 8: { // GetBacklightStatus
					var ret = GetBacklightStatus();
					break;
				}
				case 9: { // Unknown9
					Unknown9();
					break;
				}
				case 10: { // Unknown10
					Unknown10();
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					break;
				}
				case 12: { // Unknown12
					Unknown12();
					break;
				}
				case 13: { // Unknown13
					Unknown13();
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14();
					break;
				}
				case 15: { // Unknown15
					Unknown15(null);
					break;
				}
				case 16: { // ReadRawLightSensor
					var ret = ReadRawLightSensor();
					break;
				}
				case 17: { // Unknown17
					Unknown17(null);
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18(null);
					break;
				}
				case 19: { // Unknown19
					Unknown19(null);
					break;
				}
				case 20: { // Unknown20
					var ret = Unknown20();
					break;
				}
				case 21: { // Unknown21
					Unknown21(null);
					break;
				}
				case 22: { // Unknown22
					var ret = Unknown22();
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25();
					break;
				}
				case 26: { // EnableVrMode
					EnableVrMode();
					break;
				}
				case 27: { // DisableVrMode
					DisableVrMode();
					break;
				}
				case 28: { // GetVrMode
					var ret = GetVrMode();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILblController: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2(object _0) => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual object Unknown5() => throw new NotImplementedException();
		public virtual void TurnOnBacklight(object _0) => throw new NotImplementedException();
		public virtual void TurnOffBacklight(object _0) => throw new NotImplementedException();
		public virtual object GetBacklightStatus() => throw new NotImplementedException();
		public virtual void Unknown9() => throw new NotImplementedException();
		public virtual void Unknown10() => throw new NotImplementedException();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual void Unknown12() => throw new NotImplementedException();
		public virtual void Unknown13() => throw new NotImplementedException();
		public virtual object Unknown14() => throw new NotImplementedException();
		public virtual void Unknown15(object _0) => throw new NotImplementedException();
		public virtual object ReadRawLightSensor() => throw new NotImplementedException();
		public virtual void Unknown17(object _0) => throw new NotImplementedException();
		public virtual object Unknown18(object _0) => throw new NotImplementedException();
		public virtual void Unknown19(object _0) => throw new NotImplementedException();
		public virtual object Unknown20() => throw new NotImplementedException();
		public virtual void Unknown21(object _0) => throw new NotImplementedException();
		public virtual object Unknown22() => throw new NotImplementedException();
		public virtual object Unknown23() => throw new NotImplementedException();
		public virtual void Unknown24(object _0) => throw new NotImplementedException();
		public virtual object Unknown25() => throw new NotImplementedException();
		public virtual void EnableVrMode() => throw new NotImplementedException();
		public virtual void DisableVrMode() => throw new NotImplementedException();
		public virtual object GetVrMode() => throw new NotImplementedException();
	}
}
