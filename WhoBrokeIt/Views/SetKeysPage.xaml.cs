using System;
using System.Collections.Generic;
using Messier16.VstsClient;
using WhoBrokeIt.UI.Helpers;
using WhoBrokeIt.UI.Services;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace WhoBrokeIt.UI.Views
{
	public partial class SetKeysPage : ContentPage
	{
		const string Guide = "https://www.visualstudio.com/en-us/docs/integrate/get-started/auth/overview#create-personal-access-tokens-to-authenticate-access";
        bool _resetToken;
		public SetKeysPage(bool resetToken = false)
		{
			InitializeComponent();

            InstanceEntry.AutomationId = "InstanceEntry";
            TokentEntry.AutomationId = "TokenEntry";
            ContinueButton.AutomationId = "ContinueButton";

            _resetToken = resetToken;
            if(resetToken)
            {
                InstanceEntry.IsEnabled = false;
                CancelButton.IsVisible = true;
            }

			var tap = new TapGestureRecognizer((v) => 
			{
				Device.OpenUri(new Uri(Guide));
			});
			InfoButton.GestureRecognizers.Add(tap);
        }

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			if (String.IsNullOrEmpty(InstanceEntry.Text) ||
			   String.IsNullOrEmpty(TokentEntry.Text))
			{
				UserDialogs.Instance.Toast("Error");
				return;
			}

			UserDialogs.Instance.ShowLoading();
            // Replace client
			var client = new TeamServicesClient(InstanceEntry.Text,
												TokentEntry.Text);
            var connectionStatus = await client.Probe();
            if(connectionStatus == 200)
            {
                WhoBrokeItApp.RealCurrent.Client = client;

				Settings.VisualStudioInstance = InstanceEntry.Text;

                var accMgr = DependencyService.Get<IAccountManager>();
                accMgr.SaveTokenForInstance(InstanceEntry.Text, TokentEntry.Text);
				UserDialogs.Instance.HideLoading();
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
				UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowError("Error de conexión");
            }
		}


        async void HandleCancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
