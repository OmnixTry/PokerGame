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

    class HandValue
    {
        public COMBINATION Combination { get; set; }
        public int Total { get; set; }
        public int HighCard { get; set; }

        public int HeartsSum { get; private set; }
        public int DiamondSum { get; private set; }
        public int ClubSum { get; private set; }
        public int SpadesSum { get; private set; }
        public List<Card> Cards { get; private set; }

        private void getNumberOfSuit()
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

        public HandValue(List<Card> cards)
        {
            Cards = cards;
            getNumberOfSuit();
        }
    }
}
