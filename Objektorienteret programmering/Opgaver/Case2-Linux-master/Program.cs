using People;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Security.Principal;
using System.Threading.Channels;

namespace Case2
{
    internal class Program
    {
        //Denne liste holder på alle speciallægerne, som bliver skabt i en anden metode i begyndelsen af programmet
        public static List<Doctor> DoctorList = new();
        //listen her holder på patienterne
        public static List<Patient> patientList = new();
        static void Main(string[] args)
        {
            do
            {
                //Denne WriteLine er bare for at skabe mellemrum mellem hver omgang
                Debug.WriteLine("\n\n\n\n\n");
                //Laver variablerne på forhånd
                //De to string arrays holder på en pulje for- og efternavne, som tilfældigvis bliver trukket, når en ny patient laves
                string[] firstnameList = { "Mathew", "Lebron", "Peter", "Po", "Joakim" }, lastnameList = { "Stark", "Wayne", "Habsburg", "Potter", "Fiesta" };
                string firstname, lastname;
                //amountOfDoctors i variablen der holder på det valgte antal lægerer at tildele
                int tlf, amountOfDoctors = 0;
                //Listen af de valgte læger
                List<Doctor> patientsdoctors = new();
                Random rnd = new Random();
                /*rndtext bruges når det tilfældige antal læger, og vilke læger, skal vælges. Den bliver givet et tilfældigt tal,
                 * og skal output det, så man kan se hvad der blev valgt. det tilfældige tal bliver lagt i en string, fordi rnd,
                 * som er den der skaber tallet, er en klasse metode, og holder ikke på tallet*/
                string rndText, tlfText = "";

                //denne metode skaber objecterne med speciallægerne. den er void, fordi lægerne after de er skabt bliver direkte lagt i listen
                //metoden køre kun hvis listen er tom,altså programmet lige er startet, for at undgå at lægerne bliver lagt i, gentagende gange
                if (DoctorList.Count == 0)
                    PeopleCreation.Employees();

                #region De første felter og deres input. det her er de simple felter
                System.Diagnostics.Debug.Write($"Patient fornavn: ");
                Thread.Sleep(2000);
                //ReadLine
                //hver array for et tilfældigt indeksnummer, og navnet i den tilsvarende plads er hvad der bliver brugt
                firstname = firstnameList[rnd.Next(0, 5)];
                System.Diagnostics.Debug.WriteLine(firstname);

                System.Diagnostics.Debug.Write("\nPatient efternavn: ");
                Thread.Sleep(2000);
                //ReadLine
                lastname = lastnameList[rnd.Next(0, 5)];
                System.Diagnostics.Debug.WriteLine(lastname);

                System.Diagnostics.Debug.Write("\nPatient Tlf: ");
                Thread.Sleep(2000);

                //ReadLine
                //tlf skal være et otte cifredet tal, og loopet laver hvert tal en af gange. På den måde kan tal med førende 0 også fås
                //på nærmere eftertanke, kunne jeg nok et tilfældigt tal inden for variationene, og lavet noget med førende 0'er, men nu er det gjort sådan
                for (int i = 0; i < 8; i++)
                    tlfText = tlfText + rnd.Next(0, 10).ToString();
                
                //outputter det random tal i output og lægger den i tlf variablen.
                int.TryParse(tlfText, out tlf);
                System.Diagnostics.Debug.WriteLine(tlf);
                Thread.Sleep(2000);
                #endregion

                #region det her er delen hvor læger bliver tilføjet. ikke lige så simpelt
                //her ville man så vælge hvor mange læger der skal tildeles, og der er et minimum og maksimum antal læger
                System.Diagnostics.Debug.WriteLine("\nhvor mange læger?");
                while (amountOfDoctors < 1 || amountOfDoctors > 3)
                {
                    System.Diagnostics.Debug.WriteLine("Mindst 1 og maks 3 må vælges");
                    Thread.Sleep(2000);
                    //Det tilfældige tal den skaber, er størrer end parameteren til loopet, for at vise at for små og for store tal ikke er gyldige
                    rndText = rnd.Next(-1, 5).ToString();
                    Console.WriteLine(rndText);
                    int.TryParse(rndText, out amountOfDoctors);
                }

                Console.WriteLine($"\nTildel læge:");
                //Looped skriver navnene på lægerne
                for (int i = 0; i < DoctorList.Count; i++)
                {
                    Thread.Sleep(500);
                    System.Diagnostics.Debug.WriteLine($"{i + 1}. {DoctorList[i].firstname} {DoctorList[i].lastname} {DoctorList[i].specialisation}");

                }
                Thread.Sleep(2000);

                //det her loop lader dig så tilføje de læger som vælges til en liste af valgte læger.
                //loopet gentager sig indtil at antallet af valgte læger møder antallet af læger som skal tildeles
                while (patientsdoctors.Count < amountOfDoctors)
                {
                    //if statements tjekker om lægen allerede er tilføjet. hvis de er, vil en besked gives, og lægen tilføjes ikke
                    //her er parameteren for det tilfældige tal kun stort nok til at vælge en af lægerne
                    //1 = øjenlæge, 2 = Radiologi, 3 = Kirurgi,4=Onkologi
                    rndText = rnd.Next(1, 5).ToString();
                    Debug.WriteLine(rndText);
                    Thread.Sleep(500);
                    switch (rndText)
                    {
                        case "1":
                            if (patientsdoctors.Contains(DoctorList[0]))
                                System.Diagnostics.Debug.WriteLine("Denne læge er allerede tilføjet");
                            else
                            {
                                patientsdoctors.Add(DoctorList[0]);
                                Debug.WriteLine($"tilføjet {DoctorList[0].specialisation} læge");
                            }
                            break;

                        case "2":
                            if (patientsdoctors.Contains(DoctorList[1]))
                                System.Diagnostics.Debug.WriteLine("Denne læge er allerede tilføjet");
                            else
                            {
                                patientsdoctors.Add(DoctorList[1]);
                                Debug.WriteLine($"tilføjet {DoctorList[1].specialisation} læge");
                            }
                            break;

                        case "3":
                            if (patientsdoctors.Contains(DoctorList[2]))
                                System.Diagnostics.Debug.WriteLine("Denne læge er allerede tilføjet");
                            else
                            {
                                patientsdoctors.Add(DoctorList[2]);
                                Debug.WriteLine($"tilføjet {DoctorList[2].specialisation} læge");
                            }
                            break;

                        case "4":
                            if (patientsdoctors.Contains(DoctorList[3]))
                                System.Diagnostics.Debug.WriteLine("Denne læge er allerede tilføjet");
                            else
                            {
                                patientsdoctors.Add(DoctorList[3]);
                                Debug.WriteLine($"tilføjet {DoctorList[3].specialisation} læge");
                            }
                            break;

                        default:
                            System.Diagnostics.Debug.WriteLine("Valget skal være mellem 1 og 4");
                            break;
                    }
                    Thread.Sleep(2000);
                }
                #endregion

                //her tjekkes om listen af valgte læger er ok, før patienten bliver tilføjet. Mødes kravene ikke, bliver patienten ikke tilføjet
                if (PeopleCreation.ValidAssignedDoctorsCheck(patientsdoctors))
                {
                    Debug.WriteLine("Ny patient godtaget");
                    Patient newPatient = new(firstname, lastname, tlf, patientsdoctors);
                    patientList.Add(newPatient);
                }
                else
                    Debug.WriteLine("Listen af valgte læger møder ikke alle kravene. Ny patient nægtet");

                Thread.Sleep(3000);

                //loopet gentager sig indtil mindst 11 patienter er lavet
            } while (patientList.Count < 6);
        }
    }
}