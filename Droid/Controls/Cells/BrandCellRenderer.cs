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
using Xamarin.Forms.Platform.Android;
using WhoBrokeIt.UI.Controls.Cells;
using WhoBrokeIt.Droid.Controls.Cells;

[assembly: ExportRenderer(typeof(BrandCell), typeof(BrandCellRenderer))]
namespace WhoBrokeIt.Droid.Controls.Cells
{
    public class BrandCellRenderer : ViewCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {

            var inflater = LayoutInflater.FromContext(context);
            var view = inflater.Inflate(Resource.Layout.BrandCell, null);

            return view;
        }
    }
}