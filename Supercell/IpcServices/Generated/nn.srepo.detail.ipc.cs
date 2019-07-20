#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Srepo.Detail.Ipc {
	[IpcService("srepo:u")]
	[IpcService("srepo:a")]
	public unsafe partial class ISrepoService : _Base_ISrepoService {}
	public unsafe class _Base_ISrepoService : IpcInterface {
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
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISrepoService: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual object Unknown1(object _0) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
	}
}
