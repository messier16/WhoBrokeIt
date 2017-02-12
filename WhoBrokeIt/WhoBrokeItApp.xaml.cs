using Messier16.VstsClient;
using System;
using System.Collections.Generic;
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

			startingPage = new SetKeysPage();
            //if(String.IsNullOrEmpty(instance) || String.IsNullOrEmpty(token))
            //{
            //    startingPage = new SetKeysPage();
            //}
            //else
            //{
            //    Client = new TeamServicesClient(instance, token);
            //    startingPage = new ProjectListPage();
            //}

			var navMainPage = new NavigationPage(startingPage);

			navMainPage.BarBackgroundColor = VisualStudioColor;
			navMainPage.BarTextColor = Color.White;

			MainPage = navMainPage;
		}

        public TeamServicesClient Client { get; set; }

        #region Resources
        public Color VisualStudioColor => (Color)Resources["VisualStudioColor"];
		public Color VisualStudioBackgroundColor => (Color)Resources["VisualStudioBackgroundColor"];
		#endregion

		public static WhoBrokeItApp RealCurrent
		{
			get { return Application.Current as WhoBrokeItApp; }
		}
	}
}
