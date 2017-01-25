namespace MudClient.Common.Extensions {

	#region Directives
	using System.Net.Sockets;
	#endregion

	public static class TcpClientExtension {


		/// <summary>
		/// Determines whether the socket has been disconnected by the host server.
		/// </summary>
		/// <param name="client">The client.</param>
		/// <returns><c>true</c> if [is socket connected] [the specified client]; otherwise, <c>false</c>.</returns>
		public static bool IsSocketConnected(this TcpClient client) {
			if (!client.Connected) return false;
			if (client.Client.Poll(0, SelectMode.SelectRead)) {
				var buffer = new byte[1];
				return client.Client.Receive(buffer, SocketFlags.Peek) != 0;
			}
			return true;
		}

	}
}
