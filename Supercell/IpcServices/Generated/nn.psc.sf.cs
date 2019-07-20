#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Psc.Sf {
	[IpcService("psc:c")]
	public unsafe partial class IPmControl : _Base_IPmControl {}
	public unsafe class _Base_IPmControl : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					break;
				}
				case 6: { // Unknown6
					Unknown6(out var _0, im.GetBuffer<byte>(0x6, 0), im.GetBuffer<byte>(0x6, 1));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPmControl: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1(object _0) => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5() => throw new NotImplementedException();
		public virtual void Unknown6(out object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("psc:m")]
	public unsafe partial class IPmService : _Base_IPmService {}
	public unsafe class _Base_IPmService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetPmModule
					var ret = GetPmModule();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPmService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Psc.Sf.IPmModule GetPmModule() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPmModule : _Base_IPmModule {}
	public unsafe class _Base_IPmModule : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(null, im.GetBuffer<byte>(0x5, 0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // GetRequest
					var ret = GetRequest();
					break;
				}
				case 2: { // Acknowledge
					Acknowledge();
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPmModule: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object GetRequest() => throw new NotImplementedException();
		public virtual void Acknowledge() => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
	}
}
