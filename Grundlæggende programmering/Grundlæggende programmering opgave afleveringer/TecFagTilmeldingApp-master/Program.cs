using TecFagTilmeldingApp.Model;
using TecFagTilmeldingAppDag2Opgave;

namespace TecFagTilmeldingAppDag2Opgave
{
    internal class Program
    {
        public static List<Course> courses = new();
        public static List<Teacher> teachers = new();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                SoundShenanigans.AudioAntics();
            }
            //while (true)
            //{
            //    Console.Write("Indtast tal 1 for at afspille lyden: ");
            //    string talinput = Console.ReadLine();
            //    if (talinput == "1")
            //    {
            //        string myCurrentDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
            //        string appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE Yodel Goofy.wav");

            //        System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            //        soundPlayer.SoundLocation = appDir;
            //        soundPlayer.Play();
            //    }
            //    else
            //    {
            //        Console.Clear();
            //    }
            //}
            //while (true)
            //{
            //    SoundShenanigans.AudioAntics();
            //    Console.Clear();
            //}
            List<Enrollment> enrolled = new();
            string control;
            TeachersAndCourses();
            do
            {
                Console.Clear();
                StudentList(enrolled);

                Pupil NewStudent = PersonligInfo();

                Courselist();
                int choice;

                do
                {
                    Console.Write("Angiv ID for det fag som elev skal tilmeldes: ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                        choice = courses.Count + 1;
                } while (choice > courses.Count);
                
                Enrollment addition = new(NewStudent, courses[choice - 1]);
                addition.Student = NewStudent; addition.Course = courses[choice - 1];
                enrolled.Add(addition);

                Console.WriteLine($"\n{addition.Student.PersonalInfo.Firstname} {addition.Student.PersonalInfo.Lastname} er nu tilmeldt {addition.Course.Name}");

                Console.WriteLine("\nTilmeld ny elev [J/N]: ");
                do control = Console.ReadKey().KeyChar.ToString().ToUpper();
                while (control != "J" && control != "N");
            } while (control == "J");
        }

        static void TeachersAndCourses()
        {
            DateTime birthdate = new DateTime(1971, 2, 23);
            Teacher niels = new("Niels", "Olesen", birthdate, "CIT");
            Teacher henrik = new("Henrik", "Paulsen", new DateTime(1987, 6, 21), "CIT");
            Teacher jack = new("Jack", "Baltzer", new DateTime(1949, 9, 30), "CIT");
            Teacher bo = new("Bo", "Elbæk", new DateTime(1999, 2, 16), "CIT");

            Course oop = new("OOP", niels.PersonalInfo);
            Course grundprog = new("Grundlæggendeprogrammering", niels.PersonalInfo);
            Course studieteknik = new("Studieteknik", niels.PersonalInfo);
            Course netværk = new("Netværk", henrik.PersonalInfo);
            Course Clientside = new("Clientside programmering", jack.PersonalInfo);
            Course database = new("Database programmering", jack.PersonalInfo);
            Course computer = new("Computerteknologi", bo.PersonalInfo);

            courses.Add(oop);
            courses.Add(grundprog);
            courses.Add(studieteknik);
            courses.Add(netværk);
            courses.Add(Clientside);
            courses.Add(database);
            courses.Add(computer);

        }

        public static Pupil PersonligInfo()
        {

            Console.Write("\n Angiv elev fornavn: ");
            string firstname = Console.ReadLine();

            Console.Write("Angiv elev efternavn: ");
            string lastname = Console.ReadLine();

            DateTime birthday;

            do Console.Write("Angiv elev fødselsdato: ");
            while (!DateTime.TryParse(Console.ReadLine(), out birthday));

            Pupil student = new(firstname, lastname, birthday);
            return student;

        }
        internal static void Courselist()
        {
            Console.WriteLine();
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"Fag id {i + 1}, fag navn: {courses[i].Name}");
            }
        }
        public static void StudentList(List<Enrollment> enrolled)
        {

            if (enrolled.Count <= 0)
                Console.WriteLine("Ingen elever tilmeldt endnu");
            else
            {
                for (int i = 0; i < enrolled.Count; i++)
                {
                    Console.WriteLine($"{enrolled[i].Student.PersonalInfo.Firstname} {enrolled[i].Student.PersonalInfo.Lastname} ({enrolled[i].Student.Age} år gammel) er tilmeldt {enrolled[i].Course.Name}");
                }
            }
            return;
        }
    }
}