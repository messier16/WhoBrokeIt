using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;

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
				CommitDateTimeLabel.Text = commit.Committer.Date.ToLocalTime().LocalDateTime.ToString();
				CommitAuthorLabel.Text = commit.Author.Name;
				CommitDescriptionLabel.Text = commit.Comment;
				EditionsLabel.Text = commit.ChangeCounts.Edit?.ToString() ?? "-";
				AdditionsLabel.Text = commit.ChangeCounts.Add?.ToString() ?? "-";
				DeletionsLabel.Text = commit.ChangeCounts.Delete?.ToString() ?? "-";
			}
		}
	}
}
