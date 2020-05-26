using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Player
{
    abstract class Player : IPlayer
    {
        protected List<Card> _hand;
        public uint Cash { get; protected set; }

        public void HandOutCards(List<Card> hand)
        {
            _hand = hand;
        }

        public uint MakeBet(uint bet)
        {
            Cash -= bet;
            return bet;
        }

        public abstract void PerformAction();
    }
}
