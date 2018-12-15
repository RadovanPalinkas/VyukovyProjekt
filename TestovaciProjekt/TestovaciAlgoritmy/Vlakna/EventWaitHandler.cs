using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// AutoResetEvent - chová se jako turniket, nejprve metodou WaitOn() zablokujeme vlakno a pak čeká na zavolání metody Set(). Jedno zavolání této metody propustí jedno 
// vlákno.
namespace TestovaciAlgoritmy.Vlakna
{
    public class EventWaitHandlerTrida
    {
        static EventWaitHandle ewh = new AutoResetEvent(false);// instance objektu ..."true" by automaticky zavolalo funkci Set()

        public void VykonejAutoResetEvent()
        {
            Thread th = new Thread(() => UkazkaAutoResetEvent());
            Thread th2 = new Thread(() => UkazkaAutoResetEvent());
            th.Name = "prvni ";
            th2.Name = "druhe ";
            th.IsBackground = true;
            th2.IsBackground = true;
            th.Start();
            th2.Start();
            Thread.Sleep(5000);
            ewh.Set();//propustí vlákno které je zaseklé metodou WaitOne() 
            ewh.Set();//propustí další vlákno které je zaseklé metodou WaitOne() a čeká ve froně           

            Console.ReadKey();
        }

        void UkazkaAutoResetEvent()
        {
          
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine($"čeká   {Thread.CurrentThread.Name}.....{i}");
                i++;
            }
            ewh.WaitOne();// zasekne vlákno a čeká až bude zavoláno "Set()"
            while (i < 10)
            {
                Console.WriteLine($"Propuštěn   {Thread.CurrentThread.Name}...{i}");
                i++;
            }
        }
    }


}
