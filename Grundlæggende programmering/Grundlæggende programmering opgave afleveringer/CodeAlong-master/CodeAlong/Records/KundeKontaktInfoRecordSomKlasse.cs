using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlong.Records
{
    internal class KundeKontaktInfoRecordSomKlasse
    {
        public string? KundenFornavn { get; init; }
        public string? KundensEfternavn { get; init; }
        public string? KundensTlf { get; init; }

        public KundeKontaktInfoRecordSomKlasse(string? kundenFornavn, string? kundensEfternavn, string? kundensTlf)
        {
            KundenFornavn = kundenFornavn;
            KundensEfternavn = kundensEfternavn;
            KundensTlf = kundensTlf;
        }
    }
}
