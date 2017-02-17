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
using WhoBrokeIt.Droid.Services;

namespace WhoBrokeIt.Droid
{

    [Activity(Label = "Who broke it?", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            var accountManager = new AccountManagerImplementation();
            var instance = WhoBrokeIt.UI.Helpers.Settings.VisualStudioInstance;
            var token = accountManager.GetTokenForInstance(instance);

            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("instance", instance);
            intent.PutExtra("token", token);
            StartActivity(intent);
        }
    }
}
