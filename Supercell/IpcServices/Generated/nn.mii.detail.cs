#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Mii.Detail {
	[IpcService("miiimg")]
	public unsafe partial class IImageDatabaseService : _Base_IImageDatabaseService {}
	public unsafe class _Base_IImageDatabaseService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(null);
					break;
				}
				case 10: { // Reload
					var ret = Reload(null);
					break;
				}
				case 11: { // GetCount
					var ret = GetCount(null);
					break;
				}
				case 12: { // IsEmpty
					var ret = IsEmpty(null);
					break;
				}
				case 13: { // IsFull
					var ret = IsFull(null);
					break;
				}
				case 14: { // GetAttribute
					var ret = GetAttribute(null);
					break;
				}
				case 15: { // LoadImage
					var ret = LoadImage(null);
					break;
				}
				case 16: { // AddOrUpdateImage
					var ret = AddOrUpdateImage(null);
					break;
				}
				case 17: { // DeleteImages
					var ret = DeleteImages(null);
					break;
				}
				case 100: { // DeleteFile
					var ret = DeleteFile(null);
					break;
				}
				case 101: { // DestroyFile
					var ret = DestroyFile(null);
					break;
				}
				case 102: { // ImportFile
					var ret = ImportFile(null);
					break;
				}
				case 103: { // ExportFile
					var ret = ExportFile(null);
					break;
				}
				case 104: { // ForceInitialize
					var ret = ForceInitialize(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IImageDatabaseService: {im.CommandId}");
			}
		}
		
		public virtual object Initialize(object _0) => throw new NotImplementedException();
		public virtual object Reload(object _0) => throw new NotImplementedException();
		public virtual object GetCount(object _0) => throw new NotImplementedException();
		public virtual object IsEmpty(object _0) => throw new NotImplementedException();
		public virtual object IsFull(object _0) => throw new NotImplementedException();
		public virtual object GetAttribute(object _0) => throw new NotImplementedException();
		public virtual object LoadImage(object _0) => throw new NotImplementedException();
		public virtual object AddOrUpdateImage(object _0) => throw new NotImplementedException();
		public virtual object DeleteImages(object _0) => throw new NotImplementedException();
		public virtual object DeleteFile(object _0) => throw new NotImplementedException();
		public virtual object DestroyFile(object _0) => throw new NotImplementedException();
		public virtual object ImportFile(object _0) => throw new NotImplementedException();
		public virtual object ExportFile(object _0) => throw new NotImplementedException();
		public virtual object ForceInitialize(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("mii:u")]
	[IpcService("mii:e")]
	public unsafe partial class IStaticService : _Base_IStaticService {}
	public unsafe class _Base_IStaticService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetDatabaseService
					var ret = GetDatabaseService(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStaticService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Mii.Detail.IDatabaseService GetDatabaseService(uint _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDatabaseService : _Base_IDatabaseService {}
	public unsafe class _Base_IDatabaseService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // IsUpdated
					var ret = IsUpdated(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 1: { // IsFullDatabase
					var ret = IsFullDatabase();
					om.SetData(0, ret);
					break;
				}
				case 2: { // GetCount
					var ret = GetCount(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // Get
					Get(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 4: { // Get1
					Get1(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 5: { // UpdateLatest
					UpdateLatest(im.GetBytes(0, 0x58), im.GetData<uint>(88), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 6: { // BuildRandom
					BuildRandom(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 7: { // BuildDefault
					BuildDefault(im.GetData<uint>(0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 8: { // Get2
					Get2(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 9: { // Get3
					Get3(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 10: { // UpdateLatest1
					UpdateLatest1(im.GetBytes(0, 0x44), im.GetData<uint>(68), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 11: { // FindIndex
					var ret = FindIndex(im.GetBytes(0, 0x10), im.GetData<byte>(16));
					om.SetData(0, ret);
					break;
				}
				case 12: { // Move
					Move(im.GetBytes(0, 0x10), im.GetData<uint>(16));
					break;
				}
				case 13: { // AddOrReplace
					AddOrReplace(im.GetBytes(0, 0x44));
					break;
				}
				case 14: { // Delete
					Delete(im.GetBytes(0, 0x10));
					break;
				}
				case 15: { // DestroyFile
					DestroyFile();
					break;
				}
				case 16: { // DeleteFile
					DeleteFile();
					break;
				}
				case 17: { // Format
					Format();
					break;
				}
				case 18: { // Import
					Import(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 19: { // Export
					Export(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 20: { // IsBrokenDatabaseWithClearFlag
					var ret = IsBrokenDatabaseWithClearFlag();
					om.SetData(0, ret);
					break;
				}
				case 21: { // GetIndex
					var ret = GetIndex(im.GetBytes(0, 0x58));
					om.SetData(0, ret);
					break;
				}
				case 22: { // SetInterfaceVersion
					var ret = SetInterfaceVersion(null);
					break;
				}
				case 23: { // Convert
					var ret = Convert(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDatabaseService: {im.CommandId}");
			}
		}
		
		public virtual byte IsUpdated(uint _0) => throw new NotImplementedException();
		public virtual byte IsFullDatabase() => throw new NotImplementedException();
		public virtual uint GetCount(uint _0) => throw new NotImplementedException();
		public virtual void Get(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Get1(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void UpdateLatest(byte[] _0, uint _1, out byte[] _2) => throw new NotImplementedException();
		public virtual void BuildRandom(uint _0, uint _1, uint _2, out byte[] _3) => throw new NotImplementedException();
		public virtual void BuildDefault(uint _0, out byte[] _1) => throw new NotImplementedException();
		public virtual void Get2(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Get3(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void UpdateLatest1(byte[] _0, uint _1, out byte[] _2) => throw new NotImplementedException();
		public virtual uint FindIndex(byte[] _0, byte _1) => throw new NotImplementedException();
		public virtual void Move(byte[] _0, uint _1) => throw new NotImplementedException();
		public virtual void AddOrReplace(byte[] _0) => throw new NotImplementedException();
		public virtual void Delete(byte[] _0) => throw new NotImplementedException();
		public virtual void DestroyFile() => throw new NotImplementedException();
		public virtual void DeleteFile() => throw new NotImplementedException();
		public virtual void Format() => throw new NotImplementedException();
		public virtual void Import(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Export(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual byte IsBrokenDatabaseWithClearFlag() => throw new NotImplementedException();
		public virtual uint GetIndex(byte[] _0) => throw new NotImplementedException();
		public virtual object SetInterfaceVersion(object _0) => throw new NotImplementedException();
		public virtual object Convert(object _0) => throw new NotImplementedException();
	}
}
