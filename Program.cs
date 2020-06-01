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
            HandValue hand = new HandValue(new List<Card>
            {
                new Card(SUIT.CLUBS, VALUE.SEVEN),
                new Card(SUIT.SPADES, VALUE.SEVEN),
                new Card(SUIT.SPADES, VALUE.KING),
                new Card(SUIT.SPADES, VALUE.EIGHT),
                new Card(SUIT.CLUBS, VALUE.FIVE),
                new Card(SUIT.DIAMONDS, VALUE.FIVE),
                new Card(SUIT.DIAMONDS, VALUE.KING)
            });

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
            Console.WriteLine(hand.Combination);
            */

            //Console.ReadLine();
        }
    }
}
