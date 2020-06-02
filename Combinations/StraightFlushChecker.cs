using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;
namespace MainGameProject.Combinations
{
    class StraightFlushChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {
            
            var request = from c in cards
                          group c by c.Suit into grp
                          where grp.Count() >= 5
                          select grp;

            if(request.Count() == 1)
            {
                List<Cards.Card> oneSuitCards = request.First().OrderByDescending(c => c.Value).ToList();
                // constant that sets distance between highest and lowest card in the combination
                const int Range = 4;
                for(int i = oneSuitCards.Count() - 1; i - Range >= 0; i--)
                {
                    if (oneSuitCards[i].Value - Range == oneSuitCards[i-Range].Value)
                    {
                        List<Card> vinningCombination = oneSuitCards.Skip(i - Range).Take(5).ToList();
                        COMBINATION combination = COMBINATION.StraightFlush;
                        return new HandValue(cards, vinningCombination, combination);
                    }
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
