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
			SourceControlLabel.Text = project.Capabilities?.Versioncontrol?.SourceControlType ?? "unknown";
			SourceControlImage.Source = SourceControlLabel.Text.ToLower();
			DescriptionLabel.Text = project.Description;

			var repos = await client.GetRepositories(_projectId);
			_repoId = repos.Value.FirstOrDefault()?.Id;

			if (SourceControlLabel.Text.Equals("git", StringComparison.OrdinalIgnoreCase))
			{
				var tg = new TapGestureRecognizer(async (v) =>
			   {
				   await Navigation.PushAsync(new RepositoryDetailPage(_repoId));
			   });
				SourceControlControl.GestureRecognizers.Add(tg);
			}
			else
			{
				ViewCommitsImage.IsVisible = false;
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

        private async void BuildDefView_BuildTapped(object sender, BasicBuildDefinition e)
        {
            await Navigation.PushAsync(new BuildsPage(_projectId, e.Id.ToString()));
        }
    }
}
