using System;
using Xamarin.Forms;

namespace Sprat
{
	public enum Suit { Diamond = 0, Heart, Club, Spade }
	public enum Number { Seven = 7, Eight, Nine, Ten, Jack, Queen, King, Ace}

	public class Card : Frame
	{
		public Suit Suit { get; set; }
		public Number Number { get; set; }
		private Image CardImage;

		public Card(Suit suit, Number number)
		{
			this.Suit = suit;
			this.Number = number;
			SetCardImage (this.Suit, this.Number);
		}

		public void SetCardImage(Suit newSuit, Number newNumber)
		{
			CardImage = new Image (){ Source = string.Format ("{0}_{1}.bmp", newSuit.ToString ().Substring (0, 1), newNumber.ToString ()) };
			this.Content = CardImage;
		}
	}
}

