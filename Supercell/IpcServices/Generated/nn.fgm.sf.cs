#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Fgm.Sf {
	[IpcService("fgm:dbg")]
	public unsafe partial class IDebugger : _Base_IDebugger {}
	public unsafe class _Base_IDebugger : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetData<ulong>(0), Kernel.Get<KObject>(im.GetCopy(0)));
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Read
					Read(out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 2: { // Cancel
					Cancel();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugger: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(ulong _0, KObject _1) => throw new NotImplementedException();
		public virtual void Read(out uint _0, out uint _1, out uint _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
	}
	
	[IpcService("fgm")]
	[IpcService("fgm:0")]
	[IpcService("fgm:9")]
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize();
					om.Move(0, ret.Handle);
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Set
					Set(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 2: { // Get
					var ret = Get();
					om.SetData(0, ret);
					break;
				}
				case 3: { // Cancel
					Cancel();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequest: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void Set(uint _0, uint _1) => throw new NotImplementedException();
		public virtual uint Get() => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
	}
}
