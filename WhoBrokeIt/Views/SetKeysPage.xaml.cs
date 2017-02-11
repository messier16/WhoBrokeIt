using System;
using System.Collections.Generic;

using static WhoBrokeIt.UI.Helpers.Settings;

using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
	public partial class SetKeysPage : ContentPage
	{
		public SetKeysPage()
		{
			InitializeComponent();
			InstanceEntry.Text = VisualStudioInstance;
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			VisualStudioInstance = InstanceEntry.Text;
		}
	}
}
