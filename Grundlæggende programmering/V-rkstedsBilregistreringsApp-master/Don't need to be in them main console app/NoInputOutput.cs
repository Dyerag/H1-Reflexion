using static VærkstedsBilregistreringsApp.ARF.ARF;

namespace VærkstedsBilregistreringsApp.Methods
{
    internal class no_inputOutput
    {
        public static bool NeedInspection(Car car, int type)
        {
            //denne if køres når biles registreringsdatoen skal tjekkes efter om der er gået fem år. i hvilket tilfælde er type 0
            if (type == 0)
                //hvis bilens registrerings dato+ 5 er større end nu, skal den ikke til syn.
                if (car.Registrydate.AddYears(5) >= DateTime.Now) return false;

            //denne if køres når der skal tjekkes om der er gået mere end to år siden sidste syn. I hvilket tilfælde er type 1
            if (type == 1)
                //if last inspection date + 2 is greater than present, no inspection required
                if (car.LastInspection.AddYears(2) >= DateTime.Now) return false;
            return true;
        }
        
        public static string IsCarDefect(Car car)
        {
            List<Car> DefectCarList = DefectiveCarsList();
            foreach (Car defectCar in DefectCarList)
            {
                if (car.Brand.ToUpper() == defectCar.Brand.ToUpper() && car.Model.ToUpper() == defectCar.Model.ToUpper() && car.Registrydate <= defectCar.Registrydate)
                    return defectCar.manufactoryError.ToString();
            }
            return null;
        }
    }
}
