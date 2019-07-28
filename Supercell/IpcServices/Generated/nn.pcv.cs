#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pcv {
	[IpcService("pcv:arb")]
	public unsafe partial class IArbitrationManager : _Base_IArbitrationManager {}
	public unsafe class _Base_IArbitrationManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ReleaseControl
					ReleaseControl(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IArbitrationManager: {im.CommandId}");
			}
		}
		
		public virtual void ReleaseControl(uint _0) => "Stub hit for Nn.Pcv.IArbitrationManager.ReleaseControl [0]".Debug();
	}
	
	[IpcService("pcv:imm")]
	public unsafe partial class IImmediateManager : _Base_IImmediateManager {}
	public unsafe class _Base_IImmediateManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetClockRate
					SetClockRate(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IImmediateManager: {im.CommandId}");
			}
		}
		
		public virtual void SetClockRate(uint _0, uint _1) => "Stub hit for Nn.Pcv.IImmediateManager.SetClockRate [0]".Debug();
	}
}
