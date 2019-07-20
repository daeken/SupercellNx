#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nv.Gemcoredump {
	[IpcService("nvgem:cd")]
	public unsafe partial class INvGemCoreDump : _Base_INvGemCoreDump {}
	public unsafe class _Base_INvGemCoreDump : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2(out var _0, im.GetBuffer<byte>(0x22, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INvGemCoreDump: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
}
