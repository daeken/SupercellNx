#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ntc.Detail.Service {
	[IpcService("ntc")]
	public unsafe partial class IStaticService : _Base_IStaticService {}
	public unsafe class _Base_IStaticService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenEnsureNetworkClockAvailabilityService
					var ret = OpenEnsureNetworkClockAvailabilityService(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 100: { // SuspendAutonomicTimeCorrection
					SuspendAutonomicTimeCorrection();
					om.Initialize(0, 0, 0);
					break;
				}
				case 101: { // ResumeAutonomicTimeCorrection
					ResumeAutonomicTimeCorrection();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IStaticService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ntc.Detail.Service.IEnsureNetworkClockAvailabilityService OpenEnsureNetworkClockAvailabilityService(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void SuspendAutonomicTimeCorrection() => "Stub hit for Nn.Ntc.Detail.Service.IStaticService.SuspendAutonomicTimeCorrection [100]".Debug();
		public virtual void ResumeAutonomicTimeCorrection() => "Stub hit for Nn.Ntc.Detail.Service.IStaticService.ResumeAutonomicTimeCorrection [101]".Debug();
	}
	
	public unsafe partial class IEnsureNetworkClockAvailabilityService : _Base_IEnsureNetworkClockAvailabilityService {}
	public unsafe class _Base_IEnsureNetworkClockAvailabilityService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // StartTask
					StartTask();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetFinishNotificationEvent
					var ret = GetFinishNotificationEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 2: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // IsProcessing
					var ret = IsProcessing();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 5: { // GetServerTime
					var ret = GetServerTime();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEnsureNetworkClockAvailabilityService: {im.CommandId}");
			}
		}
		
		public virtual void StartTask() => "Stub hit for Nn.Ntc.Detail.Service.IEnsureNetworkClockAvailabilityService.StartTask [0]".Debug();
		public virtual KObject GetFinishNotificationEvent() => throw new NotImplementedException();
		public virtual void GetResult() => "Stub hit for Nn.Ntc.Detail.Service.IEnsureNetworkClockAvailabilityService.GetResult [2]".Debug();
		public virtual void Cancel() => "Stub hit for Nn.Ntc.Detail.Service.IEnsureNetworkClockAvailabilityService.Cancel [3]".Debug();
		public virtual byte IsProcessing() => throw new NotImplementedException();
		public virtual ulong GetServerTime() => throw new NotImplementedException();
	}
}
