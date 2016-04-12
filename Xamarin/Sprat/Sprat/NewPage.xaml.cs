using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Sprat
{
	public partial class NewPage : ContentPage
	{
		public Game game;
		public int counter = 0;
		int Round = 0;
		int FpStep = 0;
		double width;
		double height;
		public NewPage ()
		{
			InitializeComponent ();
			game = new Game ();
			Init ();
			TapGestureRecognizer doubleTup = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			doubleTup.Tapped += OnDoubleTup;
			this.Content.GestureRecognizers.Add (doubleTup);

			this.Content.SizeChanged += OnStackSizeChanged; 

		}

		public void Init()
		{
			/*for (int i = 1; i < game.PeopleCount; i++)
				for (int j = 0; j < game.StepInRoundCount; j++) 
				{
					fordGrid.Children.Add (game.Players [i].Cards [j].Content, i - 1, 1);
					game.Players [i].Cards [j].Content.IsVisible = false;
				}*/
		}

		public void OnDoubleTup(object sender, EventArgs e)
		{
			Tuple<int, Card> res;
			if (!(game.Step > 0 && game.Step % game.StepInRoundCount == 0 && Round < game.Step / game.StepInRoundCount)) 
			{
				res = game.DoStep2 ();

				if (game.cnt <= 4) 
				{
					FpStep = game.FPStep;
					switch (res.Item1) 
					{
					case 0:
                        res.Item2.TranslateTo(App.ScreenWidth * 7 / 12 - res.Item2.X - Card.CWidth / 2, -100);
						break;
					case 1:
						res.Item2.IsVisible = true;
						res.Item2.TranslateTo (50, 50);
						break;
					case 2:
						res.Item2.IsVisible = true;
						res.Item2.TranslateTo (0, 50);
						break;
					case 3:
						res.Item2.IsVisible = true;
						res.Item2.TranslateTo (-50, 50);
						break;
					default:
						break;
					}
				} 
				else 
				{
					foreach (var elem in game.CardsOfCurrStep)
						elem.Content.IsVisible = false;
					game.Init2NextStep ();

					switch (game.WinPlayer) 
					{
					case 0:
						//Score0.Text = game.Players [0].Score.ToString();
						break;
					case 1:
						Score1.Text = game.Players [1].Score.ToString();
						break;
					case 2:
						Score2.Text = game.Players [2].Score.ToString();
						break;
					case 3:
						Score3.Text = game.Players [3].Score.ToString();
						break;
					}
				}
			} 
			else 
			{
				//fordGrid.Children.Clear ();
				//Grid6.Children.Clear ();
				Init ();
				game.FPRound++;
				game.FPStep = game.FPRound;
				Round++;
				if (game.FPRound > 5) {
					int t = (new Random ()).Next (4);
					game.TrumpSuit = (Suit)t;
				}
			}
		}

		void OnStackSizeChanged (object sender, EventArgs args)
		{
			width = this.absoluteLayout.Width;
			height = this.absoluteLayout.Height;
			var res = game.Players [0].Cards [0].Content.Height;
			var asd = App.ScreenWidth;
			for (int i = 0; i < game.StepInRoundCount; i++) 
			{
                AbsoluteLayout.SetLayoutFlags(game.Players[0].Cards[i], AbsoluteLayoutFlags.None);
                AbsoluteLayout.SetLayoutBounds(game.Players[0].Cards[i], new Rectangle((i + 2) * absoluteLayout.Width / 10, this.absoluteLayout.Height - 60, absoluteLayout.Width / 10, 60));
                absoluteLayout.Children.Add(game.Players[0].Cards[i]);
			}

            Card.CHeight = game.Players[0].Cards[0].Height;
            Card.CWidth = game.Players[0].Cards[0].Width;

            for (int i = 1; i < game.PeopleCount; i++)
				for (int j = 0; j < game.StepInRoundCount; j++) 
				{
                    AbsoluteLayout.SetLayoutFlags(game.Players[i].Cards[j], AbsoluteLayoutFlags.None);
                    AbsoluteLayout.SetLayoutBounds(game.Players[i].Cards[j], new Rectangle(i * absoluteLayout.Width / 3 - absoluteLayout.Width / 6 - Card.CWidth / 2,
                        this.absoluteLayout.X, Card.CWidth, Card.CHeight));
                    absoluteLayout.Children.Add(game.Players[i].Cards[j]);
                    //game.Players [i].Cards [j].IsVisible = false;
				}

        }

    }
}

