using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Sprat
{
	public partial class GamePage : ContentPage
	{
		public Game game;
		public AbsoluteLayout absoluteLayout;
		public int counter = 0;

		Label Score0;
		Label Score1;
		Label Score2;
		Label Score3;
		Label RoundText;
		Label TrumpText;

		int Round = 0;

		public GamePage ()
		{
			InitializeComponent ();
			absoluteLayout = new AbsoluteLayout();
			absoluteLayout.BackgroundColor = Color.Green;
			game = new Game ();

			Score0 = new Label { Text = "0", Font = Font.SystemFontOfSize(25) };
			Score1 = new Label { Text = "0", Font = Font.SystemFontOfSize(25) };
			Score2 = new Label { Text = "0", Font = Font.SystemFontOfSize(25) };
			Score3 = new Label { Text = "0", Font = Font.SystemFontOfSize(25) };
			RoundText = new Label { Text = string.Format("R = {0}", Round), Font = Font.SystemFontOfSize(25) };
			TrumpText = new Label { Text = ((int)game.TrumpSuit).ToString(), Font = Font.SystemFontOfSize(25) };

			InitCards ();

			TapGestureRecognizer doubleTup = new TapGestureRecognizer () { NumberOfTapsRequired = 1 };
			doubleTup.Tapped += OnDoubleTup;
			absoluteLayout.GestureRecognizers.Add (doubleTup);
		}

		public void InitCards()
		{
			absoluteLayout.Children.Clear ();

			absoluteLayout.Children.Add(Score0, new Point { X = 210, Y = 450});
			absoluteLayout.Children.Add(Score1, new Point { X = 10, Y = 450});
			absoluteLayout.Children.Add(Score2, new Point { X = 210, Y = 130});
			absoluteLayout.Children.Add(Score3, new Point { X = 370, Y = 450});
			RoundText.Text = string.Format ("R = {0}", Round);
			absoluteLayout.Children.Add(RoundText, new Point { X = 180, Y = 285});
			TrumpText.Text = ((int)game.TrumpSuit).ToString ();;
			absoluteLayout.Children.Add(TrumpText, new Point { X = 200, Y = 310});

			for (int i = 0; i < game.StepInRoundCount; i++) 
			{
				AbsoluteLayout.SetLayoutFlags(game.Players[0].Cards[i], AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds (game.Players [0].Cards [i], 
					new Rectangle (i * 1f / game.StepInRoundCount, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				absoluteLayout.Children.Add (game.Players[0].Cards[i]);
			}

			for (int i = 0; i < game.StepInRoundCount; i++) 
			{
				AbsoluteLayout.SetLayoutFlags(game.Players[1].Cards[i], AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds (game.Players [1].Cards [i], 
					new Rectangle (0f, (i + 4) * 1f / (game.StepInRoundCount + 8), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				absoluteLayout.Children.Add (game.Players[1].Cards[i]);
			}

			for (int i = 0; i < game.StepInRoundCount; i++) 
			{
				AbsoluteLayout.SetLayoutFlags(game.Players[2].Cards[i], AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds (game.Players [2].Cards [i], 
					new Rectangle (i * 1f / game.StepInRoundCount, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				absoluteLayout.Children.Add (game.Players[2].Cards[i]);
			}

			for (int i = 0; i < game.StepInRoundCount; i++) 
			{
				AbsoluteLayout.SetLayoutFlags(game.Players[3].Cards[i], AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds (game.Players [3].Cards [i], 
					new Rectangle (1f, (i + 4) * 1f / (game.StepInRoundCount + 8), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				absoluteLayout.Children.Add (game.Players[3].Cards[i]);
			}

			this.Content = absoluteLayout;
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
						res.Item2.TranslateTo (-100, 100);
						//AbsoluteLayout.SetLayoutFlags (res.Item2, AbsoluteLayoutFlags.PositionProportional);
						//AbsoluteLayout.SetLayoutBounds (res.Item2, 
						//	new Rectangle (0.5, 0.7, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
						break;
					case 1:
						AbsoluteLayout.SetLayoutFlags (res.Item2, AbsoluteLayoutFlags.PositionProportional);
						AbsoluteLayout.SetLayoutBounds (res.Item2, 
							new Rectangle (0.3, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
						break;
					case 2:
						AbsoluteLayout.SetLayoutFlags (res.Item2, AbsoluteLayoutFlags.PositionProportional);
						AbsoluteLayout.SetLayoutBounds (res.Item2, 
							new Rectangle (0.5, 0.3, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
						break;
					case 3:
						AbsoluteLayout.SetLayoutFlags (res.Item2, AbsoluteLayoutFlags.PositionProportional);
						AbsoluteLayout.SetLayoutBounds (res.Item2, 
							new Rectangle (0.7, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
						break;
					default:
						break;
					}
				} 
				else 
				{
					counter = 0;

					switch (res.Item1) 
					{
					case 0:
						Score0.Text = game.Players [res.Item1].Score.ToString();
						break;
					case 1:
						Score1.Text = game.Players [res.Item1].Score.ToString();
						break;
					case 2:
						Score2.Text = game.Players [res.Item1].Score.ToString();
						break;
					case 3:
						Score3.Text = game.Players [res.Item1].Score.ToString();
						break;
					default:
						break;
					}
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
				InitCards ();
			}
		}

	}
}

