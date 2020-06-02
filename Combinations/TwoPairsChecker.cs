using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class TwoPairsChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {
            var OneValueCards = from c in cards
                                group c by c.Value into grp
                                where grp.Count() == 2
                                orderby grp.Key descending
                                select grp;

            if (OneValueCards.Count() >= 2)
            {
                List<Cards.Card> vinningCombination = OneValueCards.First().Union(OneValueCards.Take(2).Last()).ToList();
                COMBINATION combination = COMBINATION.TwoPairs;
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
