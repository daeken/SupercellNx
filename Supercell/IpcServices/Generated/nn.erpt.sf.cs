#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Erpt.Sf {
	[IpcService("erpt:c")]
	public unsafe partial class IContext : _Base_IContext {}
	public unsafe class _Base_IContext : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SubmitContext
					SubmitContext(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				case 1: { // CreateReport
					CreateReport(null, im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1), im.GetBuffer<byte>(0x5, 2));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3();
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
					var ret = Unknown6(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContext: {im.CommandId}");
			}
		}
		
		public virtual void SubmitContext(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void CreateReport(object _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5() => throw new NotImplementedException();
		public virtual object Unknown6(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("erpt:r")]
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenReport
					var ret = OpenReport();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // OpenManager
					var ret = OpenManager();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISession: {im.CommandId}");
			}
		}
		
		public virtual Nn.Erpt.Sf.IReport OpenReport() => throw new NotImplementedException();
		public virtual Nn.Erpt.Sf.IManager OpenManager() => throw new NotImplementedException();
	}
	
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetReportList
					GetReportList(null, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1: { // GetEvent
					var ret = GetEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual void GetReportList(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject GetEvent() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual object Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IReport : _Base_IReport {}
	public unsafe class _Base_IReport : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Open
					Open(null);
					break;
				}
				case 1: { // Read
					Read(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // SetFlags
					SetFlags(null);
					break;
				}
				case 3: { // GetFlags
					var ret = GetFlags();
					break;
				}
				case 4: { // _Close
					_Close();
					break;
				}
				case 5: { // GetSize
					var ret = GetSize();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IReport: {im.CommandId}");
			}
		}
		
		public virtual void Open(object _0) => throw new NotImplementedException();
		public virtual void Read(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetFlags(object _0) => throw new NotImplementedException();
		public virtual object GetFlags() => throw new NotImplementedException();
		public virtual void _Close() => throw new NotImplementedException();
		public virtual object GetSize() => throw new NotImplementedException();
	}
}
