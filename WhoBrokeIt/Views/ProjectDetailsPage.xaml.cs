using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var project = await WhoBrokeItApp.RealCurrent.Client.GetProject(_projectId);
            Title = project.Name;
            DescriptionLabel.Text = project.Description;
        }
    }
}
