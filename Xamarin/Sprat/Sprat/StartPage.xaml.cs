using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class StartPage : ContentPage
	{
		public int Level = 1;
		public StartPage ()
		{
			InitializeComponent ();

			TapGestureRecognizer singleTupS = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			singleTupS.Tapped += OnSingleTupS;
			Settings.GestureRecognizers.Add (singleTupS);

			TapGestureRecognizer singleTupG = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			singleTupG.Tapped += OnSingleTupG;
			Play.GestureRecognizers.Add (singleTupG);

		}

		public void OnSingleTupS(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync (new SettingsPage (this));
		}
		public void OnSingleTupG(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync (new GamePage());
		}
	}
}