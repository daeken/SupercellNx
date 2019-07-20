#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Aocsrv.Detail {
	[IpcService("aoc:u")]
	public unsafe partial class IAddOnContentManager : _Base_IAddOnContentManager {}
	public unsafe class _Base_IAddOnContentManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CountAddOnContentByApplicationId
					var ret = CountAddOnContentByApplicationId(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 1: { // ListAddOnContentByApplicationId
					ListAddOnContentByApplicationId(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), out var _0, im.GetBuffer<uint>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 2: { // CountAddOnContent
					var ret = CountAddOnContent(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 3: { // ListAddOnContent
					ListAddOnContent(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid, out var _0, im.GetBuffer<uint>(0x6, 0));
					om.SetData(0, _0);
					break;
				}
				case 4: { // GetAddOnContentBaseIdByApplicationId
					var ret = GetAddOnContentBaseIdByApplicationId(im.GetData<ulong>(0));
					om.SetData(0, ret);
					break;
				}
				case 5: { // GetAddOnContentBaseId
					var ret = GetAddOnContentBaseId(im.GetData<ulong>(0), im.Pid);
					om.SetData(0, ret);
					break;
				}
				case 6: { // PrepareAddOnContentByApplicationId
					PrepareAddOnContentByApplicationId(im.GetData<uint>(0), im.GetData<ulong>(8));
					break;
				}
				case 7: { // PrepareAddOnContent
					PrepareAddOnContent(im.GetData<uint>(0), im.GetData<ulong>(8), im.Pid);
					break;
				}
				case 8: { // GetAddOnContentListChangedEvent
					var ret = GetAddOnContentListChangedEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAddOnContentManager: {im.CommandId}");
			}
		}
		
		public virtual uint CountAddOnContentByApplicationId(ulong _0) => throw new NotImplementedException();
		public virtual void ListAddOnContentByApplicationId(uint _0, uint _1, ulong _2, out uint _3, Buffer<uint> _4) => throw new NotImplementedException();
		public virtual uint CountAddOnContent(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void ListAddOnContent(uint _0, uint _1, ulong _2, ulong _3, out uint _4, Buffer<uint> _5) => throw new NotImplementedException();
		public virtual ulong GetAddOnContentBaseIdByApplicationId(ulong _0) => throw new NotImplementedException();
		public virtual ulong GetAddOnContentBaseId(ulong _0, ulong _1) => throw new NotImplementedException();
		public virtual void PrepareAddOnContentByApplicationId(uint _0, ulong _1) => throw new NotImplementedException();
		public virtual void PrepareAddOnContent(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual KObject GetAddOnContentListChangedEvent() => throw new NotImplementedException();
	}
}
