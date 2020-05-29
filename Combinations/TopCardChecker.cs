using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class TopCardChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            handValue.HighCard = (int)handValue.Cards.OrderByDescending(c => c.Value).First().Value;
        }
    }
}
