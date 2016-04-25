using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class StartPage : ContentPage
	{
        public Language lang;
        private SettingsPage settingsPage;
        private NewPage newPage;
		public StartPage ()
		{
			InitializeComponent ();
            settingsPage = new SettingsPage(this);
            lang = Language.Ru;

			TapGestureRecognizer singleTupS = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			singleTupS.Tapped += OnSingleTupS;
			Settings.GestureRecognizers.Add (singleTupS);

			TapGestureRecognizer singleTupG = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			singleTupG.Tapped += OnSingleTupG;
			Play.GestureRecognizers.Add (singleTupG);

		}

		public void OnSingleTupS(object sender, EventArgs e)
		{
            settingsPage.Parent = null;
			this.Navigation.PushModalAsync (settingsPage);
		}
		public void OnSingleTupG(object sender, EventArgs e)
		{
            if (newPage == null)
                newPage = new NewPage();
            newPage.Parent = null;
			this.Navigation.PushModalAsync (newPage);
		}
	}
}