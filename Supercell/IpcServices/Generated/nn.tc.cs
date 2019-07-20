#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Tc {
	[IpcService("tc")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetOperatingMode
					SetOperatingMode(null);
					break;
				}
				case 1: { // GetThermalEvent
					var ret = GetThermalEvent(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 6: { // Unknown6
					Unknown6();
					break;
				}
				case 7: { // Unknown7
					Unknown7();
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual void SetOperatingMode(object _0) => throw new NotImplementedException();
		public virtual KObject GetThermalEvent(object _0) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual void Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual void Unknown6() => throw new NotImplementedException();
		public virtual void Unknown7() => throw new NotImplementedException();
		public virtual object Unknown8() => throw new NotImplementedException();
	}
}
