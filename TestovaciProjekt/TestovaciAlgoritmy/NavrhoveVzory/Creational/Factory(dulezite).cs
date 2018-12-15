using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.NavrhoveVzory.Creational
{

    public class Factory
    {
        public static Budova PostavBudovu(TypBudovy typBudovy)
        {
            switch (typBudovy)
            {
                case TypBudovy.Panelak:
                    return new Panelak();
                case TypBudovy.RodinnyDum:
                    return new RodinnyDum();
                default:
                    throw new Exception("Neznámý typ budovy");
            }
        }
    }

    public class RodinnyDum : Budova
    {
        public string Barva { get; set; } = "red";

        public RodinnyDum()
        {
        }
        public override int GetObvod()
        {
            return Sirka * Vyska;
        }
        public string ZiskejBarvu()
        {
            return Barva;
        }
    }

    public class Panelak : Budova
    {
        public int Vchody { get; set; } = 5;

        public Panelak()
        {
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

    public abstract class Budova
    {
        public int Sirka { get; set; }
        public int Vyska { get; set; }
        public int Obvod { get; set; }
        public abstract int GetObvod();
    }


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
