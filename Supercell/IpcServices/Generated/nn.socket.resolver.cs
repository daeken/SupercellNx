#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Socket.Resolver {
	[IpcService("sfdnsres")]
	public unsafe partial class IResolver : _Base_IResolver {}
	public unsafe class _Base_IResolver : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetDnsAddressesPrivate
					SetDnsAddressesPrivate(im.GetData<uint>(8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetDnsAddressPrivate
					GetDnsAddressPrivate(im.GetData<uint>(8), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetHostByName
					GetHostByName(im.GetData<byte>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 3: { // GetHostByAddr
					GetHostByAddr(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<uint>(16), im.GetData<ulong>(24), im.Pid, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 4: { // GetHostStringError
					GetHostStringError(im.GetData<uint>(8), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetGaiStringError
					GetGaiStringError(im.GetData<uint>(8), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // GetAddrInfo
					GetAddrInfo(im.GetData<bool>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid, im.GetBuffer<sbyte>(0x5, 0), im.GetBuffer<sbyte>(0x5, 1), im.GetBuffer<byte>(0x5, 2), out var _0, out var _1, out var _2, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 12);
					om.SetData(8, _0);
					om.SetData(12, _1);
					om.SetData(16, _2);
					break;
				}
				case 7: { // GetNameInfo
					GetNameInfo(im.GetData<uint>(8), im.GetData<uint>(12), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x5, 0), out var _0, out var _1, im.GetBuffer<byte>(0x6, 0), im.GetBuffer<byte>(0x6, 1));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 8: { // RequestCancelHandle
					var ret = RequestCancelHandle(im.GetData<ulong>(8), im.Pid);
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 9: { // CancelSocketCall
					CancelSocketCall(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IResolver: {im.CommandId}");
			}
		}
		
		public virtual void SetDnsAddressesPrivate(uint _0, Buffer<byte> _1) => "Stub hit for Nn.Socket.Resolver.IResolver.SetDnsAddressesPrivate [0]".Debug();
		public virtual void GetDnsAddressPrivate(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetHostByName(byte _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, out uint _5, out uint _6, out uint _7, Buffer<byte> _8) => throw new NotImplementedException();
		public virtual void GetHostByAddr(uint _0, uint _1, uint _2, ulong _3, ulong _4, Buffer<byte> _5, out uint _6, out uint _7, out uint _8, Buffer<byte> _9) => throw new NotImplementedException();
		public virtual void GetHostStringError(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetGaiStringError(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetAddrInfo(bool enable_nsd_resolve, uint _1, ulong pid_placeholder, ulong _3, Buffer<sbyte> host, Buffer<sbyte> service, Buffer<byte> hints, out int ret, out uint bsd_errno, out uint packed_addrinfo_size, Buffer<byte> response) => throw new NotImplementedException();
		public virtual void GetNameInfo(uint _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, out uint _5, out uint _6, Buffer<byte> _7, Buffer<byte> _8) => throw new NotImplementedException();
		public virtual uint RequestCancelHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void CancelSocketCall(uint _0, ulong _1, ulong _2) => "Stub hit for Nn.Socket.Resolver.IResolver.CancelSocketCall [9]".Debug();
	}
}
