using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // StringBuilder je umístěn v tomto jmenném prostoru
using System.Threading.Tasks;


//string je immutable(změna stringu znamená vytvoření nového objektu string na heapu a zahození starého)
//StringBuilder je mutable (to znamená, že pro změnu není třeba vytvářet na heapu nový objekt). Díky tomu má lepší vlastnosti a výkonnost než klasický string.
//použití je vhodné tam kde se hodně pracuje s textem.
namespace TestovaciAlgoritmy
{
    class StringBuilderUkazka
    {

        //string
        void UkazkaStringu()
        {
            string text = "To";
            text += "je";
            text += "ale";
            text += "krasny";
            text += "den";
        }
        //StringBuilder
        void UkazkaStringuBuilderu()
        {
            StringBuilder text = new StringBuilder("To");
            text.Append("je");
            text.Append("ale");
            text.Append("krasny");
            text.Append("den");
        }
    }
}
