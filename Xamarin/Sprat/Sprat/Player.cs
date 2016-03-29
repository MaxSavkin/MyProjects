using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprat
{
	public class Player
	{
		public List<Card> Cards;
		public int Score { get; set; }
		private Random rand;

		public Player(List<Card> Cards)
		{
			this.Cards = Cards;
			Score = 0;
			rand = new Random ();
		}

		public void InitToNextRound(List<Card> cards)
		{
			this.Cards = cards;
		}

		public Card DoStep(List<Card> CardsList, int Round, int Step, Suit trumpSuit = Suit.Diamond)
		{
			Card FirstCard = null;
			if (CardsList != null && CardsList.Count > 0) 
			{
				FirstCard = CardsList.Where (x => x.Suit == CardsList [0].Suit).OrderByDescending (x => x.Number).First ();
			}
			Card CardToReturn = null;

			switch (Round) {

			case 0:
				if (FirstCard == null) 
				{
					if (Cards.Where (x => x.Number < Number.Jack).Count() > 0) 
					{
						var cardList = Cards.Where (x => x.Number < Number.Jack).ToList ();
						var id = rand.Next (cardList.Count);
						CardToReturn = cardList [id];
						Cards.Remove (cardList [id]);
					} 
					else 
					{
						var id = rand.Next (Cards.Count);
						CardToReturn = Cards [id];
						Cards.RemoveAt (id);
					}
				} 
				else 
				{
					if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
					{
						if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
						else
						{
							var cardList = Cards.Where (x => x.Suit == FirstCard.Suit).ToList ();
							var id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						}
					} 
					else 
					{
						var card = Cards.OrderByDescending (x => x.Number).First ();
						CardToReturn = card;
						Cards.Remove (card);
					}
				}
				break;

			case 1:
				if (FirstCard == null) 
				{
					if (Cards.Where (x => x.Number < Number.Jack).Count() > 0) 
					{
						var cardList = Cards.Where (x => x.Number < Number.Jack).ToList ();
						var id = rand.Next (cardList.Count);
						CardToReturn = cardList [id];
						Cards.Remove (cardList [id]);
					} 
					else 
					{
						var id = rand.Next (Cards.Count);
						CardToReturn = Cards [id];
						Cards.RemoveAt (id);
					}
				} 
				else 
				{
					if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
					{
						if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
						else
						{
							var cardList = Cards.Where (x => x.Suit == FirstCard.Suit).ToList ();
							var id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						}
					} 
					else 
					{
						Card card = null;
						if (Cards.Where(x => x.Suit == Suit.Heart).Count() > 0)
							card = Cards.Where(x => x.Suit == Suit.Heart).OrderByDescending (x => x.Number).First ();
						else
							card = Cards.OrderByDescending (x => x.Number).First ();

						CardToReturn = card;
						Cards.Remove (card);
					}
				}
				break;

			case 2:
				if (FirstCard == null) 
				{
					if (Cards.Where (x => x.Number < Number.Jack).Count() > 0) 
					{
						var cardList = Cards.Where (x => x.Number < Number.Jack).ToList ();
						var id = rand.Next (cardList.Count);
						CardToReturn = cardList [id];
						Cards.Remove (cardList [id]);
					} 
					else 
					{
						var id = rand.Next (Cards.Count);
						CardToReturn = Cards [id];
						Cards.RemoveAt (id);
					}
				} 
				else 
				{
					if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
					{
						if (Cards.Where (x => x.Suit == FirstCard.Suit && (x.Number == Number.Jack || x.Number == Number.King) && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && (x.Number == Number.Jack || x.Number == Number.King) && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
						else if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						} 
						else
						{
							var cardList = Cards.Where (x => x.Suit == FirstCard.Suit).ToList ();
							var id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						}
					} 
					else 
					{
						Card card = null;
						if (Cards.Where(x => x.Number == Number.Jack || x.Number == Number.King).Count() > 0)
							card = Cards.Where(x => x.Number == Number.Jack || x.Number == Number.King).OrderByDescending (x => x.Number).First ();
						else
							card = Cards.OrderByDescending (x => x.Number).First ();

						CardToReturn = card;
						Cards.Remove (card);
					}
				}
				break;

			case 3:
				if (FirstCard == null) 
				{
					if (Cards.Where (x => x.Number < Number.Jack).Count() > 0) 
					{
						var cardList = Cards.Where (x => x.Number < Number.Jack).ToList ();
						var id = rand.Next (cardList.Count);
						CardToReturn = cardList [id];
						Cards.Remove (cardList [id]);
					} 
					else 
					{
						var id = rand.Next (Cards.Count);
						CardToReturn = Cards [id];
						Cards.RemoveAt (id);
					}
				} 
				else 
				{
					if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
					{
						if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number == Number.Queen && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number == Number.Queen && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
						else if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						} 
						else
						{
							var cardList = Cards.Where (x => x.Suit == FirstCard.Suit).ToList ();
							var id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						}
					} 
					else 
					{
						Card card = null;
						if (Cards.Where(x => x.Number == Number.Queen).Count() > 0)
							card = Cards.Where(x => x.Number == Number.Queen).OrderByDescending (x => x.Number).First ();
						else
							card = Cards.OrderByDescending (x => x.Number).First ();

						CardToReturn = card;
						Cards.Remove (card);
					}
				}
				break;

			case 4:
				if (Step < 4) {
					if (FirstCard == null) {
						Card card = Cards.OrderByDescending (x => x.Number).First ();
						CardToReturn = card;
						Cards.Remove (card);
					} else {
						if (Cards.Where (x => x.Suit == FirstCard.Suit).Count () > 0) {
							Card card = Cards.Where (x => x.Suit == FirstCard.Suit).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						} else {
							var card = Cards.OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
					}
				} else {
					if (FirstCard == null) 
					{
						if (Cards.Where (x => x.Number < Number.Jack).Count() > 0) 
						{
							var cardList = Cards.Where (x => x.Number < Number.Jack).ToList ();
							var id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						} 
						else 
						{
							var card = Cards.OrderBy (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
					} 
					else 
					{
						if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
						{
							if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).Count() > 0)
							{
								var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
								CardToReturn = card;
								Cards.Remove (card);
							}
							else
							{
								var cardList = Cards.Where (x => x.Suit == FirstCard.Suit).ToList ();
								var id = rand.Next (cardList.Count);
								CardToReturn = cardList [id];
								Cards.Remove (cardList [id]);
							}
						} 
						else 
						{
							var card = Cards.OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
					}
				}
				break;

			case 5:
				if (FirstCard == null) 
				{
					var cardList = Cards.Where (x => x.Number != Number.King && x.Suit != Suit.Heart).ToList ();
					if (cardList.Count > 0) {
						var id = rand.Next (cardList.Count);
						CardToReturn = cardList [id];
						Cards.Remove (cardList [id]);
					} else {
						CardToReturn = Cards [0];
						Cards.Remove (Cards [0]);
					}
				} 
				else 
				{
					if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
					{
						if (Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == FirstCard.Suit && x.Number < FirstCard.Number).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
						else if (Cards.Where (x => x.Suit == Suit.Heart && x.Number == Number.King && x.Number == Number.Ace).Count() > 0)
						{
							var card = Cards.Where (x => x.Suit == Suit.Heart && x.Number == Number.King && x.Number == Number.Ace).OrderByDescending (x => x.Number).First ();
							CardToReturn = card;
							Cards.Remove (card);
						}
						else
						{
							var cardList = Cards.Where (x => x.Suit == FirstCard.Suit).ToList ();
							var id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						}
					} 
					else 
					{
						Card card = null;
						if (Cards.Where (x => x.Number == Number.King && x.Suit == Suit.Heart).Count () > 0)
							card = Cards.Where (x => x.Number == Number.King && x.Suit == Suit.Heart).First ();
						else
							card = Cards.OrderByDescending (x => x.Number).First ();
						
						CardToReturn = card;
						Cards.Remove (card);
					}
				}
				break;
			case 6:
			case 7:
			case 8:
			case 9:
				if (FirstCard == null) 
				{
					if (Cards.Where (x => x.Number  == Number.Ace && x.Suit == trumpSuit).Count() > 0) 
					{
						var card = Cards.Where (x => x.Number == Number.Ace && x.Suit == trumpSuit).First ();
						CardToReturn = card;
						Cards.Remove (card);
					} 
					else if (Cards.Where (x => x.Number == Number.Ace).Count() > 0) 
					{
						var cardList = Cards.Where (x => x.Number == Number.Ace).ToList ();
						var id = rand.Next (cardList.Count);
						CardToReturn = cardList [id];
						Cards.Remove (cardList [id]);
					}
					else
					{
						var cardList = Cards.Where (x => x.Suit != trumpSuit).ToList ();
						int id = 0;
						if (cardList.Count > 1) {
							id = rand.Next (cardList.Count);
							CardToReturn = cardList [id];
							Cards.Remove (cardList [id]);
						} else {						
							CardToReturn = Cards [id];
							Cards.Remove (Cards [id]);
						}
					}

				} 
				else 
				{
					if (Cards.Where (x => x.Suit == FirstCard.Suit).Count() > 0) 
					{
						var card = Cards.Where (x => x.Suit == FirstCard.Suit).OrderByDescending (x => x.Number).First ();
						CardToReturn = card;
						Cards.Remove (card);
					} 
					else if (Cards.Where (x => x.Suit == trumpSuit).Count() > 0) 
					{
						var card = Cards.Where (x => x.Suit == trumpSuit).OrderByDescending (x => x.Number).First ();
						CardToReturn = card;
						Cards.Remove (card);
					}
					else 
					{
						var card = Cards.OrderBy (x => x.Number).First ();
						CardToReturn = card;
						Cards.Remove (card);
					}
				}
				break;

			default:
				break;
			}

			return CardToReturn;
		}

		public void UpdateScore(int Round, int Step, List<Card> CurrCards)
		{
			switch(Round)
			{
			case 0:
				Score += 2 * CurrCards.Count / 4;
				break;
			case 1:
				Score += 2 * CurrCards.Where(x => x.Suit == Suit.Heart).Count();
				break;
			case 2:
				Score += 2 * CurrCards.Where(x => x.Number == Number.Jack || x.Number == Number.King).Count();
				break;
			case 3:
				Score += 4 * CurrCards.Where(x => x.Number == Number.Queen).Count();
				break;
			case 4:
				if (Step == 6 || Step == 7)
					Score += 8;
				break;
			case 5:
				Score += 16 * CurrCards.Where(x => x.Number == Number.King && x.Suit == Suit.Heart).Count();
				break;
			case 6:
			case 7:
			case 8:
			case 9:
				Score -= 3 ;
				break;
			default:
				break;
			}
		}
	}
}

