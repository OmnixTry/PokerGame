﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;
using MainGameProject.Player;
using MainGameProject.Combinations;


namespace MainGameProject.Game
{
    public enum decision
    {
        Fold,
        Call,
        Raise
    }

    abstract class AbstractStrategy : IGameStrategy
    {
        protected Player.Player _player1;
        protected Player.Player _player2;

        protected Deck _deck;
        protected List<Card> _table;

        protected uint _smallBlind;
        protected uint _biggestBet = 1;
        protected uint _bank = 0;

        protected ICombinationChecker _firstChecker;
        /// <summary>
        /// Method that iniciates the game process
        /// </summary>
        public void Play(uint startMoney)
        {
            // game preparations
            
            InicializeDeck();
            InicializePlayers(startMoney);
            if (!CanTheyProcceed()) return;
            SetupCheckers();
            GiveStartCards();

            Preflop();
            if (CanTheyProcceed() && Flop())
            {
                DisplayBanks();
                if (CanTheyProcceed() && Turn())
                {
                    DisplayBanks();
                    if (CanTheyProcceed() && !River())
                    {
                        DisplayBanks();
                        return;
                    }
                }
                else return;
            }
            else
                return;

            Showdown();
            _bank = 0;
        }

        protected virtual void SetupCheckers()
        {
            RoyalStraightFlushChecker royalStraightFlushChecker = new RoyalStraightFlushChecker();
            StraightFlushChecker straightFlushChecker = new StraightFlushChecker();
            FourOfKindChecker fourOfKindChecker = new FourOfKindChecker();
            FullHouseChecker fullHouseChecker = new FullHouseChecker();
            FlushChecker flushChecker = new FlushChecker();
            StraightChecker straightChecker = new StraightChecker();
            ThreeOfKindChecker threeOfKindChecker = new ThreeOfKindChecker();
            TwoPairsChecker twoPairsChecker = new TwoPairsChecker();
            OnePairChecker onePairChecker = new OnePairChecker();
            TopCardChecker topCardChecker = new TopCardChecker();

            royalStraightFlushChecker.SetNext(straightFlushChecker);
            straightFlushChecker.SetNext(fourOfKindChecker);
            fourOfKindChecker.SetNext(fullHouseChecker);
            fullHouseChecker.SetNext(flushChecker);
            flushChecker.SetNext(straightChecker);
            straightChecker.SetNext(threeOfKindChecker);
            threeOfKindChecker.SetNext(twoPairsChecker);
            twoPairsChecker.SetNext(onePairChecker);
            onePairChecker.SetNext(topCardChecker);

            _firstChecker = royalStraightFlushChecker;

        }

        protected virtual void InicializePlayers(uint startMoney)
        {
            _player1 = Player.HumanPlayer.GetInstance(startMoney);
            _player2 = Player.ComputerPlayer.GetInstance(startMoney);
            _player1.SetStrategy(this);
            _player2.SetStrategy(this);

        }

        protected virtual void InicializeDeck()
        {
            _deck = new Deck();
            _table = new List<Card>();
        }

        protected virtual void GiveStartCards()
        {
            _player1.HandOutCards(new List<Card> { _deck.Pop(), _deck.Pop()});
            _player2.HandOutCards(new List<Card> { _deck.Pop(), _deck.Pop()});
        }

        protected void DisplayBanks()
        {
            Console.SetCursorPosition(15, 0);
            Console.Write("PLayer's Money: {0} Computer's Money: {1} Bank: {2}       ", _player1.Cash, _player2.Cash, _bank);
        }

        protected virtual void Preflop()
        {
            Console.Clear();
            Console.WriteLine("PlayerNand:");
            DrawCards.DisplayCards(_player1.Hand, 1);

            DisplayBanks();

            // Set blinds
            Console.SetCursorPosition(0, DrawCards.SmallBlindSpace);
            Console.Write("Your small blind: ");
            _smallBlind = uint.Parse(Console.ReadLine());
            _biggestBet = 2 * _smallBlind;
            _player1.MakeBet(_smallBlind);
            _player2.MakeBet(_biggestBet);
            _bank += _smallBlind + _biggestBet;
            DisplayBanks();
        }

        protected abstract bool Flop();

