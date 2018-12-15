using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{    
    public class UkazkaPouzitiGenericity
    {
        public void vykonejPole(params int [] pole )
        {
            Genericita<int[]> gener = new Genericita<int[]>(pole) ; // vytvořim instanci 

            foreach (int i in gener.Ziskej()) // projdu a vypíšu pole
            {
                Console.WriteLine(i);
            }
        }
    }

    // takto vytvořenou třídu použiji pokud nevím jaký typ proměnné budu zpracovávat
    internal class Genericita<K>
    {
        public K cokoli; // do takto generické proměnné je možné uložit v podstatě cokoliv

        public Genericita(K cokoli)
        {
            this.cokoli = cokoli;
        }

        public K Ziskej()
        {
            return cokoli;
        }

    }
}
