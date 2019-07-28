#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Wlan.Detail {
	[IpcService("wlan:inf")]
	public unsafe partial class IInfraManager : _Base_IInfraManager {}
	public unsafe class _Base_IInfraManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetMacAddress
					var ret = GetMacAddress();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // StartScan
					StartScan(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // StopScan
					StopScan();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Connect
					Connect(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // CancelConnect
					CancelConnect();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // Disconnect
					Disconnect();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8(null);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 9: { // Unknown9
					var ret = Unknown9();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // GetScanResult
					GetScanResult(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // GetRssi
					var ret = GetRssi();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // ChangeRxAntenna
					ChangeRxAntenna(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // Unknown14
					Unknown14(im.GetBuffer<byte>(0xA, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // Unknown15
					Unknown15();
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // RequestWakeUp
					RequestWakeUp();
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // RequestIfUpDown
					RequestIfUpDown(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18();
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // Unknown19
					Unknown19(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // Unknown20
					Unknown20();
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21();
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // Unknown22
					Unknown22(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // Unknown23
					Unknown23(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // Unknown24
					var ret = Unknown24();
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // Unknown25
					Unknown25(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // Unknown26
					Unknown26();
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // Unknown27
					Unknown27();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IInfraManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown0 [0]".Debug();
		public virtual void Unknown1() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown1 [1]".Debug();
		public virtual object GetMacAddress() => throw new NotImplementedException();
		public virtual void StartScan(Buffer<byte> _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.StartScan [3]".Debug();
		public virtual void StopScan() => "Stub hit for Nn.Wlan.Detail.IInfraManager.StopScan [4]".Debug();
		public virtual void Connect(object _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.Connect [5]".Debug();
		public virtual void CancelConnect() => "Stub hit for Nn.Wlan.Detail.IInfraManager.CancelConnect [6]".Debug();
		public virtual void Disconnect() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Disconnect [7]".Debug();
		public virtual KObject Unknown8(object _0) => throw new NotImplementedException();
		public virtual object Unknown9() => throw new NotImplementedException();
		public virtual object GetState() => throw new NotImplementedException();
		public virtual void GetScanResult(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetRssi() => throw new NotImplementedException();
		public virtual void ChangeRxAntenna(object _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.ChangeRxAntenna [13]".Debug();
		public virtual void Unknown14(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown15() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown15 [15]".Debug();
		public virtual void RequestWakeUp() => "Stub hit for Nn.Wlan.Detail.IInfraManager.RequestWakeUp [16]".Debug();
		public virtual void RequestIfUpDown(object _0, Buffer<byte> _1) => "Stub hit for Nn.Wlan.Detail.IInfraManager.RequestIfUpDown [17]".Debug();
		public virtual object Unknown18() => throw new NotImplementedException();
		public virtual void Unknown19(object _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown19 [19]".Debug();
		public virtual void Unknown20() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown20 [20]".Debug();
		public virtual object Unknown21() => throw new NotImplementedException();
		public virtual void Unknown22(object _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown22 [22]".Debug();
		public virtual void Unknown23(object _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown23 [23]".Debug();
		public virtual object Unknown24() => throw new NotImplementedException();
		public virtual void Unknown25(object _0) => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown25 [25]".Debug();
		public virtual void Unknown26() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown26 [26]".Debug();
		public virtual void Unknown27() => "Stub hit for Nn.Wlan.Detail.IInfraManager.Unknown27 [27]".Debug();
	}
	
	[IpcService("wlan:lga")]
	public unsafe partial class ILocalGetActionFrame : _Base_ILocalGetActionFrame {}
	public unsafe class _Base_ILocalGetActionFrame : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILocalGetActionFrame: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("wlan:lg")]
	public unsafe partial class ILocalGetFrame : _Base_ILocalGetFrame {}
	public unsafe class _Base_ILocalGetFrame : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILocalGetFrame: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("wlan:lcl")]
	public unsafe partial class ILocalManager : _Base_ILocalManager {}
	public unsafe class _Base_ILocalManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // GetMacAddress
					var ret = GetMacAddress();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // CreateBss
					CreateBss(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // DestroyBss
					DestroyBss();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // StartScan
					StartScan(im.GetBuffer<byte>(0x15, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // StopScan
					StopScan();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Connect
					Connect(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // CancelConnect
					CancelConnect();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // Join
					Join(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // CancelJoin
					CancelJoin();
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // Disconnect
					Disconnect(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // SetBeaconLostCount
					SetBeaconLostCount(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 17: { // Unknown17
					var ret = Unknown17(null);
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18();
					om.Initialize(0, 0, 0);
					break;
				}
				case 19: { // Unknown19
					Unknown19(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // GetBssIndicationEvent
					var ret = GetBssIndicationEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 21: { // GetBssIndicationInfo
					GetBssIndicationInfo(im.GetBuffer<byte>(0x16, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 22: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // GetAllowedChannels
					var ret = GetAllowedChannels();
					om.Initialize(0, 0, 0);
					break;
				}
				case 24: { // AddIe
					var ret = AddIe(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 25: { // DeleteIe
					DeleteIe(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 26: { // Unknown26
					Unknown26(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 27: { // Unknown27
					Unknown27(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 28: { // CreateRxEntry
					var ret = CreateRxEntry(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 29: { // DeleteRxEntry
					DeleteRxEntry(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 30: { // Unknown30
					Unknown30(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 31: { // Unknown31
					var ret = Unknown31(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 32: { // AddMatchingDataToRxEntry
					AddMatchingDataToRxEntry(null, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 33: { // RemoveMatchingDataFromRxEntry
					RemoveMatchingDataFromRxEntry(null, im.GetBuffer<byte>(0x19, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 34: { // GetScanResult
					GetScanResult(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 35: { // Unknown35
					Unknown35(null, im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 36: { // SetActionFrameWithBeacon
					SetActionFrameWithBeacon(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 37: { // CancelActionFrameWithBeacon
					CancelActionFrameWithBeacon();
					om.Initialize(0, 0, 0);
					break;
				}
				case 38: { // CreateRxEntryForActionFrame
					var ret = CreateRxEntryForActionFrame(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 39: { // DeleteRxEntryForActionFrame
					DeleteRxEntryForActionFrame(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 40: { // Unknown40
					Unknown40(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 41: { // Unknown41
					var ret = Unknown41(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 42: { // CancelGetActionFrame
					CancelGetActionFrame(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 43: { // GetRssi
					var ret = GetRssi();
					om.Initialize(0, 0, 0);
					break;
				}
				case 44: { // Unknown44
					Unknown44(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 45: { // Unknown45
					Unknown45();
					om.Initialize(0, 0, 0);
					break;
				}
				case 46: { // Unknown46
					Unknown46();
					om.Initialize(0, 0, 0);
					break;
				}
				case 47: { // Unknown47
					Unknown47();
					om.Initialize(0, 0, 0);
					break;
				}
				case 48: { // Unknown48
					Unknown48();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILocalManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown0 [0]".Debug();
		public virtual void Unknown1() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown1 [1]".Debug();
		public virtual void Unknown2() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown2 [2]".Debug();
		public virtual void Unknown3() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown3 [3]".Debug();
		public virtual void Unknown4() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown4 [4]".Debug();
		public virtual void Unknown5() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown5 [5]".Debug();
		public virtual object GetMacAddress() => throw new NotImplementedException();
		public virtual void CreateBss(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.CreateBss [7]".Debug();
		public virtual void DestroyBss() => "Stub hit for Nn.Wlan.Detail.ILocalManager.DestroyBss [8]".Debug();
		public virtual void StartScan(Buffer<byte> _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.StartScan [9]".Debug();
		public virtual void StopScan() => "Stub hit for Nn.Wlan.Detail.ILocalManager.StopScan [10]".Debug();
		public virtual void Connect(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Connect [11]".Debug();
		public virtual void CancelConnect() => "Stub hit for Nn.Wlan.Detail.ILocalManager.CancelConnect [12]".Debug();
		public virtual void Join(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Join [13]".Debug();
		public virtual void CancelJoin() => "Stub hit for Nn.Wlan.Detail.ILocalManager.CancelJoin [14]".Debug();
		public virtual void Disconnect(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Disconnect [15]".Debug();
		public virtual void SetBeaconLostCount(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.SetBeaconLostCount [16]".Debug();
		public virtual KObject Unknown17(object _0) => throw new NotImplementedException();
		public virtual object Unknown18() => throw new NotImplementedException();
		public virtual void Unknown19(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject GetBssIndicationEvent() => throw new NotImplementedException();
		public virtual void GetBssIndicationInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetState() => throw new NotImplementedException();
		public virtual object GetAllowedChannels() => throw new NotImplementedException();
		public virtual object AddIe(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteIe(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.DeleteIe [25]".Debug();
		public virtual void Unknown26(Buffer<byte> _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown26 [26]".Debug();
		public virtual void Unknown27(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown27 [27]".Debug();
		public virtual object CreateRxEntry(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteRxEntry(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.DeleteRxEntry [29]".Debug();
		public virtual void Unknown30(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown30 [30]".Debug();
		public virtual object Unknown31(object _0) => throw new NotImplementedException();
		public virtual void AddMatchingDataToRxEntry(object _0, Buffer<byte> _1) => "Stub hit for Nn.Wlan.Detail.ILocalManager.AddMatchingDataToRxEntry [32]".Debug();
		public virtual void RemoveMatchingDataFromRxEntry(object _0, Buffer<byte> _1) => "Stub hit for Nn.Wlan.Detail.ILocalManager.RemoveMatchingDataFromRxEntry [33]".Debug();
		public virtual void GetScanResult(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown35(object _0, Buffer<byte> _1) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown35 [35]".Debug();
		public virtual void SetActionFrameWithBeacon(Buffer<byte> _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.SetActionFrameWithBeacon [36]".Debug();
		public virtual void CancelActionFrameWithBeacon() => "Stub hit for Nn.Wlan.Detail.ILocalManager.CancelActionFrameWithBeacon [37]".Debug();
		public virtual object CreateRxEntryForActionFrame(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteRxEntryForActionFrame(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.DeleteRxEntryForActionFrame [39]".Debug();
		public virtual void Unknown40(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown40 [40]".Debug();
		public virtual object Unknown41(object _0) => throw new NotImplementedException();
		public virtual void CancelGetActionFrame(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.CancelGetActionFrame [42]".Debug();
		public virtual object GetRssi() => throw new NotImplementedException();
		public virtual void Unknown44(object _0) => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown44 [44]".Debug();
		public virtual void Unknown45() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown45 [45]".Debug();
		public virtual void Unknown46() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown46 [46]".Debug();
		public virtual void Unknown47() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown47 [47]".Debug();
		public virtual void Unknown48() => "Stub hit for Nn.Wlan.Detail.ILocalManager.Unknown48 [48]".Debug();
	}
	
	[IpcService("wlan:sg")]
	public unsafe partial class ISocketGetFrame : _Base_ISocketGetFrame {}
	public unsafe class _Base_ISocketGetFrame : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISocketGetFrame: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("wlan:soc")]
	public unsafe partial class ISocketManager : _Base_ISocketManager {}
	public unsafe class _Base_ISocketManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null, im.GetBuffer<byte>(0x9, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // GetMacAddress
					var ret = GetMacAddress();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // SwitchTsfTimerFunction
					SwitchTsfTimerFunction(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // Unknown9
					Unknown9(null, Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)), Kernel.Get<KObject>(im.GetCopy(2)), Kernel.Get<KObject>(im.GetCopy(3)), Kernel.Get<KObject>(im.GetCopy(4)));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Unknown10
					Unknown10();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Unknown11
					Unknown11();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISocketManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(Buffer<byte> _0) => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown0 [0]".Debug();
		public virtual void Unknown1(object _0) => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown1 [1]".Debug();
		public virtual object Unknown2(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown3 [3]".Debug();
		public virtual void Unknown4(object _0) => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown4 [4]".Debug();
		public virtual object Unknown5(object _0) => throw new NotImplementedException();
		public virtual object GetMacAddress() => throw new NotImplementedException();
		public virtual void SwitchTsfTimerFunction(object _0) => "Stub hit for Nn.Wlan.Detail.ISocketManager.SwitchTsfTimerFunction [7]".Debug();
		public virtual object Unknown8() => throw new NotImplementedException();
		public virtual void Unknown9(object _0, KObject _1, KObject _2, KObject _3, KObject _4, KObject _5) => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown9 [9]".Debug();
		public virtual void Unknown10() => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown10 [10]".Debug();
		public virtual void Unknown11() => "Stub hit for Nn.Wlan.Detail.ISocketManager.Unknown11 [11]".Debug();
	}
}
