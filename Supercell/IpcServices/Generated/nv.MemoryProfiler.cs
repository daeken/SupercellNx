#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nv.MemoryProfiler {
	public unsafe partial class IMemoryProfiler : _Base_IMemoryProfiler {}
	public unsafe class _Base_IMemoryProfiler : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IMemoryProfiler: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual object Unknown1(object _0) => throw new NotImplementedException();
	}
}
