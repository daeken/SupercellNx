using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#if FULLSIGIL
using Sigil;
using Label = Sigil.Label;
#else
using SigilLite;
using Label = SigilLite.Label;
#endif
using UltimateOrb;
using Common;
// ReSharper disable ArrangeRedundantParentheses
// ReSharper disable RedundantCast
// ReSharper disable UnusedVariable
#pragma warning disable 162, 219

namespace Cpu64 {
	public partial class Recompiler {
		public bool Recompile(uint inst, ulong pc) {
			unchecked {
/*%CODE%*/
			}
			return false;
		}
	}
}