        protected virtual bool Turn()
        {
            _table.Add(_deck.Pop());
            DrawCards.DisplayCards(_table, 2);
            decision player1Decision = _player1.PerformAction();
            switch (player1Decision)
            {
                case decision.Fold:
                    Console.WriteLine("Player 2 wins!");
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
            switch (player1Decision)
            {
                case decision.Fold:
                    Console.WriteLine("Player 1 wins!");
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
            return true;
        }

        protected virtual bool River()
        {
            _table.Add(_deck.Pop());
            DrawCards.DisplayCards(_table, 2);
            decision player1Decision = _player1.PerformAction();
            switch (player1Decision)
            {
                case decision.Fold:
                    Console.WriteLine("Player 2 wins!");
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
            switch (player1Decision)
            {
                case decision.Fold:
                    Console.WriteLine("Player 1 wins!");
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
            return true;
        }

        public virtual decision PCDecisions()
        {
            var availableCards = _table.Union(_player2.Hand).OrderBy(c => c.Value);

            int inARow = 1;
            Card prev = null;
            foreach (Card card in availableCards)
            {
                if (prev == null)
                    prev = card;
                else if (prev.Value + 1 == card.Value)
                {
                    inARow++;
                    prev = card;
                }
                else
                {
                    inARow = 1;
                    prev = card;
                }                  
            }

            if(inARow == 4)
                return decision.Raise;
            else if (availableCards.GroupBy(c => c.Suit).OrderByDescending(g => g.Count()).First().Count() == 4)
                return decision.Raise;
            else if (availableCards.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).First().Count() == 3)
                return decision.Raise;
            else if (availableCards.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).First().Count() == 2)
                return decision.Call;
            else if(inARow == 3)
                return decision.Call;
            else
                return decision.Fold;
        }

        public virtual void PCDecisionPreflop() { }
        public virtual void PCDecisionFlop() { }
        public virtual void PCDecisionTurn() { }
        public virtual void PCDecisionRiver() { }

        public virtual void PlayerDecisionPreflop() { }
        public virtual void PlayerDecisionFlop() { }
        public virtual void PlayerDecisionTurn() { }
        public virtual void PlayerDecisionRiver() { }

        protected void Showdown()
        {
            foreach(Card card in _table)
            {
                _player1.Hand.Add(card);
                _player2.Hand.Add(card);
            }
            DrawCards.DisplayCards(_player1.Hand, 1);
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("COMPUTER'S HAND");
            DrawCards.DisplayCards(_player2.Hand, 2);

            // processing the hands 
            HandValue p1Hand = _firstChecker.CheckCombination(_player1.Hand);
            HandValue p2Hand = _firstChecker.CheckCombination(_player2.Hand);




            DisplayBanks();
            Console.SetCursorPosition(0, 36);
            if(p1Hand > p2Hand)
            {
                Console.WriteLine("Player1 wins");
                Console.WriteLine("Player1 Combination: {0}", p1Hand.Combination);
                Console.WriteLine("Player2 Combination: {0}", p2Hand.Combination);
                _player1.WinBank(_bank);
            }
            else
            {
                Console.WriteLine("Player2 wins");
                Console.WriteLine("Player1 Combination: {0}", p1Hand.Combination);
                Console.WriteLine("Player2 Combination: {0}", p2Hand.Combination);
                _player2.WinBank(_bank);
            }
            _bank = 0;
            DisplayBanks();
        }

        public void ResetStrategy()
        {
            _bank = 0;
            _smallBlind = 0;
            _biggestBet = 0;
            _deck = null;
            _table = null;
        }

        public virtual bool CanTheyProcceed()
        {
            if(_player1.Cash < _biggestBet)
            {
                Console.SetCursorPosition(0, DrawCards.GameResultSpace);
                Console.WriteLine("PLayer1 has no money he's lost");
                _player2.WinBank(_bank);
                _bank = 0;
                return false;
            }
            else if(_player2.Cash < _biggestBet)
            {
                Console.SetCursorPosition(0, DrawCards.GameResultSpace);
                Console.WriteLine("PLayer2 has no money he's lost");
                _player1.WinBank(_bank);
                _bank = 0;
                return false;
            }
            return true;
        }
    }
}