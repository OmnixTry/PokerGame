using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Game
{
    /// <summary>
    /// Interface for all Poker strategies
    /// </summary>
    interface IGameStrategy
    {
        /// <summary>
        /// Starts Game Algorythm
        /// </summary>
        /// <param name="startMoney">The money each of the players get in the beggining of the game</param>
        void Play(uint startMoney);

        /// <summary>
        /// Resets all the data about game stored in the strategy
        /// </summary>
        void ResetStrategy();
    }
}
