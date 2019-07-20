#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ldr.Detail {
	[IpcService("ldr:dmnt")]
	public unsafe partial class IDebugMonitorInterface : _Base_IDebugMonitorInterface {}
	public unsafe class _Base_IDebugMonitorInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // AddProcessToDebugLaunchQueue
					AddProcessToDebugLaunchQueue(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 1: { // ClearDebugLaunchQueue
					ClearDebugLaunchQueue();
					break;
				}
				case 2: { // GetNsoInfos
					GetNsoInfos(null, out var _0, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDebugMonitorInterface: {im.CommandId}");
			}
		}
		
		public virtual void AddProcessToDebugLaunchQueue(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ClearDebugLaunchQueue() => throw new NotImplementedException();
		public virtual void GetNsoInfos(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("ldr:pm")]
	public unsafe partial class IProcessManagerInterface : _Base_IProcessManagerInterface {}
	public unsafe class _Base_IProcessManagerInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateProcess
					var ret = CreateProcess(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetProgramInfo
					GetProgramInfo(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 2: { // RegisterTitle
					var ret = RegisterTitle(null);
					break;
				}
				case 3: { // UnregisterTitle
					UnregisterTitle(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IProcessManagerInterface: {im.CommandId}");
			}
		}
		
		public virtual IpcInterface CreateProcess(object _0, KObject _1) => throw new NotImplementedException();
		public virtual void GetProgramInfo(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object RegisterTitle(object _0) => throw new NotImplementedException();
		public virtual void UnregisterTitle(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("ldr:ro")]
	public unsafe partial class IRoInterface : _Base_IRoInterface {}
	public unsafe class _Base_IRoInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // LoadNro
					var ret = LoadNro(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.GetData<ulong>(24), im.GetData<ulong>(32), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 1: { // UnloadNro
					UnloadNro(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 2: { // LoadNrr
					LoadNrr(im.GetData<ulong>(0), im.GetData<ulong>(8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 3: { // UnloadNrr
					UnloadNrr(im.GetData<ulong>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 4: { // Initialize
					Initialize(im.GetData<ulong>(0), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRoInterface: {im.CommandId}");
			}
		}
		
		public virtual ulong LoadNro(ulong _0, ulong _1, ulong _2, ulong _3, ulong _4, ulong _5) => throw new NotImplementedException();
		public virtual void UnloadNro(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void LoadNrr(ulong _0, ulong _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void UnloadNrr(ulong _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void Initialize(ulong _0, ulong _1, KObject _2) => throw new NotImplementedException();
	}
	
	[IpcService("ldr:shel")]
	public unsafe partial class IShellInterface : _Base_IShellInterface {}
	public unsafe class _Base_IShellInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // AddProcessToLaunchQueue
					AddProcessToLaunchQueue(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 1: { // ClearLaunchQueue
					ClearLaunchQueue();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IShellInterface: {im.CommandId}");
			}
		}
		
		public virtual void AddProcessToLaunchQueue(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ClearLaunchQueue() => throw new NotImplementedException();
	}
}
