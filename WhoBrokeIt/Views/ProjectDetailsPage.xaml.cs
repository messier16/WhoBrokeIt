using Messier16.VstsClient.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoBrokeIt.UI.Controls;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
    public partial class ProjectDetailsPage : ContentPage
    {
		string _projectId;
		string _repoId;

		bool _initialLoad;

        public ProjectDetailsPage(string projectId)
        {
            _projectId = projectId;
			_initialLoad = true;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			if (!_initialLoad) return;
			_initialLoad = false;
			var client = WhoBrokeItApp.RealCurrent.Client;
            var project = await client.GetProject(_projectId);
            Title = project.Name;
            var sourceControl = project.Capabilities?.Versioncontrol?.SourceControlType ?? "unknown";
            //SourceControlButton.Text = sourceControl;
            SourceControlImage.Source = sourceControl.ToLower();
			DescriptionLabel.Text = project.Description;
            DescriptionLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            var repos = await client.GetRepositories(_projectId);
			_repoId = repos.Value.FirstOrDefault()?.Id;

			if (sourceControl.Equals("git", StringComparison.OrdinalIgnoreCase))
			{
                SourceControlButton.IsEnabled = true;
                SourceControlButton.Clicked += SourceControlButton_Clicked;
			}
			else
            {
                SourceControlButton.IsEnabled = false;
            }


			var definitions = await client.GetBuildDefinitions(_projectId);
			if (definitions.Count > 0)
			{
				foreach (var def in definitions.Value)
				{
					var buildDefView = new BuildDefinition();
                    buildDefView.BuildTapped += BuildDefView_BuildTapped;
					buildDefView.BindingContext = def;
					BuildDefsStack.Children.Add(buildDefView);
				}
			}
			else 
			{
                var emptyBuildDefinitions = new ListEmptyView("build_definition", "There are no build definitions")
                {
                    Margin = 5,
                    Padding = 5
                };
				BuildDefsStack.Children.Add(emptyBuildDefinitions);
			}
        }

        private async void SourceControlButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RepositoryDetailPage(_repoId));
        }

        private async void BuildDefView_BuildTapped(object sender, BasicBuildDefinition e)
        {
            await Navigation.PushAsync(new BuildsPage(_projectId, e.Id.ToString()));
        }
    }
}
