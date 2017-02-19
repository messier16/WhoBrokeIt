﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WhoBrokeIt.Droid.Services;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace WhoBrokeIt.Droid
{
	[Activity(Label = "WhoBrokeIt.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);
			//LocalizeImplementation.Init();
			//AccountManagerImplementation.Init();

            var instance = Intent.Extras.GetString("instance");
            var token = Intent.Extras.GetString("token");

            var formsApp = new UI.WhoBrokeItApp(instance, token);
            
            LoadApplication(formsApp);
		}
	}
}
