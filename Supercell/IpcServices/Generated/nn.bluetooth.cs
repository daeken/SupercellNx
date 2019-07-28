#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Bluetooth {
	[IpcService("btdrv")]
	public unsafe partial class IBluetoothDriver : _Base_IBluetoothDriver {}
	public unsafe class _Base_IBluetoothDriver : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Init
					var ret = Init();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 2: { // Enable
					Enable();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Disable
					Disable();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // CleanupAndShutdown
					CleanupAndShutdown();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetAdapterProperties
					GetAdapterProperties(im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // GetAdapterProperty
					GetAdapterProperty(null, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // SetAdapterProperty
					SetAdapterProperty(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // StartDiscovery
					StartDiscovery();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // CancelDiscovery
					CancelDiscovery();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // CreateBond
					CreateBond(null, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // RemoveBond
					RemoveBond(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // CancelBond
					CancelBond(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // PinReply
					PinReply(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // SspReply
					SspReply(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // Unknown15
					Unknown15(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // InitInterfaces
					var ret = InitInterfaces(null);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 17: { // HidHostInterfaceConnect
					HidHostInterfaceConnect(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // HidHostInterfaceDisconnect
					HidHostInterfaceDisconnect(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // HidHostInterfaceSendData
					HidHostInterfaceSendData(null, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // HidHostInterfaceSendData2
					HidHostInterfaceSendData2(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // HidHostInterfaceSetReport
					HidHostInterfaceSetReport(null, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // HidHostInterfaceGetReport
					HidHostInterfaceGetReport(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // HidHostInterfaceWakeController
					HidHostInterfaceWakeController(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // HidHostInterfaceAddPairedDevice
					HidHostInterfaceAddPairedDevice(im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // HidHostInterfaceGetPairedDevice
					HidHostInterfaceGetPairedDevice(null, im.GetBuffer<byte>(0x1A, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // HidHostInterfaceCleanupAndShutdown
					HidHostInterfaceCleanupAndShutdown();
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // Unknown27
					Unknown27(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 28: { // ExtInterfaceSetTSI
					ExtInterfaceSetTSI(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 29: { // ExtInterfaceSetBurstMode
					ExtInterfaceSetBurstMode(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // ExtInterfaceSetZeroRetran
					ExtInterfaceSetZeroRetran(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // ExtInterfaceSetMcMode
					ExtInterfaceSetMcMode(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // ExtInterfaceStartLlrMode
					ExtInterfaceStartLlrMode();
					om.Initialize(0, 0, 0);
					break;
				}
				case 33: { // ExtInterfaceExitLlrMode
					ExtInterfaceExitLlrMode();
					om.Initialize(0, 0, 0);
					break;
				}
				case 34: { // ExtInterfaceSetRadio
					ExtInterfaceSetRadio(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 35: { // ExtInterfaceSetVisibility
					ExtInterfaceSetVisibility(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 36: { // Unknown36
					Unknown36(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 37: { // Unknown37
					var ret = Unknown37();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 38: { // HidHostInterfaceGetLatestPlr
					HidHostInterfaceGetLatestPlr(out var _0, im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 39: { // ExtInterfaceGetPendingConnections
					ExtInterfaceGetPendingConnections(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // HidHostInterfaceGetChannelMap
					HidHostInterfaceGetChannelMap();
					om.Initialize(0, 0, 0);
					break;
				}
				case 41: { // SetIsBluetoothBoostEnabled
					SetIsBluetoothBoostEnabled(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 42: { // GetIsBluetoothBoostEnabled
					GetIsBluetoothBoostEnabled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 43: { // SetIsBluetoothAfhEnabled
					var ret = SetIsBluetoothAfhEnabled();
					om.Initialize(0, 0, 0);
					break;
				}
				case 44: { // GetIsBluetoothAfhEnabled
					GetIsBluetoothAfhEnabled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBluetoothDriver: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.Unknown0 [0]".Debug();
		public virtual KObject Init() => throw new NotImplementedException();
		public virtual void Enable() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.Enable [2]".Debug();
		public virtual void Disable() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.Disable [3]".Debug();
		public virtual void CleanupAndShutdown() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.CleanupAndShutdown [4]".Debug();
		public virtual void GetAdapterProperties(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetAdapterProperty(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetAdapterProperty(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.SetAdapterProperty [7]".Debug();
		public virtual void StartDiscovery() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.StartDiscovery [8]".Debug();
		public virtual void CancelDiscovery() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.CancelDiscovery [9]".Debug();
		public virtual void CreateBond(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.CreateBond [10]".Debug();
		public virtual void RemoveBond(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.RemoveBond [11]".Debug();
		public virtual void CancelBond(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.CancelBond [12]".Debug();
		public virtual void PinReply(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.PinReply [13]".Debug();
		public virtual void SspReply(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.SspReply [14]".Debug();
		public virtual void Unknown15(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual KObject InitInterfaces(object _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceConnect(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceConnect [17]".Debug();
		public virtual void HidHostInterfaceDisconnect(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceDisconnect [18]".Debug();
		public virtual void HidHostInterfaceSendData(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceSendData [19]".Debug();
		public virtual void HidHostInterfaceSendData2(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceSendData2 [20]".Debug();
		public virtual void HidHostInterfaceSetReport(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceSetReport [21]".Debug();
		public virtual void HidHostInterfaceGetReport(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceGetReport [22]".Debug();
		public virtual void HidHostInterfaceWakeController(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceWakeController [23]".Debug();
		public virtual void HidHostInterfaceAddPairedDevice(Buffer<byte> _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceAddPairedDevice [24]".Debug();
		public virtual void HidHostInterfaceGetPairedDevice(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void HidHostInterfaceCleanupAndShutdown() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceCleanupAndShutdown [26]".Debug();
		public virtual void Unknown27(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExtInterfaceSetTSI(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceSetTSI [28]".Debug();
		public virtual void ExtInterfaceSetBurstMode(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceSetBurstMode [29]".Debug();
		public virtual void ExtInterfaceSetZeroRetran(object _0, Buffer<byte> _1) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceSetZeroRetran [30]".Debug();
		public virtual void ExtInterfaceSetMcMode(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceSetMcMode [31]".Debug();
		public virtual void ExtInterfaceStartLlrMode() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceStartLlrMode [32]".Debug();
		public virtual void ExtInterfaceExitLlrMode() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceExitLlrMode [33]".Debug();
		public virtual void ExtInterfaceSetRadio(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceSetRadio [34]".Debug();
		public virtual void ExtInterfaceSetVisibility(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.ExtInterfaceSetVisibility [35]".Debug();
		public virtual void Unknown36(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.Unknown36 [36]".Debug();
		public virtual KObject Unknown37() => throw new NotImplementedException();
		public virtual void HidHostInterfaceGetLatestPlr(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ExtInterfaceGetPendingConnections(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void HidHostInterfaceGetChannelMap() => "Stub hit for Nn.Bluetooth.IBluetoothDriver.HidHostInterfaceGetChannelMap [40]".Debug();
		public virtual void SetIsBluetoothBoostEnabled(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void GetIsBluetoothBoostEnabled(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.GetIsBluetoothBoostEnabled [42]".Debug();
		public virtual object SetIsBluetoothAfhEnabled() => throw new NotImplementedException();
		public virtual void GetIsBluetoothAfhEnabled(object _0) => "Stub hit for Nn.Bluetooth.IBluetoothDriver.GetIsBluetoothAfhEnabled [44]".Debug();
	}
}
