using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Cards
{
    public enum SUIT
    {
        HEARTS,
        SPADES,
        DIAMONDS,
        CLUBS   
    }

    public enum VALUE
    {
        TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
        EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }

    /// <summary>
    /// Card for a poker game
    /// </summary>
    class Card
    {
        private readonly SUIT suit;
        private readonly VALUE value;

        public SUIT Suit { get { return suit; } }
        public VALUE Value { get { return value; } }

        public Card(SUIT st, VALUE val)
        {
            suit = st;
            value = val;
        }
    }
}
