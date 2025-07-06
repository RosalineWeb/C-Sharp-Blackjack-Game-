using System;
using System.Collections.Generic;

namespace BlackjackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("♠️ Welcome to Blackjack! ♠️");

            var deck = new Deck();
            deck.Shuffle();

            var player = new Player("You");
            var dealer = new Player("Dealer");

            player.AddCard(deck.DrawCard());
            player.AddCard(deck.DrawCard());

            dealer.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());

            Console.WriteLine("\nYour hand:");
            player.ShowHand();

            bool playerTurn = true;
            while (playerTurn)
            {
                Console.Write("\nHit or Stand? (h/s): ");
                var input = Console.ReadLine()?.ToLower();

                if (input == "h")
                {
                    player.AddCard(deck.DrawCard());
                    Console.WriteLine("You drew:");
                    player.ShowLastCard();

                    if (player.GetScore() > 21)
                    {
                        Console.WriteLine("💥 You busted!");
                        playerTurn = false;
                    }
                }
                else if (input == "s")
                {
                    playerTurn = false;
                }
            }

            Console.WriteLine("\nDealer's hand:");
            dealer.ShowHand();
            while (dealer.GetScore() < 17)
            {
                dealer.AddCard(deck.DrawCard());
                Console.WriteLine("Dealer draws:");
                dealer.ShowLastCard();
            }

            Console.WriteLine($"\nYour Score: {player.GetScore()}");
            Console.WriteLine($"Dealer Score: {dealer.GetScore()}");

            if (player.GetScore() > 21)
                Console.WriteLine("❌ You lose!");
            else if (dealer.GetScore() > 21 || player.GetScore() > dealer.GetScore())
                Console.WriteLine("✅ You win!");
            else if (player.GetScore() == dealer.GetScore())
                Console.WriteLine("🤝 It's a tie!");
            else
                Console.WriteLine("❌ Dealer wins!");

            Console.WriteLine("\nThanks for playing!");
        }
    }
}
