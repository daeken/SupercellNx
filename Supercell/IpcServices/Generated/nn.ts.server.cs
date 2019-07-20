#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ts.Server {
	[IpcService("ts")]
	public unsafe partial class IMeasurementServer : _Base_IMeasurementServer {}
	public unsafe class _Base_IMeasurementServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IMeasurementServer: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual object Unknown1(object _0) => throw new NotImplementedException();
		public virtual void Unknown2(object _0) => throw new NotImplementedException();
		public virtual object Unknown3(object _0) => throw new NotImplementedException();
	}
}
