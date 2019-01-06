using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{

    //faktoriál pomocí rekurze
    public class Faktorial
    {

        public int VypocitejFaktorial(int c)
        {
            if (c == 1) return 1;

            return VypocitejFaktorial(c - 1) * c;
        }
    }
    //faktoriál pomocí ciklu
    public class FaktorialNoRek
    {
        public int VypocitejFaktorielNoRek(int c)
        {
            int vysledek = c;

            while (1 < c)
            {
                vysledek = vysledek * --c;
            }
            return vysledek;
        }
    }
}
