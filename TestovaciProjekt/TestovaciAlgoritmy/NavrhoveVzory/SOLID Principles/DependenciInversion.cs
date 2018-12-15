using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//DEF: nemělo by se programovat proti konkrétní implementaci ale proti abstrakci.
namespace TestovaciAlgoritmy.NavrhoveVzory.SOLID_Principles
{
    interface IPomocnaTrida
    {
        void Vykonej();      
    }
    class PomocnaTrida : IPomocnaTrida
    {
        public void Vykonej()
        {
            //něco
        }
    }


    //špatně
    class DependenciInversionSpatne
    {
        public DependenciInversionSpatne(PomocnaTrida pt) //závislost na konkrétní třídě
        {
        }
    }
    //spravne
    class DependenciInversionSpravne
    {
        public DependenciInversionSpravne(IPomocnaTrida pt) //závislost na Interfacu
        {

        }
    }


}
