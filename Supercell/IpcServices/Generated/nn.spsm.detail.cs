#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Spsm.Detail {
	[IpcService("spsm")]
	public unsafe partial class IPowerStateInterface : _Base_IPowerStateInterface {}
	public unsafe class _Base_IPowerStateInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetState
					var ret = GetState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // SleepSystemAndWaitAwake
					var ret = SleepSystemAndWaitAwake();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetNotificationMessageEventHandle
					var ret = GetNotificationMessageEventHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // Unknown7
					Unknown7();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // AnalyzePerformanceLogForLastSleepWakeSequence
					AnalyzePerformanceLogForLastSleepWakeSequence(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // ChangeHomeButtonLongPressingTime
					ChangeHomeButtonLongPressingTime(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Unknown10
					Unknown10();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // Unknown11
					Unknown11(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPowerStateInterface: {im.CommandId}");
			}
		}
		
		public virtual object GetState() => throw new NotImplementedException();
		public virtual KObject SleepSystemAndWaitAwake() => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => "Stub hit for Nn.Spsm.Detail.IPowerStateInterface.Unknown3 [3]".Debug();
		public virtual KObject GetNotificationMessageEventHandle() => throw new NotImplementedException();
		public virtual object Unknown5() => throw new NotImplementedException();
		public virtual object Unknown6() => throw new NotImplementedException();
		public virtual void Unknown7() => "Stub hit for Nn.Spsm.Detail.IPowerStateInterface.Unknown7 [7]".Debug();
		public virtual void AnalyzePerformanceLogForLastSleepWakeSequence(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void ChangeHomeButtonLongPressingTime(object _0) => "Stub hit for Nn.Spsm.Detail.IPowerStateInterface.ChangeHomeButtonLongPressingTime [9]".Debug();
		public virtual void Unknown10() => "Stub hit for Nn.Spsm.Detail.IPowerStateInterface.Unknown10 [10]".Debug();
		public virtual void Unknown11(object _0) => "Stub hit for Nn.Spsm.Detail.IPowerStateInterface.Unknown11 [11]".Debug();
	}
}
