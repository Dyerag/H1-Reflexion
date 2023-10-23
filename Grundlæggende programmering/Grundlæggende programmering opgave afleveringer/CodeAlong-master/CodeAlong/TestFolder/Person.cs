using CodeAlong.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAlong.Array;

namespace CodeAlong.TestFolder
{
    internal class Person
    {
        ArrayExamples ArrayExamples = new ArrayExamples();


        public TilbageKaldtBilEnum TilbageKaldtBil { get; set; }

        
        public string? FirstName { get; set; }
        public string? LastName{ get; set; }

            public string TjekForTilbageKaldteBiler(TilbageKaldtBilEnum tilbageKaldtBil)
        {
            return tilbageKaldtBil.ToString();
        }
    }
}
