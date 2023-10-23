global using TecFagTilmeldingApp.CustomeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TecFagTilmeldingApp.Model;

namespace TecFagTilmeldingApp.CustomeTypes
{
    public abstract class Person
    {
        public PersonModel PersonalInfo { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public Person(string? firstname, string? lastname, DateTime birthday)
        {
            PersonalInfo = new PersonModel() { Firstname = firstname, Lastname = lastname };
            Birthday = birthday;
            Age = new AgeCalculator(birthday).Age;
        }

        public abstract List<string> GetInfo(List<Enrollment> enrolled);

        protected internal string ShowFullName()
        {
            return $"{PersonalInfo.Firstname} {PersonalInfo.Lastname}";
        }

        protected internal abstract string ShowAllInfo();

        protected virtual string ShowAllInfo2()
        {
            return $"{PersonalInfo.Firstname} {PersonalInfo.Lastname}";
        }

    }
    public class Enrollment
    {
        public Pupil? Student { get; set; }
        public Course? Course { get; set; }
        public Enrollment(Pupil? student, Course? course)
        {
            student = Student;
            course = Course;
        }
    }
}