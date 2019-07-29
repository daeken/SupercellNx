using System;
using System.Collections.Generic;
using System.IO;
using OpenFonts;

namespace Supercell.IpcServices.Nn.Pl.Detail {
	public partial class ISharedFontManager {
		static readonly byte[][] OpenFonts = {
			Data.ChineseSimplified, 
			Data.ChineseTraditional, 
			Data.ExtendedChineseSimplified, 
			Data.Korean, 
			Data.NintendoExtended, 
			Data.Standard
		};
		
		readonly byte[] EncData;
		readonly List<(int Offset, int Size)> Regions = new List<(int Offset, int Size)>();
		
		public ISharedFontManager() {
			const uint ExpectedResult = 0x7f9a0218;
			const uint ExpectedMagic = 0x36f81a1e;
			const uint Key = ExpectedMagic ^ ExpectedResult;
			
			using var ms = new MemoryStream();
			using var bw = new BinaryWriter(ms);
			foreach(var ttf in OpenFonts) {
				Regions.Add(((int) ms.Position + 8, ttf.Length));
				bw.Write(ExpectedResult);
				bw.Write((uint) ttf.Length ^ Key);
				bw.Write(ttf);
			}
			EncData = ms.ToArray();
		}
		
		public override void RequestLoad(uint _0) => "Stub hit for Nn.Pl.Detail.ISharedFontManager.RequestLoad [0]".Debug();
		public override uint GetLoadState(uint _0) => 1;
		public override uint GetSize(uint fontId) => (uint) Regions[(int) fontId].Size;
		public override uint GetSharedMemoryAddressOffset(uint fontId) => (uint) Regions[(int) fontId].Offset;
		public override KObject GetSharedMemoryNativeHandle() => new KSharedMemory(EncData);
		public override void GetSharedFontInOrderOfPriority(byte[] _0, out byte _1, out uint _2, Buffer<byte> _3, Buffer<byte> _4, Buffer<byte> _5) => throw new NotImplementedException();
	}
}