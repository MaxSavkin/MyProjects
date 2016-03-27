using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class NewPage : ContentPage
	{
		public Game game;
		public int counter = 0;
		int Round = 0;
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
					fordGrid.Children.Add (game.Players [i].Cards [j].Content, i - 1, 1);

			for (int i = 0; i < game.StepInRoundCount; i++)
				Grid6.Children.Add (game.Players [0].Cards [i].Content, i, 1);
		}

		public void OnDoubleTup(object sender, EventArgs e)
		{
			if (!(game.Step > 0 && game.Step % game.StepInRoundCount == 0 && Round < game.Step / game.StepInRoundCount)) 
			{
				counter++;

				var res = game.DoStep2 ();

				if (counter <= 4) 
				{
					switch (res.Item1) 
					{
					case 0:
						res.Item2.Content.TranslateTo (0, -100);
						//AbsoluteLayout.SetLayoutFlags (res.Item2, AbsoluteLayoutFlags.PositionProportional);
						//AbsoluteLayout.SetLayoutBounds (res.Item2, 
						//	new Rectangle (0.5, 0.7, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
						break;
					case 1:
						res.Item2.Content.TranslateTo (50, 50);
						break;
					case 2:
						res.Item2.Content.TranslateTo (0, 50);
						break;
					case 3:
						res.Item2.Content.TranslateTo (-50, 50);
						break;
					default:
						break;
					}
				} 
				else 
				{
					counter = 0;
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

	}
}

