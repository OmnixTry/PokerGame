using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;
using MainGameProject.Combinations;
using MainGameProject.Player;
using MainGameProject.Game;


namespace MainGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game.Game game = new Game.Game();
            game.PlayGame();
            

            /*
            List<Card> hand = new List<Card>
            {
                new Card(SUIT.CLUBS, VALUE.TWO),
                new Card(SUIT.HEARTS, VALUE.SIX),
                new Card(SUIT.CLUBS, VALUE.FOUR),
                new Card(SUIT.HEARTS, VALUE.FIVE),
                new Card(SUIT.CLUBS, VALUE.NINE),
                new Card(SUIT.HEARTS, VALUE.QUEEN),
                new Card(SUIT.DIAMONDS, VALUE.KING)
            };

            RoyalStraightFlushChecker royalStraightFlushChecker = new RoyalStraightFlushChecker();
            StraightFlushChecker straightFlushChecker = new StraightFlushChecker();
            FourOfKindChecker fourOfKindChecker = new FourOfKindChecker();
            FullHouseChecker fullHouseChecker = new FullHouseChecker();
            FlushChecker flushChecker = new FlushChecker();
            StraightChecker straightChecker = new StraightChecker();
            ThreeOfKindChecker threeOfKindChecker = new ThreeOfKindChecker();
            TwoPairsChecker twoPairsChecker = new TwoPairsChecker();
            OnePairChecker onePairChecker = new OnePairChecker();
            TopCardChecker topCardChecker = new TopCardChecker();

            royalStraightFlushChecker.SetNext(straightFlushChecker);
            straightFlushChecker.SetNext(fourOfKindChecker);
            fourOfKindChecker.SetNext(fullHouseChecker);
            fullHouseChecker.SetNext(flushChecker);
            flushChecker.SetNext(straightChecker);
            straightChecker.SetNext(threeOfKindChecker);
            threeOfKindChecker.SetNext(twoPairsChecker);
            twoPairsChecker.SetNext(onePairChecker);
            onePairChecker.SetNext(topCardChecker);
            
            royalStraightFlushChecker.CheckCombination(hand);
            HandValue handValue = royalStraightFlushChecker.CheckCombination(hand);
            Console.WriteLine(handValue.Combination);
            Console.WriteLine(handValue.HighCard);
            Console.WriteLine(handValue.Total);

            foreach (Card card in handValue.VinningCombination)
            {
                Console.WriteLine("{1} of {0}", card.Suit, card.Value);
            }
            */
            //Console.ReadLine();
        }
    }
}
