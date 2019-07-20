#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Lr {
	[IpcService("lr")]
	public unsafe partial class ILocationResolverManager : _Base_ILocationResolverManager {}
	public unsafe class _Base_ILocationResolverManager : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // OpenLocationResolver
					var ret = OpenLocationResolver(null);
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // OpenRegisteredLocationResolver
					var ret = OpenRegisteredLocationResolver();
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // RefreshLocationResolver
					RefreshLocationResolver(null);
					break;
				}
				case 3: { // OpenAddOnContentLocationResolver
					var ret = OpenAddOnContentLocationResolver();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILocationResolverManager: {im.CommandId}");
			}
		}
		
		public virtual Nn.Lr.ILocationResolver OpenLocationResolver(object _0) => throw new NotImplementedException();
		public virtual Nn.Lr.IRegisteredLocationResolver OpenRegisteredLocationResolver() => throw new NotImplementedException();
		public virtual void RefreshLocationResolver(object _0) => throw new NotImplementedException();
		public virtual Nn.Lr.IAddOnContentLocationResolver OpenAddOnContentLocationResolver() => throw new NotImplementedException();
	}
	
	public unsafe partial class IAddOnContentLocationResolver : _Base_IAddOnContentLocationResolver {}
	public unsafe class _Base_IAddOnContentLocationResolver : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ResolveAddOnContentPath
					ResolveAddOnContentPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 1: { // RegisterAddOnContentStorage
					RegisterAddOnContentStorage(null);
					break;
				}
				case 2: { // UnregisterAllAddOnContentPath
					UnregisterAllAddOnContentPath();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAddOnContentLocationResolver: {im.CommandId}");
			}
		}
		
		public virtual void ResolveAddOnContentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RegisterAddOnContentStorage(object _0) => throw new NotImplementedException();
		public virtual void UnregisterAllAddOnContentPath() => throw new NotImplementedException();
	}
	
	public unsafe partial class ILocationResolver : _Base_ILocationResolver {}
	public unsafe class _Base_ILocationResolver : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ResolveProgramPath
					ResolveProgramPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 1: { // RedirectProgramPath
					RedirectProgramPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 2: { // ResolveApplicationControlPath
					ResolveApplicationControlPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 3: { // ResolveApplicationHtmlDocumentPath
					ResolveApplicationHtmlDocumentPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 4: { // ResolveDataPath
					ResolveDataPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 5: { // RedirectApplicationControlPath
					RedirectApplicationControlPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 6: { // RedirectApplicationHtmlDocumentPath
					RedirectApplicationHtmlDocumentPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 7: { // ResolveApplicationLegalInformationPath
					ResolveApplicationLegalInformationPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 8: { // RedirectApplicationLegalInformationPath
					RedirectApplicationLegalInformationPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 9: { // Refresh
					Refresh();
					break;
				}
				case 10: { // SetProgramNcaPath2
					var ret = SetProgramNcaPath2(null);
					break;
				}
				case 11: { // ClearLocationResolver2
					var ret = ClearLocationResolver2(null);
					break;
				}
				case 12: { // DeleteProgramNcaPath
					var ret = DeleteProgramNcaPath(null);
					break;
				}
				case 13: { // DeleteControlNcaPath
					var ret = DeleteControlNcaPath(null);
					break;
				}
				case 14: { // DeleteDocHtmlNcaPath
					var ret = DeleteDocHtmlNcaPath(null);
					break;
				}
				case 15: { // DeleteInfoHtmlNcaPath
					var ret = DeleteInfoHtmlNcaPath(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ILocationResolver: {im.CommandId}");
			}
		}
		
		public virtual void ResolveProgramPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RedirectProgramPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveApplicationControlPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveApplicationHtmlDocumentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveDataPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RedirectApplicationControlPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RedirectApplicationHtmlDocumentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveApplicationLegalInformationPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RedirectApplicationLegalInformationPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Refresh() => throw new NotImplementedException();
		public virtual object SetProgramNcaPath2(object _0) => throw new NotImplementedException();
		public virtual object ClearLocationResolver2(object _0) => throw new NotImplementedException();
		public virtual object DeleteProgramNcaPath(object _0) => throw new NotImplementedException();
		public virtual object DeleteControlNcaPath(object _0) => throw new NotImplementedException();
		public virtual object DeleteDocHtmlNcaPath(object _0) => throw new NotImplementedException();
		public virtual object DeleteInfoHtmlNcaPath(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IRegisteredLocationResolver : _Base_IRegisteredLocationResolver {}
	public unsafe class _Base_IRegisteredLocationResolver : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // ResolveProgramPath
					ResolveProgramPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 1: { // RegisterProgramPath
					RegisterProgramPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 2: { // UnregisterProgramPath
					UnregisterProgramPath(null);
					break;
				}
				case 3: { // RedirectProgramPath
					RedirectProgramPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 4: { // ResolveHtmlDocumentPath
					ResolveHtmlDocumentPath(null, im.GetBuffer<byte>(0x1A, 0));
					break;
				}
				case 5: { // RegisterHtmlDocumentPath
					RegisterHtmlDocumentPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				case 6: { // UnregisterHtmlDocumentPath
					UnregisterHtmlDocumentPath(null);
					break;
				}
				case 7: { // RedirectHtmlDocumentPath
					RedirectHtmlDocumentPath(null, im.GetBuffer<byte>(0x19, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRegisteredLocationResolver: {im.CommandId}");
			}
		}
		
		public virtual void ResolveProgramPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RegisterProgramPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void UnregisterProgramPath(object _0) => throw new NotImplementedException();
		public virtual void RedirectProgramPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void ResolveHtmlDocumentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RegisterHtmlDocumentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void UnregisterHtmlDocumentPath(object _0) => throw new NotImplementedException();
		public virtual void RedirectHtmlDocumentPath(object _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
}
