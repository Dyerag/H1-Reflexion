global using TecFagTilmeldingApp.CustomeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecFagTilmeldingApp.Model;

namespace TecFagTilmeldingApp.CustomeTypes
{

    public class Teacher : Person
    {
        public string? Department { get; set; }
        public Teacher(string? firstname, string? lastname, DateTime birthday, string? department) : base(firstname, lastname, birthday)
        {
            Department = department;
            string fullname = ShowFullName();
            string defaultInfo = ShowAllInfo2();
        }

        public override List<string> GetInfo(List<Enrollment> enrolled)
        {
            List<Enrollment> TeacherCourses = new();
            List<string> coursesWithStudents = new();
            foreach (Enrollment enrollment in enrolled)
            {
                if (enrollment.Course.Teacher.Firstname == PersonalInfo.Firstname && enrollment.Course.Teacher.Lastname == PersonalInfo.Lastname)
                {
                    TeacherCourses.Add(enrollment);
                }
            }

            for (int i = 0; i < TeacherCourses.Count; i++)
            {
                if (TeacherCourses[i].Student != null)
                {
                    coursesWithStudents.Add(TeacherCourses[i].Course.Name);
                }
            }

            return coursesWithStudents;
        }
        /// <summary>
        /// Oprindlig metode ligger i base klassen og er en abstrakt metode.
        /// </summary>
        /// <returns></returns>
        protected internal override string ShowAllInfo()
        {
            return $"{PersonalInfo.Firstname} {PersonalInfo.Lastname}, department {Department}";
        }

        /// <summary>
        /// Oprindlig metode ligger i base klassen og er en virtual metode.
        /// </summary>
        /// <returns></returns>
        protected override string ShowAllInfo2()
        {
            return $"{PersonalInfo.Firstname} {PersonalInfo.Lastname}, department {Department}";
        }

    }
    public class Pupil : Person
    {
        public Pupil(string? firstname, string? lastname, DateTime birthday) : base(firstname, lastname, birthday)
        {
            string defaultInfo = ShowFullName();
        }

        public override List<string> GetInfo(List<Enrollment> enrolled)
        {
            List<string> courseList = new();
            foreach (Enrollment count in enrolled)
            {
                if (count.Student.PersonalInfo.Firstname == PersonalInfo.Firstname && count.Student.PersonalInfo.Lastname == PersonalInfo.Lastname)
                {
                    courseList.Add(count.Course.Name);
                }
            }
            return courseList;
        }

        protected internal override string ShowAllInfo()
        {
            return $"{PersonalInfo.Firstname} {PersonalInfo.Lastname}";
        }
    }
    public class Course
    {
        public string? Name { get; set; }
        public PersonModel? Teacher { get; set; }
        public Course(string? name, PersonModel? teacher)
        {
            Name = name;
            Teacher = teacher;
        }
    }


}