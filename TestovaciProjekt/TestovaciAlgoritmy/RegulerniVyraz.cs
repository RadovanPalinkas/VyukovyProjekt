using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class RegulerniVyraz
    {
        //        . = značí libovolný znak
        //        $ = retězec musí končit
        //        ^ = retězec musí začínat
        //        {}= množství znaků
        //        {,}= množství znaků "rozsah"
        //        []= výčet možných znaků
        //        ()= uzavre jako celek
        //        | =
        //        \ = eskapuje znak s kontextem abychom ho mohli použít takže např  \. nyní tečna nemá význam a je pouhý znak    
        //        * = 0 až N znaků
        //        + = 1 až N znaků
        //        ? =
        //        \s = mezera

        public void vykonej()
        {
            string item = "+12.45353477 +38.44444444";
            string pattern = @"^(\s|\t)*[-+]?([0-9]{1})?([0-9]{1})(\.[0-9]{1,8})?(\s|\t)+[-+]?([0-9]{1})?([0-9]{1})(\.[0-9]{1,8})?(\s|\t)*$";
            bool vysledek =  Regex.IsMatch(item,pattern);

            Console.WriteLine(vysledek);
            Console.ReadKey();
        }
    }
}
