using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackestJack
{
    internal class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
