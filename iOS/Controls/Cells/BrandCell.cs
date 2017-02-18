using System;

using Foundation;
using UIKit;

namespace WhoBrokeIt.iOS.Controls.Cells
{
	public partial class BrandCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("BrandCell");
		public static readonly UINib Nib;

		static BrandCell()
		{
			Nib = UINib.FromName("BrandCell", NSBundle.MainBundle);

		}

		protected BrandCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

	}
}
