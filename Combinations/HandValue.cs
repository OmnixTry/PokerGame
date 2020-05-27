using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    public enum COMBINATION
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind
    }

    /// <summary>
    /// Class used to evaluate the value of final cards at the end of the game
    /// </summary>
    class HandValue
    {
        // the result of evaluating hand
        public COMBINATION Combination { get; set; }
        public int Total { get; set; }
        public int HighCard { get; set; }

        public int HeartsSum { get; private set; }
        public int DiamondSum { get; private set; }
        public int ClubSum { get; private set; }
        public int SpadesSum { get; private set; }
        public List<Card> Cards { get; private set; }

        /// <summary>
        /// Calculates number of each suit in the final hand 
        /// </summary>
        private void GetNumberOfSuit()
        {
            foreach (Card card in Cards)
            {
                if (card.Suit == SUIT.HEARTS)
                    HeartsSum++;
                else if (card.Suit == SUIT.DIAMONDS)
                    DiamondSum++;
                else if (card.Suit == SUIT.CLUBS)
                    ClubSum++;
                else if (card.Suit == SUIT.SPADES)
                    SpadesSum++;
            }
        }

        /// <summary>
        /// Sets up the cards and prepares class for usage in evaluation rules
        /// </summary>
        /// <param name="cards">The cards to put in the class for further evaluation</param>
        public HandValue(List<Card> cards)
        {
            Cards = cards;
            GetNumberOfSuit();
            SortCards();
        }

        /// <summary>
        /// Sorts cards in the deck to make defining combinations esier
        /// </summary>
        private void SortCards()
        {
            // sorting using Linq
            var sorting = from c in Cards
                          orderby c.Value
                          select c;

            // setting sorted elements to a place
            int index = 0;
            foreach (Card c in sorting)
            {
                Cards[index] = c;
                index++;
            }
        }
    }
}
