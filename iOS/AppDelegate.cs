using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using WhoBrokeIt.iOS.Services;
using WhoBrokeIt.UI.Helpers;
using Xamarin.Forms.Platform.iOS;

namespace WhoBrokeIt.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            global::Xamarin.Forms.Forms.Init();

			var accountManager = new AccountManagerImplementation();
			var instance = Settings.VisualStudioInstance;
			var tokent = accountManager.GetTokenForInstance(instance);

			var formsApp = new UI.WhoBrokeItApp(instance, tokent);

			UIView.Appearance.TintColor = formsApp.VisualStudioColor.ToUIColor();
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent,true);

			LoadApplication(formsApp);

			return base.FinishedLaunching(app, options);
		}
	}
}
