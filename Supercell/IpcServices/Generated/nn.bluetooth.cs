#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bluetooth {
	[IpcService("btdrv")]
	public unsafe partial class IBluetoothDriver : _Base_IBluetoothDriver {}
	public unsafe class _Base_IBluetoothDriver : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Init
					var ret = Init();
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // Enable
					Enable();
					break;
				}
				case 3: { // Disable
					Disable();
					break;
				}
				case 4: { // CleanupAndShutdown
					CleanupAndShutdown();
					break;
				}
				case 5: { // GetAdapterProperties
					GetAdapterProperties(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 6: { // GetAdapterProperty
					GetAdapterProperty(null, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 7: { // SetAdapterProperty
					SetAdapterProperty(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 8: { // StartDiscovery
					StartDiscovery();
					break;
				}
				case 9: { // CancelDiscovery
					CancelDiscovery();
					break;
				}
				case 10: { // CreateBond
					CreateBond(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 11: { // RemoveBond
					RemoveBond(null);
					break;
				}
				case 12: { // CancelBond
					CancelBond(null);
					break;
				}
				case 13: { // PinReply
					PinReply(null);
					break;
				}
				case 14: { // SspReply
					SspReply(null);
					break;
				}
				case 15: { // Unknown15
					Unknown15(out var _0, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 16: { // InitInterfaces
					var ret = InitInterfaces(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 17: { // HidHostInterfaceConnect
					HidHostInterfaceConnect(null);
					break;
				}
				case 18: { // HidHostInterfaceDisconnect
					HidHostInterfaceDisconnect(null);
					break;
				}
				case 19: { // HidHostInterfaceSendData
					HidHostInterfaceSendData(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 20: { // HidHostInterfaceSendData2
					HidHostInterfaceSendData2(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 21: { // HidHostInterfaceSetReport
					HidHostInterfaceSetReport(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 22: { // HidHostInterfaceGetReport
					HidHostInterfaceGetReport(null);
					break;
				}
				case 23: { // HidHostInterfaceWakeController
					HidHostInterfaceWakeController(null);
					break;
				}
				case 24: { // HidHostInterfaceAddPairedDevice
					HidHostInterfaceAddPairedDevice(im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 25: { // HidHostInterfaceGetPairedDevice
					HidHostInterfaceGetPairedDevice(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 26: { // HidHostInterfaceCleanupAndShutdown
					HidHostInterfaceCleanupAndShutdown();
					break;
				}
				case 27: { // Unknown27
					Unknown27(out var _0, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 28: { // ExtInterfaceSetTSI
					ExtInterfaceSetTSI(null);
					break;
				}
				case 29: { // ExtInterfaceSetBurstMode
					ExtInterfaceSetBurstMode(null);
					break;
				}
				case 30: { // ExtInterfaceSetZeroRetran
					ExtInterfaceSetZeroRetran(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 31: { // ExtInterfaceSetMcMode
					ExtInterfaceSetMcMode(null);
					break;
				}
				case 32: { // ExtInterfaceStartLlrMode
					ExtInterfaceStartLlrMode();
					break;
				}
				case 33: { // ExtInterfaceExitLlrMode
					ExtInterfaceExitLlrMode();
					break;
				}
				case 34: { // ExtInterfaceSetRadio
					ExtInterfaceSetRadio(null);
					break;
				}
				case 35: { // ExtInterfaceSetVisibility
					ExtInterfaceSetVisibility(null);
					break;
				}
				case 36: { // Unknown36
					Unknown36(null);
					break;
				}
				case 37: { // Unknown37
					var ret = Unknown37();
					om.Copy(0, ret.Handle);
					break;
				}
				case 38: { // HidHostInterfaceGetLatestPlr
					HidHostInterfaceGetLatestPlr(out var _0, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 39: { // ExtInterfaceGetPendingConnections
					ExtInterfaceGetPendingConnections(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 40: { // HidHostInterfaceGetChannelMap
					HidHostInterfaceGetChannelMap();
					break;
				}
				case 41: { // SetIsBluetoothBoostEnabled
					SetIsBluetoothBoostEnabled(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 42: { // GetIsBluetoothBoostEnabled
					GetIsBluetoothBoostEnabled(null);
					break;
				}
				case 43: { // SetIsBluetoothAfhEnabled
					var ret = SetIsBluetoothAfhEnabled();
					break;
				}
				case 44: { // GetIsBluetoothAfhEnabled
					GetIsBluetoothAfhEnabled(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBluetoothDriver: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual KObject Init() => throw new NotImplementedException();
		public virtual void Enable() => throw new NotImplementedException();
		public virtual void Disable() => throw new NotImplementedException();
		public virtual void CleanupAndShutdown() => throw new NotImplementedException();
		public virtual void GetAdapterProperties(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetAdapterProperty(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAdapterProperty(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void StartDiscovery() => throw new NotImplementedException();
		public virtual void CancelDiscovery() => throw new NotImplementedException();
		public virtual void CreateBond(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RemoveBond(object _0) => throw new NotImplementedException();
		public virtual void CancelBond(object _0) => throw new NotImplementedException();
		public virtual void PinReply(object _0) => throw new NotImplementedException();
		public virtual void SspReply(object _0) => throw new NotImplementedException();
		public virtual void Unknown15(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject InitInterfaces(object _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceConnect(object _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceDisconnect(object _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceSendData(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void HidHostInterfaceSendData2(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void HidHostInterfaceSetReport(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void HidHostInterfaceGetReport(object _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceWakeController(object _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceAddPairedDevice(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceGetPairedDevice(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void HidHostInterfaceCleanupAndShutdown() => throw new NotImplementedException();
		public virtual void Unknown27(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExtInterfaceSetTSI(object _0) => throw new NotImplementedException();
		public virtual void ExtInterfaceSetBurstMode(object _0) => throw new NotImplementedException();
		public virtual void ExtInterfaceSetZeroRetran(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExtInterfaceSetMcMode(object _0) => throw new NotImplementedException();
		public virtual void ExtInterfaceStartLlrMode() => throw new NotImplementedException();
		public virtual void ExtInterfaceExitLlrMode() => throw new NotImplementedException();
		public virtual void ExtInterfaceSetRadio(object _0) => throw new NotImplementedException();
		public virtual void ExtInterfaceSetVisibility(object _0) => throw new NotImplementedException();
		public virtual void Unknown36(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown37() => throw new NotImplementedException();
		public virtual void HidHostInterfaceGetLatestPlr(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExtInterfaceGetPendingConnections(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceGetChannelMap() => throw new NotImplementedException();
		public virtual void SetIsBluetoothBoostEnabled(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetIsBluetoothBoostEnabled(object _0) => throw new NotImplementedException();
		public virtual object SetIsBluetoothAfhEnabled() => throw new NotImplementedException();
		public virtual void GetIsBluetoothAfhEnabled(object _0) => throw new NotImplementedException();
	}
}
