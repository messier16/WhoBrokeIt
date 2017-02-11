﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WhoBrokeIt.Droid.Services;

namespace WhoBrokeIt.Droid
{
	[Activity(Label = "WhoBrokeIt.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);


            var accountManager = new AccountManagerImplementation();
            var instance = WhoBrokeIt.UI.Helpers.Settings.VisualStudioInstance;
            var tokent = accountManager.GetTokenForInstance(instance);

            var formsApp = new UI.WhoBrokeItApp(instance, tokent);
            
            LoadApplication(formsApp);
		}
	}
}
