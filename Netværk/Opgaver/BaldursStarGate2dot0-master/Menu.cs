using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaldursStarGate2dot0
{
    internal class Menu
    {
        public Menu()
        {
            while (true) { MainMenu(); }
        }
        internal void MainMenu()
        {
            Console.Clear();
            Gui.Print(20, 8, "\t-----MENU-----");
            Gui.Print(10, 10, "[1] New Game\t[2] Load Save\t[3] Close Game");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    new Game();
                    break;

                case ConsoleKey.D2:
                    Player? pc = Io.Load<Player>();
                    if (pc == null)
                    {
                        Gui.Print(22, 11, "Failed to load game!", ConsoleColor.Red);
                        Console.ReadKey();
                    }
                    else new Game(pc);
                    break;

                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;
            }


        }

    }
}
