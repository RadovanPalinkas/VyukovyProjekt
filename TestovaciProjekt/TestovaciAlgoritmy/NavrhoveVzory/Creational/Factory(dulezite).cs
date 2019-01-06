using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.NavrhoveVzory.Creational
{

    public class Factory
    {
        //Funkce která vytvoří instanci danné třídy
        public static IBudova PostavBudovu(TypBudovy typBudovy)
        {
            switch (typBudovy)
            {
                case TypBudovy.Panelak:
                    return new Panelak(5, 5);
                case TypBudovy.RodinnyDum:
                    return new RodinnyDum(5,5);
                default:
                    throw new Exception("Neznámý typ budovy");
            }
        }
    }
    //Potomek 1
    public class RodinnyDum : IBudova
    {
        public int Sirka { get; set; }
        public int Vyska { get; set; }
        public int Obvod { get; set; }
        

        public RodinnyDum(int vyska,int sirka)
        {
            Vyska = vyska;
            Sirka = sirka;
           
        }
        public int ZiskejObvod()
        {
            return Sirka * Vyska;
        }
       
    }
    //Potomek 2
    public class Panelak : IBudova
    {
        public int Sirka { get; set; }
        public int Vyska { get; set; }
        public int Obvod { get; set; }     

        public Panelak(int vyska, int sirka)
        {
            Vyska = vyska;
            Sirka = sirka;           
        }
        public int ZiskejObvod()
        {
            return Sirka * Vyska;
        }
      
    }
    //Rodič
    public  interface IBudova
    {
         int Sirka { get; set; }
         int Vyska { get; set; }
         int Obvod { get; set; }
         int ZiskejObvod();
    }

    //Nezajímavé 
    public enum TypBudovy
    {
        RodinnyDum,
        Panelak
    }
  
}
