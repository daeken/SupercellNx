#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Erpt.Sf {
	[IpcService("erpt:c")]
	public unsafe partial class IContext : _Base_IContext {}
	public unsafe class _Base_IContext : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SubmitContext
					SubmitContext(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // CreateReport
					CreateReport(null, im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1), im.GetBuffer<byte>(0x5, 2));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContext: {im.CommandId}");
			}
		}
		
		public virtual void SubmitContext(Buffer<byte> _0, Buffer<byte> _1) => "Stub hit for Nn.Erpt.Sf.IContext.SubmitContext [0]".Debug();
		public virtual void CreateReport(object _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => "Stub hit for Nn.Erpt.Sf.IContext.CreateReport [1]".Debug();
		public virtual void Unknown2(object _0) => "Stub hit for Nn.Erpt.Sf.IContext.Unknown2 [2]".Debug();
		public virtual void Unknown3() => "Stub hit for Nn.Erpt.Sf.IContext.Unknown3 [3]".Debug();
		public virtual void Unknown4() => "Stub hit for Nn.Erpt.Sf.IContext.Unknown4 [4]".Debug();
		public virtual void Unknown5() => "Stub hit for Nn.Erpt.Sf.IContext.Unknown5 [5]".Debug();
		public virtual object Unknown6(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("erpt:r")]
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenReport
					var ret = OpenReport();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // OpenManager
					var ret = OpenManager();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
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
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetReportList
					GetReportList(null, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetEvent
					var ret = GetEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual void GetReportList(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject GetEvent() => throw new NotImplementedException();
		public virtual void Unknown2() => "Stub hit for Nn.Erpt.Sf.IManager.Unknown2 [2]".Debug();
		public virtual object Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IReport : _Base_IReport {}
	public unsafe class _Base_IReport : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Open
					Open(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Read
					Read(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // SetFlags
					SetFlags(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetFlags
					var ret = GetFlags();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // _Close
					_Close();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetSize
					var ret = GetSize();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IReport: {im.CommandId}");
			}
		}
		
		public virtual void Open(object _0) => "Stub hit for Nn.Erpt.Sf.IReport.Open [0]".Debug();
		public virtual void Read(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetFlags(object _0) => "Stub hit for Nn.Erpt.Sf.IReport.SetFlags [2]".Debug();
		public virtual object GetFlags() => throw new NotImplementedException();
		public virtual void _Close() => "Stub hit for Nn.Erpt.Sf.IReport._Close [4]".Debug();
		public virtual object GetSize() => throw new NotImplementedException();
	}
}
