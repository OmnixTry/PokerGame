using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    interface ICombinationChecker
    {
        void SetNext(ICombinationChecker nextHandler);
        HandValue CheckCombination(List<Cards.Card> cards);
    }
}
