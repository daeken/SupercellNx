using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using MoreLinq;
using PrettyPrinter;
using static Supercell.Globals;

namespace Supercell {
	public unsafe class IncomingMessage {
		public readonly byte* Buffer;
		public readonly bool IsDomainObject;
		public readonly ushort Type;
		public readonly uint CommandId, ACount, BCount, XCount, MoveCount, CopyCount;
		public readonly ulong Pid;
		public readonly bool HasC, HasPid;
		public readonly uint DomainHandle, DomainCommand;
		readonly uint WLen, RawOffset, SfciOffset, DescOffset, CopyOffset, MoveOffset;
		public IncomingMessage(byte* buffer, bool isDomainObject = false) {
			IsDomainObject = isDomainObject;
			Buffer = buffer;
			var buf = (uint*) buffer;
			Type = (ushort) (buf[0] & 0xFFFF);
			XCount = (buf[0] >> 16) & 0xF;
			ACount = (buf[0] >> 20) & 0xF;
			BCount = (buf[0] >> 24) & 0xF;
			WLen = buf[1] & 0x3FF;
			HasC = ((buf[1] >> 10) & 0x3) != 0;
			DomainHandle = 0;
			DomainCommand = 0;
			var pos = 2U;
			if(buf[1].HasBit(31)) {
				var hd = buf[pos++];
				HasPid = hd.HasBit(0);
				CopyCount = (hd >> 1) & 0xF;
				MoveCount = hd >> 5;
				if(HasPid) {
					Pid = *(ulong*) &buf[pos];
					pos += 2;
				}
				CopyOffset = pos * 4;
				pos += CopyCount;
				MoveOffset = pos * 4;
				pos += MoveCount;
			}

			DescOffset = pos * 4;

			pos += XCount * 2;
			pos += ACount * 3;
			pos += BCount * 3;
			RawOffset = pos * 4;
			if((pos & 3) != 0)
				pos += 4 - (pos & 3);
			if(isDomainObject && Type == 4) {
				DomainHandle = buf[pos + 1];
				DomainCommand = buf[pos] & 0xFF;
				pos += 4;
			}
			
			Debug.Assert(Type == 2 || isDomainObject && DomainCommand == 2 || buf[pos] == 0x49434653); // SFCI
			SfciOffset = pos * 4;

			CommandId = GetData<uint>(0);
		}

		T GetData<T>(uint offset) => new Span<T>(Buffer + SfciOffset + 8 + offset, Marshal.SizeOf<T>())[0];

		public static Func<IncomingMessage, object> DataGetter(Type T, uint offset) {
			switch(Activator.CreateInstance(T)) {
				case bool _: return im => im.GetData<byte>(offset) != 0;
				case byte _: return im => im.GetData<byte>(offset);
				case ushort _: return im => im.GetData<ushort>(offset);
				case uint _: return im => im.GetData<uint>(offset);
				case ulong _: return im => im.GetData<ulong>(offset);
				case sbyte _: return im => im.GetData<sbyte>(offset);
				case short _: return im => im.GetData<short>(offset);
				case int _: return im => im.GetData<int>(offset);
				case long _: return im => im.GetData<long>(offset);
				case float _: return im => im.GetData<float>(offset);
				case double _: return im => im.GetData<double>(offset);
				case { } _ when T.IsEnum: return DataGetter(Enum.GetUnderlyingType(T), offset);
				default: throw new NotSupportedException($"Can't create data getter of type {T.Name}");
			}
		}

		public static Func<IncomingMessage, object> BytesGetter(uint offset, uint size) => im =>
			new Span<byte>(im.Buffer + im.SfciOffset + 8 + offset, (int) size).ToArray();

