#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Visrv.Sf {
	[IpcService("vi:u")]
	public unsafe partial class IApplicationRootService : _Base_IApplicationRootService {}
	public unsafe class _Base_IApplicationRootService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetDisplayService
					var ret = GetDisplayService(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationRootService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Visrv.Sf.IApplicationDisplayService GetDisplayService(uint _0) => throw new NotImplementedException();
	}
	
	[IpcService("vi:m")]
	public unsafe partial class IManagerRootService : _Base_IManagerRootService {}
	public unsafe class _Base_IManagerRootService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 2: { // GetDisplayService
					var ret = GetDisplayService(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // GetDisplayServiceWithProxyNameExchange
					var ret = GetDisplayServiceWithProxyNameExchange(im.GetBytes(0, 0x8), im.GetData<uint>(8));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerRootService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Visrv.Sf.IApplicationDisplayService GetDisplayService(uint _0) => throw new NotImplementedException();
		public virtual Nn.Visrv.Sf.IApplicationDisplayService GetDisplayServiceWithProxyNameExchange(byte[] _0, uint _1) => throw new NotImplementedException();
	}
	
	[IpcService("vi:s")]
	public unsafe partial class ISystemRootService : _Base_ISystemRootService {}
	public unsafe class _Base_ISystemRootService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // GetDisplayService
					var ret = GetDisplayService(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // GetDisplayServiceWithProxyNameExchange
					var ret = GetDisplayServiceWithProxyNameExchange(im.GetBytes(0, 0x8), im.GetData<uint>(8));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemRootService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Visrv.Sf.IApplicationDisplayService GetDisplayService(uint _0) => throw new NotImplementedException();
		public virtual Nn.Visrv.Sf.IApplicationDisplayService GetDisplayServiceWithProxyNameExchange(byte[] _0, uint _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IApplicationDisplayService : _Base_IApplicationDisplayService {}
	public unsafe class _Base_IApplicationDisplayService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 100: { // GetRelayService
					var ret = GetRelayService();
					om.Move(0, ret.Handle);
					break;
				}
				case 101: { // GetSystemDisplayService
					var ret = GetSystemDisplayService();
					om.Move(0, ret.Handle);
					break;
				}
				case 102: { // GetManagerDisplayService
					var ret = GetManagerDisplayService();
					om.Move(0, ret.Handle);
					break;
				}
				case 103: { // GetIndirectDisplayTransactionService
					var ret = GetIndirectDisplayTransactionService();
					om.Move(0, ret.Handle);
					break;
				}
				case 1000: { // ListDisplays
					ListDisplays(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 1010: { // OpenDisplay
					var ret = OpenDisplay(im.GetBytes(0, 0x40));
					om.SetData(0, ret);
					break;
				}
				case 1011: { // OpenDefaultDisplay
					var ret = OpenDefaultDisplay();
					om.SetData(0, ret);
					break;
				}
				case 1020: { // CloseDisplay
					CloseDisplay(im.GetData<ulong>(0));
					break;
				}
				case 1101: { // SetDisplayEnabled
					SetDisplayEnabled(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 1102: { // GetDisplayResolution
					GetDisplayResolution(im.GetData<ulong>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 2020: { // OpenLayer
					OpenLayer(im.GetBytes(0, 0x40), im.GetData<ulong>(64), im.GetData<ulong>(72), im.Pid, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 2021: { // CloseLayer
					CloseLayer(im.GetData<ulong>(0));
					break;
				}
				case 2030: { // CreateStrayLayer
					CreateStrayLayer(im.GetData<uint>(0), im.GetData<ulong>(8), out var _0, out var _1, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 2031: { // DestroyStrayLayer
					DestroyStrayLayer(im.GetData<ulong>(0));
					break;
				}
				case 2101: { // SetLayerScalingMode
					SetLayerScalingMode(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 2102: { // ConvertScalingMode
					var ret = ConvertScalingMode(null);
					break;
				}
				case 2450: { // GetIndirectLayerImageMap
					GetIndirectLayerImageMap(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.Pid, out var _0, out var _1, im.GetBuffer<byte>(0x46, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 2451: { // GetIndirectLayerImageCropMap
					GetIndirectLayerImageCropMap(im.GetData<float>(0), im.GetData<float>(4), im.GetData<float>(8), im.GetData<float>(12), im.GetData<ulong>(16), im.GetData<ulong>(24), im.GetData<ulong>(32), im.GetData<ulong>(40), im.Pid, out var _0, out var _1, im.GetBuffer<byte>(0x46, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 2460: { // GetIndirectLayerImageRequiredMemoryInfo
					GetIndirectLayerImageRequiredMemoryInfo(im.GetData<ulong>(0), im.GetData<ulong>(8), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 5202: { // GetDisplayVsyncEvent
					var ret = GetDisplayVsyncEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 5203: { // GetDisplayVsyncEventForDebug
					var ret = GetDisplayVsyncEventForDebug(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IApplicationDisplayService: {im.CommandId}");
			}
		}
		
		public virtual Nns.Hosbinder.IHOSBinderDriver GetRelayService() => throw new NotImplementedException();
		public virtual Nn.Visrv.Sf.ISystemDisplayService GetSystemDisplayService() => throw new NotImplementedException();
		public virtual Nn.Visrv.Sf.IManagerDisplayService GetManagerDisplayService() => throw new NotImplementedException();
		public virtual Nns.Hosbinder.IHOSBinderDriver GetIndirectDisplayTransactionService() => throw new NotImplementedException();
		public virtual void ListDisplays(out ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual ulong OpenDisplay(byte[] _0) => throw new NotImplementedException();
		public virtual ulong OpenDefaultDisplay() => throw new NotImplementedException();
		public virtual void CloseDisplay(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayEnabled(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void GetDisplayResolution(ulong _0, out ulong _1, out ulong _2) => throw new NotImplementedException();
		public virtual void OpenLayer(byte[] _0, ulong _1, ulong _2, ulong _3, out ulong _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void CloseLayer(ulong _0) => throw new NotImplementedException();
		public virtual void CreateStrayLayer(uint _0, ulong _1, out ulong _2, out ulong _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void DestroyStrayLayer(ulong _0) => throw new NotImplementedException();
		public virtual void SetLayerScalingMode(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual object ConvertScalingMode(object _0) => throw new NotImplementedException();
		public virtual void GetIndirectLayerImageMap(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4, out ulong _5, out ulong _6, Buffer<byte> _7) => throw new NotImplementedException();
		public virtual void GetIndirectLayerImageCropMap(float _0, float _1, float _2, float _3, ulong _4, ulong _5, ulong _6, ulong _7, ulong _8, out ulong _9, out ulong _10, Buffer<byte> _11) => throw new NotImplementedException();
		public virtual void GetIndirectLayerImageRequiredMemoryInfo(ulong _0, ulong _1, out ulong _2, out ulong _3) => throw new NotImplementedException();
		public virtual KObject GetDisplayVsyncEvent(ulong _0) => throw new NotImplementedException();
		public virtual KObject GetDisplayVsyncEventForDebug(ulong _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IManagerDisplayService : _Base_IManagerDisplayService {}
	public unsafe class _Base_IManagerDisplayService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 200: { // AllocateProcessHeapBlock
					var ret = AllocateProcessHeapBlock(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 201: { // FreeProcessHeapBlock
					FreeProcessHeapBlock(im.GetData<ulong>(0));
					break;
				}
				case 1102: { // GetDisplayResolution
					GetDisplayResolution(im.GetData<ulong>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 2010: { // CreateManagedLayer
					var ret = CreateManagedLayer(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					om.SetData(0, ret);
					break;
				}
				case 2011: { // DestroyManagedLayer
					DestroyManagedLayer(im.GetData<ulong>(0));
					break;
				}
				case 2050: { // CreateIndirectLayer
					var ret = CreateIndirectLayer();
					om.SetData(0, ret);
					break;
				}
				case 2051: { // DestroyIndirectLayer
					DestroyIndirectLayer(im.GetData<ulong>(0));
					break;
				}
				case 2052: { // CreateIndirectProducerEndPoint
					var ret = CreateIndirectProducerEndPoint(im.GetData<ulong>(0), im.GetData<ulong>(8));
					om.SetData(0, ret);
					break;
				}
				case 2053: { // DestroyIndirectProducerEndPoint
					DestroyIndirectProducerEndPoint(im.GetData<ulong>(0));
					break;
				}
				case 2054: { // CreateIndirectConsumerEndPoint
					var ret = CreateIndirectConsumerEndPoint(im.GetData<ulong>(0), im.GetData<ulong>(8));
					om.SetData(0, ret);
					break;
				}
				case 2055: { // DestroyIndirectConsumerEndPoint
					DestroyIndirectConsumerEndPoint(im.GetData<ulong>(0));
					break;
				}
				case 2300: { // AcquireLayerTexturePresentingEvent
					var ret = AcquireLayerTexturePresentingEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 2301: { // ReleaseLayerTexturePresentingEvent
					ReleaseLayerTexturePresentingEvent(im.GetData<ulong>(0));
					break;
				}
				case 2302: { // GetDisplayHotplugEvent
					var ret = GetDisplayHotplugEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 2402: { // GetDisplayHotplugState
					var ret = GetDisplayHotplugState(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 2501: { // GetCompositorErrorInfo
					GetCompositorErrorInfo(im.GetData<ulong>(0), im.GetData<ulong>(8), out var _0, im.GetBuffer<byte>(0x16, 0));
					om.SetData(0, _0);
					break;
				}
				case 2601: { // GetDisplayErrorEvent
					var ret = GetDisplayErrorEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 4201: { // SetDisplayAlpha
					SetDisplayAlpha(im.GetData<float>(0), im.GetData<ulong>(8));
					break;
				}
				case 4203: { // SetDisplayLayerStack
					SetDisplayLayerStack(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 4205: { // SetDisplayPowerState
					SetDisplayPowerState(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 4206: { // SetDefaultDisplay
					SetDefaultDisplay(im.GetData<ulong>(0));
					break;
				}
				case 6000: { // AddToLayerStack
					AddToLayerStack(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 6001: { // RemoveFromLayerStack
					RemoveFromLayerStack(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 6002: { // SetLayerVisibility
					SetLayerVisibility(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 6003: { // SetLayerConfig
					var ret = SetLayerConfig(null);
					break;
				}
				case 6004: { // AttachLayerPresentationTracer
					var ret = AttachLayerPresentationTracer(null);
					break;
				}
				case 6005: { // DetachLayerPresentationTracer
					var ret = DetachLayerPresentationTracer(null);
					break;
				}
				case 6006: { // StartLayerPresentationRecording
					var ret = StartLayerPresentationRecording(null);
					break;
				}
				case 6007: { // StopLayerPresentationRecording
					var ret = StopLayerPresentationRecording(null);
					break;
				}
				case 6008: { // StartLayerPresentationFenceWait
					var ret = StartLayerPresentationFenceWait(null);
					break;
				}
				case 6009: { // StopLayerPresentationFenceWait
					var ret = StopLayerPresentationFenceWait(null);
					break;
				}
				case 6010: { // GetLayerPresentationAllFencesExpiredEvent
					var ret = GetLayerPresentationAllFencesExpiredEvent(null);
					break;
				}
				case 7000: { // SetContentVisibility
					SetContentVisibility(im.GetData<byte>(0));
					break;
				}
				case 8000: { // SetConductorLayer
					SetConductorLayer(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 8100: { // SetIndirectProducerFlipOffset
					SetIndirectProducerFlipOffset(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				case 8200: { // CreateSharedBufferStaticStorage
					var ret = CreateSharedBufferStaticStorage(im.GetData<ulong>(0), im.GetBuffer<byte>(0x15, 0));
					om.SetData(0, ret);
					break;
				}
				case 8201: { // CreateSharedBufferTransferMemory
					var ret = CreateSharedBufferTransferMemory(im.GetData<ulong>(0), Kernel.Get<KObject>(im.GetCopy(0)), im.GetBuffer<byte>(0x15, 0));
					om.SetData(0, ret);
					break;
				}
				case 8202: { // DestroySharedBuffer
					DestroySharedBuffer(im.GetData<ulong>(0));
					break;
				}
				case 8203: { // BindSharedLowLevelLayerToManagedLayer
					BindSharedLowLevelLayerToManagedLayer(im.GetBytes(0, 0x40), im.GetData<ulong>(64), im.GetData<ulong>(72), im.Pid);
					break;
				}
				case 8204: { // BindSharedLowLevelLayerToIndirectLayer
					BindSharedLowLevelLayerToIndirectLayer(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 8207: { // UnbindSharedLowLevelLayer
					UnbindSharedLowLevelLayer(im.GetData<ulong>(0));
					break;
				}
				case 8208: { // ConnectSharedLowLevelLayerToSharedBuffer
					ConnectSharedLowLevelLayerToSharedBuffer(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 8209: { // DisconnectSharedLowLevelLayerFromSharedBuffer
					DisconnectSharedLowLevelLayerFromSharedBuffer(im.GetData<ulong>(0));
					break;
				}
				case 8210: { // CreateSharedLayer
					var ret = CreateSharedLayer(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 8211: { // DestroySharedLayer
					DestroySharedLayer(im.GetData<ulong>(0));
					break;
				}
				case 8216: { // AttachSharedLayerToLowLevelLayer
					AttachSharedLayerToLowLevelLayer(im.GetBytes(0, 0x10), im.GetData<ulong>(16), im.GetData<ulong>(24));
					break;
				}
				case 8217: { // ForceDetachSharedLayerFromLowLevelLayer
					ForceDetachSharedLayerFromLowLevelLayer(im.GetData<ulong>(0));
					break;
				}
				case 8218: { // StartDetachSharedLayerFromLowLevelLayer
					StartDetachSharedLayerFromLowLevelLayer(im.GetData<ulong>(0));
					break;
				}
				case 8219: { // FinishDetachSharedLayerFromLowLevelLayer
					FinishDetachSharedLayerFromLowLevelLayer(im.GetData<ulong>(0));
					break;
				}
				case 8220: { // GetSharedLayerDetachReadyEvent
					var ret = GetSharedLayerDetachReadyEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 8221: { // GetSharedLowLevelLayerSynchronizedEvent
					var ret = GetSharedLowLevelLayerSynchronizedEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 8222: { // CheckSharedLowLevelLayerSynchronized
					var ret = CheckSharedLowLevelLayerSynchronized(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 8223: { // RegisterSharedBufferImporterAruid
					RegisterSharedBufferImporterAruid(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 8224: { // UnregisterSharedBufferImporterAruid
					UnregisterSharedBufferImporterAruid(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 8227: { // CreateSharedBufferProcessHeap
					var ret = CreateSharedBufferProcessHeap(im.GetData<ulong>(0), im.GetBuffer<byte>(0x15, 0));
					om.SetData(0, ret);
					break;
				}
				case 8228: { // GetSharedLayerLayerStacks
					var ret = GetSharedLayerLayerStacks(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 8229: { // SetSharedLayerLayerStacks
					SetSharedLayerLayerStacks(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 8291: { // PresentDetachedSharedFrameBufferToLowLevelLayer
					PresentDetachedSharedFrameBufferToLowLevelLayer(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				case 8292: { // FillDetachedSharedFrameBufferColor
					FillDetachedSharedFrameBufferColor(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetData<ulong>(24), im.GetData<ulong>(32));
					break;
				}
				case 8293: { // GetDetachedSharedFrameBufferImage
					GetDetachedSharedFrameBufferImage(im.GetData<ulong>(0), im.GetData<ulong>(8), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 8294: { // SetDetachedSharedFrameBufferImage
					SetDetachedSharedFrameBufferImage(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 8295: { // CopyDetachedSharedFrameBufferImage
					CopyDetachedSharedFrameBufferImage(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24));
					break;
				}
				case 8296: { // SetDetachedSharedFrameBufferSubImage
					SetDetachedSharedFrameBufferSubImage(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetData<uint>(20), im.GetData<ulong>(24), im.GetData<ulong>(32), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 8297: { // GetSharedFrameBufferContentParameter
					GetSharedFrameBufferContentParameter(im.GetData<ulong>(0), im.GetData<ulong>(8), out var _0, out var _1, out var _2, out var _3, out var _4);
					om.SetData(0, _0);
					om.SetBytes(4, _1);
					om.SetData(20, _2);
					om.SetData(24, _3);
					om.SetData(28, _4);
					break;
				}
				case 8298: { // ExpandStartupLogoOnSharedFrameBuffer
					var ret = ExpandStartupLogoOnSharedFrameBuffer(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerDisplayService: {im.CommandId}");
			}
		}
		
		public virtual ulong AllocateProcessHeapBlock(ulong _0) => throw new NotImplementedException();
		public virtual void FreeProcessHeapBlock(ulong _0) => throw new NotImplementedException();
		public virtual void GetDisplayResolution(ulong _0, out ulong _1, out ulong _2) => throw new NotImplementedException();
		public virtual ulong CreateManagedLayer(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void DestroyManagedLayer(ulong _0) => throw new NotImplementedException();
		public virtual ulong CreateIndirectLayer() => throw new NotImplementedException();
		public virtual void DestroyIndirectLayer(ulong _0) => throw new NotImplementedException();
		public virtual ulong CreateIndirectProducerEndPoint(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DestroyIndirectProducerEndPoint(ulong _0) => throw new NotImplementedException();
		public virtual ulong CreateIndirectConsumerEndPoint(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DestroyIndirectConsumerEndPoint(ulong _0) => throw new NotImplementedException();
		public virtual KObject AcquireLayerTexturePresentingEvent(ulong _0) => throw new NotImplementedException();
		public virtual void ReleaseLayerTexturePresentingEvent(ulong _0) => throw new NotImplementedException();
		public virtual KObject GetDisplayHotplugEvent(ulong _0) => throw new NotImplementedException();
		public virtual uint GetDisplayHotplugState(ulong _0) => throw new NotImplementedException();
		public virtual void GetCompositorErrorInfo(ulong _0, ulong _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual KObject GetDisplayErrorEvent(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayAlpha(float _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetDisplayLayerStack(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetDisplayPowerState(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetDefaultDisplay(ulong _0) => throw new NotImplementedException();
		public virtual void AddToLayerStack(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void RemoveFromLayerStack(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetLayerVisibility(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual object SetLayerConfig(object _0) => throw new NotImplementedException();
		public virtual object AttachLayerPresentationTracer(object _0) => throw new NotImplementedException();
		public virtual object DetachLayerPresentationTracer(object _0) => throw new NotImplementedException();
		public virtual object StartLayerPresentationRecording(object _0) => throw new NotImplementedException();
		public virtual object StopLayerPresentationRecording(object _0) => throw new NotImplementedException();
		public virtual object StartLayerPresentationFenceWait(object _0) => throw new NotImplementedException();
		public virtual object StopLayerPresentationFenceWait(object _0) => throw new NotImplementedException();
		public virtual object GetLayerPresentationAllFencesExpiredEvent(object _0) => throw new NotImplementedException();
		public virtual void SetContentVisibility(byte _0) => throw new NotImplementedException();
		public virtual void SetConductorLayer(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetIndirectProducerFlipOffset(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual ulong CreateSharedBufferStaticStorage(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual ulong CreateSharedBufferTransferMemory(ulong _0, KObject _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void DestroySharedBuffer(ulong _0) => throw new NotImplementedException();
		public virtual void BindSharedLowLevelLayerToManagedLayer(byte[] _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void BindSharedLowLevelLayerToIndirectLayer(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void UnbindSharedLowLevelLayer(ulong _0) => throw new NotImplementedException();
		public virtual void ConnectSharedLowLevelLayerToSharedBuffer(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DisconnectSharedLowLevelLayerFromSharedBuffer(ulong _0) => throw new NotImplementedException();
		public virtual ulong CreateSharedLayer(ulong _0) => throw new NotImplementedException();
		public virtual void DestroySharedLayer(ulong _0) => throw new NotImplementedException();
		public virtual void AttachSharedLayerToLowLevelLayer(byte[] _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ForceDetachSharedLayerFromLowLevelLayer(ulong _0) => throw new NotImplementedException();
		public virtual void StartDetachSharedLayerFromLowLevelLayer(ulong _0) => throw new NotImplementedException();
		public virtual void FinishDetachSharedLayerFromLowLevelLayer(ulong _0) => throw new NotImplementedException();
		public virtual KObject GetSharedLayerDetachReadyEvent(ulong _0) => throw new NotImplementedException();
		public virtual KObject GetSharedLowLevelLayerSynchronizedEvent(ulong _0) => throw new NotImplementedException();
		public virtual ulong CheckSharedLowLevelLayerSynchronized(ulong _0) => throw new NotImplementedException();
		public virtual void RegisterSharedBufferImporterAruid(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void UnregisterSharedBufferImporterAruid(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual ulong CreateSharedBufferProcessHeap(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetSharedLayerLayerStacks(ulong _0) => throw new NotImplementedException();
		public virtual void SetSharedLayerLayerStacks(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void PresentDetachedSharedFrameBufferToLowLevelLayer(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void FillDetachedSharedFrameBufferColor(uint _0, uint _1, uint _2, uint _3, uint _4, ulong _5, ulong _6) => throw new NotImplementedException();
		public virtual void GetDetachedSharedFrameBufferImage(ulong _0, ulong _1, out ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void SetDetachedSharedFrameBufferImage(uint _0, ulong _1, ulong _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void CopyDetachedSharedFrameBufferImage(uint _0, uint _1, ulong _2, ulong _3, ulong _4) => throw new NotImplementedException();
		public virtual void SetDetachedSharedFrameBufferSubImage(uint _0, uint _1, uint _2, uint _3, uint _4, uint _5, ulong _6, ulong _7, Buffer<byte> _8) => throw new NotImplementedException();
		public virtual void GetSharedFrameBufferContentParameter(ulong _0, ulong _1, out uint _2, out byte[] _3, out uint _4, out uint _5, out uint _6) => throw new NotImplementedException();
		public virtual object ExpandStartupLogoOnSharedFrameBuffer(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystemDisplayService : _Base_ISystemDisplayService {}
	public unsafe class _Base_ISystemDisplayService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1200: { // GetZOrderCountMin
					var ret = GetZOrderCountMin(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 1202: { // GetZOrderCountMax
					var ret = GetZOrderCountMax(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 1203: { // GetDisplayLogicalResolution
					GetDisplayLogicalResolution(im.GetData<ulong>(0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 1204: { // SetDisplayMagnification
					SetDisplayMagnification(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16));
					break;
				}
				case 2201: { // SetLayerPosition
					SetLayerPosition(im.GetData<float>(0), im.GetData<float>(4), im.GetData<ulong>(8));
					break;
				}
				case 2203: { // SetLayerSize
					SetLayerSize(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16));
					break;
				}
				case 2204: { // GetLayerZ
					var ret = GetLayerZ(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 2205: { // SetLayerZ
					SetLayerZ(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 2207: { // SetLayerVisibility
					SetLayerVisibility(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 2209: { // SetLayerAlpha
					SetLayerAlpha(im.GetData<float>(0), im.GetData<ulong>(8));
					break;
				}
				case 2312: { // CreateStrayLayer
					CreateStrayLayer(im.GetData<uint>(0), im.GetData<ulong>(8), out var _0, out var _1, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 2400: { // OpenIndirectLayer
					OpenIndirectLayer(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 2401: { // CloseIndirectLayer
					CloseIndirectLayer(im.GetData<ulong>(0));
					break;
				}
				case 2402: { // FlipIndirectLayer
					FlipIndirectLayer(im.GetData<ulong>(0));
					break;
				}
				case 3000: { // ListDisplayModes
					ListDisplayModes(im.GetData<ulong>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 3001: { // ListDisplayRgbRanges
					ListDisplayRgbRanges(im.GetData<ulong>(0), out var _0, im.GetBuffer<uint>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 3002: { // ListDisplayContentTypes
					ListDisplayContentTypes(im.GetData<ulong>(0), out var _0, im.GetBuffer<uint>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 3200: { // GetDisplayMode
					var ret = GetDisplayMode(im.GetData<ulong>(0));
					break;
				}
				case 3201: { // SetDisplayMode
					SetDisplayMode(im.GetData<ulong>(0), null);
					break;
				}
				case 3202: { // GetDisplayUnderscan
					var ret = GetDisplayUnderscan(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3203: { // SetDisplayUnderscan
					SetDisplayUnderscan(im.GetData<ulong>(0), im.GetData<ulong>(8));
					break;
				}
				case 3204: { // GetDisplayContentType
					var ret = GetDisplayContentType(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3205: { // SetDisplayContentType
					SetDisplayContentType(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 3206: { // GetDisplayRgbRange
					var ret = GetDisplayRgbRange(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3207: { // SetDisplayRgbRange
					SetDisplayRgbRange(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 3208: { // GetDisplayCmuMode
					var ret = GetDisplayCmuMode(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3209: { // SetDisplayCmuMode
					SetDisplayCmuMode(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 3210: { // GetDisplayContrastRatio
					var ret = GetDisplayContrastRatio(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3211: { // SetDisplayContrastRatio
					SetDisplayContrastRatio(im.GetData<float>(0), im.GetData<ulong>(8));
					break;
				}
				case 3214: { // GetDisplayGamma
					var ret = GetDisplayGamma(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3215: { // SetDisplayGamma
					SetDisplayGamma(im.GetData<float>(0), im.GetData<ulong>(8));
					break;
				}
				case 3216: { // GetDisplayCmuLuma
					var ret = GetDisplayCmuLuma(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 3217: { // SetDisplayCmuLuma
					SetDisplayCmuLuma(im.GetData<float>(0), im.GetData<ulong>(8));
					break;
				}
				case 8225: { // GetSharedBufferMemoryHandleId
					GetSharedBufferMemoryHandleId(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid, out var _0, out var _1, im.GetBuffer<byte>(0x16, 0));
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 8250: { // OpenSharedLayer
					OpenSharedLayer(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 8251: { // CloseSharedLayer
					CloseSharedLayer(im.GetData<ulong>(0));
					break;
				}
				case 8252: { // ConnectSharedLayer
					ConnectSharedLayer(im.GetData<ulong>(0));
					break;
				}
				case 8253: { // DisconnectSharedLayer
					DisconnectSharedLayer(im.GetData<ulong>(0));
					break;
				}
				case 8254: { // AcquireSharedFrameBuffer
					AcquireSharedFrameBuffer(im.GetData<ulong>(0), out var _0, out var _1, out var _2);
					om.SetBytes(0, _0);
					om.SetBytes(36, _1);
					om.SetData(56, _2);
					break;
				}
				case 8255: { // PresentSharedFrameBuffer
					PresentSharedFrameBuffer(im.GetBytes(0, 0x24), im.GetBytes(36, 0x10), im.GetData<uint>(52), im.GetData<uint>(56), im.GetData<ulong>(64), im.GetData<ulong>(72));
					break;
				}
				case 8256: { // GetSharedFrameBufferAcquirableEvent
					var ret = GetSharedFrameBufferAcquirableEvent(im.GetData<ulong>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 8257: { // FillSharedFrameBufferColor
					FillSharedFrameBufferColor(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.GetData<ulong>(24));
					break;
				}
				case 8258: { // CancelSharedFrameBuffer
					var ret = CancelSharedFrameBuffer(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemDisplayService: {im.CommandId}");
			}
		}
		
		public virtual ulong GetZOrderCountMin(ulong _0) => throw new NotImplementedException();
		public virtual ulong GetZOrderCountMax(ulong _0) => throw new NotImplementedException();
		public virtual void GetDisplayLogicalResolution(ulong _0, out uint _1, out uint _2) => throw new NotImplementedException();
		public virtual void SetDisplayMagnification(uint _0, uint _1, uint _2, uint _3, ulong _4) => throw new NotImplementedException();
		public virtual void SetLayerPosition(float _0, float _1, ulong _2) => throw new NotImplementedException();
		public virtual void SetLayerSize(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual ulong GetLayerZ(ulong _0) => throw new NotImplementedException();
		public virtual void SetLayerZ(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetLayerVisibility(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void SetLayerAlpha(float _0, ulong _1) => throw new NotImplementedException();
		public virtual void CreateStrayLayer(uint _0, ulong _1, out ulong _2, out ulong _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void OpenIndirectLayer(ulong _0, ulong _1, ulong _2, out ulong _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void CloseIndirectLayer(ulong _0) => throw new NotImplementedException();
		public virtual void FlipIndirectLayer(ulong _0) => throw new NotImplementedException();
		public virtual void ListDisplayModes(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ListDisplayRgbRanges(ulong _0, out ulong _1, Buffer<uint> _2) => throw new NotImplementedException();
		public virtual void ListDisplayContentTypes(ulong _0, out ulong _1, Buffer<uint> _2) => throw new NotImplementedException();
		public virtual object GetDisplayMode(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayMode(ulong _0, object _1) => throw new NotImplementedException();
		public virtual ulong GetDisplayUnderscan(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayUnderscan(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetDisplayContentType(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayContentType(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetDisplayRgbRange(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayRgbRange(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual uint GetDisplayCmuMode(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayCmuMode(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual float GetDisplayContrastRatio(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayContrastRatio(float _0, ulong _1) => throw new NotImplementedException();
		public virtual float GetDisplayGamma(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayGamma(float _0, ulong _1) => throw new NotImplementedException();
		public virtual float GetDisplayCmuLuma(ulong _0) => throw new NotImplementedException();
		public virtual void SetDisplayCmuLuma(float _0, ulong _1) => throw new NotImplementedException();
		public virtual void GetSharedBufferMemoryHandleId(ulong _0, ulong _1, ulong _2, out uint _3, out ulong _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void OpenSharedLayer(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void CloseSharedLayer(ulong _0) => throw new NotImplementedException();
		public virtual void ConnectSharedLayer(ulong _0) => throw new NotImplementedException();
		public virtual void DisconnectSharedLayer(ulong _0) => throw new NotImplementedException();
		public virtual void AcquireSharedFrameBuffer(ulong _0, out byte[] _1, out byte[] _2, out ulong _3) => throw new NotImplementedException();
		public virtual void PresentSharedFrameBuffer(byte[] _0, byte[] _1, uint _2, uint _3, ulong _4, ulong _5) => throw new NotImplementedException();
		public virtual KObject GetSharedFrameBufferAcquirableEvent(ulong _0) => throw new NotImplementedException();
		public virtual void FillSharedFrameBufferColor(uint _0, uint _1, uint _2, uint _3, ulong _4, ulong _5) => throw new NotImplementedException();
		public virtual object CancelSharedFrameBuffer(object _0) => throw new NotImplementedException();
	}
}
