#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfc.Am.Detail {
	[IpcService("nfc:am")]
	public unsafe partial class IAmManager : _Base_IAmManager {}
	public unsafe class _Base_IAmManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateAmInterface
					var ret = CreateAmInterface();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAmManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Nfc.Am.Detail.IAm CreateAmInterface() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAm : _Base_IAm {}
	public unsafe class _Base_IAm : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Finalize
					Finalize();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // NotifyForegroundApplet
					NotifyForegroundApplet(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAm: {im.CommandId}");
			}
		}
		
		public virtual void Initialize() => "Stub hit for Nn.Nfc.Am.Detail.IAm.Initialize [0]".Debug();
		public virtual void Finalize() => "Stub hit for Nn.Nfc.Am.Detail.IAm.Finalize [1]".Debug();
		public virtual void NotifyForegroundApplet(object _0) => "Stub hit for Nn.Nfc.Am.Detail.IAm.NotifyForegroundApplet [2]".Debug();
	}
}
