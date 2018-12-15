using System;
using System.Reflection; // je potřeba uvést referenci
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{

    //reflexe objeků
    public class ReflaxeObjektu
    {
        public static void vykonej()
        {
            ZkoumanaTrida zk = new ZkoumanaTrida(1, 2);
            ZkoumanaTrida f = new ZkoumanaTrida(1, 2);
            Type t = zk.GetType();            
            VypisInfo(t);
        }

        static void VypisInfo(Type t) // reflexe nám umožňuje zjistit metadate zkoumané třídy
        {
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.AssemblyQualifiedName);
            Console.WriteLine(t.BaseType.FullName);
            Console.WriteLine(t.IsValueType);
            Console.WriteLine(t.IsSealed);
            Console.WriteLine(t.IsPublic);
        }

    }


    // reflexe datových členů
    public class ReflexeDatovychClenu
    {
        public static void vykonej()
        {
            ZkoumanaTrida zk = new ZkoumanaTrida(1, 2);
            Type t = zk.GetType();
            VypisInfo(t);
        }

        static void VypisInfo(Type t)
        {

            //výčtový typ
            BindingFlags bf = BindingFlags.Public |BindingFlags.NonPublic| BindingFlags.Instance;            
            FieldInfo[] pole = t.GetFields(bf);

            foreach (FieldInfo fi in pole)
            {
                Console.WriteLine(fi.Name);
                Console.WriteLine(fi.FieldType);
                Console.WriteLine(fi.IsPrivate);
                Console.WriteLine(fi.IsStatic);
            }

        }
    }


    // toto bude pro ukázku námi zkoumana třída .. tuto třídu budeme zkoumat pomocí reflexe viz. třída výše.
    sealed class ZkoumanaTrida
    {
        public int prvni;
        private int druha;
        private List<string> pole1;

        
        public ZkoumanaTrida(int i, int b)
        {
            prvni = i;
            druha = b;
            pole1 = new List<string> { "asdf", "asdf", "fdas", "fdsa" };


        }
        public int TestMetoda()
        {
            return prvni + druha ;
        }

    }


}
