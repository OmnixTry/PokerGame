using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class StraightChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {
            var cardsInOrder = cards.GroupBy(c => c.Value).OrderBy(g => g.Key).ToList();

            // constant that sets distance between highest and lowest card in the combination
            const int Range = 4;
            for (int i = cardsInOrder.Count() - 1; i - Range >= 0; i--)
            {
                if (cardsInOrder[i].Key - Range == cardsInOrder[i - Range].Key)
                {
                    List<Card> vinningCombination = cardsInOrder.Skip(i - Range).Take(5).Select(g => g.First()).ToList();
                    COMBINATION combination = COMBINATION.Straight;
                    return new HandValue(cards, vinningCombination, combination);
                }
            }
           
            if (_nextChecker != null)
            {
                return _nextChecker.CheckCombination(cards);
            }
            else return null;
        }
    }
}
