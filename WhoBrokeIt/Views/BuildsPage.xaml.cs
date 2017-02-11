using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
    public partial class BuildsPage : ContentPage
    {
        string _projectId;
        string _definition; 

        public BuildsPage(string projectId, string definition)
        {
            _projectId = projectId;
            _definition = definition;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var client = WhoBrokeItApp.RealCurrent.Client;
            var builds = await client.GetBuilds(_projectId, _definition);

            BuildsList.ItemsSource = builds.Value;
        }
    }
}
