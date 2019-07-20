#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Capsrv.Sf {
	[IpcService("caps:a")]
	public unsafe partial class IAlbumAccessorService : _Base_IAlbumAccessorService {}
	public unsafe class _Base_IAlbumAccessorService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					var ret = Unknown5(null);
					break;
				}
				case 6: { // Unknown6
					var ret = Unknown6(null);
					break;
				}
				case 7: { // Unknown7
					var ret = Unknown7(null);
					break;
				}
				case 8: { // Unknown8
					Unknown8(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 9: { // Unknown9
					Unknown9(null, out var _0, im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 10: { // Unknown10
					Unknown10(null, out var _0, im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11(null);
					break;
				}
				case 12: { // Unknown12
					Unknown12(null, out var _0, im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 13: { // Unknown13
					Unknown13(null, out var _0, im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 14: { // Unknown14
					Unknown14(null, out var _0, im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 301: { // Unknown301
					Unknown301(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 401: { // Unknown401
					var ret = Unknown401();
					break;
				}
				case 501: { // Unknown501
					var ret = Unknown501(null);
					break;
				}
				case 1001: { // Unknown1001
					Unknown1001(null, out var _0, im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1002: { // Unknown1002
					Unknown1002(null, im.GetBuffer<byte>(0x16, 0), im.GetBuffer<byte>(0x46, 0), im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 8001: { // Unknown8001
					Unknown8001(null);
					break;
				}
				case 8002: { // Unknown8002
					Unknown8002(null);
					break;
				}
				case 8011: { // Unknown8011
					Unknown8011(null);
					break;
				}
				case 8012: { // Unknown8012
					var ret = Unknown8012(null);
					break;
				}
				case 8021: { // Unknown8021
					var ret = Unknown8021(null, im.Pid);
					break;
				}
				case 10011: { // Unknown10011
					Unknown10011(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAlbumAccessorService: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual void Unknown4(object _0) => throw new NotImplementedException();
		public virtual object Unknown5(object _0) => throw new NotImplementedException();
		public virtual object Unknown6(object _0) => throw new NotImplementedException();
		public virtual object Unknown7(object _0) => throw new NotImplementedException();
		public virtual void Unknown8(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown9(object _0, out object _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown10(object _0, out object _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown11(object _0) => throw new NotImplementedException();
		public virtual void Unknown12(object _0, out object _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown13(object _0, out object _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown14(object _0, out object _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown301(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown401() => throw new NotImplementedException();
		public virtual object Unknown501(object _0) => throw new NotImplementedException();
		public virtual void Unknown1001(object _0, out object _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown1002(object _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void Unknown8001(object _0) => throw new NotImplementedException();
		public virtual void Unknown8002(object _0) => throw new NotImplementedException();
		public virtual void Unknown8011(object _0) => throw new NotImplementedException();
		public virtual object Unknown8012(object _0) => throw new NotImplementedException();
		public virtual object Unknown8021(object _0, ulong _1) => throw new NotImplementedException();
		public virtual void Unknown10011(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("caps:u")]
	public unsafe partial class IAlbumApplicationService : _Base_IAlbumApplicationService {}
	public unsafe class _Base_IAlbumApplicationService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 102: { // GetAlbumFileListByAruid
					var ret = GetAlbumFileListByAruid(null);
					break;
				}
				case 103: { // DeleteAlbumFileByAruid
					var ret = DeleteAlbumFileByAruid(null);
					break;
				}
				case 104: { // GetAlbumFileSizeByAruid
					var ret = GetAlbumFileSizeByAruid(null);
					break;
				}
				case 110: { // LoadAlbumScreenShotImageByAruid
					var ret = LoadAlbumScreenShotImageByAruid(null);
					break;
				}
				case 120: { // LoadAlbumScreenShotThumbnailImageByAruid
					var ret = LoadAlbumScreenShotThumbnailImageByAruid(null);
					break;
				}
				case 60002: { // OpenAccessorSessionForApplication
					var ret = OpenAccessorSessionForApplication(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAlbumApplicationService: {im.CommandId}");
			}
		}
		
		public virtual object GetAlbumFileListByAruid(object _0) => throw new NotImplementedException();
		public virtual object DeleteAlbumFileByAruid(object _0) => throw new NotImplementedException();
		public virtual object GetAlbumFileSizeByAruid(object _0) => throw new NotImplementedException();
		public virtual object LoadAlbumScreenShotImageByAruid(object _0) => throw new NotImplementedException();
		public virtual object LoadAlbumScreenShotThumbnailImageByAruid(object _0) => throw new NotImplementedException();
		public virtual object OpenAccessorSessionForApplication(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("caps:c")]
	public unsafe partial class IAlbumControlService : _Base_IAlbumControlService {}
	public unsafe class _Base_IAlbumControlService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 2001: { // Unknown2001
					Unknown2001(null);
					break;
				}
				case 2002: { // Unknown2002
					Unknown2002(null);
					break;
				}
				case 2011: { // Unknown2011
					Unknown2011(null);
					break;
				}
				case 2012: { // Unknown2012
					Unknown2012(null);
					break;
				}
				case 2013: { // Unknown2013
					var ret = Unknown2013(null);
					break;
				}
				case 2014: { // Unknown2014
					Unknown2014(null);
					break;
				}
				case 2101: { // Unknown2101
					var ret = Unknown2101(null);
					break;
				}
				case 2102: { // Unknown2102
					var ret = Unknown2102(null);
					break;
				}
				case 2201: { // Unknown2201
					Unknown2201(null, im.GetBuffer<byte>(0x45, 0));
					break;
				}
				case 2301: { // Unknown2301
					Unknown2301(null, im.GetBuffer<byte>(0x45, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAlbumControlService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown2001(object _0) => throw new NotImplementedException();
		public virtual void Unknown2002(object _0) => throw new NotImplementedException();
		public virtual void Unknown2011(object _0) => throw new NotImplementedException();
		public virtual void Unknown2012(object _0) => throw new NotImplementedException();
		public virtual object Unknown2013(object _0) => throw new NotImplementedException();
		public virtual void Unknown2014(object _0) => throw new NotImplementedException();
		public virtual object Unknown2101(object _0) => throw new NotImplementedException();
		public virtual object Unknown2102(object _0) => throw new NotImplementedException();
		public virtual void Unknown2201(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2301(object _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	[IpcService("caps:su")]
	public unsafe partial class IScreenShotApplicationService : _Base_IScreenShotApplicationService {}
	public unsafe class _Base_IScreenShotApplicationService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 201: { // SaveScreenShot
					SaveScreenShot(im.GetData<uint>(0), im.GetData<uint>(4), im.GetData<ulong>(8), im.Pid, im.GetBuffer<byte>(0x45, 0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				case 203: { // SaveScreenShotEx0
					SaveScreenShotEx0(im.GetBytes(0, 0x40), im.GetData<uint>(64), im.GetData<ulong>(72), im.Pid, im.GetBuffer<byte>(0x45, 0), out var _0);
					om.SetBytes(0, _0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IScreenShotApplicationService: {im.CommandId}");
			}
		}
		
		public virtual void SaveScreenShot(uint _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, out byte[] _5) => throw new NotImplementedException();
		public virtual void SaveScreenShotEx0(byte[] _0, uint _1, ulong _2, ulong _3, Buffer<byte> _4, out byte[] _5) => throw new NotImplementedException();
	}
	
	[IpcService("caps:sc")]
	public unsafe partial class IScreenShotControlService : _Base_IScreenShotControlService {}
	public unsafe class _Base_IScreenShotControlService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1(null, im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 1001: { // Unknown1001
					Unknown1001(null);
					break;
				}
				case 1002: { // Unknown1002
					Unknown1002(null);
					break;
				}
				case 1003: { // Unknown1003
					Unknown1003(null);
					break;
				}
				case 1011: { // Unknown1011
					Unknown1011(null);
					break;
				}
				case 1012: { // Unknown1012
					Unknown1012(null);
					break;
				}
				case 1201: { // Unknown1201
					var ret = Unknown1201(null);
					break;
				}
				case 1202: { // Unknown1202
					Unknown1202();
					break;
				}
				case 1203: { // Unknown1203
					Unknown1203(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IScreenShotControlService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown1001(object _0) => throw new NotImplementedException();
		public virtual void Unknown1002(object _0) => throw new NotImplementedException();
		public virtual void Unknown1003(object _0) => throw new NotImplementedException();
		public virtual void Unknown1011(object _0) => throw new NotImplementedException();
		public virtual void Unknown1012(object _0) => throw new NotImplementedException();
		public virtual object Unknown1201(object _0) => throw new NotImplementedException();
		public virtual void Unknown1202() => throw new NotImplementedException();
		public virtual void Unknown1203(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	[IpcService("caps:ss")]
	public unsafe partial class IScreenShotService : _Base_IScreenShotService {}
	public unsafe class _Base_IScreenShotService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 201: { // Unknown201
					var ret = Unknown201(null, im.Pid, im.GetBuffer<byte>(0x45, 0));
					break;
				}
				case 202: { // Unknown202
					var ret = Unknown202(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x45, 1));
					break;
				}
				case 203: { // Unknown203
					var ret = Unknown203(null, im.Pid, im.GetBuffer<byte>(0x45, 0));
					break;
				}
				case 204: { // Unknown204
					var ret = Unknown204(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x45, 1));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IScreenShotService: {im.CommandId}");
			}
		}
		
		public virtual object Unknown201(object _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown202(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown203(object _0, ulong _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown204(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAlbumAccessorApplicationSession : _Base_IAlbumAccessorApplicationSession {}
	public unsafe class _Base_IAlbumAccessorApplicationSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 2001: { // OpenAlbumMovieReadStream
					var ret = OpenAlbumMovieReadStream(null);
					break;
				}
				case 2002: { // CloseAlbumMovieReadStream
					var ret = CloseAlbumMovieReadStream(null);
					break;
				}
				case 2003: { // GetAlbumMovieReadStreamMovieDataSize
					var ret = GetAlbumMovieReadStreamMovieDataSize(null);
					break;
				}
				case 2004: { // ReadMovieDataFromAlbumMovieReadStream
					var ret = ReadMovieDataFromAlbumMovieReadStream(null);
					break;
				}
				case 2005: { // GetAlbumMovieReadStreamBrokenReason
					var ret = GetAlbumMovieReadStreamBrokenReason(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAlbumAccessorApplicationSession: {im.CommandId}");
			}
		}
		
		public virtual object OpenAlbumMovieReadStream(object _0) => throw new NotImplementedException();
		public virtual object CloseAlbumMovieReadStream(object _0) => throw new NotImplementedException();
		public virtual object GetAlbumMovieReadStreamMovieDataSize(object _0) => throw new NotImplementedException();
		public virtual object ReadMovieDataFromAlbumMovieReadStream(object _0) => throw new NotImplementedException();
		public virtual object GetAlbumMovieReadStreamBrokenReason(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAlbumAccessorSession : _Base_IAlbumAccessorSession {}
	public unsafe class _Base_IAlbumAccessorSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 2001: { // Unknown2001
					var ret = Unknown2001(null);
					break;
				}
				case 2002: { // Unknown2002
					Unknown2002(null);
					break;
				}
				case 2003: { // Unknown2003
					var ret = Unknown2003(null);
					break;
				}
				case 2004: { // Unknown2004
					Unknown2004(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2005: { // Unknown2005
					Unknown2005(null);
					break;
				}
				case 2006: { // Unknown2006
					var ret = Unknown2006(null);
					break;
				}
				case 2007: { // Unknown2007
					Unknown2007(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2008: { // Unknown2008
					var ret = Unknown2008(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAlbumAccessorSession: {im.CommandId}");
			}
		}
		
		public virtual object Unknown2001(object _0) => throw new NotImplementedException();
		public virtual void Unknown2002(object _0) => throw new NotImplementedException();
		public virtual object Unknown2003(object _0) => throw new NotImplementedException();
		public virtual void Unknown2004(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown2005(object _0) => throw new NotImplementedException();
		public virtual object Unknown2006(object _0) => throw new NotImplementedException();
		public virtual void Unknown2007(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown2008(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class IAlbumControlSession : _Base_IAlbumControlSession {}
	public unsafe class _Base_IAlbumControlSession : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 2001: { // Unknown2001
					var ret = Unknown2001(null);
					break;
				}
				case 2002: { // Unknown2002
					Unknown2002(null);
					break;
				}
				case 2003: { // Unknown2003
					var ret = Unknown2003(null);
					break;
				}
				case 2004: { // Unknown2004
					Unknown2004(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2005: { // Unknown2005
					Unknown2005(null);
					break;
				}
				case 2006: { // Unknown2006
					var ret = Unknown2006(null);
					break;
				}
				case 2007: { // Unknown2007
					Unknown2007(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2008: { // Unknown2008
					var ret = Unknown2008(null);
					break;
				}
				case 2401: { // Unknown2401
					var ret = Unknown2401(null);
					break;
				}
				case 2402: { // Unknown2402
					Unknown2402(null);
					break;
				}
				case 2403: { // Unknown2403
					Unknown2403(null);
					break;
				}
				case 2404: { // Unknown2404
					Unknown2404(null);
					break;
				}
				case 2405: { // Unknown2405
					Unknown2405(null);
					break;
				}
				case 2411: { // Unknown2411
					Unknown2411(null);
					break;
				}
				case 2412: { // Unknown2412
					Unknown2412(null);
					break;
				}
				case 2413: { // Unknown2413
					Unknown2413(null);
					break;
				}
				case 2414: { // Unknown2414
					Unknown2414(null);
					break;
				}
				case 2421: { // Unknown2421
					Unknown2421(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 2422: { // Unknown2422
					Unknown2422(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2424: { // Unknown2424
					Unknown2424(null, im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 2431: { // Unknown2431
					Unknown2431(null);
					break;
				}
				case 2433: { // Unknown2433
					var ret = Unknown2433(null);
					break;
				}
				case 2434: { // Unknown2434
					Unknown2434(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IAlbumControlSession: {im.CommandId}");
			}
		}
		
		public virtual object Unknown2001(object _0) => throw new NotImplementedException();
		public virtual void Unknown2002(object _0) => throw new NotImplementedException();
		public virtual object Unknown2003(object _0) => throw new NotImplementedException();
		public virtual void Unknown2004(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown2005(object _0) => throw new NotImplementedException();
		public virtual object Unknown2006(object _0) => throw new NotImplementedException();
		public virtual void Unknown2007(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown2008(object _0) => throw new NotImplementedException();
		public virtual object Unknown2401(object _0) => throw new NotImplementedException();
		public virtual void Unknown2402(object _0) => throw new NotImplementedException();
		public virtual void Unknown2403(object _0) => throw new NotImplementedException();
		public virtual void Unknown2404(object _0) => throw new NotImplementedException();
		public virtual void Unknown2405(object _0) => throw new NotImplementedException();
		public virtual void Unknown2411(object _0) => throw new NotImplementedException();
		public virtual void Unknown2412(object _0) => throw new NotImplementedException();
		public virtual void Unknown2413(object _0) => throw new NotImplementedException();
		public virtual void Unknown2414(object _0) => throw new NotImplementedException();
		public virtual void Unknown2421(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown2422(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2424(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2431(object _0) => throw new NotImplementedException();
		public virtual object Unknown2433(object _0) => throw new NotImplementedException();
		public virtual void Unknown2434(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ICaptureControllerService : _Base_ICaptureControllerService {}
	public unsafe class _Base_ICaptureControllerService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1(null, im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 1001: { // Unknown1001
					Unknown1001(null);
					break;
				}
				case 1002: { // Unknown1002
					Unknown1002(null);
					break;
				}
				case 1011: { // Unknown1011
					Unknown1011(null);
					break;
				}
				case 2001: { // Unknown2001
					Unknown2001(null);
					break;
				}
				case 2002: { // Unknown2002
					Unknown2002(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ICaptureControllerService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown1001(object _0) => throw new NotImplementedException();
		public virtual void Unknown1002(object _0) => throw new NotImplementedException();
		public virtual void Unknown1011(object _0) => throw new NotImplementedException();
		public virtual void Unknown2001(object _0) => throw new NotImplementedException();
		public virtual void Unknown2002(object _0) => throw new NotImplementedException();
	}
}
