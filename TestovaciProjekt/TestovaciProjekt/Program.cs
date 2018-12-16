using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestovaciAlgoritmy.Vlakna;
using TestovaciAlgoritmy;
using TestovaciAlgoritmy.NavrhoveVzory.Creational;
using TestovaciAlgoritmy.Atributy;
using System.Reflection;
using TestovaciAlgoritmy.NavrhoveVzory.SOLID_Principles;
using TestovaciAlgoritmy.Serializace;
using DataAccessTest;
using DataAccessTest.EntityFrameworkPriklady;
using DataAccessTest.EntityFrameworkPriklady.DatabasePrvni;
using DataAccessTest.EntityFrameworkPriklady.CodePrvni;
using System.Security.Cryptography;
using System.IO;

namespace TestovaciProjekt
{

 

    public class Program
    {

        public static void Main(string[] args)
        {

            ////FAKTORY----------------------------------------------------------------------------------------------------------------------------  

            //PaymentProcessor pp = new PaymentProcessor();
            //pp.MakePayment(PaymentMethod.BANK_ONE, new TestovaciAlgoritmy.NavrhoveVzory.Creational.Product() { Name="Kolo",Price=4,Description="Toto je moje nove kolo"});

            PaymentProcessor2 pp2 = new PaymentProcessor2();
            pp2.MakePayment(PaymentMethod.PAYPAL, new TestovaciAlgoritmy.NavrhoveVzory.Creational.Product() { Name = "Kolo", Price = 4, Description = "Toto je moje nove kolo" });

            //IBudova b = Factory.PostavBudovu(TypBudovy.RodinnyDum);            
            //Console.WriteLine(b.ZiskejObvod()); 
            Console.ReadKey();
            ////FAKTORY----------------------------------------------------------------------------------------------------------------------------  

            ////DOS ÚTOK----------------------------------------------------------------------------------------------------------------------------  
            //UtokDOS udos = new UtokDOS();
            //udos.VykonejDos2();
            //Console.ReadKey();
            ////DOS ÚTOK----------------------------------------------------------------------------------------------------------------------------  

            ////OPEN CLOSE----------------------------------------------------------------------------------------------------------------------------  
            //Client cl = new Client();
            //cl.Save(new List<IUpsertable>() { new DbService(), new AzureTableService() });
            ////OPEN CLOSE----------------------------------------------------------------------------------------------------------------------------  

            //REGULERNI VÝRAZY----------------------------------------------------------------------------------------------------------------------------  
            //RegulerniVyraz rv = new RegulerniVyraz();
            //rv.vykonej();

            //REGULERNI VÝRAZY----------------------------------------------------------------------------------------------------------------------------  

            ////OPENCLOSE----------------------------------------------------------------------------------------------------------------------------------           
            //OpenCloseSpravneV1 ocs = new OpenCloseSpravneV1();
            //ocs.PridejFunkci(new CheckHeslo());
            //ocs.VykonejCheck(new BagCheck("sentinel", "palinkas", 5));
            ////OPENCLOSE----------------------------------------------------------------------------------------------------------------------------------

            //Entity Framework--------------------------------------------------------------------------------------------------------------------------
            //DoClass dc = new DoClass();
            //dc.CreateTable();
            //Entity Framework--------------------------------------------------------------------------------------------------------------------------

            ////SERIALIZACE JSON--------------------------------------------------------------------------------------------------------------------------
            //SerializaceJSON sj = new SerializaceJSON();
            //sj.VykonejSerializaceJSON();
            //sj.VykonejDeserializaceJSON();
            ////SERIALIZACE JSON--------------------------------------------------------------------------------------------------------------------------

            ////SERIALIZACE BINARY--------------------------------------------------------------------------------------------------------------------------
            //SerializaceBinary sb = new SerializaceBinary();
            //sb.VykonejSerializaci();
            //sb.VykonejDeserializaci();
            ////SERIALIZACE BINARY--------------------------------------------------------------------------------------------------------------------------

            ////SERIALIZACE XML--------------------------------------------------------------------------------------------------------------------------
            //SerializaceXML saveXml = new SerializaceXML();
            //saveXml.Uloz(@"mujXML.xml", "Martin", "Palinkas", 5); //relativní cesta uložení do Debug\MojeSložka\MujXml.xml
            //SerializaceXML loadXml = SerializaceXML.LoadFromFile(@"mujXML.xml");
            //Console.WriteLine(loadXml.Jmeno);
            //Console.ReadKey();
            ////SERIALIZACE XML--------------------------------------------------------------------------------------------------------------------------

            ////VLÁKNA--------------------------------------------------------------------------------------------------------------------------
            //AsyncAwait aw = new AsyncAwait();
            //aw.Vykonej();


            //ProducentSpotrebitelAutoResetEvent psare = new ProducentSpotrebitelAutoResetEvent();
            //psare.Vykonej();

            //CrossProcesEventWaitHandle.Vykonej();
            //Console.ReadKey();

            //EventWaitHandlerTrida ewht = new EventWaitHandlerTrida();
            //ewht.VykonejAutoResetEvent();

            //AbortAndThreadState aats = new AbortAndThreadState();
            //aats.Vykonej();

            //LockAndInterupt lai = new LockAndInterupt();
            //lai.Vykonej();

            //Join j = new Join();
            //j.Vykone();
            //j.th.Join();
            //Console.ReadKey();
            ////VLÁKNA--------------------------------------------------------------------------------------------------------------------------

            ////VOLATILE--------------------------------------------------------------------------------------------------------------------------
            //VolatileKeyWord.Vykonej();
            ////VOLATILE--------------------------------------------------------------------------------------------------------------------------

            ////INTERFACE SEGREGATION------------------------------------------------------------------------------------------------------------            
            //ManazerTwo manaz = new ManazerTwo();
            //manaz.Ovladej(new RobotiPracovnikTwo());
            ////INTERFACE SEGREGATION------------------------------------------------------------------------------------------------------------

            ////OPEN CLOSE---------------------------------------------------------------------------------------------------------------------            
            //OpenCloseSpravne ocs = new OpenCloseSpravne();
            //ocs.PridejFunkci(new CheckHeslo());
            //ocs.PridejFunkci(new CheckJmeno());
            //ocs.PridejFunkci(new CheckData());
            //ocs.PridejFunkci(new CheckDatum());
            //ocs.VykonejCheck(new BagCheck("fsadf", "Petr", 3));
            ////OPEN CLOSE-----------------------------------------------------------------------------------------------------------------------

            ////POUZITI USING-----------------------------------------------------------------------------------------------------------------------
            //PouzitiUsing pu = new PouzitiUsing();
            //pu.Zapis();
            ////POUZITI USING-----------------------------------------------------------------------------------------------------------------------

            ////INDEXACE-----------------------------------------------------------------------------------------------------------------------
            //IndexaceTwo indexTwo = new IndexaceTwo();
            //indexTwo[5] = new IndexaceTwo();
            //indexTwo[5].Str = "ahoj";
            //foreach (IndexaceTwo i in indexTwo.poleTwo)
            //{
            //    if (i != null)
            //    {
            //        Console.WriteLine(i.Str);
            //    }
            //}

            //Indexace index = new Indexace();
            //index[5] = "ahoj";
            //foreach (string a in index.pole)
            //{
            //    Console.WriteLine(a);
            //}
            ////INDEXACE-----------------------------------------------------------------------------------------------------------------------

            ////ATTRIBUTY-----------------------------------------------------------------------------------------------------------------------
            //PrikladVlastníhoAttributu pva = new PrikladVlastníhoAttributu();
            //pva.Vykone(pva);

            //Atributy at = new Atributy();
            //at.add(6, 6); // protože je funkce opatřená attributem obsolete tak je podtržená zelenou vlnovkou po najení myši se vypíše že je "zastaralá" 
            //Console.WriteLine(at.add(new List<int>() { 2, 2, 6, 7, 4, 1, 1 }));
            ////ATTRIBUTY-----------------------------------------------------------------------------------------------------------------------

            ////DICTIONARY-----------------------------------------------------------------------------------------------------------------------
            //Slovnik sl = new Slovnik();
            //sl.Add();
            //sl.CheckKeyAndAdd("sedmi", new zakaznik() { jmeno = "Kuba", prijmeni = "Palinkas", plat = 30000 });
            //sl.Get();
            //Console.ReadKey();
            ////DICTIONARY-----------------------------------------------------------------------------------------------------------------------

            //LambdaVyrazy lv = new LambdaVyrazy();
            //lv.Vypis(5, 5);

            //ReflexeDatovychClenu.vykonej();
            //ReflaxeObjektu.vykonej();

            //FlagyABitoveOperatory fabo = new FlagyABitoveOperatory();
            //fabo.vykonejBitoveOperatory();
            //fabo.vykonejVyctoveTypyAFlagy();

            //VyctoveTypy vt = new VyctoveTypy();
            //vt.vykonej();

            //Eventy ev = new Eventy();
            //ev.Vykonej();

            //int plat = 500;
            //string vysledek = ((plat >= 1000) ? "velký" : "malý"); //zkrácený zápis podmínky
            //Console.WriteLine(vysledek);

            //Delegati del = new Delegati();
            //del.UkazkaPraceSDelegaty();

            //Struktura struc = new Struktura(12);
            //Console.WriteLine(struc.i);

            //DedicAbstraktniTridy dat = new DedicAbstraktniTridy();
            //dat.Nastav(3, 9);
            //dat.Vypis();

            //PristupMySQL pripojeniSql = new PristupMySQL();
            ////pripojeniSql.OpenMySQLExucuteSelectFromClovek("Radovan");
            //pripojeniSql.OpenMySQLExucuteUpdateForClovek("Radovan", "Martin");

            //UkazkaPouzitiGenericity ukazkaGener = new UkazkaPouzitiGenericity();
            //ukazkaGener.vykonejPole(new int[] { 5, 6, 4, 3, 0 });

            //LINQtoOject.VypisPoleInstuLINQ();
            //LINQtoOject.VypisPoleStringuLINQ();
            //ZamestnanecLINQ zLinq = new ZamestnanecLINQ();
            //zLinq.VypisKolekci();

            //FaktorialNoRek fnr = new FaktorialNoRek();
            //Console.WriteLine(fnr.VypocitejFaktorielNoRek(6));

            //Fibonacci.VykonejFibonacci(5);

            //UkazkaSingletonu us = new UkazkaSingletonu();
            //us.Vykonej();






        }
    }
}




