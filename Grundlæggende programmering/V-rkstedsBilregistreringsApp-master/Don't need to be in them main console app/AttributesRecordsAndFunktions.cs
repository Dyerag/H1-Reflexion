global using VærkstedsBilregistreringsApp.ARF;

namespace VærkstedsBilregistreringsApp.ARF
{

    internal class ARF
    {
        /// <summary>
        /// Den record som lader ejere af biler blive instantieret, og kan ikke ændres normalt
        /// </summary>
        /// <param name="Fornavn"></param>
        /// <param name="Efternavn"></param>
        /// <param name="Tlf"></param>
        public record kontaktInfo(string? Fornavn, string? Efternavn, int? Tlf);


        /// <summary>
        /// Attributen der lader skabelen af bil objekter ske
        /// </summary>
        internal class Car : Attribute
        {
            public string? Numberplate { get; set; }
            public string? Brand { get; set; }
            public string? Model { get; set; }

            public DateTime Registrydate { get; set; }
            public DateTime LastInspection { get; set; }
            public string? MotorSize { get; set; }

            public string? manufactoryError { get; set; }
        }


        /// <summary>
        /// Listen af biler med fabriksfejl
        /// </summary>
        public static List<Car> DefectiveCarsList()
        {
            List<Car> illegalCars = new List<Car>();

            Car FiatPunto = new();
            FiatPunto.Brand = "Fiat"; FiatPunto.Model = "Punto"; FiatPunto.Registrydate = DateTime.Parse("01,01,2010"); FiatPunto.manufactoryError = "udstødning";

            Car AlfaRomeo = new();
            AlfaRomeo.Brand = "Alfa Romeo"; AlfaRomeo.Model = "Guilia"; AlfaRomeo.Registrydate = DateTime.Parse("01 - 08 - 2019"); AlfaRomeo.manufactoryError = "Styretøjet";

            illegalCars.Add(FiatPunto);
            illegalCars.Add(AlfaRomeo);

            return illegalCars;
        }

    }

}
