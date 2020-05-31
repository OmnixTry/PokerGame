using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Game
{
    class Game
    {
        private IGameStrategy _strategy;

        public Game(IGameStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IGameStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PlayGame(uint startMoney)
        {
            _strategy.Play(startMoney);
        }

        public void ResetGame()
        {
            _strategy.ResetGame();
        }
    }
}
