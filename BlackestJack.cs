using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        //public void TypeWriterEffect(string message, int delay = 50)
        //{
            //foreach (char c in message)
            //{
                //Console.Write(c);
                //Thread.Sleep(delay);
            //}

            //Console.WriteLine();
        //}


        public void TypeWriterEffect(string message, int delay = 50)
        {
            // Parse markup and typewrite with colors
            var segments = ParseMarkupSegments(message);

            foreach (var segment in segments)
            {
                foreach (char c in segment.Text)
                {
                    // Use Markup to render with proper styling
                    var markup = segment.Color == "default"
                        ? Markup.Escape(c.ToString())
                        : $"[{segment.Color}]{Markup.Escape(c.ToString())}[/]";

                    AnsiConsole.Markup(markup);
                    Thread.Sleep(delay);
                }
            }

            Console.WriteLine();
        }

        private List<MarkupSegment> ParseMarkupSegments(string input)
        {
            var segments = new List<MarkupSegment>();
            var regex = new System.Text.RegularExpressions.Regex(@"\[(\w+)\](.*?)\[/\]");

            int lastIndex = 0;
            foreach (System.Text.RegularExpressions.Match match in regex.Matches(input))
            {
                // Add plain text before the markup
                if (match.Index > lastIndex)
                {
                    segments.Add(new MarkupSegment
                    {
                        Text = input.Substring(lastIndex, match.Index - lastIndex),
                        Color = "default"
                    });
                }

                // Add the colored segment
                segments.Add(new MarkupSegment
                {
                    Text = match.Groups[2].Value,
                    Color = match.Groups[1].Value
                });

                lastIndex = match.Index + match.Length;
            }

            // Add remaining text
            if (lastIndex < input.Length)
            {
                segments.Add(new MarkupSegment
                {
                    Text = input.Substring(lastIndex),
                    Color = "default"
                });
            }

            return segments;
        }

        private class MarkupSegment
        {
            public string Text { get; set; }
            public string Color { get; set; }
        }
    }
}
