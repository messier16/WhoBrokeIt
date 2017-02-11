using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Controls
{
	public partial class BuildDefinition : ContentView
	{
		public BuildDefinition()
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var build = BindingContext as BasicBuild;
			if (build != null)
			{
				BuildNameLabel.Text = build.Name;
				RequestorNameLabel.Text = build.AuthoredBy.DisplayName;
			}	
		}
	}
}
