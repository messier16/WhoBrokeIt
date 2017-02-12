using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhoBrokeIt.UI.Views
{
	public partial class RepositoryDetailPage : ContentPage
	{
		string _repoId;
		public RepositoryDetailPage(string repoId)
		{
			_repoId = repoId;
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var client = WhoBrokeItApp.RealCurrent.Client;

			var commits = await client.GetCommits(_repoId);

			CommitList.ItemsSource = commits.Value;
		}
	}
}
