using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Player
{
    class ComputerPlayer : Player
    {
        private static ComputerPlayer _instance;

        public static ComputerPlayer GetInstance(uint startCash = 20)
        {
            if (_instance == null)
            {
                _instance = new ComputerPlayer(startCash);
            }
            return _instance;
        }

        private ComputerPlayer(uint startCash)
        {
            Cash = startCash;
        }

        public override Game.decision PerformAction()
        {
            Game.decision decision = _abstractStrategy.PCDecisions();
            Console.SetCursorPosition(0, Cards.DrawCards.FreeScreenSpace);
            Console.Write("Computer did {0}", decision.ToString());
            return decision;
        }

        public static void DisposePLayer()
        {
            _instance = null;
        }
    }    
}
