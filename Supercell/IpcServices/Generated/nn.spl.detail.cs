#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Spl.Detail {
	[IpcService("spl:")]
	[IpcService("spl:mig")]
	[IpcService("spl:fs")]
	[IpcService("spl:ssl")]
	[IpcService("spl:es")]
	[IpcService("spl:manu")]
	public unsafe partial class IGeneralInterface : _Base_IGeneralInterface {}
	public unsafe class _Base_IGeneralInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetConfig
					var ret = GetConfig(null);
					break;
				}
				case 1: { // UserExpMod
					UserExpMod(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 2: { // GenerateAesKek
					var ret = GenerateAesKek(null);
					break;
				}
				case 3: { // LoadAesKey
					LoadAesKey(null);
					break;
				}
				case 4: { // GenerateAesKey
					var ret = GenerateAesKey(null);
					break;
				}
				case 5: { // SetConfig
					SetConfig(null);
					break;
				}
				case 7: { // GetRandomBytes
					GetRandomBytes(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 9: { // LoadSecureExpModKey
					LoadSecureExpModKey(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 10: { // SecureExpMod
					SecureExpMod(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), out var _0, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 11: { // IsDevelopment
					var ret = IsDevelopment();
					break;
				}
				case 12: { // GenerateSpecificAesKey
					var ret = GenerateSpecificAesKey(null);
					break;
				}
				case 13: { // DecryptRsaPrivateKey
					DecryptRsaPrivateKey(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 14: { // DecryptAesKey
					var ret = DecryptAesKey(null);
					break;
				}
				case 15: { // DecryptAesCtr
					DecryptAesCtr(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 16: { // ComputeCmac
					var ret = ComputeCmac(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 17: { // LoadRsaOaepKey
					LoadRsaOaepKey(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 18: { // UnwrapRsaOaepWrappedTitleKey
					var ret = UnwrapRsaOaepWrappedTitleKey(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2));
					break;
				}
				case 19: { // LoadTitleKey
					LoadTitleKey(null);
					break;
				}
				case 20: { // UnwrapAesWrappedTitleKey
					var ret = UnwrapAesWrappedTitleKey(null);
					break;
				}
				case 21: { // LockAesEngine
					var ret = LockAesEngine();
					break;
				}
				case 22: { // UnlockAesEngine
					UnlockAesEngine(null);
					break;
				}
				case 23: { // GetSplWaitEvent
					var ret = GetSplWaitEvent();
					om.Copy(0, ret.Handle);
					break;
				}
				case 24: { // SetSharedData
					SetSharedData(null);
					break;
				}
				case 25: { // GetSharedData
					var ret = GetSharedData();
					break;
				}
				case 26: { // ImportSslRsaKey
					var ret = ImportSslRsaKey(null);
					break;
				}
				case 27: { // SecureExpModWithSslKey
					var ret = SecureExpModWithSslKey(null);
					break;
				}
				case 28: { // ImportEsRsaKey
					var ret = ImportEsRsaKey(null);
					break;
				}
				case 29: { // SecureExpModWithEsKey
					var ret = SecureExpModWithEsKey(null);
					break;
				}
				case 30: { // EncryptManuRsaKeyForImport
					var ret = EncryptManuRsaKeyForImport(null);
					break;
				}
				case 31: { // GetPackage2Hash
					var ret = GetPackage2Hash(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IGeneralInterface: {im.CommandId}");
			}
		}
		
		public virtual object GetConfig(object _0) => throw new NotImplementedException();
		public virtual void UserExpMod(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object GenerateAesKek(object _0) => throw new NotImplementedException();
		public virtual void LoadAesKey(object _0) => throw new NotImplementedException();
		public virtual object GenerateAesKey(object _0) => throw new NotImplementedException();
		public virtual void SetConfig(object _0) => throw new NotImplementedException();
		public virtual void GetRandomBytes(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void LoadSecureExpModKey(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void SecureExpMod(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, out object _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual object IsDevelopment() => throw new NotImplementedException();
		public virtual object GenerateSpecificAesKey(object _0) => throw new NotImplementedException();
		public virtual void DecryptRsaPrivateKey(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object DecryptAesKey(object _0) => throw new NotImplementedException();
		public virtual void DecryptAesCtr(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object ComputeCmac(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void LoadRsaOaepKey(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object UnwrapRsaOaepWrappedTitleKey(object _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual void LoadTitleKey(object _0) => throw new NotImplementedException();
		public virtual object UnwrapAesWrappedTitleKey(object _0) => throw new NotImplementedException();
		public virtual object LockAesEngine() => throw new NotImplementedException();
		public virtual void UnlockAesEngine(object _0) => throw new NotImplementedException();
		public virtual KObject GetSplWaitEvent() => throw new NotImplementedException();
		public virtual void SetSharedData(object _0) => throw new NotImplementedException();
		public virtual object GetSharedData() => throw new NotImplementedException();
		public virtual object ImportSslRsaKey(object _0) => throw new NotImplementedException();
		public virtual object SecureExpModWithSslKey(object _0) => throw new NotImplementedException();
		public virtual object ImportEsRsaKey(object _0) => throw new NotImplementedException();
		public virtual object SecureExpModWithEsKey(object _0) => throw new NotImplementedException();
		public virtual object EncryptManuRsaKeyForImport(object _0) => throw new NotImplementedException();
		public virtual object GetPackage2Hash(object _0) => throw new NotImplementedException();
	}
	
	[IpcService("csrng")]
	public unsafe partial class IRandomInterface : _Base_IRandomInterface {}
	public unsafe class _Base_IRandomInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // GetRandomBytes
					GetRandomBytes(im.GetBuffer<byte>(0x6, 0));
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IRandomInterface: {im.CommandId}");
			}
		}
		
		public virtual void GetRandomBytes(Buffer<byte> _0) => throw new NotImplementedException();
	}
	
	public unsafe partial class ICryptoInterface : _Base_ICryptoInterface {}
	public unsafe class _Base_ICryptoInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14(null);
					break;
				}
				case 15: { // Unknown15
					Unknown15(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 16: { // Unknown16
					var ret = Unknown16(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21();
					break;
				}
				case 22: { // Unknown22
					Unknown22(null);
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					om.Copy(0, ret.Handle);
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ICryptoInterface: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual object Unknown14(object _0) => throw new NotImplementedException();
		public virtual void Unknown15(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown16(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown21() => throw new NotImplementedException();
		public virtual void Unknown22(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown23() => throw new NotImplementedException();
		public virtual void Unknown24(object _0) => throw new NotImplementedException();
		public virtual object Unknown25() => throw new NotImplementedException();
	}
	
	public unsafe partial class IEsInterface : _Base_IEsInterface {}
	public unsafe class _Base_IEsInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					break;
				}
				case 13: { // Unknown13
					Unknown13(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14(null);
					break;
				}
				case 15: { // Unknown15
					Unknown15(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 16: { // Unknown16
					var ret = Unknown16(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 17: { // Unknown17
					Unknown17(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 18: { // Unknown18
					var ret = Unknown18(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2));
					break;
				}
				case 20: { // Unknown20
					var ret = Unknown20(null);
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21();
					break;
				}
				case 22: { // Unknown22
					Unknown22(null);
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					om.Copy(0, ret.Handle);
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IEsInterface: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual void Unknown13(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown14(object _0) => throw new NotImplementedException();
		public virtual void Unknown15(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown16(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown17(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown18(object _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown20(object _0) => throw new NotImplementedException();
		public virtual object Unknown21() => throw new NotImplementedException();
		public virtual void Unknown22(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown23() => throw new NotImplementedException();
		public virtual void Unknown24(object _0) => throw new NotImplementedException();
		public virtual object Unknown25() => throw new NotImplementedException();
	}
	
	public unsafe partial class IFsInterface : _Base_IFsInterface {}
	public unsafe class _Base_IFsInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 9: { // Unknown9
					Unknown9(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 10: { // Unknown10
					Unknown10(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), out var _0, im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					break;
				}
				case 12: { // Unknown12
					var ret = Unknown12(null);
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14(null);
					break;
				}
				case 15: { // Unknown15
					Unknown15(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 16: { // Unknown16
					var ret = Unknown16(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 19: { // Unknown19
					Unknown19(null);
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21();
					break;
				}
				case 22: { // Unknown22
					Unknown22(null);
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					om.Copy(0, ret.Handle);
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IFsInterface: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual void Unknown9(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown10(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, out object _3, Buffer<byte> _4) => throw new NotImplementedException();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual object Unknown12(object _0) => throw new NotImplementedException();
		public virtual object Unknown14(object _0) => throw new NotImplementedException();
		public virtual void Unknown15(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown16(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual void Unknown19(object _0) => throw new NotImplementedException();
		public virtual object Unknown21() => throw new NotImplementedException();
		public virtual void Unknown22(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown23() => throw new NotImplementedException();
		public virtual void Unknown24(object _0) => throw new NotImplementedException();
		public virtual object Unknown25() => throw new NotImplementedException();
	}
	
	public unsafe partial class ISslInterface : _Base_ISslInterface {}
	public unsafe class _Base_ISslInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // Unknown0
					var ret = Unknown0(null);
					break;
				}
				case 1: { // Unknown1
					Unknown1(im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0x9, 1), im.GetBuffer<byte>(0x9, 2), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 2: { // Unknown2
					var ret = Unknown2(null);
					break;
				}
				case 3: { // Unknown3
					Unknown3(null);
					break;
				}
				case 4: { // Unknown4
					var ret = Unknown4(null);
					break;
				}
				case 5: { // Unknown5
					Unknown5(null);
					break;
				}
				case 7: { // Unknown7
					Unknown7(im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 11: { // Unknown11
					var ret = Unknown11();
					break;
				}
				case 13: { // Unknown13
					Unknown13(null, im.GetBuffer<byte>(0x9, 0), im.GetBuffer<byte>(0xA, 0));
					break;
				}
				case 14: { // Unknown14
					var ret = Unknown14(null);
					break;
				}
				case 15: { // Unknown15
					Unknown15(null, im.GetBuffer<byte>(0x45, 0), im.GetBuffer<byte>(0x46, 0));
					break;
				}
				case 16: { // Unknown16
					var ret = Unknown16(null, im.GetBuffer<byte>(0x9, 0));
					break;
				}
				case 21: { // Unknown21
					var ret = Unknown21();
					break;
				}
				case 22: { // Unknown22
					Unknown22(null);
					break;
				}
				case 23: { // Unknown23
					var ret = Unknown23();
					om.Copy(0, ret.Handle);
					break;
				}
				case 24: { // Unknown24
					Unknown24(null);
					break;
				}
				case 25: { // Unknown25
					var ret = Unknown25();
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to ISslInterface: {im.CommandId}");
			}
		}
		
		public virtual object Unknown0(object _0) => throw new NotImplementedException();
		public virtual void Unknown1(Buffer<byte> _0, Buffer<byte> _1, Buffer<byte> _2, Buffer<byte> _3) => throw new NotImplementedException();
		public virtual object Unknown2(object _0) => throw new NotImplementedException();
		public virtual void Unknown3(object _0) => throw new NotImplementedException();
		public virtual object Unknown4(object _0) => throw new NotImplementedException();
		public virtual void Unknown5(object _0) => throw new NotImplementedException();
		public virtual void Unknown7(Buffer<byte> _0) => throw new NotImplementedException();
		public virtual object Unknown11() => throw new NotImplementedException();
		public virtual void Unknown13(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown14(object _0) => throw new NotImplementedException();
		public virtual void Unknown15(object _0, Buffer<byte> _1, Buffer<byte> _2) => throw new NotImplementedException();
		public virtual object Unknown16(object _0, Buffer<byte> _1) => throw new NotImplementedException();
		public virtual object Unknown21() => throw new NotImplementedException();
		public virtual void Unknown22(object _0) => throw new NotImplementedException();
		public virtual KObject Unknown23() => throw new NotImplementedException();
		public virtual void Unknown24(object _0) => throw new NotImplementedException();
		public virtual object Unknown25() => throw new NotImplementedException();
	}
}
