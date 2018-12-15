using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{




    public static class RozsirovaniSealedObjektu
    {
        public static void vykonej()
        {
            SealedTridy st = new SealedTridy();
            st.Rozsir(2);
        }

        //tato funkce rozšíří třídu
        public static void Rozsir(this SealedTridy st, int cislo) //důležité je klíčové slovo this
        {
           st.Cislo = st.Cislo + cislo; 
        }
    }


    //tída kterou chceme rozšiřovat
    public sealed class SealedTridy 
    {
        public int Cislo { get; set; } = 2;
    }
}
