namespace Supercell {
	public class LanguageCode {
		public static readonly string[] LanguageCodes = {
			"ja",
			"en-US",
			"fr",
			"de",
			"it",
			"es",
			"zh-CN",
			"ko",
			"nl",
			"pt",
			"ru",
			"zh-TW",
			"en-GB",
			"fr-CA",
			"es-419",
			"zh-Hans",
			"zh-Hant"
		};

		public static ulong GetLanguageCode(int index) {
			ulong code = 0;
			var shift = 0;
			foreach(var chr in LanguageCodes[index])
				code |= (ulong) (byte) chr << shift++ * 8;
			return code;
		}
	}
}