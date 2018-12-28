using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;

//aby funkce běžela asynchronně je potřeba funkci označit modifikátorem async dále pak vytvořit ulohu Task (podobné vláknu) dále pak zavolat 

namespace TestovaciAlgoritmy.Vlakna
{
    //Příklad 1 základní použití 
    public class AsyncAwait
    {
        public async Task<int> Vykonej()
        {
            Console.WriteLine("čekám na zpracování tasku.....");
            Task<int> task = new Task<int>(NactiVypisSoubor);
            task.Start();
            int vysledek = await task; //await počká na výsledek "task"
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

    //příklad 2
    public class Worker
    {   //pole se seznamem stránek které budeme chtít načíst
        private List<string> PrepData = new List<string>()
            {
            "https://www.seznam.cz",
            "https://www.Idnes.cz",
            "https://coinmarketcap.com",
            "https://www.upc.cz",
            "https://www.gomobil.cz",
            "https://ib.fio.cz/ib/login",
            "https://www.equabanking.cz/IBS/",
        };
        //Asynchroní funkce 1, v podstatě pouze uvolňuje hlavní vlákno.
        public async Task RunDownloadAsync()
        {
            Stopwatch watch = Stopwatch.StartNew();
            foreach (string site in PrepData)
            {
                WebsiteDataModel result = await Task.Run(() => DownloadWebsite(site));
                Console.WriteLine($"{result.WebsiteUrl} : {result.websiteData.Length}");
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
        //Asynchrnoní funkce 2, uvolňuje hlavní vlákno a ještě zvyšuje rychlost. protože táske běží paralerně a né sériově.
        public async Task RunDownloadParalerAsync()
        {
            Stopwatch watch = Stopwatch.StartNew();

            List <Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in PrepData)
            {
               tasks.Add( Task.Run(() => DownloadWebsite(site))); //rozpracované tásky jsou uloženy v seznamu a čeká se než ubdou všechnz dokončeny
               
            }
            WebsiteDataModel[] result = await Task.WhenAll(tasks);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.WebsiteUrl} : {item.websiteData.Length}");
            }           
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        //funkce která bude vykonávána v tásku, tuto funkci je možné přepsat tak, že použijeme DownloadStringAsync() ale je to v podstatě to samé jako vztvoření vlastního tásku
        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            output.WebsiteUrl = websiteURL;
            output.websiteData = client.DownloadString(websiteURL);
            return output;
        }
    }

    public class WebsiteDataModel
    {
        public string WebsiteUrl { get; set; } = "";
        public string websiteData { get; set; } = "";
    }
}













