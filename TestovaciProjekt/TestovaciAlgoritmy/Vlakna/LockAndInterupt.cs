using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.Vlakna
{
    public class LockAndInterupt
    {
        public void Vykonej()
        {

            Thread th1 = new Thread(() => { PomocnaTrida.UkazkaZamku2(); }); //tímto zápisem můžepe předávat funkci ve vlákně potřebné parametry   
            th1.Name = "sekundární vlákno";
            th1.Priority = ThreadPriority.Highest;//projevý se při více vláknech a více iteracích 
            th1.IsBackground = true;//pokud je vlákno na popředí pak se aplikace neukončí po stisknutí tlačítka
            th1.Start();
            


            //th1.Interrupt();// interup slouží k odblokování uspaného vlákna musí bít volána samozžejmě z jiného vlákna protože dotyčné vlákno je bloklé
                            //po násilném odblokování vyhodí vyjímku "ThreadInterruptedException". Pokud se zavolá metoda na nezablokované vlákno 
                            //pak se účinek teto metody pozdrží a jakmile dojde k zablokování tak ho odblokuje.

            Console.ReadKey();
        }
    }
  



    public class PomocnaTrida
    {
        static object zamek = new object(); // je v podstatě jedno co použiju jako zamek ale musí to být referenční proměnná        
        //LOCK 1
        public static void UkazkaZamku1()
        {
            int i = 0;
            Monitor.Enter(zamek);   //zamek 
            try
            {
                while (i < 1000)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    i++;
                }
            }
            finally
            {
                Monitor.Exit(zamek);     // odemiká zámek           
            }
        }


        //LOCK 2
        public static void UkazkaZamku2()
        {
            int i = 0;
            lock (zamek)
            {
                while (i < 3000)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    i++;
                }
            }
        }

        //INTERUPT  
        public static void UkazkaNasilneOdblokovani()
        {
            int i = 0;
            try
            {  
                while(i< 500)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " "+i );
                    i++;
                }
              Thread.Sleep(Timeout.Infinite);// uspí vlákno na nekonečně dlouho
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                while (i < 1000)//pokracování
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                    i++;
                }
            }

        }

    }
}
