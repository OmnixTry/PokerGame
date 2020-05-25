using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Cards
{
    class Deck
    {
        private List<Card> cards;
        
        public Deck(List<Card> cds)
        {
            cards = cds;
        }
        
        public void ShuffleDeck()
        {
            Random rand = new Random();
            Card temp;

            //run the shuffle 1000 times
            for (int shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    //swap the cards
                    int secondCardIndex = rand.Next(13);
                    temp = cards[i];
                    cards[i] = cards[secondCardIndex];
                    cards[secondCardIndex] = temp;
                }
            }
        }

        public Card Pop()
        {
            Card toRemove = cards.First();
            cards.RemoveAt(0);
            return toRemove;
        }
    }
}
