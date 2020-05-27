using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class FlushChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            if (handValue.HeartsSum == 5)
            {
                handValue.Total = (from c in handValue.Cards
                                   where c.Suit == Cards.SUIT.HEARTS
                                   select c).Sum(c => (int)c.Value);
                handValue.HighCard = (int)(from c in handValue.Cards
                                           where c.Suit != Cards.SUIT.HEARTS
                                           select c).OrderByDescending(c => c.Value).First().Value;
                return;
            }
            else if (handValue.DiamondSum == 5)
            {
                handValue.Total = (from c in handValue.Cards
                                   where c.Suit == Cards.SUIT.DIAMONDS
                                   select c).Sum(c => (int)c.Value);
                handValue.HighCard = (int)(from c in handValue.Cards
                                           where c.Suit != Cards.SUIT.DIAMONDS
                                           select c).OrderByDescending(c => c.Value).First().Value;
                return;
            }
            else if (handValue.ClubSum == 5)
            {
                handValue.Total = (from c in handValue.Cards
                                   where c.Suit == Cards.SUIT.CLUBS
                                   select c).Sum(c => (int)c.Value);
                handValue.HighCard = (int)(from c in handValue.Cards
                                           where c.Suit != Cards.SUIT.CLUBS
                                           select c).OrderByDescending(c => c.Value).First().Value;
                return;
            }
            else if (handValue.SpadesSum == 5)
            {
                handValue.Total = (from c in handValue.Cards
                                   where c.Suit == Cards.SUIT.SPADES
                                   select c).Sum(c => (int)c.Value);
                handValue.HighCard = (int)(from c in handValue.Cards
                                           where c.Suit != Cards.SUIT.SPADES
                                           select c).OrderByDescending(c => c.Value).First().Value;
                return;
            }

            if(_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
