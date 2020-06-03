using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Cards
{
    /// <summary>
    /// Class for drawing cards in the console window
    /// </summary>
    class DrawCards
    {
        public const int BankDisplaySpaceX = 15;
        public const int SmallBlindSpace = 31;
        public const int FreeScreenSpace = 32;
        public const int DiscardingSpace = 37;
        public const int GameResultSpace = 36;
        public const int EndMenuSpace = 40;

        /// <summary>
        /// Draws cards outlines
        /// </summary>
        /// <param name="xcoor">The x start coordinate of the outline</param>
        /// <param name="ycoor">The y start coordinate of the outline</param>
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

        /// <summary>
        /// displays suit and value of the card inside its outline
        /// </summary>
        /// <param name="card">The card froperties of which you want to display</param>
        /// <param name="xcoor">X coordinate pof the outline</param>
        /// <param name="ycoor">Y coordinate pof the outline</param>
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

        /// <summary>
        /// Display the list of cards on console
        /// </summary>
        /// <param name="cards">The list of cards to display on he console</param>
        /// <param name="row">The row of cards you want oto display it on</param>
        public static void DisplayCards(List<Card> cards, int row)
        {
            const int StartPosition = 0;
            const int RowHeight = 15;
            int x = StartPosition; //x position of the cursor. We move it left and right
            int y = 1 + RowHeight * (row - 1);//y position of the cursor, we move up and down

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
