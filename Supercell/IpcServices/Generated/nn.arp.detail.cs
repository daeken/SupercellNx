#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Arp.Detail {
	[IpcService("arp:r")]
	public unsafe partial class IReader : _Base_IReader {}
	public unsafe class _Base_IReader : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetApplicationLaunchProperty
					var ret = GetApplicationLaunchProperty(null);
					break;
				}
				case 1: { // GetApplicationLaunchPropertyWithApplicationId
					var ret = GetApplicationLaunchPropertyWithApplicationId(null);
					break;
				}
				case 2: { // GetApplicationControlProperty
					GetApplicationControlProperty(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				case 3: { // GetApplicationControlPropertyWithApplicationId
					GetApplicationControlPropertyWithApplicationId(null, im.GetBuffer<byte>(0x16, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IReader: {im.CommandId}");
			}
		}
		
		public virtual object GetApplicationLaunchProperty(object _0) => throw new NotImplementedException();
		public virtual object GetApplicationLaunchPropertyWithApplicationId(object _0) => throw new NotImplementedException();
		public virtual void GetApplicationControlProperty(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void GetApplicationControlPropertyWithApplicationId(object _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	[IpcService("arp:w")]
	public unsafe partial class IWriter : _Base_IWriter {}
	public unsafe class _Base_IWriter : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // AcquireRegistrar
					var ret = AcquireRegistrar();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // DeleteProperties
					DeleteProperties(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IWriter: {im.CommandId}");
			}
		}
		
		public virtual Nn.Arp.Detail.IRegistrar AcquireRegistrar() => throw new NotImplementedException();
		public virtual void DeleteProperties(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IRegistrar : _Base_IRegistrar {}
	public unsafe class _Base_IRegistrar : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Issue
					Issue(null);
					break;
				}
				case 1: { // SetApplicationLaunchProperty
					SetApplicationLaunchProperty(null);
					break;
				}
				case 2: { // SetApplicationControlProperty
					SetApplicationControlProperty(im.GetBuffer<byte>(0x15, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRegistrar: {im.CommandId}");
			}
		}
		
		public virtual void Issue(object _0) => throw new NotImplementedException();
		public virtual void SetApplicationLaunchProperty(object _0) => throw new NotImplementedException();
		public virtual void SetApplicationControlProperty(Buffer<byte> _0) => throw new NotImplementedException();
	}
}
