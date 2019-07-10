using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using Cpu64;
using LibHac;
using LibHac.Fs;
using LibHac.Fs.NcaUtils;
using MoreLinq.Extensions;
using PrettyPrinter;
using static Supercell.Globals;

namespace Supercell {
	public abstract class KObject {
		public readonly uint Handle;
		public bool Closed;
		public KObject() => Handle = Kernel.Add(this);
		public virtual void Close() {}
	}

	public class KEvent : KObject {
	}
	
	public class MicroKernel : IKernel {
		uint HandleIter;
		readonly Dictionary<uint, KObject> Handles = new Dictionary<uint, KObject>();

		public uint Add(KObject obj) {
			lock(Handles) {
				Handles[++HandleIter] = obj;
				return HandleIter;
			}
		}

		public T Get<T>(uint handle) where T : KObject => Handles.TryGetValue(handle, out var obj) ? obj as T : null;

		public void Close(KObject obj) {
			if(obj == null || obj.Closed) return;
			obj.Close();
			obj.Closed = true;
			Handles.Remove(obj.Handle);
		}
		
		readonly List<(ulong, ulong, string)> BinaryNames = new List<(ulong, ulong, string)>();

		public IStorage RomFs;
		
		public unsafe void LoadAndRun(string fn) {
			var pfs = new PartitionFileSystem(new FileStream(fn, FileMode.Open, FileAccess.Read).AsStorage());

			var keyset = ExternalKeys.ReadKeyFile(
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".switch/prod.keys"));

			foreach(var ticketEntry in pfs.EnumerateEntries("*.tik")) {
				var ticket = new Ticket(pfs.OpenFile(ticketEntry.FullPath, OpenMode.Read).AsStream());
				if(!keyset.TitleKeys.ContainsKey(ticket.RightsId))
					keyset.TitleKeys[ticket.RightsId] = ticket.GetTitleKey(keyset);
			}

			Nca main = null, patch = null, control = null;
			foreach(var ncaEntry in pfs.EnumerateEntries("*.nca")) {
				var storage = pfs.OpenFile(ncaEntry.FullPath, OpenMode.Read).AsStorage();
				var nca = new Nca(keyset, storage);
				if(nca.Header.ContentType == ContentType.Program) {
					if(nca.Header.GetFsHeader(Nca.GetSectionIndexFromType(NcaSectionType.Data, ContentType.Program))
						.IsPatchSection())
						patch = nca;
					else
						main = nca;
				} else if(nca.Header.ContentType == ContentType.Control)
					control = nca;
			}

			IStorage data = null;
			IFileSystem code = null;
			
			Debug.Assert(main != null);

			if(patch == null) {
				if(main.CanOpenSection(NcaSectionType.Data))
					data = main.OpenStorage(NcaSectionType.Data, IntegrityCheckLevel.ErrorOnInvalid);
				if(main.CanOpenSection(NcaSectionType.Code))
					code = main.OpenFileSystem(NcaSectionType.Code, IntegrityCheckLevel.ErrorOnInvalid);
			} else {
				if(patch.CanOpenSection(NcaSectionType.Data))
					data = main.OpenStorageWithPatch(patch, NcaSectionType.Data, IntegrityCheckLevel.ErrorOnInvalid);
				if(patch.CanOpenSection(NcaSectionType.Code))
					code = main.OpenFileSystemWithPatch(patch, NcaSectionType.Code, IntegrityCheckLevel.ErrorOnInvalid);
			}
			
			Debug.Assert(code != null && data != null);
			
			(ulong Addr, ulong Size, Nxo Nxo) LoadBinary(ulong preferred, string path) {
				$"Loading {path}".Debug();
				var bin = Nxo.Load(code.OpenFile(path, OpenMode.Read).AsStream());

				var size = (ulong) bin.Data.Length + (bin.BssEnd - bin.BssStart + 0x2000);
				var addr = Memory.AllocateAligned(size, preferred);
				//if(Path.GetFileName(path) == firstBinary && addr != preferred) throw new Exception("Couldn't map binary to preferred addr");
				$"Loaded at 0x{addr:X} - 0x{addr+size:X}".Debug();

				var root = (byte*) addr;
				foreach(var v in bin.Data)
					*root++ = v;

				return (addr, size, bin);
			}

