#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Time {
	public unsafe struct CalendarTime {
		public ushort Year;
		public byte Month;
		public byte Day;
		public byte Hour;
		public byte Minute;
		public byte Second;
	}
}
