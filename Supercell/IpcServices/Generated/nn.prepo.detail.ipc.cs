#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Prepo.Detail.Ipc {
	[IpcService("prepo:u")]
	[IpcService("prepo:s")]
	[IpcService("prepo:m")]
	[IpcService("prepo:a")]
	public unsafe partial class IPrepoService : _Base_IPrepoService {}
	public unsafe class _Base_IPrepoService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 10100: { // SaveReport
					SaveReport(im.GetData<ulong>(0), im.Pid, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 10101: { // SaveReportWithUser
					SaveReportWithUser(im.GetBytes(0, 0x10), im.GetData<ulong>(16), im.Pid, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 10200: { // RequestImmediateTransmission
					RequestImmediateTransmission();
					break;
				}
				case 10300: { // GetTransmissionStatus
					var ret = GetTransmissionStatus();
					om.SetData(0, ret);
					break;
				}
				case 20100: { // SaveSystemReport
					SaveSystemReport(im.GetData<ulong>(0), im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 20101: { // SaveSystemReportWithUser
					SaveSystemReportWithUser(im.GetBytes(0, 0x10), im.GetData<ulong>(16), im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 20200: { // SetOperationMode
					SetOperationMode(im.GetData<ulong>(0));
					break;
				}
				case 30100: { // ClearStorage
					ClearStorage();
					break;
				}
				case 40100: { // IsUserAgreementCheckEnabled
					var ret = IsUserAgreementCheckEnabled();
					om.SetData(0, ret);
					break;
				}
				case 40101: { // SetUserAgreementCheckEnabled
					SetUserAgreementCheckEnabled(im.GetData<byte>(0));
					break;
				}
				case 90100: { // GetStorageUsage
					GetStorageUsage(out var _0, out var _1);
					om.SetData(0, _0);
					om.SetData(8, _1);
					break;
				}
				case 90200: { // GetStatistics
					var ret = GetStatistics(null);
					break;
				}
				case 90201: { // GetThroughputHistory
					var ret = GetThroughputHistory(null);
					break;
				}
				case 90300: { // GetLastUploadError
					var ret = GetLastUploadError(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPrepoService: {im.CommandId}");
			}
		}
		
		public virtual void SaveReport(ulong _0, ulong _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void SaveReportWithUser(byte[] _0, ulong _1, ulong _2, Buffer<byte> _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void RequestImmediateTransmission() => throw new NotImplementedException();
		public virtual uint GetTransmissionStatus() => throw new NotImplementedException();
		public virtual void SaveSystemReport(ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SaveSystemReportWithUser(byte[] _0, ulong _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void SetOperationMode(ulong _0) => throw new NotImplementedException();
		public virtual void ClearStorage() => throw new NotImplementedException();
		public virtual byte IsUserAgreementCheckEnabled() => throw new NotImplementedException();
		public virtual void SetUserAgreementCheckEnabled(byte _0) => throw new NotImplementedException();
		public virtual void GetStorageUsage(out ulong _0, out ulong _1) => throw new NotImplementedException();
		public virtual object GetStatistics(object _0) => throw new NotImplementedException();
		public virtual object GetThroughputHistory(object _0) => throw new NotImplementedException();
		public virtual object GetLastUploadError(object _0) => throw new NotImplementedException();
	}
}
