using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.settings {
	[IpcService("set")]
	public class ISettingsServer : IpcInterface {
		[IpcCommand(0)]
		void GetLanguageCode(out ulong languageCode) => languageCode = LanguageCode.GetLanguageCode(1);
		[IpcCommand(1)]
		void GetAvailableLanguageCodes(out int count, [Buffer(0xa)] Buffer<ulong> languageCodes) {
			count = languageCodes.Length;
			for(var i = 0; i < count; ++i)
				languageCodes[i] = LanguageCode.GetLanguageCode(i);
		}
		[IpcCommand(2)]
		void MakeLanguageCode(uint unknown0, out ulong languageCode) => throw new NotImplementedException();
		[IpcCommand(3)]
		void GetAvailableLanguageCodeCount(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(4)]
		void GetRegionCode(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(5)]
		void GetAvailableLanguageCodes2(out uint unknown0, [Buffer(0x6)] Buffer<byte> languageCodes) => throw new NotImplementedException();
		[IpcCommand(6)]
		void GetAvailableLanguageCodeCount2(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(7)]
		void GetKeyCodeMap([Buffer(0x16)] Buffer<byte> keymap) => throw new NotImplementedException();
		[IpcCommand(8)]
		void GetQuestFlag(object unknown0, out object unknown1) => throw new NotImplementedException();
	}
}