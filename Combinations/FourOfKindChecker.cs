using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class FourOfKindChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {

            var request = from c in cards
                          group c by c.Value into grp
                          where grp.Count() == 4
                          select grp;

            if (request.Count() == 1)
            {
                List<Cards.Card> vinningCombination = request.First().ToList();
                COMBINATION combination = COMBINATION.FourKind;
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
