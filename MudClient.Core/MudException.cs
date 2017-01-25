namespace MudClient.Core {

	#region Directives
	using System;
	#endregion

	public class MudException
		: Exception {

		#region Properties

		/// <summary>
		/// Gets the original exception.
		/// </summary>
		/// <value>The original exception.</value>
		public Exception OriginalException { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MudException" /> class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public MudException(string message) 
			: base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MudException"/> class.
		/// </summary>
		/// <param name="originalException">The original exception.</param>
		/// <param name="message">The message.</param>
		public MudException(Exception originalException, string message)
			: base(message) {
			this.OriginalException = originalException;
		}

		#endregion

	}
}
