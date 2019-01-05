using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestovaciAlgoritmy.Serializace
{
    public class SerializaceJSON
    {
        Studen student = new Studen(5, "Radovan", "Palinkáš", Studen.Predmet.Dějepis, Studen.Predmet.Hudebka, Studen.Predmet.Přírodopis);


        public void VykonejSerializaceJSON()
        {
            string serialized = JsonConvert.SerializeObject(student);

            File.WriteAllText(@"MojeSlozka\serializaceJSON.json", serialized);
            Console.WriteLine("Serializováno: " + serialized);
            Console.ReadKey();
        }
        public void VykonejDeserializaceJSON()
        {

            string deserialized = File.ReadAllText(@"MojeSlozka\serializaceJSON.json");
            Studen student = JsonConvert.DeserializeObject<Studen>(deserialized);
            string rozvrh = "ROZVRH:";
            foreach (var sp in student.rozvrh)
            {
                rozvrh += ", "+ sp;
            }
            Console.WriteLine($"Deserializovane: {student.ID} , {student.Jmeno} , {student.Prijmeni} , {rozvrh}");
            Console.ReadKey();
        }

    }

    public class Studen
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public List<Predmet> rozvrh = new List<Predmet>();

        public Studen()
        {
            //tento konstruktou tu musí v tomto příkladu být, protože při deserializaci je volán konstruktor. 
            //A my potřebujeme aby byl volán prázdný konstruktor místo našeho druhého konstruktoru níže.
        }
        public Studen(int id, string jm, string pr, params Predmet[] predm)
        {
            ID = id;
            Jmeno = jm;
            Prijmeni = pr;

            foreach (Predmet p in predm)
            {
                rozvrh.Add(p);
            }
        }

        [Flags]
        public enum Predmet : uint
        {
            NULL = 0x0,
            Čeština = 0x1,
            Němčina = 0x2,
            Matematika = 0x4,
            Dějepis = 0x8,
            Přírodopis = 0x10,
            Hudebka = 0x20,
            Tělocvik = 0x40
        }

    }




}
