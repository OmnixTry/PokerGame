using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Player
{
    class HumanPlayer : Player
    {
        private static HumanPlayer _instance;

        public static HumanPlayer GetInstance(uint startCash = 20)
        {
            if(_instance == null)
            {
                _instance = new HumanPlayer(startCash);
            }
            return _instance;
        }

        private HumanPlayer(uint startCash)
        {
            Cash = startCash;
        }

        public override Game.decision PerformAction()
        {
            Console.SetCursorPosition(0, Cards.DrawCards.FreeScreenSpace + 1);
            Console.WriteLine("0 - fold\n1 - Call\n2 - Raise");
            int decision;
            do
            {
                decision = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(0, Cards.DrawCards.FreeScreenSpace);
                switch (decision)
                {
                    case 0:
                        Console.Write("You did {0}", Game.decision.Fold.ToString());
                        return Game.decision.Fold;
                    case 1:
                        Console.Write("You did {0}", Game.decision.Call.ToString());
                        return Game.decision.Call;
                    case 2:
                        Console.Write("You did {0}", Game.decision.Raise.ToString());
                        return Game.decision.Raise;
                }
            } while (decision >= 0 && decision <= 2);
            return Game.decision.Fold;
        }

        public static void DisposePLayer()
        {
            _instance = null;
        }

        public override void PreflopAction()
        {
            _abstractStrategy.PlayerDecisionPreflop();
        }
        public override void FlopAction()
        {
            _abstractStrategy.PlayerDecisionFlop();
        }
        public override void TurnAction()
        {
            _abstractStrategy.PlayerDecisionTurn();
        }
        public override void RiverAction()
        {
            _abstractStrategy.PlayerDecisionRiver();
        }
    }
}
