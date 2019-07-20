#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ro.Detail {
	public unsafe partial class IDebugMonitorInterface : _Base_IDebugMonitorInterface {}
	public unsafe class _Base_IDebugMonitorInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugMonitorInterface: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	public unsafe partial class IRoInterface : _Base_IRoInterface {}
	public unsafe class _Base_IRoInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.GetData<ulong>(32), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 2: { // Unknown2
					Unknown2(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 4: { // Unknown4
					Unknown4(im.GetData<ulong>(0), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRoInterface: {im.CommandId}");
			}
		}
		
		public virtual ulong Unknown0(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4, ulong _5) => throw new NotImplementedException();
		public virtual void Unknown1(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void Unknown2(ulong _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void Unknown3(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void Unknown4(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
	}
}
