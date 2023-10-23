using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecFagTilmeldingApp.CustomeTypes
{
    internal class AgeCalculator
    {
        public int Age { get; set; }

        public AgeCalculator(DateTime birthday)
        {
            Age = DateTime.Now.Year - birthday.Year;
        }
    }
}
