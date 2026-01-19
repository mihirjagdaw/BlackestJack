using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BlackestJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain)
            {
                BlackestJack game = new BlackestJack();
                List<Card> deck = game.CreateDeck();
                Person player = new Person();
                Person dealer = new Person();

                // Deal initial cards
                Card playerCard1 = game.dealCard(deck, player);
                Card dealerCard1 = game.dealCard(deck, dealer);
                Card playerCard2 = game.dealCard(deck, player);
                Card dealerCard2 = game.dealCard(deck, dealer);

                Console.WriteLine($"Your cards: {playerCard1.Rank} of {playerCard1.Suit}, {playerCard2.Rank} of {playerCard2.Suit}");
                Console.WriteLine($"Your hand value: {player.calcHandValue()}");
                Console.WriteLine($"Dealer shows: {dealerCard1.Rank} of {dealerCard1.Suit}");

                // Check for immediate blackjack
                if (player.calcHandValue() == 21 || dealer.calcHandValue() == 21)
                {
                    Console.WriteLine($"Dealer's other card: {dealerCard2.Rank} of {dealerCard2.Suit}");
                    Console.WriteLine($"Dealer's hand value: {dealer.calcHandValue()}");

                    if (player.calcHandValue() == 21 && dealer.calcHandValue() == 21)
                    {
                        Console.WriteLine("Push! Both have BlackJack.");
                    }
                    else if (player.calcHandValue() == 21)
                    {
                        Console.WriteLine("BlackJack! You win!");
                    }
                    else
                    {
                        Console.WriteLine("Dealer has BlackJack! You lose.");
                    }

                    Console.ReadKey();
                    return;
                }

                // Player's turn
                string playerChoice = "";
                while (player.calcHandValue() < 21 && !playerChoice.Equals("stand"))
                {
                    Console.WriteLine("Would you like to 'hit' or 'stand'?");
                    playerChoice = Console.ReadLine().ToLower();

                    if (playerChoice.Equals("hit"))
                    {
                        Card dealtCard = game.dealCard(deck, player);
                        Console.WriteLine($"You get: {dealtCard.Rank} of {dealtCard.Suit}");
                        Console.WriteLine($"Your hand value: {player.calcHandValue()}");

                        if (player.calcHandValue() > 21)
                        {
                            Console.WriteLine("Bust! You lose.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }

                // Dealer's turn (only if player didn't bust)
                Console.WriteLine($"Dealer's other card: {dealerCard2.Rank} of {dealerCard2.Suit}");
                Console.WriteLine($"Dealer's total: {dealer.calcHandValue()}");

                while (dealer.calcHandValue() < 17)
                {
                    Card dealtCard = game.dealCard(deck, dealer);
                    Console.WriteLine($"Dealer gets: {dealtCard.Rank} of {dealtCard.Suit}");
                    Console.WriteLine($"Dealer's total: {dealer.calcHandValue()}");
                }

                // Determine winner
                int playerScore = player.calcHandValue();
                int dealerScore = dealer.calcHandValue();

                if (dealerScore > 21)
                {
                    Console.WriteLine("Dealer busts! You win!");
                }
                else if (playerScore > dealerScore)
                {
                    Console.WriteLine("You win!");
                }
                else if (playerScore == dealerScore)
                {
                    Console.WriteLine("Push!");
                }
                else
                {
                    Console.WriteLine("Dealer wins!");
                }

                // Ask to play again
                Console.WriteLine("Would you like to play again? (y/n)");
                playAgain = Console.ReadLine().ToLower() == "y"; // if statement to set playAgain based on user input
            }

        }
    }
}
