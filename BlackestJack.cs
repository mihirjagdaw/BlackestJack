using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackestJack
{
    internal class BlackestJack
    {
        private List<String> suitList = new List<String>() { "Hearts", "Diamonds", "Clubs", "Spades" };

        private List<String> rankList = new List<String>()
            { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        public List<Card> CreateDeck()
        {
            List<Card> deck = new List<Card>();
            for (int i = 0; i < 8; i++)
            {
                foreach (string suit in suitList)
                {
                    foreach (string rank in rankList)
                    {
                        deck.Add(new Card(suit, rank));
                    }
                }
            }

            Shuffle(deck);
            return deck;
        }

        private void Shuffle(List<Card> deck)
        {
            Random rand = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        public Card dealCard(List<Card> deck, Person person)
        {
            Random rand = new Random();
            int index = rand.Next(deck.Count);
            Card dealtCard = deck[index];
            deck.RemoveAt(index);
            person.hand.Add(dealtCard);
            return dealtCard;
        }

        // Method to create type writer effect for displaying text
        public void TypeWriterEffect(string message, int delay = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }

            Console.WriteLine();
        }
    }
}
