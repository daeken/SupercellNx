#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.News.Detail.Ipc {
	[IpcService("news:a")]
	[IpcService("news:c")]
	[IpcService("news:m")]
	[IpcService("news:p")]
	[IpcService("news:v")]
	public unsafe partial class IServiceCreator : _Base_IServiceCreator {}
	public unsafe class _Base_IServiceCreator : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Move(0, ret.Handle);
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1();
					om.Move(0, ret.Handle);
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2();
					om.Move(0, ret.Handle);
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					om.Move(0, ret.Handle);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4();
					om.Move(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IServiceCreator: {im.CommandId}");
			}
		}
		
		public virtual Nn.News.Detail.Ipc.INewsService Unknown0() => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.INewlyArrivedEventHolder Unknown1() => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.INewsDataService Unknown2() => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.INewsDatabaseService Unknown3() => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.IOverwriteEventHolder Unknown4() => throw new NotImplementedException();
	}
	
	public unsafe partial class INewlyArrivedEventHolder : _Base_INewlyArrivedEventHolder {}
	public unsafe class _Base_INewlyArrivedEventHolder : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INewlyArrivedEventHolder: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
	}
	
	public unsafe partial class INewsDatabaseService : _Base_INewsDatabaseService {}
	public unsafe class _Base_INewsDatabaseService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 1: { // Unknown1
					var ret = Unknown1(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1));
					break;
				}
				case 3: { // Unknown3
					Unknown3(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1));
					break;
				}
				case 4: { // Unknown4
					Unknown4(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1));
					break;
				}
				case 5: { // Unknown5
					Unknown5(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INewsDatabaseService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(object _0, Buffer<byte> _1, Buffer<byte> _2, out object _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual object Unknown1(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown2(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown3(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown4(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Unknown5(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
	}
	
	public unsafe partial class INewsDataService : _Base_INewsDataService {}
	public unsafe class _Base_INewsDataService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					Unknown0(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 1: { // Unknown1
					Unknown1(null);
					break;
				}
				case 2: { // Unknown2
					Unknown2(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 3: { // Unknown3
					var ret = Unknown3();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INewsDataService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown0(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown1(object _0) => throw new NotImplementedException();
		public virtual void Unknown2(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown3() => throw new NotImplementedException();
	}
	
	public unsafe partial class INewsService : _Base_INewsService {}
	public unsafe class _Base_INewsService : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 10100: { // Unknown10100
					Unknown10100(im.GetBuffer<byte>(0x5, 0));
					break;
				}
				case 20100: { // Unknown20100
					Unknown20100(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 30100: { // Unknown30100
					var ret = Unknown30100(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 30101: { // Unknown30101
					Unknown30101(null, out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 30200: { // Unknown30200
					var ret = Unknown30200();
					break;
				}
				case 30300: { // Unknown30300
					Unknown30300(im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 30400: { // Unknown30400
					Unknown30400(im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				case 30900: { // Unknown30900
					var ret = Unknown30900();
					om.Move(0, ret.Handle);
					break;
				}
				case 30901: { // Unknown30901
					var ret = Unknown30901();
					om.Move(0, ret.Handle);
					break;
				}
				case 30902: { // Unknown30902
					var ret = Unknown30902();
					om.Move(0, ret.Handle);
					break;
				}
				case 40100: { // Unknown40100
					Unknown40100(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 40101: { // Unknown40101
					Unknown40101(null);
					break;
				}
				case 40200: { // Unknown40200
					Unknown40200();
					break;
				}
				case 40201: { // Unknown40201
					Unknown40201();
					break;
				}
				case 90100: { // Unknown90100
					Unknown90100(out var _0, im.GetBuffer<byte>(0x6, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to INewsService: {im.CommandId}");
			}
		}
		
		public virtual void Unknown10100(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown20100(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown30100(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown30101(object _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown30200() => throw new NotImplementedException();
		public virtual void Unknown30300(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown30400(Buffer<byte> _0, out object _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.INewlyArrivedEventHolder Unknown30900() => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.INewsDataService Unknown30901() => throw new NotImplementedException();
		public virtual Nn.News.Detail.Ipc.INewsDatabaseService Unknown30902() => throw new NotImplementedException();
		public virtual void Unknown40100(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown40101(object _0) => throw new NotImplementedException();
		public virtual void Unknown40200() => throw new NotImplementedException();
		public virtual void Unknown40201() => throw new NotImplementedException();
		public virtual void Unknown90100(out object _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class IOverwriteEventHolder : _Base_IOverwriteEventHolder {}
	public unsafe class _Base_IOverwriteEventHolder : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0();
					om.Copy(0, ret.Handle);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IOverwriteEventHolder: {im.CommandId}");
			}
		}
		
		public virtual KObject Unknown0() => throw new NotImplementedException();
	}
}
