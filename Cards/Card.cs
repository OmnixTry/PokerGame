using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Cards
{
    /// <summary>
    /// Card Suits
    /// </summary>
    public enum SUIT
    {
        HEARTS,
        SPADES,
        DIAMONDS,
        CLUBS   
    }

    /// <summary>
    /// Card Values
    /// </summary>
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

        /// <summary>
        /// The suit of the card
        /// </summary>
        public SUIT Suit { get { return suit; } }
        /// <summary>
        /// The Value of the card
        /// </summary>
        public VALUE Value { get { return value; } }

        /// <summary>
        /// Constructor that sets the suit and value properties of a card
        /// </summary>
        /// <param name="st">Suit of a card</param>
        /// <param name="val">Value of a card</param>
        public Card(SUIT st, VALUE val)
        {
            suit = st;
            value = val;
        }
    }
}
