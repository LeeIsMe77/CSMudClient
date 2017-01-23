namespace CommandClient.Common {

	#region Directives
	using System.Windows.Forms;
	using System.Xml.Linq;
	#endregion

	public class HotKey {

		#region Properties

		#region CommandText

		/// <summary>
		/// Gets or sets the command text.
		/// </summary>
		/// <value>The command text.</value>
		public string CommandText { get; set; }

		#endregion

		#region ConcatenatedText

		/// <summary>
		/// Gets the name of the concatenated.
		/// </summary>
		/// <value>The name of the concatenated.</value>
		public string ConcatenatedName => $"[{this.KeyCombination.ToString()}] [{this.CommandText}]";

		#endregion

		#region KeyCombination

		/// <summary>
		/// Gets or sets the key combination.
		/// </summary>
		/// <value>The key combination.</value>
		public Keys KeyCombination { get; set; }

		#endregion
		
		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="HotKey"/> class.
		/// </summary>
		public HotKey() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="HotKey"/> class.
		/// </summary>
		/// <param name="keyCombination">The key combination.</param>
		/// <param name="commandText">The command text.</param>
		public HotKey(Keys keyCombination, string commandText) {
			this.KeyCombination = keyCombination;
			this.CommandText = commandText;
		}

		#endregion

	}

}