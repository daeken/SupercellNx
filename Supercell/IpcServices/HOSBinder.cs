using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nns.hosbinder {
	public class IHOSBinderDriver : IpcInterface {
		[IpcCommand(0)]
		void TransactParcel(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1)]
		void AdjustRefcount(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(2)]
		void GetNativeHandle(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(3)]
		void TransactParcelAuto(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
}