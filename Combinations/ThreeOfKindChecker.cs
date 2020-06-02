using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class ThreeOfKindChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {
            var OneValueCards = from c in cards
                                group c by c.Value into grp
                                where grp.Count() >= 3
                                select grp;

            if (OneValueCards.Count() == 1)
            {
                List<Cards.Card> vinningCombination = OneValueCards.First().ToList();
                COMBINATION combination = COMBINATION.ThreeKind;
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
