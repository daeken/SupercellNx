#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pdm.Detail {
	public unsafe partial class INotifyService : _Base_INotifyService {}
	public unsafe class _Base_INotifyService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 6: { // Unknown6
					Unknown6(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INotifyService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown6(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IQueryService : _Base_IQueryService {}
	public unsafe class _Base_IQueryService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5(null);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 8: { // Unknown8
					Unknown8(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 9: { // Unknown9
					var ret = Unknown9();
					break;
				}
				case 10: { // Unknown10
					Unknown10(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 11: { // Unknown11
					Unknown11(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IQueryService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown1(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown3(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
		public virtual object Unknown5(object _0) => throw new NotImplementedException();
		public virtual object Unknown6(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown8(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown9() => throw new NotImplementedException();
		public virtual void Unknown10(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown11(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown12(object _0) => throw new NotImplementedException();
	}
}
