#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ntc.Detail.Service {
	[IpcService("ntc")]
	public unsafe partial class IStaticService : _Base_IStaticService {}
	public unsafe class _Base_IStaticService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenEnsureNetworkClockAvailabilityService
					var ret = OpenEnsureNetworkClockAvailabilityService(im.GetData<uint>(0), im.GetData<uint>(4));
					om.Move(0, ret.Handle);
					break;
				}
				case 100: { // SuspendAutonomicTimeCorrection
					SuspendAutonomicTimeCorrection();
					break;
				}
				case 101: { // ResumeAutonomicTimeCorrection
					ResumeAutonomicTimeCorrection();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStaticService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ntc.Detail.Service.IEnsureNetworkClockAvailabilityService OpenEnsureNetworkClockAvailabilityService(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void SuspendAutonomicTimeCorrection() => throw new NotImplementedException();
		public virtual void ResumeAutonomicTimeCorrection() => throw new NotImplementedException();
	}
	
	public unsafe partial class IEnsureNetworkClockAvailabilityService : _Base_IEnsureNetworkClockAvailabilityService {}
	public unsafe class _Base_IEnsureNetworkClockAvailabilityService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // StartTask
					StartTask();
					break;
				}
				case 1: { // GetFinishNotificationEvent
					var ret = GetFinishNotificationEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // GetResult
					GetResult();
					break;
				}
				case 3: { // Cancel
					Cancel();
					break;
				}
				case 4: { // IsProcessing
					var ret = IsProcessing();
					om.SetData(0, ret);
					break;
				}
				case 5: { // GetServerTime
					var ret = GetServerTime();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEnsureNetworkClockAvailabilityService: {im.CommandId}");
			}
		}
		
		public virtual void StartTask() => throw new NotImplementedException();
		public virtual KObject GetFinishNotificationEvent() => throw new NotImplementedException();
		public virtual void GetResult() => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
		public virtual byte IsProcessing() => throw new NotImplementedException();
		public virtual ulong GetServerTime() => throw new NotImplementedException();
	}
}
