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
			else if (sender == ReportBugCell)
			{
				Device.OpenUri(new Uri("mailto:feregrino@thatcsharpguy.com"));
			}
			else if (sender == SourceCell)
			{
				Device.OpenUri(new Uri("https://github.com/messier16/WhoBrokeIt"));
			}
			else if (sender == IdeaCell)
			{
				string appReviewPage = null;
				if (Device.OS == TargetPlatform.Android)
				{
					appReviewPage = "http://play.google.com/store/apps/details?id=com.facebook.katana";
				}
				else if (Device.OS == TargetPlatform.iOS)
				{
					appReviewPage = "itms-apps://itunes.apple.com/app/id353372460";
				}
				Device.OpenUri(new Uri(appReviewPage));
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
