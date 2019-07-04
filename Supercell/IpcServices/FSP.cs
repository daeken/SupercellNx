using System;
using System.IO;
using static Supercell.Globals;

// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.fssrv.sf {
	public enum FileSystemType : uint {
		Invalid = 0, 
		Invalid2 = 1, 
		Logo = 2, 
		ContentControl = 3, 
		ContentManual = 4, 
		ContentMeta = 5, 
		ContentData = 6, 
		ApplicationPackage = 7
	}

	public enum Partition : uint {
		BootPartition1Root = 0, 
		BootPartition2Root = 10, 
		UserDataRoot = 20, 
		BootConfigAndPackage2Part1 = 21, 
		BootConfigAndPackage2Part2 = 22, 
		BootConfigAndPackage2Part3 = 23, 
		BootConfigAndPackage2Part4 = 24, 
		BootConfigAndPackage2Part5 = 25, 
		BootConfigAndPackage2Part6 = 26, 
		CalibrationBinary = 27, 
		CalibrationFile = 28, 
		SafeMode = 29, 
		SystemProperEncryption = 30, 
		User = 31
	}
	
	[IpcService("fsp-srv")]
	public class IFileSystemProxy : IpcInterface {
		[IpcCommand(0)]
		void OpenFileSystem(FileSystemType filesystem_type, [Buffer(0x19)] Buffer<byte> unknown0, [Move] out IFileSystem unknown1) => throw new NotImplementedException();
		[IpcCommand(1)]
		void SetCurrentProcess(ulong unknown0, [Pid] ulong pid) {}
		[IpcCommand(2)]
		void OpenDataFileSystemByCurrentProcess([Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(7)]
		void OpenFileSystemWithPatch(FileSystemType filesystem_type, ulong id, [Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(8)]
		void OpenFileSystemWithId(FileSystemType filesystem_type, ulong /* nn::ApplicationId */ tid, [Buffer(0x19)] Buffer<byte> unknown0, [Move] out IFileSystem contentFs) => throw new NotImplementedException();
		[IpcCommand(9)]
		void OpenDataFileSystemByApplicationId(ulong /* nn::ApplicationId */ u64, [Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(11)]
		void OpenBisFileSystem(Partition partitionId, [Buffer(0x19)] Buffer<byte> unknown0, [Move] out IFileSystem bis) => throw new NotImplementedException();
		[IpcCommand(12)]
		void OpenBisStorage(Partition partitionId, [Move] out IStorage bisPartition) => throw new NotImplementedException();
		[IpcCommand(13)]
		void InvalidateBisCache() => throw new NotImplementedException();
		[IpcCommand(17)]
		void OpenHostFileSystem([Buffer(0x19)] Buffer<byte> unknown0, [Move] out IFileSystem unknown1) => throw new NotImplementedException();
		[IpcCommand(18)]
		void OpenSdCardFileSystem([Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(19)]
		void FormatSdCardFileSystem() => throw new NotImplementedException();
		[IpcCommand(21)]
		void DeleteSaveDataFileSystem(ulong /* nn::ApplicationId */ tid) => throw new NotImplementedException();
		[IpcCommand(22)]
		void CreateSaveDataFileSystem([Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveStruct */ save_struct, [Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveCreateStruct */ ave_create_struct, [Bytes(0x40 /* 16 x 4 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(23)]
		void CreateSaveDataFileSystemBySystemSaveDataId([Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveStruct */ unknown0, [Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveCreateStruct */ unknown1) => throw new NotImplementedException();
		[IpcCommand(24)]
		void RegisterSaveDataFileSystemAtomicDeletion([Buffer(0x5)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(25)]
		void DeleteSaveDataFileSystemBySaveDataSpaceId(byte unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(26)]
		void FormatSdCardDryRun() => throw new NotImplementedException();
		[IpcCommand(27)]
		void IsExFatSupported(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(28)]
		void DeleteSaveDataFileSystemBySaveDataAttribute(byte unknown0, [Bytes(0x200 /* 64 x 8 */)] byte[] unknown1) => throw new NotImplementedException();
		[IpcCommand(30)]
		void OpenGameCardStorage(uint unknown0, uint unknown1, [Move] out IStorage unknown2) => throw new NotImplementedException();
		[IpcCommand(31)]
		void OpenGameCardFileSystem(uint unknown0, uint unknown1, [Move] out IFileSystem unknown2) => throw new NotImplementedException();
		[IpcCommand(32)]
		void ExtendSaveDataFileSystem(byte unknown0, ulong unknown1, ulong unknown2, ulong unknown3) => throw new NotImplementedException();
		[IpcCommand(33)]
		void DeleteCacheStorage(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(34)]
		void GetCacheStorageSize(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(51)]
		void OpenSaveDataFileSystem(byte save_data_space_id, [Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveStruct */ save_struct, [Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(52)]
		void OpenSaveDataFileSystemBySystemSaveDataId(byte save_data_space_id, [Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveStruct */ save_struct, [Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(53)]
		void OpenReadOnlySaveDataFileSystem(byte save_data_space_id, [Bytes(0x200 /* 64 x 8 */)] byte[] /* nn::fssrv::sf::SaveStruct */ save_struct, [Move] out IFileSystem unknown0) => throw new NotImplementedException();
		[IpcCommand(57)]
		void ReadSaveDataFileSystemExtraDataBySaveDataSpaceId(byte unknown0, ulong unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(58)]
		void ReadSaveDataFileSystemExtraData(ulong unknown0, [Buffer(0x6)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(59)]
		void WriteSaveDataFileSystemExtraData(byte unknown0, ulong unknown1, [Buffer(0x5)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(60)]
		void OpenSaveDataInfoReader(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(61)]
		void OpenSaveDataInfoReaderBySaveDataSpaceId(byte unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(62)]
		void OpenCacheStorageList(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(64)]
		void OpenSaveDataInternalStorageFileSystem(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(65)]
		void UpdateSaveDataMacForDebug(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(66)]
		void WriteSaveDataFileSystemExtraData2(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(80)]
		void OpenSaveDataMetaFile(byte unknown0, uint unknown1, [Bytes(0x200 /* 64 x 8 */)] byte[] unknown2, out object unknown3) => throw new NotImplementedException();
		[IpcCommand(81)]
		void OpenSaveDataTransferManager(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(82)]
		void OpenSaveDataTransferManagerVersion2(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(100)]
		void OpenImageDirectoryFileSystem(uint unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(110)]
		void OpenContentStorageFileSystem(uint content_storage_id, out object content_fs) => throw new NotImplementedException();
		[IpcCommand(200)]
		void OpenDataStorageByCurrentProcess([Move] out IStorage data_storage) => data_storage = new IStorage(Kernel.RomFs);
		[IpcCommand(201)]
		void OpenDataStorageByProgramId(ulong /* nn::ApplicationId */ tid, out object data_storage) => throw new NotImplementedException();
		[IpcCommand(202)]
		void OpenDataStorageByDataId(byte storage_id, ulong /* nn::ApplicationId */ tid, out object data_storage) => throw new NotImplementedException();
		[IpcCommand(203)]
		void OpenPatchDataStorageByCurrentProcess(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(400)]
		void OpenDeviceOperator(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(500)]
		void OpenSdCardDetectionEventNotifier(out object sd_event_notify) => throw new NotImplementedException();
		[IpcCommand(501)]
		void OpenGameCardDetectionEventNotifier(out object game_card_event_notify) => throw new NotImplementedException();
		[IpcCommand(510)]
		void OpenSystemDataUpdateEventNotifier(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(511)]
		void NotifySystemDataUpdateEvent(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(600)]
		void SetCurrentPosixTime(ulong time) => throw new NotImplementedException();
		[IpcCommand(601)]
		void QuerySaveDataTotalSize(ulong unknown0, ulong unknown1, out ulong save_data_size) => throw new NotImplementedException();
		[IpcCommand(602)]
		void VerifySaveDataFileSystem(ulong unknown0, [Buffer(0x6)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(603)]
		void CorruptSaveDataFileSystem(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(604)]
		void CreatePaddingFile(ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(605)]
		void DeleteAllPaddingFiles() => throw new NotImplementedException();
		[IpcCommand(606)]
		void GetRightsId(byte unknown0, ulong unknown1, [Bytes(0x80 /* 16 x 8 */)] out byte[] rights) => throw new NotImplementedException();
		[IpcCommand(607)]
		void RegisterExternalKey([Bytes(0x80 /* 16 x 8 */)] byte[] unknown0, [Bytes(0x10 /* 16 x 1 */)] byte[] unknown1) => throw new NotImplementedException();
		[IpcCommand(608)]
		void UnregisterAllExternalKey() => throw new NotImplementedException();
		[IpcCommand(609)]
		void GetRightsIdByPath([Buffer(0x19)] Buffer<byte> unknown0, [Bytes(0x80 /* 16 x 8 */)] out byte[] rights) => throw new NotImplementedException();
		[IpcCommand(610)]
		void GetRightsIdAndKeyGenerationByPath([Buffer(0x19)] Buffer<byte> unknown0, out byte unknown1, [Bytes(0x80 /* 16 x 8 */)] out byte[] rights) => throw new NotImplementedException();
		[IpcCommand(611)]
		void SetCurrentPosixTimeWithTimeDifference(uint unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(612)]
		void GetFreeSpaceSizeForSaveData(byte unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(613)]
		void VerifySaveDataFileSystemBySaveDataSpaceId(byte unknown0, ulong unknown1, [Buffer(0x6)] Buffer<byte> unknown2) => throw new NotImplementedException();
		[IpcCommand(614)]
		void CorruptSaveDataFileSystemBySaveDataSpaceId(byte unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(615)]
		void QuerySaveDataInternalStorageTotalSize(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(620)]
		void SetSdCardEncryptionSeed([Bytes(0x10 /* 16 x 1 */)] byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(630)]
		void SetSdCardAccessibility(byte unknown0) => throw new NotImplementedException();
		[IpcCommand(631)]
		void IsSdCardAccessible(out byte unknown0) => throw new NotImplementedException();
		[IpcCommand(640)]
		void IsSignedSystemPartitionOnSdCardValid(out byte unknown0) => throw new NotImplementedException();
		[IpcCommand(700)]
		void OpenAccessFailureResolver(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(701)]
		void GetAccessFailureDetectionEvent(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(702)]
		void IsAccessFailureDetected(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(710)]
		void ResolveAccessFailure(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(720)]
		void AbandonAccessFailure(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(800)]
		void GetAndClearFileSystemProxyErrorInfo([Bytes(0x200 /* 128 x 4 */)] out byte[] error_info) => throw new NotImplementedException();
		[IpcCommand(1000)]
		void SetBisRootForHost(uint unknown0, [Buffer(0x19)] Buffer<byte> unknown1) => throw new NotImplementedException();
		[IpcCommand(1001)]
		void SetSaveDataSize(ulong unknown0, ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(1002)]
		void SetSaveDataRootPath([Buffer(0x19)] Buffer<byte> unknown0) => throw new NotImplementedException();
		[IpcCommand(1003)]
		void DisableAutoSaveDataCreation() => throw new NotImplementedException();
		[IpcCommand(1004)]
		void SetGlobalAccessLogMode(uint mode) {}
		[IpcCommand(1005)]
		void GetGlobalAccessLogMode(out uint mode) => mode = 0;
		[IpcCommand(1006)]
		void OutputAccessLogToSdCard([Buffer(0x5)] Buffer<byte> log_text) => throw new NotImplementedException();
		[IpcCommand(1007)]
		void RegisterUpdatePartition() => throw new NotImplementedException();
		[IpcCommand(1008)]
		void OpenRegisteredUpdatePartition(out object unknown0) => throw new NotImplementedException();
		[IpcCommand(1009)]
		void GetAndClearMemoryReportInfo([Bytes(0x400 /* 128 x 8 */)] out byte[] unknown0) => throw new NotImplementedException();
		[IpcCommand(1010)]
		void Unknown1010(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(1100)]
		void OverrideSaveDataTransferTokenSignVerificationKey([Buffer(0x5)] Buffer<byte> unknown0) => throw new NotImplementedException();
	}
	
	public class IFileSystem : IpcInterface {
	}

	public class IStorage : IpcInterface {
		readonly LibHac.Fs.IStorage Backing;

		public IStorage(LibHac.Fs.IStorage backing) => Backing = backing;
		
		[IpcCommand(0)]
		void Read(ulong offset, ulong length, [Buffer(0x46)] Buffer<byte> data) => Backing.Read(data, (long) offset);
		[IpcCommand(1)]
		void Write(ulong offset, ulong length, [Buffer(0x45)] Buffer<byte> data) => throw new NotImplementedException();
		[IpcCommand(2)]
		void Flush() => throw new NotImplementedException();
		[IpcCommand(3)]
		void SetSize(ulong size) => throw new NotImplementedException();
		[IpcCommand(4)]
		void GetSize(out ulong size) => throw new NotImplementedException();
		[IpcCommand(5)]
		void OperateRange(uint unknown0, ulong unknown1, ulong unknown2, [Bytes(0x100 /* 64 x 4 */)] out byte[] unknown3) => throw new NotImplementedException();
	}
}
