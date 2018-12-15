using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace DataAccessTest
{
    public class PristupMySQL
    {

        private MySqlCommand dotaz;
        MySqlConnection con = new MySqlConnection("server = localhost; port = 3306; user id = root; password = sentinel; database = testovacidatabase; SslMode = none");



        public void OpenMySQLExucuteSelectFromClovek(string jmeno)
        {
            try
            {
                using (con)
                {//otevre pripojeni
                    con.Open();
                    dotaz = new MySqlCommand("select * from clovek where jmeno = '" + jmeno + "';", con);
                    var read = dotaz.ExecuteReader();
                    //zkontrojuje jestli je výsledek prázdný
                    if (read.HasRows)
                    {
                        //tento ciklus probehne tolikrát kolik je výsledných rádku. není možné přistupovat k prvkům v poli read dokud nebyla zavolána funkce Read()

                        while (read.Read())
                        {
                            Console.WriteLine(read[0]);
                            Console.WriteLine(read[1]);
                            Console.WriteLine(read[2]);
                            Console.WriteLine(read[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("nebyli nalezeny žádné záznamy");
                    }
                    
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("select problém MySql");
            }
        }

        public void OpenMySQLExucuteUpdateForClovek(string jmeno, string noveJmeno)
        {

            try
            {                
                using (con)
                {
                    con.Open();
                    dotaz = new MySqlCommand("update clovek set jmeno ='" + noveJmeno + "' where jmeno = '" + jmeno + "';", con);
                    var read = dotaz.ExecuteNonQuery();
                    Console.WriteLine(read);
                    
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("mysql");
            }
            catch (Exception)
            {
                Console.WriteLine("ex");
            }
        }
    }
}
