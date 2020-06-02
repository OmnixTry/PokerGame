using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class FlushChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {
            var OneSuitCards= from c in cards
                           group c by c.Suit into grp
                           where grp.Count() >= 5
                           
                           select grp;

            if (OneSuitCards.Count() == 1)
            {
                List<Cards.Card> vinningCombination = OneSuitCards.First().ToList();
                COMBINATION combination = COMBINATION.Flush;
                return new HandValue(cards, vinningCombination, combination);
            }

            if (_nextChecker != null)
            {
                return _nextChecker.CheckCombination(cards);
            }
            else return null;
        }
    }
}
