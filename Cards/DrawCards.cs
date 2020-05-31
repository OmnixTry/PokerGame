using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Cards
{
    class DrawCards
    {
        public const int FreeScreenSpace = 32;
        //draw cards outlines
        public static void DrawCardOutline(int xcoor, int ycoor)
        {
            Console.ForegroundColor = ConsoleColor.White;

            int x = xcoor * 12;
            int y = ycoor;

            Console.SetCursorPosition(x, y);
            Console.Write(" __________\n"); //top edge of the card

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                if (i != 9)
                    Console.WriteLine("|          |");//left and right edges of the card
                else
                    Console.WriteLine("|__________|");//bottom edge of the card
            }
        }

        //displays suit and value of the card inside its outline
        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            // all suits
            char club = '\u2663';
            char spade = '\u2660';
            char diamond = '\u2666';
            char heart = '\u2665';

            char cardSuit = ' ';
            int x = xcoor * 12;
            int y = ycoor;

            //Encode each byte array from the CodePage437 into a character
            //hears and diamonds are red, clubs and spades are black
            switch (card.Suit)
            {
                case SUIT.HEARTS:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    cardSuit = heart;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case SUIT.DIAMONDS:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    cardSuit = diamond;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case SUIT.CLUBS:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    cardSuit = club;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case SUIT.SPADES:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    cardSuit = spade;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            //display the encoded character and value of the card
            Console.SetCursorPosition(x + 5, y + 5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.Value);
        }

        public static void DisplayCards(List<Card> cards, int row)
        {
            
            int x = 0; //x position of the cursor. We move it left and right
            int y = 1 + 15 * (row - 1);//y position of the cursor, we move up and down

            //display player hand
            Console.ForegroundColor = ConsoleColor.DarkCyan;       
            for (int i = 0; i < cards.Count; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(cards[i], x, y);
                x++;//move to the right
            }
        }
    }
}
