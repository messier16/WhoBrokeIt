using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
	public partial class ProjectListPage : ContentPage
	{
		public ProjectListPage(ProjectList list)
		{
			InitializeComponent();
			Projects.ItemsSource = list.Value;
		}
	}
}
