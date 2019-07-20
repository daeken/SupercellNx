#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Usb.Ds {
	[IpcService("usb:ds")]
	public unsafe partial class IDsService : _Base_IDsService {}
	public unsafe class _Base_IDsService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BindDevice
					BindDevice(im.GetData<uint>(0));
					break;
				}
				case 1: { // BindClientProcess
					BindClientProcess(Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 2: { // RegisterInterface
					var ret = RegisterInterface(im.GetData<byte>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // GetStateChangeEvent
					var ret = GetStateChangeEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 4: { // GetState
					var ret = GetState();
					om.SetData(0, ret);
					break;
				}
				case 5: { // ClearDeviceData
					ClearDeviceData();
					break;
				}
				case 6: { // AddUsbStringDescriptor
					var ret = AddUsbStringDescriptor(im.GetBuffer<byte>(0x5, 0));
					om.SetData(0, ret);
					break;
				}
				case 7: { // DeleteUsbStringDescriptor
					DeleteUsbStringDescriptor(im.GetData<byte>(0));
					break;
				}
				case 8: { // SetUsbDeviceDescriptor
					SetUsbDeviceDescriptor(im.GetData<Nn.Usb.UsbDeviceSpeed>(0), im.GetBuffer<Nn.Usb.UsbDeviceDescriptor>(0x5, 0));
					break;
				}
				case 9: { // SetBinaryObjectStore
					SetBinaryObjectStore(im.GetBuffer<Nn.Usb.UsbBosDescriptor>(0x5, 0));
					break;
				}
				case 10: { // Enable
					Enable();
					break;
				}
				case 11: { // Disable
					Disable();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDsService: {im.CommandId}");
			}
		}
		
		public virtual void BindDevice(uint complexId) => throw new NotImplementedException();
		public virtual void BindClientProcess(KObject _0) => throw new NotImplementedException();
		public virtual Nn.Usb.Ds.IDsInterface RegisterInterface(byte address) => throw new NotImplementedException();
		public virtual KObject GetStateChangeEvent() => throw new NotImplementedException();
		public virtual uint GetState() => throw new NotImplementedException();
		public virtual void ClearDeviceData() => throw new NotImplementedException();
		public virtual byte AddUsbStringDescriptor(Buffer<byte> string_descriptor) => throw new NotImplementedException();
		public virtual void DeleteUsbStringDescriptor(byte index) => throw new NotImplementedException();
		public virtual void SetUsbDeviceDescriptor(Nn.Usb.UsbDeviceSpeed speed_mode, Buffer<Nn.Usb.UsbDeviceDescriptor> descriptor) => throw new NotImplementedException();
		public virtual void SetBinaryObjectStore(Buffer<Nn.Usb.UsbBosDescriptor> _0) => throw new NotImplementedException();
		public virtual void Enable() => throw new NotImplementedException();
		public virtual void Disable() => throw new NotImplementedException();
	}
	
	public unsafe partial class IDsEndpoint : _Base_IDsEndpoint {}
	public unsafe class _Base_IDsEndpoint : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // PostBufferAsync
					var ret = PostBufferAsync(im.GetData<uint>(0), im.GetData<ulong>(8));
					om.SetData(0, ret);
					break;
				}
				case 1: { // Cancel
					Cancel();
					break;
				}
				case 2: { // GetCompletionEvent
					var ret = GetCompletionEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 3: { // GetReportData
					GetReportData((Nn.Usb.UsbReportEntry*) om.GetDataPointer(0), out var _1);
					om.SetData(0, _1);
					break;
				}
				case 4: { // Stall
					Stall();
					break;
				}
				case 5: { // SetZlt
					SetZlt(im.GetData<bool>(0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDsEndpoint: {im.CommandId}");
			}
		}
		
		public virtual uint PostBufferAsync(uint size, ulong buffer) => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
		public virtual KObject GetCompletionEvent() => throw new NotImplementedException();
		public virtual void GetReportData( Nn.Usb.UsbReportEntry* entries, out uint report_count) => throw new NotImplementedException();
		public virtual void Stall() => throw new NotImplementedException();
		public virtual void SetZlt(bool _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IDsInterface : _Base_IDsInterface {}
	public unsafe class _Base_IDsInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // RegisterEndpoint
					var ret = RegisterEndpoint(im.GetData<byte>(0));
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // GetSetupEvent
					var ret = GetSetupEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 2: { // GetSetupPacket
					GetSetupPacket(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // EnableInterface
					EnableInterface();
					break;
				}
				case 4: { // DisableInterface
					DisableInterface();
					break;
				}
				case 5: { // CtrlInPostBufferAsync
					var ret = CtrlInPostBufferAsync(im.GetData<uint>(0), im.GetData<ulong>(8));
					om.SetData(0, ret);
					break;
				}
				case 6: { // CtrlOutPostBufferAsync
					var ret = CtrlOutPostBufferAsync(im.GetData<uint>(0), im.GetData<ulong>(8));
					om.SetData(0, ret);
					break;
				}
				case 7: { // GetCtrlInCompletionEvent
					var ret = GetCtrlInCompletionEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 8: { // GetCtrlInReportData
					GetCtrlInReportData((Nn.Usb.UsbReportEntry*) om.GetDataPointer(0), out var _1);
					om.SetData(0, _1);
					break;
				}
				case 9: { // GetCtrlOutCompletionEvent
					var ret = GetCtrlOutCompletionEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 10: { // GetCtrlOutReportData
					GetCtrlOutReportData((Nn.Usb.UsbReportEntry*) om.GetDataPointer(0), out var _1);
					om.SetData(0, _1);
					break;
				}
				case 11: { // StallCtrl
					StallCtrl();
					break;
				}
				case 12: { // AppendConfigurationData
					AppendConfigurationData(im.GetData<byte>(0), im.GetData<Nn.Usb.UsbDeviceSpeed>(4), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IDsInterface: {im.CommandId}");
			}
		}
		
		public virtual Nn.Usb.Ds.IDsEndpoint RegisterEndpoint(byte address) => throw new NotImplementedException();
		public virtual KObject GetSetupEvent() => throw new NotImplementedException();
		public virtual void GetSetupPacket(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void EnableInterface() => throw new NotImplementedException();
		public virtual void DisableInterface() => throw new NotImplementedException();
		public virtual uint CtrlInPostBufferAsync(uint size, ulong buffer) => throw new NotImplementedException();
		public virtual uint CtrlOutPostBufferAsync(uint size, ulong buffer) => throw new NotImplementedException();
		public virtual KObject GetCtrlInCompletionEvent() => throw new NotImplementedException();
		public virtual void GetCtrlInReportData( Nn.Usb.UsbReportEntry* entries, out uint report_count) => throw new NotImplementedException();
		public virtual KObject GetCtrlOutCompletionEvent() => throw new NotImplementedException();
		public virtual void GetCtrlOutReportData( Nn.Usb.UsbReportEntry* entries, out uint report_count) => throw new NotImplementedException();
		public virtual void StallCtrl() => throw new NotImplementedException();
		public virtual void AppendConfigurationData(byte interface_number, Nn.Usb.UsbDeviceSpeed speed_mode, Buffer<byte> descriptor) => throw new NotImplementedException();
	}
}
