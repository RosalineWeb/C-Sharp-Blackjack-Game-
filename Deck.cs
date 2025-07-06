using System;
using System.Collections.Generic;

namespace BlackjackGame
{
    public class Deck
    {
        private List<Card> cards = new();
        private Random random = new();

        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Dictionary<string, int> values = new()
            {
                { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 },
                { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 },
                { "J", 10 }, { "Q", 10 }, { "K", 10 }, { "A", 11 }
            };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(suit, rank, values[rank]));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }

        public Card DrawCard()
        {
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
