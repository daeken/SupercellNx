using System;
using Supercell.IpcServices.nns.hosbinder;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.visrv.sf {
	[IpcService("vi:m")]
	public class IManagerRootService : IpcInterface {
		[IpcCommand(2)]
		void GetDisplayService(uint unknown0, [Move] out IApplicationDisplayService service) =>
			service = new IApplicationDisplayService();

		[IpcCommand(3)]
		void GetDisplayServiceWithProxyNameExchange([Bytes(0x8 /* 8 x 1 */)] byte[] /* nn::vi::ProxyName */ unknown0,
			uint unknown1, [Move] out IApplicationDisplayService service) => service = new IApplicationDisplayService();
	}
	
	[IpcService("vi:s")]
	public class ISystemRootService : IpcInterface {
		[IpcCommand(1)]
		void GetDisplayService(uint unknown0, [Move] out IApplicationDisplayService service) =>
			service = new IApplicationDisplayService();

		[IpcCommand(3)]
		void GetDisplayServiceWithProxyNameExchange([Bytes(0x8 /* 8 x 1 */)] byte[] /* nn::vi::ProxyName */ unknown0,
			uint unknown1, [Move] out IApplicationDisplayService service) =>
			service = new IApplicationDisplayService();
	}
	
	[IpcService("vi:u")]
	public class IApplicationRootService : IpcInterface {
		[IpcCommand(0)]
		void GetDisplayService(uint unknown0, [Move] out IApplicationDisplayService service) =>
			service = new IApplicationDisplayService();
	}

	public class IApplicationDisplayService : IpcInterface {
		[IpcCommand(100)]
		void GetRelayService([Move] out IHOSBinderDriver service) => service = new IHOSBinderDriver();

		[IpcCommand(101)]
		void GetSystemDisplayService([Move] out ISystemDisplayService service) => service = new ISystemDisplayService();

		[IpcCommand(102)]
		void GetManagerDisplayService([Move] out IManagerDisplayService service) =>
			service = new IManagerDisplayService();
		
		[IpcCommand(103)]
		void GetIndirectDisplayTransactionService(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(1000)]
		void ListDisplays(out ulong unknown0, [Buffer(0x6)] Buffer<byte /* nn::vi::DisplayInfo */> unknown1) => throw new NotImplementedException();
		[IpcCommand(1010)]
		void OpenDisplay([Bytes(0x40 /* 64 x 1 */)] byte[] /* nn::vi::DisplayName */ unknown0, out ulong displayId) => displayId = 1;
		[IpcCommand(1011)]
		void OpenDefaultDisplay(out ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(1020)]
		void CloseDisplay(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(1101)]
		void SetDisplayEnabled(bool unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(1102)]
		void GetDisplayResolution(ulong unknown0, out ulong unknown1, out ulong unknown2) => throw new NotImplementedException();
		
		[IpcCommand(2020)]
		void OpenLayer([Bytes(0x40)] byte[] displayName, ulong layerId, ulong userId, [Pid] ulong pid, out ulong parcelLength, [Buffer(0x6)] Buffer<byte> parcel) => throw new NotImplementedException();
		
		[IpcCommand(2021)]
		void CloseLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2030)]
		void CreateStrayLayer(uint unknown0, ulong unknown1, out ulong unknown2, out ulong unknown3, [Buffer(0x6)] Buffer<byte> unknown4) => throw new NotImplementedException();
		[IpcCommand(2031)]
		void DestroyStrayLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2101)]
		void SetLayerScalingMode(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(2102)]
		void ConvertScalingMode(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(2450)]
		void GetIndirectLayerImageMap(ulong unknown0, ulong unknown1, ulong unknown2, ulong /* nn::applet::AppletResourceUserId */ unknown3, [Pid] ulong pid, out ulong unknown4, out ulong unknown5, [Buffer(0x46)] Buffer<byte> unknown6) => throw new NotImplementedException();
		[IpcCommand(2451)]
		void GetIndirectLayerImageCropMap(float unknown0, float unknown1, float unknown2, float unknown3, ulong unknown4, ulong unknown5, ulong unknown6, ulong /* nn::applet::AppletResourceUserId */ unknown7, [Pid] ulong pid, out ulong unknown8, out ulong unknown9, [Buffer(0x46)] Buffer<byte> unknown10) => throw new NotImplementedException();
		[IpcCommand(2460)]
		void GetIndirectLayerImageRequiredMemoryInfo(ulong unknown0, ulong unknown1, out ulong unknown2, out ulong unknown3) => throw new NotImplementedException();
		[IpcCommand(5202)]
		void GetDisplayVsyncEvent(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(5203)]
		void GetDisplayVsyncEventForDebug(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
	}
	
	public class IManagerDisplayService : IpcInterface {
		[IpcCommand(200)]
		void AllocateProcessHeapBlock(ulong unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(201)]
		void FreeProcessHeapBlock(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(1102)]
		void GetDisplayResolution(ulong unknown0, out ulong unknown1, out ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(2010)]
		void CreateManagedLayer(uint unknown0, ulong unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, out ulong unknown3) => throw new NotImplementedException();
		[IpcCommand(2011)]
		void DestroyManagedLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2050)]
		void CreateIndirectLayer(out ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2051)]
		void DestroyIndirectLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2052)]
		void CreateIndirectProducerEndPoint(ulong unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, out ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(2053)]
		void DestroyIndirectProducerEndPoint(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2054)]
		void CreateIndirectConsumerEndPoint(ulong unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, out ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(2055)]
		void DestroyIndirectConsumerEndPoint(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2300)]
		void AcquireLayerTexturePresentingEvent(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(2301)]
		void ReleaseLayerTexturePresentingEvent(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2302)]
		void GetDisplayHotplugEvent(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(2402)]
		void GetDisplayHotplugState(ulong unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(2501)]
		void GetCompositorErrorInfo(ulong unknown0, ulong unknown1, out uint unknown2, [Buffer(0x16)] Buffer<byte /* nn::vi::CompositorError */> unknown3) => throw new NotImplementedException();
		[IpcCommand(2601)]
		void GetDisplayErrorEvent(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(4201)]
		void SetDisplayAlpha(float unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(4203)]
		void SetDisplayLayerStack(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(4205)]
		void SetDisplayPowerState(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(4206)]
		void SetDefaultDisplay(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(6000)]
		void AddToLayerStack(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(6001)]
		void RemoveFromLayerStack(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(6002)]
		void SetLayerVisibility(bool unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(6003)]
		void SetLayerConfig(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6004)]
		void AttachLayerPresentationTracer(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6005)]
		void DetachLayerPresentationTracer(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6006)]
		void StartLayerPresentationRecording(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6007)]
		void StopLayerPresentationRecording(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6008)]
		void StartLayerPresentationFenceWait(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6009)]
		void StopLayerPresentationFenceWait(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(6010)]
		void GetLayerPresentationAllFencesExpiredEvent(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(7000)]
		void SetContentVisibility(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(8000)]
		void SetConductorLayer(bool unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(8100)]
		void SetIndirectProducerFlipOffset(ulong unknown0, ulong unknown1, ulong /* nn::TimeBuffer */ unknown2) => throw new NotImplementedException();
		[IpcCommand(8200)]
		void CreateSharedBufferStaticStorage(ulong unknown0, [Buffer(0x15)] Buffer<byte /* nn::vi::fbshare::SharedMemoryPoolLayout */> unknown1, out ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown2) => throw new NotImplementedException();
		[IpcCommand(8201)]
		void CreateSharedBufferTransferMemory(ulong unknown0, [Move] KObject unknown1, [Buffer(0x15)] Buffer<byte /* nn::vi::fbshare::SharedMemoryPoolLayout */> unknown2, out ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown3) => throw new NotImplementedException();
		[IpcCommand(8202)]
		void DestroySharedBuffer(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8203)]
		void BindSharedLowLevelLayerToManagedLayer([Bytes(0x40 /* 64 x 1 */)] byte[] /* nn::vi::DisplayName */ unknown0, ulong unknown1, ulong /* nn::applet::AppletResourceUserId */ unknown2, [Pid] ulong pid) => throw new NotImplementedException();
		[IpcCommand(8204)]
		void BindSharedLowLevelLayerToIndirectLayer(ulong unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) => throw new NotImplementedException();
		[IpcCommand(8207)]
		void UnbindSharedLowLevelLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(8208)]
		void ConnectSharedLowLevelLayerToSharedBuffer(ulong unknown0, ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown1) => throw new NotImplementedException();
		[IpcCommand(8209)]
		void DisconnectSharedLowLevelLayerFromSharedBuffer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(8210)]
		void CreateSharedLayer(ulong /* nn::applet::AppletResourceUserId */ unknown0, out ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown1) => throw new NotImplementedException();
		[IpcCommand(8211)]
		void DestroySharedLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8216)]
		void AttachSharedLayerToLowLevelLayer([Bytes(0x40 /* 16 x 4 */)] byte[] /* nn::vi::fbshare::SharedLayerTextureIndexList */ unknown0, ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown1, ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(8217)]
		void ForceDetachSharedLayerFromLowLevelLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8218)]
		void StartDetachSharedLayerFromLowLevelLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8219)]
		void FinishDetachSharedLayerFromLowLevelLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8220)]
		void GetSharedLayerDetachReadyEvent(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(8221)]
		void GetSharedLowLevelLayerSynchronizedEvent(ulong unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(8222)]
		void CheckSharedLowLevelLayerSynchronized(ulong unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(8223)]
		void RegisterSharedBufferImporterAruid(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(8224)]
		void UnregisterSharedBufferImporterAruid(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1) => throw new NotImplementedException();
		[IpcCommand(8227)]
		void CreateSharedBufferProcessHeap(ulong unknown0, [Buffer(0x15)] Buffer<byte /* nn::vi::fbshare::SharedMemoryPoolLayout */> unknown1, out ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown2) => throw new NotImplementedException();
		[IpcCommand(8228)]
		void GetSharedLayerLayerStacks(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(8229)]
		void SetSharedLayerLayerStacks(uint unknown0, ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown1) => throw new NotImplementedException();
		[IpcCommand(8291)]
		void PresentDetachedSharedFrameBufferToLowLevelLayer(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, ulong unknown1, ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(8292)]
		void FillDetachedSharedFrameBufferColor(uint unknown0, uint unknown1, uint unknown2, uint unknown3, uint unknown4, ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown5, ulong unknown6) => throw new NotImplementedException();
		[IpcCommand(8293)]
		void GetDetachedSharedFrameBufferImage(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, ulong unknown1, out ulong unknown2, [Buffer(0x6)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(8294)]
		void SetDetachedSharedFrameBufferImage(uint unknown0, ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown1, ulong unknown2, [Buffer(0x5)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(8295)]
		void CopyDetachedSharedFrameBufferImage(uint unknown0, uint unknown1, ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown2, ulong unknown3, ulong unknown4) => throw new NotImplementedException();
		[IpcCommand(8296)]
		void SetDetachedSharedFrameBufferSubImage(uint unknown0, uint unknown1, uint unknown2, uint unknown3, uint unknown4, uint unknown5, ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown6, ulong unknown7, [Buffer(0x5)] Buffer<byte> unknown8) => throw new NotImplementedException();
		[IpcCommand(8297)]
		void GetSharedFrameBufferContentParameter(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, ulong unknown1, out uint unknown2, [Bytes(0x40 /* 16 x 4 */)] out byte[] /* nn::vi::CropRegion */ unknown3, out uint unknown4, out uint unknown5, out uint unknown6) => throw new NotImplementedException();
		[IpcCommand(8298)]
		void ExpandStartupLogoOnSharedFrameBuffer(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
	
	public class ISystemDisplayService : IpcInterface {
		[IpcCommand(1200)]
		void GetZOrderCountMin(ulong unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(1202)]
		void GetZOrderCountMax(ulong unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(1203)]
		void GetDisplayLogicalResolution(ulong unknown0, out uint unknown1, out uint unknown2) => throw new NotImplementedException();
		[IpcCommand(1204)]
		void SetDisplayMagnification(uint unknown0, uint unknown1, uint unknown2, uint unknown3, ulong unknown4) => throw new NotImplementedException();
		[IpcCommand(2201)]
		void SetLayerPosition(float unknown0, float unknown1, ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(2203)]
		void SetLayerSize(ulong unknown0, ulong unknown1, ulong unknown2) => throw new NotImplementedException();
		[IpcCommand(2204)]
		void GetLayerZ(ulong unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(2205)]
		void SetLayerZ(ulong unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(2207)]
		void SetLayerVisibility(bool unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(2209)]
		void SetLayerAlpha(float unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(2312)]
		void CreateStrayLayer(uint unknown0, ulong unknown1, out ulong unknown2, out ulong unknown3, [Buffer(0x6)] Buffer<byte> unknown4) => throw new NotImplementedException();
		[IpcCommand(2400)]
		void OpenIndirectLayer(ulong unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out ulong unknown2, [Buffer(0x6)] Buffer<byte> unknown3) => throw new NotImplementedException();
		[IpcCommand(2401)]
		void CloseIndirectLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(2402)]
		void FlipIndirectLayer(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(3000)]
		void ListDisplayModes(ulong unknown0, out ulong unknown1, [Buffer(0x6)] Buffer<byte /* nn::vi::DisplayModeInfo */> unknown2) => throw new NotImplementedException();
		[IpcCommand(3001)]
		void ListDisplayRgbRanges(ulong unknown0, out ulong unknown1, [Buffer(0x6)] Buffer<uint> unknown2) => throw new NotImplementedException();
		[IpcCommand(3002)]
		void ListDisplayContentTypes(ulong unknown0, out ulong unknown1, [Buffer(0x6)] Buffer<uint> unknown2) => throw new NotImplementedException();
		[IpcCommand(3200)]
		void GetDisplayMode(ulong unknown0, out object /* nn::vi::DisplayModeInfo */ unknown1) => throw new NotImplementedException();
		[IpcCommand(3201)]
		void SetDisplayMode(ulong unknown0, object /* nn::vi::DisplayModeInfo */ unknown1) => throw new NotImplementedException();
		[IpcCommand(3202)]
		void GetDisplayUnderscan(ulong unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3203)]
		void SetDisplayUnderscan(ulong unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3204)]
		void GetDisplayContentType(ulong unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(3205)]
		void SetDisplayContentType(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3206)]
		void GetDisplayRgbRange(ulong unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(3207)]
		void SetDisplayRgbRange(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3208)]
		void GetDisplayCmuMode(ulong unknown0, out uint unknown1) => throw new NotImplementedException();
		[IpcCommand(3209)]
		void SetDisplayCmuMode(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3210)]
		void GetDisplayContrastRatio(ulong unknown0, out float unknown1) => throw new NotImplementedException();
		[IpcCommand(3211)]
		void SetDisplayContrastRatio(float unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3214)]
		void GetDisplayGamma(ulong unknown0, out float unknown1) => throw new NotImplementedException();
		[IpcCommand(3215)]
		void SetDisplayGamma(float unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(3216)]
		void GetDisplayCmuLuma(ulong unknown0, out float unknown1) => throw new NotImplementedException();
		[IpcCommand(3217)]
		void SetDisplayCmuLuma(float unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(8225)]
		void GetSharedBufferMemoryHandleId(ulong /* nn::vi::fbshare::SharedBufferHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid, out uint /* nn::vi::native::NativeMemoryHandleId */ unknown2, out ulong unknown3, [Buffer(0x16)] Buffer<byte /* nn::vi::fbshare::SharedMemoryPoolLayout */> unknown4) => throw new NotImplementedException();
		[IpcCommand(8250)]
		void OpenSharedLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0, ulong /* nn::applet::AppletResourceUserId */ unknown1, [Pid] ulong pid) => throw new NotImplementedException();
		[IpcCommand(8251)]
		void CloseSharedLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8252)]
		void ConnectSharedLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8253)]
		void DisconnectSharedLayer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0) => throw new NotImplementedException();
		[IpcCommand(8254)]
		void AcquireSharedFrameBuffer(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0, [Bytes(0x90 /* 36 x 4 */)] out byte[] /* nn::vi::native::NativeSync */ unknown1, [Bytes(0x40 /* 16 x 4 */)] out byte[] /* nn::vi::fbshare::SharedLayerTextureIndexList */ unknown2, out ulong unknown3) => throw new NotImplementedException();
		[IpcCommand(8255)]
		void PresentSharedFrameBuffer([Bytes(0x90 /* 36 x 4 */)] byte[] /* nn::vi::native::NativeSync */ unknown0, [Bytes(0x40 /* 16 x 4 */)] byte[] /* nn::vi::CropRegion */ unknown1, uint unknown2, uint unknown3, ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown4, ulong unknown5) => throw new NotImplementedException();
		[IpcCommand(8256)]
		void GetSharedFrameBufferAcquirableEvent(ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown0, [Move] out KObject unknown1) => throw new NotImplementedException();
		[IpcCommand(8257)]
		void FillSharedFrameBufferColor(uint unknown0, uint unknown1, uint unknown2, uint unknown3, ulong /* nn::vi::fbshare::SharedLayerHandle */ unknown4, ulong unknown5) => throw new NotImplementedException();
		[IpcCommand(8258)]
		void CancelSharedFrameBuffer(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
}
