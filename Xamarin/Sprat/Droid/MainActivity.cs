using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Sprat.Droid
{
	[Activity (Label = "Sprat.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			App.ScreenWidth = (float)((int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density));
			App.ScreenHeight = (float)((int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			//LoadApplication (new App ());

			Android.OS.Process.KillProcess (Android.OS.Process.MyPid());

		}
	}
}

