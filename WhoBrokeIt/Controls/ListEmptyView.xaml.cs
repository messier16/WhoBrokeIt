using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WhoBrokeIt.UI.Controls
{
    public partial class ListEmptyView : ContentView
    {
        public ListEmptyView(FileImageSource image, string text)
        {
            InitializeComponent();

            EmptyImage.Source = image;
            EmptyTextLabel.Text = text;
        }
    }
}
