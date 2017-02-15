using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Controls.Cells
{
	public partial class BuildCell : ViewCell
	{
		public BuildCell()
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var build = BindingContext as Build;
			if (build != null)
			{
				BuildStatusLabel.Text = build.Status;
				BuildElapsedTimeLabel.Text = build.StartTime.LocalDateTime + " - " + build.FinishTime.LocalDateTime;
			}
		}
	}
}
