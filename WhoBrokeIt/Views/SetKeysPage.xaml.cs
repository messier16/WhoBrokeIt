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
		public SetKeysPage(string instance = null, string token = null)
		{
			InitializeComponent();
			InstanceEntry.Text = instance ?? "";
			TokentEntry.Text = token ?? "";
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
