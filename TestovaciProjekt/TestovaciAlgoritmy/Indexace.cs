using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//indexace znamená že ke třídě přistupuji jako k poli .. přez indexy
namespace TestovaciAlgoritmy
{   //příklad jedna 
    public class Indexace 
    {
        public  string [] pole = new string[10];

        public string this[int i]
        {
            get { return pole[i]; }
            set { pole[i] = value; }
        }    
        
        
    }
    //pžíklad dva
    public class IndexaceTwo
    {
        public string Str { get; set; }

        public IndexaceTwo[] poleTwo = new IndexaceTwo[10];

        public IndexaceTwo this[int i]
        {
            get { return poleTwo[i]; }
            set { poleTwo[i] = value;}
        }
    }
}
