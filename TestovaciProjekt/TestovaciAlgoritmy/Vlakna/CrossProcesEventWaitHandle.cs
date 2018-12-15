using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//toto je ukázka jak se mohou vlákna ovlivňovat navzájem(pro zjijštění jak to funguje umísti dva debug pointy... jeden do funkce Pracuje a druhý do funkce vykonej)
//te to docela maglajs
namespace TestovaciAlgoritmy.Vlakna
{
    public static class CrossProcesEventWaitHandle
    {
        static EventWaitHandle pripraven = new AutoResetEvent(false);//první turniket je pokaždé odblokován v metodě "Pracuje()"
        static EventWaitHandle makej = new AutoResetEvent(false);//druhý turniket je pokaždé odblokován v metodě "Vykonej()"
        static volatile string ukol;

        public static void Vykonej()
        {
            new Thread(Pracuje).Start();

            for (int i = 1; i<=5;i++)
            {
                pripraven.WaitOne();             
                ukol = "ahoj".PadRight(i, 'h'); //tato funkce je jen pro ilustraci, prostě přidá k řetězci tolik "h" aby měl řetězec délku "i"
                makej.Set();
            }

            pripraven.WaitOne();
            ukol = null;    //ukol se nastaví null aby se vyplo vlákno v které zpracovává funkci "Pracuje()"
            makej.Set();          
        }

        public static void Pracuje()
        {
            Thread.CurrentThread.Name = "druhe";

            int c = 0;
            while (true)
            {
                pripraven.Set();       
                makej.WaitOne();
                if (ukol == null) return; //vyskočí z funkce a tím ukončí vlákno
                Console.WriteLine(ukol);
                c++;
            }

        }
    }
}
