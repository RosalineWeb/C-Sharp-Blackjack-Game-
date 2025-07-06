using System;
using System.Collections.Generic;

namespace BlackjackGame
{
    public class Player
    {
        public string Name { get; }
        private List<Card> hand = new();

        public Player(string name)
        {
            Name = name;
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public int GetScore()
        {
            int total = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                total += card.Value;
                if (card.Rank == "A") aceCount++;
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }

        public void ShowHand()
        {
            foreach (var card in hand)
            {
                Console.WriteLine("- " + card);
            }
        }

        public void ShowLastCard()
        {
            Console.WriteLine("- " + hand[^1]);
        }
    }
}
