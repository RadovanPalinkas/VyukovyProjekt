using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    // první postup 
    public class LINQtoOject
    {
        static int[] poleIntu = new int[9] { 0, 2, 2, 2, 2, 2, 3, 3, 3 };
        static string[] poleStringu = new string[5] { "Martin", "Mara", "Petr", "Tomas", "Honza" };

        //funkce která vypíše pole intů
        public static void VypisPoleInstuLINQ()
        {
            IEnumerable<int> vysledek = poleIntu.Where(i => i < 3).OrderByDescending(i => i);

            foreach (int a in vysledek)
            {
                Console.WriteLine(a);
            }
        }
        //funkce která vypíše pole stringů
        public static void VypisPoleStringuLINQ()
        {
            IEnumerable<string> vysledek = poleStringu.Where(s => s == "Martin").Select(s => s.ToUpper());

            foreach (string a in vysledek)
            {
                Console.WriteLine(a);
            }
        }
    }
    // druhý a lepší postup---------------------------------------------------------------------------------------------------------------------------------
    public class ZamestnanecLINQ
    {
        public int id { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public int plat { get; set; }

        public  static List<ZamestnanecLINQ> kolekce()
        {
            List<ZamestnanecLINQ> zam = new List<ZamestnanecLINQ>()
            {   
            new ZamestnanecLINQ {id = 1, jmeno = "Martin", prijmeni= "Neuuman", plat=50},
            new ZamestnanecLINQ {id = 2, jmeno = "Radovan", prijmeni= "Palinkáš", plat=50},
            new ZamestnanecLINQ {id = 3, jmeno = "Honza", prijmeni= "Zeman", plat=50},
            new ZamestnanecLINQ {id = 4, jmeno = "Ruda", prijmeni= "Bláha", plat=50},
            new ZamestnanecLINQ {id = 5, jmeno = "Franta", prijmeni= "Neuuman", plat=50}
            };
            return zam;
        }
        
        public  void VypisKolekci()
        {
            List<ZamestnanecLINQ> kolekce = ZamestnanecLINQ.kolekce();

            var vysledek = from z in kolekce where z.id == 1  select z.jmeno +" "+ z.prijmeni; // vyber z kolekce jméno a příjmení jehož id == 1
                        
            foreach (string a in vysledek)
            {
                Console.WriteLine(a);               
            }
        }
    }

  
}
