#pragma warning disable 169, 465
using System;
using UltimateOrb;
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
	
	[IpcService("nvdrv:s")]
	[IpcService("nvdrv:t")]
	[IpcService("nvdrv:a")]
	[IpcService("nvdrv")]
	public unsafe partial class INvDrvServices : _Base_INvDrvServices {}
	public unsafe class _Base_INvDrvServices : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Open
					Open(im.GetBuffer<byte>(0x5, 0), out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 1: { // Ioctl
					Ioctl(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x21, 0), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 2: { // _Close
					var ret = _Close(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 3: { // Initialize
					var ret = Initialize(im.GetData<uint>(0), Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)));
					om.SetData(0, ret);
					break;
				}
				case 4: { // QueryEvent
					QueryEvent(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1);
					om.SetData(0, _0);
					om.Copy(0, _1.Handle);
					break;
				}
				case 5: { // MapSharedMem
					var ret = MapSharedMem(im.GetData<uint>(0), im.GetData<uint>(4), Kernel.Get<KObject>(im.GetCopy(0)));
					om.SetData(0, ret);
					break;
				}
				case 6: { // GetStatus
					var ret = GetStatus();
					break;
				}
				case 7: { // ForceSetClientPID
					var ret = ForceSetClientPID(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 8: { // SetClientPID
					var ret = SetClientPID(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 9: { // DumpGraphicsMemoryInfo
					DumpGraphicsMemoryInfo();
					break;
				}
				case 10: { // Unknown10
					var ret = Unknown10(im.GetData<uint>(0), Kernel.Get<KObject>(im.GetCopy(0)));
					om.SetData(0, ret);
					break;
				}
				case 11: { // Ioctl2
					Ioctl2(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x21, 0), im.GetBuffer<byte>(0x21, 1), out var _0, im.GetBuffer<byte>(0x22, 0));
					om.SetData(0, _0);
					break;
				}
				case 12: { // Ioctl3
					Ioctl3(im.GetData<uint>(0), im.GetData<uint>(4), im.GetBuffer<byte>(0x21, 0), out var _0, im.GetBuffer<byte>(0x22, 0), im.GetBuffer<byte>(0x22, 1));
					om.SetData(0, _0);
					break;
				}
				case 13: { // Unknown13
					Unknown13(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INvDrvServices: {im.CommandId}");
			}
		}
		
		public virtual void Open(Buffer<byte> path, out uint fd, out uint error_code) => throw new NotImplementedException();
		public virtual void Ioctl(uint fd, uint rq_id, Buffer<byte> _2, out uint error_code, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual uint _Close(uint fd) => throw new NotImplementedException();
		public virtual uint Initialize(uint transfer_memory_size, KObject current_process, KObject transfer_memory) => throw new NotImplementedException();
		public virtual void QueryEvent(uint fd, uint event_id, out uint _2, out KObject _3) => throw new NotImplementedException();
		public virtual uint MapSharedMem(uint fd, uint nvmap_handle, KObject _2) => throw new NotImplementedException();
		public virtual object GetStatus() => throw new NotImplementedException();
		public virtual uint ForceSetClientPID(ulong pid) => throw new NotImplementedException();
		public virtual uint SetClientPID(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DumpGraphicsMemoryInfo() => throw new NotImplementedException();
		public virtual uint Unknown10(uint _0, KObject _1) => throw new NotImplementedException();
		public virtual void Ioctl2(uint _0, uint _1, Buffer<byte> _2, Buffer<byte> _3, out uint _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void Ioctl3(uint _0, uint _1, Buffer<byte> _2, out uint _3, Buffer<byte> _4, Buffer<byte> _5) => throw new NotImplementedException();
		public virtual void Unknown13(object _0) => throw new NotImplementedException();
	}
}
