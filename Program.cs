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
            Card playerCard1 = game.dealCard(deck, player);
            Card playerCard2 = game.dealCard(deck, player);
            Console.WriteLine($"Dealt card: {playerCard1.Rank} of {playerCard1.Suit}");
            Console.WriteLine($"Dealt card: {playerCard2.Rank} of {playerCard2.Suit}");
            Console.WriteLine($"Player's hand value: {player.calcHandValue()}");

            Person dealer = new Person();
            Card dealerCard1 = game.dealCard(deck, dealer);
            Card dealerCard2 = game.dealCard(deck, dealer);

            Console.WriteLine($"Dealer's card: {dealerCard1.Rank} of {dealerCard1.Suit}");

            string playerChoice = "";

            while (player.calcHandValue() < 21)
            {
                Console.WriteLine("Would you like to 'hit' or 'stand'?");
                playerChoice = Console.ReadLine().ToLower();

                if (playerChoice.Equals("hit"))
                {
                    Card dealtCard = game.dealCard(deck, player);
                    Console.WriteLine($"Dealt card: {dealtCard.Rank} of {dealtCard.Suit}");
                    Console.WriteLine($"Player's hand value: {player.calcHandValue()}");
                }
                else
                {
                    
                }
            }
            


        }
    }
}
