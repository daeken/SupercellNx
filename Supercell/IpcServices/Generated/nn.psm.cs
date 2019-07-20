#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Psm {
	[IpcService("psm")]
	public unsafe partial class IPsmServer : _Base_IPsmServer {}
	public unsafe class _Base_IPsmServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetBatteryChargePercentage
					var ret = GetBatteryChargePercentage();
					break;
				}
				case 1: { // GetChargerType
					var ret = GetChargerType();
					break;
				}
				case 2: { // EnableBatteryCharging
					EnableBatteryCharging();
					break;
				}
				case 3: { // DisableBatteryCharging
					DisableBatteryCharging();
					break;
				}
				case 4: { // IsBatteryChargingEnabled
					var ret = IsBatteryChargingEnabled();
					break;
				}
				case 5: { // AcquireControllerPowerSupply
					AcquireControllerPowerSupply();
					break;
				}
				case 6: { // ReleaseControllerPowerSupply
					ReleaseControllerPowerSupply();
					break;
				}
				case 7: { // OpenSession
					var ret = OpenSession();
					om.Move(0, ret.Handle);
					break;
				}
				case 8: { // EnableEnoughPowerChargeEmulation
					EnableEnoughPowerChargeEmulation();
					break;
				}
				case 9: { // DisableEnoughPowerChargeEmulation
					DisableEnoughPowerChargeEmulation();
					break;
				}
				case 10: { // EnableFastBatteryCharging
					EnableFastBatteryCharging();
					break;
				}
				case 11: { // DisableFastBatteryCharging
					DisableFastBatteryCharging();
					break;
				}
				case 12: { // GetBatteryVoltageState
					var ret = GetBatteryVoltageState();
					break;
				}
				case 13: { // GetRawBatteryChargePercentage
					var ret = GetRawBatteryChargePercentage();
					break;
				}
				case 14: { // IsEnoughPowerSupplied
					var ret = IsEnoughPowerSupplied();
					break;
				}
				case 15: { // GetBatteryAgePercentage
					var ret = GetBatteryAgePercentage();
					break;
				}
				case 16: { // GetBatteryChargeInfoEvent
					var ret = GetBatteryChargeInfoEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 17: { // GetBatteryChargeInfoFields
					var ret = GetBatteryChargeInfoFields();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPsmServer: {im.CommandId}");
			}
		}
		
		public virtual object GetBatteryChargePercentage() => throw new NotImplementedException();
		public virtual object GetChargerType() => throw new NotImplementedException();
		public virtual void EnableBatteryCharging() => throw new NotImplementedException();
		public virtual void DisableBatteryCharging() => throw new NotImplementedException();
		public virtual object IsBatteryChargingEnabled() => throw new NotImplementedException();
		public virtual void AcquireControllerPowerSupply() => throw new NotImplementedException();
		public virtual void ReleaseControllerPowerSupply() => throw new NotImplementedException();
		public virtual Nn.Psm.IPsmSession OpenSession() => throw new NotImplementedException();
		public virtual void EnableEnoughPowerChargeEmulation() => throw new NotImplementedException();
		public virtual void DisableEnoughPowerChargeEmulation() => throw new NotImplementedException();
		public virtual void EnableFastBatteryCharging() => throw new NotImplementedException();
		public virtual void DisableFastBatteryCharging() => throw new NotImplementedException();
		public virtual object GetBatteryVoltageState() => throw new NotImplementedException();
		public virtual object GetRawBatteryChargePercentage() => throw new NotImplementedException();
		public virtual object IsEnoughPowerSupplied() => throw new NotImplementedException();
		public virtual object GetBatteryAgePercentage() => throw new NotImplementedException();
		public virtual KObject GetBatteryChargeInfoEvent() => throw new NotImplementedException();
		public virtual object GetBatteryChargeInfoFields() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPsmSession : _Base_IPsmSession {}
	public unsafe class _Base_IPsmSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BindStateChangeEvent
					var ret = BindStateChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // UnbindStateChangeEvent
					UnbindStateChangeEvent();
					break;
				}
				case 2: { // SetChargerTypeChangeEventEnabled
					SetChargerTypeChangeEventEnabled(null);
					break;
				}
				case 3: { // SetPowerSupplyChangeEventEnabled
					SetPowerSupplyChangeEventEnabled(null);
					break;
				}
				case 4: { // SetBatteryVoltageStateChangeEventEnabled
					SetBatteryVoltageStateChangeEventEnabled(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPsmSession: {im.CommandId}");
			}
		}
		
		public virtual KObject BindStateChangeEvent() => throw new NotImplementedException();
		public virtual void UnbindStateChangeEvent() => throw new NotImplementedException();
		public virtual void SetChargerTypeChangeEventEnabled(object _0) => throw new NotImplementedException();
		public virtual void SetPowerSupplyChangeEventEnabled(object _0) => throw new NotImplementedException();
		public virtual void SetBatteryVoltageStateChangeEventEnabled(object _0) => throw new NotImplementedException();
	}
}
