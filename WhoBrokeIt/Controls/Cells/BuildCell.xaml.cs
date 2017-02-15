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
				BuildStatusLabel.Text = build.Result;
				RequestedForLabel.Text = build.Reason;
				string startedTime = "Not started";
				if (!build.Status.Equals("NotStarted", StringComparison.OrdinalIgnoreCase))
				{
					startedTime = String.Format("{0:ddd dd, MMM yyyy at HH:mm}", build.StartTime.LocalDateTime);
					if (build.Status.Equals("completed", StringComparison.OrdinalIgnoreCase))
					{
						var elapsedTime = build.FinishTime.LocalDateTime - build.StartTime.LocalDateTime;
						startedTime += String.Format(" - {0:#.##} minutos", elapsedTime.TotalMinutes);
						if (build.Result.Equals("succeeded", StringComparison.OrdinalIgnoreCase))
						{
							BuildStatusImage.Source = "ok";
						}
						else 
						{
							BuildStatusImage.Source = "error";
						}
					}
					else //if(build.Status.Equals("inprogress", StringComparison.OrdinalIgnoreCase))
					{
						BuildStatusImage.Source = "progress";
					}

				}
				BuildElapsedTimeLabel.Text = startedTime;
			}
		}
	}
}
