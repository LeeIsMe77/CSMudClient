namespace MudClient.Management {
	partial class OptionsForm {
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
			this.backgroundColorLabel = new System.Windows.Forms.Label();
			this.foregroundColorLabel = new System.Windows.Forms.Label();
			this.fontLabel = new System.Windows.Forms.Label();
			this.backgroundColor = new System.Windows.Forms.Button();
			this.foregroundColor = new System.Windows.Forms.Button();
			this.commandColor = new System.Windows.Forms.Button();
			this.commandColorLabel = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.colorsTabPage = new System.Windows.Forms.TabPage();
			this.generalTabPage = new System.Windows.Forms.TabPage();
			this.commandDelimiterLabel = new System.Windows.Forms.Label();
			this.commandDelimiter = new System.Windows.Forms.TextBox();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.save = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.fontText = new System.Windows.Forms.TextBox();
			this.selectFont = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.colorsTabPage.SuspendLayout();
			this.generalTabPage.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// backgroundColorLabel
			// 
			this.backgroundColorLabel.Location = new System.Drawing.Point(50, 112);
			this.backgroundColorLabel.Name = "backgroundColorLabel";
			this.backgroundColorLabel.Size = new System.Drawing.Size(180, 23);
			this.backgroundColorLabel.TabIndex = 0;
			this.backgroundColorLabel.Text = "Background Color:";
			this.backgroundColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// foregroundColorLabel
			// 
			this.foregroundColorLabel.Location = new System.Drawing.Point(50, 137);
			this.foregroundColorLabel.Name = "foregroundColorLabel";
			this.foregroundColorLabel.Size = new System.Drawing.Size(180, 23);
			this.foregroundColorLabel.TabIndex = 1;
			this.foregroundColorLabel.Text = "Foreground Color:";
			this.foregroundColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// fontLabel
			// 
			this.fontLabel.Location = new System.Drawing.Point(50, 87);
			this.fontLabel.Name = "fontLabel";
			this.fontLabel.Size = new System.Drawing.Size(180, 23);
			this.fontLabel.TabIndex = 2;
			this.fontLabel.Text = "Font:";
			this.fontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// backgroundColor
			// 
			this.backgroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.backgroundColor.Location = new System.Drawing.Point(237, 112);
			this.backgroundColor.Name = "backgroundColor";
			this.backgroundColor.Size = new System.Drawing.Size(34, 23);
			this.backgroundColor.TabIndex = 3;
			this.backgroundColor.UseVisualStyleBackColor = true;
			this.backgroundColor.Click += new System.EventHandler(this.colorButtonClick);
			// 
			// foregroundColor
			// 
			this.foregroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.foregroundColor.Location = new System.Drawing.Point(237, 137);
			this.foregroundColor.Name = "foregroundColor";
			this.foregroundColor.Size = new System.Drawing.Size(34, 23);
			this.foregroundColor.TabIndex = 4;
			this.foregroundColor.UseVisualStyleBackColor = true;
			this.foregroundColor.Click += new System.EventHandler(this.colorButtonClick);
			// 
			// commandColor
			// 
			this.commandColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.commandColor.Location = new System.Drawing.Point(237, 162);
			this.commandColor.Name = "commandColor";
			this.commandColor.Size = new System.Drawing.Size(34, 23);
			this.commandColor.TabIndex = 7;
			this.commandColor.UseVisualStyleBackColor = true;
			this.commandColor.Click += new System.EventHandler(this.colorButtonClick);
			// 
			// commandColorLabel
			// 
			this.commandColorLabel.Location = new System.Drawing.Point(50, 162);
			this.commandColorLabel.Name = "commandColorLabel";
			this.commandColorLabel.Size = new System.Drawing.Size(180, 23);
			this.commandColorLabel.TabIndex = 6;
			this.commandColorLabel.Text = "Command Color:";
			this.commandColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.colorsTabPage);
			this.tabControl.Controls.Add(this.generalTabPage);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(584, 331);
			this.tabControl.TabIndex = 8;
			// 
			// colorsTabPage
			// 
			this.colorsTabPage.Controls.Add(this.selectFont);
			this.colorsTabPage.Controls.Add(this.fontText);
			this.colorsTabPage.Controls.Add(this.backgroundColorLabel);
			this.colorsTabPage.Controls.Add(this.commandColor);
			this.colorsTabPage.Controls.Add(this.foregroundColorLabel);
			this.colorsTabPage.Controls.Add(this.commandColorLabel);
			this.colorsTabPage.Controls.Add(this.fontLabel);
			this.colorsTabPage.Controls.Add(this.backgroundColor);
			this.colorsTabPage.Controls.Add(this.foregroundColor);
			this.colorsTabPage.Location = new System.Drawing.Point(4, 22);
			this.colorsTabPage.Name = "colorsTabPage";
			this.colorsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.colorsTabPage.Size = new System.Drawing.Size(576, 305);
			this.colorsTabPage.TabIndex = 0;
			this.colorsTabPage.Text = "Colors";
			this.colorsTabPage.UseVisualStyleBackColor = true;
			// 
			// generalTabPage
			// 
			this.generalTabPage.Controls.Add(this.commandDelimiter);
			this.generalTabPage.Controls.Add(this.commandDelimiterLabel);
			this.generalTabPage.Location = new System.Drawing.Point(4, 22);
			this.generalTabPage.Name = "generalTabPage";
			this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.generalTabPage.Size = new System.Drawing.Size(576, 305);
			this.generalTabPage.TabIndex = 1;
			this.generalTabPage.Text = "General";
			this.generalTabPage.UseVisualStyleBackColor = true;
			// 
			// commandDelimiterLabel
			// 
			this.commandDelimiterLabel.Location = new System.Drawing.Point(26, 59);
			this.commandDelimiterLabel.Name = "commandDelimiterLabel";
			this.commandDelimiterLabel.Size = new System.Drawing.Size(180, 23);
			this.commandDelimiterLabel.TabIndex = 4;
			this.commandDelimiterLabel.Text = "Command Delimiter:";
			this.commandDelimiterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// commandDelimiter
			// 
			this.commandDelimiter.Location = new System.Drawing.Point(212, 61);
			this.commandDelimiter.Name = "commandDelimiter";
			this.commandDelimiter.Size = new System.Drawing.Size(112, 20);
			this.commandDelimiter.TabIndex = 5;
			this.commandDelimiter.Validating += new System.ComponentModel.CancelEventHandler(this.commandDelimiter_Validating);
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.cancel);
			this.buttonPanel.Controls.Add(this.save);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 331);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(584, 30);
			this.buttonPanel.TabIndex = 9;
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
			// fontText
			// 
			this.fontText.Location = new System.Drawing.Point(237, 89);
			this.fontText.Name = "fontText";
			this.fontText.ReadOnly = true;
			this.fontText.Size = new System.Drawing.Size(210, 20);
			this.fontText.TabIndex = 8;
			// 
			// selectFont
			// 
			this.selectFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.selectFont.Location = new System.Drawing.Point(454, 89);
			this.selectFont.Name = "selectFont";
			this.selectFont.Size = new System.Drawing.Size(37, 20);
			this.selectFont.TabIndex = 9;
			this.selectFont.Text = "...";
			this.selectFont.UseVisualStyleBackColor = true;
			this.selectFont.Click += new System.EventHandler(this.selectFont_Click);
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.buttonPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.tabControl.ResumeLayout(false);
			this.colorsTabPage.ResumeLayout(false);
			this.colorsTabPage.PerformLayout();
			this.generalTabPage.ResumeLayout(false);
			this.generalTabPage.PerformLayout();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label backgroundColorLabel;
		private System.Windows.Forms.Label foregroundColorLabel;
		private System.Windows.Forms.Label fontLabel;
		private System.Windows.Forms.Button backgroundColor;
		private System.Windows.Forms.Button foregroundColor;
		private System.Windows.Forms.Button commandColor;
		private System.Windows.Forms.Label commandColorLabel;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage colorsTabPage;
		private System.Windows.Forms.TabPage generalTabPage;
		private System.Windows.Forms.TextBox commandDelimiter;
		private System.Windows.Forms.Label commandDelimiterLabel;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button selectFont;
		private System.Windows.Forms.TextBox fontText;
	}
}