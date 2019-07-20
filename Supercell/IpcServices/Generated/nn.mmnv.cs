#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Mmnv {
	[IpcService("mm:u")]
	public unsafe partial class IRequest : _Base_IRequest {}
	public unsafe class _Base_IRequest : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // InitializeOld
					InitializeOld(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8));
					break;
				}
				case 1: { // FinalizeOld
					FinalizeOld(im.GetData<uint>(0));
					break;
				}
				case 2: { // SetAndWaitOld
					SetAndWaitOld(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8));
					break;
				}
				case 3: { // GetOld
					var ret = GetOld(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				case 4: { // Initialize
					var ret = Initialize(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8));
					om.SetData(0, ret);
					break;
				}
				case 5: { // Finalize
					Finalize(im.GetData<uint>(0));
					break;
				}
				case 6: { // SetAndWait
					SetAndWait(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<uint>(8));
					break;
				}
				case 7: { // Get
					var ret = Get(im.GetData<uint>(0));
					om.SetData(0, ret);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRequest: {im.CommandId}");
			}
		}
		
		public virtual void InitializeOld(uint _0, uint _1, uint _2) => throw new NotImplementedException();
		public virtual void FinalizeOld(uint _0) => throw new NotImplementedException();
		public virtual void SetAndWaitOld(uint _0, uint _1, uint _2) => throw new NotImplementedException();
		public virtual uint GetOld(uint _0) => throw new NotImplementedException();
		public virtual uint Initialize(uint _0, uint _1, uint _2) => throw new NotImplementedException();
		public virtual void Finalize(uint _0) => throw new NotImplementedException();
		public virtual void SetAndWait(uint _0, uint _1, uint _2) => throw new NotImplementedException();
		public virtual uint Get(uint _0) => throw new NotImplementedException();
	}
}