		public Buffer<T> GetBuffer<T>(uint type, int num) where T : struct {
			if((type & 0x20) != 0)
				return GetBuffer<T>((type & ~0x20U) | 4U, num) ?? GetBuffer<T>((type & ~0x20U) | 8U, num);

			var ax = (type & 3) == 1 ? 1 : 0;
			var flags_ = type & 0xC0U;
			var flags = flags_ == 0x80 ? 3 : flags_ == 0x40 ? 1UL : 0UL;
			var cx = (type & 0xC) == 8 ? 1 : 0;
			
			switch((ax << 1) | cx) {
				case 0: { // B
					var t = (uint*) (Buffer + DescOffset + XCount * 8 + ACount * 12 + num * 12);
					ulong a = t[0], b = t[1], c = t[2];
					Debug.Assert((c & 0x3U) == flags);
					var buffer = new Buffer<T>(b | (((((c >> 2) << 4) & 0x70) | ((c >> 28) & 0xFU)) << 32),
						a | (((c >> 24) & 0xFU) << 32));
					if(BCount <= num || buffer.Size == 0)
						goto case 1; //  C buffer
					return buffer;
				}
				case 1: { // C
					var t = (uint*) (Buffer + RawOffset + WLen * 4);
					ulong a = t[0], b = t[1];
					return new Buffer<T>(a | ((b & 0xFFFFU) << 32), b >> 16);
				}
				case 2: { // A
					var t = (uint*) (Buffer + DescOffset + XCount * 8 + num * 12);
					ulong a = t[0], b = t[1], c = t[2];
					Debug.Assert((c & 0x3) == flags);
					var buffer = new Buffer<T>(b | (((((c >> 2) << 4) & 0x70) | ((c >> 28) & 0xFU)) << 32),
						a | (((c >> 24) & 0xFU) << 32));
					if(ACount <= num || buffer.Size == 0)
						goto case 3; // X buffer
					return buffer;
				}
				case 3: { // X
					var t = (uint*) (Buffer + DescOffset + num * 8);
					ulong a = t[0], b = t[1];
					return new Buffer<T>(b | ((((a >> 12) & 0xFU) | ((a >> 2) & 0x70U)) << 32), a >> 16);
				}
			}
			return null;
		}
	}

	public unsafe class OutgoingMessage {
		readonly byte* Buffer;
		public bool IsDomainObject;
		public uint ErrCode;
		uint SfcoOffset, RealDataOffset, CopyCount;
		public readonly IncomingMessage Incoming;

		public OutgoingMessage(byte* buffer, bool isDomainObject, IncomingMessage im) {
			Buffer = buffer;
			IsDomainObject = isDomainObject;
			Incoming = im;
		}

		public void Initialize(uint moveCount, uint copyCount, uint dataBytes) {
			CopyCount = copyCount;
			var buf = (uint *) Buffer;
			for(var i = 0; i < 100; ++i)
				buf[i] = 0;
			buf[0] = 0;
			buf[1] = 0;
			if(moveCount != 0 || copyCount != 0) {
				buf[1] = moveCount != 0 && !IsDomainObject || copyCount != 0 ? 1U << 31 : 0;
				buf[2] = (copyCount << 1) | ((IsDomainObject ? 0 : moveCount) << 5);
			}

			var pos = 2 + (moveCount != 0 && !IsDomainObject || copyCount != 0 ? 1 + moveCount + copyCount : 0);
			if((pos & 3) != 0)
				pos += 4 - (pos & 3);
			if(IsDomainObject) {
				buf[pos] = moveCount;
				pos += 4;
			}
			RealDataOffset = IsDomainObject ? moveCount << 2 : 0;
			var dataWords = (RealDataOffset >> 2) + (dataBytes & 3) != 0 ? (dataBytes >> 2) + 1 : dataBytes >> 2;

			buf[1] |= 4U + (IsDomainObject ? 4U : 0) + 4 + dataWords;
 
			SfcoOffset = pos * 4;
			buf[pos] = 0x4f434653; // SFCO
		}

		public void Move(uint offset, uint handle) {
			var buf = (uint*) Buffer;
			if(IsDomainObject)
				buf[(SfcoOffset >> 2) + 4 + offset] = handle;
			else
				buf[3 + CopyCount + offset] = handle;
		}

		public void Bake() {
			var buf = (uint*) Buffer;
			buf[(SfcoOffset >> 2) + 2] = ErrCode;
		}
		
		public void SetData<T>(uint offset, T value) => 
			new Span<T>(Buffer + SfcoOffset + 8 + offset + (offset < 8 ? 0 : RealDataOffset), Marshal.SizeOf<T>())[0] = value;

		public static Action<OutgoingMessage, object> DataSetter(Type T, uint offset) {
			switch(Activator.CreateInstance(T)) {
				case bool _: return (om, v) => om.SetData(offset, (byte) ((bool) v ? 1 : 0));
				case byte _: return (om, v) => om.SetData(offset, (byte) v);
				case ushort _: return (om, v) => om.SetData(offset, (ushort) v);
				case uint _: return (om, v) => om.SetData(offset, (uint) v);
				case ulong _: return (om, v) => om.SetData(offset, (ulong) v);
				case sbyte _: return (om, v) => om.SetData(offset, (sbyte) v);
				case short _: return (om, v) => om.SetData(offset, (short) v);
				case int _: return (om, v) => om.SetData(offset, (int) v);
				case long _: return (om, v) => om.SetData(offset, (long) v);
				case float _: return (om, v) => om.SetData(offset, (float) v);
				case double _: return (om, v) => om.SetData(offset, (double) v);
				default: throw new NotSupportedException($"Can't create data setter of type {T.Name}");
			}
		}

