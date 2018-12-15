using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class VyctoveTypy
    {
        public void vykonej()
        {
            // přiřadí proměnné typ konstanty mého výčtového typu.
            var pes = MujVyctovyTyp.Pes;
            // porovnání konstant 
            if (pes == MujVyctovyTyp.Kocka)
            {
            }
            // do promene nazev uloží string s názvem výčtového typu tedy "Kocka"
            string nazev = Enum.GetName(typeof(MujVyctovyTyp), MujVyctovyTyp.Kocka);
            //namapuje MujVyctovyTyp na pole stringů
            string[] pole = Enum.GetNames(typeof(MujVyctovyTyp));
            foreach (string s in pole)
            {
                Console.WriteLine(s);
            }
            //vrací celé pole výčtových typů
            Array arr = Enum.GetValues(typeof(MujVyctovyTyp));
            //vrátí true nebo false pokud výčtový typ existuje
            bool bid = MujVyctovyTyp.IsDefined(typeof(MujVyctovyTyp), "Kralik");
            //zkontroluje jestli daný výčtový typ existuje a vrátí true nebo false a pokud ano uloží do proměnné nazev vyčtoveho typu
            //parametr true rike ze se bude ignorovat velikost posmen
            MujVyctovyTyp vysledek;
            bool btp = MujVyctovyTyp.TryParse("pes", true, out vysledek);
            //uloží do proměnné string s hodnoutou výčtového typu
            string sf = MujVyctovyTyp.Format(typeof(MujVyctovyTyp), MujVyctovyTyp.Pes, "d");
           
            Console.WriteLine(nazev);
        }

        //jedná se v podstatě o kolekci konstantant, enum vychází z třídy System.Enum
        public enum MujVyctovyTyp : uint //nastavení typu pro všechny hodnoty defaultně je nastaven "int"
        {
            // jedná se o konstanty s vlastní hodnotou
            NULL = 0, // null je zde protoře enum vrací defaultně vyčtový typ na nulté pozici
            Pes = 20,
            Kocka = 100,
            Kralik = 2,
            Veverka = 60,
            Ptak = 4,
            Ryba = 20
        }
    }
}
