namespace MudClient.Management {

	#region Directives
	using System;
	using System.Drawing;
	using System.Windows.Forms;
	using CommandClient.Common;
	using Core;
	#endregion

	public partial class OptionsForm
		: Form {

		#region Statics

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="optionsManager">The options manager.</param>
		public static void ShowDialog(Form owner, OptionsManager optionsManager) {
			using (var form = new OptionsForm(optionsManager)) {
				form.ShowDialog(owner);
			}
		}

		#endregion

		#region Properties

		private readonly OptionsManager _optionsManager;
		
		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionsForm"/> class.
		/// </summary>
		/// <param name="optionsManager">The option manager.</param>
		private OptionsForm(OptionsManager optionsManager) {
			InitializeComponent();
			_optionsManager = optionsManager;
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			this.backgroundColor.BackColor = _optionsManager.BackgroundColor;
			this.foregroundColor.BackColor = _optionsManager.ForegroundColor;
			this.commandColor.BackColor = _optionsManager.CommandColor;
			this.commandDelimiter.Text = _optionsManager.CommandDelimiter.ToString();
			this.fontText.Text = _optionsManager.FontConverter.ConvertToString(_optionsManager.Font);
		}

		#endregion

		#region Control Events

		/// <summary>
		/// Handles the Click event of the cancel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void cancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Colors the button click.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void colorButtonClick(object sender, EventArgs e) {
			var senderAsButton = sender as Button;
			if (senderAsButton == null) return;

			using (var colorPicker = new ColorDialog()) {
				colorPicker.Color = senderAsButton.BackColor;
				colorPicker.SolidColorOnly = false;
				colorPicker.FullOpen = true;

				if (colorPicker.ShowDialog(this) != DialogResult.OK) return;
				//Set the chosen color
				senderAsButton.BackColor = colorPicker.Color;

				if (sender == backgroundColor) {
					_optionsManager.BackgroundColor = backgroundColor.BackColor;
				}
				else if (sender == foregroundColor) {
					_optionsManager.ForegroundColor = foregroundColor.BackColor;
				}
				else if (sender == commandColor) {
					_optionsManager.CommandColor = commandColor.BackColor;
				}

			}
		}

		/// <summary>
		/// Handles the Click event of the save control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void save_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Handles the Validating event of the commandDelimiter control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		/// <exception cref="MudException">
		/// null;You must choose a command delimiter.
		/// or
		/// null;The value {this.commandDelimiter.Text}
		/// </exception>
		private void commandDelimiter_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			try {
				if (string.IsNullOrWhiteSpace(this.commandDelimiter.Text)) {
					throw new MudException(null, @"You must choose a command delimiter.");
				}

				char tempCharacter;
				if (!char.TryParse(this.commandDelimiter.Text, out tempCharacter)) {
					throw new MudException(null, $"The value {this.commandDelimiter.Text} is not a valid command delimiter.");
				}
				_optionsManager.CommandDelimiter = tempCharacter;
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure validating command delimiter: {caught.Message}", @"Failure Validating Command Delimiter...", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
			}
		}

		/// <summary>
		/// Handles the Click event of the selectFont control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void selectFont_Click(object sender, EventArgs e) {
			try {
				using (var form = new FontDialog()) {					
					form.Font = _optionsManager.Font;
					if (form.ShowDialog(this) != DialogResult.OK) return;
					this.fontText.Text = _optionsManager.FontConverter.ConvertToString(form.Font);
					_optionsManager.Font = form.Font;
				}
			}
			catch (Exception caught) {
				MessageBox.Show(this, $"Failure selecting font: {caught.Message}", @"Failure Selecting Font...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

	}

}
