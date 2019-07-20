#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Gpio {
	[IpcService("gpio")]
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
				case 2: { // OpenSessionForTest
					var ret = OpenSessionForTest(im.GetData<uint>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // IsWakeEventActive
					var ret = IsWakeEventActive(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 4: { // GetWakeEventActiveFlagSet
					GetWakeEventActiveFlagSet(out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 5: { // SetWakeEventActiveFlagSetForDebug
					SetWakeEventActiveFlagSetForDebug(im.GetData<byte>(0), im.GetData<uint>(4));
					break;
				}
				case 6: { // SetWakePinDebugMode
					SetWakePinDebugMode(im.GetData<uint>(0));
					break;
				}
				case 7: { // OpenSession2
					var ret = OpenSession2(null);
					break;
				}
				case 8: { // IsWakeEventActive2
					var ret = IsWakeEventActive2(null);
					break;
				}
				case 9: { // SetWakeEventActiveFlagSetForDebug2
					var ret = SetWakeEventActiveFlagSetForDebug2(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Gpio.IPadSession OpenSessionForDev(uint _0) => throw new NotImplementedException();
		public virtual Nn.Gpio.IPadSession OpenSession(uint _0) => throw new NotImplementedException();
		public virtual Nn.Gpio.IPadSession OpenSessionForTest(uint _0) => throw new NotImplementedException();
		public virtual byte IsWakeEventActive(uint _0) => throw new NotImplementedException();
		public virtual void GetWakeEventActiveFlagSet(out byte[] _0) => throw new NotImplementedException();
		public virtual void SetWakeEventActiveFlagSetForDebug(byte _0, uint _1) => throw new NotImplementedException();
		public virtual void SetWakePinDebugMode(uint _0) => throw new NotImplementedException();
		public virtual object OpenSession2(object _0) => throw new NotImplementedException();
		public virtual object IsWakeEventActive2(object _0) => throw new NotImplementedException();
		public virtual object SetWakeEventActiveFlagSetForDebug2(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IPadSession : _Base_IPadSession {}
	public unsafe class _Base_IPadSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetDirection
					SetDirection(im.GetData<uint>(0));
					break;
				}
				case 1: { // GetDirection
					var ret = GetDirection();
					om.SetData(0, ret);
					break;
				}
				case 2: { // SetInterruptMode
					SetInterruptMode(im.GetData<uint>(0));
					break;
				}
				case 3: { // GetInterruptMode
					var ret = GetInterruptMode();
					om.SetData(0, ret);
					break;
				}
				case 4: { // SetInterruptEnable
					SetInterruptEnable(im.GetData<byte>(0));
					break;
				}
				case 5: { // GetInterruptEnable
					var ret = GetInterruptEnable();
					om.SetData(0, ret);
					break;
				}
				case 6: { // GetInterruptStatus
					var ret = GetInterruptStatus();
					om.SetData(0, ret);
					break;
				}
				case 7: { // ClearInterruptStatus
					ClearInterruptStatus();
					break;
				}
				case 8: { // SetValue
					SetValue(im.GetData<uint>(0));
					break;
				}
				case 9: { // GetValue
					var ret = GetValue();
					om.SetData(0, ret);
					break;
				}
				case 10: { // BindInterrupt
					var ret = BindInterrupt();
					om.Copy(0, ret.Handle);
					break;
				}
				case 11: { // UnbindInterrupt
					UnbindInterrupt();
					break;
				}
				case 12: { // SetDebounceEnabled
					SetDebounceEnabled(im.GetData<byte>(0));
					break;
				}
				case 13: { // GetDebounceEnabled
					var ret = GetDebounceEnabled();
					om.SetData(0, ret);
					break;
				}
				case 14: { // SetDebounceTime
					SetDebounceTime(im.GetData<uint>(0));
					break;
				}
				case 15: { // GetDebounceTime
					var ret = GetDebounceTime();
					om.SetData(0, ret);
					break;
				}
				case 16: { // SetValueForSleepState
					SetValueForSleepState(im.GetData<uint>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPadSession: {im.CommandId}");
			}
		}
		
		public virtual void SetDirection(uint _0) => throw new NotImplementedException();
		public virtual uint GetDirection() => throw new NotImplementedException();
		public virtual void SetInterruptMode(uint _0) => throw new NotImplementedException();
		public virtual uint GetInterruptMode() => throw new NotImplementedException();
		public virtual void SetInterruptEnable(byte _0) => throw new NotImplementedException();
		public virtual byte GetInterruptEnable() => throw new NotImplementedException();
		public virtual uint GetInterruptStatus() => throw new NotImplementedException();
		public virtual void ClearInterruptStatus() => throw new NotImplementedException();
		public virtual void SetValue(uint _0) => throw new NotImplementedException();
		public virtual uint GetValue() => throw new NotImplementedException();
		public virtual KObject BindInterrupt() => throw new NotImplementedException();
		public virtual void UnbindInterrupt() => throw new NotImplementedException();
		public virtual void SetDebounceEnabled(byte _0) => throw new NotImplementedException();
		public virtual byte GetDebounceEnabled() => throw new NotImplementedException();
		public virtual void SetDebounceTime(uint _0) => throw new NotImplementedException();
		public virtual uint GetDebounceTime() => throw new NotImplementedException();
		public virtual void SetValueForSleepState(uint _0) => throw new NotImplementedException();
	}
}
