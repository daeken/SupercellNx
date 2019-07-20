#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Jitsrv {
	[IpcService("jit:u")]
	public unsafe partial class IJitService : _Base_IJitService {}
	public unsafe class _Base_IJitService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateJitEnvironment
					var ret = CreateJitEnvironment(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IJitService: {im.CommandId}");
			}
		}
		
		public virtual object CreateJitEnvironment(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IJitEnvironment : _Base_IJitEnvironment {}
	public unsafe class _Base_IJitEnvironment : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Control
					var ret = Control(null);
					break;
				}
				case 1: { // GenerateCode
					var ret = GenerateCode(null);
					break;
				}
				case 1000: { // LoadPlugin
					var ret = LoadPlugin(null);
					break;
				}
				case 1001: { // GetCodeAddress
					var ret = GetCodeAddress(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IJitEnvironment: {im.CommandId}");
			}
		}
		
		public virtual object Control(object _0) => throw new NotImplementedException();
		public virtual object GenerateCode(object _0) => throw new NotImplementedException();
		public virtual object LoadPlugin(object _0) => throw new NotImplementedException();
		public virtual object GetCodeAddress(object _0) => throw new NotImplementedException();
	}
}
