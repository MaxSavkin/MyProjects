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
		public NewPage ()
		{
			InitializeComponent ();
			game = new Game ();

			Init ();

			TapGestureRecognizer doubleTup = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			doubleTup.Tapped += OnDoubleTup;
			this.Content.GestureRecognizers.Add (doubleTup);
		}

		public void Init()
		{
			game = new Game ();

			for (int i = 1; i < game.PeopleCount; i++)
				for (int j = 0; j < game.StepInRoundCount; j++) 
				{
					fordGrid.Children.Add (game.Players [i].Cards [j].Content, i - 1, 1);
					game.Players [i].Cards [j].Content.IsVisible = false;
				}

			for (int i = 0; i < game.StepInRoundCount; i++)
				Grid6.Children.Add (game.Players [0].Cards [i].Content, i, 1);
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
					ToStartPos (FpStep);
					game.Init2NextStep ();
				}
			} 
			else 
			{
				game.FPRound++;
				game.FPStep = game.FPRound;
				Round++;
				if (game.FPRound > 5) {
					int t = (new Random ()).Next (4);
					game.TrumpSuit = (Suit)t;
				}
			}
		}

		public void ToStartPos (int FpStep)
		{
			for (int i = 0; i < game.PeopleCount; i++) 
			{
				switch ((i + FpStep) % game.PeopleCount) 
				{
				case 0:
					game.CardsOfCurrStep[0].Content.TranslateTo (0, 100);
					game.CardsOfCurrStep[0].Content.IsVisible = false;
					break;
				case 1:
					game.CardsOfCurrStep[1].Content.TranslateTo (-50, -50);
					game.CardsOfCurrStep[1].Content.IsVisible = false;
					break;
				case 2:
					game.CardsOfCurrStep[2].Content.TranslateTo (0, -50);
					game.CardsOfCurrStep[2].Content.IsVisible = false;
					break;
				case 3:
					game.CardsOfCurrStep[3].Content.TranslateTo (50, -50);
					game.CardsOfCurrStep[3].Content.IsVisible = false;
					break;
				default:
					break;
				}	
			}
		}

	}
}

