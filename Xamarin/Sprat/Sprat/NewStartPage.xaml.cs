using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sprat
{
    public partial class NewStartPage : ContentPage
    {
        private Label GameName;
        public NewStartPage()
        {
            InitializeComponent();

            this.Content.SizeChanged += OnStackSizeChanged;
        }

        private void DrawButtons()
        {
            Button PlayBtn = new Button() { Text = "Играть", TextColor = Color.FromRgb(189, 183, 107), FontAttributes = FontAttributes.Italic, BorderRadius = 1};
            AbsoluteLayout.SetLayoutFlags(PlayBtn, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(PlayBtn, new Rectangle(absoluteLayout.Width * 0.35, absoluteLayout.Height * 0.4, absoluteLayout.Width * 0.3, absoluteLayout.Height * 0.12));
            absoluteLayout.Children.Add(PlayBtn);

            Button ChangePlayBtn = new Button() { Text = "Поменять игру", TextColor = Color.FromRgb(189, 183, 107), FontAttributes = FontAttributes.Italic };
            AbsoluteLayout.SetLayoutFlags(ChangePlayBtn, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(ChangePlayBtn, new Rectangle(absoluteLayout.Width * 0.35, absoluteLayout.Height * 0.55, absoluteLayout.Width * 0.3, absoluteLayout.Height * 0.12));
            absoluteLayout.Children.Add(ChangePlayBtn);

            Button SettingsBtn = new Button() { Text = "Настройки", TextColor = Color.FromRgb(189, 183, 107), FontAttributes = FontAttributes.Italic };
            AbsoluteLayout.SetLayoutFlags(SettingsBtn, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(SettingsBtn, new Rectangle(absoluteLayout.Width * 0.35, absoluteLayout.Height * 0.7, absoluteLayout.Width * 0.3, absoluteLayout.Height * 0.12));
            absoluteLayout.Children.Add(SettingsBtn);

            Button DescBtn = new Button() { Text = "Правила", TextColor = Color.FromRgb(189, 183, 107), FontAttributes = FontAttributes.Italic };
            AbsoluteLayout.SetLayoutFlags(DescBtn, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(DescBtn, new Rectangle(absoluteLayout.Width * 0.35, absoluteLayout.Height * 0.85, absoluteLayout.Width * 0.3, absoluteLayout.Height * 0.12));
            absoluteLayout.Children.Add(DescBtn);
            DescBtn.Clicked += (sender, e) => this.Navigation.PushModalAsync(new DescriptonPage());

            GameName = new Label() { Text = "Кильки", Font = Font.SystemFontOfSize(20, FontAttributes.Bold), TextColor = Color.FromRgb(255, 228, 181), BackgroundColor = Color.Red};
            AbsoluteLayout.SetLayoutFlags(GameName, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(GameName, new Rectangle(absoluteLayout.Width * 0.3, absoluteLayout.Height * 0.15, absoluteLayout.Width * 0.4, absoluteLayout.Height * 0.1));
            absoluteLayout.Children.Add(GameName);

        }

        void OnStackSizeChanged(object sender, EventArgs args)
        {
            DrawButtons();
        }
    }
}
