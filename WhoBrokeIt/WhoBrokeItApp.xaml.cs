using System;
using System.Collections.Generic;
using WhoBrokeIt.UI.Views;
using Xamarin.Forms;

namespace WhoBrokeIt.UI
{
	public partial class WhoBrokeItApp : Application
	{
		public WhoBrokeItApp()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new SetKeysPage());
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
