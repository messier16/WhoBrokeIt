using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;
using Humanizer;

namespace WhoBrokeIt.UI.Controls.Cells
{
	public partial class CommitCell : ViewCell
	{
		public CommitCell()
		{
			InitializeComponent();

		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var commit = BindingContext as Commit;
			if (commit != null)
			{
			    var commitDate = commit.Committer.Date.ToLocalTime().LocalDateTime;
                if (commitDate > DateTime.Today.AddDays(-1))
                {
                    CommitDateTimeLabel.Text = commitDate.Humanize(false, DateTime.Now);
                }
                else
                {
                    CommitDateTimeLabel.Text = String.Format("{0:dddd dd, MMMM yyyy at HH:mm}", commitDate);
                }
				CommitAuthorLabel.Text = commit.Author.Name;
				CommitDescriptionLabel.Text = commit.Comment;
				EditionsLabel.Text = commit.ChangeCounts.Edit?.ToString() ?? "-";
				AdditionsLabel.Text = commit.ChangeCounts.Add?.ToString() ?? "-";
				DeletionsLabel.Text = commit.ChangeCounts.Delete?.ToString() ?? "-";
			}
		}
	}
}
