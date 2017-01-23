namespace MudClient {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Management;
	#endregion

	public class Program {

		[STAThread]
		static void Main(string[] args) {
			using (var form = new MudClientForm()) {
				form.ShowDialog();
			}
		}

	}

}
