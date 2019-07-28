#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bsdsocket.Cfg {
	[IpcService("bsdcfg")]
	public unsafe partial class ServerInterface : _Base_ServerInterface {}
	public unsafe class _Base_ServerInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetIfUp
					SetIfUp(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // SetIfUpWithEvent
					var ret = SetIfUpWithEvent(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 2: { // CancelIf
					CancelIf(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // SetIfDown
					SetIfDown(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetIfState
					GetIfState(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // DhcpRenew
					DhcpRenew(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // AddStaticArpEntry
					AddStaticArpEntry(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // RemoveArpEntry
					RemoveArpEntry(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // LookupArpEntry
					LookupArpEntry(null, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // LookupArpEntry2
					LookupArpEntry2(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // ClearArpEntries
					ClearArpEntries();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // ClearArpEntries2
					ClearArpEntries2(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // PrintArpEntries
					PrintArpEntries();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ServerInterface: {im.CommandId}");
			}
		}
		
		public virtual void SetIfUp(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.SetIfUp [0]".Debug();
		public virtual KObject SetIfUpWithEvent(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void CancelIf(Buffer<byte> _0) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.CancelIf [2]".Debug();
		public virtual void SetIfDown(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.SetIfDown [3]".Debug();
		public virtual void GetIfState(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DhcpRenew(Buffer<byte> _0) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.DhcpRenew [5]".Debug();
		public virtual void AddStaticArpEntry(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.AddStaticArpEntry [6]".Debug();
		public virtual void RemoveArpEntry(object _0) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.RemoveArpEntry [7]".Debug();
		public virtual void LookupArpEntry(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void LookupArpEntry2(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ClearArpEntries() => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.ClearArpEntries [10]".Debug();
		public virtual void ClearArpEntries2(Buffer<byte> _0) => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.ClearArpEntries2 [11]".Debug();
		public virtual void PrintArpEntries() => "Stub hit for Nn.Bsdsocket.Cfg.ServerInterface.PrintArpEntries [12]".Debug();
	}
}
