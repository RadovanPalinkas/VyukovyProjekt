using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.Atributy
{
    public class Atributy
    {
        //tato funkce je zastaralá
        [Obsolete("použij add(List<int> numbers) místo této třídy ")]
        public int add(int cislo1, int cislo2)
        {
            return cislo1 + cislo2;
        }

        //tato funkce je aktuální a chci aby byla používaná
        public int add(List<int> pole)
        {
            int vysledek = 0;

            foreach (int i in pole)
            {
                vysledek = vysledek + i;
            }

            return vysledek;
        }
    }
}
