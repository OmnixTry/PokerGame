using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    /// <summary>
    /// Base class for all the winning combination checker
    /// </summary>
    abstract class BaseCombinationChecker : ICombinationChecker
    {
        /// <summary>
        /// Pointer to the Next checker
        /// </summary>
        protected ICombinationChecker _nextChecker;

        /// <summary>
        /// Set next checker in the que
        /// </summary>
        /// <param name="next">Pointer to the next checker</param>
        public void SetNext(ICombinationChecker next)
        {
            _nextChecker = next;
        }

        /// <summary>
        /// Check if the following list of cards has a particular Winning combination
        /// </summary>
        /// <param name="cards">The list of cards to check for combination</param>
        /// <returns></returns>
        public abstract HandValue CheckCombination(List<Cards.Card> cards);
    }
}
