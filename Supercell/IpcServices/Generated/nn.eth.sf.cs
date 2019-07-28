#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Eth.Sf {
	[IpcService("ethc:c")]
	public unsafe partial class IEthInterface : _Base_IEthInterface {}
	public unsafe class _Base_IEthInterface : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Initialize
					var ret = Initialize(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetMediaList
					GetMediaList(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // SetMediaType
					SetMediaType(null);
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // GetMediaType
					var ret = GetMediaType();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEthInterface: {im.CommandId}");
			}
		}
		
		public virtual KObject Initialize(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Cancel() => "Stub hit for Nn.Eth.Sf.IEthInterface.Cancel [1]".Debug();
		public virtual void GetResult() => "Stub hit for Nn.Eth.Sf.IEthInterface.GetResult [2]".Debug();
		public virtual void GetMediaList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void SetMediaType(object _0) => "Stub hit for Nn.Eth.Sf.IEthInterface.SetMediaType [4]".Debug();
		public virtual object GetMediaType() => throw new NotImplementedException();
	}
	
	[IpcService("ethc:i")]
	public unsafe partial class IEthInterfaceGroup : _Base_IEthInterfaceGroup {}
	public unsafe class _Base_IEthInterfaceGroup : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetReadableHandle
					var ret = GetReadableHandle();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 1: { // Cancel
					Cancel();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // GetResult
					GetResult();
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // GetInterfaceList
					GetInterfaceList(im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetInterfaceCount
					var ret = GetInterfaceCount();
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEthInterfaceGroup: {im.CommandId}");
			}
		}
		
		public virtual KObject GetReadableHandle() => throw new NotImplementedException();
		public virtual void Cancel() => "Stub hit for Nn.Eth.Sf.IEthInterfaceGroup.Cancel [1]".Debug();
		public virtual void GetResult() => "Stub hit for Nn.Eth.Sf.IEthInterfaceGroup.GetResult [2]".Debug();
		public virtual void GetInterfaceList(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object GetInterfaceCount() => throw new NotImplementedException();
	}
}
