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

        private async void ProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Projects.SelectedItem == null) return;

            var project = Projects.SelectedItem as BasicProject;
            await Navigation.PushAsync(new ProjectDetailsPage(project.Id));
            Projects.SelectedItem = null;
        }
    }
}
