using System;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Visrv.Sf {
	public partial class IApplicationRootService {
		public override Nn.Visrv.Sf.IApplicationDisplayService GetDisplayService(uint _0) => new IApplicationDisplayService();
	}
	
	public partial class IManagerRootService {
		public override Nn.Visrv.Sf.IApplicationDisplayService GetDisplayService(uint _0) => new IApplicationDisplayService();
		public override Nn.Visrv.Sf.IApplicationDisplayService GetDisplayServiceWithProxyNameExchange(byte[] _0, uint _1) => new IApplicationDisplayService();
	}

	public partial class ISystemRootService {
		public override Nn.Visrv.Sf.IApplicationDisplayService GetDisplayService(uint _0) => new IApplicationDisplayService();
		public override Nn.Visrv.Sf.IApplicationDisplayService GetDisplayServiceWithProxyNameExchange(byte[] _0, uint _1) => new IApplicationDisplayService();
	}

	public partial class IApplicationDisplayService {
		public override Nns.Hosbinder.IHOSBinderDriver GetRelayService() => new Nns.Hosbinder.IHOSBinderDriver();
		public override Nn.Visrv.Sf.ISystemDisplayService GetSystemDisplayService() => new ISystemDisplayService();
		public override Nn.Visrv.Sf.IManagerDisplayService GetManagerDisplayService() => new IManagerDisplayService();
		public override Nns.Hosbinder.IHOSBinderDriver GetIndirectDisplayTransactionService() => new Nns.Hosbinder.IHOSBinderDriver();
		
		public override void ListDisplays(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();

		public override ulong OpenDisplay(byte[] _0) => 1;
		
		public override ulong OpenDefaultDisplay() => throw new NotImplementedException();
		public override void CloseDisplay(ulong _0) => "Stub hit for Nn.Visrv.Sf.IApplicationDisplayService.CloseDisplay [1020]".Debug();
		public override void SetDisplayEnabled(byte _0, ulong _1) => "Stub hit for Nn.Visrv.Sf.IApplicationDisplayService.SetDisplayEnabled [1101]".Debug();
		public override void GetDisplayResolution(ulong _0, out ulong _1, out ulong _2) => throw new NotImplementedException();
		
		public override void OpenLayer(byte[] displayName, ulong layerId, ulong userId, ulong pid,
			out ulong parcelLength, Buffer<byte> parcel) =>
			parcelLength = MakeIGraphicsBufferProducer(parcel);
		
		public override void CloseLayer(ulong _0) => "Stub hit for Nn.Visrv.Sf.IApplicationDisplayService.CloseLayer [2021]".Debug();
		public override void CreateStrayLayer(uint _0, ulong _1, out ulong _2, out ulong _3, Buffer<byte> _4) => throw new NotImplementedException();
		public override void DestroyStrayLayer(ulong _0) => "Stub hit for Nn.Visrv.Sf.IApplicationDisplayService.DestroyStrayLayer [2031]".Debug();
		public override void SetLayerScalingMode(uint _0, ulong _1) => "Stub hit for Nn.Visrv.Sf.IApplicationDisplayService.SetLayerScalingMode [2101]".Debug();
		public override object ConvertScalingMode(object _0) => throw new NotImplementedException();
		public override void GetIndirectLayerImageMap(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4, out ulong _5, out ulong _6, Buffer<byte> _7) => throw new NotImplementedException();
		public override void GetIndirectLayerImageCropMap(float _0, float _1, float _2, float _3, ulong _4, ulong _5, ulong _6, ulong _7, ulong _8, out ulong _9, out ulong _10, Buffer<byte> _11) => throw new NotImplementedException();
		public override void GetIndirectLayerImageRequiredMemoryInfo(ulong _0, ulong _1, out ulong _2, out ulong _3) => throw new NotImplementedException();
		
		public override KObject GetDisplayVsyncEvent(ulong _0) => new Event();
		
		public override KObject GetDisplayVsyncEventForDebug(ulong _0) => throw new NotImplementedException();
		
		ulong MakeIGraphicsBufferProducer(Buffer<byte> parcelBuffer) =>
			Parcel.MakeParcel(parcelBuffer, bw => {
				//flat_binder_object (size is 0x28)
				bw.Write(2); //Type (BINDER_TYPE_WEAK_BINDER)
				bw.Write(0); //Flags
				bw.Write(0x20);
				bw.Write(0);
				bw.Write(0);
				bw.Write(0);
				bw.Write((byte)'d');
				bw.Write((byte)'i');
				bw.Write((byte)'s');
				bw.Write((byte)'p');
				bw.Write((byte)'d');
				bw.Write((byte)'r');
				bw.Write((byte)'v');
				bw.Write((byte)'\0');
				bw.Write(0L); //Pad
			}, new byte[4]);
	}
}
