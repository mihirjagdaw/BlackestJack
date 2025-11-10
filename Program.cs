using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackestJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlackestJack game = new BlackestJack();
            List<Card> deck = game.CreateDeck();
            Person player = new Person();
            Person dealer = new Person();

            // correct order of initial dealing
            Card playerCard1 = game.dealCard(deck, player);
            Card dealerCard1 = game.dealCard(deck, dealer);
            Card playerCard2 = game.dealCard(deck, player);
            Card dealerCard2 = game.dealCard(deck, dealer);

            Console.WriteLine($"Dealt card: {playerCard1.Rank} of {playerCard1.Suit}");
            Console.WriteLine($"Dealt card: {playerCard2.Rank} of {playerCard2.Suit}");

            Console.WriteLine($"Player's hand value: {player.calcHandValue()}");

            Console.WriteLine($"Dealer's card: {dealerCard1.Rank} of {dealerCard1.Suit}");

            // check for blackjack
            if (player.calcHandValue() == 21 && dealer.calcHandValue() < 21)
            {
                Console.WriteLine("Congrats, you got BlackJack!");
            }
            // then check if dealer has blackjack for push
            else if (player.calcHandValue() == 21 && dealer.calcHandValue() == 21)
            {
                Console.WriteLine("Push, dealer has BlackJack too :(");
            }
            // if no blackjack, continue game
            else
            {
                string playerChoice = "";

                while (player.calcHandValue() < 21 && !playerChoice.Equals("stand"))
                {
                    Console.WriteLine("Would you like to 'hit' or 'stand'?");
                    playerChoice = Console.ReadLine().ToLower();

                    if (playerChoice.Equals("hit"))
                    {
                        Card dealtCard = game.dealCard(deck, player);
                        Console.WriteLine($"Dealt card: {dealtCard.Rank} of {dealtCard.Suit}");
                        Console.WriteLine($"Player's hand value: {player.calcHandValue()}");
                        if (player.calcHandValue() > 21)
                        {
                            Console.WriteLine("Bussssssssssst, you lose.");
                        }
                    }
                    else
                    {
                        int dealerHandValue = dealer.calcHandValue();
                        Console.WriteLine($"Dealer shows a {dealerCard2.Rank} of {dealerCard2.Suit}");

                        if (dealerHandValue < 17)
                        {
                            while (dealerHandValue < 17)
                            {
                                Card dealersCards = game.dealCard(deck, dealer);
                                dealerHandValue = dealer.calcHandValue();
                                Console.WriteLine($"Dealer gets {dealersCards.Rank} of {dealersCards.Suit}, totaling to {dealerHandValue}");
                            }
                        }

                        if (player.calcHandValue() > dealerHandValue)
                        {
                            Console.WriteLine("You win!");
                        }
                        else
                        if (player.calcHandValue() == dealerHandValue)
                        {
                            Console.WriteLine("Push.");
                        }
                        else
                        {
                            Console.WriteLine("Dealer wins");
                        }
                    }
                }
            }

        }
    }
}


// add logic to support blackjack