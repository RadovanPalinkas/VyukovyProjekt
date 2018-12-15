using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.Vlakna
{
    public class ProducentSpotrebitelAutoResetEvent
    {
        public void Vykonej()
        {
            using(var q = new ProducerCustomeQueue())
            {
                q.ZaraditUkolDoFronty("ahoj");

                for(int i = 0; i < 10; i++)
                {
                    q.ZaraditUkolDoFronty("číslo " + i);
                }
                q.ZaraditUkolDoFronty("Nashle!");
            }
        }

    }

    class ProducerCustomeQueue : IDisposable
    {
        EventWaitHandle evh = new AutoResetEvent(false);
        Thread pracovneVlakno;
        object zamek = new object();
        Queue<string> ukoly = new Queue<string>();

        public ProducerCustomeQueue()
        {
            pracovneVlakno = new Thread(Pracuj);
            pracovneVlakno.Start();
        }
        public void ZaraditUkolDoFronty(string task)
        {
            lock (zamek) ukoly.Enqueue(task);
            evh.Set();

        }
        public void Dispose()
        {
            ZaraditUkolDoFronty(null);
            pracovneVlakno.Join();
            evh.Close();
        }

        void Pracuj()
        {
            while (true)
            {
                string ukol = null;
                lock (zamek)
                {
                    if (ukoly.Count > 0)
                    {
                        ukol = ukoly.Dequeue();
                        if (ukol == null) return;
                    }
                }
                if (ukol != null)
                {
                    Console.WriteLine("Provádím úkol : " + ukol);
                    Thread.Sleep(1000);
                }
                else
                {
                    evh.WaitOne();
                }
            }
        }
    }
}
