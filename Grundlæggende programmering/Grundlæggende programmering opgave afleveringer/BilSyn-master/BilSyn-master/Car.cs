using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSyn
{
    internal class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Licenseplate { get; set; }
        public Person Owner { get; set; }
        public DateTime DateofRegistration { get; set; }
        public DateTime LastInspection { get; set; }
        public int ModelYear { get; set; } = 2000;
        public float EngineSize { get; set; } = 2f;

        public string ManufacturingDefects { get; set; }
    }
}
