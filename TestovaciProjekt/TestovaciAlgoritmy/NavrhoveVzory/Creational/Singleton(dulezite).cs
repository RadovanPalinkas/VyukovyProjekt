using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.NavrhoveVzory.Creational
{

    public class UkazkaSingletonu
    {
        public void Vykonej()
        {
            Singleton a = Singleton.VytvorInstanciSingleton;
            foreach (string s in a.list)
            {
                Console.WriteLine(s);
            }
        }
    }


    //singleton nám umožní v jedné aplikaci vytvořit pouze jednu instanci která nelze měnit a lze pouze klonovat
    public sealed class Singleton
    {
        public readonly List<string> list = new List<string> { "nameDB", "root", "sentinel" };

        private static Singleton inst = null; //1) 
        private Singleton() { } //2) privátní konstruktor aby nešli vytvářet instance
        private static readonly object key = new object();

        public static Singleton VytvorInstanciSingleton
        {
            get //4) funkce porouze pro čtení
            {
                lock (key)
                {
                    if (inst == null) //5) ček jestli singleton již existuje 
                    {
                        inst = new Singleton();
                    }
                    return inst;
                }

            }
        }

    }
}
