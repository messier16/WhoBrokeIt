using System;
using WhoBrokeIt.iOS.Controls.Cells;
using FormsBrandedCell = WhoBrokeIt.UI.Controls.Cells.BrandCell;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormsBrandedCell), typeof(BrandCellRenderer))]
namespace WhoBrokeIt.iOS.Controls.Cells
{
	public class BrandCellRenderer : ViewCellRenderer
	{
		public override UIKit.UITableViewCell GetCell(Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var tvc = tv.DequeueReusableCell("BrandCell");
			if (tvc == null)
			{
				tv.RegisterNibForCellReuse(BrandCell.Nib, "BrandCell");
				tvc = tv.DequeueReusableCell("BrandCell");
			}
			//tvc.Cell = item;

			//WireUpForceUpdateSizeRequested(item, tvc, tv);

			//tvc.TextLabel.Text = item.ToString();

			//UpdateBackground(tvc, item);
			return tvc;
		}
	}
}
