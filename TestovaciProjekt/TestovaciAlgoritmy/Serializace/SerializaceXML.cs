using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;



namespace TestovaciAlgoritmy.Serializace
{
    public class SerializaceXML
    { 
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        [XmlAttribute]//uloží vlastnost v podobě attributu
        public int Vek { get; set; }

        public void Uloz(string nazevSouboru, string jm, string pr, int vek)
        {
            Jmeno = jm;
            Prijmeni = pr;
            Vek = vek;
           
            Directory.CreateDirectory(@"MojeSlozka");//vytvoří adresář ve složce "TestovaciPrajekt\Debug"

            using (FileStream fileStream = new FileStream($@"MojeSlozka\{nazevSouboru}", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializaceXML));
                xmlSerializer.Serialize(fileStream, this);
            }
        }
        public static SerializaceXML LoadFromFile(string nazevSouboru)
        {
            using (FileStream fileStream = new FileStream($@"MojeSlozka\{nazevSouboru}", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializaceXML));
                return (SerializaceXML)xmlSerializer.Deserialize(fileStream);
                
            }


        }

    }
}
