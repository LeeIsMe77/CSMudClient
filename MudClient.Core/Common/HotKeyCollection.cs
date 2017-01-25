namespace MudClient.Core.Common {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows.Forms;
	using System.Xml.Linq;
	using MudClient.Common.Extensions;
	using MudClient.Core;
	#endregion

	public sealed class HotKeyCollection 
		: Collection<HotKey> {

		#region Properties

		#region HotKeysXml

		/// <summary>
		/// Gets or sets the hot keys XML.
		/// </summary>
		/// <value>The hot keys XML.</value>
		public XElement HotKeysXml {
			get {
				return new XElement(
					@"HotKeys",
						this.Select(hotkey =>
							new XElement(
								@"HotKey",
								new XAttribute(@"KeyCombination", hotkey.KeyCombination),
								new XAttribute(@"CommandText", hotkey.CommandText)
							)
						)
					);
			}
			set {
				this.Clear();
				if (value == null) return;
				foreach (var hotKeyElement in value.Elements(@"HotKey")) {
					this.Add(
						this.ResolveKeys(hotKeyElement.SafeAttributeValue<string>(@"KeyCombination")),
						hotKeyElement.SafeAttributeValue<string>(@"CommandText")
						);
				}


			}
		}

		#endregion

		#region ParentProfile

		/// <summary>
		/// Gets the parent profile.
		/// </summary>
		/// <value>The parent profile.</value>
		private Profile ParentProfile { get; }

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="HotKeyCollection"/> class.
		/// </summary>
		/// <param name="parentProfile">The parent profile.</param>
		public HotKeyCollection(Profile parentProfile) {
			ParentProfile = parentProfile;
		}

		#endregion

		#region Collection Management

		/// <summary>
		/// Adds the specified key combination.
		/// </summary>
		/// <param name="keyCombination">The key combination.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>HotKey.</returns>
		public HotKey Add(Keys keyCombination, string commandText) {
			var hotKey = new HotKey(keyCombination, commandText);
			this.Add(hotKey);
			return hotKey;
		}

		#endregion

		#region Indexers

		/// <summary>
		/// Gets the <see cref="HotKey"/> with the specified key combination.
		/// </summary>
		/// <param name="keyCombination">The key combination.</param>
		/// <returns>HotKey.</returns>
		public HotKey this[Keys keyCombination] {
			get { return this.FirstOrDefault(hotkey => hotkey.KeyCombination == keyCombination); }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Resolves the keys.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>Keys.</returns>
		public Keys ResolveKeys(string value) {
			if (string.IsNullOrWhiteSpace(value)) return Keys.None;

			var keysToReturn = Keys.None;
			var valuesToConvert = value.ToUpper().Replace("CTRL", "CONTROL").Replace("ESC", "ESCAPE").Split(new[] { ',', '+' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var valueToConvert in valuesToConvert) {
				Keys tempKey;
				if (!Enum.TryParse(valueToConvert, true, out tempKey)) {
					throw new MudException(null, $"The value {valueToConvert} is not a valid key.");
				}
				keysToReturn = keysToReturn | tempKey;
			}
			return keysToReturn;
		}

		#endregion

	}

}