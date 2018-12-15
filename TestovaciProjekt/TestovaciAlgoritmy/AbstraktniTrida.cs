using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    //je určená jako předpis pro dědění může obsahovat i implementaci avšak nemůžou být vytvářeny instance tudíž nelze implementovat konstruktor. 
    //může dědit z jiných tříd a může implementovat interface.
    public abstract class AbstraktniTrida
    {
        protected int a { get; set; }
       
        protected AbstraktniTrida()
        {
        }
       protected AbstraktniTrida(int cislo)
        {
            a = cislo;
        }
        public virtual void Nastav(int cisloA)
        {
            a = cisloA;
        }
        public virtual void Vypis()
        {
            Console.WriteLine(a);
        }
    }

    public class DedicAbstraktniTridy : AbstraktniTrida
    {
        private int b;

        public DedicAbstraktniTridy()
        {
        }
        public DedicAbstraktniTridy(int cislo) : base(cislo) //tento konstruktor použije impementaci z konstruktoru abstract. tridy
        {            
        }
        public DedicAbstraktniTridy(int cisloA, int cisloB) : this(cisloA) // this.() pošle proměnnou do předešlého konstruktoru a vykoná jeho logiku
        {
            this.b = cisloB;
        }
        public override void Nastav(int cisloA) // přepisování = polymorhismus
        {
            base.Nastav(cisloA + 2);            
        }
        public void Nastav(int cisloA, int cisloB) // přetěžování = polymorphismus
        {
            base.Nastav(cisloA);
            this.b = cisloB + 2;            
        }
        public override void Vypis()
        {
            base.Vypis() ;
            Console.WriteLine(b);
        }


    }

}
