#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Lm {
	[IpcService("lm:get")]
	public unsafe partial class ILogGetter : _Base_ILogGetter {}
	public unsafe class _Base_ILogGetter : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // StartLogging
					var ret = StartLogging(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // StopLogging
					var ret = StopLogging(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetLog
					var ret = GetLog(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILogGetter: {im.CommandId}");
			}
		}
		
		public virtual object StartLogging(object _0) => throw new NotImplementedException();
		public virtual object StopLogging(object _0) => throw new NotImplementedException();
		public virtual object GetLog(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("lm")]
	public unsafe partial class ILogService : _Base_ILogService {}
	public unsafe class _Base_ILogService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetData<ulong>(8), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILogService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Lm.ILogger Initialize(ulong _0, ulong _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ILogger : _Base_ILogger {}
	public unsafe class _Base_ILogger : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					Initialize(im.GetBuffer<byte>(0x21, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // SetDestination
					SetDestination(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILogger: {im.CommandId}");
			}
		}
		
		public virtual void Initialize(Buffer<byte> _0) => "Stub hit for Nn.Lm.ILogger.Initialize [0]".Debug();
		public virtual void SetDestination(uint _0) => "Stub hit for Nn.Lm.ILogger.SetDestination [1]".Debug();
	}
}
