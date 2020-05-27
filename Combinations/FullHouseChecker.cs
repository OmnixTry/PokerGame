using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    class FullHouseChecker : BaseCombinationChecker
    {
        public override void CheckCombination(HandValue handValue)
        {
            //the first three cars and last two cards are of the same value
            //first two cards, and last three cards are of the same value
            /*
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue) ||
                (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue))
            {
                handValue.Total = (int)(cards[0].MyValue) + (int)(cards[1].MyValue) + (int)(cards[2].MyValue) +
                    (int)(cards[3].MyValue) + (int)(cards[4].MyValue);
                return true;
            }

            return false;
            */


            int inARow = 1;
            List<MainGameProject.Cards.Card> pair = new List<MainGameProject.Cards.Card>();
            List<MainGameProject.Cards.Card> tripple = new List<MainGameProject.Cards.Card>();
            for (int i = 0; i < 6; i++)
            {
                if(handValue.Cards[i].Value == handValue.Cards[i + 1].Value)
                {
                    inARow++;
                }
                else if(handValue.Cards[i].Value != handValue.Cards[i + 1].Value && inARow == 2 && pair.Count != 2)
                {
                    pair.Add(handValue.Cards[i]);
                    pair.Add(handValue.Cards[i-1]);
                    inARow = 1;
                }
                else if(handValue.Cards[i].Value != handValue.Cards[i + 1].Value && inARow == 3 && tripple.Count != 3)
                {
                    tripple.Add(handValue.Cards[i]);
                    tripple.Add(handValue.Cards[i-1]);
                    tripple.Add(handValue.Cards[i-2]);
                    inARow = 1;
                }
            }

            if (inARow == 3)
            {
                tripple.Add(handValue.Cards[6]);
                tripple.Add(handValue.Cards[5]);
                tripple.Add(handValue.Cards[4]);
            }
            else if (inARow == 2)
            {
                pair.Add(handValue.Cards[6]);
                pair.Add(handValue.Cards[5]);
            }

            if(pair.Count() == 2 && tripple.Count == 3)
            {
                handValue.Total += (int)pair[0].Value;
                handValue.Total += (int)pair[1].Value;
                handValue.Total += (int)tripple[0].Value;
                handValue.Total += (int)tripple[1].Value;
                handValue.Total += (int)tripple[2].Value;

                Cards.Card topCard = handValue.Cards.Except(pair).Except(tripple).OrderByDescending(x => x.Value).First();
                handValue.Combination = COMBINATION.FullHouse;
                handValue.HighCard = (int)topCard.Value;
            }

            if (_nextChecker != null)
            {
                _nextChecker.CheckCombination(handValue);
            }
        }
    }
}
