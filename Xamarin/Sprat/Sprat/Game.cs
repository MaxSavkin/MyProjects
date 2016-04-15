using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Sprat
{
	public class Game : INotifyPropertyChanged
	{
		public const int PeopleCount = 4;
		public const int StepInRoundCount = 8;

		public List<Player> Players;
        public int Step;

		public List<Card> CardsOfCurrStep;
		public int FPStep;
		public int FPRound;
        private int round;
        public int Round
        {
            get { return round; }
            set
            {
                if (round != value)
                {
                    round = value;
                    OnPropertyChanged("Round");
                }
            }
        }
		public int cnt { get; private set;}
		public Suit TrumpSuit;
        public bool IsPaused = false;
        public List<Card> PossibleCards { get; private set; }

		public Game()
		{
			Step = 0;
			CardsOfCurrStep = new List<Card>();
			Init();
			TrumpSuit = 0;
			cnt = 0;
            Round = 1;
		}

		public Tuple<int, Card> DoStep2()
		{
			cnt++;

			if (cnt <= PeopleCount) 
			{
                Card Card2Return;
                Card2Return = Players [(FPStep + cnt - 1) % PeopleCount].DoStep (CardsOfCurrStep, Step / StepInRoundCount, Step % StepInRoundCount, (FPStep + cnt - 1) % PeopleCount, TrumpSuit);
				CardsOfCurrStep.Add (Card2Return);
				return new Tuple<int, Card> ((FPStep + cnt - 1) % PeopleCount, Card2Return);
			}

			int WinPlayer = GetWinPlayer ();
			FPStep = WinPlayer;
			Players [WinPlayer].UpdateScore (Step / StepInRoundCount, Step % StepInRoundCount, CardsOfCurrStep);
            return null;
		}

		public void Init2NextStep()
		{
			Step++;
			CardsOfCurrStep.Clear();
			cnt = 0;

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

		private void Init()
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
			while (Cards.Count < StepInRoundCount * PeopleCount)
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

        public void UpdatePossibleCards()
        {
            PossibleCards = Players[0].Cards;
            switch(round)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                     if (CardsOfCurrStep.Count > 0 && Players[0].Cards.Where(x => x.Suit == CardsOfCurrStep[0].Suit).Count() > 0)
                        PossibleCards = Players[0].Cards.Where(x => x.Suit == CardsOfCurrStep[0].Suit).ToList();
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                     if (CardsOfCurrStep.Count > 0 && Players[0].Cards.Where(x => x.Suit == CardsOfCurrStep[0].Suit).Count() > 0)
                        PossibleCards = Players[0].Cards.Where(x => x.Suit == CardsOfCurrStep[0].Suit).ToList();
                    else if (CardsOfCurrStep.Count > 0 && Players[0].Cards.Where(x => x.Suit == TrumpSuit).Count() > 0)
                        PossibleCards = Players[0].Cards.Where(x => x.Suit == TrumpSuit).ToList();
                    break;
                default:
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

