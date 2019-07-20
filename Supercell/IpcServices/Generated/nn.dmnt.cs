#pragma warning disable 169, 465
using System;
using UltimateOrb;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Dmnt {
	[IpcService("dmnt:-")]
	public unsafe partial class IInterface : _Base_IInterface {}
	public unsafe class _Base_IInterface : IpcInterface {
		public void Dispatch(IncomingMessage im, OutgoingMessage om) {
			switch(im.CommandId) {
				case 0: { // BreakDebugProcess
					var ret = BreakDebugProcess(null);
					break;
				}
				case 1: { // TerminateDebugProcess
					var ret = TerminateDebugProcess(null);
					break;
				}
				case 2: { // CloseHandle
					var ret = CloseHandle(null);
					break;
				}
				case 3: { // LoadImage
					var ret = LoadImage(null);
					break;
				}
				case 4: { // GetProcessId
					var ret = GetProcessId(null);
					break;
				}
				case 5: { // GetProcessHandle
					var ret = GetProcessHandle(null);
					break;
				}
				case 6: { // WaitSynchronization
					var ret = WaitSynchronization(null);
					break;
				}
				case 7: { // GetDebugEvent
					var ret = GetDebugEvent(null);
					break;
				}
				case 8: { // GetProcessModuleInfo
					var ret = GetProcessModuleInfo(null);
					break;
				}
				case 9: { // GetProcessList
					var ret = GetProcessList(null);
					break;
				}
				case 10: { // GetThreadList
					var ret = GetThreadList(null);
					break;
				}
				case 11: { // GetDebugThreadContext
					var ret = GetDebugThreadContext(null);
					break;
				}
				case 12: { // ContinueDebugEvent
					var ret = ContinueDebugEvent(null);
					break;
				}
				case 13: { // ReadDebugProcessMemory
					var ret = ReadDebugProcessMemory(null);
					break;
				}
				case 14: { // WriteDebugProcessMemory
					var ret = WriteDebugProcessMemory(null);
					break;
				}
				case 15: { // SetDebugThreadContext
					var ret = SetDebugThreadContext(null);
					break;
				}
				case 16: { // GetDebugThreadParam
					var ret = GetDebugThreadParam(null);
					break;
				}
				case 17: { // InitializeThreadInfo
					var ret = InitializeThreadInfo(null);
					break;
				}
				case 18: { // SetHardwareBreakPoint
					var ret = SetHardwareBreakPoint(null);
					break;
				}
				case 19: { // QueryDebugProcessMemory
					var ret = QueryDebugProcessMemory(null);
					break;
				}
				case 20: { // GetProcessMemoryDetails
					var ret = GetProcessMemoryDetails(null);
					break;
				}
				case 21: { // AttachByProgramId
					var ret = AttachByProgramId(null);
					break;
				}
				case 22: { // AttachOnLaunch
					var ret = AttachOnLaunch(null);
					break;
				}
				case 23: { // GetDebugMonitorProcessId
					var ret = GetDebugMonitorProcessId(null);
					break;
				}
				case 25: { // GetJitDebugProcessList
					var ret = GetJitDebugProcessList(null);
					break;
				}
				case 26: { // CreateCoreDump
					var ret = CreateCoreDump(null);
					break;
				}
				case 27: { // GetAllDebugThreadInfo
					var ret = GetAllDebugThreadInfo(null);
					break;
				}
				case 29: { // TargetIOFileOpen
					var ret = TargetIOFileOpen(null);
					break;
				}
				case 30: { // TargetIOFileClose
					var ret = TargetIOFileClose(null);
					break;
				}
				case 31: { // TargetIOFileRead
					var ret = TargetIOFileRead(null);
					break;
				}
				case 32: { // TargetIOFileWrite
					var ret = TargetIOFileWrite(null);
					break;
				}
				case 33: { // TargetIOFileSetAttributes
					var ret = TargetIOFileSetAttributes(null);
					break;
				}
				case 34: { // TargetIOFileGetInformation
					var ret = TargetIOFileGetInformation(null);
					break;
				}
				case 35: { // TargetIOFileSetTime
					var ret = TargetIOFileSetTime(null);
					break;
				}
				case 36: { // TargetIOFileSetSize
					var ret = TargetIOFileSetSize(null);
					break;
				}
				case 37: { // TargetIOFileDelete
					var ret = TargetIOFileDelete(null);
					break;
				}
				case 38: { // TargetIOFileMove
					var ret = TargetIOFileMove(null);
					break;
				}
				case 39: { // TargetIODirectoryCreate
					var ret = TargetIODirectoryCreate(null);
					break;
				}
				case 40: { // TargetIODirectoryDelete
					var ret = TargetIODirectoryDelete(null);
					break;
				}
				case 41: { // TargetIODirectoryRename
					var ret = TargetIODirectoryRename(null);
					break;
				}
				case 42: { // TargetIODirectoryGetCount
					var ret = TargetIODirectoryGetCount(null);
					break;
				}
				case 43: { // TargetIODirectoryOpen
					var ret = TargetIODirectoryOpen(null);
					break;
				}
				case 44: { // TargetIODirectoryGetNext
					var ret = TargetIODirectoryGetNext(null);
					break;
				}
				case 45: { // TargetIODirectoryClose
					var ret = TargetIODirectoryClose(null);
					break;
				}
				case 46: { // TargetIOGetFreeSpace
					var ret = TargetIOGetFreeSpace(null);
					break;
				}
				case 47: { // TargetIOGetVolumeInformation
					var ret = TargetIOGetVolumeInformation(null);
					break;
				}
				case 48: { // InitiateCoreDump
					var ret = InitiateCoreDump(null);
					break;
				}
				case 49: { // ContinueCoreDump
					var ret = ContinueCoreDump(null);
					break;
				}
				case 50: { // AddTTYToCoreDump
					var ret = AddTTYToCoreDump(null);
					break;
				}
				case 51: { // AddImageToCoreDump
					var ret = AddImageToCoreDump(null);
					break;
				}
				case 52: { // CloseCoreDump
					var ret = CloseCoreDump(null);
					break;
				}
				default:
					throw new NotImplementedException($"Unhandled command ID to IInterface: {im.CommandId}");
			}
		}
		
		public virtual object BreakDebugProcess(object _0) => throw new NotImplementedException();
		public virtual object TerminateDebugProcess(object _0) => throw new NotImplementedException();
		public virtual object CloseHandle(object _0) => throw new NotImplementedException();
		public virtual object LoadImage(object _0) => throw new NotImplementedException();
		public virtual object GetProcessId(object _0) => throw new NotImplementedException();
		public virtual object GetProcessHandle(object _0) => throw new NotImplementedException();
		public virtual object WaitSynchronization(object _0) => throw new NotImplementedException();
		public virtual object GetDebugEvent(object _0) => throw new NotImplementedException();
		public virtual object GetProcessModuleInfo(object _0) => throw new NotImplementedException();
		public virtual object GetProcessList(object _0) => throw new NotImplementedException();
		public virtual object GetThreadList(object _0) => throw new NotImplementedException();
		public virtual object GetDebugThreadContext(object _0) => throw new NotImplementedException();
		public virtual object ContinueDebugEvent(object _0) => throw new NotImplementedException();
		public virtual object ReadDebugProcessMemory(object _0) => throw new NotImplementedException();
		public virtual object WriteDebugProcessMemory(object _0) => throw new NotImplementedException();
		public virtual object SetDebugThreadContext(object _0) => throw new NotImplementedException();
		public virtual object GetDebugThreadParam(object _0) => throw new NotImplementedException();
		public virtual object InitializeThreadInfo(object _0) => throw new NotImplementedException();
		public virtual object SetHardwareBreakPoint(object _0) => throw new NotImplementedException();
		public virtual object QueryDebugProcessMemory(object _0) => throw new NotImplementedException();
		public virtual object GetProcessMemoryDetails(object _0) => throw new NotImplementedException();
		public virtual object AttachByProgramId(object _0) => throw new NotImplementedException();
		public virtual object AttachOnLaunch(object _0) => throw new NotImplementedException();
		public virtual object GetDebugMonitorProcessId(object _0) => throw new NotImplementedException();
		public virtual object GetJitDebugProcessList(object _0) => throw new NotImplementedException();
		public virtual object CreateCoreDump(object _0) => throw new NotImplementedException();
		public virtual object GetAllDebugThreadInfo(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileOpen(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileClose(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileRead(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileWrite(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileSetAttributes(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileGetInformation(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileSetTime(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileSetSize(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileDelete(object _0) => throw new NotImplementedException();
		public virtual object TargetIOFileMove(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryCreate(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryDelete(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryRename(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryGetCount(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryOpen(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryGetNext(object _0) => throw new NotImplementedException();
		public virtual object TargetIODirectoryClose(object _0) => throw new NotImplementedException();
		public virtual object TargetIOGetFreeSpace(object _0) => throw new NotImplementedException();
		public virtual object TargetIOGetVolumeInformation(object _0) => throw new NotImplementedException();
		public virtual object InitiateCoreDump(object _0) => throw new NotImplementedException();
		public virtual object ContinueCoreDump(object _0) => throw new NotImplementedException();
		public virtual object AddTTYToCoreDump(object _0) => throw new NotImplementedException();
		public virtual object AddImageToCoreDump(object _0) => throw new NotImplementedException();
		public virtual object CloseCoreDump(object _0) => throw new NotImplementedException();
	}
}
