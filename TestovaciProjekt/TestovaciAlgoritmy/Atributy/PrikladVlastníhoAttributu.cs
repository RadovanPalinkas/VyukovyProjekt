using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestovaciAlgoritmy.Atributy
{



    [Spolupracovnik(Jmeno ="Tomáš")]
    [Autor(Jmeno = "Martin", Verze = 1)]
    public class PrikladVlastníhoAttributu
    {
        [Dostupnost]
        public int Cislo { get; set; }

        [Dostupnost]
        public void MoujeMetoda()
        {
        }
        //způsob jak se k atributům dostat
        public void Vykone(PrikladVlastníhoAttributu pva)
        {            
            Type typ = pva.GetType();
            Attribute[] at = Attribute.GetCustomAttributes(typ);
            
            

            foreach (Attribute a in at)
            {
                if (a is Autor )
                {
                    Autor autor = (Autor)a;
                    Console.WriteLine("Toto je autor a verze: {0} {1}", autor.Jmeno,  autor.Verze);
                }
                else if (a is Spolupracovnik)
                {
                    Spolupracovnik autor = (Spolupracovnik)a;
                    Console.WriteLine("Toto je autor: {0} ", autor.Jmeno);
                }
              
            }

        }
    }
  

    //Příklad 1
    //attribut je v podstatě třída, toto je můj vlastní atribut u kterého je specifikováno pro kterou konstrukci je určen.(class,method,property)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    class Dostupnost : Attribute
    {
    }

    //Příklad 2
    //
    
    public class Autor : Attribute
    {
        public string Jmeno { get; set; }
        public int Verze { get; set; }
    }
    public class Spolupracovnik : Attribute
    {
        public string Jmeno { get; set; }
        
    }

}
