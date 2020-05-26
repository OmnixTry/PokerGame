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

        public override void PerformAction()
        {
            
        }
    }
}
