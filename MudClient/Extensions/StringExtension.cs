namespace MudClient.Extensions {

	#region Directives
	using System;
	using System.Windows.Forms;
	#endregion

	public static class StringExtension {

		public static Keys ResolveKeys(this string value) {
			var keyCombination = Keys.None;
			foreach (var keyText in value.Split(new[] { ',', '+', ';' }, StringSplitOptions.RemoveEmptyEntries)) {
				Keys currentKey;
				if (Enum.TryParse(keyText, out currentKey)) {
					keyCombination = keyCombination | currentKey;
				}				
			}
			return keyCombination;
		}

	}
}
