using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class TwoPairsChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            var groups = handValue.Cards
                .GroupBy(c => c.Value)
                .Where(g => g.Count() == 2)
                .OrderByDescending(g => g.Key);

            if(groups.Count() >= 2)
            {
                foreach (var group in groups.Take(2))
                {
                    handValue.Total = group.Sum(c => (int)c.Value);
                }
                handValue.HighCard = (int)handValue.Cards
                    .GroupBy(c => c.Value)
                    .OrderByDescending(g => g.Key).Skip(2).First().Key;
                handValue.Combination = COMBINATION.TwoPairs;
                return; 
            }

            if (_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
