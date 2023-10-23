using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace BilSyn
{
    internal class Program
    {
        //static Person[] people = new Person[10];
        //static List<Person> peopleList = new List<Person>();
        static List<Car> carList = new List<Car>();
        static List<Car> DefectCarList = new List<Car>();
        static Random random = new Random();

        static void Main(string[] args)
        {
            while (true) { Menu(); }

        }

        //static void ShowPeople()
        //{
        //    foreach (Person person in people)
        //    {
        //        if (person == null) continue;
        //        Console.WriteLine("Navn: " + person.Firstname);
        //    }
        //}

        //static void AddToArray(Person Person)
        //{
        //    for (int i = 0; i < people.Length; i++)
        //    {
        //        if (people[i] == null)
        //        {
        //            people[i] = Person;
        //            return;
        //        }
        //    }

        //}

        //static void ExpandArray()
        //{
        //    Person[] Temp = new Person[people.Length + 1];
        //    people.CopyTo(Temp, 0);
        //    people = Temp;
        //}

        //static void addToList(Person person)
        //{
        //    peopleList.Add(person);
        //}

        //todo search funktion

        static void ShowCars()
        {
            Console.WriteLine("*** List of cars ***");
            foreach (Car car in carList)
            {
                ShowCar(car);
            }
        }

        static void ShowCar(Car car)
        {
            Console.WriteLine($"\ncar: {car.Brand} {car.Model} \tLicenseplate: {car.Licenseplate}");
            Console.WriteLine($"RegDate: {car.DateofRegistration.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern)} Last inspection {car.LastInspection}");

        }

        static Car CreateCar()
        {
            Console.WriteLine("\n***Create Car menu***\n");

            Car car = new Car();
            car.DateofRegistration = Randomday(1990);
            car.ModelYear = car.DateofRegistration.Year - random.Next(2);
            //car.LastInspection = car.ModelYear - Randomday();
            car.Licenseplate = GenerateRandomLicensePlate();
            //car.LastInspection = random;
            Console.Write("Brand: ");
            car.Brand = Console.ReadLine();
            Console.Write("Model: ");
            car.Model = Console.ReadLine();

            return car;
        }

        //todo if car is older than 5 years, last inspection shouldnt be more than 2 years
        //if car is not yet 5 years. forget about it;
        static bool NeedInspection(Car car)
        {
            //if car registration date+ 5 is greater than present, no inspection is required.
            if (car.DateofRegistration.AddYears(5) >= DateTime.Now) return false;
            //if last inspection date + 2 is greater than present, no inspection required
            if (car.LastInspection.AddYears(2) >= DateTime.Now) return false;
            return true;
        }


        static void Menu()
        {
            Console.WriteLine("\n*** Menu ***\n");
            Console.WriteLine("Select 1 for show all cars");
            Console.WriteLine("Select 2 for create car");
            Console.WriteLine("Select 3 for search car");
            Console.WriteLine("Select 4 for gen LP");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    ShowCars();
                    break;
                case ConsoleKey.D2:
                    SomethingCar();
                    break;
                case ConsoleKey.D3:
                    SearchCar();
                    break;

                case ConsoleKey.D4:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine(GenerateRandomLicensePlate());
                    }
                    break;
                default:
                    Console.WriteLine("Not understood");
                    break;
            }
        }

        private static void SomethingCar()
        {
            Car car = CreateCar();
            car.Owner = CreatePerson();
            carList.Add(car);
            car.Owner = owner;
            //variable  condition               True                False
            string str = NeedInspection(car) ? "bilen skal synes" : "Bilen skal Ikke synes";
            string? str2 = IsCarDefect(car);
            //if (str2 != ) Console.WriteLine(str);
        }

        static Person CreatePerson()
        {
            Console.WriteLine("Create Customer Menu ***");

            Person person = new Person();
            Console.Write("Firstname: ");
            person.Firstname = Console.ReadLine();
            Console.Write("Lastname: ");
            person.Lastname = Console.ReadLine();
            Console.Write("Telephone number: ");
            person.PhoneNumber = Console.ReadLine();
            return person;
        }

        static DateTime Randomday(int year)
        {
            DateTime Start = new DateTime(year, 1, 1);
            int range = (DateTime.Today - Start).Days;
            return Start.AddDays(random.Next(range));
        }

        static string GenerateRandomLicensePlate()
        {
            //65- 90 ascii letters
            char a1 = (char)(random.Next(25) + 65);
            char a2 = (char)(random.Next(25) + 65);
            string b = random.Next(100).ToString("00");
            string c = random.Next(100).ToString("000");

            return a1.ToString() + a2.ToString() + " " + b + " " + c;
        }

        static string IsCarDefect(Car car)
        {
            foreach (Car defectCar in DefectCarList)
            {
                if (car.Brand == defectCar.Brand && car.Model == defectCar.Model && car.ModelYear <= defectCar.ModelYear)
                    return DefectCarList.ToString();
            }
            return null;
        }

        static void DefectCars()
        {
            Car car1 = new Car() { Brand = "Alfa Romeo", Model = "Giulia", ModelYear = 2010, ManufacturingDefects = "Hjulende er firkantet" };
            Car car2 = new Car() { Brand = "Lamborghini", Model = "Countach", ModelYear = 1986, ManufacturingDefects = "poor wiper" };
            DefectCarList.Add(car1);
            DefectCarList.Add(car2);

        }
        private static void SearchCar()
        {
            Console.WriteLine("Søg på nummberplade: ");
            string input = Console.ReadLine();

            foreach (var car in carList)
            {
                if (input == car.Licenseplate)
                {
                    ShowCar(car);
                }
            }

            static void ShowCustomer(Person Owner)
            {
                Console.WriteLine($"\nOwner: {Owner.Firstname} {Owner.Lastname} \tPhone number: {Owner.PhoneNumber}");

            }
        }
    }
}