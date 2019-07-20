#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Socket.Resolver {
	[IpcService("sfdnsres")]
	public unsafe partial class IResolver : _Base_IResolver {}
	public unsafe class _Base_IResolver : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetDnsAddressesPrivate
					SetDnsAddressesPrivate(im.GetData<uint>(0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // GetDnsAddressPrivate
					GetDnsAddressPrivate(im.GetData<uint>(0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // GetHostByName
					GetHostByName(im.GetData<byte>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 3: { // GetHostByAddr
					GetHostByAddr(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 4: { // GetHostStringError
					GetHostStringError(im.GetData<uint>(0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 5: { // GetGaiStringError
					GetGaiStringError(im.GetData<uint>(0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 6: { // GetAddrInfo
					GetAddrInfo(im.GetData<byte>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1), im.GetBuffer<byte>(0x5, 2), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 7: { // GetNameInfo
					GetNameInfo(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1, im.GetBuffer<byte>(0x6, 0), im.GetBuffer<byte>(0x6, 1));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 8: { // RequestCancelHandle
					var ret = RequestCancelHandle(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 9: { // CancelSocketCall
					CancelSocketCall(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 10: { // Unknown10
					var ret = Unknown10(null);
					break;
				}
				case 11: { // ClearDnsIpServerAddressArray
					var ret = ClearDnsIpServerAddressArray(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IResolver: {im.CommandId}");
			}
		}
		
		public virtual void SetDnsAddressesPrivate(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetDnsAddressPrivate(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetHostByName(byte _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, out uint _5, out uint _6, out uint _7, Buffer<byte> _8) => throw new NotImplementedException();
		public virtual void GetHostByAddr(uint _0, uint _1, uint _2, ulong _3, ulong _4, Buffer<byte> _5, out uint _6, out uint _7, out uint _8, Buffer<byte> _9) => throw new NotImplementedException();
		public virtual void GetHostStringError(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetGaiStringError(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetAddrInfo(byte _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, Buffer<byte> _5, Buffer<byte> _6, out uint _7, out uint _8, out uint _9, Buffer<byte> _10) => throw new NotImplementedException();
		public virtual void GetNameInfo(uint _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, out uint _5, out uint _6, Buffer<byte> _7, Buffer<byte> _8) => throw new NotImplementedException();
		public virtual uint RequestCancelHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void CancelSocketCall(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual object Unknown10(object _0) => throw new NotImplementedException();
		public virtual object ClearDnsIpServerAddressArray(object _0) => throw new NotImplementedException();
	}
}
