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
            else if (sender == ThanksToCell)
            {
                await Navigation.PushAsync(new LicensesPage());
            }
            else if (sender == SourceCell)
            {
                Device.OpenUri(new Uri("https://github.com/messier16/WhoBrokeIt"));
            }
            else if (sender == IdeaCell || sender == ReportBugCell)
            {
                var emailMessenger = Plugin.Messaging.CrossMessaging.Current.EmailMessenger;
                if (emailMessenger.CanSendEmail)
                {
                    emailMessenger.SendEmail("apps@messier16.com", "About Who Broke It");
                }
            }
            else if (sender == EditTokenCell)
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
