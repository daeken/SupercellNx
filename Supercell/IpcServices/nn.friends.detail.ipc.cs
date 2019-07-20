using System;
// ReSharper disable CheckNamespace
namespace Supercell.IpcServices.Nn.Friends.Detail.Ipc {
	public partial class IServiceCreator {
		public override Nn.Friends.Detail.Ipc.IFriendService CreateFriendService() => new IFriendService();
		
		public override Nn.Friends.Detail.Ipc.INotificationService CreateNotificationService(byte[] _0) => throw new NotImplementedException();
		public override Nn.Friends.Detail.Ipc.IDaemonSuspendSessionService CreateDaemonSuspendSessionService() => throw new NotImplementedException();
	}
}
