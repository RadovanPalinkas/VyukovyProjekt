using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class Fibonacci
    {
        static int predminule = 0;
        static int minule = 1;
        static int vysledek;

        public static void VykonejFibonacci(int poziceCislaVPosloupnosti)
        {

            for (int i = 0; i < poziceCislaVPosloupnosti; i++)
            {

                switch (i)
                {
                    case 0:
                        Console.WriteLine(predminule);
                        break;
                    case 1:
                        Console.WriteLine(minule);
                        break;
                    default:
                        vysledek = predminule + minule;

                        predminule = minule;
                        minule = vysledek;

                        Console.WriteLine(vysledek);
                        break;

                }
            }
        }
    }


   

}
