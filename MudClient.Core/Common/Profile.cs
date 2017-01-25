namespace MudClient.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml.Linq;
	using MudClient.Common.Extensions;
	#endregion

	public sealed class Profile {

		#region Properties

		#region HotKeys

		private HotKeyCollection _hotKeys;

		/// <summary>
		/// Gets the hot keys.
		/// </summary>
		/// <value>The hot keys.</value>
		public HotKeyCollection HotKeys {
			get { return _hotKeys ?? (_hotKeys = new HotKeyCollection(this)); }
		}

		#endregion

		#region ParentProfile

		/// <summary>
		/// Gets the parent profile.
		/// </summary>
		/// <value>The parent profile.</value>
		private ProfileCollection ParentProfile { get; }

		#endregion

		#region ProfileName

		/// <summary>
		/// Gets or sets the name of the profile.
		/// </summary>
		/// <value>The name of the profile.</value>
		public string ProfileName { get; set; }

		#endregion

		//#region ProfileXml

		///// <summary>
		///// Gets or sets the profile XML.
		///// </summary>
		///// <value>The profile XML.</value>
		//public XElement ProfileXml {
		//	get {
		//		return new XElement(
		//			@"Profile",
		//				new XAttribute(@"ProfileName", this.ProfileName),
		//				this.HotKeys.HotKeysXml
		//				);
		//	}
		//	set {
		//		if (value == null) return;
		//		this.ProfileName = value.SafeAttributeValue(@"ProfileName");
		//		this.HotKeys.HotKeysXml = value;
				
		//	}
		//}

		//#endregion

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Profile"/> class.
		/// </summary>
		/// <param name="parentCollection">The parent collection.</param>
		public Profile(ProfileCollection parentCollection) {
			this.ParentProfile = parentCollection;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Profile"/> class.
		/// </summary>
		/// <param name="parentCollection">The parent collection.</param>
		/// <param name="profileName">Name of the profile.</param>
		public Profile(ProfileCollection parentCollection, string profileName) 
			: this(parentCollection) {
			this.ProfileName = profileName;
		}

		#endregion

	}

}
