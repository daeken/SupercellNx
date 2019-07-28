using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Settings {
	public partial class ISettingsServer {
		public override void GetLanguageCode(out byte[] code) =>
			code = BitConverter.GetBytes(LanguageCode.GetLanguageCode(1));

		public override void GetAvailableLanguageCodes(out uint count, Buffer<byte> _languageCodes) {
			var languageCodes = _languageCodes.As<ulong>();
			count = (uint) languageCodes.Length;
			for(var i = 0; i < count; ++i)
				languageCodes[i] = LanguageCode.GetLanguageCode(i);
		}
		
		public override void MakeLanguageCode(uint _0, out byte[] _1) => throw new NotImplementedException();
		public override uint GetAvailableLanguageCodeCount() => throw new NotImplementedException();
		public override uint GetRegionCode() => throw new NotImplementedException();
		public override void GetAvailableLanguageCodes2(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override uint GetAvailableLanguageCodeCount2() => throw new NotImplementedException();
		public override void GetKeyCodeMap(Buffer<byte> _0) => throw new NotImplementedException();
		public override object GetQuestFlag(object _0) => throw new NotImplementedException();
	}
}