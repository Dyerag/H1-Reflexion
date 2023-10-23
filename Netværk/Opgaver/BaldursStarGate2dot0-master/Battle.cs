using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaldursStarGate2dot0
{
    internal class Battle
    {
        public Battle(Player player, Monster monster)
        {
            Combat(player, monster);
        }

        public Battle() { }
        public bool Combat(Player pc, Monster monster)
        {
            int Round = 1;
            bool continueBattle = true;
            Console.Clear();
            Gui.Print(3, 5, $"{pc} opens a stargate, and out jumps a... " + monster.Type);
            Gui.ShowPlayer(pc);
            Gui.ShowMonster(monster);
            while (continueBattle)
            {
                if (lineCounter > 20)
                {
                    Console.Clear();
                    Gui.ShowPlayer(pc);
                    Gui.ShowMonster(monster);
                    lineCounter = 6;
                }

                Gui.Print(3, lineCounter++, "Round " + Round++ + "");
                Console.ReadKey(true);
                if (WhoStarts() == 0)
                {
                    continueBattle = Attack(monster, pc);
                    if (!continueBattle) return false;//break;
                    Console.WriteLine();
                    continueBattle = Attack(pc, monster);
                    if (!continueBattle)
                    {
                        pc.EquipmentList.AddRange(monster.EquipmentList);
                        pc.Gold += monster.Gold;
                        return true;//break;
                    }
                }
                else
                {
                    continueBattle = Attack(pc, monster);
                    if (!continueBattle)
                    {
                        pc.EquipmentList.AddRange(monster.EquipmentList);
                        pc.Gold += monster.Gold;
                        return true;//break;
                    }
                    Console.WriteLine();
                    continueBattle = Attack(monster, pc);
                    if (!continueBattle) return false;//break;
                }
            }
            return true;
        }

        int lineCounter = 6;
        private bool Attack(Creature Target, Creature attacker)
        {

            int Roll = AttackRoll();
            Gui.Print(3, lineCounter++, $"{attacker} swings, and rolls a(n) " + Roll);
            Roll = ArmorReduction(Roll, Target);
            Target.ReduceHP(Roll);

            //We check if someone died, and if, we return false, so we can stop the battle
            if (Target.CurrentHP <= 0)
            {
                Gui.Print(3, lineCounter++, $"The {Target.Type} has died");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        private int ArmorReduction(int atk, Creature creature)
        {
            return Math.Max(0, (atk - creature.Armor));
        }

        //todo add modifier to weapon and monster
        private int AttackRoll()
        {
            int att = Game.Rnd.Next(Game.Dice);
            return att;
        }

        private int WhoStarts()
        {
            return Game.Rnd.Next(2);
        }
    }
}
