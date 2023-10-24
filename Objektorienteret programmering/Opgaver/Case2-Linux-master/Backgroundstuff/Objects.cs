global using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    /// <summary>
    /// den abstrakte klasse som Doctor og patient klassen arver fra
    /// </summary>
    public abstract class Person
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int phoneNumber { get; set; }

        public Person(string Firstname, string Lastname, int PhoneNumber)
        {
            firstname = Firstname;
            lastname = Lastname;
            phoneNumber = PhoneNumber;
        }
    }

    /// <summary>
    /// Klassen der skaber læge objektet. udover at arve fra Person, indeholder den også specialiseringen af lægerne, såvel som antallet af deres patienter 
    /// </summary>
    public class Doctor : Person
    {
        public string specialisation { get; set; }
        public int totalPatients { get;set; }
        public Doctor(string Firstname, string Lastname, string Specialisation, int PhoneNumber) : base(Firstname, Lastname, PhoneNumber)
        {
            specialisation = Specialisation;
        }
    }

    /// <summary>
    /// Klassen til skabelsen af patient objekter. Udover at arve fra Person, indeholder den også en liste af læger som en patient har.
    /// </summary>
    public class Patient : Person
    {
        public List<Doctor> assignedDoctors = new();
        public Patient(string Firstname, string Lastname, int PhoneNumber, List<Doctor> AssignedDoctors) : base(Firstname, Lastname, PhoneNumber)
        {
            assignedDoctors.AddRange(AssignedDoctors);
        }
    }
}
