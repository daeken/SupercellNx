#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Nfc.Am.Detail {
	[IpcService("nfc:am")]
	public unsafe partial class IAmManager : _Base_IAmManager {}
	public unsafe class _Base_IAmManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateAmInterface
					var ret = CreateAmInterface();
					om.Move(0, ret.Handle);
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize();
					break;
				}
				case 1: { // Finalize
					Finalize();
					break;
				}
				case 2: { // NotifyForegroundApplet
					NotifyForegroundApplet(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAm: {im.CommandId}");
			}
		}
		
		public virtual void Initialize() => throw new NotImplementedException();
		public virtual void Finalize() => throw new NotImplementedException();
		public virtual void NotifyForegroundApplet(object _0) => throw new NotImplementedException();
	}
}
