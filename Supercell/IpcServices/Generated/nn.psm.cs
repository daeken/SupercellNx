#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Psm {
	[IpcService("psm")]
	public unsafe partial class IPsmServer : _Base_IPsmServer {}
	public unsafe class _Base_IPsmServer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetBatteryChargePercentage
					var ret = GetBatteryChargePercentage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetChargerType
					var ret = GetChargerType();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // EnableBatteryCharging
					EnableBatteryCharging();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // DisableBatteryCharging
					DisableBatteryCharging();
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // IsBatteryChargingEnabled
					var ret = IsBatteryChargingEnabled();
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // AcquireControllerPowerSupply
					AcquireControllerPowerSupply();
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // ReleaseControllerPowerSupply
					ReleaseControllerPowerSupply();
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // OpenSession
					var ret = OpenSession();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 8: { // EnableEnoughPowerChargeEmulation
					EnableEnoughPowerChargeEmulation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // DisableEnoughPowerChargeEmulation
					DisableEnoughPowerChargeEmulation();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // EnableFastBatteryCharging
					EnableFastBatteryCharging();
					om.Initialize(0, 0, 0);
					break;
				}
				case 11: { // DisableFastBatteryCharging
					DisableFastBatteryCharging();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // GetBatteryVoltageState
					var ret = GetBatteryVoltageState();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // GetRawBatteryChargePercentage
					var ret = GetRawBatteryChargePercentage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 14: { // IsEnoughPowerSupplied
					var ret = IsEnoughPowerSupplied();
					om.Initialize(0, 0, 0);
					break;
				}
				case 15: { // GetBatteryAgePercentage
					var ret = GetBatteryAgePercentage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetBatteryChargeInfoEvent
					var ret = GetBatteryChargeInfoEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 17: { // GetBatteryChargeInfoFields
					var ret = GetBatteryChargeInfoFields();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPsmServer: {im.CommandId}");
			}
		}
		
		public virtual object GetBatteryChargePercentage() => throw new NotImplementedException();
		public virtual object GetChargerType() => throw new NotImplementedException();
		public virtual void EnableBatteryCharging() => "Stub hit for Nn.Psm.IPsmServer.EnableBatteryCharging [2]".Debug();
		public virtual void DisableBatteryCharging() => "Stub hit for Nn.Psm.IPsmServer.DisableBatteryCharging [3]".Debug();
		public virtual object IsBatteryChargingEnabled() => throw new NotImplementedException();
		public virtual void AcquireControllerPowerSupply() => "Stub hit for Nn.Psm.IPsmServer.AcquireControllerPowerSupply [5]".Debug();
		public virtual void ReleaseControllerPowerSupply() => "Stub hit for Nn.Psm.IPsmServer.ReleaseControllerPowerSupply [6]".Debug();
		public virtual Nn.Psm.IPsmSession OpenSession() => throw new NotImplementedException();
		public virtual void EnableEnoughPowerChargeEmulation() => "Stub hit for Nn.Psm.IPsmServer.EnableEnoughPowerChargeEmulation [8]".Debug();
		public virtual void DisableEnoughPowerChargeEmulation() => "Stub hit for Nn.Psm.IPsmServer.DisableEnoughPowerChargeEmulation [9]".Debug();
		public virtual void EnableFastBatteryCharging() => "Stub hit for Nn.Psm.IPsmServer.EnableFastBatteryCharging [10]".Debug();
		public virtual void DisableFastBatteryCharging() => "Stub hit for Nn.Psm.IPsmServer.DisableFastBatteryCharging [11]".Debug();
		public virtual object GetBatteryVoltageState() => throw new NotImplementedException();
		public virtual object GetRawBatteryChargePercentage() => throw new NotImplementedException();
		public virtual object IsEnoughPowerSupplied() => throw new NotImplementedException();
		public virtual object GetBatteryAgePercentage() => throw new NotImplementedException();
		public virtual KObject GetBatteryChargeInfoEvent() => throw new NotImplementedException();
		public virtual object GetBatteryChargeInfoFields() => throw new NotImplementedException();
	}
	
	public unsafe partial class IPsmSession : _Base_IPsmSession {}
	public unsafe class _Base_IPsmSession : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BindStateChangeEvent
					var ret = BindStateChangeEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // UnbindStateChangeEvent
					UnbindStateChangeEvent();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // SetChargerTypeChangeEventEnabled
					SetChargerTypeChangeEventEnabled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // SetPowerSupplyChangeEventEnabled
					SetPowerSupplyChangeEventEnabled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // SetBatteryVoltageStateChangeEventEnabled
					SetBatteryVoltageStateChangeEventEnabled(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPsmSession: {im.CommandId}");
			}
		}
		
		public virtual KObject BindStateChangeEvent() => throw new NotImplementedException();
		public virtual void UnbindStateChangeEvent() => "Stub hit for Nn.Psm.IPsmSession.UnbindStateChangeEvent [1]".Debug();
		public virtual void SetChargerTypeChangeEventEnabled(object _0) => "Stub hit for Nn.Psm.IPsmSession.SetChargerTypeChangeEventEnabled [2]".Debug();
		public virtual void SetPowerSupplyChangeEventEnabled(object _0) => "Stub hit for Nn.Psm.IPsmSession.SetPowerSupplyChangeEventEnabled [3]".Debug();
		public virtual void SetBatteryVoltageStateChangeEventEnabled(object _0) => "Stub hit for Nn.Psm.IPsmSession.SetBatteryVoltageStateChangeEventEnabled [4]".Debug();
	}
}
