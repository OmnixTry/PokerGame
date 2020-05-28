using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class ThreeOfKindChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            var groupsByValue = handValue.Cards.GroupBy(c => c.Value).OrderByDescending(g => g.Key);
            foreach(var group in groupsByValue)
            {
                if(group.Count() == 3)
                {
                    handValue.Total = group.Select(x => (int)x.Value).Sum();
                    handValue.HighCard = (int)handValue.Cards.Except(group).OrderBy(x => x.Value).First().Value;
                    handValue.Combination = COMBINATION.ThreeKind;
                    return;
                }
            }

            if(_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
