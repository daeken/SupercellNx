#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pwm {
	[IpcService("pwm")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSessionForDev
					var ret = OpenSessionForDev(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // OpenSession
					var ret = OpenSession(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
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
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetPeriod
					SetPeriod(im.GetData<ulong>(0));
					break;
				}
				case 1: { // GetPeriod
					var ret = GetPeriod();
					om.SetData(0, ret);
					break;
				}
				case 2: { // SetDuty
					SetDuty(im.GetData<uint>(0));
					break;
				}
				case 3: { // GetDuty
					var ret = GetDuty();
					om.SetData(0, ret);
					break;
				}
				case 4: { // SetEnabled
					SetEnabled(im.GetData<byte>(0));
					break;
				}
				case 5: { // GetEnabled
					var ret = GetEnabled();
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IChannelSession: {im.CommandId}");
			}
		}
		
		public virtual void SetPeriod(ulong _0) => throw new NotImplementedException();
		public virtual ulong GetPeriod() => throw new NotImplementedException();
		public virtual void SetDuty(uint _0) => throw new NotImplementedException();
		public virtual uint GetDuty() => throw new NotImplementedException();
		public virtual void SetEnabled(byte _0) => throw new NotImplementedException();
		public virtual byte GetEnabled() => throw new NotImplementedException();
	}
}
