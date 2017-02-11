using System;
using System.Collections.Generic;
using Messier16.VstsClient;
using WhoBrokeIt.UI.Helpers;
using WhoBrokeIt.UI.Services;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
	public partial class SetKeysPage : ContentPage
	{
		public SetKeysPage()
		{
			InitializeComponent();
            InstanceEntry.Text = Settings.VisualStudioInstance;
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			Settings.VisualStudioInstance = InstanceEntry.Text;

            // Replace client
			WhoBrokeItApp.RealCurrent.Client = new TeamServicesClient(InstanceEntry.Text,
												TokentEntry.Text);
            // TODO: check credentials
			var accMgr = DependencyService.Get<IAccountManager>();
			accMgr.SaveTokenForInstance(InstanceEntry.Text, TokentEntry.Text);

			await Navigation.PushAsync(new ProjectListPage());
		}
	}
}
