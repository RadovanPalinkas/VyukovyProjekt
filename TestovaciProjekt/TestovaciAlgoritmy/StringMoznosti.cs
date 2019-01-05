using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class StringMoznosti
    {
        string nejakyString = "  mujString  ";
        string nejakyStringDva = "mujstring";
        string dlouhyString = "Pes,Kočka,Pták,Králík,Prase";
        public void Vykonej()
        {
            //porovnání stringu nebere ohledy na key sensitive
            bool bl = nejakyString.Equals(nejakyStringDva, StringComparison.CurrentCultureIgnoreCase);            
            //délka stringu
            int delka = nejakyString.Length;
            //vrátí jeden znak na indexu 4
            char ch = nejakyString[4];
            //vrátí část stringu
            string stOne = nejakyString.Substring(1, 3);
            //převede string na malá nebo velká písmena 
            string stTwo = nejakyString.ToLower();
            string stTree = nejakyString.ToUpper();
            //vyprázdní string 
            nejakyStringDva = string.Empty;
            //kontrola jestli je string empty nebo null
            bool blTwo = string.IsNullOrEmpty(nejakyStringDva);
            //ořízne počáteční nebo koncové mozery
            string stFour = nejakyString.Trim();
            //nahradí uvedenou část textu jinou
            string custom = nejakyString.Replace("muj", "tvuj");
            //rozdělí řetězec na pole
            string[] zvirata = dlouhyString.Split(',');
            //spojí pole do jednoho ratězce
            string joinedString = string.Join("#", zvirata);
        }
    }
}
