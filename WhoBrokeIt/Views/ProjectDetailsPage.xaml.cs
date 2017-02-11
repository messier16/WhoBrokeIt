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
            DescriptionLabel.Text = project.Description;

			var definitions = await client.BuildsForProject(_projectId);
			if (definitions.Count > 0)
			{
				foreach (var def in definitions.Value)
				{
					var buildDefView = new BuildDefinition();
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
    }
}
