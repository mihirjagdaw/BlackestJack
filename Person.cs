using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackestJack
{
    internal class Person
    {
        public List<Card> hand;
        private int handValue;

        public Person()
        {
            hand = new List<Card>();
            handValue = 0;
        }

        public int calcHandValue()
        {
            int value = 0;
            foreach (var card in hand)
            {
                if (int.TryParse(card.Rank, out value))
                {
                    value += int.Parse(card.Rank);
                }
                else
                {
                    if (card.Rank == "Jack" || card.Rank == "Queen" || card.Rank == "King")
                    {
                        value += 10;
                    }
                    else if (card.Rank == "Ace")
                    {
                        Console.WriteLine("Yoh, I haven't thought about this one");
                    }
                }
            }
            return value;
        }
    }
}
