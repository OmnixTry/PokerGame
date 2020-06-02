using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Cards
{
    /// <summary>
    /// Represents deck in the poker game
    /// </summary>
    class Deck
    {
        // the cards of the deck
        private List<Card> _cards;
        
        public Deck(List<Card> cards)
        {
            _cards = cards;
        }
        
        /// <summary>
        /// Creates brand new deck and shuffles it
        /// </summary>
        public Deck()
        {
            _cards = new List<Card>();
            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                    _cards.Add(new Card(s, v));

            this.Shuffle();
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            Card temp;

            //run the shuffle 1000 times
            for (int shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (int i = 0; i < _cards.Count; i++)
                {
                    //swap the cards
                    int secondCardIndex = rand.Next(_cards.Count());
                    temp = _cards[i];
                    _cards[i] = _cards[secondCardIndex];
                    _cards[secondCardIndex] = temp;
                }
            }
        }

        /// <summary>
        /// Draw a top card of the deck
        /// </summary>
        /// <returns></returns>
        public Card Pop()
        {
            Card toRemove = _cards.First();
            _cards.RemoveAt(0);
            return toRemove;
        }
    }
}
