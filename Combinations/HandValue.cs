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
        FourKind,
        StraightFlush,
        RoyalStraightFlush
    }

    /// <summary>
    /// Class used to evaluate the value of final cards at the end of the game
    /// </summary>
    class HandValue
    {
        // the result of evaluating hand
        public COMBINATION Combination { get; private set; }
        public int Total { get; private set; }
        public int HighCard { get; private set; }
        private List<Card> _vinningCombination;

        private List<Card> Cards { get; set; }
        public List<Card> VinningCombination
        {
            get
            {
                return _vinningCombination;
            }
            private set
            {
                _vinningCombination = value;
                // Calculate sum of combination and highest card
                Total = _vinningCombination.Sum(c => (int)c.Value);
                HighCard = (int)Cards.Except(_vinningCombination).OrderByDescending(c => c.Value).First().Value;
            }
        }

             

        /// <summary>
        /// Saves the result of checking combination
        /// </summary>
        /// <param name="cards">All the cards from hand and table</param>
        /// <param name="vinningCombination">The cards that form the combination</param>
        /// <param name="combination">The type of combination formed in this handValue</param>
        public HandValue(List<Card> cards, List<Card> vinningCombination, COMBINATION combination)
        {
            Cards = cards;
            VinningCombination = vinningCombination;
            Combination = combination;
        }

        public static bool operator >(HandValue handValue1, HandValue handValue2)
        {
            if (handValue1.Combination > handValue2.Combination)
                return true;
            else if (handValue1.Combination == handValue2.Combination)
            {
                if (handValue1.Total > handValue2.Total)
                    return true;
                else if (handValue1.Total == handValue2.Total)
                {
                    return handValue1.HighCard > handValue2.HighCard;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        public static bool operator <(HandValue handValue1, HandValue handValue2)
        {
            if (handValue1.Combination > handValue2.Combination)
                return false;
            else if (handValue1.Combination == handValue2.Combination)
            {
                if (handValue1.Total > handValue2.Total)
                    return false;
                else if (handValue1.Total == handValue2.Total)
                {
                    return handValue1.HighCard < handValue2.HighCard;
                }
                else
                {
                    return true;
                }
            }
            else
                return true;
        }
    }
}
