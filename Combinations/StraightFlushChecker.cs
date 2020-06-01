using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class StraightFlushChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            var group = handValue.Cards.GroupBy(c => c.Suit).Where(g => g.Count() >= 5);
            List<Cards.Card> oneSuitCards = new List<Cards.Card>();
            if (group.Count() >= 1)
            {
                foreach (Cards.Card card in group.First().OrderBy(c => c.Value))
                    oneSuitCards.Add(card);
            }
            if (oneSuitCards.Count() > 0)
            {

                List<Cards.Card> notInARow = new List<Cards.Card>();
                int inARow = 1;
                handValue.VinningCombination.Add(oneSuitCards[oneSuitCards.Count() - 1]);
                for (int i = oneSuitCards.Count() - 1; i >= 1; i--)
                {
                    if (oneSuitCards[i].Value - 1 == oneSuitCards[i - 1].Value)
                    {
                        inARow++;
                        handValue.VinningCombination.Add(oneSuitCards[i - 1]);
                    }
                    else
                    { 
                        notInARow.Add(handValue.Cards[i]);
                        if (inARow != 5)
                        {
                            handValue.VinningCombination.Clear();
                            handValue.VinningCombination.Add(handValue.Cards[i - 1]);
                            inARow = 1;
                        }
                    }
                }

                if (inARow >= 5)
                {
                    handValue.Combination = COMBINATION.StraightFlush;
                    if (inARow == 7)
                    {
                        handValue.HighCard = (int)handValue.Cards[1].Value;
                    }
                    else
                    {
                        handValue.HighCard = (int)handValue.Cards
                            .Except(oneSuitCards)
                            .Union(notInARow)
                            .OrderByDescending(c => c.Value)
                            .First().Value;
                            
                    }
                    handValue.Total = oneSuitCards.OrderByDescending(c => c.Value).Take(5).Sum(x => (int)x.Value);
                    return;
                }
            }

            if (_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
