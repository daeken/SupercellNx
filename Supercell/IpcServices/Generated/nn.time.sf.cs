#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Time.Sf {
	public unsafe struct CalendarAdditionalInfo {
		public uint TmWday;
		public int TmYday;
		public fixed byte TzName[8];
		public bool IsDaylightSavingTime;
		public int UtcOffsetSeconds;
	}
}
