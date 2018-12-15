using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    class NullableTypy
    {
        public void Vykonej()
        {
            int? cislo1 = null;
            int? cislo2 = null;

            //Možnost 1
            //Do promene vysledek nelze uložit NULL proto je potřeba zkontrolovat vstup aby my nevyskocila vyjimka.
            //V našem případě nejprve zkontrolujeme cislo1 jestli obsahuje NULL tak se vykoná kontrola cisla2 a pokud i toto objahuje NULL tak se přiřadí 0 
            int vysledek = cislo1 ?? cislo2 ?? 0;

            

            //Možnost 2
            if (cislo1.HasValue) // kontrola jestli i obsahuje hodnotu
            {
                 vysledek = (int)cislo1;
            }
            else
            {
                vysledek = 0; 
            }
        }
    }
}
