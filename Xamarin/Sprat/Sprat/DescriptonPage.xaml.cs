using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sprat
{
    public partial class DescriptonPage : ContentPage
    {
        public DescriptonPage()
        {
            InitializeComponent();

            OnLanguageChanged(null, null);
            StartPage.LanguageChanged += OnLanguageChanged;
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            switch (StartPage.Lang)
            {

                case Language.Ru:
                    DescrTxt.Text = App.Strings["DescriptionText"].Item1;
                    break;
                case Language.En:
                    DescrTxt.Text = App.Strings["DescriptionText"].Item2;
                    break;
                default:
                    break;
            }
        }
    }
}
