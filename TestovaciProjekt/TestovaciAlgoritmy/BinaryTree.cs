using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    class BinaryTree
    {
    }

    class Tree
    {
        Node top;

        public Tree()
        {
            top = null;
        }
        
        public Tree (int initial)
        {
            top = new Node(initial);
        }

        public void Add (int value)
        {
            //non-recurse add
            if (top == null)
            {
                top = new Node(value);
                return;
            }
        }
        public void AddRc(int value)
        {
            //recurse add  --- bude volána na úplně první uzel
            AddR(ref top, value);
        }
        private void AddR(ref Node N , int value)
        {
            //private recursive search for where to add the new node
        }

        public void Print (ref string newstring)
        {
            //write out the tree in sorted order to the string nestring 
            //implement using recursion

        }

    }

    class Node
    {
        public int value;
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int initial)
        {
            value = initial;
            Left = null;
            Right = null;
        }
    }
}
