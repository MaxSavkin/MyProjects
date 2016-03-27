using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sprat
{
	public class Game
	{
		public int PeopleCount = 4;
		public int CardsCount = 32;
		public int StepInRoundCount = 8;

		public List<Player> Players;

		public int Step;

		public List<Card> CardsOfCurrStep;
		public int FPStep;
		public int FPRound;
		public int cnt = 0;
		public Suit TrumpSuit;

		public Game()
		{
			Step = 0;
			CardsOfCurrStep = new List<Card>();
			CreatePlayers();
			TrumpSuit = 0;
		}

		public void DoStep()
		{
			for (int i = FPStep + 1; i <= FPStep + 4; i++) 
			{
				CardsOfCurrStep.Add (Players [i % PeopleCount].DoStep (CardsOfCurrStep, Step / StepInRoundCount, Step % StepInRoundCount));
				CardsOfCurrStep.Last ().SetCardImageNull ();
			}

			int WinPlayer = (new Random()).Next(4);
			Players[WinPlayer].BribeCards.AddRange(CardsOfCurrStep);
			Init2NextStep();
		}

		public Tuple<int, Card> DoStep2()
		{
			cnt++;

			if (cnt <= PeopleCount) 
			{
				Card Card2Return = Players [(FPStep + cnt - 1) % PeopleCount].DoStep (CardsOfCurrStep, Step / StepInRoundCount, Step % StepInRoundCount, TrumpSuit);
				CardsOfCurrStep.Add (Card2Return);
				return new Tuple<int, Card> ((FPStep + cnt - 1) % PeopleCount, Card2Return);
			}
			else
			{
				cnt = 0;
				foreach (var card in CardsOfCurrStep)
					card.SetCardImageNull ();
				int WinPlayer = GetWinPlayer ();
				FPStep = WinPlayer;
				Players [WinPlayer].BribeCards.AddRange (CardsOfCurrStep);
				Players [WinPlayer].UpdateScore (Step / StepInRoundCount, Step % StepInRoundCount);
				Init2NextStep ();
				return new Tuple<int, Card> (WinPlayer, null);
			}
		}

		public void Init2NextStep()
		{
			Step++;
			CardsOfCurrStep.Clear();

			if (Step % StepInRoundCount == 0)
			{
				List<Card> Cards = new List<Card>();
				Cards = GetRandomCardsList();
				for (int i = 0; i < PeopleCount; i++)
				{
					Players[i].InitToNextRound(Cards.Where((x, j) => j % PeopleCount == i).ToList());
					Players [i].Cards = Players [i].Cards.OrderBy (x => x.Suit).ThenBy (x => x.Number).ToList ();
				}
			}
		}

		private void CreatePlayers()
		{
			Players = new List<Player>();
			List<Card> Cards = new List<Card>();

			Cards = GetRandomCardsList();

			for (int i = 0; i < PeopleCount; i++)
			{
				Players.Add(new Player(Cards.Where((x, j) => j % PeopleCount == i).ToList()));
				Players [i].Cards = Players [i].Cards.OrderBy (x => x.Suit).ThenBy (x => x.Number).ToList ();
			}

			if (Players [0].Cards.Where (x => x.Number == Number.Ace && x.Suit == Suit.Diamond).Count() > 0)
				FPStep = 0;
			else if (Players [1].Cards.Where (x => x.Number == Number.Ace && x.Suit == Suit.Diamond).Count() > 0)
				FPStep = 1;
			else if (Players [2].Cards.Where (x => x.Number == Number.Ace && x.Suit == Suit.Diamond).Count() > 0)
				FPStep = 2;
			else if (Players [3].Cards.Where (x => x.Number == Number.Ace && x.Suit == Suit.Diamond).Count() > 0)
				FPStep = 3;
			
			FPRound = FPStep;
		}

		private List<Card> GetRandomCardsList()
		{
			HashSet<Tuple<Suit, Number>> H = new HashSet<Tuple<Suit, Number>> ();
			Dictionary<int, Card> Cards = new Dictionary<int, Card>();
			Random rand = new Random();
			int j = 0;
			while (Cards.Count < CardsCount)
			{
				int CardSuit = rand.Next(4);
				int CardNumber = rand.Next(7, 15);

				if (!H.Contains(new Tuple<Suit, Number>((Suit)CardSuit, (Number)CardNumber)))
				{
					Cards.Add(j, new Card((Suit)CardSuit, (Number)CardNumber));
					H.Add (new Tuple<Suit, Number> ((Suit)CardSuit, (Number)CardNumber));
					j++;
				}
			}

			return Cards.Values.ToList();
		}

		private int GetWinPlayer()
		{
			int Round = Step / StepInRoundCount;
			Suit FSuit = CardsOfCurrStep [0].Suit;
			Dictionary<int, Card> CardsOfCurrStepHelp = new Dictionary<int, Card> ();
			for (int i = 0; i < PeopleCount; i++)
				CardsOfCurrStepHelp.Add ((FPStep + i) % PeopleCount, CardsOfCurrStep [i]);
			switch (Round) 
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				return CardsOfCurrStepHelp.Where (x => x.Value.Suit == FSuit).OrderByDescending (x => x.Value.Number).First ().Key;
			case 6:
			case 7:
			case 8:
			case 9:
				if (CardsOfCurrStepHelp.Where (x => x.Value.Suit == TrumpSuit).Count () > 0)
					return CardsOfCurrStepHelp.Where (x => x.Value.Suit == TrumpSuit).OrderByDescending (x => x.Value.Number).First ().Key;
				else
					return CardsOfCurrStepHelp.Where (x => x.Value.Suit == FSuit).OrderByDescending (x => x.Value.Number).First ().Key;
			default:
				return -1;
			}
		}
	}
}

