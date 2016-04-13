using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Sprat
{
	public partial class NewPage : ContentPage
	{
		public Game game;
		public NewPage ()
		{
			InitializeComponent ();
			game = new Game ();

            Score1.BindingContext = game.Players[1];
            Score2.BindingContext = game.Players[2];
            Score3.BindingContext = game.Players[3];
            Score0.BindingContext = game.Players[0];
            RndTxt.BindingContext = game;

            TapGestureRecognizer doubleTup = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			doubleTup.Tapped += OnDoubleTup;
			this.Content.GestureRecognizers.Add (doubleTup);

			this.Content.SizeChanged += OnStackSizeChanged;

            //Device.StartTimer(TimeSpan.FromSeconds(10), DoStep);
        }

		public void Init()
		{
            for (int i = 0; i < Game.StepInRoundCount; i++)
            {
                AbsoluteLayout.SetLayoutFlags(game.Players[0].Cards[i], AbsoluteLayoutFlags.None);
                AbsoluteLayout.SetLayoutBounds(game.Players[0].Cards[i], new Rectangle((i + 2) * absoluteLayout.Width / 10, this.absoluteLayout.Height - 60, absoluteLayout.Width / 10, 60));
                absoluteLayout.Children.Add(game.Players[0].Cards[i]);
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
                res = game.DoStep2();

                if (game.cnt <= 4)
                {
                    switch (res.Item1)
                    {
                        case 0:
                            res.Item2.TranslateTo(absoluteLayout.Width * 7 / 12 - res.Item2.X - Card.CWidth / 2, absoluteLayout.Height / 2 + 0 - res.Item2.Y);
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

    }
}

