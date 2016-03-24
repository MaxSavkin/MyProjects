using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class SettingsPage : ContentPage
	{
		private StartPage ParentPage;

		public SettingsPage (StartPage mainPage)
		{
			InitializeComponent ();
			LevelSlider.Value = mainPage.Level;
			this.ParentPage = mainPage;
		}

		public void OnClicked(object sender, EventArgs e)
		{
			ParentPage.Level = (int)LevelSlider.Value;
			this.Navigation.PopModalAsync ();
		}
	}
}

