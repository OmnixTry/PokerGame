using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Game
{
    class TexasHoldemPoker : AbstractStrategy
    {
        protected override bool Flop()
        {
            _table.Add(_deck.Pop());
            _table.Add(_deck.Pop());
            _table.Add(_deck.Pop());
            DrawCards.DisplayCards(_table, 2);
            decision player1Decision = _player1.PerformAction();
            switch (player1Decision)
            {
                case decision.Fold:
                    Console.WriteLine("Player 2 wins!\n\n\n\n");
                    _player2.WinBank(_bank);

                    return false;
                case decision.Call:
                    _player1.MakeBet(_biggestBet);
                    _bank += _biggestBet;
                    break;
                case decision.Raise:
                    _biggestBet += _smallBlind;
                    _player1.MakeBet(_biggestBet);
                    _bank += _biggestBet;
                    break;
                default:
                    break;
            }

            
            decision player2Decision = _player2.PerformAction();
            switch (player2Decision)
            {
                case decision.Fold:
                    Console.WriteLine("Player 1 wins!\n\n\n\n");
                    _player1.WinBank(_bank);
                    _bank = 0;
                    return false;
                case decision.Call:
                    _player2.MakeBet(_biggestBet);
                    _bank += _biggestBet;
                    break;
                case decision.Raise:
                    _biggestBet += _smallBlind;
                    _player2.MakeBet(_biggestBet);
                    _bank += _biggestBet;
                    break;
                default:
                    break;
            }
            Console.WriteLine(" Biggest Bet:{0}        ", _biggestBet);
            return true;
        }
    }
}
