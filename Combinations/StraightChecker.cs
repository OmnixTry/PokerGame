using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class StraightChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            /*
            if (handValue.Cards[0].Value + 1 == handValue.Cards[1].Value &&
                handValue.Cards[1].Value + 1 == handValue.Cards[2].Value &&
                handValue.Cards[2].Value + 1 == handValue.Cards[3].Value &&
                handValue.Cards[3].Value + 1 == handValue.Cards[4].Value)
            {
                //player with the highest value of the last card wins
                handValue.Total = (int)handValue.Cards[4].Value;
                handValue.HighCard = (int)handValue.Cards[6].Value;
                handValue.Combination = COMBINATION.Straight;
                return;
            }
            else if (handValue.Cards[1].Value + 1 == handValue.Cards[2].Value &&
                handValue.Cards[2].Value + 1 == handValue.Cards[3].Value &&
                handValue.Cards[3].Value + 1 == handValue.Cards[4].Value &&
                handValue.Cards[4].Value + 1 == handValue.Cards[5].Value)
            {
                handValue.Total = (int)handValue.Cards[5].Value;
                handValue.HighCard = (int)handValue.Cards[6].Value;
                handValue.Combination = COMBINATION.Straight;
                return;
            }
            else if (handValue.Cards[2].Value + 1 == handValue.Cards[3].Value &&
                handValue.Cards[3].Value + 1 == handValue.Cards[4].Value &&
                handValue.Cards[4].Value + 1 == handValue.Cards[5].Value &&
                handValue.Cards[5].Value + 1 == handValue.Cards[6].Value)
            {
                handValue.Total = (int)handValue.Cards[6].Value;
                handValue.HighCard = (int)handValue.Cards[1].Value;
                handValue.Combination = COMBINATION.Straight;
                return;
            }
            */
            //var q = handValue.Cards.Select(c => c.Value).Distinct();
            List<Cards.Card> notInARow = new List<Cards.Card>();
            int inARow = 1;
            for(int i = handValue.Cards.Count() - 1; i >= 1; i--)
            {
                if(handValue.Cards[i].Value - 1 == handValue.Cards[i - 1].Value)
                {
                    inARow++;
                }
                else if (handValue.Cards[i].Value == handValue.Cards[i - 1].Value)
                {
                    notInARow.Add(handValue.Cards[i]);
                }
                else
                {
                    notInARow.Add(handValue.Cards[i]);
                    inARow = 1;
                }
            }

            if (inARow >= 5)
            {
                handValue.Combination = COMBINATION.Straight;
                handValue.HighCard = (int)notInARow.OrderByDescending(x => (int)x.Value).First().Value;
                handValue.Total = handValue.Cards.Except(notInARow).Sum(x => (int)x.Value);
            }

            if(_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
