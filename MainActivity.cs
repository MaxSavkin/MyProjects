[33mcommit d2cc495d4ebf92b24734a4843a40ffca647191e6[m
Author: Савкин Максим Евгениевич <savkin.m@aetp.nn>
Date:   Thu Mar 24 14:29:57 2016 +0300

    Add Xamarin Projects

[1mdiff --git a/Xamarin/Sprat/Droid/MainActivity.cs b/Xamarin/Sprat/Droid/MainActivity.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..5bf9ba7[m
[1m--- /dev/null[m
[1m+++ b/Xamarin/Sprat/Droid/MainActivity.cs[m
[36m@@ -0,0 +1,32 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m
[32m+[m[32musing Android.App;[m
[32m+[m[32musing Android.Content;[m
[32m+[m[32musing Android.Content.PM;[m
[32m+[m[32musing Android.Runtime;[m
[32m+[m[32musing Android.Views;[m
[32m+[m[32musing Android.Widget;[m
[32m+[m[32musing Android.OS;[m
[32m+[m
[32m+[m[32mnamespace Sprat.Droid[m
[32m+[m[32m{[m
[32m+[m	[32m[Activity (Label = "Sprat.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)][m
[32m+[m	[32mpublic class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity[m
[32m+[m	[32m{[m
[32m+[m		[32mprotected override void OnCreate (Bundle bundle)[m
[32m+[m		[32m{[m
[32m+[m			[32mApp.ScreenWidth = (float)((int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density));[m
[32m+[m			[32mApp.ScreenHeight = (float)((int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));[m
[32m+[m
[32m+[m			[32mbase.OnCreate (bundle);[m
[32m+[m
[32m+[m			[32mglobal::Xamarin.Forms.Forms.Init (this, bundle);[m
[32m+[m
[32m+[m			[32m//LoadApplication (new App ());[m
[32m+[m
[32m+[m			[32mAndroid.OS.Process.KillProcess (Android.OS.Process.MyPid());[m
[32m+[m
[32m+[m		[32m}[m
[32m+[m	[32m}[m
[32m+[m[32m}[m
[32m+[m
