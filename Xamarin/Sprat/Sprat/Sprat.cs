using System;

using Xamarin.Forms;

namespace Sprat
{
    public enum Language { Ru, En}

	public class App : Application
	{
		static public float ScreenWidth;
		static public float ScreenHeight;

		public App ()
		{
            // The root page of your application
            MainPage = new StartPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

