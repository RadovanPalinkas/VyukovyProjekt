using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//DEF: třída by neměla používat interface, který nepoužívá. To znamená že pokud interface předepisuje nějaké metody které třída nebude implementovat tak by tato třída neměla 
//toto rozhraní implementovat
namespace TestovaciAlgoritmy.NavrhoveVzory.SOLID_Principles
{

    //příklad špatného řešení
    public interface IPracovnik
    {
        void Pracuj();
        void Spi();
    }

    public class LidskyPracovnik : IPracovnik
    {
        public void Pracuj()
        {
            Console.WriteLine("Pracuje......");
            Thread.Sleep(2000);
        }

        public void Spi()
        {
            Console.WriteLine("Spí......");
            Thread.Sleep(2000);            
        }
    }

    public class RobotiPracovnik : IPracovnik
    {
        public void Pracuj()
        {
            Console.WriteLine("Pracuje......");
            Thread.Sleep(2000);
        }

        public void Spi()
        {
            //nic(špatně)
        }

    }

    public class Manazer
    {
        public void Rozkaz(IPracovnik prac)
        {
            prac.Pracuj();
            prac.Spi();
        }

    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //Správné řešení- předešlý interface rozdělíme do více interfaců


    interface IWorkAble
    {
        void Pracuj();
    }
    interface ISleapAble
    {
        void Spi();
    }
    public interface IPracovnikTwo
    {
        void Rozkaz();
    }

    public class LidskyPracovnikTwo : IWorkAble, ISleapAble, IPracovnikTwo
    {
        public void Pracuj()
        {
            Console.WriteLine("Pracuje......");
            Thread.Sleep(2000);
        }

        public void Spi()
        {
            Console.WriteLine("Spí......");
            Thread.Sleep(2000);
        }
        public void Rozkaz()
        {
            Pracuj();
            Spi();
        }
    }

    public class RobotiPracovnikTwo : IWorkAble, IPracovnikTwo
    {
        public void Pracuj()
        {
            Console.WriteLine("Pracuje......");
            Thread.Sleep(2000);
        }
        public void Rozkaz()
        {
            Pracuj();
        }
    }

    public class ManazerTwo //manazer ovládá pracovníky 
    {
        public void Ovladej(IPracovnikTwo prac)
        {
            prac.Rozkaz();
        }
    }

}
