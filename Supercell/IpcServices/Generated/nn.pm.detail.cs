#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pm.Detail {
	[IpcService("pm:bm")]
	public unsafe partial class IBootModeInterface : _Base_IBootModeInterface {}
	public unsafe class _Base_IBootModeInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetBootMode
					var ret = GetBootMode();
					break;
				}
				case 1: { // SetMaintenanceBoot
					SetMaintenanceBoot();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBootModeInterface: {im.CommandId}");
			}
		}
		
		public virtual object GetBootMode() => throw new NotImplementedException();
		public virtual void SetMaintenanceBoot() => throw new NotImplementedException();
	}
	
	[IpcService("pm:dmnt")]
	public unsafe partial class IDebugMonitorInterface : _Base_IDebugMonitorInterface {}
	public unsafe class _Base_IDebugMonitorInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetDebugProcesses
					GetDebugProcesses(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1: { // StartDebugProcess
					StartDebugProcess(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // GetTitlePid
					GetTitlePid(null);
					break;
				}
				case 3: { // EnableDebugForTitleId
					var ret = EnableDebugForTitleId(null);
					break;
				}
				case 4: { // GetApplicationPid
					var ret = GetApplicationPid(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 5: { // EnableDebugForApplication
					var ret = EnableDebugForApplication();
					break;
				}
				case 6: { // DisableDebug
					var ret = DisableDebug();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugMonitorInterface: {im.CommandId}");
			}
		}
		
		public virtual void GetDebugProcesses(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void StartDebugProcess(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetTitlePid(object _0) => throw new NotImplementedException();
		public virtual object EnableDebugForTitleId(object _0) => throw new NotImplementedException();
		public virtual KObject GetApplicationPid(object _0) => throw new NotImplementedException();
		public virtual object EnableDebugForApplication() => throw new NotImplementedException();
		public virtual KObject DisableDebug() => throw new NotImplementedException();
	}
	
	[IpcService("pm:info")]
	public unsafe partial class IInformationInterface : _Base_IInformationInterface {}
	public unsafe class _Base_IInformationInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetTitleId
					var ret = GetTitleId(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IInformationInterface: {im.CommandId}");
			}
		}
		
		public virtual object GetTitleId(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("pm:shell")]
	public unsafe partial class IShellInterface : _Base_IShellInterface {}
	public unsafe class _Base_IShellInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // LaunchProcess
					var ret = LaunchProcess(null);
					break;
				}
				case 1: { // TerminateProcessByPid
					TerminateProcessByPid(null);
					break;
				}
				case 2: { // TerminateProcessByTitleId
					TerminateProcessByTitleId(null);
					break;
				}
				case 3: { // GetProcessEventWaiter
					var ret = GetProcessEventWaiter();
					om.Copy(0, ret.Handle);
					break;
				}
				case 4: { // GetProcessEventType
					var ret = GetProcessEventType();
					break;
				}
				case 5: { // NotifyBootFinished
					NotifyBootFinished(null);
					break;
				}
				case 6: { // GetApplicationPid
					GetApplicationPid(null);
					break;
				}
				case 7: { // BoostSystemMemoryResourceLimit
					BoostSystemMemoryResourceLimit();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IShellInterface: {im.CommandId}");
			}
		}
		
		public virtual object LaunchProcess(object _0) => throw new NotImplementedException();
		public virtual void TerminateProcessByPid(object _0) => throw new NotImplementedException();
		public virtual void TerminateProcessByTitleId(object _0) => throw new NotImplementedException();
		public virtual KObject GetProcessEventWaiter() => throw new NotImplementedException();
		public virtual object GetProcessEventType() => throw new NotImplementedException();
		public virtual void NotifyBootFinished(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationPid(object _0) => throw new NotImplementedException();
		public virtual void BoostSystemMemoryResourceLimit() => throw new NotImplementedException();
	}
}
