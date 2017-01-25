namespace MudClient.Core.Client {

	#region Directives
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Net.Sockets;
	using System.Text;
	using System.Threading;
	using Common;
	using MudClient.Common.Extensions;
	#endregion

	public class ConnectionClient {

		//TODO: Create an event handler for OnConnectionFailed
		//TODO: Create an event handler for OnConnectionAttempted

		#region Events

		#region OnMessageReceived

		public delegate void MessageReceivedEventHandler(object sender, MessageEventArgs e);

		public event MessageReceivedEventHandler OnMessageReceived;

		#endregion

		#region OnMessageSent

		public delegate void MessageSentEventHandler(object sender, MessageEventArgs e);

		public event MessageSentEventHandler OnMessageSent;

		#endregion

		#region OnClientDisconnected

		public delegate void ClientDisconnectedEventHandler(object sender);

		public event ClientDisconnectedEventHandler OnClientDisconnected;

		#endregion

		#region OnConnectionEstablished

		public delegate void ClientConnectedEventHander(object sender);

		public ClientConnectedEventHander OnConnectionEstablished;

		#endregion

		#endregion

		#region Properties

		#region DataBuffer

		private byte[] _dataBuffer = new byte[1024 * 8 /*8KB*/];

		#endregion

		#region HostAddress

		private string _hostAddress = "localhost";

		/// <summary>
		/// Gets or sets the host address.
		/// </summary>
		/// <value>The host address.</value>
		public string HostAddress {
			get { return _hostAddress; }
			set { _hostAddress = value; }
		}

		#endregion

		#region HostPort

		private int _port = 3791;

		/// <summary>
		/// Gets or sets the port.
		/// </summary>
		/// <value>The port.</value>
		public int HostPort {
			get { return _port; }
			set { _port = value; }
		}

		#endregion

		#region ControlClient

		private TcpClient _controlClient;

		/// <summary>
		/// Gets or sets the control client.
		/// </summary>
		/// <value>The control client.</value>
		public TcpClient ControlClient {
			get {
				if (_controlClient == null) {
					_controlClient = new TcpClient();
					_controlClient.NoDelay = true;
					_controlClient.Client.NoDelay = true;
					_controlClient.Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
					//TODO: Fix encoding
				}
				return _controlClient;
			}
			set { _controlClient = value; }
		}

		#endregion

		#region ControlStream

		/// <summary>
		/// Gets or sets the control stream.
		/// </summary>
		/// <value>The control stream.</value>
		private NetworkStream ControlStream { get; set; }

		#endregion

		#region ControlReader

		/// <summary>
		/// Gets or sets the control reader.
		/// </summary>
		/// <value>The control reader.</value>
		public StreamReader ControlReader { get; set; }

		#endregion

		#region ControlWriter

		/// <summary>
		/// Gets or sets the control writer.
		/// </summary>
		/// <value>The control writer.</value>
		private StreamWriter ControlWriter { get; set; }

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandClient"/> class.
		/// </summary>
		public ConnectionClient() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandClient"/> class.
		/// </summary>
		/// <param name="hostAddress">The host address.</param>
		/// <param name="port">The port.</param>
		private ConnectionClient(string hostAddress, int port) {
			this.HostAddress = hostAddress;
			this.HostPort = port;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Begins the connect.
		/// </summary>
		/// <exception cref="System.ArgumentException"></exception>
		private void BeginConnect() {
			try {
				this.OnMessageReceived?.Invoke(this, new MessageEventArgs($"#Trying to connect to {this.HostAddress}:{this.HostPort}"));
				this.ControlClient.BeginConnect(
					this.HostAddress,
					this.HostPort,
					new AsyncCallback(OnBeginConnect),
					this.ControlClient
					);
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
			}
		}

		/// <summary>
		/// Begins listening for a message sent by the server.
		/// </summary>
		private void BeginRead() {
			try {
				if (this.ControlClient.Connected) {
					this.ControlStream.BeginRead(_dataBuffer, 0, _dataBuffer.Length, new AsyncCallback(OnBeginReceive), null);
				}
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
			}
		}

		/// <summary>
		/// Connects <see cref="TcpClient" /> asynchronously
		/// </summary>
		/// <param name="hostAddress">The host address.</param>
		/// <param name="hostPort">The host port.</param>
		public void Connect(string hostAddress, int hostPort) {
			try {
				if (!this.ControlClient.Connected) {
					this.HostAddress = hostAddress;
					this.HostPort = hostPort;
					this.BeginConnect();
				}
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
			}
		}

		/// <summary>
		/// Sends the specified message to the <see cref="TcpClient"/>
		/// </summary>
		/// <param name="message">The message.</param>
		public void SendMessage(string message) {
			try {

				if (this.ControlClient.Connected) {
					ThreadPool.QueueUserWorkItem(obj => {
						this.ControlWriter.WriteLine(message);
						this.ControlWriter.Flush();
					});
					this.OnMessageSent?.Invoke(this, new MessageEventArgs(message));
				}
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
			}
		}

		#endregion

		#region Asynchronous

		#region OnBeginConnectCompleted

		/// <summary>
		/// Connections the established.
		/// </summary>
		/// <param name="result">The result.</param>
		private void OnBeginConnect(IAsyncResult result) {
			try {
				if (!this.ControlClient.Connected) {
					this.OnMessageReceived?.Invoke(this, new MessageEventArgs($"#Failed to connect to {this.HostAddress}:{this.HostPort}"));
					return;
				}
				this.OnMessageReceived?.Invoke(this, new MessageEventArgs($"#Connected to {this.HostAddress}:{this.HostPort}"));
				this.ControlStream = this.ControlClient.GetStream();
				this.ControlWriter = new StreamWriter(this.ControlStream, Encoding.Default);
				this.ControlReader = new StreamReader(this.ControlStream, Encoding.UTF8);
				this.OnConnectionEstablished?.Invoke(this);
				this.BeginRead();
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
			}
		}

		#endregion

		#region OnBeginReceive

		/// <summary>
		/// Event fired when the control stream receives a new message from the <see cref="TcpClient"/>
		/// </summary>
		/// <param name="result">The results.</param>
		private void OnBeginReceive(IAsyncResult result) {
			try {
				if (this.ControlClient.Connected) {
					var message = Encoding.Default.GetString(_dataBuffer, 0, this.ControlStream.EndRead(result));
					if (!string.IsNullOrWhiteSpace(message) || this.ControlClient.IsSocketConnected()) {
						this.OnMessageReceived?.Invoke(this, new MessageEventArgs(message));
						this.BeginRead();
					}
					else {
						this.ControlClient.Client.Disconnect(true);
						this.OnClientDisconnected?.Invoke(this);
					}
				}
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
			}
		}

		#endregion

		#endregion

	}

}