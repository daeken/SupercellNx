#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Timesrv.Detail.Service {
	[IpcService("time:u")]
	[IpcService("time:a")]
	[IpcService("time:s")]
	public unsafe partial class IStaticService : _Base_IStaticService {}
	public unsafe class _Base_IStaticService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetStandardUserSystemClock
					var ret = GetStandardUserSystemClock();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetStandardNetworkSystemClock
					var ret = GetStandardNetworkSystemClock();
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // GetStandardSteadyClock
					var ret = GetStandardSteadyClock();
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // GetTimeZoneService
					var ret = GetTimeZoneService();
					om.Move(0, ret.Handle);
					break;
				}
				case 4: { // GetStandardLocalSystemClock
					var ret = GetStandardLocalSystemClock();
					om.Move(0, ret.Handle);
					break;
				}
				case 5: { // GetEphemeralNetworkSystemClock
					var ret = GetEphemeralNetworkSystemClock();
					om.Move(0, ret.Handle);
					break;
				}
				case 50: { // SetStandardSteadyClockInternalOffset
					SetStandardSteadyClockInternalOffset(im.GetData<ulong>(0));
					break;
				}
				case 100: { // IsStandardUserSystemClockAutomaticCorrectionEnabled
					var ret = IsStandardUserSystemClockAutomaticCorrectionEnabled();
					om.SetData(0, ret);
					break;
				}
				case 101: { // SetStandardUserSystemClockAutomaticCorrectionEnabled
					SetStandardUserSystemClockAutomaticCorrectionEnabled(im.GetData<byte>(0));
					break;
				}
				case 102: { // GetStandardUserSystemClockInitialYear
					var ret = GetStandardUserSystemClockInitialYear(null);
					break;
				}
				case 200: { // IsStandardNetworkSystemClockAccuracySufficient
					var ret = IsStandardNetworkSystemClockAccuracySufficient();
					om.SetData(0, ret);
					break;
				}
				case 300: { // CalculateMonotonicSystemClockBaseTimePoint
					var ret = CalculateMonotonicSystemClockBaseTimePoint(im.GetBytes(0, 0x20));
					om.SetData(0, ret);
					break;
				}
				case 400: { // GetClockSnapshot
					GetClockSnapshot(im.GetData<byte>(0), im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 401: { // GetClockSnapshotFromSystemClockContext
					GetClockSnapshotFromSystemClockContext(im.GetData<byte>(0), im.GetBytes(1, 0x20), im.GetBytes(33, 0x20), im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 500: { // CalculateStandardUserSystemClockDifferenceByUser
					var ret = CalculateStandardUserSystemClockDifferenceByUser(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.SetData(0, ret);
					break;
				}
				case 501: { // CalculateSpanBetween
					var ret = CalculateSpanBetween(im.GetBuffer<byte>(0x19, 0), im.GetBuffer<byte>(0x19, 1));
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStaticService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Timesrv.Detail.Service.ISystemClock GetStandardUserSystemClock() => throw new NotImplementedException();
		public virtual Nn.Timesrv.Detail.Service.ISystemClock GetStandardNetworkSystemClock() => throw new NotImplementedException();
		public virtual Nn.Timesrv.Detail.Service.ISteadyClock GetStandardSteadyClock() => throw new NotImplementedException();
		public virtual Nn.Timesrv.Detail.Service.ITimeZoneService GetTimeZoneService() => throw new NotImplementedException();
		public virtual Nn.Timesrv.Detail.Service.ISystemClock GetStandardLocalSystemClock() => throw new NotImplementedException();
		public virtual Nn.Timesrv.Detail.Service.ISystemClock GetEphemeralNetworkSystemClock() => throw new NotImplementedException();
		public virtual void SetStandardSteadyClockInternalOffset(ulong _0) => throw new NotImplementedException();
		public virtual byte IsStandardUserSystemClockAutomaticCorrectionEnabled() => throw new NotImplementedException();
		public virtual void SetStandardUserSystemClockAutomaticCorrectionEnabled(byte _0) => throw new NotImplementedException();
		public virtual object GetStandardUserSystemClockInitialYear(object _0) => throw new NotImplementedException();
		public virtual byte IsStandardNetworkSystemClockAccuracySufficient() => throw new NotImplementedException();
		public virtual ulong CalculateMonotonicSystemClockBaseTimePoint(byte[] _0) => throw new NotImplementedException();
		public virtual void GetClockSnapshot(byte _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetClockSnapshotFromSystemClockContext(byte _0, byte[] _1, byte[] _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual ulong CalculateStandardUserSystemClockDifferenceByUser(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual ulong CalculateSpanBetween(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISteadyClock : _Base_ISteadyClock {}
	public unsafe class _Base_ISteadyClock : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCurrentTimePoint
					GetCurrentTimePoint(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 2: { // GetTestOffset
					var ret = GetTestOffset();
					om.SetData(0, ret);
					break;
				}
				case 3: { // SetTestOffset
					SetTestOffset(im.GetData<ulong>(0));
					break;
				}
				case 100: { // GetRtcValue
					var ret = GetRtcValue();
					om.SetData(0, ret);
					break;
				}
				case 101: { // IsRtcResetDetected
					var ret = IsRtcResetDetected();
					om.SetData(0, ret);
					break;
				}
				case 102: { // GetSetupResultValue
					var ret = GetSetupResultValue();
					om.SetData(0, ret);
					break;
				}
				case 200: { // GetInternalOffset
					var ret = GetInternalOffset();
					om.SetData(0, ret);
					break;
				}
				case 201: { // SetInternalOffset
					SetInternalOffset(im.GetData<ulong>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISteadyClock: {im.CommandId}");
			}
		}
		
		public virtual void GetCurrentTimePoint(out byte[] _0) => throw new NotImplementedException();
		public virtual ulong GetTestOffset() => throw new NotImplementedException();
		public virtual void SetTestOffset(ulong _0) => throw new NotImplementedException();
		public virtual ulong GetRtcValue() => throw new NotImplementedException();
		public virtual byte IsRtcResetDetected() => throw new NotImplementedException();
		public virtual uint GetSetupResultValue() => throw new NotImplementedException();
		public virtual ulong GetInternalOffset() => throw new NotImplementedException();
		public virtual void SetInternalOffset(ulong _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISystemClock : _Base_ISystemClock {}
	public unsafe class _Base_ISystemClock : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCurrentTime
					var ret = GetCurrentTime();
					om.SetData(0, ret);
					break;
				}
				case 1: { // SetCurrentTime
					SetCurrentTime(im.GetData<ulong>(0));
					break;
				}
				case 2: { // GetSystemClockContext
					GetSystemClockContext(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 3: { // SetSystemClockContext
					SetSystemClockContext(im.GetBytes(0, 0x20));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISystemClock: {im.CommandId}");
			}
		}
		
		public virtual ulong GetCurrentTime() => throw new NotImplementedException();
		public virtual void SetCurrentTime(ulong _0) => throw new NotImplementedException();
		public virtual void GetSystemClockContext(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetSystemClockContext(byte[] _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ITimeZoneService : _Base_ITimeZoneService {}
	public unsafe class _Base_ITimeZoneService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetDeviceLocationName
					GetDeviceLocationName(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 1: { // SetDeviceLocationName
					SetDeviceLocationName(im.GetBytes(0, 0x24));
					break;
				}
				case 2: { // GetTotalLocationNameCount
					var ret = GetTotalLocationNameCount();
					om.SetData(0, ret);
					break;
				}
				case 3: { // LoadLocationNameList
					LoadLocationNameList(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 4: { // LoadTimeZoneRule
					LoadTimeZoneRule(im.GetBytes(0, 0x24), im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 5: { // GetTimeZoneRuleVersion
					GetTimeZoneRuleVersion(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 100: { // ToCalendarTime
					ToCalendarTime(im.GetData<ulong>(0), im.GetBuffer<byte>(0x15, 0), (Nn.Time.CalendarTime*) om.GetDataPointer(0), (Nn.Time.Sf.CalendarAdditionalInfo*) om.GetDataPointer(0));
					break;
				}
				case 101: { // ToCalendarTimeWithMyRule
					ToCalendarTimeWithMyRule(im.GetData<ulong>(0), (Nn.Time.CalendarTime*) om.GetDataPointer(0), (Nn.Time.Sf.CalendarAdditionalInfo*) om.GetDataPointer(0));
					break;
				}
				case 201: { // ToPosixTime
					ToPosixTime((Nn.Time.CalendarTime*) im.GetDataPointer(0), im.GetBuffer<byte>(0x15, 0), out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 202: { // ToPosixTimeWithMyRule
					ToPosixTimeWithMyRule((Nn.Time.CalendarTime*) im.GetDataPointer(0), out var _0, im.GetBuffer<ulong>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ITimeZoneService: {im.CommandId}");
			}
		}
		
		public virtual void GetDeviceLocationName(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetDeviceLocationName(byte[] _0) => throw new NotImplementedException();
		public virtual uint GetTotalLocationNameCount() => throw new NotImplementedException();
		public virtual void LoadLocationNameList(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void LoadTimeZoneRule(byte[] _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetTimeZoneRuleVersion(out byte[] _0) => throw new NotImplementedException();
		public virtual void ToCalendarTime(ulong _0, Buffer<byte> _1,  Nn.Time.CalendarTime* _2,  Nn.Time.Sf.CalendarAdditionalInfo* _3) => throw new NotImplementedException();
		public virtual void ToCalendarTimeWithMyRule(ulong _0,  Nn.Time.CalendarTime* _1,  Nn.Time.Sf.CalendarAdditionalInfo* _2) => throw new NotImplementedException();
		public virtual void ToPosixTime(Nn.Time.CalendarTime* _0, Buffer<byte> _1, out uint _2, Buffer<ulong> _3) => throw new NotImplementedException();
		public virtual void ToPosixTimeWithMyRule(Nn.Time.CalendarTime* _0, out uint _1, Buffer<ulong> _2) => throw new NotImplementedException();
	}
}
