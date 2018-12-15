using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//jedná se o ternální operátor .. zkrácená podmínka ... dá se použít pouze při přiřazování hodnoty
namespace TestovaciAlgoritmy
{
    class ZkracenaPodminka
    {
        public int Rozhodni()
        {
            int a = 8;
            int b = (a == 8) ? 3 : 4; //pokud je a 8 pak se pod b přiřadí "3"
            return b;            
        }

    }
}
