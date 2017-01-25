namespace MudClient.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	#endregion

	public sealed class ProfileManager {

		#region Properties

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
