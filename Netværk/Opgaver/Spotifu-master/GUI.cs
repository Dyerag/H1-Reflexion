using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifu
{
    internal class GUI
    {
        /// <summary>
        /// the method that writes stuff on screen, with text placement and color in mind
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="choice"></param>
        public static void Print(int x, int y, string text, ConsoleColor choice = ConsoleColor.Gray)
        {
            Console.ForegroundColor = choice;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Creates the logo at det top center of the window
        /// </summary>
        public static void ProgramName()
        {
            string topP1 = "_________", bottom = "|_________|", topP2 = "|         |";
            string name = "| Spotifu |";

            Console.Clear();

            Print(51, 1, topP1, ConsoleColor.Red);
            Print(50, 2, topP2, ConsoleColor.Red);
            Print(50, 3, name, ConsoleColor.Red);
            Print(50, 4, bottom, ConsoleColor.Red);
        }
    }
}
