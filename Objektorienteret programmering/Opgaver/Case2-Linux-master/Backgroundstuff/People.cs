using System;
using Case2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Linq.Expressions;

namespace People
{
    public class PeopleCreation
    {
        public static void Employees()
        {
            Doctor peter = new("Peter", "Hansen", "Øjenlæge", 11111111);
            Doctor martin = new("Martin", "Jensen", "Radiologi", 22222222);
            Doctor thomas = new("Thomas", "Olsen", "Kirurgi", 33333333);
            Doctor ole = new("Ole", "Nielsen", "Onkologi", 44444444);
            Program.DoctorList.Add(peter);
            Program.DoctorList.Add(martin);
            Program.DoctorList.Add(thomas);
            Program.DoctorList.Add(ole);
        }
        //todo make sure an exception is thrown when attempting to assign both the surgeon(kirugis) and the oncology(onkologi) to the same person
        //todo have an exception thrown when adding a new patient would result in the doctor have 3 or more patients
        public static bool ValidAssignedDoctorsCheck(List<Doctor> patientsDoctors)
        {
            bool Onkologi = false, Kirurgi = false;

            try
            {
                //Går igennem listen af valgte læger og tjekker om den indeholder både onkologi og kirurgi
                for (int i = 0; i < patientsDoctors.Count; i++)
                {
                    if (patientsDoctors[i].specialisation == "Onkologi") { Onkologi = true; }
                    if (patientsDoctors[i].specialisation == "Kirurgi") { Kirurgi = true; }
                }
                //Blev både onkologi og kirurgi fundet, går den ind i if statementet og smider en exception
                if (Onkologi == true && Kirurgi == true)
                {
                    //teksten i parameteren er besked om hvilken exception the var
                    throw new Exception("En patient må ikke være tildelt både Onkologi og Kirurgi lægerne");
                }

                //Loopet her tjekker om antallet af patienter de valgte læger har ville overskrede 3, hvis den nye blev tilføjet 
                foreach (Doctor assignedDoc in patientsDoctors)
                {
                    if (assignedDoc.totalPatients + 1 > 3)
                        //Ville tilføjelsen overskrede 3, smides en exception
                        throw new Exception($"En eller flere af lægerne har allerede 3 patienter");
                    //Bliver maksimalet ikke overskredet, stiger antallet af patienter
                    else
                        assignedDoc.totalPatients++;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Thread.Sleep(8000);
                return false;
            }

            return true;
        }
    }
}