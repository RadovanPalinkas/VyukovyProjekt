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


    //toto je výchozí třída 
    public class Eventy
    {
        public void Vykonej()
        {
            Pole pole = new Pole();

            pole.udalostPridej += PridaneFCE.VypisInfoUdalosti;            
            pole.udalostOdeber += PridaneFCE.VypisInfoUdalosti;            

            pole.PridejAVypisCoByloPridano("jghf4j");
            pole.PridejAVypisCoByloPridano("jghasdff4j");
            pole.PridejAVypisCoByloPridano("adsf");
            pole.PridejAVypisCoByloPridano("fff");

            pole.OdeberAVypisCoByloOdebrano("jghasdff4j");

            foreach (string s in pole.pole)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }

    class Pole
    {
        public delegate void udalostPridejHandelr(object obj, uint flag); // deklarujeme delegata         
        public event udalostPridejHandelr udalostPridej; // vytvoříme událost která bude spravována naším delegátem
        public event udalostPridejHandelr udalostOdeber; // vytvoříme událost která bude spravována naším delegátem
        public ArrayList pole = new ArrayList();

        public void PridejAVypisCoByloPridano(object obje)
        {
            pole.Add(obje);
            OnPridej(obje, 0x1); // jak je vidět do této zavolané události se musí jako parametr vložit nějaký objek, protože jsme to definovali v delegátovi
        }      

        //Teto funkce slouží jako ošetření volání událost, protože pokud by nebyla událost nikde inicializována tak by hodila error
        private void OnPridej(object obj, uint flag)
        {
            udalostPridej?.Invoke(obj, flag);
            //řádek výše se rovná v podstatě podmínce níže 
            //      if (udalostPridej != null)
            //              udalostPridej(obj, flag);
        }

        public void OdeberAVypisCoByloOdebrano(string nazev)
        {
            pole.Remove(nazev);           
            OnOdeber(nazev, 0x2); 
        }        
        private void OnOdeber(object obj, uint flag)
        {
            udalostOdeber?.Invoke(obj, flag);           
        }
    }

    //toto je provizorní funkce kterou budeme chtít aby událost volala 
    class PridaneFCE
    {
        public static void VypisInfoUdalosti(object obj, uint flag)
        {
            switch (flag)
            {
                case 0x1:
                    Console.WriteLine("pridáno" + " " + obj);
                    break;
                case 0x2:
                    Console.WriteLine("odebrán prvek s indexem" + " " + obj);
                    break;
            }

        }
    }
}
