using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaldursStarGate2dot0
{
    //todo cleanup (refactoring)
    //todo choose weapons
    //todo save in files
    //todo register player
    //todo exceptions
    //todo GUI life / level / mana
    //todo Counter battles won
    //todo xp & level
    internal class Game
    {
        private static List<Equipment> allEquipment;
        public static int Dice = 20;
        public static Random Rnd = new Random(10);
        public Game()
        {
            allEquipment = Io.Load<AllEquipment>().EquipmentList;
            Player pc = CreatePlayer();
            while (GameMenu(pc)) ;
        }

        public Game(Player? pc)
        {
            allEquipment = Io.Load<AllEquipment>().EquipmentList;
            while (GameMenu(pc)) ;
        }

        bool GameMenu(Player pc)
        {
            Console.Clear();
            Gui.ShowPlayer(pc);
            Gui.Print(5, 6, "\t-Hub Menu-");
            Gui.Print(3, 7, "[1] Open gate to dungeon");
            Gui.Print(3, 8, "[2]Go to Shop");
            Gui.Print(3, 9, "[3]Rest");
            Gui.Print(3, 10, "[4]Save game");
            Gui.Print(3, 11, "[5]Exit to main menu");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Monster monster = CreateMonster();
                    //new battle(player, monster)
                    bool result = new Battle().Combat(pc, monster);
                    if (!result) Gui.Print(20, 20, $"{pc.Name} won");
                    else Gui.Print(20, 20, "Monster won");
                    break;

                case ConsoleKey.D2:
                    //todo create a Shop
                    break;

                case ConsoleKey.D3:
                    pc.CurrentHP += 11;
                    break;

                case ConsoleKey.D4:
                    Io.Save(pc);
                    break;

                case ConsoleKey.D5:
                    return false;
                    break;

            }
            return true;

        }
        private Player CreatePlayer()
        {
            Player pcp = new Player();
            pcp.Type = "Player";
            Gui.Print(2, 3, "What is your name: ");
            pcp.Name = Console.ReadLine();
            pcp.MaxHP = 100;
            pcp.CurrentHP = pcp.MaxHP;
            pcp.Armor = 2;

            return pcp;
        }

        private static Monster CreateMonster()
        {
            return new Monster(allEquipment);
        }

    }
}
