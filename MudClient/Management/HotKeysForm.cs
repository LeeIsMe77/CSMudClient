namespace MudClient.Management {

	#region Directives
	using System;
	using System.Linq;
	using System.Windows.Forms;
	using CommandClient.Common;
	using Extensions;
	using MudClient.Core;
	#endregion

	public partial class HotKeysForm : Form {

		#region Properties

		private readonly HotKeyCollection _hotKeys;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="HotKeysForm"/> class.
		/// </summary>
		/// <param name="hotKeys">The hot keys.</param>
		public HotKeysForm(HotKeyCollection hotKeys) {
			InitializeComponent();
			_hotKeys = hotKeys;
		}

		#endregion

		#region Base Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			this.BindHotKeys();
		}

		private void BindHotKeys() {
			try {
				this.hotKeys.DataSource = null;
				this.hotKeys.DataSource = _hotKeys.ToList();
				this.hotKeys.DisplayMember = @"ConcatenatedName";
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure binding hotkeys: {caught.Message}", @"Failure Bingind HotKeys...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Control Events

		/// <summary>
		/// Handles the Click event of the addHotkey control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void addHotkey_Click(object sender, EventArgs e) {
			try {
				if (string.IsNullOrWhiteSpace(this.keyCombination.Text)) {
					throw new MudException(null, @"The key combination cannot be blank.");
				}

				if (string.IsNullOrWhiteSpace(this.commandText.Text)) {
					throw new MudException(null, @"The command text cannot be blank.");
				}


				var keys = _hotKeys.ResolveKeys(this.keyCombination.Text);
				if (keys == Keys.Enter) {
					throw new MudException(null, @"Enter cannot be used as a hotkey.");
				}

				if (keys == Keys.None) {
					throw new MudException(null, @"None is not a valid key!");
				}

				if (_hotKeys[keys] != null) {
					throw new MudException(null, $"The hotkey {keys} already exists.");
				}

				_hotKeys.Add(keys, this.commandText.Text);
				this.BindHotKeys();
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure creating hotkey: {caught.Message}", @"Failure Creating HotKey...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Handles the Click event of the cancel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void cancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Handles the Click event of the save control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void save_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		#endregion

	}

}
