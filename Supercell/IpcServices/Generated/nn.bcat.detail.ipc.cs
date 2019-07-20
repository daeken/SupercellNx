#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bcat.Detail.Ipc {
	[IpcService("bcat:a")]
	[IpcService("bcat:u")]
	[IpcService("bcat:m")]
	[IpcService("bcat:s")]
	public unsafe partial class IServiceCreator : _Base_IServiceCreator {}
	public unsafe class _Base_IServiceCreator : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateBcatService
					var ret = CreateBcatService(im.GetData<ulong>(0), im.Pid);
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // CreateDeliveryCacheStorageService
					var ret = CreateDeliveryCacheStorageService(im.GetData<ulong>(0), im.Pid);
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // CreateDeliveryCacheStorageServiceWithApplicationId
					var ret = CreateDeliveryCacheStorageServiceWithApplicationId(im.GetData<ulong>(0));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.Bcat.Detail.Ipc.IBcatService CreateBcatService(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual Nn.Bcat.Detail.Ipc.IDeliveryCacheStorageService CreateDeliveryCacheStorageService(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual Nn.Bcat.Detail.Ipc.IDeliveryCacheStorageService CreateDeliveryCacheStorageServiceWithApplicationId(ulong _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IBcatService : _Base_IBcatService {}
	public unsafe class _Base_IBcatService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 10100: { // RequestSyncDeliveryCache
					var ret = RequestSyncDeliveryCache();
					om.Move(0, ret.Handle);
					break;
				}
				case 10101: { // RequestSyncDeliveryCacheWithDirectoryName
					var ret = RequestSyncDeliveryCacheWithDirectoryName(null);
					break;
				}
				case 10200: { // CancelSyncDeliveryCacheRequest
					var ret = CancelSyncDeliveryCacheRequest(null);
					break;
				}
				case 20100: { // RequestSyncDeliveryCacheWithApplicationId
					var ret = RequestSyncDeliveryCacheWithApplicationId(im.GetData<uint>(0), im.GetData<ulong>(8));
					om.Move(0, ret.Handle);
					break;
				}
				case 20101: { // RequestSyncDeliveryCacheWithApplicationIdAndDirectoryName
					var ret = RequestSyncDeliveryCacheWithApplicationIdAndDirectoryName(null);
					break;
				}
				case 30100: { // SetPassphrase
					SetPassphrase(im.GetData<ulong>(0), im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 30200: { // RegisterBackgroundDeliveryTask
					RegisterBackgroundDeliveryTask(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 30201: { // UnregisterBackgroundDeliveryTask
					UnregisterBackgroundDeliveryTask(im.GetData<ulong>(0));
					break;
				}
				case 30202: { // BlockDeliveryTask
					BlockDeliveryTask(im.GetData<ulong>(0));
					break;
				}
				case 30203: { // UnblockDeliveryTask
					UnblockDeliveryTask(im.GetData<ulong>(0));
					break;
				}
				case 90100: { // EnumerateBackgroundDeliveryTask
					EnumerateBackgroundDeliveryTask(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 90200: { // GetDeliveryList
					GetDeliveryList(im.GetData<ulong>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 90201: { // ClearDeliveryCacheStorage
					ClearDeliveryCacheStorage(im.GetData<ulong>(0));
					break;
				}
				case 90300: { // GetPushNotificationLog
					GetPushNotificationLog(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBcatService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Bcat.Detail.Ipc.IDeliveryCacheProgressService RequestSyncDeliveryCache() => throw new NotImplementedException();
		public virtual object RequestSyncDeliveryCacheWithDirectoryName(object _0) => throw new NotImplementedException();
		public virtual object CancelSyncDeliveryCacheRequest(object _0) => throw new NotImplementedException();
		public virtual Nn.Bcat.Detail.Ipc.IDeliveryCacheProgressService RequestSyncDeliveryCacheWithApplicationId(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual object RequestSyncDeliveryCacheWithApplicationIdAndDirectoryName(object _0) => throw new NotImplementedException();
		public virtual void SetPassphrase(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RegisterBackgroundDeliveryTask(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void UnregisterBackgroundDeliveryTask(ulong _0) => throw new NotImplementedException();
		public virtual void BlockDeliveryTask(ulong _0) => throw new NotImplementedException();
		public virtual void UnblockDeliveryTask(ulong _0) => throw new NotImplementedException();
		public virtual void EnumerateBackgroundDeliveryTask(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetDeliveryList(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void ClearDeliveryCacheStorage(ulong _0) => throw new NotImplementedException();
		public virtual void GetPushNotificationLog(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDeliveryCacheDirectoryService : _Base_IDeliveryCacheDirectoryService {}
	public unsafe class _Base_IDeliveryCacheDirectoryService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Open
					Open(im.GetBytes(0, 0x20));
					break;
				}
				case 1: { // Read
					Read(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 2: { // GetCount
					var ret = GetCount();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDeliveryCacheDirectoryService: {im.CommandId}");
			}
		}
		
		public virtual void Open(byte[] _0) => throw new NotImplementedException();
		public virtual void Read(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetCount() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDeliveryCacheFileService : _Base_IDeliveryCacheFileService {}
	public unsafe class _Base_IDeliveryCacheFileService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Open
					Open(im.GetBytes(0, 0x20), im.GetBytes(32, 0x20));
					break;
				}
				case 1: { // Read
					Read(im.GetData<ulong>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 2: { // GetSize
					var ret = GetSize();
					om.SetData(0, ret);
					break;
				}
				case 3: { // GetDigest
					GetDigest(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDeliveryCacheFileService: {im.CommandId}");
			}
		}
		
		public virtual void Open(byte[] _0, byte[] _1) => throw new NotImplementedException();
		public virtual void Read(ulong _0, out ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual ulong GetSize() => throw new NotImplementedException();
		public virtual void GetDigest(out byte[] _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDeliveryCacheProgressService : _Base_IDeliveryCacheProgressService {}
	public unsafe class _Base_IDeliveryCacheProgressService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetEvent
					var ret = GetEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // GetImpl
					GetImpl(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDeliveryCacheProgressService: {im.CommandId}");
			}
		}
		
		public virtual KObject GetEvent() => throw new NotImplementedException();
		public virtual void GetImpl(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDeliveryCacheStorageService : _Base_IDeliveryCacheStorageService {}
	public unsafe class _Base_IDeliveryCacheStorageService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateFileService
					var ret = CreateFileService();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // CreateDirectoryService
					var ret = CreateDirectoryService();
					om.Move(0, ret.Handle);
					break;
				}
				case 10: { // EnumerateDeliveryCacheDirectory
					EnumerateDeliveryCacheDirectory(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDeliveryCacheStorageService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Bcat.Detail.Ipc.IDeliveryCacheFileService CreateFileService() => throw new NotImplementedException();
		public virtual Nn.Bcat.Detail.Ipc.IDeliveryCacheDirectoryService CreateDirectoryService() => throw new NotImplementedException();
		public virtual void EnumerateDeliveryCacheDirectory(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
}
