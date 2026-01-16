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
            int aceCount = 0; // count of aces in hand

            // First pass: calculate basic values
            foreach (var card in hand)
            {
                if (int.TryParse(card.Rank, out int numericValue))
                {
                    value += numericValue;
                }
                else if (card.Rank == "Jack" || card.Rank == "Queen" || card.Rank == "King")
                {
                    value += 10;
                }
                else if (card.Rank == "Ace")
                {
                    value += 11;
                    aceCount++;
                }
            }

            // Adjust for aces if value > 21
            while (value > 21 && aceCount > 0)
            {
                value -= 10; // Convert an Ace from 11 to 1
                aceCount--;
            }

            return value;
        }

        public void aceHit()
        {
            foreach (var card in hand)
            {
                if (card.Rank == "Ace")
                {
                    // reduce hand value by 10 to account for ace being 1 instead of 11
                    handValue -= 10;
                    return; // only adjust for one ace at a time
                }
            }
           
        }
    }
}
