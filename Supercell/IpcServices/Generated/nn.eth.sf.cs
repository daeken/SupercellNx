#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Eth.Sf {
	[IpcService("ethc:c")]
	public unsafe partial class IEthInterface : _Base_IEthInterface {}
	public unsafe class _Base_IEthInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetBuffer<byte>(0x5, 0));
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Cancel
					Cancel();
					break;
				}
				case 2: { // GetResult
					GetResult();
					break;
				}
				case 3: { // GetMediaList
					GetMediaList(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // SetMediaType
					SetMediaType(null);
					break;
				}
				case 5: { // GetMediaType
					var ret = GetMediaType();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEthInterface: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
		public virtual void GetResult() => throw new NotImplementedException();
		public virtual void GetMediaList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetMediaType(object _0) => throw new NotImplementedException();
		public virtual object GetMediaType() => throw new NotImplementedException();
	}
	
	[IpcService("ethc:i")]
	public unsafe partial class IEthInterfaceGroup : _Base_IEthInterfaceGroup {}
	public unsafe class _Base_IEthInterfaceGroup : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetReadableHandle
					var ret = GetReadableHandle();
					om.Copy(0, ret.Handle);
					break;
				}
				case 1: { // Cancel
					Cancel();
					break;
				}
				case 2: { // GetResult
					GetResult();
					break;
				}
				case 3: { // GetInterfaceList
					GetInterfaceList(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 4: { // GetInterfaceCount
					var ret = GetInterfaceCount();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEthInterfaceGroup: {im.CommandId}");
			}
		}
		
		public virtual KObject GetReadableHandle() => throw new NotImplementedException();
		public virtual void Cancel() => throw new NotImplementedException();
		public virtual void GetResult() => throw new NotImplementedException();
		public virtual void GetInterfaceList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetInterfaceCount() => throw new NotImplementedException();
	}
}
