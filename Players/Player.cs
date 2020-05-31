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
        public List<Card> Hand { get; protected set; }
        public uint Cash { get; protected set; }
        protected Game.AbstractStrategy _abstractStrategy;

        public void HandOutCards(List<Card> hand)
        {
            Hand = hand;
        }

        public void SetStrategy(Game.AbstractStrategy newStrategy)
        {
            _abstractStrategy = newStrategy;
        }

        public uint MakeBet(uint bet)
        {
            if (Cash >= bet)
            {
                Cash -= bet;
            }
            else Cash = 0;
            return bet;
        }

        public void WinBank(uint bank)
        {
            Cash += bank;
        }

        public abstract Game.decision PerformAction();

    }
}