		public static Action<OutgoingMessage, object> BytesSetter(uint offset, uint size) => (om, v) =>
			((byte[]) v).CopyTo(new Span<byte>(
				om.Buffer + om.SfcoOffset + 8 + offset + (offset < 8 ? 0 : om.RealDataOffset), (int) size));
	}
	
	public abstract class IpcInterface : KObject {
		public bool IsDomainObject;
		IpcInterface DomainOwner;
		uint DomainHandleIter = 0xf001;
		const uint ThisHandle = 0xf000;
		readonly Dictionary<uint, KObject> DomainHandles = new Dictionary<uint, KObject>();
		readonly Dictionary<uint, uint> DomainHandleMap = new Dictionary<uint, uint>();
		
		readonly Dictionary<uint, Action<IpcInterface, IncomingMessage, OutgoingMessage>> Commands;
		protected IpcInterface() => Commands = Ipc.AllCommands[GetType()];

		public uint CreateHandle(KObject obj) {
			if(obj == null) return 0xDEADBEEF;
			if(DomainOwner != null) return DomainOwner.CreateHandle(obj);
			if(!IsDomainObject) return obj.Handle;
			if(DomainHandleMap.TryGetValue(obj.Handle, out var dmap)) return dmap;
			var handle = DomainHandleMap[obj.Handle] = DomainHandleIter++;
			DomainHandles[handle] = obj;
			if(obj is IpcInterface iface)
				iface.DomainOwner = this;
			return handle;
		}

		void Dispatch(IncomingMessage incoming, OutgoingMessage outgoing) {
			if(!Commands.TryGetValue(incoming.CommandId, out var cb))
				throw new NotImplementedException($"Unknown message command for service {this}: {incoming.CommandId}");
			cb(this, incoming, outgoing);
		}

