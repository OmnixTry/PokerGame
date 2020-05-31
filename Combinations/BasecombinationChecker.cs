using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    abstract class BaseCombinationChecker : ICombinationChecker
    {
        protected ICombinationChecker _nextChecker;

        public void SetNext(ICombinationChecker next)
        {
            _nextChecker = next;
        }

        public abstract void CheckCombination(HandValue handValue);
    }
}
