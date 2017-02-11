using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using WhoBrokeIt.iOS.Services;
using WhoBrokeIt.UI.Helpers;

namespace WhoBrokeIt.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			var accountManager = new AccountManagerImplementation();
			var instance = Settings.VisualStudioInstance;
			var tokent = accountManager.GetTokenForInstance(instance);

			var formsApp = new UI.WhoBrokeItApp(instance, tokent);

			LoadApplication(formsApp);

			return base.FinishedLaunching(app, options);
		}
	}
}
