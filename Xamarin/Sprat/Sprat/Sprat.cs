using System;

using System.Collections.Generic;
using Xamarin.Forms;

namespace Sprat
{
    public enum Language { Ru, En}

    public class LanguageEventArgs : EventArgs
    {
        public Language lang { get; set; }
    }

    public class App : Application
	{
		static public float ScreenWidth;
		static public float ScreenHeight;

        static public Dictionary<string, Tuple<string, string>> Strings = new Dictionary<string, Tuple<string, string>>()
        {
            { "Name", new Tuple<string, string>("Кильки", "Sprat") },
            { "Round", new Tuple<string, string>("Раунд", "Round") },
            { "Player0", new Tuple<string, string>("Игрок", "Player") },
            { "Player1", new Tuple<string, string>("Вова", "Vova") },
            { "Player2", new Tuple<string, string>("Дима", "Dima") },
            { "Player3", new Tuple<string, string>("Юра", "Yura") },
            { "Play", new Tuple<string, string>("Играть", "Play") },
            { "Settings", new Tuple<string, string>("Настройки", "Settings") },
            { "Description", new Tuple<string, string>("Описание", "Description") },
        };

        public App ()
		{
            // The root page of your application
            MainPage = new NavigationPage(new StartPage());
            //MainPage = new NewPage();
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

