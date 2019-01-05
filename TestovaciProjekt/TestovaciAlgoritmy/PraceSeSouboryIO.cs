using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class PraceSeSouboryIO
    {
        CteniDatZeSouboru cdzs = new CteniDatZeSouboru();
        VytvorySoubor cdzs2 = new VytvorySoubor();
        public void Vykonej()
        {
            string s = cdzs.CtiSoubor();
            cdzs2.VytvorSoubor();
        }
    }

    //čtení dat ze souboru
    public class CteniDatZeSouboru
    {
        public string CtiSoubor()
        {
            using (StreamReader sr = new StreamReader("ZdrojSouradnic.txt"))
            {
                string s = sr.ReadToEnd();
                return s;
            }

        }
    }
    public class CteniTextZeSouboru
    {
        public void  CtiSoubor()
        {
            //horší způsob
            string text = File.ReadAllText("ZdrojSouradnic.txt");
            Console.WriteLine(text);
            //lepší způsob
            string[] lines = File.ReadAllLines("ZdrojSouradnic.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
    public class VytvorySoubor
    {

        public void VytvorSoubor()
        {
            //zpusob 1 ne moc hezký
            using (FileStream fs = File.Create("CreatedByFile.txt"))
            {
                Byte[] bt = new UTF8Encoding(true).GetBytes("todle je soubor pro losery");
                fs.Write(bt, 0, bt.Length);
            }
            //zpusob 2 lepší
            File.Create("CreatedByFile.txt");
            byte[] byty = new UTF8Encoding(true).GetBytes("ahoj sraci");
            File.WriteAllBytes("CreatedByFile.txt", byty);
        }
    }

   
    public class ZapisTextDoSouboru
    {
        string text = "This is now the new information.";
        string[] lines = { "line1", "line2", "line3", "line4", "line5" };
        public void ZapisText()
        {
            //zpusob1
            File.WriteAllText("CreatedByFile.txt", text);
            //zpusob2 
            File.WriteAllLines("CreatedByFile.txt", lines);
        }
       

        
    }

}
