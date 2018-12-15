using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

//aby funkce běžela asynchronně je potřeba funkci označit modifikátorem async dále pak vytvořit ulohu Task (podobné vláknu) dále pak zavolat 

namespace TestovaciAlgoritmy.Vlakna
{
    public class AsyncAwait
    {
        public void Vykonej()
        {
            Console.WriteLine("Starting");

            var worker = new Worker();
            worker.DoWork();

            while (!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
    public class Worker
    {
        public bool IsComplete { get; private set; }

        public async void DoWork()
        {
            this.IsComplete = false;
            Console.WriteLine("Doing Work");

            //bud se může jednat o tento task, nebo je možné vytvořit třídu která vrací třídu "Task"
            await Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Working!");
                        Thread.Sleep(2000);
                    });

            Console.WriteLine("Work completed");

            IsComplete = true;
        }
      

    }
    // příklad2 první je lepší
    public class Priklad2 
    {
        public async Task<int> VykonejTask()
        {
            Console.WriteLine("čekám na zpracování tasku.....");
            Task<int> task = new Task<int>(NactiVypisSoubor);
            task.Start();
            int vysledek = await task; //await počká na výsledek "task"
            return vysledek;
        }

        //použití thread
        public int VykonejVlakno()
        {
            int vysledek = 0;
            Console.WriteLine("čekám na zpracování vlakna.....");
            Thread th = new Thread(() => { vysledek = NactiVypisSoubor(); });// tímto zápisem přiřadím výstupní hodnotu funkce NactiVypisSoubor proměnné vysledek
            th.IsBackground = true;
            th.Start();
            th.Join();
            return vysledek;
        }

        int NactiVypisSoubor()
        {
            using (StreamReader sr = new StreamReader(@"D:\Programovani\C# projekty\TestovaciProjekt\TestovaciAlgoritmy\Vlakna\SouborProAsyncAwait.txt"))
            {
                string obsah = sr.ReadToEnd();
                Thread.Sleep(5000);
                int pocetZnaku = obsah.Count();
                return pocetZnaku;
            }
        }
    }


}
