using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//mno zlatá xml serializace !!!!!
//Ukázka:   toto je ukázka jak bynárne serializovat do souboru dat



namespace TestovaciAlgoritmy.Serializace
{
    public class SerializaceBinary
    {



        public void VykonejSerializaci()
        {
            Animals seznamZvirat = new Animals();

            Stream stream = File.Open($@"MojeSlozka\serializaceBinary.dat", FileMode.Create);// otevře nebo vytvoří složku
            BinaryFormatter bf = new BinaryFormatter();//vytvoří objek pro serializaci a nacpe do něj stream a náš obějk který chceme serializovat.
            bf.Serialize(stream, seznamZvirat);
            stream.Close();

            Console.WriteLine("Byla provedena Serializace");
            Console.ReadKey();
        }
        public void VykonejDeserializaci()
        {

            Stream stream = File.Open($@"MojeSlozka\serializaceBinary.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            Animals seznamZvirat = (Animals)bf.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Byla provedena Deserializace");
            Console.WriteLine(seznamZvirat.NazevDokumentu);

            foreach (Animal an in seznamZvirat.listAnimals)
            {
                Console.WriteLine($"Zvire: {an.ID} , {an.Name}, {an.PocetNouhou}, {an.Vaha}");
            }
            Console.ReadKey();
        }
    }



    [Serializable()]
    public class Animals
    {
        public string NazevDokumentu { get; set; } = "Zvirata";

        public List<Animal> listAnimals = new List<Animal>()
        {
            new Animal() { ID = 1, Name = "Pes", PocetNouhou = 4, Vaha = 30 },
            new Animal() { ID = 2, Name = "Kocka", PocetNouhou = 4, Vaha = 4 },
            new Animal() { ID = 3, Name = "Krava", PocetNouhou = 4, Vaha = 800 },
            new Animal() { ID = 4, Name = "Zajíc", PocetNouhou = 4, Vaha = 2 }
        };
    }

    [Serializable()]
    public class Animal : ISerializable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PocetNouhou { get; set; }
        public double Vaha { get; set; }

        public Animal()
        {
        }

        //tento konstruktor a funkce jsou volitelné, pokud bychom tyto funkce vymazali aplikace by fungovala dál.. 
        //tento konstruktor a funkce zde jsou kuli extra hodnotám, které můžeme také s oběktem serializovat. V našem 
        //případě je to proměnná "Pohlaví" 
        public Animal(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue("ID", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            PocetNouhou = (int)info.GetValue("PocetNouhou", typeof(int));
            Vaha = (double)info.GetValue("Vaha", typeof(double));

            string Pohlavi = (string)info.GetValue("Pohlavi", typeof(string));// při deserializaci tuto hodnotu můžeme získat odtud....
           
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("Name", Name);
            info.AddValue("PocetNouhou", PocetNouhou);
            info.AddValue("Vaha", Vaha);
            info.AddValue("Pohlavi", "M");
        }

    }

}
