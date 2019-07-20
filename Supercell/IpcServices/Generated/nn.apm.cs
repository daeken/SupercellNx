#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Apm {
	[IpcService("apm")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSession
					var ret = OpenSession();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetPerformanceMode
					var ret = GetPerformanceMode();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Apm.ISession OpenSession() => throw new NotImplementedException();
		public virtual uint GetPerformanceMode() => throw new NotImplementedException();
	}
	
	[IpcService("apm:p")]
	public unsafe partial class IManagerPrivileged : _Base_IManagerPrivileged {}
	public unsafe class _Base_IManagerPrivileged : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSession
					var ret = OpenSession();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManagerPrivileged: {im.CommandId}");
			}
		}
		
		public virtual Nn.Apm.ISession OpenSession() => throw new NotImplementedException();
	}
	
	[IpcService("apm:sys")]
	public unsafe partial class ISystemManager : _Base_ISystemManager {}
	public unsafe class _Base_ISystemManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RequestPerformanceMode
					RequestPerformanceMode(im.GetData<uint>(0));
					break;
				}
				case 1: { // GetPerformanceEvent
					var ret = GetPerformanceEvent(im.GetData<uint>(0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // GetThrottlingState
					GetThrottlingState(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 3: { // GetLastThrottlingState
					GetLastThrottlingState(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 4: { // ClearLastThrottlingState
					ClearLastThrottlingState();
					break;
				}
				case 5: { // LoadAndApplySettings
					var ret = LoadAndApplySettings(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemManager: {im.CommandId}");
			}
		}
		
		public virtual void RequestPerformanceMode(uint _0) => throw new NotImplementedException();
		public virtual KObject GetPerformanceEvent(uint _0) => throw new NotImplementedException();
		public virtual void GetThrottlingState(out byte[] _0) => throw new NotImplementedException();
		public virtual void GetLastThrottlingState(out byte[] _0) => throw new NotImplementedException();
		public virtual void ClearLastThrottlingState() => throw new NotImplementedException();
		public virtual object LoadAndApplySettings(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDebugManager : _Base_IDebugManager {}
	public unsafe class _Base_IDebugManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetThrottlingState
					var ret = GetThrottlingState();
					break;
				}
				case 1: { // GetLastThrottlingState
					var ret = GetLastThrottlingState();
					break;
				}
				case 2: { // ClearLastThrottlingState
					ClearLastThrottlingState();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugManager: {im.CommandId}");
			}
		}
		
		public virtual object GetThrottlingState() => throw new NotImplementedException();
		public virtual object GetLastThrottlingState() => throw new NotImplementedException();
		public virtual void ClearLastThrottlingState() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISession : _Base_ISession {}
	public unsafe class _Base_ISession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetPerformanceConfiguration
					SetPerformanceConfiguration(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 1: { // GetPerformanceConfiguration
					var ret = GetPerformanceConfiguration(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISession: {im.CommandId}");
			}
		}
		
		public virtual void SetPerformanceConfiguration(uint _0, uint _1) => throw new NotImplementedException();
		public virtual uint GetPerformanceConfiguration(uint _0) => throw new NotImplementedException();
	}
}
