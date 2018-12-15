using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class FlagyABitoveOperatory
    {
        public void vykonejBitoveOperatory()
        {
            BitoveOperatory bo = new BitoveOperatory();
            bo.UkazkaOperatoru();
        }

        public void vykonejVyctoveTypyAFlagy()
        {
            VyctoveTypyAFlagy vtaf = new VyctoveTypyAFlagy();
            vtaf.UkazkaFlagu();
        }
    }

    class VyctoveTypyAFlagy
    {

        public void UkazkaFlagu()
        {
            Zvirata zv; //vytvoreni kontejneru zv
            zv = Zvirata.Kocka | Zvirata.Tigr;

            //zkontrolování obsahu možnost 1
            if (!zv.HasFlag(Zvirata.Ryba))//
            {
                zv |= Zvirata.Ryba;
            }

            //zkontrolování obsahu možnost 2
            if ((zv & Zvirata.Ryba) == Zvirata.Ryba) // závorky jsou povinné protože == má větší prioritu.
            {
                Console.WriteLine("je ryba");
            }

            //odebrání 
            zv ^= Zvirata.Ryba;

            Console.WriteLine(zv);
        }

        [Flags]//pokud by zde nebyl atribut flak, tak by nám funkce UkazkaFlagu pouze sečetla hodnoty Kocky + Tigr tedy 0x1 a 0x10 = 1+16=17
        public enum Zvirata : uint
        {
            NULL = 0x0,
            Kocka = 0x1,
            Pes = 0x2,
            Ptak = 0x4,
            Ryba = 0x8,
            Tigr = 0x10,
            Medved = 0x20
        }
    }

    class BitoveOperatory
    {
        // |
        // &
        // ^
        // ~
        // >>
        // <<

        public void UkazkaOperatoru()
        {   //pro (bool)
            bool? vysledek = null;

            vysledek = false | true; // (aspoň jedna hodnota musí být "true") aby by vysledek true.
            vysledek = true & true; // (obě hodnoty musí být "true") aby byl výsledek true.
            vysledek = true ^ true; // (právě jedna hodnota musí být "true") aby byl výsledek true.

            //Dec -> Hex -> Bin
            //36  -> 24  -> 100100
            //26  -> 1A  -> 011010

            //pro (čísla)
            int cislo = 36 | 26; //alespon jedna musí být 1 
            //100100
            //011010
            //111110=> 62 
            cislo = 36 & 26; //obě musí být 1
            //100100
            //011010
            //000000=> 0   
            cislo = 36 ^ 26;//právě jedna hodnota musí být 1
            //100100
            //011010
            //111110 = 62
            cislo = 36 >> 1;
            //36 / 2^n        (n) je počet posunů v levo nebo v pravo, v našem případě (1)
            //100100 -> 010010 = 18
            //Další vysvětlení- V podstatě se jedná o dělení 2, z toho vyplývá co posun to dělení výsledku dvěma
            //př. 36 >> 3  znamená  36/2 = 18 a 18/2 = 9 a 9/2 = 4,5 výsledná hodnota je 4,5.
            cislo = 36 << 3;
            //36 * 2^n      
            //100100 -> 1001000 = 72
            //Další vysvětlení- V podstatě se jedná o násobení 2, z toho vyplývá co posun to násobení výsledku dvěma
            //př. 36 << 3  znamená  36*2 = 72 a 72*2 = 144 a 144*2 = 288 výsledná hodnota je 288.
            //----------------------------------------------------------------------------------------------------------
            //To samé v (Hex)
            cislo = 0x24 | 0x1A; //alespon jedna musí být 1
            //100100
            //011010
            //111110=> 62 
            cislo = 0x24 & 0x1A; //obě musí být 1
            //100100
            //011010
            //000000=> 0   
            cislo = 0x24 ^ 0x1A;//právě jedna hodnota musí být 1
            //100100
            //011010
            //111110 = 62
            cislo = 0x24 >> 1;
            //0x24 / 2^n        (n) je počet posunů v levo nebo v pravo, v našem případě (1)
            //100100 -> 010010 = 18
            cislo = 0x24 << 1;
            //0x24 * 2^n      
            //100100 -> 1001000 = 72
            cislo = ~0x24;
            // vysledek je -36-1 = -37 z nějakého nespecifikovaného důvodu ojedna menší



            //---------------------------------Dulezite Pro Flagy (sčítání a odčítání)----------------
            cislo = 64 | 16 | 2; // = 82  (sčítání, přiřazení)               
            int xx = cislo ^ 16; // (odčítání, odebrání) 
            int ff = cislo & 64; // (vytažení hodnoty)

            //Podmínky použití !!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
            //Toto sčátání a odčítaní funguje tak jak má pouze pokud jsou naše číslo násobky dvou, takže 
            //například (1 , 2, 4 ,8, 16, 32, 64 ...).
            //Také můžeme od čísla odečítat pouze čísla, které jsme tam přičetly nebo jejich součet.
            //V našem případe 16 + 2 = 18, toto však u flagů nevyužijeme, u flagů budeme používat pouze 
            //tento zápis při odečítání
            //xx = cislo ^ 16 ^ 2;

            //To samé pro platí pro (Hex)
            cislo = 0x40 | 0x10 | 0x2; // cislo = 82  (sčítání)               
            int yy = cislo ^ 0x10; // yy = 66(odčítání) 
            int gg = cislo & 0x10; // gg = 16 (vytažení hodnoty) 

            //Podmínky použití !!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
            //Toto sčátání a odčítaní funguje tak jak má pouze pokud jsou naše hodnoty v desítkové soustavě násobky dvou, takže 
            //například (1 , 2, 4 ,8, 16, 32, 64 ...). pro Hex (0x1, 0x2 ,0x4, 0x8, 0x10, 0x20, 0x40, 0x80 .......)
            //Také můžeme od čísla odečítat pouze čísla, které jsme tam přičetly nebo jejich součet.
            //V našem případe 0x10 + 0x2 = 12 "hex 12 = dec 18", toto však u flagů nevyužijeme, u flagů budeme používat pouze 
            //tento zápis při odečítání 
            //xx = cislo ^ 0x10 ^ 0x2;
            //---------------------------------Dulezite Pro Flagy-------------------------------

        }
    }
}
