#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ncm {
	[IpcService("ncm")]
	public unsafe partial class IContentManager : _Base_IContentManager {}
	public unsafe class _Base_IContentManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateContentStorage
					CreateContentStorage(null);
					break;
				}
				case 1: { // CreateContentMetaDatabase
					CreateContentMetaDatabase(null);
					break;
				}
				case 2: { // VerifyContentStorage
					VerifyContentStorage(null);
					break;
				}
				case 3: { // VerifyContentMetaDatabase
					VerifyContentMetaDatabase(null);
					break;
				}
				case 4: { // OpenContentStorage
					var ret = OpenContentStorage(null);
					om.Move(0, ret.Handle);
					break;
				}
				case 5: { // OpenContentMetaDatabase
					var ret = OpenContentMetaDatabase(null);
					om.Move(0, ret.Handle);
					break;
				}
				case 6: { // CloseContentStorageForcibly
					CloseContentStorageForcibly(null);
					break;
				}
				case 7: { // CloseContentMetaDatabaseForcibly
					CloseContentMetaDatabaseForcibly(null);
					break;
				}
				case 8: { // CleanupContentMetaDatabase
					CleanupContentMetaDatabase(null);
					break;
				}
				case 9: { // OpenContentStorage2
					OpenContentStorage2(null);
					break;
				}
				case 10: { // CloseContentStorage
					CloseContentStorage(null);
					break;
				}
				case 11: { // OpenContentMetaDatabase2
					OpenContentMetaDatabase2(null);
					break;
				}
				case 12: { // CloseContentMetaDatabase
					CloseContentMetaDatabase(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContentManager: {im.CommandId}");
			}
		}
		
		public virtual void CreateContentStorage(object _0) => throw new NotImplementedException();
		public virtual void CreateContentMetaDatabase(object _0) => throw new NotImplementedException();
		public virtual void VerifyContentStorage(object _0) => throw new NotImplementedException();
		public virtual void VerifyContentMetaDatabase(object _0) => throw new NotImplementedException();
		public virtual Nn.Ncm.IContentStorage OpenContentStorage(object _0) => throw new NotImplementedException();
		public virtual Nn.Ncm.IContentMetaDatabase OpenContentMetaDatabase(object _0) => throw new NotImplementedException();
		public virtual void CloseContentStorageForcibly(object _0) => throw new NotImplementedException();
		public virtual void CloseContentMetaDatabaseForcibly(object _0) => throw new NotImplementedException();
		public virtual void CleanupContentMetaDatabase(object _0) => throw new NotImplementedException();
		public virtual void OpenContentStorage2(object _0) => throw new NotImplementedException();
		public virtual void CloseContentStorage(object _0) => throw new NotImplementedException();
		public virtual void OpenContentMetaDatabase2(object _0) => throw new NotImplementedException();
		public virtual void CloseContentMetaDatabase(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IContentMetaDatabase : _Base_IContentMetaDatabase {}
	public unsafe class _Base_IContentMetaDatabase : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Set
					Set(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // Get
					Get(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Remove
					Remove(null);
					break;
				}
				case 3: { // GetContentIdByType
					var ret = GetContentIdByType(null);
					break;
				}
				case 4: { // ListContentInfo
					ListContentInfo(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 5: { // List
					List(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 6: { // GetLatestContentMetaKey
					var ret = GetLatestContentMetaKey(null);
					break;
				}
				case 7: { // ListApplication
					ListApplication(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 8: { // Has
					var ret = Has(null);
					break;
				}
				case 9: { // HasAll
					var ret = HasAll(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 10: { // GetSize
					var ret = GetSize(null);
					break;
				}
				case 11: { // GetRequiredSystemVersion
					var ret = GetRequiredSystemVersion(null);
					break;
				}
				case 12: { // GetPatchId
					var ret = GetPatchId(null);
					break;
				}
				case 13: { // DisableForcibly
					DisableForcibly();
					break;
				}
				case 14: { // LookupOrphanContent
					LookupOrphanContent(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 15: { // Commit
					Commit();
					break;
				}
				case 16: { // HasContent
					var ret = HasContent(null);
					break;
				}
				case 17: { // ListContentMetaInfo
					ListContentMetaInfo(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 18: { // GetAttributes
					var ret = GetAttributes(null);
					break;
				}
				case 19: { // GetRequiredApplicationVersion
					var ret = GetRequiredApplicationVersion(null);
					break;
				}
				case 20: { // Unknown20
					var ret = Unknown20(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContentMetaDatabase: {im.CommandId}");
			}
		}
		
		public virtual void Set(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Get(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Remove(object _0) => throw new NotImplementedException();
		public virtual object GetContentIdByType(object _0) => throw new NotImplementedException();
		public virtual void ListContentInfo(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void List(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetLatestContentMetaKey(object _0) => throw new NotImplementedException();
		public virtual void ListApplication(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Has(object _0) => throw new NotImplementedException();
		public virtual object HasAll(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetSize(object _0) => throw new NotImplementedException();
		public virtual object GetRequiredSystemVersion(object _0) => throw new NotImplementedException();
		public virtual object GetPatchId(object _0) => throw new NotImplementedException();
		public virtual void DisableForcibly() => throw new NotImplementedException();
		public virtual void LookupOrphanContent(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Commit() => throw new NotImplementedException();
		public virtual object HasContent(object _0) => throw new NotImplementedException();
		public virtual void ListContentMetaInfo(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetAttributes(object _0) => throw new NotImplementedException();
		public virtual object GetRequiredApplicationVersion(object _0) => throw new NotImplementedException();
		public virtual object Unknown20(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IContentStorage : _Base_IContentStorage {}
	public unsafe class _Base_IContentStorage : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GeneratePlaceHolderId
					var ret = GeneratePlaceHolderId();
					break;
				}
				case 1: { // CreatePlaceHolder
					CreatePlaceHolder(null);
					break;
				}
				case 2: { // DeletePlaceHolder
					DeletePlaceHolder(null);
					break;
				}
				case 3: { // HasPlaceHolder
					var ret = HasPlaceHolder(null);
					break;
				}
				case 4: { // WritePlaceHolder
					WritePlaceHolder(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 5: { // Register
					Register(null);
					break;
				}
				case 6: { // Delete
					Delete(null);
					break;
				}
				case 7: { // Has
					var ret = Has(null);
					break;
				}
				case 8: { // GetPath
					GetPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 9: { // GetPlaceHolderPath
					GetPlaceHolderPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 10: { // CleanupAllPlaceHolder
					CleanupAllPlaceHolder();
					break;
				}
				case 11: { // ListPlaceHolder
					ListPlaceHolder(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 12: { // GetContentCount
					var ret = GetContentCount();
					break;
				}
				case 13: { // ListContentId
					ListContentId(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 14: { // GetSize
					var ret = GetSize(null);
					break;
				}
				case 15: { // DisableForcibly
					DisableForcibly();
					break;
				}
				case 16: { // RevertToPlaceHolder
					RevertToPlaceHolder(null);
					break;
				}
				case 17: { // SetPlaceHolderSize
					SetPlaceHolderSize(null);
					break;
				}
				case 18: { // ReadContentIdFile
					ReadContentIdFile(null, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 19: { // GetRightsIdFromPlaceHolderId
					var ret = GetRightsIdFromPlaceHolderId(null);
					break;
				}
				case 20: { // GetRightsIdFromContentId
					var ret = GetRightsIdFromContentId(null);
					break;
				}
				case 21: { // WriteContentForDebug
					WriteContentForDebug(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 22: { // GetFreeSpaceSize
					var ret = GetFreeSpaceSize();
					break;
				}
				case 23: { // GetTotalSpaceSize
					var ret = GetTotalSpaceSize();
					break;
				}
				case 24: { // FlushStorage
					FlushStorage();
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25(null);
					break;
				}
				case 26: { // Unknown26
					Unknown26();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContentStorage: {im.CommandId}");
			}
		}
		
		public virtual object GeneratePlaceHolderId() => throw new NotImplementedException();
		public virtual void CreatePlaceHolder(object _0) => throw new NotImplementedException();
		public virtual void DeletePlaceHolder(object _0) => throw new NotImplementedException();
		public virtual object HasPlaceHolder(object _0) => throw new NotImplementedException();
		public virtual void WritePlaceHolder(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Register(object _0) => throw new NotImplementedException();
		public virtual void Delete(object _0) => throw new NotImplementedException();
		public virtual object Has(object _0) => throw new NotImplementedException();
		public virtual void GetPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetPlaceHolderPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void CleanupAllPlaceHolder() => throw new NotImplementedException();
		public virtual void ListPlaceHolder(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object GetContentCount() => throw new NotImplementedException();
		public virtual void ListContentId(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object GetSize(object _0) => throw new NotImplementedException();
		public virtual void DisableForcibly() => throw new NotImplementedException();
		public virtual void RevertToPlaceHolder(object _0) => throw new NotImplementedException();
		public virtual void SetPlaceHolderSize(object _0) => throw new NotImplementedException();
		public virtual void ReadContentIdFile(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object GetRightsIdFromPlaceHolderId(object _0) => throw new NotImplementedException();
		public virtual object GetRightsIdFromContentId(object _0) => throw new NotImplementedException();
		public virtual void WriteContentForDebug(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object GetFreeSpaceSize() => throw new NotImplementedException();
		public virtual object GetTotalSpaceSize() => throw new NotImplementedException();
		public virtual void FlushStorage() => throw new NotImplementedException();
		public virtual object Unknown25(object _0) => throw new NotImplementedException();
		public virtual void Unknown26() => throw new NotImplementedException();
	}
}
