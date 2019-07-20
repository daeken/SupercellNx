#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Wlan.Detail {
	[IpcService("wlan:inf")]
	public unsafe partial class IInfraManager : _Base_IInfraManager {}
	public unsafe class _Base_IInfraManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // GetMacAddress
					var ret = GetMacAddress();
					break;
				}
				case 3: { // StartScan
					StartScan(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				case 4: { // StopScan
					StopScan();
					break;
				}
				case 5: { // Connect
					Connect(null);
					break;
				}
				case 6: { // CancelConnect
					CancelConnect();
					break;
				}
				case 7: { // Disconnect
					Disconnect();
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 9: { // Unknown9
					var ret = Unknown9();
					break;
				}
				case 10: { // GetState
					var ret = GetState();
					break;
				}
				case 11: { // GetScanResult
					GetScanResult(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 12: { // GetRssi
					var ret = GetRssi();
					break;
				}
				case 13: { // ChangeRxAntenna
					ChangeRxAntenna(null);
					break;
				}
				case 14: { // Unknown14
					Unknown14(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 15: { // Unknown15
					Unknown15();
					break;
				}
				case 16: { // RequestWakeUp
					RequestWakeUp();
					break;
				}
				case 17: { // RequestIfUpDown
					RequestIfUpDown(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18();
					break;
				}
				case 19: { // Unknown19
					Unknown19(null);
					break;
				}
				case 20: { // Unknown20
					Unknown20();
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21();
					break;
				}
				case 22: { // Unknown22
					Unknown22(null);
					break;
				}
				case 23: { // Unknown23
					Unknown23(null);
					break;
				}
				case 24: { // Unknown24
					var ret = Unknown24();
					break;
				}
				case 25: { // Unknown25
					Unknown25(null);
					break;
				}
				case 26: { // Unknown26
					Unknown26();
					break;
				}
				case 27: { // Unknown27
					Unknown27();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IInfraManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual object GetMacAddress() => throw new NotImplementedException();
		public virtual void StartScan(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void StopScan() => throw new NotImplementedException();
		public virtual void Connect(object _0) => throw new NotImplementedException();
		public virtual void CancelConnect() => throw new NotImplementedException();
		public virtual void Disconnect() => throw new NotImplementedException();
		public virtual KObject Unknown8(object _0) => throw new NotImplementedException();
		public virtual object Unknown9() => throw new NotImplementedException();
		public virtual object GetState() => throw new NotImplementedException();
		public virtual void GetScanResult(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetRssi() => throw new NotImplementedException();
		public virtual void ChangeRxAntenna(object _0) => throw new NotImplementedException();
		public virtual void Unknown14(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown15() => throw new NotImplementedException();
		public virtual void RequestWakeUp() => throw new NotImplementedException();
		public virtual void RequestIfUpDown(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown18() => throw new NotImplementedException();
		public virtual void Unknown19(object _0) => throw new NotImplementedException();
		public virtual void Unknown20() => throw new NotImplementedException();
		public virtual object Unknown21() => throw new NotImplementedException();
		public virtual void Unknown22(object _0) => throw new NotImplementedException();
		public virtual void Unknown23(object _0) => throw new NotImplementedException();
		public virtual object Unknown24() => throw new NotImplementedException();
		public virtual void Unknown25(object _0) => throw new NotImplementedException();
		public virtual void Unknown26() => throw new NotImplementedException();
		public virtual void Unknown27() => throw new NotImplementedException();
	}
	
	[IpcService("wlan:lga")]
	public unsafe partial class ILocalGetActionFrame : _Base_ILocalGetActionFrame {}
	public unsafe class _Base_ILocalGetActionFrame : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0();
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3();
					break;
				}
				case 4: { // Unknown4
					Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5();
					break;
				}
				case 6: { // GetMacAddress
					var ret = GetMacAddress();
					break;
				}
				case 7: { // CreateBss
					CreateBss(null);
					break;
				}
				case 8: { // DestroyBss
					DestroyBss();
					break;
				}
				case 9: { // StartScan
					StartScan(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				case 10: { // StopScan
					StopScan();
					break;
				}
				case 11: { // Connect
					Connect(null);
					break;
				}
				case 12: { // CancelConnect
					CancelConnect();
					break;
				}
				case 13: { // Join
					Join(null);
					break;
				}
				case 14: { // CancelJoin
					CancelJoin();
					break;
				}
				case 15: { // Disconnect
					Disconnect(null);
					break;
				}
				case 16: { // SetBeaconLostCount
					SetBeaconLostCount(null);
					break;
				}
				case 17: { // Unknown17
					var ret = Unknown17(null);
					om.Copy(0, ret.Handle);
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18();
					break;
				}
				case 19: { // Unknown19
					Unknown19(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 20: { // GetBssIndicationEvent
					var ret = GetBssIndicationEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 21: { // GetBssIndicationInfo
					GetBssIndicationInfo(im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 22: { // GetState
					var ret = GetState();
					break;
				}
				case 23: { // GetAllowedChannels
					var ret = GetAllowedChannels();
					break;
				}
				case 24: { // AddIe
					var ret = AddIe(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 25: { // DeleteIe
					DeleteIe(null);
					break;
				}
				case 26: { // Unknown26
					Unknown26(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 27: { // Unknown27
					Unknown27(null);
					break;
				}
				case 28: { // CreateRxEntry
					var ret = CreateRxEntry(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 29: { // DeleteRxEntry
					DeleteRxEntry(null);
					break;
				}
				case 30: { // Unknown30
					Unknown30(null);
					break;
				}
				case 31: { // Unknown31
					var ret = Unknown31(null);
					break;
				}
				case 32: { // AddMatchingDataToRxEntry
					AddMatchingDataToRxEntry(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 33: { // RemoveMatchingDataFromRxEntry
					RemoveMatchingDataFromRxEntry(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 34: { // GetScanResult
					GetScanResult(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 35: { // Unknown35
					Unknown35(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 36: { // SetActionFrameWithBeacon
					SetActionFrameWithBeacon(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 37: { // CancelActionFrameWithBeacon
					CancelActionFrameWithBeacon();
					break;
				}
				case 38: { // CreateRxEntryForActionFrame
					var ret = CreateRxEntryForActionFrame(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 39: { // DeleteRxEntryForActionFrame
					DeleteRxEntryForActionFrame(null);
					break;
				}
				case 40: { // Unknown40
					Unknown40(null);
					break;
				}
				case 41: { // Unknown41
					var ret = Unknown41(null);
					break;
				}
				case 42: { // CancelGetActionFrame
					CancelGetActionFrame(null);
					break;
				}
				case 43: { // GetRssi
					var ret = GetRssi();
					break;
				}
				case 44: { // Unknown44
					Unknown44(null);
					break;
				}
				case 45: { // Unknown45
					Unknown45();
					break;
				}
				case 46: { // Unknown46
					Unknown46();
					break;
				}
				case 47: { // Unknown47
					Unknown47();
					break;
				}
				case 48: { // Unknown48
					Unknown48();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILocalManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0() => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3() => throw new NotImplementedException();
		public virtual void Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5() => throw new NotImplementedException();
		public virtual object GetMacAddress() => throw new NotImplementedException();
		public virtual void CreateBss(object _0) => throw new NotImplementedException();
		public virtual void DestroyBss() => throw new NotImplementedException();
		public virtual void StartScan(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void StopScan() => throw new NotImplementedException();
		public virtual void Connect(object _0) => throw new NotImplementedException();
		public virtual void CancelConnect() => throw new NotImplementedException();
		public virtual void Join(object _0) => throw new NotImplementedException();
		public virtual void CancelJoin() => throw new NotImplementedException();
		public virtual void Disconnect(object _0) => throw new NotImplementedException();
		public virtual void SetBeaconLostCount(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown17(object _0) => throw new NotImplementedException();
		public virtual object Unknown18() => throw new NotImplementedException();
		public virtual void Unknown19(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual KObject GetBssIndicationEvent() => throw new NotImplementedException();
		public virtual void GetBssIndicationInfo(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetState() => throw new NotImplementedException();
		public virtual object GetAllowedChannels() => throw new NotImplementedException();
		public virtual object AddIe(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteIe(object _0) => throw new NotImplementedException();
		public virtual void Unknown26(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown27(object _0) => throw new NotImplementedException();
		public virtual object CreateRxEntry(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteRxEntry(object _0) => throw new NotImplementedException();
		public virtual void Unknown30(object _0) => throw new NotImplementedException();
		public virtual object Unknown31(object _0) => throw new NotImplementedException();
		public virtual void AddMatchingDataToRxEntry(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RemoveMatchingDataFromRxEntry(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetScanResult(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown35(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SetActionFrameWithBeacon(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void CancelActionFrameWithBeacon() => throw new NotImplementedException();
		public virtual object CreateRxEntryForActionFrame(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void DeleteRxEntryForActionFrame(object _0) => throw new NotImplementedException();
		public virtual void Unknown40(object _0) => throw new NotImplementedException();
		public virtual object Unknown41(object _0) => throw new NotImplementedException();
		public virtual void CancelGetActionFrame(object _0) => throw new NotImplementedException();
		public virtual object GetRssi() => throw new NotImplementedException();
		public virtual void Unknown44(object _0) => throw new NotImplementedException();
		public virtual void Unknown45() => throw new NotImplementedException();
		public virtual void Unknown46() => throw new NotImplementedException();
		public virtual void Unknown47() => throw new NotImplementedException();
		public virtual void Unknown48() => throw new NotImplementedException();
	}
	
	[IpcService("wlan:sg")]
	public unsafe partial class ISocketGetFrame : _Base_ISocketGetFrame {}
	public unsafe class _Base_ISocketGetFrame : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, out var _0, im.GetBuffer<byte>(0x6, 0));
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5(null);
					break;
				}
				case 6: { // GetMacAddress
					var ret = GetMacAddress();
					break;
				}
				case 7: { // SwitchTsfTimerFunction
					SwitchTsfTimerFunction(null);
					break;
				}
				case 8: { // Unknown8
					var ret = Unknown8();
					break;
				}
				case 9: { // Unknown9
					Unknown9(null, Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)), Kernel.Get<KObject>(im.GetCopy(2)), Kernel.Get<KObject>(im.GetCopy(3)), Kernel.Get<KObject>(im.GetCopy(4)));
					break;
				}
				case 10: { // Unknown10
					Unknown10();
					break;
				}
				case 11: { // Unknown11
					Unknown11();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISocketManager: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0) => throw new NotImplementedException();
		public virtual object Unknown2(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual void Unknown4(object _0) => throw new NotImplementedException();
		public virtual object Unknown5(object _0) => throw new NotImplementedException();
		public virtual object GetMacAddress() => throw new NotImplementedException();
		public virtual void SwitchTsfTimerFunction(object _0) => throw new NotImplementedException();
		public virtual object Unknown8() => throw new NotImplementedException();
		public virtual void Unknown9(object _0, KObject _1, KObject _2, KObject _3, KObject _4, KObject _5) => throw new NotImplementedException();
		public virtual void Unknown10() => throw new NotImplementedException();
		public virtual void Unknown11() => throw new NotImplementedException();
	}
}
