using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Game
{
    interface IGameStrategy
    {
        void Play(uint startMoney);
    }
}
