namespace MudClient.Common.Extensions {

	#region Directives
	using System;
	using System.Drawing;
	using System.Windows.Forms;
	#endregion

	public static class RichTextBoxExtension {


		/// <summary>
		/// Appends the formatted text.
		/// </summary>
		/// <param name="richTextBox">The rich text box.</param>
		/// <param name="message">The text.</param>
		/// <param name="defaultColor">The color.</param>
		/// <param name="appendNewLine">if set to <c>true</c> [append new line].</param>
		public static void AppendFormattedText(this RichTextBox richTextBox, string message, Color defaultColor, bool appendNewLine) {

			if (appendNewLine) {
				richTextBox.AppendText(Environment.NewLine);
			}
			
			if (!string.IsNullOrWhiteSpace(message)) {
				richTextBox.SelectionStart = richTextBox.TextLength;
				richTextBox.SelectionLength = 0;

				richTextBox.SelectionColor = defaultColor;
				richTextBox.AppendText(message);
				richTextBox.SelectionColor = richTextBox.ForeColor;
			}			

		}

	}

}
