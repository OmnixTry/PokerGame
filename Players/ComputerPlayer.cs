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

        /// <summary>
        /// TODO
        /// </summary>
        public override void PerformAction()
        {

        }
    }    
}
