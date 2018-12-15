using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Definice: slovník je párová kolekce uchovávající hodnoty (klíč,hodnota)
namespace TestovaciAlgoritmy
{
    public class Slovnik
    {
        Dictionary<string, zakaznik> mujSlovnik = new Dictionary<string, zakaznik>();

        //vytvoří slovník který má "string" jako klíč a instanci zákazníka jako hodnotu
        public void Add()
        {
            mujSlovnik.Add("prvni", new zakaznik() {  jmeno = "Martin", prijmeni = "Palinkas", plat = 30000 });
            mujSlovnik.Add("druhy", new zakaznik() { jmeno = "Radovan", prijmeni = "Palinkas", plat = 30000 });
            mujSlovnik.Add("treti", new zakaznik() {  jmeno = "Tomas", prijmeni = "Palinkas", plat = 30000 });
            mujSlovnik.Add("ctvrty", new zakaznik() { jmeno = "Roman", prijmeni = "Palinkas", plat = 30000 });
            mujSlovnik.Add("paty", new zakaznik() {  jmeno = "Tonda", prijmeni = "Palinkas", plat = 30000 });
            mujSlovnik.Add("sesty", new zakaznik() { jmeno = "Kuba", prijmeni = "Palinkas", plat = 30000 });
        }

        public void Get()
        {
            //takto se prochází, je potřeba použít třídu KeyValuePair
            foreach (KeyValuePair<string, zakaznik> parHodnot in mujSlovnik)
            {
                Console.WriteLine($"{parHodnot.Key}: {parHodnot.Value.jmeno} {parHodnot.Value.prijmeni} {parHodnot.Value.plat}");
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------or------------------------------------------");
            //or
            if (mujSlovnik.ContainsKey("treti"))//  přístup přez klíč.. nejprve je potřeba zkontrolovat jestli hodnota existuje jinak vyhodí error
            {
                Console.WriteLine(mujSlovnik["treti"].jmeno + " " + mujSlovnik["treti"].prijmeni); 
            }
        }
        //klíče ve slovníku musí byt jedinečné, proto je dobré před přidáním položky do slovník zkontrolovat zda se klíč ve slovníku již neneachází, důvodem je to, že
        //pokud by se ve slovníku hodnota již nacházela tak nám při běhu aplikace hodí error.
        public void CheckKeyAndAdd(string key, zakaznik zak)
        {
            if (!mujSlovnik.ContainsKey(key))
            {
             mujSlovnik.Add(key, zak);
            }else
            {
                Console.WriteLine($"zákazník s tímto klíčem : ({key}) již existuje");
            }
        }
    }

    public class zakaznik
    {
    
        public string jmeno;
        public string prijmeni;
        public int plat;
    }
}
