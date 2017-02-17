using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using WhoBrokeIt.UI.Controls.Cells;
using WhoBrokeIt.Droid.Controls.Cells;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MenuCell), typeof(MenuCellRenderer))]
namespace WhoBrokeIt.Droid.Controls.Cells
{
    public class MenuCellRenderer : ImageCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {

            LinearLayout cell = (LinearLayout)base.GetCellCore(item, convertView, parent, context);

            ImageView image = (ImageView)cell.GetChildAt(0);
            image.SetScaleType(ImageView.ScaleType.Center);
            return cell;
        }
    }
}
