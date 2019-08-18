using System;
using Supercell.Graphics;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nns.Hosbinder {
	public partial class IHOSBinderDriver {
		static readonly NVFlinger Flinger = new NVFlinger();
		
		public override void TransactParcel(int id, uint code, Buffer<byte> parcel_data, uint flags, Buffer<byte> parcel_reply) => throw new NotImplementedException();
		
		public override void AdjustRefcount(int id, int addVal, int type) => "Stub hit for Nns.Hosbinder.IHOSBinderDriver.AdjustRefcount [1]".Debug();
		
		public override KObject GetNativeHandle(int id, uint _1) => new Event(true);

		public override void TransactParcelAuto(int id, uint code, Buffer<byte> parcelData, uint flags,
			Buffer<byte> parcelReply) =>
			Flinger.ProcessParcel(parcelReply, Parcel.GetParcelData(parcelData), code);
	}
}