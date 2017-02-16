using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Messier16.VstsClient.Objects;
using WhoBrokeIt.UI.Helpers;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
    public partial class ProjectListPage : ContentPage
    {
        bool _firstLoad;
        public ProjectListPage()
        {
            _firstLoad = true;
			NavigationPage.SetBackButtonTitle(this, "");
			Title = Settings.VisualStudioInstance;

            InitializeComponent();

			ToolbarItem settingsButton = new ToolbarItem
			{
				Text = "Settings",
				Icon = "settings"
			};
            settingsButton.Clicked += SettingsButton_Clicked;
			ToolbarItems.Add(settingsButton);
        }

        private async void SettingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!_firstLoad) return;

            var client = WhoBrokeItApp.RealCurrent.Client;
            var projects = await client.GetProjects();
			BasicProjectGroup.SetProjects(projects.Value);
			Projects.ItemsSource = BasicProjectGroup.All;
            _firstLoad = false;
        }

        private async void ProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Projects.SelectedItem == null) return;

            var project = Projects.SelectedItem as BasicProject;
            await Navigation.PushAsync(new ProjectDetailsPage(project.Id));
            Projects.SelectedItem = null;
        }

		public class BasicProjectGroup : List<BasicProject>
		{
			public string Title { get; set; }
			public string ShortName { get; set; } //will be used for jump lists
			public string Subtitle { get; set; }

			private BasicProjectGroup(string title, 
			                          char shortName, 
			                          IEnumerable<BasicProject> projects) : base(projects)
			{
				Title = title;
				ShortName = shortName.ToString();
			}

			public static void SetProjects(List<BasicProject> projects)
			{
				var basicProjects = projects.GroupBy(p => Char.ToLower(p.Name[0]))
				                            .OrderBy((arg) => arg.Key)
				                            .Select((arg1, arg2) => 
				                                    new BasicProjectGroup(arg1.FirstOrDefault().Name,arg1.Key, arg1));;

				All = basicProjects.ToList();
			}
			public static List<BasicProjectGroup> All { private set; get; }
		}
    }
}
