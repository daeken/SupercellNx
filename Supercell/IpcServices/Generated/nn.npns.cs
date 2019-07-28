#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Npns {
	[IpcService("npns:s")]
	public unsafe partial class INpnsSystem : _Base_INpnsSystem {}
	public unsafe class _Base_INpnsSystem : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 6: { // Unknown6
					Unknown6();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 11: { // Unknown11
					Unknown11(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // Unknown12
					Unknown12(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // Unknown13
					var ret = Unknown13(im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // Unknown22
					var ret = Unknown22(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // Unknown23
					Unknown23(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // Unknown31
					Unknown31(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // Unknown32
					Unknown32(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // Unknown101
					Unknown101();
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // Unknown102
					Unknown102();
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // Unknown103
					var ret = Unknown103();
					om.Initialize(0, 0, 0);
					break;
				}
				case 104: { // Unknown104
					Unknown104(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 105: { // Unknown105
					var ret = Unknown105();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 111: { // Unknown111
					Unknown111(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 112: { // Unknown112
					Unknown112();
					om.Initialize(0, 0, 0);
					break;
				}
				case 113: { // Unknown113
					Unknown113();
					om.Initialize(0, 0, 0);
					break;
				}
				case 114: { // Unknown114
					Unknown114(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 115: { // Unknown115
					Unknown115(im.GetBuffer<byte>(0xA, 0), im.GetBuffer<byte>(0xA, 1));
					om.Initialize(0, 0, 0);
					break;
				}
				case 201: { // Unknown201
					Unknown201(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 202: { // Unknown202
					Unknown202(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INpnsSystem: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1() => "Stub hit for Nn.Npns.INpnsSystem.Unknown1 [1]".Debug();
		public virtual void Unknown2(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown2 [2]".Debug();
		public virtual void Unknown3(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown4(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject Unknown5() => throw new NotImplementedException();
		public virtual void Unknown6() => "Stub hit for Nn.Npns.INpnsSystem.Unknown6 [6]".Debug();
		public virtual KObject Unknown7() => throw new NotImplementedException();
		public virtual void Unknown11(Buffer<byte> _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown11 [11]".Debug();
		public virtual void Unknown12(Buffer<byte> _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown12 [12]".Debug();
		public virtual object Unknown13(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown21(object _0) => throw new NotImplementedException();
		public virtual object Unknown22(object _0) => throw new NotImplementedException();
		public virtual void Unknown23(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown23 [23]".Debug();
		public virtual void Unknown24(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown24 [24]".Debug();
		public virtual object Unknown25(object _0) => throw new NotImplementedException();
		public virtual void Unknown31(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown31 [31]".Debug();
		public virtual void Unknown32(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown32 [32]".Debug();
		public virtual void Unknown101() => "Stub hit for Nn.Npns.INpnsSystem.Unknown101 [101]".Debug();
		public virtual void Unknown102() => "Stub hit for Nn.Npns.INpnsSystem.Unknown102 [102]".Debug();
		public virtual object Unknown103() => throw new NotImplementedException();
		public virtual void Unknown104(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject Unknown105() => throw new NotImplementedException();
		public virtual void Unknown111(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown112() => "Stub hit for Nn.Npns.INpnsSystem.Unknown112 [112]".Debug();
		public virtual void Unknown113() => "Stub hit for Nn.Npns.INpnsSystem.Unknown113 [113]".Debug();
		public virtual void Unknown114(Buffer<byte> _0, Buffer<byte> _1) => "Stub hit for Nn.Npns.INpnsSystem.Unknown114 [114]".Debug();
		public virtual void Unknown115(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown201(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown201 [201]".Debug();
		public virtual void Unknown202(object _0) => "Stub hit for Nn.Npns.INpnsSystem.Unknown202 [202]".Debug();
	}
	
	[IpcService("npns:u")]
	public unsafe partial class INpnsUser : _Base_INpnsUser {}
	public unsafe class _Base_INpnsUser : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // Unknown23
					Unknown23(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // Unknown101
					Unknown101();
					om.Initialize(0, 0, 0);
					break;
				}
				case 102: { // Unknown102
					Unknown102();
					om.Initialize(0, 0, 0);
					break;
				}
				case 103: { // Unknown103
					var ret = Unknown103();
					om.Initialize(0, 0, 0);
					break;
				}
				case 104: { // Unknown104
					Unknown104(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 111: { // Unknown111
					Unknown111(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INpnsUser: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1() => "Stub hit for Nn.Npns.INpnsUser.Unknown1 [1]".Debug();
		public virtual void Unknown2(object _0) => "Stub hit for Nn.Npns.INpnsUser.Unknown2 [2]".Debug();
		public virtual void Unknown3(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown4(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject Unknown5() => throw new NotImplementedException();
		public virtual KObject Unknown7() => throw new NotImplementedException();
		public virtual object Unknown21(object _0) => throw new NotImplementedException();
		public virtual void Unknown23(object _0) => "Stub hit for Nn.Npns.INpnsUser.Unknown23 [23]".Debug();
		public virtual object Unknown25(object _0) => throw new NotImplementedException();
		public virtual void Unknown101() => "Stub hit for Nn.Npns.INpnsUser.Unknown101 [101]".Debug();
		public virtual void Unknown102() => "Stub hit for Nn.Npns.INpnsUser.Unknown102 [102]".Debug();
		public virtual object Unknown103() => throw new NotImplementedException();
		public virtual void Unknown104(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown111(Buffer<byte> _0) => throw new NotImplementedException();
	}
}
