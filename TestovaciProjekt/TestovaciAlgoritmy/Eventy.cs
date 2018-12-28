using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    //event vs delegate
    //An Event declaration adds a layer of abstraction and protection on the delegate instance.This protection prevents clients of the
    //delegate from resetting the delegate and its invocation list and only allows adding or removing targets from the invocation list.

    //V případě, že je zboží hotové, jsou upozorněni zaregistrovaní zákaznici.
    public class Eventy
    {
        public void Vykonej()
        {
            Console.ReadKey();
        }

    }


   
}
