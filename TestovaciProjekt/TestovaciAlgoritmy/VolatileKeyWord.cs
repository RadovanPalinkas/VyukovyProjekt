using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//Volatile- toto klíčové slovo se používá ve vícevláknových aplikacích pro synchronizování lokálních pamění vláken a hlavní paměti. Neprojevý se při Debugingu ale Releasu
namespace TestovaciAlgoritmy
{
    public class VolatileKeyWord
    {
        volatile bool ukazatel = true;
        public static void Vykonej()
        {


            VolatileKeyWord vkw = new VolatileKeyWord();
            Thread th = new Thread(() => PomocnaMetoda(vkw));
            th.Name = "sekundarni";
            th.Start();
            Thread.Sleep(20);
            vkw.ukazatel = false;
            Console.WriteLine("krok 2");


        }
        public static void PomocnaMetoda(object inst)
        {
            VolatileKeyWord vkw = (VolatileKeyWord)inst;
            
            Console.WriteLine("krok 1");
            while (vkw.ukazatel)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
            Console.WriteLine("krok 3");
            Console.ReadKey();
        }
    }


}