			var filemap = code.EnumerateEntries().Select(x => (Path.GetFileName(x.FullPath), x.FullPath)).ToDictionary();
			var nfns = new List<string>();
			if(filemap.ContainsKey("rtld"))
				nfns.Add(filemap["rtld"]);
			if(filemap.ContainsKey("main"))
				nfns.Add(filemap["main"]);
			nfns = nfns.Concat(filemap.Where(kv => kv.Key.StartsWith("subsdk") && !kv.Key.Contains('.'))
				.Select(kv => kv.Value).OrderBy(x => x)).ToList();
			if(filemap.ContainsKey("sdk"))
				nfns.Add(filemap["sdk"]);
			var binaries = nfns.Select((x, i) => LoadBinary(0x7100000000U + ((ulong) i << 32), x)).ToList();
			binaries.ForEach((x, i) => BinaryNames.Add((x.Addr, x.Addr + x.Size, Path.GetFileName(nfns[i]))));

			RomFs = data;
			
			Thread.CurrentThread.Run(binaries[0].Addr);
		}

		public string MapAddress(ulong addr) {
			foreach(var (start, end, name) in BinaryNames)
				if(start <= addr && end > addr)
					return $"0x{addr:X} ({name} @ 0x{addr - start + 0x7100000000:X})";
			return $"0x{addr:X}";
		}
		public IEnumerable<(ulong Start, ulong Size)> MemoryRegions => Memory.Regions.Values;
		public void Svc(int svc) => Service.Svc(svc);

		public void Log(string message) => Logger.Log(message);
		public void LogExclusive(Action cb) => Logger.Exclusive(cb);

		[Svc(0x16)]
		public uint Close(uint handle) {
			Close(Get<KObject>(handle));
			return 0;
		}

		[Svc(0x26)]
		public uint Break(ulong reason, ulong _, ulong info) {
			throw new Exception($"Break({reason}, {info})");
		}

		string DebugBuffer = "";
		[Svc(0x27)]
		public unsafe uint OutputDebugString(ulong addr, ulong size) {
			var data = new byte[size];
			for(var i = 0; i < data.Length; ++i)
				data[i] = *(byte*) (addr + (ulong) i);
			DebugBuffer += Encoding.ASCII.GetString(data);
			int j;
			while((j = DebugBuffer.IndexOf('\n')) != -1) {
				$"Debug string: {DebugBuffer.Substring(0, j).ToPrettyString()}".Debug();
				DebugBuffer = DebugBuffer.Substring(j + 1);
			}
			return 0;
		}

		[Svc(0x29)]
		public (uint, ulong) GetInfo(ulong _, uint id1, uint handle, uint id2) {
			$"GetInfo({id1}, 0x{handle:X}, {id2})".Debug();
			var value = 0UL;
			switch((id1, id2)) {
				case (0, 0): value = 0xF; break;
				case (1, 0): value = 0xFFFFFFFF00000000UL; break;
				case (2, 0): value = 0xbb0000000; break;
				case (3, 0): value = 0x1000000000; break;
				case (4, 0): value = Memory.HeapAddress; break;
				case (5, 0): value = Memory.HeapSize; break;
				case (6, 0): value = 0x400000; break;
				case (7, 0): value = 0x10000; break;
				case (8, 0): value = 0; break;
				case (12, 0): value = 0; break;
				case (13, 0): value = 1UL << 40; break;
				case (14, 0): value = Memory.StackBase; break;
				case (15, 0): value = Memory.StackSize; break;
				case (18, 0): value = 0x10000; break;
				case (11, _): value = 0; break;
				default:
					$"Unhandled GetInfo!".Debug();
					return (0xF001, 0);
			}
			return (0, value);
		}
	}
}