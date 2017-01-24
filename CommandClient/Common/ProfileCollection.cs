namespace CommandClient.Common {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Xml.Linq;
	using MudClient.Common.Extensions;
	#endregion

	public sealed class ProfileCollection
		: Collection<Profile> {

		#region Properties

		#region ProfileCollectionXml

		/// <summary>
		/// Gets or sets the profile collection XML.
		/// </summary>
		/// <value>The profile collection XML.</value>
		public XElement ProfileCollectionXml {
			get {
				return new XElement(
					@"Profiles",
						new XAttribute(@"DefaultProfile", this.SelectedProfile.ProfileName),
						this.Select(profile =>
							new XElement(@"Profile",
								new XAttribute(@"ProfileName", profile.ProfileName),
								profile.HotKeys.HotKeysXml
								)
							)
						);
			}
			set {
				if (value == null) return;				
				foreach (var profileElement in value.Elements(@"Profile")) {
					var profile = this.Add(profileElement.SafeAttributeValue<string>(@"ProfileName"));
					profile.HotKeys.HotKeysXml = profileElement.Element(@"HotKeys");
				}
				this.SelectedProfile = this[value.SafeAttributeValue<string>(@"DefaultProfile")];
			}
		}

		#endregion

		#region SelectedProfile

		private Profile _selectedProfile;

		/// <summary>
		/// Gets the selected profile.
		/// </summary>
		/// <value>The selected profile.</value>
		public Profile SelectedProfile {
			get { return _selectedProfile ?? (_selectedProfile = this.FirstOrDefault() ?? this.Add(@"Default")); }
			set { _selectedProfile = value; }
		}

		#endregion

		#endregion

		#region CollectionManagement

		/// <summary>
		/// Adds the specified profile name.
		/// </summary>
		/// <param name="profileName">Name of the profile.</param>
		/// <returns>Profile.</returns>
		public Profile Add(string profileName) {
			var profile = new Profile(this, profileName);
			this.Add(profile);
			return profile;
		}

		#endregion

		#region Indexers

		/// <summary>
		/// Gets the <see cref="Profile" /> with the specified key combination.
		/// </summary>
		/// <param name="profileName">Name of the profile.</param>
		/// <returns>HotKey.</returns>
		public Profile this[string profileName] {
			get { return this.FirstOrDefault(profile => profile.ProfileName.Equals(profileName, StringComparison.OrdinalIgnoreCase)); }
		}

		#endregion

	}

}