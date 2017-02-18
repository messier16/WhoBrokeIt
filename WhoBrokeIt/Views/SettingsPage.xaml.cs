using System;
using System.Collections.Generic;
using Acr.UserDialogs;

using Xamarin.Forms;
using System.Threading.Tasks;
using WhoBrokeIt.UI.Services;
using WhoBrokeIt.UI.Resources;

namespace WhoBrokeIt.UI.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void SettingCellTapped(object sender, EventArgs e)
        {
            if (sender == DisconnectCell)
            {
                await DisconnectFromInstance();
            }
            else if(sender == EditTokenCell)
            {
                await EditToken();
            }
        }

        async Task DisconnectFromInstance()
        {
            var confirmation = await UserDialogs.Instance.ConfirmAsync(AppStrings.SettingsDisconnectConfirmationMessage,
                AppStrings.SettingsDisconnect, AppStrings.Accept, AppStrings.Cancel);
            if (confirmation)
            {
                var accMgr = DependencyService.Get<IAccountManager>();
                accMgr.EraseAll();
				WhoBrokeItApp.RealCurrent.ChangeMainPage(new Views.SetKeysPage());
            }
        }

        async Task EditToken()
        {
            await Navigation.PushAsync(new SetKeysPage(true));
        }
    }
}
