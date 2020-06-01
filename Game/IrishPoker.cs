using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Game
{
    class IrishPoker : AbstractStrategy
    {
        protected override void GiveStartCards()
        {
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            for(int i =0; i < 4; i++)
            {
                cards1.Add(_deck.Pop());
                cards2.Add(_deck.Pop());
            }

            _player1.HandOutCards(cards1);
            _player2.HandOutCards(cards2);
        }

        protected override bool Flop()
        {
            _table.Add(_deck.Pop());
            _table.Add(_deck.Pop());
            _table.Add(_deck.Pop());
            DrawCards.DisplayCards(_table, 2);
            _player1.FlopAction();
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

            _player2.FlopAction();
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

        public override void PCDecisionFlop()
        {
            Combinations.HandValue handValue = new Combinations.HandValue(_player2.Hand.Union(_table).ToList());
            _firstChecker.CheckCombination(handValue);

            var toDiscard = _player2.Hand.Except(handValue.VinningCombination);

            if (toDiscard.Count() >= 3)
            {
                do
                {
                    toDiscard = toDiscard.Except(toDiscard.OrderByDescending(c => c.Value).Take(1));
                } while (toDiscard.Count() != 2);
            }

            if (toDiscard.Count() <= 1)
            {
                do
                {
                    toDiscard = toDiscard.Union(_player2.Hand.Except(toDiscard).OrderBy(c => c.Value).Take(1));
                } while (toDiscard.Count() != 2);
            }

            _player2.Discard(toDiscard.ToList());
        }

        public override void PlayerDecisionFlop()
        {
            do
            {
                Console.SetCursorPosition(0, DrawCards.DiscardingSpace);
                Console.WriteLine("What card to discard?");
                int toDiscard = int.Parse(Console.ReadLine());
                if(toDiscard <= _player1.Hand.Count && toDiscard >= 1)
                {
                    _player1.Hand.Remove(_player1.Hand.Take(toDiscard).Last());
                }
                //
                // 11
                Console.SetCursorPosition(0, 1);
                for (int i = 0; i < 12; i++)
                {
                    for(int j = 0; j < 50; j++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
                DrawCards.DisplayCards(_player1.Hand, 1);
            } while (_player1.Hand.Count != 2);

            Console.SetCursorPosition(0, DrawCards.DiscardingSpace);
            Console.WriteLine("                         \n              \n");
        }
    }
}
