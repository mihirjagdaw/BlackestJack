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
            Card dealtCard = game.dealCard(deck, player);
            Console.WriteLine($"Dealt card: {dealtCard.Rank} of {dealtCard.Suit}");
        }
    }
}
