using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Sprat
{
	public partial class NewPage : ContentPage
	{
		public Game game;

        private Label Player0Txt;
        private Image PlayerImg;
        private Label Score0;
        private Label TrumpTxt;
        private Image TrumpImg;
        public NewPage ()
		{
			InitializeComponent ();
			game = new Game ();

            Score1.BindingContext = game.Players[1];
            Score2.BindingContext = game.Players[2];
            Score3.BindingContext = game.Players[3];
            
            RndTxt.BindingContext = game;
            game.PropertyChanged += OnLanguageChanged;
            
            StartPage.LanguageChanged += OnLanguageChanged;
            this.Content.SizeChanged += OnStackSizeChanged;
            OnLanguageChanged(null, null);

            Device.StartTimer(TimeSpan.FromMilliseconds(500), DoStep);
        }

		public void Init()
		{
            for (int i = 0; i < Game.StepInRoundCount; i++)
            {
                AbsoluteLayout.SetLayoutFlags(game.Players[0].Cards[i], AbsoluteLayoutFlags.None);
                AbsoluteLayout.SetLayoutBounds(game.Players[0].Cards[i], new Rectangle((i + 2) * absoluteLayout.Width / 10, this.absoluteLayout.Height - 60, absoluteLayout.Width / 10, 60));
                absoluteLayout.Children.Add(game.Players[0].Cards[i]);
                game.Players[0].Cards[i].singleTup.Tapped += WaitPlayerAction;
            }

            Card.CHeight = game.Players[0].Cards[0].Height;
            Card.CWidth = game.Players[0].Cards[0].Width;

            for (int i = 1; i < Game.PeopleCount; i++)
                for (int j = 0; j < Game.StepInRoundCount; j++)
                {
                    AbsoluteLayout.SetLayoutFlags(game.Players[i].Cards[j], AbsoluteLayoutFlags.None);
                    AbsoluteLayout.SetLayoutBounds(game.Players[i].Cards[j], new Rectangle(i * absoluteLayout.Width / 3 - absoluteLayout.Width / 6 - Card.CWidth / 2,
                        0, Card.CWidth, Card.CHeight));
                    absoluteLayout.Children.Add(game.Players[i].Cards[j]);
                    game.Players[i].Cards[j].IsVisible = false;
                }

            Label Player0Txt = new Label() { Text = "Игрок", HorizontalOptions = LayoutOptions.Center };
            Image PlayerImg = new Image { Source = "Player0.jpg", HorizontalOptions = LayoutOptions.Center };
            Label Score0 = new Label() { Text = "0", HorizontalOptions = LayoutOptions.Center };
            Score0.BindingContext = game.Players[0];

            TrumpTxt = new Label() { Text = "Козырь", HorizontalOptions = LayoutOptions.Center };
            TrumpImg = new Image { Source = "Trump.jpg" };

            absoluteLayout.Children.Add(new StackLayout() { Children = { TrumpTxt }, Spacing = 0, HorizontalOptions = LayoutOptions.Center },
                new Rectangle(0, 0, absoluteLayout.Width * 0.2, absoluteLayout.Height), AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.YProportional);
            absoluteLayout.Children.Add(TrumpImg,
                new Rectangle(0.2 * absoluteLayout.Width / 2 - Card.CWidth / 2, HintTxt.Height, Card.CWidth, Card.CHeight));
            absoluteLayout.Children.Add(new StackLayout() { Children = { Player0Txt, new Image { Source = "Player0.jpg", HorizontalOptions = LayoutOptions.Center }, Score0 },
                Spacing = 0, HorizontalOptions = LayoutOptions.Center }, 
                new Rectangle(0, 0.8, absoluteLayout.Width * 0.2, absoluteLayout.Height / 2), AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.YProportional);

        }

		public void OnDoubleTup(object sender, EventArgs e)
		{
            DoStep();
		}

        public bool DoStep()
        {
            Tuple<int, Card> res;
            if (!(game.Step > 0 && game.Step % Game.StepInRoundCount == 0 && (game.Round - 1) < game.Step / Game.StepInRoundCount))
            {
                if ((game.FPStep + game.cnt - 1 + Game.PeopleCount) % Game.PeopleCount == 3 && game.cnt != Game.PeopleCount)
                {
                    if (!game.IsPaused)
                    {
                        game.UpdatePossibleCards();
                        foreach (var card in game.PossibleCards)
                            card.TranslateTo(0, -10);

                        game.IsPaused = true;
                        return false;
                    }
                    else
                        game.IsPaused = false;
                }

                res = game.DoStep2();

                if (game.cnt <= 4)
                {
                    switch (res.Item1)
                    {
                        case 0:
                            res.Item2.TranslateTo(absoluteLayout.Width * 7 / 12 - res.Item2.X - Card.CWidth / 2, absoluteLayout.Height / 2 + 0 - res.Item2.Y - 10);
                            foreach (var card in game.PossibleCards.Where(x => x != res.Item2))
                                card.TranslateTo(0, 0);
                            break;
                        case 1:
                            res.Item2.IsVisible = true;
                            res.Item2.TranslateTo(absoluteLayout.Width * 7 / 12 - res.Item2.X - Card.CWidth / 2 - 20 - Card.CWidth, absoluteLayout.Height / 2 - 0 - Card.CHeight);
                            break;
                        case 2:
                            res.Item2.IsVisible = true;
                            res.Item2.TranslateTo(absoluteLayout.Width * 7 / 12 - res.Item2.X - Card.CWidth / 2, absoluteLayout.Height / 2 - 0 - Card.CHeight);
                            break;
                        case 3:
                            res.Item2.IsVisible = true;
                            res.Item2.TranslateTo(absoluteLayout.Width * 7 / 12 - res.Item2.X - Card.CWidth / 2 + 20 + Card.CWidth, absoluteLayout.Height / 2 - 0 - Card.CHeight);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    foreach (var elem in game.CardsOfCurrStep)
                        elem.Content.IsVisible = false;
                    game.Init2NextStep();
                }
            }
            else
            {
                Init();
                game.FPRound++;
                game.FPStep = game.FPRound;
                game.Round++;
                if (game.FPRound > 5)
                {
                    int t = (new Random()).Next(4);
                    game.TrumpSuit = (Suit)t;
                }
            }

            return true;
        }

		void OnStackSizeChanged (object sender, EventArgs args)
		{
            Init();
        }

        void WaitPlayerAction(object sender, EventArgs e)
        {
            if (game.IsPaused)
                if (game.PossibleCards.Contains(Card.SelectedCard))
                    Device.StartTimer(TimeSpan.FromMilliseconds(500), DoStep);
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            switch (StartPage.Lang)
            {

                case Language.Ru:
                    NameTxt.Text = App.Strings["Name"].Item1;
                    RndTxt.Text = string.Format("{0}: {1}", App.Strings["Round"].Item1, game.Round);
                    Player1Txt.Text = App.Strings["Player1"].Item1;
                    Player2Txt.Text = App.Strings["Player2"].Item1;
                    Player3Txt.Text = App.Strings["Player3"].Item1;
                    Player0Txt.Text = App.Strings["Player0"].Item1;

                    switch (game.Round)
                    {
                        case 1:
                            HintTxt.Text = App.Strings["Hint1"].Item1;
                            break;
                        case 2:
                            HintTxt.Text = App.Strings["Hint2"].Item1;
                            break;
                        case 3:
                            HintTxt.Text = App.Strings["Hint3"].Item1;
                            break;
                        case 4:
                            HintTxt.Text = App.Strings["Hint4"].Item1;
                            break;
                        case 5:
                            HintTxt.Text = App.Strings["Hint5"].Item1;
                            break;
                        case 6:
                            HintTxt.Text = App.Strings["Hint6"].Item1;
                            break;
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            HintTxt.Text = App.Strings["Hint0"].Item1;
                            break;
                    }

                    break;
                case Language.En:
                    NameTxt.Text = App.Strings["Name"].Item2;
                    RndTxt.Text = string.Format("{0}: {1}", App.Strings["Round"].Item2, game.Round);
                    Player1Txt.Text = App.Strings["Player1"].Item2;
                    Player2Txt.Text = App.Strings["Player2"].Item2;
                    Player3Txt.Text = App.Strings["Player3"].Item2;
                    Player0Txt.Text = App.Strings["Player0"].Item2;

                    switch (game.Round)
                    {
                        case 1:
                            HintTxt.Text = App.Strings["Hint1"].Item2;
                            break;
                        case 2:
                            HintTxt.Text = App.Strings["Hint2"].Item2;
                            break;
                        case 3:
                            HintTxt.Text = App.Strings["Hint3"].Item2;
                            break;
                        case 4:
                            HintTxt.Text = App.Strings["Hint4"].Item2;
                            break;
                        case 5:
                            HintTxt.Text = App.Strings["Hint5"].Item2;
                            break;
                        case 6:
                            HintTxt.Text = App.Strings["Hint6"].Item2;
                            break;
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            HintTxt.Text = App.Strings["Hint0"].Item2;
                            break;
                    }

                    break;
            }
        }

    }
}

