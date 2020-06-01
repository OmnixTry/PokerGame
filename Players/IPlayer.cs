using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Player
{
    interface IPlayer
    {
        void HandOutCards(List<Card> hand);
        uint MakeBet(uint bet);
        Game.decision PerformAction();

        void PreflopAction();
        void FlopAction();
        void TurnAction();
        void RiverAction();
    }
}
