using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.NavrhoveVzory.Creational
{

    public class Factory
    {
        //Funkce která vytvoří instanci donné třídy
        public static Budova PostavBudovu(TypBudovy typBudovy)
        {
            switch (typBudovy)
            {
                case TypBudovy.Panelak:
                    return new Panelak(5, 5, 3 );
                case TypBudovy.RodinnyDum:
                    return new RodinnyDum(5,5,Barva.Black);
                default:
                    throw new Exception("Neznámý typ budovy");
            }
        }
    }
    //Potomek 1
    public class RodinnyDum : Budova
    {
        public Barva Barva { get; set; }

        public RodinnyDum(int vyska,int sirka, Barva barva)
        {
            Vyska = vyska;
            Sirka = sirka;
            Barva = barva;
        }
        public override int GetObvod()
        {
            return Sirka * Vyska;
        }
        public Barva ZiskejBarvu()
        {
            return Barva;
        }
    }
    //Potomek 2
    public class Panelak : Budova
    {
        public int Vchody { get; set; }

        public Panelak(int vyska, int sirka, int vchody)
        {
            Vyska = vyska;
            Sirka = sirka;
            Vchody = vchody;
        }
        public override int GetObvod()
        {
            return Sirka * Vyska;
        }
        public int ZiskejVchody()
        {
            return Vchody;
        }
    }
    //Rodič
    public abstract class Budova
    {
        public int Sirka { get; set; }
        public int Vyska { get; set; }
        private int Obvod { get; set; }
        public abstract int GetObvod();
    }

    //Nezajímavé 
    public enum TypBudovy
    {
        RodinnyDum,
        Panelak
    }
    public enum Barva
    {
        Red,
        Blue,
        Black,
        Yelow,
        Green
    }
}
