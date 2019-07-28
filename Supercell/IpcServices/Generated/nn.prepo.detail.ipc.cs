#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Prepo.Detail.Ipc {
	[IpcService("prepo:u")]
	[IpcService("prepo:s")]
	[IpcService("prepo:m")]
	[IpcService("prepo:a")]
	public unsafe partial class IPrepoService : _Base_IPrepoService {}
	public unsafe class _Base_IPrepoService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 10100: { // SaveReport
					SaveReport(im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10101: { // SaveReportWithUser
					SaveReportWithUser(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.Pid, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10200: { // RequestImmediateTransmission
					RequestImmediateTransmission();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10300: { // GetTransmissionStatus
					var ret = GetTransmissionStatus();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 20100: { // SaveSystemReport
					SaveSystemReport(im.GetData<ulong>(8), im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20101: { // SaveSystemReportWithUser
					SaveSystemReportWithUser(im.GetBytes(8, 0x10), im.GetData<ulong>(24), im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 20200: { // SetOperationMode
					SetOperationMode(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 30100: { // ClearStorage
					ClearStorage();
					om.Initialize(0, 0, 0);
					break;
				}
				case 40100: { // IsUserAgreementCheckEnabled
					var ret = IsUserAgreementCheckEnabled();
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 40101: { // SetUserAgreementCheckEnabled
					SetUserAgreementCheckEnabled(im.GetData<byte>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 90100: { // GetStorageUsage
					GetStorageUsage(out var _0, out var _1);
					om.Initialize(0, 0, 16);
					om.SetData(8, _0);
					om.SetData(16, _1);
					break;
				}
				case 90200: { // GetStatistics
					var ret = GetStatistics(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 90201: { // GetThroughputHistory
					var ret = GetThroughputHistory(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 90300: { // GetLastUploadError
					var ret = GetLastUploadError(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPrepoService: {im.CommandId}");
			}
		}
		
		public virtual void SaveReport(ulong _0, ulong _1, Buffer<byte> _2, Buffer<byte> _3) => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.SaveReport [10100]".Debug();
		public virtual void SaveReportWithUser(byte[] _0, ulong _1, ulong _2, Buffer<byte> _3, Buffer<byte> _4) => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.SaveReportWithUser [10101]".Debug();
		public virtual void RequestImmediateTransmission() => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.RequestImmediateTransmission [10200]".Debug();
		public virtual uint GetTransmissionStatus() => throw new NotImplementedException();
		public virtual void SaveSystemReport(ulong _0, Buffer<byte> _1, Buffer<byte> _2) => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.SaveSystemReport [20100]".Debug();
		public virtual void SaveSystemReportWithUser(byte[] _0, ulong _1, Buffer<byte> _2, Buffer<byte> _3) => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.SaveSystemReportWithUser [20101]".Debug();
		public virtual void SetOperationMode(ulong _0) => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.SetOperationMode [20200]".Debug();
		public virtual void ClearStorage() => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.ClearStorage [30100]".Debug();
		public virtual byte IsUserAgreementCheckEnabled() => throw new NotImplementedException();
		public virtual void SetUserAgreementCheckEnabled(byte _0) => "Stub hit for Nn.Prepo.Detail.Ipc.IPrepoService.SetUserAgreementCheckEnabled [40101]".Debug();
		public virtual void GetStorageUsage(out ulong _0, out ulong _1) => throw new NotImplementedException();
		public virtual object GetStatistics(object _0) => throw new NotImplementedException();
		public virtual object GetThroughputHistory(object _0) => throw new NotImplementedException();
		public virtual object GetLastUploadError(object _0) => throw new NotImplementedException();
	}
}
