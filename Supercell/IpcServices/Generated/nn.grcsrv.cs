#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Grcsrv {
	[IpcService("grc:c")]
	public unsafe partial class IGrcService : _Base_IGrcService {}
	public unsafe class _Base_IGrcService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // OpenContinuousRecorder
					var ret = OpenContinuousRecorder(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 2: { // OpenGameMovieTrimmer
					var ret = OpenGameMovieTrimmer(null, Kernel.Get<KObject>(im.GetCopy(0)));
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IGrcService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Grcsrv.IContinuousRecorder OpenContinuousRecorder(object _0, KObject _1) => throw new NotImplementedException();
		public virtual Nn.Grcsrv.IGameMovieTrimmer OpenGameMovieTrimmer(object _0, KObject _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IContinuousRecorder : _Base_IContinuousRecorder {}
	public unsafe class _Base_IContinuousRecorder : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // Unknown1
					Unknown1();
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // Unknown2
					Unknown2();
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // Unknown10
					var ret = Unknown10();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 11: { // Unknown11
					Unknown11();
					om.Initialize(0, 0, 0);
					break;
				}
				case 12: { // Unknown12
					Unknown12();
					om.Initialize(0, 0, 0);
					break;
				}
				case 13: { // Unknown13
					Unknown13(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IContinuousRecorder: {im.CommandId}");
			}
		}
		
		public virtual void Unknown1() => "Stub hit for Nn.Grcsrv.IContinuousRecorder.Unknown1 [1]".Debug();
		public virtual void Unknown2() => "Stub hit for Nn.Grcsrv.IContinuousRecorder.Unknown2 [2]".Debug();
		public virtual KObject Unknown10() => throw new NotImplementedException();
		public virtual void Unknown11() => "Stub hit for Nn.Grcsrv.IContinuousRecorder.Unknown11 [11]".Debug();
		public virtual void Unknown12() => "Stub hit for Nn.Grcsrv.IContinuousRecorder.Unknown12 [12]".Debug();
		public virtual void Unknown13(object _0) => "Stub hit for Nn.Grcsrv.IContinuousRecorder.Unknown13 [13]".Debug();
	}
	
	public unsafe partial class IGameMovieTrimmer : _Base_IGameMovieTrimmer {}
	public unsafe class _Base_IGameMovieTrimmer : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 1: { // BeginTrim
					BeginTrim(im.GetData<uint>(8), im.GetData<uint>(12), im.GetBytes(16, 0x40));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // EndTrim
					EndTrim(out var _0);
					om.Initialize(0, 0, 64);
					om.SetBytes(8, _0);
					break;
				}
				case 10: { // GetNotTrimmingEvent
					var ret = GetNotTrimmingEvent();
					om.Initialize(0, 1, 0);
					om.Copy(0, CreateHandle(ret, copy: true));
					break;
				}
				case 20: { // SetThumbnailRgba
					SetThumbnailRgba(im.GetData<uint>(8), im.GetData<uint>(12), im.GetBuffer<byte>(0x45, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IGameMovieTrimmer: {im.CommandId}");
			}
		}
		
		public virtual void BeginTrim(uint _0, uint _1, byte[] _2) => "Stub hit for Nn.Grcsrv.IGameMovieTrimmer.BeginTrim [1]".Debug();
		public virtual void EndTrim(out byte[] _0) => throw new NotImplementedException();
		public virtual KObject GetNotTrimmingEvent() => throw new NotImplementedException();
		public virtual void SetThumbnailRgba(uint _0, uint _1, Buffer<byte> _2) => "Stub hit for Nn.Grcsrv.IGameMovieTrimmer.SetThumbnailRgba [20]".Debug();
	}
}
