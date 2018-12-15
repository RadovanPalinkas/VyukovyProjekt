using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{

   



    public struct Struktura 
    {
        public int i;
        public int y;
        // struktury jsou uloženy  ve stacku, ne jako třídy které jsou na heapu. Není tedy pořeba vytvářet instance. Defaultně je nastavena na private. 
        //Nemůže dědit, ale může implementovat rozhraní
        //přez konstruktor musí být inicializovány všechny vlastnosti!!!!! 
        public Struktura(int i)
        {
            this.i = i;
            this.y = 0;
        }
        public Struktura(int i, int y) : this(i)
        {
            this.y = y;
        }

    }



}
