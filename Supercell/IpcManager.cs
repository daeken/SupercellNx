using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

		T GetData<T>(uint offset) {
			return new Span<T>(Buffer + SfciOffset + 8 + offset, Marshal.SizeOf<T>())[0];
		}

		public static Func<IncomingMessage, object> DataGetter(Type T, uint offset) {
			switch(Activator.CreateInstance(T)) {
				case byte _: return im => im.GetData<byte>(offset);
				case ushort _: return im => im.GetData<ushort>(offset);
				case uint _: return im => im.GetData<uint>(offset);
				case ulong _: return im => im.GetData<ulong>(offset);
				case sbyte _: return im => im.GetData<sbyte>(offset);
				case short _: return im => im.GetData<short>(offset);
				case int _: return im => im.GetData<int>(offset);
				case long _: return im => im.GetData<long>(offset);
				default: throw new NotSupportedException($"Can't create data getter of type {T.Name}");
			}
		}

		public static Func<IncomingMessage, object> BytesGetter(uint offset, uint size) => im =>
			new Span<byte>(im.Buffer + im.SfciOffset + 8 + offset, (int) size).ToArray();
	}

	public unsafe class OutgoingMessage {
		readonly byte* Buffer;
		public readonly bool IsDomainObject;
		public uint ErrCode;
		uint SfcoOffset, RealDataOffset, CopyCount;

		public OutgoingMessage(byte* buffer, bool isDomainObject) {
			Buffer = buffer;
			IsDomainObject = isDomainObject;
		}

		public void Initialize(uint moveCount, uint copyCount, uint dataBytes) {
			CopyCount = copyCount;
			var buf = (uint *) Buffer;
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
			var buf = (uint *) Buffer;
			if(IsDomainObject)
				buf[(SfcoOffset >> 2) + 4 + offset] = handle;
			else
				buf[3 + CopyCount + offset] = handle;
		}

		public void Bake() {
			var buf = (uint *) Buffer;
			buf[(SfcoOffset >> 2) + 2] = ErrCode;
		}
	}
	
	public abstract class IpcInterface : KObject {
		// TODO: Refactor this so it happens at emulator startup
		readonly Dictionary<uint, Action<IncomingMessage, OutgoingMessage>> Commands;
		protected IpcInterface() =>
			Commands = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				.SelectMany(x =>
					x.GetCustomAttributes(typeof(IpcCommandAttribute)).Select(y => (((IpcCommandAttribute) y).Id, MI: x)))
				.Select(x => (x.Id, BuildHandler(x.Id, x.MI)))
				.ToDictionary();

		Action<IncomingMessage, OutgoingMessage> BuildHandler(uint cmdId, MethodInfo mi) {
			// TODO: Refactor this so these builder lists don't stick around
			var inputBuilders = new List<Func<IncomingMessage, object>>();
			var outputBuilders = new List<Action<OutgoingMessage, object>>();

			var inputOffset = 8U;
			var moveCount = 0U;
			var copyCount = 0U;
			var dataBytes = 0U;
			mi.GetParameters().ForEach(p => {
				if(!p.IsOut) {
					if(p.HasAttribute<PidAttribute>())
						inputBuilders.Add(im => {
							Debug.Assert(im.HasPid);
							return im.Pid;
						});
					else if(p.TryGetAttribute<BytesAttribute>(out var bytesAttribute)) {
						inputBuilders.Add(IncomingMessage.BytesGetter(inputOffset, bytesAttribute.Count));
						inputOffset += bytesAttribute.Count;
					} else {
						var type = p.ParameterType;
						inputBuilders.Add(IncomingMessage.DataGetter(type, inputOffset));
						inputOffset += (uint) Marshal.SizeOf(type);
					}
				} else {
					var type = p.ParameterType.GetElementType();
					if(type.IsSubclassOf(typeof(KObject))) {
						if(p.HasAttribute<MoveAttribute>()) {
							var movePos = moveCount++;
							outputBuilders.Add((om, v) => om.Move(movePos, ((KObject) v)?.Handle ?? 0xDEADBEEF));
						} else throw new NotSupportedException();
					} else throw new NotSupportedException();
				}
			});

			var inputFuncs = inputBuilders.ToArray();
			var outputFuncs = outputBuilders.ToArray();
			var argCount = inputFuncs.Length + outputFuncs.Length;
			if(mi.ReturnType == typeof(void))
				return (im, om) => {
					var args = new object[argCount];
					for(var i = 0; i < inputFuncs.Length; ++i)
						args[i] = inputFuncs[i](im);
					mi.Invoke(this, args);
					om.Initialize(moveCount, copyCount, dataBytes);
					om.ErrCode = 0;
					for(var i = 0; i < outputFuncs.Length; ++i)
						outputFuncs[i](om, args[inputFuncs.Length + i]);
				};
			if(mi.ReturnType == typeof(uint))
				return (im, om) => {
					var args = new object[argCount];
					for(var i = 0; i < inputFuncs.Length; ++i)
						args[i] = inputFuncs[i](im);
					om.ErrCode = (uint) mi.Invoke(this, args);
					om.Initialize(moveCount, copyCount, dataBytes);
					for(var i = 0; i < outputFuncs.Length; ++i)
						outputFuncs[i](om, args[inputFuncs.Length + i]);
				};
			throw new NotSupportedException(
				$"Return from function {mi.DeclaringType.FullName}.{mi.Name} should be void or uint.");
		}

		public unsafe uint SyncMessage(ulong bufferAddr, uint bufferSize, out bool closeHandle) {
			var buffer = (byte*) bufferAddr;
			new Span<byte>(buffer, (int) bufferSize).Hexdump();
			var incoming = new IncomingMessage(buffer);
			var outgoing = new OutgoingMessage(buffer, false);
			var ret = 0xF601U;
			closeHandle = false;
			switch(incoming.Type) {
				case 2:
					closeHandle = true;
					outgoing.Initialize(0, 0, 0);
					ret = 0x25a0b;
					break;
				case 4:
				case 6:
					if(!Commands.TryGetValue(incoming.CommandId, out var cb))
						throw new NotImplementedException($"Unknown message command for service {this}: {incoming.CommandId}");
					cb(incoming, outgoing);
					ret = 0;
					break;
				default:
					throw new NotImplementedException($"Unknown message type: {incoming.Type}");
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
	public class CopyAttribute : Attribute {}
	[AttributeUsage(AttributeTargets.Parameter)]
	public class MoveAttribute : Attribute {}

	[AttributeUsage(AttributeTargets.Parameter)]
	public class PidAttribute : Attribute {}
	
	public class IpcManager {
		readonly Dictionary<string, Type> Services;

		public IpcManager() {
			Services = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.SelectMany(x =>
					x.GetCustomAttributes(typeof(IpcServiceAttribute), true)
						.Select(y => (((IpcServiceAttribute) y).Name, x)))
				.ToDictionary();
		}

		public IpcInterface CreateService(string name) =>
			Services.TryGetValue(name, out var type)
				? (IpcInterface) Activator.CreateInstance(type)
				: throw new NotImplementedException($"Unknown service name {name.ToPrettyString()}");

		[Svc(0x1F)]
		public (uint, uint) ConnectToNamedPort(uint _, ulong _name) {
			var name = Marshal.PtrToStringAnsi((IntPtr) _name);
			$"ConnectToNamedPort({name.ToPrettyString()})".Debug();
			return (0, CreateService(name).Handle);
		}

		[Svc(0x21)]
		public uint SendSyncRequest(uint handle) {
			var service = Kernel.Get<IpcInterface>(handle);
			$"SendSyncRequest({handle:X}, {service?.ToString() ?? "null"})".Debug();
			if(service == null)
				throw new Exception();
			var ret = service.SyncMessage(Thread.CurrentThread.TlsBase, 0x100, out var closeHandle);
			if(closeHandle)
				Kernel.Close(service);
			return ret;
		}
	}
}