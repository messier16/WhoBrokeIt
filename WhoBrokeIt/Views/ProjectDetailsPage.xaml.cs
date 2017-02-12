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
        public ProjectDetailsPage(string projectId)
        {
            _projectId = projectId;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			var client = WhoBrokeItApp.RealCurrent.Client;
            var project = await client.GetProject(_projectId);
            Title = project.Name;
			SourceControlLabel.Text = project.Capabilities?.Versioncontrol?.SourceControlType;
			DescriptionLabel.Text = project.Description;

			var repos = await client.GetRepositories(_projectId);


			ReposCount.Text = repos.Value.FirstOrDefault()?.Id;
			var tg = new TapGestureRecognizer( async (v) => 
			{
				var repo = v as Label;
				await Navigation.PushAsync(new RepositoryDetailPage(repo.Text));
			});
			ReposCount.GestureRecognizers.Add(tg);


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
				BuildDefsStack.Children.Add(
					new Image { Source = "build_definition" });
			}
        }

        private async void BuildDefView_BuildTapped(object sender, BasicBuildDefinition e)
        {
            await Navigation.PushAsync(new BuildsPage(_projectId, e.Id.ToString()));
        }
    }
}
