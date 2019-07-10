using System;
using Supercell.Graphics;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nns.hosbinder {
	public class IHOSBinderDriver : IpcInterface {
		static readonly NVFlinger Flinger = new NVFlinger();
		
		[IpcCommand(0)]
		void TransactParcel(int id, uint code, [Buffer(5)] Buffer<byte> parcelData, [Buffer(6)] Buffer<byte> parcelReply, uint flags) => throw new NotImplementedException();
		
		[IpcCommand(1)]
		void AdjustRefcount(int id, int addVal, int type) {}
		
		[IpcCommand(2)]
		void GetNativeHandle(int id, uint unknown, [Move] out KEvent handle) => handle = new KEvent();

		[IpcCommand(3)]
		uint TransactParcelAuto(int id, uint code, [Buffer(0x21)] Buffer<byte> parcelData,
			[Buffer(0x22)] Buffer<byte> parcelReply, uint flags) =>
			Flinger.ProcessParcel(parcelReply, Parcel.GetParcelData(parcelData), code);
	}
}