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
			MainPage = new NavigationPage(new SetKeysPage(instance, token));
		}

		#region Resources
		public Color VisualStudioColor => (Color)Resources["VisualStudioColor"];
		#endregion

		public static WhoBrokeItApp RealCurrent
		{
			get { return Application.Current as WhoBrokeItApp; }
		}
	}
}
