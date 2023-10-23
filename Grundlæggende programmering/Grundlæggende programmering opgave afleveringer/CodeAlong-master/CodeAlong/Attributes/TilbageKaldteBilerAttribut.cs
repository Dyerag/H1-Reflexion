using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlong.Attributes
{
    internal class TilbageKaldteBilerAttribut : Attribute
    {
        public string? Mærke { get; set; }
        public string? Model { get; set; }
        public string? Årgang { get; set; }

        public string? FabriksFejl { get; set; }
    }
}
