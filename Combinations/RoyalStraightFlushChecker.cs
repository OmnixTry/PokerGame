using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class RoyalStraightFlushChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Cards.Card> cards)
        {
            var request = from c in cards
                          group c by c.Suit into gr
                          where gr.Count() >= 5
                          select gr;

            if (request.Count() == 1)
            {
                List<Card> OneSuitCards = request.First().OrderByDescending(c => c.Value).ToList();
                if (OneSuitCards[0].Value == VALUE.ACE
                    && OneSuitCards[4].Value == VALUE.TEN)
                {
                    List<Card> vinningCombination = OneSuitCards.Take(5).ToList();
                    COMBINATION combination = COMBINATION.RoyalStraightFlush;
                    return new HandValue(cards, vinningCombination, combination);
                }
                
            }

            if (_nextChecker != null)
            {
                return _nextChecker.CheckCombination(cards);
            }

            return null;
        }
    }
}
