using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class StartPage : ContentPage
	{
        private Language lang;
        public Language Lang
        {
            get{ return lang; }
            set
            {
                if (value != lang)
                {
                    lang = value;
                    ValueChanged(null, new LanguageEventArgs() { lang = lang });
                }
            }
        }
        public static event EventHandler ValueChanged;
		public StartPage ()
		{
			InitializeComponent ();
            lang = Language.Ru;

            TapGestureRecognizer singleTupSettings = new TapGestureRecognizer();
            singleTupSettings.Tapped += OnSingleTupSettings;
			Settings.GestureRecognizers.Add (singleTupSettings);

            TapGestureRecognizer singleTupGame = new TapGestureRecognizer();
            singleTupGame.Tapped += OnSingleTupGame;
			Play.GestureRecognizers.Add (singleTupGame);

            TapGestureRecognizer singleTupDescription = new TapGestureRecognizer();
            singleTupDescription.Tapped += OnSingleTupDescription;
            Description.GestureRecognizers.Add(singleTupDescription);

            ValueChanged += OnValueChanged;

        }

		public void OnSingleTupSettings(object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new SettingsPage(this));
		}
		public void OnSingleTupGame(object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new NewPage());
		}

        public void OnSingleTupDescription(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DescriptonPage());
        }

        public void OnValueChanged(object sender, EventArgs e)
        {
            switch ((e as LanguageEventArgs).lang)
            {
                
                case Language.Ru:
                    ((Label)Play.Content).Text = App.Strings["Play"].Item1;
                    ((Label)Settings.Content).Text = App.Strings["Settings"].Item1;
                    ((Label)Description.Content).Text = App.Strings["Description"].Item1;
                    break;
                case Language.En:
                    ((Label)Play.Content).Text = App.Strings["Play"].Item2;
                    ((Label)Settings.Content).Text = App.Strings["Settings"].Item2;
                    ((Label)Description.Content).Text = App.Strings["Description"].Item2;
                    break;
                default:
                    break;
            }
        }
    }
}