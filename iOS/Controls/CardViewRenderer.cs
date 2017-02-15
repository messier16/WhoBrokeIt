using System;
using UIKit;
using CoreGraphics;
using WhoBrokeIt.iOS.Controls;
using WhoBrokeIt.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CardView), typeof(CardViewRenderer))]
namespace WhoBrokeIt.iOS.Controls
{
	public class CardViewRenderer : FrameRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);

			base.NativeView.Layer.CornerRadius = 0;
			base.NativeView.Layer.ShadowColor = UIColor.Black.CGColor;
			base.NativeView.Layer.ShadowOffset = new CGSize(0, 0);
			NativeView.Layer.ShadowRadius = 2;
			NativeView.Layer.ShadowOpacity = 0.5f;
		}
	}
}

