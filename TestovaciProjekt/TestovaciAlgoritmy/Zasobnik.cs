using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class Zasobnik
    {
        public void Vykonej()
        {
            Stack<int> st = new Stack<int>();

            st.Push(5);
            st.Push(4);
            st.Push(3);
            st.Push(2);
            st.Push(1);
           
            int i = st.Pop();
            st.Peek();
        }
    }
}
