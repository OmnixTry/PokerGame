using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Combinations
{
    class TopCardChecker : BaseCombinationChecker
    {
        public override HandValue CheckCombination(List<Card> cards)
        {
            List<Card> highestCard = new List<Card>();
            highestCard.Add(cards.OrderByDescending(c => c.Value).First());
            return new HandValue(cards, highestCard, COMBINATION.Nothing);            
        }
    }
}
