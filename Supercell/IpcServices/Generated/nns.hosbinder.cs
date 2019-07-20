#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nns.Hosbinder {
	[IpcService("dispdrv")]
	public unsafe partial class IHOSBinderDriver : _Base_IHOSBinderDriver {}
	public unsafe class _Base_IHOSBinderDriver : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // TransactParcel
					var ret = TransactParcel(null);
					break;
				}
				case 1: { // AdjustRefcount
					var ret = AdjustRefcount(null);
					break;
				}
				case 2: { // GetNativeHandle
					var ret = GetNativeHandle(null);
					break;
				}
				case 3: { // TransactParcelAuto
					var ret = TransactParcelAuto(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IHOSBinderDriver: {im.CommandId}");
			}
		}
		
		public virtual object TransactParcel(object _0) => throw new NotImplementedException();
		public virtual object AdjustRefcount(object _0) => throw new NotImplementedException();
		public virtual object GetNativeHandle(object _0) => throw new NotImplementedException();
		public virtual object TransactParcelAuto(object _0) => throw new NotImplementedException();
	}
}
