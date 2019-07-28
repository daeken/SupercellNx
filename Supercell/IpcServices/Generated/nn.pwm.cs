#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pwm {
	[IpcService("pwm")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSessionForDev
					var ret = OpenSessionForDev(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // OpenSession
					var ret = OpenSession(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Pwm.IChannelSession OpenSessionForDev(uint _0) => throw new NotImplementedException();
		public virtual Nn.Pwm.IChannelSession OpenSession(uint _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IChannelSession : _Base_IChannelSession {}
	public unsafe class _Base_IChannelSession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetPeriod
					SetPeriod(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetPeriod
					var ret = GetPeriod();
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 2: { // SetDuty
					SetDuty(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetDuty
					var ret = GetDuty();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 4: { // SetEnabled
					SetEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetEnabled
					var ret = GetEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IChannelSession: {im.CommandId}");
			}
		}
		
		public virtual void SetPeriod(ulong _0) => "Stub hit for Nn.Pwm.IChannelSession.SetPeriod [0]".Debug();
		public virtual ulong GetPeriod() => throw new NotImplementedException();
		public virtual void SetDuty(uint _0) => "Stub hit for Nn.Pwm.IChannelSession.SetDuty [2]".Debug();
		public virtual uint GetDuty() => throw new NotImplementedException();
		public virtual void SetEnabled(byte _0) => "Stub hit for Nn.Pwm.IChannelSession.SetEnabled [4]".Debug();
		public virtual byte GetEnabled() => throw new NotImplementedException();
	}
}
