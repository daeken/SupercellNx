using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.nn.timesrv.detail.service {
	[IpcService("time:u")]
	[IpcService("time:a")]
	[IpcService("time:s")]
	public class IStaticService : IpcInterface {
		[IpcCommand(0)]
		void GetStandardUserSystemClock([Move] out ISystemClock service) => service = new ISystemClock();
		[IpcCommand(1)]
		void GetStandardNetworkSystemClock([Move] out ISystemClock service) => service = new ISystemClock();
		[IpcCommand(2)]
		void GetStandardSteadyClock([Move] out ISteadyClock service) => service = new ISteadyClock();
		[IpcCommand(3)]
		void GetTimeZoneService([Move] out ITimeZoneService service) => service = new ITimeZoneService();
		[IpcCommand(4)]
		void GetStandardLocalSystemClock([Move] out ISystemClock service) => service = new ISystemClock();
		[IpcCommand(5)]
		void GetEphemeralNetworkSystemClock([Move] out ISystemClock service) => service = new ISystemClock();
		[IpcCommand(50)]
		void SetStandardSteadyClockInternalOffset(ulong /* nn::TimeSpanType */ unknown0) => throw new NotImplementedException();
		[IpcCommand(100)]
		void IsStandardUserSystemClockAutomaticCorrectionEnabled(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(101)]
		void SetStandardUserSystemClockAutomaticCorrectionEnabled(bool unknown0) => throw new NotImplementedException();
		[IpcCommand(102)]
		void GetStandardUserSystemClockInitialYear(object unknown0, out object unknown1) => throw new NotImplementedException();
		[IpcCommand(200)]
		void IsStandardNetworkSystemClockAccuracySufficient(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(300)]
		void CalculateMonotonicSystemClockBaseTimePoint([Bytes(0x100 /* 32 x 8 */)] byte[] /* nn::time::SystemClockContext */ unknown0, out ulong unknown1) => throw new NotImplementedException();
		[IpcCommand(400)]
		void GetClockSnapshot(byte unknown0, [Buffer(0x1a)] Buffer<byte> snapshot) => throw new NotImplementedException();
		[IpcCommand(401)]
		void GetClockSnapshotFromSystemClockContext(byte unknown0, [Bytes(0x100 /* 32 x 8 */)] byte[] clockContext, [Bytes(0x100 /* 32 x 8 */)] byte[] clockContext2, [Buffer(0x1a)] Buffer<byte> snapshot) => throw new NotImplementedException();
		[IpcCommand(500)]
		void CalculateStandardUserSystemClockDifferenceByUser([Buffer(0x19)] Buffer<byte> snapshot, [Buffer(0x19)] Buffer<byte> snapshot2, out ulong /* nn::TimeSpanType */ unknown2) => throw new NotImplementedException();
		[IpcCommand(501)]
		void CalculateSpanBetween([Buffer(0x19)] Buffer<byte> snapshot, [Buffer(0x19)] Buffer<byte> snapshot2, out ulong /* nn::TimeSpanType */ unknown2) => throw new NotImplementedException();
	}
	
	public class ISystemClock : IpcInterface {
		[IpcCommand(0)]
		void GetCurrentTime(out ulong /* nn::time::PosixTime */ unknown0) => throw new NotImplementedException();
		[IpcCommand(1)]
		void SetCurrentTime(ulong /* nn::time::PosixTime */ unknown0) => throw new NotImplementedException();
		[IpcCommand(2)]
		void GetSystemClockContext([Bytes(0x100 /* 32 x 8 */)] out byte[] clockContext) => throw new NotImplementedException();
		[IpcCommand(3)]
		void SetSystemClockContext([Bytes(0x100 /* 32 x 8 */)] byte[] clockContext) => throw new NotImplementedException();
	}
	
	public class ISteadyClock : IpcInterface {
		[IpcCommand(0)]
		void GetCurrentTimePoint([Bytes(0xc0 /* 24 x 8 */)] out byte[] timepoint) => throw new NotImplementedException();
		[IpcCommand(2)]
		void GetTestOffset(out ulong /* nn::TimeSpanType */ unknown0) => throw new NotImplementedException();
		[IpcCommand(3)]
		void SetTestOffset(ulong /* nn::TimeSpanType */ unknown0) => throw new NotImplementedException();
		[IpcCommand(100)]
		void GetRtcValue(out ulong unknown0) => throw new NotImplementedException();
		[IpcCommand(101)]
		void IsRtcResetDetected(out bool unknown0) => throw new NotImplementedException();
		[IpcCommand(102)]
		void GetSetupResultValue(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(200)]
		void GetInternalOffset(out ulong /* nn::TimeSpanType */ unknown0) => throw new NotImplementedException();
		[IpcCommand(201)]
		void SetInternalOffset(ulong /* nn::TimeSpanType */ unknown0) => throw new NotImplementedException();
	}
	
	public class ITimeZoneService : IpcInterface {
		[IpcCommand(0)]
		void GetDeviceLocationName([Bytes(0x24 /* 36 x 1 */)] out byte[] locationName) => throw new NotImplementedException();
		[IpcCommand(1)]
		void SetDeviceLocationName([Bytes(0x24 /* 36 x 1 */)] byte[] locationName) => throw new NotImplementedException();
		[IpcCommand(2)]
		void GetTotalLocationNameCount(out uint unknown0) => throw new NotImplementedException();
		[IpcCommand(3)]
		void LoadLocationNameList(uint unknown0, out uint unknown1, [Buffer(0x6)] Buffer<byte> locationNames) => throw new NotImplementedException();
		[IpcCommand(4)]
		void LoadTimeZoneRule([Bytes(0x24 /* 36 x 1 */)] byte[] locationName, [Buffer(0x16)] Buffer<byte> rule) => throw new NotImplementedException();
		[IpcCommand(5)]
		void GetTimeZoneRuleVersion([Bytes(0x10 /* 16 x 1 */)] out byte[] ruleVersion) => throw new NotImplementedException();
		[IpcCommand(100)]
		void ToCalendarTime(ulong /* nn::time::PosixTime */ unknown0, [Buffer(0x15)] Buffer<byte> rule, out object calendarTime, out object additionalInfo) => throw new NotImplementedException();
		[IpcCommand(101)]
		void ToCalendarTimeWithMyRule(ulong /* nn::time::PosixTime */ unknown0, out object calendarTime, out object additionalInfo) => throw new NotImplementedException();
		[IpcCommand(201)]
		void ToPosixTime(object calendarTime, [Buffer(0x15)] Buffer<byte> rule, out uint unknown2, [Buffer(0xa)] Buffer<ulong> posixTime) => throw new NotImplementedException();
		[IpcCommand(202)]
		void ToPosixTimeWithMyRule(object calendarTime, out uint unknown1, [Buffer(0xa)] Buffer<ulong> posixTime) => throw new NotImplementedException();
	}
}