		public unsafe uint SyncMessage(ulong bufferAddr, uint bufferSize, out bool closeHandle) {
			var buffer = (byte*) bufferAddr;
			new Span<byte>(buffer, (int) bufferSize).Hexdump();
			var incoming = new IncomingMessage(buffer, IsDomainObject);
			var outgoing = new OutgoingMessage(buffer, IsDomainObject, incoming);
			var ret = 0xF601U;
			closeHandle = false;
			var target = this;
			if(IsDomainObject && incoming.DomainHandle != ThisHandle && incoming.Type == 4)
				target = (IpcInterface) DomainHandles[incoming.DomainHandle];
			if(!IsDomainObject || incoming.DomainCommand == 1 || incoming.Type == 2 || incoming.Type == 5)
				switch(incoming.Type) {
					case 2:
						closeHandle = true;
						outgoing.Initialize(0, 0, 0);
						ret = 0x25a0b;
						break;
					case 4:
					case 6:
						target.Dispatch(incoming, outgoing);
						ret = 0;
						break;
					case 5:
					case 7:
						switch(incoming.CommandId) {
							case 0: // ConvertSessionToDomain
								"Converting session to domain...".Debug();
								outgoing.Initialize(0, 0, 4);
								IsDomainObject = true;
								outgoing.SetData(8, ThisHandle);
								break;
							case 2: // DuplicateSession
								outgoing.IsDomainObject = false;
								outgoing.Initialize(1, 0, 0);
								outgoing.Move(0, Handle);
								break;
							case 3: // QueryPointerBufferSize
								outgoing.Initialize(0, 0, 4);
								outgoing.SetData(8, 0x500U);
								break;
							case 4: // DuplicateSessionEx
								outgoing.IsDomainObject = false;
								outgoing.Initialize(1, 0, 0);
								outgoing.Move(0, Handle);
								outgoing.ErrCode = 0;
								break;
							default:
								throw new NotImplementedException($"Unknown domain command ID: {incoming.CommandId}");
						}
						ret = 0;
						break;
					default:
						throw new NotImplementedException($"Unknown message type: {incoming.Type}");
				}
			else
				switch(incoming.DomainCommand) {
					case 2:
						DomainHandles.Remove(incoming.DomainHandle);
						outgoing.Initialize(0, 0, 0);
						outgoing.ErrCode = 0;
						ret = 0;
						break;
					default:
						throw new NotImplementedException($"Unknown domain command ID: {incoming.DomainCommand}");
				}
			if(ret == 0)
				outgoing.Bake();
			new Span<byte>(buffer, (int) bufferSize).Hexdump();
			return ret;
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class IpcServiceAttribute : Attribute {
		public readonly string Name;
		public IpcServiceAttribute(string name) => Name = name;
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class IpcCommandAttribute : Attribute {
		public readonly uint Id;
		public IpcCommandAttribute(uint id) => Id = id;
	}

	[AttributeUsage(AttributeTargets.Parameter)]
	public class BytesAttribute : Attribute {
		public readonly uint Count;
		public BytesAttribute(uint count) => Count = count;
	}

	[AttributeUsage(AttributeTargets.Parameter)]
	public class BufferAttribute : Attribute {
		public readonly uint Type;
		public BufferAttribute(uint type) => Type = type;
	}
	
	[AttributeUsage(AttributeTargets.Parameter)]
	public class CopyAttribute : Attribute {}
	[AttributeUsage(AttributeTargets.Parameter)]
	public class MoveAttribute : Attribute {}

	[AttributeUsage(AttributeTargets.Parameter)]
	public class PidAttribute : Attribute {}

	public class Buffer<T> where T : struct {
		public readonly ulong Address;
		public readonly int Size;

		public T Value {
			get => GetSpan()[0];
			set => GetSpan()[0] = value;
		}

		public Buffer(ulong address, ulong size) {
			Address = address;
			Size = (int) size;
		}
		
		public Buffer<OtherT> As<OtherT>() where OtherT : struct => new Buffer<OtherT>(Address, (ulong) Size);
		public unsafe Span<T> GetSpan() => new Span<T>((void *) Address, Size);
		public static implicit operator Span<T>(Buffer<T> buffer) => buffer.GetSpan();

		public static unsafe void ScopedSpan(Span<byte> span, Action<Buffer<T>> func) {
			fixed(byte* ptr = span)
				func(new Buffer<T>((ulong) ptr, (ulong) span.Length));
		}
	}
	
	public class IpcManager {
		readonly Dictionary<string, Type> Services;

		public readonly Dictionary<Type, Dictionary<uint, Action<IpcInterface, IncomingMessage, OutgoingMessage>>>
			AllCommands;
		
		static Action<IpcInterface, IncomingMessage, OutgoingMessage> BuildHandler(uint cmdId, MethodInfo mi) {
			var pre = new Func<IncomingMessage, object>[mi.GetParameters().Length];
			var post = new Action<IpcInterface, OutgoingMessage, object>[mi.GetParameters().Length];

			var inputOffset = 8U;
			var outputOffset = 8U;
			var moveCount = 0U;
			var copyCount = 0U;
			var dataBytes = 0U;
			var bufferNums = new Dictionary<uint, int>();
			mi.GetParameters().ForEach((p, i) => {
				if(!p.IsOut) {
					if(p.HasAttribute<PidAttribute>())
						pre[i] = im => {
							Debug.Assert(im.HasPid);
							return im.Pid;
						};
					else if(p.TryGetAttribute<BytesAttribute>(out var bytesAttribute)) {
						pre[i] = IncomingMessage.BytesGetter(inputOffset, bytesAttribute.Count);
						inputOffset += bytesAttribute.Count;
					} else if(p.TryGetAttribute<BufferAttribute>(out var bufferAttribute)) {
						var t = p.ParameterType.GenericTypeArguments[0];
						if(!bufferNums.ContainsKey(bufferAttribute.Type))
							bufferNums[bufferAttribute.Type] = 0;
						var cbo = bufferNums[bufferAttribute.Type];
						bufferNums[bufferAttribute.Type]++;
						if(t == typeof(byte))
							pre[i] = im => im.GetBuffer<byte>(bufferAttribute.Type, cbo);
						else if(t == typeof(sbyte))
							pre[i] = im => im.GetBuffer<sbyte>(bufferAttribute.Type, cbo);
						else if(t == typeof(uint))
							pre[i] = im => im.GetBuffer<uint>(bufferAttribute.Type, cbo);
						else
							throw new NotImplementedException($"Unknown buffer type {t.Name}");
					} else if(p.ParameterType == typeof(object))
						pre[i] = im => null;
					else if(p.ParameterType == typeof(KObject))
						pre[i] = im => null;
					else {
						var type = p.ParameterType;
						pre[i] = IncomingMessage.DataGetter(type, inputOffset);
						inputOffset += (uint) Marshal.SizeOf(type.IsEnum ? Enum.GetUnderlyingType(type) : type);
					}
				} else {
					var type = p.ParameterType.GetElementType();
					if(type == typeof(KObject) || type.IsSubclassOf(typeof(KObject))) {
						if(p.HasAttribute<MoveAttribute>()) {
							var movePos = moveCount++;
							post[i] = (s, om, v) => om.Move(movePos, s.CreateHandle((KObject) v));
						} else throw new NotSupportedException();
					} else if(p.TryGetAttribute<BytesAttribute>(out var bytesAttribute)) {
						var bs = OutgoingMessage.BytesSetter(outputOffset, bytesAttribute.Count);
						post[i] = (_, om, v) => bs(om, v);
						outputOffset += bytesAttribute.Count;
					} else if(type == typeof(object))
						post[i] = (_, im, v) => { };
					else {
						//$"{p.Name} -- {type.Name}".Debug();
						var ds = OutgoingMessage.DataSetter(type, outputOffset);
						post[i] = (_, om, v) => ds(om, v);
						outputOffset += (uint) Marshal.SizeOf(type);
					}
				}
			});

			var argCount = mi.GetParameters().Length;
			if(mi.ReturnType == typeof(void))
				return (s, im, om) => {
					var args = new object[argCount];
					for(var i = 0; i < argCount; ++i)
						args[i] = pre[i]?.Invoke(im);
					
					try {
						mi.Invoke(s, args);
					} catch(TargetInvocationException e) {
						if(!(e.InnerException is NotImplementedException)) throw;
						$"{s.GetType().FullName} {mi.Name} [{cmdId}] not implemented".Debug();
						Environment.Exit(1);
					}
					
					om.Initialize(moveCount, copyCount, dataBytes);
					om.ErrCode = 0;
					for(var i = 0; i < argCount; ++i)
						post[i]?.Invoke(s, om, args[i]);
				};
			if(mi.ReturnType == typeof(uint))
				return (s, im, om) => {
					var args = new object[argCount];
					for(var i = 0; i < argCount; ++i)
						args[i] = pre[i]?.Invoke(im);
					
					try {
						om.ErrCode = (uint) mi.Invoke(s, args);
					} catch(TargetInvocationException e) {
						if(!(e.InnerException is NotImplementedException)) throw;
						$"{s.GetType().FullName} {mi.Name} [{cmdId}] not implemented".Debug();
						Environment.Exit(1);
					}
					
					om.Initialize(moveCount, copyCount, dataBytes);
					for(var i = 0; i < argCount; ++i)
						post[i]?.Invoke(s, om, args[i]);
				};
			throw new NotSupportedException(
				$"Return from function {mi.DeclaringType.FullName}.{mi.Name} should be void or uint.");
		}
		
		public IpcManager() {
			Services = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.SelectMany(x =>
					x.GetCustomAttributes(typeof(IpcServiceAttribute), true)
						.Select(y => (((IpcServiceAttribute) y).Name, x)))
				.ToDictionary();
			
			AllCommands = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.Where(t => t.IsSubclassOf(typeof(IpcInterface))).Select(
					t => (t, t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
						.SelectMany(x =>
							x.GetCustomAttributes(typeof(IpcCommandAttribute))
								.Select(y => (((IpcCommandAttribute) y).Id, MI: x)))
						.Select(x => (x.Id, BuildHandler(x.Id, x.MI))).ToDictionary()))
				.ToDictionary();
		}

		public IpcInterface CreateService(string name) =>
			Services.TryGetValue(name, out var type)
				? (IpcInterface) Activator.CreateInstance(type)
				: throw new NotSupportedException($"Unknown service name {name.ToPrettyString()}");

		[Svc(0x1F)]
		public (uint, uint) ConnectToNamedPort(uint _, ulong _name) {
			var name = Marshal.PtrToStringAnsi((IntPtr) _name);
			$"ConnectToNamedPort({name.ToPrettyString()})".Debug();
			return (0, CreateService(name).Handle);
		}

		[Svc(0x21)]
		public uint SendSyncRequest(uint handle) {
			var service = Kernel.Get<IpcInterface>(handle);
			$"SendSyncRequest({handle:X}, {service?.ToString() ?? "null"}, domain: {service?.IsDomainObject})".Debug();
			if(service == null)
				throw new Exception();
			var ret = service.SyncMessage(Thread.CurrentThread.TlsBase, 0x100, out var closeHandle);
			if(closeHandle)
				Kernel.Close(service);
			return ret;
		}
	}
}