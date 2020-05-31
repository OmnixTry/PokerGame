using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class OnePairChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            var groups = handValue.Cards.GroupBy(c => c.Value).OrderByDescending(g => g.Count());

            if(groups.First().Count() == 2)
            {
                handValue.Combination = COMBINATION.OnePair;
                handValue.Total = groups.First().Sum(x => (int)x.Value);
                handValue.HighCard = (int)groups.Where(x => x.Key != groups.First().Key).OrderBy(x => x.Key).Last().Key;
                return;
            }

            if (_nextChecker != null)
                _nextChecker.CheckCombination(handValue);
        }
    }
}
