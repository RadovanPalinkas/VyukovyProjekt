using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class PouzitiUsing
    {
        
        public void Zapis()
        {
            string[] pole = new string[] { "Row1", "Row2", "Row3" };
            using (System.IO.StreamWriter zaznamenej = new System.IO.StreamWriter(@"D:\Programovani\C# projekty\TestovaciProjekt\Log.txt"))
            {

                foreach (string s in pole)
                {
                    zaznamenej.WriteLine(s);
                }
            }

        }
    }
}
