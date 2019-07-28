#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Fgm.Sf {
	[IpcService("fgm:dbg")]
	public unsafe partial class IDebugger : _Base_IDebugger {}
	public unsafe class _Base_IDebugger : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetData<ulong>(8), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Read
					Read(out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 2: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugger: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(ulong _0, KObject _1) => throw new NotImplementedException();
		public virtual void Read(out uint _0, out uint _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Cancel() => "Stub hit for Nn.Fgm.Sf.IDebugger.Cancel [2]".Debug();
	}
	
	[IpcService("fgm")]
	[IpcService("fgm:0")]
	[IpcService("fgm:9")]
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISession: {im.CommandId}");
			}
		}
		
		public virtual Nn.Fgm.Sf.IRequest Initialize() => throw new NotImplementedException();
	}
	
	public unsafe partial class IRequest : _Base_IRequest {}
	public unsafe class _Base_IRequest : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Set
					Set(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Get
					var ret = Get();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 3: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequest: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void Set(uint _0, uint _1) => "Stub hit for Nn.Fgm.Sf.IRequest.Set [1]".Debug();
		public virtual uint Get() => throw new NotImplementedException();
		public virtual void Cancel() => "Stub hit for Nn.Fgm.Sf.IRequest.Cancel [3]".Debug();
	}
}
