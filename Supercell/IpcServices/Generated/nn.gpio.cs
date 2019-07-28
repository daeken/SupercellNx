#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Gpio {
	[IpcService("gpio")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetPadSession
					var ret = GetPadSession(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(im.GetData<uint>(8));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3(im.GetData<uint>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 4: { // Unknown4
					Unknown4(out var _0);
					om.Initialize(0, 0, 16);
					om.SetBytes(8, _0);
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetData<byte>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // Unknown6
					Unknown6(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Gpio.IPadSession Unknown0(uint _0) => throw new NotImplementedException();
		public virtual Nn.Gpio.IPadSession GetPadSession(uint _0) => throw new NotImplementedException();
		public virtual Nn.Gpio.IPadSession Unknown2(uint _0) => throw new NotImplementedException();
		public virtual byte Unknown3(uint _0) => throw new NotImplementedException();
		public virtual void Unknown4(out byte[] _0) => throw new NotImplementedException();
		public virtual void Unknown5(byte _0, uint _1) => "Stub hit for Nn.Gpio.IManager.Unknown5 [5]".Debug();
		public virtual void Unknown6(uint _0) => "Stub hit for Nn.Gpio.IManager.Unknown6 [6]".Debug();
	}
	
	public unsafe partial class IPadSession : _Base_IPadSession {}
	public unsafe class _Base_IPadSession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetDirection
					SetDirection(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetDirection
					var ret = GetDirection();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 2: { // SetInterruptMode
					SetInterruptMode(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetInterruptMode
					var ret = GetInterruptMode();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 4: { // SetInterruptEnable
					SetInterruptEnable(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetInterruptEnable
					var ret = GetInterruptEnable();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 6: { // GetInterruptStatus
					var ret = GetInterruptStatus();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 7: { // ClearInterruptStatus
					ClearInterruptStatus();
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // SetValue
					SetValue(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // GetValue
					var ret = GetValue();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 10: { // BindInterrupt
					var ret = BindInterrupt();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 11: { // UnbindInterrupt
					UnbindInterrupt();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // SetDebounceEnabled
					SetDebounceEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetDebounceEnabled
					var ret = GetDebounceEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 14: { // SetDebounceTime
					SetDebounceTime(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetDebounceTime
					var ret = GetDebounceTime();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 16: { // SetValueForSleepState
					SetValueForSleepState(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPadSession: {im.CommandId}");
			}
		}
		
		public virtual void SetDirection(uint _0) => "Stub hit for Nn.Gpio.IPadSession.SetDirection [0]".Debug();
		public virtual uint GetDirection() => throw new NotImplementedException();
		public virtual void SetInterruptMode(uint _0) => "Stub hit for Nn.Gpio.IPadSession.SetInterruptMode [2]".Debug();
		public virtual uint GetInterruptMode() => throw new NotImplementedException();
		public virtual void SetInterruptEnable(byte _0) => "Stub hit for Nn.Gpio.IPadSession.SetInterruptEnable [4]".Debug();
		public virtual byte GetInterruptEnable() => throw new NotImplementedException();
		public virtual uint GetInterruptStatus() => throw new NotImplementedException();
		public virtual void ClearInterruptStatus() => "Stub hit for Nn.Gpio.IPadSession.ClearInterruptStatus [7]".Debug();
		public virtual void SetValue(uint _0) => "Stub hit for Nn.Gpio.IPadSession.SetValue [8]".Debug();
		public virtual uint GetValue() => throw new NotImplementedException();
		public virtual KObject BindInterrupt() => throw new NotImplementedException();
		public virtual void UnbindInterrupt() => "Stub hit for Nn.Gpio.IPadSession.UnbindInterrupt [11]".Debug();
		public virtual void SetDebounceEnabled(byte _0) => "Stub hit for Nn.Gpio.IPadSession.SetDebounceEnabled [12]".Debug();
		public virtual byte GetDebounceEnabled() => throw new NotImplementedException();
		public virtual void SetDebounceTime(uint _0) => "Stub hit for Nn.Gpio.IPadSession.SetDebounceTime [14]".Debug();
		public virtual uint GetDebounceTime() => throw new NotImplementedException();
		public virtual void SetValueForSleepState(uint _0) => "Stub hit for Nn.Gpio.IPadSession.SetValueForSleepState [16]".Debug();
	}
}
