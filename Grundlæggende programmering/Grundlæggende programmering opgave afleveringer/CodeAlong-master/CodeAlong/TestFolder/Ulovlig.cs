using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlong.TestFolder
{
    internal class Ulovlig : Attribute
    {
        public string? Mærke { get; set; }
        public string? Model { get; set; }
        public int Årgang { get; set; }
    }
}
