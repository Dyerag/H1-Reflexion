using VærkstedsBilregistreringsApp.Methods;
using System.Globalization;
using VærkstedsBilregistreringsApp.ARF;
using System.Runtime.Serialization;
using static VærkstedsBilregistreringsApp.ARF.ARF;

namespace VærkstedsBilregistreringsApp
{
    internal class program
    {
        //Listen af registrerede biler
        public List<object> Carslist = new List<object>();
        public object[,] Cars = { };

        static void Main(string[] args)
        {
            string input;
            #region Main kode til programmet
            do
            {
                Console.CursorVisible = false;
                CarSearch();

                #region menu teksten
                string[] MenuText = new string[3] { " Registrere ny kunde", " Vis kunde kontaktinfo", " Afslut", }; //en array med alt menutekst
                Console.WriteLine("\n");//Denne her er der kun for at skabe et mellemrum mellem bullisten og menuteksten
                for (int i = 0; i <= MenuText.GetUpperBound(0); i++)//looped checker hvad den højeste indeksplads, og bruger den til at få antallet af omgange.
                {
                    Console.WriteLine(+i + 1 + MenuText[i]); //indholde i alle indekspladserne i MenuText bliver skrevet på skærmen
                }
                #endregion

                Console.WriteLine();
                Console.WriteLine("Vælg 1, 2 eller 3");

                #region switch'en til menuen, der sender programmet til den metode som har koden tilsvarende menu valget
                //ReadKey er true, for at forhindre den i at skrive hvad input var.KeyChar får den til faktisk at se hvad input var, som ReadLine Gør, istedet for at få en ConsoleKey.
                //ToString er der fordi input er en string, og ReadKey normalt ville give en ConsoleKey.
                switch (input = Console.ReadKey(true).KeyChar.ToString())
                {
                    //Vejen til metoden der registrere nye biler
                    case "1":
                        //det virker? forstår ikke helt hvordan
                        NewCustomer<ExecutionEngineException>();
                        break;

                    //Vejen til metoden dar lader dig søge i listen af biler efter en bil med ved brug af nummerplade
                    case "2":
                        Console.WriteLine("testing input 2");
                        break;
                    //førtæller dig at programmet lukker, og lukker programmet
                    case "3":
                        Console.WriteLine("\nProgrammet lukker");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("Du SKAL vælge en af de tidligere viste muligheder");
                        Console.WriteLine("tryk for at førsætte");
                        Console.ReadKey(true);
                        break;
                }
                #endregion
            } while (input != "3");
            #endregion
        }

        /// <summary>
        /// Metoden til at oprette nye kunder
        /// </summary>
        static void NewCustomer<Engine>()
        {
            //todo make registeringCar recieve registry date
            //fornavn, efternavn og tlf skal holde på kontaktinfo til ejeren, før de bliver lagt i Record, da alle værdierne i en record kun kan gives når den bliver instantieret
            string? fornavn, efternavn;
            int tlf;
            //så at man kan se hvor musen er
            Console.CursorVisible = true;
            #region Kontakt information
            Car CarInfo = new Car();
            Console.Write("\nFornavn: ");
            fornavn = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Efternavn: ");
            efternavn = Console.ReadLine();
            /*Når tlf nummer skal gives, går koden ind i loopet. Hvis input ikke er tal, Hvil man blive spurt om at skrive det igen,
            * og teksten som fortæller hvad man skal skrive vil gentage sig. andre loops som også godkender tal er sat op på samme måde*/
            do
                Console.Write("\nTelefon nummer: ");
            while (!int.TryParse(Console.ReadLine(), out tlf));

            kontaktInfo Owner = new(fornavn, efternavn, tlf);
            #endregion

            #region Bil information
            Console.Write($"\nnummerplade: ");
            CarInfo.Numberplate = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Mærke: ");
            CarInfo.Brand = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Model: ");
            CarInfo.Model = Console.ReadLine();
            Console.Write("\nMotor: ");
            //Fik Runtime Error
            //Engine? Motorstørrelse = (Engine?)Convert.ChangeType(Console.ReadLine(),  typeof(Engine?));
            CarInfo.MotorSize = Console.ReadLine();
            bool correctTime;
            do
            {
                Console.Write("\nRegistreringsdato: ");
                try
                {
                    //Todo potentially add CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern 
                    CarInfo.Registrydate = Convert.ToDateTime(Console.ReadLine());
                    correctTime = true;
                }
                catch
                {
                    Console.WriteLine("Fejl! husk at formatere datoen rightig.Du kan bruge skråstrej, punktum eller bindestreg til at del dd / mm / yy med");
                    correctTime = false;
                }

            } while (!correctTime);

            //Tjekker om bilen skal til syne. der er kun en metoden som tjekker begge enten sidste syn, eller registrerings dato. det bliver bestemt af int værdien
            if (!Convert.ToBoolean(no_inputOutput.NeedInspection(CarInfo, 0)))
            {
                Console.WriteLine("Bilen er mere end 5 år gammel");
                //et loop der tjekker om date er skrevet rigtigt. På samme måde som tidligere
                do
                {
                    Console.WriteLine("Angive sisdte synsdato:");
                    try
                    {

                        CarInfo.LastInspection = Convert.ToDateTime(Console.ReadLine());
                        correctTime = true;
                    }
                    catch
                    {
                        Console.WriteLine("Fejl! husk at formatere datoen rightig. Du kan bruge skråstrej, punktum eller bindestreg til at del dd/mm/yy med");
                        correctTime = false;
                    }

                } while (!correctTime);
                string inspect = Convert.ToBoolean(no_inputOutput.NeedInspection(CarInfo, 1)) ? "bilen skal til syn" : "Bilen skal Ikke til syn";
                Console.WriteLine(inspect);
            }
            else
                Console.WriteLine("Bilen skal ikke til syn");

            string faktoryCheck = no_inputOutput.IsCarDefect(CarInfo);
            if (faktoryCheck != null)
                Console.WriteLine("Bilen har følgende fabriksfejl: " + faktoryCheck);
            object[] car = { Owner, CarInfo };
            
            #endregion

        }

        /// <summary>
        /// Metoden der skrive listen af registrerede biler på skærmen
        /// </summary>
        static void CarSearch()
        {
            #region listen i toppen af menuen
            //clear tømmer vinduet, for at forhindre at der er en lang række af gentagende kode hvis man går frem og tilbage i koden.
            Console.Clear();
            //if-statementet skriver listen af registrerede biler i toppen, hvís der ikke er nogen, bliver det så outputtet
            if (false)
            {
                Console.WriteLine("Registrerede biler:\n");

            }
            else
            {
                Console.WriteLine("Der er ingen registrerede biler.");
            }
            #endregion
        }

    }
}