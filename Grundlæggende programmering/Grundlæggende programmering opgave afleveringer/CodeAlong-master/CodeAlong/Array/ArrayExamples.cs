using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlong.Array
{
    internal class ArrayExamples
    {
        public void SetSimpleArray()
        {
            string[] bilmærker = new string[4] { "Fiat", "Toyota", "Kia", "" };

            Console.WriteLine(bilmærker[1]);

            foreach(string item in bilmærker)
            {
                Console.WriteLine(bilmærker[1]);
            }

            //List
            List<string> lstBilmærker = new List<string>() { "Fiat", "Toyota", "Kia" };
            foreach (string item in lstBilmærker)
            {
                Console.WriteLine($"fra List: {item}");
            }
        }
        public void SetObjectArray()
        {
            object[] FiatPunto = new object[] { "Fiat Punto", new DateTime(2010, 1, 1), "udstødning" };
            object[] AlfaRomeo = new object[] { "Alfa Romeo Giulia", new DateTime(2019, 8, 1), "Styretøj" };

            object[] tilbagekaldteBiler = new object[] {FiatPunto, AlfaRomeo};

            object[] minalfaudtræk = (object[])tilbagekaldteBiler[1];
            DateTime alfaRomeoÅrgang = (DateTime)minalfaudtræk[1];
            string mdrNavn = alfaRomeoÅrgang.ToString("MM");
            
            Console.WriteLine(mdrNavn);

            foreach(object[] array in FiatPunto)
            {
                object[] bil = (object[])array;
                foreach (string item in bil)
                    Console.WriteLine($"{item.ToString()}");
            }

            List<object> lstFiatPunto = new List<object>()
            {
                "Fiat Punto",
                new DateTime (2010, 1, 1),
                "Udstødning"

            };
            List<object> lstAlfaRomeo= new List<object>()
            {
                "Alfa Romeo Giulia",
                new DateTime (2019, 8, 1),
                "Styretøj"

            };

            List<List<object>> lstTilbagekaldteBiler = new List<List<object>>()
            {
                lstFiatPunto,
                lstAlfaRomeo
            };

            foreach(object lst in lstTilbagekaldteBiler)
            {
                //List<object> bil = new List<object>();
            }
        }
        public void SetMultiDemArray()
        {

            string[,] TilbagekaldteBiler = new string[2, 3]
            {
                 {"Fiat Punto", "2010, 1, 1", "udstødning"},
                 { "Alfa Romeo Giulia", "2019, 8, 1", "Styretøj"}
            };

            string alfaRomeomÅrgang = TilbagekaldteBiler[1,1];
            DateTime dtAlfaRomeoÅrgang = Convert.ToDateTime(alfaRomeomÅrgang);
            string mdrAlfaRomeo = dtAlfaRomeoÅrgang.ToString("MMMM");

            Console.WriteLine($"{mdrAlfaRomeo}");

            int level0 = TilbagekaldteBiler.GetUpperBound(0);
            int level1 = TilbagekaldteBiler.GetUpperBound(1);
            for(int i = 0; i <= level0; i++)
            {
                for (int j = 0; j <= level1; j++)
                {
                    string? res = TilbagekaldteBiler[i, j].ToString();
                    Console.WriteLine(res);
                }
            }
        }
        public void SetJaggedArray()
        {
            
            string[] FiatPunto = new string[] { "Fiat Punto", "2010, 1, 1", "udstødning" };
            string[] AlfaRomeo = new string[] { "Alfa Romeo Giulia", "2019, 8, 1", "Styretøj" };

            string[][] tilbagekaldteBiler = new string[][]
            {
                 new string[] { "Fiat Punto","2010, 1, 1", "udstødning", "2" },
                 new string[] { "Alfa Romeo Giulia", "2019, 8, 1", "Styretøj" }
            };

            string alfaÅrgang = tilbagekaldteBiler[1][1];
            Console.WriteLine($"{alfaÅrgang}");

            foreach (string[] item0 in tilbagekaldteBiler)
            {
                string[] bil = item0;
                foreach(object item in bil)
                    Console.WriteLine($"{item}");
            }
        }
    }
    
}