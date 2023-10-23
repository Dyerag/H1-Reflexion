using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAlong.Attributes;

namespace CodeAlong.Enum
{
    internal enum TilbageKaldtBilEnum
    {
        [TilbageKaldteBilerAttribut(Mærke = "Fiat", Model = "Punto", Årgang = "01-01-2010", FabriksFejl = "udstødning")]
        FiatPunto,
        [TilbageKaldteBilerAttribut(Mærke = "Alfa", Model = "Romeo", Årgang = "01-08-2019", FabriksFejl = "Styretøjet")]
        AlfaRomeo
    }
}
