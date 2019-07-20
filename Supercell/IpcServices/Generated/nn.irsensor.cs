#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Irsensor {
	[IpcService("irs")]
	public unsafe partial class IIrSensorServer : _Base_IIrSensorServer {}
	public unsafe class _Base_IIrSensorServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 302: { // ActivateIrsensor
					ActivateIrsensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 303: { // DeactivateIrsensor
					DeactivateIrsensor(im.GetData<ulong>(0), im.Pid);
					break;
				}
				case 304: { // GetIrsensorSharedMemoryHandle
					var ret = GetIrsensorSharedMemoryHandle(im.GetData<ulong>(0), im.Pid);
					om.Copy(0, ret.Handle);
					break;
				}
				case 305: { // StopImageProcessor
					StopImageProcessor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 306: { // RunMomentProcessor
					RunMomentProcessor(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetBytes(16, 0x20), im.Pid);
					break;
				}
				case 307: { // RunClusteringProcessor
					RunClusteringProcessor(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetBytes(16, 0x28), im.Pid);
					break;
				}
				case 308: { // RunImageTransferProcessor
					RunImageTransferProcessor(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetBytes(16, 0x18), im.GetData<ulong>(40), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 309: { // GetImageTransferProcessorState
					GetImageTransferProcessorState(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid, out var _0, im.GetBuffer<byte>(0x6, 0));
					om.SetBytes(0, _0);
					break;
				}
				case 310: { // RunTeraPluginProcessor
					RunTeraPluginProcessor(im.GetData<uint>(0), im.GetBytes(4, 0x8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 311: { // GetNpadIrCameraHandle
					var ret = GetNpadIrCameraHandle(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 312: { // RunPointingProcessor
					RunPointingProcessor(im.GetData<uint>(0), im.GetBytes(4, 0xC), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 313: { // SuspendImageProcessor
					SuspendImageProcessor(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 314: { // CheckFirmwareVersion
					CheckFirmwareVersion(im.GetData<uint>(0), im.GetBytes(4, 0x4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 315: { // SetFunctionLevel
					SetFunctionLevel(im.GetData<uint>(0), im.GetBytes(4, 0x4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 316: { // RunImageTransferExProcessor
					RunImageTransferExProcessor(im.GetData<uint>(0), im.GetData<ulong>(8), im.GetBytes(16, 0x20), im.GetData<ulong>(48), im.Pid, Kernel.Get<KObject>(im.GetCopy(0)));
					break;
				}
				case 317: { // RunIrLedProcessor
					RunIrLedProcessor(im.GetData<uint>(0), im.GetBytes(4, 0x8), im.GetData<ulong>(16), im.Pid);
					break;
				}
				case 318: { // StopImageProcessorAsync
					StopImageProcessorAsync(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 319: { // ActivateIrsensorWithFunctionLevel
					ActivateIrsensorWithFunctionLevel(im.GetBytes(0, 0x4), im.GetData<ulong>(8), im.Pid);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IIrSensorServer: {im.CommandId}");
			}
		}
		
		public virtual void ActivateIrsensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void DeactivateIrsensor(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual KObject GetIrsensorSharedMemoryHandle(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void StopImageProcessor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void RunMomentProcessor(uint _0, ulong _1, byte[] _2, ulong _3) => throw new NotImplementedException();
		public virtual void RunClusteringProcessor(uint _0, ulong _1, byte[] _2, ulong _3) => throw new NotImplementedException();
		public virtual void RunImageTransferProcessor(uint _0, ulong _1, byte[] _2, ulong _3, ulong _4, KObject _5) => throw new NotImplementedException();
		public virtual void GetImageTransferProcessorState(uint _0, ulong _1, ulong _2, out byte[] _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual void RunTeraPluginProcessor(uint _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual uint GetNpadIrCameraHandle(uint _0) => throw new NotImplementedException();
		public virtual void RunPointingProcessor(uint _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void SuspendImageProcessor(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void CheckFirmwareVersion(uint _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void SetFunctionLevel(uint _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void RunImageTransferExProcessor(uint _0, ulong _1, byte[] _2, ulong _3, ulong _4, KObject _5) => throw new NotImplementedException();
		public virtual void RunIrLedProcessor(uint _0, byte[] _1, ulong _2, ulong _3) => throw new NotImplementedException();
		public virtual void StopImageProcessorAsync(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual void ActivateIrsensorWithFunctionLevel(byte[] _0, ulong _1, ulong _2) => throw new NotImplementedException();
	}
	
	[IpcService("irs:sys")]
	public unsafe partial class IIrSensorSystemServer : _Base_IIrSensorSystemServer {}
	public unsafe class _Base_IIrSensorSystemServer : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 500: { // SetAppletResourceUserId
					SetAppletResourceUserId(im.GetData<ulong>(0));
					break;
				}
				case 501: { // RegisterAppletResourceUserId
					RegisterAppletResourceUserId(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				case 502: { // UnregisterAppletResourceUserId
					UnregisterAppletResourceUserId(im.GetData<ulong>(0));
					break;
				}
				case 503: { // EnableAppletToGetInput
					EnableAppletToGetInput(im.GetData<byte>(0), im.GetData<ulong>(8));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IIrSensorSystemServer: {im.CommandId}");
			}
		}
		
		public virtual void SetAppletResourceUserId(ulong _0) => throw new NotImplementedException();
		public virtual void RegisterAppletResourceUserId(byte _0, ulong _1) => throw new NotImplementedException();
		public virtual void UnregisterAppletResourceUserId(ulong _0) => throw new NotImplementedException();
		public virtual void EnableAppletToGetInput(byte _0, ulong _1) => throw new NotImplementedException();
	}
}
