using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class SettingsPage : ContentPage
	{
		private StartPage ParentPage;
        private Label header;
        private Picker picker;

		public SettingsPage (StartPage mainPage)
		{
			InitializeComponent ();
			this.ParentPage = mainPage;

            header = new Label
            {
                Text = "Выберите язык",
                Font = Font.BoldSystemFontOfSize(26),
                HorizontalOptions = LayoutOptions.Center
            };

            picker = new Picker
            {
                Title = "Русский",
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
            ParentPage.lang = (Language)picker.SelectedIndex;
        }

    }
}

