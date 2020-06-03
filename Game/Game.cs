using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Player;
using MainGameProject.Cards;

namespace MainGameProject.Game
{
    /// <summary>
    /// The facade class for poker game which contains the logyc of playing the game
    /// </summary>
    class Game
    {
        private IGameStrategy _strategy;

        public Game() { }

        /// <summary>
        /// Constructor that sets the strategy of the game
        /// </summary>
        /// <param name="strategy">a chosen strategy for poker.</param>
        private void SetStrategy(IGameStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Runs the algorythm of playing poker game and changing rules.
        /// </summary>
        public void PlayGame()
        {
            PrepareConsole();
            do
            {
                SetStrategy(GameSelection());
                Console.WriteLine("Set starter Money");
                uint startMoney = uint.Parse(Console.ReadLine());
                do
                {
                    Console.Clear();
                    _strategy.Play(startMoney);
                    Console.SetCursorPosition(0, DrawCards.EndMenuSpace);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Try Again? Y/N");
                } while (Console.ReadLine().ToUpper() == "Y");
                ResetGame();
                Console.WriteLine("New game?Y/N");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        /// <summary>
        /// Sets up the console for gameplay
        /// </summary>
        private void PrepareConsole()
        {
            Console.SetWindowSize(90, 51);

            // remove scroll bars by setting the buffer to the actual window size
            Console.BufferWidth = 90;
            Console.BufferHeight = 51;
            Console.Title = "Poker Game";
            // Setting Print properties
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.GetEncoding(65001);

            Console.Clear();
        }

        /// <summary>
        /// Inicializes onscreen menu for choosing the next game strategy.
        /// </summary>
        /// <returns></returns>
        private IGameStrategy GameSelection()
        {
            Console.WriteLine("What type of Poker Do You Want to play?\n" +
                "0 - Texas Holdem\n" +
                "1 - Irish Poker");
            int dec;
            do
            {
                dec = int.Parse(Console.ReadLine());
                switch (dec)
                {
                    case 0:
                        Console.Clear();
                        return new TexasHoldemPoker();
                    case 1:
                        Console.Clear();
                        return new IrishPoker();
                }
            } while (dec > 1 || dec < 0);
            return null;
        }

        /// <summary>
        /// Resets the game to prepare it for new game.
        /// </summary>
        private void ResetGame()
        {
            _strategy.ResetStrategy();
            ComputerPlayer.DisposePLayer();
            HumanPlayer.DisposePLayer();
            Console.Clear();
        }
    }
}
