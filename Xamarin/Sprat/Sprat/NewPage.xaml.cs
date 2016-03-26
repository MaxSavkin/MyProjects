using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sprat
{
	public partial class NewPage : ContentPage
	{
		public NewPage ()
		{
			InitializeComponent ();
			Game game = new Game ();
			mainGrid.Children.Add(game.Players [0].Cards [0], 1, 3);
		}
	}
}

