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
            if(String.IsNullOrEmpty(instance) || String.IsNullOrEmpty(token))
            {
                startingPage = new SetKeysPage();
            }
            else
            {
                Client = new TeamServicesClient(instance, token);
                startingPage = new ProjectListPage();
            }

            MainPage = new NavigationPage(startingPage);
		}

        public TeamServicesClient Client { get; set; }

        #region Resources
        public Color VisualStudioColor => (Color)Resources["VisualStudioColor"];
		#endregion

		public static WhoBrokeItApp RealCurrent
		{
			get { return Application.Current as WhoBrokeItApp; }
		}
	}
}
