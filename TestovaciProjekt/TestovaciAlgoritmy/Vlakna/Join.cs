using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//hlavní vlákno počká než se vykoná uvedené vlakno a pak teprve bude moci pokračovat
namespace TestovaciAlgoritmy.Vlakna
{
    public class Join
    {
        public Thread th; 
        public void Vykone()
        {
            th  = new Thread(Zpracuj);
            th.IsBackground = true;
            th.Start();
        }

        void Zpracuj()
        {
            int i = 0;
            while ( i < 5000)
            {
                Console.WriteLine("ahoj");
                i++;
            }
        }
    }
}
