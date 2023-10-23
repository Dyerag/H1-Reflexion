using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BaldursStarGate2dot0
{
    internal abstract class Creature
    {
        public int MaxHP { get; set; }
        //Field
        private int currentHP;

        //Propert. GET returns value of field, SET sets value of field from [value]
        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
            set
            {
                //If value set for currentHP property is higher than max, then value is capped at max
                if (value > MaxHP) value = MaxHP;
                currentHP = value;

                if (this.GetType() == typeof(Player))
                    Gui.ShowPlayer((Player)this);
                else Gui.ShowMonster((Monster)this);
            }
        } 
        public int Armor { get; set; }
        public string Type { get; set; } = "Unknown";
        public int Gold { get; set; }
        public List<Equipment> EquipmentList { get; set; } = new();

        public void ReduceHP(int damage)
        {
            CurrentHP -= damage;
        }

    }
}
