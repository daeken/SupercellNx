using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Common;
using K4os.Compression.LZ4;
using PrettyPrinter;

namespace App {
	enum DynamicKey {
		NULL,
		NEEDED,
		PLTRELSZ,
		PLTGOT,
		HASH,
		STRTAB,
		SYMTAB,
		RELA,
		RELASZ,
		RELAENT,
		STRSZ,
		SYMENT,
		INIT,
		FINI,
		SONAME,
		RPATH,
		SYMBOLIC,
		REL,
		RELSZ,
		RELENT,
		PLTREL,
		DEBUG,
		TEXTREL,
		JMPREL,
		BIND_NOW,
		INIT_ARRAY,
		FINI_ARRAY,
		INIT_ARRAYSZ,
		FINI_ARRAYSZ,
		RUNPATH,
		FLAGS
	}
	
	public abstract class Nxo {
		class Symbol {
			
		}
		
		public static Nxo Load(Stream stream) {
			var br = new BinaryReader(stream);
			switch(br.ReadString(4)) {
				case "NSO0": return new Nso(br);
				case { } x: throw new NotSupportedException($"Unknown magic to NXO loader: {x.ToPrettyString()}");
				default: throw new NotSupportedException();
			}
		}

		string Dynstr;
		public byte[] Data;

		protected void Load(
			(byte[] Data, uint Offset, uint Loc, uint Size) text, 
			(byte[] Data, uint Offset, uint Loc, uint Size) ro, 
			(byte[] Data, uint Offset, uint Loc, uint Size) data
		) {
			var full = Data = new byte[data.Loc + data.Size];
			Array.Copy(text.Data, full, Math.Min(text.Data.Length, ro.Loc));
			Array.Copy(ro.Data, 0, full, ro.Loc, Math.Min(ro.Data.Length, data.Loc - ro.Loc));
			Array.Copy(data.Data, 0, full, data.Loc, data.Data.Length);
			
			using var ms = new MemoryStream(full);
			using var br = new BinaryReader(ms);

			var modOff = br.At(4).ReadUInt32();
			Debug.Assert(br.At(modOff).ReadString(4) == "MOD0");

			var dynamicOff = modOff + br.ReadUInt32();
			var bssOff = modOff + br.ReadUInt32();
			var bssEnd = modOff + br.ReadUInt32();
			var unwindOff = modOff + br.ReadUInt32();
			var unwindEnd = modOff + br.ReadUInt32();
			var moduleOff = modOff + br.ReadUInt32();

			var dataSize = bssOff - data.Loc;
			var bssSize = bssEnd - bssOff;
			
			if(br.At(dynamicOff).ReadUInt64() > 0xFFFFFFFFU || br.At(dynamicOff + 0x10).ReadUInt64() > 0xFFFFFFFFU)
				throw new NotSupportedException("Aarch32 binaries not supported");

			var dynamic = new Dictionary<DynamicKey, ulong>();

			br.At(dynamicOff);
			while(true) {
				var (tag, val) = ((DynamicKey) br.ReadUInt64(), br.ReadUInt64());
				if(tag == DynamicKey.NULL)
					break;
				if(tag != DynamicKey.NEEDED)
					dynamic[tag] = val;
			}

			Dynstr = Encoding.ASCII.GetString(br.At((long) dynamic[DynamicKey.STRTAB]).ReadBytes((int) dynamic[DynamicKey.STRSZ]));
			
			Debug.Assert(dynamic[DynamicKey.SYMTAB] < dynamic[DynamicKey.STRTAB]);
			var symbols = new List<Symbol>();
		}

		string GetDynstr(ulong i) => Dynstr.Substring((int) i, Dynstr.IndexOf('\0', (int) i) - (int) i);
	}

	public class Nso : Nxo {
		public Nso(BinaryReader br) {
			var flags = br.At(0xC).ReadUInt32();
			var (toff, tloc, tsize) = (br.At(0x10).ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());
			var (roff, rloc, rsize) = (br.At(0x20).ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());
			var (doff, dloc, dsize) = (br.At(0x30).ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());
			
			var (tfilesize, rfilesize, dfilesize) = (br.At(0x60).ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());

			var textData = br.At(toff).ReadBytes((int) tfilesize);
			if(flags.HasBit(0)) {
				textData = Decompress(textData, tsize);
				toff = 0;
			}
			var roData = br.At(roff).ReadBytes((int) rfilesize);
			if(flags.HasBit(1)) {
				roData = Decompress(roData, rsize);
				roff = 0;
			}
			var dataData = br.At(doff).ReadBytes((int) dfilesize);
			if(flags.HasBit(2)) {
				dataData = Decompress(dataData, dsize);
				doff = 0;
			}

			Load((textData, toff, tloc, tsize), (roData, roff, rloc, rsize), (dataData, doff, dloc, dsize));
		}

		byte[] Decompress(byte[] data, uint size) {
			var ret = new byte[size];
			LZ4Codec.Decode(data, ret);
			return ret;
		}
	}
}