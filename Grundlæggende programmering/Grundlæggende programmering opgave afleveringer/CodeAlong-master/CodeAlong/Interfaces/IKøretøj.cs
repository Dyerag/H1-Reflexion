using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlong.Interfaces;

internal interface IKøretøj
{
    public string? Mærke { get; set; }
    public string? Model { get; set; }

    public int Alder(DateTime registreringsDato);
}
