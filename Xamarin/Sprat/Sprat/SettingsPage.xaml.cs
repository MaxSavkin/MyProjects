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
                Text = "Выберите язык",
                Font = Font.BoldSystemFontOfSize(26),
                HorizontalOptions = LayoutOptions.Center
            };

            picker = new Picker
            {

                Title = startPage.Lang == Language.Ru ?  "Русский": "English",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            picker.Items.Add("Русский");
            picker.Items.Add("English");

            picker.SelectedIndexChanged += picker_SelectedIndexChanged;

            this.Content = new StackLayout { Children = { header, picker } };

        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            startPage.Lang = (Language)picker.SelectedIndex;
        }

    }
}

