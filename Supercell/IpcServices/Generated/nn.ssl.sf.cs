#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Ssl.Sf {
	[IpcService("ssl")]
	public unsafe partial class ISslService : _Base_ISslService {}
	public unsafe class _Base_ISslService : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // CreateContext
					var ret = CreateContext(im.GetData<uint>(8), im.GetData<ulong>(16), im.Pid);
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 1: { // GetContextCount
					var ret = GetContextCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 2: { // GetCertificates
					GetCertificates(im.GetBuffer<byte>(0x5, 0), out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 3: { // GetCertificateBufSize
					var ret = GetCertificateBufSize(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 4: { // DebugIoctl
					DebugIoctl(im.GetData<ulong>(8), im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 5: { // SetInterfaceVersion
					SetInterfaceVersion(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 6: { // FlushSessionCache
					var ret = FlushSessionCache(null);
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISslService: {im.CommandId}");
			}
		}
		
		public virtual Nn.Ssl.Sf.ISslContext CreateContext(uint _0, ulong _1, ulong _2) => throw new NotImplementedException();
		public virtual uint GetContextCount() => throw new NotImplementedException();
		public virtual void GetCertificates(Buffer<byte> _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual uint GetCertificateBufSize(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void DebugIoctl(ulong _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void SetInterfaceVersion(uint _0) => "Stub hit for Nn.Ssl.Sf.ISslService.SetInterfaceVersion [5]".Debug();
		public virtual object FlushSessionCache(object _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISslConnection : _Base_ISslConnection {}
	public unsafe class _Base_ISslConnection : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetSocketDescriptor
					var ret = SetSocketDescriptor(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 1: { // SetHostName
					SetHostName(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 2: { // SetVerifyOption
					SetVerifyOption(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 3: { // SetIoMode
					SetIoMode(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 4: { // GetSocketDescriptor
					var ret = GetSocketDescriptor();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 5: { // GetHostName
					GetHostName(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 6: { // GetVerifyOption
					var ret = GetVerifyOption();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 7: { // GetIoMode
					var ret = GetIoMode();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 8: { // DoHandshake
					DoHandshake();
					om.Initialize(0, 0, 0);
					break;
				}
				case 9: { // DoHandshakeGetServerCert
					DoHandshakeGetServerCert(out var _0, out var _1, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 10: { // Read
					Read(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 11: { // Write
					var ret = Write(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 12: { // Pending
					var ret = Pending();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 13: { // Peek
					Peek(out var _0, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 4);
					om.SetData(8, _0);
					break;
				}
				case 14: { // Poll
					var ret = Poll(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 15: { // GetVerifyCertError
					GetVerifyCertError();
					om.Initialize(0, 0, 0);
					break;
				}
				case 16: { // GetNeededServerCertBufferSize
					var ret = GetNeededServerCertBufferSize();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 17: { // SetSessionCacheMode
					SetSessionCacheMode(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 18: { // GetSessionCacheMode
					var ret = GetSessionCacheMode();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 19: { // FlushSessionCache
					FlushSessionCache();
					om.Initialize(0, 0, 0);
					break;
				}
				case 20: { // SetRenegotiationMode
					SetRenegotiationMode(im.GetData<uint>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 21: { // GetRenegotiationMode
					var ret = GetRenegotiationMode();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 22: { // SetOption
					SetOption(im.GetData<byte>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 23: { // GetOption
					var ret = GetOption(im.GetData<uint>(8));
					om.Initialize(0, 0, 1);
					om.SetData(8, ret);
					break;
				}
				case 24: { // GetVerifyCertErrors
					GetVerifyCertErrors(out var _0, out var _1, im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, _0);
					om.SetData(12, _1);
					break;
				}
				case 25: { // GetCipherInfo
					GetCipherInfo(im.GetData<uint>(8), im.GetBuffer<byte>(0x6, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISslConnection: {im.CommandId}");
			}
		}
		
		public virtual uint SetSocketDescriptor(uint _0) => throw new NotImplementedException();
		public virtual void SetHostName(Buffer<byte> _0) => "Stub hit for Nn.Ssl.Sf.ISslConnection.SetHostName [1]".Debug();
		public virtual void SetVerifyOption(uint _0) => "Stub hit for Nn.Ssl.Sf.ISslConnection.SetVerifyOption [2]".Debug();
		public virtual void SetIoMode(uint _0) => "Stub hit for Nn.Ssl.Sf.ISslConnection.SetIoMode [3]".Debug();
		public virtual uint GetSocketDescriptor() => throw new NotImplementedException();
		public virtual void GetHostName(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint GetVerifyOption() => throw new NotImplementedException();
		public virtual uint GetIoMode() => throw new NotImplementedException();
		public virtual void DoHandshake() => "Stub hit for Nn.Ssl.Sf.ISslConnection.DoHandshake [8]".Debug();
		public virtual void DoHandshakeGetServerCert(out uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void Read(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint Write(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual uint Pending() => throw new NotImplementedException();
		public virtual void Peek(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual uint Poll(uint _0, uint _1) => throw new NotImplementedException();
		public virtual void GetVerifyCertError() => "Stub hit for Nn.Ssl.Sf.ISslConnection.GetVerifyCertError [15]".Debug();
		public virtual uint GetNeededServerCertBufferSize() => throw new NotImplementedException();
		public virtual void SetSessionCacheMode(uint _0) => "Stub hit for Nn.Ssl.Sf.ISslConnection.SetSessionCacheMode [17]".Debug();
		public virtual uint GetSessionCacheMode() => throw new NotImplementedException();
		public virtual void FlushSessionCache() => "Stub hit for Nn.Ssl.Sf.ISslConnection.FlushSessionCache [19]".Debug();
		public virtual void SetRenegotiationMode(uint _0) => "Stub hit for Nn.Ssl.Sf.ISslConnection.SetRenegotiationMode [20]".Debug();
		public virtual uint GetRenegotiationMode() => throw new NotImplementedException();
		public virtual void SetOption(byte _0, uint _1) => "Stub hit for Nn.Ssl.Sf.ISslConnection.SetOption [22]".Debug();
		public virtual byte GetOption(uint _0) => throw new NotImplementedException();
		public virtual void GetVerifyCertErrors(out uint _0, out uint _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual void GetCipherInfo(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
	}
	
	public unsafe partial class ISslContext : _Base_ISslContext {}
	public unsafe class _Base_ISslContext : IpcInterface {
		public override void _Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // SetOption
					SetOption(im.GetData<uint>(8), im.GetData<uint>(12));
					om.Initialize(0, 0, 0);
					break;
				}
				case 1: { // GetOption
					var ret = GetOption(im.GetData<uint>(8));
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 2: { // CreateConnection
					var ret = CreateConnection();
					om.Initialize(1, 0, 0);
					om.Move(0, CreateHandle(ret));
					break;
				}
				case 3: { // GetConnectionCount
					var ret = GetConnectionCount();
					om.Initialize(0, 0, 4);
					om.SetData(8, ret);
					break;
				}
				case 4: { // ImportServerPki
					var ret = ImportServerPki(im.GetData<uint>(8), im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 5: { // ImportClientPki
					var ret = ImportClientPki(im.GetBuffer<byte>(0x5, 0), im.GetBuffer<byte>(0x5, 1));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 6: { // RemoveServerPki
					RemoveServerPki(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 7: { // RemoveClientPki
					RemoveClientPki(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				case 8: { // RegisterInternalPki
					var ret = RegisterInternalPki(im.GetData<uint>(8));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 9: { // AddPolicyOid
					AddPolicyOid(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 0);
					break;
				}
				case 10: { // ImportCrl
					var ret = ImportCrl(im.GetBuffer<byte>(0x5, 0));
					om.Initialize(0, 0, 8);
					om.SetData(8, ret);
					break;
				}
				case 11: { // RemoveCrl
					RemoveCrl(im.GetData<ulong>(8));
					om.Initialize(0, 0, 0);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISslContext: {im.CommandId}");
			}
		}
		
		public virtual void SetOption(uint _0, uint _1) => "Stub hit for Nn.Ssl.Sf.ISslContext.SetOption [0]".Debug();
		public virtual uint GetOption(uint _0) => throw new NotImplementedException();
		public virtual Nn.Ssl.Sf.ISslConnection CreateConnection() => throw new NotImplementedException();
		public virtual uint GetConnectionCount() => throw new NotImplementedException();
		public virtual ulong ImportServerPki(uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual ulong ImportClientPki(Buffer<byte> _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void RemoveServerPki(ulong _0) => "Stub hit for Nn.Ssl.Sf.ISslContext.RemoveServerPki [6]".Debug();
		public virtual void RemoveClientPki(ulong _0) => "Stub hit for Nn.Ssl.Sf.ISslContext.RemoveClientPki [7]".Debug();
		public virtual ulong RegisterInternalPki(uint _0) => throw new NotImplementedException();
		public virtual void AddPolicyOid(Buffer<byte> _0) => "Stub hit for Nn.Ssl.Sf.ISslContext.AddPolicyOid [9]".Debug();
		public virtual ulong ImportCrl(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void RemoveCrl(ulong _0) => "Stub hit for Nn.Ssl.Sf.ISslContext.RemoveCrl [11]".Debug();
	}
}
