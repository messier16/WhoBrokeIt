using Messier16.VstsClient;
using System;
using System.Collections.Generic;
using WhoBrokeIt.UI.Resources;
using WhoBrokeIt.UI.Services;
using WhoBrokeIt.UI.Views;
using Xamarin.Forms;

namespace WhoBrokeIt.UI
{
	public partial class WhoBrokeItApp : Application
	{
		public WhoBrokeItApp(string instance, string token)
		{
			InitializeComponent();


            Page startingPage;

			//startingPage = new SetKeysPage();
            if(String.IsNullOrEmpty(instance) || String.IsNullOrEmpty(token))
            {
                startingPage = new SetKeysPage();
            }
            else
            {
                Client = new TeamServicesClient(instance, token);
                startingPage = new ProjectListPage();
            }
			ChangeMainPage(startingPage);

		}

        void SetLanguage()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var localService = DependencyService.Get<ILocalize>();
                var ci = localService.GetCurrentCultureInfo();
                AppStrings.Culture = ci; // set the RESX for resource localization
                localService.SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        public TeamServicesClient Client { get; set; }

        #region Resources
        public Color VisualStudioColor => (Color)Resources["VisualStudioColor"];
		public Color VisualStudioBackgroundColor => (Color)Resources["VisualStudioBackgroundColor"];
		#endregion

		public void ChangeMainPage(Page p)
		{

			var navMainPage = new NavigationPage(p);

			navMainPage.BarBackgroundColor = VisualStudioColor;
			navMainPage.BarTextColor = Color.White;
			MainPage = navMainPage;
		}

		public static WhoBrokeItApp RealCurrent
		{
			get { return Application.Current as WhoBrokeItApp; }
		}

		internal void ReturnToKeyPage()
		{
			ChangeMainPage(new SetKeysPage());
		}
	}
}
