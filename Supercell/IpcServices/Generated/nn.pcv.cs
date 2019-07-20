#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pcv {
	[IpcService("pcv:arb")]
	public unsafe partial class IArbitrationManager : _Base_IArbitrationManager {}
	public unsafe class _Base_IArbitrationManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ReleaseControl
					ReleaseControl(im.GetData<uint>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IArbitrationManager: {im.CommandId}");
			}
		}
		
		public virtual void ReleaseControl(uint _0) => throw new NotImplementedException();
	}
	
	[IpcService("pcv:imm")]
	public unsafe partial class IImmediateManager : _Base_IImmediateManager {}
	public unsafe class _Base_IImmediateManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetClockRate
					SetClockRate(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IImmediateManager: {im.CommandId}");
			}
		}
		
		public virtual void SetClockRate(uint _0, uint _1) => throw new NotImplementedException();
	}
}
