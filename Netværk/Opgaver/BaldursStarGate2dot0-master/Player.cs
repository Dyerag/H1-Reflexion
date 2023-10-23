using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaldursStarGate2dot0
{
    internal class Player : Creature
    {
        public string? Name { get; set; }
        public int Mana { get; set; }

        public override string? ToString()
        {
            return Name;
        }
    }
}
