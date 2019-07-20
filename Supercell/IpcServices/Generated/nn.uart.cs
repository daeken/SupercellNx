#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Uart {
	[IpcService("uart")]
	public unsafe partial class IManager : _Base_IManager {}
	public unsafe class _Base_IManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // DoesUartExist
					var ret = DoesUartExist(null);
					break;
				}
				case 1: { // DoesUartExistForTest
					var ret = DoesUartExistForTest(null);
					break;
				}
				case 2: { // SetUartBaudrate
					var ret = SetUartBaudrate(null);
					break;
				}
				case 3: { // SetUartBaudrateForTest
					var ret = SetUartBaudrateForTest(null);
					break;
				}
				case 4: { // IsSomethingUartValid
					var ret = IsSomethingUartValid(null);
					break;
				}
				case 5: { // IsSomethingUartValidForTest
					var ret = IsSomethingUartValidForTest(null);
					break;
				}
				case 6: { // GetSession
					var ret = GetSession();
					om.Move(0, ret.Handle);
					break;
				}
				case 7: { // IsSomethingUartValid2
					var ret = IsSomethingUartValid2(null);
					break;
				}
				case 8: { // IsSomethingUartValid2ForTest
					var ret = IsSomethingUartValid2ForTest(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IManager: {im.CommandId}");
			}
		}
		
		public virtual object DoesUartExist(object _0) => throw new NotImplementedException();
		public virtual object DoesUartExistForTest(object _0) => throw new NotImplementedException();
		public virtual object SetUartBaudrate(object _0) => throw new NotImplementedException();
		public virtual object SetUartBaudrateForTest(object _0) => throw new NotImplementedException();
		public virtual object IsSomethingUartValid(object _0) => throw new NotImplementedException();
		public virtual object IsSomethingUartValidForTest(object _0) => throw new NotImplementedException();
		public virtual Nn.Uart.IPortSession GetSession() => throw new NotImplementedException();
		public virtual object IsSomethingUartValid2(object _0) => throw new NotImplementedException();
		public virtual object IsSomethingUartValid2ForTest(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IPortSession : _Base_IPortSession {}
	public unsafe class _Base_IPortSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenSession
					var ret = OpenSession(null, Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)));
					break;
				}
				case 1: { // OpenSessionForTest
					var ret = OpenSessionForTest(null, Kernel.Get<KObject>(im.GetCopy(0)), Kernel.Get<KObject>(im.GetCopy(1)));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3(im.GetBuffer<byte>(0x21, 0));
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					break;
				}
				case 5: { // Unknown5
					Unknown5(out var _0, im.GetBuffer<byte>(0x22, 0));
					break;
				}
				case 6: { // Unknown6
					Unknown6(null, out var _0, out var _1);
					om.Copy(0, _1.Handle);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IPortSession: {im.CommandId}");
			}
		}
		
		public virtual object OpenSession(object _0, KObject _1, KObject _2) => throw new NotImplementedException();
		public virtual object OpenSessionForTest(object _0, KObject _1, KObject _2) => throw new NotImplementedException();
		public virtual object Unknown2() => throw new NotImplementedException();
		public virtual object Unknown3(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown4() => throw new NotImplementedException();
		public virtual void Unknown5(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown6(object _0, out object _1, out KObject _2) => throw new NotImplementedException();
		public virtual object Unknown7(object _0) => throw new NotImplementedException();
	}
}
