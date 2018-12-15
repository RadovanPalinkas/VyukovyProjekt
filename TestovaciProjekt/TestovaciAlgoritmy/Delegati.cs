using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{   //Delekát je v podstatě to samé jako event, používá se naprosto stějně, také se jedná o objekt uchovávající refernace na funkce.
    //Rozdíl event vs delegate
    //An Event declaration adds a layer of abstraction and protection on the delegate instance.This protection prevents clients of the
    //delegate from resetting the delegate and its invocation list and only allows adding or removing targets from the invocation list.

    public class Delegati
    {
        PoleDel pd = new PoleDel();

        public void UkazkaPraceSDelegaty()
        {
            pd.Pridej("ahoj");
        }

    }

    class PoleDel
    {
        public delegate void MujDelegat(object obj); //deklarace delegata
        public MujDelegat del;// existují dva způsoby jak delegátovi přiřadit funkci budto nezev v zavorce nebo přiřazení přez operator

        private ArrayList pole = new ArrayList(); // jenom pole do kterého budeme vkládat

        public void Pridej(object obj)
        {
            pole.Add(obj);

            del += TestovaciFCE.VypisInfo;
            del += TestovaciFCE.VypisInfoDalsi;
            del(obj);
        }
    }


    class TestovaciFCE
    {
        public static void VypisInfo(object obj)
        {
            Console.WriteLine("funkce 1" + " " + obj);
        }
        public static void VypisInfoDalsi(object obj)
        {
            Console.WriteLine("funkce 2" + " " + obj);
        }
    }

}
