using System;

using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

