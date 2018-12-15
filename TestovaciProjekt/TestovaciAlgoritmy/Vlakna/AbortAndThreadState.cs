using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Popis: Abort- je podobný metodě interupt, až na to že při zavolání na zablokované vlákno na to že dochází k vytvoření výjimky "TheadAbortException".
//      Hlavní rozdíl oprati Interupt je v tom, že pokud je zavoláno abort na nezablokované vlákno
//      vyhodí vyjimku hned a nečeká na zablokování.

//      ThredState- slouží k zjištění aktuálního stavu vlákna (tato třída je užitečná pro debuging, použití v programu se nedoporučuje)
namespace TestovaciAlgoritmy.Vlakna
{
    public class AbortAndThreadState
    {
        public void Vykonej()
        {
            Thread th2 = new Thread(() => PomocnaTridaTwo.UkazkaAbort());
            th2.Name = "Sekundarni Vlakno";
            th2.IsBackground = true;
            th2.Start();
            Thread.Sleep(2000);
            Console.WriteLine(th2.ThreadState);
            Thread.Sleep(2000);
            th2.Abort();
            Thread.Sleep(2000);
            Console.WriteLine(th2.ThreadState);

            Console.ReadKey();


        }
    }

    public class PomocnaTridaTwo
    {
        public static void UkazkaAbort()
        {
            int i = 0;
            try
            {

                while (i < 1000)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                    i++;
                }
                Thread.Sleep(Timeout.Infinite);

            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(Thread.CurrentThread.ThreadState);
            }
            finally
            {
                while (i < 2000)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                    i++;
                }
            }

        }


    }


}
