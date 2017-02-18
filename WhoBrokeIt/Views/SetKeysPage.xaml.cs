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
        bool _resetToken;
		public SetKeysPage(bool resetToken = false)
		{
			InitializeComponent();
            _resetToken = resetToken;
            if(resetToken)
            {
                InstanceEntry.IsEnabled = false;
                CancelButton.IsVisible = true;
            }
            InstanceEntry.Text = "--";// Settings.VisualStudioInstance;
            TokentEntry.Text = "--";

        }

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			Settings.VisualStudioInstance = InstanceEntry.Text;

            // Replace client
			var client = new TeamServicesClient(InstanceEntry.Text,
												TokentEntry.Text);
            var connectionStatus = await client.Probe();
            if(connectionStatus == 200)
            {
                WhoBrokeItApp.RealCurrent.Client = client;

                var accMgr = DependencyService.Get<IAccountManager>();
                accMgr.SaveTokenForInstance(InstanceEntry.Text, TokentEntry.Text);
                if (!_resetToken)
                {
                    WhoBrokeItApp.RealCurrent.ChangeMainPage(new ProjectListPage());
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
            else
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError("Error de conexión");
            }
		}


        async void HandleCancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
