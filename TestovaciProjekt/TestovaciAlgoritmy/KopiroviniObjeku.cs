using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{   // kopirování objeků (mělká kopie) se musí provádět pomocí dále uvedené funkce protože jinak nic nekopírujeme ale pouze měníme referenci  
    class KopiroviniObjeku
    {
        public void vykonej()
        {
            //Vzorový priklad
            TridaVzor t1 = new TridaVzor { a = 2 };
            TridaVzor t2;
            
            //špatně .... pouze se přehodí reference
            t2 = t1;
            //vykonej mělkou kopii
            t2 = t1.KopirujMelce();
            //vykonej hloubokovou kopii (správně)
            t2 = t1.KopirujHloubkove();
        }
    }

    class TridaVzor
    {
        public int a { get; set; }
        public B b = new B();

        //(mělká kopie)
        public TridaVzor KopirujMelce()
        {   // base ukazuje na "objek" protože "class" je odvozeno z "object" a uvedená funkce nám danou třídu zkopíruje a převede pomocí "as" na typ "TridaVzor"
            return this.MemberwiseClone() as TridaVzor;
        }
        //(hloubková kopie)
        public TridaVzor KopirujHloubkove()
        {   //funguje to tak že je potřeba vše udělat ručně ... nejprve si v této funkci vytvoříme novou instanci třídy a následně do ní překopírujeme
            //všechna data ze naší instance této třídy.
            TridaVzor trV = new TridaVzor();
            trV = this.MemberwiseClone() as TridaVzor;
            trV.b = new B() { cislo = this.b.cislo };
            return trV;
        }
    }

    class B
    {
        public int cislo = 2;
    }

}
