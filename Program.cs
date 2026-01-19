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

                game.TypeWriterEffect($"Your cards: {playerCard1.Rank} of {playerCard1.Suit}, {playerCard2.Rank} of {playerCard2.Suit}");
                game.TypeWriterEffect($"Your hand value: {player.calcHandValue()}");
                game.TypeWriterEffect($"Dealer shows: {dealerCard1.Rank} of {dealerCard1.Suit}");

                // Check for immediate blackjack
                if (player.calcHandValue() == 21 || dealer.calcHandValue() == 21)
                {
                    game.TypeWriterEffect($"Dealer's other card: {dealerCard2.Rank} of {dealerCard2.Suit}");
                    game.TypeWriterEffect($"Dealer's hand value: {dealer.calcHandValue()}");

                    if (player.calcHandValue() == 21 && dealer.calcHandValue() == 21)
                    {
                        game.TypeWriterEffect("Push! Both have BlackJack.");
                    }
                    else if (player.calcHandValue() == 21)
                    {
                        game.TypeWriterEffect("BlackJack! You win!");
                    }
                    else
                    {
                        game.TypeWriterEffect("Dealer has BlackJack! You lose.");
                    }

                    Console.ReadKey();
                    return;
                }

                // Player's turn
                string playerChoice = "";
                while (player.calcHandValue() < 21 && !playerChoice.Equals("stand"))
                {
                    game.TypeWriterEffect("Would you like to 'hit' or 'stand'?");
                    playerChoice = Console.ReadLine().ToLower();

                    if (playerChoice.Equals("hit"))
                    {
                        Card dealtCard = game.dealCard(deck, player);
                            game.TypeWriterEffect($"You get: {dealtCard.Rank} of {dealtCard.Suit}");
                        game.TypeWriterEffect($"Your hand value: {player.calcHandValue()}");

                        if (player.calcHandValue() > 21)
                        {
                            game.TypeWriterEffect("Bust! You lose.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }

                // Dealer's turn (only if player didn't bust)
                game.TypeWriterEffect($"Dealer's other card: {dealerCard2.Rank} of {dealerCard2.Suit}");
                game.TypeWriterEffect($"Dealer's total: {dealer.calcHandValue()}");

                while (dealer.calcHandValue() < 17)
                {
                    Card dealtCard = game.dealCard(deck, dealer);
                    game.TypeWriterEffect($"Dealer gets: {dealtCard.Rank} of {dealtCard.Suit}");
                    game.TypeWriterEffect($"Dealer's total: {dealer.calcHandValue()}");
                }

                // Determine winner
                int playerScore = player.calcHandValue();
                int dealerScore = dealer.calcHandValue();

                if (dealerScore > 21)
                {
                    game.TypeWriterEffect("Dealer busts! You win!");
                }
                else if (playerScore > dealerScore)
                {
                    game.TypeWriterEffect("You win!");
                }
                else if (playerScore == dealerScore)
                {
                    game.TypeWriterEffect("Push!");
                }
                else
                {
                    game.TypeWriterEffect("Dealer wins!");
                }

                // Ask to play again
                game.TypeWriterEffect("Would you like to play again? (y/n)");
                playAgain = Console.ReadLine().ToLower() == "y"; // if statement to set playAgain based on user input
            }

        }
    }
}
