using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    class Fronta
    {
        public void Vykonej()
        {
            var fronta = new Queue<int>();
            fronta.Enqueue(5);
            fronta.Enqueue(4);
            fronta.Enqueue(3);
            fronta.Enqueue(2);
            fronta.Enqueue(1);

            fronta.Dequeue();
            IEnumerable<int> f = fronta.Reverse();
            Console.ReadKey();
        }

    }

}
