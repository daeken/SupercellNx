using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Timesrv.Detail.Service {
	public unsafe partial class IStaticService {
		public override Nn.Timesrv.Detail.Service.ISystemClock GetStandardUserSystemClock() => new Nn.Timesrv.Detail.Service.ISystemClock();
		public override Nn.Timesrv.Detail.Service.ISystemClock GetStandardNetworkSystemClock() => new ISystemClock();
		public override Nn.Timesrv.Detail.Service.ISteadyClock GetStandardSteadyClock() => new ISteadyClock();
		public override Nn.Timesrv.Detail.Service.ITimeZoneService GetTimeZoneService() => new ITimeZoneService();
		public override Nn.Timesrv.Detail.Service.ISystemClock GetStandardLocalSystemClock() => new ISystemClock();
		public override Nn.Timesrv.Detail.Service.ISystemClock GetEphemeralNetworkSystemClock() => new ISystemClock();
		public override void SetStandardSteadyClockInternalOffset(ulong _0) => throw new NotImplementedException();
		public override byte IsStandardUserSystemClockAutomaticCorrectionEnabled() => throw new NotImplementedException();
		public override void SetStandardUserSystemClockAutomaticCorrectionEnabled(byte _0) => throw new NotImplementedException();
		public override object GetStandardUserSystemClockInitialYear(object _0) => throw new NotImplementedException();
		public override byte IsStandardNetworkSystemClockAccuracySufficient() => throw new NotImplementedException();
		public override ulong CalculateMonotonicSystemClockBaseTimePoint(byte[] _0) => throw new NotImplementedException();
		public override void GetClockSnapshot(byte _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void GetClockSnapshotFromSystemClockContext(byte _0, byte[] _1, byte[] _2, Buffer<byte> _3) => throw new NotImplementedException();
		public override ulong CalculateStandardUserSystemClockDifferenceByUser(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override ulong CalculateSpanBetween(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
}
