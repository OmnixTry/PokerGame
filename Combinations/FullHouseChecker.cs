using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class FullHouseChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {

            var tripples = from c in cards
                           group c by c.Value into grp
                           where grp.Count() == 3
                           orderby grp.Key descending
                           select grp;
            var pairs = from c in cards
                        group c by c.Value into grp
                        where grp.Count() == 2
                        orderby grp.Key descending
                        select grp;

            if (tripples.Count() >= 1 && pairs.Count() >= 1)
            {
                List<Cards.Card> vinningCombination = tripples.First().Union(pairs.First()).ToList();
                COMBINATION combination = COMBINATION.FullHouse;
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
