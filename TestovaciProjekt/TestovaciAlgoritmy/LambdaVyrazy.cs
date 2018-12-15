using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Pokud je ve vstupním parametru funkce nějaký delegát, pak je možné do něj vkládat lambda výrazy nebo anonymní funkce, se specifickým tvarem.
//níže je uveden totožný zápis lambda a anonymní funkce se stejnou funkcionalitou.

namespace TestovaciAlgoritmy
{


    public class LambdaVyrazy
    {


        public void Vypis(int par1, int par2)
        {   //Lambda
            int vysledekLambda = UkazkovaTrida.TestFunkce(par1, par2,(cislo1, cislo2) => cislo1 + cislo2 );
            //Anonymní Funkce
            int vysledekAnonymniFunkce = UkazkovaTrida.TestFunkce(par1, par2, delegate (int cislo1,int cislo2) { return cislo1 + cislo2; });
    

            Console.WriteLine(vysledekLambda);
            Console.ReadKey();
        }
    }

    public static class UkazkovaTrida
    {
        public delegate int MujDelegat(int c1, int c2);

        public static int TestFunkce(int cislo1, int cislo2, MujDelegat del) // funkce zde má delegáta jako vstupní parametr... všude tam  kde je delegát parametr můžu vkládat funkce.
        {
            return del(cislo1, cislo2);
        }
    }

}
