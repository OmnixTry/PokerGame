using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class FourOfKindChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if ((handValue.Cards[0].Value == handValue.Cards[1].Value && handValue.Cards[0].Value == handValue.Cards[2].Value && handValue.Cards[0].Value == handValue.Cards[3].Value) ||
                (handValue.Cards[1].Value == handValue.Cards[2].Value && handValue.Cards[1].Value == handValue.Cards[3].Value && handValue.Cards[1].Value == handValue.Cards[4].Value) ||
                (handValue.Cards[2].Value == handValue.Cards[3].Value && handValue.Cards[2].Value == handValue.Cards[4].Value && handValue.Cards[2].Value == handValue.Cards[5].Value))
            {
                handValue.Total = (int)handValue.Cards[3].Value * 4;
                handValue.HighCard = (int)handValue.Cards[6].Value;
                handValue.Combination = COMBINATION.FourKind;
                //return handValue;
            }
            else if (handValue.Cards[3].Value == handValue.Cards[4].Value && handValue.Cards[3].Value == handValue.Cards[5].Value && handValue.Cards[3].Value == handValue.Cards[6].Value)
            {
                handValue.Total = (int)handValue.Cards[3].Value * 4;
                handValue.HighCard = (int)handValue.Cards[2].Value;
                handValue.Combination = COMBINATION.FourKind;
                //return handValue;
            }

            if (_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
