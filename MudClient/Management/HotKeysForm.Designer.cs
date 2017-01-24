namespace MudClient.Management {
	partial class HotKeysForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.hotKeys = new System.Windows.Forms.ListBox();
			this.keysCombinationLabel = new System.Windows.Forms.Label();
			this.commandTextLabel = new System.Windows.Forms.Label();
			this.keyCombination = new System.Windows.Forms.TextBox();
			this.commandText = new System.Windows.Forms.TextBox();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.cancel = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.addHotkey = new System.Windows.Forms.Button();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// hotKeys
			// 
			this.hotKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hotKeys.FormattingEnabled = true;
			this.hotKeys.Location = new System.Drawing.Point(116, 95);
			this.hotKeys.Name = "hotKeys";
			this.hotKeys.Size = new System.Drawing.Size(359, 186);
			this.hotKeys.TabIndex = 0;
			// 
			// keysCombinationLabel
			// 
			this.keysCombinationLabel.Location = new System.Drawing.Point(12, 18);
			this.keysCombinationLabel.Name = "keysCombinationLabel";
			this.keysCombinationLabel.Size = new System.Drawing.Size(180, 23);
			this.keysCombinationLabel.TabIndex = 3;
			this.keysCombinationLabel.Text = "Key Combination:";
			this.keysCombinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// commandTextLabel
			// 
			this.commandTextLabel.Location = new System.Drawing.Point(12, 41);
			this.commandTextLabel.Name = "commandTextLabel";
			this.commandTextLabel.Size = new System.Drawing.Size(180, 23);
			this.commandTextLabel.TabIndex = 4;
			this.commandTextLabel.Text = "Command Text:";
			this.commandTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// keyCombination
			// 
			this.keyCombination.Location = new System.Drawing.Point(198, 20);
			this.keyCombination.Name = "keyCombination";
			this.keyCombination.Size = new System.Drawing.Size(277, 20);
			this.keyCombination.TabIndex = 5;
			// 
			// commandText
			// 
			this.commandText.Location = new System.Drawing.Point(198, 43);
			this.commandText.Name = "commandText";
			this.commandText.Size = new System.Drawing.Size(277, 20);
			this.commandText.TabIndex = 6;
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.cancel);
			this.buttonPanel.Controls.Add(this.save);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 331);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(584, 30);
			this.buttonPanel.TabIndex = 10;
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.Location = new System.Drawing.Point(424, 4);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "&Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// save
			// 
			this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.save.Location = new System.Drawing.Point(505, 4);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(75, 23);
			this.save.TabIndex = 0;
			this.save.Text = "&Okay";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// addHotkey
			// 
			this.addHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addHotkey.Location = new System.Drawing.Point(481, 43);
			this.addHotkey.Name = "addHotkey";
			this.addHotkey.Size = new System.Drawing.Size(75, 23);
			this.addHotkey.TabIndex = 11;
			this.addHotkey.Text = "&Add";
			this.addHotkey.UseVisualStyleBackColor = true;
			this.addHotkey.Click += new System.EventHandler(this.addHotkey_Click);
			// 
			// HotKeysForm
			// 
			this.AcceptButton = this.save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.addHotkey);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.commandText);
			this.Controls.Add(this.keyCombination);
			this.Controls.Add(this.commandTextLabel);
			this.Controls.Add(this.keysCombinationLabel);
			this.Controls.Add(this.hotKeys);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "HotKeysForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hot Keys";
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox hotKeys;
		private System.Windows.Forms.Label keysCombinationLabel;
		private System.Windows.Forms.Label commandTextLabel;
		private System.Windows.Forms.TextBox keyCombination;
		private System.Windows.Forms.TextBox commandText;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button addHotkey;
	}
}