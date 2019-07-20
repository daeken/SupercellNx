#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nns.Nvdrv {
	[IpcService("nvdrvdbg")]
	public unsafe partial class INvDrvDebugFSServices : _Base_INvDrvDebugFSServices {}
	public unsafe class _Base_INvDrvDebugFSServices : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenLog
					var ret = OpenLog(Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 1: { // CloseLog
					CloseLog(null);
					break;
				}
				case 2: { // ReadLog
					ReadLog(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null, im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INvDrvDebugFSServices: {im.CommandId}");
			}
		}
		
		public virtual object OpenLog(KObject _0) => throw new NotImplementedException();
		public virtual void CloseLog(object _0) => throw new NotImplementedException();
		public virtual void ReadLog(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown3(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown4(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("nvdrv:a")]
	[IpcService("nvdrv:s")]
	[IpcService("nvdrv:t")]
	[IpcService("nvdrv")]
	public unsafe partial class INvDrvServices : _Base_INvDrvServices {}
	public unsafe class _Base_INvDrvServices : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Open
					var ret = Open(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // Ioctl
					Ioctl(null, im.GetBuffer<byte>(0x21, 0), out var _0, im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 2: { // _Close
					var ret = _Close(null);
					break;
				}
				case 3: { // Initialize
					var ret = Initialize(null, Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)));
					break;
				}
				case 4: { // QueryEvent
					QueryEvent(null, out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 5: { // MapSharedMem
					var ret = MapSharedMem(null, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 6: { // GetStatus
					var ret = GetStatus();
					break;
				}
				case 7: { // ForceSetClientPID
					var ret = ForceSetClientPID(null);
					break;
				}
				case 8: { // SetClientPID
					var ret = SetClientPID(null, im.Pid);
					break;
				}
				case 9: { // DumpGraphicsMemoryInfo
					DumpGraphicsMemoryInfo();
					break;
				}
				case 10: { // InitializeDevtools
					var ret = InitializeDevtools(null, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 11: { // Ioctl2
					Ioctl2(null, im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 12: { // Ioctl3
					Ioctl3(null, im.GetBuffer<byte>(0x21, 0), out var _0, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1));
					break;
				}
				case 13: { // FinishInitialize
					FinishInitialize(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INvDrvServices: {im.CommandId}");
			}
		}
		
		public virtual object Open(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Ioctl(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object _Close(object _0) => throw new NotImplementedException();
		public virtual object Initialize(object _0, KObject _1, KObject _2) => throw new NotImplementedException();
		public virtual void QueryEvent(object _0, out object _1, out KObject _2) => throw new NotImplementedException();
		public virtual object MapSharedMem(object _0, KObject _1) => throw new NotImplementedException();
		public virtual object GetStatus() => throw new NotImplementedException();
		public virtual object ForceSetClientPID(object _0) => throw new NotImplementedException();
		public virtual object SetClientPID(object _0, ulong _1) => throw new NotImplementedException();
		public virtual void DumpGraphicsMemoryInfo() => throw new NotImplementedException();
		public virtual object InitializeDevtools(object _0, KObject _1) => throw new NotImplementedException();
		public virtual void Ioctl2(object _0, Buffer<byte> _1, Buffer<byte> _2, out object _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void Ioctl3(object _0, Buffer<byte> _1, out object _2, Buffer<byte> _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void FinishInitialize(object _0) => throw new NotImplementedException();
	}
}
