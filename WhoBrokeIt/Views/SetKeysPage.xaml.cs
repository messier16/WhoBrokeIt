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
			var accMgr = DependencyService.Get<IAccountManager>();
			InstanceEntry.Text = Settings.VisualStudioInstance;
			TokentEntry.Text = accMgr.GetTokenForInstance(InstanceEntry.Text);
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			Settings.VisualStudioInstance = InstanceEntry.Text;

			var client = new TeamServicesClient(InstanceEntry.Text,
												TokentEntry.Text);
			var projects = await client.GetProjects();

			var accMgr = DependencyService.Get<IAccountManager>();
			accMgr.SaveTokenForInstance(InstanceEntry.Text, TokentEntry.Text);

			await Navigation.PushAsync(new ProjectListPage(projects));
		}
	}
}
