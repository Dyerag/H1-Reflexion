using CodeAlong.Interfaces;
using CodeAlong.ModelClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlong.TestFolder
{
    internal class Køretøj<T> : IKøretøj
    {
        private const int _FørsteGangSyn = 5;
        private const int _IntervalSyn = 2;

        public string? KundenFornavn { get; set; }
        public string? KundensEfternavn { get; set; }
        public string? KundensTlf { get; set; }

        public record KundeKontaktInfoRecord(string? KundensFornavn, string? KundensEfternavn, string? KundensTlf);
        public KundeKontaktInfoRecord KundeKontaktInfo { get; set; }

        public string? Mærke { get; set; }
        public string? Model { get; set; }
        public T Størrelse { get; set; }
        public Køretøj(string? mærke, string? model, T størrelse, string? KundensFornavn, string? KundensEfternavn, string? KundensTlf)
        {
            Mærke = mærke;
            Model = model;
            Størrelse = størrelse;

            KundenFornavn = KundensFornavn;
            KundensFornavn = KundensEfternavn;
            KundensTlf = KundensTlf;

            //KundeKontaktInfo = new
        }
        
        [Ulovlig(Mærke = "Genesis", Model = "GV80", Årgang = 2023)]
        public string GetAllKøretøjInfo()
        {
            return $"mærke: {Mærke} Model: {Model}, Størrelse: {Størrelse}";
        }

        public int Alder(DateTime registreringsDato)
        {
            int age = DateTime.Now.Year-registreringsDato.Year;
            return age;
        }

        /*public ?? GetMultiValues()
        {
            int teacherId = 22;
            string teacherFornavn = "Niels";
            string teacherEfternavn = "Olesesn";
            DateTime teacherBirthDate = new DateTime(1971, 2, 23);
            return new Teacher() { Id = teacherId, Firstname= teacherFornavn,Lastname= teacherEfternavn, }
        }*/
    }
}
