using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class SettingsPage : ContentPage
	{
        private Label header;
        private Picker picker;
        private StartPage startPage;

		public SettingsPage (StartPage startPage)
		{
			InitializeComponent ();
            this.startPage = startPage;

            header = new Label
            {
                Text = StartPage.Lang == Language.Ru ? "Выберите язык" : "Select language",
                Font = Font.BoldSystemFontOfSize(26),
                HorizontalOptions = LayoutOptions.Center
            };

            picker = new Picker
            {

                Title = StartPage.Lang == Language.Ru ?  "Русский": "English",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            picker.Items.Add("Русский");
            picker.Items.Add("English");

            StartPage.LanguageChanged += OnLanguageChanged;
            picker.SelectedIndexChanged += picker_SelectedIndexChanged;

            this.Content = new StackLayout { Children = { header, picker } };

        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartPage.Lang = (Language)picker.SelectedIndex;
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            switch (StartPage.Lang)
            {

                case Language.Ru:
                    header.Text = App.Strings["Header"].Item1;
                    break;
                case Language.En:
                    header.Text = App.Strings["Header"].Item2;
                    break;
            }
        }

    }
}

