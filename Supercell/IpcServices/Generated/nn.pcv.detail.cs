#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Pcv.Detail {
	[IpcService("pcv")]
	public unsafe partial class IPcvService : _Base_IPcvService {}
	public unsafe class _Base_IPcvService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetPowerEnabled
					SetPowerEnabled(im.GetData<byte>(0), im.GetData<uint>(4));
					break;
				}
				case 1: { // SetClockEnabled
					SetClockEnabled(im.GetData<byte>(0), im.GetData<uint>(4));
					break;
				}
				case 2: { // SetClockRate
					SetClockRate(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 3: { // GetClockRate
					var ret = GetClockRate(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 4: { // GetState
					var ret = GetState(im.GetData<uint>(0));
					break;
				}
				case 5: { // GetPossibleClockRates
					GetPossibleClockRates(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, out var _1, im.GetBuffer<uint>(0xA, 0));
					om.SetData(0, _0);
					om.SetData(4, _1);
					break;
				}
				case 6: { // SetMinVClockRate
					SetMinVClockRate(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 7: { // SetReset
					SetReset(im.GetData<byte>(0), im.GetData<uint>(4));
					break;
				}
				case 8: { // SetVoltageEnabled
					SetVoltageEnabled(im.GetData<byte>(0), im.GetData<uint>(4));
					break;
				}
				case 9: { // GetVoltageEnabled
					var ret = GetVoltageEnabled(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 10: { // GetVoltageRange
					GetVoltageRange(im.GetData<uint>(0), out var _0, out var _1, out var _2);
					om.SetData(0, _0);
					om.SetData(4, _1);
					om.SetData(8, _2);
					break;
				}
				case 11: { // SetVoltageValue
					SetVoltageValue(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 12: { // GetVoltageValue
					var ret = GetVoltageValue(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 13: { // GetTemperatureThresholds
					GetTemperatureThresholds(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 14: { // SetTemperature
					SetTemperature(im.GetData<uint>(0));
					break;
				}
				case 15: { // Initialize
					Initialize();
					break;
				}
				case 16: { // IsInitialized
					var ret = IsInitialized();
					om.SetData(0, ret);
					break;
				}
				case 17: { // Finalize
					Finalize();
					break;
				}
				case 18: { // PowerOn
					PowerOn(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 19: { // PowerOff
					PowerOff(im.GetData<uint>(0));
					break;
				}
				case 20: { // ChangeVoltage
					ChangeVoltage(im.GetData<uint>(0), im.GetData<uint>(4));
					break;
				}
				case 21: { // GetPowerClockInfoEvent
					var ret = GetPowerClockInfoEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 22: { // GetOscillatorClock
					var ret = GetOscillatorClock();
					om.SetData(0, ret);
					break;
				}
				case 23: { // GetDvfsTable
					GetDvfsTable(im.GetData<uint>(0), im.GetData<uint>(4), out var _0, im.GetBuffer<uint>(0xA, 0), im.GetBuffer<uint>(0xA, 1));
					om.SetData(0, _0);
					break;
				}
				case 24: { // GetModuleStateTable
					GetModuleStateTable(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 25: { // GetPowerDomainStateTable
					GetPowerDomainStateTable(im.GetData<uint>(0), out var _0, im.GetBuffer<byte>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				case 26: { // GetFuseInfo
					GetFuseInfo(im.GetData<uint>(0), out var _0, im.GetBuffer<uint>(0xA, 0));
					om.SetData(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPcvService: {im.CommandId}");
			}
		}
		
		public virtual void SetPowerEnabled(byte _0, uint _1) => throw new NotImplementedException();
		public virtual void SetClockEnabled(byte _0, uint _1) => throw new NotImplementedException();
		public virtual void SetClockRate(uint _0, uint _1) => throw new NotImplementedException();
		public virtual uint GetClockRate(uint _0) => throw new NotImplementedException();
		public virtual object GetState(uint _0) => throw new NotImplementedException();
		public virtual void GetPossibleClockRates(uint _0, uint _1, out uint _2, out uint _3, Buffer<uint> _4) => throw new NotImplementedException();
		public virtual void SetMinVClockRate(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void SetReset(byte _0, uint _1) => throw new NotImplementedException();
		public virtual void SetVoltageEnabled(byte _0, uint _1) => throw new NotImplementedException();
		public virtual byte GetVoltageEnabled(uint _0) => throw new NotImplementedException();
		public virtual void GetVoltageRange(uint _0, out uint _1, out uint _2, out uint _3) => throw new NotImplementedException();
		public virtual void SetVoltageValue(uint _0, uint _1) => throw new NotImplementedException();
		public virtual uint GetVoltageValue(uint _0) => throw new NotImplementedException();
		public virtual void GetTemperatureThresholds(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SetTemperature(uint _0) => throw new NotImplementedException();
		public virtual void Initialize() => throw new NotImplementedException();
		public virtual byte IsInitialized() => throw new NotImplementedException();
		public virtual void Finalize() => throw new NotImplementedException();
		public virtual void PowerOn(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void PowerOff(uint _0) => throw new NotImplementedException();
		public virtual void ChangeVoltage(uint _0, uint _1) => throw new NotImplementedException();
		public virtual KObject GetPowerClockInfoEvent() => throw new NotImplementedException();
		public virtual uint GetOscillatorClock() => throw new NotImplementedException();
		public virtual void GetDvfsTable(uint _0, uint _1, out uint _2, Buffer<uint> _3, Buffer<uint> _4) => throw new NotImplementedException();
		public virtual void GetModuleStateTable(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetPowerDomainStateTable(uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetFuseInfo(uint _0, out uint _1, Buffer<uint> _2) => throw new NotImplementedException();
	}
}
