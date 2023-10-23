using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaldursStarGate2dot0
{
    internal class Gui
    {
        public static void ShowPlayer(Player pc)
        {
            if (pc == null) return;

            Print(3, 1, $"{pc}");
            Print(3, 2, $"Gold: {pc.Gold}");
            Print(3, 3, $"Hp: {pc.CurrentHP} / {pc.MaxHP}", ConsoleColor.Red);
        }

        public static void ShowMonster(Monster monster)
        {
            if (monster == null) return;
            Print(30, 1, monster.Type);
            Print(30, 2, $"Gold: {monster.Gold}");
            Print(30, 3, $"Health: {monster.CurrentHP} / {monster.MaxHP}", ConsoleColor.Red);
        }

        public static void Print(int x, int y, string text, ConsoleColor Color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = Color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
