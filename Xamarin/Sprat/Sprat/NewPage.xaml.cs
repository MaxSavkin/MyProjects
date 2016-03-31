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

			/*for (int i = 0; i < 2; i++) 
			{
				absoluteLayout.Children.Add (game.Players [0].Cards [i]);
				AbsoluteLayout.SetLayoutFlags (game.Players [0].Cards [i], AbsoluteLayoutFlags.All);
				AbsoluteLayout.SetLayoutBounds (game.Players [0].Cards [i], new Rectangle (0.2 + (double)i/10, 0.8, 0.3, 0.3));
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
						res.Item2.Content.TranslateTo (0, -100);
						break;
					case 1:
						res.Item2.Content.IsVisible = true;
						res.Item2.Content.TranslateTo (50, 50);
						break;
					case 2:
						res.Item2.Content.IsVisible = true;
						res.Item2.Content.TranslateTo (0, 50);
						break;
					case 3:
						res.Item2.Content.IsVisible = true;
						res.Item2.Content.TranslateTo (-50, 50);
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
				absoluteLayout.Children.Add (game.Players [0].Cards [i], new Point {
					X = (2 + i) * width / 10,
					Y = height - 80
				});
			}
		}

	}
}

