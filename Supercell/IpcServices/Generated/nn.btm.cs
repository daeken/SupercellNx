#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Btm {
	[IpcService("btm")]
	public unsafe partial class IBtm : _Base_IBtm {}
	public unsafe class _Base_IBtm : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					break;
				}
				case 2: { // RegisterSystemEventForConnectedDeviceConditionImpl
					RegisterSystemEventForConnectedDeviceConditionImpl(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 6: { // Unknown6
					Unknown6(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(null);
					break;
				}
				case 8: { // RegisterSystemEventForRegisteredDeviceInfoImpl
					RegisterSystemEventForRegisteredDeviceInfoImpl(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 9: { // Unknown9
					Unknown9(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 10: { // Unknown10
					Unknown10(null);
					break;
				}
				case 11: { // Unknown11
					Unknown11(null);
					break;
				}
				case 12: { // Unknown12
					Unknown12(null);
					break;
				}
				case 13: { // Unknown13
					Unknown13(null);
					break;
				}
				case 14: { // EnableRadioImpl
					EnableRadioImpl();
					break;
				}
				case 15: { // DisableRadioImpl
					DisableRadioImpl();
					break;
				}
				case 16: { // Unknown16
					Unknown16(null);
					break;
				}
				case 17: { // Unknown17
					Unknown17(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 18: { // Unknown18
					Unknown18(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 19: { // Unknown19
					Unknown19(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 20: { // Unknown20
					var ret = Unknown20();
					break;
				}
				case 21: { // Unknown21
					Unknown21(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBtm: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0() => throw new NotImplementedException();
		public virtual object Unknown1() => throw new NotImplementedException();
		public virtual void RegisterSystemEventForConnectedDeviceConditionImpl(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual void Unknown3(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown6(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(object _0) => throw new NotImplementedException();
		public virtual void RegisterSystemEventForRegisteredDeviceInfoImpl(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual void Unknown9(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown10(object _0) => throw new NotImplementedException();
		public virtual void Unknown11(object _0) => throw new NotImplementedException();
		public virtual void Unknown12(object _0) => throw new NotImplementedException();
		public virtual void Unknown13(object _0) => throw new NotImplementedException();
		public virtual void EnableRadioImpl() => throw new NotImplementedException();
		public virtual void DisableRadioImpl() => throw new NotImplementedException();
		public virtual void Unknown16(object _0) => throw new NotImplementedException();
		public virtual void Unknown17(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown18(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual void Unknown19(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual object Unknown20() => throw new NotImplementedException();
		public virtual void Unknown21(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("btm:dbg")]
	public unsafe partial class IBtmDebug : _Base_IBtmDebug {}
	public unsafe class _Base_IBtmDebug : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RegisterSystemEventForDiscoveryImpl
					RegisterSystemEventForDiscoveryImpl(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 1: { // Unknown1
					Unknown1();
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					break;
				}
				case 3: { // Unknown3
					Unknown3(im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 6: { // Unknown6
					Unknown6(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(null);
					break;
				}
				case 8: { // Unknown8
					Unknown8(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBtmDebug: {im.CommandId}");
			}
		}
		
		public virtual void RegisterSystemEventForDiscoveryImpl(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual void Unknown1() => throw new NotImplementedException();
		public virtual void Unknown2() => throw new NotImplementedException();
		public virtual void Unknown3(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual void Unknown6(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(object _0) => throw new NotImplementedException();
		public virtual void Unknown8(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("btm:sys")]
	public unsafe partial class IBtmSystem : _Base_IBtmSystem {}
	public unsafe class _Base_IBtmSystem : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetCoreImpl
					var ret = GetCoreImpl();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBtmSystem: {im.CommandId}");
			}
		}
		
		public virtual Nn.Btm.IBtmSystemCore GetCoreImpl() => throw new NotImplementedException();
	}
	
	public unsafe partial class IBtmSystemCore : _Base_IBtmSystemCore {}
	public unsafe class _Base_IBtmSystemCore : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // StartGamepadPairingImpl
					StartGamepadPairingImpl();
					break;
				}
				case 1: { // CancelGamepadPairingImpl
					CancelGamepadPairingImpl();
					break;
				}
				case 2: { // ClearGamepadPairingDatabaseImpl
					ClearGamepadPairingDatabaseImpl();
					break;
				}
				case 3: { // GetPairedGamepadCountImpl
					var ret = GetPairedGamepadCountImpl();
					break;
				}
				case 4: { // EnableRadioImpl
					EnableRadioImpl();
					break;
				}
				case 5: { // DisableRadioImpl
					DisableRadioImpl();
					break;
				}
				case 6: { // GetRadioOnOffImpl
					var ret = GetRadioOnOffImpl();
					break;
				}
				case 7: { // AcquireRadioEventImpl
					AcquireRadioEventImpl(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 8: { // AcquireGamepadPairingEventImpl
					AcquireGamepadPairingEventImpl(out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 9: { // IsGamepadPairingStartedImpl
					var ret = IsGamepadPairingStartedImpl();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IBtmSystemCore: {im.CommandId}");
			}
		}
		
		public virtual void StartGamepadPairingImpl() => throw new NotImplementedException();
		public virtual void CancelGamepadPairingImpl() => throw new NotImplementedException();
		public virtual void ClearGamepadPairingDatabaseImpl() => throw new NotImplementedException();
		public virtual object GetPairedGamepadCountImpl() => throw new NotImplementedException();
		public virtual void EnableRadioImpl() => throw new NotImplementedException();
		public virtual void DisableRadioImpl() => throw new NotImplementedException();
		public virtual object GetRadioOnOffImpl() => throw new NotImplementedException();
		public virtual void AcquireRadioEventImpl(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual void AcquireGamepadPairingEventImpl(out object _0, out KObject _1) => throw new NotImplementedException();
		public virtual object IsGamepadPairingStartedImpl() => throw new NotImplementedException();
	}
}
