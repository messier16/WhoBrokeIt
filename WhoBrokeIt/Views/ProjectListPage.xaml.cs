using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
	public partial class ProjectListPage : ContentPage
	{
        bool _firstLoad;
		public ProjectListPage()
		{
            _firstLoad = true;
			InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!_firstLoad) return;

            var client = WhoBrokeItApp.RealCurrent.Client;
            var projects = await client.GetProjects();
            Projects.ItemsSource = projects.Value;
            _firstLoad = false;
        }
    }
}
