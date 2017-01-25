namespace MudClient.Core.Common {

	#region Directives
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Xml.Linq;
	using MudClient.Core.Client;
	#endregion

	public sealed class ClientManager {

		#region Contants
		public const string ANSI_COLOR_ESCAPE_CHARACTER = "\u001b";
		public const string ANSI_RESET = "[0m";
		public const string ANSI_UNKNOWN = "[01m";
		public const string ANSI_BLACK = "[30m";
		public const string ANSI_RED = "[31m";
		public const string ANSI_GREEN = "[32m";
		public const string ANSI_YELLOW = "[33m";
		public const string ANSI_BLUE = "[34m";
		public const string ANSI_PURPLE = "[35m";
		public const string ANSI_CYAN = "[36m";
		public const string ANSI_WHITE = "[37m";
		#endregion

		#region Properties

		#region ColorDictionary

		/// <summary>
		/// Gets or sets the color dictionary.
		/// </summary>
		/// <value>The color dictionary.</value>
		public Dictionary<string, Color> ColorDictionary { get; set; } = new Dictionary<string, Color> {
			{ ANSI_RESET, Color.Black   },
			{ ANSI_UNKNOWN, Color.Black },
			{ ANSI_BLACK, Color.Black},
			{ ANSI_RED, Color.Red },
			{ ANSI_GREEN, Color.Green },
			{ ANSI_YELLOW, Color.Yellow },
			{ ANSI_BLUE, Color.Blue },
			{ ANSI_PURPLE, Color.Purple },
			{ ANSI_CYAN, Color.Teal },
			{ ANSI_WHITE, Color.White }
		};

		#endregion

		#region ConnectionClient

		private ConnectionClient _connectionClient;

		/// <summary>
		/// Gets the command client.
		/// </summary>
		/// <value>The command client.</value>
		public ConnectionClient ConnectionClient {
			get { return _connectionClient ?? (_connectionClient = new ConnectionClient()); }
		}

		#endregion
		
		#region ManagerXml

		/// <summary>
		/// Gets or sets the manager XML.
		/// </summary>
		/// <value>The manager XML.</value>
		public XElement ManagerXml {
			get {
				var returnElement = new XElement(
					@"SimpleMudClient",
						this.OptionManager.OptionsXml,
						this.ProfileCollection.ProfileCollectionXml
						);
				return returnElement;
			}
			set {
				if (value == null) return;
				this.OptionManager.OptionsXml = value.Element(@"Options");
				this.ProfileCollection.ProfileCollectionXml = value.Element(@"Profiles");
			}
		}

		#endregion

		#region OptionsManager

		private OptionsManager _optionManager;

		/// <summary>
		/// Gets the option manager.
		/// </summary>
		/// <value>The option manager.</value>
		public OptionsManager OptionManager {
			get { return _optionManager ?? (_optionManager = new OptionsManager()); }
		}

		#endregion

		#region ProfileCollection

		private ProfileCollection _profileCollection;

		/// <summary>
		/// Gets the profile collection.
		/// </summary>
		/// <value>The profile collection.</value>
		public ProfileCollection ProfileCollection {
			get { return _profileCollection ?? (_profileCollection = new ProfileCollection()); }
		}

		#endregion

		#endregion

	}

}
