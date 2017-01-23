namespace MudClient.Management {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Windows.Forms;
	using System.Xml.Linq;
	using CommandClient.Common;
	using Core;
	using Core.Client;
	using Core.Common;
	using Extensions;
	using MudClient.Common.Extensions;
	#endregion

	public partial class MudClientForm
		: Form {
		//TODO: Create a connection builder type class which contains the command parse and options
		//TODO: Migrate all code to a separate class.

		#region Constants

		#region Configuration File Name
		private const string CONFIGURATION_FILE_NAME = "SimpleMudClient.xml";
		#endregion

		#region Commands
		private const string COMMAND_ACTION = @"#ACTION";
		private const string COMMAND_ALIAS = @"#ALIAS";
		private const string COMMAND_CONNECT = @"#CONNECT";
		private const string COMMAND_HOTKEY = @"#HOTKEY";
		#endregion

		#endregion

		#region Properties

		#region ConfigurationFilePath

		private string _configurationFileDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create)}\\Simple Mud Client";

		/// <summary>
		/// Gets the configuration file path.
		/// </summary>
		/// <value>The configuration file path.</value>
		public string ConfigurationFilePath {
			get { return Path.Combine(_configurationFileDirectory, CONFIGURATION_FILE_NAME); }
		}

		#endregion

		#region ClientManager

		private MudClientManager _clientManager;

		/// <summary>
		/// Gets the client manager.
		/// </summary>
		/// <value>The client manager.</value>
		public MudClientManager ClientManager {
			get { return _clientManager ?? (_clientManager = new MudClientManager()); }
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MudClientForm" /> class.
		/// </summary>
		public MudClientForm() {
			InitializeComponent();
			this.KeyPreview = true;
		}

		#endregion

		#region Base Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			if (!this.textBox.Focused) {
				this.textBox.Focus();
			}

			try {
				var hotKey = this.ClientManager.ProfileCollection.SelectedProfile.HotKeys[e.KeyData];
				if (hotKey != null) {
					this.HandleInput(hotKey.CommandText);
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
				else if (e.KeyCode == Keys.Enter) {
					this.HandleInput(this.textBox.Text);
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			catch (Exception caught) {
				this.WriteToOutput($"#Error processing command: {caught.Message}", false, true);
			}
		}

		/// <summary>
		/// Handles the input.
		/// </summary>
		/// <param name="input">The input.</param>
		private void HandleInput(string input) {
			var inputLines = (input ?? string.Empty).Split(new[] { this.ClientManager.OptionManager.CommandDelimiter }, StringSplitOptions.None);
			foreach (var inputLine in inputLines) {
				var inputStringSplit = inputLine.Split(' ');
				switch (inputStringSplit[0].ToUpper()) {
					case COMMAND_CONNECT:
						this.ConnectToClient(inputStringSplit);
						break;
					case COMMAND_HOTKEY:
						this.ProcessHotKeyCommand(inputStringSplit);
						break;
					default:
						this.SendMessage(inputLine);
						break;
				}
			}
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="inputLine">The input line.</param>
		private void SendMessage(string inputLine) {
			this.ClientManager.ConnectionClient.SendMessage(inputLine);
		}

		/// <summary>
		/// Processes the new hotkey.
		/// </summary>
		/// <param name="inputParts">The input parts.</param>
		private void ProcessHotKeyCommand(string[] inputParts) {
			if (inputParts.Length != 3) {
				throw new MudException(null, $"The {COMMAND_HOTKEY} command requires 3 parts.");
			}

			var keys = this.ClientManager.ProfileCollection.SelectedProfile.HotKeys.ResolveKeys(inputParts[1]);
			if (keys == Keys.Enter) {
				throw new MudException(null, @"Enter cannot be used as a hotkey.");
			}

			if (this.ClientManager.ProfileCollection.SelectedProfile.HotKeys[keys] != null) {
				throw new MudException(null, $"The key combination already exists.");
			}

			if (string.IsNullOrWhiteSpace(inputParts[2])) {
				throw new MudException(null, @"The command text cannot be blank.");
			}

			this.ClientManager.ProfileCollection.SelectedProfile.HotKeys.Add(keys, inputParts[2]);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			try {
				this.LoadConfiguration();
				this.BindUIFormatting();
				this.ClientManager.ConnectionClient.OnMessageReceived += connectionClient_MessageReceived;
				this.ClientManager.ConnectionClient.OnMessageSent += connectionClient_MessageSent;
				this.ClientManager.ConnectionClient.OnClientDisconnected += connectionClient_Disconnected;
				this.ClientManager.ConnectionClient.OnConnectionEstablished += connectionClient_Connected;
				this.textBox.Focus();
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure loading client: {caught.Message}", @"Failure Loading Client...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Methods

		#region Configuration

		/// <summary>
		/// Loads the configuration.
		/// </summary>
		private void LoadConfiguration() {
			if (File.Exists(this.ConfigurationFilePath)) {
				try {
					this.ClientManager.ManagerXml = XElement.Load(this.ConfigurationFilePath);
				}
				catch (Exception caught) {
					throw new MudException(null, $"Failure loading configuration: {caught.Message}");
				}
			}
		}

		/// <summary>
		/// Saves the configuration.
		/// </summary>
		private void SaveConfiguration() {
			if (!Directory.Exists(_configurationFileDirectory)) {
				Directory.CreateDirectory(_configurationFileDirectory);
			}
			try {
				this.ClientManager.ManagerXml.Save(this.ConfigurationFilePath);
			}
			catch (Exception caught) {
				throw new MudException(caught, $"Failure saving configuration: {caught.Message}");
			}
		}

		#endregion

		/// <summary>
		/// Binds the UI formatting.
		/// </summary>
		private void BindUIFormatting() {
			this.richTextBox.BackColor = this.ClientManager.OptionManager.BackgroundColor;
			this.richTextBox.ForeColor = this.ClientManager.OptionManager.ForegroundColor;
			this.richTextBox.Font = this.ClientManager.OptionManager.Font;
		}

		/// <summary>
		/// Connects to client.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		private void ConnectToClient(string[] parameters) {
			if (parameters.Length == 3) {
				var hostAddress = parameters[1];
				var hostPortString = parameters[2];
				int hostPort;
				if (!int.TryParse(hostPortString, NumberStyles.Integer, CultureInfo.InvariantCulture, out hostPort)) {
					throw new MudException(null, $"The value {hostPortString} is not a valid port.");
				}
				this.ClientManager.ConnectionClient.Connect(hostAddress, hostPort);
			}

		}

		/// <summary>
		/// Writes to output.
		/// </summary>
		/// <param name="message">The message.</param>
		private void WriteToOutput(string message, bool isUserText, bool clearInput = false) {
			//Try splitting on new lines without removing empty entries.  For each empty entry, write a new line.
			#region AppendText
			Action<string> AppendText = (messageToWrite) => {
				this.richTextBox.SuspendLayout();
				try {
					if (clearInput) {
						this.textBox.Clear();
					}

					if (isUserText) {
						var userColor = this.ClientManager.OptionManager.CommandColor;
						this.richTextBox.AppendFormattedText(message, userColor, false);
						this.richTextBox.AppendFormattedText(string.Empty, userColor, true);
					}
					else {

						var linesToWrite = messageToWrite.Split(new[] { "\r\n", "\n\r", "\n" }, StringSplitOptions.None);
						foreach (var lineToWrite in linesToWrite) {
							var clientForeColor = this.ClientManager.OptionManager.ForegroundColor;

							if (string.IsNullOrWhiteSpace(lineToWrite)) {
								this.richTextBox.AppendFormattedText(string.Empty, clientForeColor, true);
								continue;
							}

							var lineSplitColors = lineToWrite.Split(new[] { MudClientManager.ANSI_COLOR_ESCAPE_CHARACTER }, StringSplitOptions.RemoveEmptyEntries);
							foreach (var lineSplit in lineSplitColors) {
								var textToWrite = lineSplit;
								if (!string.IsNullOrWhiteSpace(lineSplit)) {
									var writeLine = true;
									foreach (var item in this.ClientManager.ColorDictionary) {
										if (lineSplit.StartsWith(item.Key)) {
											var itemLength = item.Key.Length;
											textToWrite = lineSplit.Substring(itemLength, lineSplit.Length - itemLength);
											if (string.IsNullOrWhiteSpace(textToWrite)) {
												writeLine = false;
												break;
											}
											clientForeColor = item.Value;
											break;
										}

									}
									if (writeLine) {
										this.richTextBox.AppendFormattedText(textToWrite, clientForeColor, false);
									}
								}
							}
							this.richTextBox.AppendFormattedText(string.Empty, clientForeColor, true);
						}
					}

				}
				finally {
					this.richTextBox.ScrollToCaret();
					this.richTextBox.ResumeLayout();
				}
			};
			#endregion

			if (this.richTextBox.InvokeRequired) {
				this.richTextBox.Invoke(AppendText, message);
			}
			else {
				AppendText(message);
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Handles the FormClosing event of the MudClientForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
		private void MudClientForm_FormClosing(object sender, FormClosingEventArgs e) {
			try {
				this.SaveConfiguration();
			}
			catch { }
		}

		/// <summary>
		/// Handles the <see cref="E:ConnectionEstablished" /> event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void connectionClient_Connected(object sender) {
			this.toolStripStatusLabel.Text = @"Connected.";
		}

		/// <summary>
		/// Connections the client disconnected.
		/// </summary>
		/// <param name="sender">The sender.</param>
		private void connectionClient_Disconnected(object sender) {
			this.toolStripStatusLabel.Text = @"Disconnected.";
		}

		/// <summary>
		/// Handles the <see cref="E:MessageReceived" /> event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="MessageEventArgs"/> instance containing the event data.</param>
		private void connectionClient_MessageReceived(object sender, MessageEventArgs e) {
			this.WriteToOutput(e.Message, false, false);
		}

		/// <summary>
		/// Handles the MessageSent event of the connectionClient control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="MessageEventArgs"/> instance containing the event data.</param>
		private void connectionClient_MessageSent(object sender, MessageEventArgs e) {
			this.WriteToOutput(e.Message, true, true);
		}

		/// <summary>
		/// Handles the Click event of the closeToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// Handles the Click event of the hotKeysToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void hotKeysToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				using (var form = new HotKeysForm(this.ClientManager.ProfileCollection.SelectedProfile.HotKeys)) {
					form.ShowDialog(this);
				}
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure displaying hotkeys: {caught.Message}", @"Failure Displaying HotKeys...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Handles the Click event of the optionsToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				OptionsForm.ShowDialog(this, this.ClientManager.OptionManager);
				this.BindUIFormatting();
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure displaying options: {caught.Message}", @"Failure Displaying Options...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

	}
}
