using System;
using System.IO;
using System.Text;
using LibHac.Fs;
using PrettyPrinter;
using static Supercell.Globals;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Fssrv.Sf {
	public partial class IFileSystemProxy {
		public override Nn.Fssrv.Sf.IFileSystem OpenFileSystem(Nn.Fssrv.Sf.FileSystemType filesystem_type, Buffer<byte> _1) => throw new NotImplementedException();
		public override void SetCurrentProcess(ulong _0, ulong _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetCurrentProcess [1]".Debug();
		public override Nn.Fssrv.Sf.IFileSystem OpenDataFileSystemByCurrentProcess() => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenFileSystemWithPatch(Nn.Fssrv.Sf.FileSystemType filesystem_type, ulong id) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenFileSystemWithId(Nn.Fssrv.Sf.FileSystemType filesystem_type, ulong tid, Buffer<byte> _2) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenDataFileSystemByApplicationId(ulong u64) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenBisFileSystem(Nn.Fssrv.Sf.Partition partitionId, Buffer<byte> _1) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IStorage OpenBisStorage(Nn.Fssrv.Sf.Partition partitionId) => throw new NotImplementedException();
		public override void InvalidateBisCache() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.InvalidateBisCache [13]".Debug();
		public override Nn.Fssrv.Sf.IFileSystem OpenHostFileSystem(Buffer<byte> _0) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenSdCardFileSystem() => throw new NotImplementedException();
		public override void FormatSdCardFileSystem() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.FormatSdCardFileSystem [19]".Debug();
		public override void DeleteSaveDataFileSystem(ulong tid) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.DeleteSaveDataFileSystem [21]".Debug();
		public override void CreateSaveDataFileSystem(byte[] save_struct, byte[] ave_create_struct, byte[] _2) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.CreateSaveDataFileSystem [22]".Debug();
		public override void CreateSaveDataFileSystemBySystemSaveDataId(byte[] _0, byte[] _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.CreateSaveDataFileSystemBySystemSaveDataId [23]".Debug();
		public override void RegisterSaveDataFileSystemAtomicDeletion(Buffer<byte> _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.RegisterSaveDataFileSystemAtomicDeletion [24]".Debug();
		public override void DeleteSaveDataFileSystemBySaveDataSpaceId(byte _0, ulong _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.DeleteSaveDataFileSystemBySaveDataSpaceId [25]".Debug();
		public override void FormatSdCardDryRun() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.FormatSdCardDryRun [26]".Debug();
		public override byte IsExFatSupported() => throw new NotImplementedException();
		public override void DeleteSaveDataFileSystemBySaveDataAttribute(byte _0, byte[] _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.DeleteSaveDataFileSystemBySaveDataAttribute [28]".Debug();
		public override Nn.Fssrv.Sf.IStorage OpenGameCardStorage(uint _0, uint _1) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenGameCardFileSystem(uint _0, uint _1) => throw new NotImplementedException();
		public override void ExtendSaveDataFileSystem(byte _0, ulong _1, ulong _2, ulong _3) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.ExtendSaveDataFileSystem [32]".Debug();
		public override object DeleteCacheStorage(object _0) => throw new NotImplementedException();
		public override object GetCacheStorageSize(object _0) => throw new NotImplementedException();

		public override Nn.Fssrv.Sf.IFileSystem OpenSaveDataFileSystem(byte save_data_space_id, byte[] save_struct) =>
			new IFileSystem(new DirectorySaveDataFileSystem(new LocalFileSystem("savegame")));
		
		public override Nn.Fssrv.Sf.IFileSystem OpenSaveDataFileSystemBySystemSaveDataId(byte save_data_space_id, byte[] save_struct) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenReadOnlySaveDataFileSystem(byte save_data_space_id, byte[] save_struct) => throw new NotImplementedException();
		public override void ReadSaveDataFileSystemExtraDataBySaveDataSpaceId(byte _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override void ReadSaveDataFileSystemExtraData(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void WriteSaveDataFileSystemExtraData(byte _0, ulong _1, Buffer<byte> _2) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.WriteSaveDataFileSystemExtraData [59]".Debug();
		public override Nn.Fssrv.Sf.ISaveDataInfoReader OpenSaveDataInfoReader() => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.ISaveDataInfoReader OpenSaveDataInfoReaderBySaveDataSpaceId(byte _0) => throw new NotImplementedException();
		public override object OpenCacheStorageList(object _0) => throw new NotImplementedException();
		public override object OpenSaveDataInternalStorageFileSystem(object _0) => throw new NotImplementedException();
		public override object UpdateSaveDataMacForDebug(object _0) => throw new NotImplementedException();
		public override object WriteSaveDataFileSystemExtraData2(object _0) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFile OpenSaveDataMetaFile(byte _0, uint _1, byte[] _2) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.ISaveDataTransferManager OpenSaveDataTransferManager() => throw new NotImplementedException();
		public override object OpenSaveDataTransferManagerVersion2(object _0) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenImageDirectoryFileSystem(uint _0) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IFileSystem OpenContentStorageFileSystem(uint content_storage_id) => throw new NotImplementedException();
		
		public override Nn.Fssrv.Sf.IStorage OpenDataStorageByCurrentProcess() => new IStorage(Kernel.RomFs);
		
		public override Nn.Fssrv.Sf.IStorage OpenDataStorageByProgramId(ulong tid) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IStorage OpenDataStorageByDataId(byte storage_id, ulong tid) => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IStorage OpenPatchDataStorageByCurrentProcess() => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IDeviceOperator OpenDeviceOperator() => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IEventNotifier OpenSdCardDetectionEventNotifier() => throw new NotImplementedException();
		public override Nn.Fssrv.Sf.IEventNotifier OpenGameCardDetectionEventNotifier() => throw new NotImplementedException();
		public override object OpenSystemDataUpdateEventNotifier(object _0) => throw new NotImplementedException();
		public override object NotifySystemDataUpdateEvent(object _0) => throw new NotImplementedException();
		public override void SetCurrentPosixTime(ulong time) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetCurrentPosixTime [600]".Debug();
		public override ulong QuerySaveDataTotalSize(ulong _0, ulong _1) => throw new NotImplementedException();
		public override void VerifySaveDataFileSystem(ulong _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void CorruptSaveDataFileSystem(ulong _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.CorruptSaveDataFileSystem [603]".Debug();
		public override void CreatePaddingFile(ulong _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.CreatePaddingFile [604]".Debug();
		public override void DeleteAllPaddingFiles() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.DeleteAllPaddingFiles [605]".Debug();
		public override void GetRightsId(byte _0, ulong _1, out byte[] rights) => throw new NotImplementedException();
		public override void RegisterExternalKey(byte[] _0, byte[] _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.RegisterExternalKey [607]".Debug();
		public override void UnregisterAllExternalKey() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.UnregisterAllExternalKey [608]".Debug();
		public override void GetRightsIdByPath(Buffer<byte> _0, out byte[] rights) => throw new NotImplementedException();
		public override void GetRightsIdAndKeyGenerationByPath(Buffer<byte> _0, out byte _1, out byte[] rights) => throw new NotImplementedException();
		public override void SetCurrentPosixTimeWithTimeDifference(uint _0, ulong _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetCurrentPosixTimeWithTimeDifference [611]".Debug();
		public override ulong GetFreeSpaceSizeForSaveData(byte _0) => throw new NotImplementedException();
		public override void VerifySaveDataFileSystemBySaveDataSpaceId(byte _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public override void CorruptSaveDataFileSystemBySaveDataSpaceId(byte _0, ulong _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.CorruptSaveDataFileSystemBySaveDataSpaceId [614]".Debug();
		public override object QuerySaveDataInternalStorageTotalSize(object _0) => throw new NotImplementedException();
		public override void SetSdCardEncryptionSeed(byte[] _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetSdCardEncryptionSeed [620]".Debug();
		public override void SetSdCardAccessibility(byte _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetSdCardAccessibility [630]".Debug();
		public override byte IsSdCardAccessible() => throw new NotImplementedException();
		public override byte IsSignedSystemPartitionOnSdCardValid() => throw new NotImplementedException();
		public override object OpenAccessFailureResolver(object _0) => throw new NotImplementedException();
		public override object GetAccessFailureDetectionEvent(object _0) => throw new NotImplementedException();
		public override object IsAccessFailureDetected(object _0) => throw new NotImplementedException();
		public override object ResolveAccessFailure(object _0) => throw new NotImplementedException();
		public override object AbandonAccessFailure(object _0) => throw new NotImplementedException();
		public override void GetAndClearFileSystemProxyErrorInfo(out byte[] error_info) => throw new NotImplementedException();
		public override void SetBisRootForHost(uint _0, Buffer<byte> _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetBisRootForHost [1000]".Debug();
		public override void SetSaveDataSize(ulong _0, ulong _1) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetSaveDataSize [1001]".Debug();
		public override void SetSaveDataRootPath(Buffer<byte> _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetSaveDataRootPath [1002]".Debug();
		public override void DisableAutoSaveDataCreation() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.DisableAutoSaveDataCreation [1003]".Debug();
		public override void SetGlobalAccessLogMode(uint mode) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.SetGlobalAccessLogMode [1004]".Debug();
		public override uint GetGlobalAccessLogMode() => 0;
		public override void OutputAccessLogToSdCard(Buffer<byte> log_text) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.OutputAccessLogToSdCard [1006]".Debug();
		public override void RegisterUpdatePartition() => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.RegisterUpdatePartition [1007]".Debug();
		public override Nn.Fssrv.Sf.IFileSystem OpenRegisteredUpdatePartition() => throw new NotImplementedException();
		public override void GetAndClearMemoryReportInfo(out byte[] _0) => throw new NotImplementedException();
		public override object Unknown1010(object _0) => throw new NotImplementedException();
		public override void OverrideSaveDataTransferTokenSignVerificationKey(Buffer<byte> _0) => "Stub hit for Nn.Fssrv.Sf.IFileSystemProxy.OverrideSaveDataTransferTokenSignVerificationKey [1100]".Debug();
	}

	public partial class IFileSystem {
		readonly LibHac.Fs.IFileSystem Backing;

		public IFileSystem(LibHac.Fs.IFileSystem backing) => Backing = backing;
		
		public override void CreateFile(uint mode, ulong size, Buffer<byte> path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.CreateFile [0]".Debug();
		public override void DeleteFile(Buffer<byte> path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.DeleteFile [1]".Debug();
		public override void CreateDirectory(Buffer<byte> path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.CreateDirectory [2]".Debug();
		public override void DeleteDirectory(Buffer<byte> path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.DeleteDirectory [3]".Debug();
		public override void DeleteDirectoryRecursively(Buffer<byte> path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.DeleteDirectoryRecursively [4]".Debug();
		public override void RenameFile(Buffer<byte> old_path, Buffer<byte> new_path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.RenameFile [5]".Debug();
		public override void RenameDirectory(Buffer<byte> old_path, Buffer<byte> new_path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.RenameDirectory [6]".Debug();
		public override Nn.Fssrv.Sf.DirectoryEntryType GetEntryType(Buffer<byte> path) => throw new NotImplementedException();

		public override Nn.Fssrv.Sf.IFile OpenFile(uint mode, Buffer<byte> path) {
			var fn = Encoding.ASCII.GetString(path.Span).Split('\0', 2)[0];
			if(!Backing.FileExists(fn))
				throw new IpcException(2U | (1U << 9)); // FS.PathDoesNotExist
			return new IFile(Backing.OpenFile(fn, (OpenMode) mode));
		}
		
		public override Nn.Fssrv.Sf.IDirectory OpenDirectory(uint filter_flags, Buffer<byte> path) => throw new NotImplementedException();
		public override void Commit() => "Stub hit for Nn.Fssrv.Sf.IFileSystem.Commit [10]".Debug();
		public override ulong GetFreeSpaceSize(Buffer<byte> path) => throw new NotImplementedException();
		public override ulong GetTotalSpaceSize(Buffer<byte> path) => throw new NotImplementedException();
		public override void CleanDirectoryRecursively(Buffer<byte> path) => "Stub hit for Nn.Fssrv.Sf.IFileSystem.CleanDirectoryRecursively [13]".Debug();
		public override void GetFileTimeStampRaw(Buffer<byte> path, out byte[] timestamp) => throw new NotImplementedException();
		public override void QueryEntry(uint _0, Buffer<byte> path, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
	}

	public partial class IFile {
		readonly LibHac.Fs.IFile Backing;
		
		public IFile(LibHac.Fs.IFile backing) => Backing = backing;
		
		public override void Read(uint readOption, ulong offset, ulong size, out ulong out_size, Buffer<byte> out_buf) =>
			out_size = (ulong) Backing.Read(out_buf, (long) offset, (ReadOption) readOption);
		
		public override void Write(uint writeOption, ulong offset, ulong size, Buffer<byte> in_buf) =>
			Backing.Write(in_buf.Span, (long) offset, (WriteOption) writeOption);

		public override void Flush() => Backing.Flush();
		
		public override void SetSize(ulong size) => Backing.SetSize((long) size);

		public override ulong GetSize() => (ulong) Backing.GetSize();
		
		public override void OperateRange(uint _0, ulong _1, ulong _2, out byte[] _3) => throw new NotImplementedException();
	}

	public partial class IStorage {
		readonly LibHac.Fs.IStorage Backing;

		public IStorage(LibHac.Fs.IStorage backing) => Backing = backing;
		
		public override void Read(ulong offset, ulong length, Buffer<byte> data) => Backing.Read(data, (long) offset);
		public override void Write(ulong offset, ulong length, Buffer<byte> data) => "Stub hit for Nn.Fssrv.Sf.IStorage.Write [1]".Debug();
		public override void Flush() => "Stub hit for Nn.Fssrv.Sf.IStorage.Flush [2]".Debug();
		public override void SetSize(ulong size) => "Stub hit for Nn.Fssrv.Sf.IStorage.SetSize [3]".Debug();
		public override ulong GetSize() => throw new NotImplementedException();
		public override void OperateRange(uint _0, ulong _1, ulong _2, out byte[] _3) => throw new NotImplementedException();
	}
}
