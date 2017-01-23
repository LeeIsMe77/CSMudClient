namespace MudClient.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	#endregion

	public sealed class MessageEventArgs 
		: EventArgs {

		#region Constructors

		public MessageEventArgs()
			: base() { }

		public MessageEventArgs(string message) 
			: this() {
			this.Message = message;
		}

		#endregion

		#region Message

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }

		#endregion

	}

}
